---
title: Bemutatók mentése PHP-ben
linktitle: Bemutató mentése
type: docs
weight: 80
url: /hu/php-java/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- bemutató mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- bemutató fájlba
- bemutató adatfolyamba
- előre definiált nézettípus
- Szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési folyamat
- PHP
- Aspose.Slides
description: "PowerPoint és OpenDocument bemutatókat menthet fájlokba vagy adatfolyamokba PHP-ben az Aspose.Slides segítségével, valamint konfigurálhatja a PPTX kimenetet és a folyamatjelentést."
---
## **Áttekintés**

Miután létrehoz egy bemutatót vagy [nyisson meg egy meglévőt](/slides/hu/php-java/open-presentation/), használja a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust az eredmény írásához. Az Aspose.Slides for PHP via Java képes a bemutatót fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és más formátumokban. Az alábbi szakaszok lefedik a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat.

## **Bemutatók mentése fájlokba**

A bemutató fájlba mentéséhez adja meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) értéket a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódusnak. A formátumérték határozza meg a fájl típusát, amelyet az Aspose.Slides létrehoz.

A következő példa bemutatót hoz létre, és PPTX fájlként menti el:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Itt adjon hozzá vagy módosítson bemutató tartalmat.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése eredeti formátumban**

Fájl- és adatfolyam-észlelési példákért, az újonnan létrehozott bemutatók viselkedéséért, valamint a forrás- és kimeneti formátumok közti különbségért lásd az [Az eredeti bemutatóformátum meghatározása](/slides/hu/php-java/detect-presentation-source-format/).

Kötegelt feldolgozó alkalmazásban a bemeneti formátum nem ismerhető előre. Egy fájl betöltése után olvassa ki az eredeti formátumát a [Presentation::getSourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSourceFormat) metódusból. Adja át a kapott [SourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sourceformat/) értéket a [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/#toSaveFormat) metódusnak, hogy megkapja a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) értéket, majd használja a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust a módosított bemutató írásához.

A következő teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és a betöltött formátumban menti egy kimeneti könyvtárba:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

Az [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/#toSaveFormat) leképezi a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és a PowerPoint XML formátumokat a megfelelő bemutató mentési formátumokra. Csak a bemutató forrásformátumokat térképezi le; nem arra szolgál, hogy export formátumokat, például PDF, HTML, TIFF vagy képek válasszon. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sourceformat/) érték átadása [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) kivételt eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris tárolót használják. Ha egy ilyen bemutatót egy kiterjesztés nélküli adatfolyamból töltenek be, egy PPS vagy POT fájlt ezért PPT‑ként azonosíthatnak. Ha ezeknek a régi alkategóriáknak a megőrzése szükséges, tartsa meg az eredeti fájlnevet vagy formátum metaadatát külön, és használja azt a kimeneti fájlnév és formátum kiválasztásakor.

## **Bemutatók mentése adatfolyamokba**

A bemutató írásához anélkül, hogy végső fájl útvonalra támaszkodna, adjon meg egy írható adatfolyamot és egy [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) értéket a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódusnak. Ez a megközelítés akkor hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisban tárolni vagy memóriában feldolgozni.

A következő példa egy új bemutatót ment fájl adatfolyamba:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése előre definiált nézettípussal**

Megadhatja azt a nézetet, amelyben a PowerPoint kezdetben megnyit egy mentett bemutatót. Használja a [ViewProperties::setLastView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/#setLastView) metódust egy [ViewType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewtype/) értékkel a mentés előtt.

A következő példa a Dia-mester nézetet állítja be kezdeti nézetként:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése a szigorú Office Open XML formátumban**

A PPTX fájl létrehozásához, amely megfelel az Office Open XML szigorú profiljának, hozzon létre egy [PptxOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/) példányt, és használja a [PptxOptions::setConformance](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setConformance) metódust a [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/php-java/aspose.slides/conformance/#Iso29500-2008-Strict) értékkel. Ezután adja át a beállításokat a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódusnak.

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

A szabványos ZIP archívum korlátozza minden bejegyzés tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel a PPTX fájl egy ZIP archívum, egy nagyon nagy bemutató túllépheti ezeket a korlátokat. A ZIP64 kiterjesztések emelik a vonatkozó méret- és bejegyzésszám‑korlátokat.

Használja a [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setZip64Mode) metódust annak szabályozására, hogy az Aspose.Slides ZIP64 kiterjesztéseket írjon‑e:

- [IfNecessary](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használ ZIP64‑et, ha a bemutató meghaladja a szabványos ZIP korlátokat. Ez a alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Never) letiltja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Always) mindig ír ZIP64 kiterjesztéseket.

A következő példa minden esetben engedélyezi a ZIP64 kiterjesztéseket a kimeneti bemutatóhoz:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Ha a [Zip64Mode::Never](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Never) használatos és a bemutató nem fér bele a szabványos ZIP korlátokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Bemutatók mentése Office Open XML formátumban tömörítési szintekkel**

A PPTX kimenethez a mentési sebesség és a fájlméret egyensúlyát a [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setCompressionLevel) metódus használatával állíthatja be. A [CompressionLevel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/) osztály a következő értékeket biztosítja:

- [None](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#None) adatokat tömörítés nélkül tárol.
- [Level1](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level1) a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- [Level2](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level2) a [Level5](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level5) fokozatosan a kisebb kimenetet részesíti előnyben a mentési sebességgel szemben.
- [Level6](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level6) egyensúlyt teremt a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- [Level7](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level7) és [Level8](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level8) még inkább a kisebb kimenetet részesítik előnyben a mentési sebességgel szemben.
- [Level9](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level9) a legerősebb tömörítést biztosítja, és a legtöbb feldolgozási időt igényli.

A következő példa bemutatót ment tömörítés nélkül:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

A következő példa a maximális tömörítési szintet használja:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése a bélyegkép frissítése nélkül**

Amikor egy bemutatót PPTX‑ként ment, a [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a dokumentum bélyegképét:

- `true` a mentés során újragenerálja a bélyegképet. Ez az alapértelmezett érték.
- `false` megőrzi a meglévő bélyegképet. Ha a bemutatónak nincs bélyegképe, az Aspose.Slides nem generál újat.

A következő példa a bemutatót a bélyegkép frissítése nélkül menti:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
A bélyegkép frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás frissítései százalékban**

A mentési művelet nyomon követéséhez biztosítson egy Java proxy‑t, amely megvalósítja az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt, és adja át a proxy‑t a [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setProgressCallback) metódusnak. Az Aspose.Slides ezután a [IProgressCallback::reporting](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/#reporting-double-) metódust hívja meg a folyamat értékekkel az export során.

A következő példa a PDF export előrehaladását a konzolra jelenti:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Az Aspose egy ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) szolgáltatást kínál, amely az Aspose.Slides API‑val készült. Kiválasztott diák mentését külön PPT vagy PPTX fájlokként végzi.
{{% /alert %}}

## **GYIK**

**Támogatja‑e az Aspose.Slides az inkrementális vagy „gyors mentést”?**

Nem. Minden mentési művelet egy teljes kimeneti fájlt ír, nem csak a módosult részeket.

**Több szál is mentheti ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példány [is not thread-safe](/slides/hu/php-java/multithreading/). Minden példányt csak egy szál használhat egyszerre.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal, amikor egy bemutatót mentek?**

[Hyperlinks](/slides/hu/php-java/manage-hyperlinks/) megmaradnak a bemutatóban. Az Aspose.Slides nem másolja a külsőleg hivatkozott fájlokat, ezért a mentett bemutatónak továbbra is hozzá kell férnie azok helyéhez.

**Menthetek‑e dokumentum metaadatokat, például szerzőt, címet, céget és létrehozási dátumot?**

Igen. Állítsa be a megfelelő [document properties](/slides/hu/php-java/presentation-properties/) értékeket a mentés előtt, és az Aspose.Slides a kimeneti fájlba írja őket.