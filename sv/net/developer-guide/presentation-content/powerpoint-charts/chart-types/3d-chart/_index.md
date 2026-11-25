---
title: Anpassa 3D-diagram i presentationer i .NET
linktitle: 3D-diagram
type: docs
url: /sv/net/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för .NET. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med C#‑exempel."
---
## **Översikt**

Aspose.Slides for .NET låter dig anpassa vyn av ett 3D-diagram via egenskapen [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . Den här artikeln visar hur du justerar rotation, höjdförhållanden, djup, räta vinkel‑axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX‑format.

## **Ställ in rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och använder [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) för att lägga till ett staplat 3D‑kolumndiagram på dess första bild. Det ersätter standardserierna och -kategorierna med två serier som vardera innehåller tre värden. Arbetsbladindex `0` identifierar diagrammets första datakalkylblad; rad `0` innehåller serienamn, och kolumn `0` innehåller kategorietiketter.

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/)‑ och [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/)‑egenskaperna ställer in diagrammets rotation till respektive 40 och 270 grader. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) sätter dess djup till 150 % av dess bredd, medan [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) aktiverar räta vinkel‑axlar istället för perspektiv. Den resulterande presentationen innehåller det ifyllda diagrammet med dessa 3D‑vyinställningar.

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

## **Applicera bildfyllning på en 3D-diagramsyta**

Ett 3D‑diagram har tre ytor som du kan fylla oberoende: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) och [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Ställ in den valda ytan’s [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) till `Picture` och tilldela en bild. Ställ både [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) och ytan’s [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) till `Stretch` för att passa en kopia av bilden över ytan.

Spara [arrow.png](arrow.png) i arbetskatalogen. Exemplet roterar diagrammet och höjer det maximala värdet på den vertikala axeln så golvet syns mellan kolonnerna. Det klonar sedan bilden två gånger innan pilen appliceras på en annan yta på varje bild. Alla tre diagrammen behåller samma data, vyvinkel och bakgrund.

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

Microsoft PowerPoint visar de tre bilderna enligt följande.

| Sidovägg | Bakvägg | Golv |
| --- | --- | --- |
| ![Pil som pekar in i diagrammet längs sidoväggen](side-wall.png) | ![Pil som pekar åt höger över bakväggen](back-wall.png) | ![Pil som pekar åt höger över golvet mellan kolumnerna](floor.png) |

## **Justera höjdförhållandena för ett 3D-diagram**

Använd [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) för att sätta diagrammets höjd som en procentandel av dess bredd. Detta ändrar proportionerna i 3D‑scenen utan att ändra storlek på diagramobjektet på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, serieavstånd och formatering är identiska i alla tre filerna; endast höjdeprocenten varierar.

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

Följande bilder exporterades från de genererade presentationerna med Microsoft PowerPoint. En lägre procentandel ger en plattare scen, en högre procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns tick‑intervall och etikettplacering för att passa scenen.

| Höjd: 50% | Höjd: 100% | Höjd: 200% |
| --- | --- | --- |
| ![3D kolumndiagram med höjden satt till 50 procent av dess bredd](height_percent_50.png) | ![3D kolumndiagram med höjden satt till 100 procent av dess bredd](height_percent_100.png) | ![3D kolumndiagram med höjden satt till 200 procent av dess bredd](height_percent_200.png) |

Dessa egenskaper styr olika aspekter av diagrammet:

| Egenskap | Effekt |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Höjden på 3D‑scenen som en procentandel av dess bredd. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Höjden på diagramobjektet på bilden, i punkter. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Djupet på 3D‑scenen som en procentandel av dess bredd. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D‑kolumn‑ och stapeldiagram, inklusive cylinder‑, kon‑ och pyramidvarianter, samt 3D‑linje-, area‑, paj‑ och ytdiagram. Jämförelsen ovan använder den verifierade typen `Column3D`. Inställningen ändrar inte utseendet på ett 2D‑`ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i uppräkningen [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). För andra diagramformateringsinställningar, se [Diagramformatering](/slides/sv/net/chart-formatting/).

## **Justera gapet mellan serier**

Använd [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) för att styra avståndet mellan dataserier längs djupaxeln i ett 3D‑diagram, uttryckt som en procentandel av markörbredden. Använd värden från **0 till 500**, inklusivt: `0` tar bort gapet, medan större värden ökar avståndet. Med ett fast diagramdjup gör ett större gap markörerna tunnare längs djupaxeln.

Få åtkomst till gruppen via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som användes för åtkomst. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) är skrivskyddad och speglar gruppens inställning.

Denna inställning påverkar 3D‑kolumn‑ och stapeldiagram, inklusive deras cylinder‑, kon‑ och pyramidvarianter, samt 3D‑linje‑ och area‑diagram. Utseendet beror på om serierna är arrangerade i djup, grupperade eller staplade. För en tydlig jämförelse av gap mellan separata serier, använd `ChartType.Column3D` från uppräkningen [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Dessa egenskaper styr olika aspekter av diagrammet:

| Egenskap | Effekt |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Avstånd mellan intilliggande stapel‑ eller kolumnkluster, som en procentandel av stapelns eller kolumnens bredd. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Totalt diagramdjup, som en procentandel av diagrammets bredd. |

Följande självständiga exempel använder standarddiagramdata med tre serier och fyra kategorier. Det sparar två presentationer med identiska data, rotation, gap‑bredd och diagramdjup; endast gap‑djupet varierar.

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

Följande bilder exporterades från de genererade presentationerna med Microsoft PowerPoint.

| Gapdjup: 0% | Gapdjup: 500% |
| --- | --- |
| ![3D kolumndiagram utan gap mellan serier längs djupaxeln](gap_depth_0.png) | ![3D kolumndiagram med 500 procents gap mellan serier längs djupaxeln](gap_depth_500.png) |

## **Ändra 3D-serietyp och stapelform**

I ett grupperat cylinder‑diagram börjar den första serien med en cylindrisk stapelform. Exemplet läser [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) och [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) före och efter varje ändring.

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

| Ändring av den första serien | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Skapa diagrammet | `ClusteredCylinder` | `Cylinder` |
| Ställ `Type` till `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ställ `Bar3DShape` till `Box` | `ClusteredColumn3D` | `Box` |

Att ställa in formen till `Box` ändrar också serietypen till `ClusteredColumn3D`. Om din kod förgrenar sig på serietypen, läs `series.Type` efter att formen ändrats. Ett värde som cachats före tilldelningen skulle fortfarande välja gren `ClusteredCone`.

![PowerPoint-jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stöder 3D‑läge i Aspose.Slides?**

Aspose.Slides stöder 3D‑varianter av kolumndiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via uppräkningen [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webb?**

Ja. Du kan exportera ett diagram till en bild med [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) eller [rendera hela bilden](/slides/sv/net/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en raster‑förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggande och rendering av stora 3D‑diagram?**

Prestanda beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekter till ett minimum, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utmatning (upplösning och dimensioner) som matchar målskärm eller utskriftsbehov.