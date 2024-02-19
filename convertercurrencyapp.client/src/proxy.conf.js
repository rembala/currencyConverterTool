const PROXY_CONFIG = [
  {
    context: [
      "/currencyconverter",
    ],
    target: "https://localhost:7004",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
