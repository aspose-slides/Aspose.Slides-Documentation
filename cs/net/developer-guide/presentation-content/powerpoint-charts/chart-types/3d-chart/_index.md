---
title: Přizpůsobení 3D grafů v prezentacích v .NET
linktitle: 3D graf
type: docs
url: /cs/net/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvořte 3D grafy v PowerPoint prezentacích pomocí Aspose.Slides pro .NET. Nastavte rotaci, výškové proporce, hloubku grafu a mezery mezi řadami pomocí příkladů v jazyce C#."
---
## **Přehled**

Aspose.Slides pro .NET vám umožňuje přizpůsobit zobrazení 3D grafu pomocí vlastnosti [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Tento článek ukazuje, jak upravit rotaci, výškové proporce, hloubku, pravouhlé osy a mezery mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Ukázkový kód níže vytvoří [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a použije [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) k přidání vrstveného 3D sloupcového grafu na první snímek. Nahradí výchozí řady a kategorie dvěma řadami, z nichž každá obsahuje tři hodnoty. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy řad a sloupec `0` obsahuje štítky kategorií.

Vlastnosti [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) a [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) nastaví rotaci grafu na 40 a 270 stupňů. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) nastaví jeho hloubku na 150 % jeho šířky, zatímco [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) povolí pravouhlé osy namísto perspektivy. Výsledná prezentace obsahuje vyplněný graf s těmito nastaveními 3D zobrazení.

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

## **Úprava výškových proporcí 3D grafu**

Použijte [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím se změní proporce 3D scény, aniž by se změnily rozměry objektu grafu na snímku.

Následující příklad vytvoří graf [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) s výchozími daty: tři řady a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, mezery mezi řadami a formátování jsou ve všech třech souborech shodné; mění se pouze procento výšky.

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

Následující obrázky byly exportovány z vygenerovaných prezentací pomocí Microsoft PowerPoint. Nižší procento vytváří plošší scénu, zatímco vyšší procento vytváří vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly značek os a umístění popisků, aby scénu přizpůsobil.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 procent jeho šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 procent jeho šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 procent jeho šířky](height_percent_200.png) |

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Výška 3D scény jako procento její šířky. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Výška objektu grafu na snímku, v bodech. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Hloubka 3D scény jako procento její šířky. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Mezera mezi řadami podél osy hloubky, jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válec, kužel a pyramida, stejně jako 3D čárové, plošné, výsečové a povrchové grafy. Výše uvedené srovnání používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy výčtu [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Pro další nastavení vzhledu grafu viz [Chart Formatting](/slides/cs/net/chart-formatting/).

## **Úprava mezery mezi řadami**

Použijte [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) k řízení vzdálenosti mezi datovými řadami podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraňuje mezeru, vyšší hodnoty mezery zvětšují. Při pevné hloubce grafu zvětšení mezery způsobí, že značky jsou podél osy hloubky tenčí.

Přístup ke skupině získáte přes [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Nastavení se vztahuje na každou řadu v této skupině, nikoli jen na řadu, pomocí které je přistupováno. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) je pouze pro čtení a odráží nastavení nadřazené skupiny.

Nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich variant válec, kužel a pyramida, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou řady uspořádány v hloubce, seskupeně nebo vrstveně. Pro jasné srovnání mezer mezi samostatnými řadami použijte `ChartType.Column3D` z výčtu [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Mezera mezi řadami podél osy hloubky, jako procento šířky značky. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Mezera mezi sousedními seskupeními sloupců nebo pruhů, jako procento šířky sloupce nebo pruhu. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři řady a čtyři kategorie. Uloží dvě prezentace s identickými daty, rotací, šířkou mezery a hloubkou grafu; mění se pouze hloubka mezery.

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

Následující obrázky byly exportovány z vygenerovaných prezentací pomocí Microsoft PowerPoint.

| Hloubka mezery: 0% | Hloubka mezery: 500% |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi řadami podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500% mezerou mezi řadami podél osy hloubky](gap_depth_500.png) |

## **Změna 3D typu řady a tvaru sloupce**

V seskupeném válcovém grafu první řada začíná s válcovým tvarem sloupce. Příklad čte [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) a [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) před a po každé změně.

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

| Změna první řady | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Vytvořit graf | `ClusteredCylinder` | `Cylinder` |
| Nastavit `Type` na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Nastavit `Bar3DShape` na `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ řady na `ClusteredColumn3D`. Pokud váš kód větví podle typu řady, přečtěte `series.Type` po změně tvaru. Hodnota načtená před přiřazením by stále vedla k větvi `ClusteredCone`.

![PowerPoint srovnání zobrazující první řadu jako válce, kužele a pravoúhlé sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy vystavenými prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Pro přesný, aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) v referenci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Můžete exportovat graf jako obrázek pomocí [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) nebo [render the entire slide](/slides/cs/net/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, pokud potřebujete rastrový náhled nebo chcete vložit graf do dokumentů, řídicích panelů nebo webových stránek bez potřeby PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky držte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a plochách, omezte počet datových bodů na řadu, když je to možné, a renderujte do vhodně velkého výstupu (rozlišení a rozměry), aby odpovídal cílovému zobrazení nebo tisku.