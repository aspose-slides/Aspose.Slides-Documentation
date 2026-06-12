---
title: Waarschuwing callbacks ophalen voor lettertype-substitutie
type: docs
weight: 70
url: /nl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwing callback
- lettertype-substitutie
- renderproces
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u waarschuwing callbacks kunt ophalen voor lettertype-substitutie in Aspose.Slides voor C++ en PowerPoint- en OpenDocument-presentaties nauwkeurig kunt weergeven."
---
## **Inleiding**

Aspose.Slides for C++ stelt u in staat waarschuwing callbacks te ontvangen voor lettertype-substitutie wanneer een vereist lettertype niet beschikbaar is op de machine tijdens het renderen. Deze callbacks helpen bij het diagnosticeren van problemen met ontbrekende of ontoegankelijke lettertypen.

## **Waarschuwing Callbacks Inschakelen**

Aspose.Slides for C++ biedt eenvoudige API’s voor het ontvangen van waarschuwing callbacks bij het renderen van presentatieslides. Volg deze stappen om waarschuwing callbacks te configureren:

1. Maak een aangepaste callback-klasse die de [IWarningCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides.warnings/iwarningcallback/) interface implementeert om waarschuwingen af te handelen.
1. Stel de waarschuwing callback in met optieklassen zoals [RenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/) en anderen.
1. Laad een presentatie die een lettertype gebruikt dat niet beschikbaar is op de doelmachine.
1. Genereer een slide-thumbnail of exporteer de presentatie om het effect te observeren.

**Aangepaste Waarschuwing Callback-klasse:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Voorbeeldoutput:
//
// Lettertype wordt vervangen van XYZ naar {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Genereer een Slide-Thumbnail:**

```cpp
// Zet een waarschuwing callback op om lettertypegerelateerde waarschuwingen tijdens het renderen van slides af te handelen.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Laad de presentatie vanuit het opgegeven bestandspad.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Genereer een thumbnail-afbeelding voor elke slide in de presentatie.
for(auto&& slide : presentation->get_Slides())
{
    // Haal de slide-thumbnail afbeelding op met de opgegeven renderopties.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Exporteren naar PDF-formaat:**

```cpp
// Zet een waarschuwing callback op om lettertypegerelateerde waarschuwingen tijdens PDF-export af te handelen.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Laad de presentatie vanuit het opgegeven bestandspad.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exporteer de presentatie als PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Exporteren naar HTML-formaat:**

```cpp
// Zet een waarschuwing callback op om lettertypegerelateerde waarschuwingen tijdens HTML-export af te handelen.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Laad de presentatie vanuit het opgegeven bestandspad.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exporteer de presentatie in HTML-indeling.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```