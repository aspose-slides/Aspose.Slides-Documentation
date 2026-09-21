---
title: PDF dokumentumok szerkesztése C++-ban
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/cpp/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF PPTX-re
- PPTX PDF-re
- C++
- Aspose.Slides
description: "PDF dokumentumok szerkesztése C++-ban az Aspose.Slides-be importálással, a szöveg cseréjével, és a módosított bemutató PDF-be visszamentésével."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetővé teszi a PDF tartalom szerkesztését az oldalak diákként történő importálásával, a bemutató módosításával, majd a PDF-be való visszaexportálással. Ez a cikk egy egyszerű szövegcserét mutat be. A bemutató memóriában marad, így egy köztes PPTX fájl mentése opcionális.

## **Szöveg cseréje PDF-ben**

Használd a [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidecollection/addfrompdf/) metódust az oldalak importálásához, a [Presentation::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/replacetext/) metódust a szöveg frissítéséhez, és a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust az eredmény exportálásához.

A következő példa azt várja, hogy az `input.pdf` a "Draft" szót szerkeszthető szövegként tartalmazza az importálás után. A program ezt a szót a "Final" kifejezéssel helyettesíti, és az `edited.pdf` fájlt írja ki. Az első dia törlése az importálás előtt megakadályoz egy extra üres oldalt a kimenetben. A keresés pontosan egyező nagy- és kisbetűkkel egész szavakat keres; a `nullptr` azt jelenti, hogy nincs szükség eredmény visszahívásra.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

További beállításokért lásd a [Keresés és szövegcsere](/slides/hu/cpp/search-and-replace-text/) és a [PowerPoint konvertálása PDF-be](/slides/hu/cpp/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Note" %}}
A szövegcsere az importált szövegen működik, nem a beolvasott képekben lévő szövegen. A konverzió befolyásolhatja az elrendezést és a formázást, ezért ellenőrizze a kimenetet, különösen akkor, ha a helyettesítő szöveg hosszabb az eredetinél.
{{% /alert %}}

## **GYIK**

**Exportálás előtt szükséges-e PPTX fájlt menteni?**

Nem. A bemutatót memóriában szerkesztheti és exportálhatja. PPTX másolatot csak akkor mentse, ha tovább szeretné szerkeszteni a PowerPointban; lásd a [Prezentációk mentése](/slides/hu/cpp/save-presentation/).

**Miért maradhat egyes szövegek változatlanok?**

A példa pontosan egyező nagy- és kisbetűkkel keresi az egész "Draft" szót. Képként importált vagy különálló szövegkeretekre bontott szöveg nem feltétlenül egyezik a kereséssel. Ellenőrizze az importált tartalmat, és állítsa be a keresést a dokumentumához.