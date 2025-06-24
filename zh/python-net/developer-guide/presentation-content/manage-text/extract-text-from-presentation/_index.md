---
title: 在 Python 中从演示文稿高级提取文本
linktitle: 提取文本
type: docs
weight: 90
url: /zh/python-net/extract-text-from-presentation/
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
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python 快速轻松地从演示文稿中提取文本。按照我们的简单分步指南，节省时间并在应用程序中高效获取幻灯片内容。"
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不罕见。为此，您需要从演示文稿中所有幻灯片的所有形状中提取文本。本文解释了如何使用Aspose.Slides从Microsoft PowerPoint PPTX演示文稿中提取文本。可以通过以下方式提取文本：

- [从一张幻灯片提取文本](/slides/zh/python-net/extracting-text-from-the-presentation/)
- [使用GetAllTextBoxes方法提取文本](/slides/zh/python-net/extracting-text-from-the-presentation/)
- [分类和快速提取文本](/slides/zh/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for Python via .NET提供了Aspose.Slides.Util命名空间，其中包括SlideUtil类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取整个文本。要从PPTX演示文稿中的幻灯片提取文本，请使用SlideUtil类公开的[GetAllTextBoxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)重载静态方法。此方法接受Slide对象作为参数。
执行后，Slide方法扫描作为参数传入的幻灯片的整个文本，并返回一个TextFrame对象数组。这意味着与文本相关的任何文本格式均可用。以下代码从演示文稿的第一张幻灯片中提取所有文本：

```py
import aspose.slides as slides

#实例化表示PPTX文件的Presentation类
with slides.Presentation("pres.pptx") as pptxPresentation:
    # 从PPTX中的所有幻灯片获取ITextFrame对象的数组
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # 遍历TextFrames数组
    for i in range(len(textFramesPPTX)):
	    # 遍历当前ITextFrame中的段落
        for para in textFramesPPTX[i].paragraphs:
            # 遍历当前IParagraph中的部分
            for port in para.portions:
			    # 显示当前部分的文本
                print(port.text)

    			# 显示文本的字体高度
                print(port.portion_format.font_height)

			    # 显示文本的字体名称
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **从演示文稿中提取文本**
要扫描整个演示文稿中的文本，请使用SlideUtil类公开的[GetAllTextFrames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)静态方法。它接受两个参数：

1. 第一个，表示从中提取文本的PPTX演示文稿的Presentation对象。
1. 第二个，一个布尔值，确定在从演示文稿扫描文本时是否包含母版幻灯片。
   该方法返回一个包含文本格式信息的TextFrame对象数组。以下代码扫描演示文稿中的文本和格式信息，包括母版幻灯片。

```py
import aspose.slides as slides

#实例化表示PPTX文件的Presentation类
with slides.Presentation("pres.pptx") as pptxPresentation:
    # 从PPTX中的所有幻灯片获取ITextFrame对象的数组
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # 遍历TextFrames数组
    for i in range(len(textFramesPPTX)):
	    # 遍历当前ITextFrame中的段落
        for para in textFramesPPTX[i].paragraphs:
            # 遍历当前IParagraph中的部分
            for port in para.portions:
			    # 显示当前部分的文本
                print(port.text)

    			# 显示文本的字体高度
                print(port.portion_format.font_height)

			    # 显示文本的字体名称
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **分类和快速文本提取**
在Presentation类中添加了新的静态方法GetPresentationText。该方法有两个重载：

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

ExtractionMode枚举参数指示组织文本结果输出的模式，可以设置为以下值：
Unarranged - 原始文本，不考虑在幻灯片上的位置
Arranged - 该文本按幻灯片上的顺序排列

当速度至关重要时，可以使用Unarranged模式，它比Arranged模式更快。

PresentationText表示从演示文稿中提取的原始文本。它包含Aspose.Slides.Util命名空间中的`slides_text`属性，该属性返回SlideText对象的数组。每个对象代表对应幻灯片上的文本。SlideText对象具有以下属性：

SlideText.text - 幻灯片形状上的文本
SlideText.master_text - 该幻灯片的母版页面形状上的文本
SlideText.layout_text - 该幻灯片的布局页面形状上的文本
SlideText.notes_text - 该幻灯片的注释页面形状上的文本


新的API可以这样使用：

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```