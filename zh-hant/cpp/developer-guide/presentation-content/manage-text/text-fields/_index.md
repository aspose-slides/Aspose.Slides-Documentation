---
title: 在 C++ 中管理 PowerPoint 簡報的文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/cpp/text-fields/
keywords:
- 文字欄位
- 自動文字
- 投影片編號
- 日期與時間
- 頁首
- 頁尾
- 文字部分
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立、檢查、修改以及移除文字欄位。保留格式並檢查已儲存的 PPTX 與 PPT 檔案。"
---
## **概觀**

文字段落由多個部分組成。普通的 [IPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/) 包含文字字面值；欄位部分還具有一個 [IField](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifield/) ，其類型表示自動更新的值，例如投影片編號或日期。兩個部分可以顯示相同的字元，但只有一個包含欄位。

使用 [IPortion::get_Field](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/get_field/) 來區分它們：普通文字會傳回 `nullptr`。[IPortion::AddField](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/addfield/) 會將現有的部分轉換為欄位。將標籤與其動態值放在不同的部分中，這樣轉換值時不會同時取代標籤。

此指南涵蓋文字內的欄位、其格式設定以及在 PPTX 與 PPT 中的儲存。關於文字框與段落，請參閱 [Manage Text](/slides/zh-hant/cpp/manage-text/)。

## **建立投影片編號欄位**

以下範例建立一個文字方塊，包含文字字面值 `Slide ` 標籤，後接自動更新的編號。它在新增欄位之前設定編號的大小、字粗與顏色，然後重新開啟已儲存的簡報，檢查欄位類型、文字與格式設定。無需輸入檔案。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

新的簡報從投影片編號 1 開始，因此預期文字為 `Slide 1`，兩項檢查均應輸出 `True`。重新開啟後，編號仍為欄位，而非文字 `1`。驗證中的型別轉換與索引指的是此範例建立的圖形與部分。

## **選擇欄位類型**

[FieldType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/) 實作 [IFieldType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifieldtype/) 並提供以下預先定義的值。將適當的值傳遞給 [AddField](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/addfield/)。

| 存取器 | 用途 |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_slidenumber/) | 目前的投影片編號。 |
| [get_DateTime](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_datetime/) | 日期/時間，使用呈現應用程式的預設格式。 |
| [get_DateTime1](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_datetime9/) | 預先定義的日期或組合日期/時間格式。 |
| [get_DateTime10](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_datetime13/) | 預先定義的時間格式，包含秒數與12小時制的選項。 |
| [get_Header](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_header/) | 頁首欄位；請參閱下方的佔位字元與格式限制。 |
| [get_Footer](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_footer/) | 頁尾欄位。 |

例如，[get_DateTime3](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/get_datetime3/) 提供以英文顯示的日、完整月份名稱與年份。這些是預先定義的欄位格式，而非任意的日期格式字串。使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_languageid/) 設定的部分語言，及處理簡報的應用程式，都可能影響顯示結果。

## **從內部字串建立欄位**

[AddField] 的字串重載接受內部欄位識別碼。當要保留其他應用程式提供且沒有預定義值的識別碼時請使用它。您也可以從該識別碼建構 [FieldType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fieldtype/fieldtype/)。[IFieldType::get_InternalString](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifieldtype/get_internalstring/) 公開此識別碼供檢查。

此範例將應用程式特定的 `custom-report-id` 欄位儲存為備用文字 `Report-042`。無需輸入檔案。此識別碼不會註冊計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由了解此識別碼的應用程式提供其意義並更新其值。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

經過此 PPTX 往返後，預期類型為 `custom-report-id`，預期文字為 `Report-042`。傳遞類似 `yyyy-MM-dd` 的字串會指定欄位類型；不會設定自訂日期格式。若需要固定日期的任意格式，請使用普通文字。

## **檢查、修改與移除 日期/時間 欄位**

透過 [IField::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifield/get_type/) 讀取現有欄位類型，並透過 [IField::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifield/set_type/) 變更它。存取其類型之前請先確認欄位是否存在。若要停止自動更新，請呼叫 [IPortion::RemoveField](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/removefield/)。此操作會保留該部分及其當前文字，同時移除欄位關聯。若需要特定的固定值，請在移除欄位後指派該文字。

關於處理日期/時間欄位的 API 設定，請參閱 [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/set_currentdatetime/)。以下範例在將欄位轉換為普通文字時使用明確的核准日期。

下載 [sample.pptx](sample.pptx) 並放置於工作目錄。它包含兩個已命名的文字圖形，`UpdatedAt` 與 `ApprovedDate`，每個都有日期/時間欄位，加上普通文字標籤。以下範例遍歷一般投影片上的頂層文字圖形。它將日期/時間欄位改為長日期格式並設為斜體，同時保留其他格式設定。只有 `ApprovedDate` 中的欄位會變為固定文字。

此範例會辨識內建的內部識別碼 `datetime` 以及 `datetime1` 至 `datetime13`。群組、表格、備註、佈局與母片需要遍歷其各自的文字容器，超出本範例範圍。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

重新開啟後，`UpdatedAt` 應具有類型 `datetime3` 且仍保持動態。`ApprovedDate` 應沒有欄位，且包含文字 `05 April 2030`。兩個日期部分皆為斜體，且其原始字型大小、粗體設定與顏色保持不變。普通文字標籤保持原樣。驗證會讀取所提供範例中兩個已知圖形的第一個部分。

## **保留文字格式**

在加入欄位、變更其類型或移除時，請使用現有的部分。這些操作會保留該部分的格式設定。使用 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/get_portionformat/) 僅變更所需的屬性，就像範例對顏色或斜體的處理。

避免為了更新單一欄位而重新建立整個文字框：這可能會遺失原始部分的邊界及其個別格式。亦需區分明確設定的格式與從段落、佈局或佈景主題繼承的格式。請參閱 [Text Formatting](/slides/zh-hant/cpp/text-formatting/) 以取得更廣泛的格式選項。

## **欄位與頁首/頁尾 佔位字元**

欄位是文字部分的一部份。佔位字元是具有簡報角色的圖形，例如頁尾或投影片編號。將欄位加入普通文字方塊不會使該圖形變成佔位字元。

頁首/頁尾管理員控制投影片、佈局與母片上的佔位字元文字與可見性，並會傳播至相依投影片。即使未使用投影片編號佔位字元，在自訂文字方塊中的編號欄位仍可能有用。相反地，變更佔位字元的可見性不會從不相關的文字方塊中移除欄位。

預先定義的頁首與頁尾類型不會建立相應的佔位字元或提供其內容。特別是，一般的 PowerPoint 投影片沒有頁首佔位字元；頁首屬於備註頁與講義。不要假設任意圖形中的頁首或頁尾欄位會自動取得佔位字元管理員所設定的文字。欲了解此工作流程，請參閱 [Presentation Headers and Footers](/slides/zh-hant/cpp/presentation-header-and-footer/)。

## **PPTX 與 PPT 限制**

儲存並重新開啟後，請同時檢查欄位類型與其產生的文字。保留識別碼並不代表應用程式能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 儲存內部欄位識別碼以及欄位文字。使用上述範例在儲存並重新開啟後檢查預定義類型與自訂識別碼。未知的自訂類型不會取得自動計算邏輯。其他應用程式可能以不同方式處理不支援的識別碼。 |
| PPT | 使用舊版欄位表示，兼容性較有限。投影片編號與預定義日期/時間欄位使用舊版表示。普通投影片文字方塊中的不支援自訂欄位或頁首欄位可能顯示為 `*`。不要依賴自訂欄位或不支援的欄位情境保留其可見文字。 |

若需可攜且固定的輸出，請在儲存前將不支援的欄位轉換為普通文字，並明確指定所需的值。這會保留選定的文字，但會停止自動更新。若目標應用程式本身會重新計算欄位，亦請進行測試，以確保工作流程的完整性。

## **常見問題**

**如何判斷顯示的數字或日期是否為欄位？**  
檢查 [IPortion::get_Field](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/get_field/)。非空值即表示為欄位；僅憑顯示文字無法判斷。

**移除欄位會刪除其文字或格式嗎？**  
不會。[RemoveField](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/removefield/) 會將現有部分轉換為普通文字。若需要特定的凍結日期或備援文字，請在之後指派明確的值。

**內部字串可以定義新的日期格式或公式嗎？**  
不能。它僅用於識別欄位類型。未知的識別碼不會提供評估器或日期格式模式。請使用支援的預定義類型，或自行以普通文字格式化值。

**為何在儲存後再次檢查簡報？**  
欄位識別碼、計算後的文字以及格式是需要分別驗證的項目。即使欄位識別碼仍在，格式轉換也可能改變可見結果。