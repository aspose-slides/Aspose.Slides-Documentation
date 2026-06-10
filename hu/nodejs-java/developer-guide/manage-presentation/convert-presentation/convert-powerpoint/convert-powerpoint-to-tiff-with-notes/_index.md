---
title: PowerPoint bemutatók konvertálása TIFF-re jegyzetekkel JavaScript-ben
linktitle: PowerPoint TIFF-re jegyzetekkel
type: docs
weight: 100
url: /hu/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertálása
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
- PowerPoint jegyzetekkel
- prezentáció jegyzetekkel
- dia jegyzetekkel
- PPT jegyzetekkel
- PPTX jegyzetekkel
- TIFF jegyzetekkel
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint bemutatók konvertálása TIFF-re jegyzetekkel JavaScript-ben az Aspose.Slides for Node.js használatával. Ismerje meg, hogyan exportálhatja a diák előadói jegyzeteit hatékonyan."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java egyszerű megoldást kínál a PowerPoint és OpenDocument bemutatók (PPT, PPTX és ODP) jegyzetekkel történő TIFF formátumba konvertálására. Ez a formátum széles körben használatos nagy felbontású képek tárolására, nyomtatásra és dokumentum archiválásra. Az Aspose.Slides segítségével nemcsak az egész bemutatót exportálhatja előadói jegyzetekkel, hanem a dia bélyegképeit is előállíthatja a Jegyzet Dia nézetben. A konvertálási folyamat egyszerű és hatékony, a `save` metódus használatával a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból átalakítja a teljes bemutatót egy sor TIFF képre, miközben megőrzi a jegyzeteket és az elrendezést.

## **Bemutató konvertálása TIFF-re jegyzetekkel**

PowerPoint vagy OpenDocument bemutató TIFF-re mentése jegyzetekkel az Aspose.Slides for Node.js via Java használatával a következő lépésekből áll:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályt: Töltsön be egy PowerPoint vagy OpenDocument fájlt.
2. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) osztályt annak meghatározásához, hogyan jelenjenek meg a jegyzetek és megjegyzések.
3. Mentse a bemutatót TIFF formátumba: Adja át a beállított opciókat a [save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódusnak.

Tegyük fel, hogy van egy "speaker_notes.pptx" fájlunk a következő diával:

![A prezentációs dia előadói jegyzetekkel](slide_with_notes.png)

Az alábbi kódrészlet bemutatja, hogyan konvertálható a bemutató TIFF képpé a Jegyzet Dia nézetben a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) metódus használatával.

```js
// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // A jegyzeteket a dia alá helyezi.

    // Konfigurálja a TIFF beállításokat a jegyzetek elrendezésével.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Mentse a bemutatót TIFF-be az előadói jegyzetekkel.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A TIFF kép előadói jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Tekintse meg az Aspose [Ingyenes PowerPoint poszter konverter](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Kontrollálhatom a jegyzet terület pozícióját a létrehozott TIFF-ben?**

Igen. Használja a [notes layout settings](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) beállításait, hogy válasszon a `None`, `BottomTruncated` vagy `BottomFull` lehetőségek közül, amelyek sorrendben elrejtik a jegyzeteket, egyetlen oldalra illesztik őket, vagy lehetővé teszik, hogy további oldalakra folytatódjanak.

**Hogyan csökkenthetöm a jegyzetekkel ellátott TIFF fájl méretét látható minőségromlás nélkül?**

Válasszon egy [hatékony tömörítést](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (pl. `LZW` vagy `RLE`), állítson be egy megfelelő DPI értéket, és ha elfogadható, használjon alacsonyabb [pixel formátumot](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (például 8 bpp vagy 1 bpp monokrómhoz). Az [képméretek](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/setimagesize/) enyhe csökkentése is segíthet anélkül, hogy észrevehetően rontaná az olvashatóságot.

**A jegyzetekben használt betűtípus befolyásolja az eredményt, ha az eredeti betűtípusok hiányoznak a rendszerből?**

Igen. A hiányzó betűtípusok [helyettesítést](/slides/hu/nodejs-java/font-selection-sequence/) eredményeznek, ami megváltoztathatja a szövegmetrikákat és a megjelenést. Ennek elkerülése érdekében [szerezze be a szükséges betűtípusokat](/slides/hu/nodejs-java/custom-font/) vagy állítson be alapértelmezett [fallback font](/slides/hu/nodejs-java/fallback-font/) betűtípust, hogy a kívánt betűkészletek használatban legyenek.