---
title: Bekezdés határainak lekérése prezentációkból Pythonban
linktitle: Bekezdés
type: docs
weight: 60
url: /hu/python-net/paragraph/
keywords:
- bekezdés határok
- szövegrész határok
- bekezdés koordináta
- rész koordináta
- bekezdés méret
- szövegrész méret
- szövegkeret
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés és szövegrész határait az Aspose.Slides for Python via .NET segítségével a PowerPoint és OpenDocument prezentációkban a szöveg elhelyezésének optimalizálásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megkapni a bekezdések és szövegrészek határait, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet lekérni egy bekezdés téglalapját egy `TextFrame`-ben a `get_rect()` segítségével, hogyan lehet megszerezni a bekezdés és a rész koordinátáit egy táblázatcella szövegkeretben, valamint kiemeli a fontos részleteket, mint a mértékegységek, a szöveg sortörésének hatása a határokra, a pixel átszámítás, és a hatékony bekezdésformázási értékek.

## **Bekezdés és rész koordinátáinak lekérése a TextFrame-ben**
Az Aspose.Slides for Python via .NET használatával a fejlesztők most már lekérhetik egy bekezdés téglalap koordinátáit a TextFrame bekezdésgyűjteményében. Emellett lehetővé teszi, hogy megszerezzék egy rész koordinátáit a bekezdés részgyűjteményében. Ebben a témában egy példával bemutatjuk, hogyan lehet lekérni egy bekezdés téglalap koordinátáit valamint a rész pozícióját a bekezdésen belül.

## **Bekezdés téglalap koordinátáinak lekérése**
Az új **GetRect()** metódus hozzá lett adva. Lehetővé teszi a bekezdés határ téglalapjának lekérését.

```py
import aspose.slides as slides

# Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Bekezdés és rész méretének lekérése táblázatcella szövegkereten belül** ##

A [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) vagy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegkeretben használhatja az [IPortion.GetRect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iportion/) és az [IParagraph.GetRect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iparagraph/) metódusokat.

Ez a példa kód bemutatja a leírt műveletet:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **GYIK**

**Milyen egységben vannak megadva a bekezdés és a szövegrészek koordinátái?**

Pontban, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a dián.

**A szöveg sortörése befolyásolja a bekezdés határait?**

Igen. Ha a [wrapping](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/wrap_text/) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) beállításában, a szöveg sortörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelekre az exportált képen?**

Igen. Pontok pixelekké konvertálásához használja: pixels = points × (DPI / 72). Az eredmény a rendereléshez/exportáláshoz választott DPI-től függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílus öröklődését?**

Használja a [effective paragraph formatting data structure](/slides/hu/python-net/shape-effective-properties/); ez visszaadja a behúzások, távolságok, sortörés, RTL és egyéb beállítások végső összevont értékeit.