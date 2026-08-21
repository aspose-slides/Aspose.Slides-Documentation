---
title: Low-Code presentatiewerkzaamheden in JavaScript
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/nodejs-java/low-code-presentation-operations/
keywords:
- low-code presentatiewerk API
- presentatie converteren
- presentaties samenvoegen
- dia's itereren
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte layoutdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in JavaScript om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de grootte van presentaties te verkleinen."
---
## **Overzicht**

De `aspose.slides` namespace biedt statische hulpprogrammaclassen voor veelvoorkomende presentatie-bewerkingen. Deze helpers wikkelen vaak gebruikte workflows van het objectmodel in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatiestructuren kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low-code helpers zijn het meest bruikbaar wanneer de bewerking wordt toegepast op een heel bestand of presentatie en de standaardworkflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides objectmodel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/) wanneer u fijnmazige controle nodig hebt over individuele dia’s, masters, layout, vormen, exportinstellingen of relaties tussen presentatiestructuren.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand-naar-bestand-aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/merger/) | Volledige presentaties van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstdelen. |
| [Collect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/collect/) | Vormen uit de volledige presentatie ophalen voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) | Niet-gebruikte masters en layout verwijderen en ingesloten lettertype-data verkleinen. |

## **Een presentatie converteren**

Gebruik [Convert.autoByExtension](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/#autoByExtension) wanneer de bestandsextensie van de uitvoer voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat op basis van het uitvoerpad en schrijft het resultaat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/)‑klasse biedt ook speciale methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF-uitvoer. Gebruik het volledige objectmodel wanneer u de presentatie vóór export moet inspecteren of wijzigen of een exportoptie moet configureren die niet door de helper wordt blootgesteld. Zie [Convert Presentation](/nodejs-java/convert-presentation/) voor formaat-specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/merger/#process) om volledige presentaties met één aanroep te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia’s moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige objectmodel wanneer u geselecteerde dia’s wilt samenvoegen, een bestemmings-master of -layout wilt toepassen, secties expliciet wilt behouden of verschillende dia-groottes wilt harmoniseren. Zie [Merge Presentations](/nodejs-java/merge-presentation/) voor die scenario’s.

## **Itereer door presentatie-elementen**

De [ForEach](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/)‑klasse roept een callback aan voor elk aangevraagd type presentatiestructuur. Het voorkomt geneste verzamelingslussen en is handig voor inspectie of formatteringswijzigingen over de hele presentatie. In Node.js maakt u implementaties van de callback‑interfaces met `java.newProxy`.

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

Standaard omvat de traversie van vormen en tekst over de hele presentatie normale, master- en layoutdia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiesdia’s verwerken. Gebruik directe verzamelingslussen wanneer de traversievolgorde, vroegtijdig beëindigen, filteren voor de callback‑aanroep of gedetailleerde ouder-kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/collect/#shapes) wanneer u een verzameling van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is handig wanneer dezelfde set later wordt gefilterd, geteld of meerdere keren wordt verwerkt.

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

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#shape) in plaats daarvan wanneer elke vorm direct kan worden afgehandeld en u de verzamelde resultaten niet hoeft te behouden.

## **Inhoud van presentatie comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype-data verkleinen:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) verwijdert layoutdia’s die door geen normale dia worden gerefereerd.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) verwijdert master‑dia’s die niet meer worden gebruikt.
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

Verwijder ongebruikte layout vóór ongebruikte masters, zodat een master die na het opruimen van layout niet meer wordt gerefereerd eveneens kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de originele masters, layout of volledige ingesloten lettertype-data nodig heeft. Voor meer details, zie [Slide Master](/nodejs-java/slide-master/) en [Embedded Font](/nodejs-java/embedded-font/).

## **FAQ**

**Wanneer moet ik de low-code-API gebruiken in plaats van het volledige objectmodel?**

Gebruik low-code helpers wanneer een standaardbewerking wordt toegepast op een volledig bestand of presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia’s wilt selecteren, relaties tussen masters en layout wilt beheren, de tussenliggende staat wilt inspecteren of gedrag wilt configureren dat de helper niet biedt.

**Kan Merger presentaties combineren met verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/merger/#process) vereist dat de invoer‑presentaties hetzelfde formaat hebben. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.autoByExtension](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/convert/#autoByExtension), en voeg daarna de geconverteerde bestanden samen.

**Verwerkt ForEach master-, layout- en notitiesdia’s?**

[ForEach.slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#slide) doorloopt normale presentatiedia’s. Presentatie-brede [ForEach.shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#paragraph) en [ForEach.portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#portion) operaties omvatten standaard normale, master- en layoutdia’s. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiesdia’s op te nemen.

**Wat is het verschil tussen ForEach.shape en Collect.shapes?**

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/#shape) om elke vorm direct via een callback te verwerken. Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/collect/#shapes) wanneer u een iterabel resultaat nodig heeft dat kan worden behouden, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd het presentatiebestand kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte layout, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, kunnen de betreffende [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) operaties de bestandsgrootte niet verkleinen.

**Worden wijzigingen gemaakt door ForEach of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑object in het geheugen. Nadat u elementen hebt gewijzigd in een [ForEach](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/foreach/)‑callback of [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) hebt uitgevoerd, roept u [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)