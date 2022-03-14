# 💻 Ewave Truck Catalog Test

[![Repo size](https://img.shields.io/github/repo-size/costaruan/ewave-truck-catalog-test)](https://github.com/costaruan/volume-hand-control/)
[![Languages](https://img.shields.io/github/languages/count/costaruan/ewave-truck-catalog-test)](https://github.com/costaruan/volume-hand-control/)
[![License](https://img.shields.io/github/license/costaruan/ewave-truck-catalog-test)](https://github.com/costaruan/volume-hand-control/blob/master/LICENSE.md)
[![Made by costaruan](https://img.shields.io/badge/made%20by-costaruan-green)](https://github.com/costaruan/volume-hand-control/)

The main objective of the test is to be able to perform operations to create, read, update and delete (CRUD) trucks and their main descriptive properties.

## 👨🏻‍💻 Project

The principal technologies applied in the development of this project were the following.

    . ASP.NET Core
    . Microsoft SQL Server Database
    . Entity Framework Core
    . Fluent Validation
    . xUnit

## ✅ Validation

Data validation is the process that ensures the delivery of clear and clean data to the programs, applications, and services that use it. Validation checks the integrity of the inserted data.

```csharp
RuleFor(truckModelName => truckModelName.ModelName)
    .Must(truckModelName => models.Contains(truckModelName))
    .WithMessage(string.Concat("Please, only use ", string.Join(" or ", models), " models."));

RuleFor(truckManufactureYear => truckManufactureYear.ManufactureYear)
    .Must(truckManufactureYear => truckManufactureYear == currentYear)
    .WithMessage("Please, use the current year.");

RuleFor(truckModelYear => truckModelYear.ModelYear)
    .Must(truckModelYear => modelYears.Contains(truckModelYear))
    .WithMessage(string.Concat("Please, only use ", string.Join(" or ", modelYears), " model years."));
```

## 💭 Tests

The xUnit library is a free, open source, community-focused unit testing tool for the .NET Framework.

### 👉🏻 CreateTruckTests

The creation of these tests is to validate and register Trucks in the database.

```csharp
[Fact]
public void ShouldCreateATruck_FH_2022_2022() {}

// This test creates a Truck with the following characteristics:
//     - Model Name: FH
//     - Manufacture Year: 2022
//     - Model Year: 2022
```

```csharp
[Fact]
public void ShouldCreateATruck_FH_2022_2023() {}

// This test creates a Truck with the following characteristics:
//     - Model Name: FH
//     - Manufacture Year: 2022
//     - Model Year: 2023
```

```csharp
[Fact]
public void ShouldCreateATruck_FM_2022_2022() {}

// This test creates a Truck with the following characteristics:
//     - Model Name: FM
//     - Manufacture Year: 2022
//     - Model Year: 2022
```

```csharp
[Fact]
public void ShouldCreateATruck_FM_2022_2023() {}

// This test creates a Truck with the following characteristics:
//     - Model Name: FM
//     - Manufacture Year: 2022
//     - Model Year: 2023
```

```csharp
[Fact]
public void ShouldNotCreateATruck_FXYZ_2025_2025() {}

// This test does not create a Truck because of the following characteristics:
//     - Model Name: FXYZ
//     - Manufacture Year: 2025
//     - Model Year: 2025
```

```csharp
[Fact]
public void ShouldNotCreateATruck_FXYZ_2022_2022() {}

// This test does not create a Truck because of the following characteristic:
//     - Model Name: FXYZ
```

```csharp
[Fact]
public void ShouldNotCreateATruck_FH_2025_2022() {}

// This test does not create a Truck because of the following characteristic:
//     - Manufacture Year: 2025
```

```csharp
[Fact]
public void ShouldNotCreateATruck_FH_2022_2025() {}

// This test does not create a Truck because of the following characteristic:
//     - Model Year: 2025
```

### 👉🏻 DeleteTruckTests

The creation of these tests is to validate and delete Trucks in the database.

```csharp
[Fact]
public void ShouldNotDeleteATruckWithInexistentId() {}

// This test does not delete a Truck because of the following characteristic:
//     - Inexistent ID
```

```csharp
[Fact]
public void ShouldDeleteATruckWithExistentId() {}

// This test deletes a Truck because of the following characteristic:
//     - Existent ID
```

### 👉🏻 GetAllTrucksTests

The creation of these tests is to validate and list Trucks in the database.

```csharp
[Fact]
public void ShouldReturnAnEmptyTruckList() {}

// This test should return an empty list of Trucks because of the following characteristic:
//     - Nothing saved on the database
```

```csharp
[Fact]
public void ShouldReturnATruckListWithFourTrucks() {}

// This test should return a list of Trucks with four items because of the following characteristic:
//     - Four Trucks were saved successfully on the database
```

### 👉🏻 UpdateTruckTests

The creation of these tests is to validate and update Trucks in the database.

```csharp
[Fact]
public void ShouldNotUpdateATruckWithInexistentId() {}

// This test does not update a Truck because of the following characteristic:
//     - Inexistent ID
```

```csharp
[Fact]
public void ShouldNotUpdateATruckWithAnWrongModelName() {}

// This test does not update a Truck because of the following characteristic:
//     - Model Name: FXYZ
```

```csharp
[Fact]
public void ShouldNotUpdateATruckWithAnWrongManufactureYear() {}

// This test does not update a Truck because of the following characteristic:
//     - Manufacture Year: 2025
```

```csharp
[Fact]
public void ShouldNotUpdateATruckWithAnWrongModelYear() {}

// This test does not update a Truck because of the following characteristic:
//     - Model Year: 2025
```

```csharp
[Fact]
public void ShouldUpdateATruckWithExistentId() {}

// This test updates a Truck with the following characteristics:
//     - Model Name: FH -> FM
//     - Manufacture Year: 2022 -> 2022
//     - Model Year: 2022 -> 2023
```

## 📝 Curriculum Vitae

Following is the link for the Curriculum Vitae in the video.

🔗 [Ewave & Volvo - Curriculum Vitae Video](https://youtu.be/3EvpCXXrKfM)

## 👦🏻 Created by [Ruan Costa](https://costaruan.dev/)

[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=FFFFFF)](https://github.com/costaruan/)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=FFFFFF)](https://www.linkedin.com/in/costaruan/)
