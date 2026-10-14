---
title: Personalizza i grafici a torta nelle presentazioni con Python
linktitle: Grafico a torta
type: docs
url: /it/python-net/pie-chart/
keywords:
- grafico a torta
- gestione grafico
- personalizzazione grafico
- opzioni grafico
- impostazioni grafico
- opzioni tracciato
- colore fetta
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea e personalizza grafici a torta in Python con Aspose.Slides. Configura tracciati secondari, visualizza le etichette dei dati e applica colori automatici alle fette in PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni del tracciato secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su attività di personalizzazione dei grafici, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati di default del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni del Tracciato Secondario per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides for Python via .NET supporta le opzioni del tracciato secondario per i grafici Pie of Pie e Bar of Pie. Queste opzioni controllano la dimensione del tracciato secondario e come i punti dati vengono suddivisi tra i due tracciati.

Il seguente esempio crea un grafico Pie of Pie in una nuova presentazione e visualizza i valori dei punti dati come etichette. La proprietà [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) imposta la dimensione del tracciato secondario al 149% del tracciato principale. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) seleziona la suddivisione basata sulla percentuale, e [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) imposta la soglia al 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Visualizza i valori e configura il tracciato secondario.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Seleziona le Categorie per il Tracciato Secondario**

Utilizza la suddivisione personalizzata quando desideri raggruppare categorie specifiche nel tracciato secondario indipendentemente dai loro valori percentuali. Ad esempio, un report di vendite potrebbe mostrare Online e Events insieme in modo che i lettori possano confrontare questi due canali, anche se rappresentano il 35% e il 10% delle vendite totali.

Imposta [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) a [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) e seleziona i punti tramite [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Il metodo [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) della collezione accetta sia un indice basato su zero nella serie sia un oggetto punto dati. In questo esempio, l'indice 1 seleziona Online, e il punto all'indice 3 seleziona Events. Partners viene aggiunto temporaneamente, poi escluso usando [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Sostituisci i dati predefiniti con le vendite per canale.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Seleziona Online tramite il suo indice basato su zero ed Events tramite il suo oggetto punto dati.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Escludi Partners dalla selezione senza eliminare i dati di origine.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) ed Events (10) appaiono come fette separate nel tracciato secondario. Nel tracciato principale, sono rappresentati da una sola fetta combinata con valore 45, insieme a Retail (40) e Partners (15). Rimuovere Partners dalla selezione personalizzata lo mantiene nel tracciato principale; non rimuove la categoria o il suo valore dai dati di origine del grafico.

L'immagine seguente mostra la presentazione salvata in PowerPoint:

![Grafico Pie of Pie con Online ed Events nel tracciato secondario e il loro valore combinato di 45 nel tracciato principale](pie_of_pie_custom.png)

## **Imposta i Colori Automatici delle Fette del Grafico a Torta**

Aspose.Slides per Python via .NET può assegnare automaticamente colori diversi alle fette del grafico a torta. Il seguente esempio crea un grafico a torta con un titolo centrato e sostituisce i dati di default con tre categorie trimestrali e i loro valori. La proprietà [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) visualizza i valori 20, 50 e 30 come etichette, mentre [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) abilita un colore distinto per ogni fetta.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Aggiungi un titolo centrato al grafico.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Sostituisci i dati predefiniti usando il primo foglio di lavoro.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Mostra i valori assegna colori diversi alle fette.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Domande frequenti**

**Le varianti Pie of Pie e Bar of Pie sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) un tracciato secondario per i grafici a torta, includendo i tipi Pie of Pie e Bar of Pie.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (ad esempio PNG) senza esportare l'intera presentazione.