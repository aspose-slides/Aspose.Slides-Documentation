---
title: 在 C++ 中從簡報取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/cpp/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 光源裝置
- 斜角形狀
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何計算並套用形狀的有效屬性，以實現精確的 PowerPoint 呈現。"
---
## **概覽**

本主題說明 **local** 與 **effective** 屬性之間的差異。Local 值是直接在特定格式層級設定的值，例如：

1. 投影片上的 Portion 屬性。
1. 版面或母片投影片中原型形狀的文字樣式，當該 Portion 的文字框形狀具有此樣式時。
1. 簡報中的全域文字設定。

Local 值可以在任何層級定義或省略。當 Aspose.Slides 需要最終的「如同渲染」格式時，它會解析繼承鏈並返回 **effective** 值。您可以透過對本地格式物件呼叫 `GetEffective` 方法來取得它們。

以下範例示範如何取得 effective 值。假設第一張投影片上的第一個形狀是具有文字框且至少包含一個 Portion 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。

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
Effective formatting data 代表在套用繼承後目前計算出的格式。在目前的實作中，某些 effective 資料物件，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformateffectivedata/)，可能會在內部快取。於變更父層或繼承的格式後再次呼叫 `GetEffective` 可以重新整理快取的資料，而先前取得的物件可能不再代表先前的狀態。若您需要保留 effective 值以供日後重複使用，請將所需的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。
{{% /alert %}}

## **取得相機的 Effective 屬性**

Aspose.Slides 允許您取得相機的 effective 屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icameraeffectivedata/) 介面代表一個不可變的物件，內含相機的 effective 屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformateffectivedata/) 可取得 [ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icameraeffectivedata/) 實例，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/) 的 effective 值。

以下程式碼範例示範如何取得相機的 effective 屬性。假設第一張投影片上的第一個形狀具有 3D 格式設定。

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

## **取得光源裝置的 Effective 屬性**

Aspose.Slides 允許您取得光源裝置的 effective 屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilightrigeffectivedata/) 介面代表一個不可變的物件，內含光源裝置的 effective 屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformateffectivedata/) 可取得 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilightrigeffectivedata/) 實例，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/) 的 effective 值。

以下程式碼範例示範如何取得光源裝置的 effective 屬性。假設第一張投影片上的第一個形狀具有 3D 格式設定。

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

## **取得斜角形狀的 Effective 屬性**

Aspose.Slides 允許您取得形狀斜角的 effective 屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapebeveleffectivedata/) 介面代表一個不可變的物件，內含形狀的斜角面效果屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformateffectivedata/) 可取得 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapebeveleffectivedata/) 實例，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/) 的 effective 值。

以下程式碼範例示範如何取得形狀頂部斜角的 effective 屬性。假設第一張投影片上的第一個形狀具有 3D 格式設定。

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

## **取得文字框的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字框的 effective 屬性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformateffectivedata/) 介面包含文字框的 effective 格式屬性。

以下程式碼範例示範如何取得文字框的 effective 格式屬性。假設第一張投影片上的第一個形狀是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。

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

## **取得文字樣式的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字樣式的 effective 屬性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextstyleeffectivedata/) 介面包含文字樣式的 effective 屬性。

以下程式碼範例示範如何取得文字樣式的 effective 屬性。假設第一張投影片上的第一個形狀是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。

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

## **取得 Effective 字型高度值**

使用 Aspose.Slides，您可以取得 effective 字型高度。以下程式碼示範在不同簡報結構層級設定本地字型高度後，Portion 的 effective 字型高度如何變化。

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

## **取得表格的 Effective 填充格式**

使用 Aspose.Slides，您可以取得不同表格部份的 effective 填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformateffectivedata/) 介面包含 effective 填充格式屬性。儲存格格式的優先權高於列格式，列格式的優先權高於欄格式，欄格式的優先權高於整表格式。

因此，會使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icellformateffectivedata/) 的屬性來繪製表格儲存格。以下程式碼範例示範如何取得不同表格部份的 effective 填充格式。假設第一張投影片上的第一個形狀是 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/)。

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

## **常見問題**

**`GetEffective` 會回傳快照嗎？**

不一定。Effective 資料代表套用繼承後計算出的格式，但某些 effective 資料物件可能在內部被快取。隨後再次呼叫 `GetEffective` 可能會重新計算格式並重新整理快取的資料，因此先前取得的物件不應被視為永久快照。

**什麼時候需要再次讀取 effective 屬性？**

在變更本地格式、父層樣式、版面格式、母片格式或簡報層級的預設值後，請再次呼叫 `GetEffective`。下一次呼叫會重新評估格式層級並返回目前的 effective 結果。

**變更或移除版面/母片投影片會影響已取得的 effective 屬性嗎？**

會，變更會在下次呼叫 `GetEffective` 時反映。如果父層格式來源被變更或移除，先前取得的 effective 資料可能已陳舊。再次呼叫 `GetEffective` 後，Aspose.Slides 會重新評估格式樹，字型、顏色、大小或其他值可能會改變。

**可以透過 effective 資料物件修改值嗎？**

不能。Effective 資料物件僅提供計算出的值。請在本地格式物件上做修改，然後再次取得 effective 值。

**如果在形狀層級、版面/母片或全域設定皆未設定某屬性，會發生什麼？**

effective 值會由預設機制決定，包含 PowerPoint 與 Aspose.Slides 的預設值。解析出的值會成為目前的 effective 資料的一部份。

**從 effective 字型值能否判斷是哪個層級提供的大小或字型？**

無法直接判斷。Effective 資料只返回最終值。若要找出來源，必須檢查 Portion、段落、文字框以及版面、母片和簡報層級的本地值，以確認第一個明確定義出現的位置。

**為什麼 effective 值有時看起來與本地值相同？**

因為本地值最終即為最終值（不需要較高層級的繼承）。在此情況下，effective 值與本地值相同。

**什麼時候應使用 effective 屬性，什麼時候只使用本地屬性？**

在需要「如同渲染」的最終結果（例如對齊顏色、縮排或尺寸）時使用 effective 資料。如果您需要在格式變更後保留這些值，請將必要的屬性複製到自己的物件中。若要在特定層級修改格式，請修改本地屬性，然後在需要時再次讀取 effective 資料以驗證結果。