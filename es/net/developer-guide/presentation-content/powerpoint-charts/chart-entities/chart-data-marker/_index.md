---
title: Marcador de Datos de Gráfico
type: docs
url: /es/net/chart-data-marker/
keywords:
- opciones de marcador de gráfico
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Establecer opciones de marcador de gráfico en presentaciones de PowerPoint en C# o .NET"
---

## **Establecer Opciones de Marcador de Gráfico**
Los marcadores se pueden establecer en puntos de datos de gráficos dentro de series particulares. Para establecer opciones de marcador de gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Tomar la primera serie de gráfico.
- Agregar un nuevo punto de datos.
- Escribir la presentación en disco.

En el ejemplo dado a continuación, hemos establecido las opciones de marcador de gráfico a nivel de puntos de datos.

```c#
// Crear una instancia de la clase Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Crear el gráfico predeterminado
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Obtener el índice de la hoja de datos de gráfico predeterminada
int defaultWorksheetIndex = 0;

// Obtener la hoja de datos de gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Eliminar las series de demostración
chart.ChartData.Series.Clear();

// Agregar nuevas series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);

// Establecer la imagen
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Establecer la imagen
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Tomar la primera serie de gráfico
IChartSeries series = chart.ChartData.Series[0];

// Agregar un nuevo punto (1:3) allí.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Cambiar el marcador de la serie de gráfico
series.Marker.Size = 15;

// Escribir la presentación en disco
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```