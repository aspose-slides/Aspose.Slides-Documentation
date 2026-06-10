---
title: Prezentációk mentése Java-ban
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/java/save-presentation/
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
- előre meghatározott nézet típus
- Szigorú Office Open XML formátum
- Zip64 mód
- miniatűr frissítése
- mentés előrehaladása
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan menthet prezentációkat Java-ban az Aspose.Slides használatával — exportáljon PowerPoint vagy OpenDocument formátumba, miközben megőrzi a elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Bemutatók megnyitása Java-ban](/slides/hu/java/open-presentation/) leírja, hogyan kell használni a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályt egy bemutató megnyitásához. Ez a cikk bemutatja, hogyan hozhatunk létre és menthetünk bemutatókat. A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály tartalmazza a bemutató tartalmát. Akár az elejétől hoz létre egy bemutatót, akár egy meglévőt módosít, a végén menteni szeretné. Az Aspose.Slides for Java segítségével **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a bemutató mentésének különböző módjait.

## **Bemutatók mentése fájlokba**

Mentse a bemutatót egy fájlba a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály `save` metódusának meghívásával. A metódusnak adja meg a fájl nevét és a mentési formátumot. Az alábbi példa bemutatja, hogyan menthet egy bemutatót az Aspose.Slides használatával.

```java
// Hozza létre a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Végezzen itt némi munkát...

    // Mentse a bemutatót egy fájlba.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése folyamokba**

Menthet egy bemutatót folyamba azzal, hogy egy kimeneti folyamatot ad át a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály `save` metódusának. A bemutató többféle folyamat típusba is írható. Az alábbi példában egy új bemutatót hozunk létre, és egy fájlfolyamra mentjük.

```java
// Hozza létre a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Mentse a bemutatót a folyamba.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése előre meghatározott nézet típussal**

Az Aspose.Slides lehetővé teszi, hogy beállítsa a kezdeti nézetet, amelyet a PowerPoint a generált bemutató megnyitásakor használ a [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/) osztályon keresztül. Használja a [setLastView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/#setLastView-int-) metódust a [ViewType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewtype/) felsorolás egy értékével.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy egy bemutatót a szigorú Office Open XML formátumban mentse. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/) osztályt, és mentéskor állítsa be a megfelelőség (conformance) tulajdonságát. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) értéket állítja be, a kimeneti fájl a szigorú Office Open XML formátumban lesz mentve.

Az alábbi példa egy bemutatót hoz létre, és a szigorú Office Open XML formátumban menti.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Hozza létre a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Mentse a bemutatót a szigorú Office Open XML formátumban.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab minden fájl tömörítetlen méretére, a tömörített méretére, valamint az archívum teljes méretére, és legfeljebb 65 535 (2^16‑1) fájl tárolására. A ZIP64 formátum kiegészítések ezeket a korlátokat 2^64-re emelik.

Az [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) metódus lehetővé teszi, hogy meghatározza, mikor használjon ZIP64 formátum kiegészítéseket Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- [IfNecessary](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#IfNecessary) csak akkor használja a ZIP64 formátum kiegészítéseket, ha a bemutató meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Never) soha nem használja a ZIP64 formátum kiegészítéseket.
- [Always](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Always) mindig használja a ZIP64 formátum kiegészítéseket.

Az alábbi kód bemutatja, hogyan menthet egy bemutatót PPTX formátumban a ZIP64 formátum kiegészítésekkel engedélyezve:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Never) beállítással ment, egy [PptxException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxexception/) kerül dobásra, ha a bemutató nem menthető ZIP32 formátumban.
{{% /alert %}}

## **Bemutatók mentése a miniatűr frissítése nélkül**

Az [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) metódus szabályozza a miniatűr generálását, amikor a bemutatót PPTX formátumba menti:

- Ha `true` értékre van állítva, a mentés során a miniatűr frissül. Ez az alapértelmezett.
- Ha `false` értékre van állítva, a jelenlegi miniatűr megmarad. Ha a bemutató nem rendelkezik miniatűrrel, nem kerül generálásra.

Az alábbi kódban a bemutató PPTX formátumba van mentve a miniatűr frissítése nélkül.

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Ez a beállítás segít csökkenteni a PPTX formátumba való mentéshez szükséges időt.
{{% /alert %}}

## **Mentési folyamat frissítései százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isaveoptions/) interfész által kitettségű `setProgressCallback` metódussal, valamint az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/) osztállyal használják. Egy [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) megvalósítást adjon át a `setProgressCallback`‑nak, hogy a mentési előrehaladást százalékban kapja meg.

Az alábbi kódrészletek bemutatják, hogyan használja az `IProgressCallback`.

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Használja itt a haladási százalékos értéket.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Az Aspose kifejlesztett egy [ingyenes PowerPoint Splitter alkalmazás](https://products.aspose.app/slides/hu/splitter) saját API-jával. Az alkalmazás lehetővé teszi, hogy egy bemutatót több fájlra bontson, a kiválasztott diák új PPTX vagy PPT fájlokként való mentésével.
{{% /alert %}}

## **GYIK**

**Támogatott a "gyors mentés" (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Biztonságos-e több szálról menteni ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példány [nem szálbiztonságos](/slides/hu/java/multithreading/); egy szálból kell menteni.

**Mi történik a [Hyperlinks](/slides/hu/java/manage-hyperlinks/) és a külsőleg linkelt fájlokkal mentéskor?**

A [Hyperlinks](/slides/hu/java/manage-hyperlinks/) megmaradnak. A külsőleg linkelt fájlok (például relatív útvonalú videók) nem másolódnak automatikusan – biztosítani kell, hogy a hivatkozott útvonalak továbbra is elérhetők legyenek.

**Beállíthatom/menthetem a dokumentum metaadatokat (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/java/presentation-properties/) támogatott és a mentéskor a fájlba íródnak.