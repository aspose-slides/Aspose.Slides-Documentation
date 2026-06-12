---
title: PowerPoint-presentaties naar Word-documenten converteren in C++
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
description: "Converteer PowerPoint PPT- en PPTX-dia's naar bewerkbare Word-documenten in C++ met Aspose.Slides, met behoud van een nauwkeurige lay-out, afbeeldingen en opmaak."
---
## **Inleiding**

Als u van plan bent om tekstuele inhoud of informatie uit een presentatie (PPT of PPTX) op nieuwe manieren te gebruiken, kunt u profiteren van het converteren van de presentatie naar Word (DOC of DOCX). 

* In vergelijking met Microsoft PowerPoint biedt de Microsoft Word-app meer hulpmiddelen of functionaliteiten voor inhoud. 
* Naast de bewerkingsfuncties in Word kunt u ook profiteren van verbeterde samenwerkings-, afdruk- en deelmogelijkheden. 

{{% alert color="primary" %}} 

U kunt onze [**Presentatie naar Word Online Converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-word) uitproberen om te zien wat u kunt behalen door met tekstuele inhoud van dia's te werken. 

{{% /alert %}} 

## **Aspose.Slides en Aspose.Words**

Om een PowerPoint‑bestand (PPTX of PPT) naar Word (DOC of DOCX) te converteren, heeft u zowel [Aspose.Slides for C++](https://products.aspose.com/slides/nl/cpp/) als [Aspose.Words for C++](https://products.aspose.com/words/cpp/) nodig.

Als een zelfstandige API biedt [Aspose.Slides](https://products.aspose.app/slides) voor C++ functies waarmee u teksten uit presentaties kunt extraheren. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) is een geavanceerde documentverwerkings‑API die toepassingen in staat stelt bestanden te genereren, wijzigen, converteren, renderen, afdrukken en andere bewerkingen met documenten uit te voeren zonder Microsoft Word te gebruiken.

## **Een PowerPoint‑presentatie naar een Word‑document converteren**

Gebruik dit code‑fragment om de PowerPoint naar Word te converteren:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // genereert en voegt dia-afbeelding in
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // voegt de teksten van de dia in
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
```

## **FAQ**

**Welke componenten moeten geïnstalleerd worden om PowerPoint- en OpenDocument‑presentaties naar Word‑documenten te converteren?**

U hoeft alleen de respectieve pakketten voor [Aspose.Slides for C++](https://releases.aspose.com/slides/nl/cpp/) en [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) aan uw project toe te voegen. Beide bibliotheken functioneren als zelfstandige API's, en er is geen vereiste dat Microsoft Office geïnstalleerd is.

**Worden alle PowerPoint‑ en OpenDocument‑presentatieformaten ondersteund?**

Aspose.Slides [ondersteunt alle presentatieformaten](/slides/nl/cpp/supported-file-formats/), inclusief PPT, PPTX, ODP en andere gangbare bestandstypen. Dit zorgt ervoor dat u kunt werken met presentaties die zijn gemaakt in verschillende versies van Microsoft PowerPoint.