---
title: Crea o aggiorna i grafici delle presentazioni PowerPoint in Python
linktitle: Crea o aggiorna i grafici
type: docs
weight: 10
url: /it/python-net/create-chart/
keywords:
  - aggiungi grafico
  - crea grafico
  - modifica grafico
  - cambia grafico
  - aggiorna grafico
  - grafico a dispersione
  - grafico a torta
  - grafico a linee
  - grafico a mappa ad albero
  - grafico azionario
  - grafico a scatola e baffi
  - grafico a imbuto
  - grafico a raggi
  - grafico istogramma
  - grafico radar
  - grafico multi-categoria
  - presentazione PowerPoint
  - Python
  - Aspose.Slides
description: "Scopri come creare e personalizzare i grafici in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET. Include l'aggiunta, la formattazione e la modifica dei grafici nelle presentazioni con esempi pratici di codice in Python."
---
## **Panoramica**

Questo articolo spiega come creare e personalizzare i grafici usando Aspose.Slides per Python tramite .NET. Imparerai come aggiungere un grafico a una diapositiva, popolarlo con dati e formattarlo per soddisfare i requisiti di design. Gli esempi di codice coprono la creazione di presentazioni e grafici, la configurazione di serie, assi e legende, e l'integrazione della generazione di grafici nelle tue applicazioni.

## **Creare un grafico**

I grafici aiutano le persone a visualizzare rapidamente i dati e a ottenere intuizioni che potrebbero non essere immediatamente evidenti da una tabella o da un foglio di calcolo.

**Perché creare grafici?**

Usando i grafici, è possibile:

* aggregare, condensare o riassumere grandi quantità di dati in una singola diapositiva di una presentazione;
* evidenziare modelli e tendenze nei dati;
* dedurre la direzione e la dinamica dei dati nel tempo o rispetto a un'unità di misura specifica;
* individuare valori anomali, deviazioni, errori e dati senza senso;
* comunicare o presentare dati complessi.

In PowerPoint, è possibile creare grafici tramite la funzione *Inserisci*, che fornisce modelli per progettare molti tipi di grafici. Usando Aspose.Slides, è possibile creare sia grafici standard (basati su tipi di grafico popolari) sia grafici personalizzati.

{{% alert color="info" title="Note" %}}

Utilizza l'enumerazione [ChartType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/charttype/) nello spazio dei nomi [Aspose.Slides.Charts](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/). I valori in questa enumerazione corrispondono a diversi tipi di grafico.

{{% /alert %}}

### **Creare grafici a colonne raggruppate**

Questa sezione spiega come creare grafici a colonne raggruppate usando Aspose.Slides per Python tramite .NET. Imparerai a inizializzare una presentazione, aggiungere un grafico e personalizzare i suoi elementi come titolo, dati, serie, categorie e stile. Segui i passaggi sotto per vedere come viene generato un grafico a colonne raggruppate standard:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con alcuni dati e specifica il tipo `ChartType.CLUSTERED_COLUMN`.
1. Aggiungi un titolo al grafico.
1. Accedi al foglio dati del grafico.
1. Cancella tutte le serie e categorie predefinite.
1. Aggiungi nuove serie e categorie.
1. Aggiungi nuovi dati al grafico per le serie.
1. Applica un colore di riempimento alle serie del grafico.
1. Aggiungi etichette alle serie del grafico.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python dimostra come creare un grafico a colonne raggruppate:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Instanzia la classe Presentation che rappresenta un file PPTX.
    with slides.Presentation() as presentation:

        # Accedi alla prima diapositiva.
        slide = presentation.slides[0]

        # Aggiungi un grafico a colonne raggruppate con i dati predefiniti.
        chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

        # Imposta il titolo del grafico.
        chart.chart_title.add_text_frame_for_overriding("Sample Title")
        chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
        chart.chart_title.height = 20
        chart.has_title = True

        # Imposta l'indice del foglio dati del grafico.
        worksheet_index = 0

        # Ottieni il workbook dei dati del grafico.
        workbook = chart.chart_data.chart_data_workbook

        # Elimina le serie e le categorie generate di default.
        chart.chart_data.series.clear()
        chart.chart_data.categories.clear()

        # Aggiungi nuove serie.
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

        # Aggiungi nuove categorie.
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

        # Ottieni la prima serie del grafico.
        series = chart.chart_data.series[0]

        # Popola i dati della serie.
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

        # Imposta il colore di riempimento per la serie.
        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = draw.Color.red

        # Ottieni la seconda serie del grafico.
        series = chart.chart_data.series[1]

        # Popola i dati della serie.
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

        # Imposta il colore di riempimento per la serie.
        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = draw.Color.green

        # Imposta la prima etichetta per mostrare il nome della categoria.
        label = series.data_points[0].label
        label.data_label_format.show_category_name = True

        label = series.data_points[1].label
        label.data_label_format.show_series_name = True

        # Imposta la serie per mostrare il valore per la terza etichetta.
        label = series.data_points[2].label
        label.data_label_format.show_value = True
        label.data_label_format.show_series_name = True
        label.data_label_format.separator = "/"
                
        # Salva la presentazione su disco come file PPTX.
        presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The clustered column chart](clustered_column_chart.png)

### **Creare grafici a dispersione**

I grafici a dispersione (noti anche come scatter plot o grafici x‑y) sono spesso usati per verificare la presenza di pattern o dimostrare correlazioni tra due variabili.

Usa un grafico a dispersione quando:

* Hai dati numerici accoppiati.
* Hai due variabili che si abbinano bene insieme.
* Vuoi determinare se le due variabili sono correlate.
* Hai una variabile indipendente che ha più valori per una variabile dipendente.

Questo codice Python mostra come creare un grafico a dispersione con marcatori diversi per ogni serie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Istanzia la classe Presentation.
    with slides.Presentation() as presentation:

        # Accedi alla prima diapositiva.
        slide = presentation.slides[0]

        # Crea il grafico a dispersione predefinito.
        chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

        # Imposta l'indice del foglio dati del grafico.
        worksheet_index = 0

        # Ottieni il workbook dei dati del grafico.
        workbook = chart.chart_data.chart_data_workbook

        # Elimina la serie predefinita.
        chart.chart_data.series.clear()

        # Aggiungi nuove serie.
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

        # Ottieni la prima serie del grafico.
        series = chart.chart_data.series[0]

        # Aggiungi un nuovo punto (1:3) alla serie.
        series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

        # Aggiungi un nuovo punto (2:10).
        series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

        # Cambia il tipo della serie.
        series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

        # Cambia il marcatore della serie del grafico.
        series.marker.size = 10
        series.marker.symbol = charts.MarkerStyleType.STAR

        # Ottieni la seconda serie del grafico.
        series = chart.chart_data.series[1]

        # Aggiungi un nuovo punto (5:2) alla serie del grafico.
        series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

        # Aggiungi un nuovo punto (3:1).
        series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

        # Aggiungi un nuovo punto (2:2).
        series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

        # Aggiungi un nuovo punto (5:1).
        series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

        # Cambia il marcatore della serie del grafico.
        series.marker.size = 10
        series.marker.symbol = charts.MarkerStyleType.CIRCLE

        presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The scatter chart](scatter_chart.png)

### **Creare grafici a torta**

I grafici a torta sono ideali per mostrare la relazione parte‑intero nei dati, soprattutto quando i dati contengono etichette categoriche con valori numerici. Tuttavia, se i tuoi dati contengono molte parti o etichette, potresti considerare l'uso di un grafico a barre.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.PIE`.
1. Accedi al workbook dei dati del grafico ([ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Cancella le serie e le categorie predefinite.
1. Aggiungi nuove serie e categorie.
1. Aggiungi nuovi dati al grafico per le serie.
1. Aggiungi nuovi punti al grafico e applica colori personalizzati ai settori della torta.
1. Imposta le etichette per le serie.
1. Abilita le linee guida per le etichette delle serie.
1. Imposta l'angolo di rotazione per il grafico a torta.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico a torta:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Istanzia la classe Presentation che rappresenta un file PPTX.
    with slides.Presentation() as presentation:

        # Accedi alla prima diapositiva.
        slide = presentation.slides[0]

        # Aggiungi un grafico con i suoi dati predefiniti.
        chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

        # Imposta il titolo del grafico.
        chart.chart_title.add_text_frame_for_overriding("Sample Title")
        chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
        chart.chart_title.height = 20
        chart.has_title = True

        # Imposta l'indice del foglio dati del grafico.
        worksheet_index = 0

        # Ottieni il workbook dei dati del grafico.
        workbook = chart.chart_data.chart_data_workbook

        # Elimina le serie e le categorie generate di default.
        chart.chart_data.series.clear()
        chart.chart_data.categories.clear()

        # Aggiungi nuove categorie.
        chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
        chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
        chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

        # Aggiungi nuove serie.
        series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

        # Popola i dati della serie.
        series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
        series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
        series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

        # Imposta il colore del settore.
        chart.chart_data.series_groups[0].is_color_varied = True

        point = series.data_points[0]
        point.format.fill.fill_type = slides.FillType.SOLID
        point.format.fill.solid_fill_color.color = draw.Color.cyan

        # Imposta il bordo del settore.
        point.format.line.fill_format.fill_type = slides.FillType.SOLID
        point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
        point.format.line.width = 3.0
        point.format.line.style = slides.LineStyle.THIN_THICK
        point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

        point1 = series.data_points[1]
        point1.format.fill.fill_type = slides.FillType.SOLID
        point1.format.fill.solid_fill_color.color = draw.Color.brown

        # Imposta il bordo del settore.
        point1.format.line.fill_format.fill_type = slides.FillType.SOLID
        point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
        point1.format.line.width = 3.0
        point1.format.line.style = slides.LineStyle.SINGLE
        point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

        point2 = series.data_points[2]
        point2.format.fill.fill_type = slides.FillType.SOLID
        point2.format.fill.solid_fill_color.color = draw.Color.coral

        # Imposta il bordo del settore.
        point2.format.line.fill_format.fill_type = slides.FillType.SOLID
        point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
        point2.format.line.width = 2.0
        point2.format.line.style = slides.LineStyle.THIN_THIN
        point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

        # Crea etichette personalizzate per ogni categoria nella nuova serie.
        label1 = series.data_points[0].label

        label1.data_label_format.show_value = True

        label2 = series.data_points[1].label
        label2.data_label_format.show_value = True
        label2.data_label_format.show_legend_key = True
        label2.data_label_format.show_percentage = True

        label3 = series.data_points[2].label
        label3.data_label_format.show_series_name = True
        label3.data_label_format.show_percentage = True

        # Imposta la serie per mostrare le linee guida per il grafico.
        series.labels.default_data_label_format.show_leader_lines = True

        # Imposta l'angolo di rotazione per i settori del grafico a torta.
        chart.chart_data.series_groups[0].first_slice_angle = 180

        # Salva la presentazione su disco come file PPTX.
        presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The pie chart](pie_chart.png)

### **Creare grafici a linee**

I grafici a linee (noti anche come grafici lineari) sono ideali quando si desidera dimostrare variazioni di valore nel tempo. Con un grafico a linee, è possibile confrontare una grande quantità di dati simultaneamente, monitorare cambiamenti e tendenze nel tempo, evidenziare anomalie nelle serie di dati e altro ancora.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.LINE`.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico a linee:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Per impostazione predefinita, i punti di un grafico a linee sono collegati da linee continue rette. Se desideri che i punti siano collegati da linee tratteggiate, puoi specificare il tipo di tratto preferito come segue:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The line chart](line_chart.png)

### **Creare grafici a mappa ad albero**

I grafici a mappa ad albero sono ideali per dati di vendita quando vuoi mostrare la dimensione relativa delle categorie di dati e attirare rapidamente l'attenzione sugli elementi che contribuiscono maggiormente all'interno di ciascuna categoria.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.TREEMAP`.
1. Accedi al workbook dei dati del grafico ([ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Cancella le serie e le categorie predefinite.
1. Aggiungi nuove serie e categorie.
1. Aggiungi nuovi dati al grafico per le serie.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico a mappa ad albero:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Ramo 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Ramo 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The treemap chart](treemap_chart.png)

### **Creare grafici azionari**

I grafici azionari vengono utilizzati per visualizzare dati finanziari come prezzi di apertura, massimo, minimo e chiusura, aiutando ad analizzare le tendenze di mercato e la volatilità. Offrono approfondimenti essenziali sulle performance delle azioni, facilitando decisioni informate per investitori e analisti.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.OPEN_HIGH_LOW_CLOSE`.
1. Accedi al workbook dei dati del grafico ([ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Cancella le serie e le categorie predefinite.
1. Aggiungi nuove serie e categorie.
1. Aggiungi nuovi dati al grafico per le serie.
1. Specifica il formato delle linee alto‑basso.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico azionario:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The stock chart](stock_chart.png)

### **Creare grafici a scatola e baffi**

I grafici a scatola e baffi sono usati per visualizzare la distribuzione dei dati riepilogando misure statistiche chiave, come la mediana, i quartili e i potenziali outlier. Sono particolarmente utili nell'analisi esplorativa dei dati e negli studi statistici per comprendere rapidamente la variabilità dei dati e identificare eventuali anomalie.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.BOX_AND_WHISKER`.
1. Accedi al workbook dei dati del grafico ([ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Cancella le serie e le categorie predefinite.
1. Aggiungi nuove serie e categorie.
1. Aggiungi nuovi dati al grafico per le serie.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico a scatola e baffi:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Creare grafici a imbuto**

I grafici a imbuto sono usati per visualizzare processi che coinvolgono fasi sequenziali, dove il volume dei dati diminuisce man mano che avanza da un passo al successivo. Sono particolarmente utili per analizzare i tassi di conversione, individuare colli di bottiglia e monitorare l'efficienza dei processi di vendita o marketing.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.FUNNEL`.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico a imbuto:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The funnel chart](funnel_chart.png)

### **Creare grafici a raggi**

I grafici a raggi sono usati per visualizzare dati gerarchici, mostrando i livelli come anelli concentrici. Aiutano a illustrare relazioni parte‑intero e sono ideali per rappresentare categorie e sotto‑categorie annidate in modo chiaro e compatto.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.SUNBURST`.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico a raggi:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Ramo 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Ramo 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The sunburst chart](sunburst_chart.png)

### **Creare istogrammi**

Gli istogrammi sono usati per rappresentare la distribuzione di dati numerici raggruppando i valori in intervalli o bin. Sono particolarmente utili per identificare pattern nei dati come frequenza, asimmetria e dispersione, nonché per rilevare outlier in un dataset.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con alcuni dati e specifica il tipo `ChartType.HISTOGRAM`.
1. Accedi al workbook dei dati del grafico ([ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Cancella le serie e le categorie predefinite.
1. Aggiungi una nuova serie e popolala con punti dati. Un istogramma non ha categorie; i bin sono calcolati dai valori.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un istogramma:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The histogram chart](histogram_chart.png)

### **Creare grafici radar**

I grafici radar sono usati per visualizzare dati multivariati in un formato bidimensionale, consentendo un facile confronto di più variabili simultaneamente. Sono particolarmente utili per identificare pattern, punti di forza e debolezze su più metriche o attributi di performance.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con alcuni dati e specifica il tipo `ChartType.RADAR`.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico radar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The radar chart](radar_chart.png)

### **Creare grafici multi‑categoria**

I grafici multi‑categoria sono usati per visualizzare dati che coinvolgono più di un raggruppamento categorico, consentendo di confrontare i valori su più dimensioni simultaneamente. Sono particolarmente utili quando è necessario analizzare tendenze e relazioni in dataset complessi e a più livelli.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo `ChartType.CLUSTERED_COLUMN`.
1. Accedi al workbook dei dati del grafico ([ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Cancella le serie e le categorie predefinite.
1. Aggiungi nuove serie e categorie.
1. Aggiungi nuovi dati al grafico per le serie.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un grafico multi‑categoria:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Aggiungi una serie.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Salva la presentazione con il grafico.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The multi-category chart](multi_category_chart.png)

### **Creare grafici cartografici**

I grafici cartografici sono usati per visualizzare dati geografici mappando informazioni su posizioni specifiche come paesi, stati o città. Sono particolarmente utili per analizzare tendenze regionali, dati demografici e distribuzioni spaziali in modo chiaro e visualmente accattivante.

Questo codice Python mostra come creare un grafico cartografico:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The map chart](map_chart.png)

### **Creare grafici combinati**

Un grafico combinato (o combo) combina due o più tipi di grafico in un unico diagramma. Questo grafico consente di evidenziare, confrontare o esaminare differenze tra due o più set di dati, aiutandoti a identificare le relazioni tra di essi.

![The combination chart](combination_chart.png)

Il seguente codice Python mostra come creare il grafico combinato mostrato sopra in una presentazione PowerPoint:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # Imposta il titolo del grafico.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Imposta la legenda del grafico.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Elimina le serie e le categorie generate di default.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Aggiungi nuove categorie.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Aggiungi la prima serie.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Imposta l'asse orizzontale.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Imposta l'asse verticale.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Imposta il colore delle linee della griglia principale verticale.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Imposta l'asse orizzontale secondario.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Imposta l'asse verticale secondario.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **Aggiornare i grafici**

Aspose.Slides per Python tramite .NET consente di aggiornare i dati, la formattazione e lo stile dei grafici per mantenere le presentazioni PowerPoint aggiornate.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per aprire la presentazione contenente il grafico.
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Scorri tutte le forme per trovare il grafico.
1. Accedi al foglio dati del grafico.
1. Modifica le serie di dati del grafico cambiando i valori delle serie.
1. Aggiungi una nuova serie e popolala con i dati.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come aggiornare un grafico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanzia la classe Presentation che rappresenta un file PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Imposta l'indice del foglio dati del grafico.
            worksheet_index = 0

            # Ottieni il workbook dei dati del grafico.
            workbook = chart.chart_data.chart_data_workbook

            # Modifica i nomi delle categorie del grafico.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Ottieni la prima serie del grafico.
            series = chart.chart_data.series[0]

            # Aggiorna i dati della serie.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Modifica il nome della serie.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Ottieni la seconda serie del grafico.
            series = chart.chart_data.series[1]

            # Aggiorna i dati della serie.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Modifica il nome della serie.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Aggiungi una nuova serie.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Popola i dati della serie.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Salva la presentazione con il grafico.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare l'intervallo dati per un grafico**

Aspose.Slides per Python tramite .NET consente di utilizzare un intervallo di foglio specifico come origine dati per un grafico. Questo controlla quali celle forniscono le serie e le categorie del grafico e permette di aggiornare il grafico per riflettere le modifiche nel foglio.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per aprire la presentazione contenente il grafico.
1. Ottieni un riferimento a una diapositiva usando il suo indice.
1. Scorri tutte le forme per trovare il grafico.
1. Accedi ai dati del grafico e imposta l'intervallo.
1. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come impostare l'intervallo dati per un grafico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanzia la classe Presentation che rappresenta un file PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Usare i marcatori predefiniti nei grafici**

Quando utilizzi i marcatori predefiniti nei grafici, ogni serie del grafico riceve automaticamente un simbolo di marcatura diverso.

Questo codice Python mostra come impostare automaticamente il marcatore di una serie del grafico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Popola i dati della serie.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quali tipi di grafico sono supportati da Aspose.Slides per Python tramite .NET?**

Aspose.Slides per Python tramite .NET supporta un'ampia gamma di tipi di grafico, tra cui barre, linee, torta, area, dispersione, istogramma, radar e molti altri. Questa flessibilità consente di scegliere il tipo di grafico più appropriato per le proprie esigenze di visualizzazione dei dati.

**Come aggiungo un nuovo grafico a una diapositiva?**

Per aggiungere un grafico, crea prima un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), recupera la diapositiva desiderata usando il suo indice e quindi chiama il metodo per aggiungere un grafico, specificando il tipo di grafico e i dati iniziali. Questo processo integra il grafico direttamente nella tua presentazione.

**Come posso aggiornare i dati visualizzati in un grafico?**

Puoi aggiornare i dati di un grafico accedendo al suo workbook dei dati ([ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/)), cancellando eventuali serie e categorie predefinite, e quindi aggiungendo i dati personalizzati. Questo ti permette di aggiornare programmaticamente il grafico per riflettere gli ultimi dati.

**È possibile personalizzare l'aspetto del grafico?**

Sì, Aspose.Slides per Python tramite .NET offre ampie opzioni di personalizzazione. Puoi modificare colori, caratteri, etichette, legende e altri elementi di formattazione per adattare l'aspetto del grafico ai requisiti di progettazione specifici.