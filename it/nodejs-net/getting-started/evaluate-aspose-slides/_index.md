---
title: Valuta Aspose.Slides
type: docs
weight: 120
url: /it/nodejs-net/evaluate-aspose-slides/
keywords:
- valuta Aspose.Slides
- versione di valutazione
- filigrana di valutazione
- limitazioni della versione di prova
- licenza temporanea
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Ciò che la versione di valutazione di Aspose.Slides per Node.js via .NET limita, con uno script che mostra entrambe le limitazioni e come rimuoverle con una licenza."
---
## **Panoramica**

La versione di valutazione di Aspose.Slides per Node.js via .NET è lo stesso pacchetto npm della versione con licenza. Senza licenza, funziona in modalità valutazione: tutte le funzionalità sono disponibili, ma le presentazioni salvate e la maggior parte delle esportazioni includono una filigrana, e il testo restituito dal tuo codice è troncato. Questo articolo descrive entrambe le limitazioni e mostra come rimuoverle.

## **Limitazioni della versione di valutazione**

**Una filigrana di valutazione su ogni diapositiva.** Quando salvi una presentazione senza licenza, Aspose.Slides aggiunge una casella di testo al centro di ogni diapositiva del file salvato. La casella di testo è bloccata e mostra "Evaluation only." seguito da una linea di prodotto e da una linea di copyright. La filigrana viene inserita nel file salvato, non nella presentazione in memoria, e l’apertura di una presentazione non ne aggiunge una. Un file salvato in modalità valutazione contiene già la casella di testo, quindi aprirlo e salvarlo nuovamente aggiunge una seconda filigrana a ciascuna diapositiva.

La stessa filigrana viene disegnata nell’output quando esporti in PDF, XPS o HTML, o quando rendi le diapositive come immagini. Se rendi una presentazione già salvata in modalità valutazione, l’immagine mostra sia la filigrana salvata sia quella renderizzata.

**Testo troncato quando il tuo codice lo legge.** Il testo che il tuo codice legge tramite la proprietà `text` di un frame di testo, paragrafo o porzione è tagliato ai primi cinque caratteri, seguito dall’avviso "... text has been truncated due to evaluation version limitation." Il testo di cinque caratteri o meno viene restituito per intero. Questo vale per ogni diapositiva, anche per il testo che il tuo codice ha appena assegnato. Le esportazioni in Markdown e HTML5 sono troncate allo stesso modo.

Il testo che il tuo codice scrive viene salvato per intero: i file PPTX, le pagine PDF e le immagini delle diapositive contengono il testo completo.

## **Visualizzare le limitazioni in uno script**

Lo script seguente mostra entrambe le limitazioni. Presuppone che il pacchetto sia installato come descritto in [Installazione](/slides/it/nodejs-net/installation/) e che lo esegui dalla cartella del progetto. Aggiunge un rettangolo con una frase alla prima diapositiva, legge la frase, salva la presentazione come `evaluation.pptx`, poi riapre il file per contare le forme nella diapositiva.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Senza una licenza, vengono restituiti solo i primi cinque caratteri.
    console.log("Text read back:", rectangle.textFrame.text);

    // Il salvataggio aggiunge la filigrana di valutazione a ogni diapositiva del file.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // La diapositiva ora contiene il rettangolo e la casella di testo della filigrana.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Senza licenza, lo script stampa:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

La seconda forma è la casella di testo della filigrana. Apri `evaluation.pptx` per vedere la frase completa nel rettangolo e la filigrana al centro della diapositiva.

## **Rimuovere le limitazioni**

Per rimuovere entrambe le limitazioni, applica una licenza prima di creare qualsiasi oggetto `Presentation`. [Licensing](/slides/it/nodejs-net/licensing/) mostra come applicare un file di licenza.

{{% alert color="success" title="Tip" %}}
Per testare Aspose.Slides senza le limitazioni di valutazione prima di acquistare, richiedi una **licenza temporanea gratuita di 30 giorni**. Vedi [Come ottenere una licenza temporanea?](https://purchase.aspose.com/temporary-license) per i dettagli.
{{% /alert %}}

## **FAQ**

**La modalità di valutazione limita il numero di diapositive?**

No. Le presentazioni vengono create, aperte e salvate con tutte le loro diapositive. La filigrana e il troncamento del testo si applicano a ogni diapositiva allo stesso modo.

**Perché le immagini delle diapositive esportate mostrano la filigrana due volte?**

La presentazione era stata salvata in modalità valutazione prima di essere renderizzata, quindi contiene già una casella di testo con filigrana, e il rendering senza licenza disegna un’altra filigrana sopra di essa.

**Posso verificare che il mio codice produca il testo corretto in modalità di valutazione?**

Sì. Apri il file salvato o il PDF esportato: contengono il testo completo. Solo il testo che il tuo codice legge indietro, e l'output Markdown o HTML5, sono troncati.