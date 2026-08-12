---
title: Bemutatók mentése PHP-ban
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
- bemutató folyamba
- előre definiált nézettípus
- Szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési előrehaladás
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan menthet bemutatókat az Aspose.Slides for PHP segítségével Java-on keresztül — exportáljon PowerPoint vagy OpenDocument formátumba, miközben megőrzi az elrendezéseket, betűtípusokat és hatásokat."
---
## **Áttekintés**

[Open Presentations in PHP](/slides/hu/php-java/open-presentation/) leírja, hogyan használható a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály egy bemutató megnyitásához. Ez a cikk bemutatja, hogyan hozhatók létre és menthetők a bemutatók. A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály a bemutató tartalmát tartalmazza. Akár egy új bemutatót hoz létre, akár egy meglévőt módosít, a végén menteni kell. Az Aspose.Slides for PHP-val **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a bemutató mentésének különböző módjait.

## **Bemutatók mentése fájlokba**

A bemutató mentése fájlba a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály `save` metódusának meghívásával történik. A metódusnak át kell adni a fájlnevet és a mentési formátumot. Az alábbi példa megmutatja, hogyan menthető egy bemutató az Aspose.Slides segítségével.

```php
// Hozzon létre egy Presentation osztály példányt, amely egy bemutató fájlt képvisel.
$presentation = new Presentation();
try {
    // Végezz némi munkát itt...

    // Mentse a bemutatót egy fájlba.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése folyamokba**

A bemutató mentése folyamba egy kimeneti folyam átadásával a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály `save` metódusának lehetséges. A bemutató számos folyam típusba írható. Az alábbi példában egy új bemutatót hozunk létre, és fájlfolyamba mentjük.

```php
// Hozzon létre egy Presentation osztály példányt, amely egy bemutató fájlt képvisel.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Mentse a bemutatót a folyamra.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése előre definiált nézettípussal**

Az Aspose.Slides lehetővé teszi az induló nézet beállítását, amelyet a PowerPoint használ, amikor a generált bemutató megnyílik, a [ViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/) osztályon keresztül. Használja a [setLastView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/#setLastView) metódust a [ViewType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewtype/) felsorolás egyik értékével.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi egy bemutató mentését a Strict Office Open XML formátumban. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/) osztályt, és állítsa be a megfelelőség (conformance) tulajdonságát mentéskor. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) értéket állítja be, a kimeneti fájl a Strict Office Open XML formátumban lesz mentve.

Az alábbi példa egy bemutatót hoz létre, és a Strict Office Open XML formátumban menti.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Hozzon létre egy Presentation osztály példányt, amely egy bemutató fájlt képvisel.
$presentation = new Presentation();
try {
    // Mentse a bemutatót a Szigorú Office Open XML formátumban.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

Egy Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a kitömörített fájlméret, a tömörített fájlméret és az archívum teljes mérete tekintetében, valamint legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátum kiterjesztések ezeknek a határoknak a 2^64‑re emelését teszik lehetővé.

A [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setZip64Mode) metódus lehetővé teszi, hogy a mentés során mikor használjon ZIP64 formátum kiterjesztéseket Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- [IfNecessary](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használja a ZIP64 kiterjesztéseket, ha a bemutató meghaladja a fent említett korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Never) soha nem használja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Always) mindig használja a ZIP64 kiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthető egy bemutató PPTX fájlként a ZIP64 formátum kiterjesztésekkel engedélyezve:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Amikor a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Never) módot használja, egy [PptxException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxexception/) kerül dobásra, ha a bemutató nem menthető ZIP32 formátumban.
{{% /alert %}}

## **Bemutatók mentése Office Open XML formátumban tömörítési szintekkel**

Nagy bemutatók esetén a tömörítési szint beállításával egyensúlyozhat a fájlméret és a feldolgozási idő között. Igényeitől függően előnyben részesítheti a gyorsabb feldolgozást vagy a kisebb kimeneti fájlokat.

Az Aspose.Slides a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setCompressionLevel) metódust biztosítja, amely lehetővé teszi a Office Open XML formátumban történő mentéskor alkalmazandó tömörítési szint megadását.

Az alábbi tömörítési szintek érhetők el:

- [**None**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#None): Nincs alkalmazott tömörítés. A fájlok változatlanul tárolódnak.
- [**Level1**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level1): A leggyorsabb tömörítés a legalacsonyabb tömörítési aránnyal.
- [**Level2**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level2): Gyorsabb tömörítés, valamivel jobb aránnyal, mint a **Level1**.
- [**Level3**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level3): Jobb tömörítés, mint a **Level2**, közepes hatással a feldolgozási időre.
- [**Level4**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level4): Jobb tömörítés, mint a **Level3**.
- [**Level5**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level5): Javított tömörítés a **Level4**-hez képest, további feldolgozási idővel.
- [**Level6**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level6): Standard tömörítés, amely jó egyensúlyt biztosít a feldolgozási sebesség és a fájlméret között. Ez az *alapértelmezett tömörítési szint*.
- [**Level7**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level7): Jobb tömörítés, mint a **Level6**, lassabb feldolgozással.
- [**Level8**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level8): Jobb tömörítés, mint a **Level7**.
- [**Level9**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compressionlevel/#Level9): Maximális tömörítés. A legkisebb fájlméretet eredményezi, de a leghosszabb feldolgozási időt igényli.

Az alábbi példa bemutatja, hogyan menthető egy bemutató PPTX fájlként *tömörítés nélkül*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Ez a példa azt mutatja be, hogyan menthető egy bemutató PPTX fájlként *maximális tömörítéssel*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Bemutatók mentése a bélyegkép frissítése nélkül**

A [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a bélyegkép létrehozását, amikor a bemutatót PPTX formátumba mentik:

- Ha `true` értékre van állítva, a bélyegkép mentéskor frissül. Ez az alapértelmezett.
- Ha `false` értékre van állítva, a jelenlegi bélyegkép megmarad. Ha a bemutatónak nincs bélyegképe, nem lesz generálva.

Az alábbi kódban a bemutató PPTX‑ként kerül mentésre a bélyegkép frissítése nélkül.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Ez a beállítás segít csökkenteni a PPTX formátumba történő mentéshez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás jelentése százalékban**

A mentési előrehaladás jelentését a [setProgressCallback](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setProgressCallback) metóduson keresztül állíthatja be a [SaveOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/) és alosztályai. Adjunk meg egy Java proxy‑t, amely implementálja az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt; az exportálás során a visszahívás időközönként százalékos frissítéseket kap.

Az alábbi kódrészletek mutatják, hogyan használható az `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Használja itt a folyamat százalékos értékét.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett ki saját API‑jával. Az alkalmazás lehetővé teszi, hogy egy bemutatót több fájlra bontson, a kiválasztott dia(k) új PPTX vagy PPT fájlként történő mentésével.
{{% /alert %}}

## **GYIK**

**Támogatja a "gyors mentés" (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Biztonságos-e több szálról menteni ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/php-java/multithreading/); csak egyetlen szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal mentéskor?**

A [Hyperlinks](/slides/hu/php-java/manage-hyperlinks/) megmaradnak. A külsőleg hivatkozott fájlok (például relatív útvonalakon keresztül hivatkozott videók) nem kerülnek automatikusan másolásra – biztosítsa, hogy a hivatkozott útvonalak elérhetők maradjanak.

**Beállítható/menthető a dokumentum metaadata (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/php-java/presentation-properties/) támogatott, és a mentéskor a fájlba kerülnek.