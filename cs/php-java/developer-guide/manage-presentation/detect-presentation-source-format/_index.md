---
title: Určete původní formát prezentace v PHP
linktitle: Zdrojový formát
type: docs
weight: 35
url: /cs/php-java/detect-presentation-source-format/
keywords:
- zdrojový formát
- detekce formátu prezentace
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Přečtěte původní formát načtené prezentace v PHP pomocí Aspose.Slides pro PHP přes Java, porovnejte API pro detekci a pracujte se soubory, streamy a staršími formáty."
---
## **Přehled**

Po načtení prezentace zavolejte metodu [Presentation::getSourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSourceFormat), abyste zjistili její původní formát. Použijte ji, když další zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Zdrojový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/), který je vybrán pro výstupní soubor. Uložení do jiného formátu nemění zdrojový formát existující instance.

## **Čtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a pomocí [Presentation::getSourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSourceFormat) vybere politiku zpracování aplikace, místo aby se spoléhal na název souboru. Změňte vstupní cestu, abyste vyzkoušeli jiné formáty. Příklad vytiskne vybranou politiku; nahraďte zprávy vlastní logikou aplikace.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Rozpoznání podporovaných hodnot**

Třída [SourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sourceformat/) definuje celočíselné konstanty, které rozlišují následující formáty prezentací. Níže uvedené přípony jsou konvenční, nejedná se o rekonstrukci původního názvu souboru.

| Hodnota SourceFormat | Přípona | Formát |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentace PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentace Office Open XML |
| `Pptm` | `.pptm` | Makro‑povolující Office Open XML prezentace |
| `Pps` | `.pps` | Promítání PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML promítání |
| `Ppsm` | `.ppsm` | Makro‑povolující Office Open XML promítání |
| `Pot` | `.pot` | Šablona PowerPoint 97–2003 |
| `Potx` | `.potx` | Šablona Office Open XML |
| `Potm` | `.potm` | Makro‑povolující Office Open XML šablona |
| `Odp` | `.odp` | Prezentace OpenDocument |
| `Otp` | `.otp` | Šablona OpenDocument |
| `Fodp` | `.fodp` | Flat XML ODF prezentace |
| `Xml` | `.xml` | PowerPoint XML prezentace |

## **Čtení zdrojového formátu ze streamu**

Tento příklad vyžaduje existující soubor `sample.pps`. Načtení jeho bytů do paměťového streamu modeluje vstup přijímaný bez názvu souboru, např. jako hodnota v databázi nebo nahraný pole bajtů. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) přijímá pouze stream.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS a POT používají stejný podkladový binární formát. Při načítání podle cesty souboru může přípona pomoci rozlišit promítání nebo šablonu. Bez názvu souboru může být starší obsah PPS a POT hlášen jako `SourceFormat::Ppt`; výše uvedený příklad PPS vytiskne celočíselnou hodnotu `SourceFormat::Ppt`.

Pokud vaše aplikace musí zachovat toto rozlišení, uložte původní název souboru nebo metadata podtypu samostatně. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) a [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#getLoadFormat), když potřebujete prozkoumat soubor před načtením jeho kompletního modelu objektů. Použijte [Presentation::getSourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSourceFormat), když již instance existuje.

Tento příklad vyžaduje `sample.pptx` a vytiskne celočíselné hodnoty `LoadFormat::Pptx` a `SourceFormat::Pptx`. V produkci zvolte API odpovídající vašemu stupni zpracování; již načtená prezentace nepotřebuje druhou kontrolu jen kvůli získání jejího zdrojového formátu.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Výsledky používají konstanty z různých tříd: [LoadFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sourceformat/). Neporovnávejte jejich číselné hodnoty ani nepředpokládejte, že každý formát má identické výsledky detekce. PowerPoint XML může být před načtením hlášen jako `LoadFormat::Unknown` a po načtení jako `SourceFormat::Xml`.

## **Udržujte zdrojové a výstupní formáty oddělené**

Tento příklad vyžaduje `sample.pptx` a zapíše `converted.odp`. Vytiskne celočíselnou hodnotu `SourceFormat::Pptx` jak před, tak po uložení původní instance. Pouze nová instance načtená z výstupu ODP hlásí `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Prezentace vytvořená od začátku pomocí `new Presentation()` hlásí `SourceFormat::Pptx`. Nemá vstupní soubor: to je výchozí hodnota pro nově vytvořenou instanci, ne důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení důležité.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sourceformat/) na konvenční příponu, aniž by analyzoval vstupní název souboru. Náhradní řešení zabraňuje tichému přiřazení přípony neznámé hodnotě.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Toto mapování nepřevádí soubor ani neobnovuje starý podtyp PPS/POT ztracený během načítání ze streamu. Pro skutečné ukládání vyberte [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/) explicitně, nebo použijte konverzi uvedenou v [Ukládání prezentací v jejich původním formátu](/slides/cs/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů uložením a opětovným otevřením**

Tento autonomní příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisujíc soubory se stejnými názvy. Každý výstup znovu otevře jak podle cesty, tak přes paměťový stream. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načtení podle cesty hlásí `Pps`, zatímco načtení stejných bajtů bez názvu souboru hlásí `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Následující tabulka shrnuje identifikaci zdrojového formátu pro prezentace s odpovídajícími příponami. Jména označují konstanty; příklady v PHP vytisknou jejich celočíselné hodnoty:

| Uložený formát | SourceFormat z cesty souboru | SourceFormat z bezejmenného streamu |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respektive | Stejně jako cesta souboru |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respektive | Stejně jako cesta souboru |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respektive | Stejně jako cesta souboru |
| ODP, OTP | `Odp`, `Otp` respektive | Stejně jako cesta souboru |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Obsah PPS/POT je pro bezejmenné streamy identifikován jako `Ppt`. Tabulka popisuje identifikaci formátu, nikoli zachování všech vlastností prezentace během konverze.

## **Často kladené otázky**

**Mění uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Existující instance stále hlásí `Pptx`. Instance načtená ze uloženého souboru ODP hlásí `Odp`.

**Dokáže stream vždy rozlišit starou prezentaci, promítání a šablonu?**

Ne. PPT, PPS a POT sdílí binární formát. Uchovávejte název souboru nebo metadata podtypu samostatně, pokud je toto rozlišení vyžadováno.

**Které API mám použít, pokud je prezentace již načtena?**

Přečtěte [Presentation::getSourceFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSourceFormat). Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) pro inspekci před načtením.