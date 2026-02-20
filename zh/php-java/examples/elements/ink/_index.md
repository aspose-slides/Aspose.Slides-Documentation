---
title: 墨迹
type: docs
weight: 180
url: /zh/php-java/examples/elements/ink/
keywords:
- 墨迹
- 访问墨迹
- 删除墨迹
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 处理幻灯片上的数字墨迹：添加笔划、编辑路径、设置颜色和宽度，并将结果导出为 PowerPoint 和 OpenDocument。"
---
提供使用 **Aspose.Slides for PHP via Java** 访问现有墨迹形状并将其删除的示例。

> ❗ **注意:** 墨迹形状代表来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的墨迹笔画，但您可以读取和修改现有的墨迹。

## **访问墨迹**

获取幻灯片上的第一个墨迹形状。

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个墨迹形状。
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **删除墨迹**

从幻灯片中删除墨迹形状。

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是墨迹形状。
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```