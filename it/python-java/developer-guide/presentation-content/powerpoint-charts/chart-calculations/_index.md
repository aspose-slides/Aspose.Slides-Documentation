---
title: Ottimizza i calcoli dei grafici per le presentazioni in Python via Java
linktitle: Calcoli del grafico
type: docs
weight: 50
url: /it/python-java/chart-calculations/
keywords:
- calcoli del grafico
- elementi del grafico
- posizione dell'elemento
- posizione reale
- elemento figlio
- elemento genitore
- valori del grafico
- valore reale
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Comprendi i calcoli dei grafici, gli aggiornamenti dei dati e il controllo della precisione in Aspose.Slides per Python via Java per PPT e PPTX, con esempi pratici di codice Python."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori effettivi degli elementi del grafico, includendo la posizione reale e le dimensioni degli elementi del grafico e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori vengono popolati dopo la convalida del layout del grafico.

Inoltre, l'articolo dimostra come ottenere la posizione effettiva degli elementi genitore del grafico e come nascondere componenti del grafico quali il titolo, gli assi, la leggenda e le linee di griglia. Insieme, questi esempi ti aiutano a esaminare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**
Aspose.Slides for Python via Java fornisce un'API semplice per ottenere queste proprietà. I metodi della classe [Axis](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/) forniscono informazioni sui valori effettivi degli assi del grafico ([getActualMaxValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/it/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Chiamare prima il metodo [Chart.validateChartLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#validateChartLayout) per popolare queste proprietà con i valori effettivi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Calcolare la posizione effettiva degli elementi genitore del grafico**
Aspose.Slides for Python via Java fornisce un'API semplice per ottenere queste proprietà. I metodi della classe [ChartPlotArea](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/) forniscono informazioni sulla posizione e dimensione effettiva dell'area di tracciamento del grafico ([getActualX](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartplotarea/#getActualHeight)). Chiamare prima il metodo [Chart.validateChartLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#validateChartLayout) per popolare queste proprietà con i valori effettivi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Nascondere gli elementi del grafico**
Questa sezione spiega come nascondere le informazioni da un grafico. Utilizzando Aspose.Slides for Python via Java, è possibile nascondere **Title, Vertical Axis, Horizontal Axis** e **Grid Lines**. Il seguente esempio di codice mostra come utilizzare queste proprietà.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Nascondi il titolo del grafico.
    chart.setTitle(False)

    # Nascondi l'asse dei valori.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Nascondi l'asse delle categorie.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Nascondi la legenda.
    chart.setLegend(False)

    # Nascondi le linee della griglia principale.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Mantieni solo la prima serie. Rimuovendo dalla fine si mantengono validi gli indici rimanenti.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Imposta il colore della linea della serie.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**I libri di lavoro Excel esterni funzionano come fonte dati e come influisce questo sul ricalcolo?**

Sì. Un grafico può fare riferimento a un workbook esterno: quando si collega o si aggiorna la fonte esterna, le formule e i valori vengono prelevati da quel workbook e il grafico riflette gli aggiornamenti durante le operazioni di apertura/modifica. L'API consente di [specificare il workbook esterno](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#setExternalWorkbook) e di gestire i dati collegati.

**Posso calcolare e visualizzare linee di tendenza senza implementare la regressione da solo?**

Sì. Le [Trendlines](/slides/it/python-java/trend-line/) (lineari, esponenziali e altre) vengono aggiunte e aggiornate da Aspose.Slides; i loro parametri vengono ricalcolati automaticamente dai dati della serie, quindi non è necessario implementare i propri calcoli.

**Se una presentazione ha più grafici con collegamenti esterni, posso controllare quale workbook utilizza ogni grafico per i valori calcolati?**

Sì. Ogni grafico può puntare al proprio [workbook esterno](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#setExternalWorkbook), oppure è possibile creare/sostituire un workbook esterno per ciascun grafico indipendentemente dagli altri.