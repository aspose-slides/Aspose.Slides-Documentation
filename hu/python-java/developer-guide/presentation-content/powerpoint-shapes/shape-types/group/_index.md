---
title: Csoportos prezentációs alakzatok Pythonon keresztül Java
linktitle: Alakzatcsoport
type: docs
weight: 40
url: /hu/python-java/group/
keywords:
- csoport alakzat
- alakzatcsoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan csoportosíthat és szétcsoportosíthat alakzatokat PowerPoint prezentációkban az Aspose.Slides for Python via Java használatával – egy lépésről-lépésre útmutató ingyenes Python kóddal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk csoport alakzatokkal az Aspose.Slides-ban. Megmutatja, hogyan vehetünk fel egy csoport alakzatot egy diára, helyezhetünk el benne alakzatokat, és menthetjük a frissített bemutatót. Emellett bemutatja, hogyan érhetők el a csoporton belül tárolt alakzatok, és hogyan olvasható ki a helyettesítő szövegük a [getAlternativeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getAlternativeText) használatával. Továbbá a cikk röviden tárgyalja a kapcsolódó csoport alakzat funkciókat, mint például a beágyazott csoportok, a z-sorrend és a zárolási beállítások.

## **Csoport alakzat hozzáadása**

Az Aspose.Slides támogatja a csoport alakzatokkal való munkát a diáikon. Ez a funkció segíti a fejlesztőket gazdagabb prezentációk létrehozásában. Az Aspose.Slides for Python via Java támogatja a csoport alakzatok hozzáadását és elérését. Csoport alakzatot tölthet fel alakzatokkal, vagy elérheti annak tulajdonságait. A csoport alakzat hozzáadásához egy diára az Aspose.Slides for Python via Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diához annak indexe alapján.
1. Adjon hozzá egy csoport alakzatot a diához.
1. Helyezzen el alakzatokat a csoport alakzatban.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi példa egy csoport alakzatot ad hozzá egy diához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Példányosítja a Presentation osztályt.
presentation = Presentation()
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Eléri a dia alakzatgyűjteményét.
    slide_shapes = slide.getShapes()

    # Csoport alakzatot ad hozzá a diához.
    group_shape = slide_shapes.addGroupShape()

    # Alakzatokat ad hozzá a csoport alakzathoz.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Beállítja a csoport alakzat keretét.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # A PPTX fájlt leírja a lemezen.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alternatív szöveg elérése**

Ez a szakasz bemutatja, hogyan érhető el a csoporton belüli alakzatok alternatív szövege egy dián. Az alternatív szöveg eléréséhez az Aspose.Slides for Python via Java használatával:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályú példányt, amely egy PPTX fájlt képvisel.
1. Szerezzen referenciát egy diához annak indexe alapján.
1. Érje el a dia alakzatgyűjteményét.
1. Érje el a csoport alakzatot.
1. Olvassa ki az alakzatok alternatív szövegét a [getAlternativeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getAlternativeText) használatával.

Az alábbi példa a csoporton belüli alakzatok alternatív szövegét olvassa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Példányosítja a Presentation osztályt, amely a PPTX fájlt képviseli.
presentation = Presentation("AltText.pptx")
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Eléri egy alakzatot a dia alakzatgyűjteményében.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Eléri a csoporton belüli alakzatokat.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Kiolvassa az alternatív szöveget.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Támogatott a beágyazott csoport (csoport egy csoporton belül)?**

Igen. A [GroupShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshape/) rendelkezik egy [getParentGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getParentGroup) metódussal, amely jelzi a hierarchia támogatását: egy csoport lehet egy másik csoport alávetettje.

**Hogyan szabályozhatom a csoport z-sorrendjét a dia többi objektumához képest?**

Használja a [GroupShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshape/) objektum [getZOrderPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getZOrderPosition) metódusát a megjelenítési rétegben való pozíciójának ellenőrzéséhez.

**Megakadályozhatom a mozgatást, szerkesztést vagy csoport felbontását?**

Igen. A csoport zárolásai a [getGroupShapeLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshape/#getGroupShapeLock) segítségével érhetők el, amely lehetővé teszi a műveletek korlátozását az objektumon.