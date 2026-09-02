---
title: 管理 C++ 中的演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/cpp/shape-manipulations/
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
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 识别、克隆、删除、隐藏、重新排序、导出、对齐和翻转演示文稿形状。"
---
## **概述**

Aspose.Slides for C++ 将幻灯片上的形状表示为有序的[IShapeCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/)。该集合既是查找和修改形状的地点，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，最后一个索引为最前层形状。

本文遵循该模型。首先说明如何可靠地识别形状，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节涵盖布局级格式、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以仅使用工作流所需的操作。

## **识别并查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的创建和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_name/) 适用于开发者控制的模板，且在 PowerPoint 的“选择窗格”中易于检查。名称可以编辑，但不保证唯一，因此如果代码依赖名称，请制定命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_alternativetext/) 在已有可访问性描述或作者提供的标签时很有用。它对用户可见，可能会本地化或为可访问性重写，且不保证唯一。不要在不知情的情况下将有意义的可访问性文本用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_officeinteropshapeid/) 是只读标识符，在幻灯片内唯一，并对应 PowerPoint 互操作使用的形状 ID。在与 PowerPoint 集成或需要在形状生命周期内拥有明确引用时使用。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的[UniqueId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_uniqueid/)属性范围是整个演示文稿，但它面向插件并可能被重新分配。不要将其视为永久的外部键。如果长期身份至关重要，请将映射保存在应用程序数据中，并验证期望的形状仍然存在。

下面的示例按 `Name` 搜索并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误的对象。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

当操作特定于某种形状类型时，请在使用特定成员前检查接口。此示例仅在命名对象是[IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)时更新文本和替代文本。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **修改形状集合**

添加、克隆、删除和重新排序方法会立即作用于集合。如果操作改变了形状的数量或顺序，请不要继续依赖该操作前捕获的索引。

### **克隆形状**

[AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addclone/) 创建独立副本并将其追加到目标集合。[InsertClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/insertclone/) 也创建副本，但将其放置在指定的 Z 顺序索引处。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载还能对其进行缩放。

示例创建目标幻灯片，将带标签的矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改都不会影响源形状。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿自行处理，但克隆仍然是具有新形状标识的新集合项。

### **删除形状**

[Remove](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/remove/) 删除集合中的特定形状对象。在索引迭代期间删除多个匹配项时，请从末尾向前遍历，以保持剩余索引的有效性。

此示例删除所有具有指定名称的形状。它读取的是当前索引的形状，而不是固定的集合项，并且没有不必要地进行类型转换。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

删除后，形状计数以及后续形状的索引会改变。对未受影响形状的引用比保存的索引更可靠。同时请考虑连接线、动画和其他可能引用被删除对象的演示功能；删除可见形状可能会改变幻灯片外观之外的内容。

### **隐藏形状**

将[Hidden](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/set_hidden/)设置为 `true` 可保持形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于以后可能恢复的可选元素。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

隐藏并不等同于删除或安全保护。对象仍然可以被用户或代码发现并取消隐藏，并且仍然是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠形状按照集合顺序绘制。[Reorder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/reorder/) 将现有形状移动到目标索引而不进行克隆。索引 `0` 为最底层，`Count - 1` 为最顶层。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

矩形最初创建时位于椭圆后面。将其移动到最终索引后位于前面。请在添加或克隆所有相关形状之后再完成 Z 顺序的最终确定，因为这些操作会追加或插入新的集合项，从而改变原本的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自独立的形状集合。布局集合中的形状并非普通幻灯片上同位置形状的同一对象。当需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的[FillFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_fillformat/)和[LineFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_lineformat/)，并未假设每个形状都是 `AutoShape`。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

编辑布局可能会影响使用该布局的多个幻灯片。更改布局形状前，请确定普通幻灯片是继承该对象还是拥有本地覆盖，并对所有使用该布局的幻灯片进行测试。

## **将形状导出为 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/writeassvg/) 将单个形状的渲染内容写入流。结果只包含该形状，而不包含整个幻灯片背景或相邻形状。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

在渲染期间保持演示文稿打开。输出取决于形状的格式以及字体、图像等资源。如果需要整个合成，请导出幻灯片而不是单个形状。调用方拥有该流并需要自行关闭或释放。

## **对齐形状**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/alignshapes/) 的重载可以对齐所有形状或选定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 可使用幻灯片边缘；设置为 `false` 则相对选定形状进行对齐。

此示例将三个形状对齐到幻灯片的上边缘。对齐前会立即将返回的形状引用转换为当前索引。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

对齐会改变位置，而不是 Z 顺序。相对对齐通常需要至少两个形状，而水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `FlipH` 和 `FlipV` 值使用[NullableBool](https://reference.aspose.com/slides/zh/cpp/aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用翻转，`NotDefined` 保持未指定/默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留了其他所有框架值，仅替换了两个翻转设置。这一点很重要，因为为[Frame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/set_frame/)赋新值会替换完整的框架。

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

保存后的形状在水平和垂直方向上均被镜像，同时保持其位置、大小和旋转。

![翻转后的形状](flipped_shape.png)

## **常见问题解答**

**我应该使用集合索引作为形状标识符吗？**

仅在短期处理且集合在使用索引前不会改变的情况下可以。对于已编写的模板，请首选经过验证的 `Name` 或 `AlternativeText` 约定；对于幻灯片范围的互操作工作，请使用 `OfficeInteropShapeId`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合的相同索引处。它仍然可以被查找、重新排序、编辑或再次显示。

**为什么克隆的形状出现在另一个形状的前面？**

`AddClone` 将克隆追加到集合的末尾，而末尾对应 Z 顺序的最前面。使用 `InsertClone` 可选择初始索引，或在所有形状添加完毕后使用 `Reorder` 调整顺序。