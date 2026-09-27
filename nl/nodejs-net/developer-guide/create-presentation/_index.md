---
title: Presentaties maken in Node.js via .NET
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/nodejs-net/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PowerPoint maken
- PPTX maken
- tekstvak toevoegen
- dia toevoegen
- diaformaat
- breedbeeld
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak PowerPoint‑presentaties in JavaScript met Aspose.Slides for Node.js via .NET: voeg een tekstvak en dia's toe, stel een 16:9‑diaformaat in en sla het resultaat op als PPTX."
---
## **Overzicht**

Dit artikel laat zien hoe je een presentatie maakt met Aspose.Slides for Node.js via .NET, een tekstvak toevoegt aan de eerste dia, en het resultaat opslaat als een PPTX‑bestand. Het laat ook zien hoe je meer dia's toevoegt en hoe je de presentatie omschakelt naar breedbeeld (16:9) dia's.

De voorbeelden vereisen een project dat is opgezet zoals beschreven in [Installatie](/slides/nl/nodejs-net/installation/). Sla elk voorbeeld op als een `.js`‑bestand in de projectmap en voer het uit vanuit die map met `node`, bijvoorbeeld `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET heeft geen eigen API‑referentie. Het spiegelt de Aspose.Slides for .NET‑API met camelCase‑namen, zodat de API‑links in dit artikel verwijzen naar de overeenkomende klassen en leden in de [Aspose.Slides for .NET API‑referentie](https://reference.aspose.com/slides/nl/net/).
{{% /alert %}}

## **Een presentatie maken met een tekstvak**

Volg deze stappen om een presentatie te maken en een tekstvak op de eerste dia te plaatsen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse. Een nieuwe presentatie bevat al één lege dia.  
2. Haal die dia op uit de [slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/)‑collectie. Collecties in dit pakket worden gelezen met `get(index)`, en indexen beginnen bij 0.  
3. Voeg een rechthoek toe met de [addAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/shapecollection/addautoshape/)‑methode en stel de [text](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/text/) van het bijbehorende [textFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/textframe/) in.  
4. Sla de presentatie op met de [save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode en de `SaveFormat.Pptx`‑waarde.  
5. Roep `dispose` aan in een `finally`‑blok om de .NET‑bronnen die de presentatie ondersteunen vrij te geven.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // De positie (x, y) en de afmeting (breedte, hoogte) zijn in punten.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Het script schrijft `new-presentation.pptx` naar de projectmap. Het bestand bevat één dia met een gevulde rechthoek waarvan de linkerbovenhoek 50 punten van de linker‑ en bovenrand van de dia ligt. De rechthoek is 400 punten breed en 100 punten hoog, en de tekst staat gecentreerd. Eén punt is 1/72 inch. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan de dia; zie [Licentie](/slides/nl/nodejs-net/licensing/).

## **Dia's toevoegen**

Een nieuwe presentatie heeft één dia. Om meer dia's toe te voegen, geef je een lay-outdia door aan de [addEmptySlide](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/addemptyslide/)‑methode van de `slides`‑collectie. De [getByType](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslidecollection/getbytype/)‑methode van de [layoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/layoutslides/)‑collectie geeft de eerste lay-out terug van een opgegeven [SlideLayoutType](https://reference.aspose.com/slides/nl/net/aspose.slides/slidelayouttype/).

Het volgende voorbeeld voegt twee dia's toe met de Blank‑lay-out:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het script geeft `Slide count: 3` weer en schrijft `three-slides.pptx`. De nieuwe dia's worden achter de eerste geplaatst en bevatten geen vormen. Een nieuwe presentatie heeft altijd een Blank‑lay-out, maar een presentatie die je opent vanuit een bestand heeft mogelijk niet de gewenste lay-out; in dat geval geeft `getByType` `null` terug, dus controleer het resultaat voordat je het gebruikt.

## **Diaformaat instellen**

Een nieuwe presentatie gebruikt 4:3‑dia's van 720 × 540 punten (10 × 7,5 inch). Om breedbeelddia's te maken, roep je de [setSize](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesize/setsize/)‑methode van de [slideSize](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slidesize/) van de presentatie aan met een [SlideSizeType](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizetype/)‑waarde en een [SlideSizeScaleType](https://reference.aspose.com/slides/nl/net/aspose.slides/slidesizescaletype/)‑waarde. Het schaaltype vertelt Aspose.Slides wat te doen met vormen die al op de dia's staan; `DoNotScale` laat ze onveranderd, wat de juiste keuze is voor een presentatie zonder inhoud.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het script geeft `Slide size: 960 x 540 points` weer, wat 13,33 × 7,5 inch is, en schrijft `widescreen.pptx`. `SlideSizeType.OnScreen16x9` heeft dezelfde 16:9‑aspectverhouding maar is kleiner: 720 × 405 punten.

## **FAQ**

**In welke eenheden worden posities en afmetingen gemeten?**

In punten. Eén inch is 72 punten, dus de standaard 4:3‑dia is 720 × 540 punten, en een 16:9‑breedbeelddia is 960 × 540 punten.

**Naar welke formaten kan ik een nieuwe presentatie opslaan?**

Naar elke waarde van de [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/)‑enumeratie, bijvoorbeeld `SaveFormat.Ppt` voor PowerPoint 97–2003, `SaveFormat.Odp` voor OpenDocument, of `SaveFormat.Pdf`. Voor PDF‑output, zie [PowerPoint naar PDF converteren](/slides/nl/nodejs-net/convert-powerpoint-to-pdf/).

**Waarom bevat de opgeslagen presentatie de tekst “Evaluation only”?**

Zonder licentie voegt Aspose.Slides een evaluatiewatermerk toe aan de dia's die het opslaat. Pas een licentie toe zoals beschreven in [Licentie](/slides/nl/nodejs-net/licensing/) om dit te verwijderen.

**Waarom moet ik `dispose` aanroepen?**

Een `Presentation`‑object wordt ondersteund door een .NET‑object dat geheugen en andere bronnen beheert. Het aanroepen van `dispose` geeft deze bronnen vrij zodra je de presentatie niet meer nodig hebt, en het aanroepen in een `finally`‑blok zorgt ervoor dat ze ook bij een fout worden vrijgegeven.