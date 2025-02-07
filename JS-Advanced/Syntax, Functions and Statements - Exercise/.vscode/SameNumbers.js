function solve(number) {
    const string = number.toString();
    let isSame = true;
    let sum = 0;

    for (let i = 0; i < string.length; i++) {
        let curent = Number(string[i]);
        let next = string[i + 1];

        if (string[i] !== string[i + 1] && next !== undefined) {
            isSame = false;
        }
        
        sum += curent;
    }

    return `${isSame}\n${sum}`
}
console.log(solve(2222222));