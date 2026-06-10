---
title: Szövegrészek kezelése PowerPoint prezentációkban JavaScript használatával
linktitle: Szövegrész
type: docs
weight: 70
url: /hu/nodejs-java/portion/
keywords:
- szövegrész
- szövegrészlet
- szövegkoordináták
- szövegpozíció
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a szövegrészeket PowerPoint prezentációkban JavaScript és Aspose.Slides for Node.js segítségével Java-on keresztül, növelve a teljesítményt és a testreszabhatóságot."
---
## **Áttekintés**

A szövegrész egy bekezdésen belüli adott szövegrészt képviseli, és lehetővé teszi, hogy ezt a részt a környező tartalomtól függetlenül kezelje. Az Aspose.Slides-ben a részek akkor használhatók, amikor egy szövegrész pozícióját kell lekérni, csak a bekezdés egy részére szeretne formázást alkalmazni, vagy részletesebb szinten szeretné szabályozni a szöveg viselkedését.

Ez a cikk bemutatja, hogyan kaphatók meg egy rész elejének koordinátái a `getCoordinates()` metódus használatával. Emellett kiemeli a szokásos részhez kapcsolódó forgatókönyveket, mint például egy hivatkozás alkalmazása egyetlen szövegrészre, a formázás megoldásának megértése a rész, bekezdés, szövegkeret és téma öröklődésén keresztül, valamint a megadott betűkészlet hiányának kezelése. Továbbá megjegyzi, hogy a szövegtöltés, szín és átlátszóság különböző módon állítható be az egyes részeknél ugyanabban a bekezdésben.

## **A rész pozíciókoordinátáinak lekérése**
[**getCoordinates()**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Portion#getCoordinates--) metódus hozzá lett adva a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) osztályhoz, amely lehetővé teszi a rész elejének koordinátáinak lekérését.

```javascript
// Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // A prezentáció kontextusának átalakítása
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Alkalmazhatok hivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, [hivatkozást rendelhet](/slides/hu/nodejs-java/manage-hyperlinks/) egy egyedi részlethez; csak ez a szövegrész lesz kattintható, a teljes bekezdés nem.

**Hogyan működik a stílusöröklés: mit felülír egy Portion, és mi kerül át a Paragraph/TextFrame-ből?**

A rész szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/), a motor a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) értékét veszi; ha ott sem, akkor a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/theme/) stílusából veszi.

**Mi történik, ha a Portion-hoz megadott betűkészlet hiányzik a célgépen/kiszolgálón?**

[Font substitution rules](/slides/hu/nodejs-java/font-selection-sequence/) érvényes. A szöveg újra tördelődhet: a metrikák, elválasztás és a szélesség változhat, ami a pontos pozícionálásnál számít.

**Beállíthatok a Portion-hoz tartozó szövegtöltés átlátszóságot vagy gradienst a bekezdés többi részétől függetlenül?**

Igen, a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) szintjén a szövegszín, a töltés és az átlátszóság eltérhet a szomszédos részeketől.