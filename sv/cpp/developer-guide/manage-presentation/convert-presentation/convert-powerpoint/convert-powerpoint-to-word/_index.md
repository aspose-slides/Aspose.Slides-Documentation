---
title: Konvertera PowerPoint-presentationer till Word-dokument i C++
linktitle: PowerPoint till Word
type: docs
weight: 110
url: /sv/cpp/convert-powerpoint-to-word/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till Word
- presentation till Word
- bild till Word
- PPT till Word
- PPTX till Word
- PowerPoint till DOCX
- presentation till DOCX
- bild till DOCX
- PPT till DOCX
- PPTX till DOCX
- PowerPoint till DOC
- presentation till DOC
- bild till DOC
- PPT till DOC
- PPTX till DOC
- spara PPT som DOCX
- spara PPTX som DOCX
- exportera PPT till DOCX
- exportera PPTX till DOCX
- C++
- Aspose.Slides
description: "Konvertera PowerPoint PPT- och PPTX-bilder till redigerbara Word-dokument i C++ med Aspose.Slides, med exakt layout, bilder och formatering bevarade."
---
## **Introduktion**

Om du planerar att använda textinnehåll eller information från en presentation (PPT eller PPTX) på nya sätt, kan du ha nytta av att konvertera presentationen till Word (DOC eller DOCX). 

* Jämfört med Microsoft PowerPoint är Microsoft Word‑appen bättre utrustad med verktyg eller funktioner för innehåll. 
* Förutom redigeringsfunktionerna i Word kan du också dra nytta av förbättrat samarbete, utskrift och delningsfunktioner. 

{{% alert color="info" %}} 

Du kanske vill prova vår [**Presentation till Word Online‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-word) för att se vad du kan vinna på att arbeta med textinnehåll från bilder. 

{{% /alert %}} 

## **Aspose.Slides och Aspose.Words**

För att konvertera en PowerPoint‑fil (PPTX eller PPT) till Word (DOCX eller DOC) behöver du både [Aspose.Slides for C++](https://products.aspose.com/slides/sv/cpp/) och [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Som ett fristående API erbjuder [Aspose.Slides](https://products.aspose.app/slides) för C++ funktioner som låter dig extrahera text från presentationer. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) är ett avancerat dokumentbearbetnings‑API som låter applikationer skapa, modifiera, konvertera, rendera, skriva ut filer och utföra andra uppgifter med dokument utan att använda Microsoft Word.

## **Konvertera en PowerPoint‑presentation till ett Word‑dokument**

Använd det här kodexemplet för att konvertera PowerPoint till Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // genererar en bild av sliden som en bytearrayström
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // infogar bildens texter
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### Vilka komponenter måste installeras för att konvertera PowerPoint‑ och OpenDocument‑presentationer till Word‑dokument?

Du behöver bara lägga till de respektive paketen för [Aspose.Slides for C++](https://releases.aspose.com/slides/sv/cpp/) och [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) i ditt projekt. Båda biblioteken fungerar som fristående API:er, och det krävs ingen installation av Microsoft Office.

### Stöds alla PowerPoint‑ och OpenDocument‑presentationformat?

Aspose.Slides [stödjer alla presentationsformat](/slides/sv/cpp/supported-file-formats/), inklusive PPT, PPTX, ODP och andra vanliga filtyper. Detta säkerställer att du kan arbeta med presentationer som skapats i olika versioner av Microsoft PowerPoint.