---
title: CsoportAlak
type: docs
weight: 170
url: /hu/python-net/examples/elements/group-shape/
keywords:
- csoport
- csoport alak hozzáadása
- csoport alak elérése
- csoport alak eltávolítása
- alakok felbontása
- kód példák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Dolgozzon csoport alakokkal Pythonban az Aspose.Slides használatával: hozza létre és bontsa fel, rendezze át a gyermek alakokat, állítsa be a transzformációkat és a határokat a PowerPoint és az OpenDocument között."
---
Példák alakcsoportok létrehozására, elérésére, felbontására és eltávolítására a **Aspose.Slides for Python via .NET** használatával.

## **Csoport alak hozzáadása**

Hozzon létre egy csoportot, amely két alap alakot tartalmaz.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Csoport alak hozzáadása.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Csoport alak elérése**

Szerezze meg az első csoport alakot egy diáról.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Az első csoport alak elérése a dián.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Csoport alak eltávolítása**

Törölje a csoport alakot a diáról.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alak egy csoport alak.
        group = slide.shapes[0]

        # A csoport alak eltávolítása.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Alakok felbontása**

Mozgassa az alakokat egy csoport konténeréből kívülre.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alak egy csoport alak.
        group = slide.shapes[0]

        # Az alakok áthelyezése a csoportból.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```