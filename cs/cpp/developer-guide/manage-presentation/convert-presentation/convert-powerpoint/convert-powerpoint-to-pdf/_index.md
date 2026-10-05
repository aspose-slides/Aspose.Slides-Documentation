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
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Převést PowerPoint PPT/PPTX na vysoce kvalitní, prohledávatelné PDF v C++ pomocí Aspose.Slides, s rychlými příklady kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C++ nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Using Aspose.Slides, you can convert presentations in the following formats to PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předávejte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a poté uložte prezentaci jako PDF pomocí metody [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) poskytuje metodu [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro C++ vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplňuje pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Note** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides umožňuje převádět:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, což zajišťuje, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu renderovány přesně, včetně:

* Obrázky
* Textové rámečky a tvary
* Formátování textu
* Formátování odstavců
* Hypertextové odkazy
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokouší převést poskytnutou prezentaci do PDF pomocí optimálního nastavení na nejvyšších úrovních kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

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
Aspose nabízí bezplatný online [**PowerPoint do PDF převaděč**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto převaděčem pro živou implementaci zde popsaného postupu.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces převodu pokračovat.

### **Převod PowerPoint do PDF s vlastním nastavením**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

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

Pokud prezentace obsahuje vloženou sešit Excel, můžete chtít, aby příjemci PDF mohli přistupovat k datům sešitu i prohlížet snímky. Zavolejte [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) s `true`, aby se vložené OLE soubory zachovaly jako přílohy ve výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se souborová data také zahrnou. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nezmění na interaktivní list Excelu na stránce PDF.

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

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, např. Adobe Acrobat Reader.
2. Otevřete panel **Attachments** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze přílohy PDF/A a PDF/A-3 povoluje další typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, ne o omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

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

### **Převod PowerPoint do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Přístupová oprávnění umožňují tisk, včetně tisku vysoké kvality.

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

### **Detekce náhrad písem**

Aspose.Slides poskytuje metodu [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) pod třídou [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), která vám umožní detekovat náhrady písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o náhradě písem do konzole. Varování je vytištěno pouze když je během exportu nahrazen nepřístupný font.

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
Pro více informací o náhradě písem viz článek [Náhrada písma](/slides/cs/cpp/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků z PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou jednoslovná (one-based), a vstupní prezentace musí obsahovat alespoň tři snímky.

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

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Obsah snímku se přizpůsobí tak, aby se vešel, a exportuje jediný snímek do PDF.

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

## **Převod PowerPoint do PDF v zobrazení poznámkových snímků**

Následující příklad exportuje prezentaci do PDF, přičemž umístí poznámky řečníka každého snímku pod samotný snímek. Použijte prezentaci obsahující poznámky řečníka, aby bylo vidět výsledek.

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

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

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
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět soubory PDF do populárních formátů. Můžete provést [PDF do HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) převody. Další operace převodu PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Note:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou jako SmartArt, diagramy a vzorce jako s jedním obrazem. Individuální prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celý obraz.

## **FAQ**

**Mohu hromadně převádět více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné chránit převod PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnu skryté snímky do PDF?**

Použijte metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby se skryté snímky zahrnuly do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) a [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides pro C++ Dokumentace](/slides/cs/cpp/)
- [Aspose.Slides pro C++ API reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Bezplatné online převaděče](https://products.aspose.app/slides/conversion)