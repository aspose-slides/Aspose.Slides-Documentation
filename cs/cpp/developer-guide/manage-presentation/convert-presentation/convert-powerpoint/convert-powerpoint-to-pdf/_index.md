---
title: Převod PPT a PPTX do PDF v C++ [Zahrnuty pokročilé funkce]
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
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v C++ pomocí Aspose.Slides, s rychlými příklady kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C++ nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady fontů, vybrat konkrétní snímky pro převod a aplikovat normy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Chcete-li převést prezentaci do PDF, předávejte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a poté uložte prezentaci jako PDF pomocí metody `Save`. Třída [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) poskytuje metodu `Save`, která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro C++ vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, aby výsledné PDF co nejvěrněji odpovídalo původním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF s optimálním nastavením na nejvyšší úrovni kvality.

```c++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Uložte prezentaci jako PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose nabízí bezplatný online [**PowerPoint do PDF konvertor**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete tento konvertor použít k testování živé implementace postupu popsaného zde.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti pod třídou [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, nastavit DPI obrázků a další.

```c++
// Vytvořte instanci třídy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Nastavte kvalitu pro JPG obrázky.
pdfOptions->set_JpegQuality(90);

// Nastavte DPI pro obrázky.
pdfOptions->set_SufficientResolution(300);

// Nastavte chování metafilů.
pdfOptions->set_SaveMetafilesAsPng(true);

// Nastavte úroveň komprese textu pro textový obsah.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definujte režim souladu PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Uložte prezentaci jako PDF dokument.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k zahrnutí skrytých snímků jako stránek ve výsledném PDF.

```c++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
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

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/):

```c++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Vytvořte instanci třídy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Nastavte heslo PDF a oprávnění přístupu.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Uložte prezentaci jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Detekce substitucí fontů**

Aspose.Slides poskytuje metodu [set_WarningCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_warningcallback/) pod třídou [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), která vám umožní detekovat substituce fontů během procesu převodu prezentace do PDF.

```c++
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
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Nastavte zpětné volání varování v možnostech PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Uložte prezentaci jako PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Pro více informací o získávání upozornění na substituce fontů během procesu vykreslování viz [Získání upozornění na substituce fontů](/slides/cs/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pro více informací o substituci fontů viz článek [Substituce fontů](/slides/cs/cpp/font-substitution/).

{{% /alert %}} 

## **Převod vybraných snímků z PowerPoint do PDF**

Tento C++ kód ukazuje, jak převést pouze konkrétní snímky z prezentace PowerPoint do PDF:

```C++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Nastavte pole čísel snímků.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Uložte prezentaci jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PDF s určeným rozměrem snímku:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Vytvořte novou prezentaci s upraveným rozměrem snímku.
auto resizedPresentation = MakeObject<Presentation>();

// Nastavte vlastní velikost snímku.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Klonujte první snímek z původní prezentace.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Uložte zmenšenou prezentaci do PDF s poznámkami.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PDF, který zahrnuje poznámky:

```C++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Nastavte možnosti PDF s rozložením poznámek.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Uložte prezentaci do PDF s poznámkami.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí jakéhokoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C++ kód ukazuje proces převodu PowerPoint do PDF, který vytváří několik PDF podle různých standardů souladu:

```C++
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

Aspose.Slides podporuje operace převodu PDF, což vám umožní převádět PDF soubory do populárních formátů. Můžete provádět konverze [PDF do HTML](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-html/), [PDF na obrázek](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-jpg/) a [PDF do PNG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-png/). Další operace převodu PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-tiff/) a [PDF do XML](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako je SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené dotazy**

**Mohu převádět více souborů PowerPoint do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete programově procházet své soubory a aplikovat proces převodu.

**Je možné chránit převodní PDF heslem?**

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k nastavení hesla a definování oprávnění přístupu během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Použijte metodu `set_ShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete kontrolovat kvalitu obrázků pomocí metod jako `set_JpegQuality` a `set_SufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro C++](/slides/cs/cpp/)
- [API reference Aspose.Slides pro C++](https://reference.aspose.com/slides/cs/cpp/)
- [Bezplatné online konvertory Aspose](https://products.aspose.app/slides/cs/conversion)