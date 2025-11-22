---
title: Aufzählungszeichen und nummerierte Listen verwalten
type: docs
weight: 70
url: /de/net/manage-bullet-and-numbered-lists
keywords: "Aufzählungszeichen, Aufzählungslisten, Zahlen, Nummerierte Listen, Bildaufzählungen, Mehrstufige Aufzählungen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Erstellen Sie Aufzählungs- und nummerierte Listen in PowerPoint-Präsentationen mit C# oder .NET"
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und Nummerierungslisten auf die gleiche Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for .NET** ermöglicht es Ihnen ebenfalls, Aufzählungs‑ und Nummerierungszeichen in Folien Ihrer Präsentationen zu verwenden. 

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste die folgenden drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, Schlüsselbegriffe leicht zu überfliegen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls bei der Organisation und Präsentation von Informationen. Idealerweise sollten Sie Zahlen (statt Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (zum Beispiel *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (zum Beispiel *siehe Schritt 3*).

**Beispiel für nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachfolgenden Verfahren **Creating Bullets**:

1. Erstellen Sie eine Instanz der Presentation‑Klasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14). 
3. Speichern Sie die Präsentation. 

## **Aufzählungen erstellen**

Um eine Aufzählungsliste zu erstellen, gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)-Objekt auf die Folie (in der Sie eine Aufzählungsliste hinzufügen möchten) in der Folien‑Kollektion zu. 
3. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu. 
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standardabsatz im [TextFrame](). 
6. Erstellen Sie die erste Paragraph‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse. 
8. Setzen Sie den Aufzählungstyp auf Symbol und anschließend das Aufzählungszeichen. 
9. Legen Sie den Paragraph‑Text fest. 
10. Setzen Sie den Paragraph‑Einzug, um die Aufzählung zu setzen. 
11. Setzen Sie die Farbe der Aufzählung. 
12. Setzen Sie die Höhe der Aufzählung. 
13. Fügen Sie den erstellten Paragraphen in die Paragraph‑Sammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein. 
14. Fügen Sie den zweiten Paragraphen hinzu und wiederholen Sie die Schritte 7‑12. 
15. Speichern Sie die Präsentation. 

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
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Bildaufzählungen erstellen**

Aspose.Slides for .NET ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Einträge noch stärker hervorheben möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden. 

{{% alert color="primary" %}} 

Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen. 

In jedem Fall wird das gewählte Bild auf eine sehr kleine Größe verkleinert, daher empfehlen wir dringend, ein Bild auszuwählen, das in einer Liste (als Ersatz für das Aufzählungszeichen) gut aussieht. 

{{% /alert %}} 

Um ein Bild‑Aufzählungszeichen zu erstellen, gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)-Objekt auf die gewünschte Folie in der Folien‑Kollektion zu. 
3. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu. 
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
6. Erstellen Sie die erste Paragraph‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse. 
7. Laden Sie das Bild von der Festplatte und fügen Sie es zu [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) hinzu, und verwenden Sie dann die von der [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index)-Methode zurückgegebene [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Instanz. 
8. Setzen Sie den Aufzählungstyp auf Bild und anschließend das Bild. 
9. Legen Sie den Paragraph‑Text fest. 
10. Setzen Sie den Paragraph‑Einzug, um die Aufzählung zu setzen. 
11. Setzen Sie die Farbe der Aufzählung. 
12. Setzen Sie die Höhe der Aufzählungen. 
13. Fügen Sie den erstellten Paragraphen in die Paragraph‑Sammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein. 
14. Fügen Sie den zweiten Paragraphen hinzu und wiederholen Sie die Schritte 7‑13. 
15. Speichern Sie die Präsentation. 

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
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Mehrstufige Aufzählungen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Hauptauflistung – gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)-Objekt auf die gewünschte Folie in der Folien‑Kollektion zu. 
3. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu. 
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
6. Erstellen Sie die erste Paragraph‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse und setzen Sie die Tiefe auf 0. 
7. Erstellen Sie die zweite Paragraph‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 1. 
8. Erstellen Sie die dritte Paragraph‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 2. 
9. Erstellen Sie die vierte Paragraph‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 3. 
10. Fügen Sie die erstellten Paragraphen in die Paragraph‑Sammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein. 
11. Speichern Sie die Präsentation. 

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Nummern erstellen**

Dieser C#‑Code zeigt Ihnen, wie Sie eine nummerierte Liste in einer Folie erstellen:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Können mit Aspose.Slides erstellte Aufzählungs‑ und Nummerierungslisten in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt die Formatierung und Struktur von Aufzählungs‑ und Nummerierungslisten vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs‑ oder nummerierte Listen aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder nummerierten Listen aus bestehenden Präsentationen, wobei deren ursprüngliche Formatierung und Darstellung erhalten bleibt.

**Unterstützt Aspose.Slides Aufzählungs‑ und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich der Verwendung spezieller oder nicht‑lateinischer Zeichen.