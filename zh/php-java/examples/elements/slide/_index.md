---
title: 幻灯片
type: docs
weight: 10
url: /zh/php-java/examples/elements/slide/
keywords:
- 幻灯片
- 添加幻灯片
- 访问幻灯片
- 幻灯片索引
- 克隆幻灯片
- 重新排序幻灯片
- 删除幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中管理幻灯片：创建、克隆、重新排序、隐藏、设置背景和尺寸、应用切换效果，并导出为 PowerPoint 和 OpenDocument。"
---
本文提供了一系列示例，演示如何使用 **Aspose.Slides for PHP via Java** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

下面的每个示例都包括简要说明，随后是 PHP 代码片段。

## **添加幻灯片**

要添加新幻灯片，首先必须选择一个布局。在本例中，我们使用 `Blank` 布局并向演示文稿添加一个空白幻灯片。

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // 每张幻灯片基于布局，而布局本身基于母版幻灯片。
        // 使用 Blank 布局创建新幻灯片。
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // 使用所选布局添加一个空白幻灯片。
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **提示:** 每个幻灯片布局都源自母版幻灯片，母版定义整体设计和占位符结构。下图展示了 PowerPoint 中母版幻灯片及其关联布局的组织方式。

![母版与布局关系](master-layout-slide.png)

## **按索引访问幻灯片**

您可以使用索引访问幻灯片。

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // 通过索引访问幻灯片。
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **克隆幻灯片**

本示例演示如何克隆现有幻灯片。克隆后的幻灯片会自动添加到幻灯片集合的末尾。

```php
function cloneSlide() {
    // 默认情况下，演示文稿包含一张空白幻灯片。
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 克隆第一张幻灯片；它将被添加到演示文稿的末尾。
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // 克隆的幻灯片索引为 1（演示文稿中的第二张幻灯片）。
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **重新排序幻灯片**

您可以通过将幻灯片移动到新索引来更改顺序。在此示例中，我们将一张幻灯片移动到第一位置。

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // 将幻灯片移动到第一位置（其他幻灯片向下移动）。
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **删除幻灯片**

要删除幻灯片，只需引用它并调用 `remove`。本示例演示了按索引和按引用删除幻灯片。

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // 通过索引删除幻灯片。
        $presentation->getSlides()->removeAt(0);

        // 通过引用删除幻灯片。
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```