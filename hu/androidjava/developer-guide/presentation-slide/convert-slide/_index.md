---
title: Diák konvertálása képekké Androidon
linktitle: Dia képbe
type: docs
weight: 35
url: /hu/androidjava/convert-slide/
keywords:
- diák konvertálása
- dia exportálása
- dia képbe
- dia mentése képként
- dia PNG-be
- dia JPEG-be
- dia bitmapbe
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Diák konvertálása PPT, PPTX és ODP formátumból képekké az Aspose.Slides for Android segítségével – gyors, magas minőségű megjelenítés, tiszta Java kódrészletekkel."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egyszerűen alakítsa át a PowerPoint és OpenDocument prezentációs diákot különféle képformátumokra, például BMP, PNG, JPG (JPEG), GIF és egyebek.

A dia képévé konvertálásához kövesse az alábbi lépéseket:

1. Határozza meg a kívánt konverziós beállításokat, és válassza ki az exportálni kívánt diát a következő használatával:
    - Az [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) interfész, vagy
    - Az [IRenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irenderingoptions/) interfész.
2. A diakép előállításához hívja meg a [getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage--) metódust.

Az Aspose.Slides for Android via Java esetén az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) egy interfész, amely lehetővé teszi képek pixeladatok alapján történő kezelését. Ezzel az interfésszel számos formátumban (BMP, JPG, PNG stb.) menthet képeket.

## **Diák konvertálása bitmapképekké és a képek mentése PNG formátumban**

Átalakíthat egy diát bitmap objektummá, és közvetlenül felhasználhatja az alkalmazásában. Alternatívaként a diát bitmapté konvertálhatja, majd a képet JPEG vagy bármely más kívánt formátumban mentheti.

Ez a kód bemutatja, hogyan konvertálhatja egy prezentáció első diáját bitmap objektummá, majd mentheti a képet PNG formátumban:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // A prezentáció első diáját bitmapképpé konvertálja.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // A képet PNG formátumban menti.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása egyéni méretű képekké**

Lehet, hogy adott méretű képre van szüksége. A [getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) egyik túlterhelésével a diát a kívánt méretek (szélesség és magasság) szerinti képpé konvertálhatja.

Ez a mintakód bemutatja, hogyan kell ezt megtenni:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // A prezentáció első diáját a megadott mérettel bitmapképpé konvertálja.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // A képet JPEG formátumban menti.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása jegyzetekkel és megjegyzésekkel ellátott képekké**

Egyes diák tartalmazhatnak jegyzeteket és megjegyzéseket.

Az Aspose.Slides két interfészt biztosít – a [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) és a [IRenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irenderingoptions/) – amelyek segítségével szabályozhatja a prezentációs diák képekké alakítását. Mindkét interfész tartalmazza a `setSlidesLayoutOptions` metódust, amely lehetővé teszi a jegyzetek és megjegyzések megjelenítésének beállítását a dián, amikor azt képbe konvertálja.

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) osztállyal megadhatja a jegyzetek és megjegyzések kívánt elhelyezését a keletkező képen.

Ez a kód bemutatja, hogyan konvertálhat egy diát jegyzetekkel és megjegyzésekkel:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Betölti a prezentációs fájlt.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // A jegyzetek pozíciójának beállítása.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // A megjegyzések pozíciójának beállítása.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // A megjegyzések területének szélességének beállítása.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // A megjegyzések területének színének beállítása.

    // Létrehozza a renderelési beállításokat.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // A prezentáció első diáját képpé konvertálja.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // A képet GIF formátumban menti.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Bármely dia‑kép konverziós folyamat során a [setNotesPosition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) metódus nem alkalmazható a `BottomFull` értékre (a jegyzetek pozíciójának meghatározásához), mivel a jegyzet szövege túl nagy lehet, és nem fér el a megadott képméretben.
{{% /alert %}} 

## **Diák konvertálása képekké TIFF beállítások használatával**

Az [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) interfész nagyobb szabályozást tesz lehetővé a létrehozott TIFF kép felett, hiszen paraméterek, például méret, felbontás, színpaletta stb. megadhatók.

Ez a kód egy olyan konverziós folyamatot mutat be, ahol a TIFF beállítások segítségével 300 DPI felbontású, 2160 × 2800 méretű fekete‑fehér kép jön létre:

```java 
// Betölti a prezentációs fájlt.
Presentation presentation = new Presentation("sample.pptx");
try {
    // A prezentáció első diáját lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Beállítja a kimeneti TIFF kép beállításait.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Beállítja a kép méretét.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Beállítja a képpontformátumot (fekete-fehér).
    tiffOptions.setDpiX(300);                                        // Beállítja a vízszintes felbontást.
    tiffOptions.setDpiY(300);                                        // Beállítja a függőleges felbontást.

    // A diákat a megadott beállításokkal képpé konvertálja.
    IImage image = slide.getImage(tiffOptions);

    try {
        // A képet TIFF formátumban menti.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Összes dia konvertálása képekké**

Az Aspose.Slides lehetővé teszi, hogy egy prezentáció összes diáját képekké konvertálja, ezzel a teljes prezentációt képsorozattá alakítva.

Ez a mintakód bemutatja, hogyan konvertálhatja Java nyelven egy prezentáció összes diáját képekké:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // A prezentáció diákonkénti képként való renderelése.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Elrejti a rejtett diák kezelését (nem rendereli a rejtett diát).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // A diát képpé konvertálja.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // A képet JPEG formátumban menti.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Színes Emoji megjelenítése**

{{% alert title="Note" color="warning" %}} 
A színes emoji-k helyes megjelenítéséhez a prezentáció diáinak képekké alakítása során a prezentációban használt emoji betűtípusoknak telepítve kell lenniük, és elérhetőnek kell lenniük a konverziót végző rendszeren. Például, ha a prezentáció a **Segoe UI Emoji** betűtípust használja, és ez hiányzik, az emoji-k monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Az Aspose.Slides támogatja-e a diák animációkkal történő megjelenítését?**

Nem, a `getImage` metódus csak a dia statikus képét menti, animációk nélkül.

**Az elrejtett diák exportálhatók-e képként?**

Igen, az elrejtett diák is feldolgozhatók, mint a normálak. Csak ügyelj arra, hogy szerepeljenek a feldolgozási ciklusban.

**A képek menthetők árnyékokkal és effektusokkal?**

Igen, az Aspose.Slides támogatja az árnyékok, átlátszóság és egyéb grafikai effektusok megjelenítését a diák képként történő mentésekor.