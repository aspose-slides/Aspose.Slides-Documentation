---
title: Prezentációs diák konvertálása képekké JavaScriptben
linktitle: Dia képpé
type: docs
weight: 35
url: /hu/nodejs-java/convert-slide/
keywords: 
- dia konvertálása
- dia exportálása
- dia képpé
- dia mentése képként
- dia PNG-be
- dia JPEG-be
- dia bitmapbe
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP diákat képekké JavaScriptben az Aspose.Slides for Node.js via Java használatával – gyors, magas minőségű renderelés világos kódrészletekkel."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy könnyedén konvertálja a PowerPoint és OpenDocument bemutatódiákat különféle képformátumokká, például BMP, PNG, JPG (JPEG), GIF és mások.

A dia képbe konvertálásához kövesse az alábbi lépéseket:

1. Határozza meg a kívánt konverziós beállításokat, és válassza ki a exportálni kívánt diákat az alábbiak használatával:
    - A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályt, vagy
    - A [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/) osztályt.
2. Generálja a dia képet a [getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) metódus meghívásával.

Az Aspose.Slides for Node.js via Java-ban az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) egy olyan osztály, amely lehetővé teszi a pixelek alapján definiált képek kezelését. Ezzel az osztállyal különféle formátumokban (BMP, JPG, PNG stb.) menthet képeket.

## **Diák konvertálása bitmapre és a képek mentése PNG formátumban**

Átalakíthat egy diát bitmap objektummá, és közvetlenül felhasználhatja alkalmazásában. Alternatívaként konvertálhatja a diát bitmapre, majd elmentheti JPEG vagy bármely más kívánt formátumban.

Ez a JavaScript kód bemutatja, hogyan konvertálja egy bemutató első diáját bitmap objektummá, majd menti PNG formátumban:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertálja a bemutató első diáját bitmapre.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Mentse a képet PNG formátumban.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása képekre egyedi méretekkel**

Előfordulhat, hogy egy adott méretű képre van szüksége. A [getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) egyik túlterhelésével a diát olyan képpé alakíthatja, amelynek szélessége és magassága meg van határozva.

Ez a minta kód demonstrálja, hogyan valósítható meg:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertálja a bemutató első diáját bitmapre a megadott mérettel.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Mentse a képet JPEG formátumban.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása képekké megjegyzésekkel és kommentárokkal**

Egyes diák tartalmazhatnak megjegyzéseket és kommentárokat.

Az Aspose.Slides két osztályt kínál – a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) és a [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/) – amelyekkel szabályozható a prezentációs diák képekké renderelése. Mindkét osztály tartalmazza a `setSlidesLayoutOptions` metódust, amely lehetővé teszi a megjegyzések és kommentárok renderelésének konfigurálását a diáról kép készítésekor.

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) osztállyal megadhatja a kívánt pozíciót a megjegyzések és kommentárok számára a létrejött képen.

Ez a JavaScript kód bemutatja, hogyan konvertáljon egy diát megjegyzésekkel és kommentárokkal:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
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
 
    // Konvertálja a bemutató első diáját képpé.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Mentse a képet GIF formátumban.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Bármely diát képre konvertáló folyamatban a [setNotesPosition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódus nem alkalmazhatja a `BottomFull` beállítást (a megjegyzés pozíciójának meghatározásához), mivel a megjegyzés szövege túl nagy lehet, és nem fér el a megadott képméreten.

{{% /alert %}} 

## **Diák konvertálása képekké TIFF opciók használatával**

A [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztály nagyobb kontrollt biztosít a kimeneti TIFF kép felett, lehetővé téve a méret, felbontás, színpaletta és egyéb paraméterek megadását.

Ez a JavaScript kód bemutat egy olyan konverziós folyamatot, amely TIFF opciókat használ egy 300 DPI felbontású, fekete‑fehér képre 2160 × 2800 mérettel:

```js
// Töltse be a bemutató fájlt.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Szerezze be a bemutató első diáját.
    let slide = presentation.getSlides().get_Item(0);

    // Állítsa be a kimeneti TIFF kép beállításait.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Állítsa be a kép méretét.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Állítsa be a pixelformátumot (fekete-fehér).
    tiffOptions.setDpiX(300);                                                          // Állítsa be a vízszintes felbontást.
    tiffOptions.setDpiY(300);                                                          // Állítsa be a függőleges felbontást.

    // Konvertálja a diát képpé a megadott beállításokkal.
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

{{% alert title="Note" color="warning" %}} 

A Tiff támogatás nem garantált a JDK 9 előtti verziókban.

{{% /alert %}} 

## **Az összes dia konvertálása képekké**

Az Aspose.Slides lehetővé teszi, hogy egy bemutató összes diáját képekké konvertálja, ezáltal a teljes bemutatót sorozatként képekbe alakítva.

Ez a minta kód bemutatja, hogyan konvertálhatja egy bemutató összes diáját JavaScriptben képekké:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Renderelje a bemutatót diánként képekké.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Kezelje a rejtett diákat (ne renderelje a rejtett diákat).
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

## **Színes Emoji renderelés**

{{% alert title="Note" color="warning" %}} 
A színes emoji-k helyes rendereléséhez a prezentációból kerülő konvertálás során a rendszernek telepítve kell lennie a prezentációban használt emoji betűkészleteknek. Például, ha a bemutató **Segoe UI Emoji** betűkészletet használ, és ez hiányzik, az emoji-k monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Támogatja-e az Aspose.Slides a diák animációval való renderelését?**

Nem, a `getImage` metódus csak a dia statikus képét menti, animációk nélkül.

**Exportálhatóak-e a rejtett diák képként?**

Igen, a rejtett diák is feldolgozható ugyanúgy, mint a normál diák. Ügyeljen arra, hogy a feldolgozási ciklusban szerepeljenek.

**Menthetők-e a képek árnyékokkal és hatásokkal?**

Igen, az Aspose.Slides támogatja az árnyékok, átlátszóság és egyéb grafikai hatások renderelését a diák képként történő mentésekor.