---
title: Bestäm det ursprungliga presentationsformatet i PHP
linktitle: Källformat
type: docs
weight: 35
url: /sv/php-java/detect-presentation-source-format/
keywords:
- källformat
- identifiera presentationsformat
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Läs det ursprungliga formatet för en inläst presentation i PHP med Aspose.Slides för PHP via Java, jämför identifierings-API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att ha laddat en presentation, anropa metoden [Presentation::getSourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSourceFormat) för att bestämma dess ursprungliga format. Använd den när efterföljande bearbetning beror på formatet som den aktuella instansen laddades från.

Källformatet är skiljt från det [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/) som valts för en utdatafil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

## **Läs källformatet för en fil**

Detta exempel kräver en befintlig fil `sample.pptx`. Det laddar filen och väljer en applikationsbearbetningspolicy med [Presentation::getSourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSourceFormat), snarare än filnamnet. Ändra inmatningssökvägen för att prova andra format. Exemplet skriver ut den valda policyn; ersätt meddelandena med din applikationslogik.

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

## **Känna igen de stödda värdena**

Klassen [SourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sourceformat/) definierar heltalskonstanter som skiljer mellan följande presentationsformat. Nedanstående filändelser är konventionella, inte en återuppbyggnad av det ursprungliga filnamnet.

| SourceFormat‑värde | Filändelse | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentation 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentation |
| `Pptm` | `.pptm` | Makroaktiverad Office Open XML‑presentation |
| `Pps` | `.pps` | PowerPoint‑bildspel 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑bildspel |
| `Ppsm` | `.ppsm` | Makroaktiverat Office Open XML‑bildspel |
| `Pot` | `.pot` | PowerPoint‑mall 97–2003 |
| `Potx` | `.potx` | Office Open XML‑mall |
| `Potm` | `.potm` | Makroaktiverad Office Open XML‑mall |
| `Odp` | `.odp` | OpenDocument‑presentation |
| `Otp` | `.otp` | OpenDocument‑presentationsmall |
| `Fodp` | `.fodp` | Flat XML ODF‑presentation |
| `Xml` | `.xml` | PowerPoint XML‑presentation |

## **Läs källformatet för en ström**

Detta exempel kräver en befintlig fil `sample.pps`. Att läsa dess byte till ett minnesflöde modellerar indata som tas emot utan ett filnamn, till exempel ett databasvärde eller en uppladdad byte‑array. Konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) tar endast emot flödet.

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

PPT, PPS och POT använder samma underliggande binära format. När man laddar via en filsökväg kan filändelsen hjälpa till att skilja ett bildspel eller en mall. Utan ett filnamn kan äldre PPS‑ och POT‑innehåll rapporteras som `SourceFormat::Ppt`; PPS‑exemplet ovan skriver ut heltalsvärdet för `SourceFormat::Ppt`.

Om din applikation måste bevara skillnaden, behåll originalfilnamnet eller underliggande metadata separat. En filändelse är en användbar ledtråd för dessa äldre undertyper, men bör inte vara det enda underlaget för att identifiera godtyckligt presentationsinnehåll.

## **Jämför identifiering före och efter inläsning**

Använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/#getPresentationInfo) och [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#getLoadFormat) när du behöver inspektera en fil innan du laddar in dess kompletta presentationsobjektmodell. Använd [Presentation::getSourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSourceFormat) när instansen redan finns.

Detta exempel kräver `sample.pptx` och skriver ut heltalsvärdena för `LoadFormat::Pptx` respektive `SourceFormat::Pptx`. I produktion bör du välja det API som passar ditt bearbetningsstadium; en redan inläst presentation behöver inte en andra inspektion enbart för att få dess källformat.

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

Resultaten använder konstanter från olika klasser: [LoadFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sourceformat/). Jämför inte deras numeriska värden eller anta att varje format har identiska identifieringsresultat. PowerPoint XML kan rapporteras som `LoadFormat::Unknown` före inläsning och `SourceFormat::Xml` efter inläsning.

## **Håll käll- och utdataformat separata**

Detta exempel kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut heltalsvärdet för `SourceFormat::Pptx` både före och efter sparandet av den ursprungliga instansen. Endast den nya instansen som lästs in från ODP‑utdata rapporterar `Odp`.

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

En presentation som skapas från början med `new Presentation()` rapporterar `SourceFormat::Pptx`. Den har ingen indatafil: detta är standardvärdet för en nyinstans, inte ett bevis på att en PPTX‑fil laddades. Spåra om din applikation skapade eller laddade instansen separat om den skillnaden är viktig.

## **Mappa ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödd [SourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sourceformat/)‑värde till en konventionell filändelse, utan att parsa indatafilnamnet. Fallback‑metoden undviker att tyst tilldela en filändelse till ett okänt värde.

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

Denna mappning konverterar inte en fil eller återställer en äldre PPS/POT‑undertyp som gått förlorad vid strömladdning. För faktiskt sparande, välj ett [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/) explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Detta fristående exempel skapar en presentation och skriver tre filer i arbetskatalogen, vilket skriver över filer med samma namn. Det öppnar varje utdata både via sökväg och genom ett minnesflöde. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar inläsning via sökväg `Pps`, medan inläsning av samma byte utan filnamn rapporterar `Ppt`.

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

Följande tabell sammanfattar identifieringen av källformat för presentationer med matchande filändelser. Namnen betecknar konstanter; PHP‑exemplen skriver ut deras heltalsvärden:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från ett namn‑löst flöde |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS-/POT‑innehåll identifieras som `Ppt` för namn‑lösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av varje presentationsfunktion under konvertering.

## **FAQ**

**Ändrar sparande till ODP källformatet för en presentation som laddats från PPTX?**

Nej. Den befintliga instansen rapporterar fortfarande `Pptx`. En instans som laddas från den sparade ODP‑filen rapporterar `Odp`.

**Kan ett flöde alltid skilja en äldre presentation, ett bildspel och en mall?**

Nej. PPT, PPS och POT delar det binära formatet. Behåll filnamn eller metadata för undertyp separat när den skillnaden krävs.

**Vilket API ska jag använda om presentationen redan är laddad?**

Läs [Presentation::getSourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSourceFormat). Använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/#getPresentationInfo) för inspektion före inläsning.