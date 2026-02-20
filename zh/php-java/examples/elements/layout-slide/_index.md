---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/php-java/examples/elements/layout-slide/
keywords:
- 布局幻灯片
- 添加布局幻灯片
- 访问布局幻灯片
- 删除布局幻灯片
- 未使用的布局幻灯片
- 克隆布局幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 PHP 与 Aspose.Slides 管理布局幻灯片：在 PPT、PPTX 和 ODP 演示文稿中创建、应用、克隆、重命名并自定义占位符和主题。"
---
本文演示了如何在 Aspose.Slides for PHP via Java 中使用 **Layout Slides**。布局幻灯片定义了普通幻灯片继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，并清理未使用的幻灯片以减小演示文稿大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可复用的格式。例如，您可以添加一个在使用此布局的所有幻灯片上显示的文本框。

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // 创建一个具有空白布局类型和自定义名称的布局幻灯片。
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **提示 1:** 布局幻灯片充当单个幻灯片的模板。您可以一次定义通用元素，然后在多个幻灯片中重复使用它们。

> 💡 **提示 2:** 当您在布局幻灯片上添加形状或文本时，基于该布局的所有幻灯片会自动显示此共享内容。  
> 下面的截图显示了两张幻灯片，它们各自从同一布局幻灯片继承了文本框。

![幻灯片继承布局内容](layout-slide-result.png)


## **访问布局幻灯片**

可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）访问布局幻灯片。

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 按索引访问.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // 按布局类型访问.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **删除布局幻灯片**

如果不再需要，您可以删除特定的布局幻灯片。

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 按类型获取布局幻灯片并将其移除。
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **删除未使用的布局幻灯片**

为了减小演示文稿大小，您可能需要删除任何普通幻灯片未使用的布局幻灯片。

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 自动删除所有未被任何幻灯片引用的布局幻灯片。
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **克隆布局幻灯片**

您可以使用 `addClone` 方法复制布局幻灯片。

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 按类型获取现有的布局幻灯片。
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // 克隆布局幻灯片并将其添加到布局幻灯片集合的末尾。
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **摘要:** 布局幻灯片是管理跨幻灯片一致格式的强大工具。Aspose.Slides 提供了对创建、管理和优化布局幻灯片的完整控制。