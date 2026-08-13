---
title: Převod PPT a PPTX do PDF v C++ [Obsahuje pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/cpp/convert-powerpoint-to-pdf/
keywords:
- převést PowerPoint
- převést prezentaci
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- převést PPT do PDF
- PPTX do PDF
- převést PPTX do PDF
- uložit PowerPoint jako PDF
- uložit PPT jako PDF
- uložit PPTX jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v C++ pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C++ nabízí řadu výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat nahrazení fontů, vybrat konkrétní snímky pro převod a aplikovat normy pro soulad na výstupní dokumenty.

## **PowerPoint do PDF převody**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody `Save`. Třída [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) poskytuje metodu `Save`, která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides pro C++ vkládá informace o své API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Upozornění**, že nemůžete instruovat Aspose.Slides k změně nebo odstranění těchto informací z výstupních dokumentů.
{{% /alert %}}

Aspose.Slides umožňuje převést:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou v převodu renderovány přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperpřipojení
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést zadanou prezentaci do PDF pomocí optimálních nastavení na maximální úrovni kvality.

Tento C++ kód ukazuje, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 
Aspose nabízí bezplatný online [**PowerPoint do PDF převodník**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete si tento převodník vyzkoušet pro živou implementaci popsaného postupu.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) — které umožňují přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak má převod probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak se mají zacházet s metafily, nastavit úroveň komprese pro text, konfigurovat DPI pro obrázky a další.

Níže uvedený příklad kódu ukazuje, jak převést prezentaci PowerPoint do PDF s několika vlastními možnostmi.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Nastavte kvalitu JPG obrázků.
pdfOptions->set_JpegQuality(90);

// Nastavte DPI pro obrázky.
pdfOptions->set_SufficientResolution(300);

// Nastavte chování metafile.
pdfOptions->set_SaveMetafilesAsPng(true);

// Nastavte úroveň komprese textu pro textový obsah.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definujte režim souladu PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Uložte prezentaci jako PDF dokument.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k zahrnutí skrytých snímků jako stránek ve výsledném PDF.

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PDF se zahrnutými skrytými snímky:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Vytvořte instanci třídy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Přidejte skryté snímky.
pdfOptions->set_ShowHiddenSlides(true);

// Uložte prezentaci jako PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Převod PowerPoint do PDF chráněného heslem**

Tento C++ kód demonstruje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Vytvořte instanci třídy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Nastavte heslo PDF a přístupová oprávnění.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Uložte prezentaci jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Detekce náhrad fontů**

Aspose.Slides poskytuje metodu [set_WarningCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), která vám umožní detekovat náhrady fontů během procesu převodu prezentace do PDF.

Tento C++ kód ukazuje, jak detekovat náhrady fontů:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// Implementace zpětného volání varování.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Nastavte zpětné volání varování v PDF možnostech.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Uložte prezentaci jako PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 
Pro více informací o získávání zpětných volání pro náhrady fontů během procesu renderování viz [Getting Warning Callbacks for Fonts Substitution](/slides/cs/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pro více informací o náhradě fontů viz článek [Font Substitution](/slides/cs/cpp/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků z PowerPoint do PDF**

Tento C++ kód demonstruje, jak převést pouze konkrétní snímky z prezentace PowerPoint do PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Nastavte pole čísel snímků.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Uložte prezentaci jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Tento C++ kód demonstruje, jak převést prezentaci PowerPoint do PDF s určeným rozměrem snímku:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Vytvořte novou prezentaci s upravenou velikostí snímku.
auto resizedPresentation = MakeObject<Presentation>();

// Nastavte vlastní velikost snímku.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Zkopírujte první snímek z původní prezentace.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Uložte upravenou prezentaci jako PDF s poznámkami.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Převod PowerPoint do PDF v náhledu poznámek**

Tento C++ kód demonstruje, jak převést prezentaci PowerPoint do PDF, který zahrnuje poznámky:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Nakonfigurujte PDF možnosti s rozvržením poznámek.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Uložte prezentaci jako PDF s poznámkami.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Přístupnost a normy souhlasu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souhlasu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C++ kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF souborů podle různých standardů souhlasu:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět PDF soubory do populárních formátů. Můžete provádět převody [PDF na HTML](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-html/), [PDF na obrázek](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-image/), [PDF na JPG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-jpg/) a [PDF na PNG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-png/). Další operace převodu PDF do specializovaných formátů — [PDF na SVG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-svg/), [PDF na TIFF](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-tiff/) a [PDF na XML](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

### Můžu hromadně převést více souborů PowerPoint do PDF?

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

### Je možné PDF chránit heslem po převodu?

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

### Jak zahrnout skryté snímky do PDF?

Použijte metodu `set_ShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

### Dokáže Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?

Ano, můžete řídit kvalitu obrázků pomocí metod jako `set_JpegQuality` a `set_SufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

### Podporuje Aspose.Slides standardy souhlasu PDF/A?

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides pro C++ Dokumentace](/slides/cs/cpp/)
- [Aspose.Slides pro C++ API Reference](https://reference.aspose.com/slides/cs/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/cs/conversion)