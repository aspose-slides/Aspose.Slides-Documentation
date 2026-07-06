---
title: 從 PHP 簡報中取得段落邊界
linktitle: 段落邊界
type: docs
weight: 43
url: /zh-hant/php-java/paragraph-bounds/
keywords:
- 段落邊界
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習如何在 Aspose.Slides for PHP（透過 Java）中取得段落邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概述**

本文說明如何取得 Aspose.Slides 中段落的邊界、大小與座標。它展示了如何使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/getrect/) 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 取得段落矩形、如何取得表格儲存格文字框內段落的座標，並強調了測量單位、文字換行對邊界的影響、像素轉換以及有效段落格式值等重要細節。

## **取得段落的矩形座標**

使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/getrect/) 取得段落的邊界矩形。

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **取得表格儲存格文字框內段落的大小**

要取得表格儲存格文字框中 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 的大小與座標，請使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/getrect/)。回傳的矩形是相對於表格儲存格文字框的，因此在需要投影片層級座標時，必須加上表格位置與儲存格偏移量。

以下範例取得表格儲存格內段落的邊界，並在投影片上繪製矩形以視覺化這些邊界：

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**段落座標的單位是什麼？**

座標以點（point）為單位，1 吋等於 72 點。此單位適用於投影片上所有座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若為 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 啟用了 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setwraptext/)，文字會依區域寬度自動斷行，從而改變段落的實際邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**

能。使用下列公式將點轉換為像素：像素 = 點 × (DPI / 72)。結果取決於渲染或匯出時所選擇的 DPI。

**如何取得「有效」的段落格式參數，並考慮樣式繼承？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/php-java/shape-effective-properties/)；它會回傳縮排、行距、換行、RTL 等參數的最終合併值。