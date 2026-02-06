---
title: Hyperlink
type: docs
weight: 130
url: /de/python-net/examples/elements/hyperlink/
keywords:
- Hyperlink
- Hyperlink hinzufügen
- Hyperlink abrufen
- Hyperlink entfernen
- Hyperlink aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Hyperlinks in Python mit Aspose.Slides hinzufügen, bearbeiten und entfernen: Linktext, Formen, Folien, URLs und E-Mail; Ziele und Aktionen für PPT, PPTX und ODP festlegen."
---
Demonstriert das Hinzufügen, Zugreifen, Entfernen und Aktualisieren von Hyperlinks auf Formen mithilfe von **Aspose.Slides for Python via .NET**.

## **Hyperlink hinzufügen**

Erstellen Sie eine Rechteckform mit einem Hyperlink, der auf eine externe Website verweist.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlink abrufen**

Lesen Sie Hyperlink-Informationen aus dem Textteil einer Form.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Hyperlink entfernen**

Entfernen Sie den Hyperlink aus dem Text einer Form.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlink aktualisieren**

Ändern Sie das Ziel eines bestehenden Hyperlinks. Verwenden Sie `HyperlinkManager`, um Text zu bearbeiten, der bereits einen Hyperlink enthält, was dem sicheren Aktualisieren von Hyperlinks in PowerPoint entspricht.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Das Ändern eines Hyperlinks innerhalb des bestehenden Textes sollte über
        # HyperlinkManager erfolgen, anstatt die Eigenschaft direkt zu setzen.
        # Dies ahmt nach, wie PowerPoint Hyperlinks sicher aktualisiert.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```