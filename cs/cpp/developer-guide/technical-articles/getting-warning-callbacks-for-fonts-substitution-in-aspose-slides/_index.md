---
title: Získání varovných zpětných volání pro nahrazování písem
type: docs
weight: 70
url: /cs/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varovné zpětné volání
- nahrazování písma
- proces vykreslování
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se získávat varovná zpětná volání pro nahrazování písem v Aspose.Slides pro C++ a přesně zobrazovat prezentace PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides pro C++ vám umožňuje získávat varovné zpětné volání při nahrazování písem, když požadované písmo není během vykreslování na počítači k dispozici. Tato zpětná volání pomáhají diagnostikovat problémy s chybějícími nebo nedostupnými písmy.

## **Povolení varovných zpětných volání**

Aspose.Slides pro C++ poskytuje jednoduchá rozhraní API pro přijímání varovných zpětných volání při vykreslování snímků prezentace. Postupujte podle těchto kroků pro nastavení varovných zpětných volání:

1. Vytvořte vlastní třídu zpětného volání, která implementuje rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides.warnings/iwarningcallback/) pro zpracování varování.
1. Nastavte varovné zpětné volání pomocí tříd možností, jako jsou [RenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/) a další.
1. Načtěte prezentaci, která používá písmo, které není na cílovém počítači k dispozici.
1. Vytvořte miniaturu snímku nebo exportujte prezentaci a sledujte výsledek.

**Vlastní třída varovného zpětného volání:**

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

// Příklad výstupu:
//
// Písmo bude nahrazeno z XYZ na {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Vytvořit miniaturu snímku:**

```cpp
// Nastavte varovné zpětné volání pro zpracování varování souvisejících s písmy během vykreslování snímků.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Načtěte prezentaci ze zadané cesty souboru.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Vygenerujte miniaturu obrázku pro každý snímek v prezentaci.
for(auto&& slide : presentation->get_Slides())
{
    // Získejte miniaturu snímku pomocí zadaných možností vykreslení.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Export do formátu PDF:**

```cpp
// Nastavte varovné zpětné volání pro zpracování varování souvisejících s písmy během exportu PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Načtěte prezentaci ze zadané cesty souboru.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportujte prezentaci jako PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Export do formátu HTML:**

```cpp
// Nastavte varovné zpětné volání pro zpracování varování souvisejících s písmy během exportu HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Načtěte prezentaci ze zadané cesty souboru.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportujte prezentaci ve formátu HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```