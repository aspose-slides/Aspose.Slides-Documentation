---
title: Verwalten von Aufzählungs‑ und nummerierten Listen in Präsentationen in Python
linktitle: Listen verwalten
type: docs
weight: 70
url: /de/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
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
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑, Bild‑, mehrstufige und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python über .NET erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Python über .NET ermöglicht das Erstellen und Formatieren von Aufzählungs- und Nummerierungslisten in PowerPoint- und OpenDocument-Präsentationen. Ein Listenelement ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die Eigenschaft [Paragraph.paragraph_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/paragraph_format/), um auf die listenbezogenen Einstellungen auf Absatzebene zuzugreifen. Der Haupteinstiegspunkt ist [ParagraphFormat.bullet](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/bullet/), der ein [BulletFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/)‑Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:
- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellt
- ein Bildaufzählungszeichen erstellt
- eine mehrstufige Liste erstellt, indem die Absatztiefe festgelegt wird
- eine nummerierte Liste erstellt
- die Listformatierung in einer vorhandenen Präsentation inspiziert und ändert

## **Erstellen einer Aufzählungsliste**

Um eine Aufzählungsliste zu erstellen, fügen Sie [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Objekte zu einem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu und setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/type/) auf [BulletType.SYMBOL](https://reference.aspose.com/slides/de/python-net/aspose.slides/bullettype/). Anschließend können Sie [BulletFormat.char](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/color/) und [BulletFormat.height](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/height/) festlegen, um das Aussehen der Aufzählungszeichen zu steuern.

Der folgende Python‑Code demonstriert, wie man in einer Folie eine Aufzählungsliste erstellt:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Symbol‑Aufzählungszeichen](symbol_bullets.png)

## **Erstellen einer nummerierten Liste**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/type/) auf [BulletType.NUMBERED](https://reference.aspose.com/slides/de/python-net/aspose.slides/bullettype/). Sie können außerdem ein Nummerierungsformat mit [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/numbered_bullet_style/) auswählen oder [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) festlegen, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

Der folgende Python‑Code zeigt, wie man in einer Folie eine nummerierte Liste erstellt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die nummerierten Aufzählungszeichen](numbered_bullets.png)

## **Erstellen eines Bildaufzählungszeichens**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungs­symbol durch ein Bild zu ersetzen. Bild‑Aufzählungszeichen funktionieren am besten mit einfachen Bildern, die in kleiner Größe lesbar bleiben, wie z. B. Icons oder kleine transparente PNG‑Dateien.

{{% alert color="primary" %}}
Idealerweise, wenn Sie das reguläre Aufzählungs­symbol durch ein Bild ersetzen möchten, sollten Sie eine einfache Grafik mit transparentem Hintergrund wählen. Derartige Bilder eignen sich gut als benutzerdefinierte Aufzählungs­symbole.

Beachten Sie, dass das Bild auf eine sehr kleine Größe verkleinert wird. Aus diesem Grund empfehlen wir dringend, ein Bild auszuwählen, das auch in kleiner Darstellung klar und visuell wirksam bleibt, wenn es als Aufzählungs­zeichen in einer Liste verwendet wird.
{{% /alert %}}

Um ein Bildaufzählungszeichen zu erstellen, fügen Sie ein Bild zu [Presentation.images](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/images/) hinzu und weisen Sie das zurückgegebene Bildobjekt [BulletFormat.picture](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/picture/) zu. Setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/type/) auf [BulletType.PICTURE](https://reference.aspose.com/slides/de/python-net/aspose.slides/bullettype/), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

Der folgende Python‑Code zeigt, wie man Bild‑Aufzählungszeichen in einer Folie erstellt:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Bild‑Aufzählungszeichen](picture_bullets.png)

## **Erstellen einer mehrstufigen Liste**

Verwenden Sie [ParagraphFormat.depth](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/depth/), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

Der folgende Python‑Code zeigt, wie man eine mehrstufige Aufzählungsliste erstellt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die mehrstufige Liste](multilevel_list.png)

## **Ändern einer bestehenden Liste**

Um die Listformatierung in einer bestehenden Präsentation zu ändern, greifen Sie auf den entsprechenden Absatz zu und aktualisieren seine [ParagraphFormat.bullet](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/bullet/)-Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können auch zum Prüfen oder Ändern von Listen verwendet werden, die aus einer PPT-, PPTX‑ oder ODP‑Datei geladen wurden.

Der folgende Python‑Code ändert den ersten Absatz in einem Text‑Frame, sodass er einen nummerierten Listenstil verwendet:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Können Aufzählungs‑ und nummerierte Listen in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides bewahrt die Listformatierung, wenn das Zielformat die entsprechenden Textlayout‑ und Aufzählungsfunktionen unterstützt.

**Kann ich Listen in bestehenden Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den gewünschten Absatz zu, prüfen oder aktualisieren Sie dessen [ParagraphFormat.bullet](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/bullet/)-Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.