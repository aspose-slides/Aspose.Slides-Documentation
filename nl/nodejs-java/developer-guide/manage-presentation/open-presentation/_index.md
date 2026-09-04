---
title: Presentaties openen in JavaScript
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/nodejs-java/open-presentation/
keywords:
- PowerPoint openen
- presentatie openen
- PPTX openen
- PPT openen
- ODP openen
- presentatie laden
- PPTX laden
- PPT laden
- ODP laden
- beveiligde presentatie
- grote presentatie
- externe bron
- binaire object
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt openen in JavaScript, openingswachtwoorden kunt opgeven, het laden van bronnen kunt beheren en het geheugenverbruik kunt verminderen met Aspose.Slides voor Node.js via Java."
---
## **Introductie**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nl/nodejs-java/) kan PowerPoint- en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kun je de structuur inspecteren, dia’s bewerken, bronnen beheren en opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/) klasse. Je kunt bijvoorbeeld een openingswachtwoord opgeven, grote binaire objecten buiten het Node.js‑geheugen houden, externe bronnen beheren of ingebedde binaire data weglaten.

## **Presentaties openen**

Om een bestaande presentatie te openen, geef je het bestandspad door aan de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) constructor. Maak de presentatie vrij na gebruik zodat bestands­handvatten, tijdelijke data en andere bronnen onmiddellijk worden vrijgegeven.

Het volgende JavaScript‑voorbeeld laat zien hoe je een presentatie opent en het aantal dia’s opvraagt:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Wachtwoordbeveiligde presentaties openen**

Een openingswachtwoord versleutelt de presentatie‑inhoud. Om de volledige presentatie te laden, geef je het juiste wachtwoord door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword) en lever je de opties aan de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Voor wachtwoorddetectie, -validatie en encryptieworkflows, zie [Password-Protect Presentations](/slides/nl/nodejs-java/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen worden gelezen zonder wachtwoord; zie [Manage Presentation Properties](/slides/nl/nodejs-java/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) geeft opties terug die bepalen hoe Aspose.Slides omgaat met binaire grote objecten zoals afbeeldingen, audio en video. Je kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑data die in het geheugen wordt bewaard beperken.

De volgende JavaScript‑code demonstreert het laden van een grote presentatie (bijvoorbeeld 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Met [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) blijft het bronbestand vergrendeld totdat de presentatie‑instantie wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet terwijl die instantie nog actief is.

Aspose.Slides kan tijdens het laden de inhoud van een invoer‑stream kopiëren. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/nodejs-java/manage-blob/) voor extra opslag‑ en geheugen‑beheermogelijkheden.
{{% /alert %}}

## **Externe bronnen beheren**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepteert een implementatie van [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iresourceloadingcallback/). De callback kan vervangende data leveren, een bron omleiden, de standaardlader gebruiken of de bron overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die moeten worden opgelost volgens toepassingsspecifieke beveiligings‑ of opslagregels.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Presentaties laden zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire data bevatten die een applicatie niet nodig heeft of wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [Presentation.getVbaProject](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getVbaProject);
- ingebedde OLE‑data, beschikbaar via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑controldata, beschikbaar via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Stel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) in op `true` om deze binaire data tijdens het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie verkleint de blootstelling aan ongewenste ingebedde payloads, maar is geen volledig malware‑detectie‑ of content‑sanitiseringssysteem.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides gooit tijdens het laden een parse‑ of formaat‑exception. Verwerk die fout apart van een foutmelding voor een onjuist wachtwoord, zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen substitueren. Je kunt [font‑substitutie configureren](/slides/nl/nodejs-java/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/nodejs-java/custom-font/) om de uitvoer voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio‑ en video‑bestanden worden beschikbaar via het presentatiemodel. Externe bronnen worden opgelost volgens het geconfigureerde resource‑laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.