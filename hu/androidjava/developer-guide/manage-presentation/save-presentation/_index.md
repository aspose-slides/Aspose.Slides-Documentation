---
title: Bemutatók mentése Androidon
linktitle: Bemutató mentése
type: docs
weight: 80
url: /hu/androidjava/save-presentation/
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
- előre definiált nézet típusa
- szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési előrehaladás
- Android
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument bemutatókat menthet Androidon fájlokba vagy adatfolyamokba az Aspose.Slides segítségével, valamint konfigurálhatja a PPTX kimenetet és a folyamatjelentést."
---
## **Áttekintés**

Miután létrehoztál egy bemutatót vagy [megnyitsz egy meglévőt](/slides/hu/androidjava/open-presentation/), használd a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust az eredmény írásához. Az Aspose.Slides for Android via Java képes egy bemutatót fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és egyéb formátumokban. A következő szakaszok a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat tárgyalják.

## **Bemutatók mentése fájlokba**

A bemutató fájlba mentéséhez add meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódusnak. A formátum értéke határozza meg, milyen típusú fájlt hoz létre az Aspose.Slides.

Az alábbi példa létrehoz egy bemutatót és PPTX fájlként menti el:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Itt adja hozzá vagy módosítsa a bemutató tartalmát.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése eredeti formátumban**

A fájl- és adatfolyam-észlelési példákért, az újonnan létrehozott bemutatók viselkedéséért, valamint a forrás- és kimeneti formátumok megkülönböztetéséért lásd a [Az eredeti bemutató formátum meghatározása](/slides/hu/androidjava/detect-presentation-source-format/) oldalt.

Batch feldolgozó alkalmazásban a bemeneti formátum előre nem ismert lehet. Fájl betöltése után olvasd ki az eredeti formátumát az [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) metódussal. Add át a kapott [SourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sourceformat/) értéket a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) metódusnak, hogy megkapd a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) értéket, majd használd a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a módosított bemutató írásához.

Az alábbi teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és a betöltött formátumban egy kimeneti könyvtárba menti:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat a megfelelő bemutató mentési formátumokra térképezi. Csak a bemutató forrásformátumokat képezi le; nem arra szolgál, hogy exportálási formátumokat, például PDF, HTML, TIFF vagy képek válasszon. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sourceformat/) érték átadása [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException)-t eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris tárolót használják. Ha egy ilyen bemutatót kiterjesztés nélküli adatfolyamból töltünk be, egy PPS vagy POT fájl ezért PPT‑ként azonosítható. Ha ezeket az örökölt altípusokat meg kell őrizni, tartsd meg az eredeti fájlnevet vagy formátum metaadatot külön, és használd őket a kimeneti fájlnév és formátum kiválasztásakor.

## **Bemutatók mentése adatfolyamokba**

A bemutató írásához anélkül, hogy végleges fájlútra támaszkodnál, adj meg egy írható adatfolyamot és egy [SaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metódusnak. Ez a megközelítés akkor hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisban kell tárolni, vagy memóriában kell feldolgozni.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése előre definiált nézet típussal**

Megadhatod, hogy a PowerPoint milyen nézetben nyissa meg a mentett bemutatót. Használd a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) metódust egy [ViewType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewtype/) értékkel a mentés előtt.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése a szigorú Office Open XML formátumban**

A szigorú Office Open XML profilnak megfelelő PPTX fájl létrehozásához készíts egy [PptxOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/) példányt, és használd a [setConformance](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) metódust a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) értékkel. Ezután add át az opciókat a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódusnak.

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

A standard ZIP archívum korlátozza minden bejegyzés tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel a PPTX fájl ZIP archívum, egy nagyon nagy bemutató túllépheti ezeket a korlátokat. A ZIP64 kiterjesztések növelik a releváns méret- és számkorlátokat.

Használd a [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) metódust a ZIP64 kiterjesztések írásának vezérlésére:

- [IfNecessary](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#IfNecessary) csak akkor használ ZIP64-et, ha a bemutató meghaladja a standard ZIP korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#Never) letiltja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#Always) mindig írja a ZIP64 kiterjesztéseket.

Az alábbi példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti bemutatóhoz:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/zip64mode/#Never) módot használják, és a bemutató nem fér bele a standard ZIP korlátokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Bemutatók mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenet esetén a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) metódussal egyensúlyozhatsz a mentési sebesség és a fájlméret között. A [CompressionLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/) osztály ezeket az értékeket kínálja:

- [None](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#None) adatot tömörítés nélkül tárol.
- [Level1](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#Level1) a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- [Level2](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#Level2)‑től [Level5](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#Level5) fokozatosan előnyben részesítik a kisebb kimenetet a mentési sebességgel szemben.
- [Level6](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#Level6) egyensúlyt teremt a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- [Level7](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#Level7) és [Level8](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#Level8) tovább növelik a kisebb kimenet előnyben részesítését.
- [Level9](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/compressionlevel/#Level9) a legerősebb tömörítést biztosítja, de a legtöbb feldolgozási időt igényli.

Az alábbi példa tömörítés nélkül ment egy bemutatót:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Az alábbi példa a maximális tömörítési szintet használja:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése a bélyegkép frissítése nélkül**

Amikor egy bemutatót PPTX‑ként mentünk, a [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) metódus szabályozza a dokumentum bélyegképét:

- `true` újból generálja a bélyegképet a mentés során. Ez az alapértelmezett érték.
- `false` megőrzi a meglévő bélyegképet. Ha a bemutatónak nincs bélyegképe, az Aspose.Slides nem hoz létre újat.

Az alábbi példa a bélyegkép frissítése nélkül ment egy bemutatót:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A bélyegkép frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentés előrehaladásának frissítése százalékban**

A mentési művelet figyeléséhez valósítsd meg az [IProgressCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprogresscallback/) interfészt, és add át a megvalósítást az [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) metódusnak. Az Aspose.Slides ezután az [IProgressCallback.reporting](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) metódust hívja meg a haladás értékével az exportálás során.

Az alábbi példa a PDF exportálás előrehaladását írja ki a konzolra:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Az Aspose egy ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) alkalmazást is biztosít, amely az Aspose.Slides API‑val készült. Kiválasztott diák külön PPT vagy PPTX fájlokként menthetők.
{{% /alert %}}

## **GYIK**

**Támogatja-e az Aspose.Slides az inkrementális vagy „gyors mentés” funkciót?**

Nem. Minden mentési művelet egy teljes kimeneti fájlt ír, a változtatott részek csak frissítése helyett.

**Több szál mentheti ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány **nem szálbiztonságos** (/slides/hu/androidjava/multithreading/). Minden példányt egyszerre csak egy szál használhat.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal, amikor mentek egy bemutatót?**

A [Hiperhivatkozások](/slides/hu/androidjava/manage-hyperlinks/) a bemutatóban maradnak. Az Aspose.Slides nem másolja a külsőleg hivatkozott fájlokat, ezért a mentett bemutatónak továbbra is elérhetőnek kell maradnia ezekhez a helyekhez.

**Menthetek dokumentummetaadatokat, például szerzőt, címet, céget és létrehozási dátumot?**

Igen. Állítsd be a megfelelő [dokumentumtulajdonságokat](/slides/hu/androidjava/presentation-properties/) a mentés előtt, és az Aspose.Slides beírja őket a kimeneti fájlba.