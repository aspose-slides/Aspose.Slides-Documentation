---
title: 在 C++ 中从演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/cpp/shape-effective-properties/
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
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何计算并应用形状的有效属性，以实现精确的 PowerPoint 渲染。"
---
## **概述**

本主题解释 **本地** 和 **有效** 属性之间的区别。本地值是直接在特定格式级别设置的值，例如：

1. 幻灯片上的段落属性。
1. 原型形状文本样式在布局或母版幻灯片上，当该段落的文本框形状具有该样式时。
1. 演示文稿中的全局文本设置。

本地值可以在任何层级上定义或省略。当 Aspose.Slides 需要最终「实际渲染」的格式时，它会解析继承链并返回 **有效** 值。可以通过在本地格式对象上调用 `GetEffective` 方法来获取它们。

以下示例展示了如何获取有效值。假设第一张幻灯片上的第一个形状是一个带有文本框且至少包含一个段落的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。

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
有效格式数据表示在应用继承后计算得到的当前格式。在当前实现中，某些有效数据对象，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformateffectivedata/)，可能会在内部被缓存。在更改父级或继承的格式后再次调用 `GetEffective` 可以刷新缓存的数据，先前获取的对象可能不再代表之前的状态。如果需要保留有效值以供后续使用，请将所需的属性（例如字体高度、填充颜色、字体样式或对齐方式）复制到自己的数据对象中。
{{% /alert %}}

## **获取相机的有效属性**

Aspose.Slides 允许获取相机的有效属性。接口 [ICameraEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icameraeffectivedata/) 表示一个包含相机有效属性的不可变对象。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icameraeffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformateffectivedata/) 暴露，后者提供对 [IThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/) 的有效值。

以下代码示例展示了如何获取相机的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

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

## **获取灯光装置的有效属性**

Aspose.Slides 允许获取灯光装置的有效属性。接口 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilightrigeffectivedata/) 表示一个包含灯光装置有效属性的不可变对象。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilightrigeffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformateffectivedata/) 暴露，后者提供对 [IThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/) 的有效值。

以下代码示例展示了如何获取灯光装置的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

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

## **获取形状斜角的有效属性**

Aspose.Slides 允许获取形状斜角的有效属性。接口 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapebeveleffectivedata/) 表示一个包含形状面部斜角有效属性的不可变对象。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapebeveleffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformateffectivedata/) 暴露，后者提供对 [IThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/) 的有效值。

以下代码示例展示了如何获取形状顶部斜角的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

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

## **获取文本框的有效属性**

使用 Aspose.Slides，您可以获取文本框的有效属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformateffectivedata/) 接口包含文本框的有效格式属性。

以下代码示例展示了如何获取文本框的有效格式属性。假设第一张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。

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

## **获取文本样式的有效属性**

使用 Aspose.Slides，您可以获取文本样式的有效属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextstyleeffectivedata/) 接口包含文本样式的有效属性。

以下代码示例展示了如何获取文本样式的有效属性。假设第一张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。

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

## **获取有效字体高度值**

使用 Aspose.Slides，您可以获取有效的字体高度。以下代码演示了在演示文稿不同层级设置本地字体高度后，段落的有效字体高度如何变化。

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

## **获取表格的有效填充格式**

使用 Aspose.Slides，您可以获取表格不同部分的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifillformateffectivedata/) 接口包含有效的填充格式属性。单元格格式的优先级高于行格式，行格式优先于列格式，列格式优先于整个表格的格式。

因此，绘制表格单元格时使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icellformateffectivedata/) 的属性。以下代码示例展示了如何获取表格不同部分的有效填充格式。假设第一张幻灯片上的第一个形状是一个 [ITable](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itable/)。

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

## **常见问题**

**`GetEffective` 是否返回快照？**

并非总是如此。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能会在内部被缓存。后续调用 `GetEffective` 可能会重新计算格式并刷新缓存的数据，因此先前获取的对象不应被视为持久的快照。

**何时应重新读取有效属性？**

在更改本地格式、父样式、布局格式、母版格式或演示文稿级别的默认设置后，请再次调用 `GetEffective`。下次调用会重新评估格式层次并返回当前的有效结果。

**更改或删除布局/母版幻灯片会影响已检索的有效属性吗？**

会，但该更改会在下次调用 `GetEffective` 时生效。如果父级格式源被更改或移除，先前获取的有效数据可能已经过时。再次调用 `GetEffective` 后，Aspose.Slides 会重新评估格式树，导致字体、颜色、尺寸或其他值可能发生变化。

**我可以通过有效数据对象修改数值吗？**

不能。有效数据对象仅暴露计算后的值。请在本地格式对象中进行修改，然后再次获取有效值。

**如果属性既未在形状层级设置，也未在布局/母版或全局设置中设置，会怎样？**

有效值将由默认机制决定，其中包括 PowerPoint 和 Aspose.Slides 的默认值。该解析得到的值将成为当前有效数据的一部分。

**从有效的字体值，我能判断是哪个层级提供的大小或字体吗？**

无法直接判断。有效数据只返回最终值。若要查找来源，需要检查段落、段落、文本框以及布局、母版和演示文稿层级的文本样式中的本地值，找出首次出现的显式定义。

**为什么有效值有时看起来与本地值相同？**

因为本地值已经是最终值（不需要更高层级的继承）。在这种情况下，有效值与本地值相同。

**何时应该使用有效属性，何时仅使用本地属性？**

当需要在所有继承应用后得到“实际渲染”结果时（例如对齐颜色、缩进或大小），应使用有效数据。如果希望保留这些值而不受后续格式更改影响，请将所需属性复制到自己的对象中。如果需要在特定层级修改格式，请修改本地属性，然后在必要时再次读取有效数据以验证结果。