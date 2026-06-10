---
title: "Prezentációk mentése Androidon"
linktitle: "Prezentáció mentése"
type: docs
weight: 80
url: /hu/androidjava/save-presentation/
keywords:
  - "PowerPoint mentése"
  - "OpenDocument mentése"
  - "prezentáció mentése"
  - "dia mentése"
  - "PPT mentése"
  - "PPTX mentése"
  - "ODP mentése"
  - "prezentáció fájlba"
  - "prezentáció folyamba"
  - "előre definiált nézet típus"
  - "Szigorú Office Open XML formátum"
  - "Zip64 mód"
  - "miniatűr frissítése"
  - "mentési előrehaladás"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Ismerje meg, hogyan menthet prezentációkat Java használatával az Aspose.Slides for Android segítségével – exportáljon PowerPoint vagy OpenDocument formátumba, miközben megőrzi az elrendezéseket, betűtípusokat és hatásokat."
---
## **Áttekintés**

Az [Open Presentations on Android](/slides/hu/androidjava/open-presentation/) leírja, hogyan kell használni a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályt egy prezentáció megnyitásához. Ez a cikk bemutatja, hogyan hozhatunk létre és menthetünk prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály tartalmazza a prezentáció tartalmát. Akár egy új prezentációt hozunk létre, akár egy meglévőt módosítunk, a befejezés után el kell menteni azt. Az Aspose.Slides for Android segítségével **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a prezentáció mentésének különféle módjait.

## **Prezentációk mentése fájlokba**

Mentse a prezentációt egy fájlba a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály `save` metódusának meghívásával. Adja meg a fájlnevet és a mentési formátumot a metódusnak. Az alábbi példa megmutatja, hogyan menthető egy prezentáció az Aspose.Slides segítségével.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Végezzen itt némi munkát...

    // Mentse a prezentációt egy fájlba.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése folyamokba**

Menthet egy prezentációt egy folyamra úgy, hogy egy kimeneti folyamot ad át a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály `save` metódusának. A prezentáció számos folyam típusba írható. Az alábbi példában egy új prezentációt hozunk létre, és egy fájlfolyamra mentjük.

```java
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Mentse a prezentációt a folyamra.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése előre definiált nézet típussal**

Aspose.Slides lehetővé teszi, hogy beállítsa a kezdeti nézetet, amelyet a PowerPoint a generált prezentáció megnyitásakor használ a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/) osztályon keresztül. Használja a [setLastView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) metódust a [ViewType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewtype/) felsorolás egy értékével.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése szigorú Office Open XML formátumban**

Aspose.Slides lehetővé teszi, hogy egy prezentációt a szigorú Office Open XML formátumban mentsen. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/) osztályt, és állítsa be a megfelelőség (conformance) tulajdonságát a mentéskor. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) értéket állítja be, a kimeneti fájl a szigorú Office Open XML formátumban lesz mentve.

Az alábbi példa létrehoz egy prezentációt, és a szigorú Office Open XML formátumban menti.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Mentse a prezentációt a Szigorú Office Open XML formátumban.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab bármely fájl tömörítetlen méretére, a tömörített méretre és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájlra korlátozza az archívumot. A ZIP64 formátum kiterjesztések ezeknek a korlátoknak a 2^64‑re emelését teszik lehetővé.

Az [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) metódus lehetővé teszi, hogy a ZIP64 formátum kiterjesztéseket akkor használja, amikor egy Office Open XML fájlt ment.

Ez a metódus a következő módokkal használható:

- [IfNecessary](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#IfNecessary) csak akkor használja a ZIP64 formátum kiterjesztéseket, ha a prezentáció meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#Never) soha nem használja a ZIP64 formátum kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#Always) mindig használja a ZIP64 formátum kiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthető egy prezentáció PPTX formátumban a ZIP64 kiterjesztésekkel engedélyezve:

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
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#Never) használatával ment, akkor egy [PptxException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxexception/) kerül kivételhez, ha a prezentáció nem menthető ZIP32 formátumban.
{{% /alert %}}

## **Prezentációk mentése a miniatűr frissítése nélkül**

A [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) metódus szabályozza a miniatűr generálását, amikor egy prezentációt PPTX formátumban ment:

- Ha `true`-ra van állítva, a miniatűr a mentés során frissül. Ez az alapértelmezett.
- Ha `false`-ra van állítva, a jelenlegi miniatűr megmarad. Ha a prezentációnak nincs miniatűrje, nem kerül generálásra.

Az alábbi kódban a prezentációt PPTX formátumban mentjük a miniatűr frissítése nélkül.

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
Ez az opció segít csökkenteni a PPTX formátumban történő prezentáció mentéséhez szükséges időt.
{{% /alert %}}

## **Mentés előrehaladásának frissítése százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isaveoptions/) interfész `setProgressCallback` metódusán keresztül, valamint az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/) osztályon keresztül használják. Egy [IProgressCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprogresscallback/) megvalósítás hozzárendelésével a `setProgressCallback` segítségével százalékos mentési előrehaladási értesítéseket kaphat.

Az alábbi kódrészletek bemutatják, hogyan kell használni az `IProgressCallback`-et.

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
        // Itt használja a százalékos előrehaladási értéket.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett ki saját API-jával. Az alkalmazás lehetővé teszi egy prezentáció több fájlra bontását a kiválasztott diák új PPTX vagy PPT fájlokként való mentésével.
{{% /alert %}}

## **GYIK**

**Támogatja a "gyors mentés" (inkrementális mentés) funkciót, amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális "gyors mentés" nem támogatott.

**Biztonságos-e több szálról menteni ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/androidjava/multithreading/); egyetlen szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg csatolt fájlokkal a mentéskor?**

A [Hyperlinks](/slides/hu/androidjava/manage-hyperlinks/) megmarad. A külsőleg hivatkozott fájlok (például relatív útvonalakkal hivatkozott videók) nem kerülnek automatikusan másolásra – győződjön meg arról, hogy a hivatkozott útvonalak elérhetők maradnak.

**Beállíthatom/menthetem a dokumentum metaadatait (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/androidjava/presentation-properties/) támogatott, és a mentéskor a fájlba lesznek írva.