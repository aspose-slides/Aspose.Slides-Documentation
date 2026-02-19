---
title: 文本框
type: docs
weight: 40
url: /zh/androidjava/examples/elements/text-box/
keywords:
- 代码示例
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中使用文本框：使用 Java 对 PPT、PPTX 和 ODP 演示文稿进行添加、格式化、对齐、换行、自动适应和样式设置。"
---
在 Aspose.Slides 中，**文本框**由 `AutoShape` 表示。几乎任何形状都可以包含文本，但典型的文本框没有填充或边框，仅显示文本。

本指南说明如何以编程方式添加、访问和删除文本框。

## **添加文本框**

文本框只是一个没有填充或边框且包含一些格式化文本的 `AutoShape`。以下是创建方法：

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 创建一个矩形形状（默认填充并带边框且无文字）。
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // 移除填充和边框，使其看起来像普通的文本框。
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // 设置文本格式。
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // 赋予实际的文本内容。
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意:** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以充当文本框。

## **按内容访问文本框**

要查找包含特定关键字（例如“Slide”）的所有文本框，请遍历形状并检查其文本：

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // 只有 AutoShape 可以包含可编辑的文本。
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // 对匹配的文本框执行操作。
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **按内容删除文本框**

此示例查找并删除第一张幻灯片上包含特定关键字的所有文本框：

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **提示:** 在迭代期间修改形状集合前，始终先创建该集合的副本，以避免集合修改错误。