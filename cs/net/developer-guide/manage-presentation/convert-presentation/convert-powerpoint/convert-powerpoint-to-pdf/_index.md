---
title: Převod PPT a PPTX do PDF v .NET [Obsahuje pokročilé funkce]
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
description: "Převádějte PowerPoint PPT/PPTX na vysoce kvalitní, prohledávatelné PDF v .NET pomocí Aspose.Slides, s rychlými ukázkami kódu v C# a pokročilými možnostmi konverze."
---
## **Přehled**

Konvertování prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v C# nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozložení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace na PDF dokumenty, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, zabezpečit PDF soubory heslem, detekovat substituce písem, vybrat konkrétní snímky pro konverzi a aplikovat standardy shody na výstupní dokumenty.

## **Konverze PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech na PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace na PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) vystavuje metodu [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), která se typicky používá k převodu prezentace na PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro .NET vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci v dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou při konverzi renderovány přesně, včetně:

* Obrázky
* Textové rámečky a tvary
* Formátování textu
* Formátování odstavců
* Hypertextové odkazy
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést zadanou prezentaci do PDF s optimálním nastavením při maximální úrovni kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose nabízí bezplatný online [**PowerPoint do PDF převaděč**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který ukazuje proces převodu prezentace na PDF. Můžete provést test s tímto převaděčem pro živou implementaci postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces konverze probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Při použití vlastních možností konverze můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

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

### **Automatický výběr komprese obrázků**

Pokud prezentace obsahuje mnoho fotografií nebo snímků obrazovky, zmenšení velikosti exportovaného PDF může usnadnit jeho odeslání e‑mailem nebo stažení. Nastavte [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) na `true`, aby se během exportu PDF automaticky vybral nejvhodnější kompresní algoritmus pro každý obrázek.

Následující příklad načte existující prezentaci, povolí automatický výběr komprese obrázků a uloží ji jako PDF dokument. Všechna ostatní nastavení exportu PDF zachovají své výchozí hodnoty.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Tato volba vybírá kompresní algoritmus pro každý obrázek. Snížení [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) snižuje kvalitu JPEG obrázku, zatímco snížení [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) umožňuje obrázkům být downsamplovány na nižší rozlišení, což může zmenšit detail. Povolení automatického výběru komprese samo o sobě nesníží žádné z těchto nastavení.

Výběr kompresních algoritmů pro obrázky vyžaduje dodatečný čas zpracování a paměť. Snížení velikosti závisí na obrázcích v prezentaci a nastaveních exportu; pevné snížení není u každé prezentace zaručeno.

### **Zachovat vložené soubory OLE jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excel, můžete chtít, aby příjemci PDF mohli přistupovat k datům sešitu i prohlížet snímky. Nastavte [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) na `true`, aby se vložené soubory OLE zachovaly jako přílohy v výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona objektu OLE je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením volby na `true` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. Objekt OLE se na stránce PDF nestane interaktivním listem Excel.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excel, a exportuje ji do PDF s připojeným sešitem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

1. Otevřete exportované PDF v prohlížeči, který podporuje přílohy souborů, například Adobe Acrobat Reader.
2. Otevřete panel **Attachments** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu k prohlédnutí dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze přílohy PDF/A a PDF/A-3 povoluje další typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli o omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení shody PDF a neukazuje export do PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

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

Následující příklad exportuje prezentaci do PDF, které vyžaduje heslo `password` pro otevření. Přístupová práva umožňují tisk, včetně tisku ve vysoké kvalitě.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detekce substitucí písem**

Aspose.Slides poskytuje vlastnost [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) pod třídou [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), která vám umožní detekovat substituce písem během procesu konverze prezentace na PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o substitucích písem do konzole. Varování je vytištěno pouze tehdy, když je během exportu nahrazen nepodporovaný font.

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
Pro více informací o substituci písem viz [Substituce písem](/slides/cs/net/font-substitution/) článek.
{{% /alert %}} 

### **Zpracování písem bez samostatného tučného řezu**

Prezentace může použít tučné formátování textu i když její font nemá samostatný tučný řez. Text se může i tak zobrazit tučně pomocí syntetického tučného písma, které uměle zesiluje běžné glyfy. Pokud takový text vypadá příliš těžce nebo se liší od zamýšleného vzhledu v PDF, zkuste nastavit [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) na `true`. Tato volba během exportu PDF vykreslí dotčený text jako bitmapu a může zlepšit jeho vzhled u některých fontů. Jeho výchozí hodnota je `false`.

Ukázková prezentace obsahuje dva textové rámečky: jeden s běžným textem a druhý s tučným formátováním aplikovaným na stejný font, který nemá samostatný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písma a exportuje ji do PDF:

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

Následující náhledy ukazují výstup s vypnutou a zapnutou volbou. V tomto příkladu má tučný text při vypnuté volbě silnější tahy. Po zapnutí volby jsou tahy lehčí; běžný text zůstává nezměněn. Porovnejte výsledky, než si vyberete nastavení pro svou prezentaci.

| Možnost vypnuta (`false`, výchozí) | Možnost zapnuta (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutá](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutá](unsupported-bold-enabled.png) |

V tomto příkladu povolení volby převádí pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho hrany vypadají při 800 % zoomu měkčeji. Běžný text zůstává vyhledávatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučný, když jeho font nemá samostatný tučný řez. [Substituce písem](/slides/cs/net/font-substitution/) místo toho vybere jiný font, pokud původní není k dispozici.

## **Převod vybraných snímků z PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou jednorozměrná (číslování od jedné) a vstupní prezentace musí obsahovat alespoň tři snímky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Změří obsah snímku tak, aby pasoval, a exportuje jediný snímek do PDF.

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

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF a umístí poznámky řečníka každého snímku pod snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

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

## **Přístupnost a standardy shody pro PDF**

Aspose.Slides vám umožňuje použít postup konverze, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů shody: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento C# kód demonstruje proces převodu PowerPoint do PDF, který vytváří několik PDF na základě různých standardů shody:

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
Můžete provést konverze [PDF do HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Další operace konverze PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním tvarem. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celý tvar.

## **Často kladené otázky**

**Mohu převést více souborů PowerPoint do PDF hromadně?**  
Ano, Aspose.Slides podporuje dávkovou konverzi více souborů PPT nebo PPTX do PDF. Můžete projít své soubory a aplikovat proces konverze programově.

**Je možné zabezpečit převzaté PDF heslem?**  
Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu konverze.

**Jak zahrnout skryté snímky do PDF?**  
Nastavte vlastnost [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) v třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) na `true`, aby se skryté snímky zahrnuly do výsledného PDF.

**Umí Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**  
Ano, můžete řídit kvalitu obrázků nastavením vlastností, jako jsou [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) a [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) v třídě [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby se zajistila vysoká kvalita obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy shody PDF/A?**  
Ano, Aspose.Slides vám umožňuje exportovat PDF, která jsou v souladu s různými standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides pro .NET Dokumentace](/slides/cs/net/)
- [Aspose.Slides pro .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Bezplatné online převodníky](https://products.aspose.app/slides/conversion)