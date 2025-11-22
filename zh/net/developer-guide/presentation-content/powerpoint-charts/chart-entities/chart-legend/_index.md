---
title: 图表图例
type: docs
url: /zh/net/chart-legend/
keywords: "图表图例, 图例字体大小, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中为 PowerPoint 演示文稿设置图表图例的位置和字体大小"
---

## **图例定位**
要设置图例属性，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 获取幻灯片的引用。
- 在幻灯片上添加图表。
- 设置图例的属性。
- 将演示文稿保存为 PPTX 文件。

在下面的示例中，我们为图表图例设置了位置和大小。
```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

// 获取幻灯片的引用
ISlide slide = presentation.Slides[0];

// 在幻灯片上添加聚簇柱形图表
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// 设置图例属性
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// 将演示文稿写入磁盘
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **设置图例字体大小**
Aspose.Slides for .NET 允许开发人员设置图例的字体大小。请按照以下步骤操作：

- 实例化 `Presentation` 类。
- 创建默认图表。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```



## **设置单个图例项的字体大小**
Aspose.Slides for .NET 允许开发人员设置单个图例项的字体大小。请按照以下步骤操作：

- 实例化 `Presentation` 类。
- 创建默认图表。
- 访问图例项。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**我可以启用图例，使图表自动为其分配空间，而不是覆盖吗？**

可以。将非覆盖模式（[Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`）设为 false；此时绘图区域会收缩以容纳图例。

**我可以创建多行图例标签吗？**

可以。当空间不足时，长标签会自动换行；通过在系列名称中插入换行符可以实现强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

不要为图例或其文本设置显式的颜色、填充或字体。这样它们会继承主题的设置，并在主题更改时自动更新。