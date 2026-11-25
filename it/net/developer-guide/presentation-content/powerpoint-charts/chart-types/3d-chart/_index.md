---
title: Personalizza i grafici 3D nelle presentazioni in .NET
linktitle: Grafico 3D
type: docs
url: /it/net/3d-chart/
keywords:
- Grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea grafici 3D in presentazioni PowerPoint con Aspose.Slides per .NET. Regola rotazione, proporzioni di altezza, profondità del grafico e spaziatura tra le serie con esempi C#."
---
## **Panoramica**

Aspose.Slides for .NET consente di personalizzare la vista di un grafico 3D tramite la proprietà [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Questo articolo dimostra come regolare la rotazione, le proporzioni di altezza, la profondità, gli assi ad angolo retto e la spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la Rotazione e la Profondità di un Grafico 3D**

L'esempio seguente crea una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e utilizza [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) per aggiungere un grafico a colonne 3D impilato alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L'indice del foglio di lavoro `0` identifica il primo foglio di dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

Le proprietà [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) e [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) imposta la sua profondità al 150% della sua larghezza, mentre [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) abilita assi ad angolo retto invece della prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

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

## **Applica un Riempimento Immagine a una Superficie di Grafico 3D**

Un grafico 3D ha tre superfici che è possibile riempire indipendentemente: la [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), la [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) e il [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Imposta il [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) della superficie selezionata su `Picture` e assegna un'immagine. Imposta sia il [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) che il [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) della superficie su `Stretch` per adattare una copia dell'immagine su tutta la superficie.

Salva [arrow.png](arrow.png) nella directory di lavoro. L'esempio ruota il grafico e aumenta il valore massimo sull'asse verticale in modo che il pavimento sia visibile tra le colonne. Quindi clona la diapositiva due volte prima di applicare la freccia a una superficie diversa in ciascuna diapositiva. Tutti e tre i grafici mantengono gli stessi dati, l'angolo di visualizzazione e lo sfondo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint mostra le tre diapositive come segue.

| Parete laterale | Parete posteriore | Pavimento |
| --- | --- | --- |
| ![Freccia che punta nel grafico lungo la parete laterale](side-wall.png) | ![Freccia che punta a destra lungo la parete posteriore](back-wall.png) | ![Freccia che punta a destra sul pavimento tra le colonne](floor.png) |

## **Regola le Proporzioni di Altezza di un Grafico 3D**

Usa [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) per impostare l'altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l'oggetto grafico sulla diapositiva.

L'esempio seguente crea un grafico [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50%, 100% e 200%. La posizione, larghezza e altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, la spaziatura delle serie e la formattazione sono identici in tutti e tre i file; solo la percentuale di altezza varia.

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

Le seguenti immagini sono state esportate dalle presentazioni generate con Microsoft PowerPoint. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più alta produce una scena più alta all'interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli delle tacche degli assi e il posizionamento delle etichette per adattare la scena.

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

L'impostazione dell'altezza influisce su grafici a colonne e barre 3D, incluse le varianti cilindro, cono e piramide, nonché su grafici a linee, area, torta e superficie 3D. Il confronto sopra utilizza il tipo verificato `Column3D`. L'impostazione non modifica l'aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri dell'enumerazione [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Per altre impostazioni di aspetto del grafico, vedere [Chart Formatting](/slides/it/net/chart-formatting/).

## **Regola lo Spazio Tra le Serie**

Usa [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) per controllare la distanza tra le serie di dati lungo l'asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità del grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l'asse di profondità.

Accedi al gruppo tramite [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). L'impostazione si applica a tutte le serie di quel gruppo, non solo alla serie usata per accedervi. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) è di sola lettura e riflette l'impostazione del gruppo padre.

Questa impostazione influisce su grafici a colonne e barre 3D, incluse le loro varianti cilindro, cono e piramide, nonché su grafici a linee e area 3D. L'aspetto dipende dal modo in cui le serie sono organizzate in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, utilizza `ChartType.Column3D` dall'enumerazione [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Queste proprietà controllano diversi aspetti del grafico:

| Proprietà | Effetto |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Spaziatura tra gruppi adiacenti di barre o colonne, come percentuale della larghezza della barra o della colonna. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L'esempio autonomo seguente utilizza i dati predefiniti del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; cambia solo la profondità dello spazio.

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

| Profondità spazio: 0% | Profondità spazio: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l'asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500% tra le serie lungo l'asse di profondità](gap_depth_500.png) |

## **Modifica il Tipo di Serie 3D e la Forma della Barra**

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

| Modifica per la prima serie | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Crea il grafico | `ClusteredCylinder` | `Cylinder` |
| Imposta `Type` a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Imposta `Bar3DShape` a `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma a `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il tuo codice ramifica in base al tipo di serie, leggi `series.Type` dopo aver cambiato la forma. Un valore memorizzato prima dell'assegnazione selezionerebbe comunque il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme a tipi 3D correlati esposti tramite l'enumerazione [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Per un elenco preciso e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. È possibile esportare un grafico in immagine con [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o [rendere l'intera diapositiva](/slides/it/net/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando serve un'anteprima raster o si vuole incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è la prestazione nella costruzione e nel rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per risultati ottimali, mantieni gli effetti 3D minimi, evita texture pesanti su pareti e aree di tracciamento, limita il numero di punti dati per serie quando possibile e rendi a una risoluzione e dimensione adeguate al display o alla stampa di destinazione.