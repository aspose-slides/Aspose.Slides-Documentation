---
title: Prezentációs alakzatok bélyegképeinek létrehozása Androidon
linktitle: Alakzat bélyegképek
type: docs
weight: 70
url: /hu/androidjava/create-shape-thumbnails/
keywords:
- alakzat bélyegkép
- alakzat kép
- alakzat renderelése
- alakzat renderelés
- vizuális határok
- alakzat határok
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Készítsen magas minőségű alakzat bélyegképeket PowerPoint diákról az Aspose.Slides for Android via Java segítségével – egyszerűen hozhat létre és exportálhat prezentációs bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java használható olyan prezentációs fájlok létrehozására, ahol minden oldal egy diának felel meg. A diákat a Microsoft PowerPoint segítségével nyithatja meg. Néha a fejlesztőknek különálló képszerkesztőben kell megtekinteniük a formák képeit. Ilyen esetekben az Aspose.Slides for Android via Java segít a diák alakzatainak bélyegképét generálni.

Ebben a témában bemutatjuk, hogyan lehet különböző helyzetekben diabélyegképeket készíteni:

- Alakzat bélyegképének generálása dián belül.
- Alakzat bélyegképének generálása felhasználó által meghatározott méretekkel.
- Alakzat bélyegképének készítése a forma megjelenésének határain belül.

## **Alakzat bélyegképének generálása diáról**
Az Aspose.Slides for Android via Java segítségével egy bármely dia alakzatának bélyegképét a következőképpen hozhatja létre:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezze be egy diát a referencia segítségével azonosító vagy index alapján.
1. [Szerezze meg az alakzat bélyegképét](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getImage--) a hivatkozott diáról alapértelmezett méretezéssel.
1. Mentse a bélyegképet a kívánt képformátumban.

Ez a példakód megmutatja, hogyan generálhat bélyegképet egy alakzatról egy dián:

```java
// Példányosítsa a Presentation osztályt, amely a prezentációs fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Készítsen teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Mentse a képet lemezre PNG formátumban
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Felhasználó által definiált méretezési tényező bélyegképe**
Az Aspose.Slides for Android via Java segítségével egy dián lévő alakzat bélyegképét a következőképpen állíthatja be felhasználó által meghatározott méretekkel:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezze be egy diát a referencia segítségével azonosító vagy index alapján.
1. [Szerezze meg az alakzat bélyegképét](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) a hivatkozott diáról felhasználó által meghatározott dimenziókkal.
1. Mentse a bélyegképet a kívánt képformátumban.

Ez a példakód megmutatja, hogyan generálhat bélyegképet egy meghatározott méretezési tényező alapján:

```java
// Példányosítsa a Presentation osztályt, amely a prezentációs fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Készítsen teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Mentse a képet lemezre PNG formátumban
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
Ez a módszer lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül generáljanak bélyegképet, figyelembe véve az összes formahatást. A generált bélyegkép a dián lévő határokra korlátozódik. A forma megjelenésének határain belül lévő diababélyegkép előállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezze be egy diát a referencia segítségével azonosító vagy index alapján.
1. Szerezze meg a hivatkozott dia bélyegképét úgy, hogy a forma határait a megjelenésként használja.
1. Mentse a bélyegképet a kívánt képformátumban.

Ez a példakód az előző lépések alapján készült:

```java
// Egy Presentation osztály példányosítása, amely a prezentációs fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Készítsen teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Mentse a képet lemezre PNG formátumban
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **A forma tényleges vizuális határainak lekérdezése**

Az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) keret‑tulajdonságai – a `getX()`, `getY()`, `getWidth()`, és `getHeight()` metódusok – a prezentációs modellben tárolt téglalapot írják le. A ténylegesen renderelt tartalom meghaladhatja ezt a keretet, vagy egy másik tengely‑igazított téglalapot foglalhat el. A forgatás, vonalak, nyilak, szövegelrendezés és túlcsordulás, a generált SmartArt geometria és egyéb renderelési hatások mind változtathatják az elfoglalt területet.

Használja a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getVisualBounds--) metódust, hogy ezt a területet képkészítés nélkül kiszámítsa. A metódus egy [RectF](https://developer.android.com/reference/android/graphics/RectF) objektumot ad vissza diakoordinátákban. A visszaadott téglalap nincs levágva a diára, ezért koordinátái negatívak is lehetnek, ha a tartalom túlnyúlik a dia eredetén.

A [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getVisualBounds--) jelenleg nincs deklarálva az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) felületen. Ezért a dián lévő forma gyűjteményéből származó formát interfész‑értékként tartsa meg, és csak a metódus hívásakor cast-olja át.

Az alábbi példa lekérdezi és összehasonlítja a keret‑ és a vizuális határokat:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Ugyanazt a [RectF](https://developer.android.com/reference/android/graphics/RectF) objektumot használhatja a közeli formák balra, jobbra, felül vagy alul lévő élére igazításhoz; elegendő hely lefoglalásához egy generált elrendezésben; vagy a megengedett területen kívüli tartalom észleléséhez. A vizuális határok különösen hasznosak SmartArt, szövegdobozok, nyilak, képek, elforgatott alakzatok és csoportos formák esetén, ahol a tárolt keret nem tükrözi a teljes renderelt eredményt.

Használja a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getVisualBounds--) metódust, ha koordinátákra van szüksége elrendezéshez vagy validációhoz, és nem szükséges bitmap. Használja az [IShape.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getImage--) metódust, ha a formát renderelni kell. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapethumbnailbounds/) esetén a `ShapeThumbnailBounds.Shape` a képet a forma határaiból méretezi, beleértve a kontúr beállításokat, míg a `ShapeThumbnailBounds.Appearance` a kép méretét a forma megjelenéséből veszi, és a diahatárokra korlátozza az eredményt. Ezzel szemben a [Shape.getVisualBounds](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getVisualBounds--) csak a kiszámított téglalapot adja vissza, és nem vágja le a diára.

## **GYIK**

**Milyen képformátumok használhatók az alakzat bélyegképeinek mentésekor?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/), és egyebek. Az alakzatok [exportálhatók vektor SVG‑ként](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) a forma tartalmának SVG‑ként mentésével.

**Mi a különbség a Shape és az Appearance határok között bélyegkép renderelésekor?**  
`Shape` a forma geometriáját használja; `Appearance` figyelembe veszi a [vizuális hatásokat](/slides/hu/androidjava/shape-effect/) (árnyékok, fények stb.).

**Mi történik, ha egy alakzat rejtettként van megjelölve? Továbbra is generálódik a bélyegképe?**  
A rejtett alakzat továbbra is része a modellnek és renderelhető; a rejtett jelző a diavetítés megjelenését befolyásolja, de nem akadályozza meg az alakzat képének generálását.

**Támogatottak a csoportos alakzatok, diagramok, SmartArt és egyéb összetett objektumok?**  
Igen. Bármely, [Shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/)‑ként reprezentált objektum (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/), és a [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/smartart/)) menthető bélyegkép vagy SVG formátumban.

**Hatással vannak a rendszerben telepített betűtípusok a szöveges alakzatok bélyegképének minőségére?**  
Igen. Ajánlott [szükséges betűtípusokat biztosítani](/slides/hu/androidjava/custom-font/) (vagy [betűtípus‑helyettesítéseket konfigurálni](/slides/hu/androidjava/font-substitution/)), hogy elkerülje a nem kívánt fallback‑eket és a szöveg átrendeződését.