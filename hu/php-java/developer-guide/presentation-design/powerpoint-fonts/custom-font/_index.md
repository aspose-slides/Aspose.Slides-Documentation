---
title: PowerPoint betűk testreszabása PHP-ben
linktitle: Egyedi betű
type: docs
weight: 20
url: /hu/php-java/custom-font/
keywords:
- betű
- egyedi betű
- külső betű
- betű betöltése
- betűk kezelése
- betűmappa
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Testreszabja a betűket a PowerPoint diákon az Aspose.Slides for PHP via Java segítségével, hogy prezentációi minden eszközön élesek és következetesek legyenek."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyedi betűkészletek használatát a prezentációkban anélkül, hogy azokat az operációs rendszerre telepítené. Betűkészleteket tölthet be egyedi mappákból, dokumentumszintű betűforrásokkal adhatja meg a prezentációhoz, vagy külső betűket tölthet be közvetlenül bináris adatokból.

A betöltött betűkészletek a prezentáció megjelenítésekor vagy exportálásakor kerülnek felhasználásra, például PDF, képek és egyéb támogatott formátumok esetén. Ez segít az egységes kimenet biztosításában a különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűmappákat, és hogyan törölheti a betűkészlet-gyorsítót külső betűk használata után.

Az egyedi betűkészletek regisztrálása a megjelenítéshez különálló a betűkészletek PPTX fájlba ágyazásától. Ha a betűtípust magában a prezentációban kell tárolni, használja kifejezetten a betűkészlet‑ágyazási funkciókat.

{{% alert color="primary" %}} 

Az Aspose Slides lehetővé teszi ezen betűkészletek betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódussal:

* TrueType (.ttf) és TrueType Collection (.ttc) betűkészletek. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.
* OpenType (.otf) betűkészletek. Lásd az [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.

{{% /alert %}}

## **Egyedi betűkészletek betöltése**

Az Aspose.Slides lehetővé teszi a prezentációban használt betűkészletek betöltését anélkül, hogy azokat a rendszerre telepítené. Ez az exportálási kimenetet érinti – például PDF, képek és egyéb támogatott formátumok – így a létrehozott dokumentumok környezetfüggetlenül egységesek maradnak. A betűkészletek egyedi könyvtárakból töltődnek be.

1. Adja meg a betűfájlokat tartalmazó egy vagy több mappát.
2. Hívja meg a statikus [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a mappákból való betöltéshez.
3. Töltse be és jelenítse meg/exportálja a prezentációt.
4. Hívja meg a [FontsLoader::clearCache](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#clearCache--) metódust a betűkészlet-gyorsító törléséhez.

Az alábbi kódrészlet bemutatja a betűkészlet betöltési folyamatát:

```php
// Definiálja az egyedi betűfájlokat tartalmazó mappákat.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Töltsön be egyedi betűkészleteket a megadott mappákból.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderelje/exportálja a prezentációt (pl. PDF, képek vagy más formátumok) a betöltött betűkészletekkel.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Törölje a betűkészlet gyorsítótárát a munka befejezése után.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Megjegyzés" %}}

A [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűk keresési útvonalaihoz, de nem módosítja a betűk inicializálási sorrendjét.
A betűk a következő sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűútvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyedi betűmappák lekérdezése**
Az Aspose.Slides a [getFontFolders](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#getFontFolders--) metódust kínálja, amely lehetővé teszi a betűmappák megtalálását. Ez a metódus a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűmappákat adja vissza.

Ez a PHP‑kód bemutatja, hogyan használja a [getFontFolders](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#getFontFolders--) metódust:

```php
# Ez a sor kiírja azokat a mappákat, ahol a betűfájlok keresése történik.
# Ezek a LoadExternalFonts metódussal és a rendszer betűmappáival hozzáadott mappák.
$fontFolders = FontsLoader::getFontFolders();
```

## **Egyedi betűkészletek megadása egy prezentációhoz**
Az Aspose.Slides a [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) metódust biztosítja, amely lehetővé teszi külső betűkészletek megadását a prezentációhoz.

Ez a PHP‑kód mutatja, hogyan használja a [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) metódust:

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
    # Munkavégzés a prezentációval
    # A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappákból és azok alkönyvtáraiból származó betűkészletek elérhetők a prezentáció számára
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Betűkészletek külső kezelése**

Az Aspose.Slides a [loadExternalFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust kínálja, amely lehetővé teszi külső betűkészletek betöltését bináris adatból.

Ez a PHP‑kód demonstrálja a bájt‑tömb alapú betűkészlet betöltési folyamatot:

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
        # külső betű betöltve a prezentáció élettartama alatt
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

**Hatással vannak az egyedi betűk a teljes exportálásra (PDF, PNG, SVG, HTML)?**

Igen. A kapcsolt betűkészleteket a renderelő minden exportformátumban használja.

**Ágyazódnak-e automatikusan az egyedi betűk a létrehozott PPTX‑be?**

Nem. A betűk regisztrálása a megjelenítéshez nem ugyanaz, mint a betűk PPTX‑be ágyazása. Ha a betűtípust a prezentáció fájljában kell tárolni, használja a kifejezett [ágyazási funkciókat](/slides/hu/php-java/embedded-font/).

**Ellenőrizhetem-e a visszaesés (fallback) viselkedését, ha egy egyedi betű hiányos karakterekkel rendelkezik?**

Igen. Konfigurálja a [betűcserét](/slides/hu/php-java/font-substitution/), a [helyettesítési szabályokat](/slides/hu/php-java/font-replacement/) és a [fallback készleteket](/slides/hu/php-java/fallback-font/), hogy pontosan meghatározza, melyik betűt használja, ha a kért karakter hiányzik.

**Használhatok‑e betűket Linux/Docker konténerekben anélkül, hogy rendszerszinten telepíteném őket?**

Igen. Hivatkozhat saját betűmappáira, vagy betöltheti a betűket bájt‑tömbökből. Ez eltávolítja a rendszer betűkönyvtárakra való függőséget a konténer‑képből.

**Mi a helyzet a licenceléssel – beágyazhatok‑e bármilyen egyedi betűt korlátozások nélkül?**

Ön felelős a betűk licencelési megfelelőségéért. A feltételek változóak; egyes licencek tiltják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betű EULA‑ját, mielőtt a kimeneteket terjesztené.