---
title: Dostosowywanie wykresów 3D w prezentacjach w .NET
linktitle: Wykres 3D
type: docs
url: /pl/net/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Tworzenie wykresów 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides for .NET. Dostosuj obrót, proporcje wysokości, głębokość wykresu oraz odstępy między seriami przy pomocy przykładów w C#."
---
## **Przegląd**

Aspose.Slides for .NET umożliwia dostosowanie widoku wykresu 3D za pomocą właściwości [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Ten artykuł pokazuje, jak dostosować obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Poniższy przykład tworzy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i używa [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) do dodania skumulowanego wykresu kolumnowego 3D na pierwszym slajdzie. Zastępuje domyślne serie i kategorie dwoma seriami zawierającymi po trzy wartości. Index arkusza kalkulacyjnego `0` identyfikuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` – etykiety kategorii.

Właściwości [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) i [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) ustawiają obrót wykresu odpowiednio na 40 i 270 stopni. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) ustawia jego głębokość na 150 % szerokości, natomiast [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) włącza osie pod kątem prostym zamiast perspektywy. Powstała prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

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

## **Zastosuj wypełnienie obrazem do powierzchni wykresu 3D**

Wykres 3D ma trzy powierzchnie, które możesz wypełniać niezależnie: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) oraz [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Ustaw dla wybranej powierzchni [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na `Picture` i przypisz obraz. Ustaw zarówno [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) jak i [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) powierzchni na `Stretch`, aby dopasować jedną kopię obrazu do całej powierzchni.

Zapisz [arrow.png](arrow.png) w katalogu roboczym. Przykład obraca wykres i podnosi maksymalną wartość na osi pionowej, aby podłoga była widoczna pomiędzy kolumnami. Następnie dwukrotnie klonuje slajd, stosując strzałkę do innej powierzchni na każdym slajdzie. Wszystkie trzy wykresy zachowują te same dane, kąt patrzenia i tło.

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

Microsoft PowerPoint wyświetla trzy slajdy w następujący sposób.

| Ściana boczna | Ściana tylna | Podłoga |
| --- | --- | --- |
| ![Strzałka wskazująca w wykres wzdłuż ściany bocznej](side-wall.png) | ![Strzałka wskazująca w prawo po ścianie tylnej](back-wall.png) | ![Strzałka wskazująca w prawo po podłodze między kolumnami](floor.png) |

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/), aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, obrót, głębokość, odstępy między seriami i formatowanie są identyczne we wszystkich trzech plikach; zmienia się jedynie procent wysokości.

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

Poniższe obrazy zostały wyeksportowane z wygenerowanych prezentacji przy użyciu Microsoft PowerPoint. Mniejszy procent daje płaską scenę, większy – wyższą scenę w tym samym obiekcie wykresu. PowerPoint może także dostosować interwały znaków osi i położenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50 % szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100 % szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200 % szerokości](height_percent_200.png) |

Te właściwości kontrolują różne aspekty wykresu:

| Właściwość | Efekt |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Wysokość sceny 3D jako procent jej szerokości. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Głębokość sceny 3D jako procent jej szerokości. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Odległość między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |

Ustawienie wysokości wpływa na wykresy kolumnowe i słupkowe 3D, w tym warianty cylinder, stożek i piramida, a także wykresy liniowe, powierzchniowe i kołowe 3D. Powyższe porównanie używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu wykresu 2D `ClusteredColumn` ani wykresu `BubbleWith3D`; są to członkowie wyliczenia [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Dla innych ustawień wyglądu wykresu zobacz [Chart Formatting](/slides/pl/net/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) do kontrolowania odległości między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażonej jako procent szerokości znacznika. Dozwolone wartości to **0 do 500**, włącznie: `0` usuwa odstęp, wyższe wartości zwiększają przestrzeń. Przy stałej głębokości wykresu zwiększenie odstępu powoduje, że znaczniki stają się cieńsze wzdłuż osi głębokości.

Dostęp do grupy uzyskuje się przez [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Ustawienie ma zastosowanie do każdej serii w tej grupie, nie tylko do serii użytej do uzyskania grupy. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) jest tylko do odczytu i odzwierciedla ustawienie grupy nadrzędnej.

To ustawienie wpływa na wykresy kolumnowe i słupkowe 3D, w tym ich warianty cylinder, stożek i piramida, a także wykresy liniowe i powierzchniowe 3D. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, skupione czy skumulowane. Aby uzyskać wyraźne porównanie odstępów między oddzielnymi seriami, użyj `ChartType.Column3D` z wyliczenia [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Te właściwości kontrolują różne aspekty wykresu:

| Właściwość | Efekt |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Odległość między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Odległość między sąsiednimi skupiskami słupków lub kolumn, jako procent ich szerokości. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Ogólna głębokość wykresu, jako procent szerokości wykresu. |

Poniższy, samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, obrotem, szerokością odstępu i głębokością wykresu; zmienia się wyłącznie głębokość odstępu.

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

Poniższe obrazy zostały wyeksportowane z wygenerowanych prezentacji przy użyciu Microsoft PowerPoint.

| Głębokość odstępu: 0% | Głębokość odstępu: 500% |
| --- | --- |
| ![Wykres kolumnowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z 500 % odstępem między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie skumulowanych cylindrów pierwsza seria zaczyna się od kształtu słupka cylindrycznego. Przykład odczytuje [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) oraz [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) przed i po każdej zmianie.

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

| Zmiana pierwszej serii | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Utwórz wykres | `ClusteredCylinder` | `Cylinder` |
| Ustaw `Type` na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ustaw `Bar3DShape` na `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` zmienia również typ serii na `ClusteredColumn3D`. Jeśli Twój kod rozgałęzia się w zależności od typu serii, odczytaj `series.Type` po zmianie kształtu. Wartość zbuforowana przed przypisaniem nadal spowodowałaby wybranie gałęzi `ClusteredCone`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje 3‑D warianty wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100 % Stacked Column 3D, a także powiązane typy 3D udostępniane przez wyliczenie [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) w dokumentacji API zainstalowanej wersji.

**Czy mogę otrzymać rastrowy obraz wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres do obrazu przy użyciu [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) lub [renderować cały slajd](/slides/pl/net/convert-powerpoint-to-png/) do formatów takich jak PNG czy JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od wielkości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, ogranicz efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, o ile to możliwe, oraz renderuj do odpowiednio dobranej rozdzielczości i wymiarów, aby dopasować się do docelowego wyświetlacza lub wymagań druku.