---
title: 使用 C++ 在簡報中自訂 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/cpp/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立 3D 圖表。透過 C++ 範例調整旋轉、 高度比例、 圖表深度以及系列間的間距。"
---
## **概觀**

Aspose.Slides for C++ 允許您透過[IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/)自訂 3D 圖表的檢視方式。本篇文章示範如何調整旋轉、 高度比例、 深度、 直角座標軸，以及系列之間的間距，最後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)，並使用[IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)在第一張投影片上加入堆疊式 3D 柱狀圖。它會以兩個每個包含三個值的系列取代預設的系列與類別。工作表索引`0`代表圖表的第一個資料工作表；第`0`列保存系列名稱，第`0`欄保存類別標籤。

[set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/)與[set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/)方法分別將圖表的旋轉設定為 40 與 270 度。[set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/)將深度設定為寬度的 150%，而[set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/)則啟用直角座標軸而非透視。產生的簡報包含套用這些 3D 檢視設定的圖表。

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

## **調整 3D 圖表的高度比例**

使用[IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/)以寬度的百分比設定 3D 圖表的高度。此操作會改變 3D 場景的比例，卻不會改變投影片上圖表物件的大小。

以下範例建立一個[Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)圖表，使用預設資料：三個系列與四個類別。它會以 50%、100% 與 200% 的高度比例分別儲存三個簡報。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，唯一改變的是高度百分比。

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

以下圖片取自等效的 .NET 範例，使用 Microsoft PowerPoint 匯出，說明相同的高度設定。較小的百分比會產生較平坦的場景，較大的百分比則在相同圖表物件中產生較高的場景。PowerPoint 可能會同時調整座標軸刻度間隔與標籤位置以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 欄狀圖，高度設定為寬度的 50%](height_percent_50.png) | ![3D 欄狀圖，高度設定為寬度的 100%](height_percent_100.png) | ![3D 欄狀圖，高度設定為寬度的 200%](height_percent_200.png) |

以下方法控制圖表的不同層面：

| 方法 | 效果 |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | 以寬度的百分比設定 3D 場景的高度。 |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | 以點數設定投影片上圖表物件的高度。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 以寬度的百分比設定 3D 場景的深度。 |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 以標記寬度的百分比設定沿深度軸的系列間距。 |

高度設定會影響 3D 柱狀圖與條形圖（包括圓柱、圓錐與金字塔變體），以及 3D 折線圖、面積圖、圓餅圖與曲面圖。上表使用驗證過的 `Column3D` 類型。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱皆為[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列舉型別的成員。如需其他圖表外觀設定，請參閱[Chart Formatting](/slides/zh-hant/cpp/chart-formatting/)。

## **調整系列之間的間隙**

使用[IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/)以標記寬度的百分比控制 3D 圖表中資料系列沿深度軸的距離。可接受的值為 **0 到 500**（含），`0` 會移除間隙，較大的值則會增加間距。當圖表深度固定時，增加間隙會使標記在深度軸上變得較細。

透過[IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/)存取群組。此設定會套用到該群組中的每個系列，而不僅限於用來取得群組的那個系列。[IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/)會回傳父群組的設定。

此設定會影響 3D 柱狀圖與條形圖（包括圓柱、圓錐與金字塔變體），以及 3D 折線與面積圖。外觀取決於系列是深度排列、群集或堆疊。若要清楚比較分開系列之間的間隙，請使用[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列舉中的`ChartType::Column3D`。

以下方法控制圖表的不同層面：

| 方法 | 效果 |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 以標記寬度的百分比設定沿深度軸的系列間距。 |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | 以條形或欄位寬度的百分比設定相鄰條形或欄位群組之間的間距。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 以圖表寬度的百分比設定整體圖表深度。 |

以下自行完整的範例使用預設圖表資料，包含三個系列與四個類別。它會儲存兩個簡報，資料、旋轉、間距與圖表深度相同，唯一改變的是間距深度。

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

以下圖片取自等效的 .NET 範例，使用 Microsoft PowerPoint 匯出，說明相同的間距深度設定。

| 間距深度：0% | 間距深度：500% |
| --- | --- |
| ![3D 欄狀圖，深度軸上系列之間無間隙](gap_depth_0.png) | ![3D 欄狀圖，深度軸上系列之間有 500% 的間隙](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在群集圓柱圖中，第一系列的條形預設為圓柱形。範例會在每次變更前後讀取[IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/)與[IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/)。

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

| 對第一系列的變更 | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) 並傳入 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 呼叫 [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) 並傳入 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設定為 `Box` 也會將系列類型變更為 `ClusteredColumn3D`。如果您的程式碼根據系列類型分支，請在變更形狀後呼叫`series->get_Type()`。在變更前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一系列從左至右分別為圓柱、圓錐與矩形欄位](series-shapes.png)

## **常見問題**

**哪種類型的圖表在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援欄狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，以及透過[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列舉公開的相關 3D 類型。如需確切且最新的清單，請檢查您所安裝版本的 API 參考中[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以供報告或網站使用嗎？**

可以。您可以使用[Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)將圖表匯出為影像，或使用[render the entire slide](/slides/zh-hant/cpp/convert-powerpoint-to-png/)匯出整張投影片為 PNG、JPEG 等格式。當您需要點陣圖預覽，或想在文件、儀表板或網頁中嵌入圖表而不需 PowerPoint 時，這非常實用。

**建立與渲染大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳效果，建議盡量減少 3D 效果，避免在牆面與繪圖區使用大量紋理，盡可能限制每個系列的資料點數，並將輸出解析度與尺寸設為符合目標顯示或列印需求的大小。