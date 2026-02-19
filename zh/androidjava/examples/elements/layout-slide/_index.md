---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/androidjava/examples/elements/layout-slide/
keywords:
- 代码示例
- 布局幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中掌握布局幻灯片：使用 Java 示例选择、应用和自定义幻灯片布局、占位符和母版，适用于 PPT、PPTX 和 ODP 演示文稿。"
---
本文演示如何在 Aspose.Slides for Android via Java 中使用 **Layout Slides**。布局幻灯片定义普通幻灯片继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，并清理未使用的布局以减小演示文稿大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可重用的格式。例如，您可以添加一个在使用此布局的所有幻灯片上出现的文本框。

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // 创建一个具有空白布局类型和自定义名称的布局幻灯片。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // 向布局幻灯片添加一个文本框。
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // 添加两个使用此布局的幻灯片；两者都会从布局中继承文本。
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意 1:** 布局幻灯片充当各个幻灯片的模板。您可以一次定义通用元素，并在多个幻灯片中重复使用它们。

> 💡 **注意 2:** 当您向布局幻灯片添加形状或文本时，所有基于该布局的幻灯片将自动显示此共享内容。下面的截图显示了两张幻灯片，每张都从同一布局幻灯片继承了一个文本框。

![继承布局内容的幻灯片](layout-slide-result.png)

## **访问布局幻灯片**

可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）访问布局幻灯片。

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 通过索引访问布局幻灯片。
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 通过类型访问布局幻灯片。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **删除布局幻灯片**

如果不再需要，您可以删除特定的布局幻灯片。

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 根据类型获取布局幻灯片并将其删除。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **删除未使用的布局幻灯片**

为了减小演示文稿大小，您可能希望删除未被任何普通幻灯片使用的布局幻灯片。

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 自动删除所有未被任何幻灯片引用的布局幻灯片。
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **克隆布局幻灯片**

您可以使用 `addClone` 方法复制布局幻灯片。

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 根据类型获取现有布局幻灯片。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // 将布局幻灯片克隆到布局幻灯片集合的末尾。
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **摘要:** 布局幻灯片是管理跨幻灯片一致格式的强大工具。Aspose.Slides 提供了对创建、管理和优化布局幻灯片的完整控制。