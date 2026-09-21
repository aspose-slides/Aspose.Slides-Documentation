---
title: PDF-documenten bewerken in C++
linktitle: PDF bewerken
type: docs
weight: 65
url: /nl/cpp/edit-pdf/
keywords:
- PDF bewerken
- PDF-tekst vervangen
- PDF naar PPTX
- PPTX naar PDF
- C++
- Aspose.Slides
description: "PDF-documenten bewerken in C++ door ze te importeren in Aspose.Slides, tekst te vervangen en de aangepaste presentatie terug op te slaan als PDF."
---
## **Overzicht**

Aspose.Slides for C++ stelt u in staat PDF‑inhoud te bewerken door de pagina’s te importeren als dia’s, de presentatie aan te passen en deze weer naar PDF te exporteren. In dit artikel wordt een eenvoudige tekster vervanging weergegeven. De presentatie blijft in het geheugen, dus het opslaan van een tussentijdse PPTX‑bestand is optioneel.

## **Tekst vervangen in een PDF**

Gebruik [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidecollection/addfrompdf/) om de pagina’s te importeren, [Presentation::ReplaceText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/replacetext/) om de tekst bij te werken, en [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) om het resultaat te exporteren.

Het volgende voorbeeld gaat ervan uit dat `input.pdf` het woord “Draft” bevat als bewerkbare tekst na import. Het vervangt dat woord door “Final” en schrijft `edited.pdf`. Het wissen van de eerste dia vóór import voorkomt een extra lege pagina in de uitvoer. De zoekopdracht zoekt naar volledige woorden met dezelfde hoofdlettergevoeligheid; `nullptr` betekent dat er geen result‑callback nodig is.

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

Zie voor meer opties [Search and Replace Text](/slides/nl/cpp/search-and-replace-text/) en [Convert PowerPoint to PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Tekstvervanging werkt op geïmporteerde tekst, niet op tekst binnen gescande afbeeldingen. De conversie kan de lay‑out en opmaak beïnvloeden, controleer dus de uitvoer, vooral wanneer de vervangende tekst langer is dan het origineel.

{{% /alert %}}

## **FAQ**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. U kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla alleen een PPTX‑kopie op als u deze later nog in PowerPoint wilt blijven bewerken; zie [Save Presentations](/slides/nl/cpp/save-presentation/).

**Waarom blijft sommige tekst onveranderd?**

Het voorbeeld zoekt naar het volledige woord “Draft” met exacte hoofdlettergebruik. Tekst die als afbeelding is geïmporteerd of die verdeeld is over afzonderlijke tekstkaders zal niet noodzakelijkerwijs overeenkomen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor uw document.