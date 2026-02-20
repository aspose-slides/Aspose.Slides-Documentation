---
title: SmartArt
type: docs
weight: 140
url: /zh/php-java/examples/elements/smartart/
keywords:
- SmartArt
- 添加 SmartArt
- 访问 SmartArt
- 删除 SmartArt
- SmartArt 布局
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 构建和编辑 SmartArt：添加节点、更改布局和样式、精确转换为形状，并导出为 PPT、PPTX 和 ODP。"
---
演示如何使用 **Aspose.Slides for PHP via Java** 添加 SmartArt 图形、访问它们、删除它们以及更改布局。

## **添加 SmartArt**

使用内置布局之一插入 SmartArt 图形。

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **访问 SmartArt**

检索幻灯片上的第一个 SmartArt 对象。

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个 SmartArt。
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **删除 SmartArt**

从幻灯片中删除 SmartArt 形状。

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是 SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **更改 SmartArt 布局**

更新现有 SmartArt 图形的布局类型。

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是 SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // 更改 SmartArt 的布局.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```