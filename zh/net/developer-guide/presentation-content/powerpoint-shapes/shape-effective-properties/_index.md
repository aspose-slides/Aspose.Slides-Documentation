---
title: "形状有效属性"
type: docs
weight: 50
url: /zh/net/shape-effective-properties/
keywords: "形状属性, 相机属性, 灯光装置, 斜角形状, 文本框, 文本样式, 字体高度值, 表格填充格式, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中获取 PowerPoint 演示文稿的有效形状属性"
---

在本主题中，我们将讨论 **effective**（有效）和 **local**（本地）属性。当我们直接在这些层级设置值时

1. 在部分所在幻灯片的部分属性中。
1. 在布局或母版幻灯片上的原型形状文本样式中（如果该部分的文本框形状有的话）。
1. 在演示文稿的全局文本设置中。

这些值被称为 **local**（本地）值。 在任何层级，**local** 值都可以被定义或省略。但最后当应用程序需要知道该部分应该如何显示时，它会使用 **effective**（有效）值。可以通过从本地格式调用 **getEffective()** 方法来获取有效值。

以下示例演示如何获取有效值。
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
Aspose.Slides for .NET 允许开发者获取相机的有效属性。为此，Aspose.Slides 中添加了 **CameraEffectiveData** 类。CameraEffectiveData 类表示一个不可变对象，包含相机的有效属性。**CameraEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

下面的代码示例演示如何获取相机的有效属性。
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
Aspose.Slides for .NET 允许开发者获取灯光装置的有效属性。为此，Aspose.Slides 中添加了 **LightRigEffectiveData** 类。LightRigEffectiveData 类表示一个不可变对象，包含灯光装置的有效属性。**LightRigEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

下面的代码示例演示如何获取灯光装置的有效属性。
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
Aspose.Slides for .NET 允许开发者获取斜角形状的有效属性。为此，Aspose.Slides 中添加了 **ShapeBevelEffectiveData** 类。ShapeBevelEffectiveData 类表示一个不可变对象，包含形状面部斜角的有效属性。**ShapeBevelEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

下面的代码示例演示如何获取斜角形状的有效属性。
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

下面的代码示例演示如何获取文本框的有效格式属性。
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
使用 Aspose.Slides for .NET，您可以获取文本样式的有效属性。为此，Aspose.Slides 中添加了 **TextStyleEffectiveData** 类，其中包含文本样式的有效属性。

下面的代码示例演示如何获取文本样式的有效属性。
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


## **获取有效字体高度值**
使用 Aspose.Slides for .NET，您可以获取字体高度的有效属性。下面的代码演示在不同的演示文稿结构层级上设置本地字体高度值后，部分的有效字体高度值如何变化。
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
使用 Aspose.Slides for .NET，您可以获取不同表格逻辑部分的有效填充格式。为此，Aspose.Slides 中添加了 **IFillFormatEffectiveData** 接口，其中包含有效填充格式属性。请注意，单元格格式始终优先于行格式，行格式优先于列格式，列格式优先于整个表格。

因此最终 **CellFormatEffectiveData** 属性总是用于绘制表格。下面的代码示例演示如何获取不同表格逻辑部分的有效填充格式。
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


## **FAQ**

**How can I tell that I got a "snapshot" rather than a "live object," and when should I read effective properties again?**  
EffectiveData 对象是调用时计算值的不可变快照。如果您更改了形状的本地或继承设置，需要重新获取 EffectiveData 以获得更新后的值。

**Does changing the layout/master slide affect effective properties that have already been retrieved?**  
会，但只有在您再次读取它们后才会生效。已经获取的 EffectiveData 对象不会自行更新——在更改布局或母版后需再次请求。

**Can I modify values through EffectiveData?**  
不能。EffectiveData 是只读的。请在本地格式对象（shape/text/3D 等）中进行更改，然后再次获取有效值。

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**  
有效值将由默认机制（PowerPoint/Aspose.Slides 的默认值）决定。该解析后的值会成为 EffectiveData 快照的一部分。

**From an effective font value, can I tell which level provided the size or typeface?**  
不能直接从 EffectiveData 判断来源。它只返回最终值。如需追溯来源，请检查部分/段落/文本框的本地值以及布局/母版/演示文稿的文本样式，找出首次出现显式定义的层级。

**Why do EffectiveData values sometimes look identical to the local ones?**  
因为本地值已经是最终值（无需更高层级的继承）。在这种情况下，有效值与本地值相同。

**When should I use effective properties, and when should I work only with local ones?**  
当您需要“渲染后”的结果（例如对齐颜色、缩进或尺寸）时使用 EffectiveData。如果您只需在特定层级修改格式，请修改本地属性，并在需要时重新读取 EffectiveData 以验证结果。