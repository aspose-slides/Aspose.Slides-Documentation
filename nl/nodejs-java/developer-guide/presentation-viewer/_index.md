---
title: Maak een presentatieweergave in JavaScript
linktitle: Presentatieweergave
type: docs
weight: 50
url: /nl/nodejs-java/presentation-viewer/
keywords:
- presentatie bekijken
- presentatieweergave
- presentatieweergave maken
- PPT bekijken
- PPTX bekijken
- ODP bekijken
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak een aangepaste presentatieweergave in JavaScript met Aspose.Slides voor Node.js. Toon eenvoudig PowerPoint- en OpenDocument-bestanden zonder Microsoft PowerPoint."
---
## **Inleiding**

Aspose.Slides voor Node.js via Java wordt gebruikt om presentatie‑bestanden met dia's te maken. Deze dia's kunnen bekeken worden door presentaties te openen in Microsoft PowerPoint, bijvoorbeeld. Soms hebben ontwikkelaars echter dia's nodig als afbeelding in hun favoriete beeldviewer of willen ze hun eigen presentatieweergave maken. In dat geval maakt Aspose.Slides het mogelijk om een enkele dia als afbeelding te exporteren. Dit artikel beschrijft hoe u dat doet.

## **Genereer een SVG-afbeelding van een dia**

Om een SVG‑afbeelding van een presentatiedia met Aspose.Slides te genereren, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.  
1. Haal de dia‑referentie op via de index.  
1. Open een bestandsstream.  
1. Sla de dia op als een SVG‑afbeelding naar de bestandsstream.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Genereer een SVG met een aangepaste vorm‑ID**

Aspose.Slides kan worden gebruikt om een [SVG](https://docs.fileformat.com/page-description-language/svg/) te genereren van een dia met een aangepaste vorm‑ID. Hiervoor gebruikt u de `setId`‑methode van [SvgShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kan worden gebruikt om de vorm‑ID in te stellen.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Maak een miniatuurafbeelding van een dia**

Aspose.Slides helpt u miniatuurafbeeldingen van dia's te genereren. Om een miniatuur van een dia te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.  
1. Haal de dia‑referentie op via de index.  
1. Haal de miniatuurafbeelding van de referentiedia op met een gedefinieerde schaal.  
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Maak een dia‑miniatuur met door de gebruiker gedefinieerde afmetingen**

Om een miniatuurafbeelding van een dia met door de gebruiker gedefinieerde afmetingen te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.  
1. Haal de dia‑referentie op via de index.  
1. Haal de miniatuurafbeelding van de referentiedia op met de opgegeven afmetingen.  
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Maak een dia‑miniatuur met spreker‑notities**

Om de miniatuur van een dia met spreker‑notities te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/)‑klasse.  
1. Gebruik de `RenderingOptions.setSlidesLayoutOptions`‑methode om de positie van spreker‑notities in te stellen.  
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.  
1. Haal de dia‑referentie op via de index.  
1. Haal de miniatuurafbeelding van de referentiedia op met de rendering‑opties.  
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Live‑voorbeeld**

U kunt de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) uitproberen om te zien wat u met de Aspose.Slides‑API kunt implementeren:

![Online PowerPoint-viewer](online-PowerPoint-viewer.png)

## **Veelgestelde vragen**

**Kan ik een presentatieweergave inbedden in een Node.js‑webapplicatie?**

Ja. U kunt Aspose.Slides aan de serverzijde gebruiken om dia's te renderen als afbeeldingen of HTML en deze in de browser weer te geven. Navigatie‑ en zoom‑functies kunnen met JavaScript worden geïmplementeerd voor een interactieve ervaring.

**Wat is de beste manier om dia's weer te geven in een aangepaste viewer?**

De aanbevolen aanpak is om elke dia te renderen als een afbeelding (bijv. PNG of SVG) of om deze te converteren naar HTML met Aspose.Slides, en vervolgens de output weer te geven in een picture‑box (voor desktop) of een HTML‑container (voor web).

**Hoe ga ik om met grote presentaties met veel dia's?**

Voor grote presentaties kunt u overwegen om dia's lazy te laden of on‑demand te renderen. Dat betekent dat de inhoud van een dia alleen wordt gegenereerd wanneer de gebruiker er naartoe navigeert, waardoor geheugen‑ en laadtijd worden verminderd.