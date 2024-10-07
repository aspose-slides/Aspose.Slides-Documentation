---
title: Aufzählungs- und Nummerierungslisten verwalten
type: docs
weight: 70
url: /net/manage-bullet-and-numbered-lists
keywords: "Aufzählungen, Aufzählungslisten, Nummern, Nummerierte Listen, Bildaufzählungen, mehrstufige Aufzählungen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Erstellen Sie Aufzählungs- und nummerierte Listen in PowerPoint-Präsentationen in C# oder .NET"
---

In **Microsoft PowerPoint** können Sie Aufzählungs- und nummerierte Listen auf die gleiche Weise erstellen, wie Sie es in Word und anderen Texteditoren tun. **Aspose.Slides für .NET** ermöglicht es Ihnen auch, Aufzählungen und Nummern in Folien Ihrer Präsentationen zu verwenden.

### Warum Aufzählungslisten verwenden?

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren.

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, leicht nach Schlüsselstellen zu scannen
- kommuniziert und übermittelt wichtige Details effizient.

### Warum nummerierte Listen verwenden?

Nummerierte Listen helfen ebenfalls bei der Organisation und Präsentation von Informationen. Idealerweise sollten Sie Nummern (anstelle von Aufzählungen) verwenden, wenn die Reihenfolge der Einträge (zum Beispiel *Schritt 1, Schritt 2*, usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (zum Beispiel *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im Verfahren **Erstellung von Aufzählungen** unten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation.

## Erstellung von Aufzählungen

Um eine Aufzählungsliste zu erstellen, befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die Folie (in die Sie eine Aufzählungsliste einfügen möchten) in der Folienkollektion über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) Objekt zu.
3. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame]().
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) Klasse.
8. Setzen Sie den Aufzählungstyp auf Symbol und dann das Aufzählungszeichen.
9. Setzen Sie den Absatztext.
10. Setzen Sie den Absatz-Indent, um die Aufzählung zu setzen.
11. Setzen Sie die Farbe der Aufzählung.
12. Setzen Sie die Höhe der Aufzählung.
13. Fügen Sie den erstellten Absatz in die [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) Absatzkollektion ein.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7-12.
15. Speichern Sie die Präsentation.

Dieser Beispielcode in C#—eine Implementierung der obigen Schritte—zeigt Ihnen, wie Sie eine Aufzählungsliste in einer Folie erstellen:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "Mein Text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Erstellung von Bildaufzählungen

Aspose.Slides für .NET ermöglicht es Ihnen, die Aufzählungen in Aufzählungslisten zu ändern. Sie können die Aufzählungen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder noch mehr Aufmerksamkeit auf Einträge einer Liste lenken möchten, können Sie Ihr eigenes Bild als Aufzählung verwenden.

 {{% alert color="primary" %}} 

Idealerweise, wenn Sie beabsichtigen, das reguläre Aufzählungssymbol durch ein Bild zu ersetzen, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder funktionieren am besten als benutzerdefinierte Aufzählungssymbole.

In jedem Fall wird das Bild, das Sie wählen, auf eine sehr kleine Größe reduziert, daher empfehlen wir dringend, ein Bild auszuwählen, das in einer Liste gut aussieht (als Ersatz für das Aufzählungssymbol).

{{% /alert %}} 

Um eine Bildaufzählung zu erstellen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) Objekt zu.
3. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) Klasse.
7. Laden Sie das Bild von der Festplatte und fügen Sie es zu [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) hinzu und verwenden Sie dann die [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) Instanz, die von der [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index) Methode zurückgegeben wurde.
8. Setzen Sie den Aufzählungstyp auf Bild und dann das Bild.
9. Setzen Sie den Absatztext.
10. Setzen Sie den Absatz-Indent, um die Aufzählung zu setzen.
11. Setzen Sie die Farbe der Aufzählung.
12. Setzen Sie die Höhe der Aufzählungen.
13. Fügen Sie den erstellten Absatz in die [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) Absatzkollektion ein.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7-13.
15. Speichern Sie die Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine Bildaufzählung in einer Folie erstellen:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "Mein Text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Erstellung von mehrstufigen Aufzählungen

Um eine Aufzählungsliste zu erstellen, die Elemente auf unterschiedlichen Ebenen enthält—zusätzliche Listen unter der Hauptaufzählungsliste—gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) Objekt zu.
3. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) Klasse und mit der Tiefe auf 0 gesetzt.
7. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und der Tiefe auf 1 gesetzt.
8. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und der Tiefe auf 2 gesetzt.
9. Erstellen Sie die vierte Absatzinstanz mit der Paragraph-Klasse und der Tiefe auf 3 gesetzt.
10. Fügen Sie die erstellten Absätze in die [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) Absatzkollektion ein.
11. Speichern Sie die Präsentation.

Dieser Code, der eine Implementierung der obigen Schritte ist, zeigt Ihnen, wie Sie eine mehrstufige Aufzählungsliste in C# erstellen:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "Mein Text Tiefe 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "Mein Text Tiefe 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "Mein Text Tiefe 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "Mein Text Tiefe 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Erstellung von Nummern

Dieser C#-Code zeigt Ihnen, wie Sie eine nummerierte Liste in einer Folie erstellen:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "Mein Text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "Mein Text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```