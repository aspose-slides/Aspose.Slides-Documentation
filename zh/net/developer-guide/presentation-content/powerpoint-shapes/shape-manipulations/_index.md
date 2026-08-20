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
- 移除形状
- 隐藏形状
- 更改形状顺序
- 获取互操作形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 识别、克隆、移除、隐藏、重新排序、导出、对齐和翻转演示文稿形状。"
---
## **概述**

Aspose.Slides for .NET 将幻灯片上的形状表示为有序的[IShapeCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/)。该集合既是查找和修改形状的地点，也是它们堆叠顺序的来源：索引 `0` 为最靠后形状，最后的索引为最前面的形状。

本文遵循该模型。首先解释如何可靠地识别形状，然后展示如何克隆、移除、隐藏和重新排序形状。最后的章节涵盖布局级格式化、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以仅使用工作流需要的操作。

## **识别和查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、移除或重新排序形状都会改变其索引。请根据演示文稿的编写和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/name/) 对于开发者控制的模板很有用，并且可以在 PowerPoint 的“选择窗格”中轻松检查。名称可以编辑，但不保证唯一，因此如果代码依赖名称，请建立命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/alternativetext/) 在可访问性描述或作者提供的标签已经标识形状时很有用。它对用户可见，可能会本地化或为可访问性重新编写，但也不保证唯一。不要悄悄将有意义的可访问性文本用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/officeinteropshapeid/) 是只读标识符，在同一幻灯片内唯一，对应 PowerPoint 互操作使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的场景。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的[UniqueId](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/uniqueid/)属性具有演示文稿范围，但主要供插件使用，且可以重新分配。它不应被视为永久的外部键。如果长期身份至关重要，请在应用程序数据中保存映射并验证期望的形状仍然存在。

下面的示例按 `Name` 进行序数比较搜索，并报告幻灯片范围的 interop ID。当模板不包含期望的形状时，代码会报告该结果而不是继续使用错误的对象。

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

## **修改形状集合**

add、clone、remove 和 reorder 方法会立即作用于集合。如果操作更改了形状的数量或顺序，请不要继续依赖操作前捕获的索引。

### **克隆形状**

[AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addclone/) 创建一个独立的副本并将其追加到目标集合。[InsertClone](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/insertclone/) 也会创建副本，但将其放置在指定的 Z 顺序索引。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载还能对其进行缩放。

示例创建目标幻灯片，将标记矩形克隆到前面，并在后面插入第二个克隆。对任意克隆的更改都不会影响源形状。

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

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍是具有新形状标识的新集合项。

### **移除形状**

[Remove](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/remove/) 从其集合中删除特定的形状对象。在索引迭代期间移除多个匹配项时，请从末尾向前遍历，以确保每个剩余索引保持有效。

此示例移除所有具有指定名称的形状。它读取 `slide.Shapes[i]`，而不是固定的集合项，并且没有不必要地转换形状类型。

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

移除后，形状计数以及后续形状的索引都会变化。对未受影响形状的引用比保存的索引更可靠。同时考虑连接线、动画以及可能引用被移除对象的其他演示功能；移除可见形状可能会改变幻灯片外观之外的内容。

### **隐藏形状**

将 [Hidden](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/hidden/) 设置为 `true` 可让形状仍保留在集合中，但在普通幻灯片放映中不出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于以后可能恢复的可选元素。

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

隐藏并不等同于删除或安全措施。用户或代码仍可以发现并取消隐藏该对象，它仍然是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[Reorder](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/reorder/) 将现有形状移动到目标索引，且不会克隆它。索引 `0` 为后置，`Count - 1` 为前置。

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

矩形最先创建，最初位于椭圆后面。将其移动到最后一个索引后会位于前面。添加或克隆所有相关形状后再确定 Z 顺序，因为这些操作会追加或插入新的集合项，可能会改变原本的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状与普通幻灯片上位置相同的形状不是同一个对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的[FillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/fillformat/)和[LineFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/lineformat/)，而不假设每个形状都是 `AutoShape`。

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

编辑布局可能影响使用该布局的多个幻灯片。更改布局形状前，请确定普通幻灯片是继承该对象还是包含本地覆盖，并对使用该布局的每张幻灯片进行测试。

## **将形状导出为 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/writeassvg/) 将单个形状的渲染内容写入流。结果只包含该形状，而不包括整个幻灯片背景或相邻形状。

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

渲染时请保持演示文稿打开。输出取决于形状的格式以及字体、图像等资源。如果需要完整的组合，请导出整张幻灯片而不是单个形状。调用者拥有该流并必须自行释放。

## **对齐形状**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/alignshapes/) 的重载可以对齐所有形状或选定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/net/aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设置为 `false` 则相对于彼此对齐选中形状。

此示例将三个形状对齐到幻灯片的顶部边缘。返回的形状引用在对齐前立即转换为当前索引。

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

对齐会改变位置，而不是 Z 顺序。相对对齐通常需要至少两个形状，而水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `FlipH` 和 `FlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh/net/aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用，`NotDefined` 保持未定义/默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留其他所有框架值，仅替换两个翻转设置。这一点很重要，因为为形状分配新的 [Frame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/frame/) 会替换整个框架。

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

保存后的形状在保持位置、大小和旋转的同时，实现了水平和垂直镜像。

![翻转后的形状](flipped_shape.png)

## **FAQ**

**我应该使用集合索引作为形状标识符吗？**

仅在短期处理且在使用索引之前集合不会改变的情况下使用。对于编写好的模板，建议使用经验证的 `Name` 或 `AlternativeText` 约定；对于需要幻灯片范围互操作的工作，使用 `OfficeInteropShapeId`。

**隐藏形状会将其从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合中，索引不变。它仍然可以被查找、重新排序、编辑或再次显示。

**为什么克隆的形状会出现在另一个形状的前面？**

`AddClone` 将克隆追加到集合的末尾，而集合末尾对应 Z 顺序的最前面。使用 `InsertClone` 可以选择初始索引，或在添加完所有形状后使用 `Reorder` 调整顺序。