---
title: Modifica la dimensione della diapositiva della presentazione in JavaScript
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/nodejs-java/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- widescreen
- 4:3
- 16:9
- imposta dimensione diapositiva
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a dimensione piena
- tipo di schermo
- non ridimensionare
- garantire adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Scopri come ridimensionare rapidamente le diapositive in file PPT, PPTX e ODP con Node.js e Aspose.Slides, ottimizzare le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa che per la visualizzazione su schermo.  

Dimensioni e rapporti d'aspetto delle diapositive più comuni:

- **Standard (rapporto d'aspetto 4:3)**: Ideale per schermi e dispositivi più datati.  
- **Widescreen (rapporto d'aspetto 16:9)**: Consigliato per proiettori e display moderni.  

Assicurati che la tua presentazione mantenga la coerenza, poiché un'unica dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3.
{{% /alert %}}

## **Modifica delle dimensioni della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare le dimensioni della diapositiva in una presentazione in JavaScript utilizzando Aspose.Slides:

```javascript
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

## **Specificare dimensioni personalizzate della diapositiva nelle presentazioni**

Se le dimensioni comuni delle diapositive (4:3 e 16:9) non sono adatte al tuo lavoro, potresti decidere di utilizzare una dimensione della diapositiva specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza reale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la tua presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione.  

Questo esempio di codice mostra come utilizzare Aspose.Slides per Node.js tramite Java per specificare una dimensione personalizzata della diapositiva per una presentazione in JavaScript:

```javascript
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

## **Gestire i problemi quando si modifica la dimensione delle diapositive nelle presentazioni**

Dopo aver modificato la dimensione della diapositiva per una presentazione, i contenuti delle diapositive (ad esempio immagini o oggetti) potrebbero deformarsi. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando si modifica la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti delle diapositive.  

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se desideri ridimensionare a una diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti si adattino (in questo modo eviti di perdere contenuti), usa questa impostazione.

- `Maximize`

  Se desideri aumentare la dimensione della diapositiva e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione.

Questo esempio di codice mostra come utilizzare l'impostazione `Maximize` quando si modifica la dimensione della diapositiva di una presentazione:

```javascript
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

**Posso impostare una dimensione personalizzata della diapositiva usando unità diverse da pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto corrisponde a 1/72 di pollice. È possibile convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione personalizzata della diapositiva molto grande influirà sulle prestazioni e sull'utilizzo della memoria durante il rendering?**

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più elevata comportano un maggiore consumo di memoria e tempi di elaborazione più lunghi. Punta a una dimensione della diapositiva pratica e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?**

Non è possibile [unire le presentazioni](/slides/it/nodejs-java/merge-presentation/) quando hanno dimensioni di diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire i contenuti esistenti tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e queste rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [intere diapositive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage) così come per [forme selezionate](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un'inquadratura e una geometria coerenti.