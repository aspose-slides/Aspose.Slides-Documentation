---
title: Načtení a aktualizace informací o prezentaci v PHP
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/php-java/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- prozkoumat PPTX
- prozkoumat PPT
- prozkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP pro rychlejší pochopení a inteligentnější audity obsahu."
---
## **Přehled**

Aspose.Slides dokáže rozpoznat formát prezentace a přečíst její metadata dokumentu, aniž by vytvořil kompletní objektový model prezentace. To je užitečné, když potřebujete klasifikovat soubory, vytvořit inventář nebo zkontrolovat vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek ukazuje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) a [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/), a také cílené aktualizace pomocí [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/).

## **Kontrola formátu prezentace**

Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) k inspekci souboru, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Metoda [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#getLoadFormat) vrací zjištěný formát, například PPTX, PPT nebo ODP.

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

## **Vytvoření lehkého inventáře prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexování nebo pro systém správy dokumentů. V takovém scénáři použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) k získání objektu [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/) a poté zavolejte [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) k načtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) ani nevyžaduje průchod kompletním objektovým modelem prezentace.

Rozšířené vlastnosti poskytované [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Hodnota inventáře |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getSlides) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getNotes) | Počet snímků obsahujících poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getParagraphs) | Celkový počet odstavců, pokud jsou k dispozici. |
| [getWords](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getWords) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty, aniž by vytvořil objekt [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a vytiskne kompaktní inventář. Také kombinuje [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getHeadingPairs) s [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getTitlesOfParts) pro zobrazení skupin obsahu, jako jsou fonty, motivy a názvy snímků.

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

Každý [HeadingPair](https://reference.aspose.com/slides/cs/php-java/aspose.slides/headingpair/) poskytuje název skupiny a počet položek v této skupině. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getTitlesOfParts) vrací ploché, uspořádané pole, takže je třeba spotřebovat počet po sobě jdoucích názvů určených každým heading pair.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace, aby pro tento volání přepočítal tyto hodnoty. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která naposledy soubor uložila, neaktualizovala jeho dokumentové vlastnosti.

- **PPTX:** Formát poskytuje rozšířené dokumentové vlastnosti pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako heading pairs a částí názvů. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající dokumentové souhrnné vlastnosti. Pokud je vlastnost chybějící nebo nebyla výrobcem dokumentu aktualizována, Aspose.Slides vrací její uloženou nebo výchozí hodnotu místo výpočtu z snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty se nepřekrývají se všemi rozšířenými vlastnostmi PowerPointu. Metadata pro skryté snímky, poznámky, multimédia, heading‑pair a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Neberte nulovou hodnotu nebo prázdné pole jako autoritativní důkaz, že odpovídající obsah chybí.

Použijte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prozkoumejte její živý objektový model, pokud výsledek musí odrážet změny v paměti nebo pokud potřebujete ověřit skutečný obsah prezentace.

## **Aktualizace vlastností prezentace**

Vlastnosti vrácené metodou [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) lze také měnit bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Proveďte změny pomocí [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) a poté zapište svázanou prezentaci pomocí [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Následující obrázek zobrazuje původní vlastnosti dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad mění název a čas posledního uložení a výsledek zapíše do nového souboru:

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

Následující obrázek zobrazuje změněné vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany viz následující články:

- [Password-Protect Presentations](/slides/cs/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/php-java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation::getFontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getFontsManager). Zavolejte [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) pro získání vložených písem a [FontsManager::getFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getFonts) pro získání písem používaných v prezentaci. Porovnejte oba výsledky a najděte písma, která jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostačující, přečtěte [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getHiddenSlides) přes [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties). To je vhodné pro lehký inventář. Pokud byla prezentace upravena v paměti, uložená metadata mohou chybět nebo být zastaralá, nebo pokud potřebujete ověřit živé hodnoty, projděte [Presentation::getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlides) a zkontrolujte metodu [Slide::getHidden](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getHidden) každého snímku.

**Mohu zjistit, zda je použita vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Načtěte prezentaci a zavolejte [Presentation::getSlideSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlideSize). Použijte [SlideSize::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/#getSize) a [SlideSize::getOrientation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/#getOrientation) k porovnání aktuálního nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/) a zavolejte [ChartData::getDataSourceType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#getDataSourceType). Pro externí sešit zavolejte [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdrojů.

**Jak mohu posoudit 'těžké' snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost složitosti. Projděte [Presentation::getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlides) a kolekci [BaseSlide::getShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getShapes) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály ke screenu a změřte reprezentativní vykreslení nebo export, než označíte snímek za potvrzený výkonový úzký zátěž.