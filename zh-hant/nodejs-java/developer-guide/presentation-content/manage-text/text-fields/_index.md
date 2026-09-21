---
title: 在 JavaScript 中管理 PowerPoint 簡報的文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/nodejs-java/text-fields/
keywords:
- 文字欄位
- 自動文字
- 投影片編號
- 日期與時間
- 頁首
- 頁腳
- 文字區段
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 簡報中建立、檢查、修改與移除文字欄位。保留格式並驗證已儲存的 PPTX 與 PPT 檔案。"
---
## **概述**

文字段落由多個部分組成。普通的 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 包含文字字面值；欄位部分還具備一個 [Field](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/field/)，其類型指示自動更新的值，例如投影片編號或日期。兩個部分可以顯示相同的字元，但只有其中一個包含欄位。

使用 [Portion.getField](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#getField) 來區分它們：對於普通文字會回傳 `null`。[Portion.addField](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#addField) 會將現有的部分轉換為欄位。請將標籤與其動態值放在不同的部分中，以避免在轉換值時同時取代標籤。

本指南介紹文字內的欄位、其格式設定，以及在 PPTX 和 PPT 中的儲存方式。關於文字框和段落，請參閱 [Manage Text](/slides/zh-hant/nodejs-java/manage-text/)。

## **建立投影片編號欄位**

以下完整範例會建立一個文字方塊，內含文字字面值 `Slide ` 標籤，之後接自動更新的編號。它會在加入欄位前設定編號的大小、粗細與顏色，然後重新開啟已儲存的簡報，檢查欄位類型、文字與格式。此範例不需要任何輸入檔案。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

新的簡報以投影片編號 1 開始，因此文字為 `Slide 1`，兩項檢查皆會輸出 `true`。重新開啟後，編號仍為欄位；它不是字面值 `1`。驗證中的索引指的是此範例建立的圖形與部分。

## **選擇欄位類型**

[FieldType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/) 提供以下方法以取得預定義值。將適當的值傳遞給 [addField](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#addField)。

| 方法 | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | 目前的投影片編號。 |
| [getDateTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getDateTime) | 在呈現應用程式的預設格式下的日期/時間。 |
| [getDateTime1](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | 預定義的日期或組合日期/時間格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | 預定義的時間格式，可選擇顯示秒數與 12 小時制。 |
| [getHeader](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getHeader) | 頁首欄位；請參閱下方的占位符與格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getFooter) | 頁腳欄位。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getDateTime3) 代表英文的日、完整月份名稱與年份。這些是預先定義的欄位格式，而非任意的日期格式字串。透過 [setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 設定的語言以及處理簡報的應用程式可能會影響顯示結果。

## **從內部字串建立欄位**

[addField](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#addField) 的字串重載接受內部欄位識別碼。當要保留其他應用程式提供且沒有預定義值的識別碼時，請使用它。您也可以從該識別碼建立 [FieldType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/)。[FieldType.getInternalString](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fieldtype/#getInternalString) 可公開該識別碼以供檢查。

此範例以備用文字 `Report-042` 儲存應用程式專屬的 `custom-report-id` 欄位。該識別碼不會註冊計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由了解此識別碼的應用程式提供其意義並更新其值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

經過此 PPTX 循環後，類型為 `custom-report-id`，文字為 `Report-042`。傳遞類似 `yyyy-MM-dd` 的字串只會指定欄位類型；不會設定自訂日期格式。如需任意格式的固定日期，請使用普通文字。

## **檢查、修改與移除日期/時間欄位**

透過 [Field.setType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/field/#setType) 變更既有欄位。訪問其類型前請先確認欄位存在。若要停止自動更新，呼叫 [Portion.removeField](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#removeField)。此操作會保留部分及其目前文字，同時移除欄位關聯。如果需要特定的固定值，請在移除欄位後指派該文字。

有關日期/時間欄位處理的 API 設定，請參閱 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#setCurrentDateTime)。以下範例在將欄位轉換為普通文字時使用明確的核准日期。

下載 [sample.pptx](sample.pptx) 並放置於工作目錄。它包含兩個具名文字圖形，`UpdatedAt` 和 `ApprovedDate`，各自帶有日期/時間欄位，另有普通文字標籤。以下範例遍歷一般投影片的頂層文字圖形。它將日期/時間欄位改為長日期格式並設定斜體，同時保留其他格式。只有 `ApprovedDate` 中的欄位會變為固定文字。

核准日期為 2030 年 4 月 5 日；JavaScript 的月份索引從零開始，因此四月為 `3`。為了使日期不受本地時區影響，建構與格式化皆使用 UTC。

此範例能辨識內建的內部識別碼 `datetime` 以及 `datetime1` 到 `datetime13`。群組、表格、備註、版面配置與母片需要自行遍歷其文字容器，超出本範例的範圍。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

重新開啟後，`UpdatedAt` 的類型為 `datetime3`，仍為動態。`ApprovedDate` 沒有欄位，內容為 `05 April 2030`。兩個日期部分皆為斜體，且其原始字型大小、粗體設定與顏色保持不變。普通文字標籤未變。驗證會讀取提供樣本中兩個已知圖形的第一個部分。

## **保留文字格式**

在加入欄位、變更類型或移除欄位時，請使用現有的部分。這些操作會保留該部分的格式。使用 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#getPortionFormat) 僅變更必要的屬性，範例中即是對顏色或斜體的處理。

避免僅為更新單一欄位而重新建構整個文字框：這樣可能會遺失原始部分的邊界與各自的格式。也要區分明確設定的格式與從段落、版面配置或佈景主題繼承的格式。請參閱 [Text Formatting](/slides/zh-hant/nodejs-java/text-formatting/) 了解更廣泛的格式選項。

## **欄位與頁首/頁腳占位符**

欄位是文字部分的一部份。占位符是具備簡報角色的圖形，例如頁腳或投影片編號。將欄位加入普通文字方塊並不會將該圖形變成占位符。

頁首/頁腳管理員控制投影片、版面配置與母片上占位符的文字與可見性，並會傳遞至相依的投影片。因此，即使未使用投影片編號占位符，自訂文字方塊中的編號欄位仍可能有用。相反地，變更占位符的可見性不會從不相關的文字方塊中移除欄位。

預先定義的頁首與頁腳類型不會建立相應的占位符或提供其內容。特別是，一般的 PowerPoint 投影片沒有頁首占位符；頁首屬於備註頁與講義。不要假設任意圖形中的頁首或頁腳欄位會自動取得透過占位符管理員設定的文字。如需此工作流程，請參閱 [Presentation Headers and Footers](/slides/zh-hant/nodejs-java/presentation-header-and-footer/)。

## **PPTX 與 PPT 限制**

在儲存與重新開啟後，請同時檢查欄位類型與其產生的文字。保留識別碼並不代表應用程式能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 在欄位文字旁儲存內部欄位識別碼。於往返檢查中，預定義類型與上述使用的自訂識別碼均能在儲存與重新開啟後保留。未知的自訂類型保留其備用文字，未取得自動計算機制。其他應用程式可能對不支援的識別碼有不同處理方式。 |
| PPT | 使用舊版欄位表示方式，兼容性較受限。於往返檢查中，投影片編號與預定義的日期/時間欄位能在儲存與重新開啟後保留。普通投影片文字方塊中的自訂欄位在重新開啟時仍帶有其識別碼，但文字為 `*`；相同情境下的頁首欄位亦產生 `*`。不要依賴自訂欄位或不支援的欄位情境保留其可見文字。 |

若需可移植、固定的輸出，請在儲存前將不支援的欄位轉換為普通文字並明確指派所需的值。這樣可保留所選文字，同時刻意停止自動更新。若目標應用程式自身會重新計算欄位，亦請進行測試以確保工作流程的正確性。

## **FAQ**

**如何判斷顯示的數字或日期是否為欄位？**

檢查 [Portion.getField](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#getField)。非 null 值即表示為欄位；僅憑顯示的文字無法判斷。

**移除欄位會同時移除其文字或格式嗎？**

不會。[removeField](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/#removeField) 會將現有的部分轉為普通文字。若需特定的凍結日期或備用值，可在之後指派明確的文字。

**內部字串能定義新的日期格式或公式嗎？**

不能。它只用來識別欄位類型。未知的識別碼不會提供評估器或日期格式模式。請使用支援的預定義類型，或自行將值格式化為普通文字。

**為何在儲存後再次檢查簡報？**

欄位識別碼、計算後的文字與格式是需要分別驗證的項目。即使欄位識別碼仍在，格式轉換也可能改變可見結果。