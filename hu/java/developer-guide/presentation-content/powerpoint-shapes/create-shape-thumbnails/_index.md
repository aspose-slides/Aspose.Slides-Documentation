---
title: Prezentációs alakzatok bélyegképeinek létrehozása Java-ban
linktitle: Alakzat bélyegképek
type: docs
weight: 70
url: /hu/java/create-shape-thumbnails/
keywords:
- alakzat bélyegkép
- alakzat kép
- alakzat renderelése
- alakzat renderelés
- vizuális határok
- alakzat határok
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Készítsen nagy minőségű alakzat bélyegképeket PowerPoint diákról az Aspose.Slides for Java segítségével – egyszerűen hozhat és exportálhat prezentációs bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides for Java használható prezentációs fájlok létrehozására, ahol minden oldal egy diát jelent. A diák megtekinthetők a prezentációs fájlok Microsoft PowerPoint-ban történő megnyitásával. Bizonyos esetekben a fejlesztőknek azonban külön képnézőben kell megtekinteniük a alakzatok képeit. Ilyenkor az Aspose.Slides for Java segít a diák alakzatainak bélyegképének előállításában.

Ez a cikk bemutatja, hogyan generálhatók a dia bélyegképek különböző módokon:

- Alakzat bélyegképének generálása egy dián belül.
- Alakzat bélyegképének generálása felhasználó által meghatározott méretekkel a dia alakzata számára.
- Alakzat bélyegképének generálása az alakzat megjelenésének határain belül.

## **Alakzat bélyegképének generálása diáról**

Az Aspose.Slides for Java használatával egy bármelyik diáról történő alakzat bélyegkép generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Szerezze be egy diára a hivatkozást az ID vagy index használatával.
3. [Az alakzat bélyegképének lekérése](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getImage--) a hivatkozott diáról alapértelmezett méretezésben.
4. Mentse el a bélyegképet a kívánt képformátumban.

Ez a mintakód bemutatja, hogyan generálhat alakzat bélyegképet egy diáról:

```java
// Példányosít egy Presentation osztályt, amely a prezentációs fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Hozzon létre egy teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Mentse a képet a lemezre PNG formátumban
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Felhasználó által meghatározott méretezési tényezővel rendelkező bélyegkép generálása**

Az Aspose.Slides for Java használatával egy dia alakzatának bélyegképének generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Szerezze be egy diára a hivatkozást az ID vagy index használatával.
3. [A forma bélyegképének lekérése](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getImage-int-float-float-) a hivatkozott diáról felhasználó által meghatározott méretekkel.
4. Mentse el a bélyegképet a kívánt képformátumban.

Ez a mintakód bemutatja, hogyan generálhat egy alakzat bélyegképet a meghatározott méretezési tényező alapján:

```java
// Példányosít egy Presentation osztályt, amely a prezentációs fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Hozzon létre egy teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Mentse a képet a lemezre PNG formátumban
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Határokon alapuló alakzat megjelenés bélyegkép létrehozása**

Ez a módszer a formák bélyegképeinek létrehozására lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül előállítsanak bélyegképet. Figyelembe veszi az összes formahatást. Az előállított forma bélyegképét a dia határai korlátozzák. A dia forma bélyegképének a megjelenés határain belül történő generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Szerezze be egy diára a hivatkozást az ID vagy index használatával.
3. Szerezze meg a hivatkozott dia bélyegképét a forma határainak megjelenésként való használatával.
4. Mentse el a bélyegképet a kívánt képformátumban.

Ez a mintakód a fenti lépések alapján készült:

```java
// Példányosít egy Presentation osztályt, amely a prezentációs fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Hozzon létre egy teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Mentse a képet a lemezre PNG formátumban
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **A forma tényleges vizuális határainak lekérése**

[IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) keret tulajdonságai—a `getX()`, `getY()`, `getWidth()` és `getHeight()` metódusai—leírják a prezentáció modellben tárolt téglalapot. Az a tartalom, amely ténylegesen megjelenik, kiterjedhet a kereten túlra, vagy egy másik tengelyre igazított téglalapot foglalhat el. A forgatás, körvonalak, nyílfejek, szöveg elrendezés és túlcsordulás, a generált SmartArt geometria és egyéb renderelési hatások mind módosíthatják a lefedett területet.

Használja a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getVisualBounds--) metódust, hogy kiszámítsa azt a lefedett területet anélkül, hogy képet hozna létre. A metódus egy [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) objektumot ad vissza dia koordinátákban. A visszaadott téglalap nincs vágva a diára, így koordinátái negatívak lehetnek, ha a tartalom a dia kiindulópontja túlra terjed.

[Shape.getVisualBounds](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getVisualBounds--) jelenleg nincs deklarálva az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) felületen. Ezért a diák alakzatelőállításából származó alakzatot interfacéként tartsa meg, és csak a metódus hívásakor végezzen cast-ot.

A következő példa lekéri és összehasonlítja a keret és a vizuális határokat:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

A same [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) használható a közeli alakzatok balra, jobbra, felül vagy alul lévő szélhez való igazításához; elegendő hely lefoglalásához egy generált elrendezésben; vagy a megengedett területen kívül eső tartalom észlelésére. A vizuális határok különösen hasznosak a SmartArt, szövegdobozok, nyilak, képek, forgatott alakzatok és csoportos alakzatok esetén, ahol a tárolt keret nem tükrözi a teljes renderelt eredményt.

Használja a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getVisualBounds--) metódust, ha elrendezéshez vagy ellenőrzéshez koordinátákra van szüksége, és nem szükséges bitmap. Használja az [IShape.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getImage--) metódust, ha a forma renderelése szükséges. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapethumbnailbounds/) esetén a `ShapeThumbnailBounds.Shape` a kép méretét a forma határainak figyelembe vételével állítja be, beleértve a körvonal beállításokat, míg a `ShapeThumbnailBounds.Appearance` a forma megjelenéséből méretezi a képet, és a diára korlátozza az eredményt. Ezzel szemben a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getVisualBounds--) csak a kiszámított téglalapot adja vissza, és nem vágja le a diára.

## **GYIK**

**Milyen képformátumok használhatók a forma bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/), és mások. Az alakzatok vektor SVG‑ként is [exportálhatók](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) a forma tartalmának SVG‑ként történő mentésével.

**Mi a különbség a Shape és az Appearance határok között a bélyegkép renderelésekor?**

`Shape` a forma geometriáját használja; `Appearance` a [vizuális hatásokat](/slides/hu/java/shape-effect/) (árnyékok, ragyogás stb.) veszi figyelembe.

**Mi történik, ha egy alakzat rejtettnek van jelölve? Még mindig generál-e bélyegképet?**

A rejtett alakzat továbbra is része a modellnek, és renderelhető; a rejtett jelző a diavetítés megjelenését befolyásolja, de nem akadályozza meg a forma képének előállítását.

**Támogatottak a csoportos alakzatok, diagramok, SmartArt és más összetett objektumok?**

Igen. Bármely, [Shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/)‑ként reprezentált objektum (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/) és a [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/smartart/) elemeket) menthető bélyegképként vagy SVG‑ként.

**A rendszerben telepített betűtípusok befolyásolják a szöveg alakzatok bélyegképeinek minőségét?**

Igen. Ajánlott [a szükséges betűtípusokat biztosítani](/slides/hu/java/custom-font/) (vagy [betűtípus helyettesítéseket konfigurálni](/slides/hu/java/font-substitution/)), hogy elkerülje a nem kívánt helyettesítéseket és a szöveg újrarendeződését.