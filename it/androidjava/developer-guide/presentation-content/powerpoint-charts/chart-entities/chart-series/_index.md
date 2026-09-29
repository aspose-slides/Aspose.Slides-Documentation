---
title: Gestire le serie di dati del grafico nelle presentazioni su Android
linktitle: Serie di dati
type: docs
url: /it/androidjava/chart-series/
keywords:
- serie di grafico
- sovrapposizione della serie
- colore della serie
- nome della serie
- punto dati
- cella della cartella di lavoro
- spazio tra le serie
- valore negativo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come gestire le serie di grafici, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni su Android."
---
## **Panoramica**

Un grafico memorizza i dati tracciati in una cartella di lavoro dei dati del grafico. Un [IChartSeries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/) rappresenta un insieme di valori correlati, e ogni [IChartDataPoint](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapoint/) nella serie fa riferimento a una o più celle della cartella di lavoro. Gli oggetti [IChartCategory](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalla serie. Il nome della serie, le categorie e i valori dei punti sono quindi collegati agli oggetti [IChartDataCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/) anziché essere memorizzati solo come testo visualizzato.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio, riga e colonna passati a [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) sono basati su zero. Questa disposizione è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che tutti i grafici esistenti la utilizzino. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre diversi ambiti:

- Impostazioni a livello di serie, come [IChartSeries.getFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getFormat--), forniscono l'aspetto predefinito per tutti i punti di una serie.
- Impostazioni del punto dati, come [IChartDataPoint.getFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), sovrascrivono l'aspetto della serie per un punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [IChartSeriesGroup](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseriesgroup/). Accedere al gruppo tramite [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) quando è necessario impostare opzioni come sovrapposizione o larghezza dello spazio.

Quando non viene impostato un riempimento esplicito per un punto o una serie, lo stile e il tema del grafico determinano l'aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, la formattazione del punto ha la precedenza per quel punto.

![serie-di-grafico-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione delle serie del grafico**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getOverlap--) indica quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione di sola lettura dell'impostazione sul gruppo di serie genitore. Utilizzare [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L'esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Il nuovo grafico contiene serie di esempio, categorie e valori.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Sovrapposizione delle serie](series_overlap.png)

## **Modifica il colore di riempimento della serie**

Utilizzare [IChartSeries.getFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getFormat--) per impostare il riempimento predefinito per un'intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [IChartDataPoint.getFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) sovrascrive il riempimento della serie per quel punto.

L'esempio seguente applica un riempimento solido blu alla prima serie:

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

![Colore della serie](series_color.png)

## **Modifica il nome della serie**

Il nome di una serie è memorizzato nella cartella di lavoro dei dati del grafico e viene normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 corrisponde a riga 0, colonna 1 e contiene il nome della prima serie. Le costanti nominate nell'esempio seguente rendono esplicita questa struttura:

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

È anche possibile aggiornare la cella già referenziata da [IChartSeries.getName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getName--). Questo approccio evita di presumere una riga o colonna specifica in un grafico esistente:

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

![Nome della serie](series_name.png)

## **Recupera il colore di riempimento automatico della serie**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) restituisce il colore calcolato dall'indice della serie e dallo stile del grafico come intero ARGB Android. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. La chiamata al metodo legge il colore calcolato; non assegna un nuovo riempimento.

L'esempio seguente stampa l'intero colore automatico di ciascuna serie predefinita:

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

## **Imposta il colore di riempimento invertito per una serie del grafico**

Per serie a barre, colonne e bolle, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento regolare della serie su solido, abilitare l'inversione e assegnare il colore per valori negativi tramite [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L'esempio seguente sostituisce i dati predefiniti del grafico con una singola serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

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

![Colore di riempimento solido invertito](inverted_solid_fill_color.png)

È possibile abilitare l'inversione per un singolo punto tramite [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Nell'esempio seguente l'inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Il punto è anche assegnato a un valore negativo in modo che l'effetto sia visibile:

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

## **Cancella il valore di un punto dati specifico**

Per rendere vuoto un punto senza rimuovere gli altri, impostare la cella di supporto della cartella di lavoro su `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [IChartDataPoint.getValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Il punto dati rimane nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto secondo le impostazioni di valori vuoti del grafico.

L'esempio seguente cancella solo il secondo punto nella prima serie:

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

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella di dimensione. Cancellare solo la cella che rappresenta il valore da rimuovere. Non chiamare [IChartDataPointCollection.clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) quando si desidera conservare gli altri punti, poiché quel metodo rimuove tutti i punti dati dalla collezione.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso distinto dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio di lavoro, vedere [Include Data from Hidden Rows and Columns](/slides/it/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Chiamare [IChartDataCell.setValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) con `null` per rendere una cella vuota. Uno zero numerico rimane zero indipendentemente dall'impostazione delle celle vuote.

Utilizzare [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all'intero grafico. Cambia il modo in cui i vuoti sono tracciati, senza riempire la cella vuota della cartella di lavoro con zero o un valore interpolato.

L'esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ogni modalità. Non è richiesto alcun file di input. Il [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/) utilizza il foglio 0, la colonna 0 per le etichette di categoria e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

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

    // Lasciare il giorno 3 realmente vuoto, mantenendo la sua categoria e il punto dati.
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

Il confronto qui sotto mostra gli stessi dati in tutti e tre i file. Il Giorno 3 è vuoto nella cartella di lavoro in ogni caso:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero porta la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L'effetto visivo dipende dal tipo di grafico. Un grafico a linee rende tutti e tre i modi facili da confrontare. I grafici a barre e colonne non hanno una linea da collegare attraverso una categoria mancante, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Analogamente, un grafico a dispersione con solo marcatori non ha linea di collegamento. Non aspettare tre risultati distinti per ogni tipo di grafico; verifica l'output per il tipo che utilizzi.

## **Imposta la larghezza dello spazio tra le serie**

La larghezza dello spazio è lo spazio tra cluster di barre o colonne adiacenti, espresso in percentuale della larghezza della barra o colonna. Come la sovrapposizione, appartiene al gruppo di serie genitore piuttosto che a una singola serie. Chiamare [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) una volta per il gruppo. Un valore più grande crea più spazio tra i cluster; un valore più piccolo li rende più densi.

L'esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

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

![Larghezza dello spazio](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall'enumerazione [ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/) utilizzano dati di grafico, ma le loro serie non hanno tutte la stessa struttura di valori o impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione dei punti dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo a gruppi di barre o colonne compatibili.

**Cos'è un gruppo di serie del grafico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [IShapeCollection.addChart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le collezioni di serie sia quelle di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati riferiscono celle in un [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/). Modificando una cella referenziata si aggiorna l'elemento corrispondente del grafico. Quando si costruiscono dati personalizzati, mantenere allineate le righe delle categorie e le righe dei valori delle serie in modo che ogni punto sia tracciato nella categoria prevista.

**Come faccio a cancellare un punto invece dell'intera serie?**

Impostare la cella di valore pertinente su `null` per mantenere la posizione di categoria del punto come punto vuoto. Utilizzare [IChartDataPointCollection.clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) solo quando si intende rimuovere tutti i punti da quella serie. Se si rimuovono anche le categorie, aggiornare tutte le serie affinché i loro valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l'impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, chiamare [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) e impostare il colore restituito da [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). È possibile sovrascrivere il comportamento per un singolo punto con [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Questi metodi influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione vince quando sia una serie sia un punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a utilizzare la formattazione esplicita della serie o, se la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le impostazioni di gruppo come sovrapposizione e larghezza dello spazio controllano il layout e non sono sovrascritte dalla formattazione a livello di punto.

**C'è un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al numero di serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiamare [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sul gruppo di serie genitore appropriato. Aumentare il valore per ampliare lo spazio tra i cluster, o diminuirlo per avvicinarli.