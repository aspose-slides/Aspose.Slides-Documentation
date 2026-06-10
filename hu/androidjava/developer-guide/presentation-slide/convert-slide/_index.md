---
title: Prezentációs diák konvertálása képekké Androidon
linktitle: Dia képhez
type: docs
weight: 35
url: /hu/androidjava/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képpé
- dia mentése képként
- dia PNG-be
- dia JPEG-be
- dia bitmapre
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP diákot képekké az Aspose.Slides for Android segítségével – gyors, magas minőségű renderelés tiszta Java kódrészletekkel."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy könnyedén konvertálja a PowerPoint és OpenDocument prezentációs diákot különféle képformátumokra, többek között BMP, PNG, JPG (JPEG), GIF és egyéb formátumokra.

A dia képformátumba konvertálásához kövesse az alábbi lépéseket:

1. Határozza meg a kívánt konverziós beállításokat, és válassza ki a kívánt diák exportálásához a következőket használva:
    - A [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) interfészt, vagy
    - A [IRenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irenderingoptions/) interfészt.
2. Generálja a dia képet a [getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage--) metódus meghívásával.

Az Aspose.Slides for Android via Java-ban az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) egy interfész, amely lehetővé teszi a pixeladatokkal definiált képek kezelését. Ezzel az interfésszel számos formátumban (BMP, JPG, PNG stb.) menthet képeket.

## **Diák konvertálása Bitmap-ekké és a képek mentése PNG formátumban**

Átkonvertálhat egy diát bitmap objektummá, és közvetlenül használhatja az alkalmazásában. Alternatívaként a diát bitmap-re konvertálhatja, majd a képet JPEG vagy bármely más kívánt formátumban mentheti.

Ez a kód bemutatja, hogyan lehet a bemutató első diáját bitmap objektummá konvertálni, majd a képet PNG formátumban menteni:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertálja a bemutató első diáját bitmapre.
    IImage image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Mentse a képet PNG formátumban.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása egyedi méretű képekké**

Lehet, hogy egy adott méretű képre van szüksége. A [getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) egyik túlterhelésének használatával egy diát konvertálhat egy adott méretű (szélesség és magasság) képpé.

Ez a mintakód bemutatja, hogyan lehet ezt megtenni:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertálja a bemutató első diáját a megadott mérettel bitmapre.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Mentse a képet JPEG formátumban.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása jegyzetekkel és megjegyzésekkel képekké**

Egyes diák jegyzeteket és megjegyzéseket tartalmazhatnak.

Az Aspose.Slides két interfészt biztosít – a [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) és az [IRenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irenderingoptions/) – amelyek lehetővé teszik a bemutató diák képformátumba való renderelésének szabályozását. Mindkét interfész tartalmazza a `setSlidesLayoutOptions` metódust, amely lehetővé teszi a jegyzetek és megjegyzések renderelésének beállítását egy dián, amikor képpé konvertálja.

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) osztállyal megadhatja a kívánt pozíciót a jegyzetek és megjegyzések számára a keletkezett képen.

Ez a kód bemutatja, hogyan konvertáljon egy diát jegyzetekkel és megjegyzésekkel:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Állítsa be a jegyzetek pozícióját.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Állítsa be a megjegyzések pozícióját.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Állítsa be a megjegyzések területének szélességét.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Állítsa be a megjegyzések területének színét.

    // Create the rendering options.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Convert the first slide of the presentation to an image.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Save the image in the GIF format.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Bármely dia‑kép konvertálási folyamat során a [setNotesPosition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) metódus nem alkalmazhatja a `BottomFull` értéket (a jegyzetek pozíciójának megadására), mert a jegyzet szövege túl nagy lehet, így nem fér el a megadott képméretben.

{{% /alert %}} 

## **Diák konvertálása képekké TIFF beállítások használatával**

Az [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) interfész nagyobb szabályozást tesz lehetővé a keletkezett TIFF kép felett, mivel lehetővé teszi olyan paraméterek megadását, mint a méret, felbontás, színpaletta és egyéb beállítások.

Ez a kód bemutat egy olyan konvertálási folyamatot, ahol a TIFF beállításokat használva egy 300 DPI felbontású, 2160 × 2800 méretű fekete‑fehér képet állít elő:

```java 
// Prezentációs fájl betöltése.
Presentation presentation = new Presentation("sample.pptx");
try {
    // A prezentáció első diájának lekérése.
    ISlide slide = presentation.getSlides().get_Item(0);

    // A kimeneti TIFF kép beállításainak konfigurálása.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Állítsa be a kép méretét.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Állítsa be a pixelformátumot (fekete-fehér).
    tiffOptions.setDpiX(300);                                        // Állítsa be a horizontális felbontást.
    tiffOptions.setDpiY(300);                                        // Állítsa be a vertikális felbontást.

    // A diát a megadott beállításokkal képpé konvertálja.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Mentse a képet TIFF formátumban.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Az összes dia konvertálása képekké**

Az Aspose.Slides lehetővé teszi, hogy egy bemutató összes diáját képekké konvertálja, ezzel a teljes bemutatót képsorozattá alakítva.

Ez a mintakód bemutatja, hogyan konvertálhatja a bemutató összes diáját képekké Java‑ban:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Renderelje a prezentációt diánként képekké.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Rejtett diák kezelése (ne renderelje a rejtett diákokat).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Konvertálja a diát képpé.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Mentse a képet JPEG formátumban.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Támogatja-e az Aspose.Slides a diák animációval történő renderelését?**

Nem, a `getImage` metódus csak egy statikus képet ment a diáról, animációk nélkül.

**Exportálhatók-e rejtett diák képek formájában?**

Igen, a rejtett diákat ugyanúgy feldolgozhatja, mint a normál diákat. Csak gondoskodjon arról, hogy a feldolgozási ciklusban szerepeljenek.

**Menthetők-e a képek árnyékokkal és effektusokkal?**

Igen, az Aspose.Slides támogatja az árnyékok, átlátszóság és egyéb grafikai effektusok renderelését a diák képként történő mentésekor.