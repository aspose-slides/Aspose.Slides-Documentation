---
title: Anpassa PowerPoint-typsnitt i PHP
linktitle: Anpassat typsnitt
type: docs
weight: 20
url: /sv/php-java/custom-font/
keywords:
- typsnitt
- anpassat typsnitt
- externt typsnitt
- ladda typsnitt
- hantera typsnitt
- typsnittsmapp
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Anpassa typsnitt i PowerPoint-bilder med Aspose.Slides för PHP via Java för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade typsnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in typsnitt från anpassade mappar, tillhandahålla typsnitt för en specifik presentation via dokumentnivå‑typsnittskällor, eller läsa in externa typsnitt direkt från binär data.

Inlästa typsnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsistent över olika miljöer. Artikeln förklarar också hur du kontrollerar typsnittsmapporna som används av Aspose.Slides och hur du rensar typsnittscachen efter att ha arbetat med externa typsnitt.

Registrering av anpassade typsnitt för rendering är separerat från att bädda in typsnitt i en PPTX‑fil. Om ett typsnitt måste lagras i presentationen själv, använd typsnittsinbäddningsfunktionerna explicit.

{{% alert color="primary" %}} 
Aspose Slides låter dig läsa in dessa typsnitt med metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) och TrueType Collection (.ttc) typsnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) typsnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Ladda anpassade typsnitt**

Aspose.Slides låter dig läsa in typsnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata — såsom PDF, bilder och andra stödda format — så att de resulterande dokumenten ser konsistenta ut i olika miljöer. Typsnitt läses in från anpassade kataloger.

1. Ange en eller flera mappar som innehåller typsnittsfilern​a.
2. Anropa den statiska metoden [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) för att läsa in typsnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader::clearCache](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#clearCache--) för att rensa typsnittscachen.

Följande kodexempel visar fontinläsningsprocessen:

```php
// Definiera mappar som innehåller anpassade typsnittsfiler.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Ladda in anpassade typsnitt från de angivna mapparna.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa typsnitten.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Rensa typsnittscachen när arbetet är slutfört.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) lägger till ytterligare mappar i typsnittssökvägarna, men ändrar inte ordningen för typsnittsinitialisering.  
Typsnitt initieras i följande ordning:

1. Operativsystemets standardtypsnittssökväg.
2. Sökvägarna som lästs in via [FontsLoader](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta anpassade typsnittsmappar**
Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#getFontFolders--) så att du kan hitta typsnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets typsnittsmappar.

Denna PHP‑kod visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Denna rad visar mappar där typsnittsfiler söks.
# Det är mappar som lagts till via LoadExternalFonts-metoden och systemets typsnittsmapp.
$fontFolders = FontsLoader::getFontFolders();
```

## **Ange anpassade typsnitt som används i en presentation**
Aspose.Slides tillhandahåller metoden [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) så att du kan ange externa typsnitt som ska användas i presentationen.

Denna PHP‑kod visar hur du använder metoden [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    # Arbeta med presentationen
    # CustomFont1, CustomFont2 och typsnitt från assets\fonts & global\fonts mappar och deras underkataloger är tillgängliga för presentationen
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Hantera typsnitt externt**

Aspose.Slides tillhandahåller metoden [loadExternalFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) så att du kan läsa in externa typsnitt från binär data.

Denna PHP‑kod demonstrerar processen för att läsa in typsnitt från en byte‑array:

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
        # externt typsnitt laddat under presentationens livstid
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

**Påverkar anpassade typsnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna typsnitt används av renderaren i alla exportformat.

**Bäddas anpassade typsnitt automatiskt i den resulterande PPTX‑filen?**

Nej. Att registrera ett typsnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att typsnittet ska finnas i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/php-java/embedded-font/).

**Kan jag styra fallback‑beteende när ett anpassat typsnitt saknar vissa glyfer?**

Ja. Konfigurera [typsnittssubstitution](/slides/sv/php-java/font-substitution/), [ersättningsregler](/slides/sv/php-java/font-replacement/) och [fallback‑uppsättningar](/slides/sv/php-java/fallback-font/) för att exakt ange vilket typsnitt som ska användas när den begärda glyfen saknas.

**Kan jag använda typsnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**

Ja. Peka på dina egna typsnittsmappar eller läs in typsnitt från byte‑arrayer. Detta eliminerar alla beroenden på systemets typsnittskataloger i behållaravbilden.

**Hur är det med licensiering — kan jag bädda in vilket anpassat typsnitt som helst utan restriktioner?**

Du ansvarar för att följa typsnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid typsnittets EULA innan du distribuerar resultat.