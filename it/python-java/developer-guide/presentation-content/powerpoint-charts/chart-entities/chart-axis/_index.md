---
title: Personalizza gli assi dei grafici nelle presentazioni usando Python
linktitle: Asse del grafico
type: docs
url: /it/python-java/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare l'asse
- manipolare l'asse
- gestire l'asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per Python via Java per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici in Aspose.Slides. Mostra come ottenere i valori effettivi degli assi, scambiare i dati tra gli assi, nascondere l'asse verticale o orizzontale per i grafici a linee, modificare il tipo di asse di categoria, impostare il formato data per i valori dell'asse di categoria, ruotare il titolo di un asse, impostare la posizione dell'asse e impostare l'unità di visualizzazione dell'asse dei valori.

## **Ottenere i valori massimi sull'asse verticale di un grafico**

Aspose.Slides for Python via Java consente di ottenere i valori minimo e massimo su un asse verticale. Segui questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Accedere alla prima diapositiva.
3. Aggiungere un grafico con dati predefiniti.
4. Ottenere il valore massimo effettivo sull'asse.
5. Ottenere il valore minimo effettivo sull'asse.
6. Ottenere l'unità principale effettiva dell'asse.
7. Ottenere l'unità secondaria effettiva dell'asse.
8. Ottenere la scala dell'unità principale effettiva dell'asse.
9. Ottenere la scala dell'unità secondaria effettiva dell'asse.

Questo codice di esempio—un'implementazione dei passaggi sopra—mostra come ottenere i valori richiesti in Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Salva la presentazione
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Scambiare i dati tra gli assi**

Aspose.Slides consente di scambiare rapidamente i dati tra gli assi: i dati rappresentati sull'asse verticale (asse y) vengono spostati sull'asse orizzontale (asse x) e viceversa.

Questo codice Python mostra come eseguire lo scambio di dati tra gli assi di un grafico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Carica i dati predefiniti del grafico nel workbook — switchRowColumn traspone il workbook,
    # quindi deve essere popolato per primo
    workbook = chart.getChartData().getChartDataWorkbook()

    # Scambia righe e colonne
    chart.getChartData().switchRowColumn()

    # Salva la presentazione
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Disabilitare l'asse verticale per i grafici a linee**

Questo codice Python mostra come nascondere l'asse verticale per un grafico a linee:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Disabilitare l'asse orizzontale per i grafici a linee**

Questo codice mostra come nascondere l'asse orizzontale per un grafico a linee:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modificare un asse di categoria**

Utilizzando il metodo [setCategoryAxisType](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#setCategoryAxisType), è possibile specificare il tipo di asse di categoria preferito (**date** o **text**). Questo codice in Python dimostra l'operazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Impostare il formato della data per i valori dell'asse di categoria**

Aspose.Slides for Python via Java consente di impostare il formato data per un valore dell'asse di categoria. L'operazione è dimostrata in questo codice Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare un angolo di rotazione per il titolo di un asse del grafico**

Aspose.Slides for Python via Java consente di impostare l'angolo di rotazione per il titolo di un asse del grafico. Questo codice Python dimostra l'operazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare la posizione dell'asse su un asse di categoria o di valore**

Aspose.Slides for Python via Java consente di impostare la posizione dell'asse su un asse di categoria o di valore. Questo codice Python mostra come eseguire l'operazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare l'unità di visualizzazione su un asse di valore del grafico**

Aspose.Slides for Python via Java consente di impostare l'unità di visualizzazione di un asse di valore del grafico. L'asse quindi scala le etichette dei tick secondo quell'unità: con [DisplayUnitType.Millions](https://reference.aspose.com/slides/it/python-java/aspose.slides/displayunittype/#Millions), un asse che arriva a 60 000 000 viene etichettato da 0 a 60. Questo codice Python dimostra l'operazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Come impostare il valore al quale un asse incrocia l'altro (incrocio degli assi)?**

Gli assi forniscono un [crossing setting](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#setCrossType): è possibile scegliere di incrociare a zero, al valore massimo di categoria/valore, o a un valore numerico specifico. Questo è utile per spostare l'asse X verso l'alto o verso il basso o per enfatizzare una linea di base.

**Come posizionare i segni di divisione rispetto all'asse (incrocio, esterno, interno)?**

Impostare la [tick mark position](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#setMajorTickMark) su "cross", "outside" o "inside". Questo influisce sulla leggibilità e aiuta a risparmiare spazio, soprattutto su grafici di piccole dimensioni.