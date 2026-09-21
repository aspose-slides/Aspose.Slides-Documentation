---
title: 在 PowerPoint 簡報中於 Python 透過 Java 管理文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/python-java/text-fields/
keywords:
- 文字欄位
- 自動文字
- 投影片編號
- 日期與時間
- 頁首
- 頁腳
- 文字部份
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "建立、檢查、修改與移除 PowerPoint 簡報中的文字欄位，使用 Aspose.Slides for Python via Java。保留格式並驗證已儲存的 PPTX 與 PPT 檔案。"
---
## **概觀**

文字段落由多個部份組成。普通的[Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/)包含字面文字；欄位部份也具有一個[Field](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/field/)其類型識別自動更新的值，例如投影片編號或日期。兩個部份可以顯示相同的字元，但只有其中一個包含欄位。

使用[Portion.getField](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getField)來區分它們：對於普通文字會返回`None`。[Portion.addField](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#addField)會將現有部份轉換為欄位。將標籤與其動態值放在不同的部份中，以免在轉換值時同時取代標籤。

本指南涵蓋文字內的欄位、它們的格式設定，以及在 PPTX 和 PPT 中的儲存方式。關於文字框與段落，請參閱[Manage Text](/slides/zh-hant/python-java/manage-text/)。

## **建立投影片編號欄位**

以下完整範例建立一個文字方塊，內含字面`Slide `標籤，後接自動更新的編號。它會在加入欄位前設定編號的大小、字重與顏色，然後重新開啟已儲存的簡報，檢查欄位類型、文字與格式。無需輸入檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

新簡報從投影片編號 1 開始，因此文字為`Slide 1`，兩項檢查皆輸出`True`。重新開啟後編號仍為欄位，而非字面`1`。驗證中的索引指的是本範例所建立的形狀與部份。

## **選擇欄位類型**

[FieldType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/)提供以下方法取得預定義值。將適當的值傳遞給[addField](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#addField)。

| 方法 | 用途 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getSlideNumber) | 目前的投影片編號。 |
| [getDateTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getDateTime) | 以渲染應用程式的預設格式顯示日期/時間。 |
| [getDateTime1](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getDateTime9) | 預先定義的日期或組合日期/時間格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getDateTime13) | 預先定義的時間格式，包含秒與 12 小時制的選項。 |
| [getHeader](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getHeader) | 頁首欄位；請參閱下方的佔位字與格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getFooter) | 頁腳欄位。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getDateTime3)代表英文的「日、完整月份名稱與年份」。這些是預定義的欄位格式，而非任意的 Python 日期格式字串。使用[setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setLanguageId)設定的語言以及處理簡報的應用程式都可能影響最終顯示結果。

## **從內部字串建立欄位**

[addField](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#addField)的字串重載接受內部欄位識別碼。當需要保留另一個應用程式提供且沒有預定義值的識別碼時使用。也可以從該識別碼建構[FieldType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#FieldType)。[FieldType.getInternalString](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fieldtype/#getInternalString)可將此識別碼公開供檢查。

此範例在文字中儲存一個應用程式專屬的`custom-report-id`欄位，備援文字為`Report-042`。此識別碼不會註冊計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由能理解此識別碼的應用程式自行提供意義並更新其值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

經過此 PPTX 往返後，類型為`custom-report-id`，文字為`Report-042`。傳入類似`yyyy-MM-dd`的字串只會命名欄位類型，並不會設定自訂日期格式。若需固定的任意格式日期，請使用普通文字。

## **檢查、修改與移除日期/時間欄位**

透過[Field.setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/field/#setType)變更現有欄位。存取其類型前需先確認欄位是否存在。若要停止自動更新，呼叫[Portion.removeField](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#removeField)。此操作會保留部份及其當前文字，同時移除欄位關聯。若需要特定的固定值，可在移除欄位後自行指定文字。

關於與日期/時間欄位處理相關的 API 設定，請參閱[Presentation.setCurrentDateTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#setCurrentDateTime)。以下範例在將欄位轉為普通文字時使用明確的批准日期。

下載[sample.pptx](sample.pptx)並放置於工作目錄。檔案包含兩個具名文字形狀 `UpdatedAt` 與 `ApprovedDate`，各自帶有日期/時間欄位，外加普通文字標籤。下列範例遍歷普通投影片上的頂層文字形狀，將日期/時間欄位改為長日期格式並斜體，同時保留其他格式。只有 `ApprovedDate` 中的欄位會變成固定文字。

範例會辨識內建的 `datetime` 與 `datetime1` 至 `datetime13` 識別碼。群組、表格、備註、版面配置與母片需要自行遍歷其文字容器，超出本範例範圍。

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # 使用英文月份名稱，不受系統語系影響。
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

重新開啟後，`UpdatedAt` 的類型為 `datetime3`，仍為動態；`ApprovedDate` 沒有欄位，內容為 `05 April 2030`。兩個日期部份皆為斜體，且保留原始字型大小、粗體設定與顏色。普通文字標籤保持不變。驗證會讀取提供樣本中兩個已知形狀的第一個部份。

## **保留文字格式**

在加入欄位、變更類型或移除欄位時，請直接使用現有部份，這些操作會保留該部份的格式。使用[Portion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getPortionFormat)僅變更必要的屬性，如範例所示的顏色或斜體。

避免為了更新單一欄位而重建整個文字框：這會遺失原部份的邊界與各自的格式。亦需區分明確設定的格式與段落、版面或佈景主題所繼承的格式。請參閱[Text Formatting](/slides/zh-hant/python-java/text-formatting/)了解更廣泛的格式選項。

## **欄位與頁首/頁腳佔位元件**

欄位是文字部份的一部份。佔位元件則是具有簡報角色的形狀，例如頁腳或投影片編號。將欄位加入普通文字方塊不會使該形狀變成佔位元件。

頁首/頁腳管理員控制佔位元件的文字與可見性，適用於投影片、版面配置與母片，並會傳遞至衍生投影片。自訂文字方塊中的編號欄位即使未使用投影片編號佔位元件仍可能有用。相反地，變更佔位元件的可見性不會從無關的文字方塊中移除欄位。

預定義的頁首與頁腳類型不會建立相對應的佔位元件或提供其內容。特別是一般的 PowerPoint 投影片並沒有頁首佔位元件；頁首屬於備註頁與講義。不要假設任意形狀中的頁首或頁腳欄位會自動取得佔位元件管理員所設定的文字。相關工作流程請參閱[Presentation Headers and Footers](/slides/zh-hant/python-java/presentation-header-and-footer/)。

## **PPTX 與 PPT 限制**

在儲存與重新開啟後，同時檢查欄位類型與最終文字。保留識別碼並不代表應用程式一定能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 內部欄位識別碼會與欄位文字一起儲存。於往返檢查中，前述的預定義類型與自訂識別碼均能在儲存與重新開啟後存活。未知的自訂類型保留其備援文字，未取得自動計算邏輯。其他應用程式可能會以不同方式處理不支援的識別碼。 |
| PPT | 使用舊版欄位表示方式，兼容性較受限。於往返檢查中，投影片編號與預定義的日期/時間欄位能存活。普通投影片文字方塊中的自訂欄位重新開啟時會保留識別碼，但文字顯示為 `*`；同樣情況亦發生在相同情境下的頁首欄位。不要依賴自訂欄位或不支援的欄位環境保留可見文字。 |

若需可移植且固定的輸出，請將不支援的欄位轉為普通文字，並在儲存前明確指定欲保留的值。這樣可以保留所選文字，但會主動停止自動更新。當目標應用程式本身會重新計算欄位時，也請同時測試其行為。

## **常見問題**

**如何判斷顯示的數字或日期是否為欄位？**

檢查[Portion.getField](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getField)。返回非`None`的值即代表該部份是欄位，僅靠顯示的文字無法辨別。

**移除欄位會同時移除其文字或格式嗎？**

不會。[removeField](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#removeField)會將現有部份轉為普通文字。若需要特定的凍結日期或備援文字，可在移除後自行指派。

**內部字串能定義新的日期格式或公式嗎？**

不能。它只用於識別欄位類型。未知的識別碼不會提供評估器或 Python 日期格式樣式。請使用支援的預定義類型，或自行將值格式化為普通文字。

**為什麼儲存後還要再次檢查簡報？**

欄位識別碼、計算後的文字與格式是需要分別驗證的項目。格式轉換可能會改變可見結果，即使欄位識別碼仍然存在。