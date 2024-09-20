---
title: 3D График
type: docs
url: /net/3d-chart/
keywords: "3d график, rotationX, rotationY, depthpercent, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Установите rotationX, rotationY и depthpercents для 3D графика в презентации PowerPoint на C# или .NET"
---

## **Установка свойств RotationX, RotationY и DepthPercents для 3D Графика**
Aspose.Slides для .NET предоставляет простой API для установки этих свойств. Следующая статья поможет вам установить различные свойства, такие как X,Y Ротация, **DepthPercents** и др. Пример кода применяет установки вышеперечисленных свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите первый слайд.
1. Добавьте график с умолчательными данными.
1. Установите свойства Rotation3D.
1. Запишите измененную презентацию в файл PPTX.

```c#
// Создание экземпляра класса Presentation
Presentation presentation = new Presentation();
           
// Получение первого слайда
ISlide slide = presentation.Slides[0];

// Добавление графика с умолчательными данными
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Установка индекса листа данных графика
int defaultWorksheetIndex = 0;

// Получение рабочего листа данных графика
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Добавление серий
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.Type);

// Добавление категорий
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Категория 3"));

// Установка свойств Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Получение второй серии графика
IChartSeries series = chart.ChartData.Series[1];

// Теперь заполняем данные серии
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Установка значения OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Запись презентации на диск
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```