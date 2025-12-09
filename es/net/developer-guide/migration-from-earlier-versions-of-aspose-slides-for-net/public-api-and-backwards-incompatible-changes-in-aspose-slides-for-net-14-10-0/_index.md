---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.10.0
linktitle: Aspose.Slides para .NET 14.10.0
type: docs
weight: 120
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migración
- código legado
- código moderno
- enfoque legado
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

Esta página enumera todas las [agregadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) o [eliminadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) clases, métodos, propiedades y demás, y otros cambios introducidos con la API de Aspose.Slides para .NET 14.10.0.

{{% /alert %}} 
## **Cambios de API pública**
#### **Se ha añadido el tipo de campo Aspose.Slides.FieldType.Footer**
#### **El elemento de enumeración ShapeElementFillSource.Own ha sido eliminado**
El elemento de enumeración ShapeElementFillSource.Own se ha eliminado por estar duplicado. Use ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
#### **Se han añadido métodos para eliminar puntos de datos y categorías de gráficos**
Se han añadido los siguientes métodos, que permiten eliminar un punto de datos de gráfico de una colección de puntos de datos:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Se ha añadido el siguiente método, que permite eliminar una categoría de gráfico de la colección contenedora:

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
Las propiedades BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle se han eliminado. Fueron marcadas como obsoletas hace tiempo.
#### **Se han eliminado los constructores inútiles y obsoletos**
The following constructors have been removed:

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