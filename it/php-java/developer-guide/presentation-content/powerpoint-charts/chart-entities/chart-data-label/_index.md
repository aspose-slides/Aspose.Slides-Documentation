---
title: Gestisci le etichette dei dati del grafico nelle presentazioni usando PHP
linktitle: Etichetta dati
type: docs
url: /it/php-java/chart-data-label/
keywords:
- grafico
- etichetta dati
- precisione dei dati
- percentuale
- distanza etichetta
- posizione etichetta
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara ad aggiungere e formattare le etichette dei dati del grafico nelle presentazioni PowerPoint utilizzando Aspose.Slides per PHP via Java per slide più coinvolgenti."
---
## **Introduzione**

Le etichette dati mostrano informazioni sulle serie del grafico e sui singoli punti dati, aiutando i lettori a identificare i valori e a comprendere il grafico. Questo articolo spiega come formattare i valori, visualizzare le percentuali, leggere il testo delle etichette, controllare le etichette oltre il valore massimo dell'asse, regolare la spaziatura delle etichette dell'asse delle categorie e posizionare le etichette di un grafico a torta.

## **Impostare la precisione dei dati nelle etichette del grafico**

Usa [setNumberFormatOfValues](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) per formattare i valori delle serie. Questo esempio crea un grafico a linee con dati predefiniti, visualizza la sua tabella dati e abilita le etichette di valore per la prima serie. Il formato `#,##0.00` mostra un separatore delle migliaia e due decimali senza modificare i valori originali.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Visualizzare la percentuale come etichette**

Per un grafico a colonne impilate, calcola ciascun valore come percentuale del totale della categoria e assegna il testo al frame di testo restituito da [getTextFrameForOverriding](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Questo esempio utilizza i dati predefiniti del grafico e visualizza le percentuali con due decimali in un carattere da 8 pt. Le categorie con totale pari a zero vengono omesse per evitare divisioni per zero. Ricalcola il testo personalizzato dell’etichetta se i dati del grafico cambiano.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impostare il simbolo percentuale con le etichette dei dati**

Quando i valori sono memorizzati come frazioni, usa [setNumberFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabelformat/#setNumberFormat) per visualizzare le percentuali. Passa `false` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) per applicare il formato dell’etichetta in modo indipendente dalle celle di origine.

Questo esempio crea un grafico a colonne impilate al 100 % con serie rosse e blu su quattro categorie. Ogni coppia di valori somma a 1. Il formato etichetta `0.0%` visualizza 0.30 come 30.0 %, mentre l’asse verticale usa due decimali. Entrambe le serie utilizzano testo etichetta bianco da 10 pt.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Leggere il testo effettivo delle etichette dati**

Usa [getActualLabelText](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/#getActualLabelText) per recuperare il testo prodotto dalle impostazioni di un’etichetta dati. È utile quando si estraggono le etichette per report, si ricerca il contenuto di una presentazione o si convalidano i grafici generati. Nell’esempio seguente, il [formato predefinito delle etichette dati](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabelformat/) combina il nome della categoria, il nome della serie e il valore. Un punto formatta il valore come percentuale, un altro utilizza testo personalizzato da [getTextFrameForOverriding](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Il numero memorizzato in un punto dati rimane `0.75`, anche quando la sua etichetta mostra `75 %` insieme ai nomi di categoria e di serie. Il testo personalizzato sostituisce il testo generato dell’etichetta. [getActualLabelText](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/#getActualLabelText) restituisce la stringa dell’etichetta risultante in entrambi i casi. Controlla [isVisible](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/#isVisible) separatamente, come mostrato sopra, quando vuoi estrarre solo le etichette visibili.

## **Controllare le etichette dati oltre il valore massimo dell'asse**

Quando limiti manualmente l’intervallo di un asse, alcuni punti dati possono superare il valore massimo. Usa [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) per controllare se le loro etichette dati vengono visualizzate. Questa impostazione modifica la visibilità delle etichette; non altera l’intervallo dell’asse né i valori dei dati sottostanti.

L’esempio seguente crea un grafico a colonne raggruppate 2D con valori 60 e 120. Passa `false` a [setAutomaticMaxValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/#setAutomaticMaxValue) e imposta il massimo a 100 con [setMaxValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/#setMaxValue) sull’asse verticale. La prima diapositiva consente etichette oltre il massimo; una copia di quella diapositiva le disabilita. Entrambe le diapositive vengono salvate in `DataLabelsOverMaximum.pptx`.

Abilita le etichette di valore con [setShowValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabelformat/#setShowValue). L’impostazione a livello di grafico non attiva la visualizzazione del valore da sola né sovrascrive la visualizzazione disabilitata di un’etichetta individuale. Questo esempio abilita i valori per l’intera serie e usa [setPosition](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabelformat/#setPosition) per posizionare le etichette all’estremità esterna di ogni colonna.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le immagini seguenti mostrano le diapositive salvate renderizzate da Microsoft PowerPoint. Con `true`, l’etichetta **120** è visibile al limite superiore; con `false`, è nascosta. L’etichetta **60** rimane visibile, il valore massimo dell’asse resta **100** e il secondo punto dati resta **120** in entrambi i casi.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Grafico PowerPoint che mostra l’etichetta valore 120 con un massimo dell’asse di 100](data-labels-over-maximum-true.png) | ![Grafico PowerPoint che nasconde l’etichetta valore 120 con un massimo dell’asse di 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Questo esempio utilizza un grafico a colonne 2D con un asse dei valori. I grafici senza asse dei valori, come i grafici a torta e a ciambella, non hanno un valore massimo dell’asse da limitare in questo modo.
{{% /alert %}}

## **Impostare la distanza dell’etichetta dall’asse**

Usa [setLabelOffset](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/#setLabelOffset) per controllare la distanza tra le etichette dell’asse delle categorie e l’asse stesso. Il valore è una percentuale della dimensione massima del carattere delle etichette dell’asse. Questo esempio crea un grafico a colonne raggruppate e imposta lo spostamento delle etichette dell’asse orizzontale a 500. Questa impostazione influisce sulle etichette dell’asse delle categorie, non sulle etichette associate ai singoli punti dati.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Regolare la posizione dell’etichetta**

Su un grafico a torta, regola le posizioni delle etichette dati per migliorare la spaziatura e fare spazio alle linee guida.

Questo esempio visualizza il valore del primo punto dati, posiziona la sua etichetta fuori dalla fetta e regola gli spostamenti orizzontale e verticale usando [setX](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/#setX) e [setY](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/#setY). Questi spostamenti sono relativi alla larghezza e all’altezza del grafico, rispettivamente.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Grafico a torta con etichetta dati regolata](pie-chart-adjusted-label.png)

## **FAQ**

**Come posso evitare che le etichette dati si sovrappongano in grafici affollati?**

Combina il posizionamento automatico delle etichette, le linee guida e una riduzione della dimensione del carattere; se necessario, nascondi alcuni campi (ad esempio, la categoria) o mostra le etichette solo per valori estremi o punti chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come garantire uno stile di etichetta coerente durante l’esportazione in PDF/immagini?**

Imposta esplicitamente la famiglia e la dimensione del carattere e verifica che il carattere sia disponibile nell’ambiente di rendering per evitare fallback.