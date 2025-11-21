---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.2.0
linktitle: Aspose.Slides para .NET 15.2.0
type: docs
weight: 140
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 
Esta página enumera todas las clases, métodos, propiedades y demás [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/), y otros cambios introducidos con la API de Aspose.Slides for .NET 15.2.0.
{{% /alert %}} 
## **Cambios en la API pública**
#### **Se han añadido los métodos AddDataPointForDoughnutSeries**
Los dos sobrecargas del método IChartDataPointCollection.AddDataPointForDoughnutSeries() se han añadido para agregar puntos de datos a series del tipo de gráfico Dona.
#### **La clase Aspose.Slides.SmartArt.SmartArtShape ha heredado de la clase Aspose.Slides.GeometryShape**
La clase Aspose.Slides.SmartArt.SmartArtShape ha heredado de la clase Aspose.Slides.GeometryShape. Este cambio mejora el modelo de objetos de Aspose.Slides y agrega nuevas funcionalidades a la clase SmartArtShape.
#### **Se han añadido métodos para eliminar puntos de datos y categorías de gráficos por índice**
El método IChartDataPointCollection.RemoveAt(int index) se ha añadido para eliminar un punto de datos del gráfico por su índice.
El método IChartCategoryCollection.RemoveAt(int index) se ha añadido para eliminar una categoría del gráfico por su índice.
#### **Se ha añadido el valor PptXPptY a la enumeración Aspose.Slides.Animation.PropertyType**
Se ha añadido el valor PptXPptY a la enumeración Aspose.Slides.Animation.PropertyType en el contexto de una corrección de problema de serialización.
#### **Se ha añadido el método System.Drawing.Color GetAutomaticSeriesColor() a Aspose.Slides.Charts.IChartSeries**
El método GetAutomaticSeriesColor devuelve un color automático de la serie basado en el índice de la serie y el estilo del gráfico. Este color se usa por defecto si FillType es NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```