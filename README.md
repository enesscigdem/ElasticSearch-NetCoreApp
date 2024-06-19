# ElasticSearch-NetCoreApp

This project demonstrates the use of .NET Core 7.0 MVC with Elasticsearch and Tailwind CSS. The application is designed to handle large datasets efficiently, specifically working with over 1 million records. It also includes a separate application for seeding data into Elasticsearch.

<p align="center">
  <img src="https://github.com/enesscigdem/ElasticSearch-NetCoreApp/assets/55703841/112be522-d158-445c-b2ed-cb605638d622" alt="Screenshot 1" width="400">
  <img src="https://github.com/enesscigdem/ElasticSearch-NetCoreApp/assets/55703841/6588bd3c-d043-459d-8a7d-bdbc26fc2efa" alt="Screenshot 2" width="400">
</p>
## Table of Contents

- [Technologies Used](#technologies-used)
- [Installation and Setup](#installation-and-setup)
  - [Elasticsearch Installation](#elasticsearch-installation)
  - [Kibana Installation](#kibana-installation)
- [Project Structure](#project-structure)
- [Seeding Data](#seeding-data)
- [Working with Kibana](#working-with-kibana)
- [Features](#features)

## Technologies Used

- **.NET Core 7.0 MVC**: The main framework used for building the web application.
- **Elasticsearch**: A search engine used for efficient search and analytics.
- **Kibana**: An open-source data visualization and exploration tool used for working with Elasticsearch.
- **Tailwind CSS**: A utility-first CSS framework for styling the application.

## Installation and Setup

### Elasticsearch Installation

1. **Download and extract Elasticsearch**:
   - Download the latest version from the [official website](https://www.elastic.co/downloads/elasticsearch).
   - Extract the downloaded file.

2. **Run Elasticsearch**:
   ```sh
   cd elasticsearch-x.y.z
   ./bin/elasticsearch
   ```

### Kibana Installation

1. **Download and extract Kibana**:
   - Download the latest version from the [official website](https://www.elastic.co/downloads/kibana).
   - Extract the downloaded file.

2. **Run Kibana**:
   ```sh
   cd kibana-x.y.z
   ./bin/kibana
   ```

### Connecting Kibana to Elasticsearch

- Open Kibana in your browser at `http://localhost:5601`.
- Configure Kibana to connect to your Elasticsearch instance using the provided settings and credentials.

## Project Structure

The project consists of two main applications:

1. **MyElasticApp**: The main MVC application that interacts with Elasticsearch.
2. **ElasticAppSeedData**: A console application used for seeding data into Elasticsearch.

## Seeding Data

To handle large datasets, we use a separate application for seeding data. This approach ensures that the main application remains performant and responsive.

1. **Run the seed data application**:
   ```sh
   dotnet run --project ElasticAppSeedData
   ```

2. **Verify data in Elasticsearch**:
   - Open Kibana.
   - Navigate to the `Discover` tab.
   - Verify that the data has been indexed correctly.

## Working with Kibana

Kibana provides a powerful interface for working with data in Elasticsearch. Here's a quick guide:

1. **Create a Data View**:
   - Open Kibana at `http://localhost:5601`.
   - Navigate to the `Management` tab.
   - Create a new data view for the `products` index.

2. **Explore Data**:
   - Use the `Discover` tab to search and analyze data.
   - Create visualizations and dashboards for more insights.

## Features

- **Dark Mode with Tailwind CSS**: The application features a dark mode design, enhancing the user experience.
- **Search Functionality**: Efficiently search through a large dataset using Elasticsearch.
- **Responsive UI**: The application is styled with Tailwind CSS for a modern and responsive user interface.
- **Large Dataset Handling**: Efficiently handle and display over 1 million records.

## Additional Notes

- Ensure that both Elasticsearch and Kibana are running before starting the main application.
- Tailwind CSS is used for styling the application, providing a clean and modern look.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
