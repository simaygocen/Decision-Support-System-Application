# Self Organizing Map (SOM) - Decision Support System

This project implements a Decision Support System (DSS) using the Self Organizing Map (SOM) algorithm. The SOM is a type of artificial neural network used for unsupervised learning and data clustering. The project converts the C# implementation of the SOM algorithm into a desktop application for easier interaction.

## Features

- **Data Clustering**: The SOM algorithm is used to cluster input data based on their similarity.
- **Data Normalization**: The input data is normalized to ensure effective training.
- **Training the Map**: The model uses a competitive learning process to adjust the weights of the neurons in the grid.
- **SSE Calculation**: The model calculates the Sum of Squared Errors (SSE) to assess the accuracy of clustering.
- **Desktop Application**: The application is built with a Windows Forms interface for easy interaction.

## Usage

1. **Input Data**: The application reads input data from a CSV file, where each row consists of data values followed by a label.
2. **Normalization**: The data is normalized before being used to train the SOM.
3. **Training**: The SOM is trained using the normalized data.
4. **Results**: The coordinates of each data point in the SOM grid are displayed, along with their clustering results.

## Code Structure

- **Map Class**: Handles the initialization, training, and evaluation of the SOM.
- **Neuron Class**: Represents the neurons in the SOM grid, including the weight updates and distance calculations.
- **Form1**: The main Windows Forms interface that interacts with the SOM.
  
## Screenshots of Application

![goruntu1](https://github.com/user-attachments/assets/ea9581df-20a4-4c17-bd5d-fda80327e1b4)
![goruntu2](https://github.com/user-attachments/assets/ca70586c-f220-456e-b29b-241bf9760d3e)
![goruntu3](https://github.com/user-attachments/assets/595847ca-599f-4f69-9cf3-584bfbfa5520)


## Requirements

- .NET Framework (version)
- Windows OS

## Installation

1. Clone the repository or download the project files.
2. Open the solution file (`.sln`) in Visual Studio.
3. Build and run the application.

## License

This project is licensed under the MIT License - see the LICENSE file for details.



