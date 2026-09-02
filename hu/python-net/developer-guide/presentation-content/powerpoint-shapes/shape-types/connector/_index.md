---
title: Csatlakozók kezelése prezentációkban Python nyelven
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/python-net/connector/
keywords:
- csatlakozó
- csatlakozó típusa
- csatlakozási pont
- csatlakozó vonal
- csatlakozó szög
- kapcsolódási hely
- állítópont
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá, csatlakoztathat, átirányíthat, állíthat és vizsgálhat egyenes, hajlított és ívelt PowerPoint csatlakozókat az Aspose.Slides for Python segítségével .NET-en keresztül."
---
## **Áttekintés**

A csatlakozó egy vonal, amely két alakzathoz maradhat csatlakoztatva, amikor bármelyik alakzat mozog. Végpontjai csatlakozási helyekhez kapcsolódnak, amelyeket a PowerPoint zöld pontok jelölnek. Néhány görbített és íves csatlakozó továbbá beállítási pontokat jelenít meg, narancssárga pontokként, amelyek az egyes csatlakozó szegmensek pozícióját szabályozzák.

Az Aspose.Slides a csatlakozókat az [IConnector](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iconnector/) interfészen keresztül képviseli. Létrehozhatja őket, csatlakoztathatja a végpontjaikat alakzatokhoz, kiválaszthatja a csatlakozási helyeket, átirányíthatja őket, és módosíthatja a beállítási pontokkal rendelkező csatlakozók geometriáját.

## **Csatlakozótípusok**

A [ShapeType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapetype/) felsorolás lineáris, hajlított és íves csatlakozók előbeállításait tartalmazza. Az alábbi táblázat a rendelkezésre álló csatlakozógeometriákat és az egyes előbeállítások által meghatározott beállítási pontok számát mutatja.

| Csatlakozó | Kép | Beállítási pontok száma |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

A beállítási pontok száma és jelentése a kiválasztott csatlakozó előbeállítás része. Ne feltételezze, hogy két különböző csatlakozótípus ugyanazt a gyűjteményszerkezetet mutatja.

## **Két alakzat összekapcsolása**

Használja az [IShapeCollection.add_connector](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapecollection/add_connector/) metódust csatlakozó hozzáadásához, és állítsa be a [start_shape_connected_to](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iconnector/start_shape_connected_to/) és [end_shape_connected_to](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iconnector/end_shape_connected_to/) tulajdonságokat. Miután mindkét végpont csatlakozik, az [IConnector.reroute](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iconnector/reroute/) rövid útvonalat választ a két alakzat között.

Az alábbi példa egy ellipszist és egy téglalapot kapcsol össze egy hajlított csatlakozóval:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
A `reroute` hívása megváltoztathatja a [start_shape_connection_site_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) és a [end_shape_connection_site_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) értékeket. A csatlakozási helyeket az újrairányítás után állítsa be, ha azoknak rögzítve kell maradniuk.
{{% /alert %}}

## **Csatlakozási hely kiválasztása**

Minden csatlakoztatható alakzat a [connection_site_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/igeometryshape/connection_site_count/) segítségével jelenti a helyek számát. Érvényesítse a kívánt, nullával kezdődő helyindexet, mielőtt azt a csatlakozó végéhez rendeli; a helyek száma alakzatgeometriától függ.

Ez a példa akkor csatlakoztatja a csatlakozót az ellipszis egy adott helyéhez, ha az a hely létezik:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Csatlakozó pontjának módosítása**

A beállítási pontokkal rendelkező csatlakozók ezeket a [IGeometryShape.adjustments](https://reference.aspose.com/slides/hu/python-net/aspose.slides/igeometryshape/adjustments/) segítségével teszik elérhetővé. Vizsgálja meg minden [IAdjustValue](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iadjustvalue/) esetén a [type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iadjustvalue/type/) tulajdonságot, mielőtt módosítaná a [raw_value](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iadjustvalue/raw_value/) értéket. Általános alakzatmanipulációhoz lásd a [Shape Manipulation](/slides/hu/python-net/shape-manipulations/) oldalt.

A csatlakozó beállítások száma, sorrendje, jelentése és érvényes értéktartománya az adott csatlakozó előbeállítástól függ. A `type` tulajdonság csak olvasható, míg a beállítási érték írható. A csak olvasható [name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iadjustvalue/name/) tulajdonság további azonosítást biztosít, ha a csatlakozó több, ugyanazzal a szemantikai típussal rendelkező beállítást tartalmaz.

### **Útvonal akadály elkerülésével**

A következő elrendezésben egy `ShapeType.BENT_CONNECTOR5` csatlakozó két alakzat között áthalad egy harmadik alakzaton:

![connector-obstruction](connector-obstruction.png)

Ez a kód hozza létre az akadályba ütköző csatlakozót:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

A függőleges hajlítás mozgatása megváltoztatja az útvonalat, így a csatlakozó kikerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Ahelyett, hogy feltételezné, hogy az `1` index mindig a függőleges hajlítást jelenti, ez a példa a `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` elemet keresi, és csak akkor módosítja, ha a várt szemantikai típus jelen van:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

Egy `ShapeType.BENT_CONNECTOR5` két `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` és egy `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` beállítással rendelkezik. Ha a szükséges típus többször is előfordul, vizsgálja meg a `name` értéket és az adott előbeállítás ismert geometriáját, mielőtt kiválasztana egyet. Ha egy beállítás a [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapeadjustmenttype/) típust adja vissza, tekintse jelentését és tartományát az előbeállítás specifikusnak, és ne módosítsa, amíg a szerződés nem ismert.

## **A beállítási értékek összekapcsolása a csatlakozó geometriával**

Görbített csatlakozók esetén a beállítási értékek felhasználhatók az egyes szegmensek pozíciójának becslésére. Ezek a számítások az adott csatlakozó előbeállításhoz kötöttek:

- `ShapeType.BENT_CONNECTOR4` általában egy `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` és egy `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` beállítást tesz elérhetővé.
- Ezeknél a hajlítási pozícióknál a `raw_value / 100000` adja a csatlakozó keret szélességének vagy magasságának a példákban használt hányadát.
- Egy csatlakozó keret elforgatható vagy tükrözhető, ezért a keretkoordinátákat át kell alakítani, mielőtt összehasonlítanák a diavetítés koordinátáival.

Az alábbi példák először a `type` segítségével azonosítják a beállításokat, és nem tekintik a gyűjteményindexeket hordozható azonosítóknak.

### **Nem forgatott csatlakozó**

A kezdeti elrendezés két szöveges alakzatot tartalmaz, amelyet egy `ShapeType.BENT_CONNECTOR4` kapcsol össze:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa megvizsgálja a csatlakozót, és lekéri a vízszintes és függőleges hajlítási beállításokat:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

A két hajlítást egyidejűleg módosítani szeretnénk; először keresse meg a várt típust, majd csak akkor módosítsa az értékeket, ha mindkettőt megtalálta:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény egy olyan csatlakozó, amelynek vízszintes és függőleges szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Miután a szemantikai típusok ismertek, értékeik átalakíthatók csatlakozó‑keret koordinátákká. Ez a példa egy vékony téglalapot rajzol a két hajlítási beállítás által vezérelt függőleges szegmens fölé:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

A segédalakzat jelöli a kiszámított szegmenst:

![connector-adjusted-2](connector-adjusted-2.png)

### **Forgatott vagy tükrözött csatlakozó**

Ha ugyanaz a csatlakozó geometria függőlegesen van orientálva, akkor a [frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapeframe/flip_h/) és [flip_v](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapeframe/flip_v/) értékek befolyásolják a csatlakozó‑keret koordináták slide‑koordinátává történő átalakítását.

Ez a példa létrehozza és módosítja a függőlegesen orientált csatlakozót:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Az módosított csatlakozó függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges forgásszög `alpha` esetén egy csatlakozó‑keret pont `(x, y)` elforgatása a kerpközép `(x0, y0)` körül:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90‑fokos orientációt, és piros segédvonallal jelöli a megfelelő csatlakozó szegmenst:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

A piros segédvonal a koordináta‑átalakítás után jelzi a kiszámított szegmenst:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt előbeállításokat írják le, nem egy univerzális csatlakozómodellt. Érvényesítse a beállítási típusokat, a keret orientációját és az értéktartományokat, mielőtt ugyanazt a számítást más előbeállításra alkalmazná.

## **Csatlakozó irányszögének meghatározása**

Egy egyenes csatlakozó irányát a szélesség és magasság, valamint a vízszintes és függőleges tükrözések figyelembevételével számíthatjuk ki. Az alábbi példa a pozitív vízszintes tengelytől óramutató járásával megegyező szöget adja meg slide‑koordinátákban:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**Hogyan tudom ellenőrizni, hogy egy csatlakozó csatlakozhat-e egy alakzathoz?**

Ellenőrizze az alakzat [connection_site_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/igeometryshape/connection_site_count/) értékét. A pozitív szám azt jelenti, hogy az alakzat csatlakozási helyeket biztosít. Érvényesítse a kiválasztott helyindexet, mielőtt a csatlakozó egyik végéhez rendeli.

**Azonosíthatok-e egy csatlakozó beállítást a gyűjteményindex alapján?**

Az index csak akkor jelentős, ha ismert a csatlakozó előbeállítása és a gyűjtemény elrendezése. Módosítás előtt ellenőrizze a [IAdjustValue.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iadjustvalue/type/) értéket, és ha ugyanaz a szemantikai típus többször is előfordul, használja a [IAdjustValue.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iadjustvalue/name/) értéket további információként.

**Mi történik, ha egy csatlakoztatott alakzatot törlik?**

A csatlakozó megfelelő vége leválik. A csatlakozó a dián marad, törölhető, szabad vonalként pozicionálható, vagy újra csatlakoztatható egy másik alakzathoz.

**Megmaradnak a csatlakozások, ha egy diát másolnak?**

Általában megmaradnak, ha a csatlakoztatott alakzatokkal együtt másolják a diát. Ha egy csatlakozót másolnak anélkül, hogy a célalakzata egyike is másolva lenne, az érintett véget újra csatlakoztatni kell.