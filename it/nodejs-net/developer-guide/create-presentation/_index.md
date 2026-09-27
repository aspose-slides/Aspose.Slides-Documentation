---
title: Creare presentazioni in Node.js via .NET
linktitle: Creare presentazione
type: docs
weight: 10
url: /it/nodejs-net/create-presentation/
keywords:
- creare presentazione
- nuova presentazione
- creare PowerPoint
- creare PPTX
- aggiungere casella di testo
- aggiungere diapositiva
- dimensione diapositiva
- widescreen
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea presentazioni PowerPoint in JavaScript con Aspose.Slides per Node.js via .NET: aggiungi una casella di testo e diapositive, imposta una dimensione diapositiva 16:9 e salva il risultato come PPTX."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione con Aspose.Slides for Node.js via .NET, aggiungere una casella di testo alla sua prima diapositiva e salvare il risultato come file PPTX. Mostra anche come aggiungere altre diapositive e come passare la presentazione a diapositive widescreen (16:9).

Gli esempi richiedono un progetto configurato come descritto in [Installation](/slides/it/nodejs-net/installation/). Salva ogni esempio come file `.js` nella cartella del progetto ed eseguilo da quella cartella con `node`, ad esempio `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides per Node.js via .NET non dispone di una propria documentazione API. Rispecchia l'API di Aspose.Slides per .NET con nomi camelCase, quindi i collegamenti API in questo articolo puntano alle classi e ai membri corrispondenti nella [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/it/net/).
{{% /alert %}}

## **Creare una presentazione con una casella di testo**

Per creare una presentazione e inserire una casella di testo nella sua prima diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Una nuova presentazione contiene già una diapositiva vuota.
2. Recupera quella diapositiva dalla collezione [slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/). Le collezioni in questo pacchetto si leggono con `get(index)`, e gli indici partono da 0.
3. Aggiungi un rettangolo con il metodo [addAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/shapecollection/addautoshape/) e imposta il [text](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/text/) del suo [textFrame](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/textframe/).
4. Salva la presentazione con il metodo [save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) e il valore `SaveFormat.Pptx`.
5. Chiama `dispose` in un blocco `finally` per rilasciare le risorse .NET che supportano la presentazione.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La posizione (x, y) e le dimensioni (larghezza, altezza) sono in punti.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Lo script scrive `new-presentation.pptx` nella cartella del progetto. Il file contiene una diapositiva con un rettangolo riempito il cui angolo superiore sinistro è a 50 punti dal bordo sinistro e superiore della diapositiva. Il rettangolo è largo 400 punti e alto 100 punti, e il suo testo è centrato. Un punto corrisponde a 1/72 di pollice. Senza una licenza, Aspose.Slides aggiunge anche una filigrana di valutazione alla diapositiva; vedi [Licensing](/slides/it/nodejs-net/licensing/).

## **Aggiungere diapositive**

Una nuova presentazione contiene una diapositiva. Per aggiungerne altre, passa una diapositiva di layout al metodo [addEmptySlide](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/addemptyslide/) della collezione `slides`. Il metodo [getByType](https://reference.aspose.com/slides/it/net/aspose.slides/layoutslidecollection/getbytype/) della collezione [layoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/layoutslides/) restituisce il primo layout di un determinato [SlideLayoutType](https://reference.aspose.com/slides/it/net/aspose.slides/slidelayouttype/).

Il seguente esempio aggiunge due diapositive con il layout Blank:

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

Lo script stampa `Slide count: 3` e scrive `three-slides.pptx`. Le nuove diapositive sono aggiunte dopo la prima e non contengono forme. Una nuova presentazione ha sempre un layout Blank, ma una presentazione aperta da un file potrebbe non avere un layout del tipo richiesto; in tal caso `getByType` restituisce `null`, quindi verifica il risultato prima di usarlo.

## **Impostare la dimensione della diapositiva**

Una nuova presentazione utilizza diapositive 4:3 che sono 720 × 540 punti (10 × 7,5 pollici). Per creare diapositive widescreen, chiama il metodo [setSize](https://reference.aspose.com/slides/it/net/aspose.slides/slidesize/setsize/) della [slideSize](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slidesize/) della presentazione con un valore [SlideSizeType](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizetype/) e un valore [SlideSizeScaleType](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/). Il tipo di scala indica ad Aspose.Slides cosa fare con le forme già presenti sulle diapositive; `DoNotScale` le lascia così come sono, scelta corretta per una presentazione che non ha ancora contenuti.

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

Lo script stampa `Slide size: 960 x 540 points`, che corrisponde a 13,33 × 7,5 pollici, e scrive `widescreen.pptx`. `SlideSizeType.OnScreen16x9` ha lo stesso rapporto d'aspetto 16:9 ma è più piccolo: 720 × 405 punti.

## **FAQ**

**In quali unità vengono misurate posizioni e dimensioni?**

In punti. Un pollice è 72 punti, quindi la diapositiva predefinita 4:3 è 720 × 540 punti, e una diapositiva widescreen 16:9 è 960 × 540 punti.

**In quali formati posso salvare una nuova presentazione?**

Qualsiasi valore dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/), ad esempio `SaveFormat.Ppt` per PowerPoint 97–2003, `SaveFormat.Odp` per OpenDocument, o `SaveFormat.Pdf`. Per l'output PDF, vedi [Convert PowerPoint to PDF](/slides/it/nodejs-net/convert-powerpoint-to-pdf/).

**Perché la presentazione salvata contiene il testo "Evaluation only"?**

Senza una licenza, Aspose.Slides aggiunge una filigrana di valutazione alle diapositive salvate. Applica una licenza come descritto in [Licensing](/slides/it/nodejs-net/licensing/) per rimuoverla.

**Perché dovrei chiamare `dispose`?**

Un oggetto `Presentation` è supportato da un oggetto .NET che occupa memoria e altre risorse. Chiamare `dispose` le rilascia non appena non hai più bisogno della presentazione, e chiamarlo in un blocco `finally` le rilascia anche in caso di errore.