---
title: PowerPoint diák konvertálása PNG-re JavaScriptben
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint prezentációkat gyorsan konvertáljon magas minőségű PNG képekké JavaScriptben az Aspose.Slides for Node.js segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhatók a prezentációs diák PNG képekké az Aspose.Slides for Node.js via Java segítségével. Betölthet prezentációkat olyan formátumokban, mint a PPT, PPTX és ODP, renderelheti az egyes diákat, és különálló PNG képként mentheti őket.

Az alábbi példák bemutatják a renderelést az alapértelmezett méretezésben, a méretezés növelését, a kimeneti méretek pixelben történő megadását és egy gradient renderelési stílus kiválasztását.

## **PowerPoint konvertálása PNG-re**

Töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal, és érje el diákját a [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) gyűjteményen keresztül. A példában minden diát a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) paraméterek nélkül renderelnek egy bélyegkép létrehozásához. Ezután a [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) metódust hívják a [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) segítségével, hogy minden renderelt diát PNG képként mentse.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Az paraméter nélküli [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) túlterhelés 0.2-s méretarányban renderel. Például egy 720 × 540 pont méretű dia 144 × 108 pixeles bélyegképet eredményez. A kimeneti méretek vezérléséhez használja a méretarányokkal vagy az alább bemutatott explicit képmérettel rendelkező túlterheléseket.
{{% /alert %}}

## **PowerPoint konvertálása PNG-re egyéni méretekkel**

Adjon meg vízszintes és függőleges méretarányokat a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) metódusnak a renderelt méretek vezérléséhez. Ebben a példában mindkét tényező 2, így egy 720 × 540 pont méretű dia 1440 × 1080 pixeles képet eredményez. Az azonos méretarányok megőrzik a dia arányát. Minden kép PNG formátumban kerül mentésre az [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) metódussal.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint konvertálása PNG-re egyéni mérettel**

Kimeneti méretek pixelben történő megadásához adjon meg méretet a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) metódusnak a méretarányok helyett. Ez a példa minden diát 960 × 720 pixelben renderel, és az eredményt az [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) metódussal menti. Válasszon olyan méreteket, amelyek megfelelnek a dia arányának, hogy elkerülje a kép nyújtását.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gradient renderelési stílus kiválasztása**

Tegyük fel, hogy egy dia gradient kitöltéseket tartalmaz, de az exportált PNG-ben a átmenetek világosabbak vagy másképp néznek ki, mint a PowerPointban. A [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) metódust, amelyet a [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) örököl, használhatja a gradientok renderelésének módjának kiválasztásához.

Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első diája két lineáris gradientet tartalmaz: ciántól narancssárgáig felül, és kéktől sárgáig alul. Minden gradientnek két színállomása van, 0% és 100%.

A következő példa betölti ezt a prezentációt, és a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) metódussal mindkét módban rendereli az első diát.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Alapértelmezett | PowerPointUI |
| --- | --- |
| ![Cianról narancssárgára és kékről sárgára gradientek renderelve Alapértelmezett módon](gradient-Default.png) | ![Ugyanazok a gradientek renderelve PowerPointUI-val](gradient-PowerPointUI.png) |

Ebben a példában a `Default` világosabb köztes színeket eredményez, míg a `PowerPointUI` sötétebb köztes színeket. A különbség a gradient színeitől és színállomásaitól függ.

Válassza a `Default`-ot, ha az alapértelmezett Aspose.Slides kimenet megfelel az igényeinek. Próbálja ki a `PowerPointUI`-t, ha az a prioritása, hogy a megjelenés megegyezzen a PowerPointban láthatóval. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem általánosan előnyösebb.

## **GYIK**

**Hogyan exportálhatok egy adott alakzatot, például diagramot vagy képet, a teljes dia helyett?**

Az Aspose.Slides támogatja az [egyedi alakzatok bélyegképeinek létrehozását](/slides/hu/nodejs-java/create-shape-thumbnails/), amely lehetővé teszi egy alakzat PNG képpé renderelését.

**Támogatott a párhuzamos konvertálás egy szerveren?**

Igen. Használjon külön prezentációs példányt minden szálhoz vagy folyamathoz; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/nodejs-java/multithreading/).

**Mik a kiértékelési korlátozások PNG exportálásakor?**

A kiértékelési mód vízjelhez adja a kimeneti képeket, és [további korlátozásokat](/slides/hu/nodejs-java/licensing/) alkalmaz, amíg licencet nem alkalmaznak.