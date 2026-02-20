---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/php-java/examples/elements/master-slide/
keywords:
- 母版幻灯片
- 添加母版幻灯片
- 访问母版幻灯片
- 删除母版幻灯片
- 未使用的母版幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中管理母版幻灯片：创建、编辑、克隆并格式化主题、背景和占位符，以统一 PowerPoint 和 OpenDocument 中的幻灯片。"
---
母版幻灯片构成 PowerPoint 幻灯片继承层次结构的顶层。**母版幻灯片** 定义常见的设计元素，例如背景、徽标和文本格式。**布局幻灯片** 继承自母版幻灯片，**普通幻灯片** 继承自布局幻灯片。

本文演示如何使用 Aspose.Slides for PHP via Java 创建、修改和管理母版幻灯片。

## **添加母版幻灯片**

此示例展示如何通过克隆默认母版创建新母版幻灯片。

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // 克隆默认母版幻灯片。
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **提示 1：**母版幻灯片提供了一种在所有幻灯片中应用一致品牌或共享设计元素的方式。对母版所做的任何更改都会自动反映在依赖的布局和普通幻灯片上。

> 💡 **提示 2：**添加到母版幻灯片的任何形状或格式都会被布局幻灯片继承，进而被使用这些布局的所有普通幻灯片继承。  
> 下图说明了在母版幻灯片上添加的文本框如何自动呈现在最终幻灯片上。

![母版继承示例](master-slide-banner.png)

## **访问母版幻灯片**

您可以使用 `Presentation::getMasters` 方法访问母版幻灯片。以下示例展示了如何检索并处理它们：

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 访问第一个母版幻灯片。
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **删除母版幻灯片**

母版幻灯片可以通过索引或引用进行删除。

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 按索引删除。
        $presentation->getMasters()->removeAt(0);

        // 或按引用删除。
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **删除未使用的母版幻灯片**

有些演示文稿包含未使用的母版幻灯片。删除这些幻灯片可以帮助减小文件大小。

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 删除所有未使用的母版幻灯片（即使标记为 Preserve 的也会删除）。
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **提示：**使用 `removeUnused(true)` 可清理未使用的母版幻灯片并减小演示文稿的大小。