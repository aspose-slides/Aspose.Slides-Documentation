---
title: Platzhalter verwalten
type: docs
weight: 10
url: /python-net/manage-placeholder/
keywords: "Platzhalter, Platzhaltertext, Eingabetext, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Ändern Sie Platzhaltertext und Eingabetext in PowerPoint-Präsentationen mit Python"
---

## **Text im Platzhalter ändern**

Mit [Aspose.Slides für Python über .NET](/slides/python-net/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, den Text in einem Platzhalter zu ändern.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Sie können eine solche Präsentation in der Standardanwendung Microsoft PowerPoint erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter in dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Durchlaufen Sie die Formen, um den Platzhalter zu finden.
4. Typkonvertieren Sie die Platzhalterform zu einer [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) und ändern Sie den Text über das [`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) das mit der [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) assoziiert ist.
5. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt, wie man den Text in einem Platzhalter ändert:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Durchläuft die Formen, um den Platzhalter zu finden
    for shp in sld.shapes:
        if shp.placeholder != None:
            # Ändert den Text in jedem Platzhalter
            shp.text_frame.text = "Dies ist ein Platzhalter"

    # Speichert die Präsentation auf der Festplatte
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Eingabetext in einem Platzhalter festlegen**
Standard- und vordefinierte Layouts enthalten Platzhalter-Eingabetexte wie ***Klicken Sie, um einen Titel hinzuzufügen*** oder ***Klicken Sie, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Eingabetexte in Platzhalter-Layouts einfügen.

Dieser Python-Code zeigt Ihnen, wie Sie den Eingabetext in einem Platzhalter festlegen:

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # Durchläuft die Folie
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # PowerPoint zeigt "Klicken Sie, um einen Titel hinzuzufügen".
                text = "Titel hinzufügen"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # Fügt einen Untertitel hinzu.
                text = "Untertitel hinzufügen"

            shape.text_frame.text = text

            print("Platzhalter mit Text: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **Transparenz des Platzhalterbildes festlegen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Textplatzhalter festzulegen. Durch das Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben des Textes und des Bildes).

Dieser Python-Code zeigt, wie Sie die Transparenz für einen Bildhintergrund (innerhalb einer Form) festlegen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```