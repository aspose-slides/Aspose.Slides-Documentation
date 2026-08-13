---
title: PowerPoint előadások konvertálása PDF-re jegyzetekkel .NET-ben
linktitle: PowerPoint PDF-re jegyzetekkel
type: docs
weight: 50
url: /hu/net/convert-powerpoint-to-pdf-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-re jegyzetekkel az Aspose.Slides for .NET segítségével. Tartsa meg az elrendezéseket és az előadói jegyzeteket professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít, hogy hatékonyan megvalósíthassa ezt a feladatot. A cikk végére képes lesz:

- Megvalósítani a konvertálási folyamatot, amely a PowerPoint diákat PDF dokumentumokká alakítja, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF-et, hogy az előadói jegyzetek szerepeljenek benne, és az Ön igényei szerint legyenek formázva.

## **PowerPoint konvertálása PDF-re jegyzetekkel**

A `Save` metódus a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályban használható egy PPT vagy PPTX prezentáció PDF-re konvertálásához előadói jegyzetekkel. Az Aspose.Slides segítségével egyszerűen betölti a prezentációt, beállítja a elrendezési opciókat a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) osztály használatával, hogy tartalmazza az előadói jegyzeteket, majd PDF-ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF-re a Jegyzet Diák nézetben.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Állítsa be a PDF beállításokat az előadói jegyzetek rendereléséhez.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Renderelje az előadói jegyzeteket a dia alá.
        }
    };

    // Mentse a prezentációt PDF-be előadói jegyzetekkel.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást. 
{{% /alert %}}