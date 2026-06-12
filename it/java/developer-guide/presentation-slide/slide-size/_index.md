---
title: Modifica la dimensione della diapositiva della presentazione in Java
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/java/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- schermo panoramico
- 4:3
- 16:9
- imposta dimensione diapositiva
- modifica dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a dimensione completa
- tipo di schermo
- non ridimensionare
- assicurare adattamento
- massimizza
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
descriptions: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con Java e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa sia per la visualizzazione su schermo. 

Dimensioni e rapporti d'aspetto delle diapositive più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati che la coerenza sia mantenuta in tutta la presentazione poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto standard 4:3. 
{{% /alert %}}

## **Modifica le dimensioni della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare le dimensioni della diapositiva in una presentazione Java utilizzando Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specifica dimensioni personalizzate delle diapositive nelle presentazioni**

Se le dimensioni comuni delle diapositive (4:3 e 16:9) non sono adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Per esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per Java per specificare una dimensione personalizzata della diapositiva per una presentazione in Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // formato carta A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato le dimensioni della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, ad esempio) può risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, modificando le dimensioni della diapositiva, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON desideri che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se desideri ridimensionare a una dimensione di diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti rientrino nella diapositiva (in questo modo eviti di perdere contenuti), usa questa impostazione. 

- `Maximize`

  Se desideri ridimensionare a una dimensione di diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `Maximize` quando si modifica la dimensione della diapositiva di una presentazione:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso impostare una dimensione di diapositiva personalizzata utilizzando unità diverse da pollici (ad esempio, punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto corrisponde a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e usare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione di diapositiva personalizzata molto grande influenzerà le prestazioni e l'utilizzo della memoria durante il rendering?**

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più elevata comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Punta a una dimensione di diapositiva pratica e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione di diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?**

Non è possibile [unire le presentazioni](/slides/it/java/merge-presentation/) quando hanno dimensioni di diapositiva differenti — prima, ridimensiona una presentazione per farla corrispondere all'altra. Modificando la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispettano la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [intere diapositive](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) così come per [forme selezionate](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo inquadrature e geometrie coerenti.