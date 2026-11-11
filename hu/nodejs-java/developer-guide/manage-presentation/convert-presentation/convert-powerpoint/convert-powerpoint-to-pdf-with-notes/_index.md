---
title: PowerPoint-prezentációk konvertálása PDF-re jegyzetekkel JavaScriptben
linktitle: PowerPoint PDF-re konvertálás jegyzetekkel
type: docs
weight: 50
url: /hu/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
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
description: "Konvertálja a PPT és PPTX formátumokat PDF-re jegyzetekkel JavaScriptben az Aspose.Slides for Node.js használatával. Őrizze a elrendezéseket és az előadói jegyzeteket professzionális prezentációkhoz."
---
## **Áttekintés**

Ezen a cikkben megtanulja, hogyan lehet PowerPoint-prezentációkat PDF formátumba konvertálni előadói jegyzetekkel az Aspose.Slides segítségével. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít, hogy hatékonyan elvégezhesse ezt a feladatot. A cikk végére képes lesz:

- A konverziós folyamat megvalósítása a PowerPoint-diák PDF dokumentumokká alakításához, miközben megőrzi az előadói jegyzeteket.
- A kimeneti PDF testreszabása annak biztosítására, hogy az előadói jegyzetek szerepelnek és a követelményeknek megfelelően formázottak legyenek.

A jegyzetoldal méretei és tájolása exportálás előtt beállításához lásd a [Jegyzetoldal Mérete](/slides/hu/nodejs-java/notes-size/).

## **PowerPoint konvertálása PDF-re jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF-re, előadói jegyzetekkel történő konvertálásához. Az Aspose.Slides segítségével egyszerűen betölti a prezentációt, beállítja az elrendezési beállításokat a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) osztály használatával az előadói jegyzetek felvételéhez, majd a fájlt PDF formátumban menti. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF-re a Jegyzet Diák nézetben.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Állítsa be a PDF beállításokat az előadói jegyzetek rendereléséhez.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Az előadói jegyzetek megjelenítése a dia alatt.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Mentse a prezentációt PDF-be előadói jegyzetekkel.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Érdemes lehet megnézni az Aspose [Online PowerPoint PDF konvertáló](https://products.aspose.app/slides/hu/conversion) szolgáltatását.
{{% /alert %}}