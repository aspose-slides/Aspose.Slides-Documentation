---
title: Personalizza i grafici a torta nelle presentazioni con Python
linktitle: Grafico a torta
type: docs
url: /it/python-net/pie-chart/
keywords:
- grafico a torta
- gestire il grafico
- personalizzare il grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di tracciato
- colore della fetta
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a torta in Python con Aspose.Slides, esportabili in PowerPoint e OpenDocument, migliorando la narrazione dei tuoi dati in pochi secondi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su passaggi pratici di personalizzazione del grafico, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati di default del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni di Tracciato Secondario per i Grafici Pie of Pie e Bar of Pie**
Aspose.Slides for Python via .NET ora supporta le opzioni di tracciato secondario per i grafici Pie of Pie o Bar of Pie. In questo argomento, vedremo con un esempio come specificare queste opzioni utilizzando Aspose.Slides. Per specificare le proprietà, seguite i passaggi seguenti:

1. Istanziare l'oggetto di classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Aggiungere un grafico alla diapositiva.
1. Specificare le opzioni di tracciato secondario del grafico.
1. Scrivere la presentazione su disco.

Nell'esempio riportato di seguito, abbiamo impostato diverse proprietà del grafico Pie of Pie.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crea un'istanza della classe Presentation
with slides.Presentation() as presentation:
    # Aggiungi un grafico alla diapositiva
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Imposta diverse proprietà
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Salva la presentazione su disco
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare i Colori Automatici delle Fette del Grafico a Torta**
Aspose.Slides per Python via .NET fornisce un'API semplice per impostare i colori automatici delle fette del grafico a torta. Il codice di esempio applica l'impostazione delle proprietà sopra citate.

1. Creare un'istanza della classe Presentation.
1. Accedere alla prima diapositiva.
1. Aggiungere un grafico con i dati predefiniti.
1. Impostare il titolo del grafico.
1. Impostare la prima serie su Mostra valori.
1. Impostare l'indice del foglio dati del grafico.
1. Ottenere il foglio di lavoro dei dati del grafico.
1. Eliminare le serie e le categorie generate di default.
1. Aggiungere nuove categorie.
1. Aggiungere nuove serie.

Scrivere la presentazione modificata in un file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanzia la classe Presentation che rappresenta il file PPTX
with slides.Presentation() as presentation:
	# Accedi alla prima diapositiva
	slide = presentation.slides[0]

	# Aggiungi un grafico con dati predefiniti
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Imposta il titolo del grafico
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Imposta la prima serie per mostrare i valori
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Imposta l'indice del foglio dati del grafico
	defaultWorksheetIndex = 0

	# Ottieni il foglio dati del grafico
	fact = chart.chart_data.chart_data_workbook

	# Elimina le serie e le categorie generate di default
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Aggiungi nuove categorie
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Aggiungi nuove serie
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Ora popola i dati della serie
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le varianti 'Pie of Pie' e 'Bar of Pie' sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/charttype/) un tracciato secondario per i grafici a torta, comprese le tipologie 'Pie of Pie' e 'Bar of Pie'.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/get_image/) (ad esempio PNG) senza l'intera presentazione.