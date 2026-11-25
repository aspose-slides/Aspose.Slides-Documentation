---
title: Personalizza grafici 3D nelle presentazioni utilizzando Python
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

Aspose.Slides per Python via Java consente di personalizzare la visualizzazione di un grafico 3D attraverso il metodo [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Questo articolo dimostra come regolare la rotazione, le proporzioni dell'altezza, la profondità, gli assi a angolo retto e la spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la Rotazione e la Profondità di un Grafico 3D**

L'esempio seguente crea una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e utilizza [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) per aggiungere un grafico a colonne 3D impilato alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L'indice del foglio di lavoro `0` identifica il primo foglio di dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

I metodi [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) e [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) imposta la sua profondità al 150% della larghezza, mentre [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) abilita assi a angolo retto invece della prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

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

## **Applica un Riempimento Immagine a una Superficie di Grafico 3D**

Un grafico 3D ha tre superfici che è possibile riempire in modo indipendente: il [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), il [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall), e il [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Imposta il [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) della superficie su `Picture` e assegna un'immagine. Imposta sia il [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) sia il [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) della superficie su `Stretch` per adattare una copia dell'immagine sulla superficie.

Salva [arrow.png](arrow.png) nella directory di lavoro. L'esempio ruota il grafico e aumenta il valore massimo sull'asse verticale in modo che il pavimento sia visibile tra le colonne. Quindi clona la diapositiva due volte e applica la freccia a una superficie diversa in ciascuna diapositiva. Tutti e tre i grafici mantengono gli stessi dati, l'angolo di visualizzazione e lo sfondo.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint mostra le tre diapositive come segue.

| Parete laterale | Parete posteriore | Pavimento |
| --- | --- | --- |
| ![Freccia che punta nel grafico lungo la parete laterale](side-wall.png) | ![Freccia che punta verso destra sulla parete posteriore](back-wall.png) | ![Freccia che punta verso destra sul pavimento tra le colonne](floor.png) |

## **Regola le Proporzioni dell'Altezza di un Grafico 3D**

Usa [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) per impostare l'altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l'oggetto grafico sulla diapositiva.

Il seguente esempio crea un grafico [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50%, 100% e 200%. La posizione, larghezza e altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, la spaziatura delle serie e la formattazione sono identici in tutti e tre i file; solo la percentuale di altezza cambia.

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

Le immagini seguenti illustrano le stesse impostazioni di altezza nell'esempio .NET equivalente e sono state esportate con Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all'interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli delle tacche degli assi e il posizionamento delle etichette per adattare la scena.

| Altezza: 50% | Altezza: 100% | Altezza: 200% |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50% della larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100% della larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200% della larghezza](height_percent_200.png) |

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Altezza della scena 3D come percentuale della sua larghezza. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Altezza dell'oggetto grafico nella diapositiva, in punti. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondità della scena 3D come percentuale della sua larghezza. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |

L'impostazione dell'altezza influisce sui grafici a colonne e a barre 3D, incluse le varianti cilindro, cono e piramide, così come sui grafici 3D a linea, area, torta e superficie. Il confronto sopra utilizza il tipo verificato `Column3D`. L'impostazione non cambia l'aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri della classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Per altre impostazioni di aspetto del grafico, vedi [Chart Formatting](/slides/it/python-java/chart-formatting/).

## **Regola lo Spazio tra le Serie**

Usa [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) per controllare la distanza tra le serie di dati lungo l'asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità del grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l'asse di profondità.

Accedi al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). L'impostazione si applica a tutte le serie in quel gruppo, non solo alla serie usata per accedervi. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) restituisce lo spazio di profondità e riflette l'impostazione del gruppo genitore.

Questa impostazione influisce sui grafici a colonne e a barre 3D, incluse le loro varianti cilindro, cono e piramide, così come sui grafici 3D a linea e area. L'aspetto dipende dal modo in cui le serie sono disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, usa `ChartType.Column3D` dalla classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Spaziatura tra cluster di barre o colonne adiacenti, come percentuale della larghezza della barra o colonna. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

Il seguente esempio autonomo utilizza i dati predefiniti del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; solo lo spazio di profondità varia.

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

Le immagini seguenti illustrano le stesse impostazioni di spazio di profondità nell'esempio .NET equivalente e sono state esportate con Microsoft PowerPoint.

| Spazio di profondità: 0% | Spazio di profondità: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l'asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500% tra le serie lungo l'asse di profondità](gap_depth_500.png) |

## **Cambia il Tipo di Serie 3D e la Forma della Barra**

In un grafico a cilindri raggruppati, la prima serie inizia con una forma di barra cilindrica. L'esempio stampa i valori interi restituiti da [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) e [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) prima e dopo ogni modifica. La tabella fornisce i corrispondenti nomi costanti.

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
| Imposta il tipo di serie su `ClusteredCone` | `ClusteredCone` | `Cone` |
| Imposta la forma della barra su `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il tuo codice effettua branching sul tipo di serie, chiama `series.getType()` dopo aver cambiato la forma. Un valore memorizzato prima dell'assegnazione selezionerebbe comunque il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, oltre ai relativi tipi 3D esposti attraverso la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Per un elenco preciso e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in un'immagine con [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) o [render the entire slide](/slides/it/python-java/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando ti serve un'anteprima raster o vuoi inserire il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è la performance nella creazione e rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di tracciato, limita il numero di punti dati per serie quando possibile e rendi a una risoluzione e dimensioni adeguate al dispositivo di destinazione o alle esigenze di stampa.