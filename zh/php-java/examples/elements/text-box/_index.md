---
title: 文本框
type: docs
weight: 40
url: /zh/php-java/examples/elements/text-box/
keywords:
- 文本框
- 添加文本框
- 访问文本框
- 删除文本框
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 创建和格式化文本框：设置字体、对齐、换行、自动调整大小，以及链接，以完善 PowerPoint 和 OpenDocument 的幻灯片。"
---
在 Aspose.Slides 中，**文本框**由 `AutoShape` 表示。几乎任何形状都可以包含文本，但典型的文本框没有填充或边框，仅显示文本。

本指南说明如何以编程方式添加、访问和删除文本框。

## **添加文本框**

文本框仅是一个没有填充或边框且包含一些格式化文本的 `AutoShape`。下面展示如何创建一个：

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 创建一个矩形形状（默认填充并带边框且无文本）。
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // 移除填充和边框，使其看起来像典型的文本框。
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // 设置文本格式。
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // 分配实际的文本内容。
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **注意：** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以充当文本框。

## **按内容访问文本框**

要查找所有包含特定关键字（例如“Slide”）的文本框，请遍历形状并检查其文本：

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个文本框。
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // 对匹配的文本框进行操作。
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **按内容删除文本框**

此示例查找并删除第一张幻灯片上所有包含特定关键字的文本框：

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

> 💡 **提示：** 在遍历期间修改时，请始终先创建形状集合的副本，以避免集合修改错误。