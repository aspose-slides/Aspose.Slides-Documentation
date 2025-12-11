---
title: 在 Android 上的高级演示文稿文本提取
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
description: "快速使用 Aspose.Slides for Android via Java 从 PowerPoint 和 OpenDocument 演示文稿中提取文本。按照我们的简明一步步指南，节省时间。"
---

{{% alert color="primary" %}} 

开发者需要从演示文稿中提取文本并不罕见。为此，你需要从演示文稿的所有幻灯片的所有形状中提取文本。本文介绍了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。 

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for Android via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) 类。该类公开了多个重载的静态方法，用于提取演示文稿或幻灯片中的全部文本。要从 PPTX 演示文稿的幻灯片中提取文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) 类公开的 [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 重载静态方法。此方法接受 Slide 对象作为参数。

执行后，Slide 方法会扫描作为参数传入的幻灯片中的全部文本，并返回一个 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 对象数组。这意味着可以获取与文本关联的任何文本格式。以下代码片段提取了演示文稿第一张幻灯片上的所有文本：
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
                //遍历当前 IParagraph 中的文本段
                for (IPortion port : para.getPortions()) {
                    //显示当前文本段的文字
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

1. 首先，一个代表要提取文本的演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) 对象。  
2. 其次，一个布尔值，决定在扫描演示文稿文本时是否包括母版幻灯片。  
   方法返回一个包含文本格式信息的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 对象数组。下面的代码扫描了演示文稿的文本和格式信息，包括母版幻灯片。
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
            //遍历当前 IParagraph 中的文本段
            for (IPortion port : para.getPortions())
            {
                //显示当前文本段的文字
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


## **分类和快速文本提取**
在 Presentation 类中添加了新的静态方法 getPresentationText。此方法有三个重载版本：
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **常见问题**

**Aspose.Slides 在文本提取过程中处理大型演示文稿的速度如何？**

Aspose.Slides 经过高性能优化，能够高效处理即使是[大型演示文稿](/slides/zh/androidjava/open-presentation/)，因此适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

是的，Aspose.Slides 完全支持从表格、图表及其它复杂幻灯片元素中提取文本，使您能够轻松访问和分析所有文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版进行文本提取，但它会有一定限制，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。