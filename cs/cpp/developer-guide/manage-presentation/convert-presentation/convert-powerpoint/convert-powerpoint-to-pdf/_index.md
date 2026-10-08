---
title: Převod PPT a PPTX do PDF v C++ [Zahrnuty pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/cpp/convert-powerpoint-to-pdf/
keywords:
- převod PowerPointu
- převod prezentace
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- převod PPT do PDF
- PPTX do PDF
- převod PPTX do PDF
- uložit PowerPoint jako PDF
- uložit PPT jako PDF
- uložit PPTX jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v C++ pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi konverze."
---
## **Přehled**

Konverze prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C++ nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce fontů, vybrat konkrétní snímky pro konverzi a aplikovat standardy souladu na výstupní dokumenty.

## **Konverze PowerPointu do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) poskytuje metodu [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro C++ vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci ve výstupních dokumentech změnilo nebo odstranilo.
{{% /alert %}}

Aspose.Slides vám umožňuje převádět:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, přičemž výsledné PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou během převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a patičky
* Odrážky
* Tabulky

## **Převod PowerPointu do PDF**

Standardní proces konverze PowerPointu do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést zadanou prezentaci do PDF pomocí optimálního nastavení s maximálními úrovněmi kvality.

V následujícím příkladu se načte prezentace a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose nabízí zdarma online [**PowerPoint do PDF převodník**](https://products.aspose.app/slides/conversion/ppt-to-pdf) který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto převodníkem pro živou implementaci zde popsaného postupu.
{{% /alert %}}

## **Převod PowerPointu do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), které umožňují přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces konverze probíhat.

### **Převod PowerPointu do PDF s vlastními možnostmi**

Při použití vlastních možností konverze můžete definovat preferované nastavení kvality rastrů, určit, jak mají být metafily zpracovány, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s kvalitou JPEG nastavenou na 90, rozlišením obrázků 300 DPI, metafily uloženými jako PNG a kompresí textu Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excelu, můžete chtít, aby příjemci PDF mohli přistupovat k datům sešitu i zobrazovat snímky. Zavolejte [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) s hodnotou `true`, aby se vložené OLE soubory zachovaly jako přílohy v výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením volby na `true` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nezmění na interaktivní list Excelu na stránce PDF.

V následujícím příkladu se načte prezentace, která již obsahuje vložený sešit Excelu, a exportuje se do PDF se sešitem připojeným.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Pro kontrolu výsledku:

1. Otevřete exportovaný PDF v prohlížeči, který podporuje souborové přílohy, např. Adobe Acrobat Reader.
2. Otevřete panel **Přílohy** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro prohlédnutí dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 umožňuje jen přílohy PDF/A a PDF/A-3 povoluje jiné typy souborů, včetně sešitů Excelu. Jedná se o požadavky standardů, ne o omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPointu do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF, včetně všech skrytých snímků.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Převod PowerPointu do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Oprávnění přístupu umožňují tisk, včetně tisku ve vysoké kvalitě.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Detekce substitucí fontů**

Aspose.Slides poskytuje metodu [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), která umožňuje detekovat substituce fontů během procesu konverze prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypisuje varování o substituci fontů do konzole. Varování se vypíše jen tehdy, když je během exportu nahrazen nedostupný font.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Pro více informací o substituci fontů si přečtěte článek [Substituce fontů](/slides/cs/cpp/font-substitution/).
{{% /alert %}} 

### **Zpracování fontů bez dedikovaného tučného řezu**

Prezentace může použít tučné formátování textu i přesto, že její font nemá dedikovaný tučný styl. Text se může i tak jevit tučně díky syntetickému ztuštění, které uměle zahušťuje běžné glyfy. Pokud takový text vypadá příliš těžce nebo jinak odlišně od zamýšleného vzhledu v PDF, zkuste zavolat [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) s hodnotou `true`. Tato volba během exportu PDF vykreslí dotčený text jako bitmapu a může zlepšit jeho vzhled u některých fontů. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a jedno s tučným formátováním aplikovaným na stejný font, který nemá dedikovaný tučný styl. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů fontu a exportuje ji do PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Následující náhledy ukazují výstup s vypnutou a zapnutou volbou. V tomto příkladu má tučný text těžší tahy při vypnuté volbě. Při zapnuté volbě jsou tahy lehčí; běžný text zůstává nezměněn. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba vypnuta (`false`, výchozí) | Volba zapnuta (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu fontu vypnutá](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu fontu zapnutá](unsupported-bold-enabled.png) |

V tomto příkladu povolení volby převede pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho hrany vypadají při 800 % přiblížení měkce. Běžný text zůstává prohledávatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučný, pokud jeho font nemá dedikovaný tučný styl. [Substituce fontů](/slides/cs/cpp/font-substitution/) místo toho vybere jiný font, když originál není dostupný.

## **Převod vybraných snímků z PowerPointu do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou číslována od jedné a vstupní prezentace musí obsahovat alespoň tři snímky.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Převod PowerPointu do PDF s vlastní velikostí snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Obsah snímku se přizpůsobí a exportuje se jediný snímek do PDF.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Převod PowerPointu do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF, přičemž poznámky přednášejícího ke každému snímku umístí pod snímek. Použijte prezentaci obsahující poznámky přednášejícího, abyste viděli výsledek.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup konverze, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF s použitím libovolného z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

C++ kód ukazuje proces konverze PowerPointu do PDF, který vytváří několik PDF podle různých standardů souladu:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět PDF soubory do populárních formátů. Můžete provádět převody [PDF do HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut jen pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převádět více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje dávkovou konverzi více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces konverze programově.

**Je možné PDF po převodu chránit heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) k nastavení hesla a definování oprávnění přístupu během procesu konverze.

**Jak zahrnout skryté snímky do PDF?**

Použijte metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby se skryté snímky zahrnuly do výsledného PDF.

**Může Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete ovládat kvalitu obrázků pomocí metod jako [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) a [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajišťují, že vaše dokumenty vyhovují požadavkům na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro C++](/slides/cs/cpp/)
- [API reference Aspose.Slides pro C++](https://reference.aspose.com/slides/cpp/)
- [Aspose zdarma online převodníky](https://products.aspose.app/slides/conversion)