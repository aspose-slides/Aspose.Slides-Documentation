---
title: 從簡報中取得形狀的有效屬性（C++）
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/cpp/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 光源組
- 斜角形狀
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: 了解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中區分形狀的本地、繼承與有效格式設定。
---
## **了解本地、繼承與有效屬性**

PowerPoint 的格式化可能來自多個來源。直接儲存在物件上的值稱為 **本地值**。如果未設定該值，PowerPoint 會查看父層的格式來源，例如段落預設、文字樣式、版面或母片投影片、佈景主題，或是簡報層級的預設值。這些值稱為 **繼承值**。在整個層級解析完畢後剩餘的值即為 **有效值**——用來呈現物件的最終值。

例如，文字片段可能未自行定義字型高度。它的本地[字型高度](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/)會是 `std::numeric_limits<float>::quiet_NaN()`，表示「此處未設定」。該片段可以從段落、簡報的預設文字樣式或其他相關來源繼承高度。對片段格式呼叫[取得有效值](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)會回傳最終解析出的高度。

根據不同需求使用兩種格式化資料：

- 讀取或變更本地格式物件，例如[IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)，當您需要控制值的定義位置時。
- 讀取有效資料物件，例如[IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformateffectivedata/)，當您需要最終呈現的結果時。有效資料為唯讀。

## **比較本地、繼承與有效值**

以下完整範例會建立一個圖形，並在簡報、段落、片段層級設定字型高度。每一步都會列印這些層級所定義的值，以及同一文字片段的最終有效值。範例亦說明為何在格式變更後必須重新讀取有效資料。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// 在兩個不同層級定義繼承值。
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // 在先前的變更之後讀取有效資料。
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// 片段上的本地值會覆寫兩個繼承值。
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// 變更繼承值不會覆寫已存在的本地值。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// 清除本地值。片段現在再次從段落繼承。
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// 清除段落值。簡報預設現在提供結果。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

此範例的優先順序為：片段本地格式 > 段落格式 > 簡報預設。其他物件可能有不同的繼承鏈，但原則相同：較具體的明確值會贏得繼承計算，而[取得有效值](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)會返回最終結果。

## **取得有效文字屬性**

文字格式分散於多個物件：

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/) 解析文字框屬性，如邊距、錨點、自動調整與垂直文字方向。
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextstyle/) 解析每個文字樣式層級的段落格式。
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/) 解析段落屬性，如對齊、縮排與項目符號。
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/) 解析字元屬性，如字型高度、字型、顏色、粗體與斜體。

在下一個範例中，`text-formatting.pptx` 必須至少包含一張投影片與一個帶有非空文字框的[IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。IAutoShape 可以出現在圖形集合的任何位置；程式碼會搜尋合適的物件並在使用前驗證它。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **取得有效 3D 屬性**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/) 會回傳一個[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformateffectivedata/)物件，該物件彙總所有解析後的 3D 設定。其[相機](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icameraeffectivedata/)、[光源組](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilightrigeffectivedata/)、[上斜角](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapebeveleffectivedata/)與[下斜角](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapebeveleffectivedata/)資料皆公開相對應的有效設定。一次讀取這些相關設定，可更易於了解圖形的最終 3D 外觀。

此範例的 `shape-3d.pptx` 必須在第一張投影片上至少有一個圖形。若您希望輸出包含非預設值，請對該圖形套用 3D 相機、光源或斜角設定。

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **取得有效表格格式**

表格格式可以來源於表格樣式，也可以來源於套用於整張表格、欄、列或單一儲存格的格式。對於明確定義的填充，優先順序為儲存格 > 列 > 欄 > 整張表格。儲存格的有效格式即是繪製該儲存格時使用的最終格式。

此範例的 `table-formatting.pptx` 必須在第一張投影片上至少包含一個表格，且該表格至少有一列與一欄。程式碼會搜尋[ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/)，而不是假設第一個圖形就是表格。

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

如果您需要顏色而不只是填充類型，請先檢查有效的[FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformateffectivedata/)，再根據該類型讀取相應屬性——例如，對於實心填充可使用[SolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformateffectivedata/)。

## **變更後重新讀取有效資料**

有效資料描述了解析時的格式層級。變更任何可能參與該層級的項目後，請再次呼叫 `GetEffective`，包括：

- 物件的本地格式；
- 段落或文字框的預設值；
- 表格樣式、表格、欄、列或儲存格的格式；
- 版面或母片投影片的格式；
- 佈景主題或簡報層級的預設值；
- 指派給投影片的版面或母片。

不要將有效資料物件當作永久快照保存。Aspose.Slides 可能在內部快取部分有效資料，稍後的 `GetEffective` 呼叫會刷新這些資料。若需在變更前後比較值，請在變更前先將需要的標量值（例如字型高度、顏色、對齊或斜角寬度）複製到自己的變數中。

若要變更值，請更新相應的本地格式物件，然後呼叫 `GetEffective` 以驗證結果。有效資料物件本身為唯讀。

## **FAQ**

**我該如何判斷是哪個層級提供了有效值？**

有效資料只包含最終值，未說明其來源。請從最具體的層級向外檢查相關的本地物件。對於文字，可能包括片段、段落、文字框、版面、母片、佈景主題與簡報預設值。`std::numeric_limits<float>::quiet_NaN()` 或 `nullptr` 等未定義值表示搜尋會繼續到更上層。

**如果沒有任何層級定義屬性會發生什麼？**

Aspose.Slides 會解析出相應的 PowerPoint 或程式庫預設值。即使沒有本地物件明確定義，解析後的值仍會出現在有效資料中。

**為什麼有效值有時會等於本地值？**

本地值在繼承計算中獲勝。當屬性在物件上已明確設定且沒有更具體的規則覆寫時，就會出現此情況，這是正常的。

**什麼時候應使用本地資料而非有效資料？**

當您需要檢查或編輯特定層級的格式時，使用本地資料。當您需要在繼承、佈景規則與相關樣式解析後的最終外觀時，使用有效資料。完整的[比較本地、繼承與有效值範例](#compare-local-inherited-and-effective-values)在同一工作流程中示範了兩者的使用方式。