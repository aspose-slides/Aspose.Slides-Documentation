---
title: Ukládat prezentace v Javě
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/java/save-presentation/
keywords:
- ukládat PowerPoint
- ukládat OpenDocument
- ukládat prezentaci
- ukládat snímek
- ukládat PPT
- ukládat PPTX
- ukládat ODP
- prezentace do souboru
- prezentace do proudu
- předdefinovaný typ zobrazení
- přísný formát Office Open XML
- režim Zip64
- obnovení miniatury
- průběh ukládání
- Java
- Aspose.Slides
description: "Ukládejte prezentace PowerPoint a OpenDocument do souborů nebo proudů v Javě s Aspose.Slides a nastavte výstup PPTX a hlášení průběhu."
---
## **Přehled**

Po vytvoření prezentace nebo [otevření existující](/slides/cs/java/open-presentation/), použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) k zápisu výsledku. Aspose.Slides pro Java může ukládat prezentaci do souboru nebo proudu ve formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce pokrývají standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Ukládání prezentací do souborů**

Pro uložení prezentace do souboru předáte výstupní cestu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Příkladem níže se vytvoří prezentace a uloží jako soubor PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Přidat nebo upravit obsah prezentace zde.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací v jejich původním formátu**

Pro příklady detekce souboru a proudu, chování nově vytvořených prezentací a rozdíl mezi zdrojovým a výstupním formátem se podívejte na [Determine the Original Presentation Format](/slides/cs/java/detect-presentation-source-format/).

V aplikaci pro dávkové zpracování nemusí být vstupní formát znám předem. Po načtení souboru přečtěte jeho původní formát pomocí metody [IPresentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSourceFormat--). Předejte získanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sourceformat/) metodě [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/#toSaveFormat-int-) pro získání odpovídající hodnoty [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/), a pak použijte [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) k zápisu upravené prezentace.

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideutil/#toSaveFormat-int-) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty pro ukládání prezentací. Mapuje pouze zdrojové formáty prezentací; není určen pro výběr exportních formátů jako PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné hodnoty [SourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sourceformat/) vede k [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Starší soubory PPT, PPS a POT používají stejný binární kontejner. Když je taková prezentace načtena z proudu bez přípony souboru, může být soubor PPS nebo POT identifikován jako PPT. Pokud je vyžadováno zachování těchto starých podtypů, uchovejte původní název souboru nebo metadata formátu samostatně a použijte je při výběru výstupního názvu souboru a formátu.

## **Ukládání prezentací do proudů**

Pro zápis prezentace bez použití konečné cesty k souboru předáte zapisovatelný proud a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Tento přístup je užitečný, když musí být výstup vrácen z webové služby, uložen v databázi nebo zpracován v paměti.

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

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Můžete určit, v jakém zobrazení PowerPoint při otevření uložené prezentace nejprve zobrazí. Před uložením použijte metodu [ViewProperties.setLastView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#setLastView-int-) s hodnotou [ViewType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewtype/).

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

## **Ukládání prezentací v přísném formátu Office Open XML**

Aby byl vytvořen soubor PPTX, který odpovídá přísnému profilu Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/) a použijte její metodu [setConformance](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/#setConformance-int-) s hodnotou [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). Poté předáte možnosti metodě [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

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

## **Ukládání prezentací ve formátu Office Open XML v režimu Zip64**

Standardní archiv ZIP omezuje komprimovanou i nekomprimovanou velikost každé položky, celkovou velikost archivu a počet položek. Protože je soubor PPTX archiv ZIP, může velmi velká prezentace tato omezení překročit. Rozšíření ZIP64 zvyšují platná omezení velikosti a počtu položek.

Přiřaďte metodě [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) kontrolu, zda Aspose.Slides zapisuje rozšíření ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#IfNecessary) používá ZIP64 pouze když prezentace překročí standardní limity ZIP. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Never) zakáže rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Always) vždy zapisuje rozšíření ZIP64.

Následující příklad vždy zapne rozšíření ZIP64 pro výstupní prezentaci:

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
Pokud je použito [Zip64Mode.Never](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Never), a prezentace se nevejde do standardních limitů ZIP, operace ukládání vyvolá [PptxException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Ukládání prezentací ve formátu Office Open XML s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání vůči velikosti souboru pomocí metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Třída [CompressionLevel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/) poskytuje následující hodnoty:

- [None](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#None) ukládá data bez komprese.
- [Level1](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level1) poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- [Level2](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level2) až [Level5](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level5) postupně upřednostňují menší výstup před rychlostí ukládání.
- [Level6](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level6) vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- [Level7](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level7) a [Level8](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level8) dále upřednostňují menší výstup před rychlostí ukládání.
- [Level9](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level9) poskytuje nejsilnější kompresi a vyžaduje nejvíce výpočetního času.

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

## **Ukládání prezentací bez obnovení miniatury**

Když se prezentace uloží jako PPTX, metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) řídí její miniaturu dokumentu:

- `true` regeneruje miniaturu během operace ukládání. Toto je výchozí hodnota.
- `false` zachová existující miniaturu. Pokud prezentace nemá miniaturu, Aspose.Slides ji nevyrobí.

Následující příklad uloží prezentaci bez obnovení její miniatury:

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
Vypnutí obnovení miniatury může zkrátit dobu potřebnou k uložení souboru PPTX.
{{% /alert %}}

## **Získávání aktualizací průběhu ukládání v procentech**

Pro sledování operace ukládání implementujte rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/) a předáte implementaci metodě [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides pak volá metodu [IProgressCallback.reporting](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/#reporting-double-) s hodnotami průběhu během exportu.

Následující příklad hlásí průběh exportu PDF do konzole:

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
Aspose nabízí zdarma [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) postavený na API Aspose.Slides. Ukládá vybrané snímky z prezentace jako samostatné soubory PPT nebo PPTX.
{{% /alert %}}

## **FAQ**

**Podporuje Aspose.Slides inkrementální nebo „rychlé uložení“?**

Ne. Každá operace ukládání zapíše kompletní výstupní soubor místo aktualizace pouze změněných částí.

**Může více vláken ukládat stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) [není thread‑safe](/slides/cs/java/multithreading/). Přistupujte a ukládejte každou instanci pouze z jednoho vlákna najednou.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při uložení prezentace?**

[Hyperlinky](/slides/cs/java/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě propojené soubory, takže uložená prezentace musí i nadále mít přístup k jejich umístěním.

**Mohu uložit metadata dokumentu, jako je autor, název, společnost a datum vytvoření?**

Ano. Před uložením nastavte příslušné [vlastnosti dokumentu](/slides/cs/java/presentation-properties/) a Aspose.Slides je zapíše do výstupního souboru.