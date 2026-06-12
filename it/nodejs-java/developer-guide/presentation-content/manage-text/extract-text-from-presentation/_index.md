---
title: Estrazione avanzata del testo dalle presentazioni in JavaScript
linktitle: Estrai testo
type: docs
weight: 90
url: /it/nodejs-java/extract-text-from-presentation/
keywords:
- estrarre testo
- estrarre testo da diapositiva
- estrarre testo da presentazione
- estrarre testo da PowerPoint
- estrarre testo da OpenDocument
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- recuperare testo
- recuperare testo da diapositiva
- recuperare testo da presentazione
- recuperare testo da PowerPoint
- recuperare testo da OpenDocument
- recuperare testo da PPT
- recuperare testo da PPTX
- recuperare testo da ODP
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Estrai rapidamente il testo da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Node.js via Java. Segui la nostra semplice guida passo dopo passo per risparmiare tempo."
---
## **Panoramica**

L'estrazione del testo dalle presentazioni è un'operazione comune ma essenziale per gli sviluppatori che lavorano con i contenuti delle diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), l'accesso e il recupero dei dati testuali può essere fondamentale per analisi, automazione, indicizzazione o migrazione dei contenuti.

Questo articolo fornisce una guida completa su come estrarre in modo efficiente il testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides per Node.js tramite Java. Imparerai a iterare sistematicamente gli elementi della presentazione per recuperare con precisione il contenuto testuale di cui hai bisogno.

## **Estrarre testo da una diapositiva**

Aspose.Slides per Node.js tramite Java fornisce la classe [SlideUtil](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/) . Questa classe espone diversi metodi statici sovraccaricati per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre il testo da una diapositiva in una presentazione, utilizza il metodo [getAllTextBoxes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Questo metodo accetta un oggetto diapositiva come parametro. Quando viene eseguito, il metodo scansiona l'intera diapositiva alla ricerca di testo e restituisce un array di oggetti [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) , preservando qualsiasi formattazione del testo.

La seguente porzione di codice estrae tutto il testo dalla prima diapositiva della presentazione:

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

## **Estrarre testo da una presentazione**

Per scansionare il testo dell'intera presentazione, usa il metodo statico [getAllTextFrames](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/) . Accetta due parametri:

1. In primo luogo, un oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.  
1. In secondo luogo, un valore `boolean` che indica se le diapositive master devono essere incluse durante la scansione del testo della presentazione.

Il metodo restituisce un array di oggetti [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) , includendo informazioni sulla formattazione del testo. Il codice sottostante scansiona il testo e i dettagli di formattazione da una presentazione, includendo le diapositive master.

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

## **Estrazione testuale categorizzata e veloce**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

L'argomento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textextractionarrangingmode/) indica la modalità per organizzare il risultato dell'estrazione del testo e può essere impostato ai seguenti valori:
- `Unarranged` - Il testo grezzo senza considerare la sua posizione nella diapositiva.  
- `Arranged` - Il testo è disposto nello stesso ordine della diapositiva.

La modalità `Unarranged` può essere utilizzata quando la velocità è fondamentale; è più veloce della modalità `Arranged`.

[PresentationText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationtext/) rappresenta il testo grezzo estratto dalla presentazione. Il suo metodo `getSlidesText` restituisce un array di oggetti, ciascuno dei quali rappresenta il testo della diapositiva corrispondente. Ogni oggetto testo della diapositiva ha i seguenti metodi:

- Il suo metodo `getText` restituisce il testo contenuto nelle forme della diapositiva.  
- Il suo metodo `getMasterText` restituisce il testo contenuto nelle forme della diapositiva master associate a questa diapositiva.  
- Il suo metodo `getLayoutText` restituisce il testo contenuto nelle forme della diapositiva layout associate a questa diapositiva.  
- Il suo metodo `getNotesText` restituisce il testo contenuto nelle forme della diapositiva delle note associate a questa diapositiva.  
- Il suo metodo `getCommentsText` restituisce il testo contenuto nei commenti associati a questa diapositiva.

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

## **FAQ**

**Quanto velocemente Aspose.Slides elabora grandi presentazioni durante l'estrazione del testo?**

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [presentazioni di grandi dimensioni](/slides/it/nodejs-java/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o in batch.

**Aspose.Slides può estrarre testo da tabelle e grafici all'interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti correlati a grafici, così puoi accedere e analizzare il contenuto testuale nelle strutture di presentazione più comuni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

Puoi estrarre testo utilizzando la versione di prova gratuita di Aspose.Slides, sebbene presenti [alcune limitazioni](/slides/it/nodejs-java/licensing/), come l'elaborazione di un numero limitato di diapositive. Per un utilizzo senza restrizioni e per gestire presentazioni più grandi, è consigliato acquistare una licenza completa.