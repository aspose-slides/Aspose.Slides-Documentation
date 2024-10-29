---
title: Auflisten von Aufzählungs- und Nummerierten Listen verwalten
type: docs
weight: 70
url: /de/python-net/manage-bullet-and-numbered-lists/
keywords: "Aufzählungen, Aufzählungslisten, Nummern, Nummerierte Listen, Bildaufzählungen, mehrstufige Aufzählungen, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Erstellen Sie Aufzählungs- und nummerierte Listen in einer PowerPoint-Präsentation in Python"
---

In **Microsoft PowerPoint** können Sie Aufzählungs- und nummerierte Listen auf die gleiche Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides für Python über .NET** ermöglicht es Ihnen auch, Aufzählungen und Nummern in Folien Ihrer Präsentationen zu verwenden.

### Warum Aufzählungslisten verwenden?

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren.

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, wichtige Punkte schnell zu scannen
- kommuniziert und liefert wichtige Details effizient.

### Warum nummerierte Listen verwenden?

Nummerierte Listen helfen auch, Informationen zu organisieren und zu präsentieren. Idealerweise sollten Sie Nummern (anstatt von Aufzählungen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn auf einen Eintrag verwiesen werden muss (z. B. *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im Verfahren **Aufzählungen erstellen** unten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation.

## Aufzählungen erstellen

Um eine Aufzählungsliste zu erstellen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie (in der Sie eine Aufzählungsliste hinzufügen möchten) in der Folienkollektion über das [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Objekt zu.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) auf der ausgewählten Folie hinzu.
4. Greifen Sie auf das [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [text_frame]().
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse.
8. Setzen Sie den Aufzählungstyp auf Symbol und dann das Aufzählungszeichen.
9. Setzen Sie den Absatztext.
10. Setzen Sie den Absatz-Einzug, um die Aufzählung festzulegen.
11. Setzen Sie die Farbe der Aufzählung.
12. Setzen Sie die Höhe der Aufzählung.
13. Fügen Sie den erstellten Absatz in die [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Absatzkollektion hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7-12.
15. Speichern Sie die Präsentation.

Dieser Beispielcode in Python—eine Implementierung der obigen Schritte—zeigt Ihnen, wie Sie eine Aufzählungsliste in einer Folie erstellen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Mein Text"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## Bildaufzählungen erstellen

Aspose.Slides für Python über .NET ermöglicht es Ihnen, die Aufzählungen in Aufzählungslisten zu ändern. Sie können die Aufzählungen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie visuelles Interesse an einer Liste hinzufügen oder noch mehr Aufmerksamkeit auf Einträge in einer Liste lenken möchten, können Sie Ihr eigenes Bild als Aufzählung verwenden.

{{% alert color="primary" %}} 

Idealerweise, wenn Sie beabsichtigen, das reguläre Aufzählungssymbol durch ein Bild zu ersetzen, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder wirken am besten als benutzerdefinierte Aufzählungssymbole.

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe reduziert, daher empfehlen wir dringend, ein Bild auszuwählen, das gut aussieht (als Ersatz für das Aufzählungssymbol) in einer Liste.

{{% /alert %}} 

Um eine Bildaufzählung zu erstellen, gehen Sie durch die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion über das [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Objekt zu.
3. Fügen Sie eine [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) in der ausgewählten Folie hinzu.
4. Greifen Sie auf das [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse.
7. Laden Sie ein Bild von der Festplatte und fügen Sie es zu [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) hinzu und verwenden Sie dann die [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) Instanz, die von der [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) Methode zurückgegeben wurde.
8. Setzen Sie den Aufzählungstyp auf Bild und dann das Bild.
9. Setzen Sie den Absatztext.
10. Setzen Sie den Absatz-Einzug, um die Aufzählung festzulegen.
11. Setzen Sie die Farbe der Aufzählung.
12. Setzen Sie die Höhe der Aufzählungen.
13. Fügen Sie den erstellten Absatz in die [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Absatzkollektion hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7-13.
15. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Bildaufzählung in einer Folie erstellen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Mein Text"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

## Mehrstufige Aufzählungen erstellen

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält—zusätzliche Listen unter der Hauptaufzählungsliste—gehen Sie durch diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion über das [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Objekt zu.
3. Fügen Sie eine [auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) in der ausgewählten Folie hinzu.
4. Greifen Sie auf das [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) Klasse und der Tiefe auf 0 gesetzt.
7. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und der Tiefe auf 1 gesetzt.
8. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und der Tiefe auf 2 gesetzt.
9. Erstellen Sie die vierte Absatzinstanz mit der Paragraph-Klasse und der Tiefe auf 3 gesetzt.
10. Fügen Sie die erstellten Absätze in die [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Absatzkollektion hinzu.
11. Speichern Sie die Präsentation.

Dieser Code, der eine Implementierung der obigen Schritte darstellt, zeigt Ihnen, wie Sie eine mehrstufige Aufzählungsliste in Python erstellen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "Mein Text Tiefe 0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "Mein Text Tiefe 1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "Mein Text Tiefe 2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "Mein Text Tiefe 3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

## Nummern erstellen

Dieser Python-Code zeigt Ihnen, wie Sie eine nummerierte Liste in einer Folie erstellen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "Mein Text 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Mein Text 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```