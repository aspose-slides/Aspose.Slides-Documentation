---
title: Personalizza le legende dei grafici nelle presentazioni con Python
linktitle: Legenda del grafico
type: docs
url: /it/python-net/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per Python via .NET per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides for Python via .NET offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda, formattare una voce di legenda individuale e nascondere o ripristinare voci selezionate.

Le FAQ coprono comportamenti correlati, inclusa la riserva di spazio per la legenda, la visualizzazione di etichette multilinea e l'ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della Legenda**

Utilizza le proprietà [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) e [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) della legenda per specificarne la posizione e le dimensioni come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti alla prima diapositiva. Dividendo gli offset e le dimensioni desiderate della legenda per la larghezza e l'altezza del grafico si ottengono valori relativi: la legenda è spostata di 50 punti dall'angolo in alto a sinistra del grafico e dimensionata a 100 per 100 punti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Esprimi la posizione e la dimensione della legenda relative al grafico.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la Dimensione del Carattere di una Legenda**

Utilizza il [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) della legenda per accedere alla formattazione del testo e impostare [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della legenda a 20 punti. Disabilita inoltre i limiti automatici per l'asse verticale e ne imposta l'intervallo da -5 a 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la Dimensione del Carattere di una Voce di Legenda Individuale**

Utilizza la collezione [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) della legenda per accedere alla formattazione di una voce specifica. Gli indici delle voci partono da zero, quindi l'indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate i cui dati predefiniti includono almeno due serie. Formatta la seconda voce della legenda con testo in grassetto, corsivo e di colore blu a 20 punti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Nascondi Voci di Legenda Individuali**

Per escludere una serie ausiliaria dalla legenda mantenendo i dati visibili, imposta [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) su `True` tramite [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Questo nasconde solo la voce di legenda selezionata; non rimuove la serie né i suoi punti dati. Impostare [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) su `False`, invece, nasconde l'intera legenda.

L'esempio seguente crea un grafico a colonne raggruppate con più serie utilizzando dati predefiniti. Nasconde la voce di legenda della seconda serie (indice `1`) e salva la presentazione. Poi ripristina la voce impostando [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) su `False` e salva una seconda copia. Le colonne rimangono visibili in entrambi i file.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Ripristina la stessa voce senza modificare i dati del grafico.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Il confronto seguente mostra lo stesso grafico con tutte le voci visibili e con la seconda voce nascosta. Le colonne della seconda serie rimangono inalterate.

![Confronto di un grafico con tutte le voci della legenda visibili e con la Serie 2 nascosta dalla legenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

Nei grafici a colonne, barre e linee, le voci della legenda identificano le serie. Nei grafici a torta, identificano i singoli punti dati (fette), quindi usa [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) sulla fetta selezionata. L'API documenta questa proprietà del punto dati per i tipi di grafico `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` e `BAR_OF_PIE`. Non presumere che si applichi ai grafici a ciambella, che non sono inclusi in quell'elenco.

## **FAQ**

**Posso fare in modo che il grafico riservi spazio per la legenda anziché sovrapporla?**

Sì. Imposta [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) su `False` per riservare spazio per la legenda anziché permetterle di sovrapporsi all'area del grafico.

**Posso creare etichette della legenda multilinea?**

Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. È inoltre possibile utilizzare caratteri di nuova riga nei nomi delle serie per richiedere interruzioni di linea.

**Come faccio a far sì che la legenda segua lo schema di colori del tema della presentazione?**

Lascia non impostati i colori, i riempimenti e i caratteri della legenda in modo che possa ereditare la formattazione del tema. La formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.