---
title: Manage Presentation Shapes in C++
linktitle: Shape Manipulation
type: docs
weight: 40
url: /cpp/shape-manipulations/
keywords:
- PowerPoint shape
- presentation shape
- shape on slide
- find shape
- clone shape
- remove shape
- hide shape
- change shape order
- get interop shape ID
- shape alternative text
- shape layout formats
- shape as SVG
- shape to SVG
- align shape
- flip shape
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to identify, clone, remove, hide, reorder, export, align, and flip presentation shapes with Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides for C++ represents the shapes on a slide as an ordered [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/). The collection is both the place where you find and modify shapes and the source of their stacking order: index `0` is the backmost shape, while the last index is the frontmost shape.

This article follows that model. It first explains how to identify a shape reliably, then shows how to clone, remove, hide, and reorder shapes. The final sections cover layout-level formatting, SVG export, alignment, and flip settings. Each example is independent, so you can use only the operations your workflow requires.

## **Identify and Find Shapes**

Collection indexes are convenient while processing a known file, but they are not stable identifiers. Adding, removing, or reordering a shape can change its index. Choose an identifier according to how the presentation is authored and maintained:

- [Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) is useful for developer-controlled templates and is easy to inspect in PowerPoint's Selection Pane. Names can be edited and are not guaranteed to be unique, so establish a naming convention if code depends on them.
- [AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) is useful when an accessibility description or an author-supplied tag already identifies the shape. It is visible to users, may be localized or rewritten for accessibility, and is not guaranteed to be unique. Do not silently repurpose meaningful accessibility text as a database key.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) is a read-only identifier that is unique within a slide and corresponds to the shape ID used by PowerPoint interop. Use it when integrating with PowerPoint or when you need an unambiguous reference during the lifetime of a shape. A cloned or recreated shape is a different shape and receives its own ID.

The related [UniqueId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_uniqueid/) property has presentation scope, but it is intended for add-ins and can be reassigned. It should not be treated as a permanent external key. If long-term identity is essential, keep the mapping in application data and validate that the expected shape still exists.

The following example searches by `Name` and reports the slide-scoped interop ID. When the template does not contain the expected shape, the code reports that result instead of continuing with the wrong object.

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

When an operation is specific to a shape type, check the interface before using type-specific members. This example updates text and alternative text only if the named object is an [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

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

## **Modify the Shape Collection**

The add, clone, remove, and reorder methods operate on the collection immediately. If an operation changes the number or order of shapes, do not continue to rely on indexes captured before that operation.

### **Clone a Shape**

[AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addclone/) creates an independent copy and appends it to the target collection. [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/insertclone/) also creates a copy but places it at a specified z-order index. The overloads that accept coordinates move the clone without changing its size; overloads with width and height can resize it as well.

The example creates a destination slide, clones a labeled rectangle to the front, and inserts a second clone at the back. Changes to either clone do not modify the source shape.

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

Cloning copies the shape's content and formatting, including its name and alternative text. Assign new logical identifiers to the clone when those values must be unique. Resources used by complex shapes are handled by the presentation, but a clone remains a new collection item with a new shape identity.

### **Remove Shapes**

[Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) deletes a specific shape object from its collection. When removing multiple matches during indexed iteration, traverse from the end so that each remaining index stays valid.

This example removes every shape with a designated name. It reads the current indexed shape, not a fixed collection item, and it does not cast the shape unnecessarily.

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

After removal, the shape count and the indexes of later shapes change. References to unaffected shapes remain more reliable than saved indexes. Also consider connectors, animations, and other presentation features that may refer to the removed object; removing a visible shape can change more than the slide's appearance.

### **Hide a Shape**

Setting [Hidden](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_hidden/) to `true` keeps the shape in the collection but prevents it from appearing in the normal slide show. Its index, formatting, and content remain available to code, so hiding is appropriate for optional elements that may be restored later.

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

Hiding is not deletion or security. The object can still be discovered and unhidden by a user or by code, and it remains part of the presentation file.

### **Change the Z-Order**

Overlapping shapes are painted in collection order. [Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/) moves an existing shape to a target index without cloning it. Index `0` is the back; `Count - 1` is the front.

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

The rectangle is created first and initially sits behind the ellipse. Moving it to the final index puts it in front. Finalize z-order after adding or cloning all related shapes, because those operations append or insert new collection items and can alter the intended stack.

## **Inspect Shapes on Layout Slides**

Normal slides, layout slides, and master slides have separate shape collections. A shape in a layout collection is not the same object as a similarly positioned shape on a normal slide. Inspect layout shapes when you need to understand or change formatting supplied by a layout.

The following example reads each layout shape's [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_fillformat/) and [LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) without assuming that every shape is an `AutoShape`.

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

Editing a layout can affect multiple slides that use it. Before changing a layout shape, determine whether a normal slide inherits the object or contains a local override, and test every slide that uses that layout.

## **Export a Shape to SVG**

[WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) writes one shape's rendered content to a stream. The result contains the shape, not the entire slide background or neighboring shapes.

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

Keep the presentation open while rendering. The output depends on the shape's formatting and on resources such as fonts and images. If you need the whole composition, export the slide rather than an individual shape. The caller owns the stream and must close or dispose it.

## **Align Shapes**

The [SlideUtil::AlignShapes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/alignshapes/) overloads align either all shapes or selected collection indexes. [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/aspose.slides/shapesalignmenttype/) specifies the edge, center line, or distribution mode. Set `alignToSlide` to `true` to use the slide edges; set it to `false` to align the selected shapes relative to one another.

This example aligns three shapes to the top edge of the slide. The returned shape references are converted to their current indexes immediately before alignment.

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

Alignment changes positions, not z-order. Relative alignment normally needs at least two shapes, while horizontal or vertical distribution needs enough shapes to define spacing. Recompute indexes if you modify the collection before calling the method.

## **Flip a Shape**

The [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) class stores position, size, horizontal and vertical flip settings, and rotation. Its `FlipH` and `FlipV` values use [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/): `True` enables the flip, `False` disables it, and `NotDefined` preserves the unspecified/default state.

The input presentation below contains one unflipped shape.

![The shape before flipping](shape_to_be_flipped.png)

The example preserves every other frame value and replaces only the two flip settings. This is important because assigning a new [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_frame/) replaces the complete frame.

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

The saved shape is mirrored horizontally and vertically while keeping its position, size, and rotation.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Only for short-lived processing when the collection will not change before the index is used. Prefer a validated `Name` or `AlternativeText` convention for authored templates, or `OfficeInteropShapeId` for slide-scoped interop work.

**Does hiding a shape remove it from the z-order?**

No. A hidden shape remains in the collection at the same index. It can be found, reordered, edited, or made visible again.

**Why did a cloned shape appear in front of another shape?**

`AddClone` appends the clone to the end of the collection, which is the front of the z-order. Use `InsertClone` to choose the initial index or `Reorder` after all shapes have been added.
