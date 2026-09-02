---
title: Gestire le serie di dati del grafico nelle presentazioni in PHP
linktitle: Serie di dati
type: docs
url: /it/php-java/chart-series/
keywords:
- serie di grafico
- sovrapposizione serie
- colore serie
- nome serie
- punto dati
- cella cartella di lavoro
- gap serie
- valore negativo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza del gap e i valori negativi nelle presentazioni con PHP."
---
## **Panoramica**

Un grafico memorizza i dati tracciati in una cartella di lavoro dei dati del grafico. Un [ChartSeries](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/) rappresenta un insieme di valori correlati, e ogni [ChartDataPoint](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/) nella serie si riferisce a una o più celle della cartella di lavoro. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalla serie. Il nome della serie, le categorie e i valori dei punti sono quindi collegati a oggetti [ChartDataCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/) anziché essere archiviati solo come testo visualizzato.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio di lavoro, riga e colonna passati a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#getCell) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che ogni grafico esistente lo utilizzi. Per una presentazione caricata, ispeziona le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti diversi:

- Impostazioni a livello di serie, come [ChartSeries.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getFormat), forniscono l’aspetto predefinito per tutti i punti di una serie.
- Impostazioni per i punti dati, come [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getFormat), sovrascrivono l’aspetto della serie per un punto.
- Le impostazioni di gruppo si applicano alle serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/). Accedi al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getParentSeriesGroup) quando è necessario impostare opzioni come la sovrapposizione o la larghezza del gap.

Quando non è impostata alcuna riempimento esplicito per punti o serie, lo stile e il tema del grafico determinano l’aspetto automatico. Quando sono presenti sia la formattazione della serie che del punto, la formattazione del punto ha la precedenza per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getOverlap) riporta quanto barre o colonne si sovrappongono in un grafico 2D, da ‑100 a 100 percento. È una proiezione di sola lettura dell’impostazione sul gruppo di serie genitore. Usa [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/#setOverlap) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

Il seguente esempio imposta la sovrapposizione per il gruppo che contiene la prima serie:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Il nuovo grafico contiene serie di esempio, categorie e valori.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![La sovrapposizione della serie](series_overlap.png)

## **Modifica il colore di riempimento della serie**

Usa [ChartSeries.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getFormat) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getFormat) sovrascrive il riempimento della serie per quel punto.

Il seguente esempio applica un riempimento blu solido alla prima serie:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![Il colore della serie](series_color.png)

## **Modifica il nome della serie**

Un nome di serie è memorizzato nella cartella di lavoro dei dati del grafico e viene normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 è alla riga 0, colonna 1 e contiene il nome della prima serie. Le variabili nominate nell’esempio seguente rendono esplicita tale struttura:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Puoi anche aggiornare la cella già referenziata da [ChartSeries.getName](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getName). Questo approccio evita di presumere una riga e colonna particolari in un grafico esistente:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![Il nome della serie](series_name.png)

## **Ottieni il colore di riempimento automatico della serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) restituisce il colore calcolato dall’indice della serie e dallo stile del grafico. È il colore usato quando il riempimento della serie non è stato definito esplicitamente. L’invocazione del metodo legge il colore calcolato; non assegna un nuovo riempimento.

Il seguente esempio stampa il colore automatico di ogni serie predefinita:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Esempio di output per lo stile di grafico predefinito:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

I colori esatti dipendono dallo stile e dal tema del grafico.

## **Imposta il colore di riempimento invertito per una serie di grafico**

Per le serie a barre, colonne e bolle, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#setInvertIfNegative) può visualizzare i valori negativi con un riempimento diverso. Imposta il riempimento regolare della serie su solido, abilita l’inversione e assegna il colore per i valori negativi tramite [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

Il seguente esempio sostituisce i dati del grafico predefiniti con una sola serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![Il colore di riempimento solido invertito](inverted_solid_fill_color.png)

Puoi abilitare l’inversione per un punto tramite [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Nell’esempio seguente, l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Al punto è anche assegnato un valore negativo affinché l’effetto sia visibile:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Cancella il valore di un punto dati specifico**

Per rendere vuoto un punto senza rimuovere gli altri, imposta la cella di supporto nella cartella di lavoro a `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getValue). Il punto dati rimane nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto secondo le impostazioni di valore vuoto del grafico.

Il seguente esempio cancella solo il secondo punto nella prima serie:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella per la dimensione. Cancella solo la cella che rappresenta il valore che intendi rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointcollection/#clear) quando vuoi mantenere gli altri punti, perché quel metodo rimuove tutti i punti dati dalla collezione.

## **Imposta la larghezza del gap della serie**

La larghezza del gap è lo spazio tra cluster di barre o colonne adiacenti, espresso in percentuale della larghezza della barra o colonna. Come la sovrapposizione, appartiene al gruppo di serie genitore piuttosto che a una singola serie. Chiama [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/#setGapWidth) una volta per il gruppo. Un valore più grande crea più spazio tra i cluster; un valore più piccolo li rende più densi.

Il seguente esempio modifica la larghezza del gap e salva solo la presentazione finale:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Il risultato:

![La larghezza del gap](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/it/php-java/aspose.slides/charttype/) utilizzano dati del grafico, ma le loro serie non hanno tutte la stessa struttura di valori o impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Usa il metodo di creazione dei punti dati che corrisponde al tipo di serie. Opzioni come la sovrapposizione e la larghezza del gap si applicano solo a gruppi di barre o colonne compatibili.

**Che cos'è un gruppo di serie di grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.addChart](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addChart) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le collezioni di serie che di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/). Modificando una cella di riferimento si aggiorna l’elemento corrispondente del grafico. Quando crei dati personalizzati, mantieni le righe delle categorie e le righe dei valori delle serie allineate in modo che ogni punto venga tracciato sotto la categoria prevista.

**Come posso cancellare un punto invece dell’intera serie?**

Imposta la cella di valore pertinente a `null` per mantenere la posizione della categoria del punto come punto vuoto. Usa [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointcollection/#clear) solo quando vuoi rimuovere tutti i punti da quella serie. Se rimuovi anche le categorie, aggiorna ogni serie affinché i loro valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/#setDisplayBlanksAs). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegli l’impostazione che corrisponde al significato dei dati mancanti nella tua presentazione.

**Come sono formattati i valori negativi?**

Per le serie di barre, colonne e bolle supportate, chiama [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#setInvertIfNegative) e imposta il colore restituito da [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Puoi sovrascrivere il comportamento per un punto individuale con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Questi metodi influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia una serie che un punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a utilizzare il formato esplicito della serie o, se il formato della serie non è definito, lo stile e il tema automatici del grafico. Le impostazioni di gruppo come la sovrapposizione e la larghezza del gap controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al numero di serie. Nella pratica, i vincoli del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiama [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/#setGapWidth) sul gruppo di serie genitore appropriato. Aumenta il valore per allargare lo spazio tra i gruppi, oppure diminuiscilo per avvicinare i gruppi.