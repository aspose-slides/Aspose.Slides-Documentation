---
title: 管理自适应设置
type: docs
weight: 30
url: /zh/androidjava/manage-autofit-settings/
keywords: "文本框, 自适应, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中设置 PowerPoint 中文本框的自适应设置"
---

默认情况下，当您添加一个文本框时，Microsoft PowerPoint 会使用**调整形状以适合文本**设置来处理文本框——它会自动调整文本框的大小，以确保文本总是适合文本框内。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动放大文本框——增加其高度——以便容纳更多文本。
* 当文本框中的文本变得更短或更小，PowerPoint 会自动缩小文本框——减少其高度——以清除多余的空间。

在 PowerPoint 中，有4个重要参数或选项控制文本框的自适应行为：

* **不自适应**
* **溢出时缩小文本**
* **调整形状以适合文本**
* **在形状内换行文本。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java 提供类似的选项——在 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类下的一些属性——允许您控制演示文稿中文本框的自适应行为。

## **调整形状以适合文本**

如果您希望文本框中的文本在文本更改后始终适合该框，您必须使用**调整形状以适合文本**选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

这段 Java 代码显示了如何指定文本必须始终适合其框的 PowerPoint 演示文稿：

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

如果文本变得更长或更大，文本框将自动调整大小（高度增加），以确保所有文本都适合其中。如果文本变得更短，则情况相反。

## **不自适应**

如果您希望文本框或形状在文本更改时保留其尺寸，则必须使用**不自适应**选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

这段 Java 代码显示了如何指定文本框在 PowerPoint 演示文稿中必须始终保留其尺寸：

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

当文本变得过长而无法放入其框内时，它将溢出。

## **溢出时缩小文本**

如果文本对于其框来说过长，则通过**溢出时缩小文本**选项，您可以指定文本的大小和间距必须减少，以使其适合框内。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

这段 Java 代码显示了如何指定在 PowerPoint 演示文稿中，文本在溢出时必须被缩小：

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

当使用**溢出时缩小文本**选项时，该设置仅在文本变得过长而无法放入其框时应用。

{{% /alert %}}

## **换行文本**

如果您希望形状中的文本在文本超出形状边界（仅宽度）时能够换行，您必须使用**在形状内换行文本**参数。要指定此设置，您必须将 [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `true`。

这段 Java 代码显示了如何在 PowerPoint 演示文稿中使用换行文本设置：

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

如果您将 `WrapText` 属性设置为 `False`，当形状内部的文本变得比形状的宽度长时，文本将沿着单行延伸超出形状的边界。

{{% /alert %}}