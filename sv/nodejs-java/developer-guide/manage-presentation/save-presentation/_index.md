---
title: Spara presentationer i JavaScript
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/nodejs-java/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparande av framsteg
- Node.js
- JavaScript
- Aspose.Slides
description: "Spara PowerPoint- och OpenDocument-presentationer till filer eller strömmar i JavaScript med Aspose.Slides, samt konfigurera PPTX-utdata och rapportering av förlopp."
---
## **Översikt**

Efter att du har skapat en presentation eller [öppna en befintlig](/slides/sv/nodejs-java/open-presentation/), använd metoden [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) för att skriva resultatet. Aspose.Slides för Node.js via Java kan spara en presentation till en fil eller ström i PowerPoint, OpenDocument, PDF och andra format. Följande avsnitt täcker de standardlagringsoperationerna och de alternativ som finns för PPTX-utdata.

## **Spara presentationer till filer**

För att spara en presentation till en fil, skicka output‑sökvägen och ett [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/) värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save). Formatvärdet bestämmer vilken typ av fil som Aspose.Slides skapar.

Följande exempel skapar en presentation och sparar den som en PPTX‑fil:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Lägg till eller ändra presentationsinnehåll här.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i deras ursprungliga format**

För exempel på fil‑ och strömdetektion, beteendet för nyskapade presentationer och skillnaden mellan källa‑ och utdataformat, se [Bestäm det ursprungliga presentationsformatet](/slides/sv/nodejs-java/detect-presentation-source-format/).

I ett batch‑bearbetningsprogram kan indataformatet vara okänt i förväg. Efter att ha laddat en fil, läs dess ursprungliga format från metoden [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSourceFormat). Skicka det resulterande [SourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sourceformat/) värdet till [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/#toSaveFormat) för att få motsvarande [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/) värde, och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) för att skriva den modifierade presentationen.

Följande kompletta exempel bearbetar varje fil i en inmatningskatalog, uppdaterar dess titel och sparar den till en utdatamapp i det format den laddades från:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/#toSaveFormat) mappar PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP och PowerPoint XML till deras motsvarande presentationssparformat. Det mappar endast presentationskällformat; det är inte avsett att välja exportformat såsom PDF, HTML, TIFF eller bilder. Att skicka ett ej stödt eller ogiltigt [SourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sourceformat/) värde resulterar i ett fel.

Äldre PPT-, PPS- och POT-filer använder samma binära behållare. När en sådan presentation laddas från en ström utan filändelse kan en PPS- eller POT-fil därför identifieras som PPT. Om bevarande av dessa äldre subtyper krävs, behåll det ursprungliga filnamnet eller formatmetadata separat och använd dem när du väljer utdatafilnamn och format.

## **Spara presentationer till strömmar**

För att skriva en presentation utan att förlita dig på en slutgiltig filsökväg, skicka en skrivbar ström och ett [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/) värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save). Detta tillvägagångssätt är användbart när utdata måste returneras från en webbtjänst, lagras i en databas eller bearbetas i minnet.

Följande exempel sparar en ny presentation till en filström:

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

## **Spara presentationer med en fördefinierad vytyp**

Du kan ange den vy som PowerPoint initialt öppnar en sparad presentation i. Använd metoden [ViewProperties.setLastView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#setLastView) med ett [ViewType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewtype/) värde innan du sparar.

Följande exempel konfigurerar Slide Master‑vyn som den initiala vyn:

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

## **Spara presentationer i det strikt Office Open XML‑formatet**

För att skapa en PPTX‑fil som följer den strikta profilen av Office Open XML, skapa en [PptxOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/) instans och använd dess [setConformance](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#setConformance) metod med [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Skicka sedan alternativen till metoden [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save).

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

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

Ett standard‑ZIP‑arkiv begränsar den komprimerade och okomprimerade storleken för varje post, den totala arkivstorleken och antalet poster. Eftersom en PPTX‑fil är ett ZIP‑arkiv kan en mycket stor presentation överskrida dessa gränser. ZIP64‑tillägg höjer de tillämpliga storleks‑ och postgränserna.

Använd metoden [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) för att kontrollera om Aspose.Slides skriver ZIP64‑tillägg:

- [IfNecessary](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#IfNecessary) använder ZIP64 endast när presentationen överskrider standard‑ZIP‑gränserna. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Never) inaktiverar ZIP64‑tillägg.
- [Always](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Always) skriver alltid ZIP64‑tillägg.

Följande exempel aktiverar alltid ZIP64‑tillägg för presentationsutdata:

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
Om [Zip64Mode.Never](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zip64mode/#Never) används och presentationen inte får plats inom standard‑ZIP‑gränserna, kastar sparoperationen ett [PptxException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

För PPTX‑utdata kan du balansera sparhastighet mot filstorlek genom att använda metoden [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). Klassen [CompressionLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/) tillhandahåller följande värden:

- [None](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#None) lagrar data utan kompression.
- [Level1](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level1) ger den snabbaste komprimeringen och den största komprimerade utdata.
- [Level2](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level2) till [Level5](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level5) föredrar successivt mindre utdata framför sparhastighet.
- [Level6](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level6) balanserar sparhastighet och filstorlek. Detta är standardnivån.
- [Level7](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level7) och [Level8](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level8) föredrar ytterligare mindre utdata framför sparhastighet.
- [Level9](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compressionlevel/#Level9) ger den starkaste komprimeringen och kräver mest bearbetningstid.

Följande exempel sparar en presentation utan kompression:

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

Följande exempel använder den maximala komprimeringsnivån:

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

## **Spara presentationer utan att uppdatera miniatyren**

När en presentation sparas som PPTX styr metoden [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) dess dokumentminiatyr:

- `true` regenererar miniatyren under sparoperationen. Detta är standardvärdet.
- `false` behåller befintlig miniatyr. Om presentationen saknar miniatyr genererar inte Aspose.Slides någon.

Följande exempel sparar en presentation utan att uppdatera dess miniatyr:

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
Att inaktivera miniatyruppdatering kan minska den tid som krävs för att spara en PPTX‑fil.
{{% /alert %}}

## **Spara förloppsuppdateringar i procent**

För att övervaka en sparoperation, implementera gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/) med en Java‑proxy och skicka implementationen till metoden [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides kallar sedan metoden [IProgressCallback.reporting](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/#reporting-double-) med förloppsvärden under exporten.

Följande exempel rapporterar förloppet för en PDF‑export till konsolen:

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
Aspose erbjuder en gratis [PowerPoint Splitter](https://products.aspose.app/slides/sv/splitter) byggd med Aspose.Slides‑API. Den sparar valda bilder från en presentation som separata PPT‑ eller PPTX‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöder Aspose.Slides inkrementell eller “snabb spara”?**

Nej. Varje sparoperation skriver en komplett utdatafil snarare än att bara uppdatera de ändrade delarna.

**Kan flera trådar spara samma Presentation‑instans?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) instans [är inte trådsäker](/slides/sv/nodejs-java/multithreading/). Åtkomst och sparning av varje instans får endast ske från en tråd åt gången.

**Vad händer med hyperlänkar och externt länkade filer när jag sparar en presentation?**

[Hyperlänkar](/slides/sv/nodejs-java/manage-hyperlinks/) förblir i presentationen. Aspose.Slides kopierar inte externt länkade filer, så den sparade presentationen måste fortfarande kunna nå deras platser.

**Kan jag spara dokumentmetadata såsom författare, titel, företag och skapelsedatum?**

Ja. Ställ in lämpliga [dokumentegenskaper](/slides/sv/nodejs-java/presentation-properties/) innan du sparar, så skriver Aspose.Slides dem till utdatafilen.