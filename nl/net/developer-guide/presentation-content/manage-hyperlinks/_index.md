---
title: Beheer presentatie-hyperlinks in .NET
linktitle: Beheer hyperlink
type: docs
weight: 20
url: /nl/net/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst-hyperlink
- dia-hyperlink
- vorm-hyperlink
- afbeeldings-hyperlink
- video-hyperlink
- mutabele hyperlink
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer hyperlinks in PowerPoint-en OpenDocument-presentaties moeiteloos met Aspose.Slides voor .NET—verbeter interactiviteit en workflow in enkele minuten."
---
## **Inleiding**

Een hyperlink is een verwijzing naar een object, gegevens of een locatie in iets. Dit zijn veelvoorkomende hyperlinks in PowerPoint‑presentaties:

* Links naar websites in tekst, vormen of media
* Links naar dia's

Aspose.Slides voor .NET stelt u in staat om vele taken met betrekking tot hyperlinks in presentaties uit te voeren.

{{% alert color="primary" %}} 
U wilt misschien Aspose Simple, [gratis online PowerPoint‑editor.](https://products.aspose.app/slides/nl/editor)
{{% /alert %}} 

## **URL-hyperlinks toevoegen**

### **URL-hyperlinks toevoegen aan tekst**

Deze C#‑code laat zien hoe u een website‑hyperlink aan een tekst toevoegt:
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

### **URL-hyperlinks toevoegen aan vormen of frames**

Deze voorbeeldcode in C# laat zien hoe u een website‑hyperlink aan een vorm toevoegt:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **URL-hyperlinks toevoegen aan media**

Aspose.Slides stelt u in staat hyperlinks toe te voegen aan afbeeldingen, audio‑ en videobestanden. 

Deze voorbeeldcode laat zien hoe u een hyperlink aan een **afbeelding** toevoegt:
```c#
using (Presentation pres = new Presentation())
{
    // Voegt afbeelding toe aan presentatie
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Maakt een afbeeldingframe op dia 1 op basis van de eerder toegevoegde afbeelding
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Deze voorbeeldcode laat zien hoe u een hyperlink aan een **audiobestand** toevoegt:
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

Deze voorbeeldcode laat zien hoe u een hyperlink aan een **video** toevoegt:
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
U wilt misschien *[OLE beheren](https://docs.aspose.com/slides/nl/net/manage-ole/)*.
{{% /alert %}}

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Aangezien hyperlinks u toestaan verwijzingen naar objecten of locaties toe te voegen, kunt u ze gebruiken om een inhoudsopgave te maken. 

Deze voorbeeldcode laat zien hoe u een inhoudsopgave met hyperlinks maakt:
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

## **Hyperlinks opmaken**

### **Kleur**

Met de eigenschap [ColorSource](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/properties/colorsource) in de interface [IHyperlink](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink) kunt u de kleur voor hyperlinks instellen en ook kleurinformatie van hyperlinks ophalen. De functie werd voor het eerst geïntroduceerd in PowerPoint 2019, dus wijzigingen met betrekking tot deze eigenschap gelden niet voor oudere PowerPoint‑versies.

Deze voorbeeldcode toont een bewerking waarbij hyperlinks met verschillende kleuren aan dezelfde dia werden toegevoegd:
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

### **Geluid**

Aspose.Slides biedt de volgende eigenschappen om een hyperlink te benadrukken met een geluid:
- [IHyperlink.Sound](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Een hyperlinkgeluid toevoegen**

Deze C#‑code laat zien hoe u een hyperlink instelt die een geluid afspeelt en stopt met een andere hyperlink:
```c#
using (Presentation pres = new Presentation())
{
	// Voegt nieuwe audio toe aan de audio-collectie van de presentatie
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Voegt een nieuwe vorm toe met een hyperlink naar de volgende dia
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Controleert de hyperlink op "Geen geluid"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Stelt de hyperlink in die geluid afspeelt
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Voegt een lege dia toe 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Voegt een nieuwe vorm toe met de NoAction-hyperlink
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Stelt de hyperlink‑vlag "Stop eerder geluid" in
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Een hyperlinkgeluid extraheren**

Deze C#‑code laat zien hoe u het geluid dat in een hyperlink wordt gebruikt, kunt extraheren:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Verkrijgt de hyperlink van de eerste vorm
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extraheert het hyperlinkgeluid als byte-array
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Hyperlinks uit presentaties verwijderen**

### **Hyperlinks uit tekst verwijderen**

Deze C#‑code laat zien hoe u de hyperlink uit een tekst in een presentatiedia verwijdert:
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

### **Hyperlinks uit vormen of frames verwijderen**

Deze C#‑code laat zien hoe u de hyperlink uit een vorm in een presentatiedia verwijdert: 
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

## **Mutabele hyperlink**

De klasse [Hyperlink](https://reference.aspose.com/slides/nl/net/aspose.slides/hyperlink) is mutabel. Met deze klasse kunt u de waarden van de volgende eigenschappen wijzigen:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/properties/highlightclick)

Het codefragment toont hoe u een hyperlink aan een dia toevoegt en later de tooltip bewerkt:
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

## **Ondersteunde eigenschappen in IHyperlinkQueries**

U kunt IHyperlinkQueries benaderen vanuit een presentatie, dia of tekst waarvoor de hyperlink is gedefinieerd. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/properties/hyperlinkqueries)

De IHyperlinkQueries‑klasse ondersteunt de volgende methoden en eigenschappen: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**Hoe kan ik interne navigatie creëren, niet alleen naar een dia, maar naar een "sectie" of de eerste dia van een sectie?**

Secties in PowerPoint zijn groeperingen van dia's; navigatie richt zich technisch op een specifieke dia. Om "naar een sectie te navigeren" linkt u doorgaans naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de masterslide koppelen zodat deze op alle dia's werkt?**

Ja. Elementen van de masterslide en lay‑out ondersteunen hyperlinks. Dergelijke koppelingen verschijnen op onderliggende dia's en zijn klikbaar tijdens de diavoorstelling.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

In [PDF](/slides/nl/net/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/net/convert-powerpoint-to-html/) ja—koppelingen worden over het algemeen behouden. Bij export naar [afbeeldingen](/slides/nl/net/convert-powerpoint-to-png/) en [video](/slides/nl/net/convert-powerpoint-to-video/) blijft de klikbaarheid niet behouden vanwege de aard van die formaten (raster‑frames/video ondersteunen geen hyperlinks).