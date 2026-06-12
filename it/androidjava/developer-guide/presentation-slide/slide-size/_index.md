---
title: Cambia la dimensione della diapositiva della presentazione su Android
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
- diapositiva a grandezza piena
- tipo di schermo
- non scalare
- assicurare adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
descriptions: "Ridimensiona rapidamente le diapositive in file PPT, PPTX e ODP con Java e Aspose.Slides per Android, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa che per la visualizzazione su schermo. 

Dimensioni delle diapositive più comuni e rapporti:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.

Garantisci la coerenza in tutta la presentazione, poiché una singola dimensione della diapositiva e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni della diapositiva all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto standard 4:3.
{{% /alert %}}

## **Modifica la dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come cambiare la dimensione della diapositiva in una presentazione in Java usando Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specifica dimensioni diapositive personalizzate nelle presentazioni**

Se le dimensioni diapositive comuni (4:3 e 16:9) non sono adatte al tuo lavoro, potresti decidere di utilizzare una dimensione diapositive specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per Android tramite Java per specificare una dimensione diapositive personalizzata per una presentazione in Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Formato carta A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, i contenuti delle diapositive (immagini o oggetti, ad esempio) potrebbero distorcersi. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando si cambia la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti delle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una delle seguenti impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, utilizza questa impostazione.

- `EnsureFit`

  Se vuoi ridimensionare a una dimensione di diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti si adattino alle diapositive (in questo modo eviti di perdere contenuti), utilizza questa impostazione. 

- `Maximize`

  Se vuoi ridimensionare a una dimensione di diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, utilizza questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `Maximize` quando si cambia la dimensione della diapositiva di una presentazione:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso impostare una dimensione diapositive personalizzata usando unità diverse da pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto corrisponde a 1/72 di pollice. È possibile convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione diapositive personalizzata molto grande influenzerà le prestazioni e l'utilizzo della memoria durante il rendering?**

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più alta comportano un consumo di memoria maggiore e tempi di elaborazione più lunghi. Si consiglia di scegliere una dimensione pratica della diapositiva e di regolare la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione diapositive non standard e poi unire diapositive da presentazioni con dimensioni diverse?**

Non è possibile [merge presentations](/slides/it/androidjava/merge-presentation/) quando le presentazioni hanno dimensioni diapositive diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [entire slides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) così come per [selected shapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un'inquadratura e una geometria coerenti.