---
title: PowerPoint prezentációk konvertálása Szórólap módban JavaScript használatával
linktitle: Szórólap mód
type: docs
weight: 150
url: /hu/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertálás
- prezentáció konvertálása
- szórólap mód
- szórólap
- PPT
- PPTX
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Prezentációk konvertálása szórólapokká. Diák száma oldalanként beállítása, jegyzetek megtartása, export PDF vagy képek formátumba az Aspose.Slides for Node.js használatával, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a prezentációk különböző formátumokra történő konvertálását, beleértve a szórólapok létrehozását nyomtatáshoz Szórólap módon. Ez a mód lehetővé teszi, hogy konfigurálja, hogyan jelenjenek meg több dia egyetlen oldalon, ami konferenciákon, szemináriumokon és egyéb eseményeken hasznos. A mód engedélyezhető a `setSlidesLayoutOptions` metódus beállításával a [PdfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) és a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályokban.

## **Szórólap mód exportálása**

A Szórólap mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egy oldalra és egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan lehet egy prezentációt PDF-re konvertálni Szórólap módban.

```js
// Prezentáció betöltése.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Exportálási beállítások megadása.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
slidesLayoutOptions.setPrintSlideNumbers(true);                                // dia számlálók nyomtatása
slidesLayoutOptions.setPrintFrameSlide(true);                                  // keret nyomtatása a diák köré
slidesLayoutOptions.setPrintComments(false);                                   // nincs megjegyzés

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Prezentáció exportálása PDF-be a kiválasztott elrendezéssel.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumok esetén érhető el, például PDF, HTML, TIFF, illetve képként történő rendereléskor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális dia bélyegkép száma oldalanként a Szórólap módban?**

Az Aspose.Slides [presets](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handouttype/) legfeljebb 9 bélyegképet támogat oldalanként, vízszintes vagy függőleges elrendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A bélyegképek számát és sorrendjét szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handouttype/) felsorolás határozza meg; tetszőleges elrendezések nem támogatottak.

**Tudok rejtett diákot is belefoglalni a Szórólap kimenetbe?**

Igen. Használja a `setShowHiddenSlides` metódust a célformátum exportbeállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) esetén.