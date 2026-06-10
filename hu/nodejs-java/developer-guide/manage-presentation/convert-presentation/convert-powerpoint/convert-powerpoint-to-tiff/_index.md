---
title: PowerPoint prezentációk konvertálása TIFF-be JavaScriptben
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
description: "Ismerje meg, hogyan konvertálhat egyszerűen PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for Node.js használatával, JavaScript kódpéldákkal."
---
## **Bevezetés**

TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képformátum, amely kiemelkedő minőségéről és a grafika részletes megőrzéséről ismert. Tervezők, fotósok és asztali kiadók gyakran választják a TIFF-et a rétegek, a színpontosság és az eredeti beállítások megőrzése érdekében.

Az Aspose.Slides segítségével egyszerűen konvertálhatja PowerPoint diái (PPT, PPTX) és OpenDocument diái (ODP) közvetlenül magas minőségű TIFF képekké, biztosítva, hogy prezentációi a maximális vizuális hitelességet megőrizzék.

## **Prezentáció konvertálása TIFF formátumba**

A [mentés](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) metódus használatával, amelyet a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály biztosít, gyorsan konvertálhat egy teljes PowerPoint prezentációt TIFF-be. A keletkezett TIFF képek a alapértelmezett dia méretnek felelnek meg.

Ez a JavaScript kód bemutatja, hogyan konvertáljunk egy PowerPoint prezentációt TIFF-be:

```js
// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képviseli.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Mentse a prezentációt TIFF formátumban.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása fekete-fehér TIFF formátumba**

A [setBwConversionMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) metódus a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban lehetővé teszi, hogy megadja az algoritmust, amelyet színes dia vagy kép fekete-fehér TIFF-be történő konvertálásakor használ. Vegye figyelembe, hogy ez a beállítás csak akkor érvényes, ha a [setCompressionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) metódus `CCITT4` vagy `CCITT3` értékre van állítva.

Tegyük fel, hogy van egy „sample.pptx” fájlunk a következő diával:

![Egy prezentációs dia](slide_black_and_white.png)

Ez a JavaScript kód bemutatja, hogyan konvertáljuk a színes diát fekete-fehér TIFF-be:

```js
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

## **Prezentáció konvertálása egyéni méretű TIFF formátumba**

Ha olyan TIFF képre van szüksége, amelynek meghatározott méretei vannak, a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályban elérhető metódusokkal beállíthatja a kívánt értékeket. Például a [setImageSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setImageSize) metódus lehetővé teszi a keletkezett kép méretének meghatározását.

Ez a JavaScript kód bemutatja, hogyan konvertáljunk egy PowerPoint prezentációt egyéni méretű TIFF képekké:

```js
// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Állítsa be a tömörítési típust.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Tömörítési típusok:
        Default - Az alapértelmezett tömörítési sémát határozza meg (LZW).
        None - Nem használ tömörítést.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // A mélység a tömörítési típustól függ, és nem állítható be manuálisan.

    // Állítsa be a kép DPI értékét.
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

## **Prezentáció konvertálása egyéni képpontformátumú TIFF formátumba**

A [setPixelFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) metódussal a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályból megadhatja a kívánt képpontformátumot a keletkezett TIFF képhez.

Ez a JavaScript kód bemutatja, hogyan konvertáljunk egy PowerPoint prezentációt egyéni képpontformátumú TIFF képbe:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    Az ImagePixelFormat a következő értékeket tartalmazza (a dokumentáció szerint):
        Format1bppIndexed - 1 bit per pixel, indexelt.
        Format4bppIndexed - 4 bit per pixel, indexelt.
        Format8bppIndexed - 8 bit per pixel, indexelt.
        Format24bppRgb    - 24 bit per pixel, RGB.
        Format32bppArgb   - 32 bit per pixel, ARGB.
    */

    /// Mentse a prezentációt TIFF formátumban a megadott képmérettel.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tipp" color="primary" %}}

Tekintse meg az Aspose ingyenes [PowerPoint poszter konverterét](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **GYIK**

**Konvertálhatok egyetlen diát a teljes PowerPoint prezentáció helyett TIFF-be?**

Igen. Az Aspose.Slides lehetővé teszi, hogy egyes diákat a PowerPoint és OpenDocument prezentációkból külön-külön TIFF képekké konvertáljon.

**Van valamilyen korlátozás a diák számát illetően, amikor prezentációt konvertálunk TIFF-be?**

Nem, az Aspose.Slides nem szab korlátozásokat a diák számára. Bármilyen méretű prezentációt konvertálhat TIFF formátumba.

**A PowerPoint animációk és áttűnési effektusok megmaradnak a diák TIFF-be konvertálásakor?**

Nem, a TIFF egy statikus képformátum. Ezért az animációk és áttűnési effektusok nem maradnak meg; csak a diák statikus pillanatképei exportálódnak.