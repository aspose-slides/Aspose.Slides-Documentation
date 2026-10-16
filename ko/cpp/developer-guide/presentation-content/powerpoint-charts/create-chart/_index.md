---
title: C++에서 PowerPoint 프레젠테이션 차트 만들기 또는 업데이트
linktitle: 차트 만들기 또는 업데이트
type: docs
weight: 10
url: /ko/cpp/create-chart/
aliases:
  - /cpp/update-chart/
keywords:
- 차트 추가
- 차트 만들기
- 차트 편집
- 차트 변경
- 차트 업데이트
- 산점도 차트
- 파이 차트
- 선 차트
- 트리맵 차트
- 스톡 차트
- 박스 및 수염 차트
- 퍼널 차트
- 선버스트 차트
- 히스토그램 차트
- 레이더 차트
- 다중 카테고리 차트
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 차트를 만들고 사용자 지정합니다. C++ 실용 코드 예제로 차트를 추가, 서식 지정 및 편집합니다."
---
## **개요**

이 문서는 Aspose.Slides for C++를 사용하여 차트를 만들고 사용자 지정하는 방법에 대한 포괄적인 가이드를 제공합니다. 슬라이드에 차트를 프로그래밍 방식으로 추가하고 데이터를 채우며 특정 디자인 요구 사항에 맞게 다양한 서식 옵션을 적용하는 방법을 배울 수 있습니다. 문서 전체에 걸쳐 자세한 코드 예제가 초기 프레젠테이션 및 차트 개체 초기화부터 시리즈, 축 및 범례 구성에 이르는 각 단계를 보여줍니다. 이 가이드를 따르면 C++ 애플리케이션에 동적 차트 생성을 통합하는 방법을 확실히 이해하게 되어 데이터 기반 프레젠테이션을 만드는 프로세스를 간소화할 수 있습니다.

## **차트 만들기**

차트는 사람들에게 데이터를 빠르게 시각화하고 표나 스프레드시트에서 즉시 드러나지 않을 수 있는 인사이트를 제공하는 데 도움을 줍니다.

**왜 차트를 만들까요?**

차트를 사용하면 다음을 수행할 수 있습니다:

* 프레젠테이션의 단일 슬라이드에 대량의 데이터를 집계, 압축 또는 요약합니다;
* 데이터의 패턴과 추세를 드러냅니다;
* 특정 측정 단위에 대한 시간 경과에 따른 데이터의 방향과 모멘텀을 추정합니다;
* 이상치, 변칙, 편차, 오류 및 비논리적 데이터를 식별합니다;
* 복잡한 데이터를 전달하거나 프레젠테이션합니다.

PowerPoint에서는 *삽입* 기능을 통해 다양한 차트 템플릿을 제공하여 차트를 만들 수 있습니다. Aspose.Slides를 사용하면 일반 차트(대중적인 차트 유형 기반)와 사용자 정의 차트를 모두 만들 수 있습니다.

{{% alert color="info" title="Note" %}}
[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 열거형을 [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/) 네임스페이스에서 사용합니다. 이 열거형 값은 서로 다른 차트 유형에 해당합니다.
{{% /alert %}}

### **클러스터드 열 차트 만들기**

이 예제는 [AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)을 사용하여 세 범주에 걸쳐 두 시리즈를 비교하는 클러스터드 열 차트를 만듭니다. 시리즈는 빨간색 및 초록색 채우기를 사용하고, 개별 레이블은 범주 이름, 시리즈 이름 및 값을 표시합니다. 워크시트 인덱스 0은 포함된 차트 워크북의 첫 번째 시트를 나타냅니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <drawing/color.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box(String(u"Series 1")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());
seriesNameCell = workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box(String(u"Series 2")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

auto categoryCell = workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box(String(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box(String(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box(String(u"Category 3")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto valueCell = workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box(20));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box(50));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box(30));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);

series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

series = chart->get_ChartData()->get_Series()->idx_get(1);

valueCell = workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box(30));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box(10));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box(60));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);

series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Green());

auto label = series->get_DataPoints()->idx_get(0)->get_Label();
label->get_DataLabelFormat()->set_ShowCategoryName(true);

label = series->get_DataPoints()->idx_get(1)->get_Label();
label->get_DataLabelFormat()->set_ShowSeriesName(true);

label = series->get_DataPoints()->idx_get(2)->get_Label();
label->get_DataLabelFormat()->set_ShowValue(true);
label->get_DataLabelFormat()->set_ShowSeriesName(true);
label->get_DataLabelFormat()->set_Separator(u"/");

presentation->Save(u"AsposeChart.pptx", SaveFormat::Pptx);
```

결과:

![클러스터드 열 차트](clustered_column_chart.png)

### **산점도 차트 만들기**

산점도 차트(산점도 플롯 또는 x‑y 그래프라고도 함)는 두 변수 간의 패턴을 확인하거나 상관 관계를 보여주는 데 자주 사용됩니다.

산점도 차트를 사용할 때:

* 쌍을 이루는 숫자 데이터가 있습니다.
* 두 변수가 서로 잘 맞습니다.
* 두 변수가 관련되어 있는지 확인하고자 합니다.
* 종속 변수에 대해 여러 값을 갖는 독립 변수가 있습니다.

이 예제는 두 세트의 x‑y 값을 플롯합니다. 첫 번째 시리즈는 별 마커가 있는 직선, 두 번째 시리즈는 원형 마커가 있는 곡선을 사용하며, 두 시리즈 모두 [set_Size](https://reference.aspose.com/slides/cpp/aspose.slides.charts/imarker/set_size/)으로 크기 10을 설정합니다. [set_Symbol](https://reference.aspose.com/slides/cpp/aspose.slides.charts/imarker/set_symbol/) 메서드는 마커 모양을 제어합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IMarker.h>
#include <DOM/Chart/MarkerStyleType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithSmoothLines, 20, 20, 500, 300);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Series()->Clear();

auto seriesNameCell = workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box(String(u"Series 1")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());
seriesNameCell = workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box(String(u"Series 2")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto xValueCell = workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box(1));
auto yValueCell = workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box(3));
series->get_DataPoints()->AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box(2));
yValueCell = workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box(10));
series->get_DataPoints()->AddDataPointForScatterSeries(xValueCell, yValueCell);

series->set_Type(ChartType::ScatterWithStraightLinesAndMarkers);

series->get_Marker()->set_Size(10);
series->get_Marker()->set_Symbol(MarkerStyleType::Star);

series = chart->get_ChartData()->get_Series()->idx_get(1);

xValueCell = workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box(5));
yValueCell = workbook->GetCell(worksheetIndex, 2, 4, ObjectExt::Box(2));
series->get_DataPoints()->AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box(3));
yValueCell = workbook->GetCell(worksheetIndex, 3, 4, ObjectExt::Box(1));
series->get_DataPoints()->AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook->GetCell(worksheetIndex, 4, 3, ObjectExt::Box(2));
yValueCell = workbook->GetCell(worksheetIndex, 4, 4, ObjectExt::Box(2));
series->get_DataPoints()->AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook->GetCell(worksheetIndex, 5, 3, ObjectExt::Box(5));
yValueCell = workbook->GetCell(worksheetIndex, 5, 4, ObjectExt::Box(1));
series->get_DataPoints()->AddDataPointForScatterSeries(xValueCell, yValueCell);

series->get_Marker()->set_Size(10);
series->get_Marker()->set_Symbol(MarkerStyleType::Circle);

presentation->Save(u"AsposeChart.pptx", SaveFormat::Pptx);
```

결과:

![산점도 차트](scatter_chart.png)

### **파이 차트 만들기**

파이 차트는 특히 데이터에 범주형 레이블과 숫자 값이 포함된 경우 전체 대비 부분 관계를 표시하는 데 가장 적합합니다. 그러나 데이터에 많은 부분이나 레이블이 포함된 경우 막대 차트를 고려하는 것이 좋습니다.

이 예제는 3개의 분기값을 가진 파이 차트를 만듭니다. 각 조각은 사용자 지정 채우기와 테두리를 가지고 있으며, 레이블은 값, 백분율 및 시리즈 정보를 조합해 표시합니다. [set_FirstSliceAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_firstsliceangle/) 메서드는 첫 번째 조각이 180도에서 시작하도록 설정합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <drawing/color.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IChartSeriesGroupCollection.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 20, 20, 500, 300);

chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

chart->get_ChartData()->get_Series()->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto categoryCell = workbook->GetCell(0, 1, 0, ObjectExt::Box(String(u"1st Qtr")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, 2, 0, ObjectExt::Box(String(u"2nd Qtr")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, 3, 0, ObjectExt::Box(String(u"3rd Qtr")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto seriesNameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box(String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

auto valueCell = workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box(20));
series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box(50));
series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box(30));
series->get_DataPoints()->AddDataPointForPieSeries(valueCell);

chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

auto firstSlice = series->get_DataPoints()->idx_get(0);
firstSlice->get_Format()->get_Fill()->set_FillType(FillType::Solid);
firstSlice->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Cyan());

firstSlice->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
firstSlice->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());
firstSlice->get_Format()->get_Line()->set_Width(3.0);
firstSlice->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
firstSlice->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDash);

auto secondSlice = series->get_DataPoints()->idx_get(1);
secondSlice->get_Format()->get_Fill()->set_FillType(FillType::Solid);
secondSlice->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Brown());

secondSlice->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
secondSlice->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
secondSlice->get_Format()->get_Line()->set_Width(3.0);
secondSlice->get_Format()->get_Line()->set_Style(LineStyle::Single);
secondSlice->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);

auto thirdSlice = series->get_DataPoints()->idx_get(2);
thirdSlice->get_Format()->get_Fill()->set_FillType(FillType::Solid);
thirdSlice->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Coral());

thirdSlice->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
thirdSlice->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
thirdSlice->get_Format()->get_Line()->set_Width(2.0);
thirdSlice->get_Format()->get_Line()->set_Style(LineStyle::ThinThin);
thirdSlice->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);

auto firstLabel = series->get_DataPoints()->idx_get(0)->get_Label();
firstLabel->get_DataLabelFormat()->set_ShowValue(true);

auto secondLabel = series->get_DataPoints()->idx_get(1)->get_Label();
secondLabel->get_DataLabelFormat()->set_ShowValue(true);
secondLabel->get_DataLabelFormat()->set_ShowLegendKey(true);
secondLabel->get_DataLabelFormat()->set_ShowPercentage(true);

auto thirdLabel = series->get_DataPoints()->idx_get(2)->get_Label();
thirdLabel->get_DataLabelFormat()->set_ShowSeriesName(true);
thirdLabel->get_DataLabelFormat()->set_ShowPercentage(true);

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);

presentation->Save(u"PieChart.pptx", SaveFormat::Pptx);
```

결과:

![파이 차트](pie_chart.png)

파이 차트 외부 레이블의 가독성을 높이려면 [Format Leader Lines](/slides/ko/cpp/chart-data-label/#format-leader-lines)에서 레이블 위치 지정 및 선 색상, 너비, 투명도, 대시 스타일을 사용자 지정하는 예제를 참조하십시오.

### **선 차트 만들기**

선 차트(선 그래프라고도 함)는 시간 경과에 따른 값 변화를 보여주고자 할 때 가장 적합합니다. 선 차트를 사용하면 한 번에 많은 데이터를 비교하고, 시간에 따른 변화와 추세를 추적하며, 데이터 시리즈의 이상치를 강조하는 등 다양한 작업을 수행할 수 있습니다.

이 예제는 [AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)을 사용하여 기본 시리즈와 범주가 포함된 선 차트를 만든 다음 PPTX 파일로 저장합니다.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto lineChart = slide->get_Shapes()->AddChart(ChartType::Line, 20, 20, 500, 300);

presentation->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

기본적으로 선 차트의 포인트는 직선으로 연결됩니다. 포인트를 대시로 연결하려면 [set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/)에 [LineDashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) 값 중 하나를 전달합니다.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto lineChart = slide->get_Shapes()->AddChart(ChartType::Line, 20, 20, 500, 300);

for (auto series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

결과:

![선 차트](line_chart.png)

### **트리맵 차트 만들기**

트리맵 차트는 매출 데이터에서 각 데이터 카테고리의 상대적 크기를 보여주고 각 카테고리 내에서 큰 기여도를 가진 항목에 주의를 끌고자 할 때 가장 적합합니다.

이 예제는 8개의 잎을 4개의 줄기와 2개의 가지로 그룹화한 트리맵을 만듭니다. [SetGroupingItem](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) 메서드는 레벨 1에 줄기를, 레벨 2에 가지를 할당합니다. 값은 사각형의 상대적 크기를 결정하고, 카테고리 레이블과 겹치는 상위 레이블이 계층 구조를 식별합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCategoryLevelsManager.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/ParentLabelLayoutType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Treemap, 20, 20, 500, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

// 분기 1
auto categoryCell = workbook->GetCell(0, u"C1", ObjectExt::Box(String(u"Leaf1")));
auto leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem1")));
leaf->get_GroupingLevels()->SetGroupingItem(2, ObjectExt::Box(String(u"Branch1")));

categoryCell = workbook->GetCell(0, u"C2", ObjectExt::Box(String(u"Leaf2")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

categoryCell = workbook->GetCell(0, u"C3", ObjectExt::Box(String(u"Leaf3")));
leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem2")));

categoryCell = workbook->GetCell(0, u"C4", ObjectExt::Box(String(u"Leaf4")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

// 분기 2
categoryCell = workbook->GetCell(0, u"C5", ObjectExt::Box(String(u"Leaf5")));
leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem3")));
leaf->get_GroupingLevels()->SetGroupingItem(2, ObjectExt::Box(String(u"Branch2")));

categoryCell = workbook->GetCell(0, u"C6", ObjectExt::Box(String(u"Leaf6")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

categoryCell = workbook->GetCell(0, u"C7", ObjectExt::Box(String(u"Leaf7")));
leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem4")));

categoryCell = workbook->GetCell(0, u"C8", ObjectExt::Box(String(u"Leaf8")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Treemap);
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
auto valueCell = workbook->GetCell(0, u"D1", ObjectExt::Box(4));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
valueCell = workbook->GetCell(0, u"D2", ObjectExt::Box(5));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
valueCell = workbook->GetCell(0, u"D3", ObjectExt::Box(3));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
valueCell = workbook->GetCell(0, u"D4", ObjectExt::Box(6));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
valueCell = workbook->GetCell(0, u"D5", ObjectExt::Box(9));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
valueCell = workbook->GetCell(0, u"D6", ObjectExt::Box(9));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
valueCell = workbook->GetCell(0, u"D7", ObjectExt::Box(4));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
valueCell = workbook->GetCell(0, u"D8", ObjectExt::Box(3));
series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);

series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);

presentation->Save(u"Treemap.pptx", SaveFormat::Pptx);
```

결과:

![트리맵 차트](treemap_chart.png)

### **워터폴 차트 만들기**

워터폴 차트는 양·음의 변화가 최종 값에 어떻게 기여하는지를 보여줍니다. 예를 들어, 수익에서 시작해 비용을 차감하고 기타 수입을 더하는 방식으로 이익을 분류할 수 있습니다. 변화 열은 이전 값과 새로운 진행 값 사이를 연결하고, 총합 열은 0에서 누적 값까지 확장됩니다.

다음 예제는 미국 달러 천 단위 금액을 사용합니다:

| 카테고리 | 워크북 값 | 열 유형 |
| --- | ---: | --- |
| Revenue | 1000 | 증가 |
| Cost of sales | -400 | 감소 |
| Gross profit | 600 | 중간 합계 |
| Operating expenses | -200 | 감소 |
| Other income | 50 | 증가 |
| Net profit | 450 | 최종 합계 |

중간 또는 최종 합계 포인트를 표시하려면 해당 포인트의 [set_SetAsTotal](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdatapoint/set_setastotal/) 메서드에 `true`를 전달합니다. 워크북 셀에 실제 누적 금액을 제공해야 합니다: 총이익은 `600` (`1000 - 400`), 순이익은 `450` (`600 - 200 + 50`). 이 메서드는 열을 합계로 표시하지만 셀 값을 계산하거나 채우지는 않습니다. 0을 자리 표시자로 사용하거나 합계 포인트에 다른 변화를 제공하지 마십시오. 총합 열은 누적 값을 표시하지만 진행 값에 다시 더하지는 않습니다.

이 전체 C++ 예제는 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)의 `Waterfall` 멤버를 사용해 차트를 만들고, 기본 데이터를 지운 뒤 포함된 워크북을 채웁니다. 워크시트 인덱스 `0`은 첫 번째 워크시트를 선택하고, A 열에 카테고리 이름을, B 열에 값을 넣습니다. 각 값 셀은 [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/)로 추가합니다. 0‑based 포인트 인덱스 `2`와 `5`가 각각 중간 및 최종 합계를 식별합니다. [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/)에 `true`를 전달하면 값이 열에 표시됩니다. 입력 프레젠테이션이나 워크북은 필요하지 않습니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/array.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Waterfall, 20, 20, 680, 200);

chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Profit breakdown (USD thousands)");
chart->get_ChartTitle()->set_Overlay(false);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

workbook->Clear(worksheetIndex);

auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box(String(u"Profit")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::Waterfall);
auto categories = MakeArray<String>({ u"Revenue", u"Cost of sales", u"Gross profit", u"Operating expenses", u"Other income", u"Net profit" });
auto values = MakeArray<double>({ 1000, -400, 600, -200, 50, 450 });

for (auto i = 0; i < categories->get_Length(); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, ObjectExt::Box(categories->idx_get(i)));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, ObjectExt::Box(values->idx_get(i)));
    series->get_DataPoints()->AddDataPointForWaterfallSeries(valueCell);
}

// 세 번째와 여섯 번째 포인트는 총계이며, 추가 변동이 아닙니다.
series->get_DataPoints()->idx_get(2)->set_SetAsTotal(true);
series->get_DataPoints()->idx_get(5)->set_SetAsTotal(true);
series->set_ShowConnectorLines(true);
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"WaterfallChart.pptx", SaveFormat::Pptx);
```

시리즈 수준의 [set_ShowConnectorLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseries/set_showconnectorlines/) 메서드에 `true`를 전달하면 연속 열을 연결하는 선이 표시되어 진행 값을 파악하기 쉬워집니다. 이 선을 숨기려면 예제에서 저장하기 전에 `series->set_ShowConnectorLines(false);` 로 교체하면 됩니다. 이는 선 가시성만 변경하고 데이터나 합계에는 영향을 주지 않습니다.

저장된 프레젠테이션에는 600의 총이익과 450의 순이익이 0에서 시작해 그려집니다:

![워터폴 차트(수익, 비용, 총이익 600, 순이익 450, 값 레이블 및 연결선 포함)](waterfall_chart.png)

### **스톡 차트 만들기**

스톡 차트는 시가, 고가, 저가, 종가와 같은 금융 데이터를 표시하여 시장 추세와 변동성을 분석하는 데 도움을 줍니다. 이러한 차트는 주식 성과에 대한 핵심 인사이트를 제공하여 투자자와 분석가가 정보에 입각한 결정을 내릴 수 있도록 합니다.

이 예제는 순서대로 네 개의 시리즈와 세 개의 카테고리를 가진 OHLC(시가‑고가‑저가‑종가) 차트를 만들고, [set_HasUpDownBars](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iupdownbarsmanager/set_hasupdownbars/) 메서드로 상승/하락 막대를 활성화하며, [get_HiLowLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/get_hilowlinesformat/)으로 가격 범위를 나타내는 고저 라인을 제어합니다. 개별 시리즈 라인과 작은 수평 격자선은 숨겨집니다.

```cpp
#include <DOM/Chart/IChartLinesFormat.h>
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IChartSeriesGroupCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IUpDownBarsManager.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::OpenHighLowClose, 20, 20, 500, 300, false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

auto categoryCell = workbook->GetCell(0, 1, 0, ObjectExt::Box(String(u"A")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, 2, 0, ObjectExt::Box(String(u"B")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, 3, 0, ObjectExt::Box(String(u"C")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto seriesNameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box(String(u"Open")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::OpenHighLowClose);
seriesNameCell = workbook->GetCell(0, 0, 2, ObjectExt::Box(String(u"High")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::OpenHighLowClose);
seriesNameCell = workbook->GetCell(0, 0, 3, ObjectExt::Box(String(u"Low")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::OpenHighLowClose);
seriesNameCell = workbook->GetCell(0, 0, 4, ObjectExt::Box(String(u"Close")));
chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::OpenHighLowClose);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto valueCell = workbook->GetCell(0, 1, 1, ObjectExt::Box(72));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 2, 1, ObjectExt::Box(25));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 3, 1, ObjectExt::Box(38));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);

series = chart->get_ChartData()->get_Series()->idx_get(1);
valueCell = workbook->GetCell(0, 1, 2, ObjectExt::Box(172));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 2, 2, ObjectExt::Box(57));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 3, 2, ObjectExt::Box(57));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);

series = chart->get_ChartData()->get_Series()->idx_get(2);
valueCell = workbook->GetCell(0, 1, 3, ObjectExt::Box(12));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 2, 3, ObjectExt::Box(12));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 3, 3, ObjectExt::Box(13));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);

series = chart->get_ChartData()->get_Series()->idx_get(3);
valueCell = workbook->GetCell(0, 1, 4, ObjectExt::Box(25));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 2, 4, ObjectExt::Box(38));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);
valueCell = workbook->GetCell(0, 3, 4, ObjectExt::Box(50));
series->get_DataPoints()->AddDataPointForStockSeries(valueCell);

chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars(true);
chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);

for (auto stockSeries : chart->get_ChartData()->get_Series())
{
    stockSeries->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
}

chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

presentation->Save(u"Stock-chart.pptx", SaveFormat::Pptx);
```

결과:

![스톡 차트](stock_chart.png)

### **박스 및 수염 차트 만들기**

박스 및 수염 차트는 중앙값, 사분위수, 잠재적 이상치와 같은 핵심 통계 측정값을 요약하여 데이터 분포를 표시하는 데 사용됩니다. 탐색적 데이터 분석 및 통계 연구에서 데이터 변동성을 빠르게 파악하고 이상치를 식별하는 데 특히 유용합니다.

이 예제는 여섯 개 값으로 박스 및 수염 차트를 만들며, [set_QuartileMethod](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_quartilemethod/) 메서드로 독점 사분위 계산을 선택합니다. 또한 평균선, 평균 마커, 내부 포인트 및 이상치 포인트를 활성화합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IMarker.h>
#include <DOM/Chart/QuartileMethodType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::BoxAndWhisker, 20, 20, 500, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A1", ObjectExt::Box(String(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box(String(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A3", ObjectExt::Box(String(u"Category 3")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A4", ObjectExt::Box(String(u"Category 4")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A5", ObjectExt::Box(String(u"Category 5")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A6", ObjectExt::Box(String(u"Category 6")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::BoxAndWhisker);

series->set_QuartileMethod(QuartileMethodType::Exclusive);
series->set_ShowMeanLine(true);
series->set_ShowMeanMarkers(true);
series->set_ShowInnerPoints(true);
series->set_ShowOutlierPoints(true);

auto valueCell = workbook->GetCell(0, u"B1", ObjectExt::Box(15));
series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook->GetCell(0, u"B2", ObjectExt::Box(41));
series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook->GetCell(0, u"B3", ObjectExt::Box(16));
series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook->GetCell(0, u"B4", ObjectExt::Box(10));
series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook->GetCell(0, u"B5", ObjectExt::Box(23));
series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook->GetCell(0, u"B6", ObjectExt::Box(16));
series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation->Save(u"BoxAndWhisker.pptx", SaveFormat::Pptx);
```

### **퍼널 차트 만들기**

퍼널 차트는 단계별로 진행될수록 데이터 양이 감소하는 프로세스를 시각화하는 데 사용됩니다. 전환율 분석, 병목 현상 식별, 영업 또는 마케팅 프로세스의 효율성 추적에 특히 도움이 됩니다.

이 예제는 [AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)을 사용해 기존 프레젠테이션의 첫 번째 슬라이드에 퍼널 차트를 추가하고, 기본 데이터를 6개의 카테고리와 50~500 사이의 값으로 교체한 뒤 업데이트된 프레젠테이션을 저장합니다. 입력 프레젠테이션에는 최소 하나의 슬라이드가 있어야 합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Funnel, 50, 50, 500, 400);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A1", ObjectExt::Box(String(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box(String(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A3", ObjectExt::Box(String(u"Category 3")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A4", ObjectExt::Box(String(u"Category 4")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A5", ObjectExt::Box(String(u"Category 5")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
categoryCell = workbook->GetCell(0, u"A6", ObjectExt::Box(String(u"Category 6")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Funnel);

auto valueCell = workbook->GetCell(0, u"B1", ObjectExt::Box(50));
series->get_DataPoints()->AddDataPointForFunnelSeries(valueCell);
valueCell = workbook->GetCell(0, u"B2", ObjectExt::Box(100));
series->get_DataPoints()->AddDataPointForFunnelSeries(valueCell);
valueCell = workbook->GetCell(0, u"B3", ObjectExt::Box(200));
series->get_DataPoints()->AddDataPointForFunnelSeries(valueCell);
valueCell = workbook->GetCell(0, u"B4", ObjectExt::Box(300));
series->get_DataPoints()->AddDataPointForFunnelSeries(valueCell);
valueCell = workbook->GetCell(0, u"B5", ObjectExt::Box(400));
series->get_DataPoints()->AddDataPointForFunnelSeries(valueCell);
valueCell = workbook->GetCell(0, u"B6", ObjectExt::Box(500));
series->get_DataPoints()->AddDataPointForFunnelSeries(valueCell);

presentation->Save(u"Funnel.pptx", SaveFormat::Pptx);
```

결과:

![퍼널 차트](funnel_chart.png)

### **선버스트 차트 만들기**

선버스트 차트는 계층적 데이터를 원형의 동심원으로 표시하여 부분‑전체 관계를 시각화합니다. 중첩된 카테고리와 하위 카테고리를 명확하고 압축된 형식으로 나타내는 데 이상적입니다.

이 예제는 8개의 잎을 4개의 줄기와 2개의 가지로 그룹화한 선버스트 차트를 만들고, [SetGroupingItem](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) 메서드로 레벨 1에 줄기, 레벨 2에 가지를 할당합니다. 카테고리 레이블이 구획을 식별하고, 값이 상대적 크기를 결정합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCategoryLevelsManager.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Sunburst, 20, 20, 500, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

// 분기 1
auto categoryCell = workbook->GetCell(0, u"C1", ObjectExt::Box(String(u"Leaf1")));
auto leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem1")));
leaf->get_GroupingLevels()->SetGroupingItem(2, ObjectExt::Box(String(u"Branch1")));

categoryCell = workbook->GetCell(0, u"C2", ObjectExt::Box(String(u"Leaf2")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

categoryCell = workbook->GetCell(0, u"C3", ObjectExt::Box(String(u"Leaf3")));
leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem2")));

categoryCell = workbook->GetCell(0, u"C4", ObjectExt::Box(String(u"Leaf4")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

// 분기 2
categoryCell = workbook->GetCell(0, u"C5", ObjectExt::Box(String(u"Leaf5")));
leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem3")));
leaf->get_GroupingLevels()->SetGroupingItem(2, ObjectExt::Box(String(u"Branch2")));

categoryCell = workbook->GetCell(0, u"C6", ObjectExt::Box(String(u"Leaf6")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

categoryCell = workbook->GetCell(0, u"C7", ObjectExt::Box(String(u"Leaf7")));
leaf = chart->get_ChartData()->get_Categories()->Add(categoryCell);
leaf->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Stem4")));

categoryCell = workbook->GetCell(0, u"C8", ObjectExt::Box(String(u"Leaf8")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Sunburst);
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
auto valueCell = workbook->GetCell(0, u"D1", ObjectExt::Box(4));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
valueCell = workbook->GetCell(0, u"D2", ObjectExt::Box(5));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
valueCell = workbook->GetCell(0, u"D3", ObjectExt::Box(3));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
valueCell = workbook->GetCell(0, u"D4", ObjectExt::Box(6));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
valueCell = workbook->GetCell(0, u"D5", ObjectExt::Box(9));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
valueCell = workbook->GetCell(0, u"D6", ObjectExt::Box(9));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
valueCell = workbook->GetCell(0, u"D7", ObjectExt::Box(4));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
valueCell = workbook->GetCell(0, u"D8", ObjectExt::Box(3));
series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);

presentation->Save(u"Sunburst.pptx", SaveFormat::Pptx);
```

결과:

![선버스트 차트](sunburst_chart.png)

### **히스토그램 차트 만들기**

히스토그램 차트는 수치 값을 구간(빈)으로 나누어 분포를 표시합니다. 주문 처리 시간과 같은 월별 보고서에서는 동일한 구간 너비와 임계값을 사용해 구간을 일관되게 유지하고 분포를 비교하기 쉽게 합니다.

수평 축에 [set_AggregationType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_aggregationtype/) 메서드와 [AxisAggregationType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axisaggregationtype/) 중 하나를 지정합니다. `ByBinWidth`에만 적용되는 [set_BinWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_binwidth/)와 `ByNumberOfBins`에만 적용되는 [set_NumberOfBins](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberofbins/)을 사용합니다. `Automatic`을 지정하면 차트가 자동으로 빈을 선택합니다.

#### **고정 구간 너비 사용**

이 예제는 10분 구간으로 처리 시간을 그룹화하고, 10분 이하와 40분 초과에 대한 별도 빈을 제공합니다. [set_IsUnderflowBin](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isunderflowbin/) 및 [set_IsOverflowBin](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isoverflowbin/)으로 이러한 빈을 활성화합니다. 명시적 임계값을 제공하려면 [set_UnderflowBin](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_underflowbin/) 및 [set_OverflowBin](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_overflowbin/)을 사용하고, [set_IsAutomaticUnderflowBin](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticunderflowbin/) 및 [set_IsAutomaticOverflowBin](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticoverflowbin/)에 `false`를 전달합니다.

```cpp
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/AxisAggregationType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Histogram, 20, 20, 680, 200);

chart->set_HasLegend(false);
chart->set_HasTitle(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Histogram);
auto values = MakeArray<double>({ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 });
for (auto i = 0; i < values->get_Length(); i++)
{
    auto valueCell = workbook->GetCell(0, i, 0, ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForHistogramSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_AggregationType(AxisAggregationType::ByBinWidth);
axis->set_BinWidth(10);
axis->set_IsUnderflowBin(true);
axis->set_IsAutomaticUnderflowBin(false);
axis->set_UnderflowBin(10);
axis->set_IsOverflowBin(true);
axis->set_IsAutomaticOverflowBin(false);
axis->set_OverflowBin(40);

presentation->Save(u"Histogram-bin-width.pptx", SaveFormat::Pptx);
```

PowerPoint에서 표시되는 프레젠테이션은 **3, 4, 4, 4, 2**의 빈 개수를 보여줍니다. 언더플로 빈은 `5, 10, 10`을 포함하므로 임계값이 포함적이며, 오버플로 빈은 `41, 50`만 포함하므로 임계값이 배타적입니다; 값 `40`은 앞선 구간에 남습니다. 내부 빈은 하한보다 크고 상한보다 작거나 같은 값을 포함합니다.

![10분 구간 및 명시적 언더플로·오버플로 임계값을 적용한 히스토그램](histogram_bin_width.png)

#### **구간 수 지정**

고정 구간 대신 고정 세부 수준을 원한다면 동일한 데이터에 대해 5개의 구간을 요청합니다. 이 예제는 언더플로·오버플로 빈을 비활성화합니다. 차트는 데이터 범위에서 너비를 계산하므로 보고서마다 구간 경계가 달라질 수 있습니다.

```cpp
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/AxisAggregationType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Histogram, 20, 20, 680, 200);

chart->set_HasLegend(false);
chart->set_HasTitle(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Histogram);
auto values = MakeArray<double>({ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 });
for (auto i = 0; i < values->get_Length(); i++)
{
    auto valueCell = workbook->GetCell(0, i, 0, ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForHistogramSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_AggregationType(AxisAggregationType::ByNumberOfBins);
axis->set_NumberOfBins(5);

presentation->Save(u"Histogram-bin-count.pptx", SaveFormat::Pptx);
```

다섯 구간의 개수는 **4, 4, 4, 4, 1**입니다. 위의 고정 너비 결과와 비교해 보시면 입력값은 동일하지만 경계가 다릅니다.

![동일 데이터에서 계산된 5개 구간 히스토그램](histogram_bin_count.png)

### **레이더 차트 만들기**

레이더 차트는 다변량 데이터를 2차원 형식으로 표시하여 여러 변수를 동시에 쉽게 비교할 수 있게 합니다. 여러 성능 지표나 특성에 대한 패턴, 강점, 약점을 식별하는 데 특히 유용합니다.

이 예제는 [AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)을 사용해 기본 시리즈와 범주를 가진 레이더 차트를 만든 뒤 PPTX 파일로 저장합니다.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddChart(ChartType::Radar, 20, 20, 500, 300);

presentation->Save(u"Radar-chart.pptx", SaveFormat::Pptx);
```

결과:

![레이더 차트](radar_chart.png)

### **다중 카테고리 차트 만들기**

다중 카테고리 차트는 하나 이상의 카테고리 그룹이 포함된 데이터를 표시해 여러 차원에서 값을 비교할 수 있게 합니다. 복잡하고 다층적인 데이터세트에서 추세와 관계를 분석할 때 특히 도움이 됩니다.

이 예제는 4쌍으로 배열된 8개의 카테고리를 가진 클러스터드 열 차트를 만들고, [SetGroupingItem](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) 메서드로 각 쌍에 레벨 1에서 공유 레이블을 부여해 개별 레이블과 그룹 레이블이 모두 표시되는 카테고리 축을 생성합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCategoryLevelsManager.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto worksheetIndex = 0;

auto categoryCell = workbook->GetCell(0, u"c2", ObjectExt::Box(String(u"A")));
auto category = chart->get_ChartData()->get_Categories()->Add(categoryCell);
category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Group1")));
categoryCell = workbook->GetCell(0, u"c3", ObjectExt::Box(String(u"B")));
category = chart->get_ChartData()->get_Categories()->Add(categoryCell);

categoryCell = workbook->GetCell(0, u"c4", ObjectExt::Box(String(u"C")));
category = chart->get_ChartData()->get_Categories()->Add(categoryCell);
category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Group2")));
categoryCell = workbook->GetCell(0, u"c5", ObjectExt::Box(String(u"D")));
category = chart->get_ChartData()->get_Categories()->Add(categoryCell);

categoryCell = workbook->GetCell(0, u"c6", ObjectExt::Box(String(u"E")));
category = chart->get_ChartData()->get_Categories()->Add(categoryCell);
category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Group3")));
categoryCell = workbook->GetCell(0, u"c7", ObjectExt::Box(String(u"F")));
category = chart->get_ChartData()->get_Categories()->Add(categoryCell);

categoryCell = workbook->GetCell(0, u"c8", ObjectExt::Box(String(u"G")));
category = chart->get_ChartData()->get_Categories()->Add(categoryCell);
category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box(String(u"Group4")));
categoryCell = workbook->GetCell(0, u"c9", ObjectExt::Box(String(u"H")));
category = chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto seriesNameCell = workbook->GetCell(0, u"D1", ObjectExt::Box(String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::ClusteredColumn);

auto valueCell = workbook->GetCell(worksheetIndex, u"D2", ObjectExt::Box(10));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, u"D3", ObjectExt::Box(20));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, u"D4", ObjectExt::Box(30));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, u"D5", ObjectExt::Box(40));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, u"D6", ObjectExt::Box(50));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, u"D7", ObjectExt::Box(60));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, u"D8", ObjectExt::Box(70));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
valueCell = workbook->GetCell(worksheetIndex, u"D9", ObjectExt::Box(80));
series->get_DataPoints()->AddDataPointForBarSeries(valueCell);

presentation->Save(u"AsposeChart.pptx", SaveFormat::Pptx);
```

결과:

![다중 카테고리 차트](multi_category_chart.png)

### **지도 차트 만들기**

지도 차트는 국가, 주, 도시와 같은 특정 위치에 정보를 매핑해 지리 데이터를 시각화합니다. 지역 트렌드, 인구 통계 데이터 및 공간 분포를 명확하고 시각적으로 매력적인 방식으로 분석하는 데 특히 유용합니다.

이 예제는 [AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)을 사용해 기본 지리 데이터를 가진 지도 차트를 만든 뒤 PowerPoint에서 확인할 수 있도록 저장합니다.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 20, 20, 500, 300);

presentation->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

결과:

![지도 차트](map_chart.png)

{{% alert color="info" title="Note" %}}
위 그림은 PowerPoint에서 열어 본 저장된 프레젠테이션을 보여줍니다. Aspose.Slides는 지도 차트와 데이터를 올바르게 기록하지만 자체적으로 지도 차트를 그리지는 않습니다. 슬라이드가 이미지로 렌더링되거나 PDF 또는 SVG로 변환될 때 차트 영역이 비어 있게 됩니다. 동일 슬라이드의 다른 도형은 영향을 받지 않습니다.
{{% /alert %}}

### **조합 차트 만들기**

조합 차트(또는 콤보 차트)는 하나의 그래프에 두 개 이상의 차트 유형을 결합합니다. 이 차트를 사용하면 두 개 이상의 데이터 세트를 강조, 비교 또는 차이를 검사하여 관계를 파악할 수 있습니다.

![조합 차트](combination_chart.png)

이 예제는 네 개의 카테고리에 걸쳐 두 개의 클러스터드 열 시리즈와 한 개의 선 시리즈를 결합합니다. 열은 기본 수직 축을 사용하고, [set_PlotOnSecondAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_plotonsecondaxis/)는 선을 오른쪽에 있는 보조 수직 축에 배치합니다. 도우미 함수가 제목, 범례, 축 레이블 및 격자선을 구성합니다.

```cpp
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IAxisFormat.h>
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <drawing/color.h>
#include <DOM/Chart/AxisPositionType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IChartSeriesGroupCollection.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/LegendPositionType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

struct ComboChartExample
{
    static void CreateComboChart()
    {
        auto presentation = MakeObject<Presentation>();
        auto chart = CreateChartWithFirstSeries(presentation->get_Slide(0));

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation->Save(u"combo-chart.pptx", SaveFormat::Pptx);
    }

    static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
    {
        auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

        chart->set_HasTitle(true);
        chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
        chart->get_ChartTitle()->set_Overlay(false);
        auto portionFormat = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
        portionFormat->set_FontBold(NullableBool::False);
        portionFormat->set_FontHeight(18.0f);

        chart->get_Legend()->set_Position(LegendPositionType::Bottom);
        chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0f);

        chart->get_ChartData()->get_Series()->Clear();
        chart->get_ChartData()->get_Categories()->Clear();

        auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
        auto worksheetIndex = 0;

        auto categoryCell = workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box(String(u"Category 1")));
        chart->get_ChartData()->get_Categories()->Add(categoryCell);
        categoryCell = workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box(String(u"Category 2")));
        chart->get_ChartData()->get_Categories()->Add(categoryCell);
        categoryCell = workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box(String(u"Category 3")));
        chart->get_ChartData()->get_Categories()->Add(categoryCell);
        categoryCell = workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box(String(u"Category 4")));
        chart->get_ChartData()->get_Categories()->Add(categoryCell);

        auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box(String(u"Series 1")));
        auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

        series->get_ParentSeriesGroup()->set_Overlap(-25);
        series->get_ParentSeriesGroup()->set_GapWidth(220);

        auto valueCell = workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box(4.3));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box(2.5));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box(3.5));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box(4.5));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);

        return chart;
    }

    static void AddSecondSeriesToChart(SharedPtr<IChart> chart)
    {
        auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
        const int worksheetIndex = 0;

        auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box(String(u"Series 2")));
        auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::ClusteredColumn);

        series->get_ParentSeriesGroup()->set_Overlap(-25);
        series->get_ParentSeriesGroup()->set_GapWidth(220);

        auto valueCell = workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box(2.4));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box(4.4));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box(1.8));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 4, 2, ObjectExt::Box(2.8));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    static void AddThirdSeriesToChart(SharedPtr<IChart> chart)
    {
        auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
        const int worksheetIndex = 0;

        auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, ObjectExt::Box(String(u"Series 3")));
        auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::Line);

        auto valueCell = workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box(2.0));
        series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box(2.0));
        series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box(3.0));
        series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 4, 3, ObjectExt::Box(5.0));
        series->get_DataPoints()->AddDataPointForLineSeries(valueCell);

        series->set_PlotOnSecondAxis(true);
    }

    static void SetPrimaryAxesFormat(SharedPtr<IChart> chart)
    {
        auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
        horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0f);
        horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

        SetAxisTitle(horizontalAxis, u"X Axis");

        auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
        verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0f);
        verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

        SetAxisTitle(verticalAxis, u"Y Axis 1");

        auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
        majorGridLinesFormat->set_FillType(FillType::Solid);
        majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
    }

    static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
    {
        auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
        secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
        secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
        secondaryHorizontalAxis->set_IsVisible(false);
        secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
        secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

        auto secondaryVerticalAxis = chart->get_Axes()->get_SecondaryVerticalAxis();
        secondaryVerticalAxis->set_Position(AxisPositionType::Right);
        secondaryVerticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0f);
        secondaryVerticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
        secondaryVerticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
        secondaryVerticalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

        SetAxisTitle(secondaryVerticalAxis, u"Y Axis 2");
    }

    static void SetAxisTitle(SharedPtr<IAxis> axis, String axisTitle)
    {
        axis->set_HasTitle(true);
        axis->get_Title()->set_Overlay(false);
        auto titlePortionFormat = axis->get_Title()->AddTextFrameForOverriding(axisTitle)->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
        titlePortionFormat->set_FontBold(NullableBool::False);
        titlePortionFormat->set_FontHeight(12.0f);
    }
};

ComboChartExample::CreateComboChart();
```

## **차트 업데이트**

Aspose.Slides for C++를 사용하면 차트 데이터를 수정하고 서식 및 스타일을 변경하여 PowerPoint 차트를 업데이트할 수 있습니다. 이 기능을 통해 프레젠테이션을 동적 콘텐츠와 함께 최신 상태로 유지하고 차트가 현재 데이터와 시각적 표준을 정확히 반영하도록 할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 있는 "My chart"라는 차트를 업데이트합니다. 각 시리즈에 세 개의 데이터 포인트가 포함된 두 개의 열 시리즈가 필요하며, 카테고리 레이블은 A 열에, 시리즈 이름은 첫 번째 워크시트의 첫 번째 행에 있습니다. 예제는 [GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/)을 사용해 워크북 셀을 변경하고, 시리즈 값을 업데이트하며, 세 번째 시리즈를 추가하고, [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_type/)을 통해 차트를 클러스터드 실린더 형태로 전환합니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

const String chartName = u"My chart";

auto presentation = MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : slide->get_Shapes())
{
    auto chart = System::DynamicCast<IChart>(shape);
    if (chart != nullptr && chart->get_Name() == chartName)
    {
        auto worksheetIndex = 0;

        auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

        workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box(String(u"Modified Category 1")));
        workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box(String(u"Modified Category 2")));

        auto series = chart->get_ChartData()->get_Series()->idx_get(0);

        workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box(String(u"New_Series 1")));
        series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(ObjectExt::Box(90));
        series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(ObjectExt::Box(123));
        series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(ObjectExt::Box(44));

        series = chart->get_ChartData()->get_Series()->idx_get(1);

        workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box(String(u"New_Series 2")));
        series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(ObjectExt::Box(23));
        series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(ObjectExt::Box(67));
        series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(ObjectExt::Box(99));

        auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, ObjectExt::Box(String(u"Series 3")));
        series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

        auto valueCell = workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box(20));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box(50));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
        valueCell = workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box(30));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);

        chart->set_Type(ChartType::ClusteredCylinder);
    }
}

presentation->Save(u"AsposeChartModified.pptx", SaveFormat::Pptx);
```

## **차트의 데이터 범위 설정**

기존 차트가 이미 사용하고 있는 범위를 확인하려면 [Retrieve a Chart's Data Range](/slides/ko/cpp/chart-workbook/#retrieve-a-charts-data-range) 문서를 참조하십시오.

Aspose.Slides for C++는 워크시트의 특정 데이터 범위를 차트 데이터 소스로 정의할 수 있는 유연성을 제공합니다. 이를 통해 워크시트의 일부 영역을 차트에 직접 매핑하여 어떤 셀이 차트 시리즈와 카테고리에 기여하는지 제어할 수 있습니다. 결과적으로 워크시트의 최신 데이터 변경 사항을 차트에 쉽게 반영하고 동기화하여 PowerPoint 프레젠테이션이 현재 정확한 정보를 반영하도록 할 수 있습니다.

이 예제는 [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/)을 사용해 기존 프레젠테이션의 첫 번째 슬라이드에 있는 "My chart" 차트의 데이터 소스를 `Sheet1!A1:B4`로 설정합니다. 차트 워크북에 해당 워크시트가 포함되어 있고, 첫 번째 행에 시리즈 헤더, A 열에 카테고리 레이블, B 열에 세 개의 값을 포함하는 범위가 채워져 있어야 합니다.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

const String chartName = u"My chart";

auto presentation = MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : slide->get_Shapes())
{
    auto chart = System::DynamicCast<IChart>(shape);
    if (chart != nullptr && chart->get_Name() == chartName)
    {
        chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
    }
}

presentation->Save(u"SetDataRange.pptx", SaveFormat::Pptx);
```

## **차트에서 기본 마커 사용**

차트에서 기본 마커를 사용하면 각 차트 시리즈에 자동으로 서로 다른 기본 마커 기호가 할당됩니다.

이 예제는 [AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/)을 사용해 두 개의 선 시리즈와 범례가 포함된 차트를 만들고, [get_Marker](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_marker/) 설정이 자동 할당된 마커 기호를 유지하도록 합니다. 첫 번째 시리즈는 음수 값과 `nullptr`로 표시된 누락 값을 포함하고, 두 번째 시리즈는 모든 카테고리에 값을 갖습니다.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IMarker.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10, 10, 400, 400);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

auto seriesNameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box(String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

auto categoryCell = workbook->GetCell(0, 1, 0, ObjectExt::Box(String(u"C1")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
auto valueCell = workbook->GetCell(0, 1, 1, ObjectExt::Box(24));
series->get_DataPoints()->AddDataPointForLineSeries(valueCell);

categoryCell = workbook->GetCell(0, 2, 0, ObjectExt::Box(String(u"C2")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
valueCell = workbook->GetCell(0, 2, 1, ObjectExt::Box(23));
series->get_DataPoints()->AddDataPointForLineSeries(valueCell);

categoryCell = workbook->GetCell(0, 3, 0, ObjectExt::Box(String(u"C3")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
valueCell = workbook->GetCell(0, 3, 1, ObjectExt::Box(-10));
series->get_DataPoints()->AddDataPointForLineSeries(valueCell);

categoryCell = workbook->GetCell(0, 4, 0, ObjectExt::Box(String(u"C4")));
chart->get_ChartData()->get_Categories()->Add(categoryCell);
valueCell = workbook->GetCell(0, 4, 1, nullptr);
series->get_DataPoints()->AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook->GetCell(0, 0, 2, ObjectExt::Box(String(u"Series 2")));
auto secondSeries = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

valueCell = workbook->GetCell(0, 1, 2, ObjectExt::Box(30));
secondSeries->get_DataPoints()->AddDataPointForLineSeries(valueCell);
valueCell = workbook->GetCell(0, 2, 2, ObjectExt::Box(10));
secondSeries->get_DataPoints()->AddDataPointForLineSeries(valueCell);
valueCell = workbook->GetCell(0, 3, 2, ObjectExt::Box(60));
secondSeries->get_DataPoints()->AddDataPointForLineSeries(valueCell);
valueCell = workbook->GetCell(0, 4, 2, ObjectExt::Box(40));
secondSeries->get_DataPoints()->AddDataPointForLineSeries(valueCell);

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

presentation->Save(u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides for C++에서 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides for C++는 막대, 선, 파이, 영역, 산점도, 히스토그램, 레이더 등 다양한 차트 유형을 지원합니다. 이를 통해 데이터 시각화 요구에 가장 적합한 차트 유형을 선택할 수 있습니다.

**슬라이드에 새 차트를 어떻게 추가합니까?**

차트를 추가하려면 먼저 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation) 클래스를 인스턴스화하고 인덱스로 원하는 슬라이드를 가져온 다음 차트 유형과 초기 데이터를 지정해 차트를 추가하는 메서드를 호출하면 됩니다. 이 과정으로 차트가 프레젠테이션에 직접 통합됩니다.

**차트에 표시되는 데이터를 어떻게 업데이트합니까?**

차트의 [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/)에 접근해 기본 시리즈와 범주를 지우고 사용자 지정 데이터를 추가하면 차트 데이터를 업데이트할 수 있습니다. 이를 통해 최신 데이터를 반영하도록 차트를 프로그래밍 방식으로 새로 고칠 수 있습니다.

**차트의 모양을 사용자 지정할 수 있습니까?**

예, Aspose.Slides for C++는 색상, 글꼴, 레이블, 범례 및 기타 서식 요소를 수정해 차트 모양을 특정 디자인 요구 사항에 맞게 조정할 수 있는 광범위한 사용자 지정 옵션을 제공합니다.