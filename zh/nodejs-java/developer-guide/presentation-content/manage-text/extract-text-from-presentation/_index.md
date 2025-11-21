---
title: 从演示文稿中提取文本
type: docs
weight: 90
url: /zh/nodejs-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不少见。为此，您需要提取演示文稿中所有幻灯片上所有形状的文本。本文介绍如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。 

{{% /alert %}} 

## **从幻灯片提取文本**

Aspose.Slides for Node.js via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) 类。该类公开了一系列重载的静态方法，用于从演示文稿或幻灯片中提取全部文本。要从 PPTX 演示文稿中的幻灯片提取文本，使用由 [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) 类公开的 [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) 重载静态方法。此方法接受 Slide 对象作为参数。  
执行后，Slide 方法会扫描传入参数的幻灯片中的全部文本，并返回一个 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 对象数组。这意味着可以获取到与文本相关的任何格式信息。以下代码片段提取演示文稿第一张幻灯片上的全部文本：
```javascript
    // 实例化表示 PPTX 文件的 Presentation 类
    var pres = new aspose.slides.Presentation("demo.pptx");
    try {
        for (var s = 0; s < pres.getSlides().size(); s++) {
            let slide = pres.getSlides().get_Item(s);
            // 从 PPTX 中的所有幻灯片获取 ITextFrame 对象数组
            var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
            // 循环遍历 TextFrame 数组
            for (var i = 0; i < textFramesPPTX.length; i++) {
                // 循环遍历当前 ITextFrame 中的段落
                for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                    let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                    // 循环遍历当前 IParagraph 中的部分
                    for (let k = 0; k < para.getPortions().getCount(); k++) {
                        let port = para.getPortions().get_Item(k);
                        // 在当前部分显示文本
                        console.log(port.getText());
                        // 显示文本的字体高度
                        console.log(port.getPortionFormat().getFontHeight());
                        // 显示文本的字体名称
                        if (port.getPortionFormat().getLatinFont() != null) {
                            console.log(port.getPortionFormat().getLatinFont().getFontName());
                        }
                    });
                }
            }
        });
    } finally {
        pres.dispose();
    }
```


## **从演示文稿提取文本**

要扫描整个演示文稿的文本，使用 SlideUtil 类公开的 [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) 静态方法。该方法接受两个参数：

1. 首先，一个代表要提取文本的演示文稿的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) 对象。  
2. 其次，一个布尔值，用于确定在扫描演示文稿文本时是否包含母版幻灯片。  

该方法返回一个 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 对象数组，包含完整的文本格式信息。下面的代码扫描演示文稿（包括母版幻灯片）的文本及其格式信息：
```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // 从 PPTX 中所有幻灯片获取 ITextFrame 对象数组
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // 循环遍历 TextFrame 数组
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // 循环遍历当前 ITextFrame 中的段落
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // 循环遍历当前 IParagraph 中的部分
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // 在当前部分显示文本
                console.log(port.getText());
                // 显示文本的字体高度
                console.log(port.getPortionFormat().getFontHeight());
                // 显示文本的字体名称
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **分类和快速文本提取**

已在 Presentation 类中添加了新的静态方法 getPresentationText。此方法有三个重载版本：
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) objects. Every object represent the text on the corresponding slide. [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) object have the following methods:

- [SlideText.getText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getText--) - The text on the slide's shapes
- [SlideText.getMasterText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getMasterText--) - The text on the master page's shapes for this slide
- [SlideText.getLayoutText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [SlideText.getNotesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class which implements the [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **常见问题**

**在文本提取过程中，Aspose.Slides 处理大型演示文稿的速度如何？**

Aspose.Slides 经过高性能优化，即使是大型演示文稿也能高效处理，适用于实时或批量处理场景。

**Aspose.Slides 能从演示文稿中的表格和图表提取文本吗？**

是的，Aspose.Slides 完全支持从表格、图表以及其他复杂幻灯片元素中提取文本，帮助您轻松访问并分析所有文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版提取文本，但该版本在处理的幻灯片数量上有限制。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。