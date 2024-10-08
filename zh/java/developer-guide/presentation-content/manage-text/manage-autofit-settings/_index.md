---
title: 管理自动适应设置
type: docs
weight: 30
url: /zh/java/manage-autofit-settings/
keywords: "文本框, 自动适应, PowerPoint 演示文稿, Java, Aspose.Slides for Java"
description: "在 Java 中为 PowerPoint 的文本框设置自动适应设置"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **调整形状以适应文本** 设置——它会自动调整文本框的大小，以确保文本始终适合其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动放大文本框——增加其高度——以便能够容纳更多文本。
* 当文本框中的文本变得更短或更小时，PowerPoint 会自动减少文本框——减小其高度——以清除多余的空间。

在 PowerPoint 中，这四个重要参数或选项控制文本框的自动适应行为：

* **不自动适应**
* **溢出时缩小文本**
* **调整形状以适应文本**
* **在形状中换行文本。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java 提供了类似的选项——一些属性在 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类中——允许您控制演示文稿中文本框的自动适应行为。

## **调整形状以适应文本**

如果您希望文本在文本框中始终适合该文本框，您必须使用 **调整形状以适应文本** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 Java 代码演示如何指定文本在 PowerPoint 演示文稿中的文本框中始终适合：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

如果文本变得更长或更大，文本框将被自动调整大小（高度增加），以确保所有文本都适合其中。如果文本变得更短，则反向发生。

## **不自动适应**

如果您希望文本框或形状在包含的文本发生变化时保持其尺寸，您必须使用 **不自动适应** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 Java 代码演示如何指定文本框必须始终保持其尺寸在 PowerPoint 演示文稿中：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

当文本变得太长而无法容纳在文本框内时，它将溢出。

## **溢出时缩小文本**

如果文本变得太长而无法在文本框内容纳，您可以通过 **溢出时缩小文本** 选项来指定文本的大小和间距必须减少，以使其适合文本框。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 Java 代码演示如何指定文本在 PowerPoint 演示文稿中溢出时必须缩小：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="信息" color="info" %}}

使用 **溢出时缩小文本** 选项时，只有在文本变得太长而无法在文本框中容纳时，设置才会生效。

{{% /alert %}}

## **换行文本**

如果您希望形状中的文本在超出形状边界（仅宽度）时换行，您必须使用 **在形状中换行文本** 参数。要指定此设置，您必须将 [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `true`。

以下 Java 代码演示如何在 PowerPoint 演示文稿中使用换行文本设置：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

如果您将 `WrapText` 属性设置为 `False`，当形状内部的文本变得比形状的宽度更长时，文本将沿着单行扩展超出形状的边界。

{{% /alert %}}