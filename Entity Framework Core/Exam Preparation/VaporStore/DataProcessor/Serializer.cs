﻿using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		// JSON
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var data = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
            {
                Id = x.Id,
                Genre = x.Name,
                Games = x.Games
                    .Select(g => new
                {
                    Id = g.Id,
                    Title = g.Name,
                    Developer = g.Developer.Name,
                    Tags = string.Join(", ", g.GameTags
                        .Select(t => t.Tag.Name)),
                    Players = g.Purchases.Count(),
                })
                    .Where(gm => gm.Players > 0)
                    .OrderByDescending(g=>g.Players)
                    .ThenBy(g => g.Id),
                TotalPlayers = x.Games.Sum(game => game.Purchases.Count),
            })
                .OrderByDescending(x=>x.TotalPlayers)
                .ThenBy(x=>x.Id);

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

		//XML
		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {

            var data = context.Users.ToList().Where(x => x.Cards.Any(x => x.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(x => new UserXmlExportModel
                {
                    Username = x.Username,
                    TotalSpent = x.Cards
                        .Sum(x => x.Purchases
                            .Where(p => p.Type.ToString() == storeType)
                            .Sum(p => p.Game.Price)),
                    Purchases = x.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p=> p.Type.ToString() == storeType)
                        .Select(p => new PurchaseXmlExportModel
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameXmlExportModel
                        {
                            Title = p.Game.Name,
                            Price = p.Game.Price,
                            Genre = p.Game.Genre.Name,
                        },
                    })
                        .OrderBy(x => x.Date)
                        .ToArray()
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(UserXmlExportModel[]), new XmlRootAttribute("Users"));

            var sw = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(sw, data, ns);

            return sw.ToString();
		}
	}
}