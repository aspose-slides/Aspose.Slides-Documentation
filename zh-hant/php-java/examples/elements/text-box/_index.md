---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/php-java/examples/elements/text-box/
keywords:
- 文字方塊
- 新增文字方塊
- 存取文字方塊
- 移除文字方塊
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中建立與格式化文字方塊：設定字型、對齊、換行、自動調整大小，以及連結，以完善 PowerPoint 與 OpenDocument 簡報。"
---
在 Aspose.Slides 中，**文字方塊** 以 `AutoShape` 表示。幾乎所有形狀都可以包含文字，但一般的文字方塊沒有填充或邊框，且僅顯示文字。

本指南說明如何以程式方式新增、存取與移除文字方塊。

## **新增文字方塊**

文字方塊只是沒有填充或邊框且含有格式化文字的 `AutoShape`。以下說明如何建立它：

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 建立一個矩形形狀（預設為填充且有邊框，且不含文字）。
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // 移除填充與邊框，使其看起來像一般的文字方塊。
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // 設定文字格式。
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // 指定實際的文字內容。
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **註解:** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以作為文字方塊使用。

## **依內容存取文字方塊**

若要找出所有包含特定關鍵字（例如「Slide」）的文字方塊，可遍歷形狀並檢查它們的文字：

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 取得投影片上的第一個文字方塊。
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // 對匹配的文字方塊執行某些操作。
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **依內容移除文字方塊**

此範例會找出並刪除第一張投影片中所有包含特定關鍵字的文字方塊：

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **技巧:** 在遍歷期間修改形狀集合前，務必先建立該集合的副本，以避免集合修改錯誤。