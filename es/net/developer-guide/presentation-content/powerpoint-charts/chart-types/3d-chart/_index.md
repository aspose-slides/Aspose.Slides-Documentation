---
title: Gráfico 3D
type: docs
url: /es/net/3d-chart/
keywords: "gráfico 3d, rotationX, rotationY, depthpercent, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Establecer rotationX, rotationY y depthpercents para gráfico 3D en presentación de PowerPoint en C# o .NET"
---

## **Establecer propiedades RotationX, RotationY y DepthPercents del Gráfico 3D**
Aspose.Slides para .NET proporciona una API simple para establecer estas propiedades. Este artículo a continuación le ayudará a cómo establecer diferentes propiedades como Rotación X, Y, **DepthPercents**, etc. El código de muestra aplica el establecimiento de las propiedades mencionadas anteriormente.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Acceder a la primera diapositiva.
1. Añadir gráfico con datos predeterminados.
1. Establecer propiedades Rotation3D.
1. Escribir la presentación modificada en un archivo PPTX.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();
           
// Acceder a la primera diapositiva
ISlide slide = presentation.Slides[0];

// Añadir gráfico con datos predeterminados
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Establecer el índice de la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtener la hoja de trabajo de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Añadir series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

// Añadir categorías
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));

// Establecer propiedades Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Tomar la segunda serie del gráfico
IChartSeries series = chart.ChartData.Series[1];

// Ahora poblamos los datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Establecer el valor de OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Escribir presentación en disco
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```