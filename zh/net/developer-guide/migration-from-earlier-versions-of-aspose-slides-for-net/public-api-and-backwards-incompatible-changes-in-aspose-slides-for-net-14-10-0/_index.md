---
title: Aspose.Slides for .NET 14.10.0 中的公共 API 及向后不兼容更改
type: docs
weight: 120
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

此页面列出了 Aspose.Slides for .NET 14.10.0 API 中所有 [添加的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) 或 [移除的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) 类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **添加了 Aspose.Slides.FieldType.Footer 字段类型**
添加了 Footer 字段类型，以实现创建该类型字段的可能性和有效的演示文稿序列化。
#### **删除了枚举元素 ShapeElementFillSource.Own**
删除了枚举元素 ShapeElementFillSource.Own，因为它是重复的。请使用 ShapeElementFillSource.Shape 代替 ShapeElementFillSource.Own。
#### **添加了图表数据点和类别删除方法**
添加了以下方法，以允许从图表数据点集合中移除图表数据点：

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

添加了以下方法，以允许从包含集合中移除图表类别：

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //使用 ChartCategory.Remove() 移除

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //使用 ChartCategoryCollection.Remove() 移除

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//使用 ChartDataPoint.Remove() 移除

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **已移除过时的 Aspose.Slides.ParagraphFormat 属性**
已移除属性 BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle。这些属性早已标记为过时。
#### **已移除无用和过时的构造函数**
已移除以下构造函数：

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