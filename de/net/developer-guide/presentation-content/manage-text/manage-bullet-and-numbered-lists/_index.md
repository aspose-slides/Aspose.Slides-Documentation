---
title: Verwalten von Aufzählungs- und nummerierten Listen in Präsentationen in .NET
linktitle: Listen verwalten
type: docs
weight: 70
url: /de/net/manage-bullet-and-numbered-lists
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- benutzerdefiniertes Aufzählungszeichen
- mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑ und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET verwalten. Schritt‑für‑Schritt‑Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und nummerierte Listen auf dieselbe Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for .NET** ermöglicht es Ihnen ebenfalls, Aufzählungszeichen und Nummern in Folien Ihrer Präsentationen zu verwenden. 

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, Schlüsselpunkte leicht zu überfliegen
- kommuniziert und übermittelt wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls beim Organisieren und Präsentieren von Informationen. Idealerweise sollten Sie Zahlen (anstelle von Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachstehenden Verfahren **Creating Bullets**:

1. Erstellen Sie eine Instanz der Präsentationsklasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14). 
3. Speichern Sie die Präsentation. 

## **Aufzählungen erstellen**

So erstellen Sie eine Aufzählungsliste, indem Sie diese Schritte ausführen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)-Objekt auf die Folie (in der Sie eine Aufzählungsliste hinzufügen möchten) in der Folienkollektion zu. 
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu. 
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standardabsatz im [TextFrame](). 
6. Erstellen Sie die erste Absatzinstanz mithilfe der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse. 
8. Legen Sie den Aufzählungstyp auf Symbol fest und setzen Sie dann das Aufzählungszeichen. 
9. Setzen Sie den Absatztext. 
10. Stellen Sie den Absatz‑Einzug ein, um die Aufzählung festzulegen. 
11. Legen Sie die Farbe der Aufzählung fest. 
12. Stellen Sie die Höhe der Aufzählung ein. 
13. Fügen Sie den erstellten Absatz in die Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein. 
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7‑12. 
15. Speichern Sie die Präsentation. 

Dieser Beispielcode in C# — eine Umsetzung der obigen Schritte — zeigt, wie Sie in einer Folie eine Aufzählungsliste erstellen:
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

Idealerweise sollten Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungssymbole. 

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe verkleinert, daher empfehlen wir dringend, ein Bild auszuwählen, das in einer Liste (als Ersatz für das Aufzählungszeichen) gut aussieht. 

{{% /alert %}} 

So erstellen Sie ein Bildaufzählungszeichen, indem Sie diese Schritte ausführen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)-Objekt auf die gewünschte Folie in der Folienkollektion zu. 
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu. 
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
6. Erstellen Sie die erste Absatzinstanz mithilfe der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse. 
7. Laden Sie ein Bild von der Festplatte, fügen Sie es zu [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) hinzu und verwenden Sie anschließend die von der [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index)-Methode zurückgegebene [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)-Instanz. 
8. Legen Sie den Aufzählungstyp auf Bild fest und setzen Sie anschließend das Bild. 
9. Setzen Sie den Absatztext. 
10. Stellen Sie den Absatz‑Einzug ein, um die Aufzählung festzulegen. 
11. Legen Sie die Farbe der Aufzählung fest. 
12. Stellen Sie die Höhe der Aufzählungen ein. 
13. Fügen Sie den erstellten Absatz in die Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein. 
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7‑13. 
15. Speichern Sie die Präsentation. 

Dieser C#‑Code zeigt, wie Sie in einer Folie ein Bildaufzählungszeichen erstellen:
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

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält — zusätzliche Listen unter der Hauptaufzählungsliste — gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse. 
2. Greifen Sie über das [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)-Objekt auf die gewünschte Folie in der Folienkollektion zu. 
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) hinzu. 
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) der hinzugefügten Form zu. 
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
6. Erstellen Sie die erste Absatzinstanz mithilfe der [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)-Klasse und setzen Sie die Tiefe auf 0. 
7. Erstellen Sie die zweite Absatzinstanz mithilfe der Paragraph‑Klasse und setzen Sie die Tiefe auf 1. 
8. Erstellen Sie die dritte Absatzinstanz mithilfe der Paragraph‑Klasse und setzen Sie die Tiefe auf 2. 
9. Erstellen Sie die vierte Absatzinstanz mithilfe der Paragraph‑Klasse und setzen Sie die Tiefe auf 3. 
10. Fügen Sie die erstellten Absätze in die Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) ein. 
11. Speichern Sie die Präsentation. 

Dieser Code, der die oben genannten Schritte umsetzt, zeigt, wie Sie in C# eine mehrstufige Aufzählungsliste erstellen:
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

Ja, Aspose.Slides ermöglicht es, Aufzählungs‑ oder nummerierte Listen aus bestehenden Präsentationen zu importieren und zu bearbeiten, wobei die ursprüngliche Formatierung und das Erscheinungsbild erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs‑ und nummerierte Listen in in mehreren Sprachen erstellten Präsentationen?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs‑ und nummerierten Listen in jeder Sprache, einschließlich der Verwendung spezieller oder nicht‑lateinischer Zeichen.