---
title: 图表数据表
type: docs
url: /zh/net/chart-data-table/
keywords: "字体属性, 图表数据表, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中为 PowerPoint 演示文稿中的图表数据库表设置字体属性"
---

## **为图表数据表设置字体属性**
Aspose.Slides for .NET 提供支持以更改系列颜色中的类别颜色。

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

以下是给出的示例。 

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```