---
title: Personalizza i grafici 3D nelle presentazioni con Python
linktitle: Grafico 3D
type: docs
url: /it/python-net/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea grafici 3D in presentazioni PowerPoint con Aspose.Slides per Python via .NET. Regola rotazione, proporzioni dell'altezza, profondità del grafico e spaziatura tra le serie con esempi Python."
---
## **Panoramica**

Aspose.Slides per Python via .NET ti consente di personalizzare la visualizzazione di un grafico 3D tramite la proprietà [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Questo articolo dimostra come regolare la rotazione, le proporzioni dell'altezza, la profondità, gli assi ad angolo retto e la spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la Rotazione e la Profondità di un Grafico 3D**

L'esempio seguente crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e utilizza [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) per aggiungere un grafico a colonne 3D impilato alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L'indice del foglio di lavoro `0` identifica il primo foglio dati del grafico; la riga `0` contiene i nomi delle serie, e la colonna `0` contiene le etichette delle categorie.

Le proprietà [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) e [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) ne imposta la profondità al 150% della larghezza, mentre [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) abilita gli assi ad angolo retto anziché la prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Regola le Proporzioni dell'Altezza di un Grafico 3D**

Utilizza [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) per impostare l'altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l'oggetto grafico sulla diapositiva.

L'esempio seguente crea un grafico [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50%, 100% e 200%. La posizione, larghezza e altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, la spaziatura delle serie e la formattazione sono identici in tutti e tre i file; cambia solo la percentuale di altezza.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Le immagini seguenti sono state esportate dalle presentazioni generate utilizzando Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all'interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli delle tacche degli assi e la disposizione delle etichette per adattarsi alla scena.

| Altezza: 50% | Altezza: 100% | Altezza: 200% |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50% della sua larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100% della sua larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200% della sua larghezza](height_percent_200.png) |

Queste proprietà controllano diversi aspetti del grafico:

| Proprietà | Effetto |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Altezza della scena 3D come percentuale della sua larghezza. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Altezza dell'oggetto grafico sulla diapositiva, in punti. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profondità della scena 3D come percentuale della sua larghezza. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Spaziatura tra le serie lungo l'asse della profondità, come percentuale della larghezza del marcatore. |

L'impostazione dell'altezza influisce su grafici a colonne e barre 3D, comprese le varianti cilindro, cono e piramide, nonché su grafici 3D a linee, aree, torta e superficie. Il confronto sopra utilizza il tipo verificato `COLUMN_3D`. L'impostazione non modifica l'aspetto di un grafico 2D `CLUSTERED_COLUMN` o di un grafico `BUBBLE_WITH_3D`; questi nomi sono membri dell'enumerazione [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Per altre impostazioni di aspetto del grafico, vedere [Chart Formatting](/slides/it/python-net/chart-formatting/).

## **Regola lo Spazio Tra le Serie**

Utilizza [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) per controllare la distanza tra le serie di dati lungo l'asse della profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità del grafico fissa, incrementare lo spazio rende i marcatori più sottili lungo l'asse della profondità.

Accedi al gruppo tramite [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). L'impostazione si applica a tutte le serie di quel gruppo, non solo alla serie usata per accedervi. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) è di sola lettura e riflette l'impostazione del gruppo genitore.

Questa impostazione influisce su grafici a colonne e barre 3D, incluse le loro varianti cilindro, cono e piramide, nonché su grafici 3D a linee e aree. L'aspetto dipende dal modo in cui le serie sono disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, usa `ChartType.COLUMN_3D` dall'enumerazione [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Queste proprietà controllano diversi aspetti del grafico:

| Proprietà | Effetto |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Spaziatura tra le serie lungo l'asse della profondità, come percentuale della larghezza del marcatore. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Spaziatura tra i cluster di barre o colonne adiacenti, come percentuale della larghezza della barra o della colonna. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L'esempio autonomo seguente utilizza i dati predefiniti del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; cambia solo la profondità dello spazio.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Le immagini seguenti sono state esportate dalle presentazioni generate utilizzando Microsoft PowerPoint.

| Spazio tra le serie: 0% | Spazio tra le serie: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l'asse della profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500% tra le serie lungo l'asse della profondità](gap_depth_500.png) |

## **Modifica il Tipo di Serie 3D e la Forma della Barra**

In un grafico a cilindri raggruppati, la prima serie inizia con barre cilindriche. L'esempio legge [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) e [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) prima e dopo ogni modifica.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Modifica alla prima serie | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Crea il grafico | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Imposta `type` su `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Imposta `bar_3d_shape` su `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Impostare la forma su `BOX` cambia anche il tipo di serie in `CLUSTERED_COLUMN_3D`. Se il tuo codice utilizza rami basati sul tipo di serie, leggi `series.type` dopo aver cambiato la forma. Un valore memorizzato prima dell'assegnazione selezionerebbe ancora il ramo `CLUSTERED_CONE`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme a tipi 3D correlati esposti tramite l'enumerazione [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Per un elenco preciso e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) nella referenza API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in un'immagine con [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) o [render the entire slide](/slides/it/python-net/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando serve un'anteprima raster o desideri incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è la resa prestazionale nella costruzione e rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per risultati ottimali, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di tracciamento, limita il numero di punti dati per serie quando possibile e renderizza a un'uscita di dimensioni adeguate (risoluzione e dimensioni) per corrispondere al display o alle esigenze di stampa target.