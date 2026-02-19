---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/java/examples/elements/layout-slide/
keywords:
- 代码示例
- 布局幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中掌握布局幻灯片：选择、应用并自定义幻灯片布局、占位符和母版，提供针对 PPT、PPTX 和 ODP 演示文稿的 Java 示例。"
---
本文演示如何在 Aspose.Slides for Java 中使用 **Layout Slides**。布局幻灯片定义普通幻灯片继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，并清理未使用的布局幻灯片以减小演示文稿大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可复用的格式。例如，您可以添加一个文本框，使其在使用该布局的所有幻灯片上显示。

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // 创建一个使用空白布局类型且自定义名称的布局幻灯片。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // 向布局幻灯片添加一个文本框。
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // 使用此布局添加两张幻灯片；两者都会继承布局中的文本。
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** 布局幻灯片充当单个幻灯片的模板。您可以一次定义通用元素，然后在多个幻灯片中重复使用它们。

> 💡 **Note 2:** 当您向布局幻灯片添加形状或文本时，基于该布局的所有幻灯片会自动显示这些共享内容。  
> 以下截图显示了两张幻灯片，它们各自从相同的布局幻灯片继承了一个文本框。

![继承布局内容的幻灯片](layout-slide-result.png)

## **访问布局幻灯片**

布局幻灯片可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）进行访问。

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 按索引访问布局幻灯片。
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 按类型访问布局幻灯片。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **删除布局幻灯片**

如果某个布局幻灯片不再需要，您可以将其删除。

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 按类型获取布局幻灯片并将其删除。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **删除未使用的布局幻灯片**

为减小演示文稿大小，您可能需要删除未被任何普通幻灯片使用的布局幻灯片。

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
        // 按类型获取现有布局幻灯片。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // 将布局幻灯片克隆到布局幻灯片集合的末尾。
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** 布局幻灯片是管理幻灯片一致格式的强大工具。Aspose.Slides 提供了对创建、管理和优化布局幻灯片的完整控制。