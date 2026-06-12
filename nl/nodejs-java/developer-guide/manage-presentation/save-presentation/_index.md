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
description: "Ontdek hoe u presentaties kunt opslaan met Aspose.Slides voor Node.js via Java — exporteer naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open Presentations in JavaScript](/slides/nl/nodejs-java/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt deze opslaan wanneer je klaar bent. Met Aspose.Slides voor Node.js kun je opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op in een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld toont hoe je een presentatie opslaat met Aspose.Slides.

```js
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

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse. Een presentatie kan naar veel verschillende stream‑typen worden geschreven. In het onderstaande voorbeeld maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```js
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

Aspose.Slides laat je het begingebied instellen dat PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/) klasse. Gebruik de [setLastView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#setLastView)‑methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewtype/) enumeratie.

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Aspose.Slides laat je een presentatie opslaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/) klasse en stel de `conformance`‑eigenschap in bij het opslaan. Als je [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het voorbeeld hieronder maakt een presentatie en slaat deze op in het Strict Office Open XML‑formaat.

```js
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

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en daarnaast een limiet van 65 535 (2^16‑1) bestanden. Zip64‑formatextensies verhogen deze limieten tot 2^64.

De [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode)‑methode laat je kiezen wanneer Zip64‑formatextensies moeten worden gebruikt bij het opslaan van een Office Open XML‑bestand.

Deze methode kan met de volgende modi worden gebruikt:

- [IfNecessary](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#IfNecessary) gebruikt Zip64‑formatextensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Never) gebruikt nooit Zip64‑formatextensies.
- [Always](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Always) gebruikt altijd Zip64‑formatextensies.

De volgende code toont hoe je een presentatie opslaat als PPTX met Zip64‑formatextensies ingeschakeld:

```js
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
Wanneer je opslaat met [Zip64Mode.Never](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zip64mode/#Never), wordt er een [PptxException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxexception/) gegooid als de presentatie niet kan worden opgeslagen in Zip32‑formaat.
{{% /alert %}}

## **Presentaties opslaan zonder het miniatuurbeeld te vernieuwen**

De [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail)‑methode bepaalt of een miniatuurbeeld wordt gegenereerd bij het opslaan van een presentatie naar PPTX:

- Als `true`, wordt het miniatuurbeeld tijdens het opslaan vernieuwd. Dit is de standaardwaarde.
- Als `false`, blijft het huidige miniatuurbeeld behouden. Als de presentatie geen miniatuurbeeld heeft, wordt er geen gegenereerd.

In de code hieronder wordt de presentatie opgeslagen naar PPTX zonder het miniatuurbeeld te vernieuwen.

```js
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
Deze optie helpt de tijd te verkorten die nodig is om een presentatie op te slaan in PPTX‑formaat.
{{% /alert %}}

## **Opslagvoortgang bijwerken in procenten**

De voortgangsrapportage bij opslaan wordt geconfigureerd via de [setProgressCallback](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setProgressCallback)‑methode op [SaveOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/) en diens subklassen. Geef een Java‑proxy op die de [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/) interface implementeert; tijdens het exporteren ontvangt de callback periodieke procentuele updates.

De volgende code‑fragmenten laten zien hoe je `IProgressCallback` gebruikt.

```javascript
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
Aspose heeft een [gratis PowerPoint‑splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met zijn eigen API. De app laat je een presentatie opsplitsen in meerdere bestanden door geselecteerde dia's op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **Veelgestelde vragen**

**Wordt “fast save” (incremental save) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt elke keer het volledige doelbestand aan; incrementeel “fast save” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) instantie is [niet thread‑safe](/slides/nl/nodejs-java/multithreading/); sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/nodejs-java/manage-hyperlinks/) blijven behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd — zorg ervoor dat de gerefereerde paden toegankelijk blijven.

**Kan ik document‑metadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/nodejs-java/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.