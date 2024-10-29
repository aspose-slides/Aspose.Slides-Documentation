---
title: API Pública y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para .NET 14.10.0
type: docs
weight: 120
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades y demás que han sido [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/), así como otros cambios introducidos con la API de Aspose.Slides para .NET 14.10.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Se ha agregado el tipo de campo Aspose.Slides.FieldType.Footer**
Se ha agregado el tipo de campo Footer para la implementación de la posibilidad de crear campos de este tipo y para la serialización válida de presentaciones.
#### **Se ha eliminado el elemento de Enum ShapeElementFillSource.Own**
El elemento de Enum ShapeElementFillSource.Own se ha eliminado por ser duplicado. Utilice ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
#### **Se han agregado métodos para eliminar puntos de datos de gráficos y categorías**
Se han añadido los siguientes métodos que permiten eliminar un punto de datos de gráfico de una colección de puntos de datos:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

Se ha añadido el siguiente método que permite eliminar una categoría de gráfico de la colección que la contiene:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //eliminar con ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //eliminar con ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//eliminar con ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Se han eliminado propiedades obsoletas de Aspose.Slides.ParagraphFormat**
Se han eliminado las propiedades BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle. Fueron marcadas como obsoletas hace mucho tiempo.
#### **Se han eliminado constructores inútiles y obsoletos**
Se han eliminado los siguientes constructores:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)