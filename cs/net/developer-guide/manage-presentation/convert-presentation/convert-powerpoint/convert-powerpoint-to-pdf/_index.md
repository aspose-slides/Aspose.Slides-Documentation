---
title: Převod PPT a PPTX do PDF v .NET [Zahrnuty pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Převádějte PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v .NET pomocí Aspose.Slides, s rychlými ukázkami kódu v C# a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C# nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, používat různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [Uložit](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/). Třída [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) poskytuje metodu [Uložit](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/), která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro .NET vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledná PDF soubory věrně odpovídají originálním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hypertextové odkazy
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokouší převést zadanou prezentaci do PDF pomocí optimálního nastavení na nejvyšších úrovních kvality.

Tento C# kód ukazuje, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Uložte prezentaci jako PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose nabízí bezplatný online [**PowerPoint do PDF převodník**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete provést test s tímto převodníkem pro živou implementaci postupu popsaného zde.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) — které vám umožní přizpůsobit výsledný PDF, uzamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Níže uvedený příklad kódu ukazuje, jak převést prezentaci PowerPoint do PDF s několika vlastními možnostmi.

```c#
// Vytvořte instanci třídy PdfOptions.
var pdfOptions = new PdfOptions
{
    // Nastavte kvalitu pro JPG obrázky.
    JpegQuality = 90,

    // Nastavte DPI pro obrázky.
    SufficientResolution = 300,

    // Nastavte chování pro metafily.
    SaveMetafilesAsPng = true,

    // Nastavte úroveň komprese textu pro textový obsah.
    TextCompression = PdfTextCompression.Flate,

    // Definujte režim souladu PDF.
    Compliance = PdfCompliance.Pdf15
};

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Uložte prezentaci jako PDF dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) k zahrnutí skrytých snímků jako stránek ve výsledném PDF.

Tento C# kód ukazuje, jak převést prezentaci PowerPoint do PDF se zahrnutými skrytými snímky:

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Vytvořte instanci třídy PdfOptions.
var pdfOptions = new PdfOptions();

// Přidejte skryté snímky.
pdfOptions.ShowHiddenSlides = true;

// Uložte prezentaci jako PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Převod PowerPoint do PDF chráněného heslem**

Tento C# kód demonstruje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/):

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Vytvořte instanci třídy PdfOptions.
var pdfOptions = new PdfOptions();

// Nastavte heslo PDF a přístupová oprávnění.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Uložte prezentaci jako PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detekce substituce písem**

Aspose.Slides poskytuje vlastnost [WarningCallback](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/warningcallback/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), která vám umožní detekovat substituce písem během procesu převodu prezentace do PDF.

Tento C# kód ukazuje, jak detekovat substituce písem:

```c#
public static void Main()
{
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file. 
    using var presentation = new Presentation("sample.pptx");

    // Nastavte zpětné volání varování v možnostech PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Uložte prezentaci jako PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementace zpětného volání varování.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Pro více informací o přijímání upozornění na substituci písem během procesu vykreslování se podívejte na [Získání upozornění na substituci písem](/slides/cs/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pro více informací o substituci písem se podívejte na článek [Substituce písem](/slides/cs/net/font-substitution/).

{{% /alert %}} 

## **Převod vybraných snímků z PowerPointu do PDF**

Tento C# kód demonstruje, jak převést pouze konkrétní snímky z prezentace PowerPoint do PDF:

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Nastavte pole čísel snímků.
int[] slides = { 1, 3 };

// Uložte prezentaci jako PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Převod PowerPoint do PDF se vlastní velikostí snímku**

Tento C# kód demonstruje, jak převést prezentaci PowerPoint do PDF s určenou velikostí snímku:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento C# kód demonstruje, jak převést prezentaci PowerPoint do PDF, který zahrnuje poznámky:

```c#
// Načtěte PowerPoint prezentaci.
using var presentation = new Presentation("NotesFile.pptx");

// Nakonfigurujte možnosti PDF s rozvržením poznámek.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Uložte prezentaci do PDF s poznámkami.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C# kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF souborů na základě různých standardů souladu:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides podporuje operace převodu PDF, což vám umožní převést PDF soubory do populárních formátů. Můžete provést převody [PDF do HTML](https://products.aspose.com/slides/cs/net/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/cs/net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/cs/net/conversion/pdf-to-jpg/) a [PDF do PNG](https://products.aspose.com/slides/cs/net/conversion/pdf-to-png/). Další operace převodu PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/cs/net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cs/net/conversion/pdf-to-tiff/) a [PDF do XML](https://products.aspose.com/slides/cs/net/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním obrazcem. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celý obrazec.

## **Často kladené otázky**

**Mohu hromadně převést více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné chránit převzatý PDF heslem?**

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Nastavte vlastnost `ShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) na `true`, aby byly skryté snímky zahrnuty do výsledného PDF.

**Může Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků nastavením vlastností jako `JpegQuality` a `SufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajišťuje, že vaše dokumenty splňují požadavky na přístupnost i archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro .NET](/slides/cs/net/)
- [Referenční příručka API Aspose.Slides pro .NET](https://reference.aspose.com/slides/cs/net/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/cs/conversion)