---
title: Geavanceerde Tekstextractie uit Presentaties in JavaScript
linktitle: Tekst Extraheren
type: docs
weight: 90
url: /nl/nodejs-java/extract-text-from-presentation/
keywords:
- tekst extraheren
- tekst extraheren uit dia
- tekst extraheren uit presentatie
- tekst extraheren uit PowerPoint
- tekst extraheren uit OpenDocument
- tekst extraheren uit PPT
- tekst extraheren uit PPTX
- tekst extraheren uit ODP
- tekst ophalen
- tekst ophalen uit dia
- tekst ophalen uit presentatie
- tekst ophalen uit PowerPoint
- tekst ophalen uit OpenDocument
- tekst ophalen uit PPT
- tekst ophalen uit PPTX
- tekst ophalen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Snel tekst extraheren uit PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Node.js via Java. Volg onze eenvoudige, stapsgewijze gids om tijd te besparen."
---
## **Overzicht**

Het extraheren van tekst uit presentaties is een veelvoorkomende maar essentiële taak voor ontwikkelaars die met dia‑inhoud werken. Of je nu te maken hebt met Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat, of OpenDocument‑presentaties (ODP), toegang krijgen tot en het ophalen van tekstgegevens kan cruciaal zijn voor analyse, automatisering, indexering of contentmigratie.

Dit artikel biedt een uitgebreide gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met Aspose.Slides for Node.js via Java. Je leert hoe je systematisch door presentatie‑elementen kunt itereren om de benodigde tekstinhoud nauwkeurig op te halen.

## **Tekst extraheren uit een dia**

Aspose.Slides for Node.js via Java biedt de [SlideUtil](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/)‑klasse. Deze klasse stelt verschillende overladen statische methoden beschikbaar om alle tekst uit een presentatie of dia te extraheren. Om tekst uit een dia in een presentatie te extraheren, gebruik je de [getAllTextBoxes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-)‑methode. Deze methode accepteert een dia‑object als parameter. Bij uitvoering scant de methode de volledige dia op tekst en retourneert een array van [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/)‑objecten, waarbij eventuele tekstopmaak behouden blijft.

De onderstaande codefragment extrahert alle tekst van de eerste dia van de presentatie:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tekst extraheren uit een presentatie**

Om tekst uit de volledige presentatie te scannen, gebruik je de [getAllTextFrames](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-)‑statische methode die wordt blootgesteld door de [SlideUtil](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/)‑klasse. Deze accepteert twee parameters:

1. Ten eerste een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑object dat een PowerPoint‑ of OpenDocument‑presentatie vertegenwoordigt waaruit tekst zal worden geëxtraheerd.  
1. Ten tweede een `boolean`‑waarde die aangeeft of de master‑dia's moeten worden inbegrepen bij het scannen van tekst uit de presentatie.

De methode retourneert een array van [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/)‑objecten, inclusief informatie over tekstopmaak. De onderstaande code scant de tekst en opmaakdetails uit een presentatie, inclusief de master‑dia's.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gecategoriseerde en snelle tekstextractie**

De [PresentationFactory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/)‑klasse biedt ook methoden om alle tekst uit presentaties te extraheren:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Het argument van de enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textextractionarrangingmode/) geeft de modus aan voor het organiseren van het resultaat van de tekstextractie en kan worden ingesteld op de volgende waarden:
- `Unarranged` - De ruwe tekst zonder rekening te houden met de positie op de dia.  
- `Arranged` - De tekst wordt gerangschikt in dezelfde volgorde als op de dia.

De niet‑gerangschikte modus kan worden gebruikt wanneer snelheid cruciaal is; deze is sneller dan de gerangschikte modus.

[PresentationText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is geëxtraheerd. De `getSlidesText`‑methode retourneert een array van objecten, elk representerend de tekst op de bijbehorende dia. Elk dia‑tekstobject heeft de volgende methoden:

- De `getText`‑methode retourneert de tekst binnen de vormen van de dia.  
- De `getMasterText`‑methode retourneert de tekst binnen de vormen van de master‑dia die aan deze dia is gekoppeld.  
- De `getLayoutText`‑methode retourneert de tekst binnen de vormen van de lay‑out‑dia die aan deze dia is gekoppeld.  
- De `getNotesText`‑methode retourneert de tekst binnen de vormen van de notities‑dia die aan deze dia is gekoppeld.  
- De `getCommentsText`‑methode retourneert de tekst binnen de commentaren die aan deze dia zijn gekoppeld.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **Veelgestelde vragen**

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekstextractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [grote presentaties](/slides/nl/nodejs-java/open-presentation/) verwerken, waardoor het geschikt is voor real‑time of bulk‑verwerkingsscenario’s.

**Kan Aspose.Slides tekst extraheren uit tabellen en grafieken binnen presentaties?**

Ja. Aspose.Slides kan tekst extraheren uit vele dia‑elementen, inclusief tabellen en grafiekgerelateerde objecten, zodat je toegang krijgt tot en de tekstinhoud kunt analyseren in gangbare presentatiestructuren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [bepaalde beperkingen](/slides/nl/nodejs-java/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia’s. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aanbevolen een volledige licentie aan te schaffen.