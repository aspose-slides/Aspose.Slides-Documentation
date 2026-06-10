---
title: PowerPoint előadások konvertálása PDF-be jegyzetekkel C++-ban
linktitle: PowerPoint PDF-be jegyzetekkel
type: docs
weight: 50
url: /hu/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-be jegyzetekkel az Aspose.Slides for C++ használatával. Megőrzi az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ezen a cikken megtanulja, hogyan konvertálhatja a PowerPoint előadásokat PDF formátumba előadói jegyzetekkel az Aspose.Slides segítségével. Ez az útmutató lefedi a szükséges lépéseket, és kódpéldákat biztosít a feladat hatékony elvégzéséhez. A cikk végére képes lesz:

- A konverziós folyamat megvalósítása a PowerPoint diákat PDF dokumentumokká alakítva, miközben megőrzi az előadói jegyzeteket.
- Az eredmény PDF testreszabása annak biztosítása érdekében, hogy az előadói jegyzetek benne legyenek, és a követelményeinek megfelelően legyenek formázva.

## **PowerPoint konvertálása PDF-be jegyzetekkel**

A `Save` metódus a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban használható egy PPT vagy PPTX előadás PDF-re konvertálásához előadói jegyzetekkel. Az Aspose.Slides használatával egyszerűen betölti az előadást, a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztály segítségével konfigurálja az elrendezési beállításokat az előadói jegyzetek bevonásához, majd a fájlt PDF-ként menti. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF-re Jegyzet diá nézetben.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// PDF beállítások konfigurálása az előadói jegyzetek megjelenítéséhez.
    
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Az előadói jegyzetek megjelenítése a dia alatt.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Prezentáció mentése PDF-be előadói jegyzetekkel.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást. 
{{% /alert %}}