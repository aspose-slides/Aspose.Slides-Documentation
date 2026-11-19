---
title: Personalizza i grafici 3D nelle presentazioni usando Python
linktitle: Grafico 3D
type: docs
url: /it/python-java/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea grafici 3D nelle presentazioni PowerPoint con Aspose.Slides per Python via Java. Regola rotazione, proporzioni dell'altezza, profondità del grafico e spaziatura tra le serie con esempi Python."
---
## **Panoramica**

Aspose.Slides per Python via Java consente di personalizzare la visualizzazione di un grafico 3D tramite il metodo [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Questo articolo dimostra come regolare rotazione, proporzioni dell'altezza, profondità, assi a angolo retto e spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la rotazione e la profondità di un grafico 3D**

L'esempio seguente crea una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e utilizza [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) per aggiungere un grafico a colonne 3D impilato alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L'indice del foglio di lavoro `0` identifica il primo foglio dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

I metodi [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) e [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) impostano la rotazione del grafico rispettivamente a 40 e 270 gradi. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) ne imposta la profondità al 150 % della larghezza, mentre [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) abilita assi a angolo retto anziché la prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Regola le proporzioni dell'altezza di un grafico 3D**

Usa [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) per impostare l'altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l'oggetto grafico nella diapositiva.

L'esempio seguente crea un grafico [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50 %, 100 % e 200 %. La posizione, larghezza e altezza del grafico rimangono fisse. Dati, rotazione, profondità, spaziatura delle serie e formattazione sono identici in tutti e tre i file; cambia solo la percentuale di altezza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le immagini seguenti illustrano le stesse impostazioni di altezza nell'esempio .NET equivalente e sono state esportate con Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all'interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli di tick dell'asse e la posizione delle etichette per adattarsi alla scena.

| Altezza: 50% | Altezza: 100% | Altezza: 200% |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50 percento della sua larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100 percento della sua larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200 percento della sua larghezza](height_percent_200.png) |

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Altezza della scena 3D come percentuale della sua larghezza. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Altezza dell'oggetto grafico nella diapositiva, in punti. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondità della scena 3D come percentuale della sua larghezza. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |

L'impostazione dell'altezza influisce su grafici a colonne e barre 3D, comprese le varianti cilindro, cono e piramide, nonché su grafici 3D a linee, aree, torta e superficie. Il confronto sopra utilizza il tipo verificato `Column3D`. L'impostazione non modifica l'aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi fanno parte della classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Per altre impostazioni di aspetto del grafico, vedere [Chart Formatting](/slides/it/python-java/chart-formatting/).

## **Regola lo spazio tra le serie**

Usa [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) per controllare la distanza tra le serie di dati lungo l'asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità del grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l'asse di profondità.

Accedi al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). L'impostazione si applica a tutte le serie del gruppo, non solo a quella usata per accedervi. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) restituisce lo spazio di profondità e riflette l'impostazione del gruppo padre.

Questa impostazione influisce su grafici a colonne e barre 3D, comprese le loro varianti cilindro, cono e piramide, nonché su grafici 3D a linee e aree. L'aspetto dipende da come le serie sono disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, usa `ChartType.Column3D` della classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

| Metodo | Effetto |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Spaziatura tra gruppi di barre o colonne adiacenti, come percentuale della larghezza della barra o della colonna. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L'esempio autonomo seguente utilizza i dati grafico predefiniti, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; varia solo la profondità dello spazio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le immagini seguenti illustrano le stesse impostazioni di profondità dello spazio nell'esempio .NET equivalente e sono state esportate con Microsoft PowerPoint.

| Profondità del gap: 0% | Profondità del gap: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spaziatura tra le serie lungo l'asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con una spaziatura del 500 percento tra le serie lungo l'asse di profondità](gap_depth_500.png) |

## **Modifica il tipo di serie 3D e la forma della barra**

In un grafico cilindro raggruppato, la prima serie inizia con una forma di barra cilindrica. L'esempio stampa i valori interi restituiti da [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) e [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) prima e dopo ogni modifica. La tabella fornisce i nomi costanti corrispondenti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Modifica alla prima serie | Tipo di serie | Forma della barra |
| --- | --- | --- |
| Crea il grafico | `ClusteredCylinder` | `Cylinder` |
| Imposta il tipo di serie a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Imposta la forma della barra a `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il tuo codice utilizza ramificazioni basate sul tipo di serie, chiama `series.getType()` dopo aver modificato la forma. Un valore memorizzato prima dell'assegnazione selezionerebbe comunque la ramificazione `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipologie di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta le varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, insieme ai tipi 3D correlati esposti tramite la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Per un elenco esatto e aggiornato, verifica i membri di [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in immagine con [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) o [renderizzare l'intera diapositiva](/slides/it/python-java/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando serve un'anteprima raster o desideri incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è le prestazioni nella creazione e rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di tracciato, limita il numero di punti dati per serie quando possibile e renderizza a una risoluzione e dimensioni adeguate al display o alla stampa di destinazione.