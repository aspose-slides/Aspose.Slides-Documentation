---
title: PowerPoint bemutatók konvertálása PDF-re jegyzetekkel C++-ban
linktitle: PowerPoint PDF-re jegyzetekkel
type: docs
weight: 50
url: /hu/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-re jegyzetekkel az Aspose.Slides for C++ használatával. Tartsa meg a elrendezéseket és az előadói jegyzeteket a professzionális bemutatókhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint bemutatókat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészletekkel segíti a feladat hatékony elvégzését. A cikk végére képes lesz:

- Megvalósítani a konverziós folyamatot, hogy a PowerPoint diait PDF dokumentummá alakítsa, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF-et, hogy az előadói jegyzetek szerepeljenek benne, és az igényeinek megfelelően legyenek formázva.

## **PowerPoint konvertálása PDF-re jegyzetekkel**

A `Save` metódus a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban használható egy PPT vagy PPTX bemutató PDF-re konvertálásához előadói jegyzetekkel. Az Aspose.Slides segítségével egyszerűen betölti a bemutatót, a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztály segítségével beállítja a elrendezési opciókat az előadói jegyzetek felvételéhez, majd PDF-ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy minta bemutatót PDF-re a Jegyzet Dia nézetben.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// PDF opciók konfigurálása az előadói jegyzetek megjelenítéséhez.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Az előadói jegyzetek megjelenítése a dia alatt.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// A bemutató mentése PDF-be előadói jegyzetekkel.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatását. 
{{% /alert %}}