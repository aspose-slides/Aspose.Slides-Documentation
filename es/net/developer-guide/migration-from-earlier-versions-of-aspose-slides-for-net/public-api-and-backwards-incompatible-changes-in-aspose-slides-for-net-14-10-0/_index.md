---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.10.0
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
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todos los [added](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) o [removed](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) clases, métodos, propiedades y demás, y los demás cambios introducidos con la API Aspose.Slides for .NET 14.10.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se ha añadido el tipo de campo Aspose.Slides.FieldType.Footer**
Se ha añadido el tipo de campo Footer para permitir la creación de campos de este tipo y para una serialización válida de presentaciones.
#### **Se ha eliminado el elemento enum ShapeElementFillSource.Own**
El elemento enum ShapeElementFillSource.Own se ha eliminado por estar duplicado. Use ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
#### **Se han añadido métodos para eliminar puntos de datos y categorías de gráficos**
Los siguientes métodos, que permiten eliminar un punto de datos de una colección de puntos de datos de gráfico, se han añadido:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

El siguiente método, que permite eliminar una categoría de gráfico de la colección contenedora, se ha añadido:

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
#### **Se han eliminado propiedades obsoletas de Aspose.Slides.ParagraphFormat**
Se han eliminado las propiedades BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle. Fueron marcadas como obsoletas hace mucho tiempo.
#### **Se han eliminado constructores inútiles y obsoletos**
Los siguientes constructores han sido eliminados:

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