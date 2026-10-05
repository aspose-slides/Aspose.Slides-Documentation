---
title: Převod PPT a PPTX do PDF v PHP [Zahrnuty pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v PHP pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v PHP nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a použít standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). Třída [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro PHP přes Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci v výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledná PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou v převodu renderovány přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint na PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF pomocí optimálního nastavení při maximální úrovni kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose nabízí bezplatný online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který ukazuje proces převodu prezentace do PDF. Můžete tento konvertor vyzkoušet pro živou implementaci postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti třídy [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), které vám umožňují přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metaznačky, nastavit úroveň komprese pro text, nakonfigurovat DPI pro obrázky a další.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Zachovat vložené soubory OLE jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excel, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k prohlížení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) s hodnotou `true` pro zachování vložených souborů OLE jako příloh ve výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona objektu OLE je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se souborová data také zahrnou. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. Objekt OLE se nestane interaktivním listem Excelu na stránce PDF.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excel, a exportuje ji do PDF s připojeným sešitem.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Pro kontrolu výsledku:

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Attachments** a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje jen přílohy PDF/A a PDF/A-3 povoluje jiné typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ze třídy [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) k zahrnutí skrytých snímků jako stránek ve výsledném PDF.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Převod PowerPoint do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Přístupová oprávnění umožňují tisk, včetně tisku ve vysoké kvalitě.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Detekce náhrad písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) pod třídou [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), která vám umožňuje detekovat náhrady písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o náhradách písem do konzole. Varování se vypíše jen v případě, že během exportu dojde k náhradě nedostupného písma.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Pro více informací o náhradě písem viz článek [Náhrada písma](/slides/cs/php-java/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků z PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou číslována od jedné a vstupní prezentace musí obsahovat alespoň tři snímky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Převod PowerPoint do PDF s vlastní velikostí snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Škáluje obsah snímku tak, aby se vešel, a exportuje jediný snímek do PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Odstraňte prázdný snímek, který byl vytvořen při vytvoření nové prezentace.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámkových snímků**

Následující příklad exportuje prezentaci do PDF a umístí poznámky řečníka každého snímku pod samotný snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí jakéhokoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět soubory PDF do populárních formátů. Můžete provádět [PDF na HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF na obrázek](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF na JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) a [PDF na PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) převody. Další operace převodu PDF do specializovaných formátů — [PDF na SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF na TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), a [PDF na XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako je SmartArt, diagramy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převést více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

**Je možné chránit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) s hodnotou `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly do výsledného PDF.

**Může Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve svém PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides pro PHP přes Java Dokumentace](/slides/cs/php-java/)
- [Aspose.Slides pro PHP přes Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose bezplatné online převodníky](https://products.aspose.app/slides/conversion)