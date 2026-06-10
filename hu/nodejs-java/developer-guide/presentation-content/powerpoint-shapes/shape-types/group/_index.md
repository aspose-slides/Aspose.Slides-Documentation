---
title: Csoportos bemutató alakzatok JavaScriptben
linktitle: Alakzatcsoport
type: docs
weight: 40
url: /hu/nodejs-java/group/
keywords:
- csoport alakzat
- alakzatcsoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan csoportosítsa és szedje szét az alakzatokat PowerPoint bemutatókban az Aspose.Slides for Node.js via Java segítségével — gyors, lépésről lépésre útmutató ingyenes JavaScript kóddal."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk csoport alakzatokkal az Aspose.Slides‑ben. Bemutatja, hogyan adhatunk csoport alakzatot egy diára, hogyan helyezhetünk bele alakzatokat, és hogyan menthetjük a frissített bemutatót. Emellett bemutatja, hogyan érhetjük el a csoportban tárolt alakzatokat és olvashatjuk a `AlternativeText` értéküket. Továbbá a cikk röviden érinti a csoport‑alakzatok kapcsolódó funkcióit, például a beágyazott csoportokat, a z‑rendet és a zárolási lehetőségeket.

## **Csoport alakzat hozzáadása**
Az Aspose.Slides támogatja a csoport alakzatokkal való munkát a diákon. Ez a funkció segíti a fejlesztőket gazdagabb bemutatók készítésében. Az Aspose.Slides for Node.js via Java támogatja a csoport alakzatok hozzáadását vagy elérését. Lehetőség van alakzatokat hozzáadni egy már hozzáadott csoport alakzathoz, vagy bármely tulajdonságát elérni. Csoport alakzat hozzáadásához egy diára az Aspose.Slides for Node.js via Java segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg a dia hivatkozását az Index használatával
1. Adjon hozzá egy csoport alakzatot a diához.
1. Adja hozzá az alakzatokat a hozzáadott csoport alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi példakód egy csoport alakzatot ad hozzá egy diához.

```javascript
// Példányosítsa a Presentation osztályt
var pres = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát
    var sld = pres.getSlides().get_Item(0);
    // A diák alakzatgyűjteményének elérése
    var slideShapes = sld.getShapes();
    // Csoport alakzat hozzáadása a diához
    var groupShape = slideShapes.addGroupShape();
    // Alakzatok hozzáadása a hozzáadott csoport alakzathoz
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Csoport alakzat keretének hozzáadása
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // A PPTX fájl írása a lemezre
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **AltText tulajdonság elérése**
Ez a téma egyszerű lépéseket mutat be, kódrészletekkel együtt, a csoport alakzat hozzáadásához és a csoport alakzatok AltText tulajdonságának eléréséhez a diákon. A csoport alakzat AltText értékének eléréséhez egy dián az Aspose.Slides for Node.js via Java segítségével:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) példányt, amely egy PPTX fájlt képvisel.
1. Szerezze meg a dia hivatkozását az Index használatával.
1. Hozzáférés a dia alakzatgyűjteményéhez.
1. Hozzáférés a csoport alakzathoz.
1. Hívja meg a [getAlternativeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getAlternativeText--) tulajdonságot.

Az alábbi példakód eléri a csoport alakzat alternatív szövegét.

```javascript
// Példányosítja a Presentation osztályt, amely PPTX fájlt képvisel
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Az első dia lekérése
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // A diák alakzatgyűjteményének elérése
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // A csoport alakzat elérése.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Az AltText tulajdonság elérése
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Támogatott-e a beágyazott csoportosítás (csoport egy másik csoporton belül)?**

Igen. A [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/) rendelkezik egy [getParentGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getparentgroup/) metódussal, amely közvetlenül jelzi a hierarchia támogatását (egy csoport lehet egy másik csoport gyermekeként).

**Hogyan szabályozhatom a csoport z‑rendjét a dián lévő egyéb objektumokhoz képest?**

Használja a [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/) [getZOrderPosition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getzorderposition/) metódusát a pozíciójának megtekintéséhez a megjelenítési rétegben.

**Megakadályozható a mozgatás/szerkesztés/csoportbontás?**

Igen. A csoport zárolási szekciója a [GroupShapeLock](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) segítségével érhető el, amely lehetővé teszi a műveletek korlátozását az objektumon.