---
title: Crea un visualizzatore di presentazioni in JavaScript
linktitle: Visualizzatore di presentazioni
type: docs
weight: 50
url: /it/nodejs-java/presentation-viewer/
keywords:
- visualizzare presentazione
- visualizzatore di presentazioni
- creare visualizzatore di presentazioni
- visualizzare PPT
- visualizzare PPTX
- visualizzare ODP
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea un visualizzatore di presentazioni personalizzato in JavaScript con Aspose.Slides per Node.js. Visualizza facilmente file PowerPoint e OpenDocument senza Microsoft PowerPoint."
---
## **Introduzione**

Aspose.Slides per Node.js tramite Java viene utilizzato per creare file di presentazione con diapositive. Queste diapositive possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le diapositive come immagini nel loro visualizzatore di immagini preferito o creare il proprio visualizzatore di presentazioni. In tali casi, Aspose.Slides consente di esportare una singola diapositiva come immagine. Questo articolo descrive come farlo.

## **Generare un'immagine SVG da una diapositiva**

Per generare un'immagine SVG da una diapositiva di una presentazione con Aspose.Slides, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Apri un flusso di file.
1. Salva la diapositiva come immagine SVG nel flusso di file.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generare un SVG con ID forma personalizzato**

Aspose.Slides può essere utilizzato per generare un [SVG](https://docs.fileformat.com/page-description-language/svg/) da una diapositiva con un ID forma personalizzato. Per farlo, utilizzare il metodo `setId` di [SvgShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgshape/). È possibile utilizzare `CustomSvgShapeFormattingController` per impostare l'ID della forma.

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

## **Creare un'immagine miniatura di una diapositiva**

Aspose.Slides ti aiuta a generare immagini miniatura delle diapositive. Per generare una miniatura di una diapositiva utilizzando Aspose.Slides, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento a una scala definita.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

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

## **Creare una miniatura di diapositiva con dimensioni definite dall'utente**

Per creare un'immagine miniatura di diapositiva con dimensioni definite dall'utente, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le dimensioni definite.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

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

## **Creare una miniatura di diapositiva con note del relatore**

Per generare la miniatura di una diapositiva con note del relatore usando Aspose.Slides, seguire i passaggi seguenti:

1. Crea un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/).
1. Utilizza il metodo `RenderingOptions.setSlidesLayoutOptions` per impostare la posizione delle note del relatore.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le opzioni di rendering.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

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

## **Esempio live**

Puoi provare l'app gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/it/viewer/) per vedere cosa puoi implementare con l'API di Aspose.Slides:

![Visualizzatore PowerPoint online](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web Node.js?**

Sì. È possibile utilizzare Aspose.Slides sul lato server per rendere le diapositive come immagini o HTML e visualizzarle nel browser. Le funzionalità di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le diapositive all'interno di un visualizzatore personalizzato?**

L'approccio consigliato è rendere ogni diapositiva come immagine (ad es., PNG o SVG) o convertirla in HTML usando Aspose.Slides, quindi visualizzare il risultato all'interno di un picture box (per desktop) o di un contenitore HTML (per il web).

**Come gestire presentazioni di grandi dimensioni con molte diapositive?**

Per presentazioni di grandi dimensioni, considerare il caricamento lazy-loading o il rendering su richiesta delle diapositive. Ciò significa generare il contenuto di una diapositiva solo quando l'utente vi naviga, riducendo memoria e tempi di caricamento.