---
title: 使用 Java 中的 AutoFit 提升您的演示文稿
linktitle: AutoFit 设置
type: docs
weight: 30
url: /zh/java/manage-autofit-settings/
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
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示，并提升内容可读性。"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 会对该文本框使用 **Resize shape to fix text** 设置——它会自动调整文本框的大小，以确保其中的文本始终适配。 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文本。 
* 当文本框中的文本变短或变小，PowerPoint 会自动缩小文本框——降低其高度——以清除多余空间。 

在 PowerPoint 中，以下四个重要的参数或选项用于控制文本框的自动适配行为： 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java 提供了类似的选项——在 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类下的一些属性——可以让您控制演示文稿中文本框的自动适配行为。 

## **调整形状以适应文本**

如果您希望在对文本进行更改后，盒子中的文本始终能够适配该盒子，则必须使用 **Resize shape to fix text** 选项。要指定此设置，请将来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类的 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

下面的 Java 代码演示了如何指定文本必须始终适配其所在的盒子：

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


如果文本变长或变大，文本框会自动调整大小（高度增大），以确保所有文本都能适配。若文本变短，则会相反。 

## **不自动适配**

如果您希望文本框或形状无论其包含的文本如何更改都保持其尺寸，则必须使用 **Do not Autofit** 选项。要指定此设置，请将来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类的 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性设置为 `None`。 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

下面的 Java 代码演示了如何指定文本框在 PowerPoint 演示文稿中始终保持其尺寸：

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


当文本长度超过盒子时，内容会溢出。 

## **溢出时缩小文本**

如果文本长度超过盒子，通过 **Shrink text on overflow** 选项，您可以指定将文本的大小和间距缩小，以使其适配盒子。要指定此设置，请将来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类的 [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) 属性设置为 `Normal`。 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

下面的 Java 代码演示了如何在 PowerPoint 演示文稿中指定文本在溢出时进行缩小：

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
使用 **Shrink text on overflow** 选项时，设置仅在文本长度超过盒子时才会生效。 
{{% /alert %}}

## **换行文本**

如果您希望当文本超出形状的边界（仅宽度）时，在该形状内部进行换行，则必须使用 **Wrap text in shape** 参数。要指定此设置，需要将来自 [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) 类的 [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) 属性设置为 `true`。 

下面的 Java 代码演示了在 PowerPoint 演示文稿中使用换行文本设置：

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
如果将形状的 `WrapText` 属性设为 `False`，当形状内部的文本长度超过形状宽度时，文本会沿单行延伸超出形状边界。 
{{% /alert %}}

## **常见问题**

**文本框的内部边距会影响 AutoFit 吗？**  
是的。内边距会减少可用于文本的区域，因此 AutoFit 会更早触发——缩小字体或调整形状大小。请在调节 AutoFit 之前检查并调整边距。

**AutoFit 如何与手动和软换行交互？**  
强制换行会保留下来，AutoFit 会在这些换行周围调整字体大小和间距。删除不必要的换行通常可以减小 AutoFit 的收缩力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**  
会。更换为字形度量不同的字体会改变文本的宽高，从而影响最终的字体大小和换行方式。进行任何字体更改或替换后，请重新检查幻灯片。