---
title: Ukládání prezentací na Androidu
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/androidjava/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do proudu
- předdefinovaný typ zobrazení
- přísný formát Office Open XML
- režim Zip64
- obnovení miniatury
- postup ukládání
- Android
- Java
- Aspose.Slides
description: "Uložte prezentace PowerPoint a OpenDocument do souborů nebo proudů na Androidu pomocí Aspose.Slides a nakonfigurujte výstup PPTX a hlášení postupu."
---
## **Přehled**

Po vytvoření prezentace nebo [open an existing one](/slides/cs/androidjava/open-presentation/), použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) k zápisu výsledku. Aspose.Slides for Android via Java může uložit prezentaci do souboru nebo proudu ve formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce popisují standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Uložit prezentace do souborů**

Chcete‑li uložit prezentaci do souboru, předejte cestu k výstupu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Následující příklad vytvoří prezentaci a uloží ji jako soubor PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Přidejte nebo upravte obsah prezentace zde.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Uložit prezentace v jejich původním formátu**

Pro příklady detekce souboru a proudu, chování nově vytvořených prezentací a rozdíl mezi zdrojovým a výstupním formátem viz [Determine the Original Presentation Format](/slides/cs/androidjava/detect-presentation-source-format/).

V aplikaci zpracovávající dávky může být vstupní formát neznámý. Po načtení souboru přečtěte jeho původní formát pomocí metody [IPresentation.getSourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Výslednou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sourceformat/) předávejte metodě [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-), abyste získali odpovídající hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/), a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) k zápisu upravené prezentace.

Následující kompletní příklad zpracuje každý soubor ve vstupním adresáři, aktualizuje jeho název a uloží jej do výstupního adresáře ve formátu, ze kterého byl načten:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty ukládání prezentace. Mapuje pouze zdrojové formáty prezentace; není určeno k výběru exportních formátů, jako jsou PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné hodnoty [SourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sourceformat/) vede k výjimce [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Legacy soubory PPT, PPS a POT používají stejný binární kontejner. Když je taková prezentace načtena z proudu bez přípony souboru, může být soubor PPS nebo POT identifikován jako PPT. Pokud je nutné zachovat tyto starší podtypy, uchovejte původní název souboru nebo metadata formátu samostatně a použijte je při volbě výstupního názvu souboru a formátu.

## **Uložit prezentace do proudu**

Chcete‑li zapsat prezentaci bez použití konečné cesty k souboru, předejte zapisovatelný proud a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Tento přístup je užitečný, když je výstup vrácen z webové služby, uložen v databázi nebo zpracován v paměti.

Následující příklad uloží novou prezentaci do souborového proudu:

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

## **Uložit prezentace s předdefinovaným typem zobrazení**

Můžete určit, v jakém zobrazení PowerPoint otevře uloženou prezentaci. Před uložením použijte metodu [ViewProperties.setLastView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) s hodnotou [ViewType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewtype/).

Následující příklad nastaví zobrazení Slide Master jako počáteční zobrazení:

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

## **Uložit prezentace ve striktním formátu Office Open XML**

Chcete‑li vytvořit soubor PPTX, který splňuje přísný profil Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/) a použijte její metodu [setConformance](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) s hodnotou [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Poté předejte možnosti metodě [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

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

## **Uložit prezentace v formátu Office Open XML v režimu Zip64**

Standardní archiv ZIP omezuje komprimovanou i dekomprimovanou velikost každé položky, celkovou velikost archivu a počet položek. Protože je soubor PPTX archiv ZIP, velmi velká prezentace může tato omezení překročit. Rozšíření ZIP64 zvyšují příslušná omezení velikosti a počtu položek.

Použijte metodu [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) k určení, zda má Aspose.Slides zapisovat rozšíření ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#IfNecessary) používá ZIP64 jen v případě, že prezentace překročí standardní limity ZIP. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#Never) zakazuje rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#Always) vždy zapisuje rozšíření ZIP64.

Následující příklad vždy povolí rozšíření ZIP64 pro výstupní prezentaci:

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
Pokud je použito [Zip64Mode.Never](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#Never) a prezentace se nevejde do standardních limitů ZIP, operace uložení vyvolá výjimku [PptxException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Uložit prezentace v formátu Office Open XML s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání a velikost souboru pomocí metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Třída [CompressionLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/) poskytuje následující hodnoty:

- [None](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#None) ukládá data bez komprese.
- [Level1](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#Level1) poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- [Level2](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#Level2) až [Level5](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#Level5) postupně upřednostňují menší výstup před rychlostí ukládání.
- [Level6](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#Level6) vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- [Level7](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#Level7) a [Level8](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#Level8) dále upřednostňují menší výstup před rychlostí ukládání.
- [Level9](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compressionlevel/#Level9) poskytuje nejvyšší kompresi a vyžaduje nejvíce času na zpracování.

Následující příklad uloží prezentaci bez komprese:

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

Následující příklad použije maximální úroveň komprese:

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

## **Uložit prezentace bez obnovení náhledu**

Když je prezentace uložena jako PPTX, metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) řídí její náhled dokumentu:

- `true` znovu vytvoří náhled během operace uložení. Toto je výchozí hodnota.
- `false` zachová existující náhled. Pokud prezentace nemá náhled, Aspose.Slides jej nevytvoří.

Následující příklad uloží prezentaci bez obnovení jejího náhledu:

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
Zakázání obnovení náhledu může zkrátit dobu potřebnou k uložení souboru PPTX.
{{% /alert %}}

## **Ukládat průběžné informace o postupu v procentech**

Pro sledování operace uložení implementujte rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprogresscallback/) a předávejte jeho implementaci metodě [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides pak volá metodu [IProgressCallback.reporting](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) s hodnotami postupu během exportu.

Následující příklad hlásí postup exportu PDF do konzole:

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
Aspose nabízí zdarma [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) postavený na API Aspose.Slides. Umožňuje uložit vybrané snímky z prezentace jako samostatné soubory PPT nebo PPTX.
{{% /alert %}}

## **FAQ**

**Podporuje Aspose.Slides inkrementální nebo “rychlé uložení”?**

Ne. Každá operace ukládání zapíše kompletní výstupní soubor místo aktualizace pouze změněných částí.

**Mohou více vláken ukládat stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) není thread‑safe. Přístup a ukládání každé instance by mělo probíhat z jednoho vlákna najednou.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při uložení prezentace?**

[Hyperlinks](/slides/cs/androidjava/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě propojené soubory, takže uložená prezentace musí mít stále přístup k jejich umístěním.

**Mohu uložit metadata dokumentu, jako autor, název, společnost a datum vytvoření?**

Ano. Před uložením nastavte příslušné [document properties](/slides/cs/androidjava/presentation-properties/) a Aspose.Slides je zapíše do výstupního souboru.