---
title: C++에서 프레젠테이션을 위한 차트 계산 최적화
linktitle: 차트 계산
type: docs
weight: 50
url: /ko/cpp/chart-calculations/
keywords:
- 차트 계산
- 차트 요소
- 요소 위치
- 실제 위치
- 자식 요소
- 부모 요소
- 차트 값
- 실제 값
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 PPT 및 PPTX용 차트 계산, 데이터 업데이트 및 정밀 제어를 이해하고, 실용적인 C++ 코드 예제를 제공합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 차트 계산 및 레이아웃 데이터를 작업하기 위한 API를 제공합니다. 이 문서에서는 `IActualLayout`을 구현하는 요소의 실제 위치와 크기 및 차트 축의 실제 값을 포함한 차트 요소의 실제 값을 검색하는 방법을 보여줍니다. 또한 이러한 값은 차트 레이아웃 검증 후에 채워진다는 점을 설명합니다.

또한, 문서에서는 부모 차트 요소의 실제 위치를 가져오는 방법과 제목, 축, 범례, 그리드 라인과 같은 차트 구성 요소를 숨기는 방법을 시연합니다. 이러한 예제를 통해 차트 레이아웃 정보를 검사하고 PowerPoint 프레젠테이션에서 차트 요소의 표시 여부를 프로그래밍 방식으로 제어할 수 있습니다.

## **차트 요소의 실제 값 계산**
Aspose.Slides for C++는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. 이를 통해 차트 요소의 실제 값을 계산할 수 있습니다. 실제 값에는 IActualLayout 인터페이스를 구현하는 요소의 위치(IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight())와 실제 축 값(IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale())이 포함됩니다.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// 프레젠테이션 저장
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **부모 차트 요소의 실제 위치 계산**
Aspose.Slides for C++는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. IActualLayout의 메서드는 부모 차트 요소의 실제 위치에 대한 정보를 제공합니다. 실제 값으로 속성을 채우려면 이전에 IChart::ValidateChartLayout() 메서드를 호출해야 합니다.

``` cpp
// 빈 프레젠테이션 만들기
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **차트 요소 숨기기**
이 항목에서는 차트에서 정보를 숨기는 방법을 이해하는 데 도움이 됩니다. Aspose.Slides for C++를 사용하면 차트에서 **제목, 수직 축, 수평 축** 및 **그리드 라인**을 숨길 수 있습니다. 아래 코드 예시는 이러한 속성을 사용하는 방법을 보여줍니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **차트 데이터 범위 설정**
Aspose.Slides for C++는 차트에 대한 데이터 범위를 가장 쉽게 설정할 수 있는 가장 간단한 API를 제공합니다. 차트에 대한 데이터 범위를 설정하려면:

- 차트를 포함하고 있는 `Presentation` 클래스의 인스턴스를 엽니다.
- 인덱스를 사용하여 슬라이드 참조를 얻습니다.
- 모든 도형을 순회하여 원하는 차트를 찾습니다.
- 차트 데이터를 액세스하고 범위를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 차트를 업데이트하는 방법을 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**외부 Excel 워크북을 데이터 소스로 사용할 수 있나요? 그리고 재계산에 어떤 영향을 줍니까?**

예. 차트는 외부 워크북을 참조할 수 있습니다. 외부 소스를 연결하거나 새로 고치면 해당 워크북에서 수식과 값이 가져와지고, 차트는 열기/편집 작업 중에 업데이트를 반영합니다. API를 사용하면 [외부 워크북 지정](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) 경로를 지정하고 연결된 데이터를 관리할 수 있습니다.

**회귀를 직접 구현하지 않고 추세선을 계산하고 표시할 수 있나요?**

예. [Trendlines](/slides/ko/cpp/trend-line/) (선형, 지수 등)은 Aspose.Slides에 의해 추가 및 업데이트되며, 파라미터는 시리즈 데이터에서 자동으로 재계산되므로 직접 계산 로직을 구현할 필요가 없습니다.

**프레젠테이션에 외부 링크가 있는 여러 차트가 포함된 경우, 각 차트가 사용할 워크북을 개별적으로 제어할 수 있나요?**

예. 각 차트는 자체 [외부 워크북](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chartdata/setexternalworkbook/)을 지정할 수 있으며, 다른 차트와 독립적으로 외부 워크북을 생성하거나 교체할 수 있습니다.