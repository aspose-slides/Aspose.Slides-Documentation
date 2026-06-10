---
title: Diaformák bélyegképeinek létrehozása Androidon
linktitle: Forma bélyegképek
type: docs
weight: 70
url: /hu/androidjava/create-shape-thumbnails/
keywords:
- forma bélyegkép
- forma kép
- forma renderelése
- forma renderelés
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Készítsen nagy felbontású forma bélyegképeket PowerPoint diákról az Aspose.Slides for Android via Java segítségével – egyszerűen hozhat létre és exportálhat bemutató bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java használható bemutatófájlok létrehozására, ahol minden oldal egy diára vonatkozik. A diákat a Microsoft PowerPoint segítségével nyitható meg. Néha azonban a fejlesztőknek külön képfeldolgozóban kell megtekinteniük a formák képeit. Ilyen esetekben az Aspose.Slides for Android via Java segít kis bélyegkép képeket generálni a diaformákról.

Ebben a témában bemutatjuk, hogyan generálhatunk dia bélyegképeket különböző helyzetekben:

- Forma bélyegkép generálása egy dián belül.
- Forma bélyegkép generálása egy diára vonatkozó formához felhasználó által meghatározott méretekkel.
- Forma bélyegkép generálása a forma megjelenésének határain belül.

## **Forma bélyegkép generálása diáról**
Az Aspose.Slides for Android via Java használatával egy tetszőleges diáról forma bélyegkép generálásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Szerezze meg egy tetszőleges dia referenciáját az ID vagy index alapján.
3. [Szerezze meg a forma bélyegkép képét](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getImage--) a hivatkozott diáról alapértelmezett méretben.
4. Mentse a bélyegkép képet a kívánt képformátumban.

Ez a példakód megmutatja, hogyan generálhat forma bélyegképet egy diáról:

```java
// Létrehozza a Presentation osztályt, amely a bemutató fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Teljes méretű képet hoz létre
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // A képet PNG formátumban menti le a lemezre
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Felhasználó által meghatározott méretezési tényező bélyegkép generálása**
Az Aspose.Slides for Android via Java használatával egy dia forma bélyegképének generálásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Szerezze meg egy tetszőleges dia referenciáját az ID vagy index alapján.
3. [Szerezze meg a forma bélyegkép képét](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) a hivatkozott diáról felhasználó által meghatározott méretekkel.
4. Mentse a bélyegkép képet a kívánt képformátumban.

Ez a példakód megmutatja, hogyan generálhat forma bélyegképet egy meghatározott méretezési tényező alapján:

```java
// Létrehozza a Presentation osztályt, amely a bemutató fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Teljes méretű képet hoz létre
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // A képet PNG formátumban menti le a lemezre
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Határoló-alapú forma megjelenés bélyegkép létrehozása**
Ez a forma bélyegképek létrehozási módszer lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül generáljanak bélyegképet. Figyelembe veszi az összes formahatást. A generált forma bélyegkép a dia határai által van korlátozva. A dia forma bélyegképének a megjelenésének határán belül történő generálásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Szerezze meg egy tetszőleges dia referenciáját az ID vagy index alapján.
3. Szerezze meg a hivatkozott dia bélyegképét a forma határaival mint megjelenés.
4. Mentse a bélyegkép képet a kívánt képformátumban.

Ez a példakód a fenti lépések alapján készült:

```java
// Létrehozza a Presentation osztályt, amely a bemutató fájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Teljes méretű képet hoz létre
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // A képet PNG formátumban menti le a lemezre
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Milyen képformátumok használhatók a forma bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/), és egyebek. A formák [exportálhatók vektor SVG-ként](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) a forma tartalmának SVG-ként mentésével.

**Mi a különbség a Shape és az Appearance határok között a bélyegkép renderelésekor?**

`Shape` a forma geometriai adatait használja; `Appearance` a [vizuális hatásokat](/slides/hu/androidjava/shape-effect/) (árnyékok, ragyogások stb.) veszi figyelembe.

**Mi történik, ha egy forma rejtettnek van jelölve? Még mindig megjelenik-e bélyegképként?**

A rejtett forma továbbra is része a modellnek, és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg a forma képének generálását.

**Támogatottak a csoportos formák, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely objektum, amely a [Shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/) (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/), és a [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/smartart/)) formájában van reprezentálva, menthető bélyegképként vagy SVG-ként.

**A rendszerben telepített betűkészletek befolyásolják a szöveges formák bélyegképeinek minőségét?**

Igen. Ajánlott [a szükséges betűkészleteket biztosítani](/slides/hu/androidjava/custom-font/) (vagy [betűkészlet helyettesítéseket beállítani](/slides/hu/androidjava/font-substitution/)), hogy elkerüljük a nem kívánt tartalomcsere- és szövegújraelrendezési problémákat.