---
title: A PowerPoint betűtípusok testreszabása PHP-ben
linktitle: Egyéni betűtípus
type: docs
weight: 20
url: /hu/php-java/custom-font/
keywords:
- betűtípus
- egyéni betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Testreszabhatja a PowerPoint diák betűtípusait az Aspose.Slides for PHP via Java segítségével, hogy prezentációi minden eszközön élesek és konzisztens megjelenést biztosítsanak."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a prezentációkban a betűtípusok operációs rendszerre történő telepítése nélkül. Betűtípusokat tölthet be egyéni mappákból, megadhat betűtípusokat egy adott prezentációhoz a dokumentumszintű betűtípusforrásokon keresztül, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor a prezentációt renderelik vagy exportálják, például PDF-be, képekbe és más támogatott formátumokba. Ez segít a prezentációk kimenetét konzisztensen tartani különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizhetők az Aspose.Slides által használt betűtípus mappák, és hogyan törölhető a betűtípus gyorsítótár a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különálló a betűtípusok PPTX fájlba ágyazásától. Ha egy betűtípust a prezentáción belül kell tárolni, használja kifejezetten az ágyazási funkciókat.

Egy prezentáció témája különböző betűcsaládokra hivatkozhat az egyes írásrendszerekhez. Ezek a leképezések betűtípus neveket tárolnak, de nem telepítik vagy töltik be a betűtípus fájlokat. Lásd a [Script-Specific Theme Fonts](/slides/hu/php-java/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használd az alábbi betöltési beállításokat, hogy a hivatkozott betűtípusok elérhetők legyenek a konzisztens rendereléshez.

{{% alert color="info" title="Note" %}}

Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus használatával:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.

{{% /alert %}}

## **Betűtípusok egyéni betöltése**

Az Aspose.Slides lehetővé teszi, hogy betöltse a prezentációban használt betűtípusokat a rendszerre történő telepítés nélkül. Ez befolyásolja az export kimenetet – például PDF, képek és más támogatott formátumok – így a keletkező dokumentumok környezetek között konzisztensnek tűnnek. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípus fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a betűtípusok betöltéséhez az adott mappákból.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader::clearCache](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#clearCache--) metódust a betűtípus gyorsítótár törléséhez.

Az alábbi kódrészlet bemutatja a betűtípus betöltési folyamatát:

```php
// Határozza meg az egyéni betűtípus fájlokat tartalmazó mappákat.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderelje/exportálja a prezentációt (pl. PDF-be, képekbe vagy más formátumokra) a betöltött betűtípusokkal.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Törölje a betűtípus gyorsítótárát a munka befejezése után.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem módosítja a betűtípus inicializálási sorrendet.  
A betűtípusok a következő sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus útvonal.
2. A [FontsLoader](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus mappák lekérése**

Az Aspose.Slides biztosítja a [getFontFolders](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#getFontFolders--) metódust, amely lehetővé teszi a betűtípus mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűtípus mappákat.

Ez a PHP kód bemutatja, hogyan kell használni a [getFontFolders](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#getFontFolders--) metódust:

```php
# Ez a sor kiírja azokat a mappákat, ahol a betűtípus fájlok keresésre kerülnek.
# Ezek azok a mappák, amelyeket a LoadExternalFonts metódus és a rendszer betűtípus mappái adtak hozzá.
$fontFolders = FontsLoader::getFontFolders();
```

## **Egyéni betűtípusok megadása a prezentációhoz**

Az Aspose.Slides biztosítja a [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) metódust, amely lehetővé teszi, hogy megadja a prezentációval együtt használandó külső betűtípusokat.

Ez a PHP kód bemutatja, hogyan kell használni a [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) metódust:

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
    # Dolgozzon a prezentációval
    # A CustomFont1, CustomFont2, valamint az assets\fonts és a global\fonts mappákból (és alkönyvtáraikból) származó betűtípusok elérhetők a prezentáció számára
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides biztosítja a [loadExternalFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust, amely lehetővé teszi külső betűtípusok betöltését bináris adatokból.

Ez a PHP kód bemutatja a bájt tömböt használó betűtípus betöltési folyamatot:

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
        #       külső betűtípus betöltve a prezentáció működése során
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **GYIK**

### A egyéni betűtípusok befolyásolják-e az exportot minden formátumban (PDF, PNG, SVG, HTML)?

Igen. A kapcsolt betűtípusok a renderelő által minden export formátumban használatban vannak.

### A egyéni betűtípusok automatikusan beágyazódnak a létrejövő PPTX fájlba?

Nem. Egy betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX-be való beágyazása. Ha a betűtípust a prezentáció fájljában szeretné megtartani, akkor a kifejezett [embedding features](/slides/hu/php-java/embedded-font/) funkciót kell használni.

### Ellenőrizhetem-e a fallback viselkedést, ha egy egyéni betűtípus bizonyos glifeket hiányol?

Igen. Állítsa be a [font substitution](/slides/hu/php-java/font-substitution/), [replacement rules](/slides/hu/php-java/font-replacement/) és [fallback sets](/slides/hu/php-java/fallback-font/) lehetőségeket, hogy pontosan meghatározza, melyik betűtípust használja, ha a kért glif hiányzik.

### Használhatok-e betűtípusokat Linux/Docker konténerekben a rendszerre való telepítés nélkül?

Igen. Hivatkozhat a saját betűtípus mappáira vagy betöltheti a betűtípusokat bájt tömbökből. Ez megszünteti a függőséget a rendszer betűtípus könyvtáraktól a konténer képen belül.

### Mi a helyzet a licenceléssel—beágyazhatok-e bármilyen egyéni betűtípust korlátozások nélkül?

Ön felelős a betűtípus licencelésének betartásáért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimenetet terjesztené.