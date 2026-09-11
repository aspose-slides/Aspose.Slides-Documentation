---
title: SmartArt alakzatcsomópontok kezelése prezentációkban Python segítségével
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/python-java/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- alcsomópont
- csomópont hozzáadása
- csomópont pozíció
- csomópont elérése
- csomópont eltávolítása
- egyéni pozíció
- segítő csomópont
- kitöltési formátum
- csomópont renderelése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "SmartArt alakzatcsomópontok kezelése PPT és PPTX fájlokban az Aspose.Slides for Python via Java segítségével. Szerezzen világos kódrészleteket és tippeket, hogy hatékonyabbá tegye prezentációit."
---
## **Áttekintés**

A PowerPoint‑prezentációkban a SmartArt‑grafikákat csomópontok szervezik, amelyek szöveget tartalmaznak és meghatározzák a diagram felépítését. Az Aspose.Slides lehetővé teszi ezen SmartArt‑csomópontok programozott kezelését: új csomópontok és alcsomópontok hozzáadása, alcsomópontok beszúrása egy adott pozícióban, meglévő csomópontok elérése, valamint a szövegük, szintjük és pozíciójuk olvasása.

Ez a cikk bemutatja a SmartArt‑alak csomópontok kezelését. Megmutatja, hogyan lehet csomópontokat eltávolítani, alcsomópontokkal index vagy pozíció alapján dolgozni, egy segítő csomópontot normál csomóponttá változtatni, a SmartArt csomópont alakzatok pozícióját, méretét és forgását módosítani, a csomópont kitöltési formátumát beállítani, valamint egy SmartArt alcsomóponthoz bélyegképet generálni.

## **SmartArt‑csomópont hozzáadása**
Az Aspose.Slides for Python via Java API-t biztosít a SmartArt‑alakok kezeléséhez. A következő példa egy csomópontot és egy alcsomópontot ad hozzá egy SmartArt‑alakhoz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt‑alakot tartalmazó prezentációt.  
2. Szerezze meg az első diát az indexe alapján.  
3. Iteráljon végig az összes alakzatot az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.  
5. [Adj hozzá egy új csomópontot](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnodecollection/#addNode) a SmartArt alakzat [node collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/#getAllNodes) gyűjteményéhez, és állítsa be a szövegét a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) segítségével.  
6. [Adj hozzá](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnodecollection/#addNode) egy [alcsomópontot](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#getChildNodes) az új csomóponthoz, és állítsa be a szövegét a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) segítségével.  
7. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt‑csomópont hozzáadása egy adott pozícióban**
A következő példa egy alcsomópontot ad hozzá egy SmartArt‑csomóponton belül egy adott pozícióban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezze meg az első diát az indexe alapján.  
3. Adjon hozzá egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) alakzatot a [StackedList](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartlayouttype/#StackedList) elrendezéssel a diára.  
4. Érje el az első csomópontot a hozzáadott SmartArt alakzatban.  
5. Adj hozzá egy alcsomópontot a kiválasztott csomóponthoz a 2. pozícióban a [addNodeByPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) használatával, és állítsa be a szövegét.  
6. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt‑csomópont elérése**
A következő példa a SmartArt‑alak csomópontjait érinti. A [getLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/#getLayout) által visszaadott elrendezés csak olvasható, és a SmartArt‑alak hozzáadásakor kerül beállításra.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt‑alakot tartalmazó prezentációt.  
2. Szerezze meg az első diát az indexe alapján.  
3. Iteráljon végig az összes alakzatot az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.  
5. Iteráljon végig az összes [nodes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/#getAllNodes) elemen a SmartArt alakzatban.  
6. Olvassa ki és mutassa a SmartArt csomópont pozícióját, szintjét és szövegét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt‑alcsomópont elérése**
A következő példa a SmartArt‑alak egyes csomópontjainak alcsomópontjait érinti.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt‑alakot tartalmazó prezentációt.  
2. Szerezze meg az első diát az indexe alapján.  
3. Iteráljon végig az összes alakzatot az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.  
5. Iteráljon végig az összes [nodes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/#getAllNodes) elemen a SmartArt alakzatban.  
6. Minden csomópontnál iteráljon végig az [child nodes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#getChildNodes) elemein.  
7. Olvassa ki és mutassa az [child node](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#getChildNodes) pozícióját, szintjét és szövegét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt‑alcsomópont elérése egy adott pozícióban**
A következő példa egy alcsomópontot ér el egy adott indexen a szülőcsomópont gyűjteményében.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezze meg az első diát az indexe alapján.  
3. Adjon hozzá egy SmartArt alakzatot a [StackedList](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartlayouttype/#StackedList) elrendezéssel.  
4. Érje el a hozzáadott SmartArt alakzatot.  
5. Érje el a 0. indexű csomópontot a SmartArt alakzatban.  
6. Érje el az 1. indexű alcsomópontot a [get_Item](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnodecollection/#get_Item) használatával.  
7. Olvassa ki és mutassa az [child node](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#getChildNodes) pozícióját, szintjét és szövegét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt‑csomópont eltávolítása**
A következő példa egy csomópontot távolít el egy SmartArt alakzatból.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt‑alakot tartalmazó prezentációt.  
2. Szerezze meg az első diát az indexe alapján.  
3. Iteráljon végig az összes alakzatot az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.  
5. Ellenőrizze, hogy a [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) alakzat legalább egy csomópontot tartalmaz.  
6. Válassza ki a törlendő SmartArt csomópontot.  
7. Távolítsa el a kiválasztott csomópontot a [removeNode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnodecollection/#removeNode) használatával.  
8. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt‑csomópont eltávolítása egy adott pozícióból**
A következő példa egy alcsomópontot távolít el egy adott indexen a SmartArt‑csomópont gyűjteményében.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt‑alakot tartalmazó prezentációt.  
2. Szerezze meg az első diát az indexe alapján.  
3. Iteráljon végig az összes alakzatot az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.  
5. Ha létezik, érje el a 0. indexű SmartArt csomópontot.  
6. Ellenőrizze, hogy a kiválasztott SmartArt csomópontnak legalább két alcsomópontja van.  
7. Távolítsa el az 1. indexű alcsomópontot a [removeNode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnodecollection/#removeNode) használatával.  
8. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egy alcsomópont egyéni pozíciójának beállítása egy SmartArt objektumban**
Az Aspose.Slides for Python via Java támogatja a [SmartArtShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartshape/) pozíciójának beállítását a [setX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setX) és [setY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setY) metódusokkal. A következő példa egyedi pozíciót, méretet és forgást állít be a SmartArt csomópont alakzatok számára. Új csomópontok hozzáadása újraszámolja az összes csomópont pozícióját és méretét. Az egyéni pozícionálás lehetővé teszi a csomópontok kívánt elrendezését.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Segítő csomópont ellenőrzése**
{{% alert color="info" title="Megjegyzés" %}} 

Ez a szakasz a programozottan az Aspose.Slides for Python via Java segítségével a prezentációs diákra hozzáadott SmartArt alakzatokat vizsgálja.

{{% /alert %}} 

A következő forrás SmartArt alakzatot használja a példában.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Ábra: Forrás SmartArt alakzat a dián**|

A következő példa az asszisztens csomópontokat azonosítja a SmartArt csomópontgyűjteményben, és normál csomópontokká változtatja őket.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a SmartArt‑alakot tartalmazó prezentációt.  
2. Szerezze meg az első diát az indexe alapján.  
3. Iteráljon végig az összes alakzatot az első dián.  
4. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) példány-e.  
5. Iteráljon végig a SmartArt alakzat összes csomópontján, és ellenőrizze, hogy [Assistant Nodes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#isAssistant)‑ek-e.  
6. Minden asszisztens csomópontot változtasson normál csomóponttá.  
7. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Ábra: Asszisztens csomópontok módosítva egy SmartArt alakzaton a dián**|

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for Python via Java lehetővé teszi egyedi SmartArt alakzatok hozzáadását és a kitöltési formátumuk beállítását. Ez a cikk bemutatja, hogyan hozhatók létre és érhetők el a SmartArt alakzatok, valamint hogyan állítható be a kitöltési formátum az Aspose.Slides for Python via Java‑val.

Kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen egy diát az indexe alapján.  
3. Adjon hozzá egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) alakzatot a [ClosedChevronProcess](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) elrendezéssel.  
4. Állítsa be a [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getFillFormat) formátumot a SmartArt alakzat csomópontjainál.  
5. Írja ki a módosított prezentációt PPTX fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt alcsomópont bélyegképének generálása**
A SmartArt alcsomópont bélyegképének generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. [Adj hozzá egy SmartArt alakzatot](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addSmartArt).  
3. Szerezzen egy csomópontot az indexe alapján.  
4. Szerezze meg a bélyegkép képet.  
5. Mentse a bélyegkép képet a kívánt képformátumban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Támogatott a SmartArt animáció?**

Igen. A SmartArt‑ot szabályos alakzatként kezelik, így alkalmazhatóak a [szabványos animációk](/slides/hu/python-java/shape-animation/) (belépés, kilépés, hangsúlyozás, mozgási útvonal), valamint beállítható az időzítés. Szükség esetén az SmartArt‑csomópontok belső alakzatait is animálhatja.

**Hogyan találhatom meg megbízhatóan egy adott SmartArt‑ot a dián, ha annak belső azonosítója ismeretlen?**

Keressen és állítson be [alternatív szöveget](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getAlternativeText). Az egyedi alternatív szöveg beállítása a SmartArt‑ra lehetővé teszi a programozott keresést azonosítók nélkül.

**Megmarad a SmartArt megjelenése a prezentáció PDF‑be konvertálásakor?**

Igen. Az Aspose.Slides a [PDF export](/slides/hu/python-java/convert-powerpoint-to-pdf/) során magas vizuális pontossággal rendereli a SmartArt‑ot, megőrizve a layoutot, színeket és hatásokat.

**Kivonhatok-e egy teljes SmartArt képet (előnézet vagy jelentés céljából)?**

Igen. A SmartArt‑alakzatot renderelheti [raszteres formátumokba](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) vagy [SVG‑be](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#writeAsSvgToBytes) a skálázható vektoros kimenethez, ami alkalmas bélyegképekhez, jelentésekhez vagy webes használatra.