---
title: Converti le diapositive della presentazione in immagini in Node.js via .NET
linktitle: Diapositiva in immagine
type: docs
weight: 40
url: /it/nodejs-net/convert-slide/
keywords:
- convertire diapositiva
- diapositiva in immagine
- diapositiva in PNG
- salvare diapositiva come immagine
- renderizzare diapositiva
- miniatura diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderizza le diapositive di presentazioni PPTX, PPT e ODP come immagini PNG in JavaScript con Aspose.Slides per Node.js via .NET, a un fattore di scala o a una dimensione esatta in pixel."
---
## **Panoramica**

Aspose.Slides per Node.js via .NET rende le diapositive di presentazioni PowerPoint e OpenDocument come immagini, ad esempio per mostrare anteprime delle diapositive su una pagina web. Questo articolo mostra due modi per scegliere la dimensione dell’immagine: un fattore di scala relativo alle dimensioni della diapositiva e una dimensione esatta in pixel. Entrambi gli esempi salvano file PNG.

Gli esempi si aspettano una presentazione denominata `sample.pptx` nella cartella del progetto che hai impostato in [Installation](/slides/it/nodejs-net/installation/). Qualsiasi presentazione PowerPoint va bene. Salva ciascun esempio come file `.js` nella cartella del progetto ed eseguilo da quella cartella con `node`.

{{% alert color="info" title="Nota" %}}
Aspose.Slides per Node.js via .NET non dispone di una propria documentazione API. Rispecchia l’API di Aspose.Slides per .NET con nomi camelCase, quindi i collegamenti API in questo articolo puntano alle classi e ai membri corrispondenti nella [documentazione API di Aspose.Slides per .NET](https://reference.aspose.com/slides/it/net/).
{{% /alert %}}

Per convertire una diapositiva in un’immagine, segui questi passaggi:

1. Apri la presentazione con il costruttore [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/presentation/).
1. Ottieni una diapositiva dalla raccolta [slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/) con `get(index)`. Gli indici partono da 0.
1. Renderizza la diapositiva con `getImageWithScale` o `getImageWithImageSize`. Nella documentazione API .NET, entrambi sono overload di [Slide.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage/). Restituiscono un oggetto immagine che corrisponde a [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/).
1. Salva l’immagine con il suo metodo [save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/save/) e un valore [ImageFormat](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/), quindi chiama il suo metodo `dispose`.

## **Convertire ogni diapositiva in un’immagine PNG**

`getImageWithScale` accetta un fattore di scala orizzontale e uno verticale. Con una scala di 1, un punto della diapositiva diventa un pixel dell’immagine. L’esempio seguente renderizza ogni diapositiva con una scala di 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Una scala di 1 renderizza un pixel per punto; 2 raddoppia la larghezza e l'altezza.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Lo script scrive un file per diapositiva, `slide_1.png`, `slide_2.png` e così via, numerati a partire da 1. Per una presentazione 16:9 con diapositive di 960 × 540 punti, ogni immagine è 1920 × 1080 pixel. Anche le diapositive nascoste vengono renderizzate; per saltarle, controlla la proprietà [hidden](https://reference.aspose.com/slides/it/net/aspose.slides/slide/hidden/) della diapositiva. Ogni immagine viene eliminata nel proprio blocco `finally`, che la rilascia prima che la diapositiva successiva venga renderizzata. Senza licenza, le immagini mostrano anche una filigrana di valutazione; vedi [Licensing](/slides/it/nodejs-net/licensing/).

## **Convertire una diapositiva in un’immagine di dimensioni specificate**

`getImageWithImageSize` accetta un oggetto con `width` e `height` in pixel. L’esempio seguente renderizza la prima diapositiva larga 1280 pixel e calcola l’altezza in base alle dimensioni della diapositiva, in modo che l’immagine mantenga le proporzioni della diapositiva:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

La proprietà [slideSize.size](https://reference.aspose.com/slides/it/net/aspose.slides/slidesize/size/) restituisce la larghezza e l’altezza della diapositiva in punti. Per una presentazione 16:9, lo script stampa `Saved a 1280 x 720 image` e scrive `slide_1_1280px.png`; per una presentazione 4:3, l’immagine è 1280 × 960 pixel.

## **Domande frequenti**

**Perché l’immagine restituita da `getImage` senza argomenti è così piccola?**

Senza argomenti, `getImage` renderizza la diapositiva al 20 % della sua dimensione in punti, quindi una diapositiva di 960 × 540 punti diventa un’immagine di 192 × 108 pixel. Usa `getImageWithScale` o `getImageWithImageSize` per scegliere la dimensione.

**Come salvo in formato JPEG o altri formati immagine?**

Passa un altro valore `ImageFormat` al metodo `save` dell’immagine, ad esempio `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Il formato deriva dal valore `ImageFormat`, non dall’estensione del file, quindi mantieni i due coerenti.

**Perché il testo nelle immagini appare diverso su Linux?**

Aspose.Slides può usare solo i font installati sulla macchina che renderizza le diapositive. Quando una presentazione utilizza un font mancante, ad esempio Calibri su un tipico server Linux, Aspose.Slides usa un font installato al suo posto, il che può modificare l’aspetto del testo e le interruzioni di riga. Installa i font utilizzati dalle tue presentazioni per ottenere le stesse immagini di Windows.

**Perché `getThumbnailWithImageSize` genera un TypeError?**

Il README del pacchetto usa `getThumbnailWithImageSize`, ma il pacchetto non ha metodi `getThumbnail`. Usa `getImageWithImageSize` invece; accetta lo stesso argomento `{ width, height }`.