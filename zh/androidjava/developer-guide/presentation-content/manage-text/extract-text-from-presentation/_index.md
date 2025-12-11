---
title: Android 上演示文稿的高级文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/androidjava/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 快速从 PowerPoint 和 OpenDocument 演示文稿中提取文本。遵循我们的简明分步指南，节省时间。"
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不罕见。为此，您需要从演示文稿中所有幻灯片的所有形状中提取文本。本文介绍了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。 

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for Android via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) 类。该类公开了一系列用于从演示文稿或幻灯片中提取全部文本的重载静态方法。要从 PPTX 演示文稿中的幻灯片提取文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) 类公开的 [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 重载静态方法。此方法接受 Slide 对象作为参数。  
执行后，Slide 方法会扫描作为参数传入的幻灯片中的全部文本，并返回一个 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 对象数组。这意味着可以获取与文本关联的所有文本格式信息。下面的代码示例提取了演示文稿第一张幻灯片上的全部文本：
```java
//实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //获取 PPTX 中所有幻灯片的 ITextFrame 对象数组
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //遍历 TextFrame 数组
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //遍历当前 ITextFrame 中的段落
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //遍历当前 IParagraph 中的文本片段
                for (IPortion port : para.getPortions()) {
                    //显示当前片段的文本
                    System.out.println(port.getText());

                    //显示文本的字体高度
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //显示文本的字体名称
                    if (port.getPortionFormat().getLatinFont() != null)
                        System.out.println(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **从演示文稿中提取文本**
要扫描整个演示文稿的文本，请使用 SlideUtil 类公开的 [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) 静态方法。它接受两个参数：

1. 首先，一个表示要提取文本的演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) 对象。  
1. 其次，一个布尔值，用于决定在扫描演示文稿文本时是否包括母版幻灯片。  
   该方法返回一个包含文本格式信息的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 对象数组。下面的代码扫描了演示文稿（包括母版幻灯片）的文本及其格式信息。  
```java
//实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation("demo.pptx");
try {
    //获取 PPTX 中所有幻灯片的 ITextFrame 对象数组
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //遍历 TextFrame 数组
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //遍历当前 ITextFrame 中的段落
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //遍历当前 IParagraph 中的文本片段
            for (IPortion port : para.getPortions())
            {
                //显示当前片段的文本
                System.out.println(port.getText());

                //显示文本的字体高度
                System.out.println(port.getPortionFormat().getFontHeight());

                //显示文本的字体名称
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **分类与快速文本提取**
Presentation 类已添加新的静态方法 getPresentationText。该方法有三个重载版本：
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) interface.

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **常见问题**

**Aspose.Slides 在文本提取过程中处理大型演示文稿的速度有多快？**

Aspose.Slides 经过高性能优化，能够高效处理甚至是 [large presentations](/slides/zh/androidjava/open-presentation/)（大型演示文稿），因此适用于实时或批量处理场景。  

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

是的，Aspose.Slides 完全支持从表格、图表及其他复杂幻灯片元素中提取文本，帮助您轻松访问和分析所有文本内容。  

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版进行文本提取，但其会有一些限制，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大型的演示文稿，建议购买正式许可证。