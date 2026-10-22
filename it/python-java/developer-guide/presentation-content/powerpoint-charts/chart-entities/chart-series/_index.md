---
title: Gestire le serie di dati del grafico nelle presentazioni in Python
linktitle: Serie di dati
type: docs
url: /it/python-java/chart-series/
keywords:
- serie del grafico
- sovrapposizione della serie
- colore della serie
- nome della serie
- punto dati
- cella della cartella di lavoro
- spazio tra serie
- valore negativo
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni con Aspose.Slides per Python via Java."
---
## **Panoramica**

Un grafico può memorizzare i valori tracciati nelle celle della cartella di lavoro o direttamente come letterali numerici. Un [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) rappresenta un insieme di valori correlati, e ogni [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) rappresenta un punto in tale serie. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Nei grafici creati con dati predefiniti, i nomi delle serie, le categorie e i valori dei punti utilizzano oggetti [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) provenienti dalla cartella di lavoro del grafico.

Per un tipico grafico a categorie, la cartella di lavoro predefinita usa la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio, riga e colonna passati a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che tutti i grafici esistenti lo utilizzino. Per una presentazione caricata, esaminare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti diversi:

- Impostazioni a livello di serie, come [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), forniscono l’aspetto predefinito per tutti i punti di una serie.
- Impostazioni a livello di punto dati, come [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), sovrascrivono l’aspetto della serie per un singolo punto.
- Impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Accedere al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) quando è necessario impostare opzioni come la sovrapposizione o la larghezza dello spazio.

Quando non è impostata esplicitamente una riempimento per punto o serie, lo stile e il tema del grafico determinano l’aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, prevale la formattazione del punto per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Impostare i valori della serie usando letterali numerici**

Utilizzare i letterali numerici quando i valori della serie provengono da dati o calcoli dell’applicazione e non richiedono riferimenti a celle del foglio di lavoro. Chiamare [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) con [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) prima di assegnare a ciascun punto il risultato di [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) tramite [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

L’impostazione della raccolta controlla il tipo di origine di tutti i valori dei punti in quella serie. Il metodo [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) di ciascun valore di punto restituisce il tipo selezionato; modificalo tramite l’impostazione della raccolta. Con `Worksheet`, usare [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) per accedere alla cella di riferimento. Con `DoubleLiterals`, usare [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) o `setAsLiteralDouble` per leggere o scrivere direttamente il numero.

L’esempio seguente crea un grafico a colonne con serie e categorie predefinite, quindi assegna valori calcolati di 10, 20, … ai punti esistenti della prima serie. Salva la presentazione, la riapre e stampa i valori memorizzati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Il tipo di origine del valore del punto è separato da [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), che identifica la configurazione interna o esterna della cartella di lavoro del grafico. L’uso di letterali numerici non rimuove, di per sé, la cartella di lavoro incorporata. In questo esempio, la cartella di lavoro rimane disponibile per le etichette delle categorie, i nomi delle serie e le altre serie. Vedi [Chart Workbook](/slides/it/python-java/chart-workbook/) per la gestione della cartella di lavoro.

Per i grafici a dispersione e a bolle, utilizzare [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) e [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) per scegliere le origini per [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) e [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). I grafici a bolle usano anche [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) per [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Impostare ogni origine applicabile su `DoubleLiterals` prima di assegnare i numeri tramite il metodo `setAsLiteralDouble` del valore.

## **Impostare la sovrapposizione della serie del grafico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) indica di quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione di sola lettura dell’impostazione sul gruppo di serie padre. Utilizzare [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che mostrano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L’esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Il nuovo grafico contiene serie di esempio, categorie e valori.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Sovrapposizione della serie](series_overlap.png)

## **Modificare il colore di riempimento della serie**

Utilizzare [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) sovrascrive il riempimento della serie per quel punto.

L’esempio seguente applica un riempimento solido blu alla prima serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Colore della serie](series_color.png)

## **Modificare il nome della serie**

Il nome di una serie è memorizzato nella cartella di lavoro dei dati del grafico e viene normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 si trova alla riga 0, colonna 1 e contiene il nome della prima serie. Le variabili nominate nell’esempio seguente rendono esplicita tale struttura:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

È anche possibile aggiornare la cella già referenziata da [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). Questo approccio evita di presumere una riga e colonna specifiche in un grafico esistente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Nome della serie](series_name.png)

### **Creare una serie con un nome proveniente da più celle**

Un nome di serie composito è utile quando il nome del prodotto e il periodo di riferimento sono memorizzati in celle separate della cartella di lavoro. Ad esempio, è possibile combinare `Product A` in B1 e `2026` in C1 in un unico nome di serie mantenendo entrambi i collegamenti alle rispettive celle di origine.

Usare [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) per recuperare l’intervallo di nome, quindi passare quella raccolta a [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). L’argomento `skipHiddenCells` controlla se includere le celle nascoste: `True` le esclude, `False` le include. Questo esempio utilizza `False` per includere ogni cella nell’intervallo di nome.

L’esempio seguente crea una presentazione con una serie e due punti dati. Le celle B1:C1 forniscono solo il nome della serie; A2:A3 forniscono le etichette delle categorie e B2:B3 forniscono i valori numerici.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Queste due celle forniscono il nome della serie.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Celle separate forniscono le categorie e i punti dati numerici.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il nome della serie risultante è `Product A 2026`, con uno spazio tra i due valori delle celle. La legenda lo mostra come una singola voce per entrambe le colonne. L’immagine sotto illustra il risultato:

![Grafico a colonne con valori Nord e Sud e il nome della serie composito Product A 2026 nella legenda](composite_series_name.png)

## **Ottenere il colore automatico di riempimento della serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) restituisce il colore calcolato in base all’indice della serie e allo stile del grafico. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. La chiamata al metodo legge il colore calcolato; non assegna un nuovo riempimento.

L’esempio seguente stampa il colore automatico di ciascuna serie predefinita:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Output d’esempio per lo stile di grafico predefinito:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

I colori esatti dipendono dallo stile e dal tema del grafico.

## **Impostare il colore di riempimento invertito per una serie del grafico**

Per le serie a barre, colonne e bolle, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento della serie regolare su solido, abilitare l’inversione e assegnare il colore per i valori negativi tramite [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L’esempio seguente sostituisce i dati del grafico predefiniti con una sola serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Colore di riempimento solido invertito](inverted_solid_fill_color.png)

È possibile abilitare l’inversione per un singolo punto tramite [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Nell’esempio seguente l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Al punto viene anche assegnato un valore negativo affinché l’effetto sia visibile:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cancellare il valore di un punto dati specifico**

Per rendere vuoto un punto senza rimuovere gli altri punti, impostare la cella della cartella di lavoro di supporto su `None`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Il punto dati rimane nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto secondo le impostazioni dei valori vuoti del grafico.

L’esempio seguente cancella solo il secondo punto della prima serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella per la dimensione. Cancellare solo la cella che rappresenta il valore che si intende rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) quando si vuole mantenere gli altri punti, perché quel metodo rimuove tutti i punti dati dalla raccolta.

## **Controllare la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso distinto dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio, vedere [Include Data from Hidden Rows and Columns](/slides/it/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Chiamare [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) con `None` per rendere una cella vuota. Uno zero numerico rimane zero a prescindere dall’impostazione delle celle vuote.

Usare [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all’intero grafico. Cambia il modo in cui i vuoti vengono tracciati, senza riempire la cella vuota della cartella con zero o un valore interpolato.

L’esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario alcun file di input. Il [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) usa il foglio 0, la colonna 0 per le etichette delle categorie e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpipe.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Lascia il giorno 3 realmente vuoto, mantenendo la sua categoria e il punto dati.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, impostare la modalità desiderata e salvare la presentazione una sola volta anziché iterare sulle modalità.

Il confronto qui sotto mostra gli stessi dati nei tre file. Il Giorno 3 è vuoto nella cartella di lavoro in tutti i casi:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero abbassa la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L’effetto visibile dipende dal tipo di grafico. Un grafico a linee rende tutti e tre i risultati facili da confrontare. I grafici a barre e a colonne non hanno una linea da collegare attraverso una categoria mancante, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Analogamente, un grafico a dispersione con solo marcatori non ha linea di collegamento. Non aspettarsi tre risultati distinti per tutti i tipi di grafico; verificare l’output per il tipo utilizzato.

## **Impostare la larghezza dello spazio tra serie**

La larghezza dello spazio è lo spazio tra i cluster di barre o colonne adiacenti, espresso come percentuale della larghezza della barra o colonna. Come la sovrapposizione, appartiene al gruppo di serie padre piuttosto che a una singola serie. Chiamare [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) una sola volta per il gruppo. Un valore più grande crea più spazio tra i cluster; un valore più piccolo li rende più densi.

L’esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Larghezza dello spazio](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) usano dati del grafico, ma le loro serie non hanno tutte la stessa struttura di valori o impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo a gruppi di barre o colonne compatibili.

**Cos’è un gruppo di serie del grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie del grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le collezioni di serie sia quelle di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Cambiare una cella di riferimento aggiorna l’elemento corrispondente del grafico. Quando si costruiscono dati personalizzati, mantenere le righe delle categorie e le righe dei valori delle serie allineate affinché ogni punto sia tracciato nella categoria prevista.

**Come posso cancellare un punto invece di tutta la serie?**

Impostare la cella del valore pertinente su `None` per mantenere la posizione di categoria del punto come punto vuoto. Usare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) solo quando si intende rimuovere tutti i punti di quella serie. Se si rimuovono anche le categorie, aggiornare tutte le serie affinché i loro valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l’impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Control the Display of Empty Cells](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, chiamare [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) e impostare il colore restituito da [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). È possibile sovrascrivere il comportamento per un singolo punto con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Questi metodi influiscono sulla formattazione, non sui valori numerici memorizzati.

**Quale formattazione prevale quando sia la serie sia il punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a usare la formattazione esplicita della serie o, quando la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le impostazioni di gruppo come sovrapposizione e larghezza dello spazio controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato per il conteggio delle serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiamare [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) sul gruppo di serie padre appropriato. Aumentare il valore per allargare lo spazio tra i cluster, oppure diminuirlo per avvicinare i cluster.