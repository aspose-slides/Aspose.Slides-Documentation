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
- 圖形超連結
- 圖片超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，輕鬆在 PowerPoint 與 OpenDocument 簡報中管理超連結──在數分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是對某個物件、資料或某處的參考。以下是 PowerPoint 簡報中常見的超連結：

* 文字、圖形或媒體中的網站連結
* 投影片連結

Aspose.Slides for .NET 允許您在簡報中執行許多與超連結相關的任務。

{{% alert color="primary" %}} 

您可能想要看看 Aspose 簡易的[免費線上 PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)

{{% /alert %}} 

## **新增 URL 超連結**

### **將 URL 超連結新增至文字**

以下 C# 程式碼示範如何將網站超連結新增至文字：

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

### **將 URL 超連結新增至圖形或框架**

以下 C# 範例程式碼示範如何將網站超連結新增至圖形：

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **將 URL 超連結新增至媒體**

Aspose.Slides 允許您為圖片、音訊和視訊檔案新增超連結。 

以下範例程式碼示範如何為**圖片**新增超連結：

```c#
using (Presentation pres = new Presentation())
{
    // 將影像加入簡報
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // 根據先前加入的影像在投影片 1 上建立圖片框
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

以下範例程式碼示範如何為**音訊檔案**新增超連結：

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

以下範例程式碼示範如何為**視訊**新增超連結：

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

{{%  alert  title="Tip"  color="primary"  %}} 

您可能想看看 *[管理 OLE](https://docs.aspose.com/slides/zh-hant/net/manage-ole/)*。

{{% /alert %}}


## **使用超連結建立目錄**

由於超連結可讓您加入對物件或位置的參考，您可以使用它們建立目錄。 

以下範例程式碼示範如何使用超連結建立目錄：

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

## **格式化超連結**

### **顏色**

使用介面 [IHyperlink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink) 中的 [ColorSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/colorsource) 屬性，您可以設定超連結的顏色，亦可取得超連結的顏色資訊。此功能首次於 PowerPoint 2019 引入，因此屬性相關的變更不適用於較舊的 PowerPoint 版本。

以下範例程式碼示範在同一投影片中新增不同顏色的超連結的操作：

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
### **音效**

Aspose.Slides 提供以下屬性，讓您以音效強調超連結：

- [IHyperlink.Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **新增超連結音效**

以下 C# 程式碼示範如何設定在點擊時播放音效的超連結，並以另一個超連結停止音效：

```c#
using (Presentation pres = new Presentation())
{
	// 將新音訊加入簡報的音訊集合
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 新增具有前往下一張投影片超連結的圖形
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// 檢查超連結是否為「無音效」
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 設定會播放音效的超連結
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 新增空白投影片 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// 新增具有 NoAction 超連結的圖形
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// 設定超連結「停止先前音效」旗標
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **擷取超連結音效**

以下 C# 程式碼示範如何擷取超連結使用的音效：

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 取得第一個圖形的超連結
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// 以位元組陣列擷取超連結音效
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **從簡報中移除超連結**

### **從文字中移除超連結**

以下 C# 程式碼示範如何從簡報投影片的文字中移除超連結：

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

### **從圖形或框架中移除超連結**

以下 C# 程式碼示範如何從簡報投影片的圖形中移除超連結： 

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

## **可變的 Hyperlink**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/hyperlink) 類別是可變的。使用此類別，您可以變更以下屬性的值：

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlink/properties/highlightclick)

以下程式碼片段示範如何在投影片中新增超連結，並稍後編輯其工具提示：

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

## **IHyperlinkQueries 中支援的屬性**

您可以從簡報、投影片或定義了超連結的文字取得 IHyperlinkQueries。

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/properties/hyperlinkqueries)

[IHyperlinkQueries] 類別支援以下方法與屬性：

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **常見問題**

**如何在簡報中建立不僅指向投影片，而是指向「節」或該節的第一張投影片的內部導覽？**

PowerPoint 中的節是投影片的分組；導覽在技術上仍指向特定的投影片。若要「導覽至節」，通常會連結到該節的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上均可使用嗎？**

可以。母片與版面配置元素支援超連結。此類連結會出現在子投影片上，並在簡報放映時可點擊。

**在匯出為 PDF、HTML、影像或影片時，超連結會被保留嗎？**

在 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/net/convert-powerpoint-to-html/) 中，會保留連結；在匯出為 [影像](/slides/zh-hant/net/convert-powerpoint-to-png/) 與 [影片](/slides/zh-hant/net/convert-powerpoint-to-video/) 時，因為這些格式本質上是點陣框格/影片，不支援超連結，點擊功能將不會保留。