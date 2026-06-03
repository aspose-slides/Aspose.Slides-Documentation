---
title: Get Shape Effective Properties from Presentations in C++
linktitle: Effective Properties
type: docs
weight: 50
url: /cpp/shape-effective-properties/
keywords:
- shape properties
- camera properties
- light rig
- bevel shape
- text frame
- text style
- font height
- fill format
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Discover how Aspose.Slides for C++ calculates and applies effective shape properties for precise PowerPoint rendering."
---

## **Overview**

This topic explains the difference between **local** and **effective** properties. Local values are values that are set directly at a specific formatting level, such as:

1. Portion properties on a slide.
1. Prototype shape text styles on a layout or master slide, when the portion's text frame shape has one.
1. Global text settings in a presentation.

Local values can be defined or omitted at any level. When Aspose.Slides needs the final "as rendered" formatting, it resolves the inheritance chain and returns **effective** values. You can get them by calling the `GetEffective` method on the local format object.

The following example shows how to get effective values. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) with a text frame and at least one portion.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}

Effective formatting data represents the current calculated formatting after inheritance is applied. In the current implementation, some effective data objects, such as [IPortionFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformateffectivedata/), may be cached internally. Calling `GetEffective` again after changing parent or inherited formatting can refresh the cached data, and a previously obtained object may no longer represent the earlier state. If you need to preserve effective values for later reuse, copy the required properties, such as font height, fill color, font style, or alignment, into your own data object.

{{% /alert %}}

## **Get Effective Properties of a Camera**

Aspose.Slides allows you to get effective properties of a camera. The [ICameraEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/icameraeffectivedata/) interface represents an immutable object that contains effective camera properties. An [ICameraEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/icameraeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the camera. It assumes that the first shape on the first slide has 3D formatting.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Get Effective Properties of a Light Rig**

Aspose.Slides allows you to get effective properties of a light rig. The [ILightRigEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrigeffectivedata/) interface represents an immutable object that contains effective light rig properties. An [ILightRigEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrigeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the light rig. It assumes that the first shape on the first slide has 3D formatting.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Get Effective Properties of a Bevel Shape**

Aspose.Slides allows you to get effective properties of a shape bevel. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ishapebeveleffectivedata/) interface represents an immutable object that contains effective face-relief properties for a shape. An [IShapeBevelEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ishapebeveleffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the top bevel of a shape. It assumes that the first shape on the first slide has 3D formatting.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Get Effective Properties of a Text Frame**

Using Aspose.Slides, you can get effective properties of a text frame. The [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformateffectivedata/) interface contains effective text frame formatting properties.

The following code sample shows how to get effective text frame formatting properties. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) with a text frame.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Get Effective Properties of a Text Style**

Using Aspose.Slides, you can get effective properties of a text style. The [ITextStyleEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/itextstyleeffectivedata/) interface contains effective text style properties.

The following code sample shows how to get effective text style properties. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) with a text frame.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Get the Effective Font Height Value**

Using Aspose.Slides, you can get the effective font height. The following code demonstrates how a portion's effective font height changes after local font height values are set at different presentation structure levels.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Get the Effective Fill Format for a Table**

Using Aspose.Slides, you can get effective fill formatting for different table parts. The [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/) interface contains effective fill formatting properties. Cell formatting has higher priority than row formatting, row formatting has higher priority than column formatting, and column formatting has higher priority than whole-table formatting.

As a result, [ICellFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/icellformateffectivedata/) properties are used to draw the table cell. The following code sample shows how to get effective fill formatting for different table parts. It assumes that the first shape on the first slide is an [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

**Does `GetEffective` return a snapshot?**

Not always. Effective data represents the calculated formatting after inheritance is applied, but some effective data objects can be cached internally. A subsequent `GetEffective` call may recalculate formatting and refresh the cached data, so a previously obtained object should not be treated as a durable snapshot.

**When should I read effective properties again?**

Call `GetEffective` again after changing local formatting, parent styles, layout formatting, master formatting, or presentation-level defaults. The next call re-evaluates the formatting hierarchy and returns the current effective result.

**Does changing or removing a layout/master slide affect effective properties that have already been retrieved?**

Yes, but the change is reflected on the next `GetEffective` call. If a parent formatting source is changed or removed, previously obtained effective data may be stale. Once `GetEffective` is called again, Aspose.Slides re-evaluates the formatting tree and the resulting fonts, colors, sizes, or other values may change.

**Can I modify values through effective data objects?**

No. Effective data objects expose calculated values. Make changes in the local formatting objects, and then obtain the effective values again.

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

The effective value is determined by the default mechanism, which includes PowerPoint and Aspose.Slides defaults. That resolved value becomes part of the current effective data.

**From an effective font value, can I tell which level provided the size or typeface?**

Not directly. Effective data returns the final value. To find the source, check local values at the portion, paragraph, text frame, and text styles at the layout, master, and presentation levels to see where the first explicit definition appears.

**Why do effective values sometimes look identical to the local ones?**

Because the local value ended up being final (no higher-level inheritance was needed). In such cases, the effective value matches the local one.

**When should I use effective properties, and when should I work only with local ones?**

Use effective data when you need the "as rendered" result after all inheritance is applied, such as to align colors, indents, or sizes. If you need to preserve those values regardless of later formatting changes, copy the required properties into your own object. If you need to change formatting at a specific level, modify local properties and then, if needed, read the effective data again to verify the outcome.
