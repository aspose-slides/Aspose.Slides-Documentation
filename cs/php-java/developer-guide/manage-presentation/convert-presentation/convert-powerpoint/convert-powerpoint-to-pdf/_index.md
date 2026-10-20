---
title: Převod PPT a PPTX do PDF v PHP [Zahrnuty pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/php-java/convert-powerpoint-to-pdf/
keywords:
- převod PowerPoint
- převod prezentace
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- převod PPT do PDF
- PPTX do PDF
- převod PPTX do PDF
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
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v PHP pomocí Aspose.Slides, s rychlými ukázkovými kódy a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v PHP nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento návod ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce fontů, vybrat konkrétní snímky pro převod a použít standardy souladu na výstupní dokumenty.

## **Převody PowerPoint na PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Chcete‑li převést prezentaci do PDF, předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/), která se běžně používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF doplní Aspose.Slides pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka**: nemůžete Aspose.Slides instruovat, aby tuto informaci v dokumentech změnilo nebo odstranilo.
{{% /alert %}}

Aspose.Slides umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF tak, že výsledné PDF úzce odpovídají původním prezentacím. Při převodu jsou přesně zachyceny následující prvky a atributy:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint na PDF**

Standardní proces převodu PowerPoint → PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést zadanou prezentaci do PDF pomocí optimálního nastavení na maximální úrovni kvality.

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
Aspose nabízí bezplatný online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Tento převodník můžete použít k testování živé implementace postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint na PDF s volbami**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak má probíhat proces převodu.

### **Převod PowerPoint na PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, konfigurovat DPI obrázků a další.

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

### **Automatický výběr komprese obrázků**

Když prezentace obsahuje mnoho fotografií nebo snímků obrazovky, zmenšení velikosti exportovaného PDF může usnadnit jeho odeslání e‑mailem nebo stažení. Zavolejte [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) s hodnotou `true` a během exportu PDF se automaticky vybere nejvhodnější algoritmus komprese pro každý obrázek.

Následující příklad načte existující prezentaci, povolí automatický výběr komprese obrázků a uloží ji jako PDF dokument. Všechny ostatní nastavení exportu PDF zůstanou na výchozích hodnotách.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Tato možnost volí algoritmus komprese pro každý obrázek. Snížením hodnoty předané metodě [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) se místo toho sníží kvalita JPEG obrázku, zatímco snížením hodnoty předané metodě [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) se umožní downsampling obrázků na nižší rozlišení, což může omezit detail. Povolení automatického výběru komprese samo o sobě nemění žádné z těchto nastavení.

Výběr algoritmů komprese obrázků vyžaduje dodatečný čas zpracování a paměť. Úbytek velikosti závisí na obrázcích v prezentaci a nastaveních exportu; pevný úbytek není u každé prezentace garantován.

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excelu, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k zobrazení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) s hodnotou `true` a vložené OLE soubory se zachovají jako přílohy v výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu se vykreslí na stránce PDF, ale samotný vložený soubor není zahrnut jako příloha. Nastavením na `true` se kromě náhledu přidá i datová část souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor odděleně. OLE objekt se nezmění na interaktivní list Excelu na stránce PDF.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excelu, a exportuje ji do PDF s připojeným sešitem.

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

1. Otevřete exportované PDF v prohlížeči, který podporuje soubory příloh, například Adobe Acrobat Reader.
2. Otevřete panel **Attachments** a vyhledejte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu k prohlédnutí dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A‑1 zakazuje vložené soubory, PDF/A‑2 povoluje pouze přílohy PDF/A a PDF/A‑3 povoluje další typy souborů, včetně sešitů Excelu. Jedná se o požadavky standardů, ne o specifická omezení Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export do PDF/A.
{{% /alert %}}

### **Převod PowerPoint na PDF s skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) a zahrnout skryté snímky jako stránky v výsledném PDF.

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

### **Převod PowerPoint na PDF chráněné heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Přístupová práva umožňují tisk, včetně tisku ve vysoké kvalitě.

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

### **Detekce substituce fontů**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), která vám umožní detekovat substituce fontů během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o substituci fontů do konzole. Varování se zobrazí jen tehdy, když je během exportu nahrazen nedostupný font.

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
Další informace o substituci fontů naleznete v článku [Font Substitution](/slides/cs/php-java/font-substitution/).
{{% /alert %}} 

### **Zpracování fontů bez dedikovaného tučného řezu**

Prezentace může použít tučné formátování textu, i když daný font nemá vlastní tučný řez. Text se pak zobrazí tučně pomocí syntetického ztučování, které uměle zahušťuje běžné glyfy. Když tento text v PDF vypadá příliš těžce nebo jinak neodpovídá zamýšlenému vzhledu, zkuste zavolat [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) s hodnotou `true`. Tato možnost během exportu PDF vykreslí dotčený text jako bitmapu a může tak pro některé fonty zlepšit jeho vzhled. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a druhé s tučným formátováním stejného fontu, který nemá dedikovaný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů fontů a exportuje ji do PDF:

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

Následující náhledy ukazují výstup s vypnutou a zapnutou možností. V tomto příkladu má tučný text těžší tahy při vypnuté volbě. Při zapnuté volbě jsou tahy lehčí; běžný text zůstává nezměněn. Porovnejte výsledky před tím, než si zvolíte nastavení pro svou prezentaci.

| Možnost vypnuta (`false`, výchozí) | Možnost zapnuta (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného tučného stylu vypnutá](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného tučného stylu zapnutá](unsupported-bold-enabled.png) |

V tomto příkladu povolení volby převádí jen tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho hrany při 800 % přiblížení vypadají měkčeji. Běžný text zůstává vyhledávatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato volba rasterizuje text formátovaný jako tučný, pokud daný font nemá dedikovaný tučný řez. [Font substitution](/slides/cs/php-java/font-substitution/) místo toho vybere jiný font, když původní není dostupný.

## **Převod vybraných snímků z PowerPointu do PDF**

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

## **Převod PowerPoint na PDF s vlastní velikostí snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Měřítkem přizpůsobí obsah snímku a exportuje jediný snímek do PDF.

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

    // Odstraňte prázdný snímek, který byl vytvořen v nové prezentaci.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Převod PowerPoint na PDF v zobrazení poznámkových snímků**

Následující příklad exportuje prezentaci do PDF tak, že pod každým snímkem umístí poznámky řečníka. Pro zobrazení výsledku použijte prezentaci obsahující poznámky řečníka.

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

Aspose.Slides vám umožňuje použít proceduru převodu, která odpovídá [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF s jakýmkoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint → PDF, který vytváří více PDF souborů podle různých standardů souladu:

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
Aspose.Slides podporuje operace převodu PDF, což vám umožní převádět PDF soubory do populárních formátů. Můžete provádět [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) a [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) převody. Další převody PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), a [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou celkovou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován jen pro celou figuru.

## **Často kladené otázky**

**Mohu převádět více souborů PowerPoint do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

**Je možné PDF po převodu chránit heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových práv během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) s hodnotou `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) a skryté snímky budou zahrnuty do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) ve třídě [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, a tak zajišťují, že vaše dokumenty splňují požadavky na přístupnost i archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro PHP přes Java](/slides/cs/php-java/)
- [API reference Aspose.Slides pro PHP přes Java](https://reference.aspose.com/slides/php-java/)
- [Aspose bezplatné online převodníky](https://products.aspose.app/slides/conversion)