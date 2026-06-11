---
title: Hämta varningsåteruppringningar för teckensnittssubstitution
type: docs
weight: 70
url: /sv/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningsåteruppringning
- teckensnittssubstitution
- renderingsprocess
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig att hämta varningsåteruppringningar för teckensnittssubstitution i Aspose.Slides för C++ och visa PowerPoint- och OpenDocument-presentationer korrekt."
---
## **Introduktion**

Aspose.Slides för C++ låter dig ta emot varningsåteruppringningar för teckensnittssubstitution när ett nödvändigt teckensnitt inte är tillgängligt på maskinen under rendering. Dessa återuppringningar hjälper till att diagnostisera problem med saknade eller otillgängliga teckensnitt.

## **Aktivera varningsåteruppringningar**

Aspose.Slides för C++ tillhandahåller enkla API:er för att ta emot varningsåteruppringningar när presentationsbilder renderas. Följ dessa steg för att konfigurera varningsåteruppringningar:

1. Skapa en anpassad återuppringningsklass som implementerar gränssnittet [IWarningCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides.warnings/iwarningcallback/) för att hantera varningar.
1. Ställ in varningsåteruppringningen med hjälp av alternativklasser såsom [RenderingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/) och andra.
1. Läs in en presentation som använder ett teckensnitt som inte är tillgängligt på målmaskinen.
1. Generera en bildminiatyr eller exportera presentationen för att observera resultatet.

**Anpassad varningsåteruppringningsklass:**

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

// Exempelutdata:
//
// Teckensnittet kommer att ersättas från XYZ till {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Generera en bildminiatyr:**

```cpp
// Ställ in en varningsåteruppringning för att hantera teckensnittsrelaterade varningar under bildrendering.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Läs in presentationen från den angivna filsökvägen.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Generera en miniatyrbild för varje bild i presentationen.
for(auto&& slide : presentation->get_Slides())
{
    // Hämta bildens miniatyrbild med de angivna renderingsalternativen.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Exportera till PDF-format:**

```cpp
// Ställ in en varningsåteruppringning för att hantera teckensnittsrelaterade varningar under PDF-export.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Läs in presentationen från den angivna filsökvägen.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportera presentationen som PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Exportera till HTML-format:**

```cpp
// Ställ in en varningsåteruppringning för att hantera teckensnittsrelaterade varningar under HTML-export.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Läs in presentationen från den angivna filsökvägen.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportera presentationen i HTML-format.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```