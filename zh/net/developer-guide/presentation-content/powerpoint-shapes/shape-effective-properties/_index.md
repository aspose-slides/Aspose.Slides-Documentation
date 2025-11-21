---
title: 在 .NET 中从演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/net/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光装置
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何计算并应用有效形状属性，以实现精确的 PowerPoint 渲染。"
---

在本主题中，我们将讨论 **effective**（有效）和 **local**（本地）属性。当我们直接在以下层级设置值时

1. 在文本段落所在幻灯片的段落属性上。
1. 在布局或母版幻灯片上的原型形状文本样式上（如果段落的文本框形状拥有该样式）。
1. 在演示文稿的全局文本设置中。

这些值称为 **local**（本地）值。 在任何层级，**local** 值都可以被定义或省略。 但最终当应用程序需要知道段落应该呈现为何种外观时，它会使用 **effective**（有效）值。 您可以通过本地格式的 **getEffective()** 方法获取有效值。

以下示例展示了如何获取有效值。
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
Aspose.Slides for .NET 允许开发者获取相机的有效属性。 为此，Aspose.Slides 中添加了 **CameraEffectiveData** 类。CameraEffectiveData 类表示一个不可变对象，包含有效的相机属性。**CameraEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

以下代码示例展示了如何获取相机的有效属性。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective camera properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```



## **获取灯光装置的有效属性**
Aspose.Slides for .NET 允许开发者获取灯光装置的有效属性。 为此，Aspose.Slides 中添加了 **LightRigEffectiveData** 类。LightRigEffectiveData 类表示一个不可变对象，包含有效的灯光装置属性。**LightRigEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

以下代码示例展示了如何获取灯光装置的有效属性。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```



## **获取斜角形状的有效属性**
Aspose.Slides for .NET 允许开发者获取斜角形状的有效属性。 为此，Aspose.Slides 中添加了 **ShapeBevelEffectiveData** 类。ShapeBevelEffectiveData 类表示一个不可变对象，包含有效的形状面部凹凸属性。**ShapeBevelEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

以下代码示例展示了如何获取斜角形状的有效属性。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective shape's top face relief properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
}
```




## **获取文本框的有效属性**
使用 Aspose.Slides for .NET，您可以获取文本框的有效属性。 为此，Aspose.Slides 中添加了 **TextFrameFormatEffectiveData** 类，包含有效的文本框格式属性。

以下代码示例展示了如何获取文本框的有效格式属性。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Margins");
	Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
}
```




## **获取文本样式的有效属性**
使用 Aspose.Slides for .NET，您可以获取文本样式的有效属性。 为此，Aspose.Slides 中添加了 **TextStyleEffectiveData** 类，包含有效的文本样式属性。

以下代码示例展示了如何获取文本样式的有效属性。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Effective paragraph formatting for style level #" + i + " =");

        Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
    }
}
```



## **获取有效的字体高度值**
使用 Aspose.Slides for .NET，您可以获取字体高度的有效属性。 以下代码演示了在不同演示文稿结构层级上设置本地字体高度后，段落的有效字体高度值如何变化。
```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Effective font height just after creation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Effective font height after setting entire presentation default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Effective font height after setting paragraph default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Effective font height after setting portion #0 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Effective font height after setting portion #1 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```



## **获取表格的有效填充格式**
使用 Aspose.Slides for .NET，您可以获取不同表格逻辑部分的有效填充格式。 为此，Aspose.Slides 中添加了 **IFillFormatEffectiveData** 接口，包含有效的填充格式属性。请注意，单元格格式始终优先于行格式，行格式优先于列格式，列格式又优先于整张表。

因此，最终始终使用 **CellFormatEffectiveData** 属性来绘制表格。以下代码示例展示了如何获取不同表格逻辑部分的有效填充格式。
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


## **常见问题解答**

**如何判断我得到的是“快照”而不是“实时对象”，以及何时需要重新读取有效属性？**

EffectiveData 对象是调用时计算值的不可变快照。若更改了形状的本地或继承设置，需要再次获取有效数据以获得更新后的值。

**更改布局/母版幻灯片会影响已获取的有效属性吗？**

会，但只有在您再次读取它们时才会生效。已获取的 EffectiveData 对象不会自行更新——在更改布局或母版后需要重新请求。

**我可以通过 EffectiveData 修改值吗？**

不能。EffectiveData 是只读的。请在本地格式对象（形状/文本/3D 等）中进行修改，然后再次获取有效值。

**如果在形状层、布局/母版以及全局设置中都未设置某属性，会怎样？**

有效值由默认机制（PowerPoint/Aspose.Slides 的默认值）决定。该解析后的默认值会成为 EffectiveData 快照的一部分。

**从有效的字体值中，我能判断是哪个层级提供了大小或字体吗？**

不能直接判断。EffectiveData 只返回最终值。若想了解来源，需要检查段落/文本框/段落的本地值以及布局/母版/演示文稿的文本样式，查找首次出现的显式定义。

**为什么 EffectiveData 的值有时与本地值完全相同？**

因为本地值已经是最终值（没有更高层级的继承需要覆盖）。在这种情况下，有效值与本地值相同。

**何时应该使用有效属性，何时仅使用本地属性？**

当您需要获取“渲染后”的结果（即所有继承已应用后的值，例如对齐颜色、缩进或尺寸）时，使用 EffectiveData。如果您只需在特定层级修改格式，先修改本地属性；如有需要，再重新读取 EffectiveData 以验证结果。