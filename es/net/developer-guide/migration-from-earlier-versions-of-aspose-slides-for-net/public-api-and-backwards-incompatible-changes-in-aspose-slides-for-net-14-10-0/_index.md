---
title: Cambios de API pública y incompatibles hacia atrás en Aspose.Slides para .NET 14.10.0
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
{{% alert color="info" %}}
Esta página enumera todas las clases, métodos, propiedades, etc. [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) y otros cambios introducidos con la API de Aspose.Slides para .NET 14.10.0.
{{% /alert %}}
## **Cambios de API pública**
#### **Aspose.Slides.FieldType.Footer Field Type Has Been Added**
Se ha añadido el tipo de campo Footer para permitir la creación de campos de este tipo y para una serialización válida de presentaciones.
#### **Enum Element ShapeElementFillSource.Own Has Been Deleted**
El elemento enumerado ShapeElementFillSource.Own se ha eliminado por estar duplicado. Utilice ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
#### **Methods for Chart Data Points, Categories Removing Have Been Added**
Se han añadido los siguientes métodos, que permiten eliminar un punto de datos de una colección de puntos de datos de gráfico:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Se ha añadido el siguiente método, que permite eliminar una categoría de gráfico de la colección contenedora:

IChartCategory.Remove()
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```
#### **Obsolete Aspose.Slides.ParagraphFormat Properties Have Been Removed**
Las propiedades BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle han sido eliminadas. Hace tiempo se marcaron como obsoletas.
#### **Unuseful and Obsolete Constructors Have Been Removed**
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