---
title: PowerPoint-prezentációk átalakítása PDF-re jegyzetekkel JavaScriptben
linktitle: PowerPoint PDF-re jegyzetekkel
type: docs
weight: 50
url: /hu/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint PDF-re
- prezentáció PDF-re
- dia PDF-re
- PPT PDF-re
- PPTX PDF-re
- prezentáció mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF jegyzetekkel
- Node.js
- JavaScript
- Aspose.Slides
description: "Átalakítja a PPT és PPTX formátumokat PDF-re jegyzetekkel JavaScriptben az Aspose.Slides for Node.js használatával. Megőrzi az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan alakíthatja át a PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít, amelyek segítenek hatékonyan végrehajtani ezt a feladatot. A cikk végére képes lesz:

- Megvalósítani a konverziós folyamatot, hogy a PowerPoint-diák PDF‑dokumentummá alakuljanak a jegyzetek megőrzésével.
- Testreszabni a kimeneti PDF‑et úgy, hogy a jegyzetek bele legyenek foglalva és a kívánt formátumban jelenjenek meg.

## **PowerPoint átalakítása PDF‑be jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑re konvertálására előadói jegyzetekkel. Az Aspose.Slides segítségével egyszerűen betölti a prezentációt, beállítja az elrendezési lehetőségeket a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) osztály használatával, hogy a jegyzetek szerepeljenek, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF‑be Jegyzet Diák nézetben.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// PDF beállítások konfigurálása az előadói jegyzetek megjelenítéséhez.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Az előadói jegyzetek megjelenítése a dia alatt.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// A prezentáció mentése PDF-be előadói jegyzetekkel.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion). 
{{% /alert %}}