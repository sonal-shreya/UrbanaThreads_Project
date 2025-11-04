document.addEventListener("DOMContentLoaded", () => {

    const categoryFilter = document.getElementById("filterCategory");

    let chartInventory, chartProductStock, chartInventoryValue;

    // ✅ Load category filter dropdown
    async function loadCategoryFilter() {
        const res = await fetch("/Dashboard/GetCategories");
        const data = await res.json();

        categoryFilter.innerHTML =
            `<option value="all">All</option>` +
            data.map(c => `<option value="${c}">${c}</option>`).join("");
    }

    // ✅ Inventory by Category (Pie Chart)
    async function loadInventoryDistribution() {
        const res = await fetch("/Dashboard/InventoryDistribution");
        const data = await res.json();

        const labels = data.map(x => x.category);
        const stocks = data.map(x => x.stock);

        const ctx = document.getElementById("inventoryDistribution");

        if (chartInventory) chartInventory.destroy();

        chartInventory = new Chart(ctx, {
            type: "pie",
            data: {
                labels,
                datasets: [{
                    data: stocks,
                    backgroundColor: ["#4BC0C0", "#FF6384", "#FFCD56", "#36A2EB"]
                }]
            },
            options: { responsive: true }
        });
    }

    // ✅ Stock by Product (Bar Chart)
    async function loadStockByProduct() {
        const category = categoryFilter?.value || "all";
        const res = await fetch(`/Dashboard/StockByProduct?category=${category}`);
        const data = await res.json();

        const labels = data.map(x => x.name);
        const values = data.map(x => x.stock);

        const ctx = document.getElementById("stockByProduct");

        if (chartProductStock) chartProductStock.destroy();

        chartProductStock = new Chart(ctx, {
            type: "bar",
            data: {
                labels,
                datasets: [{
                    label: "Stock",
                    data: values,
                    backgroundColor: "rgba(54, 162, 235, 0.5)",
                    borderColor: "rgb(54, 162, 235)",
                    borderWidth: 2
                }]
            },
            options: {
                responsive: true,
                scales: { y: { beginAtZero: true } }
            }
        });
    }

    // ✅ Inventory Value by Category (Bar Chart)
    async function loadInventoryValue() {
        const category = categoryFilter?.value || "all";
        const res = await fetch(`/Dashboard/SalesByCategory?category=${category}`);
        const data = await res.json();

        const labels = data.map(x => x.category);
        const values = data.map(x => x.value);

        const ctx = document.getElementById("inventoryValue");

        if (chartInventoryValue) chartInventoryValue.destroy();

        chartInventoryValue = new Chart(ctx, {
            type: "bar",
            data: {
                labels,
                datasets: [{
                    label: "Inventory Value ($)",
                    data: values,
                    backgroundColor: "rgba(75, 192, 192, 0.5)",
                    borderColor: "rgb(75, 192, 192)",
                    borderWidth: 2
                }]
            },
            options: {
                responsive: true,
                scales: { y: { beginAtZero: true } }
            }
        });
    }

    // ✅ Load Low Stock Items
    async function loadLowStockList() {
        const res = await fetch("/Dashboard/LowStockProducts");
        const data = await res.json();

        const container = document.getElementById("lowStockList");

        if (!data.length) {
            container.innerHTML = "<li class='list-group-item'>✅ No low stock products.</li>";
            return;
        }

        container.innerHTML = data
            .map(i => `<li class='list-group-item'>${i.name} — <b>${i.stock}</b> left (min: ${i.reorderLevel})</li>`)
            .join("");
    }


    let monthlyChart, topProductChart;

    // ---- Monthly Sales Trend ----
    async function loadMonthlySales() {
        const res = await fetch("/Dashboard/MonthlySalesTrend");
        const data = await res.json();

        const labels = data.map(x => x.month);
        const values = data.map(x => x.total);

        if (monthlyChart) monthlyChart.destroy();

        monthlyChart = new Chart(document.getElementById("monthlySales"), {
            type: "line",
            data: {
                labels,
                datasets: [{
                    label: "Sales ($)",
                    data: values,
                    borderWidth: 2,
                    borderColor: "#28e0b9",
                    fill: false,
                    tension: 0.3
                }]
            }
        });
    }

    // ---- Top Selling Products ----
    async function loadTopProducts() {
        const res = await fetch("/Dashboard/TopSellingProducts");
        const data = await res.json();

        const labels = data.map(x => x.product);
        const values = data.map(x => x.quantity);

        if (topProductChart) topProductChart.destroy();

        topProductChart = new Chart(document.getElementById("topProducts"), {
            type: "bar",
            data: {
                labels,
                datasets: [{
                    label: "Units Sold",
                    data: values,
                    backgroundColor: "#36A2EB"
                }]
            }
        });
    }
  

    // ✅ Filter Button
    document.getElementById("applyFilters")?.addEventListener("click", () => {
        loadStockByProduct();
        loadInventoryValue();
    });

    // ✅ Initialize Dashboard
    async function init() {
        await loadCategoryFilter();
        loadInventoryDistribution();
        loadStockByProduct();
        loadInventoryValue();
        loadLowStockList();
        loadMonthlySales();
        loadTopProducts();
    }

    init();
});
