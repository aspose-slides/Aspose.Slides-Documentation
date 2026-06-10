---
title: PowerPoint előadások konvertálása TIFF-re jegyzettel PHP-ban
linktitle: PowerPoint TIFF-re jegyzettel
type: docs
weight: 100
url: /hu/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "Konvertálja a PowerPoint előadásokat TIFF-re jegyzettel az Aspose.Slides for PHP via Java használatával. Tanulja meg, hogyan exportálhatja a diák előadó jegyzeteit hatékonyan."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java egyszerű megoldást kínál a PowerPoint és OpenDocument prezentációk (PPT, PPTX és ODP) jegyzetekkel együtt TIFF formátumba történő konvertálására. Ez a formátum széles körben használatos a magas minőségű képek tárolására, nyomtatásra és dokumentumok archiválására. Az Aspose.Slides segítségével nem csak a teljes prezentációt exportálhatja előadó jegyzetekkel, hanem a Diák előnézeti képét is létrehozhatja a Jegyzet Diák nézetben. A konvertálási folyamat egyszerű és hatékony, a `save` metódust használva a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból, amely a teljes bemutatót TIFF képek sorozatává alakítja, miközben megőrzi a jegyzeteket és az elrendezést.

## **Prezentáció konvertálása TIFF-re jegyzetekkel**

PowerPoint vagy OpenDocument prezentáció TIFF-re, jegyzetekkel együtt mentése az Aspose.Slides for PHP via Java használatával a következő lépéseket tartalmazza:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztálypéldányt: Töltsön be egy PowerPoint vagy OpenDocument fájlt.
1. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/) osztályt a jegyzetek és megjegyzések megjelenítésének módjának meghatározásához.
1. Mentse a bemutatót TIFF formátumba: Adja át a beállított opciókat a [save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódusnak.

Tegyük fel, hogy van egy "speaker_notes.pptx" fájlunk a következő diával:

![A prezentáció diája előadó jegyzetekkel](slide_with_notes.png)

Az alábbi kódrészlet bemutatja, hogyan konvertálhatjuk a prezentációt TIFF képpé a Jegyzet Diák nézetben a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) metódus használatával.

```php
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Megjeleníti a jegyzeteket a dia alatt.

    // Állítsa be a TIFF beállításokat a jegyzetelrendezéssel.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Mentse a prezentációt TIFF formátumba az előadó jegyzetekkel.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A TIFF kép előadó jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Nézze meg az Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **GYIK**

**Kezelhetem a jegyzetek területének pozícióját az eredményül kapott TIFF-ben?**

Igen. Használja a [jegyzetek elrendezési beállításai](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) opciót, hogy a `None`, `BottomTruncated` vagy `BottomFull` lehetőségek közül válasszon, melyek rendre a jegyzetek elrejtését, egyetlen oldalra való illesztését vagy a további oldalakra való folytatását jelentik.

**Hogyan csökkenthetjük egy jegyzetekkel ellátott TIFF fájl méretét anélkül, hogy a minőség láthatóan romlana?**

Válasszon egy [hatékony tömörítést](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/setcompressiontype/) (például `LZW` vagy `RLE`), állítson be egy ésszerű DPI értéket, és ha elfogadható, használjon alacsonyabb [pixel format](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/setpixelformat/) (például 8 bpp vagy 1 bpp monokróm esetben). Az [image dimensions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/setimagesize/) enyhe csökkentése is segíthet anélkül, hogy jelentősen ronthatná az olvashatóságot.

**A jegyzetekben használt betűtípus befolyásolja az eredményt, ha az eredeti betűtípusok hiányoznak a rendszerből?**

Igen. A hiányzó betűtípusok [helyettesítést](/slides/hu/php-java/font-selection-sequence/) idéznek elő, ami megváltoztathatja a szöveg metrikáit és megjelenését. Ennek elkerülése érdekében [szükséges betűtípusok biztosítása](/slides/hu/php-java/custom-font/) vagy egy alapértelmezett [fallback font](/slides/hu/php-java/fallback-font/) beállítása szükséges, hogy a kívánt betűkészletek legyenek használva.