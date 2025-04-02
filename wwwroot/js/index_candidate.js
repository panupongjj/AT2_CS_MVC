document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("searchInput")?.addEventListener("keyup", filterTable);
});

function filterTable() {
    let input = document.getElementById("searchInput").value.toLowerCase();
    let table = document.getElementById("dataTable");
    let rows = table.getElementsByTagName("tr");

    for (let i = 1; i < rows.length; i++) { // Skip header row
        let row = rows[i];
        let name = row.getElementsByTagName("td")[0]?.textContent.toLowerCase();
        let university = row.getElementsByTagName("td")[3]?.textContent.toLowerCase(); // University column index 3

        if (name.includes(input) || university.includes(input)) {
            row.style.display = "";
        } else {
            row.style.display = "none";
        }
    }
}

function sortTable(columnIndex) {
    let table = document.getElementById("dataTable");
    let rows = Array.from(table.rows).slice(1); // Exclude header row
    let ascending = table.getAttribute("data-sort-asc") === "true";

    rows.sort((a, b) => {
        let cellA = a.cells[columnIndex].textContent.trim();
        let cellB = b.cells[columnIndex].textContent.trim();

        if (!isNaN(cellA) && !isNaN(cellB)) {
            return ascending ? cellA - cellB : cellB - cellA;
        }
        return ascending ? cellA.localeCompare(cellB) : cellB.localeCompare(cellA);
    });

    table.setAttribute("data-sort-asc", !ascending); // Toggle sorting direction
    rows.forEach(row => table.appendChild(row));
}