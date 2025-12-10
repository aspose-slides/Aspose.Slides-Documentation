---
title: Verwalten von Aufzählungs- und Nummerierungslisten in Präsentationen mit .NET
linktitle: Listen verwalten
type: docs
weight: 70
url: /de/net/manage-bullet-and-numbered-lists
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑ und Nummerierungslisten in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET verwalten. Schritt‑für‑Schritt‑Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und Nummerierungslisten auf die gleiche Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for .NET** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Nummern in Folien Ihrer Präsentationen zu verwenden. 

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für Aufzählungslisten**

In den meisten Fällen erfüllt eine Aufzählungsliste drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Betrachter auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Betrachtern, Schlüsselpunkte leicht zu überfliegen
- kommuniziert und liefert wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls beim Organisieren und Präsentieren von Informationen. Idealerweise sollten Sie Zahlen (statt Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für nummerierte Listen**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachstehenden **Creating Bullets**‑Verfahren:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation. 

## **Aufzählungen erstellen**

Um eine Aufzählungsliste zu erstellen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)‑Objekt auf die Folie (in der Sie eine Aufzählungsliste hinzufügen möchten) in der Folien‑Sammlung zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) in der ausgewählten Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standard‑Absatz im [TextFrame]().
6. Erstellen Sie die erste Absatz‑Instanz mithilfe der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)‑Klasse.
8. Setzen Sie den Aufzählungstyp auf Symbol und anschließend das Aufzählungszeichen.
9. Setzen Sie den Absatztext.
10. Setzen Sie den Absatz‑Einzug, um die Aufzählung zu setzen.
11. Legen Sie die Farbe der Aufzählung fest.
12. Legen Sie die Höhe der Aufzählung fest.
13. Fügen Sie den erstellten Absatz in die Absatz‑Sammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7‑12.
15. Speichern Sie die Präsentation.

Dieser Beispielcode in C# – eine Implementierung der obigen Schritte – zeigt, wie Sie eine Aufzählungsliste in einer Folie erstellen:
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

Aspose.Slides for .NET ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Aufmerksamkeit noch stärker auf Listeneinträge lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden. 

 {{% alert color="primary" %}} 

Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen.

Auf jeden Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe verkleinert, daher empfehlen wir dringend, ein Bild auszuwählen, das (als Ersatz für das Aufzählungszeichen) in einer Liste gut aussieht. 

{{% /alert %}} 

Um ein Bildaufzählungszeichen zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)‑Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) in der ausgewählten Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse.
7. Laden Sie ein Bild von der Festplatte und fügen Sie es zu [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) hinzu und verwenden Sie anschließend die [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)‑Instanz, die von der [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index)‑Methode zurückgegeben wurde.
8. Setzen Sie den Aufzählungstyp auf Bild und anschließend das Bild.
9. Setzen Sie den Absatztext.
10. Setzen Sie den Absatz‑Einzug, um das Aufzählungszeichen zu setzen.
11. Legen Sie die Farbe des Aufzählungszeichens fest.
12. Legen Sie die Höhe der Aufzählungszeichen fest.
13. Fügen Sie den erstellten Absatz in die Absatz‑Sammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7‑13.
15. Speichern Sie die Präsentation.

Dieser C#‑Code zeigt, wie Sie ein Bildaufzählungszeichen in einer Folie erstellen:
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

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Haupt‑Aufzählungsliste – gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)‑Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) in der ausgewählten Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu.
5. Entfernen Sie den Standard‑Absatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die erstellten Absätze in die Absatz‑Sammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein.
11. Speichern Sie die Präsentation.

Dieser Code, der eine Implementierung der obigen Schritte darstellt, zeigt, wie Sie in C# eine mehrstufige Aufzählungsliste erstellen:
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

Dieser C#‑Code zeigt, wie Sie in einer Folie eine nummerierte Liste erstellen:
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

**Können mit Aspose.Slides erstellte Aufzählungs‑ und nummerierte Listen in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt die Formatierung und Struktur von Aufzählungs‑ und nummerierten Listen vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt so für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs‑ oder nummerierte Listen aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder nummerierten Listen aus bestehenden Präsentationen, wobei deren ursprüngliche Formatierung und Erscheinungsbild erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs‑ und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich der Verwendung von Sonder‑ oder nicht‑lateinischen Zeichen.