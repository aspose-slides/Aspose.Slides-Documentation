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
- distanza etichetta
- posizione etichetta
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Impara ad aggiungere e formattare le etichette dei dati del grafico nelle presentazioni PowerPoint usando Aspose.Slides per Python via Java per diapositive più coinvolgenti."
---
## **Introduzione**

Le etichette dei dati mostrano informazioni sulle serie del grafico e sui singoli punti dati, aiutando i lettori a identificare i valori e a comprendere il grafico. Questo articolo spiega come formattare i valori, visualizzare le percentuali, leggere il testo delle etichette, controllare le etichette oltre il valore massimo dell'asse, regolare la spaziatura delle etichette dell'asse di categoria e posizionare le etichette dei grafici a torta.

## **Impostare la precisione dei dati nelle etichette del grafico**

Usa [setNumberFormatOfValues](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) per formattare i valori delle serie. Questo esempio crea un grafico a linee con dati predefiniti, visualizza la sua tabella dati e abilita le etichette dei valori per la prima serie. Il formato `#,##0.00` visualizza un separatore delle migliaia e due cifre decimali senza modificare i valori sottostanti.

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

Per un grafico a colonne impilate, calcola ciascun valore come percentuale del totale della sua categoria e assegna il testo al frame di testo restituito da [getTextFrameForOverriding](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Questo esempio utilizza i dati predefiniti del grafico e visualizza le percentuali con due cifre decimali in un carattere da 8 punti. Le categorie con un totale pari a zero sono saltate per evitare divisioni per zero. Ricalcola il testo personalizzato dell'etichetta se i dati del grafico cambiano.

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

Quando i valori sono memorizzati come frazioni, usa [setNumberFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabelformat/#setNumberFormat) per visualizzare le percentuali. Passa `False` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) per applicare il formato dell'etichetta indipendentemente dalle celle di origine.

Questo esempio crea un grafico a colonne impilate al 100% con serie rosse e blu su quattro categorie. Ogni coppia di valori somma 1. Il formato dell'etichetta `0.0%` visualizza 0,30 come 30,0%, mentre l'asse verticale utilizza due cifre decimali. Entrambe le serie usano testo etichetta bianco, da 10 punti.

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

## **Leggere il testo effettivo delle etichette dei dati**

Usa [getActualLabelText](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabel/#getActualLabelText) per recuperare il testo generato dalle impostazioni di un'etichetta di dati. Ciò è utile quando si estraggono le etichette per i report, si cerca il contenuto della presentazione o si convalidano i grafici generati. Nell'esempio seguente, il [formato di etichetta dati](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabelformat/) predefinito combina il nome di ciascuna categoria, il nome della serie e il valore. Un punto formatta il suo valore come percentuale, e un altro utilizza testo personalizzato da [getTextFrameForOverriding](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Il numero memorizzato in un punto dati rimane `0.75`, anche quando la sua etichetta mostra `75%` insieme ai nomi di categoria e di serie. Il testo personalizzato sostituisce il testo generato dell'etichetta. [getActualLabelText](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabel/#getActualLabelText) restituisce la stringa dell'etichetta risultante in entrambi i casi. Verifica [isVisible](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabel/#isVisible) separatamente, come mostrato sopra, quando desideri estrarre solo le etichette visibili.

## **Controllare le etichette dei dati oltre il valore massimo dell'asse**

Quando limiti manualmente l'intervallo di un asse, alcuni punti dati possono superare il valore massimo. Usa [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) per controllare se le loro etichette dei dati vengono visualizzate. Questa impostazione modifica la visibilità dell'etichetta; non modifica l'intervallo dell'asse né i valori sottostanti.

L'esempio seguente crea un grafico a colonne raggruppate 2D con valori 60 e 120. Passa `False` a [setAutomaticMaxValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#setAutomaticMaxValue) e imposta il massimo a 100 con [setMaxValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#setMaxValue) sull'asse verticale. La prima diapositiva permette etichette oltre il massimo; una copia di quella diapositiva le disabilita. Entrambe le diapositive sono salvate in `DataLabelsOverMaximum.pptx`.

Abilita le etichette dei valori con [setShowValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabelformat/#setShowValue). L'impostazione a livello di grafico non abilita la visualizzazione dei valori di per sé né sovrascrive la visualizzazione dei valori disabilitata per un'etichetta individuale. Questo esempio abilita i valori per l'intera serie e utilizza [setPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabelformat/#setPosition) per posizionare le etichette all'estremità esterna di ogni colonna.

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

Le immagini seguenti mostrano le diapositive salvate renderizzate da Microsoft PowerPoint. Con `True`, l'etichetta **120** è visibile al limite superiore; con `False`, è nascosta. L'etichetta **60** rimane visibile, il valore massimo dell'asse resta a **100**, e il secondo punto dati rimane **120** in entrambi i casi.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Grafico PowerPoint che mostra l'etichetta di valore 120 con un valore massimo dell'asse di 100](data-labels-over-maximum-true.png) | ![Grafico PowerPoint che nasconde l'etichetta di valore 120 con un valore massimo dell'asse di 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Questo esempio utilizza un grafico a colonne 2D con un asse dei valori. I grafici senza un asse dei valori, come i grafici a torta e a ciambella, non hanno un valore massimo dell'asse da limitare in questo modo.
{{% /alert %}}

## **Impostare la distanza dell'etichetta dall'asse**

Usa [setLabelOffset](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#setLabelOffset) per controllare la distanza tra le etichette dell'asse di categoria e l'asse. Il valore è una percentuale della dimensione massima del carattere delle etichette dell'asse. Questo esempio crea un grafico a colonne raggruppate e imposta lo scostamento dell'etichetta dell'asse orizzontale a 500. Questa impostazione influisce sulle etichette dell'asse di categoria piuttosto che sulle etichette associate a singoli punti dati.

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

Su un grafico a torta, regola le posizioni delle etichette dei dati per migliorare la spaziatura e fare spazio alle linee guida.

Questo esempio visualizza il valore del primo punto dati, posiziona la sua etichetta all'esterno della fetta e regola gli offset orizzontali e verticali usando [setX](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabel/#setX) e [setY](https://reference.aspose.com/slides/it/python-java/aspose.slides/datalabel/#setY). Questi offset sono relativi alla larghezza e all'altezza del grafico, rispettivamente.

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

![Grafico a torta con posizione dell'etichetta dei dati regolata](pie-chart-adjusted-label.png)

## **FAQ**

**Come posso impedire la sovrapposizione delle etichette dei dati su grafici densi?**

Combina il posizionamento automatico delle etichette, le linee guida e una dimensione del carattere ridotta; se necessario, nascondi alcuni campi (ad esempio, la categoria) o mostra le etichette solo per i valori estremi o i punti chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come posso garantire uno stile di etichetta coerente durante l'esportazione in PDF/immagini?**

Imposta esplicitamente la famiglia e la dimensione del carattere e verifica che il font sia disponibile nell'ambiente di rendering per evitare il fallback.