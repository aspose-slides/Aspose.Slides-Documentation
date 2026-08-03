---
title: Diavetítés-formák bélyegképeinek létrehozása JavaScript-ben
linktitle: Forma bélyegképek
type: docs
weight: 70
url: /hu/nodejs-java/create-shape-thumbnails/
keywords:
- forma bélyegkép
- forma kép
- forma megjelenítése
- forma renderelés
- vizuális határok
- forma határok
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Készítsen magas minőségű forma bélyegképeket PowerPoint diákból JavaScript és az Aspose.Slides for Node.js segítségével – egyszerűen hozhatja létre és exportálhatja a prezentáció bélyegképeit."
---
## **Bevezetés**

Az Aspose.Slides használható prezentációs fájlok létrehozására, ahol minden oldal egy diát jelent. Ezeket a diákat megtekinthetjük a prezentációs fájlok Microsoft PowerPoint‑tal történő megnyitásával. Néha azonban a fejlesztőknek a formák képeit külön képnézőben kell megjeleníteniük. Ilyenkor az Aspose.Slides segít előállítani a diaformák bélyegkép‑képeit. Ennek a funkciónak a használatát ebben a cikkben ismertetjük.

Ez a cikk különböző módokon mutatja be a diabélyegképek előállítását:

- A forma bélyegképének előállítása a dián belül.
- A forma bélyegképének előállítása egy diaformához felhasználó által megadott méretekkel.
- A forma bélyegképének előállítása a forma megjelenésének határain belül.

## **Forma bélyegképek előállítása diákból**

A forma bélyegképének előállításához bármely diáról az Aspose.Slides for Node.js via Java használatával, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
2. Szerezze meg a bármely dia hivatkozását az azonosítója vagy indexe alapján.
3. A hivatkozott diáról a [forma bélyegképének lekérése](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getImage--) alapértelmezett mérettel.
4. Mentse a bélyegképet a kívánt képadatformátumban.

```javascript
// Hozzon létre egy Presentation osztályt, amely a prezentációs fájlt képviseli
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Hozzon létre egy teljes méretű képet
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Mentse a képet a lemezen PNG formátumban
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

## **Felhasználó által meghatározott méretezési tényezővel ellátott forma bélyegképek előállítása**

A dián lévő forma bélyegképének előállításához az Aspose.Slides for Node.js via Java használatával, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
2. Szerezze meg a bármely dia hivatkozását az azonosítója vagy indexe alapján.
3. A hivatkozott diáról a [forma bélyegképének lekérése](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) felhasználó által megadott méretekkel.
4. Mentse a bélyegképet a kívánt képadatformátumban.

```javascript
// Létrehoz egy Presentation osztályt, amely a prezentációs fájlt képviseli
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Létrehoz egy teljes méretű képet
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Mentse a képet a lemezen PNG formátumban
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

## **Határokon belüli forma bélyegkép előállítása**

Ez a forma bélyegképek létrehozási módszer lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül generáljanak bélyegképet. Figyelembe veszi a forma összes effektjét. A generált forma bélyegkép a diahatárokra korlátozott. A diában lévő forma megjelenésének határain belüli bélyegkép előállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
2. Szerezze meg a bármely dia hivatkozását az azonosítója vagy indexe alapján.
3. A forma határait megjelenésként használva szerezze meg a hivatkozott diáról a bélyegképet.
4. Mentse a bélyegképet a kívánt képadatformátumban.

```javascript
// Létrehoz egy Presentation osztályt, amely a prezentációs fájlt képviseli
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Létrehoz egy teljes méretű képet
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Mentse a képet a lemezen PNG formátumban
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

## **A forma tényleges vizuális határainak lekérése**

A [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) keret tulajdonságai—az `getX()`, `getY()`, `getWidth()`, és `getHeight()` metódusok—leírják a prezentációs modellben tárolt téglalapot. A ténylegesen renderelt tartalom túlnyúlhat ezen a kereten vagy egy másik tengelyekhez igazított téglalapot foglalhat el. A forgatás, körvonalak, nyílfejek, szöveg elrendezése és túltöltése, a generált SmartArt geometria és egyéb renderelési hatások mind megváltoztathatják az elfoglalt területet.

Használja a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getVisualBounds--) metódust az elfoglalt terület kiszámításához anélkül, hogy képet hozna létre. A metódus egy [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) objektumot ad vissza diakoordinátákban. A visszaadott téglalap nincs vágva a diára, ezért koordinátái negatívak lehetnek, ha a tartalom túlnyúlik a dia eredetén.

A következő példa lekéri és összehasonlítja a keret és a vizuális határokat:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Ugyanaz a téglalap használható a közeli formák bal, jobb, felső vagy alsó éléhez való igazításra; elegendő hely fenntartására egy generált elrendezésben; vagy a megengedett tartományon kívüli tartalom észlelésére. A vizuális határok különösen hasznosak SmartArt, szövegdobozok, nyilak, képek, forgatott formák és csoportos formák esetén, ahol a tárolt keret nem feltétlenül tükrözi a teljes renderelt eredményt.

Használja a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getVisualBounds--) metódust, ha koordinátákra van szüksége elrendezéshez vagy validáláshoz, és nem szükséges bitmap. Használja a [Shape.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage--) metódust, ha a forma renderelésére van szükség. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapethumbnailbounds/) esetén a `ShapeThumbnailBounds.Shape` a képet a forma határai alapján méretezi, beleértve a körvonal beállításokat, míg a `ShapeThumbnailBounds.Appearance` a forma megjelenése alapján méretezi, és a diahatárokra korlátozza az eredményt. Ezzel szemben a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getVisualBounds--) csak a kiszámított téglalapot adja vissza és nem vágja le a diára.

## **FAQ**

**Milyen képadatformátumok használhatók a forma bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/), és egyebek. A formák [exportálhatók vektor SVG‑ként](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) a forma tartalmának SVG‑ként mentésével.

**Mi a különbség a Shape és az Appearance határok között bélyegkép renderelésekor?**

`Shape` a forma geometriáját használja; `Appearance` a [vizuális effekteket](/slides/hu/nodejs-java/shape-effect/) (árnyékok, ragyogás stb.) veszi figyelembe.

**Mi történik, ha egy forma rejtettnek van jelölve? Még megjelenik-e bélyegképként?**

Egy rejtett forma továbbra is része a modellnek és renderelhető; a rejtett jelző a diavetítés megjelenését befolyásolja, de nem akadályozza meg a forma képének előállítását.

**Támogatottak a csoportos formák, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely, [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/)‑ként (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/), és a [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/)) reprezentált objektum menthető bélyegképként vagy SVG‑ként.

**A rendszerben telepített betűkészletek befolyásolják a szövegformák bélyegképeinek minőségét?**

Igen. Ajánlott [a szükséges betűkészletek biztosítása](/slides/hu/nodejs-java/custom-font/) (vagy a [betűkészlet helyettesítések konfigurálása](/slides/hu/nodejs-java/font-substitution/)), hogy elkerülje a nem kívánt helyettesítéseket és a szöveg újraelrendeződését.