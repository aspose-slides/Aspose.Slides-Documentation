---
title: Ukládání prezentací v JavaScriptu
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/nodejs-java/save-presentation/
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
- obnovení náhledu
- průběh ukládání
- Node.js
- JavaScript
- Aspose.Slides
description: "Uložte prezentace PowerPoint a OpenDocument do souborů nebo proudů v JavaScriptu pomocí Aspose.Slides a nakonfigurujte výstup PPTX a hlášení průběhu."
---
## **Přehled**

Po vytvoření prezentace nebo [otevření existující](/slides/cs/nodejs-java/open-presentation/), použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) k zápisu výsledku. Aspose.Slides pro Node.js prostřednictvím Java může uložit prezentaci do souboru nebo proudu ve formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce pokrývají standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Ukládání prezentací do souborů**

Pro uložení prezentace do souboru předáte cestu k výstupu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Následující příklad vytváří prezentaci a ukládá ji jako soubor PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Přidejte nebo upravte obsah prezentace zde.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací v jejich původním formátu**

Pro příklady detekce souboru a proudu, chování nově vytvořených prezentací a rozdíl mezi vstupním a výstupním formátem viz [Determine the Original Presentation Format](/slides/cs/nodejs-java/detect-presentation-source-format/).

V aplikaci pro dávkové zpracování může být vstupní formát neznámý dopředu. Po načtení souboru přečtěte jeho původní formát pomocí metody [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSourceFormat). Předejte získanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sourceformat/) metodě [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/#toSaveFormat), abyste získali odpovídající hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/), a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) k zápisu upravené prezentace.

Následující kompletní příklad zpracovává každý soubor ve vstupním adresáři, aktualizuje jeho název a uloží jej do výstupního adresáře ve formátu, z kterého byl načten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/#toSaveFormat) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty pro uložení prezentace. Mapuje pouze zdrojové formáty prezentací; není určen k výběru exportních formátů jako PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné hodnoty [SourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sourceformat/) vede k chybě.

Staré soubory PPT, PPS a POT používají stejný binární kontejner. Když je taková prezentace načtena z proudu bez přípony souboru, může být soubor PPS nebo POT identifikován jako PPT. Pokud je třeba zachovat tyto starší podtypy, uchovejte původní název souboru nebo metadata formátu samostatně a použijte je při výběru výstupního názvu souboru a formátu.

## **Ukládání prezentací do proudu**

Aby bylo možné zapsat prezentaci bez závislosti na konečné cestě k souboru, předáte zapisovatelný proud a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save). Tento přístup je užitečný, když musí být výstup vrácen z webové služby, uložen v databázi nebo zpracován v paměti.

Následující příklad ukládá novou prezentaci do souborového proudu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Můžete určit zobrazení, ve kterém PowerPoint otevře uloženou prezentaci při prvním spuštění. Před uložením použijte metodu [ViewProperties.setLastView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#setLastView) s hodnotou [ViewType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewtype/).

Následující příklad nastavuje zobrazení Slide Master jako počáteční zobrazení:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve striktním formátu Office Open XML**

Chcete-li vytvořit soubor PPTX, který odpovídá přísnému profilu Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/) a použijte její metodu [setConformance](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#setConformance) s hodnotou [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Poté předáte možnosti metodě [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací ve formátu Office Open XML v režimu Zip64**

Standardní archiv ZIP omezuje velikost komprimovaného i dekomprimovaného každého záznamu, celkovou velikost archivu a počet záznamů. Jelikož je soubor PPTX archiv ZIP, může velmi velká prezentace tyto limity překročit. Rozšíření ZIP64 zvyšují platné limity velikosti a počtu záznamů.

Použijte metodu [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) k řízení, zda Aspose.Slides zapisuje rozšíření ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#IfNecessary) používá ZIP64 jen když prezentace překročí standardní limity ZIP. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Never) zakazuje rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Always) vždy zapisuje rozšíření ZIP64.

Následující příklad vždy povolí rozšíření ZIP64 pro výstupní prezentaci:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Pokud je použito [Zip64Mode.Never](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zip64mode/#Never), a prezentace se nevejde do standardních limitů ZIP, operace uložení vyvolá výjimku [PptxException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Ukládání prezentací ve formátu Office Open XML s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání a velikost souboru pomocí metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). Třída [CompressionLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/) poskytuje následující hodnoty:

- [None](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#None) ukládá data bez komprese.
- [Level1](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level1) poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- [Level2](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level2) až [Level5](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level5) postupně upřednostňují menší výstup před rychlostí ukládání.
- [Level6](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level6) vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- [Level7](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level7) a [Level8](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level8) ještě více upřednostňují menší výstup před rychlostí ukládání.
- [Level9](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compressionlevel/#Level9) poskytuje nejsilnější kompresi a vyžaduje nejvíce času na zpracování.

Následující příklad ukládá prezentaci bez komprese:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Následující příklad používá maximální úroveň komprese:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací bez obnovení náhledu**

Při uložení prezentace jako PPTX metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) řídí její náhled dokumentu:

- `true` regeneruje náhled během operace uložení. Toto je výchozí hodnota.
- `false` zachová existující náhled. Pokud prezentace nemá náhled, Aspose.Slides jej nevytvoří.

Následující příklad ukládá prezentaci bez obnovení jejího náhledu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Vypnutí obnovení náhledu může snížit čas potřebný k uložení souboru PPTX.
{{% /alert %}}

## **Ukládání průběhu v procentech**

Aby bylo možné sledovat operaci ukládání, implementujte rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/) pomocí Java proxy a předávejte implementaci metodě [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides následně volá metodu [IProgressCallback.reporting](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/#reporting-double-) s hodnotami průběhu během exportu.

Následující příklad hlásí průběh exportu PDF do konzole:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose poskytuje zdarma [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) postavený na API Aspose.Slides. Ukládá vybrané snímky z prezentace jako samostatné soubory PPT nebo PPTX.
{{% /alert %}}

## **FAQ**

**Podporuje Aspose.Slides inkrementální nebo „rychlé ukládání“?**

Ne. Každá operace ukládání zapíše kompletní výstupní soubor místo aktualizace jen změněných částí.

**Může více vláken uložit stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) není [thread-safe](/slides/cs/nodejs-java/multithreading/). Přístup a ukládání každé instance by mělo probíhat pouze z jednoho vlákna najednou.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při uložení prezentace?**

[Hyperlinks](/slides/cs/nodejs-java/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě odkazované soubory, takže uložená prezentace musí i nadále mít přístup k jejich umístěním.

**Mohu uložit metadata dokumentu jako autor, název, společnost a datum vytvoření?**

Ano. Před uložením nastavte příslušné [vlastnosti dokumentu](/slides/cs/nodejs-java/presentation-properties/) a Aspose.Slides je zapíše do výstupního souboru.