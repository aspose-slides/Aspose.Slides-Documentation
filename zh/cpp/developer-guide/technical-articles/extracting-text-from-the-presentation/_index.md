---
title: 从演示文稿中提取文本
type: docs
weight: 60
url: /zh/cpp/extracting-text-from-the-presentation/
keywords:
- 提取文本
- 检索文本
- 幻灯片
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中从幻灯片或整个演示文稿中提取文本，并以编程方式处理 PPT、PPTX 和 ODP 内容。"
---

{{% alert color="primary" %}} 

开发者需要从演示文稿中提取文本并不罕见。为此，您需要从演示文稿中所有幻灯片的所有形状中提取文本。本文介绍如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。文本可以通过以下方式提取：

[从单个幻灯片提取文本](/slides/zh/cpp/extracting-text-from-the-presentation/)
[使用 GetAllTextBoxes 方法提取文本](/slides/zh/cpp/extracting-text-from-the-presentation/)
[分类且快速的文本提取](/slides/zh/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **从幻灯片提取文本**
Aspose.Slides for C++ 提供了 Aspose.Slides.Util 命名空间，其中包含 PresentationScanner 类。该类提供了多个重载的静态方法，用于从演示文稿或幻灯片中提取完整文本。要从 PPTX 演示文稿的幻灯片中提取文本，请使用 PresentationScanner 类公开的 [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/) 重载静态方法。此方法接受 Slide 对象作为参数。  
执行时，Slide 方法会扫描传入参数的幻灯片中的全部文本，并返回一个 TextFrame 对象数组。这意味着可以获取与文本关联的任何格式信息。下面的代码片段提取演示文稿第一张幻灯片上的所有文本：

**C#**
``` cpp

 //实例化表示 PPTX 文件的 PresentationEx 类

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//获取第一张幻灯片上的 TextFrameEx 对象数组

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//遍历 TextFrame 数组

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //遍历当前 TextFrame 中的段落

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //遍历当前段落中的文本片段

        foreach (Portion port in para.Portions)

        {

            //显示当前片段的文本

            Console.WriteLine(port.Text);

            //显示文本的字体高度

            Console.WriteLine(port.PortionFormat.FontHeight);

            //显示文本的字体名称

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **从整个演示文稿提取文本**
要扫描整个演示文稿的文本，请使用 PresentationScanner 类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) 静态方法。它接受两个参数：

1. 首先，表示要提取文本的 PPTX 演示文稿的 Presentation 对象。  
2. 其次，一个布尔值，用于决定在扫描演示文稿文本时是否包含母版幻灯片。  

该方法返回一个 TextFrame 对象数组，包含文本格式信息。下面的代码扫描演示文稿的文本及其格式信息，包括母版幻灯片。

**C#**
``` cpp

 //实例化表示 PPTX 文件的 Presentation 类

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//从 PPTX 的所有幻灯片获取 ITextFrame 对象数组

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//遍历 TextFrame 数组

for (int i = 0; i < textFramesPPTX.Length; i++)

    //遍历当前 ITextFrame 中的段落

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //遍历当前 IParagraph 中的文本片段

        foreach (IPortion port in para.Portions)

        {

            //显示当前片段的文本

            Console.WriteLine(port.Text);

            //显示文本的字体高度

            Console.WriteLine(port.PortionFormat.FontHeight);

            //显示文本的字体名称

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }


```


## **分类且快速的文本提取**
Presentation 类已添加新的静态方法 GetPresentationText。此方法有两个重载版本：
``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```


ExtractionMode 枚举参数指示组织文本结果输出的模式，可设置为以下值：
Unarranged - 原始文本，不考虑在幻灯片上的位置  
Arranged - 文本按照在幻灯片上的顺序排列  

当速度至关重要时，可使用 Unarranged 模式，它比 Arranged 模式更快。

PresentationText 表示从演示文稿提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 SlidesText 属性，该属性返回 ISlideText 对象数组。每个对象代表相应幻灯片上的文本。ISlideText 对象具有以下属性：

- ISlideText.Text - 幻灯片形状上的文本  
- ISlideText.MasterText - 此幻灯片所在母版页形状上的文本  
- ISlideText.LayoutText - 此幻灯片所在布局页形状上的文本  
- ISlideText.NotesText - 此幻灯片所在备注页形状上的文本  

另外还有实现 ISlideText 接口的 SlideText 类。  

新 API 的使用方式如下：
``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```
