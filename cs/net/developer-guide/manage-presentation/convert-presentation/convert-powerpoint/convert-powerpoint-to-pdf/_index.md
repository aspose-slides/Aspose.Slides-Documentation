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

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C# nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, zabezpečit PDF soubory heslem, detekovat náhrady fontů, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předávejte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a poté uložte prezentaci jako PDF pomocí metody [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) poskytuje metodu [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro .NET vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokouší převést zadanou prezentaci do PDF s optimálním nastavením a maximální úrovní kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose nabízí bezplatný online [**PowerPoint do PDF převodník**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto převodníkem pro živou implementaci popsaného postupu.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — které vám umožňují přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces převodu postupovat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s kvalitou JPEG nastavenou na 90, rozlišením obrázku 300 DPI, metafily uloženými jako PNG a Flate kompresí textu.

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

Pokud prezentace obsahuje vložený sešit Excelu, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k prohlédnutí snímků. Nastavte [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) na `true`, aby se vložené OLE soubory zachovaly jako přílohy v výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se soubor také zahrne. Náhled zůstává vizuální reprezentací; příloha umožňuje příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nestane interaktivním listem Excelu na stránce PDF.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excelu, a exportuje ji do PDF s přiloženým sešitem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Pro kontrolu výsledku:

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Attachments** a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A‑1 zakazuje vložené soubory, PDF/A‑2 povoluje pouze přílohy PDF/A a PDF/A‑3 povoluje jiné typy souborů, včetně sešitů Excelu. Jedná se o požadavky standardů, nikoli o omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) a zahrnout skryté snímky jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF včetně všech skrytých snímků.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Převod PowerPoint do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Přístupová oprávnění umožňují tisk, včetně tisku vysoké kvality.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detekovat náhrady fontů**

Aspose.Slides poskytuje vlastnost [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ve třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), která vám umožňuje detekovat náhrady fontů během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o náhradách fontů do konzole. Varování se vypisuje jen v případě, že během exportu dojde k substituci nedostupného fontu.

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
Další informace o náhradách fontů naleznete v článku [Font Substitution](/slides/cs/net/font-substitution/).
{{% /alert %}}

### **Zpracování fontů bez dedikovaného tučného řezu**

Prezentace může použít tučné formátování textu i když daný font nemá dedikovaný tučný řez. Text se pak může zobrazit tučně pomocí syntetického ztučnění, které uměle zesiluje běžné glyfy. Když takový text v PDF vypadá příliš těžce nebo neodpovídá zamýšlenému vzhledu, zkuste nastavit [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) na `true`. Tato možnost při exportu PDF rendruje dotčený text jako bitmapu a může zlepšit jeho vzhled u některých fontů. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a druhé s tučným formátováním aplikovaným na stejný font, který nemá dedikovaný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů fontu a exportuje ji do PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Níže jsou uvedeny náhledy s vypnutým a zapnutým nastavením. V tomto příkladu má tučný text těžší tahy při vypnuté volbě. Při zapnuté volbě jsou tahy lehčí; běžný text zůstává beze změny. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba vypnutá (`false`, výchozí) | Volba zapnutá (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutá](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutá](unsupported-bold-enabled.png) |

V tomto příkladu zapnutí volby převádí jen tučný text na bitmapu: nelze jej vybírat, kopírovat ani vyhledávat jako text bez OCR a jeho hrany působí měkčeji při 800 % přiblížení. Běžný text zůstává vyhledávatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučné, pokud jeho font nemá dedikovaný tučný řez. [Font Substitution](/slides/cs/net/font-substitution/) místo toho vybere jiný font, pokud je původní nedostupný.

## **Převod vybraných snímků z PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou jedničková a vstupní prezentace musí obsahovat alespoň tři snímky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s rozměrem snímku 612 × 792 bodů (8,5 × 11 palců). Přizpůsobí obsah snímku tak, aby se vešel, a exportuje jediný snímek do PDF.

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

## **Převod PowerPoint do PDF v náhledu poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF a umístí poznámky řečníka pod každý snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

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

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Dokument PowerPoint můžete exportovat do PDF podle libovolného z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C# kód demonstruje proces převodu PowerPoint do PDF, který vytváří několik PDF na základě různých standardů souladu:

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
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět soubory PDF do populárních formátů. Můžete provádět konverze [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) a [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Další konverze PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), a [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a rovnice, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován jen pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převádět více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné zabezpečit převod PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Nastavte vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) ve třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) na `true`, aby se skryté snímky zahrnuly do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete kontrolovat kvalitu obrázků nastavením vlastností, jako jsou [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) a [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/), ve třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby vaše PDF obsahovalo vysoce kvalitní obrázky.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro .NET](/slides/cs/net/)
- [Reference API Aspose.Slides pro .NET](https://reference.aspose.com/slides/net/)
- [Aspose Bezplatné online převodníky](https://products.aspose.app/slides/conversion)