---
title: 在 PHP 中获取演示文稿的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/php-java/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中检索段落边界，以优化 PowerPoint 演示文稿中的文本定位。"
---
## **概述**

本文说明如何获取 Aspose.Slides 中段落的边界、大小和坐标。它展示了如何使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/getrect/) 从 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 中检索段落矩形，如何获取表格单元格 TextFrame 中段落的坐标，并重点说明了测量单位、换行对边界的影响、像素转换以及有效段落格式值等重要细节。

## **获取段落的矩形坐标**

使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/getrect/) 获取段落的边界矩形。

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

## **获取表格单元格 TextFrame 中段落的大小**

要获取表格单元格 TextFrame 中 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 的大小和坐标，请使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/getrect/)。返回的矩形相对于表格单元格 TextFrame，因此在需要幻灯片级坐标时需加上表格位置和单元格偏移。

以下示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以可视化这些边界：

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

## **常见问题**

**段落坐标以何种单位衡量？**

它们以点（point）为单位，1 英寸等于 72 点。这适用于幻灯片上的所有坐标和尺寸。

**换行会影响段落的边界吗？**

会。如果为 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 启用了 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/setwraptext/)，文本会在区域宽度内换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式将点转换为像素：像素 = 点 × (DPI / 72)。结果取决于渲染或导出时选择的 DPI。

**如何获取考虑样式继承后的“有效”段落格式参数？**

使用 [effective paragraph formatting data structure](/slides/zh/php-java/shape-effective-properties/)，它返回缩进、间距、换行、RTL 等属性的最终合并值。