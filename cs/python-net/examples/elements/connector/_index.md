---
title: Spojnice
type: docs
weight: 190
url: /cs/python-net/examples/elements/connector/
keywords:
- spojnice
- přidat spojnici
- přístup ke spojnici
- odstranit spojnici
- znovu propojit tvary
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vykreslete a ovládejte spojnice v Pythonu pomocí Aspose.Slides: přidejte, směrujte, přesměrujte, nastavte připojovací body, šipky a styly pro propojení tvarů v PPT, PPTX a ODP."
---
Ukazuje, jak propojit tvary pomocí spojnic a změnit jejich cíle pomocí **Aspose.Slides for Python via .NET**.

## **Přidat spojnici**

Vložte tvar spojnice mezi dva body na snímku.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidejte zakřivený tvar spojnice.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Získat spojnici**

Načtěte první tvar spojnice přidaný do snímku.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Přístup k první spojnici na snímku.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Odstranit spojnici**

Odstraňte spojnici ze snímku.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je spojnice.
        connector = slide.shapes[0]

        # Odstraňte spojnici.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Znovu připojit tvary**

Připojte spojnici k dvěma tvarům přiřazením počátečního a koncového cíle.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Přidejte první obdélníkový tvar.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Přidejte druhý obdélníkový tvar.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Přidejte zakřivený tvar spojnice.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Připojte počátek spojnice k prvnímu tvaru.
        connector.start_shape_connected_to = shape1
        # Připojte konec spojnice ke druhému tvaru.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```