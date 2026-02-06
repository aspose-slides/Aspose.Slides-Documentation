---
title: Verbinder
type: docs
weight: 190
url: /de/python-net/examples/elements/connector/
keywords:
- Verbinder
- Connector hinzufügen
- Connector abrufen
- Connector entfernen
- Formen neu verbinden
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Zeichnen und steuern Sie Connectors in Python mit Aspose.Slides: Hinzufügen, Routen, Umleiten, Festlegen von Verbindungspunkten, Pfeilen und Stilen, um Formen in PPT, PPTX und ODP zu verknüpfen."
---
Zeigt, wie man Formen mit Connectors verbindet und deren Ziele ändert, wobei **Aspose.Slides for Python via .NET** verwendet wird.

## **Connector hinzufügen**

Fügen Sie eine Connector-Form zwischen zwei Punkten auf der Folie ein.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Eine gebogene Connector-Form hinzufügen.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf einen Connector**

Rufen Sie die zuerst zur Folie hinzugefügte Connector-Form ab.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Greifen Sie auf den ersten Connector auf der Folie zu.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Connector entfernen**

Löschen Sie einen Connector von der Folie.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, die erste Form ist ein Connector.
        connector = slide.shapes[0]

        # Connector entfernen.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formen neu verbinden**

Verbinden Sie einen Connector mit zwei Formen, indem Sie Start- und Endziele zuweisen.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Die erste Rechteckform hinzufügen.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Die zweite Rechteckform hinzufügen.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Eine gebogene Connector-Form hinzufügen.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Den Start des Connectors mit der ersten Form verbinden.
        connector.start_shape_connected_to = shape1
        # Das Ende des Connectors mit der zweiten Form verbinden.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```