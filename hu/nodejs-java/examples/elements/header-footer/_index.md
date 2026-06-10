---
title: Fejléc és lábléc
type: docs
weight: 220
url: /hu/nodejs-java/examples/elements/header-footer/
keywords:
- kód példa
- fejléc
- lábléc
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js segítségével szabályozhatja a dia fejléceket és lábléceket: hozzáadhat dátumokat, diá számokat és egyéni szöveget PPT, PPTX és ODP formátumokban JavaScript példákkal."
---
Ez a cikk bemutatja, hogyan lehet lábléceket hozzáadni és a dátum-idő helyfoglalókat frissíteni a **Aspose.Slides for Node.js via Java** használatával.

## **Lábléc hozzáadása**

Adjon szöveget a dia lábléc területéhez, és tegye láthatóvá.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Dátum és idő frissítése**

Módosítsa a dátum-idő helyfoglalót egy dián.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```