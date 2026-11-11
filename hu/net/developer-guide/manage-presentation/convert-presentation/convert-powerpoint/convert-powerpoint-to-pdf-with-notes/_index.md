---
title: PowerPoint előadások konvertálása PDF-be jegyzetekkel .NET-ben
linktitle: PowerPoint PDF-be jegyzetekkel
type: docs
weight: 50
url: /hu/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PDF-be
- prezentáció PDF-be
- dia PDF-be
- PPT PDF-be
- PPTX PDF-be
- prezentáció mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF jegyzetekkel
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-be jegyzetekkel az Aspose.Slides for .NET segítségével. Tartsa meg az elrendezéseket és az előadói jegyzeteket a professzionális bemutatókhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint előadásokat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít, hogy hatékonyan elvégezhesse ezt a feladatot. A cikk végére képes lesz:

- Megvalósítani a konverziós folyamatot, amely a PowerPoint diákat PDF dokumentummá alakítja, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF-et, hogy biztosítsa az előadói jegyzetek belefoglalását és a kívánt formázását.

A jegyzetoldal méretének és tájolásának beállításához exportálás előtt, lásd a [Notes Page Size](/slides/hu/net/notes-size/).

## **PowerPoint konvertálása PDF-be jegyzetekkel**

A `Save` metódus a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályban használható egy PPT vagy PPTX előadás PDF-be konvertálására előadói jegyzetekkel. Az Aspose.Slides segítségével egyszerűen betölti az előadást, a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) osztály segítségével konfigurálja az elrendezési beállításokat az előadói jegyzetek felvételéhez, majd PDF-ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy példány előadást PDF-be a Jegyzetdia nézetben.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // PDF beállítások konfigurálása az előadói jegyzetek rendereléséhez.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Az előadói jegyzetek megjelenítése a dia alatt.
        }
    };

    // A prezentáció mentése PDF-be előadói jegyzetekkel.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion). 
{{% /alert %}}