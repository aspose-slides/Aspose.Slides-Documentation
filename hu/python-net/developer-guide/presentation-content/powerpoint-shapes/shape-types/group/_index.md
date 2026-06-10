---
title: Csoportos prezentációs alakzatok Pythonban
linktitle: Alakzat Csoport
type: docs
weight: 40
url: /hu/python-net/group/
keywords:
- csoport alakzat
- alakzat csoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan csoportosíthat és szétcsoportosíthat alakzatokat PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Python használatával — gyors, lépésről lépésre útmutató ingyenes kóddal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet csoport alakzatokkal dolgozni az Aspose.Slides-ban. Megmutatja, hogyan adhatunk egy csoport alakzatot egy diára, helyezhetünk el benne alakzatokat, és menthetjük a módosított prezentációt. Bemutatja továbbá, hogyan érhetjük el a csoporton belül tárolt alakzatokat, és olvashatjuk azok `alternative_text` értékeit. Emellett a cikk röviden áttekinti a csoport-alakzatok kapcsolódó képességeit, például a beágyazott csoportokat, z-sorrendet és a zárolási beállításokat.

## **Csoport alakzatok hozzáadása**

Az Aspose.Slides támogatja a csoport alakzatok használatát egy dián. Ez a funkció lehetővé teszi, hogy gazdagabb prezentációkat hozzunk létre több alakzatot egyetlen objektumként kezelve. Hozzáadhat új csoport alakzatokat, elérheti a meglévőket, feltöltheti őket gyermek alakzatokkal, és olvashat vagy módosíthat bármelyik tulajdonságukat. Egy csoport alakzat hozzáadásához a diára:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezzen referenciát egy diára index alapján.  
3. Adjon hozzá egy [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/) elemet a diához.  
4. Adjon alakzatokat az új csoport alakzathoz.  
5. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példa bemutatja, hogyan adhatunk csoport alakzatot egy diához.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy csoport alakzatot a diához.
    group_shape = slide.shapes.add_group_shape()

    # Adjon hozzá alakzatokat a csoport alakzat belsejébe.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Írja ki a PPTX fájlt a lemezre.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Az Alt Text tulajdonság elérése**

Ez a szakasz bemutatja, hogyan olvasható a csoport alakzaton belül elhelyezkedő alakzatok Alt Text értéke egy dián az Aspose.Slides használatával. Az alakzatok Alt Text értékének eléréséhez:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt egy PPTX fájl képviseletére.  
2. Szerezzen referenciát a diára annak indexe alapján.  
3. Érje el a dia alakzatgyűjteményét.  
4. Érje el a [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/) elemet.  
5. Olvassa el az Alt Text tulajdonságot.

Az alábbi példa lekéri a csoport alakzatokban található alakzatok Alt Text értékét.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a PPTX fájl megnyitásához.
with slides.Presentation("group_shape.pptx") as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Érje el a csoport alakzatot.
            for child_shape in shape.shapes:
                # Érje el az Alt Text tulajdonságot.
                print(child_shape.alternative_text)
```

## **GYIK**

**Támogatott-e a beágyazott csoportosítás (csoport egy csoporton belül)?**

Igen. A [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/) rendelkezik egy [parent_group](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/parent_group/) tulajdonsággal, amely közvetlenül jelzi a hierarchia támogatását (egy csoport lehet egy másik csoport gyermekeként).

**Hogyan szabályozhatom a csoport z-sorrendjét a dia többi objektumához képest?**

Használja a [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/)[z_order_position](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/z_order_position/) tulajdonságát a megjelenítési veremben elfoglalt helyének vizsgálatához.

**Megakadályozhatom a mozgatást/szerkesztést/csoportfelbontást?**

Igen. A csoport zárolási szakasza a [group_shape_lock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/group_shape_lock/) segítségével érhető el, ami lehetővé teszi, hogy korlátozza a műveleteket az objektumon.