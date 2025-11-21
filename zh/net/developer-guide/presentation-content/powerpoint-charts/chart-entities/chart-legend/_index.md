---
title: 在 .NET 中自定义演示文稿的图表图例
linktitle: 图表图例
type: docs
url: /zh/net/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自定义图表图例，以优化 PowerPoint 演示文稿的图例格式."
---

## **图例定位**
为了设置图例属性，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 获取幻灯片的引用。
- 在幻灯片上添加图表。
- 设置图例的属性。
- 将演示文稿写入为 PPTX 文件。

以下示例中，我们已设置图表图例的位置和大小。
```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

// 获取幻灯片的引用
ISlide slide = presentation.Slides[0];

// 在幻灯片上添加簇状柱形图
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


## **常见问题**

**我可以启用图例，使图表自动为其分配空间而不是覆盖吗？**

可以。使用非覆盖模式（[Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/)=`false`）；此时绘图区会缩小以容纳图例。

**我可以制作多行图例标签吗？**

可以。当空间不足时，长标签会自动换行；通过在系列名称中加入换行符可以实现强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

不要为图例或其文本显式设置颜色、填充或字体。这样它们会继承主题的设置，并在设计更改时正确更新。