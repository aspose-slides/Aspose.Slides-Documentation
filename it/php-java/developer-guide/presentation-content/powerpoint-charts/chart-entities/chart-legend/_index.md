---
title: Personalizza le legende dei grafici nelle presentazioni usando PHP
linktitle: Legenda del grafico
type: docs
url: /it/php-java/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per PHP via Java per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda e applicare la formattazione a una voce singola della legenda.

Copre inoltre diversi comportamenti correlati nella FAQ, incluso l'uso della modalità non sovrapposta in modo che l'area del grafico lasci spazio alla legenda, consentendo alle etichette lunghe della legenda di andare a capo o usare interruzioni di riga, e permettendo alla formattazione della legenda di ereditare dal tema della presentazione quando non vengono impostati esplicitamente testo e riempimento.

## **Posizionamento della legenda**
Per impostare le proprietà della legenda, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
- Ottieni il riferimento della diapositiva.
- Aggiungi un grafico alla diapositiva.
- Imposta le proprietà della legenda.
- Scrivi la presentazione in un file PPTX.

Nel esempio mostrato di seguito, abbiamo impostato la posizione e le dimensioni per la legenda del grafico.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Ottieni il riferimento della diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiungi un grafico a colonne raggruppate sulla diapositiva
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Imposta le proprietà della legenda
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Scrivi la presentazione su disco
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta la dimensione del carattere della legenda**
Aspose.Slides per PHP via Java consente agli sviluppatori di impostare la dimensione del carattere della legenda. Segui i passaggi seguenti:

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
- Crea il grafico predefinito.
- Imposta la dimensione del carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta la dimensione del carattere di una voce della legenda**
Aspose.Slides per PHP via Java consente agli sviluppatori di impostare la dimensione del carattere delle voci singole della legenda. Segui i passaggi seguenti:

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
- Crea il grafico predefinito.
- Accedi alla voce della legenda.
- Imposta la dimensione del carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso abilitare la legenda in modo che il grafico riservi automaticamente spazio per essa invece di sovrapporla?**

Sì. Usa la modalità non sovrapposta ([setOverlay(false)](https://reference.aspose.com/slides/it/php-java/aspose.slides/legend/setoverlay/)); in questo caso, l'area del grafico si ridurrà per accogliere la legenda.

**Posso creare etichette della legenda multilinea?**

Sì. Le etichette lunghe vanno a capo automaticamente quando lo spazio è insufficiente; le interruzioni di riga forzate sono supportate tramite caratteri di nuova linea nel nome della serie.

**Come posso fare in modo che la legenda segua lo schema colori del tema della presentazione?**

Non impostare colori/riempimenti/caratteri espliciti per la legenda o per il suo testo. In questo modo erediterà dal tema e si aggiornerà correttamente quando il design cambia.