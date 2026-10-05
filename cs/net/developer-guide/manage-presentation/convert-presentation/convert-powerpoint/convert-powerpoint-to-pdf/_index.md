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
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v .NET pomocí Aspose.Slides, s rychlými příklady C# kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C# nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti k řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPointu do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) poskytuje metodu [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), která se obvykle používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro .NET vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides vám umožňuje převádět:
* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, přičemž zajišťuje, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou během převodu vykresleny přesně, včetně:
* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPointu do PDF**

Standardní proces převodu PowerPointu do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést poskytnutou prezentaci do PDF s optimálním nastavením na nejvyšších úrovních kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose nabízí bezplatný online [**PowerPoint do PDF převodník**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto konvertérem pro živou implementaci popsaného postupu.
{{% /alert %}}

## **Převod PowerPointu do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti třídy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), které vám umožňují přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPointu do PDF s vlastním nastavením**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, nakonfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s kvalitou JPEG nastavenou na 90, rozlišením obrázku 300 DPI, metafily uloženými jako PNG a kompresí textu Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excelu, můžete chtít, aby příjemci PDF měli přístup k údajům sešitu i k zobrazení snímků. Nastavte [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) na `true`, abyste zachovali vložené OLE soubory jako přílohy ve výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se k tomu přidá i data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se na stránce PDF nestane interaktivním listem Excelu.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excelu, a exportuje ji do PDF s připojeným sešitem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Pro kontrolu výsledku:
1. Otevřete exportované PDF ve prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Attachments** v prohlížeči a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro prohlédnutí dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení pro přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze přílohy PDF/A a PDF/A-3 povoluje jiné typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export do PDF/A.
{{% /alert %}}

### **Převod PowerPointu do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) třídy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), abyste zahrnuli skryté snímky jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF, včetně všech skrytých snímků.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Převod PowerPointu do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, které vyžaduje heslo `password` k otevření. Přístupová oprávnění umožňují tisk, včetně vysoce kvalitního tisku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detekce náhrad písem**

Aspose.Slides poskytuje vlastnost [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) třídy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), která vám umožňuje detekovat náhrady písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypisuje varování o náhradách písem do konzole. Varování se vytiskne jen v případě, že během exportu dojde k náhradě nedostupného písma.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Pro více informací o náhradě písem si přečtěte článek [Náhrada písma](/slides/cs/net/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků z PowerPointu do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou jednoslovná (počítaná od jedné) a vstupní prezentace musí obsahovat alespoň tři snímky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Převod PowerPointu do PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s rozměrem snímku 612 × 792 bodů (8,5 × 11 palců). Obsah snímku se přizpůsobí a exportuje se jediný snímek do PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Převod PowerPointu do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF a umístí poznámky přednášejícího každého snímku pod snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který vyhovuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C# kód demonstruje proces převodu PowerPointu do PDF, který vytváří více PDF na základě různých standardů souladu:

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides podporuje operace převodu PDF, umožňující převádět PDF soubory do populárních formátů. Můžete provést převody [PDF do HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Další operace převodu PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převést více souborů PowerPoint do PDF?**  
Ano, Aspose.Slides podporuje dávkový převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné chránit převod PDF heslem?**  
Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**  
Nastavte vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) ve třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) na `true`, aby se skryté snímky zahrnuly do výsledného PDF.

**Dokáže Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**  
Ano, můžete řídit kvalitu obrázků nastavením vlastností jako [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) a [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) ve třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**  
Ano, Aspose.Slides vám umožňuje exportovat PDF, která vyhovují různým standardům, včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro .NET](/slides/cs/net/)
- [API reference Aspose.Slides pro .NET](https://reference.aspose.com/slides/net/)
- [Bezplatné online konvertory Aspose](https://products.aspose.app/slides/conversion)