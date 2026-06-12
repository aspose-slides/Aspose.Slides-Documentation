---
title: Connector
type: docs
weight: 190
url: /nl/python-net/examples/elements/connector/
keywords:
- connector
- connector toevoegen
- connector openen
- connector verwijderen
- vormen opnieuw verbinden
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Teken en beheer connectoren in Python met Aspose.Slides: voeg toe, routeer, herrouteer, stel verbindingspunten, pijlen en stijlen in om vormen te koppelen in PPT, PPTX en ODP."
---
Toont hoe vormen te verbinden met connectoren en hun doelstellingen te wijzigen met **Aspose.Slides for Python via .NET**.

## **Connector toevoegen**

Voeg een connectorvorm in tussen twee punten op de dia.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een gebogen connectorvorm toe.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Connector openen**

Haal de eerste toegevoegde connectorvorm op van een dia.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Open de eerste connector op de dia.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Connector verwijderen**

Verwijder een connector van de dia.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een connector is.
        connector = slide.shapes[0]

        # Verwijder de connector.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Vormen opnieuw verbinden**

Koppel een connector aan twee vormen door start- en einddoel toe te wijzen.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Voeg de eerste rechthoekvorm toe.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Voeg de tweede rechthoekvorm toe.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Voeg een gebogen connectorvorm toe.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Verbind het begin van de connector met de eerste vorm.
        connector.start_shape_connected_to = shape1
        # Verbind het einde van de connector met de tweede vorm.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```