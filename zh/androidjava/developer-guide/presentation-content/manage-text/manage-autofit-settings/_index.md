---
title: 使用 Android 上的 AutoFit 增强您的演示文稿
linktitle: 自动适配设置
type: docs
weight: 30
url: /zh/androidjava/manage-autofit-settings/
keywords:
- 文本框
- 自动适配
- 不自动适配
- 适配文本
- 缩小文本
- 换行文本
- 调整形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for Android 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **Resize shape to fix text** 设置——它会自动调整文本框大小，以确保其中的文本始终能够完整显示。

![PowerPoint 文本框](textbox-in-powerpoint.png)

* 当文本框中的文字变长或变大时，PowerPoint 会自动增大文本框——提升其高度——以容纳更多文字。  
* 当文本框中的文字变短或变小，PowerPoint 会自动缩小文本框——降低其高度——以去除多余空间。

在 PowerPoint 中，有 4 个重要参数或选项用于控制文本框的自动适配行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint 自动适配选项](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java 提供了类似的选项——在 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类下的一些属性——可以让您控制演示文稿中文本框的自动适配行为。

## **Resize a Shape to Fit Text**

如果希望文本在更改后始终适合其所在的框，需要使用 **Resize shape to fix text** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `Shape`。

![PowerPoint 始终适配设置](alwaysfit-setting-powerpoint.png)

下面的 Java 代码演示了如何在 PowerPoint 演示文稿中指定文本必须始终适应其所在的框：
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


如果文字变长或变大，文本框会自动（高度）增大，以确保所有文字都能容纳其中；如果文字变短，则相反。

## **Do Not Autofit**

如果希望文本框或形状在文字内容变化时保持其尺寸不变，需要使用 **Do not Autofit** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `None`。

![PowerPoint 不自动适配设置](donotautofit-setting-powerpoint.png)

下面的 Java 代码演示了如何在 PowerPoint 演示文稿中指定文本框必须保持其尺寸：
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


当文字长度超出框的范围时，会溢出显示。

## **Shrink Text on Overflow**

如果文字超出框的范围，可通过 **Shrink text on overflow** 选项指定在溢出时缩小文字的大小和间距，使其适应框。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `Normal`。

![PowerPoint 缩小文字设置](shrinktextonoverflow-setting-powerpoint.png)

下面的 Java 代码演示了如何在 PowerPoint 演示文稿中指定文字在溢出时进行缩小：
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


{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 选项时，仅当文字超出框的范围时才会应用该设置。
{{% /alert %}}

## **Wrap Text**

如果希望文字在超出形状宽度时换行显示，需要使用 **Wrap text in shape** 参数。要指定此设置，需要将 [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类）设置为 `true`。

下面的 Java 代码演示了如何在 PowerPoint 演示文稿中使用换行设置：
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


{{% alert title="Note" color="warning" %}} 
如果为形状的 `WrapText` 属性设置为 `False`，当形状内部的文字长度超过形状宽度时，文字会在单行中超出形状边界。
{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**

是的。内边距（内部边距）会减少可用于文字的区域，因此 AutoFit 会更早触发——更快地缩小字体或调整形状大小。请先检查并调整边距，然后再微调 AutoFit。

**How does AutoFit interact with manual and soft line breaks?**

强制换行会保留其位置，AutoFit 会在这些换行周围调整字体大小和间距。删除不必要的换行通常可以降低 AutoFit 对文字的收缩力度。

**Does changing the theme font or triggering font substitution affect AutoFit results?**

会。替换为字形度量不同的字体会改变文字的宽高，从而影响最终的字体大小和换行方式。任何字体更改或替换后，请重新检查幻灯片的显示效果。