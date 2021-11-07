function calc() {
    var table = document.getElementById("table");
    var sum = 0;
    let lastRow = table.rows[table.rows.length - 1].cells[3];
    for (var i = 1; i < table.rows.length - 1; i++) {
        let row = table.rows[i];
        sum += Number(row.cells[1].innerText) * Number(row.cells[3].innerText);
    }
    lastRow.innerText = sum;
}

window.onload = function () {
    calc();
}