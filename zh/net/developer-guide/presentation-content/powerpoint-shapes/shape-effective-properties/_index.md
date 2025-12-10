---
title: 从 .NET 演示文稿获取形状的有效属性
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
description: "了解 Aspose.Slides for .NET 如何计算并应用有效的形状属性，以实现精准的 PowerPoint 渲染。"
---

在本主题中，我们将讨论 **effective** 和 **local** 属性。当我们在这些级别直接设置值时

1. 在部分（portion）所在的幻灯片上的部分属性。
1. 在布局或母版幻灯片上的原型形状文本样式中（如果该部分的文本框形状有原型的话）。
1. 在演示文稿的全局文本设置中。

那么这些值被称为 **local** 值。 在任何级别，**local** 值都可能被定义或省略。但最终，当应用程序需要知道该部分应如何呈现时，它会使用 **effective** 值。您可以通过在本地格式上使用 **getEffective()** 方法来获取有效值。

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
Aspose.Slides for .NET 允许开发者获取相机的有效属性。为此，Aspose.Slides 中添加了 **CameraEffectiveData** 类。**CameraEffectiveData** 类表示一个包含有效相机属性的不可变对象。**CameraEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 **ThreeDFormat** 类的有效值对。

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
Aspose.Slides for .NET 允许开发者获取灯光装置的有效属性。为此，Aspose.Slides 中添加了 **LightRigEffectiveData** 类。**LightRigEffectiveData** 类表示一个包含有效灯光装置信息的不可变对象。**LightRigEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 **ThreeDFormat** 类的有效值对。

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
Aspose.Slides for .NET 允许开发者获取斜角形状的有效属性。为此，Aspose.Slides 中添加了 **ShapeBevelEffectiveData** 类。**ShapeBevelEffectiveData** 类表示一个包含有效形状面部浮雕属性的不可变对象。**ShapeBevelEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 **ThreeDFormat** 类的有效值对。

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
使用 Aspose.Slides for .NET，您可以获取文本框的有效属性。为此，Aspose.Slides 中添加了 **TextFrameFormatEffectiveData** 类，其中包含文本框的有效格式属性。

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
使用 Aspose.Slides for .NET，您可以获取文本样式的有效属性。为此，Aspose.Slides 中添加了 **TextStyleEffectiveData** 类，其中包含有效的文本样式属性。

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
使用 Aspose.Slides for .NET，您可以获取字体高度的有效属性。下面的代码演示了在演示文稿的不同结构层级上设置本地字体高度后，部分的有效字体高度值如何改变。
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
使用 Aspose.Slides for .NET，您可以获取表格不同逻辑部分的有效填充格式。为此，Aspose.Slides 中添加了 **IFillFormatEffectiveData** 接口，其中包含有效的填充格式属性。请注意，单元格格式的优先级始终高于行格式，行的优先级高于列，列的优先级高于整个表格。

因此，最终绘制表格时始终使用 **CellFormatEffectiveData** 属性。以下代码示例展示了如何获取表格不同逻辑部分的有效填充格式。
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


## **常见问题**

**我如何判断得到的是“快照”而不是“实时对象”，以及何时应重新读取有效属性？**
EffectiveData 对象是调用时计算值的不可变快照。如果您更改了形状的本地或继承设置，需要再次获取有效数据以获得更新后的值。

**更改布局/母版幻灯片是否会影响已获取的有效属性？**
会的，但只有在您重新读取后才会生效。已经获取的 EffectiveData 对象不会自行更新——在更改布局或母版后需要再次请求。

**我可以通过 EffectiveData 修改值吗？**
不能。EffectiveData 只读。请在本地格式化对象（形状/文本/3D 等）中进行修改，然后再次获取有效值。

**如果属性在形状级别、布局/母版以及全局设置中都未设置，会怎样？**
有效值将由默认机制（PowerPoint/Aspose.Slides 的默认设置）决定。该解析得到的值会成为 EffectiveData 快照的一部分。

**从有效的字体值，我能判断是哪个级别提供的大小或字体吗？**
不能直接判断。EffectiveData 返回的是最终值。若要查找来源，需要检查部分/段落/文本框的本地值以及布局/母版/演示文稿的文本样式，找出首次出现显式定义的层级。

**为什么 EffectiveData 的值有时与本地值完全相同？**
因为本地值已经是最终值（不需要更高级别的继承）。在这种情况下，EffectiveData 与本地值相同。

**何时应该使用有效属性，何时只使用本地属性？**
当您需要在所有继承应用后得到“渲染后的”结果时（例如对齐颜色、缩进或尺寸），应使用 EffectiveData。如果您只需在特定层级修改格式，请修改本地属性，并在需要时重新读取 EffectiveData 以验证结果。