---
title: Bekezdés határainak lekérése prezentációkból Pythonban Java segítségével
linktitle: Bekezdés határai
type: docs
weight: 43
url: /hu/python-java/paragraph-bounds/
keywords:
- bekezdés határai
- bekezdés koordináta
- bekezdés méret
- szövegkeret
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés határait az Aspose.Slides Python-ban Java használatával, a szöveg elhelyezésének optimalizálása érdekében a PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk azt mutatja be, hogyan lehet lekérni a bekezdések határait, méretét és koordinátáit az Aspose.Slides-ban. Bemutatja, hogyan lehet egy bekezdés téglalapját megszerezni egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) segítségével a [Paragraph.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getRect) használatával, hogyan lehet a bekezdés koordinátáit egy táblázatcella szövegkereten belül lekérni, valamint kiemeli a fontos részleteket, például a mérési egységeket, a szöveg tördelésének hatását a határokra, a pixel átalakítást és a hatékony bekezdésformázási értékeket.

## **Bekezdés téglalap alakú koordinátáinak lekérése**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getRect) metódust a bekezdés körülhatároló téglalapjának lekéréséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Bekezdés méretének lekérése egy táblázatcella szövegkereten belül**

A [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegkereten belül, használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getRect) metódust. A visszaadott téglalap a táblázatcella szövegkerethez relatív, ezért adja hozzá a tábla pozícióját és a cella eltolását, ha diánivel szintű koordinátákra van szüksége.

Az alábbi példa a bekezdés határait lekéri egy táblázatcella belsejében, és téglalapokat rajzol a diához, hogy megjelenítse ezeket a határokat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Milyen mértékegységben mérik a bekezdés koordinátáit?**

A koordinátákat pontban (points) mérik, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a dián.

**A szó megtörése befolyásolja a bekezdés határait?**

Igen. Ha a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) számára, a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelekre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel lehet átalakítani: pixels = points × (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz választott DPI-től függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílus öröklődését?**

Használja a [effective paragraph formatting data structure](/slides/hu/python-java/shape-effective-properties/) elemet; ez visszaadja a végső, egyesített értékeket a behúzásokra, távolságokra, tördelésre, RTL-re és egyéb beállításokra.