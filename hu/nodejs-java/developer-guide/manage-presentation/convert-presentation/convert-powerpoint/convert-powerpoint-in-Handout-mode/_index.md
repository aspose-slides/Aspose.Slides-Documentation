---
title: PowerPoint prezentációk konvertálása kézikönyv módban JavaScript használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- kézikönyv mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a bemutatókat kézikönyvekké. Állítsa be az oldalankénti diákat, tartsa meg a megjegyzéseket, exportáljon PDF-be vagy képekbe az Aspose.Slides for Node.js segítségével, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a bemutatókat különböző formátumokra konvertálja, beleértve a kézikönyvek létrehozását a Handout mód nyomtatásához. Ez a mód lehetővé teszi, hogy beállítsa, hogyan jelennek meg több dia egyetlen lapon, ami konferenciák, szemináriumok és egyéb események esetén hasznos. Ezt a módot engedélyezheti a `setSlidesLayoutOptions` metódus beállításával a [PdfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) és a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályokban.

A kézikönyv oldal méretének és tájolásának beállításához exportálás előtt, lásd a [Megjegyzés oldal mérete](/slides/hu/nodejs-java/notes-size/).

## **Kézikönyv mód exportálása**

A kézikönyv mód beállításához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egyetlen lapra, valamint egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertálhat egy bemutatót PDF-be kézikönyv módban.

```js
const asposeSlides = require("aspose.slides.via.java");

// Prezentáció betöltése.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Exportálási beállítások beállítása.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
slidesLayoutOptions.setPrintSlideNumbers(true);                                // dia számok nyomtatása
slidesLayoutOptions.setPrintFrameSlide(true);                                  // keret nyomtatása a diák körül
slidesLayoutOptions.setPrintComments(false);                                   // nincs megjegyzés

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exportálja a prezentációt PDF-be a kiválasztott elrendezéssel.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
Ne feledje, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumok esetén érhető el, például PDF, HTML, TIFF, és képek renderelésekor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diakép száma oldalanként a kézikönyv módban?**

Az Aspose.Slides a [presets](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handouttype/) legfeljebb 9 diaképet támogat oldalanként, vízszintes vagy függőleges rendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A diaképek száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handouttype/) felsorolás által van meghatározva; tetszőleges elrendezések nem támogatottak.

**Tartalmazhatok rejtett diákat a kézikönyv kimenetben?**

Igen. Használja a `setShowHiddenSlides` metódust az exportálási beállításokban a célformátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) esetén.