---
title: .NET에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/net/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 생성
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 하이퍼링크를 손쉽게 관리하고, 몇 분 만에 인터랙티브 기능과 워크플로우를 향상시킵니다."
---
## **소개**

하이퍼링크는 객체나 데이터, 혹은 어떤 위치에 대한 참조입니다. 다음은 PowerPoint 프레젠테이션에서 흔히 사용되는 하이퍼링크입니다:

* 텍스트, 도형 또는 미디어 안의 웹사이트 링크
* 슬라이드 링크

Aspose.Slides for .NET을 사용하면 프레젠테이션에서 하이퍼링크와 관련된 다양한 작업을 수행할 수 있습니다. 

{{% alert color="primary" %}} 
Aspose 간단한 무료 온라인 PowerPoint 편집기를 확인해 보세요, [free online PowerPoint editor.](https://products.aspose.app/slides/ko/editor)
{{% /alert %}} 

## **URL 하이퍼링크 추가**

### **텍스트에 URL 하이퍼링크 추가**

이 C# 코드는 텍스트에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

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

### **도형 또는 프레임에 URL 하이퍼링크 추가**

이 C# 샘플 코드는 도형에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **미디어에 URL 하이퍼링크 추가**

Aspose.Slides를 사용하면 이미지, 오디오 및 비디오 파일에 하이퍼링크를 추가할 수 있습니다. 

이 샘플 코드는 **이미지**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
    // 프레젠테이션에 이미지 추가
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // 이전에 추가된 이미지를 기반으로 슬라이드 1에 그림 프레임 생성
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

이 샘플 코드는 **오디오 파일**에 하이퍼링크를 추가하는 방법을 보여줍니다:

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

이 샘플 코드는 **비디오**에 하이퍼링크를 추가하는 방법을 보여줍니다:

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

{{% alert title="팁" color="primary" %}} 
다음 항목을 확인해 보세요 *[Manage OLE](https://docs.aspose.com/slides/ko/net/manage-ole/)*.
{{% /alert %}}

## **목차 생성을 위해 하이퍼링크 사용**

하이퍼링크는 객체나 위치에 대한 참조를 추가할 수 있으므로 목차를 만드는 데 사용할 수 있습니다. 

이 샘플 코드는 하이퍼링크가 포함된 목차를 만드는 방법을 보여줍니다:

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

## **하이퍼링크 서식 지정**

### **색상**

[IHyperlink](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink) 인터페이스의 [ColorSource](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink/properties/colorsource) 속성을 사용하면 하이퍼링크 색상을 설정하고 색상 정보를 가져올 수 있습니다. 이 기능은 PowerPoint 2019에 처음 도입되었으며, 속성과 관련된 변경 사항은 이전 PowerPoint 버전에는 적용되지 않습니다.

다음 샘플 코드는 동일한 슬라이드에 서로 다른 색상의 하이퍼링크가 추가된 예를 보여줍니다:

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

### **소리**

Aspose.Slides는 하이퍼링크에 소리를 부여할 수 있는 다음 속성을 제공합니다:
- [IHyperlink.Sound](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **하이퍼링크 소리 추가**

이 C# 코드는 소리를 재생하는 하이퍼링크를 설정하고 다른 하이퍼링크로 중지하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
	// 프레젠테이션 오디오 컬렉션에 새 오디오를 추가합니다
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 다음 슬라이드로 이동하는 하이퍼링크가 있는 새 도형을 추가합니다
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// 하이퍼링크가 "소리 없음"인지 확인합니다
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// 소리를 재생하는 하이퍼링크를 설정합니다
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// 빈 슬라이드를 추가합니다 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// NoAction 하이퍼링크가 있는 새 도형을 추가합니다
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// 하이퍼링크 "이전 소리 중지" 플래그를 설정합니다
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **하이퍼링크 소리 추출**

이 C# 코드는 하이퍼링크에 사용된 소리를 추출하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// 첫 번째 도형의 하이퍼링크를 가져옵니다
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// 하이퍼링크 사운드를 바이트 배열로 추출합니다
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **프레젠테이션에서 하이퍼링크 제거**

### **텍스트에서 하이퍼링크 제거**

이 C# 코드는 프레젠테이션 슬라이드의 텍스트에서 하이퍼링크를 제거하는 방법을 보여줍니다:

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

### **도형 또는 프레임에서 하이퍼링크 제거**

이 C# 코드는 프레젠테이션 슬라이드의 도형에서 하이퍼링크를 제거하는 방법을 보여줍니다: 

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

## **가변 하이퍼링크**

[Hyperlink](https://reference.aspose.com/slides/ko/net/aspose.slides/hyperlink) 클래스는 가변입니다. 이 클래스를 사용하면 다음 속성의 값을 변경할 수 있습니다:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlink/properties/highlightclick)

다음 코드 조각은 슬라이드에 하이퍼링크를 추가하고 이후에 툴팁을 편집하는 방법을 보여줍니다:

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

## **IHyperlinkQueries에서 지원되는 속성**

프레젠테이션, 슬라이드 또는 하이퍼링크가 정의된 텍스트에서 IHyperlinkQueries에 접근할 수 있습니다. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries 클래스는 다음 메서드와 속성을 지원합니다: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**슬라이드뿐만 아니라 "섹션"이나 섹션의 첫 번째 슬라이드로 이동하는 내부 탐색을 만들려면 어떻게 해야 하나요?**

PowerPoint에서 섹션은 슬라이드의 그룹이며, 탐색은 기술적으로 특정 슬라이드를 목표로 합니다. "섹션으로 이동"하려면 일반적으로 해당 섹션의 첫 번째 슬라이드에 링크를 연결합니다.

**마스터 슬라이드 요소에 하이퍼링크를 연결하면 모든 슬라이드에서 작동하게 할 수 있나요?**

예. 마스터 슬라이드 및 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 링크는 하위 슬라이드에 표시되며 슬라이드 쇼 중에 클릭할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지되나요?**

[PDF](/slides/ko/net/convert-powerpoint-to-pdf/)와 [HTML](/slides/ko/net/convert-powerpoint-to-html/)에서는 링크가 일반적으로 유지됩니다. [images](/slides/ko/net/convert-powerpoint-to-png/)와 [video](/slides/ko/net/convert-powerpoint-to-video/)로 내보낼 경우, 해당 포맷이 래스터 프레임/비디오이기 때문에 클릭 가능성이 유지되지 않습니다.