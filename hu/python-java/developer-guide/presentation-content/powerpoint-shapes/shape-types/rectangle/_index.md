---
title: Téglalapok hozzáadása prezentációkhoz Pythonban Java‑n keresztül
linktitle: Téglalap
type: docs
weight: 80
url: /hu/python-java/rectangle/
keywords:
- téglalap hozzáadása
- téglalap létrehozása
- téglalap alakzat
- egyszerű téglalap
- formázott téglalap
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Emelje a PowerPoint prezentációit téglalapok hozzáadásával az Aspose.Slides for Python via Java segítségével—könnyedén tervezhet és módosíthat alakzatokat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk hozzá téglalap alakzatokat a PowerPoint diához az Aspose.Slides használatával. Lefedi egy egyszerű téglalap létrehozását, egy formázott téglalap létrehozását, és a frissített prezentáció mentését PPTX fájlként.

Láthatja továbbá, hogyan alkalmazhat alapvető téglalap formázást, például egyetlen színű kitöltést, vonal színt és vonalvastagságot. Emellett a cikk GYIK-ja olyan kapcsolódó téglalap feladatokra mutat, mint a lekerekített sarkok, képes kitöltések, vizuális hatások, hiperlinkek, alakzatzárolások, exportálási lehetőségek és hatékony tulajdonságok.

## **Téglalap hozzáadása egy diára**

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
- Szerezzen referenciát a diára az indexe alapján.
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) téglalap típusú alakzatot a [addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/) objektumon keresztül érhető el.
- Írja ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy egyszerű téglalapot adtunk hozzá a prezentáció első diájához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Létrehozza a Presentation osztályt, amely a PPTX fájlt képviseli.
presentation = Presentation()
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy téglalap alakzatot.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # A PPTX fájlt lemezre írja.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formázott téglalap hozzáadása egy diára**

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
- Szerezzen referenciát a diára az indexe alapján.
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) téglalap típusú alakzatot a [addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/) objektumon keresztül érhető el.
- Állítsa be a téglalap [fill type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét szilárdra.
- Állítsa be a téglalap színét a [setColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/colorformat/#setColor) metódussal a [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/) objektum szilárd kitöltési színén, amely a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumhoz tartozik.
- Állítsa be a téglalap körvonalának színét.
- Állítsa be a téglalap körvonalának vastagságát.
- Írja ki a módosított prezentációt PPTX fájlként.

A fenti lépéseket az alább bemutatott példában valósítottuk meg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Létrehozza a Presentation osztályt, amely a PPTX fájlt képviseli.
presentation = Presentation()
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy téglalap alakzatot.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formázza a téglalap kitöltését.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formázza a téglalap körvonalát.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # A PPTX fájlt lemezre írja.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Hogyan adhatok hozzá egy lekerekített sarkokkal rendelkező téglalapot?**

Használja a lekerekített sarkú [shape type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/) és állítsa be a sarok sugárát az alakzat tulajdonságaiban; a lekerekítés egyes sarkokra is alkalmazható geometriai beállításokkal.

**Hogyan tölthetek ki egy téglalapot képpel (textúrával)?**

Válassza ki a képes [fill type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/), adja meg a kép forrását, és állítsa be a [stretching/tiling modes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillmode/) beállításait.

**Lehet egy téglalapnak árnyéka és ragyogása?**

Igen. [Külső/belső árnyék, ragyogás és lágy szél](/slides/hu/python-java/shape-effect/) érhetők el állítható paraméterekkel.

**Átalakíthatom a téglalapot gombbal és hiperlinkkel?**

Igen. [Rendeljen hozzá egy hiperlinket](/slides/hu/python-java/manage-hyperlinks/) az alakzat kattintásához (ugrás egy diára, fájlra, webcímre vagy e‑mailre).

**Hogyan védhetem meg a téglalapot a mozgatástól és módosításoktól?**

[Használja az alakzatzárolásokat](/slides/hu/python-java/applying-protection-to-presentation/): megtilthatja a mozgatást, átméretezést, kiválasztást vagy szövegszerkesztést a elrendezés megőrzése érdekében.

**Átalakíthatom-e a téglalapot raszteres képpé vagy SVG‑vé?**

Igen. A [shape renderelésével](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) képpé konvertálhatja a megadott mérettel/méretezéssel, vagy [exportálhatja SVG‑ként](/slides/hu/python-java/create-shape-thumbnails/) vektorként való felhasználáshoz.

**Hogyan tudom gyorsan lekérni egy téglalap tényleges (hatékony) tulajdonságait a téma és öröklődés figyelembevételével?**

[Használja az alakzat hatékony tulajdonságait](/slides/hu/python-java/shape-effective-properties/): az API kiszámított értékeket ad vissza, amelyek figyelembe veszik a téma stílusait, elrendezést és helyi beállításokat, ezáltal leegyszerűsítve a formázás elemzését.