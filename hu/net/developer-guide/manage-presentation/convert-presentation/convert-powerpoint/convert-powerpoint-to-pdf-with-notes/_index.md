---
title: PowerPoint-prezentációk PDF-be konvertálása jegyzetekkel .NET-ben
linktitle: PowerPoint PDF-hez jegyzetekkel
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
description: "Konvertálja a PPT és PPTX formátumokat PDF-be jegyzetekkel az Aspose.Slides for .NET segítségével. Megőrzi az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertáljon PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató bemutatja a szükséges lépéseket, és kódrészleteket biztosít a feladat hatékony végrehajtásához. A cikk végére képes lesz:

- A konverziós folyamat megvalósítására, amely a PowerPoint‑diaikat PDF‑dokumentummá alakítja át, miközben megőrzi az előadói jegyzeteket.
- A kimeneti PDF testreszabására, hogy az előadói jegyzetek a kívánt módon legyenek belefoglalva és formázva.

## **PowerPoint átalakítása PDF‑re jegyzettel**

A `Save` metódus a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑re konvertálására előadói jegyzetekkel. Az Aspose.Slides‑szel egyszerűen betölti a prezentációt, beállítja az elrendezési lehetőségeket a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) osztály segítségével, hogy a jegyzetek is szerepeljenek, majd PDF‑ként elmenti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF‑re a Jegyzetdia nézetben.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // PDF-beállítások konfigurálása a felolvasói jegyzetek megjelenítéséhez.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // A felolvasói jegyzetek megjelenítése a dia alatta.
        }
    };

    // A prezentáció mentése PDF-be felolvasói jegyzetekkel.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion). 
{{% /alert %}}