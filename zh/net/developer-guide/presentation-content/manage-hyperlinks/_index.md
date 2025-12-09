---
title: 在 .NET 中管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/net/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 删除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图像超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 轻松管理 PowerPoint 和 OpenDocument 演示文稿中的超链接——在几分钟内提升交互性和工作流。"
---

超链接是对对象、数据或某处位置的引用。这些是在 PowerPoint 演示文稿中常见的超链接：

* 在文本、形状或媒体内部链接到网站
* 链接到幻灯片

Aspose.Slides for .NET 允许您在演示文稿中执行许多涉及超链接的任务。 

{{% alert color="primary" %}} 
您可能想了解 Aspose 简单的，免费在线 PowerPoint 编辑器。[免费在线 PowerPoint 编辑器](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **添加 URL 超链接**

### **向文本添加 URL 超链接**

下面的 C# 代码演示了如何向文本添加网站超链接：
```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


### **向形状或框架添加 URL 超链接**

下面的 C# 示例代码演示了如何向形状添加网站超链接：
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **向媒体添加 URL 超链接**

Aspose.Slides 允许您向图像、音频和视频文件添加超链接。 

下面的示例代码演示了如何向 **图像** 添加超链接：
```c#
using (Presentation pres = new Presentation())
{
    // 向演示文稿添加图像
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // 在第 1 张幻灯片上基于先前添加的图像创建图片框
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


下面的示例代码演示了如何向 **音频文件** 添加超链接：
```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


下面的示例代码演示了如何向 **视频** 添加超链接：
``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


{{%  alert  title="提示"  color="primary"  %}} 
您可能想了解 *[管理 OLE](https://docs.aspose.com/slides/net/manage-ole/)*。
{{% /alert %}}

## **使用超链接创建目录**

由于超链接允许您添加对对象或位置的引用，您可以利用它们创建目录。 

下面的示例代码演示了如何使用超链接创建目录：
```c#
using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```


## **格式化超链接**

### **颜色**

使用 [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink) 接口中的 [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) 属性，您可以设置超链接的颜色，也可以从超链接获取颜色信息。此功能首次在 PowerPoint 2019 中引入，因此对该属性的更改不适用于旧版 PowerPoint。 

下面的示例代码演示了在同一幻灯片中添加不同颜色的超链接的操作：
```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```


### **声音**

Aspose.Slides 提供以下属性，以便您通过声音强调超链接：

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **添加超链接声音**

下面的 C# 代码演示了如何设置播放声音的超链接，并通过另一个超链接停止它：
```c#
using (Presentation pres = new Presentation())
{
	// 添加新的音频到演示文稿的音频集合
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 添加带有超链接指向下一张幻灯片的新形状
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// 检查超链接是否为“无声音”
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 设置播放声音的超链接
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 添加空白幻灯片
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// 添加带有 NoAction 超链接的新形状
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// 设置“停止之前声音”标志
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **提取超链接声音**

下面的 C# 代码演示了如何提取超链接中使用的声音：
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 获取第一个形状的超链接
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// 将超链接声音提取为字节数组
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **删除演示文稿中的超链接**

### **从文本中删除超链接**

下面的 C# 代码演示了如何从演示文稿幻灯片中的文本删除超链接：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```


### **从形状或框架中删除超链接**

下面的 C# 代码演示了如何从演示文稿幻灯片中的形状删除超链接：
``` csharp
using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```


## **可变超链接**

[Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) 类是可变的。使用此类，您可以更改以下属性的值：

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

下面的代码片段演示了如何向幻灯片添加超链接并随后编辑其工具提示：
```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **IHyperlinkQueries 支持的属性**

您可以从定义了超链接的演示文稿、幻灯片或文本访问 IHyperlinkQueries。 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries 类支持以下方法和属性： 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **常见问题**

**如何创建不仅跳转到幻灯片，还能跳转到“章节”或章节的第一张幻灯片的内部导航？**

PowerPoint 中的章节是幻灯片的分组；导航本质上指向特定的幻灯片。要 “导航到章节”，通常需要链接到该章节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素上，使其在所有幻灯片上工作吗？**

可以。母版幻灯片和布局元素支持超链接。这些链接会出现在子幻灯片上，并在放映过程中可点击。

**导出为 PDF、HTML、图像或视频时，超链接会被保留吗？**

在 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh/net/convert-powerpoint-to-html/) 中，会保留链接。导出为 [图像](/slides/zh/net/convert-powerpoint-to-png/) 和 [视频](/slides/zh/net/convert-powerpoint-to-video/) 时，由于这些格式的特性（光栅帧/视频不支持超链接），链接不可点击。