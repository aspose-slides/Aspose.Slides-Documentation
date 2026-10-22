---
title: Gestire le serie di dati del grafico nelle presentazioni su Android
linktitle: Serie di dati
type: docs
url: /it/androidjava/chart-series/
keywords:
- serie di grafico
- sovrapposizione di serie
- colore della serie
- nome della serie
- punto dati
- cella della cartella di lavoro
- gap della serie
- valore negativo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara a gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza del gap e i valori negativi nelle presentazioni su Android."
---
## **Panoramica**

Un grafico può memorizzare i valori tracciati nelle celle della cartella di lavoro o direttamente come letterali numerici. Un [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) rappresenta un insieme di valori correlati, e ogni [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) rappresenta un punto in quella serie. Gli oggetti [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Nei grafici creati con dati predefiniti, i nomi delle serie, le categorie e i valori dei punti utilizzano oggetti [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) della cartella di lavoro del grafico.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio, riga e colonna passati a [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) sono basati su zero. Questa disposizione è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che tutti i grafici esistenti la utilizzino. Per una presentazione caricata, esaminare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti differenti:

- Impostazioni a livello di serie, come [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--), forniscono l’aspetto predefinito per tutti i punti di una serie.
- Impostazioni a livello di punto dati, come [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), sovrascrivono l’aspetto della serie per un singolo punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/). Accedere al gruppo tramite [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) quando è necessario impostare opzioni come sovrapposizione o larghezza del gap.

Quando non è impostato un riempimento esplicito per punto o serie, lo stile e il tema del grafico determinano l’aspetto automatico. Quando sono presenti sia formattazione della serie sia del punto, la formattazione del punto ha la precedenza per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Impostare i valori della serie usando letterali numerici**

Utilizzare i letterali numerici quando i valori della serie provengono da dati o calcoli dell’applicazione e non richiedono riferimenti a celle del foglio. Chiamare [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) con [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) prima di assegnare a ciascun punto il risultato di [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) tramite [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

L’impostazione della collezione controlla il tipo di origine di tutti i valori dei punti in quella serie. Il metodo [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) di ciascun valore di punto restituisce il tipo selezionato; modificarlo tramite l’impostazione della collezione. Con `Worksheet`, utilizzare [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) per accedere alla cella di riferimento. Con `DoubleLiterals`, utilizzare [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) o `setAsLiteralDouble` per leggere o scrivere direttamente il numero.

L’esempio seguente crea un grafico a colonne con serie e categorie predefinite, quindi assegna valori calcolati di 10, 20 e così via ai punti esistenti della sua prima serie. Salva la presentazione, la riapre e stampa i valori memorizzati.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Il tipo di origine del valore del punto è separato da [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--), che identifica la configurazione interna o esterna della cartella di lavoro del grafico. L’utilizzo di letterali numerici non elimina, di per sé, la cartella di lavoro incorporata. In questo esempio, la cartella di lavoro rimane disponibile per le etichette di categoria, i nomi delle serie e le altre serie. vedere [Cartella di lavoro del grafico](/slides/it/androidjava/chart-workbook/) per la gestione della cartella di lavoro.

Per i grafici a dispersione e a bolle, utilizzare [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) e [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) per scegliere le origini per [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) e [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--). I grafici a bolle utilizzano anche [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) per [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Impostare ogni origine applicabile su `DoubleLiterals` prima di assegnare numeri tramite il metodo `setAsLiteralDouble` di quel valore.

## **Impostare la sovrapposizione delle serie del grafico**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) indica quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione in sola lettura dell’impostazione sul gruppo di serie genitore. Utilizzare [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L’esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Il nuovo grafico contiene serie, categorie e valori di esempio.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La sovrapposizione delle serie](series_overlap.png)

## **Modificare il colore di riempimento della serie**

Utilizzare [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) sovrascrive il riempimento della serie per quel punto.

L’esempio seguente applica un riempimento solido blu alla prima serie:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il colore della serie](series_color.png)

## **Modificare il nome della serie**

Il nome di una serie è memorizzato nella cartella di lavoro del grafico e normalmente viene visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 si trova alla riga 0, colonna 1 e contiene il nome della prima serie. Le costanti nominate nell’esempio seguente rendono esplicita quella struttura:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

È inoltre possibile aggiornare la cella già referenziata da [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--). Questo approccio evita di assumere una riga e una colonna specifiche in un grafico esistente:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il nome della serie](series_name.png)

### **Creare una serie con nome da più celle**

Un nome di serie composito è utile quando il nome del prodotto e il periodo di rendiconto sono memorizzati in celle separate della cartella di lavoro. Ad esempio, è possibile combinare `Product A` in B1 e `2026` in C1 in un unico nome di serie mantenendo entrambe le parti collegate alle loro celle di origine.

Utilizzare [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) per recuperare l’intervallo dei nomi, quindi passare quella collezione a [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). L’argomento `skipHiddenCells` controlla se le celle nascoste sono incluse: `true` le esclude, `false` le include. Questo esempio utilizza `false` per includere ogni cella nell’intervallo dei nomi.

L’esempio seguente crea una presentazione con una serie e due punti dati. Le celle B1:C1 forniscono solo il nome della serie; A2:A3 forniscono le etichette di categoria, e B2:B3 forniscono i valori numerici.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Queste due celle forniscono il nome della serie.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Celle separate forniscono le categorie e i punti dati numerici.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il nome della serie risultante è `Product A 2026`, con uno spazio tra i due valori delle celle. La legenda lo visualizza come un’unica voce per entrambe le colonne. L’immagine sottostante illustra il risultato:

![Grafico a colonne con valori Nord e Sud e il nome composito della serie Product A 2026 nella legenda](composite_series_name.png)

## **Ottenere il colore di riempimento automatico della serie**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) restituisce il colore calcolato dall’indice della serie e dallo stile del grafico come intero ARGB Android. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. La chiamata al metodo legge il colore calcolato; non assegna un nuovo riempimento.

L’esempio seguente stampa l’intero colore automatico di ciascuna serie predefinita:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

I valori interi esatti dipendono dallo stile e dal tema del grafico.

## **Impostare il colore di riempimento invertito per una serie del grafico**

Per le serie a barre, colonne e bolle, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento regolare della serie su solido, abilitare l’inversione e assegnare il colore del valore negativo tramite [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L’esempio seguente sostituisce i dati predefiniti del grafico con una serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il colore di riempimento solido invertito](inverted_solid_fill_color.png)

È possibile abilitare l’inversione per un singolo punto tramite [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Nell’esempio seguente l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Il punto è inoltre assegnato a un valore negativo in modo che l’effetto sia visibile:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cancellare il valore di uno specifico punto dati**

Per rendere vuoto un punto senza rimuovere gli altri, impostare la cella di supporto della cartella di lavoro su `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Il punto dati rimane nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto in base alle impostazioni dei valori vuoti del grafico.

L’esempio seguente cancella solo il secondo punto nella prima serie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I grafici a dispersione utilizzano celle X e Y separate, e i grafici a bolle usano anche una cella per la dimensione. Cancellare solo la cella che rappresenta il valore che si intende rimuovere. Non chiamare [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) quando si desidera mantenere gli altri punti, poiché quel metodo rimuove tutti i punti dati dalla collezione.

## **Controllare la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso separato dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio, vedere [Include Data from Hidden Rows and Columns](/slides/it/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Chiamare [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) con `null` per rendere una cella vuota. Uno zero numerico rimane zero indipendentemente dall’impostazione delle celle vuote.

Utilizzare [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all’intero grafico. Cambia il modo in cui i vuoti sono tracciati, senza riempire la cella della cartella di lavoro vuota con zero o un valore interpolato.

L’esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario alcun file di input. Il [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) utilizza il foglio 0, la colonna 0 per le etichette di categoria e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Lascia il giorno 3 realmente vuoto, mantenendo la sua categoria e il punto dati.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, assegnare la modalità desiderata e salvare la presentazione una volta anziché iterare sulle modalità.

Il confronto sotto mostra gli stessi dati in tutti e tre i file. Il Giorno 3 è vuoto nella cartella di lavoro in tutti i casi:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero abbassa la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L’effetto visibile dipende dal tipo di grafico. Un grafico a linee rende facili da confrontare tutti e tre i modi. I grafici a barre e a colonne non hanno linee da collegare tra categorie mancanti, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono apparire simili. Allo stesso modo, un grafico a dispersione con soli marcatori non ha linea di collegamento. Non aspettatevi tre risultati distinti per ogni tipo di grafico; verificate l’output per il tipo che state usando.

## **Impostare la larghezza del gap della serie**

La larghezza del gap è lo spazio tra cluster di barre o colonne adiacenti, espresso in percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie genitore piuttosto che a una singola serie. Chiamare [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) una volta per il gruppo. Un valore più grande crea più spazio tra i cluster; un valore più piccolo li rende più densi.

L’esempio seguente modifica la larghezza del gap e salva solo la presentazione finale:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La larghezza del gap](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) utilizzano dati di grafico, ma le loro serie non hanno tutte la stessa struttura di valori o le stesse impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza del gap si applicano solo a gruppi di barre o colonne compatibili.

**Che cos’è un gruppo di serie di grafico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi la modifica del gruppo raggiunta tramite una serie non cambia necessariamente tutte le serie del grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le serie sia le collezioni di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette di categoria e i valori dei punti dati fanno riferimento a celle in un [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/). Modificare una cella di riferimento aggiorna l’elemento del grafico corrispondente. Quando si costruiscono dati personalizzati, mantenere le righe di categoria e le righe dei valori delle serie allineate in modo che ogni punto sia tracciato sotto la categoria prevista.

**Come cancellare un punto invece di tutta la serie?**

Impostare la cella del valore pertinente su `null` per mantenere la posizione di categoria del punto come punto vuoto. Utilizzare [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) solo quando si intende rimuovere tutti i punti di quella serie. Se si rimuovono anche le categorie, aggiornare ogni serie affinché i valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). I grafici supportati possono visualizzare i vuoti come gap, come valori zero o collegando i punti vicini. Scegliere l’impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Controllare la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, chiamare [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) e impostare il colore restituito da [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). È possibile sovrascrivere il comportamento per un singolo punto con [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Questi metodi influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia la serie sia il punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a usare la formattazione esplicita della serie o, se la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le impostazioni di gruppo, come sovrapposizione e larghezza del gap, controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato per il conteggio delle serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, i tempi di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiamare [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sul gruppo di serie genitore appropriato. Incrementare il valore per aumentare lo spazio tra i cluster, o diminuirlo per avvicinare i cluster.