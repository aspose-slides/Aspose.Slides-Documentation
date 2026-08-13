---
title: PowerPoint előadások konvertálása TIFF-be jegyzetekkel Androidon
linktitle: PowerPoint TIFF-be jegyzetekkel
type: docs
weight: 100
url: /hu/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
  - PowerPoint konvertálása
  - előadás konvertálása
  - dia konvertálása
  - PPT konvertálása
  - PPTX konvertálása
  - PowerPoint TIFF-be
  - előadás TIFF-be
  - dia TIFF-be
  - PPT TIFF-be
  - PPTX TIFF-be
  - PPT mentése TIFF-ként
  - PPTX mentése TIFF-ként
  - PPT exportálása TIFF-be
  - PPTX exportálása TIFF-be
  - PowerPoint jegyzetekkel
  - előadás jegyzetekkel
  - dia jegyzetekkel
  - PPT jegyzetekkel
  - PPTX jegyzetekkel
  - TIFF jegyzetekkel
  - Android
  - Java
  - Aspose.Slides
description: "PowerPoint előadások konvertálása TIFF-be jegyzetekkel az Aspose.Slides for Android via Java segítségével. Ismerje meg, hogyan exportálhatja hatékonyan a diákat előadói jegyzetekkel."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java egyszerű megoldást nyújt a PowerPoint és OpenDocument előadások (PPT, PPTX és ODP) jegyzetekkel együtt TIFF formátumba történő konvertálására. Ez a formátum széles körben használatos magas minőségű képek tárolására, nyomtatásra és dokumentumok archiválására. Az Aspose.Slides segítségével nemcsak teljes előadást exportálhat előadói jegyzetekkel, hanem diakép bélyegképeket is generálhat a Jegyzetek Dia nézetben. A konverziós folyamat egyszerű és hatékony, a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály `save` metódusát használva alakítja át a teljes előadást TIFF képek sorozatává, miközben megőrzi a jegyzeteket és az elrendezést.

## **Előadás konvertálása TIFF-be jegyzetekkel**

A PowerPoint vagy OpenDocument előadás TIFF-be, jegyzetekkel mentése az Aspose.Slides for Android via Java használatával a következő lépéseket tartalmazza:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályt: Töltsön be egy PowerPoint vagy OpenDocument fájlt.  
1. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) osztályt a jegyzetek és megjegyzések megjelenítési módjának meghatározásához.  
1. Mentse az előadást TIFF-be: Adja át a beállított opciókat a [save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódusnak.  

Tegyük fel, hogy van egy "speaker_notes.pptx" fájlunk a következő diával:

![Az előadásdia előadói jegyzetekkel](slide_with_notes.png)

Az alábbi kódrészlet bemutatja, hogyan konvertálhatjuk az előadást TIFF képpé a Jegyzetek Dia nézetben a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódus használatával.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // A jegyzeteket a dia alá jeleníti meg.

    // Állítsa be a TIFF beállításokat a jegyzetek elrendezésével.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Mentse a bemutatót TIFF-be a előadói jegyzetekkel.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A TIFF kép előadói jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Tekintse meg az Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online) szolgáltatást.
{{% /alert %}}

## **GYIK**

### Vezérelhetem a jegyzetek területének pozícióját a létrehozott TIFF-ben?

Igen. Használja a [notes layout settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) beállításokat, hogy a `None`, `BottomTruncated` vagy `BottomFull` lehetőségek közül válasszon, amelyek ennek megfelelően elrejtik a jegyzeteket, egyetlen oldalra illesztik őket, vagy további oldalakra folyathatják őket.

### Hogyan csökkenthetem a jegyzetekkel rendelkező TIFF fájl méretét anélkül, hogy látható minőségromlás lépne fel?

Válasszon egy [efficient compression](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (például `LZW` vagy `RLE`) beállítást, állítson be egy megfelelő DPI-t, és ha elfogadható, használjon alacsonyabb [pixel format](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (például 8 bpp vagy 1 bpp monokrómhoz). Az [image dimensions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) enyhe csökkentése is segíthet anélkül, hogy észrevehetően rontaná az olvashatóságot.

### Befolyásolja a jegyzetek betűtípusa az eredményt, ha a rendszeren hiányzik az eredeti betűtípus?

Igen. A hiányzó betűtípusok [substitution](/slides/hu/androidjava/font-selection-sequence/) műveletet indítanak, ami megváltoztathatja a szövegmetrikákat és a megjelenést. Ennek elkerülése érdekében [supply the required fonts](/slides/hu/androidjava/custom-font/) vagy állítson be alapértelmezett [fallback font](/slides/hu/androidjava/fallback-font/) betűtípust, hogy a kívánt betűcsaládok legyenek használva.