---
title: 在 .NET 中管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/net/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取互操作形状 ID
- 形状替代文本
- 形状调整点
- 预设形状调整
- 形状几何
- 形状布局格式
- 形状为 SVG
- 形状转换为 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 识别、调整、克隆、删除、隐藏、重新排序、导出、对齐和翻转演示文稿形状。"
---
## **概述**

Aspose.Slides for .NET 将幻灯片上的形状表示为有序的 [IShapeCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/)。该集合既是查找和修改形状的场所，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，最后一个索引为最前层形状。

本文遵循该模型。首先说明如何可靠地识别形状并修改预设形状的调整点，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节涉及布局级别的格式设置、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以只使用工作流所需的操作。

## **识别并查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的编写和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/name/) 适用于开发者可控的模板，并且在 PowerPoint 的“选择窗格”中易于检查。名称可以编辑，但不保证唯一，因此如果代码依赖名称，需要建立命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/alternativetext/) 适用于已经通过可访问性描述或作者提供的标签标识形状的情况。它对用户可见，可能会本地化或为可访问性重写，但也不保证唯一。不要将有意义的可访问性文本静默用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/officeinteropshapeid/) 是只读标识符，在同一幻灯片内唯一，并对应 PowerPoint 互操作使用的形状 ID。将在与 PowerPoint 集成或在形状生命周期内需要明确引用时使用。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的 [UniqueId](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/uniqueid/) 属性作用于整个演示文稿，但仅供插件使用且可能被重新分配。它不应被视为永久的外部键。如果长期身份至关重要，请在应用程序数据中保存映射并验证期望的形状仍然存在。

有关读取和更新替代文本标题及描述的实际示例，请参阅 [Manage Alternative Text Titles and Descriptions](/slides/zh/net/presentation-accessibility/)。使用替代文本向阅读器解释视觉内容的含义，并将其与代码用于查找形状的名称分离。

下面的示例使用序数比较按 `Name` 搜索，并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误的对象。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

当操作特定于某种形状类型时，请在使用类型特定成员之前检查接口。此示例仅在命名对象是 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 时更新文本和替代文本。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **识别并修改预设形状调整**

预设几何形状可以公开控制角大小、箭头比例或弧度等特性的调整点。通过只读的 [IGeometryShape.Adjustments](https://reference.aspose.com/slides/zh/net/aspose.slides/igeometryshape/adjustments/) 集合访问它们。该集合本身由形状提供，但每个 [IAdjustValue](https://reference.aspose.com/slides/zh/net/aspose.slides/iadjustvalue/) 包含一个可更改的值。

不要仅依赖固定的集合索引。遍历调整项并检查只读的 [Type](https://reference.aspose.com/slides/zh/net/aspose.slides/adjustvalue/type/) 属性，其 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh/net/aspose.slides/shapeadjustmenttype/) 值描述了该调整控制的内容。只读的 [Name](https://reference.aspose.com/slides/zh/net/aspose.slides/adjustvalue/name/) 属性提供了额外的标识信息，特别是在预设包含多个具有相同语义类型的调整时非常有用。

使用与调整意义相匹配的值属性：

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | 圆角的大小 | [RawValue](https://reference.aspose.com/slides/zh/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | 箭头尾部的粗细 | `RawValue` |
| `ArrowheadLength` | 箭头头部的长度 | `RawValue` |
| `ArrowheadWidth` | 箭头头部的宽度 | `RawValue` |
| `StartAngle` | 饼图或弧线的起始角度 | [AngleValue](https://reference.aspose.com/slides/zh/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | 饼图或弧线的结束角度 | `AngleValue` |

`Type` 和 `Name` 不能赋值。`RawValue` 是预设原生几何单位的可读写整数，而 `AngleValue` 是以度为单位的可读写角度。调整项的数量、顺序、含义以及有效范围取决于预设的 [ShapeType](https://reference.aspose.com/slides/zh/net/aspose.slides/igeometryshape/shapetype/)。对一种预设有效的值在另一种预设中可能无效或产生不同效果。

当 `Type` 为 `ShapeAdjustmentType.Custom` 时，API 不识别标准语义含义。检查 `Name`、预设类型以及现有值，除非已知预期含义和范围，否则保持调整不变。即使是已识别的类型，在选择值之前也要检查同一类型是否出现多次。[Connector](/slides/zh/net/connector/) 文章展示了连接器弯曲调整的这种情况。

下面的完整示例创建了三种预设形状的默认和修改版本。它遍历每个调整，报告其 `Name` 和 `Type`，通过 `RawValue` 更改与尺寸相关的值，通过 `AngleValue` 更改角度，并保存结果。左列保留默认几何，右列显示调整后的圆角矩形、四向箭头和饼形。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// 为默认和调整后的形状列添加标题。
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

在更改值之前检查语义类型使代码对意图更加明确，避免假设特定集合索引在不同预设形状中具有相同含义。

## **修改形状集合**

添加、克隆、删除和重新排序方法会立即作用于集合。如果操作改变了形状的数量或顺序，请勿继续依赖操作前捕获的索引。

### **克隆形状**

[AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addclone/) 创建一个独立的副本并将其追加到目标集合。[InsertClone](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/insertclone/) 也创建副本，但将其放置在指定的 Z 顺序索引处。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载则可以对其进行缩放。

示例创建了一个目标幻灯片，将标记的矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改都不会影响源形状。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

克隆会复制形状的内容和格式，包括其名称和替代文本。当这些值必须唯一时，为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍是具有新形状身份的集合新项。

### **删除形状**

[Remove](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/remove/) 从其集合中删除特定的形状对象。在索引迭代期间删除多个匹配项时，请从末尾向前遍历，以保持剩余索引有效。

此示例删除所有具有指定名称的形状。它读取 `slide.Shapes[i]`，而不是固定的集合项，并且没有不必要地强制转换形状。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

删除后，形状计数以及后续形状的索引会发生变化。对未受影响的形状保持引用比保存的索引更可靠。同时考虑连接器、动画和其他可能引用已删除对象的演示功能；删除可见形状可能会改变幻灯片的外观以外的内容。

### **隐藏形状**

将 [Hidden](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/hidden/) 设置为 `true` 可保持形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于可能稍后恢复的可选元素。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

隐藏并非删除或安全措施。对象仍可以被用户或代码发现并取消隐藏，并且仍是演示文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[Reorder](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/reorder/) 将已存在的形状移动到目标索引而不进行克隆。索引 `0` 为最底层，`Count - 1` 为最前层。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

矩形最先创建，最初位于椭圆后面。将其移动到最终索引后会出现在前面。添加或克隆所有相关形状后再完成 Z 顺序的最终确定，因为这些操作会追加或插入新集合项，从而改变预期的堆叠顺序。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状与普通幻灯片上位置相同的形状不是同一对象。需要理解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的 [FillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/fillformat/) 和 [LineFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/lineformat/)，并且不假设每个形状都是 `AutoShape`。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

编辑布局可能会影响使用该布局的多个幻灯片。在更改布局形状之前，请确定普通幻灯片是继承该对象还是包含本地覆盖，并测试所有使用该布局的幻灯片。

## **将形状导出为 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/writeassvg/) 将单个形状的渲染内容写入流。结果只包含该形状，而不是整个幻灯片的背景或相邻形状。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

在渲染期间保持演示文稿打开。输出受形状格式以及字体、图像等资源的影响。如果需要整个组合，请导出幻灯片而不是单个形状。调用方拥有该流并负责释放。

## **对齐形状**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/alignshapes/) 的重载可以对齐所有形状或选定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/net/aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设置为 `false` 则相对于彼此对齐选定形状。

此示例将三个形状对齐到幻灯片的上边缘。返回的形状引用在对齐前立即转换为其当前索引。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

对齐会改变位置，而不是 Z 顺序。相对对齐通常至少需要两个形状，而水平或垂直分布则需要足够的形状来确定间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `FlipH` 和 `FlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh/net/aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用翻转，`NotDefined` 保持未指定/默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![The shape before flipping](shape_to_be_flipped.png)

示例保留其他所有帧值，仅替换两个翻转设置。这一点很重要，因为为 [Frame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/frame/) 分配新值会替换完整的帧。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

保存后的形状在水平和垂直方向上均为镜像，同时保持其位置、大小和旋转。

![The shape after flipping](flipped_shape.png)

## **常见问题**

**是否应该使用集合索引作为形状标识符？**

仅在集合在使用索引前不会改变的短期处理场景中使用。对于已编写的模板，首选经验证的 `Name` 或 `AlternativeText` 约定；对于幻灯片范围的互操作工作，使用 `OfficeInteropShapeId`。

**隐藏形状会将其从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合中的相同索引。它仍然可以被查找、重新排序、编辑或再次显示。

**为什么克隆的形状会出现在另一个形状前面？**

`AddClone` 将克隆追加到集合末尾，即 Z 顺序的前面。使用 `InsertClone` 可选择初始索引，或在添加完所有形状后使用 `Reorder`。

**是否可以使用固定索引来识别预设形状调整？**

仅在验证了确切的预设和集合布局后才可以。更推荐遍历 `IGeometryShape.Adjustments` 并检查 `IAdjustValue.Type`；如果同一语义类型出现多次，可使用 `IAdjustValue.Name` 作为额外信息。