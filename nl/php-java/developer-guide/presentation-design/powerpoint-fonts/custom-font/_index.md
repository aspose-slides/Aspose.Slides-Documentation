---
title: PowerPoint-lettertypen aanpassen in PHP
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/php-java/custom-font/
keywords:
- lettertype
- aangepast lettertype
- extern lettertype
- lettertype laden
- lettertypen beheren
- lettertype map
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Pas lettertypen in PowerPoint-dia's aan met Aspose.Slides voor PHP via Java om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen in presentaties te gebruiken zonder ze op het besturingssysteem te installeren. U kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie via document‑niveau font‑bronnen beschikbaar stellen, of externe lettertypen direct vanuit binaire gegevens laden.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de output van de presentatie consistent te houden in verschillende omgevingen. Het artikel legt ook uit hoe u de lettertype‑mappen die door Aspose.Slides worden gebruikt kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor rendering staat los van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype in de presentatie zelf moet worden opgeslagen, gebruik dan expliciet de functies voor het insluiten van lettertypen.

Een presentatiethema kan verschillende lettertypefamilies refereren voor afzonderlijke schrijfsystemen. Deze koppelingen slaan lettertype‑namen op maar installeren of laden de lettertype‑bestanden niet. Zie [Script‑Specific Theme Fonts](/slides/nl/php-java/script-specific-font-mappings/) om de koppelingen te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente rendering.

{{% alert color="info" title="Opmerking" %}}

Aspose Slides maakt het mogelijk om deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode:

* TrueType‑lettertypen (.ttf) en TrueType Collection‑lettertypen (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides maakt het mogelijk om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen uit aangepaste directories.

1. Geef één of meer mappen op die de lettertypebestanden bevatten.
2. Roep de statische [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode aan om lettertypen uit die mappen te laden.
3. Laad en render/​exporteer de presentatie.
4. Roep [FontsLoader::clearCache](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#clearCache--) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld toont het laadproces van lettertypen:

```php
// Definieer mappen die aangepaste lettertypebestanden bevatten.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Wis de lettertype-cache nadat het werk voltooid is.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar wijzigt niet de volgorde waarin lettertypen worden geïnitialiseerd.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard‑pad van het besturingssysteem voor lettertypen.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#getFontFolders--)‑methode om u in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die via de `LoadExternalFonts`‑methode zijn toegevoegd en systeem‑lettertype‑mappen.

Deze PHP‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```php
# Deze regel geeft de mappen weer waarin naar lettertypebestanden wordt gezocht.
# Dit zijn mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeem-lettertypemappen.
$fontFolders = FontsLoader::getFontFolders();
```

## **Aangepaste lettertypen voor een presentatie specificeren**
Aspose.Slides biedt de [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑methode om externe lettertypen op te geven die met de presentatie worden gebruikt.

Deze PHP‑code laat zien hoe u de [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑methode gebruikt:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Werken met de presentatie
    # CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts en global\fonts en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑methode om externe lettertypen uit binaire gegevens te laden.

Deze PHP‑code demonstreert het laadproces van een lettertype‑byte‑array:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # extern lettertype geladen tijdens de levensduur van de presentatie
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### Beïnvloeden aangepaste lettertypen de export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

### Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?

Nee. Een lettertype registreren voor rendering is niet hetzelfde als het insluiten in een PPTX. Als u het lettertype in het presentatie‑bestand wilt hebben, moet u expliciet de [insluitings‑functies](/slides/nl/php-java/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?

Ja. Configureer [font substitution](/slides/nl/php-java/font-substitution/), [replacement rules](/slides/nl/php-java/font-replacement/) en [fallback sets](/slides/nl/php-java/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

### Kan ik lettertypen in Linux/Docker‑containers gebruiken zonder ze systeemwijd te installeren?

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen uit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑directories in de container‑image.

### Hoe zit het met licenties — mag ik elk aangepast lettertype insluiten zonder restricties?

U bent verantwoordelijk voor de naleving van de licenties van de lettertypen. De voorwaarden verschillen; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de output distribueert.