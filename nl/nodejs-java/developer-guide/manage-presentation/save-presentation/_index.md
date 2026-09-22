---
title: Presentaties opslaan in JavaScript
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/nodejs-java/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- vooraf gedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang bij opslaan
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint- en OpenDocument‑presentaties opslaan naar bestanden of streams in JavaScript met Aspose.Slides, en de PPTX‑output en voortgangsrapportage configureren."
---
## **Overzicht**

Nadat u een presentatie heeft gemaakt of [een bestaande openen](/slides/nl/nodejs-java/open-presentation/), gebruikt u de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) methode om het resultaat te schrijven. Aspose.Slides for Node.js via Java kan een presentatie opslaan naar een bestand of stream in PowerPoint, OpenDocument, PDF en andere formaten. De volgende secties behandelen de standaard opslaan‑bewerkingen en de opties die beschikbaar zijn voor PPTX‑output.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geeft u het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) methode. De formatwaarde bepaalt het type bestand dat Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie en slaat deze op als een PPTX‑bestand:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Voeg presentatiedata toe of wijzig de inhoud hier.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

Voor voorbeelden van bestand‑ en streamdetectie, het gedrag van nieuw aangemaakte presentaties, en het onderscheid tussen bron‑ en uitvoerformaten, zie [Bepaal het oorspronkelijke presentatie‑formaat](/slides/nl/nodejs-java/detect-presentation-source-format/).

In een batch‑verwerkingsapplicatie is het invoerformaat mogelijk niet van tevoren bekend. Na het laden van een bestand, leest u het oorspronkelijke formaat via de [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSourceFormat) methode. Geef de verkregen [SourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sourceformat/) waarde door aan [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/#toSaveFormat) om de bijbehorende [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/) waarde te verkrijgen, en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) om de gewijzigde presentatie te schrijven.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij, en slaat het op in een uitvoermap in het formaat waarin het werd geladen:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/#toSaveFormat) zet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint‑XML om naar hun overeenkomstige presentatie‑opslaan‑formaten. Het zet alleen presentaties bronformaten om; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sourceformat/) waarde leidt tot een fout.

Legacy‑PPT, PPS en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie wordt geladen uit een stream zonder bestandsextensie, kan een PPS‑ of POT‑bestand daardoor als PPT worden geïdentificeerd. Als het behouden van deze legacy‑subtypes vereist is, bewaar dan de oorspronkelijke bestandsnaam of format‑metadata apart en gebruik deze bij het kiezen van de uitvoer‑bestandsnaam en -formaat.

## **Presentaties opslaan naar streams**

Om een presentatie te schrijven zonder te vertrouwen op een definitief bestandspad, geeft u een schrijfbare stream en een [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) methode. Deze aanpak is handig wanneer de uitvoer moet worden geretourneerd vanuit een webservice, opgeslagen in een database, of in het geheugen moet worden verwerkt.

Het volgende voorbeeld slaat een nieuwe presentatie op naar een bestands‑stream:

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

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

U kunt de weergave specificeren waarin PowerPoint een opgeslagen presentatie aanvankelijk opent. Gebruik de [ViewProperties.setLastView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#setLastView) methode met een [ViewType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewtype/) waarde vóór het opslaan.

Het volgende voorbeeld stelt Slide Master‑weergave in als de initiële weergave:

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

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Om een PPTX‑bestand te maken dat voldoet aan het Strict‑profiel van Office Open XML, maakt u een [PptxOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/) instantie en gebruikt u de [setConformance](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#setConformance) methode met [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Geef vervolgens de opties door aan de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) methode.

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

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een standaard ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elk item, de totale archiefgrootte en het aantal items. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie die limieten overschrijden. ZIP64‑extensies verhogen de toepasselijke grootte‑ en item‑aantallimieten.

- [IfNecessary](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Never) schakelt ZIP64‑extensies uit.
- [Always](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Always) schrijft altijd ZIP64‑extensies.

Het volgende voorbeeld schakelt ZIP64‑extensies altijd in voor de uitvoerpresentatie:

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

{{% alert color="warning" title="Waarschuwing" %}}
Als [Zip64Mode.Never](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Never) wordt gebruikt en de presentatie niet binnen de standaard ZIP‑limieten past, werpt de opslaan‑bewerking een [PptxException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Voor PPTX‑output kunt u de opslagsnelheid afwegen tegen de bestandsgrootte door de [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) methode te gebruiken. De [CompressionLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/) klasse biedt deze waarden:

- [None](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#None) slaat gegevens op zonder compressie.
- [Level1](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level1) biedt de snelste compressie en de grootste gecomprimeerde uitvoer.
- [Level2](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level2) geeft geleidelijk de voorkeur aan een kleinere uitvoer boven opslag‑snelheid.
- [Level3](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level3) geeft geleidelijk de voorkeur aan een kleinere uitvoer boven opslag‑snelheid.
- [Level4](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level4) geeft geleidelijk de voorkeur aan een kleinere uitvoer boven opslag‑snelheid.
- [Level5](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level5) geeft geleidelijk de voorkeur aan een kleinere uitvoer boven opslag‑snelheid.
- [Level6](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level6) balanceert opslagsnelheid en bestandsgrootte. Dit is het standaardniveau.
- [Level7](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level7) en [Level8](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level8) geven nog meer de voorkeur aan een kleinere uitvoer boven opslag‑snelheid.
- [Level9](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level9) biedt de sterkste compressie en vereist de meeste verwerkingstijd.

Het volgende voorbeeld slaat een presentatie op zonder compressie:

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

Het volgende voorbeeld gebruikt het maximale compressieniveau:

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

## **Presentaties opslaan zonder miniatuur te vernieuwen**

Wanneer een presentatie wordt opgeslagen als PPTX, regelt de [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) methode de document‑miniatuur:

- `true` regenereert de miniatuur tijdens de opslaan‑bewerking. Dit is de standaardwaarde.
- `false` behoudt de bestaande miniatuur. Als de presentatie geen miniatuur heeft, genereert Aspose.Slides er geen.

Het volgende voorbeeld slaat een presentatie op zonder de miniatuur te vernieuwen:

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

{{% alert color="info" title="Opmerking" %}}
Het uitschakelen van het vernieuwen van de miniatuur kan de tijd die nodig is om een PPTX‑bestand op te slaan verkorten.
{{% /alert %}}

## **Voortgangsupdates bij opslaan in percentage**

Om een opslaan‑bewerking te monitoren, implementeert u de [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/) interface met een Java‑proxy en geeft u de implementatie door aan de [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) methode. Aspose.Slides roept vervolgens de [IProgressCallback.reporting](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/#reporting-double-) methode aan met voortgangswaarden tijdens de export.

Het volgende voorbeeld meldt de voortgang van een PDF‑export naar de console:

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

{{% alert color="info" title="Opmerking" %}}
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) gebouwd met de Aspose.Slides‑API. Het slaat geselecteerde dia's uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides incrementeel of “fast save”?**

Nee. Elke opslaan‑bewerking schrijft een volledig uitvoerbestand in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) instantie [is not thread-safe](/slides/nl/nodejs-java/multithreading/). Benader en sla elke instantie slechts vanuit één thread tegelijk op.

**Wat gebeurt er met hyperlinks en extern gekoppelde bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/nodejs-java/manage-hyperlinks/) blijven in de presentatie. Aspose.Slides kopieert geen extern gekoppelde bestanden, dus de opgeslagen presentatie moet nog steeds toegang hebben tot hun locaties.

**Kan ik documentmetadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [document properties](/slides/nl/nodejs-java/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het uitvoerbestand.