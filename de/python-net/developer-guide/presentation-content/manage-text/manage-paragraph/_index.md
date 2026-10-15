---
title: PowerPoint-Textabsätze in Python verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatz‑Einzug
- Hängender Einzug
- Absatz‑Aufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatz‑Eigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via .NET Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML‑Inhalte und Absatz‑Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides for Python via .NET stellt Text als Hierarchie von TextFrames, Absätzen und Portionen dar:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) repräsentiert den Textcontainer in einer Form und bietet Zugriff auf die Absatzsammlung.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) repräsentiert einen Absatz in einem TextFrame und bietet Zugriff auf seine Portionen und die Absatz‑Formatierung.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann eigene Zeichen‑ und Absatzformatierung besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriften, Farben, Größen und weiterer Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

Erstellen Sie Absätze im TextFrame einer Form und verwenden Sie Portionen, um einzelne Textläufe zu formatieren. Dieser Abschnitt zeigt, wie Sie mehrere Portionen in jedem Absatz kombinieren und unterschiedliche Farben, Schriftgrößen und Stile anwenden.

### **Absätze mit mehreren Portionen erstellen**

Das folgende Python‑Beispiel erstellt drei Absätze, die jeweils drei Textläufe in ihrer [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/)‑Sammlung enthalten. Es verwendet den Standardabsatz und dessen leere Portion erneut, fügt dann die übrigen Absätze und Portionen hinzu. Die Formatierung wird über [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) angewendet: Die erste Portion jedes Absatzes ist rot, fett und 15 pt; die zweite ist blau, kursiv und 18 pt. Die dritte Portion behält die Standardformatierung bei:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Aufzählungs‑ und Nummerierungslisten erstellen**

Organisieren Sie Absatztext in Listen mit Symbolen, Zahlen oder benutzerdefinierten Bildern. Die Beispiele in diesem Abschnitt behandeln Aufzählungsformatierung, mehrstufige Listen und benutzerdefinierte Startzahlen.

### **Aufzählungs‑ oder Nummerierungsliste erstellen**

Aufzählungen und Nummerierungen erleichtern das Scannen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) definiert.

Dieses Python‑Beispiel fügt einem TextFrame ein Symbol‑Bullet und ein nummeriertes Element hinzu. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) wählt den Bullet‑Typ, während [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) das Symbol liefert und [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) den Nummerierungsstil festlegt. Beide Elemente verwenden schwarze Bullets mit einer Höhe von 100 % und einem Absatz‑Einzug von 25 pt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Bild‑Bullets verwenden**

Bild‑Bullets ermöglichen die Verwendung eines benutzerdefinierten Bildes anstelle eines Symbols oder einer Zahl.

Das Beispiel setzt voraus, dass sich `bullets.png` im Arbeitsverzeichnis befindet. Dieses Python‑Beispiel fügt der Präsentations‑Bildsammlung ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) hinzu und verwendet es als Absatz‑Bullet. Es setzt [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) auf Bild‑Bullet und weist das Bild über [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) zu. [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) wird auf 100 % gesetzt, um die Bullet‑Größe relativ zum Absatztext zu bestimmen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Mehrstufige Liste erstellen**

Setzen Sie [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/), um Absätze auf unterschiedlichen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

Dieses Python‑Beispiel weist vier Absätzen die Werte 0 bis 3 für [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) zu und erzeugt so eine Hierarchie innerhalb eines TextFrames. Jeder Absatz verwendet ein Symbol‑Bullet, wobei [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) zwischen einem runden Bullet und einem Bindestrich wechselt, um benachbarte Ebenen zu unterscheiden:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Nummerierte Listenelemente mit benutzerdefinierten Werten starten**

Verwenden Sie [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/), um die Anfangszahl für einen nummerierten Absatz festzulegen.

Dieses Python‑Beispiel setzt [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) auf Nummerierung für drei Absätze und weist [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) die Werte 2, 3 und 7 zu. Der Startwert wird für jeden Absatz separat konfiguriert, sodass die angezeigten Zahlen übersprungen werden können:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Absatzlayout und End‑Eigenschaften steuern**

Passen Sie Absatz‑Ränder und Einzüge an, um die Position der ersten Zeile und umgebrochener Zeilen zu steuern. Sie können das Absatz‑Endzeichen auch separat vom sichtbaren Text formatieren.

### **Ersten‑Zeilen‑Einzug setzen**

Verwenden Sie die Eigenschaft [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/), um den Einzug der ersten Zeile eines Absatzes zu steuern. Diese Eigenschaft verschiebt nur die erste Zeile relativ zum linken Absatz‑Rand. Ein positiver Wert bewegt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/), wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/), wenn Sie nur die erste Zeile verschieben wollen.

Das folgende Beispiel gibt drei Absätzen denselben [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) von 20 pt und [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) Werte von 0, 20 und 40 pt. Die ersten Zeilen beginnen bei zunehmend größeren Versätzen, während umgebrochene Zeilen denselben linken Rand behalten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der Erste‑Zeilen‑Einzug der Absätze](first_line_indent.png)

### **Hängenden Einzug setzen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Eigenschaft [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Setzen Sie `indent` auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) die linke Position des Absatzkörpers, und [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven `margin_left`‑Wert und einen negativen `indent`‑Wert.

Diese Formatierung ist nützlich für Literaturverzeichnisse, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

Das folgende Python‑Beispiel kombiniert [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) Werte von 40 und 60 pt mit [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) Werten von -20 und -30 pt. In jedem Absatz beginnt die erste Zeile links von den umgebrochenen Zeilen; der zweite Absatz hat einen tieferen hängenden Einzug:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der hängende Einzug der Absätze](hanging_indent.png)

### **End‑Absatz‑Lauf‑Eigenschaften setzen**

Die Eigenschaft [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) steuert die Formatierung des Absatz‑Endzeichens. Das Beispiel lädt `Test.pptx`, das mindestens eine Folie enthalten muss, und erstellt ein [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) mit [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) = 48 pt und [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) = Times New Roman. Es weist dieses Format dem Endzeichen des zweiten Absatzes zu, wobei die sichtbaren Textportionen unverändert bleiben:

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenderte Zeilen zählen**

Für Absatz‑Regeln, die automatisches Umbrechen und Interpunktion am Zeilenende beeinflussen, siehe [Control Line Breaking](/slides/de/python-net/text-formatting/#control-line-breaking) und [Control Hanging Punctuation](/slides/de/python-net/text-formatting/#control-hanging-punctuation).

Verwenden Sie [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/), um die nach Textlayout von einem Absatz belegten Zeilen zu zählen, einschließlich automatischem Umbrechen. Dies ist nützlich, um Textlänge und Layout in Vorlagen zu prüfen.

Ein Absatz ist ein Element in [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), und er kann mehrere gerenderte Zeilen belegen. Ein expliziter Zeilenumbruch innerhalb eines Absatzes erzwingt eine neue Zeile, ohne einen weiteren Absatz zu erzeugen. Automatisches Umbrechen erzeugt Zeilen basierend auf der verfügbaren Breite, ohne explizite Zeilenumbrüche im Text einzufügen. Daher liefert das Zählen von Absätzen oder Zeilenumbruch‑Zeichen nicht die gerenderte Zeilenzahl.

Das folgende Beispiel erstellt eine Textform, zählt ihre Zeilen, verengt die Form und ersetzt dann den Text durch einen kürzeren String. Das Beispiel aktiviert [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) und deaktiviert [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/), sodass die Formbreite das Umbrechen steuert, ohne den Text automatisch zu verkleinern oder die Form zu skalieren. Jede Messung nutzt [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Formabmessungen werden in Punkten angegeben. Abschließend fügt das Beispiel einen weiteren Absatz hinzu und summiert die Zeilenzähler über das TextFrame hinweg:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Bei diesem Text und diesen Abmessungen erhöht das Verengen der Form die Zeilenzahl, während das Ersetzen des Textes durch den kurzen String sie reduziert. Exakte Zahlen können je nach Schriftverfügbarkeit, Schriftgröße, Rändern, Einzügen, Umbrechen und Autofit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriften und Layout‑Einstellungen, wenn Sie eine Vorlage prüfen.

Die Zeilenzahl allein bestimmt nicht, ob Text über den Container hinausläuft. Die verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstände sowie das Autofit‑Verhalten sind ebenfalls relevant; selbst eine einzelne Zeile kann die verfügbare Breite überschreiten, wenn Umbrechen deaktiviert ist.

## **Absatzinhalt importieren und exportieren**

Verwenden Sie HTML, um Text in eine Präsentation zu bringen oder vorhandene Absätze für die Weiterverwendung zu exportieren. Dieser Abschnitt zeigt außerdem, wie einzelne Absätze als Bilder gerendert werden, einschließlich Absätzen in Tabellenzellen.

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/), um HTML‑Markup in Absätze und Portionen eines TextFrames zu konvertieren.

Dieses Python‑Beispiel liest HTML aus `file.html` im Arbeitsverzeichnis und übergibt das Markup an [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Es löscht den Standardabsatz des TextFrames, sodass das Frame nur den importierten Inhalt enthält. Die rechteckige Form lässt an jeder Folienkante einen Rand von 10 pt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Absatz‑Text nach HTML exportieren**

Verwenden Sie [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/), um einen ausgewählten Absatzbereich als HTML zu exportieren. Beim Wiederverwenden von Präsentationstext auf einer Website möchten Sie möglicherweise lokale Hervorhebungen beibehalten, ohne die Schriftarten, Größen oder Textbox‑Stile der Präsentation zu übernehmen. Setzen Sie [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/), um zu steuern, wie weit der Exporter der Formatierungs‑Vererbung folgt.

Laden Sie [die Beispielpräsentation](text-inheritance.pptx) herunter und platzieren Sie sie im Arbeitsverzeichnis der Anwendung. Ihre erste Folie enthält eine Textform mit dem Text „Inherited text; explicit red 18pt“. Der Input nutzt bewusst mehrere Formatierungsebenen:

- Der Standard‑Textstil der Präsentation liefert Calibri mit 28 pt.
- Der Text‑Stil des TextFrames erster Ebene liefert blauen Text und Kursivschrift.
- Der Absatz setzt fett kursiven Text explizit.
- Die zweite Portion, „explicit red 18pt“, setzt roten Text und 18 pt Größe explizit.

Das folgende vollständige Beispiel exportiert dieselben Absätze dreimal. Es übergibt [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) an die Export‑Methode und schreibt jedes Ergebnis in eine separate UTF‑8‑HTML‑Datei:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Das erzeugte HTML enthält das folgende CSS für die erste Portion, „Inherited text; “. Die Tabelle listet die relevanten Deklarationen; andere erzeugte Eigenschaften wurden der Übersichtlichkeit halber ausgelassen.

| Ausgabe | Relevantes CSS für die erste Portion | Darstellung |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text mit 28 pt in Calibri, falls die Schrift verfügbar ist. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text; die umgebende Seite oder der Browser liefert Schriftart und Größe. |
| `ParagraphOnly.html` | `font-weight:bold` | Fetter Text; Schriftart, Größe, Farbe und Kursivstil werden von der umgebenden Seite oder dem Browser bereitgestellt. |

Die zweite Portion behält `color:#ff0000`, `font-size:18pt` und `font-weight:bold` in allen drei Ausgaben bei. Sie behält ebenfalls Kursivschrift bei `ALL` und `TEXT_BOX`, jedoch nicht bei `PARAGRAPH_ONLY`. Das Einschränken der Vererbung entfernt daher nicht die ausdrücklich zugewiesene Formatierung eines Absatzes oder einer Portion.

Öffnen Sie die Dateien im selben Browser, um sie zu vergleichen. In den beiden eingeschränkten Modi werden ausgelassene CSS‑Eigenschaften durch die Styles der Zielseite oder die Browser‑Defaults aufgelöst, sodass das Ergebnis vom Verwendungsort des HTML abhängt.

### **Einen Absatz als Bild rendern**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) rendert einen einzelnen Absatz direkt und gibt ein [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) in einer Datei oder einem Stream. Das Rendern der enthaltenden Form oder das manuelle Zuschneiden eines Bitmaps ist nicht erforderlich.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) kann `None` zurückgeben, wenn der Absatz nicht in seiner übergeordneten Sammlung gefunden wird, keine gültigen Render‑Grenzen besitzt oder nicht gerendert werden kann. Prüfen Sie das Ergebnis vor dem Speichern und geben Sie das zurückgegebene Bild nach Gebrauch frei.

#### **Absatz im Standardskala rendern**

Das Beispiel verwendet `sample.pptx`, eine Präsentation mit einer Folie, deren erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

Das folgende Beispiel wählt den zweiten Absatz (Index 1) aus und ruft [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) ohne Skalierungsparameter auf. Es prüft, dass die Form den benötigten Absatz enthält und dass das Rendering ein Bild liefert, bevor [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) zum Speichern im PNG‑Format aufgerufen wird. Der Kontext‑Manager gibt die Bild‑Ressourcen nach dem Gebrauch frei.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Das Ergebnis:

![Das Absatz‑Bild](paragraph_to_image_output.png)

#### **Absatz in Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/), die die Parameter `scale_x` und `scale_y` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in ihrer ersten Zelle mit dem doppelten Standard‑Breiten‑ und Höhenfaktor und speichert das Ergebnis als PNG‑Bild.

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Ein Skalierungsfaktor von `1` behält die Standard‑Pixelgröße bei. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß wie die Standard‑Abmessungen sind, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen in der Regel schärferen Text für Zoom‑ oder hochauflösende Ausgaben, erhöhen jedoch Speicher‑ und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Detail. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes zu erhalten; unterschiedliche horizontale und vertikale Faktoren strecken die Ausgabe unabhängig voneinander.

Das Rendern einer gesamten Form mit [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) bleibt sinnvoll, wenn das Ergebnis die Füllung, den Rand oder andere visuelle Kontexte der Form enthalten muss. Für ein Bild, das nur einen Absatz zeigt, verwenden Sie [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **FAQ**

**Kann ich das Zeilen‑Umbrechen in einem TextFrame vollständig deaktivieren?**

Ja. Setzen Sie [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) auf deaktiviert, damit Zeilen nicht an den Rändern des TextFrames umbrochen werden.

**Wie erhalte ich die genauen On‑Slide‑Grenzen eines bestimmten Absatzes?**

Verwenden Sie [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/), um das Begrenzungs‑Rechteck des Absatzes zu erhalten. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ist eine Absatz‑Einstellung und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

Um Portionen unterschiedlicher Schriftgrößen innerhalb einer Zeile vertikal auszurichten, siehe [Align Fonts Within a Line](/slides/de/python-net/text-formatting/#align-fonts-within-a-line).

**Kann ich die Rechtschreib‑Sprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.