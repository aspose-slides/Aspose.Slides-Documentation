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
- widescreen
- 4:3
- 16:9
- impostare dimensione diapositiva
- modificare dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a grandezza naturale
- tipo di schermo
- non ridimensionare
- garantire adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive in file PPT, PPTX e ODP con Java e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare la dimensione della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentale sia per la stampa sia per la visualizzazione su schermo. 

Dimensioni e rapporti d'aspetto delle diapositive più comuni:

- **Standard (rapporto d'aspetto 4:3)**: Ideale per schermi e dispositivi più datati.
- **Widescreen (rapporto d'aspetto 16:9)**: Consigliato per proiettori e display moderni.

Assicura coerenza in tutta la presentazione poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3.
{{% /alert %}}

## **Modifica la dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione Java utilizzando Aspose.Slides:

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

Se trovi che le dimensioni comuni delle diapositive (4:3 e 16:9) non siano adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato oppure di visualizzare la presentazione su particolari tipi di schermo, è probabile che tu tragga vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per Java per specificare una dimensione personalizzata della diapositiva per una presentazione in Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Formato carta A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestisci il contenuto delle diapositive dopo il ridimensionamento**

Dopo aver cambiato la dimensione della diapositiva in una presentazione, il contenuto delle diapositive (ad esempio immagini o oggetti) può deformarsi. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, modificando la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti delle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti nelle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se desideri ridimensionare a una diapositiva più piccola e vuoi che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti si adattino alle diapositive (così eviti la perdita di contenuto), usa questa impostazione. 

- `Maximize`

  Se desideri ingrandire a una diapositiva più grande e vuoi che Aspose.Slides aumenti le dimensioni degli oggetti delle diapositive per renderli proporzionali alla nuova dimensione della diapositiva, usa questa impostazione. 

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

**Posso impostare una dimensione personalizzata della diapositiva usando unità diverse dal pollice (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto corrisponde a 1/72 di pollice. È possibile convertire qualsiasi unità (ad esempio millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione personalizzata della diapositiva molto grande influirà sulle prestazioni e sull'utilizzo della memoria durante il rendering?**

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più alta comportano un maggiore consumo di memoria e tempi di elaborazione più lunghi. Mira a una dimensione della diapositiva praticabile e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?**

Non è possibile [unire le presentazioni](/slides/it/java/merge-presentation/) quando hanno dimensioni della diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [diapositive intere](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) così come per [forme selezionate](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un inquadramento e una geometria coerenti.