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
- prezentáció adatfolyamba
- előre meghatározott nézet típusa
- Szigorú Office Open XML formátum
- Zip64 mód
- miniatűr frissítése
- mentés előrehaladása
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk mentése fájlokba vagy adatfolyamokba Java-ban az Aspose.Slides használatával, valamint a PPTX kimenet és az előrehaladás jelentésének konfigurálása."
---
## **Áttekintés**

Miután létrehoz egy prezentációt vagy [nyiss meg egy meglévőt](/slides/hu/java/open-presentation/), használja a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust az eredmény írásához. Az Aspose.Slides for Java képes egy prezentációt fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és egyéb formátumokban. Az alábbi szakaszok bemutatják a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat.

## **Prezentációk mentése fájlokba**

Egy prezentáció fájlba mentéséhez adja meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódusnak. A formátum érték meghatározza, hogy milyen típusú fájlt hoz létre az Aspose.Slides.

A következő példa egy prezentációt hoz létre, és PPTX fájlként menti el:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Itt adja hozzá vagy módosítsa a prezentáció tartalmát.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése eredeti formátumban**

Az fájl- és adatfolyam‑detektálási példákért, az újonnan létrehozott prezentációk viselkedéséért, valamint a forrás‑ és kimeneti formátumok közti különbségért lásd a [Az eredeti prezentáció formátumának meghatározása](/slides/hu/java/detect-presentation-source-format/) témát.

Kötegelt feldolgozási alkalmazásban a bemeneti formátum előre nem ismert. Egy fájl betöltése után olvassa ki az eredeti formátumát az [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSourceFormat--) metódussal. A kapott [SourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sourceformat/) értéket adja át a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/#toSaveFormat-int-) metódusnak, hogy megkapja a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) értéket, majd a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal írja ki a módosított prezentációt.

A következő teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és a betöltéskor használt formátumban menti egy kimeneti könyvtárba:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/#toSaveFormat-int-) a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és a PowerPoint XML formátumokat a megfelelő prezentáció‑mentési formátumokra térképezi. Csak a prezentáció forrásformátumait térképezi; nem arra szolgál, hogy exportálási formátumokat, például PDF‑et, HTML‑t, TIFF‑et vagy képeket válasszon. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sourceformat/) érték átadása [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)-t eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris tárolót használják. Ha egy ilyen prezentációt kiterjesztés nélküli adatfolyamból tölt be, a PPS vagy POT fájl ezért PPT‑ként azonosítható. Ha meg kell őrizni ezeket a régi altípusokat, tartsa meg az eredeti fájlnevet vagy a formátum‑metaadatot külön, és használja fel a kimeneti fájlnév és formátum kiválasztásakor.

## **Prezentációk mentése adatfolyamokba**

Egy prezentáció írásához anélkül, hogy végleges fájlútra támaszkodna, adjon meg egy írható adatfolyamot és egy [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metódusnak. Ez a megközelítés hasznos, ha a kimenetet webszolgáltatásból kell visszaadni, adatbázisban tárolni vagy memóriában feldolgozni.

A következő példa egy új prezentációt fájl‑adatfolyamba ment:

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

## **Prezentációk mentése előre meghatározott nézet típussal**

Megadhatja azt a nézetet, amelyben a PowerPoint kezdetben megnyit egy mentett prezentációt. Használja a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewproperties/#setLastView-int-) metódust egy [ViewType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/viewtype/) értékkel a mentés előtt.

A következő példa a Dia‑mester nézetet állítja be kezdeti nézetként:

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

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Egy PPTX fájl létrehozásához, amely megfelel az Office Open XML szigorú profiljának, hozzon létre egy [PptxOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/) példányt, és hívja meg a [setConformance](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/#setConformance-int-) metódust a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) értékkel. Ezután adja át a beállításokat a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódusnak.

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

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Egy szabványos ZIP archívum korlátozza az egyes bejegyzések tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy prezentáció túlcsordulhat ezeken a korlátokon. A ZIP64 kiterjesztések megemelik a vonatkozó méret‑ és bejegyzésszám‑korlátokat.

Használja a [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) metódust annak vezérlésére, hogy az Aspose.Slides ZIP64 kiterjesztéseket írjon‑e:

- [IfNecessary](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#IfNecessary) csak akkor használ ZIP64‑et, ha a prezentáció meghaladja a szabványos ZIP‑korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Never) letiltja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Always) mindig ír ZIP64 kiterjesztéseket.

A következő példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti prezentációhoz:

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

{{% alert color="warning" title="Figyelmeztetés" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/java/com.aspose.slides/zip64mode/#Never) módot használják, és a prezentáció nem fér bele a szabványos ZIP‑korlátokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenet esetén a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) metódus használatával egyensúlyozhat a mentés sebessége és a fájlméret között. A [CompressionLevel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/) osztály a következő értékeket biztosítja:

- [None](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#None) adatot tömörítés nélkül tárol.
- [Level1](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level1) a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- [Level2](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level2)‑től [Level5](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level5) fokozatosan a kisebb kimenetet részesítik előnyben a mentés sebessége rovására.
- [Level6](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level6) az mentési sebesség és a fájlméret egyensúlyát biztosítja. Ez az alapértelmezett szint.
- [Level7](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level7) és [Level8](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level8) tovább részesítik előnyben a kisebb kimenetet a sebesség rovására.
- [Level9](https://reference.aspose.com/slides/hu/java/com.aspose.slides/compressionlevel/#Level9) a legerősebb tömörítést biztosítja, de a legtöbb feldolgozási időt igényli.

A következő példa tömörítés nélkül ment egy prezentációt:

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

A következő példa a maximális tömörítési szintet használja:

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

## **Prezentációk mentése a miniatűr frissítése nélkül**

Amikor egy prezentációt PPTX‑ként mentünk, a [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) metódus szabályozza a dokumentum‑miniatűrt:

- `true` újragenerálja a miniatűrt a mentés során. Ez az alapértelmezett érték.
- `false` megőrzi a meglévő miniatűrt. Ha a prezentációnak nincs miniatűre, az Aspose.Slides nem hoz létre újat.

A következő példa a miniatűr frissítése nélkül ment egy prezentációt:

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

{{% alert color="info" title="Megjegyzés" %}}
A miniatűr frissítésének letiltása csökkentheti egy PPTX‑fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentési folyamat frissítéseinek megjelenítése százalékban**

A mentés felügyeletéhez valósítsa meg az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt, és adja át a megvalósítást az [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) metódusnak. Az Aspose.Slides ekkor a [IProgressCallback.reporting](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/#reporting-double-) metódust hívja meg a folyamat értékeivel az exportálás során.

A következő példa egy PDF‑exportálás előrehaladását írja ki a konzolra:

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

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose egy ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) eszközt biztosít, amely az Aspose.Slides API‑val készült. Kiválasztott diákot külön PPT vagy PPTX fájlokként ment.
{{% /alert %}}

## **GYIK**

**Támogatja-e az Aspose.Slides az inkrementális vagy „gyors mentést”?**

Nem. Minden mentési művelet egy teljes kimeneti fájlt ír, nem csak a módosult részeket.

**Több szál is mentheti-e ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/java/multithreading/). Minden példányt csak egy szálról lehet elérni és menteni egyszerre.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal, amikor mentek egy prezentációt?**

A [Hyperlinks](/slides/hu/java/manage-hyperlinks/) a prezentációban marad. Az Aspose.Slides nem másolja a külsőleg hivatkozott fájlokat, így a mentett prezentációnak továbbra is el kell tudnia érni azok helyét.

**Menthetek-e dokumentummetaadatokat, például szerzőt, címet, céget és létrehozási dátumot?**

Igen. Állítsa be a megfelelő [dokumentumtulajdonságokat](/slides/hu/java/presentation-properties/) a mentés előtt, és az Aspose.Slides azokat a kimeneti fájlba írja.