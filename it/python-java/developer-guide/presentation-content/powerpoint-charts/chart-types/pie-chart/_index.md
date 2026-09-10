---
title: Personalizza i grafici a torta nelle presentazioni usando Python via Java
linktitle: Grafico a torta
type: docs
url: /it/python-java/pie-chart/
keywords:
- grafico a torta
- gestire il grafico
- personalizzare il grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di tracciamento
- colore della fetta
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a torta in Python via Java con Aspose.Slides, esportabili in PowerPoint, migliorando la narrazione dei tuoi dati in pochi secondi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni del secondo tracciato per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su passaggi pratici di personalizzazione dei grafici, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati del grafico predefiniti con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni del Secondo Tracciato per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides for Python via Java supporta le opzioni del secondo tracciato per i grafici Pie of Pie e Bar of Pie. Questa sezione mostra come specificare tali opzioni usando Aspose.Slides. Segui questi passaggi:

1. Istanzia un oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Aggiungi un grafico alla diapositiva.
1. Specifica le opzioni del secondo tracciato del grafico.
1. Scrivi la presentazione su disco.

Nel seguente esempio vengono impostate diverse proprietà di un grafico Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    # Aggiungi un grafico alla diapositiva.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Imposta proprietà diverse.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Scrivi la presentazione su disco.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta i Colori Automatici delle Fette del Grafico a Torta**

Aspose.Slides for Python via Java fornisce un'API semplice per impostare i colori automatici delle fette del grafico a torta. Il seguente esempio dimostra come applicare queste impostazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Imposta il titolo del grafico.
1. Imposta l'indice del foglio di lavoro dei dati del grafico.
1. Ottieni la cartella di lavoro dei dati del grafico.
1. Elimina le serie e le categorie predefinite.
1. Aggiungi nuove categorie.
1. Aggiungi una nuova serie.
1. Imposta la nuova serie per mostrare i valori.

Scrivi la presentazione modificata in un file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    # Aggiungi un grafico con dati predefiniti.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Imposta il titolo del grafico.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Imposta l'indice del foglio di lavoro dei dati del grafico.
    default_worksheet_index = 0

    # Ottieni la cartella di lavoro dei dati del grafico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Elimina le serie e le categorie predefinite.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Aggiungi nuove categorie.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Aggiungi una nuova serie.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Popola i dati della serie.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Imposta la nuova serie per mostrare i valori.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Le variazioni 'Pie of Pie' e 'Bar of Pie' sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/) un secondo tracciato per i grafici a torta, inclusi i tipi 'Pie of Pie' e 'Bar of Pie'.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) (ad esempio PNG) senza l'intera presentazione.