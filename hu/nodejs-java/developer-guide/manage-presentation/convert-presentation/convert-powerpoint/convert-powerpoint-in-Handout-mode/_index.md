---
title: PowerPoint prezentációk konvertálása kézibevezetés módban JavaScript használatával
linktitle: Kézibevezetés mód
type: docs
weight: 150
url: /hu/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- kézibevezetés mód
- kézibevezetés
- PPT
- PPTX
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a prezentációkat kézibevezetéssé. Állítsa be a dia számát oldalanként, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides for Node.js segítségével, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Aspose.Slides lehetővé teszi a prezentációk különböző formátumokba történő konvertálását, többek között a kézibevevők létrehozását nyomtatáshoz Kézibevezetés módban. Ez a mód lehetővé teszi, hogy beállítsa, hány dia jelenik meg egy oldalon, ami konferenciák, szemináriumok és egyéb események esetén hasznos. Ezt a módot a `setSlidesLayoutOptions` metódus beállításával aktiválhatja a [PdfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) és [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) osztályokban.

## **Kézibevezetés módú exportálás**

A Kézibevezetés mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia helyezhető egy oldalra, valamint egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertálhat egy prezentációt PDF-re Kézibevezetés módban.

```js
// Töltsön be egy prezentációt.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
slidesLayoutOptions.setPrintSlideNumbers(true);                                // diák számának nyomtatása
slidesLayoutOptions.setPrintFrameSlide(true);                                  // keret nyomtatása a diák körül
slidesLayoutOptions.setPrintComments(false);                                   // nincs megjegyzés

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, és képek renderelésekor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális dia bélyegkép száma oldalanként a Kézibevezetés módban?**

Az Aspose.Slides támogatja a [presets](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handouttype/) legfeljebb 9 bélyegképet oldalanként vízszintes vagy függőleges sorrendben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyedi rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A bélyegképek száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handouttype/) felsorolás által van szabályozva; tetszőleges elrendezések nem támogatottak.

**Tartalmazhatok rejtett diákat a Kézibevezetés kimenetben?**

Igen. Használja a `setShowHiddenSlides` metódust a célformátum exportbeállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/) esetén.