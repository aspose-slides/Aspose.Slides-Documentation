---
title: PowerPoint prezentációk konvertálása kézikönyv módban C++ használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- kézikönyv mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Konvertálja a prezentációkat kézikönyvekké C++-ban. Állítsa be az oldalankénti diákat, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekké az Aspose.Slides segítségével, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a prezentációk különféle formátumokra való konvertálását, beleértve a kézikönyvek létrehozását nyomtatáshoz Kézikönyv módban. Ez a mód lehetővé teszi, hogy beállítsa, hogyan jelennek meg több dia egy oldalon, ami hasznos konferenciákon, szemináriumokon és egyéb eseményeken. Engedélyezheti ezt a módot a `set_SlidesLayoutOptions` metódus meghívásával az [IPdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ihtmloptions/) és [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) interfészekben.

A kézikönyv oldal méreteinek és tájolásának beállításához exportálás előtt, lásd a [Jegyzetoldal mérete](/slides/hu/cpp/notes-size/).

## **Kézikönyv mód export**

A kézikönyv mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egy oldalra, valamint a többi megjelenítési paramétert.

Az alábbi kódrészlet bemutatja, hogyan konvertálhatja a prezentációt PDF formátumba kézikönyv módban.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Betölti a prezentációt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Beállítja az exportálási beállításokat.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // dia számok nyomtatása
slidesLayoutOptions->set_PrintFrameSlide(true);                      // keret nyomtatása a diák körül
slidesLayoutOptions->set_PrintComments(false);                       // nincsenek megjegyzések

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportálja a prezentációt PDF-be a választott elrendezéssel.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `set_SlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, valamint képként történő renderelésnél.
{{% /alert %}} 

## **GYIK**

### Mi a maximális diakép szám oldalanként a kézikönyv módban?

Az Aspose.Slides [előre definiált beállításokat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handouttype/) támogat, amelyek legfeljebb 9 bélyegképet tesznek lehetővé oldalanként vízszintes vagy függőleges sorrendben: 1, 2, 3, 4 (vízszintesen/függőlegesen), 6 (vízszintesen/függőlegesen) és 9 (vízszintesen/függőlegesen).

### Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?

Nem. A bélyegképek számát és sorrendjét szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handouttype/) felsorolás szabályozza; egyedi elrendezések nem támogatottak.

### Beilleszthetek rejtett diákot a kézikönyv kimenetbe?

Igen. Használja a `set_ShowHiddenSlides` metódust a célformátum exportbeállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) esetén.