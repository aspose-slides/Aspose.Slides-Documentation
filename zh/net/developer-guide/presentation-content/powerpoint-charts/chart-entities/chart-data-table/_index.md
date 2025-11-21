---
title: 在 .NET 中自定义演示文稿的图表数据表
linktitle: 数据表
type: docs
url: /zh/net/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中自定义 PPT 和 PPTX 的图表数据表，以提升演示文稿的效率和视觉吸引力。"
---

## **设置图表数据表的字体属性**
Aspose.Slides for .NET 提供了更改系列颜色中类别颜色的支持。

1. 实例化[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类对象。
1. 在幻灯片上添加图表。
1. 设置图表数据表。
1. 设置字体高度。
1. 保存修改后的演示文稿。

以下示例已给出。
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


## **常见问题**

**我可以在图表数据表的数值旁显示小图例键吗？**

是的。数据表支持[legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/)，您可以打开或关闭它们。

**将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

是的。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/net/convert-powerpoint-to-html/)/[image](/slides/zh/net/convert-powerpoint-to-png/) 包含带有数据表的图表。

**模板文件中的图表是否支持数据表？**

是的。对于从现有演示文稿或模板加载的任何图表，您可以使用图表的属性检查并更改数据表是否[显示](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/)。

**如何快速查找文件中哪些图表已启用数据表？**

检查每个图表的属性以确定数据表是否[显示](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/)，并遍历幻灯片以识别已启用数据表的图表。