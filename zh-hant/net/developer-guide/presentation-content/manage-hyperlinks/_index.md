---
title: 在 .NET 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/net/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 形狀超連結
- 影像超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆管理 PowerPoint 與 OpenDocument 簡報中的超連結——在數分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是對物件、資料或某個位置的參考。以下是在 PowerPoint 簡報中常見的超連結：

* 文字、圖形或媒體內的網站連結
* 投影片連結

Aspose.Slides for .NET 可讓您在簡報中執行許多與超連結相關的工作。

{{% alert color="info" %}} 
您可能想要試用 Aspose 簡易的，[免費線上 PowerPoint 編輯器。](https://products.aspose.app/slides/zh-hant/editor)
{{% /alert %}} 

## **新增 URL 超連結**

### **將 URL 超連結新增至文字**

此 C# 程式碼示範如何將網站超連結新增至文字：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **將 URL 超連結新增至形狀或框架**

此 C# 範例程式碼示範如何將網站超連結新增至形狀：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **將 URL 超連結新增至多媒體**

Aspose.Slides 允許您將超連結新增至影像、音訊與視訊檔案。

此範例程式碼示範如何將超連結新增至**影像**：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // 將影像新增至簡報
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // 在投影片 1 上根據先前新增的影像建立圖片框
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

 此範例程式碼示範如何將超連結新增至**音訊檔**：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

 此範例程式碼示範如何將超連結新增至**視訊**：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 
您可能想查看 *[管理 OLE](https://docs.aspose.com/slides/zh-hant/net/manage-ole/)*。
{{% /alert %}}

## **使用超連結建立目錄**

由於超連結可用於加入對物件或位置的參考，您可以利用它們來建立目錄。

此範例程式碼示範如何使用超連結建立目錄：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **格式化超連結**

### **顏色**

透過 [IHyperlink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink) 介面的 [ColorSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/colorsource) 屬性，您可以設定超連結的顏色，也能取得超連結的顏色資訊。此功能最早於 PowerPoint 2019 引入，因此屬性的變更不會套用到較舊的 PowerPoint 版本。

此範例程式碼示範在同一張投影片上加入不同顏色的超連結：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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
### **聲音**

Aspose.Slides 提供以下屬性，以便您以聲音強調超連結：
- [IHyperlink.Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/sound)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **新增超連結聲音**

此 C# 程式碼示範如何設定會播放聲音的超連結，並以另一個超連結停止播放：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// 將新音訊新增至簡報的音訊集合
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 新增帶有超連結至下一張投影片的形狀
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// 檢查超連結是否為「無聲」
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 設定播放聲音的超連結
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 新增空白投影片 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// 新增帶有 NoAction 超連結的形狀
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// 設定超連結的「停止先前聲音」旗標
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **擷取超連結聲音**

此 C# 程式碼示範如何擷取超連結中使用的聲音：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 取得第一個形狀的超連結
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// 以位元組陣列擷取超連結聲音
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **從簡報中移除超連結**

### **從文字中移除超連結**

此 C# 程式碼示範如何從投影片中的文字移除超連結：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **從形狀或框架中移除超連結**

此 C# 程式碼示範如何從投影片中的形狀移除超連結：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **可變超連結**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/hyperlink) 類別是可變的。透過此類別，您可以變更以下屬性的值：

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/highlightclick)

此程式碼片段示範如何將超連結新增至投影片，並在之後編輯其工具提示：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **IHyperlinkQueries 中支援的屬性**

您可以從簡報、投影片或定義了超連結的文字框取得 IHyperlinkQueries。

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries 類別支援以下方法與屬性：

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

### 如何在內部導覽時不僅指向投影片，而是指向「區段」或區段的第一張投影片？

PowerPoint 中的區段是投影片的分組；導覽實際上仍針對特定投影片。若要「導覽至區段」，通常會連結至該區段的第一張投影片。

### 我可以將超連結附加到母片元素，使其在所有投影片上皆有效嗎？

可以。母片與版面配置元素支援超連結。這些連結會出現在子投影片上，播放簡報時即可點選。

### 匯出為 PDF、HTML、圖片或影片時，超連結會被保留嗎？

在[PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)和[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)中，會保留連結。匯出至[圖片](/slides/zh-hant/net/convert-powerpoint-to-png/)和[影片](/slides/zh-hant/net/convert-powerpoint-to-video/)時，因為這些格式的特性（光柵框架/影片不支援超連結），點擊功能不會被保留。