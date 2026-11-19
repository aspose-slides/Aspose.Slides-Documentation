---
title: 3D diagramok testreszabása prezentációkban .NET-ben
linktitle: 3D Diagram
type: docs
url: /hu/net/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Készítsen 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for .NET segítségével. Állítsa be a forgatást, a magasság arányait, a diagram mélységét és a sorozatok közti távolságot C# példákkal."
---
## **Áttekintés**

Az Aspose.Slides for .NET lehetővé teszi, hogy a 3D diagram nézetét a [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) tulajdonság segítségével testreszabja. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányai, a mélység, a derékszögű tengelyek és a sorok közti távolság, majd hogyan menthető a prezentáció PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) objektumot, és a [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) segítségével egy halmozott 3D oszlopdiagramot ad hozzá az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két sorozatra, amelyek mindegyike három értéket tartalmaz. A `0` munkalap-index a diagram első adatlapját jelöli; a `0` sor a sorozatneveket, az `0` oszlop pedig a kategória címkéket tartalmazza.

A [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) és a [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) tulajdonságok a diagram forgatását állítják be 40 és 270 fokra. A [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) a szélesség 150 %-ára állítja be a mélységet, míg a [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) a perspektíva helyett derékszögű tengelyeket aktiválja. Az eredményül kapott prezentáció a feltöltött diagramot tartalmazza ezekkel a 3D nézetbeállításokkal.

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

## **A 3D diagram magasságarányának beállítása**

Használja a [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) tulajdonságot a 3D diagram magasságának a szélességéhez viszonyított százalékos beállításához. Ez a 3D jelenet arányait változtatja meg anélkül, hogy a diagram objektum méretét a dián átméretezné.

A következő példa létrehoz egy [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) diagramot az alapértelmezett adatokkal: három sorozat és négy kategória. Három prezentációt ment 50 %, 100 % és 200 % magasságarányokkal. A diagram pozíciója, szélessége és magassága állandó marad. Az adatok, forgatás, mélység, sorok közti távolság és formázás minden három fájlban azonos; csak a magasság százalékos értéke változik.

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

Az alábbi képek a generált prezentációkból lettek exportálva a Microsoft PowerPoint használatával. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék a ugyanazon diagramobjektumban magasabb jelenetet hoz létre. A PowerPoint esetleg a tengelyek jelölőinek intervallumát és a címkék elhelyezését is módosíthatja a jelenethez igazodva.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélességének 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélességének 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélességének 200%-a](height_percent_200.png) |

Ezek a tulajdonságok a diagram különböző aspektusait szabályozzák:

| Tulajdonság | Hatás |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | A 3D jelenet magassága a szélességének százalékában. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | A diagram objektum magassága a dián pontban. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | A 3D jelenet mélysége a szélességének százalékában. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | A sorok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magasság beállítása a 3D oszlop- és sávdiagramokra hat, beleértve a henger-, kúp- és piramisváltozatokat, valamint a 3D vonal-, terület-, kör- és felületdiagramokat. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem változtatja meg a 2D `ClusteredColumn` vagy a `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolás tagjai. Egyéb diagram megjelenési beállításokért lásd a [Chart Formatting](/slides/hu/net/chart-formatting/) oldalt.

## **A sorok közti rés (gap) beállítása**

Használja a [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) tulajdonságot a 3D diagram adat‑sorai közti távolság szabályozásához a mélységi tengelyen, a jelölő szélességének százalékában kifejezve. Az értékek **0‑tól 500‑ig** terjednek, zárólagos: a `0` eltávolítja a részt, míg a nagyobb értékek növelik a távolságot. Fix diagrammélység mellett a rés növelése vékonyabb jelölőket eredményez a mélységi tengelyen.

A csoportot a [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) segítségével érheti el. A beállítás a csoport összes sorozatára érvényes, nem csak arra, amelyen keresztül hozzáfér. Az [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) csak olvasható, és a szülőcsoport beállítását tükrözi.

Ez a beállítás a 3D oszlop- és sávdiagramokra hat, beleértve azok henger-, kúp- és piramisváltozatait, valamint a 3D vonal‑ és területdiagramokra. A megjelenés attól függ, hogy a sorozatok a mélység mentén, csoportosítva vagy halmozva vannak‑e. A különálló sorozatok közti rés könnyű összehasonlításához használja a `ChartType.Column3D` típusú diagramot a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolásból.

Ezek a tulajdonságok a diagram különböző aspektusait szabályozzák:

| Tulajdonság | Hatás |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | A sorok közti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | A szomszédos sáv‑ vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | A diagram összes mélysége, a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két prezentációt ment azonos adatokkal, forgatással, rés szélességgel és diagrammélységgel; csak a rés mélysége változik.

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

Az alábbi képek a generált prezentációkból lettek exportálva a Microsoft PowerPoint segítségével.

| Réstűlés: 0% | Réstűlés: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelyiknek nincs része a sorok között a mélységi tengely mentén](gap_depth_0.png) | ![3D oszlopdiagram, amelyiknek 500 százalékos része van a sorok között a mélységi tengely mentén](gap_depth_500.png) |

## **A 3D sorozattípus és a sáv alakjának módosítása**

Egy csoportosított hengerdiagram esetén az első sorozat henger alakú sávval indul. A példa beolvassa az [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) és az [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) értékeket minden változtatás előtt és után.

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

| Változtatás az első sorozaton | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| `Type` beállítása `ClusteredCone`‑ra | `ClusteredCone` | `Cone` |
| `Bar3DShape` beállítása `Box`‑ra | `ClusteredColumn3D` | `Box` |

A `Box` alakra történő beállítás a sorozat típusát is `ClusteredColumn3D`‑ra módosítja. Ha a kódban a sorozattípus alapján elágazik, olvassa a `series.Type` értékét a forma módosítása után. A hozzárendelés előtt cache‑elt érték még mindig a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely az első sorozatot hengerként, kónként és téglalapos oszlopként mutatja balról jobbra](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides‑ben?**

Az Aspose.Slides támogatja a 3D oszlopdiagramok változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolás biztosít. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) tagjait az adott verzió API referenciájában.

**Kaphatok raster képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. Exportálhatja a diagramot képként a [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) vagy a [diák teljes renderelésével](/slides/hu/net/convert-powerpoint-to-png/) PNG vagy JPEG formátumban. Ez hasznos, ha raszteres előnézetre van szüksége, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba szeretné beágyazni PowerPoint igénylése nélkül.

**Milyen teljesítményű a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adat mennyiségétől és a vizuális komplexitástól függ. A legjobb eredmény érdekében tartsa a 3D hatásokat minimális szinten, kerülje a nehéz textúrákat a falakon és a diagramterületeken, korlátozza sorozatonkénti adatpontok számát, és rendereljen megfelelő méretű kimenetre (felbontás és méretek) a célkijelző vagy nyomtatási igényeknek megfelelően.