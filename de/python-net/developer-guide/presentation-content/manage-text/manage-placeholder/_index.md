---
title: Placeholders in Präsentationen mit Python verwalten
linktitle: Placeholders verwalten
type: docs
weight: 10
url: /de/python-net/manage-placeholder/
keywords:
- Platzhalter
- Text-Platzhalter
- Bild-Platzhalter
- Diagramm-Platzhalter
- Hinweistext
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Placeholders in Aspose.Slides für Python über .NET mühelos verwalten: Text ersetzen, Hinweistexte anpassen und Bildtransparenz in PowerPoint und OpenDocument festlegen."
---

## **Übersicht**

Platzhalter definieren reservierte Bereiche in Meistern, Layouts und Folien — wie Titel, Inhalt, Bild, Diagramm, Datum/Uhrzeit, Foliennummer und Fußzeile — die steuern, wo Inhalte platziert werden und wie sie Formatierungen erben. Mit Aspose.Slides für Python können Sie Platzhalter auf einer Folie, ihrem Layout oder dem Master entdecken, indem Sie prüfen, dass `shape.placeholder` nicht `None` ist, den `placeholder.type` inspizieren und dann den zugehörigen Inhalt und die Formatierung lesen oder ändern. Die API ermöglicht das Hinzufügen neuer Platzhalter zu einem Master oder Layout, sodass sie an nachgelagerte Folien weitergegeben werden, das Verschieben und Größenändern vorhandener Platzhalter, das Konvertieren eines Platzhalters in eine normale Form, wenn Sie die volle Kontrolle benötigen, oder das Entfernen, um ein Design zu vereinfachen. Die nachstehenden Beispiele zeigen, wie man Platzhalter auflistet, Text und Stil aktualisiert und Layouts konsistent hält, indem Änderungen auf der entsprechenden Ebene angewendet werden.

## **Text in Platzhaltern ändern**

Mit Aspose.Slides für Python können Sie Platzhalter auf Folien in einer Präsentation finden und ändern. Aspose.Slides ermöglicht das Ändern des Textes in einem Platzhalter.

**Voraussetzung:** Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie in Microsoft PowerPoint erstellen.

So verwenden Sie Aspose.Slides, um den Text in einem Platzhalter zu ersetzen:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Iterieren Sie über die Shapes, um den Platzhalter zu finden.
4. Ändern Sie den Text mithilfe des [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), das mit dem [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) verknüpft ist.
5. Speichern Sie die geänderte Präsentation.

Dieser Python‑Code zeigt, wie man den Text in einem Platzhalter ändert:
```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    # Durchlaufen Sie die Shapes, um Platzhalter zu finden.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Ändern Sie den Text in jedem Platzhalter.
            shape.text_frame.text = "This is Placeholder"

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Hinweistext für einen Platzhalter festlegen**

Standard‑ und vorgefertigte Layouts enthalten Platzhalter‑Hinweistexte wie **Click to add a title** oder **Click to add a subtitle**. Mit Aspose.Slides können Sie diese Hinweise durch eigenen Text in den Platzhalter‑Layouts ersetzen.

Das folgende Python‑Beispiel zeigt, wie man den Hinweistext für einen Platzhalter festlegt:
```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Durchlaufen Sie die Shapes, um Platzhalter zu finden.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Bildtransparenz in einem Platzhalter festlegen**

Aspose.Slides ermöglicht das Festlegen der Transparenz eines Hintergrundbildes in einem Text‑Platzhalter. Durch Anpassen der Transparenz des Bildes in diesem Rahmen können Sie je nach Farben entweder den Text oder das Bild hervorheben.

Das folgende Python‑Beispiel zeigt, wie man die Transparenz eines Bild‑Hintergrunds innerhalb einer Form festlegt:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```


## **FAQ**

**Was ist ein Basis‑Platzhalter und wie unterscheidet er sich von einer lokalen Form auf einer Folie?**

Ein Basis‑Platzhalter ist die ursprüngliche Form in einem Layout oder Master, von der die Form der Folie erbt — Typ, Position und einige Formatierungen stammen daraus. Eine lokale Form ist unabhängig; existiert kein Basis‑Platzhalter, findet keine Vererbung statt.

**Wie kann ich alle Titel oder Beschriftungen in einer Präsentation aktualisieren, ohne jede Folie zu durchlaufen?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder im Master. Folien, die auf diesen Layouts/diesem Master basieren, übernehmen die Änderung automatisch.

**Wie steuere ich die Standard‑Kopf‑/Fußzeilen‑Platzhalter — Datum & Uhrzeit, Foliennummer und Fußzeilentext?**

Verwenden Sie die HeaderFooter‑Manager im entsprechenden Geltungsbereich (normale Folien, Layouts, Master, Notizen/Handzettel), um diese Platzhalter ein- oder auszuschalten und deren Inhalt festzulegen.