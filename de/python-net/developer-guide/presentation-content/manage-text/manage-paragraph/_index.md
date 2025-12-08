---
title: PowerPoint-Textabsätze in Python verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/python-net/manage-paragraph/
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
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für Python über .NET—optimieren Sie Ausrichtung, Abstand und Stil in PowerPoint- und OpenDocument-Präsentationen in Python, um das Publikum zu fesseln."
---

## **Übersicht**

Aspose.Slides stellt die Klassen bereit, die Sie benötigen, um in Python mit PowerPoint-Text zu arbeiten.

* Aspose.Slides stellt die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) bereit, um Textfeld-Objekte zu erstellen. Ein `TextFrame`-Objekt kann ein oder mehrere Absätze enthalten (jeder Absatz ist durch einen Wagenrücklauf getrennt).
* Aspose.Slides stellt die Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) bereit, um Absatz-Objekte zu erstellen. Ein `Paragraph`-Objekt kann ein oder mehrere Textabschnitte enthalten.
* Aspose.Slides stellt die Klasse [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) bereit, um Textabschnitt-Objekte zu erstellen und deren Formatierungseigenschaften festzulegen.

Ein `Paragraph`-Objekt kann Text mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `Portion`-Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Abschnitten hinzufügen**

Diese Schritte zeigen, wie man ein Textfeld hinzufügt, das drei Absätze enthält, wobei jeder Absatz drei Abschnitte hat:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Holen Sie eine Referenz zur Zielfolie anhand ihres Index.
1. Fügen Sie der Folie eine rechteckige [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Holen Sie das dem [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) zugeordnete [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
1. Erstellen Sie zwei [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)-Objekte und fügen Sie sie der Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) hinzu (zusammen mit dem Standardabsatz ergibt das drei Absätze).
1. Erstellen Sie für jeden Absatz drei [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)-Objekte und fügen Sie sie der Abschnittssammlung dieses Absatzes hinzu.
1. Legen Sie den Text für jeden Abschnitt fest.
1. Wenden Sie das gewünschte Format auf jeden Textabschnitt mithilfe der von [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) bereitgestellten Eigenschaften an.
1. Speichern Sie die geänderte Präsentation.

Der folgende Python-Code implementiert diese Schritte:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, um eine neue PPTX-Datei zu erstellen.
with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Ein rechteckiges AutoShape hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Zugriff auf das TextFrame des AutoShape.
    text_frame = shape.text_frame

    # Absätze und Abschnitte erstellen; die Formatierung wird unten angewendet.
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

    # Die PPTX-Datei auf dem Datenträger speichern.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Absatzaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgezählte Absätze sind oft leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie auf die Zielfolie anhand ihres Index zu.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Setzen Sie den Aufzählungstyp des Absatzes auf `SYMBOL` und geben Sie das Aufzählungszeichen an.
1. Legen Sie den Text des Absatzes fest.
1. Setzen Sie den Einzug des Aufzählungszeichens für den Absatz.
1. Legen Sie die Aufzählungsfarbe fest.
1. Legen Sie die Aufzählungsgröße (Höhe) fest.
1. Fügen Sie den Absatz der Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)'s hinzu.
1. Fügen Sie einen zweiten Absatz hinzu und wiederholen Sie die Schritte 7–12.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt, wie man Aufzählungsabsätze hinzufügt:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstelle eine Präsentationsinstanz.
with slides.Presentation() as presentation:

    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    # Füge ein AutoShape hinzu und greife darauf zu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Greife auf das TextFrame des erstellten AutoShape zu.
    text_frame = shape.text_frame

    # Entferne den Standardabsatz.
    text_frame.paragraphs.remove_at(0)

    # Erstelle einen Absatz.
    paragraph = slides.Paragraph()

    # Setze den Aufzählungsstil und das Symbol des Absatzes.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Setze den Absatztext.
    paragraph.text = "Welcome to Aspose.Slides"

    # Setze den Aufzählungseinzug.
    paragraph.paragraph_format.indent = 25

    # Setze die Aufzählungsfarbe.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Setze die Aufzählungshöhe.
    paragraph.paragraph_format.bullet.height = 100

    # Füge den Absatz dem TextFrame hinzu.
    text_frame.paragraphs.add(paragraph)

    # Erstelle den zweiten Absatz.
    paragraph2 = slides.Paragraph()

    # Setze den Aufzählungstyp und -stil des Absatzes.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Setze den Absatztext.
    paragraph2.text = "This is numbered bullet"

    # Setze den Aufzählungseinzug.
    paragraph2.paragraph_format.indent = 25

    # Setze die Aufzählungsfarbe.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Setze die Aufzählungshöhe.
    paragraph2.paragraph_format.bullet.height = 100

    # Füge den Absatz dem TextFrame hinzu.
    text_frame.paragraphs.add(paragraph2)

    # Speichere die Präsentation als PPTX-Datei.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Bildaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bildaufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie auf die Zielfolie anhand ihres Index zu.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Laden Sie ein Bild in ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) .
1. Setzen Sie den Aufzählungstyp auf [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) und weisen Sie das Bild zu.
1. Legen Sie den Absatztext fest.
1. Setzen Sie den Absatz-Einzug für die Aufzählung.
1. Legen Sie die Aufzählungsfarbe fest.
1. Setzen Sie die Aufzählungshöhe.
1. Fügen Sie den neuen Absatz der Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)'s hinzu.
1. Fügen Sie einen zweiten Absatz hinzu und wiederholen Sie die Schritte 8–12.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt, wie man Bildaufzählungen hinzufügt und verwaltet:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Laden Sie das Aufzählungsbild.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Fügen Sie ein AutoShape hinzu und greifen Sie darauf zu.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Greifen Sie auf das TextFrame des erstellten AutoShape zu.
    text_frame = auto_shape.text_frame

    # Entfernen Sie den Standardabsatz.
    text_frame.paragraphs.remove_at(0)

    # Erstellen Sie einen neuen Absatz.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Setzen Sie den Aufzählungstyp des Absatzes auf Bild und weisen Sie das Bild zu.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Setzen Sie die Aufzählungshöhe.
    paragraph.paragraph_format.bullet.height = 100

    # Fügen Sie den Absatz dem TextFrame hinzu.
    text_frame.paragraphs.add(paragraph)

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Speichern Sie die Präsentation als PPT-Datei.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```


## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie auf die Zielfolie anhand ihres Index zu.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) und setzen Sie seine Tiefe auf 0.
1. Erstellen Sie den zweiten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) und setzen Sie seine Tiefe auf 1.
1. Erstellen Sie den dritten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) und setzen Sie seine Tiefe auf 2.
1. Erstellen Sie den vierten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) und setzen Sie seine Tiefe auf 3.
1. Fügen Sie die neuen Absätze der Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)'s hinzu.
1. Speichern Sie die Präsentation.

Der folgende Python-Code zeigt, wie man mehrstufige Aufzählungen hinzufügt und verwaltet:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstelle eine Präsentationsinstanz.
with slides.Presentation() as presentation:

    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]
    
    # Füge ein AutoShape hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Greife auf das TextFrame des erstellten AutoShape zu.
    text_frame = auto_shape.text_frame
    
    # Lösche den Standardabsatz.
    text_frame.paragraphs.clear()

    # Füge den ersten Absatz hinzu.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setze die Aufzählungsebene.
    paragraph1.paragraph_format.depth = 0

    # Füge den zweiten Absatz hinzu.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setze die Aufzählungsebene.
    paragraph2.paragraph_format.depth = 1

    # Füge den dritten Absatz hinzu.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setze die Aufzählungsebene.
    paragraph3.paragraph_format.depth = 2

    # Füge den vierten Absatz hinzu.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setze die Aufzählungsebene.
    paragraph4.paragraph_format.depth = 3

    # Füge die Absätze zur Sammlung hinzu.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Speichere die Präsentation als PPTX-Datei.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Absätze mit benutzerdefinierten nummerierten Listen verwalten**

Die Klasse [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) stellt die Eigenschaft `numbered_bullet_start_with` (und weitere) bereit, um benutzerdefinierte Nummerierung und Formatierung für Absätze zu steuern.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie auf die Folie zu, die die Absätze enthalten wird.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Erstellen Sie den ersten [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) und setzen Sie `numbered_bullet_start_with` auf 2.
1. Erstellen Sie den zweiten [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) und setzen Sie `numbered_bullet_start_with` auf 3.
1. Erstellen Sie den dritten [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) und setzen Sie `numbered_bullet_start_with` auf 7.
1. Fügen Sie die Absätze der Sammlung des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) hinzu.
1. Speichern Sie die Präsentation.

Der folgende Python-Code demonstriert, wie man Absätze mit benutzerdefinierter Nummerierung und Formatierung hinzufügt und verwaltet.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape hinzufügen und darauf zugreifen.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Das TextFrame des erstellten AutoShape aufrufen.
    text_frame = shape.text_frame

    # Den vorhandenen Standardabsatz entfernen.
    text_frame.paragraphs.remove_at(0)

    # Erstes nummeriertes Element erstellen (Start bei 2, Ebenentiefe 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Zweites nummeriertes Element erstellen (Start bei 3, Ebenentiefe 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Drittes nummeriertes Element erstellen (Start bei 7, Ebenentiefe 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Absatzeinzug festlegen**

Absatzeinzüge helfen, eine klare Lesehierarchie auf einer Folie zu etablieren und die Textausrichtung fein abzustimmen. Das nachstehende Beispiel zeigt, wie man sowohl Gesamteinzüge als auch Erstzeileneinzüge in Aspose.Slides für Python über die Eigenschaften von [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) festlegt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Greifen Sie auf die Zielfolie anhand ihres Index zu.
1. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Fügen Sie dem [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ein [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Kontur des Rechtecks aus.
1. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) über dessen `paragraph_format`-Eigenschaft.
1. Speichern Sie die geänderte Präsentation als PPT-Datei.

Der folgende Python-Code zeigt, wie man Absatzeinzüge festlegt:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Rechteckform hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # TextFrame zum Rechteck hinzufügen.
    text_frame = shape.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # Text so einstellen, dass er in die Form passt.
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Kontur des Rechtecks als solide festlegen.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Ersten Absatz im TextFrame abrufen und dessen Aufzählungszeichen und Einzug festlegen.
    paragraph1 = text_frame.paragraphs[0]
    # Aufzählungsstil und Symbol des Absatzes festlegen.
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.alignment = slides.TextAlignment.LEFT

    paragraph1.paragraph_format.depth = 2
    paragraph1.paragraph_format.indent = 30

    # Zweiten Absatz im TextFrame abrufen und dessen Aufzählungszeichen und Einzug festlegen.
    paragraph2 = text_frame.paragraphs[1]
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = chr(8226)
    paragraph2.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph2.paragraph_format.depth = 2
    paragraph2.paragraph_format.indent = 40

    # Dritten Absatz im TextFrame abrufen und dessen Aufzählungszeichen und Einzug festlegen.
    paragraph3 = text_frame.paragraphs[2]
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph3.paragraph_format.depth = 2
    paragraph3.paragraph_format.indent = 50

    # Präsentation auf die Festplatte schreiben.
    presentation.save("indent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Hängenden Einzug für Absätze festlegen**

Dieser Python-Code zeigt, wie man einen hängenden Einzug für einen Absatz festlegt:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    paragraph1 = slides.Paragraph()
    paragraph1.text = "Example"
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Set Hanging Indent for Paragraphs"
    paragraph3 = slides.Paragraph()
    paragraph3.text = "This Python code shows how to set a hanging indent for a paragraph: "

    paragraph2.paragraph_format.margin_left = 10
    paragraph3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(paragraph1)
    paragraphs.add(paragraph2)
    paragraphs.add(paragraph3)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Format des End‑Abschnitts eines Absatzes verwalten**

Wenn Sie das Styling des „Endes“ eines Absatzes (die nach dem letzten Textabschnitt angewandte Formatierung) steuern müssen, verwenden Sie die Eigenschaft `end_paragraph_portion_format`. Das nachstehende Beispiel wendet eine größere Times‑New‑Roman‑Schrift auf das Ende des zweiten Absatzes an.

1. Erstellen oder öffnen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Datei.
1. Holen Sie die Zielfolie anhand ihres Index.
1. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Verwenden Sie das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form und erstellen Sie zwei Absätze.
1. Erstellen Sie ein [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) das auf 48 pt Times New Roman gesetzt ist und wenden Sie es als End‑Abschnittsformat des Absatzes an.
1. Weisen Sie es dem `end_paragraph_portion_format` des Absatzes zu (gilt für das Ende des zweiten Absatzes).
1. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt, wie man das End‑Abschnittsformat für den zweiten Absatz festlegt:
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

Aspose.Slides bietet erweiterte Unterstützung für den Import von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Greifen Sie auf die Zielfolie anhand ihres Index zu.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) hinzu.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) des [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) zu.
1. Entfernen Sie den Standardabsatz aus dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Lesen Sie die Quell‑HTML‑Datei.
1. Erstellen Sie den ersten Absatz mit der Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) .
1. Fügen Sie den HTML‑Inhalt zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) hinzu.
1. Speichern Sie die geänderte Präsentation.

Der folgende Python-Code implementiert diese Schritte zum Import von HTML‑Text in Absätze.
```python
import aspose.slides as slides

# Erstelle eine leere Presentation-Instanz.
with slides.Presentation() as presentation:

    # Greife auf die erste Folie der Präsentation zu.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Füge ein AutoShape hinzu, um den HTML-Inhalt aufzunehmen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Lösche alle Absätze im hinzugefügten Textframe.
    shape.text_frame.paragraphs.clear()

    # Lade die HTML-Datei.
    with open("file.html", "rt") as html_stream:
        # Füge Text aus der HTML-Datei zum Textframe hinzu.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Speichere die Präsentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Absatztext nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für den Export von Text nach HTML.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Zielpräsentation.
1. Greifen Sie auf die gewünschte Folie anhand ihres Index zu.
1. Wählen Sie die Form aus, die den zu exportierenden Text enthält.
1. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) der Form zu.
1. Öffnen Sie einen Dateistream, um die HTML‑Ausgabe zu schreiben.
1. Geben Sie den Startindex an und exportieren Sie die gewünschten Absätze.

Dieses Python‑Beispiel zeigt, wie man Absatztext nach HTML exportiert.
```python
import aspose.slides as slides

# Lade die Präsentationsdatei.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Greife auf die erste Folie der Präsentation zu.
    slide = presentation.slides[0]

    # Ziel-Shape-Index.
    index = 0

    # Greife auf das Shape nach Index zu.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Schreibe Absatzdaten nach HTML, indem der Startabsatz-Index und die Gesamtzahl der zu exportierenden Absätze angegeben werden.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```


## **Einen Absatz als Bild speichern**

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie man einen Textabsatz, dargestellt durch die Klasse [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/), als Bild speichert. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, über die `get_image`‑Methoden der Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), das Berechnen der Grenzen des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren spezifischer Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Nehmen wir an, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form von der ersten Folie der Präsentation und berechnen anschließend die Grenzen des zweiten Absatzes im Textfeld der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Dieses Verfahren ist besonders nützlich, wenn ein bestimmter Absatz als separates Bild gespeichert werden soll, wobei die genauen Abmessungen und Formatierungen des Textes erhalten bleiben.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Speichern Sie die Form im Speicher als Bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Erstellen Sie ein Form-Bitmap aus dem Speicher.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Berechnen Sie die Grenzen des zweiten Absatzes.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Berechnen Sie die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Zuschneiden des Form-Bitmap, um nur das Absatz-Bitmap zu erhalten.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


Das Ergebnis:

![Das Absatzbild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatzbild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht eine höhere Auflösung beim Export des Absatzes. Die Absatzgrenzen werden anschließend unter Berücksichtigung der Skalierung berechnet. Skalierung kann besonders nützlich sein, wenn ein detaillierteres Bild benötigt wird, etwa für den Einsatz in hochwertigen Druckmaterialien.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Speichern Sie die Form im Speicher als Bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Erstellen Sie ein Form-Bitmap aus dem Speicher.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Berechnen Sie die Grenzen des zweiten Absatzes.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Berechnen Sie die Koordinaten und die Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Zuschneiden des Form-Bitmap, um nur das Absatz-Bitmap zu erhalten.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


## **FAQ**

**Kann ich das Zeilenumbruchverhalten in einem Textfeld vollständig deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des Textfelds ([wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)), um den Umbruch auszuschalten, sodass Zeilen nicht an den Rändern des Felds umbrechen.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes ermitteln?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Abschnitts) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ist eine Absatz‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der einzelnen Abschnittsformatierung.

**Kann ich für nur einen Teil eines Absatzes (z. B. ein Wort) eine Rechtschreib‑Sprache festlegen?**

Ja. Die Sprache wird auf Abschnittsebene festgelegt ([PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes koexistieren können.