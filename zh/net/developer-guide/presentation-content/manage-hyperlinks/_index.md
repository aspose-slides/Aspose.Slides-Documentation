---
title: 管理超链接
type: docs
weight: 20
url: /net/manage-hyperlinks/
keywords: "添加超链接, PowerPoint 演示文稿, PowerPoint 超链接, 文本超链接, 幻灯片超链接, 形状超链接, 图像超链接, 视频超链接, .NET, C#, Csharp"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加超链接"
---

超链接是对某个对象、数据或某个地方的引用。这些是在 PowerPoint 演示文稿中常见的超链接：

* 文本、形状或媒体中的网站链接
* 幻灯片链接

Aspose.Slides for .NET 允许您执行许多与演示文稿中的超链接相关的任务。

{{% alert color="primary" %}} 

您可能想查看 Aspose 简单的 [免费在线 PowerPoint 编辑器。](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **添加 URL 超链接**

### **向文本添加 URL 超链接**

以下 C# 代码演示如何向文本添加网站超链接：

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: 文件格式 API");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "超过 70% 的财富 100 强公司信任 Aspose API";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **向形状或框架添加 URL 超链接**

以下 C# 示例代码演示如何向形状添加网站超链接：

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "超过 70% 的财富 100 强公司信任 Aspose API";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **向媒体添加 URL 超链接**

Aspose.Slides 允许您向图像、音频和视频文件添加超链接。

以下示例代码演示如何向 **图像** 添加超链接：

```c#
using (Presentation pres = new Presentation())
{
    // 向演示文稿添加图像
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // 创建基于先前添加的图像的幻灯片 1 上的图片框
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "超过 70% 的财富 100 强公司信任 Aspose API";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

以下示例代码演示如何向 **音频文件** 添加超链接：

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "超过 70% 的财富 100 强公司信任 Aspose API";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

以下示例代码演示如何向 **视频** 添加超链接：

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "超过 70% 的财富 100 强公司信任 Aspose API";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="提示"  color="primary"  %}} 

您可能想查看 *[管理 OLE](https://docs.aspose.com/slides/net/manage-ole/)*。

{{% /alert %}}


## **使用超链接创建目录**

由于超链接允许您添加对对象或位置的引用，因此您可以使用它们来创建目录。

以下示例代码演示如何创建带有超链接的目录：

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
    paragraph.Text = "幻灯片 2 的标题 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "第 2 页";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **格式化超链接**

### **颜色**

使用 [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) 属性，可以为超链接设置颜色，并从超链接中获取颜色信息。此功能首次在 PowerPoint 2019 中引入，因此涉及该属性的更改不适用于旧版 PowerPoint。

以下示例代码演示了在同一幻灯片中添加不同颜色的超链接的操作：

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("这是彩色超链接的示例。");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("这是普通超链接的示例。");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **声音**

Aspose.Slides 提供这些属性，以强调超链接的声音：
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **添加超链接声音**

以下 C# 代码演示如何设置播放声音的超链接，并通过另一个超链接停止它：

```c#
using (Presentation pres = new Presentation())
{
	// 向演示文稿音频集合添加新音频
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 添加带有超链接的形状到下一个幻灯片
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// 检查超链接的“No Sound”
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 设置播放声音的超链接
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 添加空幻灯片 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// 添加带有 NoAction 超链接的形状
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// 设置超链接“停止上一个声音”标志
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **提取超链接声音**

以下 C# 代码演示如何提取超链接中使用的声音：

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 获取第一个形状超链接
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// 提取超链接声音到字节数组
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **从演示文稿中删除超链接**

### **从文本中删除超链接**

以下 C# 代码演示如何从演示文稿幻灯片中的文本中删除超链接：

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

以下 C# 代码演示如何从演示文稿幻灯片中的形状中删除超链接： 

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

以下代码片段演示如何向幻灯片添加超链接并稍后编辑其工具提示：

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: 文件格式 API");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "超过 70% 的财富 100 强公司信任 Aspose API";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```




## **在 IHyperlinkQueries 中支持的属性**

您可以从演示文稿、幻灯片或定义超链接的文本中访问 IHyperlinkQueries。

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries 类支持以下方法和属性： 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)