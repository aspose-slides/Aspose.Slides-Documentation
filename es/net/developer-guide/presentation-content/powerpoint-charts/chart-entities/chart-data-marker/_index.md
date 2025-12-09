---
title: Administrar marcadores de datos de gráficos en presentaciones en .NET
linktitle: Marcador de datos
type: docs
url: /es/net/chart-data-marker/
keywords:
- gráfico
- punto de datos
- marcador
- opciones de marcador
- tamaño del marcador
- tipo de relleno
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo personalizar los marcadores de datos de gráficos en Aspose.Slides para .NET, mejorando el impacto de las presentaciones en formatos PPT y PPTX con ejemplos claros de código en C#."
---

## **Establecer opciones de marcador de gráfico**
Los marcadores pueden establecerse en los puntos de datos del gráfico dentro de series específicas. Para establecer opciones de marcador de gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Obtener la primera serie del gráfico.
- Agregar un nuevo punto de datos.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos establecido las opciones de marcador del gráfico a nivel de puntos de datos.
```c#
// Crear una instancia de la clase Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Obtener el índice de la hoja de cálculo de datos del gráfico predeterminada
int defaultWorksheetIndex = 0;

// Obtener la hoja de cálculo de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Eliminar series de demostración
chart.ChartData.Series.Clear();

// Agregar nueva serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Establecer la imagen
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Establecer la imagen
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Tomar la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

// Agregar nuevo punto (1:3) allí.
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

// Cambiar el marcador de la serie del gráfico
series.Marker.Size = 15;

// Guardar la presentación en disco
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Qué formas de marcador están disponibles de forma predeterminada?**

Hay formas estándar disponibles (círculo, cuadrado, diamante, triángulo, etc.); la lista está definida por la enumeración [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/). Si necesita una forma no estándar, utilice un marcador con un relleno de imagen para emular visuales personalizados.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**

Sí. Al renderizar gráficos a [formatos raster](/slides/es/net/convert-powerpoint-to-png/) o guardar [formas como SVG](/slides/es/net/render-a-slide-as-an-svg-image/), los marcadores conservan su apariencia y configuración, incluido el tamaño, el relleno y el contorno.