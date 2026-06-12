---
title: Renderizzare le diapositive di presentazione come immagini SVG in JavaScript
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- salva PPT come SVG
- salva PPTX come SVG
- esporta PPT in SVG
- esporta PPTX in SVG
- renderizza diapositiva
- converti diapositiva
- esporta diapositiva
- immagine vettoriale
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come renderizzare le diapositive PowerPoint come immagini SVG usando Aspose.Slides per Node.js via Java. Visuali di alta qualità con semplici esempi di codice JavaScript."
---
## **Panoramica**

Questo articolo spiega come renderizzare le diapositive di una presentazione come immagini SVG utilizzando Aspose.Slides. Descrive il formato SVG e i suoi vantaggi, inclusi scalabilità, accessibilità e idoneità per lo sviluppo web.

Imparerai come caricare un file di presentazione, iterare le sue diapositive e salvare ogni diapositiva come un file SVG separato. L’articolo copre i formati di presentazione PowerPoint e OpenDocument, inclusi PPT, PPTX, ODP e PPS, e mostra come eseguire la conversione programmaticamente con la classe `Presentation` e il metodo `writeAsSvg`.

## **Formato SVG**

SVG—acronimo di Scalable Vector Graphics—è un tipo o formato grafico standard usato per renderizzare immagini bidimensionali. SVG memorizza le immagini come vettori in XML con dettagli che ne definiscono il comportamento o l’aspetto.

SVG è uno dei pochi formati per immagini che soddisfa standard molto elevati in termini di: scalabilità, interattività, prestazioni, accessibilità, programmabilità e altri. Per questi motivi è comunemente usato nello sviluppo web.

Potresti voler usare file SVG quando hai bisogno di

- **stampa la tua presentazione in un *format molto grande*.** Le immagini SVG possono scalare a qualsiasi risoluzione o livello. Puoi ridimensionare le immagini SVG tutte le volte necessarie senza sacrificare la qualità.
- **usa grafici e diagrammi dalle tue diapositive in *diversi media o piattaforme*.** La maggior parte dei lettori può interpretare i file SVG. 
- **usa le *dimensioni più piccole possibili* delle immagini**. I file SVG sono generalmente più piccoli delle loro controparti ad alta risoluzione in altri formati, specialmente nei formati basati su bitmap (JPEG o PNG).

## **Renderizzare diapositive come immagini SVG**

Aspose.Slides per Node.js via Java ti permette di esportare le diapositive delle tue presentazioni come immagini SVG. Segui questi passaggi per generare immagini SVG:

1. Crea un'istanza della classe Presentation.
2. Itera attraverso tutte le diapositive della presentazione.
3. Scrivi ogni diapositiva in un proprio file SVG mediante FileOutputStream.

{{% alert color="primary" %}} 
Potresti provare la nostra [applicazione web gratuita](https://products.aspose.app/slides/it/conversion/ppt-to-svg) in cui abbiamo implementato la funzione di conversione da PPT a SVG di Aspose.Slides per Node.js via Java.
{{% /alert %}} 

Questo codice di esempio in JavaScript mostra come convertire PPT in SVG usando Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Perché l'SVG risultante potrebbe apparire differente tra i browser?**

Il supporto per specifiche funzionalità SVG è implementato diversamente dai motori dei browser. I parametri [SVGOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgoptions/) aiutano a uniformare le incompatibilità.

**È possibile esportare non solo le diapositive ma anche forme individuali in SVG?**

Sì. Qualsiasi [forma può essere salvata come SVG separato](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/), il che è comodo per icone, pittogrammi e riutilizzo di grafica.

**È possibile combinare più diapositive in un unico SVG (strip/document)?**

Lo scenario standard è una diapositiva → un SVG. Combinare più diapositive in un unico canvas SVG è un passaggio di post‑elaborazione eseguito a livello di applicazione.