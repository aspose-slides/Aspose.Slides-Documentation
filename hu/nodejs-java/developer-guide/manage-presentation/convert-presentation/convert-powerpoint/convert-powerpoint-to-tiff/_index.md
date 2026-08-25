---
title: "PowerPoint-prezentációk konvertálása TIFF-be JavaScript-ben"
titlelink: "PowerPoint TIFF-re"
type: docs
weight: 90
url: /hu/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
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
description: "Ismerje meg, hogyan konvertálhat könnyedén PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for Node.js használatával, JavaScript kódpéldákkal."
---
## **Bevezetés**

TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képformátum, amely kimagasló minőségéről és a grafika részletes megőrzéséről ismert. A tervezők, fényképészek és asztali kiadók gyakran a TIFF-et választják rétegek, színpontosság és az eredeti beállítások megőrzésére a képeikben.

Az Aspose.Slides segítségével könnyedén konvertálhatja PowerPoint-diáit (PPT, PPTX) és OpenDocument-diáit (ODP) közvetlenül magas minőségű TIFF képekké, biztosítva, hogy előadásai a lehető legnagyobb vizuális hűséget megőrizzék.

## **Prezentáció konvertálása TIFF formátumba**

A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály által biztosított [save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) metódus használatával gyorsan konvertálhatja az egész PowerPoint-prezentációt TIFF-be. A keletkezett TIFF képek az alapértelmezett diák méretének felelnek meg.

Ez a JavaScript kód bemutatja, hogyan konvertálható egy PowerPoint-prezentáció TIFF formátumba:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) reprezentál.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Mentse a prezentációt TIFF formátumban.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása fekete-fehér TIFF formátumba**

A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban lévő [setBwConversionMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) metódus lehetővé teszi, hogy megadja a színes dia vagy kép fekete-fehér TIFF formátumba konvertálásához használt algoritmust. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [setCompressionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) metódus `CCITT4` vagy `CCITT3` értékre van állítva.

{{% alert color="info" title="Note" %}}
A [TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) egy export-szintű beállítás, amely a teljes TIFF kép pixelkonvertálási algoritmusát választja. Annak meghatározásához, hogyan jelenjen meg egy adott alakzat fekete-fehér megjelenítési módban, használja a [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) metódust. Példákért tekintse meg a [Control Black-and-White Rendering for Shapes](/slides/hu/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) oldalt.
{{% /alert %}}

Hogyan legyen, ha van egy "sample.pptx" fájlunk a következő diával:

![Prezentációs dia](slide_black_and_white.png)

Ez a JavaScript kód bemutatja, hogyan konvertálható a színes dia fekete-fehér TIFF formátumba:

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

## **Prezentáció konvertálása TIFF formátumba egyedi mérettel**

Ha konkrét méretű TIFF képre van szüksége, a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban elérhető metódusokkal állíthatja be a kívánt értékeket. Például a [setImageSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setImageSize) metódus lehetővé teszi a keletkezett kép méretének meghatározását.

Ez a JavaScript kód bemutatja, hogyan konvertálható egy PowerPoint-prezentáció egyedi méretű TIFF képekké:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képviseli.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Állítsa be a tömörítési típust.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Tömörítési típusok:
        Default - A alapértelmezett tömörítési sémát (LZW) jelöli.
        None - Nem alkalmaz tömörítést.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // A színmélységet a pixel formátum szabályozza (lásd az alábbi példát); a CCITT3 és CCITT4 mindig 1 bit per pixel-t eredményez.

    // Állítsa be a kép DPI-ját.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Állítsa be a kép méretét.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Mentse a prezentációt TIFF-be a megadott mérettel.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása TIFF formátumba egyedi képpontformátummal**

A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban lévő [setPixelFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) metódus segítségével megadhatja a kívánt pixelformátumot a keletkezett TIFF képhez.

Ez a JavaScript kód bemutatja, hogyan konvertálható egy PowerPoint-prezentáció egyedi pixelformátummal ellátott TIFF képbe:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) reprezentál.
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

    /// Mentse a prezentációt TIFF-be a megadott képmérettel.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Tekintse meg az Aspose [INGYENES PowerPoint poszter konverterét](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Konvertálhatok egyetlen diát az egész PowerPoint-prezentáció helyett TIFF-be?**

Igen. Az Aspose.Slides lehetővé teszi, hogy a PowerPoint és OpenDocument prezentációkból egyes diákat külön-külön TIFF képekké konvertáljon.

**Nem korlátozza a diák száma a prezentációk TIFF-re konvertálásakor?**

Nem, az Aspose.Slides nem korlátozza a diák számát. Bármilyen méretű prezentációt konvertálhat TIFF formátumba.

**Megőrződnek-e a PowerPoint animációk és átmenetek, amikor diákat konvertálunk TIFF-re?**

Nem, a TIFF egy statikus képformátum. Így az animációk és átmeneti hatások nem kerülnek megőrzésre; csak a diák statikus pillanatképei kerülnek exportálásra.