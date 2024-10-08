---
title: 形状有效属性
type: docs
weight: 50
url: /net/shape-effective-properties/
keywords: "形状属性, 相机属性, 灯光设备, 倾斜形状, 文本框, 文本样式, 字体高度值, 表格填充格式, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中获取 PowerPoint 演示文稿中的有效形状属性"
---

在本主题中，我们将讨论**有效**和**本地**属性。当我们在这些级别直接设置值时

1. 在部分属性上在部分的幻灯片上。
1. 在布局或母版幻灯片上的原型形状文本样式（如果部分的文本框形状有一个）。
1. 在演示文稿的全局文本设置中。

那么这些值称为**本地**值。在任何级别，**本地**值都可以被定义或省略。但是最终，当应用程序需要知道部分应是什么样子时，它使用**有效**值。您可以使用来自本地格式的**getEffective()**方法获取有效值。

下面的示例演示了如何获取有效值。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextFrameFormat localTextFrameFormat = shape.TextFrame.TextFrameFormat;
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

    IPortionFormat localPortionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.GetEffective();
}
```



## **获取相机的有效属性**
Aspose.Slides for .NET 允许开发人员获取相机的有效属性。为此，Aspose.Slides 中添加了**CameraEffectiveData**类。CameraEffectiveData 类表示一个不可变对象，包含有效的相机属性。**CameraEffectiveData**类的实例用作**ThreeDFormatEffectiveData**类的一部分，该类是 ThreeDFormat 类的有效值对。

以下代码示例演示了如何获取相机的有效属性。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= 有效的相机属性 =");
	Console.WriteLine("类型: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("视场: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("缩放: " + threeDEffectiveData.Camera.Zoom);
}
```


## **获取灯光设备的有效属性**
Aspose.Slides for .NET 允许开发人员获取灯光设备的有效属性。为此，Aspose.Slides 中添加了**LightRigEffectiveData**类。LightRigEffectiveData 类表示一个不可变对象，包含有效的灯光设备属性。**LightRigEffectiveData**类的实例用作**ThreeDFormatEffectiveData**类的一部分，该类是 ThreeDFormat 类的有效值对。

以下代码示例演示了如何获取灯光设备的有效属性。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= 有效的灯光设备属性 =");
	Console.WriteLine("类型: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("方向: " + threeDEffectiveData.LightRig.Direction);
}
```


## **获取斜角形状的有效属性**
Aspose.Slides for .NET 允许开发人员获取斜角形状的有效属性。为此，Aspose.Slides 中添加了**ShapeBevelEffectiveData**类。ShapeBevelEffectiveData 类表示一个不可变对象，包含有效的形状面凹凸属性。**ShapeBevelEffectiveData**类的实例用作**ThreeDFormatEffectiveData**类的一部分，该类是 ThreeDFormat 类的有效值对。

以下代码示例演示了如何获取斜角形状的有效属性。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= 有效的形状顶面凹凸属性 =");
	Console.WriteLine("类型: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("宽度: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("高度: " + threeDEffectiveData.BevelTop.Height);
}
```



## **获取文本框的有效属性**
使用 Aspose.Slides for .NET，您可以获取文本框的有效属性。为此，Aspose.Slides 中添加了**TextFrameFormatEffectiveData**类，包含有效的文本框格式属性。

以下代码示例演示了如何获取有效的文本框格式属性。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("锚定类型: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("自动调整类型: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("文本垂直类型: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("边距");
	Console.WriteLine("   左: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   上: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   右: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   下: " + effectiveTextFrameFormat.MarginBottom);
}
```



## **获取文本样式的有效属性**
使用 Aspose.Slides for .NET，您可以获取文本样式的有效属性。为此，Aspose.Slides 中添加了**TextStyleEffectiveData**类，包含有效的文本样式属性。

以下代码示例演示了如何获取有效的文本样式属性。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= 样式级别 #" + i + " 的有效段落格式 =");

        Console.WriteLine("深度: " + effectiveStyleLevel.Depth);
        Console.WriteLine("缩进: " + effectiveStyleLevel.Indent);
        Console.WriteLine("对齐: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("字体对齐: " + effectiveStyleLevel.FontAlignment);
    }
}

```


## **获取有效的字体高度值**
使用 Aspose.Slides for .NET，您可以获取字体高度的有效属性。以下代码展示了在不同演示文稿结构级别上设置本地字体高度值后，部分的有效字体高度值的变化。

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("带有第一部分的示例文本");
    IPortion portion1 = new Portion(" 和第二部分。");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("创建后有效的字体高度:");
    Console.WriteLine("部分 #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("部分 #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("设置整个演示文稿的默认字体高度后有效的字体高度:");
    Console.WriteLine("部分 #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("部分 #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("设置段落的默认字体高度后有效的字体高度:");
    Console.WriteLine("部分 #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("部分 #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("设置部分 #0 字体高度后有效的字体高度:");
    Console.WriteLine("部分 #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("部分 #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("设置部分 #1 字体高度后有效的字体高度:");
    Console.WriteLine("部分 #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("部分 #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **获取表格的有效填充格式**
使用 Aspose.Slides for .NET，您可以获取不同表格逻辑部分的有效填充格式。为此，Aspose.Slides 中添加了**IFillFormatEffectiveData**接口，包含有效的填充格式属性。请注意，单元格格式始终优先于行格式，行优先于列，而列优先于整个表格。

因此，**CellFormatEffectiveData**属性始终用于绘制表格。以下代码示例演示了如何获取不同表格逻辑部分的有效填充格式。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	ITable tbl = pres.Slides[0].Shapes[0] as ITable;
	ITableFormatEffectiveData tableFormatEffective = tbl.TableFormat.GetEffective();
	IRowFormatEffectiveData rowFormatEffective = tbl.Rows[0].RowFormat.GetEffective();
	IColumnFormatEffectiveData columnFormatEffective = tbl.Columns[0].ColumnFormat.GetEffective();
	ICellFormatEffectiveData cellFormatEffective = tbl[0, 0].CellFormat.GetEffective();

	IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.FillFormat;
	IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.FillFormat;
	IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.FillFormat;
	IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.FillFormat;
}
```