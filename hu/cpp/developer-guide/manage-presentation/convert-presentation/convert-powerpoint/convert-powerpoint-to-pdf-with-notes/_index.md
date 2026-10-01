---
title: PowerPoint bemutatók konvertálása PDF-be jegyzetekkel C++-ban
linktitle: PowerPoint PDF-be jegyzetekkel
type: docs
weight: 50
url: /hu/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PDF-be
- bemutató PDF-be
- dia PDF-be
- PPT PDF-be
- PPTX PDF-be
- bemutató mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF jegyzetekkel
- C++
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-be jegyzetekkel az Aspose.Slides for C++ segítségével. Megőrzi a elrendezéseket és az előadói jegyzeteket a professzionális bemutatókhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhatja a PowerPoint bemutatókat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít a feladat hatékony elvégzéséhez. A cikk végére képes lesz:

- A konverziós folyamat megvalósítása, amely a PowerPoint diákot PDF dokumentummá alakítja, miközben megőrzi az előadói jegyzeteket.
- A kimeneti PDF testreszabása annak biztosítására, hogy az előadói jegyzetek benne legyenek, és az igényeinek megfelelően legyenek formázva.

A jegyzetoldal méretének és tájolásának beállításához exportálás előtt tekintse meg a [Jegyzetoldal mérete](/slides/hu/cpp/notes-size/).

## **PowerPoint konvertálása PDF-be jegyzetekkel**

A `Save` metódus a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban használható PPT vagy PPTX bemutató PDF‑be konvertálására előadói jegyzetekkel. Az Aspose.Slides‑szel egyszerűen betölti a bemutatót, beállítja az elrendezési beállításokat a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) osztály segítségével az előadói jegyzetek belefoglalásához, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintabemutatót PDF‑be a Jegyzet dia nézetben.

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

// PDF beállítások konfigurálása az előadói jegyzetek megjelenítéséhez.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Az előadói jegyzetek megjelenítése a dia alatt.
    
    auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// A bemutató mentése PDF-be előadói jegyzetekkel.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Érdemes megnézni az Aspose [Online PowerPoint‑PDF konverter](https://products.aspose.app/slides/hu/conversion). 
{{% /alert %}}