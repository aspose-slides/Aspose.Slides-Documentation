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
  - Absatz‑Aufzählungszeichen
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
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Python via .NET – optimieren Sie Ausrichtung, Abstand und Stil in PowerPoint- und OpenDocument‑Präsentationen in Python, um das Publikum zu begeistern."
---
## **Einleitung**

Aspose.Slides stellt die Klassen bereit, die Sie benötigen, um mit PowerPoint‑Text in Python zu arbeiten.

* Aspose.Slides stellt die [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/)‑Klasse zum Erstellen von TextFrame‑Objekten bereit. Ein `TextFrame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Wagenrücklauf getrennt).
* Aspose.Slides stellt die [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse zum Erstellen von Absatz‑Objekten bereit. Ein `Paragraph`‑Objekt kann einen oder mehrere Text‑Portionen enthalten.
* Aspose.Slides stellt die [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/)‑Klasse zum Erstellen von Text‑Portion‑Objekten und zum Festlegen ihrer Formatierungseigenschaften bereit.

Ein `Paragraph`‑Objekt kann Text mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `Portion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen TextFrame hinzufügen, der drei Absätze enthält, wobei jeder Absatz drei Portionen hat:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz zur Zielfolie anhand ihres Index.
1. Fügen Sie der Folie eine rechteckige [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Rufen Sie das mit der [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) verbundene [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) ab.
1. Erstellen Sie zwei [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Objekte und fügen Sie sie der Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu (zusammen mit dem Standardabsatz ergeben sie drei Absätze).
1. Erstellen Sie für jeden Absatz drei [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/)‑Objekte und fügen Sie sie der Portionensammlung dieses Absatzes hinzu.
1. Setzen Sie den Text für jede Portion.
1. Wenden Sie die gewünschten Formatierungen auf jede Text‑Portion an, indem Sie die von [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/) bereitgestellten Eigenschaften verwenden.
1. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code implementiert diese Schritte:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, um eine neue PPTX-Datei zu erstellen.
with slides.Presentation() as presentation:

    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    # Fügen Sie ein rechteckiges AutoShape hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Greifen Sie auf das TextFrame des AutoShape zu.
    text_frame = shape.text_frame

    # Erstellen Sie Absätze und Portionen; die Formatierung wird unten angewendet.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Speichern Sie die PPTX-Datei auf dem Datenträger.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Absätze mit Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufzählungsabsätze sind oft leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Greifen Sie über den Index auf die Zielfolie zu.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der Form zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten Absatz mit der [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse.
1. Setzen Sie den Aufzählungstyp des Absatzes auf `SYMBOL` und geben Sie das Aufzählungszeichen an.
1. Setzen Sie den Text des Absatzes.
1. Legen Sie den Aufzählungseinzug für den Absatz fest.
1. Setzen Sie die Aufzählungsfarbe.
1. Setzen Sie die Aufzählungsgröße (Höhe).
1. Fügen Sie den Absatz zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu.
1. Fügen Sie einen zweiten Absatz hinzu und wiederholen Sie die Schritte 7–12.
1. Speichern Sie die Präsentation.

Dieser Python‑Code zeigt, wie Sie Aufzählungsabsätze hinzufügen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Präsentationsinstanz erstellen.
with slides.Presentation() as presentation:

    # Auf die erste Folie zugreifen.
    slide = presentation.slides[0]

    # AutoShape hinzufügen und darauf zugreifen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Textframe des erstellten AutoShape zugreifen.
    text_frame = shape.text_frame

    # Standardabsatz entfernen.
    text_frame.paragraphs.remove_at(0)

    # Absatz erzeugen.
    paragraph = slides.Paragraph()

    # Aufzählungsstil und Symbol des Absatzes festlegen.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Absatztext festlegen.
    paragraph.text = "Welcome to Aspose.Slides"

    # Aufzählungseinzug festlegen.
    paragraph.paragraph_format.indent = 25

    # Aufzählungsfarbe festlegen.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Aufzählungshöhe festlegen.
    paragraph.paragraph_format.bullet.height = 100

    # Absatz zum Textframe hinzufügen.
    text_frame.paragraphs.add(paragraph)

    # Zweiten Absatz erzeugen.
    paragraph2 = slides.Paragraph()

    # Aufzählungsart und -stil des Absatzes festlegen.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Absatztext festlegen.
    paragraph2.text = "This is numbered bullet"

    # Aufzählungseinzug festlegen.
    paragraph2.paragraph_format.indent = 25

    # Aufzählungsfarbe festlegen.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Aufzählungshöhe festlegen.
    paragraph2.paragraph_format.bullet.height = 100

    # Absatz zum Textframe hinzufügen.
    text_frame.paragraphs.add(paragraph2)

    # Präsentation als PPTX-Datei speichern.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bild‑Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bild‑Aufzählungszeichen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Greifen Sie über den Index auf die Zielfolie zu.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der Form zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten Absatz mit der [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse.
1. Laden Sie ein Bild in ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/).
1. Setzen Sie den Aufzählungstyp auf [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) und weisen Sie das Bild zu.
1. Setzen Sie den Text des Absatzes.
1. Legen Sie den Einzug des Absatzes für das Aufzählungszeichen fest.
1. Setzen Sie die Aufzählungsfarbe.
1. Setzen Sie die Aufzählungshöhe.
1. Fügen Sie den neuen Absatz zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu.
1. Fügen Sie einen zweiten Absatz hinzu und wiederholen Sie die Schritte 8–12.
1. Speichern Sie die Präsentation.

Dieser Python‑Code zeigt, wie Sie Bild‑Aufzählungszeichen hinzufügen und verwalten:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Auf die erste Folie zugreifen.
    slide = presentation.slides[0]

    # Aufzählungsbild laden.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # AutoShape hinzufügen und darauf zugreifen.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # TextFrame des erstellten AutoShape zugreifen.
    text_frame = auto_shape.text_frame

    # Standardabsatz entfernen.
    text_frame.paragraphs.remove_at(0)

    # Neuen Absatz erstellen.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Aufzählungstyp des Absatzes auf Bild setzen und das Bild zuweisen.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Aufzählungshöhe festlegen.
    paragraph.paragraph_format.bullet.height = 100

    # Absatz zum Textframe hinzufügen.
    text_frame.paragraphs.add(paragraph)

    # Präsentation als PPTX-Datei speichern.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Präsentation als PPT-Datei speichern.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Mehrstufige Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungszeichen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Greifen Sie über den Index auf die Zielfolie zu.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten Absatz mit der [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse und setzen Sie seine Tiefe auf 0.
1. Erstellen Sie den zweiten Absatz mit der [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse und setzen Sie seine Tiefe auf 1.
1. Erstellen Sie den dritten Absatz mit der [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse und setzen Sie seine Tiefe auf 2.
1. Erstellen Sie den vierten Absatz mit der [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse und setzen Sie seine Tiefe auf 3.
1. Fügen Sie die neuen Absätze zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie mehrstufige Aufzählungszeichen hinzufügen und verwalten:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Präsentationsinstanz erstellen.
with slides.Presentation() as presentation:

    # Auf die erste Folie zugreifen.
    slide = presentation.slides[0]
    
    # AutoShape hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # TextFrame des erstellten AutoShape zugreifen.
    text_frame = auto_shape.text_frame
    
    # Standardabsatz leeren.
    text_frame.paragraphs.clear()

    # Ersten Absatz hinzufügen.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Aufzählungsebene festlegen.
    paragraph1.paragraph_format.depth = 0

    # Zweiten Absatz hinzufügen.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Aufzählungsebene festlegen.
    paragraph2.paragraph_format.depth = 1

    # Dritten Absatz hinzufügen.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Aufzählungsebene festlegen.
    paragraph3.paragraph_format.depth = 2

    # Vierten Absatz hinzufügen.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Aufzählungsebene festlegen.
    paragraph4.paragraph_format.depth = 3

    # Absätze zur Sammlung hinzufügen.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Präsentation als PPTX-Datei speichern.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Absätze mit benutzerdefinierten nummerierten Listen verwalten**

Die [BulletFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/bulletformat/)‑Klasse bietet die Eigenschaft `numbered_bullet_start_with` (und weitere), um benutzerdefinierte Nummerierung und Formatierung für Absätze zu steuern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Greifen Sie auf die Folie zu, die die Absätze enthalten soll.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der Form zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) und setzen Sie `numbered_bullet_start_with` auf 2.
1. Erstellen Sie den zweiten [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) und setzen Sie `numbered_bullet_start_with` auf 3.
1. Erstellen Sie den dritten [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) und setzen Sie `numbered_bullet_start_with` auf 7.
1. Fügen Sie die Absätze zur Sammlung des [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert das Hinzufügen und Verwalten von Absätzen mit benutzerdefinierter Nummerierung und Formatierung.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape hinzufügen und darauf zugreifen.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # TextFrame des erstellten AutoShape zugreifen.
    text_frame = shape.text_frame

    # Standard vorhandenen Absatz entfernen.
    text_frame.paragraphs.remove_at(0)

    # Ersten nummerierten Punkt erstellen (Start bei 2, Ebenentiefe 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Zweiten nummerierten Punkt erstellen (Start bei 3, Ebenentiefe 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Dritten nummerierten Punkt erstellen (Start bei 7, Ebenentiefe 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Einrückung der ersten Zeile für einen Absatz festlegen**

Verwenden Sie die Eigenschaft [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/), um die Einrückung der ersten Zeile eines Absatzes zu steuern. Diese Eigenschaft verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat.margin_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/margin_left/), wenn Sie den gesamten Absatz verschieben möchten. Verwenden Sie [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/), wenn Sie nur die erste Zeile verschieben wollen.

Das nachstehende Beispiel erstellt mehrere Absätze und wendet verschiedene `indent`‑Werte an, um zu zeigen, wie sich die Einrückung der ersten Zeile auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Zielfolie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie für sie unterschiedliche [indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/)‑Werte.
6. Fügen Sie die Absätze dem TextFrame hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie Sie die Einrückung eines Absatzes festlegen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Einrückung der ersten Zeile der Absätze](first_line_indent.png)

## **Hängende Einrückung für einen Absatz festlegen**

Eine hängende Einrückung ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Eigenschaft [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/). Setzen Sie `indent` auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [ParagraphFormat.margin_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/margin_left/) die linke Position des Absatzkörpers, und [ParagraphFormat.indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Für eine hängende Einrückung setzen Sie einen positiven `margin_left`‑Wert und einen negativen `indent`‑Wert.

Diese Formatierung ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein sollen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Zielfolie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und setzen Sie für jeden einen positiven [margin_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/margin_left/)‑Wert.
6. Setzen Sie einen negativen [indent](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/indent/)‑Wert, um den hängenden Einrückungseffekt zu erzeugen.
7. Fügen Sie die Absätze dem TextFrame hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie Sie eine hängende Einrückung für einen Absatz festlegen:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Hängende Einrückung der Absätze](hanging_indent.png)

## **End‑Absatz‑Portion‑Format verwalten**

Wenn Sie das Styling des „Endes“ eines Absatzes (die nach dem letzten Textportion angewendete Formatierung) steuern möchten, verwenden Sie die Eigenschaft `end_paragraph_portion_format`. Das nachstehende Beispiel wendet eine größere Times‑New‑Roman‑Schrift auf das Ende des zweiten Absatzes an.

1. Erstellen oder öffnen Sie eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Datei.
1. Holen Sie die Zielfolie über den Index.
1. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) hinzu.
1. Verwenden Sie das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der Form und erstellen Sie zwei Absätze.
1. Erstellen Sie ein [PortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/) mit 48 pt Times New Roman und wenden Sie es als End‑Absatz‑Portion‑Format des Absatzes an.
1. Weisen Sie es dem `end_paragraph_portion_format` des zweiten Absatzes zu.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie das End‑Absatz‑Portion‑Format für den zweiten Absatz festlegen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **HTML‑Text in Absätze importieren**

Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Greifen Sie über den Index auf die Zielfolie zu.
1. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) zur Folie hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/).
1. Lesen Sie die Quell‑HTML‑Datei.
1. Erstellen Sie den ersten Absatz mit der [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse.
1. Fügen Sie den HTML‑Inhalt zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) hinzu.
1. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code implementiert diese Schritte zum Importieren von HTML‑Text in Absätze.

```python
import aspose.slides as slides

# Leere Präsentationsinstanz erstellen.
with slides.Presentation() as presentation:

    # Auf die erste Folie der Präsentation zugreifen.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # AutoShape hinzufügen, um den HTML-Inhalt unterzubringen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Alle Absätze im hinzugefügten Textframe leeren.
    shape.text_frame.paragraphs.clear()

    # HTML-Datei laden.
    with open("file.html", "rt") as html_stream:
        # Text aus der HTML-Datei zum Textframe hinzufügen.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Präsentation speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für den Export von Text nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse und laden Sie die Zielpräsentation.
1. Greifen Sie über den Index auf die gewünschte Folie zu.
1. Wählen Sie die Form aus, die den zu exportierenden Text enthält.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) der Form zu.
1. Öffnen Sie einen Dateistream, um die HTML‑Ausgabe zu schreiben.
1. Geben Sie den Start‑Index an und exportieren Sie die gewünschten Absätze.

Dieses Python‑Beispiel zeigt, wie Sie Absatz‑Text nach HTML exportieren.

```python
import aspose.slides as slides

# Präsentationsdatei laden.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Auf die erste Folie der Präsentation zugreifen.
    slide = presentation.slides[0]

    # Ziel-Shape-Index.
    index = 0

    # Shape anhand des Index zugreifen.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Absatzdaten nach HTML schreiben, indem der Start-Absatzindex und die Gesamtzahl der zu exportierenden Absätze angegeben werden.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Einen Absatz als Bild speichern**

In diesem Abschnitt betrachten wir zwei Beispiele, die zeigen, wie ein Textabsatz, dargestellt durch die [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/)‑Klasse, als Bild gespeichert wird. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, über die `get_image`‑Methoden der [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/)‑Klasse, das Berechnen der Grenzen des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Vorgehensweisen ermöglichen das Extrahieren bestimmter Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens **sample.pptx** mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form von der ersten Folie der Präsentation und berechnen die Grenzen des zweiten Absatzes im TextFrame der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild neu gezeichnet, das im PNG‑Format gespeichert wird. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern möchten, während Sie die genauen Abmessungen und die Formatierung des Textes beibehalten.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Die Form im Speicher als Bitmap speichern.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Ein Shape‑Bitmap aus dem Speicher erstellen.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Die Grenzen des zweiten Absatzes berechnen.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße – 1 × 1 Pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Das Shape‑Bitmap zuschneiden, um nur das Absatz‑Bitmap zu erhalten.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Das Ergebnis:

![Das Absatz‑Bild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatz‑Bild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein Bild mit höherer Auflösung beim Export des Absatzes. Die Absatz‑Grenzen werden anschließend unter Berücksichtigung des Skalierungsfaktors berechnet. Skalierung ist besonders nützlich, wenn ein detaillierteres Bild benötigt wird, beispielsweise für den Einsatz in hochwertigem Druckmaterial.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Die Form im Speicher als Bitmap speichern.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Ein Shape‑Bitmap aus dem Speicher erstellen.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Die Grenzen des zweiten Absatzes berechnen.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße – 1 × 1 Pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Das Shape‑Bitmap zuschneiden, um nur das Absatz‑Bitmap zu erhalten.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**Kann ich das Zeilenumbruchverhalten innerhalb eines TextFrames vollständig deaktivieren?**

Ja. Verwenden Sie die Einstellung `wrap_text` des TextFrames ([wrap_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/wrap_text/)), um den Umbruch auszuschalten, sodass Zeilen nicht an den Rändern des Frames umbrechen.

**Wie kann ich die genauen On‑Slide‑Grenzen eines bestimmten Absatzes erhalten?**

Sie können das Begrenzungs‑Rechteck des Absatzes (und sogar einer einzelnen Portion) abfragen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/alignment/) ist eine Absatz‑Ebene‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungssprache nur für einen Teil eines Absatzes (z. B. ein Wort) festlegen?**

Ja. Die Sprache wird auf Portion‑Ebene festgelegt ([PortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/language_id/)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes koexistieren können.