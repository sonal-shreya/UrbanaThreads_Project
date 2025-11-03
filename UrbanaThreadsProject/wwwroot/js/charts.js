// charts.js

// Chart 1: Sales by Category
new Chart(document.getElementById('salesByCategory'), {
  type: 'bar',
  data: {
    labels: ['Tops', 'Jeans', 'Jackets', 'Dresses', 'Shoes', 'Accessories'],
    datasets: [{
      label: 'Sales ($)',
      data: [42000, 36000, 27000, 31000, 22000, 18000],
      backgroundColor: '#28e0b9'
    }]
  },
  options: { responsive: true, plugins: { legend: { display: false } } }
});

// Chart 2: Monthly Sales Trend
new Chart(document.getElementById('monthlySalesTrend'), {
  type: 'line',
  data: {
    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
    datasets: [{
      label: 'Sales ($)',
      data: [15000, 18000, 21000, 26000, 31000, 35000],
      borderColor: '#7c5cff',
      tension: 0.4,
      fill: false
    }]
  },
  options: { responsive: true }
});

// Chart 3: Inventory Distribution
new Chart(document.getElementById('inventoryDistribution'), {
  type: 'pie',
  data: {
    labels: ['Urban Basics', 'EcoActive', 'Smart Streetwear'],
    datasets: [{
      data: [45, 30, 25],
      backgroundColor: ['#28e0b9', '#7c5cff', '#f2c6a0']
    }]
  },
  options: { responsive: true }
});

// Chart 4: Sales by Region
new Chart(document.getElementById('salesByRegion'), {
  type: 'bar',
  data: {
    labels: ['New York', 'Los Angeles', 'Miami', 'Chicago', 'Dallas'],
    datasets: [{
      label: 'Revenue ($)',
      data: [32000, 28000, 21000, 25000, 19000],
      backgroundColor: '#f2c6a0'
    }]
  },
  options: { responsive: true, plugins: { legend: { display: false } } }
});

// Chart 5: Customer Demographics
new Chart(document.getElementById('customerDemographics'), {
  type: 'doughnut',
  data: {
    labels: ['18-25', '26-35', '36-50', '50+'],
    datasets: [{
      data: [40, 35, 20, 5],
      backgroundColor: ['#28e0b9', '#7c5cff', '#f2c6a0', '#c9a6b9']
    }]
  },
  options: { responsive: true }
});

// Chart 6: Weekly Traffic
new Chart(document.getElementById('weeklyTraffic'), {
  type: 'line',
  data: {
    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
    datasets: [{
      label: 'Visitors',
      data: [400, 500, 700, 650, 800, 1200, 900],
      borderColor: '#28e0b9',
      backgroundColor: 'rgba(40, 224, 185, 0.2)',
      fill: true,
      tension: 0.4
    }]
  },
  options: { responsive: true }
});

