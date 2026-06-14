---
title: 在 PHP 中從簡報取得段落邊界
linktitle: 段落
type: docs
weight: 60
url: /zh-hant/php-java/paragraph/
keywords:
- 段落邊界
- 文字片段邊界
- 段落座標
- 片段座標
- 段落大小
- 文字片段大小
- 文字框
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中檢索段落與文字片段的邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概觀**

本文說明如何取得 Aspose.Slides 中段落與文字片段的邊界、大小與座標。它展示了如何使用 `getRect()` 取得 `TextFrame` 中段落的矩形、如何在表格儲存格文字框內取得段落與片段的座標，並強調重要細節，例如測量單位、文字換行對邊界的影響、像素轉換，以及有效段落格式化值。

## **取得文字框中段落與片段的座標**
使用 Aspose.Slides for PHP via Java，開發人員現在可以取得 TextFrame 中段落集合內段落的矩形座標。它也允許您取得段落中片段集合的[片段座標](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getCoordinates)。在本主題中，我們將透過範例示範如何取得段落的矩形座標以及段落內片段的位置。

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **取得段落的矩形座標**
使用[**getRect()**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getRect) 方法，開發人員可以取得段落的邊界矩形。

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **取得表格儲存格文字框內段落與片段的大小**
若要取得表格儲存格文字框內 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Portion) 或 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Paragraph) 的大小與座標，您可以使用 [Portion::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getRect) 和 [Paragraph::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getRect) 方法。

以下範例程式碼示範上述操作：

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**段落與文字片段的座標以何種單位回傳？**  
以點 (point) 為單位，1 吋 = 72 點。此單位適用於投影片上所有的座標與尺寸。

**文字換行會影響段落的邊界嗎？**  
是。若在[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 中啟用[wrapping](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setwraptext/)，文字會換行以符合區域寬度，從而改變段落的實際邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**  
可以。使用以下公式將點轉換為像素：pixels = points × (DPI / 72)。結果取決於渲染或匯出時選擇的 DPI。

**如何取得考慮樣式繼承的「有效」段落格式參數？**  
使用[有效段落格式資料結構](/slides/zh-hant/php-java/shape-effective-properties/)，它會返回縮排、間距、換行、RTL 以及其他屬性的最終合併值。