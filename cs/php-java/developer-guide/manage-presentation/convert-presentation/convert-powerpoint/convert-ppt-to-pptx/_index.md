---
title: Převod PPT na PPTX v PHP
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/php-java/convert-ppt-to-pptx/
keywords:
- převod PowerPointu
- převod prezentace
- převod snímku
- převod PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Převod starých souborů PPT na PPTX v PHP pomocí Aspose.Slides. Obsahuje ukázky PHP pro převod jednoho souboru i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides for PHP via Java může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co ověřit po převodu.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), pak zavolejte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) s argumentem [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/#Pptx). Blok `finally` uvolní prezentaci a její zdroje.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Načtěte starou PPT prezentaci.
$presentation = new Presentation("presentation.ppt");
try {
    // Uložte prezentaci ve formátu PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Přípona souboru sama o sobě nevybírá výstupní formát; rozhoduje o tom argument [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/#Pptx). Ujistěte se, že vstupní a výstupní cesty jsou odlišné, pokud potřebujete zachovat původní soubor PPT.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jednoho převodu nezastaví zbytek dávky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Pro produkční zátěže zaznamenejte úplnou výjimku, rozhodněte, zda může být existující výstupní soubor přepsán, a zapište názvy neúspěšných souborů do fronty pro opětovné zpracování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání převodu. Viz [Password-Protected Presentations](/php-java/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Převod obvykle zachovává snímky, master stránky, rozvržení, text, tvary, obrázky, tabulky a grafy. Přesto PPT a PPTX neprozrazují každou funkci naprosto stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo odkazované OLE objekty, ActiveX ovládací prvky, vložená média, neobvyklá písma nebo VBA makra. Pouhý soubor PPTX není formát podporující makra, takže použijte vhodný pracovní postup s podporou maker, když musí být VBA zachováno. Také ověřte, že požadovaná písma a externí zdroje jsou dostupné v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

Pro důležité dokumenty znovu programově otevřete vygenerovaný PPTX a zkontrolujte klíčové počty snímků a obsah, poté porovnejte jeho vzhled a chování prezentace v zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) za důkaz, že každá starší funkce má přesný ekvivalent v PPTX.

## **Kdy použít PPTX**

Použijte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo uložena ve formátu, který je snazší zkontrolovat a obnovit než starší binární PPT. Ponechte původní PPT jako archivní nebo rollback kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované převody, dávkové zpracování nebo řešení chyb na úrovni aplikace použijte PHP API.

## **Související články**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Uložit prezentace v PHP](/php-java/save-presentation/)
- [Podporované formáty souborů](/php-java/supported-file-formats/)
- [Otevřít prezentace v PHP](/php-java/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides for PHP via Java načítá a ukládá soubory prezentací bez nutnosti Microsoft PowerPoint.

**Zachová převod PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Zkontrolujte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru poskytnete správné heslo. Chybějící nebo nesprávné heslo způsobí selhání operace načtení.

**Mám po převodu smazat soubor PPT?**

Uchovejte originál, dokud neověříte PPTX ve vizualizacích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii, pokud se starší funkce převedou odlišně.