---
title: 在 .NET 中从演示文稿获取形状有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/net/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 灯光装置
- 斜面形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何计算并应用有效的形状属性，以实现精确的 PowerPoint 渲染。"
---
## **概述**

本主题解释 **local** 和 **effective** 属性之间的区别。Local 值是直接在特定格式级别设置的值，例如：

1. 幻灯片上的段落属性。
1. 当段落的文本框形状具有该样式时，布局或母版幻灯片上的原型形状文本样式。
1. 演示文稿中的全局文本设置。

本地值可以在任何级别定义或省略。当 Aspose.Slides 需要最终的“渲染后”格式时，它会解析继承链并返回 **effective** 值。您可以通过在本地格式对象上调用 `GetEffective` 方法来获取它们。

以下示例展示如何获取有效值。它假设首张幻灯片上的第一个形状是一个带有文本框且至少包含一个段落的 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
有效的格式化数据表示在应用继承后当前计算得到的格式。在当前实现中，某些有效数据对象（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformateffectivedata/)）可能会在内部缓存。更改父级或继承的格式后再次调用 `GetEffective` 可以刷新缓存的数据，先前获取的对象可能不再代表之前的状态。如果需要保留有效值以供后续使用，请将所需属性（如字体高度、填充颜色、字体样式或对齐方式）复制到您自己的数据对象中。
{{% /alert %}}

## **获取摄像机的有效属性**

Aspose.Slides 允许您获取相机的有效属性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/icameraeffectivedata/) 接口表示一个包含有效相机属性的不可变对象。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/icameraeffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/) 暴露，该接口提供 [IThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/) 的有效值。

以下代码示例展示如何获取相机的有效属性。它假设首张幻灯片上的第一个形状具有 3D 格式。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **获取灯光装置的有效属性**

Aspose.Slides 允许您获取灯光装置的有效属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ilightrigeffectivedata/) 接口表示一个包含有效灯光装置属性的不可变对象。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ilightrigeffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/) 暴露，该接口提供 [IThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/) 的有效值。

以下代码示例展示如何获取灯光装置的有效属性。它假设首张幻灯片上的第一个形状具有 3D 格式。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **获取形状斜面的有效属性**

Aspose.Slides 允许您获取形状斜面的有效属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapebeveleffectivedata/) 接口表示一个包含形状有效面部凸起属性的不可变对象。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapebeveleffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/) 暴露，该接口提供 [IThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/) 的有效值。

以下代码示例展示如何获取形状顶部斜面的有效属性。它假设首张幻灯片上的第一个形状具有 3D 格式。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **获取文本框的有效属性**

使用 Aspose.Slides，您可以获取文本框的有效属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformateffectivedata/) 接口包含有效的文本框格式属性。

以下代码示例展示如何获取有效的文本框格式属性。它假设首张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **获取文本样式的有效属性**

使用 Aspose.Slides，您可以获取文本样式的有效属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/itextstyleeffectivedata/) 接口包含有效的文本样式属性。

以下代码示例展示如何获取有效的文本样式属性。它假设首张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **获取有效的字体高度值**

使用 Aspose.Slides，您可以获取有效的字体高度。以下代码演示在演示文稿的不同结构层级设置本地字体高度后，段落的有效字体高度如何变化。

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **获取表格的有效填充格式**

使用 Aspose.Slides，您可以获取不同表格部分的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ifillformateffectivedata/) 接口包含有效的填充格式属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整表格式。

因此，绘制表格单元格时使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/icellformateffectivedata/) 的属性。以下代码示例展示如何获取不同表格部分的有效填充格式。它假设首张幻灯片上的第一个形状是一个 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/)。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **常见问题**

**`GetEffective` 会返回快照吗？**

并非总是。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能会在内部被缓存。随后调用 `GetEffective` 可能会重新计算格式并刷新缓存的数据，因此先前获取的对象不应视为持久的快照。

**何时需要重新读取有效属性？**

在更改本地格式、父级样式、版面格式、母版格式或演示文稿级默认设置后再次调用 `GetEffective`。下一次调用会重新评估格式层次并返回当前的有效结果。

**更改或移除版面/母版幻灯片会影响已获取的有效属性吗？**

是的，但更改会在下次调用 `GetEffective` 时体现。如果父级格式源被更改或移除，先前获取的有效数据可能已过时。再次调用 `GetEffective` 后，Aspose.Slides 将重新评估格式树，所得到的字体、颜色、大小或其他值可能会变化。

**我可以通过有效数据对象修改值吗？**

不能。有效数据对象只提供计算后的值。请在本地格式对象中进行修改，然后再次获取有效值。

**如果在形状层、版面/母版层或全局设置中都未设置属性，会怎样？**

有效值由默认机制决定，包括 PowerPoint 和 Aspose.Slides 的默认设置。解析得到的值将成为当前有效数据的一部分。

**从有效的字体值，我能判断是哪个层级提供的大小或字体吗？**

不能直接判断。有效数据只返回最终值。若要找出来源，需要检查段落、段、文本框以及版面、母版和演示文稿层级的文本样式中的本地值，找出首次出现显式定义的层级。

**为什么有效值有时看起来与本地值相同？**

因为本地值已经是最终值（不需要更高层级的继承）。在这种情况下，有效值与本地值相同。

**何时应该使用有效属性，何时仅使用本地属性？**

当您需要在所有继承应用后得到“渲染后”的结果时（例如对齐颜色、缩进或尺寸），使用有效数据。如果需要在后续格式更改后仍保留这些值，请将所需属性复制到自己的对象中。如果需要在特定层级修改格式，请修改本地属性，然后在需要时再次读取有效数据以验证结果。