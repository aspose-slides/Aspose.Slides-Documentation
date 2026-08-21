---
title: PowerPoint prezentációk konvertálása TIFF-re JavaScript-ben
titlelink: PowerPoint TIFF-re
type: docs
weight: 90
url: /hu/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint TIFF-re
- prezentáció TIFF-re
- dia TIFF-re
- PPT TIFF-re
- PPTX TIFF-re
- PPT mentése TIFF-ként
- PPTX mentése TIFF-ként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet egyszerűen konvertálni a PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for Node.js használatával, JavaScript kódrészletekkel."
---
## **Bevezetés**

A TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képfájl formátum, amely kivételes minőségéről és a grafikák részletes megőrzéséről ismert. A tervezők, fényképészek és asztali kiadványszerkesztők gyakran választják a TIFF-et, hogy megőrizzék a rétegeket, a színpontosságot és az eredeti beállításokat a képeiken.

Az Aspose.Slides segítségével egyszerűen konvertálhatja PowerPoint diái (PPT, PPTX) és OpenDocument diái (ODP) közvetlenül magas minőségű TIFF képekké, biztosítva, hogy a bemutatók megőrzik a maximális vizuális hűséget.

## **Prezentáció konvertálása TIFF-be**

A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály által biztosított [save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) metódus használatával gyorsan konvertálhat egy teljes PowerPoint prezentációt TIFF formátumba. A létrehozott TIFF képek az alapértelmezett dia méretnek felelnek meg.

Ez a JavaScript kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt TIFF formátumba:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// A Presentation osztály példányosítása, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // A prezentáció mentése TIFF formátumba.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása fekete-fehér TIFF-be**

A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban található [setBwConversionMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) metódus lehetővé teszi, hogy megadja az algoritmust, amelyet színes dia vagy kép fekete-fehér TIFF-be konvertálásakor használ. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [setCompressionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) metódus `CCITT4` vagy `CCITT3` értékre van állítva.

{{% alert color="info" title="Megjegyzés" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) egy export-szintű beállítás, amely egy képpont-konvertálási algoritmust választ a teljes TIFF képhez. Annak meghatározásához, hogy egy adott alakzat hogyan jelenjen meg fekete-fehér megjelenítési módban, használja a [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) metódust. Példákért tekintse meg a [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) oldalt.
{{% /alert %}}

Tegyük fel, hogy van egy "sample.pptx" fájlunk a következő diával:

![Egy prezentációs dia](slide_black_and_white.png)

Ez a JavaScript kód bemutatja, hogyan konvertálhatja a színes diát fekete-fehér TIFF-be:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Fekete-fehér TIFF](TIFF_black_and_white.png)

## **Prezentáció konvertálása TIFF-be egyéni mérettel**

Ha egy adott méretű TIFF képre van szüksége, akkor a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban elérhető metódusokkal beállíthatja a kívánt értékeket. Például a [setImageSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setImageSize) metódus lehetővé teszi a létrehozott kép méretének meghatározását.

Ez a JavaScript kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt egyéni méretű TIFF képekké:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// A Presentation osztály példányosítása, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Állítsa be a tömörítési típust.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Tömörítési típusok:
        Default - Az alapértelmezett tömörítési séma (LZW) meghatározása.
        None - Nincs tömörítés.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // A színmélységet a képpontformátum szabályozza (lásd alább a példát); a CCITT3 és CCITT4 mindig 1 bitet képpontonként állít elő.

    // Állítsa be a kép DPI-jét.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Állítsa be a kép méretét.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Mentse a prezentációt TIFF formátumban a megadott mérettel.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása TIFF-be egyéni képpontformátummal**

A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban található [setPixelFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) metódus segítségével megadhatja a kívánt képpontformátumot a létrehozott TIFF képhez.

Ez a JavaScript kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt egyéni képpontformátummal rendelkező TIFF képre:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// A Presentation osztály példányosítása, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    Az ImagePixelFormat a következő értékeket tartalmazza (a dokumentáció szerint):
        Format1bppIndexed - 1 bit képpontonként, indexelt.
        Format4bppIndexed - 4 bit képpontonként, indexelt.
        Format8bppIndexed - 8 bit képpontonként, indexelt.
        Format24bppRgb    - 24 bit képpontonként, RGB.
        Format32bppArgb   - 32 bit képpontonként, ARGB.
    */

    /// Mentse a prezentációt TIFF formátumban a megadott kép mérettel.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tipp" color="info" %}}
Tekintse meg az Aspose ingyenes [PowerPoint poszter konverterét](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Konvertálhatok egyedi diát az egész PowerPoint prezentáció helyett TIFF-be?**  
Igen. Az Aspose.Slides lehetővé teszi, hogy egyedi diákat konvertáljon PowerPoint és OpenDocument prezentációkból TIFF képekké külön-külön.

**Van korlátozás a diák számában a prezentáció TIFF-be konvertálása során?**  
Nem, az Aspose.Slides nem állapít meg semmilyen korlátozást a diák számában. Bármilyen méretű prezentációt konvertálhat TIFF formátumba.

**A PowerPoint animációk és átmenetek megmaradnak a diák TIFF-be konvertálásakor?**  
Nem, a TIFF egy statikus képfájl formátum. Ezért az animációk és átmenetek nem maradnak meg; csak a diák statikus pillanatképei exportálódnak.