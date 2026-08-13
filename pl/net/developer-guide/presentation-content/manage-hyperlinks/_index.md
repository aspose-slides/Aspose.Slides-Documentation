---
title: Zarządzanie hiperłączami prezentacji w .NET
linktitle: Zarządzaj hiperłączem
type: docs
weight: 20
url: /pl/net/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatuj hiperłącze
- usuń hiperłącze
- zaktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Bezproblemowo zarządzaj hiperłączami w prezentacjach PowerPoint i OpenDocument za pomocą Aspose.Slides dla .NET — zwiększ interaktywność i usprawnij przepływ pracy w kilka minut."
---
## **Wprowadzenie**

Hiperłącze jest odwołaniem do obiektu, danych lub miejsca w czymś. Oto typowe hiperłącza w prezentacjach PowerPoint:

* Odnośniki do witryn internetowych w obrębie tekstów, kształtów lub multimediów
* Odnośniki do slajdów

Aspose.Slides dla .NET umożliwia wykonywanie wielu zadań związanych z hiperłączami w prezentacjach. 

{{% alert color="info" %}} 

Możesz chcieć sprawdzić prosty, [darmowy edytor PowerPoint online.](https://products.aspose.app/slides/pl/editor)

{{% /alert %}} 

## **Dodaj hiperłącza URL**

### **Dodaj hiperłącza URL do tekstu**

Ten kod C# pokazuje, jak dodać hiperłącze do strony internetowej w tekście:

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

### **Dodaj hiperłącza URL do kształtów lub ramek**

Ten przykładowy kod w C# pokazuje, jak dodać hiperłącze do strony internetowej w kształcie:

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

### **Dodaj hiperłącza URL do multimediów**

Aspose.Slides pozwala dodawać hiperłącza do obrazów, plików audio i wideo. 

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **obrazu**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // Dodaje obraz do prezentacji
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Tworzy ramkę obrazu na slajdzie 1 na podstawie wcześniej dodanego obrazu
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **pliku audio**:

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

Ten przykładowy kod pokazuje, jak dodać hiperłącze do **wideo**:

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

Możesz chcieć zobaczyć *[Zarządzanie OLE](https://docs.aspose.com/slides/pl/net/manage-ole/)*.

{{% /alert %}}


## **Użyj hiperłączy do stworzenia spisu treści**

Ponieważ hiperłącza pozwalają dodawać odwołania do obiektów lub miejsc, możesz ich używać do tworzenia spisu treści. 

Ten przykładowy kod pokazuje, jak stworzyć spis treści z hiperłączami:

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

## **Formatuj hiperłącza**

### **Kolor**

Za pomocą właściwości [ColorSource](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink/properties/colorsource) w interfejsie [IHyperlink](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink) możesz ustawić kolor dla hiperłączy oraz pobrać informacje o kolorze z hiperłączy. Funkcja została wprowadzona po raz pierwszy w PowerPoint 2019, więc zmiany dotyczące tej właściwości nie mają zastosowania w starszych wersjach PowerPoint.

Ten przykładowy kod demonstruje operację, w której do tego samego slajdu dodano hiperłącza o różnych kolorach:

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
### **Dźwięk**

Aspose.Slides udostępnia następujące właściwości, które pozwalają podkreślić hiperłącze dźwiękiem:
- [IHyperlink.Sound](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Dodaj dźwięk do hiperłącza**

Ten kod C# pokazuje, jak ustawić hiperłącze odtwarzające dźwięk i zatrzymać je innym hiperłączem:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Dodaje nowy dźwięk do kolekcji audio prezentacji
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Dodaje nowy kształt z hiperłączem do następnego slajdu
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Sprawdza hiperłącze pod kątem "No Sound"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Ustawia hiperłącze, które odtwarza dźwięk
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Dodaje pusty slajd 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Dodaje nowy kształt z hiperłączem NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Ustawia flagę hiperłącza "Stop previous sound"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Wyodrębnij dźwięk z hiperłącza**

Ten kod C# pokazuje, jak wyodrębnić dźwięk użyty w hiperłączu:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Pobiera hiperłącze pierwszego kształtu
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Wyodrębnia dźwięk hiperłącza do tablicy bajtów
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Usuń hiperłącza z prezentacji**

### **Usuń hiperłącza z tekstu**

Ten kod C# pokazuje, jak usunąć hiperłącze z tekstu na slajdzie prezentacji:

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

### **Usuń hiperłącza z kształtów lub ramek**

Ten kod C# pokazuje, jak usunąć hiperłącze z kształtu na slajdzie prezentacji: 

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

## **Modyfikowalne hiperłącze**

Klasa [Hyperlink](https://reference.aspose.com/slides/pl/net/aspose.slides/hyperlink) jest modyfikowalna. Dzięki tej klasie możesz zmienić wartości następujących właściwości:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlink/properties/highlightclick)

Fragment kodu pokazuje, jak dodać hiperłącze do slajdu i później edytować jego podpowiedź:

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

## **Obsługiwane właściwości w IHyperlinkQueries**

Możesz uzyskać dostęp do IHyperlinkQueries z prezentacji, slajdu lub tekstu, dla którego zdefiniowano hiperłącze. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Klasa IHyperlinkQueries obsługuje następujące metody i właściwości: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/pl/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

### Jak mogę stworzyć wewnętrzną nawigację nie tylko do slajdu, ale do „sekcji” lub pierwszego slajdu sekcji?

Sekcje w PowerPoint są grupowaniami slajdów; nawigacja technicznie kieruje się do konkretnego slajdu. Aby „nawigować do sekcji”, zazwyczaj linkuje się do jej pierwszego slajdu.

### Czy mogę dołączyć hiperłącze do elementów slajdu głównego, aby działało na wszystkich slajdach?

Tak. Elementy slajdu głównego i układu obsługują hiperłącza. Takie linki pojawiają się na slajdach podrzędnych i są klikalne podczas pokazu slajdów.

### Czy hiperłącza zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?

W [PDF](/slides/pl/net/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/net/convert-powerpoint-to-html/) tak — linki są zazwyczaj zachowywane. Przy eksporcie do [obrazów](/slides/pl/net/convert-powerpoint-to-png/) i [wideo](/slides/pl/net/convert-powerpoint-to-video/) możliwość klikania nie zostanie przeniesiona ze względu na charakter tych formatów (klatki rastrowe/wideo nie obsługują hiperłączy).