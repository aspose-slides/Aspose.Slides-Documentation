---
title: Gestire le serie di dati del grafico nelle presentazioni in PHP
linktitle: Serie di dati
type: docs
url: /it/php-java/chart-series/
keywords:
- serie di grafico
- sovrapposizione della serie
- colore della serie
- nome della serie
- punto dati
- cella del foglio di lavoro
- spazio della serie
- valore negativo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come gestire le serie di grafico, i punti dati, le celle del foglio di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni con PHP."
---
## **Panoramica**

Un grafico memorizza i dati tracciati in una cartella di lavoro dei dati del grafico. Un [ChartSeries](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/) rappresenta un insieme di valori correlati e ogni [ChartDataPoint](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/) nella serie fa riferimento a una o più celle della cartella di lavoro. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Il nome della serie, le categorie e i valori dei punti sono quindi collegati a oggetti [ChartDataCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/) anziché essere memorizzati solo come testo visualizzato.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio di lavoro, riga e colonna passati a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#getCell) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che tutti i grafici esistenti lo utilizzino. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti differenti:

- Impostazioni a livello di serie, come [ChartSeries.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getFormat), forniscono l’aspetto predefinito per tutti i punti in una serie.
- Impostazioni a livello di punto dati, come [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getFormat), sovrascrivono l’aspetto della serie per un singolo punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/). Accedere al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getParentSeriesGroup) quando è necessario impostare opzioni come sovrapposizione o larghezza dello spazio.

Quando non è impostato alcun riempimento esplicito per punto o serie, lo stile e il tema del grafico determinano l’aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, la formattazione del punto prevale per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getOverlap) indica quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione in sola lettura dell’impostazione sul gruppo di serie genitore. Utilizzare [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/#setOverlap) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L’esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

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

![Sovrapposizione della serie](series_overlap.png)

## **Cambia il colore di riempimento della serie**

Utilizzare [ChartSeries.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getFormat) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getFormat) sovrascrive il riempimento della serie per quel punto.

L’esempio seguente applica un riempimento a tinta unita blu alla prima serie:

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

![Colore della serie](series_color.png)

## **Cambia il nome della serie**

Il nome di una serie è memorizzato nella cartella di lavoro dei dati del grafico ed è normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 è alla riga 0, colonna 1 e contiene il nome della prima serie. Le variabili nominate nell’esempio seguente rendono esplicita questa struttura:

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

È possibile aggiornare anche la cella già referenziata da [ChartSeries.getName](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getName). Questo approccio evita di presumere una riga o una colonna particolare in un grafico esistente:

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

![Nome della serie](series_name.png)

## **Ottieni il colore di riempimento automatico della serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) restituisce il colore calcolato dall’indice della serie e dallo stile del grafico. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. Chiamare il metodo legge il colore calcolato; non assegna un nuovo riempimento.

L’esempio seguente stampa il colore automatico di ciascuna serie predefinita:

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

Output di esempio per lo stile di grafico predefinito:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

I colori esatti dipendono dallo stile e dal tema del grafico.

## **Imposta il colore di riempimento invertito per una serie del grafico**

Per serie a barre, colonne e bolle, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#setInvertIfNegative) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento normale della serie a tinta unita, abilitare l’inversione e assegnare il colore per i valori negativi tramite [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L’esempio seguente sostituisce i dati del grafico predefiniti con una singola serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

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

![Colore di riempimento solido invertito](inverted_solid_fill_color.png)

È possibile abilitare l’inversione per un singolo punto tramite [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Nell’esempio seguente l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Il punto è anche assegnato a un valore negativo in modo che l’effetto sia visibile:

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

Per rendere vuoto un punto senza rimuovere gli altri, impostare la cella di supporto nella cartella di lavoro su `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getValue). Il punto dati rimane nella stessa posizione di categoria, ma il grafico lo considera vuoto in base alle impostazioni dei valori vuoti del grafico.

L’esempio seguente cancella solo il secondo punto nella prima serie:

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

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle utilizzano anche una cella per la dimensione. Cancellare solo la cella che rappresenta il valore da rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointcollection/#clear) quando si desidera mantenere gli altri punti, poiché quel metodo rimuove tutti i punti dati dalla collezione.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso distinto dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio di lavoro, vedere [Include Data from Hidden Rows and Columns](/slides/it/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Chiamare [ChartDataCell::setValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatacell/#setValue) con `null` per rendere una cella vuota. Uno zero numerico rimane zero indipendentemente dall’impostazione delle celle vuote.

Utilizzare [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/#setDisplayBlanksAs) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all’intero grafico. Modifica il modo in cui i valori vuoti vengono tracciati, senza riempire la cella vuota con zero o con un valore interpolato.

L’esempio autoconclusivo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario alcun file di input. Il [ChartDataWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/) utilizza il foglio 0, la colonna 0 per le etichette delle categorie e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

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

    // Lascia il giorno 3 veramente vuoto, mantenendo la sua categoria e il punto dati.
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

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare solo una versione, assegnare la modalità desiderata e salvare la presentazione una sola volta invece di iterare sulle modalità.

Il confronto sotto mostra gli stessi dati in tutti e tre i file. Il Giorno 3 è vuoto nella cartella di lavoro in ogni caso:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero porta la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L’effetto visibile dipende dal tipo di grafico. Un grafico a linee rende facili i confronti tra le tre modalità. I grafici a barre e colonne non hanno una linea da collegare attraverso una categoria mancante, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Analogamente, un grafico a dispersione con solo marcatori non ha linea di collegamento. Non aspettare tre risultati distinti per ogni tipo di grafico; verifica l’output per il tipo che utilizzi.

## **Imposta la larghezza dello spazio tra le serie**

La larghezza dello spazio è lo spazio tra i raggruppamenti adiacenti di barre o colonne, espresso come percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie genitore anziché a una singola serie. Chiamare [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/#setGapWidth) una sola volta per il gruppo. Un valore maggiore crea più spazio tra i raggruppamenti; un valore minore li rende più densi.

L’esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

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

![Larghezza dello spazio](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/it/php-java/aspose.slides/charttype/) utilizzano dati del grafico, ma le loro serie non hanno tutte la stessa struttura di valore o le stesse impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati corrispondente al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo a gruppi di barre o colonne compatibili.

**Che cos’è un gruppo di serie di grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.addChart](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addChart) crea serie di esempio, categorie e valori. È possibile modificare quelle celle o cancellare sia le collezioni di serie che di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/). Modificare una cella referenziata aggiorna l’elemento corrispondente del grafico. Quando si costruiscono dati personalizzati, mantenere le righe delle categorie e le righe dei valori delle serie allineate in modo che ogni punto sia tracciato sotto la categoria prevista.

**Come cancello un solo punto invece dell’intera serie?**

Impostare la cella del valore pertinente su `null` per mantenere la posizione di categoria del punto come punto vuoto. Utilizzare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointcollection/#clear) solo quando si intende rimuovere tutti i punti da quella serie. Se si rimuovono anche le categorie, aggiornare tutte le serie affinché i loro valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/#setDisplayBlanksAs). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l’impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, chiamare [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#setInvertIfNegative) e impostare il colore restituito da [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). È possibile sovrascrivere il comportamento per un punto individuale con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Questi metodi influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia la serie sia il punto sono formattati?**

La formattazione esplicita del punto dati prevale per quel punto. Gli altri punti continuano a utilizzare la formattazione esplicita della serie o, quando la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le impostazioni di gruppo, come sovrapposizione e larghezza dello spazio, controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al numero di serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, i tempi di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiamare [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/#setGapWidth) sul gruppo di serie genitore appropriato. Aumentare il valore per ampliare lo spazio tra i raggruppamenti o diminuirlo per avvicinarli.