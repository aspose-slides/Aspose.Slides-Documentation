---
title: Modifica le dimensioni della diapositiva della presentazione in PHP
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/php-java/slide-size/
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
- diapositiva a piena dimensione
- tipo di schermo
- non scalare
- garantire adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con PHP e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni delle diapositive e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa sia per la visualizzazione a schermo.

Dimensioni e rapporti d'aspetto più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.  
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.

Garantisci coerenza in tutta la presentazione, poiché una singola dimensione e rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione, evitando così complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3.  
{{% /alert %}}

## **Modificare la dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione usando Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Specificare dimensioni personalizzate delle diapositive nelle presentazioni**

Se le dimensioni comuni (4:3 e 16:9) non sono adatte al tuo lavoro, puoi decidere di utilizzare una dimensione di diapositiva specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale da una presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su tipi di schermo particolari, potresti trarre vantaggio dall'impostare una dimensione personalizzata per la tua presentazione.

Questo esempio di codice mostra come utilizzare Aspose.Slides per PHP via Java per specificare una dimensione personalizzata della diapositiva per una presentazione:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// Formato carta A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gestire il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, ad esempio) può risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, modificando la dimensione della diapositiva, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce il contenuto delle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi usare una delle seguenti impostazioni:

- `DoNotScale`

  Se NON desideri che gli oggetti sulle diapositive vengano ridimensionati, utilizza questa impostazione.

- `EnsureFit`

  Se vuoi ridimensionare a una diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti per garantire che tutti entrino nella diapositiva (evitando la perdita di contenuto), utilizza questa impostazione.

- `Maximize`

  Se vuoi ridimensionare a una diapositiva più grande e desideri che Aspose.Slides ingrandisca gli oggetti per renderli proporzionali alla nuova dimensione, utilizza questa impostazione.

Questo esempio di codice mostra come usare l'impostazione `Maximize` quando si modifica la dimensione della diapositiva di una presentazione:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso impostare una dimensione personalizzata della diapositiva usando unità diverse da pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e usare i valori convertiti per definire larghezza e altezza della diapositiva.

**Una dimensione di diapositiva personalizzata molto grande influisce sulle prestazioni e sull'uso della memoria durante il rendering?**

Sì. Dimensioni maggiori (in punti) combinate con una scala di rendering più alta aumentano il consumo di memoria e i tempi di elaborazione. È consigliabile scegliere una dimensione pratica della diapositiva e regolare la scala di rendering solo quando necessario per ottenere la qualità desiderata.

**Posso definire una dimensione di diapositiva non standard e poi unire diapositive da presentazioni con dimensioni diverse?**

Non è possibile [unire presentazioni](/slides/it/php-java/merge-presentation/) quando hanno dimensioni di diapositiva diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive conservando la formattazione.

**Posso generare miniature per singole forme o regioni specifiche di una diapositiva, e rispettano la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [intere diapositive](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) così come per [forme selezionate](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto corrente della diapositiva, garantendo un inquadramento e una geometria coerenti.