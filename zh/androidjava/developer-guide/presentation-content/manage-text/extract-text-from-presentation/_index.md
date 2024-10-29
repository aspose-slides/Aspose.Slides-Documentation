---
title: 从演示文稿中提取文本
type: docs
weight: 90
url: /zh/androidjava/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

开发者需要从演示文稿中提取文本并不罕见。为此，您需要从演示文稿中所有幻灯片的所有形状中提取文本。本文解释了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for Android 通过 Java 提供了 [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) 类。该类公开了一组重载的静态方法，用于从演示文稿或幻灯片中提取全部文本。要从 PPTX 演示文稿中的幻灯片提取文本，请使用 [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) 类中公开的 [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 重载静态方法。该方法接受幻灯片对象作为参数。
执行后，幻灯片方法会扫描作为参数传递的幻灯片中的全部文本，并返回一个 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 对象数组。这意味着与文本相关的任何文本格式信息均可用。以下代码片段提取演示文稿中的第一张幻灯片上的所有文本：

```java
//实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //从 PPTX 中获取 ITextFrame 对象的数组
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //循环遍历 TextFrames 数组
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //循环遍历当前 ITextFrame 中的段落
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //循环遍历当前 IParagraph 中的部分
                for (IPortion port : para.getPortions()) {
                    //显示当前部分的文本
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
要扫描整个演示文稿中的文本，请使用 SlideUtil 类中公开的 [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) 静态方法。它接受两个参数：

1. 首先，一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) 对象，表示从中提取文本的演示文稿。
2. 其次，一个布尔值，确定在从演示文稿中扫描文本时是否包含母版幻灯片。
该方法返回一个具有文本格式信息的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 对象数组。下面的代码从演示文稿中扫描文本和格式信息，包括母版幻灯片。

```java
//实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation("demo.pptx");
try {
    //从 PPTX 中获取 ITextFrame 对象的数组
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //循环遍历 TextFrames 数组
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //循环遍历当前 ITextFrame 中的段落
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //循环遍历当前 IParagraph 中的部分
            for (IPortion port : para.getPortions())
            {
                //显示当前部分的文本
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
Presentation 类中新增了静态方法 getPresentationText。该方法有三个重载：

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

[TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) 枚举参数指示组织文本结果输出的模式，可以设置为以下值：
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - 原始文本，不考虑在幻灯片上的位置
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - 文本按幻灯片上的顺序定位

**Unarranged** 模式可以在速度至关重要时使用，它比 Arranged 模式更快。

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) 代表从演示文稿中提取的原始文本。它包含一个 [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) 方法，该方法返回一个 [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) 对象数组。每个对象表示对应幻灯片上的文本。 [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) 对象具有以下方法：

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - 幻灯片形状上的文本
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - 此幻灯片的母版页面形状上的文本
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - 此幻灯片的布局页面形状上的文本
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - 此幻灯片的备注页面形状上的文本

还有一个 [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) 类实现了 [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) 接口。

新的 API 可以这样使用：

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```