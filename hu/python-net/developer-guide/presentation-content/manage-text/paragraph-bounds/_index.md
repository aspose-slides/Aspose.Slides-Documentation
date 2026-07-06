---
title: Bekezdéshatárok lekérése prezentációkból Pythonban
linktitle: Bekezdéshatárok
type: docs
weight: 43
url: /hu/python-net/paragraph-bounds/
keywords:
- bekezdés határok
- bekezdés koordináta
- bekezdés méret
- szövegkeret
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet az Aspose.Slides for Python via .NET segítségével lekérni a bekezdés határait a PowerPoint és OpenDocument prezentációk szövegpozicionálásának optimalizálásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések határait, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet egy bekezdés téglalapját lekérni egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) segítségével a [Paragraph.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/get_rect/), hogyan lehet a táblázatcella szövegkeretben lévő bekezdés koordinátáit megkapni, és kiemeli a fontos részleteket, például a mérési egységeket, a szövegcsomagolás hatását a határokra, a pixelkonverziót és a hatékony bekezdésformázási értékeket.

## **Bekezdés téglalap koordinátáinak lekérése**

Használja a [Paragraph.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/get_rect/) függvényt a bekezdés körülíró téglalapjának lekéréséhez.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Bekezdés méretének lekérése egy táblázatcella szövegkeretben**

Az [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegkeretben, használja a [Paragraph.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/get_rect/)-t. A visszaadott téglalap a táblázatcella szövegkerethez relatív, ezért a diá szintű koordinátákhoz adja hozzá a táblázat pozícióját és a cella eltolását.

A következő példa lekéri a bekezdés határait egy táblázatcellán belül, és téglalapokat rajzol a diára a határok megjelenítéséhez:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Milyen egységben mérik a bekezdés koordinátáit?**

A pontban (points) mérik, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre érvényes a dián.

**A szövegeltakarás befolyásolja a bekezdés határait?**

Igen. Ha a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/wrap_text/) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) számára, a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők a pixelre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel alakíthatja át: pixel = pont × (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz választott DPI-től függ.

**Hogyan kapom meg a "hatékony" bekezdésformázási paramétereket, figyelembe véve a stílusöröklődést?**

Használja a [hatékony bekezdésformázási adatstruktúra](/slides/hu/python-net/shape-effective-properties/)-t; ez visszaadja a behúzások, sorok közti távolság, tördelés, jobbról balra írás és egyéb beállítások végső, egyesített értékeit.