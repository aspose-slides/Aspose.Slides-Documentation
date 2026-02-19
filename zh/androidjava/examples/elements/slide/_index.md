---
title: 幻灯片
type: docs
weight: 10
url: /zh/androidjava/examples/elements/slide/
keywords:
- 代码示例
- 幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中控制幻灯片：使用 Java 创建、克隆、重新排序、调整大小、设置背景，并为 PPT、PPTX 和 ODP 演示文稿应用过渡效果。"
---
本文提供了一系列示例，演示如何使用 **Aspose.Slides for Android via Java** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

下面的每个示例包括简要说明以及 Java 代码片段。

## **添加幻灯片**

要添加新幻灯片，首先必须选择布局。在本例中，我们使用 `Blank` 布局并向演示文稿添加一个空白幻灯片。

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意:** 每个幻灯片布局都来源于母版幻灯片，母版定义了整体设计和占位符结构。下图展示了 PowerPoint 中母版幻灯片及其关联布局的组织方式。

![母版和布局关系](master-layout-slide.png)

## **按索引访问幻灯片**

您可以通过索引访问幻灯片，或根据引用查找幻灯片的索引。这对于遍历或修改特定幻灯片非常有用。

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // 添加另一个空白幻灯片。
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // 按索引访问幻灯片。
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // 从引用获取幻灯片索引，然后按索引访问它。
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **克隆幻灯片**

本示例演示如何克隆现有幻灯片。克隆的幻灯片会自动添加到幻灯片集合的末尾。

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **重新排序幻灯片**

您可以通过将幻灯片移动到新索引来改变其顺序。在本例中，我们将克隆的幻灯片移动到第一位置。

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **删除幻灯片**

要删除幻灯片，只需引用它并调用 `remove`。本示例先添加第二张幻灯片，然后删除原始幻灯片，最终仅保留新添加的幻灯片。

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```