---
title: Gestire le serie di dati del grafico nelle presentazioni in Python
linktitle: Serie di dati
type: docs
url: /it/python-java/chart-series/
keywords:
- serie di grafico
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
description: "Scopri come gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza del gap e i valori negativi nelle presentazioni con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Un grafico memorizza i dati tracciati in una cartella di lavoro dei dati del grafico. Un [ChartSeries](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/) rappresenta un insieme di valori correlati e ogni [ChartDataPoint](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/) nella serie si riferisce a una o più celle della cartella di lavoro. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Il nome della serie, le categorie e i valori dei punti sono quindi collegati a oggetti [ChartDataCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatacell/) anziché memorizzati solo come testo visualizzato.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio di lavoro, riga e colonna passati a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdataworkbook/#getCell) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che ogni grafico esistente lo utilizzi. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre diversi ambiti:

- Impostazioni a livello di serie, come [ChartSeries.getFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getFormat), forniscono l'aspetto predefinito per tutti i punti di una serie.
- Impostazioni del punto dati, come [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#getFormat), sovrascrivono l'aspetto della serie per un punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/). Accedere al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getParentSeriesGroup) quando è necessario impostare opzioni come sovrapposizione o larghezza del gap.

Quando non è impostata alcuna riempimento esplicito per punto o serie, lo stile e il tema del grafico determinano l'aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, la formattazione del punto ha la precedenza per quel punto.

![serie-di-grafico-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getOverlap) restituisce quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione in sola lettura dell'impostazione sul gruppo di serie padre. Usa [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setOverlap) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che mostrano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L'esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

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

## **Modifica il colore di riempimento della serie**

Usa [ChartSeries.getFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getFormat) per impostare il riempimento predefinito per un'intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.getFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#getFormat) sovrascrive il riempimento della serie per quel punto.

L'esempio seguente applica un riempimento solido blu alla prima serie:

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

![Il colore della serie](series_color.png)

## **Modifica il nome della serie**

Il nome di una serie è archiviato nella cartella di lavoro dei dati del grafico ed è normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 si trova alla riga 0, colonna 1 e contiene il nome della prima serie. Le variabili nominate nell'esempio seguente rendono esplicita questa struttura:

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

Puoi anche aggiornare la cella già referenziata da [ChartSeries.getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getName). Questo approccio evita di supporre una riga e colonna specifiche in un grafico esistente:

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

![Il nome della serie](series_name.png)

## **Ottieni il colore di riempimento automatico della serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) restituisce il colore calcolato in base all'indice della serie e allo stile del grafico. Questo è il colore utilizzato quando il riempimento della serie non è stato definito esplicitamente. Chiamare il metodo legge il colore calcolato; non assegna un nuovo riempimento.

L'esempio seguente stampa il colore automatico di ciascuna serie predefinita:

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

Esempio di output per lo stile di grafico predefinito:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

I colori esatti dipendono dallo stile e dal tema del grafico.

## **Imposta il colore di riempimento invertito per una serie di grafico**

Per le serie a barre, colonne e bolle, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#setInvertIfNegative) può visualizzare i valori negativi con un riempimento diverso. Imposta il riempimento regolare della serie su solido, abilita l'inversione e assegna il colore per i valori negativi tramite [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L'esempio seguente sostituisce i dati di grafico predefiniti con una sola serie. La riga 0 del foglio di lavoro contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

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

![Il colore di riempimento solido invertito](inverted_solid_fill_color.png)

Puoi abilitare l'inversione per un punto tramite [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Nell'esempio seguente, l'inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Al punto è anche assegnato un valore negativo in modo che l'effetto sia visibile:

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

## **Cancella un valore specifico di punto dati**

Per rendere vuoto un punto senza rimuovere gli altri punti, impostare la cella di supporto nella cartella di lavoro a `None`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.getValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#getValue). Il punto dati rimane nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto secondo le impostazioni di valori vuoti del grafico.

L'esempio seguente cancella solo il secondo punto nella prima serie:

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

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella di dimensione. Cancella solo la cella che rappresenta il valore che intendi rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapointcollection/#clear) quando vuoi mantenere gli altri punti, perché quel metodo rimuove tutti i punti dati dalla collezione.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso separato dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio di lavoro, vedere [Include Data from Hidden Rows and Columns](/slides/it/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota nella cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Chiama [ChartDataCell.setValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatacell/#setValue) con `None` per rendere una cella vuota. Uno zero numerico rimane zero indipendentemente dall'impostazione delle celle vuote.

Usa [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setDisplayBlanksAs) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all'intero grafico. Cambia il modo in cui i vuoti sono tracciati, senza riempire la cella vuota della cartella di lavoro con zero o un valore interpolato.

L'esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico in ciascuna modalità. Non è richiesto alcun file di input. Il [ChartDataWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdataworkbook/) utilizza il foglio di lavoro 0, la colonna 0 per le etichette di categoria e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
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

    # Lasciare il giorno 3 vuoto, mantenendo la sua categoria e il punto dati.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, assegna la modalità desiderata e salva la presentazione una volta invece di iterare sulle modalità.

Il confronto qui sotto mostra gli stessi dati in tutti e tre i file. Il Giorno 3 è vuoto nella cartella di lavoro in ogni caso:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero abbassa la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L'effetto visibile dipende dal tipo di grafico. Un grafico a linee rende tutti e tre i modi facili da confrontare. I grafici a barre e colonne non hanno una linea da collegare attraverso una categoria mancante, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Allo stesso modo, un grafico a dispersione con soli marker non ha linea di collegamento. Non aspettarti tre risultati distinti per ogni tipo di grafico; verifica l'output per il tipo che utilizzi.

## **Imposta la larghezza del gap della serie**

La larghezza del gap è lo spazio tra cluster di barre o colonne adiacenti, espresso come percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie padre piuttosto che a una singola serie. Chiama [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setGapWidth) una volta per il gruppo. Un valore più grande crea più spazio tra i cluster; un valore più piccolo li rende più densi.

L'esempio seguente modifica la larghezza del gap e salva solo la presentazione finale:

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

![La larghezza del gap](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall'enumerazione [ChartType](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/) utilizzano dati di grafico, ma le loro serie non hanno tutte la stessa struttura di valori o impostazioni. Per esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono dimensioni delle bolle. Usa il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza del gap si applicano solo a gruppi di barre o colonne compatibili.

**Che cos'è un gruppo di serie di grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.addChart](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addChart) crea serie di esempio, categorie e valori. È possibile modificare quelle celle o cancellare sia le raccolte di serie che di categorie prima di aggiungere un set di dati completamente personalizzato. Una sovraccarico può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdataworkbook/). Modificando una cella referenziata si aggiorna l'elemento corrispondente del grafico. Quando crei dati personalizzati, mantieni le righe delle categorie e le righe dei valori delle serie allineate affinché ogni punto sia tracciato sotto la categoria prevista.

**Come posso cancellare un punto invece dell'intera serie?**

Imposta la cella di valore pertinente a `None` per mantenere la posizione di categoria del punto come punto vuoto. Usa [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapointcollection/#clear) solo quando intendi rimuovere tutti i punti da quella serie. Se rimuovi anche le categorie, aggiorna ogni serie affinché i loro valori rimangano allineati con la raccolta delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e dal valore configurato tramite [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setDisplayBlanksAs). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegli l'impostazione che corrisponde al significato dei dati mancanti nella tua presentazione. Vedi [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come sono formattati i valori negativi?**

Per le serie di barre, colonne e bolle supportate, chiama [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#setInvertIfNegative) e imposta il colore restituito da [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Puoi sovrascrivere il comportamento per un singolo punto con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Questi metodi influenzano la formattazione, non i valori numerici archiviati.

**Quale formattazione prevale quando sia una serie che un punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a utilizzare il formato esplicito della serie o, se il formato della serie non è definito, lo stile e il tema automatici del grafico. Le impostazioni di gruppo come sovrapposizione e larghezza del gap controllano il layout e non sono sovrascritture della formattazione a livello di punto.

**C'è un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al numero di serie. In pratica, le restrizioni del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Chiama [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setGapWidth) sul gruppo di serie padre appropriato. Aumenta il valore per ampliare lo spazio tra i cluster o diminuiscilo per avvicinare i cluster.