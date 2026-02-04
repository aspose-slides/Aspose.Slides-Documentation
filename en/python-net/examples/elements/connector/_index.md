---
title: Connector
type: docs
weight: 190
url: /python-net/examples/elements/connector/
keywords:
- connector
- add connector
- access connector
- remove connector
- reconnect shapes
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Draw and control connectors in Python with Aspose.Slides: add, route, reroute, set connection points, arrows and styles to link shapes in PPT, PPTX and ODP."
---

Shows how to connect shapes with connectors and change their targets using **Aspose.Slides for Python via .NET**.

## **Add a Connector**

Insert a connector shape between two points on the slide.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a bent connector shape.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Connector**

Retrieve the first connector shape added to a slide.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first connector on the slide.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Remove a Connector**

Delete a connector from the slide.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the fist shape is a connector.
        connector = slide.shapes[0]

        # Remove the connector.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Reconnect Shapes**

Attach a connector to two shapes by assigning start and end targets.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Add the first rectangle shape.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Add the second rectangle shape.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Add a bent connector shape.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Connect the start of the connector to the first shape.
        connector.start_shape_connected_to = shape1
        # Connect the end of the connector to the second shape.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```
