---
title: Gestire le serie di dati del grafico in Python
linktitle: Serie di dati
type: docs
url: /it/python-net/chart-series/
keywords:
- serie di grafico
- sovrapposizione delle serie
- colore della serie
- colore della categoria
- nome della serie
- punto dati
- spazio della serie
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come gestire le serie di dati dei grafici in Python per PowerPoint (PPT/PPTX) con esempi pratici di codice e migliori pratiche per migliorare le tue presentazioni dei dati."
---
## **Panoramica**

Questo articolo descrive il ruolo di [ChartSeries](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/) in Aspose.Slides per Python, concentrandosi su come i dati sono strutturati e visualizzati all'interno delle presentazioni. Questi oggetti forniscono gli elementi fondamentali che definiscono insiemi individuali di punti dati, categorie e parametri di aspetto in un grafico. Lavorando con [ChartSeries](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/), gli sviluppatori possono integrare senza soluzione di continuità le fonti dati sottostanti e mantenere il controllo totale su come le informazioni vengono visualizzate, ottenendo presentazioni dinamiche e basate sui dati che trasmettono chiaramente approfondimenti e analisi.

Una serie è una riga o colonna di numeri tracciati in un grafico.

![serie-di-grafico-powerpoint](chart-series-powerpoint.png)

## **Imposta Sovrapposizione delle Serie**

La proprietà [ChartSeries.overlap](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/overlap/) controlla come le barre e le colonne si sovrappongono in un grafico 2D specificando un intervallo da -100 a 100. Poiché questa proprietà è associata al gruppo di serie anziché a singole serie di grafico, è di sola lettura a livello di serie. Per configurare i valori di sovrapposizione, utilizzare la proprietà `parent_series_group.overlap` di lettura/scrittura, che applica la sovrapposizione specificata a tutte le serie del gruppo.

Di seguito è riportato un esempio Python che dimostra come creare una presentazione, aggiungere un grafico a colonne raggruppate, accedere alla prima serie del grafico, configurare l'impostazione di sovrapposizione e quindi salvare il risultato come file PPTX:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Imposta la sovrapposizione della serie.
        series.parent_series_group.overlap = series_overlap

    # Salva il file della presentazione su disco.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La sovrapposizione della serie](series_overlap.png)

## **Modifica il Colore di Riempimento della Serie**

Aspose.Slides rende semplice la personalizzazione dei colori di riempimento delle serie di grafico, consentendo di evidenziare punti dati specifici e di creare grafici visivamente accattivanti. Ciò è realizzato tramite l'oggetto [Format](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/format/), che supporta vari tipi di riempimento, configurazioni di colore e altre opzioni di stile avanzate. Dopo aver aggiunto un grafico a una diapositiva e aver accesso alla serie desiderata, è sufficiente ottenere la serie e applicare il colore di riempimento appropriato. Oltre ai riempimenti solidi, è possibile utilizzare riempimenti a gradiente o a motivo per una maggiore flessibilità di design. Una volta impostati i colori secondo le proprie esigenze, salvare la presentazione per finalizzare l'aspetto aggiornato.

Il seguente esempio di codice Python mostra come cambiare il colore della prima serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Imposta il colore della prima serie.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Salva il file della presentazione su disco.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il colore della serie](series_color.png)

## **Rinomina una Serie**

Aspose.Slides offre un modo semplice per modificare i nomi delle serie di grafico, facilitando l'etichettatura dei dati in modo chiaro e significativo. Accedendo alla cella del foglio di lavoro pertinente nei dati del grafico, gli sviluppatori possono personalizzare la modalità di presentazione dei dati. Questa modifica è particolarmente utile quando i nomi delle serie devono essere aggiornati o chiariti in base al contesto dei dati. Dopo aver rinominato la serie, la presentazione può essere salvata per preservare le modifiche.

Di seguito è riportato un frammento di codice Python che dimostra questo processo in azione.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Imposta il nome della prima serie.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Salva il file della presentazione su disco.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Il seguente codice Python mostra un modo alternativo per cambiare il nome della serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Imposta il nome della prima serie.
    series.name.as_cells[0].value = series_name

    # Salva il file della presentazione su disco.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

Il risultato:

![Il nome della serie](series_name.png)

## **Ottieni il Colore di Riempimento Automatico della Serie**

Aspose.Slides per Python consente di ottenere il colore di riempimento automatico per le serie di grafico all'interno di un'area di tracciamento. Dopo aver creato un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), è possibile ottenere un riferimento alla diapositiva desiderata tramite indice, quindi aggiungere un grafico utilizzando il tipo preferito (ad esempio `ChartType.CLUSTERED_COLUMN`). Accedendo alle serie nel grafico, è possibile ottenere il colore di riempimento automatico.

Il codice Python qui sotto dimostra questo processo in dettaglio.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Ottieni il colore di riempimento della serie.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Esempio di Output:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Imposta Colori di Riempimento Invertiti per una Serie**

Quando la tua serie di dati contiene sia valori positivi che negativi, colorare ogni colonna o barra allo stesso modo può rendere il grafico difficile da leggere. Aspose.Slides per Python consente di assegnare un colore di riempimento invertito — un riempimento separato applicato automaticamente ai punti dati che si trovano sotto zero — in modo che i valori negativi risaltino a colpo d'occhio. In questa sezione imparerai come abilitare questa opzione, scegliere un colore appropriato e salvare la presentazione aggiornata.

Il seguente esempio di codice dimostra l'operazione:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Aggiungi nuove categorie.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Aggiungi una nuova serie.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Popola i dati della serie.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Imposta le impostazioni di colore per la serie.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il colore di riempimento solido invertito](inverted_solid_fill_color.png)

È possibile invertire il colore di riempimento per un singolo punto dati anziché per l'intera serie. Basta accedere al `ChartDataPoint` desiderato e impostare la sua proprietà `invert_if_negative` su `True`.

Il seguente esempio di codice mostra come fare questo:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Cancella Dati per Punti Dati Specifici**

A volte un grafico contiene valori di prova, outlier o voci obsolete che è necessario rimuovere senza ricostruire l'intera serie. Aspose.Slides per Python consente di puntare a qualsiasi punto dati tramite indice, cancellarne il contenuto e aggiornare istantaneamente il grafico in modo che i punti rimanenti si spostino e gli assi si ridimensionino automaticamente.

Il seguente esempio di codice dimostra l'operazione:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta Larghezza del Gap della Serie**

La larghezza del gap controlla la quantità di spazio vuoto tra colonne o barre adiacenti — gap più ampi evidenziano categorie individuali, mentre gap più stretti creano un aspetto più denso e compatto. Con Aspose.Slides for Python è possibile regolare finemente questo parametro per un'intera serie, ottenendo esattamente l'equilibrio visivo richiesto dalla presentazione senza modificare i dati sottostanti.

Il seguente esempio di codice mostra come impostare la larghezza del gap per una serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Crea una presentazione vuota.
with slides.Presentation() as presentation:

    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi un grafico con dati predefiniti.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Salva la presentazione su disco.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Imposta il valore di gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Salva la presentazione su disco.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La larghezza del gap](gap_width.png)

## **FAQ**

**Esiste un limite al numero di serie che un singolo grafico può contenere?**

Aspose.Slides non impone un limite fisso al numero di serie che è possibile aggiungere. Il limite pratico è determinato dalla leggibilità del grafico e dalla memoria disponibile per la tua applicazione.

**Cosa succede se le colonne all'interno di un cluster sono troppo vicine o troppo distanti?**

Regola l'impostazione [gap_width](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/gap_width/) per quella serie (o per il suo gruppo di serie genitore). Aumentare il valore amplia lo spazio tra le colonne, mentre diminuirlo le avvicina.