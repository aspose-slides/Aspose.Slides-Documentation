---
title: PowerPoint‑presentaties converteren naar Word‑documenten in C++
linktitle: PowerPoint naar Word
type: docs
weight: 110
url: /nl/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar Word
- presentatie naar Word
- dia naar Word
- PPT naar Word
- PPTX naar Word
- PowerPoint naar DOCX
- presentatie naar DOCX
- dia naar DOCX
- PPT naar DOCX
- PPTX naar DOCX
- PowerPoint naar DOC
- presentatie naar DOC
- dia naar DOC
- PPT naar DOC
- PPTX naar DOC
- PPT opslaan als DOCX
- PPTX opslaan als DOCX
- PPT exporteren naar DOCX
- PPTX exporteren naar DOCX
- C++
- Aspose.Slides
description: "Converteer PowerPoint PPT- en PPTX-dia's naar bewerkbare Word-documenten in C++ met behulp van Aspose.Slides, waarbij de nauwkeurige lay-out, afbeeldingen en opmaak behouden blijven."
---
## **Inleiding**

Als u van plan bent om tekstuele inhoud of informatie uit een presentatie (PPT of PPTX) op nieuwe manieren te gebruiken, kunt u profiteren van het converteren van de presentatie naar Word (DOC of DOCX). 

* In vergelijking met Microsoft PowerPoint biedt de Microsoft Word-app meer gereedschappen of functionaliteiten voor inhoud. 
* Naast de bewerkingsfuncties in Word kunt u ook profiteren van verbeterde samenwerking, afdrukken en deelopties. 

{{% alert color="info" %}} 
U kunt onze [**Presentatie naar Word Online Converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-word) uitproberen om te zien wat u kunt behalen door te werken met tekstuele inhoud van dia's. 
{{% /alert %}} 

## **Aspose.Slides en Aspose.Words**

Om een PowerPoint‑bestand (PPTX of PPT) naar Word (DOCX of DOC) te converteren, heeft u zowel [Aspose.Slides for C++](https://products.aspose.com/slides/nl/cpp/) als [Aspose.Words for C++](https://products.aspose.com/words/cpp/) nodig.

Als zelfstandige API biedt [Aspose.Slides](https://products.aspose.app/slides) voor C++ functies die u in staat stellen tekst uit presentaties te extraheren. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) is een geavanceerde documentverwerkings‑API die applicaties in staat stelt bestanden te genereren, te wijzigen, te converteren, te renderen, af te drukken en andere taken met documenten uit te voeren zonder gebruik te maken van Microsoft Word.

## **Converteer een PowerPoint‑presentatie naar een Word‑document**

Gebruik dit codefragment om de PowerPoint naar Word te converteren:

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
    // genereert een dia-afbeelding als byte-array-stream
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // voegt dia-teksten in
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

## **Veelgestelde vragen**

### Welke componenten moeten geïnstalleerd worden om PowerPoint‑ en OpenDocument‑presentaties naar Word‑documenten te converteren?

U hoeft alleen de desbetreffende pakketten voor [Aspose.Slides for C++](https://releases.aspose.com/slides/nl/cpp/) en [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) aan uw project toe te voegen. Beide bibliotheken werken als zelfstandige API’s en er is geen vereiste om Microsoft Office te installeren.

### Worden alle PowerPoint‑ en OpenDocument‑presentatieformaten ondersteund?

Aspose.Slides [ondersteunt alle presentatieformaten](/slides/nl/cpp/supported-file-formats/), waaronder PPT, PPTX, ODP en andere gangbare bestandstypen. Dit zorgt ervoor dat u kunt werken met presentaties die zijn gemaakt in verschillende versies van Microsoft PowerPoint.