---
title: Skapa en presentationsvisare i JavaScript
linktitle: Presentationsvisare
type: docs
weight: 50
url: /sv/nodejs-java/presentation-viewer/
keywords:
- visa presentation
- presentationsvisare
- skapa presentationsvisare
- visa PPT
- visa PPTX
- visa ODP
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa en anpassad presentationsvisare i JavaScript med Aspose.Slides för Node.js. Visa enkelt PowerPoint- och OpenDocument-filer utan Microsoft PowerPoint."
---
## **Introduktion**

Aspose.Slides för Node.js via Java används för att skapa presentationsfiler med bilder. Dessa bilder kan visas genom att öppna presentationerna i Microsoft PowerPoint, till exempel. Ibland kan utvecklare dock behöva visa bilder som bilder i sin föredragna bildvisare eller skapa sin egen presentationsvisare. I sådana fall tillåter Aspose.Slides att du exporterar en enskild bild som en bild. Denna artikel beskriver hur du gör det.

## **Generera en SVG‑bild från en bild**

För att generera en SVG‑bild från en presentationsbild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta bildreferensen via dess index.
1. Öppna en filström.
1. Spara bilden som en SVG‑bild till filströmmen.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generera en SVG med ett anpassat form‑ID**

Aspose.Slides kan användas för att generera en [SVG](https://docs.fileformat.com/page-description-language/svg/) från en bild med ett anpassat form‑ID. För att göra detta, använd `setId`‑metoden från [SvgShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kan användas för att sätta form‑ID:t.

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

## **Skapa en miniatyrbild för en bild**

Aspose.Slides hjälper dig att generera miniatyrbilder av bilder. För att generera en miniatyr av en bild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta bildreferensen via dess index.
1. Hämta miniatyrbilden av den refererade bilden i en definierad skala.
1. Spara miniatyrbilden i valfritt bildformat.

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

## **Skapa en miniatyrbild med användardefinierade dimensioner**

För att skapa en miniatyrbild med användardefinierade dimensioner, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta bildreferensen via dess index.
1. Hämta miniatyrbilden av den refererade bilden med de definierade dimensionerna.
1. Spara miniatyrbilden i valfritt bildformat.

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

## **Skapa en miniatyrbild med talarnoter**

För att generera en miniatyr av en bild med talarnoter med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [RenderingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/).
1. Använd metoden `RenderingOptions.setSlidesLayoutOptions` för att ange positionen för talarnoter.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta bildreferensen via dess index.
1. Hämta miniatyrbilden av den refererade bilden med renderingsalternativen.
1. Spara miniatyrbilden i valfritt bildformat.

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

## **Live‑exempel**

Du kan prova den kostnadsfria appen [**Aspose.Slides Viewer**](https://products.aspose.app/slides/sv/viewer/) för att se vad du kan implementera med Aspose.Slides‑API:

![Online PowerPoint‑visare](online-PowerPoint-viewer.png)

## **FAQ**

**Kan jag bädda in en presentationsvisare i en Node.js‑webbapplikation?**

Ja. Du kan använda Aspose.Slides på serversidan för att rendera bilder som bilder eller HTML och visa dem i webbläsaren. Navigations‑ och zoom‑funktioner kan implementeras med JavaScript för en interaktiv upplevelse.

**Vad är det bästa sättet att visa bilder i en anpassad visare?**

Den rekommenderade metoden är att rendera varje bild som en bild (t.ex. PNG eller SVG) eller konvertera den till HTML med Aspose.Slides, och sedan visa resultatet i en bildruta (för skrivbord) eller HTML‑behållare (för webben).

**Hur hanterar jag stora presentationer med många bilder?**

För stora bildspel bör du överväga lazy‑loading eller rendera bilder på begäran. Det innebär att generera en bilds innehåll först när användaren navigerar till den, vilket minskar minnes‑ och laddningstid.