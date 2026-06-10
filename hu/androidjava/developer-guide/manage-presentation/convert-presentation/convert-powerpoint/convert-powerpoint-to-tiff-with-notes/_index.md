---
title: PowerPoint előadások konvertálása TIFF formátumba jegyzetekkel Androidon
linktitle: PowerPoint TIFF-re jegyzetekkel
type: docs
weight: 100
url: /hu/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint előadásokat TIFF formátumba jegyzetekkel az Aspose.Slides for Android via Java segítségével. Ismerje meg, hogyan exportálhat diákat előadás jegyzetekkel hatékonyan."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java egyszerű megoldást kínál a PowerPoint és OpenDocument bemutatók (PPT, PPTX és ODP) jegyzetekkel történő TIFF formátumba konvertálásához. Ez a formátum széles körben használatos magas minőségű képtároláshoz, nyomtatáshoz és dokumentumarchiváláshoz. Az Aspose.Slides segítségével nem csak a teljes bemutatókat exportálhatja előadás jegyzetekkel, hanem a Diák miniatűr képeit is előállíthatja a Jegyzet Diák nézetben. A konverziós folyamat egyszerű és hatékony, a `save` metódus használatával a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból átalakítja a teljes bemutatót egy sor TIFF képpé, miközben megőrzi a jegyzeteket és az elrendezést.

## **Bemutató konvertálása TIFF formátumba jegyzetekkel**

PowerPoint vagy OpenDocument bemutató TIFF formátumba történő mentése jegyzetekkel az Aspose.Slides for Android via Java használatával a következő lépéseket tartalmazza:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt: Töltse be a PowerPoint vagy OpenDocument fájlt.
2. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) osztályt annak meghatározásához, hogyan jelenjenek meg a jegyzetek és a megjegyzések.
3. Mentse a bemutatót TIFF formátumba: Adja át a beállított opciókat a [save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódusnak.

Tegyük fel, hogy van egy "speaker_notes.pptx" fájlunk a következő diával:

![A bemutató dia előadás jegyzetekkel](slide_with_notes.png)

Az alábbi kódrészlet bemutatja, hogyan lehet a bemutatót TIFF képpé konvertálni a Jegyzet Diák nézetben a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódus segítségével.

```java
// Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // A jegyzeteket a dia alá jeleníti meg.

    // Konfigurálja a TIFF beállításokat jegyzetelrendezéssel.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Mentse a bemutatót TIFF formátumba a előadás jegyzetekkel.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A TIFF kép előadás jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Nézze meg az Aspose [Ingyenes PowerPoint poszter konverter](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Meg tudom határozni a jegyzet terület pozícióját a létrehozott TIFF-ben?**

Igen. Használja a [notes layout settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) lehetőséget a `None`, `BottomTruncated` vagy `BottomFull` beállítások közül választáshoz, amelyek rendre a jegyzeteket elrejtik, egyetlen oldalra illesztik, vagy további oldalakra folytatják.

**Hogyan csökkenthetem a jegyzetekkel ellátott TIFF fájl méretét anélkül, hogy látható minőségromlás lépne fel?**

Válasszon egy [efficient compression](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (például `LZW` vagy `RLE`) opciót, állítson be ésszerű DPI értéket, és ha elfogadható, használjon alacsonyabb [pixel format](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (például 8 bpp vagy 1 bpp monokróm esetén). A [image dimensions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) enyhe csökkentése is segíthet anélkül, hogy jelentősen befolyásolná az olvashatóságot.

**Hat a jegyzetekben használt betűtípus az eredményre, ha az eredeti betűtípusok hiányoznak a rendszerből?**

Igen. A hiányzó betűtípusok [substitution](/slides/hu/androidjava/font-selection-sequence/) műveletet váltanak ki, ami megváltoztathatja a szöveg metrikáit és megjelenését. Ennek elkerülése érdekében [supply the required fonts](/slides/hu/androidjava/custom-font/) vagy állítson be alapértelmezett [fallback font](/slides/hu/androidjava/fallback-font/) betűtípust, hogy a kívánt betűkészletek legyenek használva.