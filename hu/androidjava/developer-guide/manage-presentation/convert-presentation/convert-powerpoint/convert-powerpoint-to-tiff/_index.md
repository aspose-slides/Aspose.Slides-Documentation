---
title: "PowerPoint prezentációk konvertálása TIFF-be Androidon"
titlelink: "PowerPoint TIFF-re"
type: docs
weight: 90
url: /hu/androidjava/convert-powerpoint-to-tiff/
keywords:
- "PowerPoint konvertálása"
- "OpenDocument konvertálása"
- "prezentáció konvertálása"
- "dia konvertálása"
- "PPT konvertálása"
- "PPTX konvertálása"
- "PowerPoint TIFF-re"
- "prezentáció TIFF-be"
- "dia TIFF-be"
- "PPT TIFF-be"
- "PPTX TIFF-be"
- "PPT mentése TIFF-ként"
- "PPTX mentése TIFF-ként"
- "PPT exportálása TIFF-be"
- "PPTX exportálása TIFF-be"
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhat egyszerűen PowerPoint (PPT, PPTX) prezentációkat magas minőségű TIFF képekké az Aspose.Slides for Android használatával, Java kódpéldákkal."
---
## **Bevezetés**

A TIFF (**Tagged Image File Format**) egy széles körben használt, veszteségmentes raszteres képfájlformátum, amely kivételes minőségéről és a grafika részletes megőrzéséről ismert. Tervezők, fotósok és asztali kiadványszerkesztők gyakran választják a TIFF-et, hogy megőrizzék a rétegeket, a színpontosságot és az eredeti beállításokat a képeikben.

Az Aspose.Slides segítségével könnyedén konvertálhatja PowerPoint‑diáit (PPT, PPTX) és OpenDocument‑diáit (ODP) közvetlenül magas minőségű TIFF‑képekké, biztosítva, hogy a bemutatók a lehető legmagasabb vizuális hűséggel maradjanak meg.

## **Prezentáció konvertálása TIFF‑formátumba**

A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály által biztosított [save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal gyorsan konvertálhatja az egész PowerPoint‑prezentációt TIFF‑formátumba. A kapott TIFF‑képek az alapértelmezett diamérethez igazodnak.

Ez a kód bemutatja, hogyan konvertáljon PowerPoint‑prezentációt TIFF‑formátumba:

```java
import com.aspose.slides.*;

// Hozzon létre egy Presentation osztály példányt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Mentse a prezentációt TIFF formátumban.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Prezentáció konvertálása fekete‑fehér TIFF‑formátumba**

A [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) osztályban található [setBwConversionMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) metódus lehetővé teszi, hogy megadja az algoritmust, amelyet színes dia vagy kép fekete‑fehér TIFF‑re konvertálásakor használ. Vegye figyelembe, hogy ez a beállítás csak akkor lép érvényre, ha a [setCompressionType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) metódus `CCITT4` vagy `CCITT3` értékre van állítva.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) egy export‑szintű beállítás, amely a teljes TIFF‑kép pixeleinek konvertálási algoritmusát választja ki. Egyetlen alakzat fekete‑fehér megjelenésének meghatározásához a [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metódust használja. Lásd a [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) oldalt példákért.
{{% /alert %}}

Tegyük fel, hogy van egy „sample.pptx” fájlunk a következő diával:

![Prezentációs dia](slide_black_and_white.png)

Ez a kód bemutatja, hogyan konvertálja a színes diát fekete‑fehér TIFF‑re:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Fekete‑fehér TIFF](TIFF_black_and_white.png)

## **Prezentáció konvertálása egyedi méretű TIFF‑formátumba**

Ha konkrét méretű TIFF‑képre van szüksége, a [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) osztályban elérhető metódusokkal megadhatja a kívánt értékeket. Például a [setImageSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) metódus segítségével meghatározhatja a létrejövő kép méretét.

Ez a kód bemutatja, hogyan konvertáljon PowerPoint‑prezentációt egyedi méretű TIFF‑képekké:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Hozzon létre egy Presentation osztály példányt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Állítsa be a tömörítési típust.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Tömörítési típusok:
        Default - Az alapértelmezett tömörítési sémát (LZW) jelöli.
        None - Nincs tömörítés.
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
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Mentse a prezentációt TIFF formátumban a megadott mérettel.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Prezentáció konvertálása egyedi képpontformátumú TIFF‑formátumba**

A [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) osztály [setPixelFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) metódusával megadhatja a kívánt pixelformátumot a kimeneti TIFF‑képhez.

Ez a kód bemutatja, hogyan konvertáljon PowerPoint‑prezentációt egyedi pixelformátumú TIFF‑képre:

```java
import com.aspose.slides.*;

// Hozzon létre egy Presentation osztály példányt, amely egy prezentációs fájlt (PPT, PPTX, ODP stb.) képvisel.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat a következő értékeket tartalmazza (a dokumentáció szerint):
        Format1bppIndexed - 1 bit képpontonként, indexelt.
        Format4bppIndexed - 4 bit képpontonként, indexelt.
        Format8bppIndexed - 8 bit képpontonként, indexelt.
        Format24bppRgb    - 24 bit képpontonként, RGB.
        Format32bppArgb   - 32 bit képpontonként, ARGB.
    */
    
    // Mentse a prezentációt TIFF formátumban a megadott pixelformátummal.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Tekintse meg az Aspose ingyenes [PowerPoint to Poster konverterét](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Konvertálhatok egyetlen diát a teljes PowerPoint‑prezentáció helyett TIFF‑formátumba?**

Igen. Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑ és OpenDocument‑prezentációkból különálló diákat konvertáljon TIFF‑képekké.

**Van korlátozás a diák számát illetően a prezentáció TIFF‑formátumba konvertálásakor?**

Nem, az Aspose.Slides nem szab korlátozást a diák számát illetően. Bármilyen méretű prezentációt konvertálhat TIFF‑formátumba.

**A PowerPoint‑animációk és átmeneti hatások megmaradnak a diák TIFF‑formátumba konvertálásakor?**

Nem, a TIFF egy statikus képfájlformátum. Ezért az animációk és átmeneti hatások nem maradnak meg; csak a diák statikus pillanatképei exportálódnak.