---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/nodejs-java/examples/elements/layout-slide/
keywords:
- 代码示例
- 布局幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中掌握布局幻灯片：选择、应用和自定义幻灯片布局、占位符和母版，并提供 PPT、PPTX 和 ODP 演示文稿的示例。"
---
本文演示如何在 Aspose.Slides for Node.js via Java 中使用 **Layout Slides**。布局幻灯片定义了普通幻灯片所继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，并清理未使用的布局幻灯片以减小演示文稿大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可重用的格式。

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // 创建一个带有空白布局类型和自定义名称的布局幻灯片。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意 1:** 布局幻灯片充当单个幻灯片的模板。您可以一次定义公共元素，并在多个幻灯片中重复使用它们。

> 💡 **注意 2:** 当您向布局幻灯片添加形状或文本时，所有基于该布局的幻灯片会自动显示此共享内容。下图显示了两个幻灯片，它们各自从同一布局幻灯片继承了一个文本框。

![继承布局内容的幻灯片](layout-slide-result.png)

## **访问布局幻灯片**

布局幻灯片可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）访问。

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 通过索引访问布局幻灯片。
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 通过类型访问布局幻灯片。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **删除布局幻灯片**

如果不再需要，可以删除特定的布局幻灯片。

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 按类型获取布局幻灯片并将其删除。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **删除未使用的布局幻灯片**

为了减小演示文稿大小，您可能希望删除未被任何普通幻灯片使用的布局幻灯片。

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // 自动删除所有未被任何幻灯片引用的布局幻灯片。
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **克隆布局幻灯片**

您可以使用 `addClone` 方法复制布局幻灯片。

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 获取指定类型的现有布局幻灯片。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // 将布局幻灯片克隆到布局幻灯片集合的末尾。
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **概要:** 布局幻灯片是管理跨幻灯片一致格式的强大工具。Aspose.Slides 提供了对布局幻灯片的创建、管理和优化的完整控制。