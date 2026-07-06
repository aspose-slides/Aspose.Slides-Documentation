---
title: 在 Java 中获取演示文稿的文本块边界
linktitle: 文本块边界
type: docs
weight: 47
url: /zh/java/portion-bounds/
keywords:
- 文本块边界
- 文本块
- 文本片段
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中检索文本块边界。"
---
## **概述**

文本块表示段落内的特定文本片段，并允许您独立于周围内容对该片段进行操作。在 Aspose.Slides 中，当您需要获取文本片段的边界、仅对段落的一部分应用格式，或更细致地控制文本行为时，可使用文本块。

本文展示了如何使用[IPortion.getRect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPortion#getRect--)获取文本块的边界矩形。它还展示了如何使用[IPortion.getCoordinates](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPortion#getCoordinates--)获取文本块起始位置的坐标。此外，还强调了一些常见的文本块相关场景，例如为单个文本片段应用超链接、了解格式如何通过文本块、段落、文本框和主题继承来解析，以及处理指定字体缺失的情况。

## **获取文本块的边界**

使用[IPortion.getRect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPortion#getRect--)检索文本块的边界矩形：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **获取文本块的坐标**

使用[IPortion.getCoordinates](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPortion#getCoordinates--)检索文本块起始位置的坐标：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我可以仅对单段落中的部分文本应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/java/manage-hyperlinks/)给单独的文本块；只有该片段可点击，而不是整个段落。

**样式继承如何工作：文本块会覆盖哪些属性，而哪些属性来源于段落或文本框？**

文本块级别的属性具有最高优先级。如果属性未在[IPortion](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportion/)上设置，Aspose.Slides 将从[IParagraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/)获取。若该处也未设置，则 Aspose.Slides 使用[ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)或[theme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/theme/)的样式。

**如果为文本块指定的字体在目标机器或服务器上缺失，会发生什么情况？**

[字体替换规则](/slides/zh/java/font-selection-sequence/)会生效。文本可能会重新排版：度量、连字符以及宽度可能会变化，这对精确定位很重要。

**我可以为特定文本块单独设置文字填充透明度或渐变，而不影响段落的其他部分吗？**

是的，位于[IPortion](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportion/)级别的文字颜色、填充和透明度可以与相邻片段不同。