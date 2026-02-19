---
title: 幻灯片
type: docs
weight: 10
url: /zh/nodejs-java/examples/elements/slide/
keywords:
- 代码示例
- 幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中控制幻灯片：创建、克隆、重新排序、调整大小、设置背景，并对 PPT、PPTX 和 ODP 演示文稿应用过渡效果。"
---
本文提供了一系列示例，演示如何使用 **Aspose.Slides for Node.js via Java** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

每个示例下面都有简要说明以及相应的 JavaScript 代码片段。

## **添加幻灯片**

要添加新幻灯片，必须先选择布局。本例使用 `Blank` 布局并向演示文稿中添加一个空白幻灯片。

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意：** 每个幻灯片布局都源自母版幻灯片，母版定义了整体设计和占位符结构。下图展示了 PowerPoint 中母版幻灯片及其关联布局的组织方式。

![母版与布局关系](master-layout-slide.png)

## **按索引访问幻灯片**

您可以使用索引访问幻灯片。这对于遍历或修改特定幻灯片非常有用。

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // 按索引访问幻灯片。
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **克隆幻灯片**

本示例演示如何克隆现有幻灯片。克隆的幻灯片会自动添加到幻灯片集合的末尾。

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **重新排序幻灯片**

您可以通过将幻灯片移动到新索引来更改顺序。本例将一张幻灯片移动到第一位。

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // 通过将第二张幻灯片移动到第一位置来重新排序幻灯片。
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **删除幻灯片**

要删除幻灯片，只需引用它并调用 `remove`。本例先添加第二张幻灯片，然后删除原始幻灯片，只保留新添加的那一张。

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```