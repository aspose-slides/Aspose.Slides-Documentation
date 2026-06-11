---
title: Anslutning
type: docs
weight: 190
url: /sv/python-net/examples/elements/connector/
keywords:
- anslutning
- lägg till anslutning
- åtkomst till anslutning
- ta bort anslutning
- återanslut former
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Rita och kontrollera anslutningar i Python med Aspose.Slides: lägg till, rutera, omrutera, ställ in anslutningspunkter, pilar och stilar för att länka former i PPT, PPTX och ODP."
---
Visar hur man ansluter former med anslutningar och ändrar deras mål med **Aspose.Slides for Python via .NET**.

## **Lägg till en anslutning**

Infoga en anslutningsform mellan två punkter på bilden.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till en böjd anslutningsform.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till en anslutning**

Hämta den första anslutningsformen som lagts till på en bild.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första anslutningen på bilden.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Ta bort en anslutning**

Ta bort en anslutning från bilden.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att den första formen är en anslutning.
        connector = slide.shapes[0]

        # Ta bort anslutningen.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Återanslut former**

Fäst en anslutning till två former genom att tilldela start- och slutmål.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Lägg till den första rektangelformen.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Lägg till den andra rektangelformen.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Lägg till en böjd anslutningsform.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Anslut början av anslutningen till den första formen.
        connector.start_shape_connected_to = shape1
        # Anslut slutet av anslutningen till den andra formen.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```