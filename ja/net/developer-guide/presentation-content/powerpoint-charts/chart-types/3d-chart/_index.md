---
title: .NET のプレゼンテーションで 3D チャートをカスタマイズする
linktitle: 3D チャート
type: docs
url: /ja/net/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。C# のサンプルで回転、高さの比率、チャートの深さ、シリーズ間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for .NET を使用すると、[IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) プロパティを介して 3D チャートの表示をカスタマイズできます。本記事では、回転、高さの比率、深さ、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と深さの設定**

以下の例は [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成し、[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) を使用して最初のスライドにスタック 3D 列チャートを追加します。デフォルトのシリーズとカテゴリを、各 3 つの値を持つ 2 つのシリーズに置き換えます。ワークシートインデックス `0` はチャートの最初のデータワークシートを示し、行 `0` がシリーズ名、列 `0` がカテゴリラベルを保持します。

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) と [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) プロパティはそれぞれチャートの回転を 40 度と 270 度に設定します。[DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) は幅の 150% に深さを設定し、[RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) は遠近法の代わりに直角軸を有効にします。結果のプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D チャートの高さ比率の調整**

[IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例はデフォルトデータ（3 つのシリーズと 4 つのカテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) チャートを作成し、高さ比率が 50%、100%、200% の 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、シリーズ間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

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

以下の画像は Microsoft PowerPoint を使用して生成されたプレゼンテーションからエクスポートしたものです。小さいパーセンテージはフラットなシーンを、 大きいパーセンテージは同じチャートオブジェクト内で高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛間隔やラベル配置を自動調整することがあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さの 3D 列チャート](height_percent_50.png) | ![幅の 100% に設定された高さの 3D 列チャート](height_percent_100.png) | ![幅の 200% に設定された高さの 3D 列チャート](height_percent_200.png) |

これらのプロパティは、チャートのさまざまな側面を制御します:

| プロパティ | 効果 |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | 幅に対する 3D シーンの高さのパーセンテージ。 |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | スライド上のチャートオブジェクトの高さ（ポイント）。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 幅に対する 3D シーンの深さのパーセンテージ。 |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | マーカー幅のパーセンテージで表した、深さ軸に沿ったシリーズ間の間隔。 |

高さ設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 列および棒チャート、ならびに 3D 折れ線、面、円、サーフェス チャートに影響します。上記比較は検証済みの `Column3D` タイプを使用しています。この設定は 2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更しません。これらは [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体のメンバーです。その他のチャート外観設定については、[チャートの書式設定](/slides/ja/net/chart-formatting/) を参照してください。

## **シリーズ間のギャップの調整**

[IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) を使用して、3D チャートの深さ軸に沿ったデータシリーズ間の距離をマーカー幅のパーセンテージで制御します。**0 から 500**（含む）の値を使用できます：`0` はギャップを削除し、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) を通じてグループにアクセスします。この設定はそのグループ内のすべてのシリーズに適用され、アクセスに使用したシリーズだけに限定されません。[IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) は読み取り専用で、親グループの設定を反映します。

この設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 列および棒チャート、ならびに 3D 折れ線および面チャートに影響します。外観はシリーズが深さ方向に配置されているか、クラスター化されているか、スタックされているかによって変わります。個別シリーズ間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体の `ChartType.Column3D` を使用してください。

これらのプロパティは、チャートのさまざまな側面を制御します:

| プロパティ | 効果 |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 深さ軸に沿ったシリーズ間の間隔（マーカー幅のパーセンテージ）。 |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | 隣接する棒または列クラスター間の間隔（棒または列幅のパーセンテージ）。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | チャート幅に対する全体的な深さのパーセンテージ。 |

以下の例はデフォルトのチャートデータ（3 つのシリーズと 4 つのカテゴリ）を使用し、データ、回転、ギャップ幅、チャート深さが同一の 2 つのプレゼンテーションを保存します。ギャップ深さだけが変わります。

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

以下の画像は Microsoft PowerPoint を使用して生成されたプレゼンテーションからエクスポートしたものです。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿ったシリーズ間にギャップがない 3D 列チャート](gap_depth_0.png) | ![深さ軸に沿ったシリーズ間に 500% のギャップがある 3D 列チャート](gap_depth_500.png) |

## **3D シリーズ タイプとバー形状の変更**

クラスター化シリンダーチャートでは、最初のシリーズはシリンダー形状のバーで開始します。例では、各変更前後に [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) と [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) を読み取ります。

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

| 最初のシリーズへの変更 | `Type` | `Bar3DShape` |
| --- | --- | --- |
| チャートを作成 | `ClusteredCylinder` | `Cylinder` |
| `Type` を `ClusteredCone` に設定 | `ClusteredCone` | `Cone` |
| `Bar3DShape` を `Box` に設定 | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、シリーズタイプも `ClusteredColumn3D` に変更されます。コードがシリーズタイプで分岐している場合、形状変更後に `series.Type` を読み取ってください。代入前にキャッシュされた値は依然として `ClusteredCone` 分岐を選択します。

![左から右へ、シリンダー、コーン、矩形列として表示された最初のシリーズの PowerPoint 比較](series-shapes.png)

## **FAQ**

**Aspose.Slides がサポートする 3D モードのチャート タイプはどれですか？**

Aspose.Slides は列チャートの 3D バリエーション（Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D）をサポートし、関連する 3D タイプは [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で公開されています。正確な最新リストは、インストール済みバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) のメンバーをご確認ください。

**レポートや Web 用に 3D チャートのラスター画像を取得できますか？**

はい。[Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) を使用してチャートを画像としてエクスポートするか、[スライド全体をレンダリング](/slides/ja/net/convert-powerpoint-to-png/) して PNG や JPEG 形式で保存できます。これにより、ラスター プレビューが必要な場合や、PowerPoint を必要とせずに文書、ダッシュボード、Web ページにチャートを埋め込むことが容易になります。

**大規模な 3D チャートの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。ベストプラクティスとして、3D 効果は最小限に抑え、壁やプロット領域への重いテクスチャを避け、可能な限りシリーズあたりのデータポイント数を制限し、ターゲット表示または印刷要件に合わせた解像度とサイズで出力することを推奨します。