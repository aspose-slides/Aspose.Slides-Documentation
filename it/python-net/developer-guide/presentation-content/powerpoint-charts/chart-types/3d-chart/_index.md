---
title: Personalizza grafici 3D nelle presentazioni con Python
linktitle: Grafico 3D
type: docs
url: /it/python-net/3d-chart/
keywords:
- grafico 3d
- rotazione
- profondità
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici 3D in Aspose.Slides per Python via .NET, con supporto per i file PPT, PPTX e ODP—potenzia le tue presentazioni oggi."
---
## **Panoramica**

Questo articolo spiega come personalizzare un grafico 3D in Aspose.Slides configurando le impostazioni `rotation_3d` come `rotation_x`, `rotation_y`, `depth_percents` e `right_angle_axes`. Illustra la creazione di una presentazione, l'aggiunta di un grafico 3D con dati predefiniti, l'applicazione delle impostazioni di visualizzazione 3D richieste e il salvataggio della presentazione modificata come file PPTX.

## **Imposta le proprietà RotationX, RotationY e DepthPercents del grafico 3D**
Aspose.Slides per Python via .NET fornisce un'API semplice per impostare queste proprietà. L'articolo seguente ti aiuterà a impostare diverse proprietà come Rotazione X, Y, **DepthPercents** ecc. Il codice di esempio applica l'impostazione delle suddette proprietà.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con dati predefiniti.
4. Imposta le proprietà Rotation3D.
5. Scrivi la presentazione modificata in un file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea un'istanza della classe Presentation
with slides.Presentation() as presentation:
            
    # Accedi alla prima diapositiva
    slide = presentation.slides[0]

    # Aggiungi un grafico con dati predefiniti
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Imposta l'indice del foglio dati del grafico
    defaultWorksheetIndex = 0

    # Ottieni il foglio di lavoro dei dati del grafico
    fact = chart.chart_data.chart_data_workbook

    # Aggiungi serie
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Aggiungi categorie
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Imposta le proprietà Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Prendi la seconda serie del grafico
    series = chart.chart_data.series[1]

    # Ora popolando i dati della serie
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Imposta il valore OverLap
    series.parent_series_group.overlap = 100         

    # Scrivi la presentazione su disco
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta le varianti 3D dei grafici a colonne, includendo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme ai relativi tipi 3D esposti tramite l'enumerazione [ChartType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/charttype/). Per un elenco preciso e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico come immagine tramite l'[API del grafico](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/get_image/) o [renderizzare l'intera diapositiva](/slides/it/python-net/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando hai bisogno di un'anteprima pixel-perfect o desideri incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Quanto è performante la creazione e il rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree del grafico, limita il numero di punti dati per serie quando possibile e renderizza su un output di dimensioni adeguate (risoluzione e dimensioni) per corrispondere al display o alle esigenze di stampa desiderate.