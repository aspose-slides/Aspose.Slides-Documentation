---
title: Prezentációk mentése Androidon
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/androidjava/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- prezentáció mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- prezentáció fájlba
- prezentáció streambe
- előre definiált nézet típusa
- Szigorú Office Open XML formátum
- Zip64 mód
- miniature frissítése
- mentési előrehaladás
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan lehet prezentációkat menteni Java-ban az Aspose.Slides for Android segítségével—exportálás PowerPoint vagy OpenDocument formátumba, miközben megmaradnak a elrendezések, betűtípusok és effektusok."
---
## **Áttekintés**

[Open Presentations on Android](/slides/hu/androidjava/open-presentation/) leírja, hogyan használható a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály egy prezentáció megnyitásához. Ez a cikk bemutatja, hogyan hozhatunk létre és menthetünk prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály tartalmazza a prezentáció tartalmát. Akár egy prezentációt hoz létre a semmiből, akár egy meglévőt módosít, a végén menteni kell. Az Aspose.Slides for Android segítségével **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a prezentáció mentésének különböző módjait.

## **Prezentációk mentése fájlokba**

Egy prezentációt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály `save` metódusának meghívásával menthet fájlba. Adja meg a fájl nevét és a mentési formátumot a metódusnak. Az alábbi példa bemutatja, hogyan ment egy prezentációt az Aspose.Slides segítségével.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Végezzen itt némi munkát...

    // Mentse a prezentációt egy fájlba.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése folyamatokba**

Prezentációt menthet folyamatba egy kimeneti stream átadásával a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály `save` metódusának. Egy prezentáció többféle stream típusba írható. Az alábbi példában új prezentációt hozunk létre és fájl streambe mentjük.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Mentse a prezentációt a streambe.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése előre definiált nézet típussal**

Aspose.Slides lehetővé teszi, hogy beállítsa a PowerPoint által a generált prezentáció megnyitásakor használt kezdő nézetet a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/) osztály segítségével. Használja a [setLastView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) metódust a [ViewType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewtype/) felsorolásból származó értékkel.

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

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációt a szigorú Office Open XML formátumban mentse. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/) osztályt, és állítsa be a conformance tulajdonságot mentéskor. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) értéket állítja be, akkor a kimeneti fájl a szigorú Office Open XML formátumban lesz mentve.

Az alábbi példa egy prezentációt hoz létre és ment a szigorú Office Open XML formátumban.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Mentse a prezentációt a szigorú Office Open XML formátumban.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Egy Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 byte) korlátot szab az egyes fájlok kitömörített méretére, a fájlok tömörített méretére és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájlt engedélyez. A ZIP64 formátum kiterjesztések ezeknek a korlátoknak a 2^64‑re való emelését teszik lehetővé.

Az [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) metódus lehetővé teszi, hogy a mentés során megadja, mikor használjon ZIP64 formátum kiegészítéseket Office Open XML fájlok esetén.

Ez a metódus a következő módokkal használható:

- **IfNecessary**‑ esetén a ZIP64 formátum kiegészítéseket csak akkor alkalmazza, ha a prezentáció meghaladja a fentebb leírt korlátokat. Ez az alapértelmezett mód.
- **Never**‑ esetén soha nem használja a ZIP64 formátum kiegészítéseket.
- **Always**‑ esetén mindig használja a ZIP64 formátum kiegészítéseket.

Az alábbi kód bemutatja, hogyan menthet egy prezentációt PPTX fájlként ZIP64 formátum kiegészítésekkel engedélyezve:

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
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#Never) metódussal ment, akkor egy [PptxException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxexception/) kivétel keletkezik, ha a prezentációt nem lehet ZIP32 formátumban menteni.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

Nagy prezentációk esetén a tömörítési szint beállításával egyensúlyt teremthet a fájlméret és a feldolgozási idő között. Az igényeitől függően választhat gyorsabb feldolgozást vagy kisebb kimeneti fájlokat.

Az Aspose.Slides biztosítja az [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) metódust, amely lehetővé teszi a Office Open XML formátumban történő mentéskor használandó tömörítési szint megadását.

A rendelkezésre álló tömörítési szintek:

- **None**: Nincs tömörítés. A fájlok változatlanul tárolódnak.
- **Level1**: A leggyorsabb tömörítés a legalacsonyabb tömörítési aránnyal.
- **Level2**: Gyorsabb tömörítés, enyhén jobb tömörítési arány, mint a **Level1**.
- **Level3**: Jobb tömörítés a **Level2**‑nél, közepes hatással a feldolgozási időre.
- **Level4**: Jobb tömörítés a **Level3**‑nál.
- **Level5**: Javított tömörítés a **Level4**‑nél, további feldolgozási idővel.
- **Level6**: Standard tömörítés, amely jó egyensúlyt kínál a feldolgozási sebesség és a fájlméret között. Ez a *alapértelmezett tömörítési szint*.
- **Level7**: Jobb tömörítés a **Level6**‑nél, lassabb feldolgozással.
- **Level8**: Jobb tömörítés a **Level7**‑nél.
- **Level9**: Maximum tömörítés. A legkisebb fájlméretet eredményezi, de a leghosszabb feldolgozási időt igényli.

Az alábbi példa bemutatja, hogyan menthet egy prezentációt PPTX fájlként *tömörítés nélkül*:

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

Az alábbi példa bemutatja, hogyan menthet egy prezentációt PPTX fájlként *maximum tömörítéssel*:

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

A [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) metódus szabályozza a miniatűr generálást a PPTX formátumba mentéskor:

- Ha `true` értékre van beállítva, a mentés során a miniatűr frissül. Ez az alapértelmezett.
- Ha `false` értékre van beállítva, a jelenlegi miniatűr megmarad. Ha a prezentációnak nincs miniatűre, akkor egy sem lesz generálva.

Az alábbi kódrészlet a prezentációt PPTX formátumba menti a miniatűr frissítése nélkül.

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
Ez a lehetőség segít csökkenteni a PPTX formátumba történő mentéshez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás frissítése százalékban**

Az [IProgressCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprogresscallback/) interfészt a [ISaveOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isaveoptions/) interfész és az absztrakt [SaveOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/) osztály `setProgressCallback` metódusa exponálja. Egy [IProgressCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprogresscallback/) implementáció hozzárendelésével a `setProgressCallback` használatával százalékos mentési előrehaladást kaphat.

Az alábbi kódrészletek bemutatják, hogyan használja az `IProgressCallback`-ot.

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Használja itt a folyamat százalékos értékét.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Az Aspose egy ingyenes PowerPoint Splitter alkalmazást fejlesztett ki (https://products.aspose.app/slides/hu/splitter) a saját API-ja használatával. Az alkalmazás lehetővé teszi, hogy egy prezentációt több fájlra osszon szét úgy, hogy a kiválasztott diák új PPTX vagy PPT fájlként legyenek mentve.
{{% /alert %}}

## **GYIK**

**Támogatja a "gyors mentést" (inkrementális mentés), amely csak a változásokat írja?**  
Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális "gyors mentés" nem támogatott.

**Biztonságos-e több szálról ugyanazt a Presentation példányt menteni?**  
Nem. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány nem szálbiztos; egyetlen szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal mentéskor?**  
A [Hyperlinks](/slides/hu/androidjava/manage-hyperlinks/) megmaradnak. A külsőleg linkelt fájlok (például relatív útvonalú videók) nem kerülnek automatikusan másolásra – biztosítsa, hogy a hivatkozott útvonalak továbbra is elérhetők legyenek.

**Beállítható / menthető a dokumentum metaadata (Szerző, Cím, Cég, Dátum)?**  
Igen. A szabványos [document properties](/slides/hu/androidjava/presentation-properties/) támogatott, és a mentéskor a fájlba kerülnek.