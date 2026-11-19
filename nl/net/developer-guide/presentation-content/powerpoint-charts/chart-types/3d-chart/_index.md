---
title: 3D-diagrammen aanpassen in presentaties in .NET
linktitle: 3D-diagram
type: docs
url: /nl/net/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides voor .NET. Pas rotatie, hoogteverhoudingen, diagramdiepte en tussenruimte tussen reeksen aan met C#-voorbeelden."
---
## **Overzicht**

Aspose.Slides for .NET stelt u in staat de weergave van een 3D-diagram aan te passen via de [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) eigenschap. Dit artikel laat zien hoe u rotatie, hoogte‑verhoudingen, diepte, loodrechte assen en de tussenruimte tussen reeksen kunt aanpassen en vervolgens de presentatie opslaat in PPTX‑formaat.

## **Rotatie en diepte van een 3D-diagram instellen**

Het onderstaande voorbeeld maakt een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) aan en gebruikt [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) om een gestapeld 3D‑kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaardreeksen en -categorieën door twee reeksen met elk drie waarden. Werkblad‑index `0` identificeert het eerste gegevenswerkblad van het diagram; rij `0` bevat de reeksenamen en kolom `0` bevat de categorielabels.

De eigenschappen [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) en [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) zetten de rotatie van het diagram respectievelijk op 40 en 270 graden. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) stelt de diepte in op 150 % van de breedte, terwijl [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) rechte hoeksassen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

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

## **Hoogte‑verhoudingen van een 3D-diagram aanpassen**

Gebruik [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) om de hoogte van een 3D-diagram in te stellen als een percentage van de breedte. Dit verandert de verhoudingen van de 3D‑scene zonder de grootte van het diagramobject op de dia aan te passen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) diagram met de standaardgegevens: drie reeksen en vier categorieën. Het slaat drie presentaties op met hoogte‑verhoudingen van 50 %, 100 % en 200 %. De positie, breedte en hoogte van het diagram blijven gelijk. De gegevens, rotatie, diepte, tussenruimte van de reeksen en opmaak zijn in alle drie de bestanden identiek; alleen het hoogte‑percentage verandert.

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

De volgende afbeeldingen zijn geëxporteerd uit de gegenereerde presentaties met Microsoft PowerPoint. Een kleiner percentage levert een plattere scène op, terwijl een groter percentage een hogere scène binnen hetzelfde diagramobject produceert. PowerPoint kan ook de intervalwaarden van de assen en de plaatsing van labels aanpassen om de scène passend weer te geven.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D kolomdiagram met hoogte ingesteld op 50 procent van de breedte](height_percent_50.png) | ![3D kolomdiagram met hoogte ingesteld op 100 procent van de breedte](height_percent_100.png) | ![3D kolomdiagram met hoogte ingesteld op 200 procent van de breedte](height_percent_200.png) |

Deze eigenschappen regelen verschillende aspecten van het diagram:

| Eigenschap | Effect |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Hoogte van de 3D‑scene als een percentage van de breedte. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Hoogte van het diagramobject op de dia, in punten. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Diepte van de 3D‑scene als een percentage van de breedte. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Tussenruimte tussen reeksen langs de diepte‑as, als een percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief cilindrische, kegel‑ en piramide‑varianten, evenals 3D‑lijn-, vlak-, taart‑ en oppervlakdiagrammen. De bovenstaande vergelijking maakt gebruik van het geverifieerde type `Column3D`. De instelling verandert niet het uiterlijk van een 2D‑`ClusteredColumn`‑diagram of een `BubbleWith3D`‑diagram; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeratie. Voor andere diagram‑opmaakinstellingen, zie [Diagramopmaak](/slides/nl/net/chart-formatting/).

## **Tussenruimte tussen reeksen aanpassen**

Gebruik [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) om de afstand tussen gegevensreeksen langs de diepte‑as van een 3D‑diagram te regelen, uitgedrukt als een percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de tussenruimte, terwijl grotere waarden de afstand vergroten. Bij een vaste diagramdiepte maakt een grotere tussenruimte de markers dunner langs de diepte‑as.

Benader de groep via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Deze instelling geldt voor elke reeks in die groep, niet alleen voor de reeks die wordt gebruikt om er toegang toe te krijgen. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) is alleen‑lezen en geeft de instelling van de bovenliggende groep weer.

Deze instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief hun cilindrische, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑ en vlakdiagrammen. Het uiterlijk hangt af van of de reeksen in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van tussenruimtes tussen afzonderlijke reeksen, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeratie.

Deze eigenschappen regelen verschillende aspecten van het diagram:

| Eigenschap | Effect |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Tussenruimte tussen reeksen langs de diepte‑as, als een percentage van de markerbreedte. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Tussenruimte tussen aangrenzende staaf‑ of kolomclusters, als een percentage van de breedte van de staaf of kolom. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Totale diagramdiepte, als een percentage van de diagrambreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaarddiagramgegevens, die drie reeksen en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, tussenruimte‑breedte en diagramdiepte; alleen de tussenruimte‑diepte verandert.

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

De volgende afbeeldingen zijn geëxporteerd uit de gegenereerde presentaties met Microsoft PowerPoint.

| Tussenruimte: 0% | Tussenruimte: 500% |
| --- | --- |
| ![3D kolomdiagram zonder tussenruimte tussen reeksen langs de diepte‑as](gap_depth_0.png) | ![3D kolomdiagram met een tussenruimte van 500 procent tussen reeksen langs de diepte‑as](gap_depth_500.png) |

## **Wijzig het 3D‑serietype en de balkvorm**

In een gegroepeerd cilinderdiagram begint de eerste reeks met een cilindrische balkvorm. Het voorbeeld leest [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) en [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) vóór en na elke wijziging.

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

| Wijziging van de eerste reeks | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Diagram maken | `ClusteredCylinder` | `Cylinder` |
| `Type` instellen op `ClusteredCone` | `ClusteredCone` | `Cone` |
| `Bar3DShape` instellen op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` verandert ook het serietype naar `ClusteredColumn3D`. Als uw code vertakt op basis van het serietype, lees dan `series.Type` na het wijzigen van de vorm. Een vóór de toewijzing gecachte waarde zou nog steeds de `ClusteredCone`‑tak selecteren.

![PowerPoint‑vergelijking die de eerste reeks toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke diagramtypen ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die via de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeratie worden blootgesteld. Voor een exacte, actuele lijst, bekijk de leden van de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding met [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) of [render de volledige dia](/slides/nl/net/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een raster‑preview nodig heeft of het diagram in documenten, dashboards of webpagina's wilt insluiten zonder PowerPoint te vereisen.

**Hoe presteert het bouwen en renderen van grote 3D-diagrammen?**

De prestaties zijn afhankelijk van de hoeveelheid gegevens en de visuele complexiteit. Voor optimale resultaten houdt u 3D‑effecten minimaal, vermijdt u zware texturen op wanden en plotgebieden, beperkt u het aantal gegevenspunten per reeks waar mogelijk, en rendert u naar een passend formaat (resolutie en afmetingen) dat overeenkomt met de beoogde weergave‑ of afdrukvereisten.