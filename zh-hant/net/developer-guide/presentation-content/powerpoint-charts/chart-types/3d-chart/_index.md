---
title: 在 .NET 中自訂簡報的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/net/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立 3D 圖表。透過 C# 範例調整旋轉、 高度比例、圖表深度與系列間的間距。"
---
## **概觀**

Aspose.Slides for .NET 允許您透過 [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) 屬性自訂 3D 圖表的檢視。本文示範如何調整旋轉、高度比例、深度、直角座標軸以及系列間距離，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 並使用 [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) 在其第一張投影片上新增堆疊式 3D 柱狀圖。它以兩個每個包含三個值的系列取代預設的系列與類別。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列存放系列名稱，第 `0` 欄存放類別標籤。

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) 與 [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) 屬性分別將圖表的旋轉設定為 40 度與 270 度。[DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) 將其深度設定為寬度的 150%，而 [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) 則啟用直角座標軸取代透視。最終的簡報包含套用這些 3D 觀察設定的填入圖表。

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

## **對 3D 圖表表面套用圖片填色**

3D 圖表有三個表面可獨立填色： [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/)、 [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/)、 [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/)。將選取表面的 [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為 `Picture` 並指定圖片。再將 [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) 與表面的 [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) 都設為 `Stretch`，使單一圖片複本填滿整個表面。

將 [arrow.png](arrow.png) 儲存於工作目錄。範例會旋轉圖表並提升垂直軸的最大值，使得地板在柱狀之間可見。接著複製投影片兩次，然後在每張投影片的不同表面套用箭頭。三個圖表保留相同的資料、檢視角度與背景。

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

Microsoft PowerPoint 會如下顯示這三張投影片。

| 側牆 | 背牆 | 底面 |
| --- | --- | --- |
| ![箭頭指向圖表側牆](side-wall.png) | ![箭頭指向右側穿過背牆](back-wall.png) | ![箭頭指向右側穿過柱狀之間的底面](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) 以圖表寬度的百分比設定 3D 圖表的高度。此設定會改變 3D 場景的比例，卻不會調整投影片上圖表物件的大小。

以下範例建立一個使用預設資料（三個系列與四個類別）的 [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 圖表。它會將三個簡報分別儲存為高度比例為 50%、100% 與 200%。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，唯一改變的是高度百分比。

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

以下影像是使用 Microsoft PowerPoint 從產生的簡報匯出。較小的百分比會產生較平坦的場景，而較大的百分比會在相同圖表物件內產生較高的場景。PowerPoint 也可能調整座標軸刻度間隔與標籤位置以配合場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱狀圖，高度設定為寬度的 50%](height_percent_50.png) | ![3D 柱狀圖，高度設定為寬度的 100%](height_percent_100.png) | ![3D 柱狀圖，高度設定為寬度的 200%](height_percent_200.png) |

這些屬性控制圖表的不同面向：

| 屬性 | 效果 |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | 3D 場景的高度，以寬度的百分比表示。 |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | 投影片上圖表物件的高度，單位為點 (points)。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 3D 場景的深度，以寬度的百分比表示。 |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條狀圖，包括圓柱、圓錐與金字塔等變體，以及 3D 折線、區域、圓餅與曲面圖。上述比較使用已驗證的 `Column3D` 類型。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱是 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列舉的成員。其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/net/chart-formatting/)。

## **調整系列間的間距**

使用 [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) 來控制 3D 圖表中資料系列在深度軸上的距離，使用百分比表示相對於標記寬度。可使用 **0 到 500**（含）之間的值：`0` 會移除間距，較大的值則會增加間距。當圖表深度固定時，增大間距會使深度軸上的標記變得較薄。

透過 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) 取得群組。此設定會套用至該群組中的每個系列，而不僅是用來存取的系列。[IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) 為唯讀屬性，反映父群組的設定。

此設定會影響 3D 柱狀圖與條狀圖，包括其圓柱、圓錐與金字塔變體，以及 3D 折線與區域圖。外觀取決於系列是以深度、叢集或堆疊方式排列。若要清晰比較不同系列之間的間距，請使用來自 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列舉的 `ChartType.Column3D`。

| 屬性 | 效果 |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | 相鄰條或柱叢集之間的間距，以條或柱寬度的百分比表示。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 整體圖表深度，以圖表寬度的百分比表示。 |

以下獨立範例使用預設圖表資料，包含三個系列與四個類別。它會將兩個簡報儲存，資料、旋轉、間距寬度與圖表深度皆相同，唯一變化的是間距深度。

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

以下影像是使用 Microsoft PowerPoint 從產生的簡報匯出。

| 間距深度：0% | 間距深度：500% |
| --- | --- |
| ![3D 柱狀圖，系列在深度軸上沒有間距](gap_depth_0.png) | ![3D 柱狀圖，系列在深度軸上有 500% 的間距](gap_depth_500.png) |

## **變更 3D 系列類型與條形外觀**

在叢集式圓柱圖中，第一個系列起始為圓柱形條形。範例在每次變更前後讀取 [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) 與 [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/)。

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

| 對第一個系列的變更 | `Type` | `Bar3DShape` |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 將 `Type` 設為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將 `Bar3DShape` 設為 `Box` | `ClusteredColumn3D` | `Box` |

將外觀設定為 `Box` 也會將系列類型改為 `ClusteredColumn3D`。如果您的程式碼依系列類型分支，請在變更外觀後讀取 `series.Type`。在指派前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，左至右顯示第一個系列分別為圓柱、圓錐與矩形柱形](series-shapes.png)

## **FAQ**

**哪種圖表類型支援 Aspose.Slides 的 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，及透過 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列舉所公開的相關 3D 類型。欲取得完整且最新的清單，請在您安裝的版本之 API 參考中檢查 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖供報告或網頁使用嗎？**

可以。您可以使用 [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) 將圖表匯出為圖像，或將整張投影片[渲染](/slides/zh-hant/net/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。當您需要點陣預覽或想在文件、儀表板或網頁中嵌入圖表而不需 PowerPoint 時，此方式相當有用。

**建立與渲染大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為獲得最佳效果，請盡量減少 3D 效果，避免在牆面與繪圖區域使用大量紋理，盡可能限制每個系列的資料點數量，並以適當的輸出尺寸（解析度與尺寸）進行渲染，以符合目標顯示或列印需求。