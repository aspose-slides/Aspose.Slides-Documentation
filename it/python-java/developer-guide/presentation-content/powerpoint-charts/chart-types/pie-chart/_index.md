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
- opzioni del tracciato
- colore della sezione
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea e personalizza grafici a torta in Python via Java con Aspose.Slides. Configura tracciati secondari, visualizza etichette dei dati e applica colori automatici alle sezioni in PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle sezioni per un grafico a torta standard.

Gli esempi si concentrano su attività di personalizzazione del grafico come aggiungere un grafico a una diapositiva, modificare le impostazioni delle serie e delle etichette, sostituire i dati di default del grafico con categorie e valori personalizzati, e salvare la presentazione aggiornata.

## **Opzioni del Tracciato Secondario per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides for Python via Java supporta le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie. Queste opzioni controllano la dimensione del tracciato secondario e come i punti dati sono suddivisi tra i due tracciati.

L'esempio seguente crea un grafico Pie of Pie in una nuova presentazione e visualizza i valori dei punti dati come etichette. Il metodo [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) imposta la dimensione del tracciato secondario al 149% del tracciato principale. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) seleziona la suddivisione basata su percentuale, e [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) imposta la soglia al 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Visualizza i valori e configura il tracciato secondario.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Seleziona le Categorie per il Tracciato Secondario**

Utilizza la suddivisione personalizzata quando vuoi raggruppare categorie specifiche nel tracciato secondario indipendentemente dai loro valori percentuali. Per esempio, un report di vendite potrebbe mostrare Online e Events insieme affinché i lettori possano confrontare questi due canali, anche se rappresentano il 35% e il 10% delle vendite totali.

Chiama [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) con [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) e seleziona i punti tramite [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Il metodo [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) della collezione accetta un indice basato su zero nella serie; usa [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) per aggiungere un oggetto punto dati. In questo esempio, l'indice 1 seleziona Online, e il punto all'indice 3 seleziona Events. Partners viene aggiunto temporaneamente, poi escluso usando [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Sostituisci i dati predefiniti con le vendite per canale.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Seleziona Online per il suo indice basato su zero e Events per il suo oggetto punto dati.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Escludi Partners dalla selezione senza eliminare i suoi dati di origine.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) e Events (10) appaiono come sezioni separate nel tracciato secondario. Nel tracciato principale, sono rappresentati da una singola sezione combinata con valore 45, insieme a Retail (40) e Partners (15). Rimuovere Partners dalla selezione personalizzata lo mantiene nel tracciato principale; non rimuove la categoria o il suo valore dai dati di origine del grafico.

L'immagine seguente mostra la presentazione salvata in PowerPoint:

![Grafico Pie of Pie con Online ed Events nel tracciato secondario e il loro valore combinato di 45 nel tracciato principale](pie_of_pie_custom.png)

## **Imposta i Colori Automatici delle Sezioni del Grafico a Torta**

Aspose.Slides for Python via Java può assegnare automaticamente colori diversi alle sezioni del grafico a torta. L'esempio seguente crea un grafico a torta con un titolo centrato e sostituisce i dati di default con tre categorie trimestrali e i loro valori. Il metodo [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) visualizza i valori 20, 50 e 30 come etichette, mentre [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) abilita un colore distinto per ogni sezione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Aggiungi un titolo del grafico centrato.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Sostituisci i dati predefiniti usando il primo foglio di lavoro.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Visualizza i valori e assegna colori diversi alle sezioni.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Le varianti Pie of Pie e Bar of Pie sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) un tracciato secondario per i grafici a torta, incluse le tipologie Pie of Pie e Bar of Pie.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (ad esempio PNG) senza esportare l'intera presentazione.