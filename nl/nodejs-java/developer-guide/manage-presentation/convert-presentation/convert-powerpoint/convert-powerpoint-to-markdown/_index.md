---
title: Converteer PowerPoint-presentaties naar Markdown in JavaScript
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- dia naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- dia opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- Markdown afbeeldingsexport
- CDN-afbeeldingskoppelingen
- PowerPoint
- presentatie
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PPT- en PPTX-presentaties naar Markdown in JavaScript en bepaal waar geëxporteerde bitmap-, metafile- en SVG-afbeeldingen worden opgeslagen en waarnaar ze verwijzen."
---
## **Overzicht**

Aspose.Slides for Node.js via Java kan PPT‑ en PPTX‑presentaties naar Markdown converteren voor documentatie, statische sites, content‑migratie en versie‑beheersworkflows. U kunt een Markdown‑variant kiezen, bepalen hoe de inhoud van de dia's wordt gerenderd en beslissen waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst.

Standaard gebruikt de Markdown‑export alleen tekstoutput. Om visuele inhoud te exporteren stelt u het exporttype in met de [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/)‑methode op de `Sequential`‑ of `Visual`‑waarde van de [MarkdownExportType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownexporttype/)‑enumeratie. `Sequential` rendert dia‑items afzonderlijk en in volgorde, terwijl `Visual` gegroepeerde items samenhoudt om hun visuele relatie te behouden. De `TextOnly`‑waarde genereert geen afbeeldingsbronnen, waardoor de callbacks voor het opslaan van afbeeldingen in die modus niet worden aangeroepen.

## **Een presentatie naar Markdown converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse en roep vervolgens de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑methode aan met de `Md`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/)‑enumeratie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Kies een Markdown‑variant**

De [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/)‑methode bepaalt welke Markdown‑specificatie voor de output wordt gebruikt. De [Flavor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/flavor/)‑enumeratie omvat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

Het volgende voorbeeld exporteert een presentatie als CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Afbeeldingen exporteren met het standaard lokaal‑opslaan‑gedrag**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/)‑klasse biedt twee methoden om lokaal op te slaan afbeeldingen te configureren:

- [setBasePath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/) geeft de basismap op voor het Markdown‑document en de bijbehorende bronnen.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/) geeft de afbeeldingssubmap op. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsverwijzingen in het Markdown‑document:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Dit gedrag dient tevens als fallback wanneer een aangepaste afbeelding‑opslaan‑handler `false` retourneert.

## **Afbeelding opslaan en Markdown‑links aanpassen**

Gebruik de [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/)‑methode om een callback te registreren voor niet‑SVG bitmap‑ en metafile‑bronnen die tijdens de Markdown‑export worden gegenereerd. De `MarkdownImageSavingHandler`‑callback ontvangt het [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/)‑object, de bijbehorende [ImageFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/)‑waarde en de gegenereerde Markdown‑link als een string‑array met één element. Sla de afbeelding op of upload deze met het opgegeven formaat, en vervang `link[0]` door de referentie die in de Markdown‑output moet verschijnen.

Bronnen die in SVG‑formaat worden uitgegeven, worden apart behandeld. Registreer een callback met de [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/)‑methode. De `MarkdownSvgImageSavingHandler`‑callback ontvangt een `ISvgImage`‑object en de één‑element‑`link`‑array. Een SVG heeft geen `ImageFormat`‑argument; schrijf of upload in plaats daarvan de XML‑gegevens via de `ISvgImage.getSvgData`‑methode. Afhankelijk van de exportmodus en visuele groepering kan een SVG in de bronpresentatie gerasterd of gecombineerd met andere inhoud worden; de resulterende niet‑SVG‑resource wordt dan doorgegeven aan de afbeelding‑opslaan‑callback. Registreer beide callbacks wanneer elke geëxporteerde visuele resource aangepaste verwerking vereist.

In Node.js maakt u implementaties van deze callback‑interfaces met `java.newProxy`.

De retourwaarde van de handler bepaalt wie de afbeelding verwerkt:

- Retourneer `true` zodra de handler de afbeelding heeft opgeslagen, geüpload, getransformeerd of anderszins verwerkt en een geldige waarde aan `link[0]` heeft toegekend. Aspose.Slides schrijft die waarde naar het Markdown‑document en voert niet de standaard lokale opslag uit.
- Retourneer `false` om Aspose.Slides de afbeelding lokaal te laten opslaan en de link te genereren volgens de waarden die zijn ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Een handler die `true` retourneert, neemt de verantwoordelijkheid voor de afbeelding op zich. Als hij `true` retourneert zonder een geldige, niet‑lege link toe te wijzen, mislukt de export met een `InvalidOperationException`.
{{% /alert %}}

### **Afbeeldingen opslaan in een CDN‑origin‑directory en externe URL’s gebruiken**

Het volgende voorbeeld beschouwt `cdn-origin/presentations/quarterly-report` als een aangekoppelde of gesynchroniseerde CDN‑origin‑directory. Elke handler extraheert de gegenereerde bestandsnaam, slaat de afbeelding op in die aangepaste map en vervangt de gegenereerde lokale referentie door een openbare CDN‑URL. Het voorbeeld voert zelf geen netwerkupload uit: de URL wordt pas geldig nadat de map is aangekoppeld als CDN‑origin of de bestanden zijn gepubliceerd naar het CDN. Voor object‑opslag vervangt u de bestands‑systeem‑schrijfopdracht door de upload‑operatie van de opslag‑SDK en kent u `link[0]` pas toe nadat de upload geslaagd is.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

De bitmap‑handler retourneert opzettelijk `false` voor afbeeldingen kleiner dan 128 × 128 pixels, zodat Aspose.Slides die afbeeldingen opslaat in `output/fallback-images` volgens het standaardgedrag. Grotere bitmap‑ en metafile‑resources, evenals SVG‑resources, worden door de aangepaste code afgehandeld. Bijvoorbeeld, een gegenereerde lokale referentie zoals `fallback-images/image1.png` wordt `https://cdn.example.com/presentations/quarterly-report/image1.png`. De handlers gebruiken alleen besturingssysteem‑paden bij het schrijven van bestanden; links die naar Markdown worden geschreven gebruiken schuine strepen en URL‑gecodeerde bestandsnamen. Pas dezelfde regel toe bij het opbouwen van relatieve links: gebruik `/`, niet het platform‑specifieke map‑scheidingsteken.

## **Veelgestelde vragen**

**Kan één handler zowel raster‑afbeeldingen als SVG‑afbeeldingen verwerken?**

Nee. Gebruik [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/) voor bitmap‑ en metafile‑resources en [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/) voor SVG‑resources. De eerste levert een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/)‑object en een [ImageFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/)‑waarde; de tweede levert een `ISvgImage`‑object waarvan de SVG‑data kan worden gelezen met `ISvgImage.getSvgData`. Een bron‑SVG die tijdens de export gerasterd wordt, wordt door de afbeelding‑opslaan‑callback verwerkt.

**Wat gebeurt er wanneer een afbeelding‑opslaan‑handler `false` retourneert?**

Aspose.Slides gebruikt het standaard lokaal‑opslaan‑gedrag. De afbeelding‑locatie en gegenereerde referentie worden bepaald door de waarden die zijn ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/).

**Kan een handler een URL leveren zonder de afbeelding lokaal op te slaan?**

Ja. De handler kan de afbeelding uploaden naar object‑opslag of doorgeven aan een andere service, de resulterende URL toewijzen aan `link[0]` en `true` retourneren. De handler moet de verwerking zelf voltooien; het retourneren van `true` voorkomt de standaard lokale opslag.

**Waarom gooit de Markdown‑export een `InvalidOperationException` vanuit een handler?**

Deze uitzondering treedt op wanneer de handler `true` retourneert maar geen geldige link opgeeft. Ken vóór het retourneren van `true` het relatieve pad of de externe URL toe die in Markdown moet worden geschreven.

**Welke pad‑scheidingsteken moet worden gebruikt in afbeeldings‑links?**

Gebruik schuine strepen (`/`) in Markdown‑links en URL’s. Gebruik `path.join` alleen voor besturingssysteem‑paden; normaliseer vervolgens de Markdown‑referentie apart.

**Worden hyperlinks behouden tijdens de Markdown‑export?**

Ja. Tekst‑[hyperlinks](/slides/nl/nodejs-java/manage-hyperlinks/) blijven behouden als standaard Markdown‑links. Dia‑[transities](/slides/nl/nodejs-java/slide-transition/) en [animaties](/slides/nl/nodejs-java/powerpoint-animation/) worden niet geconverteerd.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

U kunt verschillende presentatie‑bestanden parallel verwerken, maar deel geen enkele [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie tussen threads. Volg de [multithreading‑richtlijnen](/slides/nl/nodejs-java/multithreading/) en gebruik een aparte instantie per bestand.