---
title: Gestire le etichette dei dati del grafico nelle presentazioni usando Python
linktitle: Etichetta dati
type: docs
url: /it/python-java/chart-data-label/
keywords:
- grafico
- etichetta dati
- precisione dei dati
- percentuale
- distanza dell'etichetta
- posizione dell'etichetta
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Impara ad aggiungere e formattare le etichette dei dati del grafico nelle presentazioni PowerPoint usando Aspose.Slides per Python tramite Java per diapositive più coinvolgenti."
---
## **Introduzione**

Le etichette dei dati mostrano informazioni sulle serie del grafico e sui singoli punti dati, aiutando i lettori a identificare i valori e a comprendere il grafico. Questo articolo spiega come formattare i valori, visualizzare le percentuali, leggere il testo delle etichette, controllare le etichette oltre il massimo dell'asse, regolare la spaziatura delle etichette dell'asse di categoria e posizionare le etichette dei grafici a torta.

## **Impostare la precisione dei dati nelle etichette del grafico**

Usa [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) per formattare i valori della serie. Questo esempio crea un grafico a linee con dati predefiniti, visualizza la sua tabella dati e abilita le etichette dei valori per la prima serie. Il formato `#,##0.00` mostra un separatore delle migliaia e due cifre decimali senza modificare i valori sottostanti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Visualizzare la percentuale come etichette**

Per un grafico a colonne impilate, calcola ogni valore come percentuale del totale della sua categoria e assegna il testo al frame di testo restituito da [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Questo esempio utilizza i dati predefiniti del grafico e visualizza le percentuali con due cifre decimali in un carattere da 8 punti. Le categorie con un totale pari a zero vengono ignorate per evitare divisioni per zero. Ricalcola il testo personalizzato dell'etichetta se i dati del grafico cambiano.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare il simbolo percentuale con le etichette dei dati del grafico**

Quando i valori sono memorizzati come frazioni, usa [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) per visualizzare le percentuali. Passa `False` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) per applicare il formato dell'etichetta in modo indipendente dalle celle di origine.

Questo esempio crea un grafico a colonne impilate al 100% con serie rosse e blu su quattro categorie. Ogni coppia di valori somma a 1. Il formato dell'etichetta `0.0%` visualizza 0,30 come 30,0%, mentre l'asse verticale utilizza due cifre decimali. Entrambe le serie usano testo dell'etichetta bianco, da 10 punti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Leggere il testo reale delle etichette dei dati**

Usa [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) per recuperare il testo prodotto dalle impostazioni di un'etichetta dati. Questo è utile quando si estraggono le etichette per report, si ricerca il contenuto di una presentazione o si convalidano i grafici generati. Nell'esempio seguente, il [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) predefinito combina il nome di ogni categoria, il nome della serie e il valore. Un punto formatta il suo valore come percentuale, e un altro utilizza testo personalizzato da [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Il numero memorizzato in un punto dati rimane `0.75`, anche quando la sua etichetta mostra `75%` insieme ai nomi di categoria e serie. Il testo personalizzato sostituisce il testo dell'etichetta generato. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) restituisce la stringa dell'etichetta risultante in entrambi i casi. Controlla [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) separatamente, come mostrato sopra, quando desideri estrarre solo le etichette visibili.

## **Controllare le etichette dei dati oltre il massimo dell'asse**

Quando limiti manualmente l'intervallo di un asse, alcuni punti dati possono superare il suo massimo. Usa [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) per controllare se le loro etichette vengono visualizzate. Questa impostazione modifica la visibilità delle etichette; non modifica l'intervallo dell'asse né i valori dei dati sottostanti.

L'esempio seguente crea un grafico a colonne raggruppate 2D con valori 60 e 120. Passa `False` a [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) e imposta il massimo a 100 con [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) sull'asse verticale. La prima diapositiva consente etichette oltre il massimo; una copia di quella diapositiva le disabilita. Entrambe le diapositive sono salvate in `DataLabelsOverMaximum.pptx`.

Abilita le etichette dei valori con [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). L'impostazione a livello di grafico non abilita la visualizzazione dei valori da sola né sovrascrive la visualizzazione disabilitata di un'etichetta individuale. Questo esempio abilita i valori per l'intera serie e usa [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) per posizionare le etichette all'estremità esterna di ogni colonna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le immagini seguenti mostrano le diapositive salvate renderizzate da Microsoft PowerPoint. Con `True`, l'etichetta **120** è visibile al limite superiore; con `False`, è nascosta. L'etichetta **60** resta visibile, il massimo dell'asse rimane **100**, e il secondo punto dati rimane **120** in entrambi i casi.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Grafico PowerPoint che mostra l'etichetta valore 120 con un massimo dell'asse di 100](data-labels-over-maximum-true.png) | ![Grafico PowerPoint che nasconde l'etichetta valore 120 con un massimo dell'asse di 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Questo esempio utilizza un grafico a colonne 2D con un asse dei valori. I grafici senza asse dei valori, come i grafici a torta e a ciambella, non hanno un massimo dell'asse da limitare in questo modo.
{{% /alert %}}

## **Impostare la distanza dell'etichetta da un asse**

Usa [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) per controllare la distanza tra le etichette dell'asse di categoria e l'asse. Il valore è una percentuale della dimensione massima del carattere delle etichette dell'asse. Questo esempio crea un grafico a colonne raggruppate e imposta lo spostamento dell'etichetta dell'asse orizzontale a 500. Questa impostazione influisce sulle etichette dell'asse di categoria piuttosto che sulle etichette collegate ai singoli punti dati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Regolare la posizione dell'etichetta**

Su un grafico a torta, regola le posizioni delle etichette dei dati per migliorare la spaziatura e fare spazio alle linee di collegamento.

Questo esempio visualizza il valore del primo punto dati, posiziona la sua etichetta all'esterno della fetta e regola gli offset orizzontale e verticale usando [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) e [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Questi offset sono relativi alla larghezza e all'altezza del grafico, rispettivamente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Grafico a torta con una posizione dell'etichetta dati regolata](pie-chart-adjusted-label.png)

## **Formattare le linee di collegamento**

Quando le etichette di un grafico a torta si trovano all'esterno delle loro fette, le linee di collegamento aiutano i lettori a associare ogni valore alla fetta corretta. Un colore contrastante e una linea leggermente più spessa possono rendere queste connessioni più facili da seguire, mentre trasparenza e stile tratteggiato mantengono le linee discreti visivamente.

Usa [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) per formattare le linee di collegamento a livello della raccolta di etichette dei dati della serie. Le impostazioni in `series.getLabels().getLeaderLinesFormat().getLine()` si applicano alla raccolta, piuttosto che a un'etichetta singola.

Questo esempio crea un grafico a torta con dati predefiniti, visualizza i valori all'esterno delle fette e abilita [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Sposta due etichette più lontano dalle loro fette usando gli offset [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) e [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY), espressi come frazioni della larghezza e dell'altezza del grafico. Non è necessaria alcuna presentazione di input.

Il [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) della linea imposta un colore blu pieno con un valore alfa di 191 su 255, fornendo circa il 25% di trasparenza. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) imposta lo spessore a 2 punti, e [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) rende la linea tratteggiata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Sposta due etichette più lontano dalle loro fette.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Abilitare le linee di collegamento non garantisce che una linea appaia per ogni etichetta. La visibilità dipende dal posizionamento dell'etichetta e dal comportamento di layout del grafico. In questo esempio, le due etichette spostate hanno linee di collegamento visibili; le etichette che rimangono vicine alle loro fette non ne hanno bisogno.

L'immagine seguente mostra il file `FormattedLeaderLines.pptx` salvato e renderizzato con Aspose.Slides:

![Grafico a torta con linee di collegamento blu, semitrasparenti e tratteggiate che collegano due etichette esterne alle loro fette](formatted-leader-lines.png)

## **Aggiungere più righe di etichette dei dati sopra un grafico a colonne**

Questo esempio crea un grafico a colonne con due righe di etichette dei dati sopra l'area del grafico. La Serie A visualizza le colonne visibili, mentre le Serie B e C forniscono le etichette aggiuntive. Le loro colonne sono nascoste rimuovendo il riempimento e il contorno. Il metodo [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) allinea le tre serie con gli stessi centri di categoria.

Le impostazioni del [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) riservano spazio per le righe di etichette. Dopo che [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) calcola le posizioni predefinite, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) e [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) preservano l'allineamento orizzontale e applicano offset verticali per disporre le etichette in due righe. I numeri rimangono etichette dei dati collegate ai valori della serie; solo le intestazioni delle righe sono forme di testo separate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Nascondi le colonne di B e C, ma mantieni le loro etichette dei dati.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Allinea tutte e tre le serie con gli stessi centri di categoria.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Usa meno linee della griglia per questo esempio compatto.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Riserva spazio sopra il grafico per due righe di etichette dei dati.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Mantieni la posizione orizzontale predefinita. Y è una compensazione da
            # la posizione predefinita dell'etichetta, espressa come frazione dell'altezza del grafico.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Solo l'intestazione della riga è una forma di testo separata.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Grafico a colonne con due righe di etichette dei dati sopra l'area del grafico](multiple-rows-of-labels.png)

## **FAQ**

**Come posso evitare la sovrapposizione delle etichette dei dati sui grafici densi?**

Combina il posizionamento automatico delle etichette, le linee di collegamento e una dimensione del carattere ridotta; se necessario, nascondi alcuni campi (ad esempio la categoria) o mostra le etichette solo per valori estremi o punti chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come posso garantire uno stile coerente delle etichette durante l'esportazione in PDF/immagini?**

Imposta esplicitamente la famiglia e la dimensione del carattere e verifica che il font sia disponibile nell'ambiente di rendering per evitare il fallback.