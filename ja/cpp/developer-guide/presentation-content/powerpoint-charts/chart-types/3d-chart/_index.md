---
title: C++ を使用してプレゼンテーションの 3D チャートをカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/cpp/3d-chart/
keywords:
- 3D チャート
- 回転
- 奥行き
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。C++ のサンプルで回転、高さの割合、チャートの奥行き、系列間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for C++ を使用すると、[IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/) を介して 3D チャートのビューをカスタマイズできます。この記事では、回転、高さの割合、奥行き、直角軸、系列間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と深さの設定**

以下のサンプルは、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) を作成し、[IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) を使用して最初のスライドに積み上げ 3D コラムチャートを追加します。既定の系列とカテゴリを、各 3 つの値を持つ 2 系列に置き換えます。ワークシートインデックス `0` はチャートの最初のデータ ワークシートを示し、行 `0` が系列名、列 `0` がカテゴリ ラベルを保持します。

[set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) と [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) メソッドはそれぞれチャートの回転を 40 度と 270 度に設定します。[set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) は幅の 150% の深さに設定し、[set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) は透視投影の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **3D チャートの高さの割合の調整**

[IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) を使用して、3D チャートの高さを幅に対するパーセンテージで設定できます。これにより、スライド上のチャート オブジェクトのサイズを変更せずに 3D シーンの比例が変わります。

以下の例は、デフォルト データ（系列 3 件、カテゴリ 4 件）を持つ [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) チャートを作成し、高さの割合を 50%、100%、200% にした 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、系列間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

以下の画像は同等の .NET サンプルから Microsoft PowerPoint でエクスポートしたもので、同じ高さ設定を示しています。パーセンテージが小さいほどシーンは平坦になり、パーセンテージが大きいほど同一チャート オブジェクト内でシーンが高くなります。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置も調整することがあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さの 3D コラムチャート](height_percent_50.png) | ![幅の 100% に設定された高さの 3D コラムチャート](height_percent_100.png) | ![幅の 200% に設定された高さの 3D コラムチャート](height_percent_200.png) |

これらのメソッドはチャートの異なる側面を制御します。

| メソッド | 効果 |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | 3D シーンの高さを幅に対するパーセンテージで設定します。 |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | スライド上のチャート オブジェクトの高さをポイント単位で設定します。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 3D シーンの奥行きを幅に対するパーセンテージで設定します。 |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | マーカー幅に対するパーセンテージで、深さ軸に沿った系列間の間隔を設定します。 |

高さの設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D コラムおよびバーチャート、さらに 3D ライン、エリア、パイ、サーフェス チャートに影響します。上記の比較は検証済みの `Column3D` 型を使用しています。この設定は 2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更しません。これらは [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列挙体のメンバーです。その他のチャート外観設定については、[Chart Formatting](/slides/ja/cpp/chart-formatting/) を参照してください。

## **系列間のギャップの調整**

[IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) を使用して、3D チャートの深さ軸に沿ったデータ系列間の距離をマーカー幅に対するパーセンテージで制御します。**0 から 500**（包括）の範囲の値を使用できます。`0` はギャップを除去し、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

[IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) でグループにアクセスします。この設定はそのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限定されません。[IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) は親グループの設定を返します。

この設定はシリンダー、コーン、ピラミッド バリエーションを含む 3D コラムおよびバーチャート、さらに 3D ラインとエリア チャートに影響します。外観は系列が深さ方向に配置されているか、クラスター化されているか、積み上げられているかによって異なります。個別系列間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列挙体の `ChartType::Column3D` を使用してください。

これらのメソッドはチャートの異なる側面を制御します。

| メソッド | 効果 |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 深さ軸に沿った系列間の間隔を、マーカー幅に対するパーセンテージで設定します。 |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | 隣接するバーまたはコラム クラスター間の間隔を、バーまたはコラム幅に対するパーセンテージで設定します。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | チャート全体の深さを、チャート幅に対するパーセンテージで設定します。 |

以下の独立したサンプルはデフォルトのチャート データ（系列 3 件、カテゴリ 4 件）を使用します。データ、回転、ギャップ幅、チャート深さは同一で、ギャップ深さだけが異なる 2 つのプレゼンテーションを保存します。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

以下の画像は同等の .NET サンプルから Microsoft PowerPoint でエクスポートしたもので、同じギャップ深さ設定を示しています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿って系列間にギャップがない 3D コラムチャート](gap_depth_0.png) | ![深さ軸に沿って系列間に 500% のギャップがある 3D コラムチャート](gap_depth_500.png) |

## **3D 系列タイプとバー形状の変更**

クラスター化シリンダー チャートでは、最初の系列はシリンダー形状のバーで開始します。サンプルは各変更前後に [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) と [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) を読み取ります。

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| 最初の系列の変更 | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| チャート作成 | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` で [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) を呼び出す | `ClusteredCone` | `Cone` |
| `Box` で [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) を呼び出す | `ClusteredColumn3D` | `Box` |

形状を `Box` に設定すると、系列タイプも `ClusteredColumn3D` に変更されます。コードが系列タイプで分岐している場合は、形状変更後に `series->get_Type()` を呼び出してください。変更前にキャッシュされた値は依然として `ClusteredCone` のブランチを選択します。

![左から右へ、シリンダー、コーン、長方形の列として表示された最初の系列を示す PowerPoint 比較画像](series-shapes.png)

## **FAQ**

**どのチャートタイプが Aspose.Slides で 3D モードをサポートしていますか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D を含むコラム チャートの 3D バリエーション、および [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列挙体で公開されている関連 3D タイプをサポートします。正確で最新の一覧は、インストール済みバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) のメンバーを確認してください。

**レポートや Web 用に 3D チャートのラスタ画像を取得できますか？**

はい。[Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) を使用してチャートを画像としてエクスポートするか、[スライド全体をレンダリング](/slides/ja/cpp/convert-powerpoint-to-png/) して PNG や JPEG 形式で取得できます。これにより、ラスタ プレビューが必要な場合や、PowerPoint を使用せずに文書、ダッシュボード、ウェブページにチャートを埋め込むことができます。

**大規模な 3D チャートの構築とレンダリングはどの程度のパフォーマンスですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。ベストな結果を得るには、3D エフェクトを最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限り系列ごとのデータポイント数を制限し、ターゲットの表示または印刷要件に合わせた解像度とサイズで出力してください。