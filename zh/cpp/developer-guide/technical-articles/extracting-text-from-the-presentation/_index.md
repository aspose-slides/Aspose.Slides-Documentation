---
title: 从演示文稿中提取文本
type: docs
weight: 60
url: /cpp/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

开发者提取演示文稿中的文本并不罕见。为此，您需要从演示文稿中所有幻灯片的所有形状中提取文本。本文解释了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。可以通过以下方式提取文本：

[从单个幻灯片提取文本](/slides/cpp/extracting-text-from-the-presentation/)
[使用 GetAllTextBoxes 方法提取文本](/slides/cpp/extracting-text-from-the-presentation/)
[分类和快速提取文本](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for C++ 提供了 Aspose.Slides.Util 命名空间，其中包括 PresentationScanner 类。该类提供多个重载的静态方法，用于提取演示文稿或幻灯片中的全部文本。要从 PPTX 演示文稿中的幻灯片提取文本，请使用 PresentationScanner 类提供的 [GetAllTextBoxes](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) 重载静态方法。该方法接受 Slide 对象作为参数。
执行时，Slide 方法会扫描传入的幻灯片的全部文本，并返回一个 TextFrame 对象数组。这意味着与文本相关的任何文本格式信息都可用。以下代码片段提取演示文稿第一张幻灯片上的所有文本：

**C#**

``` cpp

 //实例化表示 PPTX 文件的 PresentationEx 类

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//从第一张幻灯片获取 TextFrameEx 对象数组

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//遍历 TextFrames 数组

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //遍历当前 TextFrame 中的段落

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //遍历当前段落中的部分

        foreach (Portion port in para.Portions)

        {

            //显示当前部分的文本

            Console.WriteLine(port.Text);

            //显示文本的字体高度

            Console.WriteLine(port.PortionFormat.FontHeight);

            //显示文本的字体名称

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **从整个演示文稿中提取文本**
要扫描整个演示文稿中的文本，请使用 PresentationScanner 类提供的 [GetAllTextFrames](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) 静态方法。它接受两个参数：

1. 首先，一个 Presentation 对象，表示要提取文本的 PPTX 演示文稿。
1. 其次，一个 Boolean 值，用于确定在从演示文稿扫描文本时是否包含母版幻灯片。
   该方法返回一个包含文本格式信息的 TextFrame 对象数组。下面的代码从演示文稿中扫描文本和格式信息，包括母版幻灯片。

**C#**

``` cpp

 //实例化表示 PPTX 文件的 Presentation 类

Presentation pptxPresentation = new Presentation(path + "demo.pptx");
//从 PPTX 中的所有幻灯片获取 ITextFrame 对象数组

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//遍历 TextFrames 数组

for (int i = 0; i < textFramesPPTX.Length; i++)

    //遍历当前 ITextFrame 中的段落

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //遍历当前 IParagraph 中的部分

        foreach (IPortion port in para.Portions)

        {

            //显示当前部分的文本

            Console.WriteLine(port.Text);

            //显示文本的字体高度

            Console.WriteLine(port.PortionFormat.FontHeight);

            //显示文本的字体名称

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }


```


## **分类和快速提取文本**
已向 Presentation 类添加了新的静态方法 GetPresentationText。该方法有两个重载：

``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```

ExtractionMode 枚举参数指示组织文本结果的输出模式，可以设置为以下值：
未整理 - 原始文本，不考虑在幻灯片上的位置
整理 - 文本按幻灯片上的顺序排列

当速度至关重要时，可以使用未整理模式，它比整理模式更快。

PresentationText 表示从演示文稿中提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 SlidesText 属性，该属性返回 ISlideText 对象数组。每个对象表示相应幻灯片上的文本。ISlideText 对象具有以下属性：

ISlideText.Text - 幻灯片形状上的文本
ISlideText.MasterText - 该幻灯片母版页面形状上的文本
ISlideText.LayoutText - 该幻灯片布局页面形状上的文本
ISlideText.NotesText - 该幻灯片备注页面形状上的文本

还有一个 SlideText 类实现了 ISlideText 接口。

新的 API 可以这样使用：

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```