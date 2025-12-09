---
title: API pública y cambios incompatibles retroactivos en Aspose.Slides para .NET 14.10.0
linktitle: Aspose.Slides para .NET 14.10.0
type: docs
weight: 120
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
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

Esta página enumera todas las clases, métodos, propiedades y demás [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/), y otros cambios introducidos con la API de Aspose.Slides for .NET 14.10.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se ha añadido el tipo de campo Aspose.Slides.FieldType.Footer**
Se ha añadido el tipo de campo Footer para permitir la creación de campos de este tipo y la serialización válida de presentaciones.
#### **Se ha eliminado el elemento de enumeración ShapeElementFillSource.Own**
El elemento de enumeración ShapeElementFillSource.Own se ha eliminado por estar duplicado. Use ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
#### **Se han añadido métodos para eliminar puntos de datos del gráfico y categorías**
Se han añadido los siguientes métodos, que permiten eliminar un punto de datos del gráfico de una colección de puntos de datos del gráfico:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

Se ha añadido el siguiente método, que permite eliminar una categoría del gráfico de la colección que la contiene:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //remove with ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remove with ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//remove with ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Se han eliminado las propiedades obsoletas de Aspose.Slides.ParagraphFormat**
Se han eliminado las propiedades BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle. Fueron marcadas como obsoletas hace mucho tiempo.
#### **Se han eliminado los constructores inútiles y obsoletos**
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