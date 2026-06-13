---
title: 프레젠테이션 차트의 플롯 영역을 C++에서 사용자 지정
linktitle: 플롯 영역
type: docs
url: /ko/cpp/chart-plot-area/
keywords:
- 차트
- 플롯 영역
- 플롯 영역 너비
- 플롯 영역 높이
- 플롯 영역 크기
- 레이아웃 모드
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 차트 플롯 영역을 사용자 지정하는 방법을 알아보세요. 슬라이드 시각 효과를 손쉽게 향상시킬 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트의 플롯 영역을 다루는 방법을 보여줍니다. 차트 레이아웃을 검증한 후 X, Y, 너비, 높이 값을 읽어 플롯 영역의 실제 위치와 크기를 가져오는 방법을 설명합니다.

또한 레이아웃을 수동으로 설정할 때 `LayoutTargetType`을 사용하여 플롯 영역을 내부 영역으로 계산할지 축 및 축 레이블을 포함한 외부 영역으로 계산할지를 정의하는 레이아웃 모드 구성 방법을 시연합니다.

## **차트 플롯 영역의 너비와 높이 가져오기**
Aspose.Slides for C++는 간단한 API를 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터로 차트를 추가합니다.
1. 실제 값을 얻기 위해 IChart::ValidateChartLayout() 메서드를 호출합니다.
1. 차트 요소의 실제 X 위치(왼쪽)를 차트 왼쪽 위 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 위쪽 위치를 차트 왼쪽 위 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 너비를 가져옵니다.
1. 차트 요소의 실제 높이를 가져옵니다.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// 차트가 포함된 프레젠테이션 저장
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **차트 플롯 영역의 레이아웃 모드 설정**
Aspose.Slides for C++는 차트 플롯 영역의 레이아웃 모드를 설정하는 간단한 API를 제공합니다. **LayoutTargetType** 속성이 **ChartPlotArea** 및 **IChartPlotArea** 클래스에 추가되었습니다. 플롯 영역 레이아웃을 수동으로 정의한 경우, 이 속성은 플롯 영역을 내부(축 및 축 레이블 제외) 또는 외부(축 및 축 레이블 포함)로 레이아웃할지를 지정합니다. **LayoutTargetType** 열거형에 정의된 두 가지 가능한 값이 있습니다.

- **LayoutTargetType.Inner** – 틱 마크와 축 레이블을 포함하지 않는 플롯 영역 내부 크기로 플롯 영역 크기를 결정함을 지정합니다.
- **LayoutTargetType.Outer** – 틱 마크와 축 레이블을 포함한 플롯 영역 외부 크기로 플롯 영역 크기를 결정함을 지정합니다.

예제 코드는 다음과 같습니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **자주 묻는 질문**

**ActualX, ActualY, ActualWidth, ActualHeight는 어떤 단위로 반환되나요?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 Aspose.Slides 좌표 단위입니다.

**플롯 영역과 차트 영역은 콘텐츠 측면에서 어떻게 다릅니까?**

플롯 영역은 데이터 그리기 영역(시리즈, 눈금선, 추세선 등)이며, 차트 영역은 주변 요소(제목, 범례 등)를 포함합니다. 3D 차트에서는 플롯 영역이 벽/바닥 및 축도 포함합니다.

**레이아웃이 수동인 경우 플롯 영역의 X, Y, Width, Height는 어떻게 해석되나요?**

차트 전체 크기의 비율(0–1)로 해석됩니다. 이 모드에서는 자동 위치 지정이 비활성화되고 사용자가 설정한 비율이 사용됩니다.

**범례를 추가하거나 이동한 후 플롯 영역 위치가 변경된 이유는 무엇인가요?**

범례는 플롯 영역 외부의 차트 영역에 위치하지만 레이아웃과 사용 가능한 공간에 영향을 미칩니다. 따라서 자동 위치 지정이 적용될 경우 범례가 플롯 영역을 이동시킬 수 있습니다. (이는 PowerPoint 차트의 표준 동작입니다.)