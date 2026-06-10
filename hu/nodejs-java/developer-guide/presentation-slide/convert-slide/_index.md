---
title: Prezentációs diák konvertálása képekké JavaScriptben
linktitle: Dia kép formátumba
type: docs
weight: 35
url: /hu/nodejs-java/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képpé
- dia mentése képként
- dia PNG formátumba
- dia JPEG formátumba
- dia bitmap formátumba
- dia TIFF formátumba
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PPT, PPTX és ODP diák konvertálása képekké JavaScriptben az Aspose.Slides for Node.js via Java használatával – gyors, magas minőségű renderelés világos kódpéldákkal."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy könnyedén konvertálja a PowerPoint és OpenDocument prezentációs diákat különféle képformátumokba, többek között BMP, PNG, JPG (JPEG), GIF és egyebek.

A dia képbe konvertálásához kövesse az alábbi lépéseket:

1. Határozza meg a kívánt konverziós beállításokat, és válassza ki a exportálni kívánt diákat a következők használatával:
    - a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályt, vagy
    - a [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/) osztályt.
2. A diakép előállításához hívja meg a [getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) metódust.

Az Aspose.Slides for Node.js via Java-ban az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) egy olyan osztály, amely lehetővé teszi a pixeladatok által definiált képek kezelését. Ezzel az osztállyal számos formátumban menthet képeket (BMP, JPG, PNG stb.).

## **Diák konvertálása bitmap-ra és képek mentése PNG formátumban**

Konvertálhat egy diát bitmap objektummá, és közvetlenül felhasználhatja az alkalmazásában. Alternatív megoldásként a diát bitmap-re konvertálhatja, majd a képet JPEG vagy bármely más kedvelt formátumban mentheti.

Ez a JavaScript kód bemutatja, hogyan konvertálja egy prezentáció első diáját bitmap objektummá, majd mentse a képet PNG formátumban:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // A prezentáció első diáját bitmap-re konvertálja.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // A képet PNG formátumban menti.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása képekké egyéni méretekkel**

Előfordulhat, hogy egy adott méretű képre van szüksége. A [getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) egyik overload-jával a diát konkrét méretű (szélesség és magasság) képpé konvertálhatja.

Ez a mintakód bemutatja, hogyan hajtható végre:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // A prezentáció első diáját a megadott mérettel bitmap-re konvertálja.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // A képet JPEG formátumban menti.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása képekké megjegyzésekkel és kommentárokkal**

Egyes diák megjegyzéseket és kommentárokat is tartalmazhatnak.

Az Aspose.Slides két osztályt biztosít – a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) és a [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/) – amelyekkel szabályozhatja a prezentációs diák képekbe történő renderelését. Mindkét osztály tartalmazza a `setSlidesLayoutOptions` metódust, amely lehetővé teszi a megjegyzések és kommentárok renderelésének konfigurálását a dián, amikor képpé konvertálja.

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) osztállyal megadhatja a kívánt pozíciót a megjegyzések és kommentárok számára a létrehozott képen.

Ez a JavaScript kód bemutatja, hogyan konvertáljon egy diát megjegyzésekkel és kommentárokkal:

```js
const scaleX = 2;
const scaleY = scaleX;

// Töltsön be egy prezentációfájlt.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Állítsa be a jegyzetek pozícióját.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Állítsa be a kommentárok pozícióját.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Állítsa be a kommentár terület szélességét.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Állítsa be a kommentár terület színét.

    // Hozza létre a renderelési beállításokat.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Konvertálja a prezentáció első diáját képpé.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // A képet GIF formátumban menti.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Megjegyzés" color="warning" %}} 

Bármely diából képre való konvertálási folyamat során a `setNotesPosition` metódus nem alkalmazható a `BottomFull` értékkel (a megjegyzés pozíciójának meghatározásához), mivel egy megjegyzés szövege túl nagy lehet, és nem fér bele a megadott képméretbe.

{{% /alert %}} 

## **Diák konvertálása képekké TIFF opciók használatával**

A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztály nagyobb kontrollt biztosít a létrehozott TIFF kép felett, lehetővé téve a méret, felbontás, színpaletta és egyéb paraméterek megadását.

Ez a JavaScript kód egy olyan konvertálási folyamatot mutat be, ahol a TIFF opciók segítségével fekete-fehér képet állítunk elő 300 DPI felbontással és 2160 × 2800 mérettel:

```js
// Töltsön be egy prezentációfájlt.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Szerezze meg a prezentáció első diáját.
    let slide = presentation.getSlides().get_Item(0);

    // Állítsa be a kimeneti TIFF kép beállításait.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Állítsa be a kép méretét.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Állítsa be a pixelformátumot (fekete-fehér).
    tiffOptions.setDpiX(300);                                                          // Állítsa be a vízszintes felbontást.
    tiffOptions.setDpiY(300);                                                          // Állítsa be a függőleges felbontást.

    // Konvertálja a diát a megadott beállításokkal képpé.
    let image = slide.getImage(tiffOptions);
    try {
        // Mentse a képet TIFF formátumban.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Megjegyzés" color="warning" %}} 

A TIFF támogatás nem garantált a JDK 9-nél korábbi verziókban.

{{% /alert %}} 

## **Az összes dia konvertálása képekké**

Az Aspose.Slides lehetővé teszi, hogy egy prezentáció összes diáját képekké konvertálja, így a teljes prezentáció sorozatos képpé alakul.

Ez a mintakód bemutatja, hogyan konvertálja egy prezentáció összes diáját képekké JavaScriptben:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Renderelje a prezentációt képekké dia per dia.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Rejtett diák kezelése (ne renderelje a rejtett diákot).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Konvertálja a diát képpé.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Mentse a képet JPEG formátumban.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gyakran Ismételt Kérdések**

**Támogatja-e az Aspose.Slides a diák animációval történő renderelését?**

Nem, a `getImage` metódus csak a dia statikus képét menti el, animációk nélkül.

**Exportálhatók-e a rejtett diák képekként?**

Igen, a rejtett diák is feldolgozhatók, mint a normál diák. Csak győződjön meg róla, hogy azok  

**Menthetők-e a képek árnyékokkal és effektusokkal?**

Igen, az Aspose.Slides támogatja az árnyékok, átlátszóság és egyéb grafikai effektusok renderelését a diák képként történő mentésekor.