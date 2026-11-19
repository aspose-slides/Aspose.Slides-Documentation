---
title: C++을 사용하여 프레젠테이션에서 3D 차트 맞춤화
linktitle: 3D 차트
type: docs
url: /ko/cpp/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에 3D 차트를 만들 수 있습니다. C++ 예제를 통해 회전, 높이 비율, 차트 깊이 및 시리즈 간 간격을 조정합니다."
---
## **개요**

Aspose.Slides for C++를 사용하면 [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/)를 통해 3D 차트의 보기를 사용자 지정할 수 있습니다. 이 문서에서는 회전, 높이 비율, 깊이, 직각 축 및 시리즈 간 간격을 조정하고 프레젠테이션을 PPTX 형식으로 저장하는 방법을 보여 줍니다.

## **3D 차트의 회전 및 깊이 설정**

아래 예제는 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)을 생성하고 [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)을 사용하여 첫 번째 슬라이드에 누적 3D 컬럼 차트를 추가합니다. 기본 시리즈와 범주를 각각 세 개의 값을 가진 두 개의 시리즈로 교체합니다. 워크시트 인덱스 `0`은 차트의 첫 번째 데이터 워크시트를 지정하고, 행 `0`은 시리즈 이름을, 열 `0`은 범주 레이블을 보유합니다.

[set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) 및 [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) 메서드는 차트의 회전을 각각 40도와 270도로 설정합니다. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/)는 깊이를 너비의 150%로 설정하고, [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/)는 원근 대신 직각 축을 활성화합니다. 결과 프레젠테이션에는 이러한 3D 보기 설정이 적용된 차트가 포함됩니다.

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

## **3D 차트의 높이 비율 조정**

[IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/)를 사용하여 3D 차트의 높이를 너비에 대한 백분율로 설정합니다. 이렇게 하면 슬라이드의 차트 객체 크기를 변경하지 않고 3D 장면의 비율이 바뀝니다.

다음 예제는 기본 데이터(시리즈 3개와 범주 4개)를 사용하여 [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 차트를 생성합니다. 높이 비율을 50%, 100%, 200%로 설정한 세 개의 프레젠테이션을 저장합니다. 차트의 위치, 너비 및 높이는 고정된 상태로 유지됩니다. 데이터, 회전, 깊이, 시리즈 간 간격 및 서식은 세 파일 모두 동일하며, 높이 백분율만 변경됩니다.

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

.NET 예제와 동일한 이미지를 Microsoft PowerPoint를 사용해 내보냈으며 동일한 높이 설정을 보여 줍니다. 작은 백분율은 더 평평한 장면을 만들고, 큰 백분율은 같은 차트 객체 내에서 더 높은 장면을 생성합니다. PowerPoint는 장면에 맞게 축 눈금 간격 및 레이블 위치를 조정할 수도 있습니다.

| 높이: 50% | 높이: 100% | 높이: 200% |
| --- | --- | --- |
| ![너비의 50%로 높이가 설정된 3D 컬럼 차트](height_percent_50.png) | ![너비의 100%로 높이가 설정된 3D 컬럼 차트](height_percent_100.png) | ![너비의 200%로 높이가 설정된 3D 컬럼 차트](height_percent_200.png) |

다음 메서드는 차트의 다양한 측면을 제어합니다:

| 메서드 | 효과 |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | 3D 장면의 높이를 너비에 대한 백분율로 설정합니다. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | 슬라이드에 있는 차트 객체의 높이(포인트 단위). |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 3D 장면의 깊이를 너비에 대한 백분율로 설정합니다. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 설정합니다. |

높이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선, 면, 파이 및 서피스 차트에 영향을 줍니다. 위 비교는 검증된 `Column3D` 유형을 사용합니다. 이 설정은 2D `ClusteredColumn` 차트나 `BubbleWith3D` 차트의 외관을 변경하지 않으며, 이러한 이름은 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 열거형의 멤버입니다. 다른 차트 외관 설정에 대해서는 [Chart Formatting](/slides/ko/cpp/chart-formatting/)을 참조하십시오.

## **시리즈 간 간격 조정**

[IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/)을 사용하여 3D 차트의 깊이 축을 따라 데이터 시리즈 간 거리를 마커 너비의 백분율로 제어합니다. **0부터 500까지**의 값을 사용할 수 있으며, `0`은 간격을 없애고 큰 값은 간격을 늘립니다. 차트 깊이가 고정된 경우, 간격을 늘리면 깊이 축을 따라 마커가 더 얇아집니다.

[IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/)을 통해 그룹에 접근합니다. 이 설정은 해당 그룹의 모든 시리즈에 적용되며, 접근에 사용된 시리즈에만 해당되는 것이 아닙니다. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/)은 상위 그룹의 설정을 반환합니다.

이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선 및 면 차트에 영향을 줍니다. 외관은 시리즈가 깊이별, 클러스터형, 누적형인지에 따라 달라집니다. 개별 시리즈 간 간격을 명확히 비교하려면 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 열거형의 `ChartType::Column3D`를 사용하십시오.

다음 메서드는 차트의 다양한 측면을 제어합니다:

| 메서드 | 효과 |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 설정합니다. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | 인접한 막대 또는 컬럼 클러스터 사이의 간격을 막대 또는 컬럼 너비의 백분율로 설정합니다. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 차트 전체 깊이를 차트 너비의 백분율로 설정합니다. |

다음 자체 포함 예제는 기본 차트 데이터(시리즈 3개와 범주 4개)를 사용합니다. 데이터, 회전, 간격 너비 및 차트 깊이가 동일한 두 개의 프레젠테이션을 저장하며, 간격 깊이만 변경됩니다.

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

.NET 예제와 동일한 이미지를 Microsoft PowerPoint로 내보냈으며 동일한 간격 깊이 설정을 보여 줍니다.

| 간격 깊이: 0% | 간격 깊이: 500% |
| --- | --- |
| ![깊이 축을 따라 시리즈 간 간격이 없는 3D 컬럼 차트](gap_depth_0.png) | ![깊이 축을 따라 시리즈 간 500% 간격이 있는 3D 컬럼 차트](gap_depth_500.png) |

## **3D 시리즈 유형 및 막대 모양 변경**

클러스터 실린더 차트에서 첫 번째 시리즈는 실린더 형 막대로 시작합니다. 예제는 각 변경 전후에 [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) 및 [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/)을 읽습니다.

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

| 첫 번째 시리즈에 대한 변경 | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| 차트 생성 | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone`으로 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) 호출 | `ClusteredCone` | `Cone` |
| `Box`로 [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) 호출 | `ClusteredColumn3D` | `Box` |

`Box`로 모양을 설정하면 시리즈 유형도 `ClusteredColumn3D`로 변경됩니다. 코드에서 시리즈 유형에 따라 분기한다면, 모양을 변경한 후 `series->get_Type()`을 호출하십시오. 변경 전 캐시된 값은 여전히 `ClusteredCone` 분기를 선택하게 됩니다.

![PowerPoint 비교: 왼쪽에서 오른쪽으로 첫 번째 시리즈가 실린더, 원뿔 및 직사각형 컬럼으로 표시되는 모습](series-shapes.png)

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 컬럼 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 열거형을 통해 노출되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에서 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 멤버를 확인하십시오.

**보고서나 웹용으로 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)를 사용해 차트를 이미지로 내보내거나 [전체 슬라이드 렌더링](/slides/ko/cpp/convert-powerpoint-to-png/)을 통해 PNG 또는 JPEG와 같은 형식으로 저장할 수 있습니다. 이는 래스터 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드 또는 웹 페이지에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 생성하고 렌더링하는 성능은 어떠한가요?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 벽과 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능한 경우 시리즈당 데이터 포인트 수를 제한하고, 목표 디스플레이 또는 인쇄 요구에 맞게 해상도와 크기가 적절한 출력으로 렌더링하십시오.