---
title: Aspose.Slides for .NET 14.10.0 的公共 API 及向后不兼容更改
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "回顾 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有已[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)或已[已删除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 14.10.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **Aspose.Slides.FieldType.Footer 字段类型已添加**
已添加 Footer 字段类型，以实现创建此类型字段的可能性并支持有效的演示文稿序列化。
#### **枚举元素 ShapeElementFillSource.Own 已删除**
枚举元素 ShapeElementFillSource.Own 已被删除，因为它是重复的。请使用 ShapeElementFillSource.Shape 代替 ShapeElementFillSource.Own。
#### **已添加用于删除图表数据点和类别的方法**
已添加以下方法，可从图表数据点集合中删除图表数据点：

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

已添加以下方法，可从所属集合中删除图表类别：

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
#### **已删除过时的 Aspose.Slides.ParagraphFormat 属性**
属性 BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle 已被删除。它们早已标记为过时。
#### **已删除无用且过时的构造函数**
已删除以下构造函数：

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