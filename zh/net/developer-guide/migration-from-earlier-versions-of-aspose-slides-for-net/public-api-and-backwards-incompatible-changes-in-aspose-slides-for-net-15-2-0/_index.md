---
title: Aspose.Slides for .NET 15.2.0 的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出了全部[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 15.2.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已添加 AddDataPointForDoughnutSeries 方法**
已添加 IChartDataPointCollection.AddDataPointForDoughnutSeries() 方法的两个重载，用于向环形图系列中添加数据点。
#### **Aspose.Slides.SmartArt.SmartArtShape 类已从 Aspose.Slides.GeometryShape 类继承**
Aspose.Slides.SmartArt.SmartArtShape 类已从 Aspose.Slides.GeometryShape 类继承。此更改改进了 Aspose.Slides 对象模型，并为 SmartArtShape 类添加了新特性。
#### **已添加按索引删除图表数据点和图表类别的方法**
已添加 IChartDataPointCollection.RemoveAt(int index) 方法，用于按索引删除图表数据点。
已添加 IChartCategoryCollection.RemoveAt(int index) 方法，用于按索引删除图表类别。
#### **已在 Aspose.Slides.Animation.PropertyType 枚举中添加 PptXPptY 值**
在修复序列化问题的范围内，已在 Aspose.Slides.Animation.PropertyType 枚举中添加 PptXPptY 值。
#### **已在 Aspose.Slides.Charts.IChartSeries 中添加 System.Drawing.Color GetAutomaticSeriesColor() 方法**
GetAutomaticSeriesColor 方法根据系列索引和图表样式返回系列的自动颜色。如果 FillType 等于 NotDefined，则默认使用此颜色。

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