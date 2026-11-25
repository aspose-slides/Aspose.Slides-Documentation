---
title: .NET でプレゼンテーションの 3D チャートをカスタマイズする
linktitle: 3D チャート
type: docs
url: /ja/net/3d-chart/
keywords:
- 3D チャート
- 回転
- 奥行き
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint のプレゼンテーションに 3D チャートを作成します。C# のサンプルで回転、高さの割合、チャートの奥行き、系列間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for .NET では、[IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) プロパティを使用して 3D チャートの表示をカスタマイズできます。この記事では、回転、高さの割合、奥行き、直角軸、系列間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と奥行きを設定する**

以下の例では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成し、[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) を使用して最初のスライドに積み上げ 3D 縦棒チャートを追加します。デフォルトの系列とカテゴリを、各 3 つの値を持つ 2 つの系列に置き換えます。ワークシート インデックス `0` はチャートの最初のデータ ワークシートを示し、行 `0` には系列名、列 `0` にはカテゴリ ラベルが格納されます。

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) と [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) プロパティは、それぞれチャートの回転を 40 度および 270 度に設定します。[DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) は幅の 150% の深さに設定し、[RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) は透視投影の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D チャートの表面に画像塗りつぶしを適用する**

3D チャートには、独立して塗りつぶすことのできる 3 つの表面があります: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/)、[back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/)、[floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/)。選択した表面の [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) を `Picture` に設定し、画像を割り当てます。[picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) と表面の [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) の両方を `Stretch` に設定して、画像を表面全体に 1 枚でフィットさせます。

[arrow.png](arrow.png) を作業ディレクトリに保存します。例では、チャートを回転させ、垂直軸の最大値を上げて列間に床が見えるようにします。その後、スライドを 2 回複製し、各スライドの別の表面に矢印を適用します。3 つのチャートはすべて同じデータ、視点、背景を保持します。

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

Microsoft PowerPoint は、次のように 3 つのスライドを表示します。

| 側壁 | 背面壁 | 床 |
| --- | --- | --- |
| ![側壁に沿ってチャート内に向かう矢印](side-wall.png) | ![背面壁を横切って右向きの矢印](back-wall.png) | ![列間の床を横切って右向きの矢印](floor.png) |

## **3D チャートの高さの割合を調整する**

[IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャート オブジェクトのサイズを変更せずに 3D シーンの比例が変わります。

以下の例では、デフォルト データ（3 系列、4 カテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) チャートを作成します。高さの割合を 50%、100%、200% に設定した 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、奥行き、系列間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

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

以下の画像は、Microsoft PowerPoint を使用して生成されたプレゼンテーションからエクスポートしたものです。割合が小さいほど平坦なシーンになり、割合が大きいほど同じチャートオブジェクト内でより高いシーンになります。PowerPoint はシーンに合わせて軸目盛りの間隔やラベルの配置を調整することがあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さの 3D 縦棒チャート](height_percent_50.png) | ![幅の 100% に設定された高さの 3D 縦棒チャート](height_percent_100.png) | ![幅の 200% に設定された高さの 3D 縦棒チャート](height_percent_200.png) |

これらのプロパティはチャートのさまざまな側面を制御します：

| Property | Effect |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | 3D シーンの高さを幅のパーセンテージで表したもの。 |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | スライド上のチャートオブジェクトの高さ（ポイント単位）。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 3D シーンの深さを幅のパーセンテージで表したもの。 |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 深さ軸に沿った系列間の間隔（マーカー幅のパーセンテージ）。 |

高さ設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 縦棒および横棒チャート、ならびに 3D ライン、エリア、円、サーフェス チャートに影響します。上記の比較は検証済みの `Column3D` タイプを使用しています。この設定は 2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体のメンバーです。その他のチャート外観設定については、[Chart Formatting](/slides/ja/net/chart-formatting/) を参照してください。

## **系列間のギャップを調整する**

[IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) を使用して、3D チャートの深さ軸に沿ったデータ系列間の距離をマーカー幅のパーセンテージで制御します。**0 から 500**（両端含む）の値を使用します：`0` はギャップをなくし、値が大きくなるほど間隔が広がります。チャートの奥行きを固定したままギャップを増やすと、深さ軸に沿ったマーカーが細くなります。

[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) を介してグループにアクセスします。この設定は、そのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限られません。[IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) は読み取り専用で、親グループの設定を反映します。

この設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 縦棒・横棒チャート、および 3D ライン・エリアチャートに影響します。外観は系列が深さ方向に配置されているか、クラスター化されているか、積み上げられているかによって変わります。別々の系列間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体の `ChartType.Column3D` を使用してください。

これらのプロパティはチャートのさまざまな側面を制御します：

| Property | Effect |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 深さ軸に沿った系列間の間隔（マーカー幅のパーセンテージ）。 |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | 隣接する棒または列クラスター間の間隔（棒または列幅のパーセンテージ）。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | チャート全体の奥行き（チャート幅のパーセンテージ）。 |

以下の自己完結型例は、3 系列 4 カテゴリを含むデフォルトのチャート データを使用します。データ、回転、ギャップ幅、チャートの奥行きが同一の 2 つのプレゼンテーションを保存し、ギャップの深さだけが変わります。

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

以下の画像は、Microsoft PowerPoint を使用して生成されたプレゼンテーションからエクスポートしたものです。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿った系列間にギャップがない 3D 縦棒チャート](gap_depth_0.png) | ![深さ軸に沿った系列間に 500% のギャップがある 3D 縦棒チャート](gap_depth_500.png) |

## **3D 系列タイプと棒形状を変更する**

クラスター化シリンダー チャートでは、最初の系列はシリンダー形状の棒で始まります。例では、各変更前後に [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) と [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) を読み取ります。

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

| 最初の系列への変更 | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set `Type` to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set `Bar3DShape` to `Box` | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、系列タイプも `ClusteredColumn3D` に変更されます。コードが系列タイプで分岐している場合は、形状を変更した後に `series.Type` を読み取ってください。代入前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![PowerPoint の比較画像。左から右へ、最初の系列がシリンダー、コーン、矩形列として表示されています](series-shapes.png)

## **よくある質問**

**Aspose.Slides がサポートする 3D モード対応のチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの列チャートの 3D バリエーションと、[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で公開されている関連 3D タイプをサポートします。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) のメンバーを確認してください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) で画像にエクスポートしたり、[render the entire slide](/slides/ja/net/convert-powerpoint-to-png/) を使用して PNG や JPEG などの形式に変換できます。ラスタ プレビューが必要な場合や、PowerPoint を使用せずに文書、ダッシュボード、ウェブページにチャートを埋め込む場合に便利です。

**大規模な 3D チャートの構築とレンダリングのパフォーマンスはどの程度ですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るには、3D 効果を最小限に抑え、壁やプロット領域への重いテクスチャを避け、可能な限り系列ごとのデータポイント数を制限し、対象の表示や印刷要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。