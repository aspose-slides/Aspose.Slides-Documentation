---
title: Bepaal het originele presentatieformaat in PHP
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/php-java/detect-presentation-source-format/
keywords:
- bronformaat
- detecteer presentatiefomaat
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lees het originele formaat van een geladen presentatie in PHP met Aspose.Slides voor PHP via Java, vergelijk de detectie-API's en behandel bestanden, streams en legacy-formaten."
---
## **Overzicht**

Nadat u een presentatie hebt geladen, roept u de [Presentation::getSourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSourceFormat) methode aan om het originele formaat te bepalen. Gebruik deze wanneer latere verwerking afhankelijk is van het formaat waarin de huidige instantie is geladen.

Het bronformaat is anders dan het [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/) dat voor een uitvoerbestand wordt geselecteerd. Opslaan naar een ander formaat wijzigt het bronformaat van de bestaande instantie niet.

## **Lees het bronformaat van een bestand**

Dit voorbeeld vereist een bestaand `sample.pptx`‑bestand. Het laadt het bestand en selecteert een toepassingsverwerkingsbeleid met behulp van [Presentation::getSourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSourceFormat), in plaats van de bestandsnaam. Wijzig het invoerpad om andere formaten te proberen. Het voorbeeld drukt het geselecteerde beleid af; vervang de berichten door uw eigen toepassingslogica.

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

## **Herken de ondersteunde waarden**

De klasse [SourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sourceformat/) definieert gehele constante die de volgende presentatieformaten onderscheiden. De extensies hieronder zijn conventionele extensies, geen reconstructie van de originele bestandsnaam.

| SourceFormat‑waarde | Extensie | Formaat |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentatie 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentatie |
| `Pptm` | `.pptm` | Macro‑ingeschakelde Office Open XML‑presentatie |
| `Pps` | `.pps` | PowerPoint‑diavoorstelling 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑diavoorstelling |
| `Ppsm` | `.ppsm` | Macro‑ingeschakelde Office Open XML‑diavoorstelling |
| `Pot` | `.pot` | PowerPoint‑sjabloon 97–2003 |
| `Potx` | `.potx` | Office Open XML‑sjabloon |
| `Potm` | `.potm` | Macro‑ingeschakelde Office Open XML‑sjabloon |
| `Odp` | `.odp` | OpenDocument‑presentatie |
| `Otp` | `.otp` | OpenDocument‑presentatiesjabloon |
| `Fodp` | `.fodp` | Flat XML ODF‑presentatie |
| `Xml` | `.xml` | PowerPoint‑XML‑presentatie |

## **Lees het bronformaat van een stream**

Dit voorbeeld vereist een bestaand `sample.pps`‑bestand. Het lezen van de bytes in een geheugen‑stream modelleert invoer die zonder bestandsnaam wordt ontvangen, zoals een database‑waarde of een geüploade byte‑array. De [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑constructor ontvangt alleen de stream.

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

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij laden via een bestandspad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder een bestandsnaam kan legacy‑PPS‑ en‑POT‑inhoud gerapporteerd worden als `SourceFormat::Ppt`; het bovenstaande PPS‑voorbeeld drukt de gehele waarde van `SourceFormat::Ppt` af.

Als uw toepassing het onderscheid moet behouden, bewaar dan de oorspronkelijke bestandsnaam of sub‑type‑metadata apart. Een extensie is een nuttige hint voor deze legacy‑subtypen, maar mag niet de enige basis zijn om willekeurige presentatiew inhoud te identificeren.

## **Vergelijk detectie vóór en na het laden**

Gebruik [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) en [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#getLoadFormat) wanneer u een bestand moet inspecteren voordat het volledige presentatiemodel wordt geladen. Gebruik [Presentation::getSourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSourceFormat) wanneer de instantie reeds bestaat.

Dit voorbeeld vereist `sample.pptx` en drukt respectievelijk de gehele waarden van `LoadFormat::Pptx` en `SourceFormat::Pptx` af. In productie kiest u de API die past bij uw verwerkingsfase; een al geladen presentatie heeft geen tweede inspectie nodig uitsluitend om het bronformaat te verkrijgen.

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

De resultaten gebruiken constanten uit verschillende klassen: [LoadFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sourceformat/). Vergelijk hun numerieke waarden niet en ga niet ervan uit dat elk formaat identieke detectieresultaten oplevert. PowerPoint‑XML kan gerapporteerd worden als `LoadFormat::Unknown` vóór het laden en `SourceFormat::Xml` daarna.

## **Houd bron‑ en uitvoerformaten gescheiden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het drukt de gehele waarde van `SourceFormat::Pptx` af, zowel vóór als na het opslaan van de oorspronkelijke instantie. Alleen de nieuwe instantie die is geladen uit de ODP‑output rapporteert `Odp`.

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

Een presentatie die vanaf nul is gemaakt met `new Presentation()` rapporteert `SourceFormat::Pptx`. Het heeft geen invoerbestand: dit is de standaardwaarde voor een nieuw aangemaakte instantie, geen bewijs dat een PPTX‑bestand is geladen. Houd bij of uw toepassing de instantie heeft gecreëerd of geladen, als dat onderscheid van belang is.

## **Koppel een bronformaat aan een extensie**

Het volgende voorbeeld vereist `sample.pptx`. Het koppelt elke momenteel ondersteunde [SourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sourceformat/)‑waarde aan een conventionele extensie, zonder de invoer‑bestandsnaam te analyseren. De fallback voorkomt dat stilzwijgend een extensie wordt toegekend aan een niet‑herkende waarde.

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

Deze koppeling converteert geen bestand en herstelt geen legacy‑PPS‑/‑POT‑subtype dat verloren ging tijdens het laden van een stream. Voor werkelijk opslaan selecteert u expliciet een [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/), of u gebruikt de conversie die wordt getoond in [Save Presentations in Their Original Format](/slides/nl/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifieer formaten door opslaan en opnieuw openen**

Dit zelfstandige voorbeeld maakt een presentatie en schrijft drie bestanden in de werkmap, waarbij bestanden met dezelfde namen worden overschreven. Het opent elke uitvoer zowel via het pad als via een geheugen‑stream opnieuw. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS rapporteert het laden via pad `Pps`, terwijl het laden van dezelfde bytes zonder bestandsnaam `Ppt` rapporteert.

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

De volgende tabel vat de bron‑formaat‑identificatie samen voor presentaties met overeenkomende extensies. Namen duiden constanten aan; de PHP‑voorbeelden drukken hun gehele waarden af:

| Opgeslagen formaat | SourceFormat vanaf een bestandspad | SourceFormat vanaf een naamloze stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectievelijk | Zelfde als bestandspad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectievelijk | Zelfde als bestandspad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectievelijk | Zelfde als bestandspad |
| ODP, OTP | `Odp`, `Otp` respectievelijk | Zelfde als bestandspad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS-/POT‑inhoud wordt geïdentificeerd als `Ppt` voor naamloze streams. De tabel beschrijft format‑identificatie, niet het behoud van elke presentatiefunctie tijdens conversie.

## **FAQ**

**Verandert het opslaan naar ODP het bronformaat van een presentatie die is geladen vanuit PPTX?**

Nee. De bestaande instantie rapporteert nog steeds `Pptx`. Een instantie die is geladen vanuit het opgeslagen ODP‑bestand rapporteert `Odp`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of sub‑type‑metadata apart wanneer dat onderscheid vereist is.

**Welke API moet ik gebruiken als de presentatie al is geladen?**

Lees [Presentation::getSourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSourceFormat). Gebruik [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) voor inspectie vóór het laden.