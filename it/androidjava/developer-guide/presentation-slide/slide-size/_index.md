---
title: Modifica la dimensione delle diapositive della presentazione su Android
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/androidjava/slide-size/
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
- diapositiva a grandezza intera
- tipo di schermo
- non scalare
- garantire adattamento
- massimizza
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Ridimensiona rapidamente le diapositive nei file PPT, PPTX e ODP con Java e Aspose.Slides per Android, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa che per la visualizzazione su schermo.  

Dimensioni e rapporti d'aspetto delle diapositive più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.  
- **Widescreen (rapporto 16:9)**: Raccomandato per proiettori e display moderni.  

Assicurati della coerenza in tutta la presentazione, poiché un'unica dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.  

{{% alert color="info" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto standard 4:3.
{{% /alert %}}

## **Modifica le dimensioni della diapositiva nelle presentazioni**

Questo codice di esempio mostra come modificare le dimensioni della diapositiva in una presentazione in Java utilizzando Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specifica dimensioni personalizzate della diapositiva nelle presentazioni**

Se trovi le dimensioni comuni delle diapositive (4:3 e 16:9) inadeguate per il tuo lavoro, puoi decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su alcuni tipi di schermo, è probabile che tu tragga vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione.  

Questo codice di esempio mostra come utilizzare Aspose.Slides per Android tramite Java per specificare una dimensione personalizzata della diapositiva per una presentazione in Java:

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

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato le dimensioni della diapositiva di una presentazione, i contenuti delle diapositive (immagini o oggetti, ad esempio) possono diventare distorti. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, cambiando le dimensioni della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.  

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`  
  Se NON desideri che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.  

- `EnsureFit`  
  Se vuoi ridimensionare a una diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per assicurarsi che tutti rientrino nelle diapositive (in questo modo eviti di perdere contenuti), usa questa impostazione.  

- `Maximize`  
  Se vuoi ridimensionare a una diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione.  

Questo codice di esempio mostra come utilizzare l'impostazione `Maximize` quando si modifica la dimensione della diapositiva di una presentazione:

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

### Posso impostare una dimensione personalizzata della diapositiva usando unità diverse da pollici (ad esempio punti o millimetri)?

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.  

### Una dimensione personalizzata molto grande influenzerà le prestazioni e l'utilizzo della memoria durante il rendering?

Sì. Dimensioni più grandi delle diapositive (in punti) combinate con una scala di rendering più elevata aumentano il consumo di memoria e i tempi di elaborazione. Mira a una dimensione pratica della diapositiva e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.  

### Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?

Non puoi [unire presentazioni](/slides/it/androidjava/merge-presentation/) mentre hanno dimensioni di diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Cambiando le dimensioni della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.  

### Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?

Sì. Aspose.Slides può generare miniature per [diapositive intere](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) così come per [forme selezionate](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un inquadramento e una geometria coerenti.