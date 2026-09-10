---
title: Personalizza i grafici 3D nelle presentazioni usando Python
linktitle: Grafico 3D
type: docs
url: /it/python-java/3d-chart/
keywords:
- Grafico 3D
- Rotazione
- Profondità
- PowerPoint
- Presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici 3-D in Aspose.Slides per Python via Java, con supporto per file PPT e PPTX—potenzia le tue presentazioni oggi."
---
## **Panoramica**

Questo articolo spiega come personalizzare un grafico 3D in Aspose.Slides configurando le impostazioni di [Rotation3D](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotation3d/) come [setRotationX](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotation3d/#setDepthPercents) e [setRightAngleAxes](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Viene illustrato come creare una presentazione, aggiungere un grafico 3D con dati predefiniti, applicare le impostazioni di visualizzazione 3D richieste e salvare la presentazione modificata come file PPTX.

## **Imposta rotazione X, rotazione Y e profondità di un grafico 3D**
Aspose.Slides for Python via Java fornisce un'API semplice per impostare queste proprietà. L'esempio seguente mostra come impostare la rotazione X, la rotazione Y e la profondità di un grafico 3D.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Imposta le proprietà di rotazione 3D.
1. Scrivi la presentazione modificata in un file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Accedi alla prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un grafico con dati predefiniti.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Imposta l'indice del foglio di lavoro dei dati del grafico.
    default_worksheet_index = 0

    # Ottieni la cartella di lavoro dei dati del grafico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Aggiungi serie.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Aggiungi categorie.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Imposta le proprietà di rotazione 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Accedi alla seconda serie del grafico.
    series = chart.getChartData().getSeries().get_Item(1)

    # Popola i dati della serie.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Salva la presentazione.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme ai tipi 3D correlati esposti tramite la classe [ChartType](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/). Per un elenco preciso e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o per il web?**

Sì. Puoi esportare un grafico in un'immagine tramite l'[chart API](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) o [render the entire slide](/slides/it/python-java/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando hai bisogno di un'anteprima pixel-perfect o desideri incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Quanto è efficiente la creazione e il rendering di grafici 3D di grandi dimensioni?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di tracciato, limita il numero di punti dati per serie quando possibile e rendi l'output a una dimensione (risoluzione e dimensioni) adeguata al display o alla stampa di destinazione.