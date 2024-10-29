---
title: API Pública y Cambios Incompatibles hacia Atrás en Aspose.Slides para .NET 15.2.0
type: docs
weight: 140
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades, etc., [agregadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) o [eliminadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/), y otros cambios introducidos con el API de Aspose.Slides para .NET 15.2.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Se han agregado los métodos AddDataPointForDoughnutSeries**
Se han agregado dos sobrecargas del método IChartDataPointCollection.AddDataPointForDoughnutSeries() para agregar puntos de datos a series del tipo de gráfico de dona.
#### **La clase Aspose.Slides.SmartArt.SmartArtShape ha heredado de la clase Aspose.Slides.GeometryShape**
La clase Aspose.Slides.SmartArt.SmartArtShape ha heredado de la clase Aspose.Slides.GeometryShape. Este cambio mejora el modelo de objeto de Aspose.Slides y agrega nuevas características a la clase SmartArtShape.
#### **Se han agregado métodos para eliminar puntos de datos del gráfico y categorías del gráfico por índice**
Se ha agregado el método IChartDataPointCollection.RemoveAt(int index) para eliminar un punto de datos del gráfico por su índice.
Se ha agregado el método IChartCategoryCollection.RemoveAt(int index) para eliminar una categoría del gráfico por su índice.
#### **Se ha agregado el valor PptXPptY a la enumeración Aspose.Slides.Animation.PropertyType**
Se ha agregado el valor PptXPptY a la enumeración Aspose.Slides.Animation.PropertyType en el contexto de una solución de problema de serialización.
#### **Se ha agregado el método System.Drawing.Color GetAutomaticSeriesColor() a Aspose.Slides.Charts.IChartSeries**
El método GetAutomaticSeriesColor devuelve un color automático de la serie basado en el índice de la serie y el estilo del gráfico. Este color se utiliza por defecto si FillType es igual a NotDefined.

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