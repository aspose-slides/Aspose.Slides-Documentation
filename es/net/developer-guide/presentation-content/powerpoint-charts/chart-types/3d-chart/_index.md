---
title: Personalizar gráficos 3D en presentaciones en .NET
linktitle: Gráfico 3D
type: docs
url: /es/net/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos 3-D en Aspose.Slides para .NET, con soporte para archivos PPT y PPTX — mejore sus presentaciones hoy."
---

## **Establecer las propiedades RotationX, RotationY y DepthPercents del gráfico 3D**
Aspose.Slides for .NET proporciona una API sencilla para establecer estas propiedades. El siguiente artículo le ayudará a configurar diferentes propiedades como Rotación X,Y, **DepthPercents**, etc. El código de ejemplo aplica la configuración de dichas propiedades.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Acceda a la primera diapositiva.
3. Agregue un gráfico con datos predeterminados.
4. Establezca las propiedades Rotation3D.
5. Guarde la presentación modificada en un archivo PPTX.
```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();
           
// Acceder a la primera diapositiva
ISlide slide = presentation.Slides[0];

// Añadir un gráfico con datos predeterminados
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Establecer el índice de la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtener la hoja de cálculo de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Añadir series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Añadir categorías
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Establecer propiedades de Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Tomar la segunda serie del gráfico
IChartSeries series = chart.ChartData.Series[1];

// Ahora rellenando los datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Establecer valor de OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Guardar la presentación en disco
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Qué tipos de gráficos admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100% Stacked Column 3D, junto con tipos 3D relacionados expuestos a través de la enumeración [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) en la referencia de API de la versión que tiene instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen mediante la [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o [renderizar toda la diapositiva](/slides/es/net/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa pixel-perfect o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trama, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) que coincida con la pantalla objetivo o las necesidades de impresión.