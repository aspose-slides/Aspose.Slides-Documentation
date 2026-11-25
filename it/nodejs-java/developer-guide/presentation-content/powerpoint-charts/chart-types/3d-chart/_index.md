---
title: Personalizza i grafici 3D nelle presentazioni usando JavaScript
linktitle: Grafico 3D
type: docs
url: /it/nodejs-java/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea grafici 3D nelle presentazioni PowerPoint con Aspose.Slides per Node.js via Java. Regola rotazione, proporzioni dell'altezza, profondità del grafico e spaziatura tra le serie con esempi JavaScript."
---
## **Panoramica**

Aspose.Slides per Node.js via Java consente di personalizzare la visualizzazione di un grafico 3D tramite il metodo [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Questo articolo dimostra come regolare la rotazione, le proporzioni dell’altezza, la profondità, gli assi ad angolo retto e la spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la rotazione e la profondità di un grafico 3D**

L'esempio seguente crea una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e utilizza [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) per aggiungere un grafico a colonne 3D impilate alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L'indice del foglio di lavoro `0` identifica il primo foglio dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

I metodi [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) e [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) impostano la rotazione del grafico rispettivamente a 40 e 270 gradi. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) imposta la sua profondità al 150% della sua larghezza, mentre [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) abilita gli assi ad angolo retto al posto della prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Applica un riempimento immagine alla superficie di un grafico 3D**

È possibile riempire in modo indipendente la [parete laterale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), la [parete posteriore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/), e il [pavimento](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) di un grafico 3D. Imposta il [tipo di riempimento](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) della superficie su `Picture` e assegna un'immagine. Imposta sia il [modalità di riempimento immagine](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) che il [tipo di immagine](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) della superficie su `Stretch` per adattare una copia dell'immagine alla superficie.

Salva [arrow.png](arrow.png) nella directory di lavoro. L'esempio ruota il grafico e aumenta il valore massimo sull'asse verticale in modo che il pavimento sia visibile tra le colonne. Poi clona la diapositiva due volte e applica la freccia a una superficie diversa su ciascuna diapositiva. Tutti e tre i grafici mantengono gli stessi dati, l'angolo di visualizzazione e lo sfondo.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint mostra le tre diapositive come segue.

| Parete laterale | Parete posteriore | Pavimento |
| --- | --- | --- |
| ![Freccia che punta nel grafico lungo la parete laterale](side-wall.png) | ![Freccia che punta a destra lungo la parete posteriore](back-wall.png) | ![Freccia che punta a destra sul pavimento tra le colonne](floor.png) |

## **Regola le proporzioni dell'altezza di un grafico 3D**

Usa [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) per impostare l'altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l'oggetto del grafico sulla diapositiva.

Il seguente esempio crea un grafico [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50%, 100% e 200%. La posizione, la larghezza e l'altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, la spaziatura delle serie e la formattazione sono identici in tutti e tre i file; cambia solo la percentuale di altezza.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le seguenti immagini illustrano le stesse impostazioni di altezza nell'esempio .NET equivalente e sono state esportate con Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all'interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli delle tacche degli assi e il posizionamento delle etichette per adattarsi alla scena.

| Altezza: 50% | Altezza: 100% | Altezza: 200% |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50% della sua larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100% della sua larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200% della sua larghezza](height_percent_200.png) |

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Altezza della scena 3D come percentuale della sua larghezza. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Altezza dell'oggetto grafico sulla diapositiva, in punti. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profondità della scena 3D come percentuale della sua larghezza. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |

L'impostazione dell'altezza influisce su grafici a colonne e barre 3D, incluse le varianti cilindro, cono e piramide, nonché su grafici 3D a linee, aree, torta e superficie. Il confronto sopra utilizza il tipo verificato `Column3D`. L'impostazione non cambia l'aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri della classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Per altre impostazioni di aspetto dei grafici, vedi [Formattazione del grafico](/slides/it/nodejs-java/chart-formatting/).

## **Regola lo spazio tra le serie**

Usa [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) per controllare la distanza tra le serie di dati lungo l'asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità di grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l'asse di profondità.

Accedi al gruppo tramite [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). L'impostazione si applica a tutte le serie di quel gruppo, non solo alla serie usata per accedervi. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) restituisce lo spazio di profondità e riflette l'impostazione del gruppo genitore.

Questa impostazione influisce su grafici a colonne e barre 3D, incluse le varianti cilindro, cono e piramide, così come su grafici 3D a linee e aree. L'aspetto dipende dal modo in cui le serie sono disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, usa `ChartType.Column3D` della classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Spaziatura tra gruppi di barre o colonne adiacenti, come percentuale della larghezza della barra o colonna. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L'esempio autonomo seguente utilizza i dati predefiniti del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; cambia solo la profondità dello spazio.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le seguenti immagini illustrano le stesse impostazioni di profondità dello spazio nell'esempio .NET equivalente e sono state esportate con Microsoft PowerPoint.

| Profondità: 0% | Profondità: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l'asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500% tra le serie lungo l'asse di profondità](gap_depth_500.png) |

## **Modifica il tipo di serie 3D e la forma della barra**

In un grafico a cilindri raggruppati, la prima serie inizia con una forma di barra cilindrica. L'esempio stampa i valori interi restituiti da [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) e [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) prima e dopo ogni modifica. La tabella fornisce i nomi costanti corrispondenti.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Modifica della prima serie | Tipo di serie | Forma della barra |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il tuo codice esegue branch in base al tipo di serie, chiama `series.getType()` dopo aver cambiato la forma. Un valore memorizzato prima dell'assegnazione selezionerebbe ancora il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme a tipi 3D correlati esposti tramite la classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Per un elenco esatto e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) nel riferimento API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in un'immagine con [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) o [render the entire slide](/slides/it/nodejs-java/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando hai bisogno di un'anteprima raster o vuoi incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è la performance nella creazione e nel rendering di grandi grafici 3D?**

La performance dipende dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di trama, limita il numero di punti dati per serie quando possibile e rendi a una risoluzione e dimensioni appropriate per il dispositivo di destinazione o per la stampa.