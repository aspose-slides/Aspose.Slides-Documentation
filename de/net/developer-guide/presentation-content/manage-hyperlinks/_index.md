---
title: Hyperlinks verwalten
type: docs
weight: 20
url: /net/manage-hyperlinks/
keywords: "Hyperlink hinzufügen, PowerPoint-Präsentation, PowerPoint-Hyperlink, Texthyperlink, Folienhyperlink, Formhyperlink, Bildhyperlink, Videohyperlink, .NET, C#, Csharp"
description: "Hyperlink zu einer PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

Ein Hyperlink ist ein Verweis auf ein Objekt oder Daten oder einen Ort in etwas. Diese sind häufige Hyperlinks in PowerPoint-Präsentationen:

* Links zu Websites innerhalb von Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für .NET ermöglicht es Ihnen, viele Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen durchzuführen.

{{% alert color="primary" %}} 

Sie möchten vielleicht den einfachen, [kostenlosen Online-PowerPoint-Editor von Aspose] (https://products.aspose.app/slides/editor) ausprobieren.

{{% /alert %}} 

## **Hinzufügen von URL-Hyperlinks**

### **Hinzufügen von URL-Hyperlinks zu Texten**

Dieser C#-Code zeigt Ihnen, wie Sie einen Hyperlink zu einer Website zu einem Text hinzufügen:

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: Dateiformat-APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Mehr als 70% der Fortune 100-Unternehmen vertrauen auf Aspose-APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Hinzufügen von URL-Hyperlinks zu Formen oder Rahmen**

Dieser Beispielcode in C# zeigt Ihnen, wie Sie einen Hyperlink zu einer Website zu einer Form hinzufügen:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "Mehr als 70% der Fortune 100-Unternehmen vertrauen auf Aspose-APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Hinzufügen von URL-Hyperlinks zu Medien**

Aspose.Slides ermöglicht es Ihnen, Hyperlinks zu Bildern, Audio- und Video-Dateien hinzuzufügen.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Bild** hinzufügen:

```c#
using (Presentation pres = new Presentation())
{
    // Fügt Bild zur Präsentation hinzu
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Erstellt einen Bilderahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "Mehr als 70% der Fortune 100-Unternehmen vertrauen auf Aspose-APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einer **Audio-Datei** hinzufügen:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "Mehr als 70% der Fortune 100-Unternehmen vertrauen auf Aspose-APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Video** hinzufügen:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "Mehr als 70% der Fortune 100-Unternehmen vertrauen auf Aspose-APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tipp"  color="primary"  %}} 

Sie möchten vielleicht *[OLE verwalten](https://docs.aspose.com/slides/net/manage-ole/)* sehen.

{{% /alert %}}

## **Verwendung von Hyperlinks zur Erstellung eines Inhaltsverzeichnisses**

Da Hyperlinks es Ihnen ermöglichen, Verweise auf Objekte oder Orte hinzuzufügen, können Sie sie verwenden, um ein Inhaltsverzeichnis zu erstellen.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:

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
    paragraph.Text = "Titel der Folie 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Seite 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Formatierung von Hyperlinks**

### **Farbe**

Mit der [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) Eigenschaft in der [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink) Schnittstelle können Sie die Farbe für Hyperlinks festlegen und auch die Farbinformation von Hyperlinks abrufen. Das Feature wurde erstmals in PowerPoint 2019 eingeführt, daher gelten Änderungen in Bezug auf die Eigenschaft nicht für ältere PowerPoint-Versionen.

Dieser Beispielcode zeigt eine Operation, bei der Hyperlinks mit unterschiedlichen Farben zur gleichen Folie hinzugefügt wurden:

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("Dies ist ein Beispiel für einen farbigen Hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("Dies ist ein Beispiel für einen gewöhnlichen Hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```

### **Ton**

Aspose.Slides bietet diese Eigenschaften an, um einen Hyperlink mit einem Ton zu betonen:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Hyperlink-Sound hinzufügen**

Dieser C#-Code zeigt Ihnen, wie Sie den Hyperlink festlegen, der einen Ton abspielt und ihn mit einem anderen Hyperlink stoppt:

```c#
using (Presentation pres = new Presentation())
{
	// Fügt einen neuen Audio-Tracks zur Präsentation hinzu
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Fügt eine neue Form mit dem Hyperlink zur nächsten Folie hinzu
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Überprüft den Hyperlink auf "Kein Ton"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Setzt den Hyperlink, der Ton abspielt
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Fügt die leere Folie hinzu
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Fügt eine neue Form mit dem NoAction-Hyperlink hinzu
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Setzt das Hyperlink-Flag "Vorherigen Ton stoppen"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Hyperlink-Sound extrahieren**

Dieser C#-Code zeigt Ihnen, wie Sie den in einem Hyperlink verwendeten Ton extrahieren:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Holt den ersten Formularhyperlink
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Extrahiert den Hyperlink-Sound im Byte-Array
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Entfernen von Hyperlinks in Präsentationen**

### **Entfernen von Hyperlinks aus Texten**

Dieser C#-Code zeigt Ihnen, wie Sie den Hyperlink von einem Text in einer Präsentationsfolie entfernen:

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

Dieser C#-Code zeigt Ihnen, wie Sie den Hyperlink von einer Form in einer Präsentationsfolie entfernen:

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

Die [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) Klasse ist veränderbar. Mit dieser Klasse können Sie die Werte für diese Eigenschaften ändern:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

Der Codeausschnitt zeigt Ihnen, wie Sie einen Hyperlink zu einer Folie hinzufügen und später sein Tooltip bearbeiten:

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: Dateiformat-APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Mehr als 70% der Fortune 100-Unternehmen vertrauen auf Aspose-APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können auf IHyperlinkQueries von einer Präsentation, Folie oder Text zugreifen, für die der Hyperlink definiert ist.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Die IHyperlinkQueries-Klasse unterstützt diese Methoden und Eigenschaften:

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)