---
title: 使用 PHP 在簡報中管理文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/php-java/manage-textbox/
keywords:
- 文字方塊
- 文字框
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄位
- 新增超連結
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中建立、辨識、格式化與更新文字方塊。"
---
## **簡介**

在 Aspose.Slides for PHP via Java 中，投影片文字儲存在屬於形狀的文字框中。 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 類別代表最常見的含文字形狀，並透過 [AutoShape::getTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#getTextFrame) 方法公開其文字。

{{% alert color="info" title="注意" %}}
每個自動形狀皆繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)，但不是所有形狀都是自動形狀或支援文字框。處理現有簡報時，請使用 `java_instanceof` 檢查形狀是否為 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 後，才存取其文字。
{{% /alert %}}

## **在投影片上建立文字方塊**

若要建立文字方塊，先在投影片上加入自動形狀，將文字加入其文字框，然後儲存簡報。以下範例會建立一個矩形文字方塊：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

傳遞給 [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addAutoShape) 的座標與尺寸以點為單位。[AutoShape::addTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#addTextFrame) 會使用提供的文字初始化文字框。

## **檢查文字方塊形狀**

使用 [AutoShape::isTextBox](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#isTextBox) 方法判斷自動形狀是否被視為文字方塊。當簡報同時包含含文字與純圖形的自動形狀時，這個方法非常有用。

![文字方塊與形狀](istextbox.png)

以下範例會檢查簡報中的每個自動形狀：

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

新加入的自動形狀在未包含非空文字之前不被視為文字方塊。您可以透過 [AutoShape::addTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#addTextFrame) 或 [TextFrame::setText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#setText) 提供文字。加入或指定空字串會使 [AutoShape::isTextBox](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#isTextBox) 回傳 `false`：

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

前兩次呼叫會印出 `true`；後兩次會印出 `false`。

## **找到擁有文字框的形狀**

通用的文字處理程式碼可能只取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)，卻不知道它屬於哪個簡報物件。使用唯讀的 [TextFrame::getParentShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentShape) 方法即可回溯到其擁有的 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)。

對於由自動形狀或其他含文字形狀擁有的文字框，[TextFrame::getParentShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentShape) 會回傳擁有者，而 [TextFrame::getParentCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentCell) 會回傳 `null`。在存取之前請使用 `java_is_null` 檢查回傳值。若要同時識別形狀與表格儲存格的擁有者（包含與 SmartArt 節點相關的形狀），請參閱 [Search and Replace Text](/slides/zh-hant/php-java/search-and-replace-text/)。

## **為文字方塊新增欄位**

[TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setColumnCount) 方法會將文字框分割成多個欄位，而 [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setColumnSpacing) 則設定欄位之間的間距（單位為點）。這兩項設定皆屬於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/)，可透過現有文字方塊的文字框進行變更。文字會在同一形狀內的欄位之間重新排版，不會延伸至其他形狀。

以下範例建立一個三欄文字方塊，欄與欄之間間距為 10 點，儲存簡報，並從輸出檔案讀回設定值：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **從單一欄位擷取文字**

使用 [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#splitTextByColumns) 可取得既有文字框中每個可視欄位所分配的文字。此方法會為每個欄位回傳一個字串，依欄位的閱讀順序排列。單欄文字框會產生僅含一個元素的陣列，空欄位則以空字串表示。回傳的字串僅含純文字；不會保留段落層級的格式資訊。

此功能在以下情境中特別有用：

- 擷取文字同時保留其以欄位為基礎的閱讀順序。
- 索引或比較多欄投影片的內容。
- 將每個欄位匯出到不同的檔案、資料庫欄位或其他目的地。
- 檢查在變更欄位數 (TextFrameFormat::setColumnCount)、欄位間距 (TextFrameFormat::setColumnSpacing)、字型或文字框大小後，文字如何重新分配。

此方法僅回報目前 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 內的文字分布；不會自動在不同形狀或文字方塊之間流動文字。欄位分布可能受可用字型與其他文字排版設定影響，因此在結果一致性重要時，請確保所需字型已安裝。

以下範例載入簡報，尋找第一個具多欄文字框的自動形狀，讀取其設定的欄位數，並將每個欄位的文字寫入獨立檔案。未提供文字框的形狀會被略過。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **更新文字**

若要在整份簡報中更新文字，請遍歷投影片與形狀，選取自動形狀，然後編輯其文字段落。於段落層級作業可同時變更文字與字元格式。

以下範例將自動形狀文字中所有 `years` 替換為 `months`，並將受影響的段落設定為粗體：

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此遍歷僅會更新自動形狀中的文字。儲存在表格、圖表、SmartArt 或群組形狀中的文字，必須分別遍歷這些物件的集合才能修改。

## **新增帶有超連結的文字方塊**

超連結可以指派給特定的文字段落，只有該段文字會成為可點擊的連結。使用 [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) 可將段落與外部 URL 關聯。

以下範例建立帶連結的文字，並將其儲存至簡報：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**文字方塊與母片或版面配置投影片上的文字佔位區有何差異？**

佔位區 ([placeholder](/slides/zh-hant/php-java/manage-placeholder/)) 可以從 [master slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 或 [layout slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 繼承其位置與格式。一般的文字方塊則是建立於當前投影片上的獨立形狀，版面變更時不會取得佔位區的行為。

**如何在不變更圖表、表格或 SmartArt 文字的前提下取代文字？**

將遍歷範圍限制在 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 物件，如同「更新文字」範例所示。圖表、表格與 SmartArt 會在各自的物件模型中保存文字，因此不會被此迴圈修改。