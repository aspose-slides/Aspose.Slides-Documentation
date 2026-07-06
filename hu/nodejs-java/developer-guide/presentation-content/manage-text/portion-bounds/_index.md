---
title: Szövegrész határértékeinek lekérése prezentációkból JavaScript-ben
linktitle: Rész határai
type: docs
weight: 47
url: /hu/nodejs-java/portion-bounds/
keywords:
- szövegrész határok
- szövegrész
- szövegrészlet
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a szövegrész határait PowerPoint prezentációkban, az Aspose.Slides for Node.js Java használatával."
---
## **Áttekintés**

A szövegrész egy bekezdésen belüli konkrét szövegtöredéket képvisel, és lehetővé teszi, hogy ezt a töredéket a környező tartalomtól függetlenül kezelje. Az Aspose.Slides-ban a részeket akkor használhatja, amikor a szövegtöredék határait kell lekérdeznie, csak a bekezdés egy részére szeretne formázást alkalmazni, vagy részletesebb szinten kívánja irányítani a szöveg viselkedését.

Ez a cikk bemutatja, hogyan kell a [Portion.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/getrect/) segítségével lekérni egy rész határoló téglalapját. Továbbá megmutatja, hogyan lehet a [Portion.getCoordinates](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/getcoordinates/) segítségével lekérni egy rész kezdetének koordinátáit. Emellett kiemeli a gyakori, a részhez kapcsolódó szcenáriókat, például egyetlen szövegtöredékhez hiperhivatkozás alkalmazását, a formázás feloldásának módját a rész, bekezdés, szövegkeret és téma öröklődésén keresztül, valamint azt, hogy mi történik, ha a megadott betűtípus nem áll rendelkezésre.

## **A szövegrész határoló téglalapjának lekérése**

Használja a [Portion.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/getrect/) metódust egy szövegrész határoló téglalapjának lekérdezéséhez:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **A szövegrész koordinátáinak lekérése**

Használja a [Portion.getCoordinates](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/getcoordinates/) metódust egy szövegrész kezdetének koordinátáinak lekérdezéséhez:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, [assign a hyperlink](/slides/hu/nodejs-java/manage-hyperlinks/) segítségével egy egyedi részhez rendelhet hiperhivatkozást; csak ez a töredék lesz kattintható, nem pedig az egész bekezdés.

**Hogyan működik a stíluselődlés: mit felülír egy rész, és mi kerül át egy bekezdésből vagy szövegkeretből?**

A részszintű tulajdonságok rendelkeznek a legmagasabb precedenciával. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) szinten, az Aspose.Slides a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/)-től veszi. Ha ott sem áll rendelkezésre, akkor a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/theme/) stílusát használja.

**Mi történik, ha a részhez megadott betűtípus hiányzik a célgépen vagy szerveren?**

A [Font substitution rules](/slides/hu/nodejs-java/font-selection-sequence/) kerülnek alkalmazásra. A szöveg átterveződhet: a metrikák, a szóelválasztás és a szélesség változhat, ami a pontos pozicionálás szempontjából fontos.

**Beállíthatok-e a részhez tartozó szövegtöltés átlátszóságát vagy fokozatot a bekezdés többi részétől függetlenül?**

Igen, a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) szintjén a szövegszín, a kitöltés és az átlátszóság eltérhet a szomszédos töredékektől.