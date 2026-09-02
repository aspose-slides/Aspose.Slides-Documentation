---
title: Převod PPT na PPTX v PHP
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/php-java/convert-ppt-to-pptx/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Převod starších souborů PPT na PPTX v PHP pomocí Aspose.Slides. Obsahuje příklady v PHP pro převod jednotlivých souborů i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro PHP přes Java dokáže načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co zkontrolovat po konverzi.

## **Převod souboru PPT do PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) . Poté zavolejte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) s argumentem [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/#Pptx) . Blok `finally` uvolní prezentaci a její prostředky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Načíst starou PPT prezentaci.
$presentation = new Presentation("presentation.ppt");
try {
    // Uložit prezentaci ve formátu PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Přípona souboru sama o sobě neurčuje výstupní formát; argument [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/#Pptx) to dělá. Pokud potřebujete zachovat původní soubor PPT, udržujte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován samostatně, takže selhání jedné konverze neukončí zbytek dávky.

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

Pro produkční úlohy zaznamenávejte úplnou výjimku, rozhodněte, zda může být existující výstupní soubor přepsán, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání konverze. Viz [Prezentace chráněné heslem](/slides/cs/php-java/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Přesnost a starší funkce**

Konverze obvykle zachovává snímky, předlohy, rozvržení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nevyjadřují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená multimédia, neobvyklá písma nebo VBA makra. Běžný soubor PPTX není formát podporující makra, takže při potřebě VBA použijte vhodný workflow podporující makra. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu otevřete vygenerovaný PPTX programově a zkontrolujte počet snímků a obsah, poté porovnejte jeho vzhled a chování prezentace ve zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) za důkaz, že každá starší funkce má přesnou reprezentaci v PPTX.

## **Kdy použít PPTX**

Používejte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo ukládána do formátu, který je snadněji kontrolovatelný a obnovitelný než starší binární PPT. Uchovávejte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami přesnosti.

Pokud potřebujete místo toho PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Konverze prezentací do více formátů](/slides/cs/php-java/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online převaděč PPT na PPTX](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte PHP API.

## **Související články**

- [PPT vs PPTX](/slides/cs/php-java/ppt-vs-pptx/)
- [Ukládání prezentací v PHP](/slides/cs/php-java/save-presentation/)
- [Podporované formáty souborů](/slides/cs/php-java/supported-file-formats/)
- [Otevírání prezentací v PHP](/slides/cs/php-java/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPointu?**

Ano. Aspose.Slides pro PHP přes Java načítá a ukládá soubory prezentací bez potřeby Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Ukládá běžný obsah prezentace, ale přesná věrnost není zaručena u každé starší nebo nepodporované funkce. Zkontrolujte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, multimédia, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítací operace.

**Mám po konverzi smazat soubor PPT?**

Uchovávejte originál, dokud neověříte PPTX v prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii, pokud se starší funkce převede odlišně.