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
- diapositiva a grandezza intera
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
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con Node.js e Aspose.Slides, ottimizzare le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides offre strumenti completi per regolare la dimensione della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa sia per la visualizzazione su schermo. 

Dimensioni e rapporti d'aspetto più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi. 
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni. 

Assicurati la coerenza in tutta la presentazione poiché una singola dimensione di diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides usano il rapporto 4:3 standard.
{{% /alert %}}

## **Modifica della dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione in JavaScript usando Aspose.Slides:

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

## **Specificare dimensioni diapositive personalizzate nelle presentazioni**

Se le dimensioni diapositive comuni (4:3 e 16:9) non sono adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, potresti trarre beneficio dall'uso di un'impostazione di dimensione personalizzata per la tua presentazione. 

Questo esempio di codice mostra come usare Aspose.Slides per Node.js via Java per specificare una dimensione diapositive personalizzata per una presentazione in JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// formato carta A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestione dei problemi quando si modifica la dimensione delle diapositive nelle presentazioni**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, ad esempio) può diventare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, modificando la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON desideri che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se vuoi ridimensionare a una diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti rientrino (in questo modo eviti la perdita di contenuti), usa questa impostazione. 

- `Maximize`

  Se vuoi ridimensionare a una diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come usare l'impostazione `Maximize` quando si modifica la dimensione della diapositiva di una presentazione:

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

**Posso impostare una dimensione diapositive personalizzata usando unità diverse dagli pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza internamente i punti, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione diapositive personalizzata molto grande influisce sulle prestazioni e sull'uso della memoria durante il rendering?**

Sì. Dimensioni diapositive più grandi (in punti) combinate con una scala di rendering più alta comportano un maggiore consumo di memoria e tempi di elaborazione più lunghi. Punta a una dimensione diapositive pratica e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione diapositive non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?**

Non è possibile [merge presentations](/slides/it/nodejs-java/merge-presentation/) quando hanno dimensioni diapositive diverse — prima, ridimensiona una presentazione per farla coincidere con l'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione di diapositiva?**

Sì. Aspose.Slides può renderizzare miniature per [diapositive intere](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getImage) così come per [forme selezionate](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un'inquadratura e una geometria coerenti.