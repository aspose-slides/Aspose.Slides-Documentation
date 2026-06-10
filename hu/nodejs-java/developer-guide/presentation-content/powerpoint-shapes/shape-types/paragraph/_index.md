---
title: Bekezdés határolók lekérése prezentációkból JavaScript-ben
linktitle: Bekezdés
type: docs
weight: 60
url: /hu/nodejs-java/paragraph/
keywords:
- bekezdés határoló
- szövegrész határoló
- bekezdés koordináta
- rész koordináta
- bekezdés méret
- szövegrész méret
- szövegkeret
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet JavaScriptben az Aspose.Slides for Node.js segítségével lekérni a bekezdés és szövegrész határolókat, hogy optimalizálja a szöveg elhelyezését PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések és szövegrészek határolóit, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet a `TextFrame`‑en belüli bekezdés téglalapját visszanyerni a `getRect()` használatával, hogyan lehet a bekezdés és rész koordinátáit egy táblázatcella szövegkeretén belül lekérni, valamint kiemeli a fontos részleteket, például a mérések egységeit, a szöveg tördelésének hatását a határolókra, a pixelkonverziót és a hatékony bekezdésformázási értékeket.

## **Bekezdés és rész koordináták lekérése TextFrame‑ben**
Az Aspose.Slides for Node.js via Java használatával a fejlesztők most már lekérhetik a `TextFrame` bekezdésgyűjteményében lévő bekezdés téglalap koordinátáit. Emellett lehetővé teszi a [rész koordinátáinak](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Portion#getCoordinates--) lekérését egy bekezdés részgyűjteményén belül. Ebben a témában egy példán keresztül bemutatjuk, hogyan lehet a bekezdés téglalap koordinátáit és a rész pozícióját a bekezdésen belül lekérni.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Bekezdés téglalap koordinátáinak lekérése**
A [**getRect()**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Paragraph#getRect--) metódus használatával a fejlesztők lekérhetik a bekezdés határoló téglalapját.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bekezdés és rész méretének lekérése táblázatcella szövegkeretben**

A [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Portion) vagy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Paragraph) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegkeretben használhatja a [Portion.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Portion#getRect--) és a [Paragraph.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Paragraph#getRect--) metódusokat.

Ez a minta kód demonstrálja a leírt műveletet:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Milyen mértékegységben adják vissza a bekezdés és szövegrészek koordinátáit?**

Pontokban, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a dián.

**A szóeltörés befolyásolja a bekezdés határolóit?**

Igen. Ha a [tördelés](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/setwraptext/) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ben, a szöveg a terület szélességéhez igazítva törik, ami megváltoztatja a bekezdés tényleges határolóit.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelekre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel lehet konvertálni: pixelek = pontok × (DPI / 72). Az eredmény a renderelés/exportálás során választott DPI‑tól függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílus öröklődését?**

Használja a [hatékony bekezdésformázási adatstruktúrát](/slides/hu/nodejs-java/shape-effective-properties/); ez visszaadja a végső összevont értékeket a behúzásokra, távolságokra, tördelésre, jobbról balra írásra és egyebekre vonatkozóan.