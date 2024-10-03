---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 14.10.0 API.

{{% /alert %}} 
## **Public API Chages**
#### **Aspose.Slides.FieldType.Footer field type has been added**
The Footer field type has been added for the implementation of the possibility to create fields of this type and for valid presentation serialization.
#### **Enum element ShapeElementFillSource.Own has been deleted**
Enum element ShapeElementFillSource.Own has been deleted as duplicated. Use ShapeElementFillSource.Shape instead of ShapeElementFillSource.Own.
#### **Methods for chart data points, categories removing have been added**
The following methods, which allow to remove chart data point from a chart data point collection have been added:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

The following method, which allows to remove a chart category from the containing collection has been added:

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
#### **Obsolete Aspose.Slides.ParagraphFormat propertyies have been removed**
The properties BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle have been removed. They were marked as obsolete long time ago.
#### **Unuseful and obsolete constructors have been removed**
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
