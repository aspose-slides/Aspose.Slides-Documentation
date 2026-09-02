---
title: Přizpůsobení písem PowerPoint v PHP
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/php-java/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- spravovat písma
- složka písem
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint slidech pomocí Aspose.Slides pro PHP přes Java, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích bez jejich instalace do operačního systému. Můžete načítat písma z vlastních složek, poskytovat písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu nebo načítat externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky písem používané Aspose.Slides a jak vyprázdnit mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od jejich vložení do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte funkce vkládání písem výslovně.

Téma prezentace může odkazovat na různé rodiny písem pro jednotlivé písma. Tyto mapování ukládají názvy písem, ale neinstalují ani nenačítají soubory písem. Viz [Script-Specific Theme Fonts](/slides/cs/php-java/script-specific-font-mappings/) pro správu mapování a použijte níže uvedené možnosti načítání, aby odkazovaná písma byla k dispozici pro konzistentní vykreslování.

{{% alert color="info" title="Poznámka" %}}
Aspose Slides vám umožňuje načíst tato písma pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma použité v prezentaci bez jejich instalace v systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více složek obsahujících soubory písem.
2. Zavolejte statickou metodu [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader::clearCache](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#clearCache--) pro vyprázdnění mezipaměti písem.

Následující ukázka kódu demonstruje proces načítání písem:

```php
// Definujte složky, které obsahují vlastní soubory písem.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Načtěte vlastní písma ze zadaných složek.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Vyprázdněte mezipaměť písem po dokončení práce.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Poznámka" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené přes [FontsLoader](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Získat vlastní složky písem**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#getFontFolders--) pro vyhledání složek písem. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky písem.

Tento PHP kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Tento řádek vypisuje složky, kde se hledají soubory písem.
# Jedná se o složky přidané metodou LoadExternalFonts a systémové složky písem.
$fontFolders = FontsLoader::getFontFolders();
```

## **Zadání vlastních písem používaných v prezentaci**
Aspose.Slides poskytuje metodu [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) pro určení externích písem, která budou použita s prezentací.

Tento PHP kód ukazuje, jak použít metodu [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    # CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podadresářů jsou k dispozici pro prezentaci
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pro načtení externích písem z binárních dat.

Tento PHP kód demonstruje proces načítání písem z pole bajtů:

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
        # externí písmo načtené během životnosti prezentace
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

### Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?

Ano. Připojená písma jsou rendererem používána ve všech exportních formátech.

### Jsou vlastní písma automaticky vložena do výsledného PPTX?

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo součástí souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/php-java/embedded-font/).

### Mohu řídit chování náhradního písma, když vlastní písmo postrádá určité glyfy?

Ano. Nakonfigurujte [font substitution](/slides/cs/php-java/font-substitution/), [replacement rules](/slides/cs/php-java/font-replacement/) a [fallback sets](/slides/cs/php-java/fallback-font/), aby přesně určovalo, které písmo se použije, když požadovaný glyf chybí.

### Mohu použít písma v kontejnerech Linux/Docker bez jejich instalace na systémové úrovni?

Ano. Odkazujte na své vlastní složky písem nebo načítejte písma z bytových polí. Tím se odstraní jakákoliv závislost na systémových složkách písem v obrazu kontejneru.

### Jak to je s licencí—mohu vložit jakékoli vlastní písmo bez omezení?

Jste zodpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si přečtěte EULA písma před distribucí výstupů.