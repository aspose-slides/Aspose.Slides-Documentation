---
title: 公共 API 和向后不兼容的更改在 Aspose.Slides for .NET 14.10.0
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- 迁移
- 旧代码
- 现代代码
- 旧方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有已[添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)或[移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 14.10.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已添加 Aspose.Slides.FieldType.Footer 字段类型**
已添加 Footer 字段类型，以实现创建此类型字段的可能性并进行有效的演示文稿序列化。
#### **已删除 枚举成员 ShapeElementFillSource.Own**
由于重复，已删除枚举成员 ShapeElementFillSource.Own。请使用 ShapeElementFillSource.Shape 代替 ShapeElementFillSource.Own。
#### **已添加用于删除图表数据点和类别的方法**
已添加以下方法，可用于从图表数据点集合中删除图表数据点：

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

以下方法已添加，可用于从其所在集合中删除图表类别：

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **已移除过时的 Aspose.Slides.ParagraphFormat 属性**
属性 BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle 已被移除。它们早已标记为过时。
#### **已移除无用且过时的构造函数**
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