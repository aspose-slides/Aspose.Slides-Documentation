---
title: Personalizza i grafici 3D nelle presentazioni usando Java
linktitle: Grafico 3D
type: docs
url: /it/java/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea grafici 3D in presentazioni PowerPoint con Aspose.Slides per Java. Regola rotazione, proporzioni di altezza, profondità del grafico e spaziatura tra le serie con esempi Java."
---
## **Panoramica**

Aspose.Slides per Java consente di personalizzare la visualizzazione di un grafico 3D tramite il metodo [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Questo articolo dimostra come regolare la rotazione, le proporzioni di altezza, la profondità, gli assi a angolo retto e la spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la rotazione e la profondità di un grafico 3D**

L’esempio seguente crea una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) e utilizza [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) per aggiungere un grafico a colonne 3D impilato alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L’indice del foglio di lavoro `0` identifica il primo foglio dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

I metodi [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) e [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) ne fissa la profondità al 150 % della larghezza, mentre [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) abilita assi a angolo retto anziché prospettivi. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Applica un riempimento immagine alla superficie di un grafico 3D**

Un grafico 3D ha tre superfici che è possibile riempire in modo indipendente: la [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), la [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) e il [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Imposta il [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) della superficie su `Picture` e assegna un’immagine. Imposta sia il [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) sia il [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) della superficie su `Stretch` per adattare una copia dell’immagine all’intera superficie.

Salva [arrow.png](arrow.png) nella directory di lavoro. L’esempio ruota il grafico e alza il valore massimo sull’asse verticale in modo che il pavimento sia visibile tra le colonne. Quindi clona la diapositiva due volte e applica la freccia a una superficie diversa in ciascuna diapositiva. Tutti e tre i grafici conservano gli stessi dati, l’angolo di visualizzazione e lo sfondo.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint mostra le tre diapositive come segue.

| Parete laterale | Parete posteriore | Pavimento |
| --- | --- | --- |
| ![Freccia puntata verso il grafico lungo la parete laterale](side-wall.png) | ![Freccia puntata verso destra sulla parete posteriore](back-wall.png) | ![Freccia puntata verso destra sul pavimento tra le colonne](floor.png) |

## **Regola le proporzioni di altezza di un grafico 3D**

Usa [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) per impostare l’altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l’oggetto grafico nella diapositiva.

L’esempio seguente crea un grafico [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50 %, 100 % e 200 %. La posizione, la larghezza e l’altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, la spaziatura tra le serie e la formattazione sono identici in tutti e tre i file; varia solo la percentuale di altezza.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le immagini seguenti illustrano le stesse impostazioni di altezza nell’esempio .NET equivalente e sono state esportate con Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all’interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli dei tick degli assi e la disposizione delle etichette per adattare la scena.

| Altezza: 50 % | Altezza: 100 % | Altezza: 200 % |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50 % della larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100 % della larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200 % della larghezza](height_percent_200.png) |

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Altezza della scena 3D come percentuale della sua larghezza. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Altezza dell’oggetto grafico nella diapositiva, in punti. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profondità della scena 3D come percentuale della sua larghezza. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Spaziatura tra le serie lungo l’asse di profondità, come percentuale della larghezza del marcatore. |

L’impostazione dell’altezza influisce sui grafici a colonne e a barre 3D, comprese le varianti cilindro, cono e piramide, nonché sui grafici 3D a linee, aree, torta e superficie. Il confronto sopra utilizza il tipo verificato `Column3D`. L’impostazione non modifica l’aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri della classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Per altre impostazioni di aspetto dei grafici, vedere [Chart Formatting](/slides/it/java/chart-formatting/).

## **Regola lo spazio tra le serie**

Usa [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) per controllare la distanza tra le serie di dati lungo l’asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità del grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l’asse di profondità.

Accedi al gruppo tramite [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . L’impostazione si applica a tutte le serie in quel gruppo, non solo alla serie usata per accedervi. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) restituisce lo spazio di profondità e riflette l’impostazione del gruppo padre.

Questa impostazione influisce sui grafici a colonne e a barre 3D, comprese le loro varianti cilindro, cono e piramide, nonché sui grafici 3D a linee e a aree. L’aspetto dipende dal fatto che le serie siano disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, usa `ChartType.Column3D` dalla classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Spaziatura tra le serie lungo l’asse di profondità, come percentuale della larghezza del marcatore. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Spaziatura tra i gruppi di barre o colonne adiacenti, come percentuale della larghezza della barra o colonna. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L’esempio autonomo seguente utilizza i dati predefiniti del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, spaziatura di larghezza e profondità del grafico identici; varia solo la profondità dello spazio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le immagini seguenti illustrano le stesse impostazioni di profondità dello spazio nell’esempio .NET equivalente e sono state esportate con Microsoft PowerPoint.

| Profondità spazio: 0 % | Profondità spazio: 500 % |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l’asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500 % tra le serie lungo l’asse di profondità](gap_depth_500.png) |

## **Cambia il tipo di serie 3D e la forma della barra**

In un grafico a cilindri raggruppati, la prima serie inizia con una barra di forma cilindrica. L’esempio stampa i valori interi restituiti da [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) e [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) prima e dopo ogni modifica. La tabella fornisce i nomi costanti corrispondenti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Modifica della prima serie | Tipo di serie | Forma della barra |
| --- | --- | --- |
| Crea il grafico | `ClusteredCylinder` | `Cylinder` |
| Imposta il tipo di serie su `ClusteredCone` | `ClusteredCone` | `Cone` |
| Imposta la forma della barra su `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il tuo codice effettua branching sul tipo di serie, chiama `series.getType()` dopo aver modificato la forma. Un valore memorizzato prima dell’assegnazione selezionerebbe ancora il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, oltre ai tipi 3D correlati esposti tramite la classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Per un elenco esatto e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) nella documentazione API della versione installata.

**Posso ottenere un’immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in immagine con [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) o [renderizzare l’intera diapositiva](/slides/it/java/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando serve un’anteprima raster o vuoi incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è le prestazioni nella creazione e renderizzazione di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di trama, limita il numero di punti dati per serie quando possibile e renderizza con una risoluzione e dimensioni adeguate al dispositivo di destinazione o alle esigenze di stampa.