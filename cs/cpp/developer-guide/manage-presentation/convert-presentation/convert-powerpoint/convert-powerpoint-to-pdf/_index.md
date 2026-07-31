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

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C++ přináší několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti k řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy shody na výstupní dokumenty.

## **Převody PowerPointu do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody `Save`. Třída [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) poskytuje metodu `Save`, která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides pro C++ vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnilo nebo odstranilo.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textových polí a tvarů
* Formátování textu
* Formátování odstavců
* Hyperlinků
* Záhlaví a patiček
* Odrážek
* Tabulek

## **Převod PowerPointu do PDF**

Standardní proces převodu PowerPointu do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokouší převést poskytnutou prezentaci do PDF s optimálním nastavením na maximální úrovni kvality.

Tento C++ kód vám ukazuje, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

```c++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Uložte prezentaci jako PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
Aspose nabízí bezplatný online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto konvertorem pro živou implementaci zde popsaného postupu.
{{% /alert %}}

## **Převod PowerPointu do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti pod třídou [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), které vám umožní přizpůsobit výsledné PDF, zabezpečit PDF heslem nebo určit, jak má převodní proces pokračovat.

### **Převod PowerPointu do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese pro text, nakonfigurovat DPI pro obrázky a další.

Níže uvedený příklad kódu demonstruje, jak převést prezentaci PowerPoint do PDF s několika vlastními možnostmi.

```c++
// Vytvořte instanci třídy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Nastavte kvalitu pro JPG obrázky.
pdfOptions->set_JpegQuality(90);

// Nastavte DPI pro obrázky.
pdfOptions->set_SufficientResolution(300);

// Nastavte chování pro metafily.
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

### **Převod PowerPointu do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [set_ShowHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k zahrnutí skrytých snímků jako stránek do výsledného PDF.

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PDF se zahrnutými skrytými snímky:

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

### **Převod PowerPointu do PDF chráněného heslem**

Tento C++ kód demonstruje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/):

```c++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
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

### **Detekce náhrad písem**

Aspose.Slides poskytuje metodu [set_WarningCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_warningcallback/) pod třídou [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/), která vám umožní detekovat náhrady písem během procesu převodu prezentace do PDF.

Tento C++ kód ukazuje, jak detekovat náhrady písem:

```c++
// Implementace varování callbacku.
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

    // Nastavte varovný callback v PDF možnostech.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Uložte prezentaci jako PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 
Pro více informací o přijímání zpětných volání pro náhrady písem během procesu vykreslování viz [Getting Warning Callbacks for Fonts Substitution](/slides/cs/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pro více informací o náhradách písem viz článek [Font Substitution](/slides/cs/cpp/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků z PowerPointu do PDF**

Tento C++ kód demonstruje, jak převést pouze vybrané snímky z prezentace PowerPoint do PDF:

```C++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Nastavte pole čísel snímků.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Uložte prezentaci jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Převod PowerPointu do PDF se vlastní velikostí snímku**

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PDF se specifikovanou velikostí snímku:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Vytvořte novou prezentaci s upravenou velikostí snímku.
auto resizedPresentation = MakeObject<Presentation>();

// Nastavte vlastní velikost snímku.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Klonujte první snímek z původní prezentace.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Uložte změněnou prezentaci jako PDF s poznámkami.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Převod PowerPointu do PDF v zobrazení poznámek ke snímkům**

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PDF, který zahrnuje poznámky:

```C++
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
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

## **Přístupnost a standardy souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C++ kód demonstruje proces převodu PowerPointu do PDF, který vytváří více PDF na základě různých standardů souladu:

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
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět PDF soubory do populárních formátů. Můžete provést konverze [PDF do HTML](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/cs/cpp/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován jen pro celou figuru.

## **Často kladené otázky**

**Mohu převádět více souborů PowerPoint do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete projít své soubory a aplikovat proces převodu programově.

**Je možné chránit převodní PDF heslem?**

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k nastavení hesla a definování oprávnění přístupu během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Použijte metodu `set_ShowHiddenSlides` v třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako `set_JpegQuality` a `set_SufficientResolution` v třídě [PdfOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/) pro zajištění vysoce kvalitních obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro C++](/slides/cs/cpp/)
- [Reference API Aspose.Slides pro C++](https://reference.aspose.com/slides/cs/cpp/)
- [Bezplatné online konvertory Aspose](https://products.aspose.app/slides/cs/conversion)