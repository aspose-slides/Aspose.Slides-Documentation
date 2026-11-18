---
title: Crea o aggiorna grafici delle presentazioni PowerPoint in PHP
linktitle: Crea o aggiorna grafici
type: docs
weight: 10
url: /it/php-java/create-chart/
keywords:
- aggiungi grafico
- crea grafico
- modifica grafico
- cambia grafico
- aggiorna grafico
- grafico a dispersione
- grafico a torta
- grafico a linea
- grafico a mappa di albero
- grafico a borsa
- grafico a scatola e baffi
- grafico a imbuto
- grafico a raggiera
- grafico istogramma
- grafico radar
- grafico multi-categoria
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea e personalizza grafici nelle presentazioni PowerPoint usando Aspose.Slides per PHP via Java. Aggiungi, formatta e modifica i grafici con esempi di codice pratici in PHP."
---
## **Panoramica**

Questo articolo fornisce una guida completa su come creare e personalizzare i grafici usando Aspose.Slides per PHP via Java. Imparerai come aggiungere programmaticamente un grafico a una diapositiva, popolarlo con dati e applicare varie opzioni di formattazione per soddisfare i tuoi requisiti di design specifici. In tutto l’articolo, esempi di codice dettagliati illustrano ogni passaggio, dall’inizializzazione della presentazione e dell’oggetto grafico alla configurazione di serie, assi e legende. Seguendo questa guida, otterrai una solida comprensione di come integrare la generazione dinamica di grafici nelle tue applicazioni PHP, semplificando il processo di creazione di presentazioni basate sui dati.

## **Creare un Grafico**

I grafici aiutano le persone a visualizzare rapidamente i dati e a ricavare intuizioni che potrebbero non essere immediatamente evidenti da una tabella o un foglio di calcolo.

**Perché Creare Grafici?**

Usando i grafici, puoi:

* aggregare, condensare o riassumere grandi quantità di dati in una singola diapositiva di una presentazione;
* evidenziare schemi e tendenze nei dati;
* dedurre la direzione e la velocità dei dati nel tempo o rispetto a un’unità di misura specifica;
* individuare valori anomali, aberrazioni, deviazioni, errori e dati privi di senso;
* comunicare o presentare dati complessi.

In PowerPoint, puoi creare grafici tramite la funzione *Inserisci*, che fornisce modelli per la progettazione di molti tipi di grafici. Usando Aspose.Slides, puoi creare sia grafici regolari (basati su tipi di grafico popolari) sia grafici personalizzati.

{{% alert color="info" title="Nota" %}}

Usa l’enumerazione [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) nello spazio dei nomi [aspose\slides](https://reference.aspose.com/slides/php-java/aspose.slides/). I valori di questa enumerazione corrispondono a diversi tipi di grafico.

{{% /alert %}}

### **Creare Grafici a Colonna Raggruppati**

Questo esempio usa [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) per creare un grafico a colonna raggruppato che confronta due serie su tre categorie. Le serie usano riempimenti rosso e verde, e le etichette individuali mostrano i nomi delle categorie, i nomi delle serie e i valori. L’indice del foglio di lavoro 0 si riferisce al primo foglio nel workbook del grafico incorporato.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 128, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $label = $series->getDataPoints()->get_Item(0)->getLabel();
    $label->getDataLabelFormat()->setShowCategoryName(true);

    $label = $series->getDataPoints()->get_Item(1)->getLabel();
    $label->getDataLabelFormat()->setShowSeriesName(true);

    $label = $series->getDataPoints()->get_Item(2)->getLabel();
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setShowSeriesName(true);
    $label->getDataLabelFormat()->setSeparator("/");

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico a colonna raggruppato](clustered_column_chart.png)

### **Creare Grafici a Dispersione**

I grafici a dispersione (noti anche come scatter plot o grafici x‑y) sono spesso usati per verificare schemi o dimostrare correlazioni tra due variabili.

Usa un grafico a dispersione quando:

* Hai dati numerici accoppiati.
* Hai due variabili che si associano bene.
* Vuoi determinare se le due variabili sono correlate.
* Hai una variabile indipendente che presenta più valori per una variabile dipendente.

Questo esempio traccia due insiemi di valori x‑y. La prima serie usa linee rette con marcatori a stella, mentre la seconda usa linee fluide con marcatori a cerchio; entrambe usano una dimensione del marcatore di 10, configurata con [setSize](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsize/). Il metodo [setSymbol](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsymbol/) controlla la forma del marcatore.

```php
use aspose\slides\ChartType;
use aspose\slides\MarkerStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 20, 20, 500, 300);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 3, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 1, 1);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 2, 3);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 1, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 2, 10);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 3, 3);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 4, 3, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 4, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 5, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 5, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico a dispersione](scatter_chart.png)

### **Creare Grafici a Torta**

I grafici a torta sono ideali per mostrare la relazione parte‑intero nei dati, specialmente quando i dati contengono etichette categoriche con valori numerici. Tuttavia, se i tuoi dati contengono molte parti o etichette, potresti considerare l’uso di un grafico a barre.

Questo esempio crea un grafico a torta con tre valori trimestrali. Ogni fetta ha un riempimento e un bordo personalizzati, e le etichette mostrano diverse combinazioni di valori, percentuali e informazioni sulla serie. Il metodo [setFirstSliceAngle](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) imposta la prima fetta a partire da 180 gradi.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $categoryCell = $workbook->getCell(0, 1, 0, "1st Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "2nd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "3rd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);

    $firstSlice = $series->getDataPoints()->get_Item(0);
    $firstSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 255, 255);
    $firstSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $firstSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 128, 128, 128);
    $firstSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $firstSlice->getFormat()->getLine()->setWidth(3.0);
    $firstSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThick);
    $firstSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDash);

    $secondSlice = $series->getDataPoints()->get_Item(1);
    $secondSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $secondSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $secondSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 0, 255);
    $secondSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondSlice->getFormat()->getLine()->setWidth(3.0);
    $secondSlice->getFormat()->getLine()->setStyle(LineStyle::Single);
    $secondSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDot);

    $thirdSlice = $series->getDataPoints()->get_Item(2);
    $thirdSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 127, 80);
    $thirdSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $thirdSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $thirdSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $thirdSlice->getFormat()->getLine()->setWidth(2.0);
    $thirdSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThin);
    $thirdSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDotDot);

    $firstLabel = $series->getDataPoints()->get_Item(0)->getLabel();
    $firstLabel->getDataLabelFormat()->setShowValue(true);

    $secondLabel = $series->getDataPoints()->get_Item(1)->getLabel();
    $secondLabel->getDataLabelFormat()->setShowValue(true);
    $secondLabel->getDataLabelFormat()->setShowLegendKey(true);
    $secondLabel->getDataLabelFormat()->setShowPercentage(true);

    $thirdLabel = $series->getDataPoints()->get_Item(2)->getLabel();
    $thirdLabel->getDataLabelFormat()->setShowSeriesName(true);
    $thirdLabel->getDataLabelFormat()->setShowPercentage(true);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);

    $presentation->save("PieChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico a torta](pie_chart.png)

Per migliorare la leggibilità delle etichette esterne alla torta, vedi [Format Leader Lines](/slides/it/php-java/chart-data-label/#format-leader-lines) per un esempio che posiziona le etichette e personalizza colore, larghezza, trasparenza e stile tratteggio delle linee.

### **Creare Grafici a Linea**

I grafici a linea (noti anche come grafici a linee) sono ideali quando vuoi dimostrare variazioni di valore nel tempo. Usando un grafico a linea, puoi confrontare una grande quantità di dati contemporaneamente, monitorare cambiamenti e tendenze nel tempo, evidenziare anomalie nelle serie di dati e altro ancora.

Questo esempio usa [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) per creare un grafico a linea con le serie e le categorie predefinite, quindi salva la presentazione come PPTX.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    $presentation->save("lineChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Per impostazione predefinita, i punti di un grafico a linea sono collegati da linee continue rette. Se vuoi che i punti siano collegati da trattini, chiama [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) con un valore da [LineDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/):

```php
use aspose\slides\ChartType;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    for ($i = 0; $i < java_values($lineChart->getChartData()->getSeries()->size()); $i++)
    {
        $series = $lineChart->getChartData()->getSeries()->get_Item($i);
        $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico a linea](line_chart.png)

### **Creare Grafici a Mappa di Albero**

I grafici a mappa di albero sono ideali per dati di vendita quando vuoi mostrare le dimensioni relative delle categorie di dati e attirare rapidamente l’attenzione sugli elementi che hanno un contributo significativo in ciascuna categoria.

Questo esempio crea una mappa di albero con otto foglie raggruppate in quattro tronchi e due rami. Il metodo [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) assegna i tronchi al livello di raggruppamento 1 e i rami al livello 2. I valori determinano le dimensioni relative dei rettangoli, mentre le etichette di categoria e le etichette genitore sovrapposte identificano la gerarchia.

```php
use aspose\slides\ChartType;
use aspose\slides\ParentLabelLayoutType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Treemap, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Ramo 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // Ramo 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);

    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);

    $presentation->save("Treemap.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico a mappa di albero](treemap_chart.png)

### **Creare Grafici a Cascata**

Un grafico a cascata mostra come le variazioni positive e negative contribuiscono a un valore finale. Ad esempio, una ripartizione di profitto può partire dal fatturato, sottrarre i costi e aggiungere altri ricavi. Le colonne di variazione fluttuano tra il valore corrente precedente e quello nuovo, mentre le colonne totali si estendono dallo zero al valore accumulato.

L’esempio seguente usa importi in migliaia di dollari statunitensi:

| Categoria | Valore nel workbook | Tipo di colonna |
| --- | ---: | --- |
| Fatturato | 1000 | Aumento |
| Costo delle vendite | -400 | Diminuzione |
| Utile lordo | 600 | Totale intermedio |
| Spese operative | -200 | Diminuzione |
| Altri ricavi | 50 | Aumento |
| Utile netto | 450 | Totale finale |

Per contrassegnare un punto come totale intermedio o finale, chiama il suo metodo [setSetAsTotal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setsetastotal/) con `true`. Fornisci l’importo reale accumulato nella cella corrispondente del workbook: `600` per l’utile lordo (`1000 - 400`) e `450` per l’utile netto (`600 - 200 + 50`). Il metodo segna la colonna come totale; non calcola né popola il valore della cella. Non usare zero come segnaposto né fornire un’altra variazione per un punto totale. Una colonna totale mostra il valore accumulato senza aggiungerlo nuovamente al valore corrente.

Questo esempio completo in PHP crea un grafico usando il membro `Waterfall` di [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), cancella i dati predefiniti e riempie il workbook incorporato. L’indice del foglio `0` seleziona il primo foglio; la colonna A contiene i nomi delle categorie e la colonna B contiene i valori. Ogni cella valore è aggiunta con [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/). Gli indici dei punti basati su zero `2` e `5` identificano rispettivamente i totali intermedi e finali. Chiamare [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) con `true` visualizza gli importi sulle colonne. Non è necessaria alcuna presentazione o workbook in ingresso.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Waterfall, 20, 20, 680, 200);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Profit breakdown (USD thousands)");
    $chart->getChartTitle()->setOverlay(false);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $workbook->clear($worksheetIndex);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Profit");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Waterfall);
    $categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    $values = [ 1000, -400, 600, -200, 50, 450 ];

    for ($i = 0; $i < count($categories); $i++)
    {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categories[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForWaterfallSeries($valueCell);
    }

    // Il terzo e il sesto punto rappresentano totali, non variazioni aggiuntive.
    $series->getDataPoints()->get_Item(2)->setSetAsTotal(true);
    $series->getDataPoints()->get_Item(5)->setSetAsTotal(true);
    $series->setShowConnectorLines(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("WaterfallChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Chiama il metodo a livello di serie [setShowConnectorLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setshowconnectorlines/) con `true` per mostrare le linee che collegano le colonne consecutive e rendere più facile seguire il valore corrente. Per nascondere queste linee, sostituisci la chiamata al metodo nell’esempio con `$series->setShowConnectorLines(false);` prima di salvare. Questo modifica solo la visibilità delle linee, non i dati o i totali.

La presentazione salvata mostra un utile lordo di 600 e un utile netto di 450, con entrambi i totali disegnati da zero:

![Grafico a cascata che mostra fatturato, costi, utile lordo di 600 e utile netto di 450, con etichette di valore e linee di collegamento](waterfall_chart.png)

### **Creare Grafici a Borsa**

I grafici a borsa sono usati per visualizzare dati finanziari come prezzi di apertura, massimo, minimo e chiusura, aiutando ad analizzare tendenze di mercato e volatilità. Offrono informazioni essenziali sulle performance delle azioni, supportando investitori e analisti nelle decisioni informate.

Questo esempio crea un grafico Open‑High‑Low‑Close con quattro serie in quest’ordine e tre categorie. Il metodo [setUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/setupdownbars/) abilita le barre su/giù, e [getHiLowLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) controlla le linee high‑low che mostrano gli intervalli di prezzo, mentre le linee delle singole serie e le linee di griglia orizzontali minori sono nascoste.

Il manager restituito da [getUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getupdownbars/) espone oggetti di formattazione separati tramite [getUpBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/getupbarsformat/) e [getDownBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/getdownbarsformat/). Usa i metodi [getFill](https://reference.aspose.com/slides/php-java/aspose.slides/format/getfill/) e [getLine](https://reference.aspose.com/slides/php-java/aspose.slides/format/getline/) di ciascun oggetto per impostare riempimento e contorno in modo indipendente. Questo esempio usa barre verdi con contorni verde scuro per gli intervalli in rialzo e barre arancione‑rosso con contorni rosso scuro per gli intervalli in discesa.

Fornisci valori numerici per tutte e quattro le serie in ciascuna categoria, con High e Low che racchiudono Open e Close. Le barre confrontano Close con Open **all’interno della stessa categoria**, non con la categoria precedente: A scende da 72 a 25, mentre B sale da 25 a 38 e C sale da 38 a 50. Valori di Open e Close uguali non producono alcun intervallo riempito visibile. Le barre up/down coprono Open‑Close; le linee high‑low coprono Low‑High. Queste barre appartengono al gruppo di serie e non sono serie di grafico a barre ordinarie.

Questa formattazione funziona anche con grafici [Line and LineWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) contenenti almeno due serie nello stesso gruppo e valori numerici corrispondenti per ciascuna categoria. Per questi grafici a linea non impilati, le barre up/down confrontano la prima e l’ultima serie: un valore finale più alto produce una barra up, un valore finale più basso produce una barra down. Invertire le serie inverte la classificazione. L’esempio sotto usa [OpenHighLowClose](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/); non presumere che altre varianti di borsa, linea impilata o 3D utilizzino la stessa disposizione dei dati o interpretazione dell’intervallo.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::OpenHighLowClose, 20, 20, 500, 150, false);

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $categoryCell = $workbook->getCell(0, 1, 0, "A");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "B");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "C");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Open");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 2, "High");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 3, "Low");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 4, "Close");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $valueCell = $workbook->getCell(0, 1, 1, 72);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 1, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 1, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $valueCell = $workbook->getCell(0, 1, 2, 172);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $valueCell = $workbook->getCell(0, 1, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 3, 13);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $valueCell = $workbook->getCell(0, 1, 4, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 4, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 4, 50);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $upDownBars = $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars();
    $upDownBars->setUpDownBars(true);

    $upDownBars->getUpBarsFormat()->getFill()->setFillType(FillType::Solid);
    $upDownBars->getUpBarsFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 50, 205, 50));
    $upDownBars->getUpBarsFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $upDownBars->getUpBarsFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 100, 0));
    $upDownBars->getUpBarsFormat()->getLine()->setWidth(2);

    $upDownBars->getDownBarsFormat()->getFill()->setFillType(FillType::Solid);
    $upDownBars->getDownBarsFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 69, 0));
    $upDownBars->getDownBarsFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $upDownBars->getDownBarsFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $upDownBars->getDownBarsFormat()->getLine()->setWidth(2);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++)
    {
        $stockSeries = $chart->getChartData()->getSeries()->get_Item($i);
        $stockSeries->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $presentation->save("Stock-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato, esportato da PowerPoint:

![Grafico a borsa con intervallo arancione‑rosso in discesa per A e intervalli verdi in rialzo per B e C](stock_chart.png)

### **Creare Grafici a Scatola e Baffi**

I grafici a scatola e baffi sono usati per visualizzare la distribuzione dei dati sintetizzando misure statistiche chiave, come la mediana, i quartili e i potenziali outlier. Sono particolarmente utili nell’analisi esplorativa dei dati e negli studi statistici per comprendere rapidamente la variabilità dei dati e identificare eventuali anomalie.

Questo esempio crea un grafico a scatola e baffi con sei valori. Il metodo [setQuartileMethod](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setquartilemethod/) seleziona il calcolo esclusivo dei quartili. L’esempio abilita anche le linee della media, i marcatori della media, i punti interni e i punti outlier.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\QuartileMethodType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::BoxAndWhisker, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);

    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);

    $valueCell = $workbook->getCell(0, "B1", 15);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 41);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 10);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 23);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);

    $presentation->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

### **Creare Grafici a Imbuto**

I grafici a imbuto sono usati per visualizzare processi che coinvolgono fasi sequenziali, dove il volume dei dati diminuisce man mano che avanza da un passo al successivo. Sono particolarmente utili per analizzare i tassi di conversione, identificare colli di bottiglia e monitorare l’efficienza dei processi di vendita o marketing.

Questo esempio usa [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) per aggiungere un grafico a imbuto alla prima diapositiva di una presentazione esistente. Sostituisce i dati predefiniti con sei categorie e valori da 50 a 500, quindi salva la presentazione aggiornata. La presentazione di input deve contenere almeno una diapositiva.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);

    $valueCell = $workbook->getCell(0, "B1", 50);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 100);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 200);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 300);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 400);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 500);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);

    $presentation->save("Funnel.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico a imbuto](funnel_chart.png)

### **Creare Grafici Sunburst**

I grafici sunburst sono usati per visualizzare dati gerarchici, mostrando i livelli come anelli concentrici. Aiutano a illustrare relazioni parte‑intero e sono ideali per rappresentare categorie nidificate e sotto‑categorie in un formato chiaro e compatto.

Questo esempio crea un grafico sunburst con otto foglie raggruppate in quattro tronchi e due rami. Il metodo [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) assegna i tronchi al livello di raggruppamento 1 e i rami al livello 2. Le etichette di categoria identificano i segmenti e i valori determinano le loro dimensioni relative.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Sunburst, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Ramo 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // Ramo 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);

    $presentation->save("Sunburst.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico Sunburst](sunburst_chart.png)

### **Creare Grafici Istogramma**

Gli istogrammi mostrano come i valori numerici sono distribuiti tra intervalli (bin). Per i rapporti mensili sui tempi di elaborazione degli ordini, usa la stessa larghezza dei bin e le stesse soglie per mantenere coerenti gli intervalli e facilitare il confronto delle distribuzioni.

Chiama [setAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaggregationtype/) sull’asse orizzontale con una modalità da [AxisAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setbinwidth/) si applica solo a `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberofbins/) si applica solo a `ByNumberOfBins`. Usa `Automatic` per lasciare che il grafico scelga i bin.

#### **Usare una Larghezza Fissa del Bin**

Questo esempio raggruppa i tempi di elaborazione in intervalli di 10 minuti, con bin separati per i tempi ≤ 10 minuti e > 40 minuti. Abilita questi bin con [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) e [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/). Quando fornisci soglie esplicite tramite [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) e [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/), chiama [setAutomaticUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticunderflowbin/) e [setAutomaticOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticoverflowbin/) con `false`.

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByBinWidth);
    $axis->setBinWidth(10);
    $axis->setUnderflowBin(true);
    $axis->setAutomaticUnderflowBin(false);
    $axis->setUnderflowBin(10);
    $axis->setOverflowBin(true);
    $axis->setAutomaticOverflowBin(false);
    $axis->setOverflowBin(40);

    $presentation->save("Histogram-bin-width.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

La presentazione mostrata in PowerPoint indica conteggi dei bin di **3, 4, 4, 4 e 2**. Il bin di underflow include `5, 10, 10`, quindi la sua soglia è inclusiva. Il bin di overflow include solo `41, 50`, quindi la sua soglia è esclusiva; entrambi i valori pari a `40` rimangono nell’intervallo precedente. I bin interiori contengono valori maggiori del limite inferiore e minori o uguali al limite superiore.

![Istogramma con bin da 10 minuti e soglie di underflow e overflow esplicite](histogram_bin_width.png)

#### **Specificare il Numero di Bin**

Per un livello di dettaglio fisso anziché intervalli fissi, richiedi cinque bin per gli stessi dati. Questo esempio lascia i bin di underflow e overflow disabilitati. Il grafico determina la larghezza dal range dei dati, quindi i limiti possono cambiare tra i rapporti.

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByNumberOfBins);
    $axis->setNumberOfBins(5);

    $presentation->save("Histogram-bin-count.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

I cinque bin hanno conteggi di **4, 4, 4, 4 e 1**. Confronta questa distribuzione con il risultato a larghezza fissa sopra: i valori di input sono identici, ma i limiti differiscono.

![Istogramma con cinque bin calcolati dagli stessi dati](histogram_bin_count.png)

### **Creare Grafici Radar**

I grafici radar sono usati per visualizzare dati multivariati in un formato bidimensionale, consentendo un facile confronto di più variabili simultaneamente. Sono particolarmente utili per identificare schemi, punti di forza e debolezze attraverso più metriche o attributi di performance.

Questo esempio usa [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) per creare un grafico radar con le serie e le categorie predefinite, quindi salva la presentazione come PPTX.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addChart(ChartType::Radar, 20, 20, 500, 300);

    $presentation->save("Radar-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico radar](radar_chart.png)

### **Creare Grafici Multi‑Categoria**

I grafici multi‑categoria sono usati per visualizzare dati che coinvolgono più raggruppamenti categorici, consentendo di confrontare valori attraverso più dimensioni simultaneamente. Sono particolarmente utili quando è necessario analizzare tendenze e relazioni all’interno di set di dati complessi e multilivello.

Questo esempio crea un grafico a colonna raggruppato con otto categorie disposte in quattro coppie. Il metodo [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) assegna a ciascuna coppia un’etichetta condivisa al livello di raggruppamento 1, producendo un asse delle categorie con etichette sia individuali sia di gruppo.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell(0, "c2", "A");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $categoryCell = $workbook->getCell(0, "c3", "B");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c4", "C");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $categoryCell = $workbook->getCell(0, "c5", "D");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c6", "E");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $categoryCell = $workbook->getCell(0, "c7", "F");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c8", "G");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $categoryCell = $workbook->getCell(0, "c9", "H");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, "D1", "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $valueCell = $workbook->getCell($worksheetIndex, "D2", 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D3", 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D4", 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D5", 40);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D6", 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D7", 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D8", 70);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D9", 80);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico multi‑categoria](multi_category_chart.png)

#### **Rimuovere un’Etichetta del Trimestre**

Scarica [quarters.pptx](quarters.pptx) e posizionalo nella stessa directory dello script PHP. Il suo grafico mostra nove mesi e una singola serie di vendite con valori da 10 a 18. sull’asse delle categorie, Q1 copre gennaio‑marzo, Q2 aprile‑giugno e Q3 luglio‑settembre.

Aprile è la quarta categoria (indice 3) e contiene l’etichetta Q2. Usa [getGroupingLevels](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getgroupinglevels/) per accedere ai livelli di raggruppamento di aprile, quindi chiama [deleteGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/deletegroupingitem/) con livello 1 per rimuovere la sua etichetta di trimestre. Il livello 0 rappresenta il mese stesso e non può essere rimosso con questo metodo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/quarters.pptx");
try
{
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $april = $chart->getChartData()->getCategories()->get_Item(3);
    $april->getGroupingLevels()->deleteGroupingItem(1);

    $presentation->save(__DIR__ . "/quarters-updated.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}

$reopened = new Presentation(__DIR__ . "/quarters-updated.pptx");
try
{
    $updatedChart = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $updatedChart->getChartData();

    $months = [];
    $categories = $data->getCategories();
    
    for ($i = 0; $i < java_values($categories->size()); $i++)
    {
        $months[] = (string)$categories->get_Item($i)->getAsCell()->getValue();
    }

    $sales = [];
    $points = $data->getSeries()->get_Item(0)->getDataPoints();
    for ($i = 0; $i < java_values($points->size()); $i++)
    {
        $sales[] = (string)$points->get_Item($i)->getValue()->getData();
    }

    echo implode(", ", $months), PHP_EOL;
    echo implode(", ", $sales), PHP_EOL;
}
finally
{
    $reopened->dispose();
}
```

Dopo aver riaperto il grafico, l’esempio stampa i mesi originali (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) e i valori di vendita (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) nello stesso ordine. Apri `quarters-updated.pptx` in PowerPoint per confrontare le etichette dell’asse. L’etichetta Q2 e il confine di gruppo prima di aprile scompaiono, quindi Q1 copre gennaio‑giugno. Q3 inizia ancora a luglio.

![Etichette dei trimestri prima e dopo la rimozione. A sinistra, Q2 copre aprile‑giugno. A destra, Q1 copre gennaio‑giugno.](quarter-label-comparison.png)

### **Creare Grafici Mappa**

I grafici mappa sono usati per visualizzare dati geografici mappando le informazioni a località specifiche come paesi, stati o città. Sono particolarmente utili per analizzare tendenze regionali, dati demografici e distribuzioni spaziali in modo chiaro e visivamente coinvolgente.

Questo esempio usa [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) per creare un grafico mappa con i dati geografici predefiniti e lo salva per la visualizzazione in PowerPoint.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Map, 20, 20, 500, 300);

    $presentation->save("mapChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Il risultato:

![Il grafico mappa](map_chart.png)

{{% alert color="info" title="Nota" %}}

L’immagine sopra mostra la presentazione salvata aperta in PowerPoint. Aspose.Slides scrive correttamente il grafico mappa e i suoi dati, ma non disegna i grafici mappa da sé: quando una diapositiva che ne contiene viene resa in immagine o convertita in PDF o SVG, l’area del grafico risulta vuota. Le altre forme sulla stessa diapositiva non sono interessate.

{{% /alert %}}

### **Creare Grafici di Combinazione**

Un grafico di combinazione (o combo) combina due o più tipi di grafico in un unico diagramma. Questo grafico consente di evidenziare, confrontare o esaminare differenze tra due o più set di dati, aiutandoti a identificare le relazioni tra di essi.

![Il grafico di combinazione](combination_chart.png)

Questo esempio combina due serie a colonna raggruppata con una serie a linea su quattro categorie. Le colonne usano l’asse verticale primario, mentre [setPlotOnSecondAxis](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setplotonsecondaxis/) posiziona la linea su un asse verticale secondario a destra. Le funzioni di supporto configurano titolo, legenda, etichette degli assi e linee della griglia.

```php
use aspose\slides\AxisPositionType;
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\FillType;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function createComboChart()
{
    $presentation = new Presentation();
    try
    {
        $chart = createChartWithFirstSeries($presentation->getSlides()->get_Item(0));

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    }
    finally
    {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide)
{
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $portionFormat = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $portionFormat->setFontBold(NullableBool::False);
    $portionFormat->setFontHeight(18);

    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 4, 0, "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 4.3);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 2.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 3.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 1, 4.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    return $chart;
}

function addSecondSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 2.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 4.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 1.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 2, 2.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
}

function addThirdSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 3.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 3, 5.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart)
{
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 217, 217, 217);
    $majorGridLinesFormat->getSolidFillColor()->setColor($color);
}

function setSecondaryAxesFormat($chart)
{
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle)
{
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titlePortionFormat = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $titlePortionFormat->setFontBold(NullableBool::False);
    $titlePortionFormat->setFontHeight(12);
}

createComboChart();
```

## **Aggiornare i Grafici**

Aspose.Slides per PHP via Java consente di aggiornare i grafici PowerPoint modificando dati, formattazione e stile. Questa funzionalità semplifica il mantenimento delle presentazioni aggiornate con contenuti dinamici e garantisce che i grafici riflettano accuratamente dati e standard visivi attuali.

Questo esempio aggiorna il grafico denominato "My chart" sulla prima diapositiva di una presentazione esistente. Richiede due serie di colonne con tre punti dati ciascuna, con etichette di categoria nella colonna A e nomi delle serie nella prima riga del primo foglio di lavoro. L’esempio usa [getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) per modificare le celle del workbook, aggiorna i valori delle serie, aggiunge una terza serie e cambia il grafico in cilindri raggruppati tramite [setType](https://reference.aspose.com/slides/php-java/aspose.slides/chart/settype/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $worksheetIndex = 0;

            $workbook = $chart->getChartData()->getChartDataWorkbook();

            $workbook->getCell($worksheetIndex, 1, 0, "Modified Category 1");
            $workbook->getCell($worksheetIndex, 2, 0, "Modified Category 2");

            $series = $chart->getChartData()->getSeries()->get_Item(0);

            $workbook->getCell($worksheetIndex, 0, 1, "New_Series 1");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(44);

            $series = $chart->getChartData()->getSeries()->get_Item(1);

            $workbook->getCell($worksheetIndex, 0, 2, "New_Series 2");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(99);

            $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
            $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

            $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 20);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 50);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 30);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);

            $chart->setType(ChartType::ClusteredCylinder);
        }
    }

    $presentation->save("AsposeChartModified.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **Impostare l’Intervallo Dati per un Grafico**

Per ispezionare l’intervallo già utilizzato da un grafico esistente, vedi [Retrieve a Chart's Data Range](/slides/it/php-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides per PHP via Java offre la flessibilità di definire un intervallo dati specifico da un foglio di lavoro come origine per i dati del tuo grafico. Questo significa che puoi mappare direttamente una porzione del tuo foglio al grafico, controllando quali celle contribuiscono alle serie e alle categorie del grafico. Di conseguenza, puoi aggiornare e sincronizzare facilmente i grafici con le ultime modifiche dei dati nel foglio, garantendo che le tue presentazioni PowerPoint riflettano informazioni attuali e accurate.

Questo esempio usa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) per impostare la fonte dati del grafico denominato "My chart" sulla prima diapositiva di una presentazione esistente a `Sheet1!A1:B4`. Il workbook del grafico deve contenere quel foglio e un intervallo popolato con un’intestazione di serie nella prima riga, etichette di categoria nella colonna A e tre valori nella colonna B.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $chart->getChartData()->setRange("Sheet1!A1:B4");
        }
    }

    $presentation->save("SetDataRange.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **Usare Marcatori Predefiniti nei Grafici**

Quando usi marcatori predefiniti nei grafici, ogni serie del grafico ottiene automaticamente un simbolo di marcatore predefinito diverso.

Questo esempio usa [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) per creare un grafico con due serie a linea e una legenda. Le impostazioni del marcatore accessibili tramite [getMarker](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getmarker/) mantengono i simboli di marcatore assegnati automaticamente. La prima serie include un valore negativo e un valore mancante, rappresentato da `null`, mentre la seconda ha un valore per ogni categoria.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell(0, 1, 0, "C1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 1, 1, 24);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 2, 0, "C2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 2, 1, 23);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 3, 0, "C3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 3, 1, -10);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 4, 0, "C4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 4, 1, null);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $seriesNameCell = $workbook->getCell(0, 0, 2, "Series 2");
    $secondSeries = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell(0, 1, 2, 30);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 10);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 60);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 4, 2, 40);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);

    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);

    $presentation->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **FAQ**

**Quali tipi di grafico sono supportati da Aspose.Slides per PHP via Java?**

Aspose.Slides per PHP via Java supporta una vasta gamma di tipi di grafico, tra cui barre, linee, torta, area, dispersione, istogramma, radar e molti altri. Questa flessibilità ti permette di scegliere il tipo di grafico più adatto alle tue esigenze di visualizzazione dei dati.

**Come aggiungo un nuovo grafico a una diapositiva?**

Per aggiungere un grafico, crei prima un’istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), recuperi la diapositiva desiderata usando il suo indice, quindi chiami il metodo per aggiungere un grafico, specificando il tipo di grafico e i dati iniziali. Questo processo integra il grafico direttamente nella tua presentazione.

**Come posso aggiornare i dati visualizzati in un grafico?**

Puoi aggiornare i dati di un grafico accedendo al suo workbook dei dati ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)), cancellando eventuali serie e categorie predefinite, quindi aggiungendo i tuoi dati personalizzati. Questo ti consente di aggiornare programmaticamente il grafico per riflettere i dati più recenti.

**È possibile personalizzare l’aspetto del grafico?**

Sì, Aspose.Slides per PHP via Java fornisce ampie opzioni di personalizzazione. Puoi modificare colori, caratteri, etichette, legende e altri elementi di formattazione per adattare l’aspetto del grafico alle tue specifiche esigenze di design.