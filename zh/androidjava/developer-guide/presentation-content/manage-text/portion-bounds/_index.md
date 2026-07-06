---
title: 在 Android 上从演示文稿中获取文本片段边界
linktitle: 片段边界
type: docs
weight: 47
url: /zh/androidjava/portion-bounds/
keywords:
- 文本片段边界
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 通过 Java 检索 PowerPoint 演示文稿中的文本片段边界。"
---
## **概述**

文本片段表示段落内部的特定文字片段，并允许您独立于周围内容对该片段进行操作。 在 Aspose.Slides 中，当您需要获取文本片段的边界、仅对段落的一部分应用格式，或在更细粒度的层面控制文本行为时，可以使用文本片段。

本文展示了如何使用[IPortion.getRect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPortion#getRect--)获取文本片段的边界矩形。它还展示了如何使用[IPortion.getCoordinates](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPortion#getCoordinates--)获取文本片段起始位置的坐标。另外，还重点说明了常见的与文本片段相关的场景，例如为单个文本片段应用超链接、了解格式如何通过文本片段、段落、文本框和主题继承进行解析，以及处理指定字体不可用的情况。

## **获取文本片段的边界**

使用[IPortion.getRect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPortion#getRect--)检索文本片段的边界矩形：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **获取文本片段的坐标**

使用[IPortion.getCoordinates](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPortion#getCoordinates--)检索文本片段起始位置的坐标：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我能仅对单个段落中的部分文本应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/androidjava/manage-hyperlinks/)到单个文本片段；只有该片段可点击，而不是整段。

**样式继承是如何工作的：文本片段会覆盖哪些属性，而哪些属性来自段落或文本框？**

文本片段级别的属性具有最高优先级。如果在[IPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/)上未设置属性，Aspose.Slides 会从[IParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/)获取。如果仍未设置，则使用[ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)或[theme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/theme/)样式。

**如果为文本片段指定的字体在目标机器或服务器上不存在，会发生什么？**

[Font substitution rules](/slides/zh/androidjava/font-selection-sequence/)适用。文本可能会重新排版：度量、连字和宽度可能会改变，这对精确定位很重要。

**我能单独为文本片段设置填充透明度或渐变，而不影响段落的其他部分吗？**

可以，在[IPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/)级别的文本颜色、填充和透明度可以与相邻片段不同。