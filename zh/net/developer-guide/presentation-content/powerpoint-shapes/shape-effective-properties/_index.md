---
title: 从 .NET 演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/net/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
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
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中区分本地、继承和有效的形状格式。"
---
## **理解本地、继承和有效属性**

PowerPoint 格式可以来自多个来源。直接存储在对象上的值称为 **本地值**。如果未设置该值，PowerPoint 会查找父级格式来源，例如段落默认值、文本样式、版面或母版幻灯片、主题或演示文稿级别的默认值。这些值是 **继承值**。在整个层次结构解析完毕后剩余的值就是 **有效值**—用于渲染对象的值。

例如，文本片段可能未定义自身的字体高度。它的本地 [FontHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/fontheight/) 为 `float.NaN`，表示“此处未设置”。该片段可以从其段落、演示文稿的默认文本样式或其他适用来源继承高度。对片段格式调用 [GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/geteffective/) 将返回最终解析后的高度。

针对不同需求使用这两种格式数据：

- 读取或更改本地格式对象，例如 [IPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/)，当您需要控制值的定义位置时。
- 读取有效数据对象，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformateffectivedata/)，当您需要最终渲染结果时。有效数据是只读的。

## **比较本地、继承和有效值**

以下完整示例创建一个形状，并在演示文稿、段落和片段级别应用字体高度。每一步都会打印这些级别定义的值以及同一文本片段的最终有效值。它还演示了为什么在格式更改后必须再次读取有效数据。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// 定义两个不同层级的继承值。
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// 片段上的本地值会覆盖两个继承值。
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// 更改继承值不会覆盖已有的本地值。
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// 清除本地值。片段现在再次从段落继承。
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// 清除段落值。演示文稿默认值现在提供结果。
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // 在前面的更改后读取有效数据。
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

此示例中的优先级是片段本地格式，其次是段落格式，最后是演示文稿默认值。其他对象可能具有不同的继承链，但原理相同：更具体的显式值会优先，并且 [GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/geteffective/) 返回最终结果。

## **获取有效文本属性**

文本格式分布在多个对象中：

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/geteffective/) 解析文本框属性，例如边距、锚定、自动适应和垂直文本方向。
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/zh/net/aspose.slides/itextstyle/geteffective/) 解析每个文本样式级别的段落格式。
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/geteffective/) 解析段落属性，例如对齐、缩进和项目符号。
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/geteffective/) 解析字符属性，例如字体高度、字形、颜色、粗体和斜体。

对于下一个示例，`text-formatting.pptx` 必须至少包含一张幻灯片和一个带有非空文本框的 [AutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/)。AutoShape 可以位于形状集合的任何位置；代码会搜索合适的对象并在使用前进行验证。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **获取有效的 3D 属性**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/geteffective/) 返回一个 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/) 对象，汇总所有解析后的 3D 设置。其 [Camera](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/camera/)、[LightRig](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/lightrig/)、[BevelTop](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/beveltop/) 和 [BevelBottom](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) 属性公开相应的有效数据。一起读取这些相关设置可更容易理解形状的最终 3D 外观。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **获取有效表格格式**

表格格式可以来自表格样式，也可以来自应用于整张表、列、行或单元格的格式。对于显式定义的填充冲突，优先级为单元格、行、列，然后是整张表。单元格的有效格式即用于绘制该单元格的最终格式。

对于此示例，`table-formatting.pptx` 必须在首张幻灯片上至少包含一张表。该表必须至少有一行和一列。代码会搜索一个 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/)，而不是假设 `Shapes[0]` 是表。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

如果您需要颜色而不仅仅是填充类型，首先检查有效的 [FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/ifillformateffectivedata/filltype/)，然后读取对应类型的属性——例如，对于实心填充读取 [SolidFillColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ifillformateffectivedata/solidfillcolor/)。

## **在更改后重新读取有效数据**

有效数据描述了解析时的格式层次结构。在更改任何可能参与该层次结构的内容后，请再次调用 `GetEffective`，包括：

- 对象的本地格式；
- 段落或文本框默认值；
- 表格样式、表格、列、行或单元格格式；
- 版面或母版幻灯片格式；
- 主题数据或演示文稿级别默认值；
- 分配给幻灯片的版面或母版。

不要将有效数据对象作为永久快照保存。Aspose.Slides 可能在内部缓存某些有效数据，后续的 `GetEffective` 调用可以刷新这些数据。如果需要比较更改前后的值，请在更改之前将所需的标量值（如字体高度、颜色、对齐方式或斜角宽度）复制到自己的变量中。

要更改值，请更新相应的本地格式对象，然后调用 `GetEffective` 验证结果。有效数据对象本身是只读的。

## **常见问题**

**我如何判断是哪个层级提供了有效值？**  
有效数据仅包含最终值，而不说明来源。请从最具体的层级向外检查相应的本地对象。对于文本，这可能包括片段、段落、文本框、版面、母版、主题和演示文稿默认值。`float.NaN` 或 `null` 等未定义值表示搜索会继续到更高层级。

**当没有任何层级定义属性时会发生什么？**  
Aspose.Slides 会解析出相应的 PowerPoint 或库默认值。该解析后的值会出现在有效数据中，即使没有本地对象显式定义它。

**为什么有效值有时等于本地值？**  
本地值在继承计算中获胜。当属性在对象上显式设置且没有更具体的规则覆盖时，会出现这种情况，属于预期行为。

**何时应该使用本地数据而不是有效数据？**  
当您需要检查或编辑特定的格式层级时使用本地数据。需要在继承、主题规则和适用样式全部解析后得到的最终外观时，使用有效数据。**完整比较示例**（#compare-local-inherited-and-effective-values）在同一工作流中展示了两者的使用方式。