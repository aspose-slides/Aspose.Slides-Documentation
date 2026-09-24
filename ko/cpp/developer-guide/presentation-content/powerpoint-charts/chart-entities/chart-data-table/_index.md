---
title: C++를 사용하여 프레젠테이션의 차트 데이터 테이블 사용자 지정
linktitle: 데이터 테이블
type: docs
url: /ko/cpp/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 글꼴 속성
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 차트 데이터 테이블의 글꼴, 테두리 및 범례 키를 사용자 지정합니다."
---
## **개요**

Aspose.Slides for C++를 사용하면 차트의 데이터 테이블을 표시하고 텍스트 서식, 테두리, 범례 키를 사용자 지정할 수 있습니다. 이 문서에서는 테이블을 활성화하고 텍스트를 서식 지정하며 각 테두리 유형을 제어하고 범례 키를 표시하거나 숨기는 방법을 설명합니다. 예제는 구성된 차트를 PPTX 파일로 저장합니다.

## **글꼴 속성 설정**

차트의 데이터 테이블을 표시하려면 `true`를 [IChart::set_HasDataTable](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/set_hasdatatable/)에 전달합니다. 테이블에 액세스하고 텍스트 서식을 구성하려면 [IChart::get_ChartDataTable](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/get_chartdatatable/)를 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
1. 첫 번째 슬라이드에 클러스터형 세로 막대 차트를 추가합니다.
1. 차트의 데이터 테이블을 활성화합니다.
1. [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_fontbold/)으로 굵은 텍스트를 사용하고 `20`을 [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_fontheight/)에 전달하여 20포인트 텍스트를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 예제는 작업 디렉터리에 최소 하나의 슬라이드가 포함된 `test.pptx`가 있어야 합니다. 위치 (50, 50)에 너비 600포인트, 높이 400포인트인 기본 데이터 차트를 추가합니다. 저장된 `output.pptx`에는 데이터 테이블이 활성화되고 지정된 글꼴 설정이 적용된 차트가 포함됩니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **데이터 테이블 테두리 사용자 지정**

[IChart::set_HasDataTable](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/set_hasdatatable/)으로 테이블을 활성화하고 [IChart::get_ChartDataTable](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/get_chartdatatable/)를 통해 접근합니다. 세 가지 테두리 유형을 개별적으로 제어할 수 있습니다.

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/)은 가로 셀 테두리를 제어합니다.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/)은 세로 셀 테두리를 제어합니다.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/)은 테이블 외곽 테두리를 제어합니다.

각 세터에 `true`를 전달하면 테두리를 표시하고 `false`를 전달하면 숨깁니다. 다음 예제는 기본 데이터가 있는 클러스터형 세로 막대 차트를 만들고, 가로 테두리와 외곽 테두리를 표시하며, 세로 테두리를 숨깁니다. 입력 파일이 필요 없으며 차트 위치와 크기는 포인트 단위로 지정됩니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

아래 비교는 네 경우 모두 동일한 차트 데이터와 범례 키 설정을 사용합니다. 모든 테두리를 활성화한 상태에서 각각 하나의 테두리만 비활성화한 변형을 보여 줍니다. 왼쪽 아래 변형이 예제의 테두리 설정과 일치합니다.

![모든 테두리가 활성화된 차트 데이터 테이블, 가로 테두리 없음, 세로 테두리 없음, 외곽 테두리 없음](data-table-borders.png)

## **범례 키 표시 또는 숨기기**

범례 키는 데이터 테이블에서 시리즈 이름 옆에 표시되는 작은 색상 마커입니다. 각 테이블 행을 차트 시리즈와 연결하는 데 도움을 줍니다. [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatatable/set_showlegendkey/)에 `true`를 전달하면 마커를 표시하고 `false`를 전달하면 숨깁니다.

차트의 별도 범례는 [IChart::set_HasLegend](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/set_haslegend/)로 제어합니다. 이 설정은 독립적이며, 별도 범례를 숨겨도 데이터 테이블 내부의 키는 숨겨지지 않고, 테이블의 키를 숨겨도 별도 범례는 영향을 받지 않습니다.

다음 예제는 기본 데이터 차트를 만들고 데이터 테이블을 활성화한 뒤, 테이블 내부에 범례 키를 표시하고 별도 범례를 숨깁니다. 모든 테이블 테두리는 명시적으로 활성화됩니다. 입력 프레젠테이션이 필요하지 않습니다. 테이블 키만 숨기려면 [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatatable/set_showlegendkey/)에 `false`를 전달합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

아래 비교는 동일한 테이블에서 범례 키가 표시된 경우와 숨겨진 경우를 보여 줍니다. 모든 테두리는 계속 활성화된 상태이며, 별도 차트 범례는 두 경우 모두 숨겨져 있습니다.

![왼쪽에 범례 키가 표시되고 오른쪽에 숨겨진 차트 데이터 테이블](data-table-legend-keys.png)

## **FAQ**

**차트 데이터 테이블에 범례 키를 표시할 수 있나요?**

예. [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatatable/set_showlegendkey/)에 `true`를 전달하면 범례 키가 표시되고 `false`를 전달하면 숨겨집니다.

**프레젠테이션을 PDF, HTML 또는 이미지로 내보낼 때 데이터 테이블이 유지되나요?**

예. Aspose.Slides는 차트와 표시된 데이터 테이블을 슬라이드의 일부로 렌더링하여 [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/ko/cpp/convert-powerpoint-to-html/), [이미지](/slides/ko/cpp/convert-powerpoint-to-png/)로 내보낼 수 있습니다.

**템플릿에서 로드한 차트의 데이터 테이블을 작업할 수 있나요?**

예. 기존 프레젠테이션이나 템플릿에서 로드한 차트의 경우, [IChart::get_HasDataTable](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/get_hasdatatable/)을 사용해 데이터 테이블이 표시되는지 확인하고 [IChart::set_HasDataTable](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/set_hasdatatable/)을 사용해 표시 여부를 변경할 수 있습니다.

**데이터 테이블이 활성화된 차트를 어떻게 찾을 수 있나요?**

각 슬라이드의 셰이프를 순회하면서 차트를 식별하고, 해당 차트의 [IChart::get_HasDataTable](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/get_hasdatatable/) 결과를 확인합니다. `true`이면 데이터 테이블이 활성화된 것입니다.