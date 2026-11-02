---
title: Listen mit Aufzählungs‑ und Nummerierungszeichen in Präsentationen in Python verwalten
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
- Symbolaufzählungszeichen
- Bildaufzählungszeichen
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
description: "Erfahren Sie, wie Sie Aufzählungs-, Bild-, mehrstufige und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Python über .NET ermöglicht das Erstellen und Formatieren von Aufzählungs‑ und nummerierten Listen in PowerPoint‑ und OpenDocument‑Präsentationen. Ein Listenelement ist ein Absatz, dessen Aufzählungseinstellungen über sein Absatzformat gesteuert werden.

Verwenden Sie die [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/)‑Eigenschaft, um Listeneinstellungen auf Absatzebene zuzugreifen. Der Haupteinstiegspunkt ist [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), der ein [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/)‑Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- eine Bildaufzählung erstellen
- eine mehrstufige Liste erstellen, indem die Absatztiefe festgelegt wird
- eine nummerierte Liste erstellen
- Listformatierung in einer vorhandenen Präsentation prüfen und ändern
- die tatsächlichen Listensymbole und Nummern zusammen mit dem Absatztext lesen

## **Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)-Objekte zu einem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) hinzu und setzen [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) auf [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Anschließend können Sie [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/) und [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) festlegen, um das Erscheinungsbild der Aufzählungszeichen zu steuern.

Der folgende Python‑Code zeigt, wie man in einer Folie eine Aufzählungsliste erstellt:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
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

![Die Symbolaufzählungen](symbol_bullets.png)

## **Nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) auf [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Sie können außerdem ein Nummerierungsformat mit [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) wählen oder [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) festlegen, wenn die Liste mit einem anderen Wert als 1 beginnen soll.

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

![Die nummerierten Aufzählungen](numbered_bullets.png)

## **Bildaufzählung erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungssymbol durch ein Bild zu ersetzen. Bildaufzählungen funktionieren am besten mit einfachen Bildern, die in kleiner Größe lesbar bleiben, wie z. B. Symbole oder kleine transparente PNG‑Dateien.

{{% alert color="info" title="Note" %}}
Im Idealfall, wenn Sie das reguläre Aufzählungssymbol durch ein Bild ersetzen möchten, sollten Sie eine einfache Grafik mit transparentem Hintergrund wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungssymbole.

Beachten Sie, dass das Bild auf eine sehr kleine Größe verkleinert wird. Aus diesem Grund empfehlen wir dringend, ein Bild auszuwählen, das auch in kleiner Größe klar und visuell wirksam bleibt, wenn es als Aufzählungszeichen in einer Liste verwendet wird.
{{% /alert %}}

Um eine Bildaufzählung zu erstellen, fügen Sie ein Bild zu [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) hinzu und weisen das zurückgegebene Bildobjekt [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) zu. Setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) auf [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![Ein Bild für die Aufzählungszeichen](picture_for_bullets.png)

Der folgende Python‑Code zeigt, wie man Bildaufzählungen in einer Folie erstellt:

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

![Die Bildaufzählungen](picture_bullets.png)

## **Mehrstufige Liste erstellen**

Verwenden Sie [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw. Die Tiefe steuert nur die Einrückung; setzen Sie [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) für jeden Absatz, wenn die Ebenen ebenfalls Aufzählungszeichen erhalten sollen.

Der folgende Python‑Code zeigt, wie man eine mehrstufige Liste erstellt:

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

## **Vorhandene Liste ändern**

Um die Listformatierung in einer vorhandenen Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren dessen [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/)‑Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können zum Prüfen oder Ändern von aus einer PPT-, PPTX- oder ODP‑Datei geladenen Listen verwendet werden.

Der folgende Python‑Code ändert den ersten Absatz in einem Textfeld, sodass er einen nummerierten Liststil verwendet:

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

## **Tatsächliche Aufzählungswerte lesen**

Beim Extrahieren von Präsentationsinhalten sollten Listensymbole zusammen mit dem Absatztext beibehalten werden. Rufen Sie [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) auf und greifen Sie auf [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) zu, um das effektive Aufzählungsformat zu erhalten. Prüfen Sie dessen [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/), bevor Sie [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) lesen.

Bei nummerierten Listen unterscheiden Sie diese drei Werte:

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) bestimmt das Format, z. B. arabische Zahlen gefolgt von einem Punkt oder Kleinbuchstaben gefolgt von einem Punkt.
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) gibt die Startnummer für eine Gruppe nummerierter Absätze an.
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) gibt das formatierte Symbol für einen bestimmten Absatz zurück. Zum Beispiel liefert das zweite Element in einer Liste, die bei 5 beginnt, `6.`.

Bewahren Sie [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) für jeden Absatz, um dessen Verschachtelungsgrad beizubehalten. Das tatsächliche Symbol codiert nicht die vollständige Hierarchie: Ein verschachteltes Element kann `c.` zurückgeben, anstatt eines kombinierten Labels wie `6.c.`.

Das folgende eigenständige Beispiel erstellt Listen, speichert sie in einer Präsentation und lädt die Präsentation erneut, um für jeden Absatz den Text, die Tiefe, den Aufzählungstyp und den tatsächlichen Wert zu melden. Das kleine blaue Bildsymbol wird aus Inline‑SVG erstellt.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # Erstelle einen Bildmarker ohne eine externe Bilddatei.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

Die Quelllisten werden unten angezeigt.

![Listen, die bei 5 beginnen, verschachtelte Buchstaben‑ und römische Zahlen‑Elemente, ein Symbolmarker, ein Absatz ohne Aufzählungszeichen und ein blaues Bildmarker](actual_bullet_values.png)

Der Bericht stimmt mit den in PowerPoint angezeigten Symbolen überein:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

Für [BulletType.NONE und BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) gibt [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) `None` zurück, nicht einen leeren String. Behandeln Sie diese Typen separat: Der erstgenannte hat kein Symbol, während der letztere das separate Extrahieren des Aufzählungsbildes erfordert. Ein Bildaufzählungszeichen kann nicht ausschließlich durch Extrahieren eines Textsymbols reproduziert werden.

## **FAQ**

**Kann man Aufzählungs‑ und nummerierte Listen in PDF oder Bilder exportieren?**

Ja. Aspose.Slides bewahrt die Listformatierung, wenn das Zielformat die entsprechende Textlayout‑ und Aufzählungs‑Funktionen unterstützt.

**Kann ich Listen in bestehenden Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/)‑Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.