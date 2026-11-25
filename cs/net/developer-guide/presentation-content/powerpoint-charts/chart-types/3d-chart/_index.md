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
description: "Vytvořte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro .NET. Upravit rotaci, výškové poměry, hloubku grafu a rozestupy mezi řadami pomocí příkladů v C#."
---
## **Přehled**

Aspose.Slides for .NET vám umožňuje přizpůsobit zobrazení 3D grafu pomocí vlastnosti [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . Tento článek ukazuje, jak upravit rotaci, výškové poměry, hloubku, pravouhlé osy a rozestupy mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Příklad níže vytvoří [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a pomocí [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) přidá na první snímek seskupený 3D sloupcový graf. Nahradí výchozí řady a kategorie dvěma řadami, z nichž každá obsahuje tři hodnoty. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy řad a sloupec `0` obsahuje popisky kategorií.

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) a [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) vlastnosti nastaví rotaci grafu na 40 a 270 stupňů. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) nastaví jeho hloubku na 150 % šířky, zatímco [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) povolí pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje vyplněný graf s těmito nastaveními 3D zobrazení.

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

## **Aplikace obrázkové výplně na povrch 3D grafu**

3D graf má tři povrchy, které můžete vyplnit nezávisle: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) a [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Vyberte povrch a nastavte jeho [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na `Picture` a přiřaďte obrázek. Nastavte jak [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) tak [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) povrchu na `Stretch`, aby se jeden exemplář obrázku rozprostřel po celém povrchu.

Uložte [arrow.png](arrow.png) do pracovního adresáře. Příklad otáčí graf a zvyšuje maximální hodnotu na svislé ose, aby byl podlaha viditelná mezi sloupci. Poté duplikuje snímek dvakrát, než na každém snímku použije šipku na jiný povrch. Všechny tři grafy zachovávají stejná data, úhel pohledu i pozadí.

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

Microsoft PowerPoint zobrazuje tři snímky následovně.

| Bočnice | Zadní stěna | Podlaha |
| --- | --- | --- |
| ![Šipka ukazující do grafu podél bočnice](side-wall.png) | ![Šipka ukazující doprava podél zadní stěny](back-wall.png) | ![Šipka ukazující doprava podél podlahy mezi sloupci](floor.png) |

## **Úprava výškových proporcí 3D grafu**

Použijte [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) , abyste nastavili výšku 3D grafu jako procento jeho šířky. Tím změníte proporce 3D scény, aniž byste měnili velikost objektu grafu na snímku.

Následující příklad vytvoří graf [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) , který používá výchozí data: tři řady a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, rozestupy řad a formátování jsou ve všech třech souborech identické; mění se pouze procento výšky.

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

Následující obrázky byly exportovány z vygenerovaných prezentací pomocí Microsoft PowerPoint. Menší procento vytváří plošší scénu, zatímco větší procento vytváří vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly značek os a umístění popisků tak, aby scéna zapadla.

| Výška: 50 % | Výška: 100 % | Výška: 200 % |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 % jeho šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 % jeho šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 % jeho šířky](height_percent_200.png) |

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Výška 3D scény jako procento její šířky. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Výška objektu grafu na snímku v bodech. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Hloubka 3D scény jako procento její šířky. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Rozestup mezi řadami podél osy hloubky jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válec, kužel a pyramida, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Výše uvedené srovnání používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy výčtu [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Pro další nastavení vzhledu grafu viz [Chart Formatting](/slides/cs/net/chart-formatting/).

## **Úprava mezery mezi řadami**

Použijte [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) , abyste řídili vzdálenost mezi datovými řadami podél osy hloubky 3D grafu, vyjádřenou jako procento šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty zvětší rozestup. Při pevné hloubce grafu zvětšení mezery ztenčuje značky podél osy hloubky.

Skupinu získáte přes [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Nastavení se vztahuje na všechny řady v této skupině, ne jen na řadu, přes kterou byl přístup získán. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) je pouze pro čtení a odráží nastavení nadřazené skupiny.

Nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich variant válec, kužel a pyramida, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou řady uspořádány v hloubce, seskupeny nebo vrstveny. Pro jasné srovnání mezer mezi jednotlivými řadami použijte `ChartType.Column3D` z výčtu [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Tyto vlastnosti řídí různé aspekty grafu:

| Vlastnost | Efekt |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Rozestup mezi řadami podél osy hloubky jako procento šířky značky. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Rozestup mezi sousedními shluky sloupců či pruhů jako procento šířky sloupce či pruhu. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři řady a čtyři kategorie. Uloží dva prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se pouze hloubka mezery.

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

| Hloubka mezery: 0 % | Hloubka mezery: 500 % |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi řadami podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s mezerou 500 % mezi řadami podél osy hloubky](gap_depth_500.png) |

## **Změna typu 3D řady a tvaru pruhu**

V seskupeném válecovém grafu začíná první řada s válcovým tvarem pruhu. Příklad načte [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) a [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) před a po každé změně.

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

Nastavení tvaru na `Box` také mění typ řady na `ClusteredColumn3D`. Pokud váš kód rozvětvuje podle typu řady, přečtěte `series.Type` po změně tvaru. Hodnota uložená před přiřazením by stále vedla k větvi `ClusteredCone`.

![Porovnání v PowerPointu ukazující první řadu jako válcové, kuželové a obdélníkové sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy vystavenými prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) v API referenci vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat jako obrázek pomocí [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) nebo [vyrenderovat celý snímek](/slides/cs/net/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, pokud potřebujete rastrový náhled nebo chcete vložit graf do dokumentů, dashboardů či webových stránek bez potřeby PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a ploše grafu, omezte počet datových bodů na řadu, pokud je to možné, a vykreslujte do výstupu s vhodnou velikostí (rozlišení a rozměry), aby odpovídal cílovému displeji nebo tisku.