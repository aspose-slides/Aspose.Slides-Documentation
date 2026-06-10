---
title: Diák formáinak bélyegképeinek létrehozása Java-ban
linktitle: Forma bélyegképek
type: docs
weight: 70
url: /hu/java/create-shape-thumbnails/
keywords:
- forma bélyegkép
- forma kép
- forma renderelése
- forma renderelés
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Készítsen magas minőségű forma bélyegképeket PowerPoint diákról az Aspose.Slides for Java segítségével – egyszerűen hozhat létre és exportálhat prezentációs bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides for Java használható prezentációs fájlok létrehozására, ahol minden oldal egy diát képvisel. A diákat a Microsoft PowerPoint‑al lehet megnyitni. Néha azonban a fejlesztők a formák képeit külön szeretnék megtekinteni egy képnéző programban. Ilyen esetekben az Aspose.Slides for Java segít bélyegkép képeket generálni a diák formáiról.

Ez a cikk bemutatja, hogyan lehet különböző módokon generálni diabélyegképeket:

- Egy dián belüli forma bélyegképének előállítása.
- Felhasználó által meghatározott méretekkel rendelkező forma bélyegképének előállítása.
- A forma megjelenésének határain belüli bélyegkép előállítása.

## **Forma bélyegkép generálása diáról**
A forma bélyegkép generálásához bármely diáról az Aspose.Slides for Java‑val kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
2. Szerezze meg a kívánt dia hivatkozását azonosítója vagy indexe alapján.
3. [Szerezze meg a forma bélyegkép képét](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getImage--) a hivatkozott diáról az alapértelmezett méretben.
4. Mentse a bélyegképet a kívánt képformátumban.

Az alábbi minta kód megmutatja, hogyan kell egy diáról forma bélyegképet generálni:

```java
// Példányosít egy Presentation osztályt, amely a prezentációfájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Létrehoz egy teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Mentse a képet lemezen PNG formátumban
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Felhasználó által meghatározott léptékmértékű bélyegkép generálása**
A dián lévő forma bélyegképének generálásához az Aspose.Slides for Java‑val tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
2. Szerezze meg a kívánt dia hivatkozását azonosítója vagy indexe alapján.
3. [Szerezze meg a forma bélyegkép képét](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getImage-int-float-float-) a hivatkozott diáról felhasználó által meghatározott méretekkel.
4. Mentse a bélyegképet a kívánt képformátumban.

Az alábbi minta kód megmutatja, hogyan kell egy definiált léptékmérték alapján forma bélyegképet generálni:

```java
// Példányosít egy Presentation osztályt, amely a prezentációfájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Létrehoz egy teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Mentse a képet lemezen PNG formátumban
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Határ alapú forma megjelenésű bélyegkép létrehozása**
Ez a módszer lehetővé teszi, hogy a fejlesztők a forma megjelenésének határain belül generáljanak bélyegképet, figyelembe véve a forma összes effektusát. A generált forma bélyegkép a dia határai között korlátozódik. A megjelenés határon belüli diára vonatkozó forma bélyegkép előállításához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
2. Szerezze meg a kívánt dia hivatkozását azonosítója vagy indexe alapján.
3. Szerezze meg a hivatkozott dia bélyegképét a forma határak alapján, mint megjelenés.
4. Mentse a bélyegképet a kívánt képformátumban.

Az alábbi minta kód a fenti lépések alapján készült:

```java
// Példányosít egy Presentation osztályt, amely a prezentációfájlt képviseli
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Létrehoz egy teljes méretű képet
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Mentse a képet lemezen PNG formátumban
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

**Milyen képformátumok használhatók forma bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/), és egyebek. A formák [vektorként exportálhatók SVG‑ként](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) a forma tartalmának SVG‑ként mentésével.

**Mi a különbség a Shape és az Appearance határok között a bélyegkép renderelésekor?**

A `Shape` a forma geometriai határait használja; az `Appearance` a [visual effects](/slides/hu/java/shape-effect/) (árnyékok, fények stb.) figyelembevételével számít.

**Mi történik, ha egy forma rejtettként van megjelölve? Megjelenik még mindig bélyegkép formájában?**

A rejtett forma továbbra is része a modellnek és renderelhető; a rejtett jelző csak a diavetítés megjelenését befolyásolja, de nem akadályozza meg a forma képének generálását.

**Támogatottak-e a csoportos formák, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely objektum, amely [Shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/)‑ként van reprezentálva (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/) és a [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/smartart/) elemeket), menthető bélyegkép vagy SVG formájában.

**A rendszerben telepített betűtípusok befolyásolják a szövegformák bélyegképeinek minőségét?**

Igen. Ajánlott [a szükséges betűtípusok biztosítása](/slides/hu/java/custom-font/) (vagy a [betűtípus‑helyettesítés beállítása](/slides/hu/java/font-substitution/)) a nem kívánt visszaesések és a szöveg átrendeződésének elkerülése érdekében.