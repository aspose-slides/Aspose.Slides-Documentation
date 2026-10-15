---
title: Personalizzare gli assi dei grafici nelle presentazioni con Python
linktitle: Asse del grafico
type: docs
url: /it/python-net/chart-axis/
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
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per Python tramite .NET per personalizzare gli assi dei grafici in presentazioni PowerPoint e OpenDocument per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici con Aspose.Slides per Python tramite .NET. Copre valori dell'asse calcolati, lo scambio di righe e colonne del grafico, la visibilità dell'asse, gli intervalli delle etichette di categoria e dei segni di tacca, le categorie e la formattazione delle date, la rotazione del titolo, il posizionamento dell'asse, le unità di visualizzazione e la scala logaritmica.

## **Ottenere i Valori Massimi sull'Asse Verticale nei Grafici**

Crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e aggiungi un grafico ad area con dati predefiniti. Chiama [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) prima di leggere i valori dell'asse calcolati in modo che il layout del grafico sia aggiornato.

Leggi [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) e [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) per i limiti dell'asse, e [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) e [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) per gli intervalli delle tacche. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) e [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) forniscono scale di unità temporali, rilevanti per gli assi data. L'esempio memorizza questi valori in variabili locali e salva il grafico.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Scambiare i Dati tra gli Assi**

Usa [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) per invertire i ruoli di serie e categorie nei dati del grafico. Ogni precedente categoria diventa una serie, e ogni precedente serie diventa una categoria. Questo modifica il modo in cui i dati sono raggruppati; non scambia gli assi orizzontale e verticale. L'esempio utilizza [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) per associare i dati predefiniti a `Sheet1!A1:D5`, includendo la riga di intestazione e la colonna delle categorie, prima di scambiare righe e colonne. Salva un grafico con quattro serie e tre categorie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Invertire l'Ordine di Tracciamento di un Asse**

Usa [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) per invertire un asse di categoria o di valore. Per esempio, un grafico a barre orizzontali può mostrare le fasi del progetto dall'alto verso il basso nello stesso ordine del foglio di lavoro: Pianificazione, Sviluppo, Test. L'inversione di un asse cambia la direzione di tracciamento; non ordina né riorganizza i dati del foglio di lavoro. In confronto, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) scambia i ruoli di serie e categorie.

L'esempio seguente crea un grafico a barre orizzontali con tre fasi e una serie. Salva una presentazione con tre diapositive: ordine normale, categorie invertite e valori invertiti. Ogni copia utilizza lo stesso set di dati, e solo un asse è invertito in ciascuna copia.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Diapositiva 2: mostra la prima categoria in alto.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Mantieni l'asse di valore orizzontale in basso.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Diapositiva 3: inverte solo la scala numerica orizzontale.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Invertire un asse può anche spostare l'asse perpendicolare sul lato opposto del tracciato. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) controlla dove l'altro asse attraversa l'asse in fase di configurazione. Nella diapositiva 2, impostandolo su `MAXIMUM` sull'asse di categoria invertito si mantiene l'asse di valore orizzontale in basso. Per un punto di attraversamento specifico, usa [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Controlla le impostazioni di attraversamento quando cambi direzione, soprattutto se il grafico ha già un punto di attraversamento personalizzato. Imposta `is_plot_order_reversed` su `False` per ripristinare la direzione di tracciamento normale; le impostazioni di attraversamento sono separate.

| Ordine normale (diap. 1) | Categorie invertite (diap. 2) | Valori invertiti (diap. 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Le categorie vanno dal basso verso l'alto; i valori aumentano da sinistra a destra. | Pianificazione, Sviluppo e Test vanno dall'alto verso il basso. I valori e l'ordine delle righe del foglio di lavoro non cambiano. | Le categorie mantengono il loro ordine normale; i valori aumentano da destra a sinistra. L'asse di categoria attraversa a zero a destra. |

## **Disattivare l'Asse Verticale per i Grafici a Linee**

Imposta [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) su `False` sull'asse verticale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse verticale nascosto.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Disattivare l'Asse Orizzontale per i Grafici a Linee**

Imposta [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) su `False` sull'asse orizzontale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse orizzontale nascosto.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Modificare un Asse di Categoria**

Imposta [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) per scegliere un asse di categoria data o testo. Questo esempio richiede `ExistingChart.pptx`, con un grafico come prima forma nella prima diapositiva e celle di categoria contenenti valori data numerici di Excel. Cambia l'asse orizzontale in un asse data. Impostando [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) su `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) su `1` e [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) su mesi, posiziona le tacche principali a intervalli di un mese.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Controllare gli Intervalli delle Etichette dell'Asse di Categoria**

Quando un grafico ha molte categorie, riduci il numero di etichette dell'asse visibili senza rimuovere categorie o punti dati. Imposta [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) su `False`, quindi imposta [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) sull'intervallo di categoria desiderato. Per le categorie di testo nel loro ordine normale, il conteggio inizia dalla prima categoria:

| Intervallo | Etichette visualizzate nell'esempio |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Un intervallo di `3` visualizza ogni terza etichetta, lasciando due etichette nascoste tra quelle visualizzate. Non rimuove le colonne corrispondenti. La spaziatura automatica sceglie un intervallo in base allo spazio disponibile; non visualizza necessariamente ogni etichetta.

I segni di tacca hanno controlli separati. Imposta [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) su `False` e usa [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) per impostare il loro intervallo. Per esempio, `1` mantiene un segno di tacca a ogni intervallo di categoria mentre le etichette compaiono solo ogni terza categoria. Imposta [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) su uno stile visibile così da poter vedere il risultato. Impostare nuovamente le proprietà di spaziatura automatica su `True` permette al grafico di scegliere nuovamente quell'intervallo.

L'esempio autonomo seguente crea 24 categorie e una serie, quindi salva tre diapositive in `CategoryAxisIntervals.pptx`: spaziatura automatica, spaziatura manuale delle etichette con segni di tacca indipendenti e spaziatura automatica ripristinata. Le due copie mantengono i dati originali del grafico. Non è necessaria alcuna presentazione di input. Il testo delle etichette orizzontali rende evidente la differenza di densità.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Slide 2: mostra ogni terza etichetta, ma mantieni un segno di tacca per ogni categoria.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slide 3: lascia che il grafico scelga nuovamente entrambi gli intervalli.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Spaziatura automatica (diap. 1):** In questa rappresentazione, viene visualizzata ogni seconda etichetta di categoria e avvolta su due linee. Il risultato automatico può variare con la dimensione del grafico, i caratteri e il renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Spaziatura manuale (diap. 2):** Ogni terza etichetta è visualizzata su una linea, mentre i segni di tacca rimangono a ogni intervallo di categoria. Tutte le 24 colonne, incluse quelle senza etichette, rimangono visibili con gli stessi valori. La diapositiva 3 ripristina l'aspetto automatico mostrato sopra.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Scegliere l'Asse e l'Intervallo Corretto**

Usa questo intervallo di conteggio delle categorie per un asse di categoria testuale, come l'asse di categoria di un grafico a colonne, linee, aree o barre. In un grafico a colonne, è l'asse orizzontale. In un grafico a barre orizzontali, l'asse di categoria è verticale, quindi applica queste impostazioni a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). La spaziatura dei segni di tacca si applica anche a un asse di serie nei grafici che ne possiedono uno.

Non usare la spaziatura delle etichette di categoria per impostare la scala numerica di un asse di valore. Su un asse di valore, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) specifica una differenza di valori: per esempio, un'unità principale di `10` produce tacche a 0, 10, 20, ecc. quando l'asse parte da zero. Un intervallo di etichetta di categoria di `3` conta invece le posizioni delle categorie, indipendentemente dai loro valori dati. I grafici a dispersione e a bolle usano assi di valore anziché un asse di categoria testuale. Per un asse data, usa unità principali e scale basate sul tempo come descritto in [Modificare un Asse di Categoria](#modificare-un-asse-di-categoria).

## **Impostare il Formato Data per i Valori dell'Asse di Categoria**

L'esempio sostituisce i dati predefiniti del grafico con quattro valori annuali. Le date sono memorizzate come numeri seriali OLE Automation nel primo foglio di lavoro (indice `0`). Imposta [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) su un asse data, disattiva [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) e assegna `yyyy` a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) affinché le etichette di categoria mostrino gli anni a quattro cifre indipendentemente dal formato della cella.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare un Angolo di Rotazione per il Titolo dell'Asse del Grafico**

Abilita [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) sull'asse verticale, fornisci il testo del titolo e imposta [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) per ruotare il titolo. L'angolo è misurato in gradi; questo esempio salva un grafico a colonne con il titolo dell'asse di valore ruotato di 90 gradi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la Posizione dell'Asse su un Asse di Categoria o di Valore**

Usa [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) per controllare se l'asse di valore attraversa l'asse di categoria tra le categorie o sui segni di tacca delle categorie. Questa proprietà si applica agli assi di categoria. L'esempio la imposta su `True` sull'asse di categoria orizzontale di un grafico a colonne e salva il risultato.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare l'Unità di Visualizzazione su un Asse di Valore del Grafico**

Imposta [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) per scalare le etichette su un asse di valore senza modificare i dati sottostanti. Con [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) impostato su `MILLIONS`, un valore di 60.000.000 viene visualizzato come 60. L'esempio crea un grafico a colonne e applica l'unità di visualizzazione milioni al suo asse verticale.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Configurare un Asse di Valore Logaritmico**

Un asse di valore logaritmico è utile quando i valori positivi coprono diversi ordini di grandezza. Per esempio, un servizio potrebbe ricevere 10, 100, 1.000, 10.000 e 100.000 richieste in cinque periodi. Su una scala lineare, i valori più piccoli appaiono vicini tra loro vicino allo zero. Una scala logaritmica rende più facile confrontare la loro crescita relativa: distanze uguali rappresentano rapporti uguali anziché differenze uguali.

Imposta [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) su `True` sull'asse di valore e usa [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) per scegliere la base. Questo cambia il modo in cui i valori esistenti vengono visualizzati; non modifica i dati né aggiunge una linea di tendenza logaritmica. Una linea di tendenza rappresenta una relazione adattata ai dati ed è una funzionalità separata.

### **Scegliere l'Asse di Valore e la Base**

Per un grafico a linee o a colonne, l'asse di valore è [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Per un grafico a barre orizzontali, è [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). I grafici a dispersione e a bolle hanno due assi di valore, quindi scegli l'asse orizzontale per i valori X, l'asse verticale per i valori Y, o entrambi. Non applicare la scala logaritmica a un asse di categoria.

La base logaritmica predefinita è `10`. Per i grafici PPTX, usa una base da `2` a `1000`, inclusi; sono supportate anche basi frazionarie come `2.5`. Con base `10`, le potenze successive come 10, 100, 1.000 e 10.000 sono equidistanti.

### **Confrontare Scala Lineare e Logaritmica**

L'esempio autonomo seguente crea un grafico a linee con i cinque conteggi di richieste nella prima diapositiva, quindi clona quella diapositiva e abilita un asse di valore logaritmico base 10 sulla seconda. Entrambe le diapositive mantengono gli stessi dati.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Mantieni la prima diapositiva lineare e modifica solo la scala dell'asse dei valori della copia.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Scala lineare (diap. 1):** Distanze verticali uguali rappresentano differenze uguali nei conteggi delle richieste. Il valore più grande domina il grafico, rendendo difficile distinguere i valori più piccoli.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Scala logaritmica (diap. 2):** Distanze verticali uguali rappresentano rapporti uguali. Ogni periodo ha dieci volte più richieste del precedente, quindi i punti formano una linea crescente retta sulla scala logaritmica base 10. Le etichette dell'asse mostrano comunque i conteggi originali delle richieste.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Gestire Valori Zero e Negativi**

Una scala logaritmica può visualizzare solo valori strettamente positivi. Controlla i dati prima di abilitarla. Se valori zero o negativi sono significativi, mantieni una scala lineare o mostrali separatamente. Se l'esclusione di questi valori è appropriata per l'analisi, spiega l'omissione. Non sostituirli silenziosamente con numeri positivi piccoli, poiché ciò altera il significato dei dati. Qualsiasi valore minimo o massimo configurato manualmente per un asse logaritmico deve essere anch'esso positivo.

## **FAQ**

**Come impostare il valore al quale un asse attraversa l'altro (attraversamento dell'asse)?**

Usa [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) per selezionare il comportamento di attraversamento. Per specificare un valore numerico di attraversamento, imposta [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Queste impostazioni ti permettono di spostare l'attraversamento dell'asse a una linea di base adeguata.

**Come posizionare le etichette dei segni di tacca rispetto all'asse?**

Imposta [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) usando [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` o `NONE`. Per controllare i segni di tacca stessi, usa [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) o [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); questi sono separati dal posizionamento delle etichette.