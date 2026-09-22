---
title: Az eredeti prezentáció formátumának meghatározása PHP-ben
linktitle: Forrás formátum
type: docs
weight: 35
url: /hu/php-java/detect-presentation-source-format/
keywords:
- forrásformátum
- prezentáció formátumának felismerése
- PowerPoint
- OpenDocument
- prezentáció
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Olvassa el egy betöltött prezentáció eredeti formátumát PHP-ben az Aspose.Slides for PHP via Java segítségével, hasonlítsa össze az észlelési API‑kat, és kezelje a fájlokat, adatfolyamokat és régi formátumokat."
---
## **Áttekintés**

Az előadás betöltése után hívja meg a [Presentation::getSourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSourceFormat) metódust, hogy meghatározza az eredeti formátumát. Használja, ha a későbbi feldolgozás a betöltött példány formátumától függ.

A forrásformátum különbözik a kimeneti fájlhoz kiválasztott [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) formátumtól. Egy másik formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

## **A forrásformátum beolvasása egy fájlból**

Ez a példa egy meglévő `sample.pptx` fájlt igényel. Betölti a fájlt, és a [Presentation::getSourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSourceFormat) használatával választja ki az alkalmazás feldolgozási szabályát, nem a fájlnév alapján. Módosítsa a bemeneti útvonalat más formátumok kipróbálásához. A példa kiírja a kiválasztott szabályt; cserélje le az üzeneteket saját alkalmazáslogikájára.

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

## **A támogatott értékek felismerése**

A [SourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sourceformat/) osztály egész számú állandókat definiál, amelyek megkülönböztetik a következő előadásformátumokat. Az alábbi kiterjesztések konvencionálisak, nem az eredeti fájlnév rekonstrukciója.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 prezentáció |
| `Pptx` | `.pptx` | Office Open XML prezentáció |
| `Pptm` | `.pptm` | Makróval bővített Office Open XML prezentáció |
| `Pps` | `.pps` | PowerPoint 97–2003 diavetítés |
| `Ppsx` | `.ppsx` | Office Open XML diavetítés |
| `Ppsm` | `.ppsm` | Makróval bővített Office Open XML diavetítés |
| `Pot` | `.pot` | PowerPoint 97–2003 sablon |
| `Potx` | `.potx` | Office Open XML sablon |
| `Potm` | `.potm` | Makróval bővített Office Open XML sablon |
| `Odp` | `.odp` | OpenDocument prezentáció |
| `Otp` | `.otp` | OpenDocument prezentációs sablon |
| `Fodp` | `.fodp` | Flat XML ODF prezentáció |
| `Xml` | `.xml` | PowerPoint XML prezentáció |

## **A forrásformátum beolvasása egy adatfolyamból**

Ez a példa egy meglévő `sample.pps` fájlt igényel. A bájtok memóriaprofilba olvasása olyan bemenetet szimulál, amely fájlnév nélkül érkezik, például adatbázisérték vagy feltöltött bájt tömb. A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) konstruktor csak a folyamot kapja.

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

A PPT, PPS és POT ugyanazt a bináris formátumot használja. Fájlútvonal alapján a kiterjesztés segíthet megkülönböztetni a diavetítést vagy a sablont. Fájlnév nélkül a régi PPS és POT tartalom `SourceFormat::Ppt`‑ként jelentkezhet; a fenti PPS példa a `SourceFormat::Ppt` egész számú értékét írja ki.

Ha az alkalmazásnak meg kell őriznie a különbséget, tartsa meg az eredeti fájlnevet vagy a részlet metaadatait külön. A kiterjesztés hasznos útmutató ezekhez a régi alcsaládokhoz, de nem lehet az egyetlen alap a tetszőleges előadástartalom azonosításához.

## **Az észlelés összehasonlítása betöltés előtt és után**

Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) és a [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationinfo/#getLoadFormat) metódusokat, ha egy fájlt kell megvizsgálnia a teljes előadásobjektum modell betöltése előtt. Használja a [Presentation::getSourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSourceFormat) metódust, ha a példány már létezik.

Ez a példa `sample.pptx`‑et igényel, és kiírja a `LoadFormat::Pptx` valamint a `SourceFormat::Pptx` egész számú értékeit. Éles környezetben válassza a feldolgozási szintnek megfelelő API‑t; egy már betöltött előadásnak nem kell második alkalommal ellenőrizni csak a forrásformátum lekéréséhez.

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

Az eredmények különböző osztályok állandóiból származnak: [LoadFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadformat/) és [SourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sourceformat/). Ne hasonlítsa össze a numerikus értékeket, és ne feltételezze, hogy minden formátum azonos észlelési eredményt ad. A PowerPoint XML betöltés előtt `LoadFormat::Unknown`‑ként, betöltés után pedig `SourceFormat::Xml`‑ként jelentkezhet.

## **A forrás- és kimeneti formátumok külön kezelése**

Ez a példa `sample.pptx`‑et igényel, és `converted.odp`‑t ír. Kiírja a `SourceFormat::Pptx` egész számú értékét a mentés előtt és után is. Az ODP kimenetből betöltött új példány csak `Odp`‑t jelent.

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

Az `new Presentation()`-nel az elejétől létrehozott előadás `SourceFormat::Pptx`‑t jelent. Nincs bemeneti fájlja: ez az újonnan létrehozott példány alapértelmezett értéke, nem annak bizonyítéka, hogy PPTX fájlt töltött be. Kövesse nyomon, hogy az alkalmazás létrehozta vagy betöltötte-e a példányt, ha a különbség számít.

## **Forrásformátum leképezése kiterjesztésre**

A következő példa `sample.pptx`‑et igényel. Minden jelenleg támogatott [SourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sourceformat/) értéket leképez egy konvencionális kiterjesztésre, a bemeneti fájlnév elemzése nélkül. A tartalék elkerüli, hogy nem felismert értékhez csendben kiterjesztést rendeljünk.

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

Ez a leképezés nem konvertál fájlt, és nem állítja helyre a folyam betöltése során elveszett régi PPS/POT alcsaládot. A tényleges mentéshez válasszon egy [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) értéket kifejezetten, vagy használja a [Save Presentations in Their Original Format](/slides/hu/php-java/save-presentation/#save-presentations-in-their-original-format) példában bemutatott konverziót.

## **Formátumok ellenőrzése mentés és újraolvasás révén**

Ez az önálló példa létrehoz egy előadást, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Minden kimenetet újból megnyit útvonalként és memóriaprofilon keresztül is. PPTX és ODP esetén mindkét út jelentése megegyezik a mentett formátummal. PPS esetén az útvonal szerinti betöltés `Pps`‑t jelent, míg a fájlnév nélküli azonos bájtok betöltése `Ppt`‑t ad.

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

Az alábbi táblázat összegzi a forrásformátum azonosítást az egyező kiterjesztésű előadásoknál. A nevek állandókat jelölnek; a PHP példák a numerikus értékeket írják ki:

| Mentett formátum | SourceFormat fájlúton | SourceFormat névtelen folyamról |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` megfelelően | Ugyanaz, mint fájlúton |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` megfelelően | Ugyanaz, mint fájlúton |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` megfelelően | Ugyanaz, mint fájlúton |
| ODP, OTP | `Odp`, `Otp` megfelelően | Ugyanaz, mint fájlúton |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

A PPS/POT tartalom névtelen folyamok esetén `Ppt`‑ként azonosítható. A táblázat a formátumazonosítást írja le, nem a konverzió során minden előadásjellemző megőrzését.

## **GYIK**

**Megváltoztatja-e az ODP‑ba mentés a PPTX‑ből betöltött előadás forrásformátumát?**

Nem. A meglévő példány továbbra is `Pptx`‑et jelent. Az ODP‑ból betöltött példány `Odp`‑t jelent.

**A folyam mindig meg tudja különböztetni a régi előadást, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot használja. Tartsa meg a fájlnevet vagy a részlet metaadatait külön, ha ez a megkülönböztetés szükséges.

**Melyik API‑t kell használni, ha az előadás már betöltött?**

Olvassa a [Presentation::getSourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSourceFormat) metódust. Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ellenőrzéshez betöltés előtt.