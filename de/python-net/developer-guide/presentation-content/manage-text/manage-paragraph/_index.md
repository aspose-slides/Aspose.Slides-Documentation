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
- Absatzeinzug
- Hängender Einzug
- Absatzaufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatzeigenschaften
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via .NET Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatzbilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für Python via .NET stellt Text als Hierarchie von TextFrames, Paragraphs und Portions dar:

* [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) stellt den Textcontainer in einer Form dar und bietet Zugriff auf die zugehörige Absatzsammlung.
* [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) repräsentiert einen Absatz in einem TextFrame und bietet Zugriff auf seine Portionen und Absatz‑Formatierung.
* [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann eigenen Text und Zeichen‑Formatierung besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriftarten, Farben, Größen und weiterer Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portionen erstellen**

Die folgenden Schritte erstellen einen TextFrame mit drei Absätzen, die jeweils drei Portionen enthalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame] der Form zu.
5. Verwenden Sie den Standardabsatz und fügen Sie dem TextFrame zwei weitere [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Objekte hinzu.
6. Fügen Sie genügend [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/)‑Objekte hinzu, sodass jeder Absatz drei Portionen enthält. Der Standardabsatz enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
8. Wenden Sie Zeichen‑Formatierung über [Portion.portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/portion_format/) an.
9. Speichern Sie die geänderte Präsentation.

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

### **Eine Aufzählungs‑ oder Nummerierungsliste erstellen**

Aufzählungszeichen und Nummerierung erleichtern das Durchsuchen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [BulletFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/) definiert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame] der Form zu.
5. Entfernen Sie den Standardabsatz aus dem TextFrame.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/type/) auf [BulletType.SYMBOL](https://reference.aspose.com/slides/de/python-net/aspose.slides/bullettype/) und geben Sie das Aufzählungszeichenzeichen an.
8. Legen Sie den Absatztext, Einzug, Aufzählungszeichenfarbe und Aufzählungszeichenhöhe fest.
9. Fügen Sie den Absatz dem TextFrame hinzu.
10. Erstellen Sie einen zweiten Absatz und setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/type/) auf [BulletType.NUMBERED](https://reference.aspose.com/slides/de/python-net/aspose.slides/bullettype/).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Absatz dem TextFrame hinzu.
12. Speichern Sie die Präsentation.

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

### **Bild‑Aufzählungszeichen verwenden**

Bild‑Aufzählungszeichen lassen Sie ein benutzerdefiniertes Bild anstelle eines Symbols oder einer Zahl verwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu und greifen Sie auf dessen [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) zu.
4. Entfernen Sie den Standardabsatz aus dem TextFrame.
5. Laden Sie das Aufzählungszeichen‑Bild und fügen Sie es der Bildsammlung der Präsentation als [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) hinzu.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [BulletFormat.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/type/) auf [BulletType.PICTURE](https://reference.aspose.com/slides/de/python-net/aspose.slides/bullettype/).
8. Weisen Sie das Bild über [BulletFormat.picture](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/picture/) zu und setzen Sie die Aufzählungszeichenhöhe.
9. Fügen Sie den Absatz dem TextFrame hinzu.
10. Speichern Sie die geänderte Präsentation.

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

Setzen Sie [ParagraphFormat.depth](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/depth/) , um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu und entfernen Sie den Standardabsatz aus dessen TextFrame.
3. Erstellen Sie vier Absätze und konfigurieren Sie deren Aufzählungssymbole.
4. Setzen Sie ihre [ParagraphFormat.depth](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/depth/)‑Werte auf `0`, `1`, `2` und `3`.
5. Fügen Sie die Absätze dem TextFrame hinzu und speichern Sie die Präsentation.

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

Verwenden Sie [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) , um die initial angezeigte Nummer für einen nummerierten Absatz festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und fügen Sie einer Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
2. Entfernen Sie den Standardabsatz aus dem TextFrame der Form.
3. Erstellen Sie drei nummerierte Absätze.
4. Setzen Sie [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) für die jeweiligen Absätze auf `2`, `3` bzw. `7`.
5. Fügen Sie die Absätze dem TextFrame hinzu und speichern Sie die Präsentation.

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

## **Absatzlayout und Endeigenschaften steuern**

### **Ersten Zeileneinzug festlegen**

Verwenden Sie die Eigenschaft [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/) , um den Erstzeileneinzug eines Absatzes zu steuern. Diese Eigenschaft verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.margin_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/margin_left/) wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/) wenn Sie nur die erste Zeile verschieben wollen.

Das untenstehende Beispiel erstellt mehrere Absätze und wendet verschiedene [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/)‑Werte an, um zu demonstrieren, wie der Erstzeileneinzug das Absatzlayout beeinflusst.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame] der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/)‑Werte für sie.
6. Fügen Sie die Absätze dem TextFrame hinzu.
7. Speichern Sie die geänderte Präsentation.

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

The result:

![Der Erstzeileneinzug der Absätze](first_line_indent.png)

### **Hängenden Einzug festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erstellen Sie diesen Effekt mit der Eigenschaft [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/) . Setzen Sie `indent` auf einen negativen Wert, um die erste Zeile relativ zum Absatzkörper nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.margin_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/margin_left/) die linke Position des Absatzkörpers, und [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven `margin_left`‑Wert und einen negativen `indent`‑Wert.

Diese Formatierung ist nützlich für Bibliographien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper ausgerichtet werden müssen, nicht unter dem ersten Zeichen der ersten Zeile.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame] der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und setzen Sie für jeden Absatz einen positiven [ParagraphFormat.margin_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/margin_left/)‑Wert.
6. Setzen Sie einen negativen [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/)‑Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem TextFrame hinzu.
8. Speichern Sie die geänderte Präsentation.

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

The result:

![Der hängende Einzug der Absätze](hanging_indent.png)

### **Endabsatz‑Lauf‑Eigenschaften festlegen**

Die Eigenschaft [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) steuert die Formatierung des Absatzendezeichens. Das folgende Beispiel weist dem Endzeichen des zweiten Absatzes eine Schriftgröße und eine lateinische Schriftart zu:

1. Laden Sie eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu und entfernen Sie dessen Standardabsatz.
3. Erstellen Sie zwei Absätze und fügen Sie ihnen Textportionen hinzu.
4. Erstellen Sie ein [PortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/) , um das Endzeichen des zweiten Absatzes zu formatieren.
5. Setzen Sie [PortionFormat.font_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/font_height/) und [PortionFormat.latin_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/latin_font/).
6. Weisen Sie das Format [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) zu und speichern Sie die Präsentation.

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

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphcollection/add_from_html/) , um HTML‑Markup in Absätze und Portionen eines TextFrames zu konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
2. Greifen Sie auf eine Folie zu und fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
3. Greifen Sie auf das [TextFrame] der Form zu und entfernen Sie den Standardabsatz.
4. Lesen Sie die Quell‑HTML‑Datei.
5. Übergeben Sie die HTML‑Zeichenkette an [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphcollection/add_from_html/) .
6. Speichern Sie die geänderte Präsentation.

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

### **Absatztext nach HTML exportieren**

Verwenden Sie [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphcollection/export_to_html/) , um einen ausgewählten Bereich von Absätzen als HTML zu exportieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie auf die Folie zu und finden Sie das [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) , das den Text enthält.
3. Greifen Sie auf das [TextFrame] der Form zu.
4. Rufen Sie [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphcollection/export_to_html/) mit dem Start‑Absatz‑Index und der Anzahl zu exportierender Absätze auf.
5. Schreiben Sie die zurückgegebene HTML‑Zeichenkette in eine Datei.

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Einen Absatz als Bild rendern**

[Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) stellt die Methode `get_image` zum Rendern eines einzelnen Absatzes direkt zur Verfügung. Die Methode liefert ein [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) , das Sie mit [IImage.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/save/) in einer Datei oder einem Stream speichern können. Sie müssen nicht die enthaltende Form rendern oder ein Bitmap manuell zuschneiden.

Die Methode `get_image` kann `None` zurückgeben, wenn der Absatz in seiner übergeordneten Sammlung nicht gefunden wird, keine gültigen Rendering‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis, bevor Sie es speichern, und verwenden Sie das zurückgegebene Bild als Context‑Manager, um dessen Ressourcen freizugeben.

#### **Einen Absatz im Standardskala rendern**

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei die erste Form ein Textfeld ist, das drei Absätze enthält.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

Das folgende Beispiel rendert den zweiten Absatz in einer regulären Textform im Standardskala und speichert das zurückgegebene Bild im PNG‑Format:

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

The result:

![Das Absatzbild](paragraph_to_image_output.png)

#### **Einen Absatz in einer Tabellenzelle mit Skalierung rendern**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an `get_image`, um die Größe des gerenderten Absatzes zu steuern. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in deren erster Zelle bei doppelter Standardbreite und -höhe und speichert das Ergebnis als PNG‑Bild:

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

Ein Skalierungsfaktor von `1` behält diese Achse bei ihrer Standardpixelgröße bei. Zum Beispiel erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß sind wie die Standardmaße, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen in der Regel schärferen Text für Zoom‑ oder Hochauflösungs‑Ausgaben, erhöhen jedoch auch Speicherverbrauch und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Detailgrad. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes beizubehalten; unterschiedliche horizontale und vertikale Faktoren strecken die Ausgabe unabhängig voneinander.

Das Rendern einer ganzen Form mit [Shape.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_image/) bleibt nützlich, wenn die Ausgabe die Füllung, den Rand oder andere visuelle Kontexte der Form enthalten muss. Für ein Bild, das nur den Absatz zeigt, verwenden Sie `Paragraph.get_image`.

## **FAQ**

**Kann ich das Zeilenumbruch‑Verhalten in einem TextFrame vollständig deaktivieren?**

Ja. Setzen Sie [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/wrap_text/) , um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des TextFrames umbrochen werden.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes ermitteln?**

Verwenden Sie [Paragraph.get_rect](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/get_rect/) , um das Begrenzungsrechteck des Absatzes zu erhalten. [Portion.get_rect](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/get_rect/) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatzausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/alignment/) ist eine Einstellung auf Absatzebene und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich die Korrektursprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [PortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/language_id/) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.