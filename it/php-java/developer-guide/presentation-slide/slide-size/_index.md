---
title: Modifica la dimensione della diapositiva della presentazione in PHP
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/php-java/slide-size/
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
- assicurare adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive in file PPT, PPTX e ODP con PHP e Aspose.Slides, ottimizzare le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare la dimensione e il rapporto d'aspetto delle diapositive nelle presentazioni PowerPoint, fondamentali sia per la stampa che per la visualizzazione su schermo.

Dimensioni e rapporti d'aspetto più comuni:

- **Standard (rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati che la presentazione mantenga coerenza: una singola dimensione e rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" title="Nota" %}}
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto 4:3 standard.
{{% /alert %}}

Le pagine delle note e dei fogli suggerimento hanno dimensioni separate dalle diapositive normali. Vedi [Dimensione pagina note](/slides/it/php-java/notes-size/) per modificare dimensione e orientamento.

## **Modificare la dimensione delle diapositive nelle presentazioni**

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

Se le dimensioni comuni delle diapositive (4:3 e 16:9) non sono adatte al tuo lavoro, puoi decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale da una presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, potresti trarre vantaggio dall'impostare una dimensione personalizzata.

Questo esempio di codice mostra come usare Aspose.Slides per PHP via Java per specificare una dimensione personalizzata della diapositiva in una presentazione:

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

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, ad esempio) può risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando cambi la dimensione della diapositiva di una presentazione, puoi specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti delle diapositive.

A seconda di ciò che desideri fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DoNotScale`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `EnsureFit`

  Se vuoi ridimensionare a una diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti per garantire che tutti si adattino alle diapositive (in questo modo eviti la perdita di contenuto), usa questa impostazione.

- `Maximize`

  Se vuoi ridimensionare a una diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti per renderli proporzionali alla nuova dimensione della diapositiva, usa questa impostazione.

Questo esempio di codice mostra come usare l'impostazione `Maximize` quando si cambia la dimensione della diapositiva di una presentazione:

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

**Posso impostare una dimensione personalizzata della diapositiva usando unità diverse dagli pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e usare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione personalizzata molto grande influisce sulle prestazioni e sull'uso della memoria durante il rendering?**

Sì. Dimensioni di diapositiva più grandi (in punti) combinate con una scala di rendering più alta comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Punta a una dimensione pratica della diapositiva e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione non standard e poi unire diapositive da presentazioni con dimensioni diverse?**

Non puoi [unire presentazioni](/slides/it/php-java/merge-presentation/) mentre hanno dimensioni di diapositiva diverse — prima ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive mantenendo la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [intere diapositive](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) così come per [forme selezionate](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto corrente della diapositiva, garantendo inquadrature e geometrie coerenti.