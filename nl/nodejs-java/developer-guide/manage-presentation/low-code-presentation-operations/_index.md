---
title: Low-Code Presentatiebewerkingen in JavaScript
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/nodejs-java/low-code-presentation-operations/
keywords:
- low-code presentaties API
- presentatie converteren
- presentaties samenvoegen
- dia's itereren
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte lay-outdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in JavaScript om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

De namespace `aspose.slides` biedt statische helperklassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte workflows van het objectmodel in gerichte methoden, zodat je bestanden kunt converteren of samenvoegen, presentatiewaarde‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code helpers zijn het meest nuttig wanneer de bewerking betrekking heeft op een heel bestand of presentatie en de standaardworkflow aan je eisen voldoet. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/) wanneer je fijnmazige controle nodig hebt over afzonderlijke dia's, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/merger/) | Complete presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstgedeelte. |
| [Collect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/collect/) | Vormen uit de gehele presentatie ophalen voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑gegevens reduceren. |

## **Een presentatie converteren**

Gebruik [Convert.autoByExtension](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/#autoByExtension) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat aan de hand van het uitvoerpad en schrijft het resultaat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/)‑klasse biedt ook speciale methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑uitvoer. Gebruik het volledige objectmodel wanneer je de presentatie wilt inspecteren of wijzigen vóór export of een exportoptie wilt configureren die niet door de geselecteerde helper wordt blootgelegd. Zie [Convert Presentation](/slides/nl/nodejs-java/convert-presentation/) voor format‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/merger/#process) om volledige presentatiebestanden in één oproep te combineren. De invoerpresentaties moeten hetzelfde bestandsformaat hebben.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Deze helper is geschikt wanneer alle dia's aan één resultaat moeten worden toegevoegd zonder ze individueel te selecteren of te herkaarten. Gebruik het volledige objectmodel wanneer je geselecteerde dia's wilt samenvoegen, een bestemmings‑master of -lay‑out wilt toepassen, secties expliciet wilt behouden of verschillende dia‑groottes wilt reconcilieren. Zie [Merge Presentations](/slides/nl/nodejs-java/merge-presentation/) voor die scenario's.

## **Door presentatiewaarde‑elementen itereren**

De [ForEach](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/)‑klasse roept een callback aan voor elk gevraagde type presentatiewaarde‑element. Het vermijdt geneste verzamelingslussen en is handig voor inspectie of opmaakwijzigingen over de hele presentatie. In Node.js maak je implementaties van de callback‑interfaces met `java.newProxy`.

Het volgende voorbeeld gebruikt [ForEach.slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#paragraph) en [ForEach.portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#portion) om de overeenkomstige elementen te inspecteren:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Standaard omvat de vorm‑ en tekst‑traversal over de hele presentatie normale, master‑ en lay‑outdia's. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia's verwerken. Gebruik directe verzamelingslussen wanneer de traversaalvolgorde, vroegtijdig beëindigen, filteren vóór het aanroepen van de callback of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/collect/#shapes) wanneer je een verzameling van alle vormen in een presentatie nodig hebt in plaats van een callback voor elke vorm. Dit is nuttig wanneer dezelfde set later gefilterd, geteld of meermaals verwerkt zal worden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#shape) in plaats daarvan wanneer elke vorm direct kan worden afgehandeld en je het verzamelde resultaat niet hoeft te bewaren.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑gegevens reduceren:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) verwijdert lay‑outdia's waar geen normale dia naar verwijst.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) verwijdert master‑dia's die niet meer worden gebruikt.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwijder eerst ongebruikte lay‑outs vóór ongebruikte masters, zodat een master die na het opruimen van lay‑outs niet meer wordt verwezen, ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als je later de originele masters, lay‑outs of volledige ingesloten lettertype‑gegevens nodig hebt. Voor meer details, zie [Slide Master](/slides/nl/nodejs-java/slide-master/) en [Embedded Font](/slides/nl/nodejs-java/embedded-font/).

## **FAQ**

**Wanneer moet ik de low‑code API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code helpers wanneer een standaardbewerking van toepassing is op een compleet bestand of presentatie en geen gedetailleerde controle over afzonderlijke elementen vereist. Gebruik het volledige objectmodel wanneer je specifieke dia's moet selecteren, relaties tussen master en lay‑out moet beheren, de tussentijdse staat wilt inspecteren of gedrag wilt configureren dat de helper niet blootlegt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/merger/#process) vereist invoerpresentaties in hetzelfde formaat. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.autoByExtension](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/#autoByExtension), en voeg daarna de geconverteerde bestanden samen.

**Verwerkt ForEach master-, layout- en notitiedia's?**

[ForEach.slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#slide) itereert over normale presentatiedia's. Presentatie‑brede [ForEach.shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#paragraph) en [ForEach.portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#portion) bewerkingen omvatten standaard normale, master‑ en lay‑outdia's. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia's mee te nemen.

**Wat is het verschil tussen ForEach.shape en Collect.shapes?**

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#shape) om elke vorm direct via een callback te verwerken. Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/collect/#shapes) wanneer je een iterabel resultaat nodig hebt dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd de presentatiedoor kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, verminderen de bijbehorende [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/)‑bewerkingen mogelijk niet de bestandsgrootte.

**Worden wijzigingen die door ForEach of Compress worden aangebracht automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑object in het geheugen. Nadat je elementen hebt gewijzigd in een [ForEach](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/)‑callback of [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) hebt uitgevoerd, roep je [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Presentatie converteren](/slides/nl/nodejs-java/convert-presentation/)
- [Presentaties samenvoegen](/slides/nl/nodejs-java/merge-presentation/)
- [Slide Master](/slides/nl/nodejs-java/slide-master/)
- [Tekstvak beheren](/slides/nl/nodejs-java/manage-textbox/)
- [Ingesloten lettertype](/slides/nl/nodejs-java/embedded-font/)