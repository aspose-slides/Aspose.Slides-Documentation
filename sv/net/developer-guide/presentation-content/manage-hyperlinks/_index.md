---
title: Hantera presentationshyperlänkar i .NET
linktitle: Hantera hyperlänk
type: docs
weight: 20
url: /sv/net/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildhyperlänk
- videohyperlänk
- muterbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET på ett enkelt sätt—förbättra interaktivitet och arbetsflöde på några minuter."
---
## **Introduktion**

En hyperlänk är en referens till ett objekt eller data eller en plats i något. Detta är vanliga hyperlänkar i PowerPoint-presentationer:

* Länkar till webbplatser i texter, former eller media
* Länkar till bilder

Aspose.Slides för .NET låter dig utföra många uppgifter som rör hyperlänkar i presentationer. 

{{% alert color="primary" %}} 

Du kanske vill kolla in Aspose simple, [gratis online PowerPoint‑redigerare.](https://products.aspose.app/slides/sv/editor)

{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

### **Lägg till URL‑hyperlänkar till text**

Den här C#‑koden visar hur du lägger till en webbplats‑hyperlänk i en text:

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

### **Lägg till URL‑hyperlänkar till former eller ramar**

Det här exempelprogrammet i C# visar hur du lägger till en webbplats‑hyperlänk till en form:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Lägg till URL‑hyperlänkar till media**

Aspose.Slides låter dig lägga till hyperlänkar till bilder, ljud‑ och videofiler. 

Det här exempelprogrammet visar hur du lägger till en hyperlänk till en **bild**:

```c#
using (Presentation pres = new Presentation())
{
    // Lägger till bild i presentationen
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Skapar bildram på bild 1 baserat på tidigare tillagd bild
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Det här exempelprogrammet visar hur du lägger till en hyperlänk till en **ljudfil**:

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

Det här exempelprogrammet visar hur du lägger till en hyperlänk till en **video**:

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

Du kanske vill se *[Hantera OLE](https://docs.aspose.com/slides/sv/net/manage-ole/)*.

{{% /alert %}}


## **Använd hyperlänkar för att skapa en innehållsförteckning**

Eftersom hyperlänkar låter dig lägga till referenser till objekt eller platser kan du använda dem för att skapa en innehållsförteckning. 

Det här exempelprogrammet visar hur du skapar en innehållsförteckning med hyperlänkar:

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

## **Formatera hyperlänkar**

### **Färg**

Med egenskapen [ColorSource](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink/properties/colorsource) i gränssnittet [IHyperlink](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink) kan du ange färgen för hyperlänkar och även hämta färginformation från hyperlänkar. Funktionen introducerades först i PowerPoint 2019, så ändringar som rör egenskapen gäller inte äldre PowerPoint‑versioner.

Det här exempelprogrammet visar en operation där hyperlänkar med olika färger lades till på samma bild:

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
### **Ljud**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig betona en hyperlänk med ljud:
- [IHyperlink.Sound](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Lägg till ett hyperlänksljud**

Den här C#‑koden visar hur du ställer in hyperlänken som spelar ett ljud och stoppar det med en annan hyperlänk:

```c#
using (Presentation pres = new Presentation())
{
	// Lägger till ny ljudfil i presentationens ljudsamling
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Lägger till ny form med hyperlänken till nästa bild
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Kontrollerar hyperlänken för "Inget ljud"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Ställer in hyperlänken som spelar upp ljud
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Lägger till den tomma bilden 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Lägger till ny form med NoAction-hyperlänken
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Ställer in hyperlänkens flagga "Stoppa tidigare ljud"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Extrahera ett hyperlänksljud**

Den här C#‑koden visar hur du extraherar ljudet som används i en hyperlänk:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Hämtar den första formens hyperlänk
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extraherar hyperlänkens ljud i en bytearray
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Ta bort hyperlänkar från presentationer**

### **Ta bort hyperlänkar från text**

Den här C#‑koden visar hur du tar bort hyperlänken från en text i en presentationsbild:

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

### **Ta bort hyperlänkar från former eller ramar**

Den här C#‑koden visar hur du tar bort hyperlänken från en form i en presentationsbild: 

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

## **Muterbar hyperlänk**

Klassen [Hyperlink](https://reference.aspose.com/slides/sv/net/aspose.slides/hyperlink) är muterbar. Med den här klassen kan du ändra värdena för dessa egenskaper:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlink/properties/highlightclick)

Kodsnutten visar hur du lägger till en hyperlänk på en bild och redigerar dess verktygstips senare:

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

## **Stödda egenskaper i IHyperlinkQueries**

Du kan komma åt IHyperlinkQueries från en presentation, bild eller text där hyperlänken är definierad. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Klassen IHyperlinkQueries stöder dessa metoder och egenskaper: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/sv/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**Hur kan jag skapa intern navigation inte bara till en bild, utan till ett "avsnitt" eller den första bilden i ett avsnitt?**

Avsnitt i PowerPoint är grupperingar av bilder; navigationen riktar sig tekniskt sett till en specifik bild. För att "navigera till ett avsnitt" länkar du vanligtvis till dess första bild.

**Kan jag fästa en hyperlänk till master‑bildens element så att den fungerar på alla bilder?**

Ja. Master‑bildens och layout‑element stödjer hyperlänkar. Sådana länkar visas på underordnade bilder och är klickbara under bildspelet.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

I [PDF](/slides/sv/net/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/net/convert-powerpoint-to-html/) ja—länkar bevaras vanligtvis. Vid export till [bilder](/slides/sv/net/convert-powerpoint-to-png/) och [video](/slides/sv/net/convert-powerpoint-to-video/) kommer klickbarhet inte att överföras på grund av formatens natur (raster‑ramar/video stöder inte hyperlänkar).