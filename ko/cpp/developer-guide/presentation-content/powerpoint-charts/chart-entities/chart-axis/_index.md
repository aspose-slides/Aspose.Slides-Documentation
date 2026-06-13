---
title: C++를 사용하여 프레젠테이션의 차트 축을 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/cpp/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 맞춤
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 라인
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Aspose.Slides for C++를 사용하는 방법을 알아보세요."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 축을 사용자 지정하는 방법을 설명합니다. 실제 축 값 가져오기, 축 간 데이터 교환, 선 차트에서 수직 또는 수평 축 숨기기, 범주 축 유형 변경, 범주 축 값에 대한 날짜 형식 설정, 축 제목 회전, 축 위치 설정, 값 축에 단위 레이블 표시 방법을 보여줍니다.

## **수직 축의 최대값 가져오기**
Aspose.Slides for C++를 사용하면 수직 축의 최소값과 최대값을 얻을 수 있습니다. 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터가 포함된 차트를 추가합니다.
4. 축에서 실제 최대값을 가져옵니다.
5. 축에서 실제 최소값을 가져옵니다.
6. 축의 실제 주요 단위를 가져옵니다.
7. 축의 실제 부단위를 가져옵니다.
8. 축의 실제 주요 단위 눈금을 가져옵니다.
9. 축의 실제 부단위 눈금을 가져옵니다.

위 단계들을 구현한 샘플 코드로, C++에서 필요한 값을 가져오는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// 프레젠테이션 저장
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **축 간 데이터 교환**
Aspose.Slides를 사용하면 축 간 데이터를 빠르게 교환할 수 있습니다—수직 축(y축)의 데이터가 수평 축(x축)으로 이동하고 그 반대도 마찬가지입니다. 

다음 C++ 코드는 차트에서 축 간 데이터 교환 작업을 수행하는 방법을 보여줍니다:

``` cpp
// 빈 프레젠테이션을 생성합니다
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// 행과 열을 전환합니다
chart->get_ChartData()->SwitchRowColumn();

// 프레젠테이션을 저장합니다
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **선 차트에서 수직 축 비활성화**

다음 C++ 코드는 선 차트에서 수직 축을 숨기는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **선 차트에서 수평 축 비활성화**

다음 코드는 선 차트에서 수평 축을 숨기는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **범주 축 변경**

**set_CategoryAxisType()** 메서드를 사용하여 원하는 범주 축 유형(**date** 또는 **text**)을 지정할 수 있습니다. 다음 C++ 코드는 해당 작업을 시연합니다: 

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **범주 축 값의 날짜 형식 설정**
Aspose.Slides for C++를 사용하면 범주 축 값의 날짜 형식을 설정할 수 있습니다. 다음 C++ 코드는 해당 작업을 시연합니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **축 제목 회전 각도 설정**
Aspose.Slides for C++를 사용하면 차트 축 제목의 회전 각도를 설정할 수 있습니다. 다음 C++ 코드는 해당 작업을 시연합니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **범주 축 또는 값 축의 위치 설정**
Aspose.Slides for C++를 사용하면 범주 축 또는 값 축에서 축 위치를 설정할 수 있습니다. 다음 C++ 코드는 작업 수행 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **차트 값 축에 단위 레이블 표시 활성화**
Aspose.Slides for C++를 사용하면 차트 값 축에 단위 레이블을 표시하도록 구성할 수 있습니다. 다음 C++ 코드는 해당 작업을 시연합니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**축이 다른 축과 교차하는 값을 어떻게 설정합니까(축 교차)?**

축은 [crossing setting](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/axis/set_crosstype/)을 제공합니다: 0, 최대 범주/값 또는 특정 숫자값에서 교차하도록 선택할 수 있습니다. 이는 X축을 위아래로 이동하거나 기준선을 강조할 때 유용합니다.

**축에 대한 눈금 레이블의 위치를 어떻게 지정합니까(옆, 외부, 내부)?**

[label position](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/axis/set_majortickmark/)을 "cross", "outside", "inside" 중 하나로 설정합니다. 이는 가독성에 영향을 주며, 특히 작은 차트에서 공간 절약에 도움이 됩니다.