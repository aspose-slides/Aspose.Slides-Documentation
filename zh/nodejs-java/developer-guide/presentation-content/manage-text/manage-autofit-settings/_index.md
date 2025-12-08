---
title: 管理自动适应设置
type: docs
weight: 30
url: /zh/nodejs-java/manage-autofit-settings/
keywords: "文本框, 自动适应, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中为 PowerPoint 中的文本框设置自动适应"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **Resize shape to fix text** 设置——它会自动调整文本框大小，以确保文本始终适合其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文本。 
* 当文本框中的文本变得更短或更小时时，PowerPoint 会自动缩小文本框——减少其高度——以清除多余空间。 

在 PowerPoint 中，有 4 个重要参数或选项用于控制文本框的自动适应行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java 提供了类似的选项——在 [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) 类下的一些属性——允许您控制演示文稿中文本框的自动适应行为。

## **调整形状以适应文本**

如果您希望文本在修改后始终适应其所在的框，需要使用 **Resize shape to fix text** 选项。要指定此设置，请从 [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) 类调用 `setAutofitType` 方法，传入 `Shape` 值。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

下面的 JavaScript 代码演示如何在 PowerPoint 演示文稿中指定文本必须始终适应其框：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


如果文本变得更长或更大，文本框会自动调整大小（高度增加），以确保所有文本都能适应。如果文本变短，则相反。

## **不自动适应**

如果您希望文本框或形状无论文本如何变化都保持其尺寸，需要使用 **Do not Autofit** 选项。要指定此设置，请从 [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) 类调用 `setAutofitType` 方法，传入 `None` 值。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

下面的 JavaScript 代码演示如何在 PowerPoint 演示文稿中指定文本框必须保持其尺寸：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


当文本对其框来说过长时，会溢出。

## **溢出时收缩文本**

如果文本对其框来说过长，通过 **Shrink text on overflow** 选项，您可以指定将文本的大小和间距缩小以使其适应框。要指定此设置，请从 [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) 类调用 `setAutofitType` 方法，传入 `Normal` 值。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

下面的 JavaScript 代码演示如何在 PowerPoint 演示文稿中指定在溢出时收缩文本：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 选项时，只有当文本对其框来说过长时，才会应用此设置。
{{% /alert %}}

## **换行文本**

如果您希望形状内的文本在超出形状边界（仅宽度）时换行，需要使用 **Wrap text in shape** 参数。要指定此设置，必须从 [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) 类调用 `setWrapText` 方法，传入 `true` 值。

下面的 JavaScript 代码演示如何在 PowerPoint 演示文稿中使用换行文本设置：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 
如果对形状调用 `setWrapText` 方法并传入 `False` 值，当形状内的文本长度超过形状宽度时，文本会在单行上延伸超出形状边界。
{{% /alert %}}

## **常见问题**

**Do the text frame’s internal margins affect AutoFit?**  
**文本框的内部边距会影响 AutoFit 吗？**  
是的。内部边距（填充）会减小可用于文本的面积，从而使 AutoFit 更早触发——会更快缩小字体或调整形状大小。请在调优 AutoFit 之前检查并调整边距。

**How does AutoFit interact with manual and soft line breaks?**  
**AutoFit 与手动和软换行如何交互？**  
强制换行会保留下来，AutoFit 会在它们周围调整字体大小和间距。删除不必要的换行通常可以降低 AutoFit 的收缩力度。

**Does changing the theme font or triggering font substitution affect AutoFit results?**  
**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**  
会。替换为字形度量不同的字体会改变文本的宽度/高度，从而可能改变最终的字体大小和换行方式。进行任何字体更改或替换后，请重新检查幻灯片。