---
title: 在 PHP 中获取演示文稿的文本片段边界
linktitle: 片段边界
type: docs
weight: 47
url: /zh/php-java/portion-bounds/
keywords:
- 文本片段边界
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中检索文本片段边界。"
---
## **概述**

文本片段表示段落中一个特定的文本碎片，并允许您独立于周围内容对该碎片进行操作。在 Aspose.Slides 中，当您需要获取文本碎片的边界、仅对段落的一部分应用格式，或在更细粒度层面控制文本行为时，可使用片段。

本文展示如何使用[Portion::getRect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/getrect/)获取文本片段的边界矩形。它还展示如何使用[Portion::getCoordinates](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/getcoordinates/)获取文本片段起始位置的坐标。此外，本文还强调了常见的片段相关场景，如为单个文本碎片应用超链接、了解通过片段、段落、文本框和主题继承的格式解析方式，以及处理指定字体不可用的情况。

## **获取文本片段的边界**

使用[Portion::getRect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/getrect/)检索文本片段的边界矩形：

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

## **获取文本片段的坐标**

使用[Portion::getCoordinates](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/getcoordinates/)检索文本片段起始位置的坐标：

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

## **常见问题**

**我可以只给单段落中的部分文本应用超链接吗？**

可以，您可以[assign a hyperlink](/slides/zh/php-java/manage-hyperlinks/)到单独的片段；仅该碎片可点击，整段不会受影响。

**样式继承是如何工作的：片段会覆盖哪些属性，哪些属性来自段落或文本框？**

片段级别的属性具有最高优先级。如果在[Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/)上未设置属性，Aspose.Slides 会从[Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/)获取；如果段落也未设置，则使用[TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh/php-java/aspose.slides/theme/)的样式。

**如果片段指定的字体在目标机器或服务器上缺失会怎样？**

会应用[Font substitution rules](/slides/zh/php-java/font-selection-sequence/)。文本可能重新流动：度量、连字符和宽度可能变化，这会影响精确定位。

**我能单独为片段设置文字填充透明度或渐变，而不影响段落的其他部分吗？**

可以，[Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/)级别的文字颜色、填充和透明度可以与相邻碎片不同。