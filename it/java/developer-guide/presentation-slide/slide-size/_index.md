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
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a dimensione intera
- tipo di schermo
- non scalare
- assicurare adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con Java e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare la dimensione delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, critici sia per la stampa che per la visualizzazione su schermo. 

Dimensioni diapositive popolari e rapporti:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.  
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.  

Assicurati la coerenza in tutta la presentazione, poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3. 
{{% /alert %}}

## **Modificare la dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione in Java usando Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specificare dimensioni diapositive personalizzate nelle presentazioni**

Se trovi le dimensioni diapositive comuni (4:3 e 16:9) inadeguate per il tuo lavoro, potresti decidere di usare una dimensione di diapositiva specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la tua presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per Java per specificare una dimensione di diapositiva personalizzata per una presentazione in Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Formato carta A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestire il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva per una presentazione, i contenuti delle diapositive (immagini o oggetti, ad esempio) possono distorcersi. Per impostazione predefinita, gli oggetti vengono automaticamente ridimensionati per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando si cambia la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se desideri ridimensionare a una diapositiva più piccola e necessiti che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti si adattino (in questo modo eviti di perdere contenuti), usa questa impostazione. 

- `Maximize`

  Se desideri ridimensionare a una diapositiva più grande e necessiti che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `Maximize` quando si cambia la dimensione della diapositiva di una presentazione:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Posso impostare una dimensione diapositive personalizzata utilizzando unità diverse da pollici (ad esempio punti o millimetri)?

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto corrisponde a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

### Una dimensione diapositive personalizzata molto grande influenzerà le prestazioni e l'utilizzo della memoria durante il rendering?

Sì. Dimensioni diapositive più grandi (in punti) combinate con una scala di rendering più alta portano a un maggiore consumo di memoria e a tempi di elaborazione più lunghi. Puntare a una dimensione di diapositiva praticabile e regolare la scala di rendering solo se necessario per ottenere la qualità di output desiderata.

### Posso definire una dimensione diapositive non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?

Non è possibile [unire presentazioni](/slides/it/java/merge-presentation/) quando hanno dimensioni diapositive diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

### Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?

Sì. Aspose.Slides può generare miniature per [tutte le diapositive](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) così come per [forme selezionate](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo inquadrature e geometrie coerenti.