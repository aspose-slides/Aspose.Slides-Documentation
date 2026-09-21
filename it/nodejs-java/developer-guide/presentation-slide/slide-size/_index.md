---
title: Modifica la Dimensione della Diapositiva della Presentazione in JavaScript
linktitle: Dimensione Diapositiva
type: docs
weight: 70
url: /it/nodejs-java/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- schermo panoramico
- 4:3
- 16:9
- imposta dimensione diapositiva
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a dimensione intera
- tipo di schermo
- non scalare
- assicurare adattamento
- massimizza
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con Node.js e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, elementi critici sia per la stampa che per la visualizzazione su schermo. 

Dimensioni diapositive più comuni e rapporti:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.  
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.  

Assicurati che la presentazione mantenga coerenza, poiché una singola dimensione e rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione, evitando così complicazioni.

{{% alert color="info" title="Nota" %}}
Per impostazione predefinita, le presentazioni create con Aspose.Slides usano il rapporto standard 4:3.  
{{% /alert %}}

Le pagine note e le pagine per la distribuzione hanno dimensioni separate rispetto alle diapositive ordinarie. Vedi [Formato Pagina Note](/slides/it/nodejs-java/notes-size/) per modificare dimensioni e orientamento.

## **Modifica della Dimensione della Diapositiva nelle Presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione JavaScript usando Aspose.Slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Specificare Dimensioni Personalizzate della Diapositiva nelle Presentazioni**

Se le dimensioni comuni (4:3 e 16:9) non sono adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale su un layout di pagina personalizzato o se desideri visualizzare la presentazione su tipi di schermo particolari, potresti trarre vantaggio da una dimensione personalizzata per la presentazione. 

Questo esempio di codice mostra come usare Aspose.Slides per Node.js via Java per specificare una dimensione personalizzata della diapositiva in JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// Formato carta A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestire i Problemi Quando si Modifica la Dimensione delle Diapositive nelle Presentazioni**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, ad esempio) può risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione. Tuttavia, quando cambi la dimensione della diapositiva, puoi specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti delle diapositive.

A seconda di cosa intendi fare o ottenere, puoi usare una delle seguenti impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, utilizza questa impostazione.

- `EnsureFit`

  Se desideri ridimensionare a una diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti per garantire che tutti rientrino nella diapositiva (in questo modo eviti la perdita di contenuto), usa questa impostazione. 

- `Maximize`

  Se desideri aumentare la dimensione della diapositiva e hai bisogno che Aspose.Slides ingrandisca gli oggetti per mantenerli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come usare l'impostazione `Maximize` quando si cambia la dimensione della diapositiva di una presentazione:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso impostare una dimensione della diapositiva personalizzata usando unità diverse da pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza internamente i punti, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e usare i valori convertiti per definire larghezza e altezza della diapositiva.

**Una dimensione della diapositiva personalizzata molto grande influisce sulle prestazioni e sull'utilizzo della memoria durante il rendering?**

Sì. Dimensioni maggiori (in punti) combinate con una scala di rendering più alta aumentano il consumo di memoria e i tempi di elaborazione. Mira a una dimensione pratica della diapositiva e regola la scala di rendering solo quando necessario per ottenere la qualità desiderata.

**Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni con dimensioni diverse?**

Non è possibile [unire presentazioni](/slides/it/nodejs-java/merge-presentation/) quando hanno dimensioni diverse — prima ridimensiona una presentazione affinché corrisponda all'altra. Cambiando la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e queste rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [diapositive intere](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage) così come per [forme selezionate](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage). Le immagini risultanti riflettono la dimensione corrente della diapositiva e il rapporto d'aspetto, garantendo inquadrature e geometrie coerenti.