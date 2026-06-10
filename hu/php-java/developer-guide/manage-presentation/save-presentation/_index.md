---
title: Prezentációk mentése PHP-ben
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/php-java/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- prezentáció mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- prezentáció fájlba
- prezentáció folyamba
- előre definiált nézet típusa
- szigorú Office Open XML formátum
- Zip64 mód
- miniatűr frissítése
- mentés előrehaladása
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan menthet prezentációkat az Aspose.Slides for PHP segítségével Java-n keresztül — exportálás PowerPoint vagy OpenDocument formátumba, miközben megőrzi az elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Open Presentations in PHP](/slides/hu/php-java/open-presentation/) bemutatta, hogyan kell használni a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályt egy prezentáció megnyitásához. Ez a cikk elmagyarázza, hogyan hozhatunk létre és menthetünk prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály tartalmazza a prezentáció tartalmát. Akár a semmiből hoz létre egy prezentációt, akár meglévőt módosít, a végén menteni szeretné. Az Aspose.Slides for PHP-vel **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a prezentáció mentésének különböző módjait.

## **Prezentációk mentése fájlokba**

Mentse a prezentációt fájlba a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály `save` metódusának meghívásával. A metódusnak adja át a fájlnév és a mentési formátum paramétereket. Az alábbi példa megmutatja, hogyan menthet egy prezentációt az Aspose.Slides segítségével.

```php
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Végezzen itt némi munkát...

    // Mentse a prezentációt egy fájlba.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Prezentációk mentése folyamokba**

A prezentációt egy folyamba mentheti, ha egy kimeneti folyamot ad át a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály `save` metódusának. A prezentáció számos folyam típusba írható. Az alábbi példában egy új prezentációt hozunk létre és egy fájlfolyamba mentjük.

```php
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Mentse a prezentációt a folyamra.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Prezentációk mentése előre meghatározott nézet típussal**

Az Aspose.Slides lehetővé teszi, hogy beállítsa a PowerPoint által a generált prezentáció megnyitásakor használt kezdeti nézetet a [ViewProperties](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/) osztály segítségével. Használja a [setLastView](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewproperties/#setLastView) metódust a [ViewType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/viewtype/) felsorolás egy értékével.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy a prezentációt a szigorú Office Open XML formátumban mentse. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/) osztályt, és állítsa be a `conformance` tulajdonságát mentéskor. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) értéket adja meg, a kimeneti fájl a szigorú Office Open XML formátumban lesz elmentve.

Az alábbi példa egy prezentációt hoz létre, és a szigorú Office Open XML formátumban menti.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
$presentation = new Presentation();
try {
    // Mentse a prezentációt a szigorú Office Open XML formátumban.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a bármely fájl kitömörített méretére, a bármely fájl tömörített méretére és a teljes archívum méretére, valamint legfeljebb 65 535 (2^16‑1) fájlt enged. A ZIP64 formátum kiterjesztések ezeket a korlátokat 2^64‑re emelik.

A [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setZip64Mode) metódus lehetővé teszi, hogy kiválassza, mikor használjon ZIP64 formátum kiterjesztéseket Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- [IfNecessary](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használja a ZIP64 formátum kiterjesztéseket, ha a prezentáció meghaladja a fent említett korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Never) soha nem használ ZIP64 formátum kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Always) mindig használ ZIP64 formátum kiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthet egy prezentációt PPTX formátumban ZIP64 formátum kiterjesztésekkel engedélyezve:

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

{{% alert title="MEGJEGYZÉS" color="warning" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/php-java/aspose.slides/zip64mode/#Never) opcióval ment, akkor egy [PptxException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxexception/) kerül dobásra, ha a prezentációt nem lehet ZIP32 formátumban menteni.
{{% /alert %}}

## **Prezentációk mentése a miniatűr frissítése nélkül**

A [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a miniatűr generálását, amikor egy prezentációt PPTX-be ment:

- Ha `true`-ra van állítva, a miniatűr a mentés során frissül. Ez az alapértelmezett.
- Ha `false`-ra van állítva, a jelenlegi miniatűr megmarad. Ha a prezentációnak nincs miniatűrje, akkor egy sem nem lesz generálva.

Az alábbi kódban a prezentációt PPTX-be mentjük a miniatűr frissítése nélkül.

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

{{% alert title="Információ" color="info" %}}
Ez a lehetőség segít csökkenteni a PPTX formátumba történő mentés időtartamát.
{{% /alert %}}

## **Mentés előrehaladásának százalékos frissítése**

A mentés előrehaladásának jelentését a [setProgressCallback](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setProgressCallback) metódussal állíthatja be a [SaveOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/) és annak származékaiban. Adjon meg egy Java proxy-t, amely implementálja az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt; az exportálás során a callback időszakos százalékos frissítéseket kap.

Az alábbi kódrészletek bemutatják, hogyan használja az `IProgressCallback`-et.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Használja itt a százalékos előrehaladási értéket.
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

{{% alert title="Információ" color="info" %}}
Az Aspose egy ingyenes PowerPoint Splitter alkalmazást fejlesztett ki (https://products.aspose.app/slides/hu/splitter) a saját API-jával. Az alkalmazás lehetővé teszi, hogy egy prezentációt több fájlra bontson, a kiválasztott diák új PPTX vagy PPT fájlokként történő mentésével.
{{% /alert %}}

## **FAQ**

**Támogatott a "gyors mentés" (inkrementális mentés), így csak a változások íródnak?**

Nincs. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Mentése szálbiztonságos ugyanazon Presentation példányt több szálról?**

Nincs. A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példány [nem szálbiztonságos](/slides/hu/php-java/multithreading/); csak egy szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal mentéskor?**

A [Hyperlinks](/slides/hu/php-java/manage-hyperlinks/) megmaradnak. A külsőleg linkelt fájlok (például relatív útvonalakból elérhető videók) nem kerülnek automatikusan másolásra – győződjön meg róla, hogy a hivatkozott útvonalak elérhetők maradnak.

**Beállíthatom/menthetem a dokumentum metaadatokat (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/php-java/presentation-properties/) támogatott, és mentéskor a fájlba kerülnek.