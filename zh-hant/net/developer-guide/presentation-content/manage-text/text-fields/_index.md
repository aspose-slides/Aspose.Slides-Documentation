---
title: 在 .NET 中管理 PowerPoint 簡報的文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/net/text-fields/
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
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立、檢查、修改與移除文字欄位。保留格式並驗證已儲存的 PPTX 與 PPT 檔案。"
---
## **概觀**

文字段落由多個部分組成。普通的 [IPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/) 只包含文字；欄位部分則額外包含一個 [IField](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifield/)，其類型會識別自動更新的值，例如投影片編號或日期。兩個部分可以顯示相同的字元，但只有一個包含欄位。

使用 [IPortion.Field](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/field/) 來區分它們：普通文字的欄位為 `null`。[IPortion.AddField](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/addfield/) 會將現有的部分轉換為欄位。將標籤與其動態值保留在不同的部分中，以免在轉換值時同時取代標籤。

本指南涵蓋文字內的欄位、其格式設定，以及在 PPTX 與 PPT 中的儲存方式。關於文字框與段落的說明，請參閱 [Manage Text](/slides/zh-hant/net/manage-text/)。

## **建立投影片編號欄位**

以下完整範例建立一個文字方塊，內含字面值 `Slide ` 標籤，接著是一個自動更新的編號。它會先設定編號的大小、粗細與顏色，然後加入欄位，接著重新開啟已儲存的簡報，檢查欄位類型、文字與格式。此範例不需要輸入檔案。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

新簡報從投影片編號 1 開始，因此文字為 `Slide 1`，兩項檢查皆會輸出 `True`。重新開啟後編號仍為欄位，而不是字面值 `1`。驗證中的型別轉換與索引對應本範例所建立的圖形與部分。

## **選擇欄位類型**

[FieldType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/) 實作 [IFieldType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifieldtype/)，提供以下預先定義的值。將適當的值傳遞給 [AddField](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/addfield/)。

| 值 | 用途 |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/slidenumber/) | 目前的投影片編號。 |
| [DateTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/datetime/) | 依呈現應用程式的預設格式顯示日期/時間。 |
| [DateTime1](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/datetime9/) | 預先定義的日期或組合日期/時間格式。 |
| [DateTime10](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/datetime13/) | 預先定義的時間格式，可包含秒與 12 小時制。 |
| [Header](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/header/) | 頁首欄位；請參閱以下的占位符與格式限制。 |
| [Footer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/footer/) | 頁尾欄位。 |

例如，[DateTime3](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/datetime3/) 代表英文的「日、完整月份名稱與年份」。這些是預先定義的欄位格式，而非任意的 .NET 日期格式字串。部分的 [LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/languageid/) 以及處理簡報的應用程式都可能影響顯示結果。

## **從內部字串建立欄位**

[AddField](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/addfield/) 的字串重載接受內部欄位識別字。當需要保留其他應用程式提供且未有預先定義值的識別字時，請使用此方式。您也可以從識別字建構 [FieldType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fieldtype/fieldtype/)。[IFieldType.InternalString](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifieldtype/internalstring/) 會公開此識別字供檢查。

此範例儲存一個應用程式自訂的 `custom-report-id` 欄位，備援文字為 `Report-042`。該識別字不會註冊任何計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由能理解此識別字的應用程式提供其含義並自行更新其值。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

經過此 PPTX 循環後，類型為 `custom-report-id`，文字則為 `Report-042`。傳遞類似 `yyyy-MM-dd` 的字串會成為欄位類型名稱，而不會配置自訂日期格式。若需要固定格式的日期，請改用普通文字。

## **檢查、修改與移除日期/時間欄位**

透過 [IField.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifield/type/) 讀取並變更現有欄位。存取欄位類型前請先確認欄位是否存在。若要停止自動更新，呼叫 [IPortion.RemoveField](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/removefield/)。此方法會保留該部分與其目前文字，同時移除欄位關聯。如果需要特定的固定值，可在移除欄位後自行設定文字。

有關日期/時間欄位處理的 API 設定，請參閱 [Presentation.CurrentDateTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/currentdatetime/)。以下範例在將欄位轉換為普通文字時使用了明確的核准日期。

下載 [sample.pptx](sample.pptx) 並放置於工作目錄。檔案包含兩個具名文字圖形 `UpdatedAt` 與 `ApprovedDate`，兩者都有日期/時間欄位，外加普通文字標籤。下列程式碼會走訪普通投影片的頂層文字圖形，將日期/時間欄位改為長日期格式並套用斜體，同時保留其他格式。只有 `ApprovedDate` 中的欄位會被固定為文字。

此範例會識別內建的內部識別字 `datetime` 以及 `datetime1`~`datetime13`。群組、表格、備註、版面與母片需要自行走訪其文字容器，超出本範例範圍。

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

重新開啟後，`UpdatedAt` 仍為 `datetime3` 類型且保持動態。`ApprovedDate` 沒有欄位，顯示文字為 `05 April 2030`。兩個日期部分皆為斜體，且原本的字型大小、粗體設定與顏色保持不變。普通文字標籤未受影響。驗證程式會讀取提供樣本中兩個已知圖形的第一個部分。

## **保留文字格式**

在新增、變更類型或移除欄位時，請直接操作現有的部分。這些操作會保留該部分的格式。使用 [IPortion.PortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/portionformat/) 只變更所需屬性，如範例中對顏色或斜體的處理。

不要僅為了更新一個欄位而重建整個文字框：這樣可能會遺失原有部分的邊界與各自的格式。也要區分明確設定的格式與從段落、版面或佈景主題繼承的格式。詳情請參閱 [Text Formatting](/slides/zh-hant/net/text-formatting/)。

## **欄位與頁首/頁尾占位符**

欄位屬於文字部分。占位符則是一個具備簡報角色（如頁尾或投影片編號）的圖形。將欄位加入普通文字方塊不會使該圖形變成占位符。

頁首/頁尾管理員負責控制占位符文字與在投影片、版面及母片上的可見性，並會傳播至衍生投影片。將欄位放入自訂文字方塊仍可在未使用投影片編號占位符的情況下提供編號功能。相反地，變更占位符可見性不會移除與其他文字方塊無關的欄位。

預先定義的頁首與頁尾類型不會產生相應的占位符或提供其內容。特別是，普通 PowerPoint 投影片本身沒有頁首占位符；頁首屬於備註頁與講義。不要假設任意圖形中的頁首或頁尾欄位會自動取得占位符管理員所設定的文字。相關工作流程請參閱 [Presentation Headers and Footers](/slides/zh-hant/net/presentation-header-and-footer/)。

## **PPTX 與 PPT 的限制**

儲存並重新開啟後，請同時檢查欄位類型與最終文字。保留識別字並不代表應用程式一定能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 會將內部欄位識別字與欄位文字一起儲存。在循環檢查中，預先定義的類型與上述自訂識別字皆能在儲存與重新開啟後存活。未知的自訂類型保留備援文字；不會取得自動計算邏輯。其他應用程式可能以不同方式處理不支援的識別字。 |
| PPT | 使用舊式欄位表示方式，相容性較低。在循環檢查中，投影片編號與預先定義的日期/時間欄位能存活。普通投影片文字方塊中的自訂欄位在重新開啟時會保留識別字，但文字會變成 `*`；相同情況下的頁首欄位亦會產生 `*`。不要依賴自訂欄位或不支援的欄位情境保留可見文字。 |

若需可攜、固定的輸出，請將不支援的欄位轉換為普通文字，並在儲存前明確指定欲保留的文字。這樣可保留所選文字，同時停止自動更新。若工作流程中目標應用程式會自行重新計算欄位，亦請同時測試其行為。

## **常見問答**

**如何判斷顯示的數字或日期是否為欄位？**

檢查 [IPortion.Field](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/field/)。非 null 值即表示為欄位；僅靠顯示文字無法辨別。

**移除欄位會同時移除文字或格式嗎？**

不會。[RemoveField](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/removefield/) 會將現有部分轉為普通文字。若需要特定的凍結日期或備援文字，可在移除後自行指派值。

**內部字串能定義新的日期格式或公式嗎？**

不能。它僅用來識別欄位類型。未知的識別字不會提供評估器或 .NET 日期格式模式。請使用支援的預先定義類型，或自行將值格式化為普通文字。

**為什麼要在儲存後再次檢查簡報？**

欄位識別字、計算後的文字與格式是需要分別驗證的項目。格式轉換可能會改變可見結果，即使欄位識別字仍然存在。