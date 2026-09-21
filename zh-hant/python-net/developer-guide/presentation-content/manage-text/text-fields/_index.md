---
title: 在 Python 中管理 PowerPoint 簡報的文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/python-net/text-fields/
keywords:
- 文字欄位
- 自動文字
- 投影片編號
- 日期與時間
- 頁首
- 頁尾
- 文字分段
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python（.NET 版）在 PowerPoint 簡報中建立、檢查、修改與移除文字欄位。保留格式並驗證已儲存的 PPTX 與 PPT 檔案。"
---
## **概觀**

文字段落由多個分段組成。普通的 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 包含文字字串；欄位分段還具有一個 [Field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/field/)，其類型標示自動更新的值，例如投影片編號或日期。兩個分段可以顯示相同的字元，但僅有一個包含欄位。

使用 [Portion.field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/field/) 來區分它們：普通文字的值為 `None`。[Portion.add_field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/add_field/) 可將現有的分段轉換為欄位。請將標籤與其動態值放在不同的分段中，以免在轉換值時同時取代標籤。

本指南涵蓋文字中的欄位、它們的格式設定，以及在 PPTX 和 PPT 中的儲存。若需文字框與段落的說明，請參閱 [Manage Text](/slides/zh-hant/python-net/manage-text/)。

## **建立投影片編號欄位**

以下完整範例會建立一個文字方塊，內含文字字串 `Slide ` 標籤，後接自動更新的編號。它會在加入欄位前設定編號的大小、粗細與顏色，然後重新開啟已儲存的簡報，檢查欄位類型、文字與格式。此範例不需要輸入檔案。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

新簡報的投影片編號從 1 開始，因此文字為 `Slide 1`，且兩項檢查皆輸出 `True`。重新開啟後編號仍為欄位，而非文字 `1`。驗證中的索引指的是此範例所建立的圖形與分段。

## **選擇欄位類型**

[FieldType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/) 提供以下預定義值。將適當的值傳遞給 [add_field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/add_field/)。

| Value | Purpose |
|---|---|
| [slide_number](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/slide_number/) | 目前的投影片編號。 |
| [date_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/date_time/) | 在呈現應用程式的預設格式下的日期/時間。 |
| [date_time1](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/date_time9/) | 預定義的日期或結合日期/時間格式。 |
| [date_time10](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/date_time13/) | 預定義的時間格式，可選擇秒以及 12 小時制。 |
| [header](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/header/) | 頁首欄位；請參閱下方的占位符與格式限制。 |
| [footer](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/footer/) | 頁尾欄位。 |

例如，[date_time3](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/date_time3/) 代表英文的日、完整月份名稱與年份。這些是預定義的欄位格式，而非任意的 Python 日期格式字串。分段的 [language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/language_id/) 以及處理簡報的應用程式可能會影響顯示結果。

## **從內部字串建立欄位**

[add_field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/add_field/) 的字串多載接受內部欄位識別碼。當需要保留其他應用程式提供且沒有預定義值的識別碼時請使用它。您也可以從此識別碼建立 [FieldType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/__init__)。[FieldType.internal_string](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fieldtype/internal_string/) 可公開該識別碼以供檢查。

此範例儲存一個應用程式特定的 `custom-report-id` 欄位，備援文字為 `Report-042`。此識別碼不會註冊計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由了解此識別碼的應用程式提供其意義並更新其值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

在此 PPTX 循環之後，類型為 `custom-report-id`，文字為 `Report-042`。傳遞類似 `%Y-%m-%d` 的字串會指定欄位類型；不會設定自訂日期格式。若需任意格式的固定日期，請使用普通文字。

## **檢查、修改與移除日期/時間欄位**

透過 [Field.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/field/type/) 讀取並變更現有的欄位。存取其類型前須先確認欄位是否存在。若要停止自動更新，請呼叫 [Portion.remove_field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/remove_field/)。此操作會保留分段及其目前的文字，同時移除欄位關聯。若需要特定的固定值，可在移除欄位後指派該文字。

有關日期/時間欄位處理的 API 設定，請參閱 [Presentation.current_date_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/current_date_time/)。以下範例在將欄位轉換為普通文字時使用明確的核准日期。英語月份名稱的元組使固定日期不受系統語系影響。

下載 [sample.pptx](sample.pptx) 並將其放置於工作目錄中。該檔案包含兩個具名文字圖形，`UpdatedAt` 與 `ApprovedDate`，各自帶有日期/時間欄位，另有普通文字標籤。以下範例遍歷一般投影片的頂層文字圖形。它會將日期/時間欄位改為長日期格式並設為斜體，同時保留其他格式。僅 `ApprovedDate` 的欄位會變為固定文字。

此範例會辨識內建的內部識別碼 `datetime` 及 `datetime1` 到 `datetime13`。群組、表格、備註、版面配置與母片需要遍歷其各自的文字容器，超出本範例範圍。

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

重新開啟後，`UpdatedAt` 的類型為 `datetime3`，仍為動態。`ApprovedDate` 沒有欄位，內容為 `05 April 2030`。兩個日期分段皆為斜體，且原本的字型大小、粗體設定與顏色保持不變。普通文字標籤則未變更。驗證會讀取提供樣本中兩個已知圖形的第一個分段。

## **保留文字格式**

在加入欄位、變更其類型或移除時，請使用現有的分段。這些操作會保留該分段的格式。使用 [Portion.portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/portion_format/) 僅變更必要的屬性，正如範例對顏色或斜體的處理。

避免僅為更新單一欄位而重新建構整個文字框：這樣做可能會遺失原始分段的邊界與各自的格式。亦須區分明確設定的格式與從段落、版面或佈景主題繼承的格式。請參閱 [Text Formatting](/slides/zh-hant/python-net/text-formatting/) 以取得更廣泛的格式化選項。

## **欄位與頁首/頁尾占位符**

欄位是文字分段的一部份。占位符則是具有簡報角色的圖形，例如頁尾或投影片編號。將欄位加入普通文字方塊不會使該圖形變成占位符。

頁首/頁尾管理員控制投影片、版面與母片上占位符的文字與可見性，且會傳遞至相關投影片。即使未使用投影片編號占位符，在自訂文字方塊內的編號欄位仍可能有用。相反地，變更占位符的可見性不會移除與其無關的文字方塊中的欄位。

預先定義的頁首與頁尾類型不會建立對應的占位符或提供其內容。特別是，一般的 PowerPoint 投影片沒有頁首占位符；頁首屬於備註頁與講義。不要假設任意圖形中的頁首或頁尾欄位會自動取得透過占位符管理員設定的文字。若需此工作流程，請參閱 [Presentation Headers and Footers](/slides/zh-hant/python-net/presentation-header-and-footer/)。

## **PPTX 與 PPT 限制**

儲存並重新開啟後，請同時檢查欄位類型及其產生的文字。保留識別碼並不代表應用程式能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 在欄位文字旁儲存內部欄位識別碼。在往返檢查中，預定義類型與上述使用的自訂識別碼在儲存與重新開啟後仍然存在。未知的自訂類型保留其備援文字；不會取得自動計算邏輯。其他應用程式可能會以不同方式處理不支援的識別碼。 |
| PPT | 使用舊版欄位表示法，兼容性較受限。在往返檢查中，投影片編號與預定義的日期/時間欄位在儲存與重新開啟後仍然存在。普通投影片文字方塊中的自訂欄位重新開啟後仍保留其識別碼，但文字為 `*`；相同情境下的頁首欄位也會產生 `*`。不要依賴自訂欄位或不支援的欄位情境保留其可見文字。 |

若需可移植、固定的輸出，請在儲存前將不支援的欄位轉換為普通文字，並明確指派想要的值。這樣可保留所選文字，同時刻意停止自動更新。若目標應用程式本身會重新計算欄位，也請測試其行為以符合工作流程。

## **常見問題**

**如何判斷顯示的數字或日期是否為欄位？**

檢查 [Portion.field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/field/)。只要值不是 `None` 就代表是欄位；僅憑顯示的文字無法判斷。

**移除欄位會同時移除文字或格式嗎？**

不會。[remove_field](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/remove_field/) 會將現有的分段轉換為普通文字。若需特定的固定日期或備援值，可在之後指派明確的文字。

**內部字串能定義新的日期格式或公式嗎？**

不行。它僅用於識別欄位類型。未知的識別碼不會提供評估器或 Python 日期格式樣式。請使用支援的預定義類型，或自行將值以普通文字格式化。

**為何在儲存後再次檢查簡報？**

欄位識別碼、計算後的文字與格式是需要分別驗證的項目。即使欄位識別碼仍在，格式轉換也可能改變可見結果。