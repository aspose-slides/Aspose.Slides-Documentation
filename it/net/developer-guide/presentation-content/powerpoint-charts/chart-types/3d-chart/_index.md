---
title: Personalizza i grafici 3D nelle presentazioni in .NET
linktitle: Grafico 3D
type: docs
url: /it/net/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea grafici 3D nelle presentazioni PowerPoint con Aspose.Slides per .NET. Regola rotazione, proporzioni dell'altezza, profondità del grafico e spaziatura tra le serie con esempi C#."
---
## **Panoramica**

Aspose.Slides per .NET consente di personalizzare la visualizzazione di un grafico 3D tramite la proprietà [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Questo articolo dimostra come regolare rotazione, proporzioni dell'altezza, profondità, assi a angolo retto e spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la rotazione e la profondità di un grafico 3D**

L'esempio seguente crea una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e utilizza [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) per aggiungere un grafico a colonne 3D impilato alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L'indice del foglio di lavoro `0` identifica il primo foglio di dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

Le proprietà [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) e [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) imposta la sua profondità al 150% della larghezza, mentre [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) abilita assi a angolo retto anziché prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Regola le proporzioni dell'altezza di un grafico 3D**

Utilizza [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) per impostare l'altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l'oggetto del grafico sulla diapositiva.

L'esempio seguente crea un grafico [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50 %, 100 % e 200 %. La posizione, larghezza e altezza del grafico rimangono fisse. Dati, rotazione, profondità, spaziatura delle serie e formattazione sono identici in tutti e tre i file; cambia solo la percentuale di altezza.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Le seguenti immagini sono state esportate dalle presentazioni generate con Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all'interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli dei tick degli assi e la disposizione delle etichette per adattarsi alla scena.

| Altezza: 50% | Altezza: 100% | Altezza: 200% |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50% della sua larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100% della sua larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200% della sua larghezza](height_percent_200.png) |

Queste proprietà controllano diversi aspetti del grafico:

| Proprietà | Effetto |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Altezza della scena 3D come percentuale della sua larghezza. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Altezza dell'oggetto grafico sulla diapositiva, in punti. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profondità della scena 3D come percentuale della sua larghezza. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |

L'impostazione dell'altezza influisce su grafici a colonne e barre 3D, comprese le varianti cilindro, cono e piramide, nonché su grafici a linee, aree, torta e superficie 3D. Il confronto sopra utilizza il tipo verificato `Column3D`. L'impostazione non modifica l'aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri dell'enumerazione [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Per altre impostazioni di aspetto dei grafici, vedere [Formattazione del grafico](/slides/it/net/chart-formatting/).

## **Regola lo spazio tra le serie**

Utilizza [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) per controllare la distanza tra le serie di dati lungo l'asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità del grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l'asse di profondità.

Accedi al gruppo tramite [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). L'impostazione si applica a tutte le serie in quel gruppo, non solo alla serie usata per accedervi. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) è di sola lettura e riflette l'impostazione del gruppo genitore.

Questa impostazione influisce su grafici a colonne e barre 3D, comprese le loro varianti cilindro, cono e piramide, nonché su grafici a linee e aree 3D. L'aspetto dipende dal modo in cui le serie sono disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, utilizza `ChartType.Column3D` dall'enumerazione [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Queste proprietà controllano diversi aspetti del grafico:

| Proprietà | Effetto |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Spaziatura tra gruppi di barre o colonne adiacenti, come percentuale della larghezza della barra o della colonna. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L'esempio autonomo seguente utilizza i dati predefiniti del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza del gap e profondità del grafico identici; varia solo la profondità del gap.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Le seguenti immagini sono state esportate dalle presentazioni generate con Microsoft PowerPoint.

| Profondità del gap: 0% | Profondità del gap: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l'asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500 percento tra le serie lungo l'asse di profondità](gap_depth_500.png) |

## **Modifica il tipo di serie 3D e la forma della barra**

In un grafico a cilindri raggruppati, la prima serie inizia con una forma di barra cilindrica. L'esempio legge [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) e [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) prima e dopo ogni modifica.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Modifica alla prima serie | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Crea il grafico | `ClusteredCylinder` | `Cylinder` |
| Imposta `Type` a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Imposta `Bar3DShape` a `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il tuo codice utilizza condizioni basate sul tipo di serie, leggi `series.Type` dopo aver cambiato la forma. Un valore memorizzato prima dell'assegnazione selezionerebbe comunque il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D di grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, insieme a tipi 3D correlati esposti tramite l'enumerazione [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Per un elenco esatto e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in un'immagine con [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o [renderizzare l'intera diapositiva](/slides/it/net/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando serve un'anteprima raster o per incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Quanto è performante la creazione e il rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di trama, limita il numero di punti dati per serie quando possibile e rendi a una risoluzione e dimensioni appropriate per il dispositivo di destinazione o per la stampa.