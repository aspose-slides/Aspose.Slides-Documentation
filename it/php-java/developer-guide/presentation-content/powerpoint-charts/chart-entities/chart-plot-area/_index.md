---
title: Personalizza le aree tracciate dei grafici di presentazione in PHP
linktitle: Area Tracciata
type: docs
url: /it/php-java/chart-plot-area/
keywords:
- grafico
- area tracciata
- larghezza area tracciata
- altezza area tracciata
- dimensione area tracciata
- modalità di layout
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come personalizzare le aree tracciate dei grafici nelle presentazioni PowerPoint con Aspose.Slides per PHP via Java. Migliora l'aspetto delle tue diapositive senza sforzo."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area tracciata di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area tracciata convalidando il layout del grafico e poi leggendo i valori X, Y, larghezza e altezza.

Mostra anche come configurare la modalità di layout dell'area tracciata quando il layout è impostato manualmente, usando `LayoutTargetType` per definire se l'area tracciata è calcolata dalla sua regione interna o dalla sua regione esterna insieme ad assi ed etichette degli assi.

## **Ottenere Larghezza e Altezza dell'Area Tracciata di un Grafico**

Aspose.Slides per PHP via Java fornisce una semplice API per .

1. Crea un'istanza della classe[Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con i dati predefiniti.
4. Chiama il metodo[Chart.validateChartLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/validatechartlayout/) prima di ottenere i valori effettivi.
5. Ottiene la posizione X reale (sinistra) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
6. Ottiene la parte superiore reale dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
7. Ottiene la larghezza reale dell'elemento del grafico.
8. Ottiene l'altezza reale dell'elemento del grafico.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Impostare la Modalità di Layout di un'Area Tracciata del Grafico**

Aspose.Slides per PHP via Java fornisce una semplice API per impostare la modalità di layout dell'area tracciata del grafico. I metodi[**setLayoutTargetType**](https://reference.aspose.com/slides/it/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) e[**getLayoutTargetType**](https://reference.aspose.com/slides/it/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) sono stati aggiunti alla classe[**ChartPlotArea**](https://reference.aspose.com/slides/it/php-java/aspose.slides/ChartPlotArea). Se il layout dell'area tracciata è definito manualmente, questa proprietà specifica se disporre l'area tracciata per l'interno (escludendo assi ed etichette degli assi) o per l'esterno (includendo assi ed etichette degli assi). Ci sono due valori possibili definiti nell'enumerazione[**LayoutTargetType**](https://reference.aspose.com/slides/it/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/it/php-java/aspose.slides/LayoutTargetType#Inner) - specifica che la dimensione dell'area tracciata determina la dimensione dell'area tracciata, escludendo i segni di graduazione e le etichette degli assi.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/it/php-java/aspose.slides/LayoutTargetType#Outer) - specifica che la dimensione dell'area tracciata determina la dimensione dell'area tracciata, i segni di graduazione e le etichette degli assi.

Il codice di esempio è mostrato di seguito.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Domande Frequenti**

**In quali unità vengono restituiti gli x, y, larghezza e altezza effettivi?**

In punti; 1 pollice = 72 punti. Queste sono le unità di coordinate di Aspose.Slides.

**Qual è la differenza tra Area Tracciata e Area del Grafico in termini di contenuto?**

L'Area Tracciata è la regione di disegno dei dati (serie, linee di griglia, linee di tendenza, ecc.); l'Area del Grafico include gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'Area Tracciata include anche le pareti/pavimento e gli assi.

**Come vengono interpretati x, y, larghezza e altezza dell'Area Tracciata quando il layout è manuale?**

Sono frazioni (0–1) delle dimensioni complessive del grafico; in questa modalità, il posizionamento automatico è disabilitato e vengono utilizzate le frazioni impostate.

**Perché la posizione dell'Area Tracciata è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico fuori dall'Area Tracciata ma influisce sul layout e sullo spazio disponibile, quindi l'Area Tracciata può spostarsi quando il posizionamento automatico è attivo. (Questo è il comportamento standard dei grafici di PowerPoint.)