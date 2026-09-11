---
title: SmartArt kezelése PowerPoint prezentációkban Python használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezéstípus
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg PowerPoint SmartArt építését és szerkesztését az Aspose.Slides for Python via Java segítségével, tiszta kódmintákkal, amelyek felgyorsítják a diákkészítést és az automatizálást."
---
## **Áttekintés**

SmartArt egy PowerPoint diagram, amely csomópontokból, csomópontalakzatokból és egy elrendezésből áll. Az Aspose.Slides for Python via Java segítségével létrehozhat SmartArt-ot, kiolvashatja a szöveget a csomópontjaiból, módosíthatja az elrendezést, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és képes szervezeti diagramokat hozhat létre képekkel.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont több alakzatot is tartalmazhat. A látható szöveg beolvasásához iteráljon a [SmartArt.getAllNodes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/#getAllNodes), majd olvassa el a [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartshape/#getTextFrame) által visszaadott [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/).

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

A SmartArt elrendezés szabályozza, hogyan vannak elrendezve és összekapcsolva a csomópontok. Az alábbi példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` értékkel, átállítja `BasicProcess` értékre, és elmenti a bemutatót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#isHidden) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. Rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

Az alábbi példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` értéket használja, és ellenőrzi a csomópont rejtett állapotát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Az szervezeti diagram elrendezésének lekérdezése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti diagram elrendezést használnak, a [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) és a [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) határozzák meg, hogyan vannak elrendezve a gyermekcsomópontok egy szülőcsomópont alatt. Például beállíthatja, hogy a gyermekcsomópontok balra, jobbra vagy mindkét oldalra függjenek, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/organizationchartlayouttype/) függvényében.

Az alábbi példa egy szervezeti diagramot hoz létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` értékre állítja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy olyan SmartArt elrendezés, amely hierarchia diagramokhoz készült, és képtartalék helyeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` értéket a SmartArt objektum diára való felvitelekor.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy megfordítást jobb‑bal (RTL) nyelvek esetén?**

Igen. A [SmartArt.setReversed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/#setReversed) metódus megfordítja a diagram irányát balról jobbra és jobbról balra, vagy vissza, ha a kiválasztott SmartArt elrendezés támogatja a megfordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik bemutatóba, miközben megtartom a formázást?**

A [klónozza a SmartArt alakzatot](/slides/hu/python-java/shape-manipulations/) a [ShapeCollection.addClone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addClone) vagy a [klónozza a teljes diát](/slides/hu/python-java/clone-slides/) a SmartArt-ot tartalmazó diát másolhatja. Mindkét módszer megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézethez vagy webes exporthoz?**

[Renderelje a diát](/slides/hu/python-java/convert-powerpoint-to-png/) vagy a teljes bemutatót PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot a dián, ha több is van?**

Állítson be egy egyedi [Shape.getAlternativeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getAlternativeText) vagy [Shape.getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getName) értéket a SmartArt alakzaton, keresse meg ezt az értéket a [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getShapes) segítségével, majd ellenőrizze, hogy a megtalált alakzat egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/).