---
title: Prezentációs diák képpé konvertálása Node.js-en keresztül .NET-en
linktitle: Dia képpé
type: docs
weight: 40
url: /hu/nodejs-net/convert-slide/
keywords:
- dia konvertálása
- dia képpé
- dia PNG-be
- dia mentése képként
- dia renderelése
- dia bélyegkép
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderelje a PPTX, PPT és ODP prezentációk diáit PNG képekként JavaScriptben az Aspose.Slides for Node.js via .NET segítségével, méretezési tényező vagy pontos pixelméret alapján."
---
## **Áttekintés**

Aspose.Slides for Node.js via .NET diavetítéseket renderel PowerPoint és OpenDocument prezentációkból képként, például diaképek megjelenítéséhez egy weboldalon. Ez a cikk két módot mutat be a kép méretének kiválasztására: a diavetítés méretéhez viszonyított méretezési tényező, illetve a pontos pixelméret. Mindkét példa PNG fájlba ment.

A példák egy `sample.pptx` nevű prezentációt várnak a projekt mappában, amelyet az [Installation](/slides/hu/nodejs-net/installation/) útmutató szerint állított be. Bármely PowerPoint prezentáció megfelelő. Mentsd el minden példát `.js` fájlként a projekt mappába, és futtasd onnan a `node` paranccal.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Node.js via .NET saját API-referenciával nem rendelkezik. A .NET API-t camelCase nevekkel tükrözi, ezért a cikkben található API hivatkozások a [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) megfelelő osztályaira és tagjaira mutatnak.
{{% /alert %}}

Egy dia képévé konvertálásához kövesd az alábbi lépéseket:

1. Nyisd meg a prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) konstruktorral.  
1. Szerezz be egy diát a [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) gyűjteményből a `get(index)` metódussal. Az indexelés 0‑tól kezdődik.  
1. Rendereld a diát `getImageWithScale` vagy `getImageWithImageSize` segítségével. A .NET API referenciában mindkettő a [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) túlterhelt változata. Egy kép objektumot ad vissza, amely a [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) megfelelője.  
1. Mentsd el a képet a saját [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) metódusával és egy [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) értékkel, majd hívd meg a `dispose` metódusát.

## **Minden dia konvertálása PNG képpé**

`getImageWithScale` egy vízszintes és egy függőleges méretezési tényezőt vesz. 1‑es méretezésnél egy pont a dián egy pixelnek felel meg a képen. A következő példa minden diát 2‑es méretezéssel renderel:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Az 1-es méretezés egy pontot egy pixelnek renderel; a 2-es megduplázza a szélességet és a magasságot.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

A szkript minden diához egy fájlt ír, `slide_1.png`, `slide_2.png` stb., a számok 1‑től indulnak. Egy 16:9‑es prezentáció esetén, ahol a diák 960 × 540 pont méretűek, minden kép 1920 × 1080 pixel lesz. A rejtett diák is renderelődnek; elhagyásukhoz ellenőrizd a dia [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) tulajdonságát. Minden képet a saját `finally` blokkjában `dispose`-olnak, így felszabadul, mielőtt a következő dia renderelődne. Licenc nélkül a képek értékelő vízjelet is tartalmaznak; lásd a [Licensing](/slides/hu/nodejs-net/licensing/) oldalt.

## **Dia konvertálása adott méretű képpé**

`getImageWithImageSize` egy objektumot vesz, amely `width` és `height` értékeket tartalmaz pixelekben. A következő példa az első diát 1280 pixel szélességben rendereli, a magasságot a dia méretéből számítja ki, így a kép megtartja a dia képarányát:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

A [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) tulajdonság a dia szélességét és magasságát pontban adja vissza. Egy 16:9‑es prezentáció esetén a szkript kiírja, hogy `Saved a 1280 x 720 image`, és a fájl `slide_1_1280px.png` néven kerül mentésre; egy 4:3‑as prezentáció esetén a kép 1280 × 960 pixel lesz.

## **GYIK**

**Miért olyan kicsi a `getImage` argumentumok nélkül kapott kép?**

Argumentumok nélkül a `getImage` a dia méretének 20 %-át rendereli pontban, így egy 960 × 540 pont méretű dia 192 × 108 pixel képpé válik. Használd a `getImageWithScale` vagy `getImageWithImageSize` metódusokat a méret kiválasztásához.

**Hogyan mentsek JPEG vagy más képformátumot?**

Adj át egy másik `ImageFormat` értéket a kép `save` metódusának, például `image.save("slide_1.jpg", ImageFormat.Jpeg)`. A formátum a `ImageFormat` értéktől függ, nem a fájlkiterjesztéstől, ezért tartsd ezt egységesen.

**Miért néz ki másképp a szöveg a képeken Linuxon?**

Az Aspose.Slides csak azokon a betűtípusokon tud működni, amelyek a renderelő gépen telepítve vannak. Ha egy prezentáció olyan betűtípust használ, amely hiányzik (például a Calibri egy tipikus Linux szerveren), az Aspose.Slides egy helyettesítő betűtípust alkalmaz, ami megváltoztathatja a szöveg megjelenését és a sortöréseket. Telepítsd a prezentációkban használt betűtípusokat, hogy a képek ugyanúgy nézzenek ki, mint Windows alatt.

**Miért hibázik a `getThumbnailWithImageSize` TypeError‑tal?**

A csomag README-ja a `getThumbnailWithImageSize`-t említi, de a csomagnak nincsenek `getThumbnail` metódusai. Használd helyette a `getImageWithImageSize`-t; ez ugyanazt a `{ width, height }` argumentumot veszi.