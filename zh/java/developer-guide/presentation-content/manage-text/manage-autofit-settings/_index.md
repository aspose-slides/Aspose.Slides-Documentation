---
title: 用 Java 的 AutoFit 功能提升您的演示文稿
linktitle: 自动适配设置
type: docs
weight: 30
url: /zh/java/manage-autofit-settings/
keywords:
- 文本框
- 自动适配
- 不自动适配
- 适配文本
- 收缩文本
- 换行文本
- 调整形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 为该文本框使用 **Resize shape to fix text** 设置——它会自动调整文本框的大小，以确保文本始终适配其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文字变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文字。 
* 当文本框中的文字变短或变小，PowerPoint 会自动缩小文本框——降低其高度——以清除多余空间。 

在 PowerPoint 中，以下 4 项重要参数或选项控制文本框的自动适配行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java 提供了类似的选项——[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类下的某些属性——允许您控制演示文稿中文本框的自动适配行为。 

## **调整形状以适应文本**

如果您希望文字在进行更改后始终适配其所在的框，需要使用 **Resize shape to fix text** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 Java 代码演示了如何在 PowerPoint 演示文稿中指定文本必须始终适配其所在的框：
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


如果文字变长或变大，文本框将自动调整大小（增加高度），以确保所有文字都能适配其中。若文字变短，则会出现相反的情况。 

## **不自动适配**

如果您希望文本框或形状在文本内容更改后仍保持其尺寸，则需要使用 **Do not Autofit** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `None`。 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 Java 代码演示了如何在 PowerPoint 演示文稿中指定文本框始终保持其尺寸：
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


当文字对于其框来说过长时，会溢出。 

## **文本溢出时收缩**

如果文字对其框来说过长，可通过 **Shrink text on overflow** 选项指定将文字的大小和间距缩小，以使其适配框。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `Normal`。 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 Java 代码演示了如何在 PowerPoint 演示文稿中指定在文本溢出时进行收缩：
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
使用 **Shrink text on overflow** 选项时，只有当文字对其框来说过长时才会应用此设置。 
{{% /alert %}}

## **换行文本**

如果您希望形状内的文字在超出形状边界（仅宽度）时自动换行，需要使用 **Wrap text in shape** 参数。要指定此设置，必须将 [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类）设置为 `true`。 

以下 Java 代码演示了如何在 PowerPoint 演示文稿中使用换行文本设置：
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
如果将形状的 `WrapText` 属性设置为 `False`，当形状内部的文字长度超过形状宽度时，文字将沿单行延伸至形状边界之外。 
{{% /alert %}}

## **常见问题**

**文本框的内部边距会影响 AutoFit 吗？**

是的。填充（内部边距）会减小文字的可用区域，因此 AutoFit 会更早触发——更早缩小字体或调整形状大小。调优 AutoFit 之前请检查并调整边距。 

**AutoFit 如何与手动和软换行交互？**

强制换行保持不变，AutoFit 会在其周围调整字体大小和间距。删除不必要的换行通常可以降低 AutoFit 对文字的收缩力度。 

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**

是的。替换为具有不同字形度量的字体会改变文字的宽度/高度，从而影响最终的字体大小和换行。进行任何字体更改或替换后，请重新检查幻灯片。