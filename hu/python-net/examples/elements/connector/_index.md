---
title: Csatlakozó
type: docs
weight: 190
url: /hu/python-net/examples/elements/connector/
keywords:
- csatlakozó
- csatlakozó hozzáadása
- csatlakozó elérése
- csatlakozó eltávolítása
- alakzatok újracsatlakoztatása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Kösse össze és vezérelje a csatlakozókat Pythonban az Aspose.Slides segítségével: hozzáadás, útvonal, újraútvonal, csatlakozási pontok, nyilak és stílusok beállítása alakzatok összekapcsolásához PPT, PPTX és ODP formátumokban."
---
Bemutatja, hogyan lehet alakzatokat összekapcsolni csatlakozókkal, és megváltoztatni azok célpontjait a **Aspose.Slides for Python via .NET** használatával.

## **Csatlakozó hozzáadása**

Helyezzen el egy csatlakozó alakzatot a dia két pontja közé.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Hozzáad egy ívelt csatlakozó alakzatot.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Csatlakozó elérése**

Hozza vissza az első, a diára hozzáadott csatlakozó alakzatot.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Hozzáfér az első csatlakozóhoz a dián.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Csatlakozó eltávolítása**

Törölje a csatlakozót a diáról.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy csatlakozó.
        connector = slide.shapes[0]

        # Eltávolítja a csatlakozót.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Alakzatok újracsatlakoztatása**

Csatlakoztassa a csatlakozót két alakzathoz a kezdő- és végcélpontok hozzárendelésével.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Hozzáadja az első téglalap alakzatot.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Hozzáadja a második téglalap alakzatot.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Hozzáad egy ívelt csatlakozó alakzatot.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # A csatlakozó kezdőpontját az első alakzathoz csatlakoztatja.
        connector.start_shape_connected_to = shape1
        # A csatlakozó végpontját a második alakzathoz csatlakoztatja.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```