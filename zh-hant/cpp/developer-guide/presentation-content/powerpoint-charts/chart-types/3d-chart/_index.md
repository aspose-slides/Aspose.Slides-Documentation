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
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立 3D 圖表。透過 C++ 範例調整旋轉、高度比例、圖表深度以及系列間的間距。"
---
## **概觀**

Aspose.Slides for C++ 讓您能透過 [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/) 自訂 3D 圖表的檢視方式。本文示範如何調整旋轉角度、높度比例、深度、直角座標軸以及系列間的間距，並將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)，並使用 [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) 在第一張投影片上加入堆疊式 3D 柱狀圖。它會將預設系列與類別取代為兩個系列，每個系列各有三個值。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) 與 [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) 方法分別將圖表的旋轉設定為 40 與 270 度。[set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) 將深度設定為寬度的 150%，而 [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) 則啟用直角座標軸而非透視。最終的簡報包含已設定這些 3D 檢視參數的圖表。

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

## **對 3D 圖表表面套用圖片填充**

您可以分別填充 3D 圖表的 [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/)、[back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) 與 [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/)。將表面的 [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) 設為 `Picture` 並指派影像。若要讓單一影像完整覆蓋表面，請將 [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) 與表面的 [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) 都設為 `Stretch`。

將 [arrow.png](arrow.png) 儲存於工作目錄。範例會旋轉圖表並提升垂直軸的最大值，使底面在柱狀之間可見。接著將投影片複製兩次，分別在不同表面套用箭頭。三個圖表保留相同的資料、檢視角度與背景。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Microsoft PowerPoint 會如下顯示三張投影片。

| 側牆 | 後牆 | 底面 |
| --- | --- | --- |
| ![指向圖表側牆的箭頭](side-wall.png) | ![指向後牆右側的箭頭](back-wall.png) | ![指向柱狀之間底面的箭頭](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) 可將 3D 圖表的高度設定為寬度的百分比。此設定會在不改變投影片上圖表物件大小的情況下，改變 3D 場景的比例。

以下範例建立一個使用預設資料的 [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 圖表（三個系列、四個類別），並產生三個簡報，其高度比例分別為 50%、100% 與 200%。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，僅高度百分比不同。

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

以下影像取自等效的 .NET 範例，使用 Microsoft PowerPoint 匯出，說明相同的高度設定。較小的比例會產生較平坦的場景，較大的比例則在相同圖表物件內呈現較高的場景。PowerPoint 也可能會調整座標軸刻度間隔與標籤位置，以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度設定為寬度 50% 的 3D 柱狀圖](height_percent_50.png) | ![高度設定為寬度 100% 的 3D 柱狀圖](height_percent_100.png) | ![高度設定為寬度 200% 的 3D 柱狀圖](height_percent_200.png) |

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | 3D 場景的高度佔寬度的百分比。 |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | 投影片上圖表物件的高度（點數）。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 3D 場景的深度佔寬度的百分比。 |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 系列在深度軸上的間距，依標記寬度的百分比表示。 |

高度設定會影響包含圓柱體、錐體與金字塔變體的 3D 柱狀與條狀圖，以及 3D 折線、面積、圓餅與曲面圖。上表使用已驗證的 `Column3D` 型別。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱皆屬於 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列舉型別的成員。其他圖表外觀設定請參閱 [Chart Formatting](/slides/zh-hant/cpp/chart-formatting/)。

## **調整系列間的間隙**

使用 [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) 控制 3D 圖表中資料系列在深度軸上的間距，數值以標記寬度的百分比表示。允許的範圍為 **0 到 500**（含）：`0` 會移除間隙，較大的數值會增加間距。在固定圖表深度的情況下，增大間隙會使標記在深度軸上變得較細。

透過 [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) 取得群組。此設定會套用到該群組中的所有系列，而不僅是取得群組的那一個系列。[IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) 會回傳父群組的設定值。

此設定會影響包含圓柱體、錐體與金字塔變體的 3D 柱狀與條狀圖，以及 3D 折線與面積圖。外觀取決於系列是以深度、群組或堆疊方式排列。若要清楚比較不同系列間的間隙，請使用來自 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列舉的 `ChartType::Column3D`。

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 系列在深度軸上的間距，依標記寬度的百分比表示。 |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | 相鄰條或柱叢之間的間距，依條或柱寬度的百分比表示。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 整體圖表深度，依圖表寬度的百分比表示。 |

以下自包含範例使用預設圖表資料（三個系列、四個類別），並產生兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，僅間距深度不同。

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

以下影像取自等效的 .NET 範例，使用 Microsoft PowerPoint 匯出，說明相同的間距深度設定。

| 間距深度：0% | 間距深度：500% |
| --- | --- |
| ![深度軸上系列之間沒有間距的 3D 柱狀圖](gap_depth_0.png) | ![深度軸上系列之間有 500% 間距的 3D 柱狀圖](gap_depth_500.png) |

## **變更 3D 系列類型與條狀形狀**

在群組圓柱體圖表中，第一個系列預設為圓柱形條狀。範例在每次變更前後讀取 [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) 以及 [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/)。

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

| 變更第一個系列 | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 呼叫 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) 並傳入 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 呼叫 [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) 並傳入 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設定為 `Box` 亦會將系列類型改為 `ClusteredColumn3D`。如果您的程式碼依系列類型分支，請在變更形狀後再次呼叫 `series->get_Type()`。在變更前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，左至右分別顯示第一個系列為圓柱體、錐體與矩形柱狀](series-shapes.png)

## **常見問題集**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援多種 3D 柱狀圖變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，及透過 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 列舉所揭露的相關 3D 類型。欲取得完整且最新的列表，請檢視您所安裝版本的 API 參考中的 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以供報告或網頁使用嗎？**

可以。您可以使用 [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) 匯出圖表為影像，或將整張投影片 [render the entire slide](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。這在需要點陣預覽或將圖表嵌入文件、儀表板或網頁，而不需 PowerPoint 時特別有用。

**建立與渲染大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳效果，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。