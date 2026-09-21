---
title: 在 PHP 中管理 PowerPoint 簡報的文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/php-java/text-fields/
keywords:
- 文字欄位
- 自動文字
- 投影片編號
- 日期與時間
- 標頭
- 頁腳
- 文字部分
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）在 PowerPoint 簡報中建立、檢查、修改與移除文字欄位。保留格式並驗證已儲存的 PPTX 與 PPT 檔案。"
---
## **概觀**

文字段落由多個部分組成。普通的 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 包含純文字；欄位部分也有一個 [Field](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/field/) ，其類型標示自動更新的值，例如投影片編號或日期。兩個部分可以顯示相同的字元，但僅有其中一個包含欄位。

使用 [Portion::getField](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getField) 來區分它們：普通文字會回傳 `null`。[Portion::addField](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#addField) 會將既有部分轉換為欄位。請將標籤與其動態值放在不同的部分，以免在轉換值時同時取代標籤。

本指南說明文字內的欄位、其格式設定，以及在 PPTX 與 PPT 中的儲存方式。文字框與段落的相關資訊，請參閱 [Manage Text](/slides/zh-hant/php-java/manage-text/)。

## **建立投影片編號欄位**

以下完整範例建立一個文字方塊，其中包含文字 `Slide ` 標籤，後接自動更新的編號。它會先設定編號的大小、字重與顏色，然後加入欄位；接著重新開啟已儲存的簡報，檢查欄位類型、文字與格式。此範例不需要任何輸入檔。

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

新的簡報從投影片編號 1 開始，因此文字為 `Slide 1`，兩項檢查皆印出 `true`。重新開啟後編號仍為欄位，而不是純文字 `1`。驗證中的索引指的是此範例所建立的圖形與部分。

## **選擇欄位類型**

[FieldType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/) 提供以下方法以取得預定義值。將適當的值傳入 [addField](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#addField)。

| 方法 | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getSlideNumber) | 目前的投影片編號。 |
| [getDateTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getDateTime) | 在呈現應用程式的預設格式下的日期/時間。 |
| [getDateTime1](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getDateTime9) | 預先定義的日期或組合日期/時間格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getDateTime13) | 預先定義的時間格式，包含秒數與 12 小時制的選項。 |
| [getHeader](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getHeader) | 標頭欄位；請參閱下方的佔位符與格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getFooter) | 頁腳欄位。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getDateTime3) 代表英文的「日、完整月份名稱、年份」格式。這些是預先定義的欄位格式，而非任意的 PHP 日期格式字串。使用 [setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 設定的語系，以及處理簡報的應用程式，都可能影響最終顯示結果。

## **從內部字串建立欄位**

[addField](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#addField) 的字串重載接受內部欄位識別字。當需要保留另一個應用程式提供且沒有預定義值的識別字時，可使用此方式。您也可以從該識別字建立 [FieldType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#FieldType)。[FieldType::getInternalString](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fieldtype/#getInternalString) 可取得此識別字以供檢查。

此範例在簡報中儲存一個應用程式自訂的 `custom-report-id` 欄位，其備援文字為 `Report-042`。此識別字不會觸發計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由了解此識別字的應用程式提供其意義並自行更新其值。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

經過此 PPTX 循環後，類型為 `custom-report-id`，文字為 `Report-042`。若傳入類似 `Y-m-d` 的字串，會被視為欄位類型名稱，而不會設定自訂的日期格式。若需以任意格式呈現固定日期，請改用普通文字。

## **檢查、修改與移除日期/時間欄位**

透過 [Field::setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/field/#setType) 變更既有欄位。存取欄位類型前請先確認欄位是否存在。若要停止自動更新，呼叫 [Portion::removeField](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#removeField)。此方法會保留部分與其目前文字，同時移除欄位關聯。若需要特定的固定值，可在移除欄位後自行指派文字。

有關日期/時間欄位處理的 API 設定，請參閱 [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#setCurrentDateTime)。以下範例在將欄位轉為普通文字時，使用明確的批准日期。

下載 [sample.pptx](sample.pptx) 並放置於 JavaBridge 工作目錄，或將其絕對路徑傳入簡報建構函式。該檔案包含兩個具名文字圖形 `UpdatedAt` 與 `ApprovedDate`，各自帶有日期/時間欄位，另外還有普通文字標籤。以下程式遍歷一般投影片上的頂層文字圖形，將日期/時間欄位改為長日期格式並設為斜體，同時保留其他格式設定。只有 `ApprovedDate` 中的欄位會被轉為固定文字。

範例會辨識內建的 `datetime` 以及 `datetime1` 到 `datetime13` 識別字。群組、表格、備註、版面配置與母片需要自行遍歷其文字容器，超出本範例範圍。

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

重新開啟後，`UpdatedAt` 的類型為 `datetime3`，仍為動態；`ApprovedDate` 沒有欄位，文字為 `05 April 2030`。兩個日期部分皆為斜體，且其原始字型大小、粗體設定與顏色保持不變。普通文字標籤則未受影響。驗證會讀取提供的範例中兩個已知圖形的第一個部分。

## **保留文字格式**

在新增、變更類型或移除欄位時，請直接操作現有的部分。這些操作會保留該部分的格式。使用 [Portion::getPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getPortionFormat) 只變更必要的屬性，如範例中對顏色或斜體的設定。

避免重新建立整個文字框僅為更新單一欄位：這樣可能會遺失原有部分的邊界與個別格式。也要分辨明確設定的格式與繼承自段落、版面或佈景主題的格式。更多格式選項請參閱 [Text Formatting](/slides/zh-hant/php-java/text-formatting/)。

## **欄位與標頭/頁腳佔位符**

欄位是文字部分的一部份。佔位符則是具有簡報角色（例如頁腳或投影片編號）的圖形。將欄位加入普通文字方塊不會使該圖形變成佔位符。

標頭/頁腳管理員負責控制佔位符文字與可見性，涵蓋投影片、版面配置與母片，並會傳遞至相依的投影片。因此，即使未使用投影片編號佔位符，在自訂文字方塊內放置編號欄位仍然有用。相反地，變更佔位符的可見性不會移除與無關文字方塊中的欄位。

預定義的標頭與頁腳類型不會建立對應的佔位符或提供其內容。特別是，普通的 PowerPoint 投影片並無標頭佔位符；標頭屬於備註頁與講義。不要假設在任意圖形中的標頭或頁腳欄位會自動取得佔位符管理員所設定的文字。相關工作流程請參閱 [Presentation Headers and Footers](/slides/zh-hant/php-java/presentation-header-and-footer/)。

## **PPTX 與 PPT 限制**

儲存並重新開啟後，請同時檢查欄位類型與最終文字。保留識別字並不代表應用程式能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 會將內部欄位識別字與欄位文字一起儲存。於循環檢查中，預定義類型與上述自訂識別字皆能在儲存與重新開啟後存活。未知的自訂類型保留其備援文字，未取得自動計算邏輯。其他應用程式可能對不支援的識別字有不同處理方式。 |
| PPT | 使用舊版欄位表示方式，兼容性較低。於循環檢查中，投影片編號與預定義日期/時間欄位能在儲存與重新開啟後存活。普通投影片文字方塊中的自訂欄位會以其識別字重新開啟，但文字顯示為 `*`；相同情境下的標頭欄位亦會產生 `*`。不要依賴自訂欄位或不受支援的欄位環境保留可見文字。 |

若需可移植的固定輸出，請將不受支援的欄位轉為普通文字，並在儲存前明確指派所需的值。這樣可以保留指定的文字，同時停止自動更新。若目標應用程式本身會重新計算欄位，亦請進行測試。

## **常見問題**

**如何判斷顯示的編號或日期是否為欄位？**

檢查 [Portion::getField](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getField)。非 `null` 的回傳值表示該部分是欄位；僅看文字本身無法判斷。

**移除欄位會同時移除文字或格式嗎？**

不會。[removeField](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#removeField) 會將既有部分轉為普通文字。若需要特定的凍結日期或備援文字，可在移除後自行指定值。

**內部字串能定義新的日期格式或公式嗎？**

不能。它僅用於識別欄位類型。未知的識別字不會提供求值器或 PHP 日期格式模式。請使用受支援的預定義類型，或自行將值格式化為普通文字。

**為什麼要在儲存後再次檢查簡報？**

欄位識別字、計算後的文字與格式是三個需要分別驗證的項目。格式轉換可能會改變可見結果，即使欄位識別字仍然存在。