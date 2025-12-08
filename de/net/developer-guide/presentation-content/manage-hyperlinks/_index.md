---
title: Hyperlinks verwalten
type: docs
weight: 20
url: /de/net/manage-hyperlinks/
keywords: "Hyperlink hinzufügen, PowerPoint-Präsentation, PowerPoint-Hyperlink, Text-Hyperlink, Folien-Hyperlink, Formen-Hyperlink, Bild-Hyperlink, Video-Hyperlink, .NET, C#, Csharp"
description: "Hyperlink zu einer PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

Ein Hyperlink ist ein Verweis auf ein Objekt oder Daten oder einen Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint‑Präsentationen:

* Verknüpfungen zu Websites in Texten, Formen oder Medien
* Verknüpfungen zu Folien

Aspose.Slides für .NET ermöglicht Ihnen das Ausführen vieler Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen. 

{{% alert color="primary" %}} 

Sie möchten vielleicht Aspose Simple, [kostenlosen Online‑PowerPoint‑Editor.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Hinzufügen von URL‑Hyperlinks**

### **Hinzufügen von URL‑Hyperlinks zu Texten**

Dieser C#‑Code zeigt, wie Sie einem Text einen Website‑Hyperlink hinzufügen:
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


### **Hinzufügen von URL‑Hyperlinks zu Formen oder Rahmen**

Dieser C#‑Beispielcode zeigt, wie Sie einer Form einen Website‑Hyperlink hinzufügen:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **Hinzufügen von URL‑Hyperlinks zu Medien**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bildern, Audio‑ und Videodateien. 

Dieser Beispielcode zeigt, wie Sie einem **Bild** einen Hyperlink hinzufügen:
```c#
using (Presentation pres = new Presentation())
{
    // Fügt Bild zur Präsentation hinzu
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Erstellt Bildrahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


Dieser Beispielcode zeigt, wie Sie einer **Audiodatei** einen Hyperlink hinzufügen:
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


Dieser Beispielcode zeigt, wie Sie einem **Video** einen Hyperlink hinzufügen:
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


{{% alert title="Tipp" color="primary" %}} 

Sie möchten vielleicht *[OLE verwalten](https://docs.aspose.com/slides/net/manage-ole/)* sehen.

{{% /alert %}}

## **Verwendung von Hyperlinks zum Erstellen eines Inhaltsverzeichnisses**

Da Hyperlinks Verweise auf Objekte oder Orte ermöglichen, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden. 

Dieser Beispielcode zeigt, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:
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


## **Formatieren von Hyperlinks**

### **Farbe**

Mit der [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource)‑Eigenschaft im [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink)‑Interface können Sie die Farbe von Hyperlinks festlegen und auch Farb‑Informationen aus Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an dieser Eigenschaft für ältere PowerPoint‑Versionen nicht gelten.

Dieser Beispielcode demonstriert einen Vorgang, bei dem Hyperlinks mit unterschiedlichen Farben zur gleichen Folie hinzugefügt wurden:
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

### **Sound**

Aspose.Slides bietet diese Eigenschaften, um einen Hyperlink mit einem Sound zu versehen:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Hyperlink‑Sound hinzufügen**

Dieser C#‑Code zeigt, wie Sie einen Hyperlink festlegen, der einen Sound abspielt, und ihn mit einem anderen Hyperlink stoppt:
```c#
using (Presentation pres = new Presentation())
{
	// Fügt neue Audiodatei zur Audiosammlung der Präsentation hinzu
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Fügt neue Form mit Hyperlink zur nächsten Folie hinzu
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Prüft den Hyperlink auf "Kein Ton"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Setzt den Hyperlink, der Ton abspielt
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Fügt die leere Folie hinzu
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Fügt neue Form mit dem NoAction-Hyperlink hinzu
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Setzt das Hyperlink-Flag "Vorherigen Ton stoppen"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **Hyperlink‑Sound extrahieren**

Dieser C#‑Code zeigt, wie Sie den in einem Hyperlink verwendeten Sound extrahieren:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Ermittelt den Hyperlink der ersten Form
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrahiert den Hyperlink Sound in ein Byte-Array
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **Entfernen von Hyperlinks in Präsentationen**

### **Entfernen von Hyperlinks aus Texten**

Dieser C#‑Code zeigt, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:
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


### **Entfernen von Hyperlinks aus Formen oder Rahmen**

Dieser C#‑Code zeigt, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen: 
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


## **Veränderbarer Hyperlink**

Die [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink)‑Klasse ist veränderbar. Mit dieser Klasse können Sie die Werte folgender Eigenschaften ändern:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

Der Codeausschnitt zeigt, wie Sie einer Folie einen Hyperlink hinzufügen und später dessen Tooltip bearbeiten:
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


## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können IHyperlinkQueries aus einer Präsentation, Folie oder einem Text abrufen, für den der Hyperlink definiert ist. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Die Klasse IHyperlinkQueries unterstützt diese Methoden und Eigenschaften: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einem „Abschnitt“ oder zur ersten Folie eines Abschnitts erstellen?**

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation zielt technisch auf eine bestimmte Folie. Um „zu einem Abschnitt zu navigieren“, verlinken Sie typischerweise zu dessen erster Folie.

**Kann ich einen Hyperlink an Elemente der Master‑Folie anhängen, damit er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folie und Layout unterstützen Hyperlinks. Solche Links erscheinen auf den Kind‑Folien und sind während der Bildschirmpräsentation anklickbar.

**Werden Hyperlinks beim Exportieren nach PDF, HTML, Bildern oder Video erhalten bleiben?**

In [PDF](/slides/de/net/convert-powerpoint-to-pdf/) und [HTML](/slides/de/net/convert-powerpoint-to-html/) ja – Links werden im Allgemeinen beibehalten. Beim Export nach [Bildern](/slides/de/net/convert-powerpoint-to-png/) und [Video](/slides/de/net/convert-powerpoint-to-video/) geht die Klick‑Fähigkeit verloren, da Raster‑Frames bzw. Video keine Hyperlinks unterstützen.