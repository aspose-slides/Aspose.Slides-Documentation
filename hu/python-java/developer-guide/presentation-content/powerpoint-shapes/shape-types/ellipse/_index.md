---
title: Ellipszisek hozzáadása prezentációkhoz Pythonban Java használatával
linktitle: Ellipszis
type: docs
weight: 30
url: /hu/python-java/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, formázhat és kezelhet ellipszis alakzatokat az Aspose.Slides for Python via Java könyvtárban PPT és PPTX prezentációkban – Python kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk ellipszis alakzatokat a PowerPoint diákhoz az Aspose.Slides használatával. Tartalmazza egy egyszerű ellipszis létrehozását, egy formázott ellipszis létrehozását, és a frissített bemutató mentését PPTX fájlként. Emellett érinti a kapcsolódó kérdéseket, mint az ellipszis helyzetének és méretének kezelése, a rétegezési sorrend vezérlése, valamint animációs hatások alkalmazása.

## **Ellipszis létrehozása**

Egyszerű ellipszis hozzáadásához a bemutató egy kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
- Szerezzen referenciát egy diára az indexe alapján.
- Adj hozzá egy ellipszist a [ShapeCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/) objektum [addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) metódusával.
- Mentse a módosított bemutatót PPTX fájlként.

Az alábbi példa egy ellipszist ad hozzá az első diához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# A Presentation osztály példányosítása, amely a PPTX fájlt képviseli.
presentation = Presentation()
try:
    # Az első dia lekérése.
    slide = presentation.getSlides().get_Item(0)

    # Ellipszis alakzat hozzáadása.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # A PPTX fájl írása a lemezre.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formázott ellipszis létrehozása**

Formázott ellipszis hozzáadásához egy diára kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
- Szerezzen referenciát egy diára az indexe alapján.
- Adj hozzá egy ellipszist a [ShapeCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/) objektum [addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) metódusával.
- Állítsa be az ellipszis kitöltést szilárd típusra.
- Állítsa be az ellipszis kitöltő színét a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumhoz tartozó [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/) objektum [getSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getSolidFillColor) metódusával.
- Állítsa be az ellipszis körvonalának színét.
- Állítsa be az ellipszis körvonalának vastagságát.
- Mentse a módosított bemutatót PPTX fájlként.

Az alábbi példa egy formázott ellipszist ad hozzá a bemutató első diájához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# A Presentation osztály példányosítása, amely a PPTX fájlt képviseli.
presentation = Presentation()
try:
    # Az első dia lekérése.
    slide = presentation.getSlides().get_Item(0)

    # Ellipszis alakzat hozzáadása.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Az ellipszis kitöltésének formázása.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Az ellipszis körvonalának formázása.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # A PPTX fájl írása a lemezre.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Hogyan állíthatom be egy ellipszis pontos helyzetét és méretét a dia egységeihez viszonyítva?**

A koordinátákat és méreteket általában **pontban** adják meg. A kiszámítható eredmények érdekében a számításokat a dia méretén alapozza, és a szükséges millimétereket vagy hüvelyket konvertálja pontba, mielőtt értékeket adna meg.

**Hogyan helyezhetek el egy ellipszist más objektumok felett vagy alatt (a rétegezési sorrend vezérlése)?**

Módosítsa az objektum rajzolási sorrendjét úgy, hogy előre hozza vagy hátra küldi. Ez lehetővé teszi, hogy az ellipszis átfedje a többi objektumot, vagy feltárja az alatta lévőket.

**Hogyan animálhatom egy ellipszis megjelenését vagy hangsúlyát?**

[Alkalmazza](/slides/hu/python-java/shape-animation/) a belépés, hangsúly vagy kilépés effektusokat az alakzatra, és állítsa be a trigger-eket és az időzítést, hogy meghatározza, mikor és hogyan játszódik le az animáció.