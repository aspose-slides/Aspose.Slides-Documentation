---
title: Personalizza le barre di errore nei grafici di presentazione usando PHP
linktitle: Barra di errore
type: docs
url: /it/php-java/error-bar/
keywords:
- barra di errore
- valore personalizzato
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come aggiungere e personalizzare le barre di errore nei grafici con Aspose.Slides per PHP via Java — ottimizza le visualizzazioni dei dati nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con le barre di errore nei grafici di presentazione utilizzando Aspose.Slides. Mostra come aggiungere barre di errore a una serie di grafico, configurare le impostazioni delle barre di errore X e Y e applicare diversi tipi di valore come fisso, percentuale e valori personalizzati.

Dimostra inoltre come assegnare valori di barra di errore personalizzati per i punti dati individuali in una serie utilizzando la relativa collezione di punti dati. Inoltre, l'articolo include brevi note su come le barre di errore si comportano durante l'esportazione, la loro compatibilità con i marcatori e le etichette dati, e dove trovare le classi e gli enum di riferimento dell'API correlati.

## **Aggiungi barre di errore**
Aspose.Slides for PHP via Java fornisce un'API semplice per gestire i valori delle barre di errore. Il codice di esempio si applica quando si utilizza un tipo di valore personalizzato. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dato specifico nella [**punti dati**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriescollection/) della serie:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Aggiungere un grafico a bolle nella diapositiva desiderata.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore X.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore Y.
1. Impostare i valori e il formato delle barre.
1. Scrivere la presentazione modificata in un file PPTX.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Crea un grafico a bolle
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Aggiunta delle barre di errore e impostazione del loro formato
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Salvataggio della presentazione
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungi valori personalizzati per le barre di errore**
Aspose.Slides for PHP via Java fornisce un'API semplice per gestire i valori personalizzati delle barre di errore. Il codice di esempio si applica quando il metodo [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/it/php-java/aspose.slides/errorbarsformat/#getValueType) restituisce **Custom**. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dato specifico nella [**punti dati**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriescollection/) della serie:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Aggiungere un grafico a bolle nella diapositiva desiderata.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore X.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore Y.
1. Accedere ai singoli punti dati della serie del grafico e impostare i valori della barra di errore per ciascun punto dati della serie.
1. Impostare i valori e il formato delle barre.
1. Scrivere la presentazione modificata in un file PPTX.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Creazione di un grafico a bolle
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Aggiunta di barre di errore personalizzate e impostazione del loro formato
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Accesso al punto dati della serie del grafico e impostazione dei valori delle barre di errore per
    # punto individuale
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Impostazione delle barre di errore per i punti della serie del grafico
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Salvataggio della presentazione
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Cosa succede alle barre di errore durante l'esportazione di una presentazione in PDF o immagini?**

Vengono renderizzate come parte del grafico e preservate durante la conversione insieme al resto della formattazione del grafico, supponendo una versione o un renderer compatibili.

**Le barre di errore possono essere combinate con marcatori e etichette dati?**

Sì. Le barre di errore sono un elemento separato e sono compatibili con marcatori e etichette dati; se gli elementi si sovrappongono, potrebbe essere necessario regolare la formattazione.

**Dove posso trovare l'elenco delle proprietà e delle classi per lavorare con le barre di errore nell'API?**

Nella documentazione dell'API: la classe [ErrorBarsFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/errorbarsformat/) e le classi correlate [ErrorBarType](https://reference.aspose.com/slides/it/php-java/aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/it/php-java/aspose.slides/errorbarvaluetype/).