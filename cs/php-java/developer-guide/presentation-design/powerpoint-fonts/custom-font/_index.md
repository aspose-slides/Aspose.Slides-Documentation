---
title: Přizpůsobení fontů PowerPoint v PHP
linktitle: Vlastní font
type: docs
weight: 20
url: /cs/php-java/custom-font/
keywords:
- font
- vlastní font
- externí font
- načíst font
- spravovat fonty
- složka fontů
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte fonty v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java, aby vaše prezentace byly ostré a konzistentní na všech zařízeních."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní fonty v prezentacích, aniž byste je instalovali do operačního systému. Fonty můžete načíst z vlastních složek, poskytnout fonty pro konkrétní prezentaci prostřednictvím zdrojů fontů na úrovni dokumentu, nebo načíst externí fonty přímo z binárních dat.

Načtené fonty se používají při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky fontů používané Aspose.Slides a jak vyprázdnit mezipaměť fontů po práci s externími fonty.

Registrace vlastních fontů pro vykreslování je oddělena od vkládání fontů do souboru PPTX. Pokud musí být font uložen přímo v prezentaci, použijte funkce vkládání fontů explicitně.

{{% alert color="primary" %}} 
Aspose Slides vám umožňuje načíst tyto fonty pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) fonty. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonty. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní fonty**

Aspose.Slides vám umožňuje načíst fonty použité v prezentaci, aniž byste je instalovali v systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Fonty jsou načítány z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory fontů.  
2. Volajte statickou metodu [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pro načtení fontů z těchto složek.  
3. Načtěte a vykreslete/exportujte prezentaci.  
4. Volajte [FontsLoader::clearCache](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#clearCache--) pro vyprázdnění mezipaměti fontů.

```php
// Definujte složky, které obsahují soubory vlastních fontů.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Načtěte vlastní fonty ze zadaných složek.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených fontů.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Vyprázdněte mezipaměť fontů po dokončení práce.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro hledání fontů, ale nemění pořadí inicializace fontů.
Fonty jsou inicializovány v tomto pořadí:

1. Výchozí cesta fontů operačního systému.  
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat složky vlastních fontů**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#getFontFolders--) , která vám umožní najít složky s fonty. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky s fonty.

```php
# Tento řádek vypisuje složky, kde se vyhledávají soubory fontů.
# Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s fonty.
$fontFolders = FontsLoader::getFontFolders();
```

## **Zadání vlastních fontů používaných v prezentaci**
Aspose.Slides poskytuje metodu [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) , která vám umožní zadat externí fonty, které budou použity v prezentaci.

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
    # Práce s prezentací
    # CustomFont1, CustomFont2 a fonty ze složek assets\fonts a global\fonts a jejich podadresářů jsou v prezentaci k dispozici
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Správa fontů externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), která vám umožní načíst externí fonty z binárních dat.

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
        # externí font načten během životnosti prezentace
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **Často kladené otázky**

**Ovlivňují vlastní fonty export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojené fonty jsou používány rendererem ve všech exportních formátech.

**Jsou vlastní fonty automaticky vloženy do výsledného PPTX?**

Ne. Registrace fontu pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby byl font součástí souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/php-java/embedded-font/).

**Mohu řídit chování náhradního fontu, když vlastní font postrádá některé glyfy?**

Ano. Nakonfigurujte [font substitution](/slides/cs/php-java/font-substitution/), [replacement rules](/slides/cs/php-java/font-replacement/), a [fallback sets](/slides/cs/php-java/fallback-font/) tak, aby přesně určovaly, který font se použije, pokud požadovaný glyf chybí.

**Mohu používat fonty v kontejnerech Linux/Docker, aniž bych je instaloval systémově?**

Ano. Odkazujte na své vlastní složky s fonty nebo načítejte fonty z pole bajtů. Tím se odstraní jakákoli závislost na systémových složkách fontů v obrazu kontejneru.

**Co se týče licencí – mohu vložit jakýkoli vlastní font bez omezení?**

Jste zodpovědní za dodržování licenčních podmínek fontů. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů přečtěte licenční smlouvu (EULA) fontu.