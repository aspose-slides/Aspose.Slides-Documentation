---
title: Präsentations-Hyperlinks in .NET verwalten
linktitle: Hyperlink verwalten
type: docs
weight: 20
url: /de/net/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text-Hyperlink
- Folien-Hyperlink
- Form-Hyperlink
- Bild-Hyperlink
- Video-Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mühelos mit Aspose.Slides für .NET - steigern Sie Interaktivität und Workflow in wenigen Minuten."
---

Ein Hyperlink ist eine Referenz zu einem Objekt, Daten oder einem Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint‑Präsentationen:

* Links zu Websites in Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für .NET ermöglicht Ihnen die Durchführung vieler Aufgaben rund um Hyperlinks in Präsentationen.

{{% alert color="primary" %}} 
Vielleicht möchten Sie den einfachen Aspose, [kostenlosen Online‑PowerPoint‑Editor.](https://products.aspose.app/slides/editor) ausprobieren.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

### **URL‑Hyperlinks zu Text hinzufügen**

Dieser C#‑Code zeigt Ihnen, wie Sie einen Website‑Hyperlink zu einem Text hinzufügen:
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


### **URL‑Hyperlinks zu Formen oder Rahmen hinzufügen**

Dieses Beispiel in C# zeigt Ihnen, wie Sie einen Website‑Hyperlink zu einer Form hinzufügen:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspise APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **URL‑Hyperlinks zu Medien hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bild-, Audio‑ und Video‑Dateien. 

Dieses Beispiel zeigt Ihnen, wie Sie einen Hyperlink zu einem **Bild** hinzufügen:
```c#
using (Presentation pres = new Presentation())
{
    // Fügt ein Bild zur Präsentation hinzu
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Erstellt Bildrahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


Dieses Beispiel zeigt Ihnen, wie Sie einen Hyperlink zu einer **Audiodatei** hinzufügen:
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


Dieses Beispiel zeigt Ihnen, wie Sie einen Hyperlink zu einem **Video** hinzufügen:
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
Vielleicht möchten Sie *[OLE verwalten](https://docs.aspose.com/slides/net/manage-ole/)* sehen.
{{% /alert %}}

## **Hyperlinks verwenden, um ein Inhaltsverzeichnis zu erstellen**

Da Hyperlinks es Ihnen ermöglichen, Verweise auf Objekte oder Orte hinzuzufügen, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden.

Dieses Beispiel zeigt Ihnen, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:
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


## **Hyperlinks formatieren**

### **Farbe**

Mit der [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource)‑Eigenschaft im [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink)‑Interface können Sie die Farbe für Hyperlinks festlegen und auch Farb­informationen aus Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an dieser Eigenschaft nicht für ältere PowerPoint‑Versionen gelten.

Dieses Beispiel demonstriert einen Vorgang, bei dem Hyperlinks mit unterschiedlichen Farben zur selben Folie hinzugefügt wurden:
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

Aspose.Slides bietet diese Eigenschaften, um einen Hyperlink mit einem Sound zu betonen:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Hyperlink‑Sound hinzufügen**

Dieser C#‑Code zeigt Ihnen, wie Sie einen Hyperlink festlegen, der einen Sound abspielt, und ihn mit einem anderen Hyperlink stoppt:
```c#
using (Presentation pres = new Presentation())
{
	// Fügt neue Audiodatei zur Audiosammlung der Präsentation hinzu
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Fügt neue Form mit dem Hyperlink zur nächsten Folie hinzu
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Überprüft den Hyperlink auf "Kein Sound"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Setzt den Hyperlink, der Sound abspielt
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Fügt die leere Folie hinzu
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Fügt neue Form mit dem NoAction-Hyperlink hinzu
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Setzt das Flag "Vorherigen Sound stoppen" für den Hyperlink
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **Hyperlink‑Sound extrahieren**

Dieser C#‑Code zeigt Ihnen, wie Sie den in einem Hyperlink verwendeten Sound extrahieren:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Holt den Hyperlink der ersten Form
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrahiert den Hyperlink-Sound als Byte-Array
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **Hyperlinks aus Präsentationen entfernen**

### **Hyperlinks aus Text entfernen**

Dieser C#‑Code zeigt Ihnen, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:
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


### **Hyperlinks aus Formen oder Rahmen entfernen**

Dieser C#‑Code zeigt Ihnen, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen:
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

Die Klasse [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) ist veränderbar. Mit dieser Klasse können Sie die Werte folgender Eigenschaften ändern:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

Das Code‑Snippet zeigt Ihnen, wie Sie einer Folie einen Hyperlink hinzufügen und dessen Tooltip später bearbeiten:
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

Sie können IHyperlinkQueries aus einer Präsentation, Folie oder einem Text, für den der Hyperlink definiert ist, zugreifen. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Die Klasse IHyperlinkQueries unterstützt folgende Methoden und Eigenschaften: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einem "Abschnitt" oder der ersten Folie eines Abschnitts erstellen?**

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation zielt technisch auf eine bestimmte Folie. Um zu einem "Abschnitt" zu navigieren, verlinkt man in der Regel auf dessen erste Folie.

**Kann ich einem Element der Masterfolie einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Elemente der Masterfolie und des Layouts unterstützen Hyperlinks. Diese Links erscheinen auf den untergeordneten Folien und sind während der Bildschirmanzeige klickbar.

**Werden Hyperlinks beim Exportieren in PDF, HTML, Bilder oder Video beibehalten?**

In [PDF](/slides/de/net/convert-powerpoint-to-pdf/) und [HTML](/slides/de/net/convert-powerpoint-to-html/) ja – Links werden im Allgemeinen beibehalten. Beim Exportieren zu [Bildern](/slides/de/net/convert-powerpoint-to-png/) und [Video](/slides/de/net/convert-powerpoint-to-video/) bleibt die Klickbarkeit aufgrund des Formats nicht erhalten (Raster‑Frames/Video unterstützen keine Hyperlinks).