---
title: Gestire il testo della presentazione in Node.js via .NET
linktitle: Gestire il testo
type: docs
weight: 50
url: /it/nodejs-net/manage-text/
keywords:
- testo
- casella di testo
- aggiungere testo
- modificare testo
- formattare testo
- dimensione carattere
- testo in grassetto
- riquadro di testo
- paragrafo
- porzione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Aggiungi una casella di testo a una diapositiva, poi modifica il suo testo, la dimensione del carattere e lo stile grassetto in JavaScript con Aspose.Slides per Node.js via .NET."
---
## **Panoramica**

In Aspose.Slides, il testo su una diapositiva appartiene a una forma. Un'autoshape, come un rettangolo, ha un riquadro di testo; il riquadro contiene paragrafi e ogni paragrafo contiene porzioni, che sono sequenze di testo con la stessa formattazione. Si modifica il testo tramite il riquadro di testo e il carattere tramite il formato di una porzione.

Questo articolo aggiunge una casella di testo a una diapositiva e salva la presentazione. Successivamente apre il file salvato e modifica il testo della casella, la dimensione del carattere e lo stile grassetto.

Gli esempi richiedono un progetto configurato come descritto in [Installazione](/slides/it/nodejs-net/installation/). Salva ciascun esempio come file `.js` nella cartella del progetto ed eseguilo da quella cartella con `node`.

{{% alert color="info" title="Nota" %}}
Aspose.Slides per Node.js via .NET non ha una propria documentazione API. Rispecchia l'API Aspose.Slides per .NET con nomi camelCase, quindi i collegamenti API in questo articolo rimandano alle classi e ai membri corrispondenti nella [riferimento API Aspose.Slides per .NET](https://reference.aspose.com/slides/it/net/).
{{% /alert %}}

## **Aggiungere una casella di testo**

Per aggiungere una casella di testo, aggiungi un'autoshape a una diapositiva con il metodo [addAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/shapecollection/addautoshape/) e fornisci del testo con il metodo [addTextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/addtextframe/). L'esempio seguente aggiunge un rettangolo alla prima diapositiva di una nuova presentazione e salva la presentazione come `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La posizione (x, y) e le dimensioni (larghezza, altezza) sono in punti.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

La diapositiva in `text-box.pptx` contiene un rettangolo largo 500 punti e alto 80 punti, con il testo "Quarterly report" nel carattere e nella dimensione predefiniti. L'esempio successivo modifica questa casella di testo.

## **Modificare il testo e la sua formattazione**

L'esempio seguente apre `text-box.pptx`, creato dall'esempio precedente, e ottiene la prima forma nella prima diapositiva. Forme come immagini e tabelle non hanno un riquadro di testo, quindi l'esempio verifica che la forma sia un'[AutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/)' prima di utilizzare il [textFrame](https://reference.aspose.com/slides/it/net/aspose.slides/autoshape/textframe/) della forma. Poi esegue quanto segue:

1. Sostituisce il testo tramite la proprietà [text](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/text/) del riquadro di testo. Dopo ciò, il riquadro contiene un paragrafo con una porzione.
1. Recupera quella porzione dalle collezioni [paragraphs](https://reference.aspose.com/slides/it/net/aspose.slides/textframe/paragraphs/) e [portions](https://reference.aspose.com/slides/it/net/aspose.slides/paragraph/portions/) e legge il suo [portionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/portion/portionformat/).
1. Imposta [fontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/fontheight/), la dimensione del carattere in punti, e [fontBold](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/fontbold/), che accetta un valore [NullableBool](https://reference.aspose.com/slides/it/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

In `text-box-updated.pptx`, la casella di testo mostra "Quarterly report: third quarter" in grassetto di 32 punti. Poiché il nuovo testo è una singola porzione, le due proprietà di formattazione si applicano a tutto il testo. Senza licenza, ogni salvataggio aggiunge una filigrana di valutazione. Poiché `text-box.pptx` è stato salvato in modalità valutazione, `text-box-updated.pptx` ne contiene due; vedi [Valutare Aspose.Slides](/slides/it/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Perché `fontBold` accetta un valore `NullableBool` anziché `true` o `false`?**

Una porzione può lasciare una proprietà non definita e ereditarla dal paragrafo, dalla forma o dal layout e master della diapositiva. `NullableBool.NotDefined` significa "eredita", mentre `NullableBool.True` e `NullableBool.False` sovrascrivono il valore ereditato. Assegnare `true` o `false` genera un errore. Per lo stesso motivo, `fontHeight` restituisce `NaN` quando la porzione eredita la sua dimensione del carattere.

**Come modifico il colore del testo?**

Imposta il riempimento del formato della porzione: assegna `FillType.Solid` a `portionFormat.fillFormat.fillType`, quindi assegna un colore come `"#FF0000"` a `portionFormat.fillFormat.solidFillColor.color`. Aggiungi `FillType` ai nomi che importi dal pacchetto.

**Come formattare solo una parte del testo?**

La formattazione appartiene alle porzioni, quindi inserisci quella parte del testo in una propria porzione. Crea la porzione con `Portion.CreatePortionFromText`, aggiungila a un paragrafo con il metodo `add` della collezione `portions` del paragrafo, quindi imposta il `portionFormat` della nuova porzione. Aggiungi `Portion` ai nomi che importi dal pacchetto.

**Perché la lettura del testo restituisce "... text has been truncated due to evaluation version limitation"?**

Senza licenza, Aspose.Slides restituisce solo i primi cinque caratteri di qualsiasi testo più lungo che leggi, ad esempio `textFrame.text`, seguito da questo avviso. Il testo che scrivi viene salvato per intero. Applica una licenza come descritto nella [Licenza](/slides/it/nodejs-net/licensing/) per leggere il testo completo.