---
title: SmartArt kezelése PowerPoint prezentációkban Python használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezés típusa
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg felépíteni és szerkeszteni a PowerPoint SmartArt-ot az Aspose.Slides for Python via Java segítségével, világos kódminták használatával, amelyek felgyorsítják a dia tervezését és automatizálását."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for Python via Java-val létrehozhat SmartArt-ot, olvashat szöveget a csomópontjairól, módosíthatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat képes szervezeti diagramokat.

## **Szöveg lekérése SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatok szövegének olvasásához iteráljon a [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), majd olvassa el a [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) által visszaadott [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés szabályozza, hogyan vannak elhelyezve és összekapcsolva a csomópontok. Az alábbi példa létrehoz egy SmartArt objektumot a [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` értékkel, módosítja `BasicProcess` értékre, és elmenti a prezentációt. A [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt)‑nek átadott pozíció és méret pontban van megadva. Használja a [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout)‑t az elrendezés módosításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagram elemekként.

Az alábbi példa egy csomópontot ad hozzá egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` értéket használja, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Üzenetet ír ki, ha a csomópont rejtett, és elmenti a diagramot.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A szervezeti diagram elrendezésének lekérése vagy beállítása**

A SmartArt diagramok, amelyek szervezeti diagram elrendezést használnak, a [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) és a [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) határozzák meg, hogyan vannak elrendezve a gyermekcsomópontok egy szülőcsomópont alatt. Például a gyermekcsomópontokat beállíthatja, hogy balról, jobbról vagy mindkét oldalról lógjanak, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) függvényében.

Az alábbi példa létrehoz egy szervezeti diagramot, és beállítja az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre. A 0‑ás nulla alapú index a legfelső szintű első csomópontot választja ki; gyermekcsomópontjai a kiválasztott elrendezést használják. Ezután a módosított prezentáció el van mentve.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy SmartArt elrendezés, amely hierarchikus diagramokhoz készült, és képhasználati helyőrzőket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értéket a SmartArt objektum diára való hozzáadásakor. Ez a példa egy diagramot ment képhasználati helyőrzőkkel; nem tölti fel a helyőrzőket képekkel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Örökölt diagramok alakzatcsoportokká konvertálása**

Amikor egy meglévő prezentációt modernizál, előfordulhat, hogy frissíteni kell egy eredetileg PowerPoint 97–2003-ban létrehozott szervezeti diagramot. Az Aspose.Slides ezeket az örökölt diagramokat [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) objektumokként ábrázolja. Használja a [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) metódust, hogy egy diagramot alakzatcsoporttá alakítson, így egyes vizuális elemeket szerkeszthet. Lásd a [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) részleteket.

A konvertálás egy új csoportot ad a alakzatgyűjteményhez az eredeti diagram eltávolítása nélkül. Sikeres konvertálás után távolítsa el az eredetit a [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) metódussal, hogy elkerülje a duplikált tartalmat. Gyűjtse össze az örökölt diagramokat egy listába a konvertálás előtt, hogy az alakzatok hozzáadása és eltávolítása ne szakítsa meg az iterációt.

Az alábbi példa megnyit egy prezentációt, minden diát keres, a diagramokat alakzatcsoportokká konvertálja, és az így frissített prezentációt PPTX‑ként menti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A mentett prezentáció szerkeszthető alakzatcsoportokat tartalmaz az átalakított örökölt diagramok helyén, az eredeti diagramok már nem vannak jelen. Nyissa meg a PPTX‑et a PowerPointban, hogy szerkessze az egyes csoportok elemeit, például a szöveget, kitöltést vagy pozíciót.

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy megfordítást jobb‑bal (RTL) nyelvek esetén?**

Igen. A [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) metódus megfordítja a diagram irányát balról jobbra és vissza, amikor a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba, miközben megőrzöm a formázást?**

A [a SmartArt alakzat klónozása](/slides/hu/python-java/shape-manipulations/) használható a [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) metódussal, vagy az [az egész dia klónozása](/slides/hu/python-java/clone-slides/) a SmartArt‑ot tartalmazó diával. Mindkét megközelítés megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézethez vagy webes exporthoz?**

A [Dia renderelése](/slides/hu/python-java/convert-powerpoint-to-png/) vagy a teljes prezentáció PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Használja a [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) vagy a [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) metódust, hogy egyedi alternatív szöveget vagy nevet rendeljön a SmartArt alakzathoz, keresse meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) segítségével, majd ellenőrizze, hogy a megtalált alakzat egy [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).