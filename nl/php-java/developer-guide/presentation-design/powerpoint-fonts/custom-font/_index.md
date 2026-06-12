---
title: Aangepaste PowerPoint-lettertypen in PHP
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
description: "Pas lettertypen aan in PowerPoint-dia's met Aspose.Slides voor PHP via Java om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt u in staat om aangepaste lettertypen te gebruiken in presentaties zonder ze te installeren op het besturingssysteem. U kunt lettertypen laden uit aangepaste mappen, lettertypen beschikbaar stellen voor een specifieke presentatie via document‑niveau lettertypebronnen, of externe lettertypen rechtstreeks laden uit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de uitvoer van de presentatie consistent te houden over verschillende omgevingen. Het artikel legt ook uit hoe u de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe u de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype moet worden opgeslagen binnen de presentatie zelf, gebruik dan expliciet de functies voor het insluiten van lettertypen.

{{% alert color="primary" %}} 

Aspose Slides maakt het mogelijk om deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode:

* TrueType‑lettertypen (.ttf) en TrueType‑collecties (.ttc). Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑lettertypen (.otf). Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste Lettertypen Laden**

Aspose.Slides maakt het mogelijk om de in een presentatie gebruikte lettertypen te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien over verschillende omgevingen. Lettertypen worden geladen uit aangepaste mappen.

1. Geef één of meer mappen op die de lettertypebestanden bevatten.  
2. Roep de statische [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑methode aan om lettertypen uit die mappen te laden.  
3. Laad en render/​exporteer de presentatie.  
4. Roep [FontsLoader::clearCache](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#clearCache--) aan om de lettertype‑cache te wissen.

Het volgende codevoorbeeld toont het proces van het laden van lettertypen:

```php
// Definieer mappen die aangepaste lettertypebestanden bevatten.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderen/exporteren van de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Wis de lettertype‑cache nadat het werk is voltooid.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar wijzigt de volgorde van lettertype‑initialisatie niet.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaardlettertypepad van het besturingssysteem.  
1. De paden die zijn geladen via [FontsLoader](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Aangepaste Lettertype‑Mappen Ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#getFontFolders--)‑methode om u in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die zijn toegevoegd via de `LoadExternalFonts`‑methode en systeemlettertype‑mappen.

Deze PHP‑code laat zien hoe u [getFontFolders](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#getFontFolders--) kunt gebruiken:

```php
# Deze regel geeft de mappen weer waar naar lettertypebestanden wordt gezocht.
# Dit zijn de mappen die via de LoadExternalFonts-methode zijn toegevoegd en systeemlettertype-mappen.
$fontFolders = FontsLoader::getFontFolders();
```

## **Aangepaste Lettertypen Specifiëren voor een Presentatie**
Aspose.Slides biedt de [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑methode zodat u externe lettertypen kunt aangeven die met de presentatie gebruikt moeten worden.

Deze PHP‑code laat zien hoe u de [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑methode kunt gebruiken:

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
    # Werk met de presentatie
    # CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts & global\fonts en hun submappen zijn beschikbaar voor de presentatie
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Lettertypen Extern Beheren**

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑methode om externe lettertypen te laden uit binaire gegevens.

Deze PHP‑code demonstreert het proces van het laden van een lettertype uit een byte‑array:

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

**Hebben aangepaste lettertypen invloed op export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**

Nee. Het registreren van een lettertype voor weergave is niet hetzelfde als het insluiten ervan in een PPTX. Als u wilt dat het lettertype in het presentatie‑bestand wordt meegenomen, moet u de expliciete [insluit‑features](/slides/nl/php-java/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [lettertype‑substitutie](/slides/nl/php-java/font-substitution/), [vervangings‑regels](/slides/nl/php-java/font-replacement/) en [fallback‑sets](/slides/nl/php-java/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeem‑breed te installeren?**

Ja. Verwijs naar uw eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeemlettertype‑mappen in de container‑image.

**Hoe zit het met licenties — mag ik elk aangepast lettertype zonder beperkingen insluiten?**

U bent zelf verantwoordelijk voor de naleving van de lettertype‑licenties. De voorwaarden verschillen; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat u de output distribueert.