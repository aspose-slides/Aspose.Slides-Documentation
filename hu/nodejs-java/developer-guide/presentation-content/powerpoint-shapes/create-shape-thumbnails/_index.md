---
title: Diák formáinak előnézeti képeinek létrehozása JavaScriptben
linktitle: Alakzat előnézeti képek
type: docs
weight: 70
url: /hu/nodejs-java/create-shape-thumbnails/
keywords:
- alakzat előnézeti kép
- alakzat kép
- alakzat renderelése
- alakzat renderelés
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Készítsen magas minőségű alakzat előnézeti képeket a PowerPoint diákból JavaScript és az Aspose.Slides for Node.js segítségével – egyszerűen hozza létre és exportálja a prezentáció előnézeti képeit."
---
## **Bevezetés**

Az Aspose.Slides a bemutatófájlok létrehozására szolgál, ahol minden oldal egy diát jelent. Ezeket a diákat a Microsoft PowerPoint segítségével nyitható meg a bemutatófájlok megnyitásával. De néha a fejlesztőknek külön képnézőben kell megtekinteniük a formák képeit. Ilyen esetekben az Aspose.Slides segít az előnézeti képek létrehozásában a diák formáiról. Ennek a funkciónak a használatát ebben a cikkben ismertetjük.  
Ez a cikk elmagyarázza, hogyan lehet különböző módokon előnézeti képeket generálni a diákról:

- Alakzat előnézeti kép létrehozása egy diához.  
- Alakzat előnézeti kép létrehozása a dián lévő alakzathoz felhasználó által meghatározott méretekkel.  
- Alakzat előnézeti kép létrehozása az alakzat megjelenésének határain belül.

## **Alakzat előnézeti képek generálása diákból**
Az alakzat előnézeti kép generálásához bármely diáról az Aspose.Slides for Node.js via Java segítségével, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Szerezze be egy diának a hivatkozását azonosítója vagy indexe alapján.  
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getImage--) a hivatkozott diáról alapértelmezett méretben.  
4. Mentse el az előnézeti képet a kívánt képformátumban.

```javascript
// Egy Presentation osztály példányosítása, amely a prezentáció fájlt képviseli
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Teljes méretű kép létrehozása
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Kép mentése lemezre PNG formátumban
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alakzat előnézeti képek generálása felhasználó által meghatározott méretezési tényezővel**
Az alakzat előnézeti kép generálásához felhasználó által meghatározott méretezési tényezővel az Aspose.Slides for Node.js via Java használatával, kövesse az alábbiakat:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Szerezze be egy diának a hivatkozását azonosítója vagy indexe alapján.  
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) a hivatkozott diáról felhasználó által meghatározott méretekkel.  
4. Mentse el az előnézeti képet a kívánt képformátumban.

```javascript
// Egy Presentation osztály példányosítása, amely a prezentáció fájlt képviseli
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Teljes méretű kép létrehozása
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Kép mentése lemezre PNG formátumban
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alakzat előnézeti kép a határokon belül**
Ez a módszer a formák előnézeti képeinek létrehozására lehetővé teszi, hogy a képet az alakzat megjelenésének határai szerint generálja, figyelembe véve az összes formaeffektet. A generált előnézeti kép a dia határai által lesz korlátozva. A dia alakzatának előnézeti képe határokon belül való létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Szerezze be egy diának a hivatkozását azonosítója vagy indexe alapján.  
3. Szerezze meg a hivatkozott diáról a előnézeti képet, ahol az alakzat határai a megjelenés határai.  
4. Mentse el az előnézeti képet a kívánt képformátumban.

```javascript
// Egy Presentation osztály példányosítása, amely a prezentáció fájlt képviseli
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Teljes méretű kép létrehozása
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Kép mentése lemezre PNG formátumban
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Milyen képformátumok használhatók az alakzat előnézeti képek mentésekor?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/), és egyebek. Az alakzatok [exportálhatók vektorgrafikaként SVG](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) a tartalom SVG-ként való mentésével.

**Mi a különbség a Shape és az Appearance határok között előnézeti kép renderelésekor?**  
`Shape` a forma geometriai adatait használja; `Appearance` a [vizuális effektusokat](/slides/hu/nodejs-java/shape-effect/) (árnyékok, csillogás stb.) is figyelembe veszi.

**Mi történik, ha egy alakzat rejtettként van megjelölve? Továbbra is előnézeti képként renderelődik?**  
A rejtett alakzat továbbra is a modell része, és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg az alakzat képeinek generálását.

**Támogatottak-e csoportos alakzatok, diagramok, SmartArt és más összetett objektumok?**  
Igen. Bármely, [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/) és a [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/))ként reprezentált objektum menthető előnézeti képként vagy SVG-ként.

**A rendszer által telepített betűtípusok befolyásolják a szöveg alakzatok előnézeti képeinek minőségét?**  
Igen. Ajánlott [szükséges betűtípusok biztosítása](/slides/hu/nodejs-java/custom-font/) (vagy [betűtípus helyettesítések konfigurálása](/slides/hu/nodejs-java/font-substitution/)), hogy elkerülje a nem kívánt visszaeséseket és a szöveg átrendeződését.