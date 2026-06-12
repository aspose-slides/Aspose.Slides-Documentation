---
title: Converti le diapositive PowerPoint in PNG con JavaScript
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/nodejs-java/convert-powerpoint-to-png/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salva PPT come PNG
- salva PPTX come PNG
- esporta PPT in PNG
- esporta PPTX in PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità con JavaScript in modo rapido usando Aspose.Slides per Node.js, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in immagini PNG utilizzando Aspose.Slides. Mostra come caricare file di presentazione in formati come PPT, PPTX e ODP, renderizzare le diapositive come immagini e salvare i risultati in formato PNG.

L'articolo dimostra anche come personalizzare le immagini PNG generate impostando i valori di scala o specificando la larghezza e l'altezza desiderate.

## **Converti PowerPoint in PNG**

Segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni l'oggetto slide dalla collezione restituita dal metodo [Presentation.getSlides()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) nella classe [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide).
3. Usa il metodo [Slide.getImage()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide) per ottenere la miniatura di ogni diapositiva.
4. Usa il metodo [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/#save) per salvare la miniatura della diapositiva in formato PNG.

Questo codice JavaScript mostra come convertire una presentazione PowerPoint in PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converti PowerPoint in PNG con Dimensioni Personalizzate**

Se desideri ottenere file PNG con una certa scala, puoi impostare i valori di `desiredX` e `desiredY`, che determinano le dimensioni della miniatura risultante. 

Questo codice in JavaScript dimostra l'operazione descritta:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converti PowerPoint in PNG con Dimensione Personalizzata**

Se desideri ottenere file PNG con una certa dimensione, puoi passare i parametri `width` e `height` preferiti per `ImageSize`. 

Questo codice mostra come convertire un PowerPoint in PNG specificando la dimensione delle immagini: 

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Come posso esportare solo una forma specifica (ad es., grafico o immagine) invece dell'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/nodejs-java/create-shape-thumbnails/); è possibile renderizzare una forma in un'immagine PNG.

**La conversione parallela è supportata su un server?**

Sì, ma [non condividere](/slides/it/nodejs-java/multithreading/) un'unica istanza di presentazione tra i thread. Usa un'istanza separata per thread o processo.

**Quali sono le limitazioni della versione di prova quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/nodejs-java/licensing/) fino a quando non viene applicata una licenza.