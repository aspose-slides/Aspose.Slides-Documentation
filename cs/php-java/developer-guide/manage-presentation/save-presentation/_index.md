---
title: Ukládání prezentací v PHP
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/php-java/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do proudu
- předdefinovaný typ zobrazení
- Striktní formát Office Open XML
- režim Zip64
- obnovení miniatury
- ukládání postupu
- PHP
- Aspose.Slides
description: "Ukládejte prezentace PowerPoint a OpenDocument do souborů nebo proudů v PHP pomocí Aspose.Slides a nastavujte výstup PPTX a hlášení postupu."
---
## **Přehled**

Po vytvoření prezentace nebo [otevření existující](/slides/cs/php-java/open-presentation/) použijte metodu [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) k zápisu výsledku. Aspose.Slides for PHP via Java může prezentaci uložit do souboru nebo proudu ve formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce popisují standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Ukládání prezentací do souborů**

Pro uložení prezentace do souboru předáte výstupní cestu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/) metodě [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Následující příklad vytvoří prezentaci a uloží ji jako soubor PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Přidejte nebo upravte obsah prezentace zde.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací v jejich původním formátu**

Pro příklady detekce souboru a proudu, chování nově vytvořených prezentací a rozdíl mezi zdrojovým a výstupním formátem viz [Determine the Original Presentation Format](/slides/cs/php-java/detect-presentation-source-format/).

V aplikaci pro dávkové zpracování nemusí být vstupní formát znám předem. Po načtení souboru přečtěte jeho původní formát z metody [Presentation::getSourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSourceFormat). Výslednou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sourceformat/) předáte metodě [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/#toSaveFormat), abyste získali odpovídající hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/), a poté použijte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) k zápisu upravené prezentace.

Následující kompletní příklad zpracuje každý soubor ve vstupním adresáři, aktualizuje jeho název a uloží jej do výstupního adresáře ve formátu, ze kterého byl načten:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideutil/#toSaveFormat) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty ukládání prezentací. Mapuje pouze zdrojové formáty prezentací; nejedná se o výběr exportních formátů jako PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné hodnoty [SourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sourceformat/) vede k výjimce [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Staré soubory PPT, PPS a POT používají stejný binární kontejner. Když je taková prezentace načtena z proudu bez přípony souboru, může být PPS nebo POT identifikován jako PPT. Pokud je vyžadováno zachování těchto starých podtypů, uchovejte původní název souboru nebo metadata formátu samostatně a použijte je při výběru výstupního názvu souboru a formátu.

## **Ukládání prezentací do proudů**

Pro zápis prezentace bez použití konečné cesty souboru předáte zapisovatelný proud a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/) metodě [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save). Tento přístup je užitečný, když má být výstup vrácen z webové služby, uložen v databázi nebo zpracován v paměti.

Následující příklad uloží novou prezentaci do souborového proudu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Můžete určit zobrazení, ve kterém PowerPoint při otevření načte uloženou prezentaci. Použijte metodu [ViewProperties::setLastView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/#setLastView) s hodnotou [ViewType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewtype/) před uložením.

Následující příklad nastaví zobrazení Slide Master jako výchozí:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací ve striktním formátu Office Open XML**

Pro vytvoření souboru PPTX, který splňuje striktní profil Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/) a použijte její metodu [PptxOptions::setConformance](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setConformance) s hodnotou [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Poté předáte možnosti metodě [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací v Office Open XML formátu v režimu Zip64**

Standardní ZIP archiv omezuje komprimovanou i nekomprimovanou velikost jednotlivých položek, celkovou velikost archivu a počet položek. Protože PPTX soubor je ZIP archiv, velmi velká prezentace může tato omezení překročit. Rozšíření ZIP64 zvyšují příslušná omezení velikosti i počtu položek.

Použijte metodu [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setZip64Mode) k řízení, zda Aspose.Slides zapisuje rozšíření ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#IfNecessary) používá ZIP64 jen když prezentace překročí standardní limity ZIP. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Never) zakazuje rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Always) vždy zapisuje rozšíření ZIP64.

Následující příklad vždy povolí rozšíření ZIP64 pro výstupní prezentaci:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
If [Zip64Mode::Never](https://reference.aspose.com/slides/cs/php-java/aspose.slides/zip64mode/#Never) is used and the presentation cannot fit within standard ZIP limits, the save operation throws a [PptxException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Ukládání prezentací v Office Open XML formátu s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání a velikost souboru pomocí metody [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setCompressionLevel). Třída [CompressionLevel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/) poskytuje následující hodnoty:

- [None](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#None) ukládá data bez komprese.
- [Level1](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level1) poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- [Level2](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level2) až [Level5](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level5) postupně upřednostňují menší výstup před rychlostí ukládání.
- [Level6](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level6) vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- [Level7](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level7) a [Level8](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level8) dále upřednostňují menší výstup před rychlostí ukládání.
- [Level9](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compressionlevel/#Level9) poskytuje nejvyšší kompresi a vyžaduje nejvíce času na zpracování.

Následující příklad uloží prezentaci bez komprese:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Následující příklad použije maximální úroveň komprese:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Ukládání prezentací bez obnovení miniatury**

Při uložení prezentace jako PPTX metoda [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) řídí její miniaturu dokumentu:

- `true` znovu vytvoří miniaturu během operace ukládání. Toto je výchozí hodnota.
- `false` zachová existující miniaturu. Pokud prezentace nemá miniaturu, Aspose.Slides ji nevytvoří.

Následující příklad uloží prezentaci bez obnovení její miniatury:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Disabling thumbnail refresh can reduce the time required to save a PPTX file.
{{% /alert %}}

## **Ukládání aktualizací postupu v procentech**

Pro sledování operace ukládání poskytněte Java proxy, která implementuje rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/) a předajte proxy metodě [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides pak během exportu volá metodu [IProgressCallback::reporting](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/#reporting-double-) s hodnotami postupu.

Následující příklad hlásí postup exportu PDF do konzole:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose provides a free [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) built with the Aspose.Slides API. It saves selected slides from a presentation as separate PPT or PPTX files.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides inkrementální nebo „rychlé uložení“?**

Ne. Každá operace ukládání zapíše kompletní výstupní soubor místo aktualizace pouze změněných částí.

**Mohou více vláken ukládat stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) [není vláknově bezpečná](/slides/cs/php-java/multithreading/). Každou instanci přistupujte a ukládejte pouze z jednoho vlákna najednou.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání prezentace?**

[Hypertextové odkazy](/slides/cs/php-java/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě odkazované soubory, takže uložená prezentace musí i nadále mít přístup k jejich umístěním.

**Mohu uložit metadata dokumentu, jako je autor, název, společnost a datum vytvoření?**

Ano. Před uložením nastavte odpovídající [vlastnosti dokumentu](/slides/cs/php-java/presentation-properties/) a Aspose.Slides je zapíše do výstupního souboru.