---
title: Převod PPT a PPTX do PDF v PHP [zahrnuty pokročilé funkce]
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
description: "Převod PowerPoint PPT/PPTX na vysoce kvalitní, prohledávatelné PDF v PHP pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v PHP nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, používat různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Using Aspose.Slides, you can convert presentations in the following formats to PDF:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF, pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class and then save the presentation as a PDF using a [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) method. The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class exposes the [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) method that is typically used to convert a presentation to PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro PHP přes Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci v output dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides allows you to convert:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exports presentations to PDF, ensuring the resulting PDFs closely match the original presentations. Elements and attributes are rendered accurately in the conversion, including:

* Obrázky
* Textové pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

The standard PowerPoint-to-PDF conversion process uses default options. In this case, Aspose.Slides tries to convert the provided presentation to PDF using optimal settings at the maximum quality levels.

The following example loads a presentation and saves all visible slides to PDF using the default export settings.

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
Aspose nabízí bezplatný online [**Převodník PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete provést test s tímto převodníkem pro živou ukázku postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti pod třídou [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) které vám umožňují přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, nakonfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s kvalitou JPEG nastavenou na 90, rozlišením obrázku 300 DPI, metafily uloženými jako PNG a kompresí textu Flate.

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

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excel, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k prohlížení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) s hodnotou `true`, aby se vložené OLE soubory zachovaly jako přílohy ve výsledném PDF.

Výchozí hodnota je `false`: obrázek náhledu nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nezmění na interaktivní Excel list na stránce PDF.

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
2. Otevřete panel **Attachments** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze PDF/A přílohy a PDF/A-3 povoluje jiné typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli o omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export do PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), aby byly skryté snímky zahrnuty jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF, včetně všech skrytých snímků.

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

Následující příklad exportuje prezentaci do PDF, které vyžaduje heslo `password` k otevření. Přístupová oprávnění umožňují tisk, včetně tisku ve vysoké kvalitě.

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

### **Detekce substitucí písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) pod třídou [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), což vám umožňuje detekovat substituce písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše upozornění na substituci písem do konzole. Varování je vytištěno jen v případě, že během exportu dojde k nahrazení nedostupného písma.

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
Pro více informací o substituci písem si přečtěte článek [Substituce písem](/slides/cs/php-java/font-substitution/).
{{% /alert %}} 

### **Zpracování písem bez dedikované tučné varianty**

Prezentace může použít tučné formátování textu i když její písmo nemá dedikovanou tučnou variantu. Text se může stále zobrazit tučně pomocí syntetického zesílení, které uměle zahušťuje běžné glyfy. Pokud takový text vypadá příliš těžce nebo se liší od zamýšleného vzhledu v PDF, zkuste zavolat [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) s hodnotou `true`. Tato volba vykreslí dotčený text jako bitmapu během exportu PDF a může zlepšit jeho vzhled u některých písem. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s normálním textem a druhé s tučným formátováním aplikovaným na stejné písmo, které nemá dedikovanou tučnou variantu. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písma a exportuje ji do PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Následující náhledy ukazují výstup se zakázanou a povolenou volbou. V tomto příkladu má tučný text těžší tahy při zakázané volbě. Při povolené volbě jsou tahy lehčí; normální text zůstává nezměněn. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba vypnuta (`false`, výchozí) | Volba zapnuta (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutou](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutou](unsupported-bold-enabled.png) |

V tomto příkladu povolení volby převádí pouze tučný text na bitmapu: nemůže být vybrán, zkopírován ani vyhledáván jako text bez OCR a jeho hrany jsou při 800 % zvětšení měkčí. Normální text zůstává vyhledatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučný, pokud jeho písmo nemá dedikovanou tučnou variantu. [Substituce písem](/slides/cs/php-java/font-substitution/) místo toho vybere jiné písmo, když originál není dostupný.

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

Následující příklad zkopíruje první snímek z prezentace do nové prezentace se velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Škáluje obsah snímku tak, aby se vešel, a exportuje jediný snímek do PDF.

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

    // Odstraňte prázdný snímek, se kterým byla nová prezentace vytvořena.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF, umisťuje poznámky přednášejícího každého snímku pod snímek. Použijte prezentaci obsahující poznámky přednášejícího, abyste viděli výsledek.

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

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF na základě různých standardů souladu:

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
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět PDF soubory do populárních formátů. Můžete provést převody [PDF do HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedinou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převést více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

**Je možné zabezpečit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) s hodnotou `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), aby byly skryté snímky zahrnuty do výsledného PDF.

**Dokáže Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajistíte, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro PHP přes Java](/slides/cs/php-java/)
- [Referenční příručka API Aspose.Slides pro PHP přes Java](https://reference.aspose.com/slides/php-java/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/conversion)