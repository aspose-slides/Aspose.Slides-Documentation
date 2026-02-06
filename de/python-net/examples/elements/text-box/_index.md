---
title: Textfeld
type: docs
weight: 40
url: /de/python-net/examples/elements/text-box/
keywords:
- Textfeld
- Textfeld hinzufügen
- Textfeld zugreifen
- Textfeld entfernen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und formatieren Sie Textfelder in Python mit Aspose.Slides: Schriftarten, Ausrichtung, Zeilenumbruch, automatische Größenanpassung festlegen und Links hinzufügen, um Folien für PowerPoint und OpenDocument zu optimieren."
---
In Aspose.Slides wird ein **Textfeld** durch ein `AutoShape` dargestellt. Praktisch jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder Kontur und zeigt nur Text an.

Dieser Leitfaden erklärt, wie man Textfelder programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

## **Textfeld hinzufügen**

Ein Textfeld ist einfach ein `AutoShape` ohne Füllung oder Kontur und mit etwas formatiertem Text. So erstellt man eins:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Erstelle eine Rechteckform (standardmäßig ausgefüllt mit Rahmen und ohne Text).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Entferne Füllung und Rahmen, um es wie ein typisches Textfeld aussehen zu lassen.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Setze die Textformatierung.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Weise den eigentlichen Textinhalt zu.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Hinweis:** Jedes `AutoShape`, das ein nicht leeres `TextFrame` enthält, kann als Textfeld fungieren.

## **Textfelder nach Inhalt zugreifen**

Um alle Textfelder zu finden, die ein bestimmtes Schlüsselwort enthalten (z. B. „Slide“), iteriere über die Formen und prüfe deren Text:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Nur AutoShapes können editierbaren Text enthalten.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Etwas mit dem passenden Textfeld machen.
                    pass
```

## **Textfelder nach Inhalt entfernen**

Dieses Beispiel findet und löscht alle Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Formen finden, die entfernt werden sollen und AutoShapes sind, die das Wort "Slide" enthalten.
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Jede passende Form von der Folie entfernen.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tipp:** Erstelle immer eine Kopie der Formensammlung, bevor du sie während einer Iteration änderst, um Fehler wegen der Modifikation der Sammlung zu vermeiden.