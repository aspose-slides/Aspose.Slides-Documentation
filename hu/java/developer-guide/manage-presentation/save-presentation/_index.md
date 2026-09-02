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
- előre definiált nézet típus
- szigorú Office Open XML formátum
- Zip64 mód
- miniature frissítése
- mentési előrehaladás
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan menthet prezentációkat Java-ban az Aspose.Slides segítségével – exportáljon PowerPoint vagy OpenDocument formátumba, miközben megőrizze a elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Prezentációk megnyitása Java-ban](/slides/hu/java/open-presentation/) bemutatta, hogyan használható a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály a prezentáció megnyitásához. Ez a cikk bemutatja, hogyan hozhatók létre és menthetők a prezentációk. A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály tartalmazza a prezentáció tartalmát. Akár egy új prezentációt hozol létre a semmiből, akár egy meglévőt módosítasz, a végén el kell menteni. Az Aspose.Slides for Java segítségével **fájlba** vagy **folyamba** menthetsz. Ez a cikk bemutatja a prezentáció mentésének különböző módjait.

## **Prezentációk mentése fájlokba**

A prezentációt fájlba mentheted a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály `save` metódusának meghívásával. A metódusnak át kell adni a fájl nevet és a mentési formátumot. Az alábbi példa bemutatja, hogyan menthető egy prezentáció az Aspose.Slides segítségével.

```java
import com.aspose.slides.*;

// Hozzon létre egy Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Végezzen itt valamilyen munkát...

    // Mentse a prezentációt egy fájlba.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése folyamokba**

A prezentációt folyamba is mentheted úgy, hogy egy kimeneti stream-et adsz át a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály `save` metódusának. A prezentáció számos stream típusba írható. Az alábbi példában egy új prezentációt hozunk létre, és azt egy fájlfolyamba mentjük.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Hozzon létre egy Presentation osztályt, amely egy prezentációfájlt képvisel.
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

Az Aspose.Slides lehetővé teszi, hogy beállítsd a kezdeti nézetet, amelyet a PowerPoint a generált prezentáció megnyitásakor használ a [ViewProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/) osztályon keresztül. Használd a [setLastView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/#setLastView-int-) metódust a [ViewType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewtype/) felsorolás egy értékével.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy a prezentációt a szigorú Office Open XML formátumban mentsd. Használd a [PptxOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/) osztályt, és a mentéskor állítsd be a conformance tulajdonságát. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) értéket állítod be, a kimeneti fájl a szigorú Office Open XML formátumban kerül mentésre.

Az alábbi példa létrehoz egy prezentációt, és azt a szigorú Office Open XML formátumban menti.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Hozzon létre egy Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Mentse a prezentációt a szigorú Office Open XML formátumban.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab az egyes fájlok tömörítetlen méretére, a tömörített méretére és az archívum teljes méretére, továbbá legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátum kiterjesztések ezeket a korlátokat 2^64‑re emelik.

Az [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) metódus lehetővé teszi, hogy kiválaszd, mikor használj ZIP64 formátum kiterjesztéseket Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- [IfNecessary](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#IfNecessary) csak akkor használja a ZIP64 formátum kiterjesztéseket, ha a prezentáció meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Never) sosem használ ZIP64 formátum kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Always) mindig használja a ZIP64 formátum kiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthető egy prezentáció PPTX fájlként a ZIP64 formátum kiterjesztésekkel engedélyezve:

```java
import com.aspose.slides.*;

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
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Never) módot használod, akkor [PptxException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxexception/) kerül dobásra, ha a prezentációt nem lehet ZIP32 formátumban menteni.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

Nagy prezentációk esetén a tömörítési szintet úgy állíthatod be, hogy egyensúlyt teremts a fájlméret és a feldolgozási idő között. Az igényeidtől függően gyorsabb feldolgozást vagy kisebb kimeneti fájlokat választhatsz.

Az Aspose.Slides a [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) metódust kínálja, amely lehetővé teszi a mentéskor használt tömörítési szint megadását Office Open XML formátumban.

A következő tömörítési szintek érhetők el:

- [**None**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#None): Nem alkalmaz tömörítést. A fájlok változatlanul kerülnek tárolásra.
- [**Level1**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level1): A leggyorsabb tömörítés, legalacsonyabb tömörítési arány.
- [**Level2**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level2): Gyorsabb tömörítés, valamivel jobb tömörítési aránnyal, mint a **Level1**.
- [**Level3**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level3): Jobb tömörítést biztosít, mint a **Level2**, közepes hatással a feldolgozási időre.
- [**Level4**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level4): Jobb tömörítést nyújt, mint a **Level3**.
- [**Level5**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level5): Javított tömörítést nyújt a **Level4**-hez képest, plusz feldolgozási idővel.
- [**Level6**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level6): Standard tömörítés, amely jó egyensúlyt teremt a feldolgozási sebesség és a fájlméret között. Ez a *alapértelmezett tömörítési szint*.
- [**Level7**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level7): Jobb tömörítést biztosít, mint a **Level6**, lassabb feldolgozással.
- [**Level8**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level8): Jobb tömörítést nyújt, mint a **Level7**.
- [**Level9**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level9): Maximum tömörítés. A legkisebb fájlméretet eredményezi a leghosszabb feldolgozási idő árán.

Az alábbi példa bemutatja, hogyan menthető egy prezentáció PPTX fájlként *tömörítés nélkül*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Ez a példa mutatja, hogyan menthető egy prezentáció PPTX fájlként *maximum tömörítéssel*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése a miniatűr frissítése nélkül**

A [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) metódus vezérli a miniatűr generálását, amikor a prezentációt PPTX‑be mentjük:

- Ha `true`-ra van állítva, a mentés során frissül a miniatűr. Ez az alapértelmezett.
- Ha `false`-ra van állítva, a jelenlegi miniatűr megmarad. Ha a prezentációnak nincs miniatűre, akkor egy sem kerül létrehozásra.

Az alábbi kódban a prezentáció frissítés nélküli miniatűrrel mentődik PPTX‑be.

```java
import com.aspose.slides.*;

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
Ez a beállítás segít csökkenteni a PPTX formátumba történő mentéshez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás frissítése százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isaveoptions/) interfész és az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/) osztály által biztosított `setProgressCallback` metóduson keresztül használják. Egy [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) implementációt rendelj a `setProgressCallback`‑hez, hogy a mentés előrehaladását százalékos formában kapd.

Az alábbi kódrészlet bemutatja, hogyan használható az `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Itt használja a folyamat százalékos értékét.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett a saját API-jával. Az alkalmazás lehetővé teszi, hogy egy prezentációt több fájlra bonts a kijelölt diák új PPTX vagy PPT fájlokként való mentésével.
{{% /alert %}}

## **GYIK**

**Támogatja-e a „gyors mentés” (inkrementális mentés), amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Biztonságos-e több szálról menteni ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/java/multithreading/); egyetlen szálról kell menteni.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal mentéskor?**

[Hyperlinks](/slides/hu/java/manage-hyperlinks/) megmaradnak. A külsőleg hivatkozott fájlok (például relatív útvonalú videók) nem kerülnek automatikusan másolásra – győződj meg arról, hogy a hivatkozott útvonalak elérhetők maradnak.

**Beállíthatom/menthetem a dokumentum metaadatait (szerző, cím, cég, dátum)?**

Igen. A szabványos [document properties](/slides/hu/java/presentation-properties/) támogatottak, és a mentéskor a fájlba kerülnek írva.