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
- voorgedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang bij opslaan
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u presentaties kunt opslaan met Aspose.Slides voor Node.js via Java—exporteer naar PowerPoint of OpenDocument terwijl de lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open Presentations in JavaScript](/slides/nl/nodejs-java/open-presentation/) beschreef hoe je de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties kunt maken en opslaan. De [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt deze opslaan zodra je klaar bent. Met Aspose.Slides voor Node.js kun je opslaan naar een **bestand** of **stream**. Dit artikel bespreekt de verschillende manieren om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld toont hoe je een presentatie opslaat met Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Voer hier wat werk uit...

    // Sla de presentatie op naar een bestand.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een uitvoer‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse. Een presentatie kan naar verschillende soorten streams worden geschreven. In het voorbeeld hieronder maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Sla de presentatie op naar de stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides laat je het initiële weergavetype instellen dat PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/)‑klasse. Gebruik de [setLastView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#setLastView)‑methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewtype/)‑enumeratie.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Aspose.Slides laat je een presentatie opslaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/)‑klasse en stel de eigenschap *conformance* in bij het opslaan. Als je [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) opgeeft, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het voorbeeld hieronder maakt een presentatie en slaat deze op in het Strict Office Open XML‑formaat.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation();
try {
    // Sla de presentatie op in het Strict Office Open XML-formaat.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat limieten van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en bovendien het aantal bestanden beperkt tot 65 535 (2^16‑1). ZIP64‑formatextensies verhogen deze limieten tot 2^64.

De [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode)‑methode laat je kiezen wanneer ZIP64‑formatextensies worden gebruikt bij het opslaan van een Office Open XML‑bestand.

Deze methode kan met de volgende modi worden gebruikt:

- [IfNecessary](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64‑formatextensies alleen als de presentatie de bovengenoemde limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Never) gebruikt nooit ZIP64‑formatextensies.
- [Always](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Always) gebruikt altijd ZIP64‑formatextensies.

De volgende code laat zien hoe je een presentatie opslaat als een PPTX‑bestand met ZIP64‑formatextensies ingeschakeld:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="OPMERKING" color="warning" %}}
Wanneer je opslaat met [Zip64Mode.Never](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Never), wordt een [PptxException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxexception/) gegooid als de presentatie niet in ZIP32‑formaat kan worden opgeslagen.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Bij grote presentaties kun je het compressieniveau aanpassen om een balans te vinden tussen bestandsgrootte en verwerkingstijd. Afhankelijk van je eisen kun je kiezen voor snellere verwerking of kleinere uitvoerbestanden.

Aspose.Slides biedt de [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel)‑methode, waarmee je het compressieniveau kunt aangeven dat wordt gebruikt bij het opslaan van een presentatie in Office Open XML‑formaat.

De volgende compressieniveaus zijn beschikbaar:

- [**None**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#None): Er wordt geen compressie toegepast. Bestanden worden ongewijzigd opgeslagen.
- [**Level1**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level1): De snelste compressie met de laagste compressieverhouding.
- [**Level2**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level2): Snellere compressie met een iets betere compressieverhouding dan **Level1**.
- [**Level3**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level3): Biedt betere compressie dan **Level2** met een matige impact op verwerkingstijd.
- [**Level4**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level4): Biedt betere compressie dan **Level3**.
- [**Level5**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level5): Verbeterde compressie ten opzichte van **Level4** met extra verwerkingstijd.
- [**Level6**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level6): Standaardcompressie die een goede balans biedt tussen verwerkingssnelheid en bestandsgrootte. Dit is het *standaard compressieniveau*.
- [**Level7**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level7): Biedt betere compressie dan **Level6** met tragere verwerking.
- [**Level8**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level8): Biedt betere compressie dan **Level7**.
- [**Level9**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compressionlevel/#Level9): Maximale compressie. Levert de kleinste bestandsgrootte, maar vereist de langste verwerkingstijd.

Het volgende voorbeeld laat zien hoe je een presentatie opslaat als een PPTX‑bestand *zonder compressie*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Dit voorbeeld toont hoe je een presentatie opslaat als een PPTX‑bestand met *maximale compressie*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail)‑methode regelt de miniatuurgeneratie bij het opslaan van een presentatie naar PPTX:

- Indien `true`, wordt de miniatuur tijdens het opslaan vernieuwd. Dit is de standaardwaarde.
- Indien `false`, wordt de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de code hieronder wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Deze optie helpt de benodigde tijd te verkorten bij het opslaan van een presentatie in PPTX‑formaat.
{{% /alert %}}

## **Voortgangsrapportage in percentages**

Voortgangsrapportage tijdens het opslaan wordt geconfigureerd via de [setProgressCallback](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setProgressCallback)‑methode op [SaveOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/) en zijn subklassen. Geef een Java‑proxy die de [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/)‑interface implementeert; tijdens het exporteren ontvangt de callback periodieke percentage‑updates.

De volgende code‑fragmenten laten zien hoe je `IProgressCallback` gebruikt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Gebruik hier de voortgangspercentagewaarde.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose heeft een [gratis PowerPoint Splitter‑applicatie](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van zijn eigen API. De app laat je een presentatie splitsen in meerdere bestanden door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “snelle opslaan” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt telkens het volledige doelbestand aan; incrementeel “snelle opslaan” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie is **niet thread‑safe** (/slides/nl/nodejs-java/multithreading/); sla op vanuit één enkele thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/nodejs-java/manage-hyperlinks/) worden behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd – zorg dat de verwezen paden toegankelijk blijven.

**Kan ik document‑metadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/nodejs-java/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.