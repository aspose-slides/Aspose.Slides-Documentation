---
title: 在 PHP 中從簡報中取得文字區段的邊界
linktitle: 區段邊界
type: docs
weight: 47
url: /zh-hant/php-java/portion-bounds/
keywords:
- 文字區段邊界
- 文字區段
- 文字片段
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用透過 Java 的 Aspose.Slides for PHP 在 PowerPoint 簡報中取得文字區段的邊界。"
---
## **概述**

文字區段代表段落內的特定文字片段，並允許您獨立於周圍內容處理該片段。 在 Aspose.Slides 中，當您需要取得文字片段的邊界、僅對段落的一部分套用格式，或在更精細的層面控制文字行為時，可使用區段。

本文說明如何使用 [Portion::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/getrect/) 取得區段的邊界矩形。亦說明如何使用 [Portion::getCoordinates](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/getcoordinates/) 取得區段起始位置的座標。此外，還概述了常見的區段相關情境，例如將超連結套用於單一文字片段、了解格式如何透過區段、段落、文字框與佈景主題的繼承而決定，以及處理指定字型不存在的情況。

## **取得文字區段的邊界**

使用 [Portion::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/getrect/) 來取得文字區段的邊界矩形：

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **取得文字區段的座標**

使用 [Portion::getCoordinates](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/getcoordinates/) 來取得文字區段起始位置的座標：

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**我可以只對單一段落中的部分文字套用超連結嗎？**

是的，您可以將[指派超連結](/slides/zh-hant/php-java/manage-hyperlinks/)給單一區段；只有該片段會變成可點擊，而不是整個段落。

**樣式繼承如何運作：區段會覆寫哪些屬性，哪些會從段落或文字框取得？**

區段層級的屬性具有最高優先權。若在[Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/)上未設定屬性，Aspose.Slides 會從[Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)取得。若該處仍未設定，則會使用[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/theme/)的樣式。

**如果為區段指定的字型在目標機器或伺服器上不存在，會發生什麼情況？**

[字型替換規則](/slides/zh-hant/php-java/font-selection-sequence/)會生效。文字可能會重新換行：度量、斷字與寬度都可能改變，這對於精確定位很重要。

**我可以為區段設定特定的文字填色透明度或漸層，而不影響段落的其他部分嗎？**

可以，於[Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/)層級的文字顏色、填滿與透明度可以與相鄰的片段不同。