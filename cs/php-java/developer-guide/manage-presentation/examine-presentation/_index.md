---
title: "Získat a aktualizovat informace o prezentaci v PHP"
linktitle: "Informace o prezentaci"
type: docs
weight: 30
url: /cs/php-java/examine-presentation/
keywords:
- "formát prezentace"
- "vlastnosti prezentace"
- "vlastnosti dokumentu"
- "získat vlastnosti"
- "číst vlastnosti"
- "změnit vlastnosti"
- "upravit vlastnosti"
- "aktualizovat vlastnosti"
- "prozkoumat PPTX"
- "prozkoumat PPT"
- "prozkoumat ODP"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "PHP"
- "Aspose.Slides"
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP pro rychlejší poznatky a chytřejší audit obsahu."
---
## **Overview**

Aspose.Slides může identifikovat formát prezentace a přečíst metadata dokumentu, aniž by vytvořil úplný objektový model prezentace. To je užitečné, když potřebujete klasifikovat soubory, vytvořit inventář nebo zkontrolovat vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek ukazuje lehkou kontrolu pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) a [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/), a také cílené aktualizace prostřednictvím [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/).

## **Check a Presentation Format**

Pokud již máte načtenou prezentaci, podívejte se na [Determine the Original Presentation Format](/slides/cs/php-java/detect-presentation-source-format/) pro detekci po načtení a omezení starších PPT, PPS a POT streamů.

Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) ke kontrole souboru, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Metoda [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#getLoadFormat) udává detekovaný formát, například PPTX, PPT nebo ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Build a Lightweight Presentation Inventory**

Když zpracováváte velké množství souborů prezentací, možná budete potřebovat kompaktní inventář pro validaci, indexování nebo systém správy dokumentů. V takovém scénáři použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) k získání objektu [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/) a poté zavolejte [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) ke čtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a nevyžaduje procházení kompletním objektovým modelem prezentace.

Rozšířené vlastnosti poskytované třídou [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Hodnota inventáře |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getSlides) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getNotes) | Počet snímků obsahujících poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getParagraphs) | Celkový počet odstavců, pokud jsou k dispozici. |
| [getWords](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getWords) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Celkový počet audio a video klipů. |

Následující ukázka čte tyto hodnoty bez vytvoření objektu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a vypisuje kompaktní inventář. Kombinuje také [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getHeadingPairs) s [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getTitlesOfParts) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Každý [HeadingPair](https://reference.aspose.com/slides/cs/php-java/aspose.slides/headingpair/) poskytuje název skupiny a počet položek v této skupině. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getTitlesOfParts) vrací ploché, uspořádané pole, proto zpracujte počet po sobě jdoucích názvů určených každou dvojicí nadpisů.

### **Stored Metadata and Format Limitations**

Vlastnosti inventáře vrácené metodou [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektovým modelem prezentace za účelem přepočítání těchto hodnot při tomto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala své dokumentové vlastnosti.

- **PPTX:** Formát poskytuje rozšířené dokumentové vlastnosti pro počet snímků, poznámek, skrytých snímků, odstavců, slov a multimediálních klipů, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány tvůrcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající vlastnosti souhrnu dokumentu. Pokud je vlastnost absentní nebo nebyla obnovená tvůrcem dokumentu, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počet stránek, odstavců a slov, ale tyto hodnoty se nepřekládají na každou rozšířenou vlastnost specifickou pro PowerPoint. Metadata pro skryté snímky, poznámky, multimédia, páry nadpisů a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Neinterpretujte nulovou hodnotu nebo prázdné pole jako definitivní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prozkoumejte její živý objektový model, pokud výsledek musí odrážet změny v paměti nebo pokud potřebujete ověřit skutečný obsah prezentace.

## **Update Presentation Properties**

Vlastnosti vrácené metodou [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) lze také změnit, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Proveďte změny pomocí [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) a poté zapište svázanou prezentaci pomocí [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Níže uvedený obrázek zobrazuje původní vlastnosti dokumentu.

![Original document properties of the PowerPoint presentation](input_properties.png)

Následující ukázka mění název a čas posledního uložení a zapíše výsledek do nového souboru:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Níže uvedený obrázek zobrazuje upravené vlastnosti dokumentu.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

Pro související bezpečnostní kontroly a nastavení ochrany viz následující články:

- [Password-Protect Presentations](/slides/cs/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/php-java/write-protected-presentation/)

## **FAQ**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation::getFontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getFontsManager). Zavolejte [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) pro získání vložených písem a [FontsManager::getFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getFonts) pro získání písem použitých v prezentaci. Porovnejte oba výsledky a najdete písma, která jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostatečná, přečtěte [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getHiddenSlides) přes [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties). To je vhodné pro lehký inventář. Pokud byla prezentace změněna v paměti, mohou být uložená metadata chybějící nebo zastaralá, nebo potřebujete ověřit živé hodnoty – projděte [Presentation::getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlides) a zkontrolujte metodu [Slide::getHidden](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getHidden) každého snímku.

**Mohu zjistit, zda je použita vlastní velikost snímku a orientace, a zda se liší od výchozích hodnot?**

Ano. Načtěte prezentaci a zavolejte [Presentation::getSlideSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlideSize). Použijte [SlideSize::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/#getSize) a [SlideSize::getOrientation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/#getOrientation) pro porovnání aktuálního nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/) a zavolejte [ChartData::getDataSourceType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#getDataSourceType). Pro externí sešit použijte [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření dostupnosti cíle vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost komplexnosti. Projděte [Presentation::getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlides) a kolekci [BaseSlide::getShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getShapes) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály pro filtraci a změřte reprezentativní vykreslení nebo export, než označíte snímek za potvrzený výkonový úzký bod.