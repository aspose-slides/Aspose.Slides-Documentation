---
title: Gestire le serie di dati del grafico nelle presentazioni in PHP
linktitle: Serie di dati
type: docs
url: /it/php-java/chart-series/
keywords:
- serie del grafico
- sovrapposizione delle serie
- colore della serie
- nome della serie
- punto dati
- cella della cartella di lavoro
- spazio della serie
- valore negativo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come gestire le serie di grafici, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni con PHP."
---
## **Panoramica**

Un grafico può memorizzare i valori tracciati nelle celle della cartella di lavoro o direttamente come letterali numerici. Un [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) rappresenta un insieme di valori correlati, e ciascun [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) rappresenta un punto di quella serie. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Nei grafici creati con dati predefiniti, i nomi delle serie, le categorie e i valori dei punti utilizzano oggetti [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) della cartella di lavoro del grafico.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio di lavoro, riga e colonna passati a [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) sono basati su zero. Questa disposizione è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che tutti i grafici esistenti la utilizzino. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

- Impostazioni a livello di serie, come [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), forniscono l'aspetto predefinito per tutti i punti di una serie.
- Impostazioni a livello di punto dati, come [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), sovrascrivono l'aspetto della serie per un singolo punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Accedere al gruppo tramite [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) quando è necessario impostare opzioni come la sovrapposizione o la larghezza dello spazio.

Quando non è impostato un riempimento esplicito per il punto o la serie, lo stile e il tema del grafico determinano l'aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, la formattazione del punto ha la precedenza per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta i valori della serie usando i letterali numerici**

Utilizzare i letterali numerici quando i valori della serie provengono da dati o calcoli dell'applicazione e non richiedono riferimenti a celle del foglio di lavoro. Chiamare [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) con [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) prima di assegnare il risultato di [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) di ciascun punto tramite [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

L'impostazione della collezione controlla il tipo di origine di tutti i valori dei punti in quella serie. Il metodo [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) di ciascun valore di punto restituisce il tipo selezionato; modificarlo tramite l'impostazione della collezione. Con `Worksheet`, utilizzare [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) per accedere alla cella di riferimento. Con `DoubleLiterals`, utilizzare [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) o `setAsLiteralDouble` per leggere o scrivere direttamente il numero.

L'esempio seguente crea un grafico a colonne con serie e categorie predefinite, quindi assegna valori calcolati di 10, 20 e così via ai punti esistenti della sua prima serie. Salva la presentazione, la riapre e stampa i valori memorizzati.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Il tipo di origine del valore del punto è separato da [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), che identifica la configurazione interna o esterna della cartella di lavoro del grafico. L'uso di letterali numerici non rimuove, di per sé, la cartella di lavoro incorporata. In questo esempio, la cartella di lavoro rimane disponibile per le etichette di categoria, i nomi delle serie e le altre serie. Vedere [Cartella di lavoro del grafico](/slides/it/php-java/chart-workbook/) per la gestione della cartella di lavoro.

Per i grafici a dispersione e a bolle, utilizzare [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) e [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) per scegliere le origini per [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) e [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). I grafici a bolle usano anche [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) per [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Impostare ciascuna origine applicabile su `DoubleLiterals` prima di assegnare numeri tramite il metodo `setAsLiteralDouble` di quel valore.

## **Imposta la sovrapposizione della serie del grafico**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) indica di quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione in sola lettura dell'impostazione sul gruppo di serie padre. Utilizzare [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L'esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

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

Utilizzare [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) per impostare il riempimento predefinito per un'intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) sovrascrive il riempimento della serie per quel punto.

L'esempio seguente applica un riempimento solido blu alla prima serie:

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

Il nome di una serie è memorizzato nella cartella di lavoro dei dati del grafico ed è normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 si trova alla riga 0, colonna 1 e contiene il nome della prima serie. Le variabili nominate nell'esempio seguente rendono esplicita questa struttura:

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

È anche possibile aggiornare la cella già referenziata da [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Questo approccio evita di presumere una riga e colonna specifiche in un grafico esistente:

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

### **Crea una serie con un nome da più celle**

Un nome di serie composito è utile quando il nome del prodotto e il periodo di rendicontazione sono memorizzati in celle della cartella di lavoro separate. Ad esempio, è possibile combinare `Product A` in B1 e `2026` in C1 in un unico nome di serie mantenendo entrambe le parti collegate alle loro celle di origine.

Utilizzare [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) per recuperare l'intervallo di nomi, quindi passare quella collezione a [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). L'argomento `skipHiddenCells` controlla se includere le celle nascoste: `true` le esclude, `false` le include. Questo esempio utilizza `false` per includere ogni cella nell'intervallo di nomi.

L'esempio seguente crea una presentazione con una serie e due punti dati. Le celle B1:C1 forniscono solo il nome della serie; A2:A3 forniscono le etichette delle categorie, e B2:B3 forniscono i valori numerici.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Queste due celle forniscono il nome della serie.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Celle separate forniscono le categorie e i punti dati numerici.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il nome della serie risultante è `Product A 2026`, con uno spazio tra i due valori delle celle. La legenda lo visualizza come una voce per entrambe le colonne. L'immagine seguente illustra il risultato:

![Grafico a colonne con valori Nord e Sud e il nome della serie composita Product A 2026 nella legenda](composite_series_name.png)

## **Ottieni il colore di riempimento automatico della serie**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) restituisce il colore calcolato dall'indice della serie e dallo stile del grafico. Questo è il colore utilizzato quando il riempimento della serie non è stato definito esplicitamente. Chiamare il metodo legge il colore calcolato; non assegna un nuovo riempimento.

L'esempio seguente stampa il colore automatico di ciascuna serie predefinita:

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

## **Imposta il colore di riempimento invertito per una serie del grafico**

Per le serie a barre, colonne e bolle, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento regolare della serie su solido, abilitare l'inversione e assegnare il colore del valore negativo tramite [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). I numeri negativi rimangono invariati nella cartella di lavoro; ne cambia solo il colore di visualizzazione.

L'esempio seguente sostituisce i dati del grafico predefiniti con una serie. La riga 0 del foglio di lavoro contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

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

È possibile abilitare l'inversione per un singolo punto tramite [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Nell'esempio seguente, l'inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Il punto è anche assegnato a un valore negativo in modo che l'effetto sia visibile:

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

Per rendere vuoto un punto senza rimuovere gli altri punti, impostare la cella della cartella di lavoro di supporto su `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Il punto dati rimane nella stessa posizione della categoria, ma il grafico tratta il suo valore come vuoto in base alle impostazioni dei valori vuoti del grafico.

L'esempio seguente cancella solo il secondo punto della prima serie:

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

I grafici a dispersione utilizzano celle X e Y separate, e i grafici a bolle utilizzano anche una cella per le dimensioni. Cancella solo la cella che rappresenta il valore che si intende rimuovere. Non chiamare [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) quando si desidera mantenere gli altri punti, poiché quel metodo rimuove tutti i punti dati dalla collezione.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso separato dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio di lavoro, vedere [Includi dati da righe e colonne nascoste](/slides/it/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Chiamare [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) con `null` per rendere una cella vuota. Uno zero numerico resta zero indipendentemente dall'impostazione delle celle vuote.

Utilizzare [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all'intero grafico. Modifica il modo in cui i vuoti sono tracciati, senza riempire la cella vuota della cartella di lavoro con zero o con un valore interpolato.

L'esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario un file di input. Il [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) utilizza il foglio 0, la colonna 0 per le etichette di categoria e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Lasciare il giorno 3 realmente vuoto, mantenendo la sua categoria e il punto dati.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Ogni file di output salva la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, impostare la modalità desiderata e salvare la presentazione una volta anziché iterare sulle modalità.

Il confronto sotto mostra gli stessi dati in tutti e tre i file. Il Giorno 3 è vuoto nella cartella di lavoro in ogni caso:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero fa scendere la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L'effetto visibile dipende dal tipo di grafico. Un grafico a linee rende tutti e tre i modi facili da confrontare. I grafici a barre e a colonne non hanno una linea da collegare tra una categoria mancante, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Allo stesso modo, un grafico a dispersione con solo marcatori non ha linea di collegamento. Non ci si deve aspettare tre risultati distinti per ogni tipo di grafico; verificare l'output per il tipo in uso.

## **Imposta la larghezza dello spazio della serie**

La larghezza dello spazio è lo spazio tra gruppi di barre o colonne adiacenti, espresso in percentuale della larghezza della barra o colonna. Come la sovrapposizione, appartiene al gruppo di serie padre piuttosto che a una singola serie. Chiamare [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) una volta per il gruppo. Un valore più grande crea più spazio tra i gruppi; un valore più piccolo li rende più densi.

L'esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

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

![La larghezza dello spazio](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall'enumerazione [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) utilizzano dati del grafico, ma le loro serie non hanno tutte la stessa struttura di valori o impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo ai gruppi di barre o colonne compatibili.

**Che cos'è un gruppo di serie del grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le collezioni di serie che quelle di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Modificare una cella referenziata aggiorna l'elemento corrispondente del grafico. Quando si costruiscono dati personalizzati, mantenere le righe di categoria e le righe dei valori delle serie allineate in modo che ogni punto sia tracciato sotto la categoria prevista.

**Come cancello un punto invece dell'intera serie?**

Impostare la cella di valore pertinente su `null` per mantenere la posizione della categoria del punto come punto vuoto. Utilizzare [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) solo quando si intende rimuovere tutti i punti da quella serie. Se si rimuovono anche le categorie, aggiornare ogni serie affinché i valori rimangano allineati con la collezione di categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l'impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, chiamare [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) e impostare il colore restituito da [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). È possibile sovrascrivere il comportamento per un singolo punto con [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Questi metodi influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia una serie sia un punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a utilizzare la formattazione esplicita della serie o, quando la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le impostazioni di gruppo, come sovrapposizione e larghezza dello spazio, controllano il layout e non sono override di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al numero di serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiamare [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) sul gruppo di serie padre appropriato. Incrementare il valore per aumentare lo spazio tra i gruppi, o decrementarlo per avvicinare i gruppi.