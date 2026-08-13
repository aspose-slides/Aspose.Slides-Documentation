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
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v .NET pomocí Aspose.Slides, s rychlými ukázkami C# kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C# nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, používat různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a použít standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) poskytuje metodu [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/), která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro .NET vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou „*Aspose.Slides*“ a pole PDF Producer hodnotou ve formě „*Aspose.Slides v XX.XX*“. **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides vám umožňuje převádět:

* Celé prezentace do PDF
* konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že vzniklé PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu renderovány přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě Aspose.Slides se pokouší převést poskytnutou prezentaci do PDF s optimálním nastavením na maximální úrovni kvality.

Tento C# kód vám ukazuje, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Uložte prezentaci jako PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose nabízí zdarma online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto převodníkem pro živou implementaci popsaného postupu.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), které vám umožňují přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak má probíhat proces převodu.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Níže uvedený příklad kódu demonstruje, jak převést PowerPoint prezentaci do PDF s několika vlastními možnostmi.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy PdfOptions.
var pdfOptions = new PdfOptions
{
    // Nastavte kvalitu pro JPG obrázky.
    JpegQuality = 90,

    // Nastavte DPI pro obrázky.
    SufficientResolution = 300,

    // Nastavte chování pro metasoubory.
    SaveMetafilesAsPng = true,

    // Nastavte úroveň komprese textu pro textový obsah.
    TextCompression = PdfTextCompression.Flate,

    // Definujte režim souladu PDF.
    Compliance = PdfCompliance.Pdf15
};

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Uložte prezentaci jako PDF dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), abyste zahrnuli skryté snímky jako stránky do výsledného PDF.

Tento C# kód ukazuje, jak převést PowerPoint prezentaci do PDF se zahrnutými skrytými snímky:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Vytvořte instanci třídy PdfOptions.
var pdfOptions = new PdfOptions();

// Přidejte skryté snímky.
pdfOptions.ShowHiddenSlides = true;

// Uložte prezentaci jako PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Převod PowerPoint do PDF chráněného heslem**

Tento C# kód demonstruje, jak převést PowerPoint prezentaci do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Vytvořte instanci třídy PdfOptions.
var pdfOptions = new PdfOptions();

// Nastavte heslo PDF a přístupová oprávnění.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Uložte prezentaci jako PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detekce náhrad písem**

Aspose.Slides poskytuje vlastnost [WarningCallback](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/warningcallback/) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), která vám umožňuje detekovat náhrady písem během procesu převodu prezentace do PDF.

Tento C# kód ukazuje, jak detekovat náhrady písem:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // Nastavte zpětné volání varování v PDF možnostech.
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

{{%  alert color="info"  %}} 

Další informace o přijímání zpětných volání pro náhrady písem během procesu vykreslování najdete v článku [Getting Warning Callbacks for Fonts Substitution](/slides/cs/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Více informací o náhradách písem naleznete v článku [Font Substitution](/slides/cs/net/font-substitution/).

{{% /alert %}} 

## **Převod vybraných snímků z PowerPointu do PDF**

Tento C# kód demonstruje, jak převést pouze konkrétní snímky z PowerPoint prezentace do PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Nastavte pole čísel snímků.
int[] slides = { 1, 3 };

// Uložte prezentaci jako PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Tento C# kód demonstruje, jak převést PowerPoint prezentaci do PDF s určeným rozměrem snímku:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);

// Save the resized presentation as a PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento C# kód demonstruje, jak převést PowerPoint prezentaci do PDF, který zahrnuje poznámky:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Načtěte prezentaci PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Nastavte PDF možnosti s rozvržením poznámek.
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

## **Přístupnost a standardy souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který vyhovuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat PowerPoint dokument do PDF pomocí kterékoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C# kód ukazuje proces převodu PowerPoint do PDF, který vytváří více PDF na základě různých standardů souladu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides podporuje operace převodu PDF, které vám umožňují převádět soubory PDF do populárních formátů. Můžete provádět konverze [PDF to HTML](https://products.aspose.com/slides/cs/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cs/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cs/net/conversion/pdf-to-jpg/), a [PDF to PNG](https://products.aspose.com/slides/cs/net/conversion/pdf-to-png/). Ostatní konverze PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/cs/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cs/net/conversion/pdf-to-tiff/), a [PDF to XML](https://products.aspose.com/slides/cs/net/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním objektem. Individuální elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celý objekt.

## **Často kladené otázky**

### Mohu hromadně převádět více souborů PowerPoint do PDF?

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

### Je možné chránit převáděné PDF heslem?

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

### Jak zahrnu skryté snímky do PDF?

Nastavte vlastnost `ShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) na `true`, aby se skryté snímky zahrnuly do výsledného PDF.

### Může Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?

Ano, můžete kontrolovat kvalitu obrázků nastavením vlastností jako `JpegQuality` a `SufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

### Podporuje Aspose.Slides standardy souladu PDF/A?

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajistí, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro .NET](/slides/cs/net/)
- [API reference Aspose.Slides pro .NET](https://reference.aspose.com/slides/cs/net/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/cs/conversion)