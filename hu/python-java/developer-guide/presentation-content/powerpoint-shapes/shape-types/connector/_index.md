---
title: Csatlakozók kezelése prezentációkban Pythonon keresztül Java-val
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/python-java/connector/
keywords:
- csatlakozó
- csatlakozó típus
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- kapcsolódási hely
- beállítási pont
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá, csatolhat, újratervezhet, állíthat be és vizsgálhat meg egyenes, hajlított és ívelt PowerPoint csatlakozókat az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A csatlakozó egy vonal, amely két alakzathoz is rögzítve maradhat, ha bármelyik alakzat mozog. Végződései a csatlakozási pontokhoz kapcsolódnak, amelyeket a PowerPoint zöld pontokként jelenít meg. Néhány hajlított és ívelt csatlakozó is tartalmaz beállítási pontokat, amelyek narancssárga pontokként jelennek meg, és az egyes csatlakozó szegmensek helyzetét szabályozzák.

Az Aspose.Slides a csatlakozókat a [Connector](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/) osztályon keresztül képviseli. Létrehozhatja őket, a végüket alakzatokhoz csatolhatja, kiválaszthatja a csatlakozási pontokat, újratervezheti őket, és módosíthatja a beállítási pontokkal rendelkező csatlakozók geometriáját.

## **Csatlakozó típusok**

A [ShapeType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/) osztály tartalmaz egyenes, hajlított és ívelt csatlakozó előbeállításokat. Az alábbi táblázat a rendelkezésre álló csatlakozó geometriákat és az egyes előbeállítások által meghatározott beállítási pontok számát mutatja.

| Csatlakozó | Kép | Beállítási pontok száma |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

A beállítási pontok száma és jelentése a kiválasztott csatlakozó előbeállítás része. Ne tételezze fel, hogy két különböző csatlakozó típus ugyanazt a gyűjtemény elrendezést mutatja.

## **Két alakzat összekapcsolása**

Használja a [ShapeCollection.addConnector](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addConnector) metódust egy csatlakozó hozzáadásához, és a [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/#setStartShapeConnectedTo) és a [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/#setEndShapeConnectedTo) metódusokat a végek csatlakoztatásához. Miután mindkét vég csatlakoztatva van, a [Connector.reroute](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/#reroute) kiválaszt egy rövid útvonalat az alakzatok között.

A következő példa egy ellipszist és egy téglalapot köt össze egy hajlított csatlakozóval:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Figyelmeztetés" %}}
A [reroute](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/#reroute) hívása módosíthatja a [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) és a [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex) értékeket. A újratervezés után rendelje hozzá a konkrét csatlakozási pontokat, ha azoknak rögzítve kell maradniuk.
{{% /alert %}}

## **Csatlakozási pont választása**

Minden csatlakoztatható alakzat a [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getConnectionSiteCount) segítségével jelzi a helyek számát. Érvényesítse a kívánt, nullától kezdődő hely indexet, mielőtt egy csatlakozó végéhez rendeli; a helyek száma alakzat geometria szerint változik.

Ez a példa a csatlakozót a ellipszis egy adott helyéhez csatolja, ha az a hely létezik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Csatlakozó pont beállítása**

A beállítási pontokkal rendelkező csatlakozók ezeket a [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/python-java/aspose.slides/geometryshape/#getAdjustments) segítségével tehetik elérhetővé. Vizsgálja meg minden [AdjustValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/) elemet, és ellenőrizze a [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getType) értékét, mielőtt a [setRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#setRawValue) segítségével módosítaná. Az előre beállított alakzatbeállítások azonosításának általános szabályait a [Shape Manipulation](/slides/hu/python-java/shape-manipulations/) leírja.

A csatlakozó beállítások száma, sorrendje, jelentése és érvényes értéktartománya a csatlakozó előbeállítástól függ. A beállítás típusa csak olvasható, míg a beállítás értéke írható. A csak-olvasásra szánt [getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getName) metódus további azonosítást nyújt, ha egy csatlakozó több, ugyanazon szemantikus típusú beállítást tartalmaz.

### **Út akadály körül**

A következő elrendezésben egy [BentConnector5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector5) csatlakozó a két alakzat között áthalad egy harmadik alakzaton:

![connector-obstruction](connector-obstruction.png)

Ez a kód létrehozza az akadálytörő csatlakozót:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A függőleges hajlítás mozgatása megváltoztatja az útvonalat, így a csatlakozó megkerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Ahelyett, hogy feltételeznénk, hogy a gyűjtemény index `1` mindig a függőleges hajlítást jelöli, ez a példa a [ConnectorBendPositionY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) keresésével módosítja azt csak akkor, ha a várt szemantikus típus jelen van:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Egy [BentConnector5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector5) két [ConnectorBendPositionX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) és egy [ConnectorBendPositionY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) beállítással rendelkezik. Ha a szükséges típus többször is előfordul, vizsgálja meg a [getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getName) metódust és az adott előbeállítás ismert geometriáját, mielőtt kiválasztaná. Ha egy beállítás a [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#Custom) értéket adja vissza, tekintse jelentését és tartományát előre beállított specifikusnak, és ne módosítsa, amíg ez a szerződés nem ismert.

## **A beállítási értékek összekapcsolása a csatlakozó geometriával**

Hajlított csatlakozók esetén a beállítási értékek felhasználhatók az egyes szegmensek pozícióinak becslésére. Ezek a számítások a csatlakozó előbeállításra jellemzőek:

- A [BentConnector4](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector4) általában egy [ConnectorBendPositionX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) és egy [ConnectorBendPositionY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) beállítást tesz elérhetővé.
- Ezekhez a hajlítási pozíciókhoz a [getRawValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getRawValue) által visszaadott érték `100000.0`-val való osztása adja meg a csatlakozó keret szélességének vagy magasságának arányát, ahogy az alábbi példák is mutatják.
- A csatlakozó kerete elforgatható vagy tükrözhető, ezért a keret koordinátákat át kell alakítani, mielőtt a dia koordinátáival összehasonlítanák.

A következő példák először a [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getType) segítségével azonosítják a beállításokat. Nem tekintik a gyűjtemény indexeket hordozható azonosítóknak.

### **Forgatás nélküli csatlakozó**

A kezdeti elrendezés két szöveges alakzatot tartalmaz, amelyeket egy [BentConnector4](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#BentConnector4) köt össze:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa vizsgálja a csatlakozót, és lekéri a horizontális és vertikális hajlítási beállításait:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Mindkét hajlítás megváltoztatásához keresse meg a várt típusokat, és csak akkor módosítsa az értékeket, ha mindkettő megtalálásra került:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény egy olyan csatlakozó, amelynek a horizontális és vertikális szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Miután a szemantikus típusok ismertek, értékeik átalakíthatók a csatlakozó-keret koordinátáira. Ez a példa egy vékony téglalapot rajzol a két hajlítási beállítás által vezérelt vertikális szegmens fölé:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az útmutató alakzat jelöli a kiszámított szegmenst:

![connector-adjusted-2](connector-adjusted-2.png)

### **Elforgatott vagy tükrözött csatlakozó**

Amikor ugyanaz a csatlakozó geometria függőlegesen van elorientálva, a [Shape.getFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getFrame), a [ShapeFrame.getFlipH](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeframe/#getFlipH), és a [ShapeFrame.getFlipV](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapeframe/#getFlipV) értékek befolyásolják a csatlakozó-keret koordinátákról a dia koordinátákra történő átalakítást.

Ez a példa létrehozza és módosítja a függőlegesen orientált csatlakozót:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A módosított csatlakozó függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges forgatási szög `alpha` esetén egy csatlakozó-keret pont `(x, y)` elforgatható a keret középpontja `(x0, y0)` körül:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90 fokos orientációt, és egy piros útmutatót rajzol a megfelelő csatlakozó szegmens fölé:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A piros útmutató jelöli a koordinátatranszformáció után kiszámított szegmenst:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt előbeállításokat írják le, nem egy általános csatlakozó modellt. Ellenőrizze a beállítási típusokat, a keret orientációt és az értéktartományokat, mielőtt ugyanazt a számítást egy másik előbeállításra alkalmazná.

## **Csatlakozó irányszög megtalálása**

Egy egyenes csatlakozó iránya a szélesség és magasság alapján számítható ki, a vízszintes és függőleges tükrözések figyelembevételével. A következő példa a pozitív vízszintes tengelytől óramutató járásával megegyező szöget adja meg a dia koordinátáiban:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy csatlakozó csatlakoztatható-e egy alakzathoz?**

Ellenőrizze az alakzat [getConnectionSiteCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getConnectionSiteCount) értékét. A pozitív szám azt jelenti, hogy az alakzat csatlakozási pontokat biztosít. Érvényesítse a kiválasztott hely indexet, mielőtt bármelyik csatlakozó végéhez rendeli.

**Azonosítható-e egy csatlakozó beállítás a gyűjtemény indexe alapján?**

Az index csak egy ismert csatlakozó előbeállítás és gyűjtemény elrendezés esetén jelentős. Ellenőrizze a [AdjustValue.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getType) értéket a módosítás előtt, és használja a [AdjustValue.getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/adjustvalue/#getName) metódust további információként, ha ugyanaz a szemantikus típus többször is előfordul.

**Mi történik, ha egy csatlakoztatott alakzatot törlik?**

A megfelelő csatlakozó vég leválik. A csatlakozó a dián marad, és törölhető, szabad vonalként pozicionálható, vagy egy másik alakzathoz csatolható.

**Megmaradnak-e a csatlakozók kötései, amikor egy diát másolnak?**

A kötéseket általában megőrzik, amikor a csatlakoztatott alakzatokkal együtt másolják a diát. Ha egy csatlakozót anélkül másolnak, hogy a célalakzata is jelen lenne, a érintett véget újra csatlakoztatni kell.