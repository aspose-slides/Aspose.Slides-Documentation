---
title: C++를 사용하여 프레젠테이션에서 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/cpp/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 카테고리 색상
- 시리즈 이름
- 데이터 포인트
- 시리즈 간격
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "실용적인 코드 예제와 모범 사례를 통해 PowerPoint(PPT/PPTX)용 C++에서 차트 시리즈를 관리하고 데이터 프레젠테이션을 향상시키는 방법을 배웁니다."
---
## **개요**

이 문서는 Aspose.Slides에서 [ChartSeries](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts.chartseries/)의 역할을 설명하며, 프레젠테이션 내에서 데이터가 어떻게 구조화되고 시각화되는지에 초점을 맞춥니다. 이러한 객체는 차트에서 개별 데이터 포인트 집합, 카테고리 및 모양 매개변수를 정의하는 기본 요소를 제공합니다. [ChartSeries](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts.chartseries/)를 사용하면 개발자는 기본 데이터 소스를 원활하게 통합하고 정보 표시 방식을 완전히 제어할 수 있어, 통찰력과 분석을 명확히 전달하는 동적이고 데이터 기반의 프레젠테이션을 만들 수 있습니다.

시리즈는 차트에 플롯되는 숫자의 행 또는 열입니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **데이터 시리즈 겹침 설정**

[IChartSeries::get_Overlap()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) 메서드를 사용하면 2D 차트에서 막대와 열이 겹치는 정도를 지정할 수 있습니다(범위: -100~100). 이 속성은 상위 시리즈 그룹의 모든 시리즈에 적용됩니다. 이는 해당 그룹 속성의 투영입니다.

`get_ParentSeriesGroup()::set_Overlap()` 메서드를 사용하여 `Overlap`에 원하는 값을 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 클러스터형 열 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근합니다.
1. 차트 시리즈의 `ParentSeriesGroup`에 접근하고 해당 시리즈의 겹침 값을 원하는 값으로 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

이 C++ 코드는 차트 시리즈의 겹침을 설정하는 방법을 보여 줍니다:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// 차트 추가
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // 시리즈 겹침 설정
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// 프레젠테이션 파일을 디스크에 저장
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **데이터 시리즈 색상 변경**
Aspose.Slides for C++에서는 다음과 같이 시리즈 색상을 변경할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 차트를 추가합니다.
1. 색상을 변경하려는 시리즈에 접근합니다.
1. 원하는 채우기 유형과 채우기 색상을 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

이 C++ 코드는 시리즈 색상을 변경하는 방법을 보여 줍니다:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **데이터 시리즈 카테고리 색상 변경**
Aspose.Slides for C++에서는 다음과 같이 시리즈 카테고리 색상을 변경할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 차트를 추가합니다.
1. 색상을 변경하려는 시리즈 카테고리에 접근합니다.
1. 원하는 채우기 유형과 채우기 색상을 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

이 C++ 코드는 시리즈 카테고리 색상을 변경하는 방법을 보여 줍니다:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **데이터 시리즈 이름 변경** 

기본적으로 차트의 범례 이름은 각 열 또는 행 위에 있는 셀의 내용입니다.

예시(샘플 이미지)에서는

* 열은 *Series 1, Series 2,* 및 *Series 3*이고,
* 행은 *Category 1, Category 2, Category 3,* 및 *Category 4*입니다.

Aspose.Slides for C++에서는 차트 데이터와 범례에서 시리즈 이름을 업데이트하거나 변경할 수 있습니다.

이 C++ 코드는 `ChartDataWorkbook`에서 차트 데이터의 시리즈 이름을 변경하는 방법을 보여 줍니다:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

이 C++ 코드는 `Series`를 통해 범례에 있는 시리즈 이름을 변경하는 방법을 보여 줍니다:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **데이터 시리즈 채우기 색상 설정**

Aspose.Slides for C++에서는 플롯 영역 내 차트 시리즈에 자동 채우기 색상을 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 원하는 유형(예시에서는 `ChartType::ClusteredColumn`)에 따라 기본 데이터가 포함된 차트를 추가합니다.
1. 차트 시리즈에 접근하고 채우기 색상을 Automatic으로 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

이 C++ 코드는 차트 시리즈의 자동 채우기 색상을 설정하는 방법을 보여 줍니다:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// 클러스터형 열 차트를 생성합니다
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// 시리즈 채우기 형식을 자동으로 설정합니다
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// 프레젠테이션 파일을 디스크에 저장합니다
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **데이터 시리즈 반전 채우기 색상 설정**
Aspose.Slides에서는 플롯 영역 내 차트 시리즈에 반전 채우기 색상을 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 원하는 유형(예시에서는 `ChartType::ClusteredColumn`)에 따라 기본 데이터가 포함된 차트를 추가합니다.
1. 차트 시리즈에 접근하고 채우기 색상을 invert로 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

이 C++ 코드는 해당 동작을 보여 줍니다:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **차트 시리즈에 반전 채우기 색상 적용**
Aspose.Slides에서는 `IChartDataPoint::set_InvertIfNegative()` 및 `ChartDataPoint.set_InvertIfNegative()` 메서드를 통해 반전을 설정할 수 있습니다. 이러한 메서드로 반전이 설정되면, 데이터 포인트가 음수 값을 받을 때 색상이 반전됩니다.

이 C++ 코드는 해당 동작을 보여 줍니다:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **특정 데이터 포인트 값 삭제**
Aspose.Slides for C++에서는 다음과 같이 특정 차트 시리즈의 `DataPoints` 데이터를 삭제할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 가져옵니다.
3. 인덱스로 차트 참조를 가져옵니다.
4. 차트의 모든 `DataPoints`를 반복하면서 `XValue`와 `YValue`를 null로 설정합니다.
5. 특정 차트 시리즈에 대한 모든 `DataPoints`를 삭제합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

이 C++ 코드는 해당 동작을 보여 줍니다:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **데이터 시리즈 간격 너비 설정**
Aspose.Slides for C++에서는 **`set_GapWidth()`** 메서드를 통해 시리즈의 Gap Width를 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터가 포함된 차트를 추가합니다.
1. 任意의 차트 시리즈에 접근합니다.
1. `GapWidth` 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

이 C++ 코드는 시리즈의 Gap Width를 설정하는 방법을 보여 줍니다:

```cpp
// 빈 프레젠테이션 생성 
auto presentation = System::MakeObject<Presentation>();

// 프레젠테이션의 첫 번째 슬라이드에 접근
auto slide = presentation->get_Slides()->idx_get(0);

// 기본 데이터가 포함된 차트 추가
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// 차트 데이터 시트 인덱스 설정
int32_t worksheetIndex = 0;

// 차트 데이터 워크시트 가져오기
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// 시리즈 추가
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// 카테고리 추가
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// 두 번째 차트 시리즈 가져오기
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// 시리즈 데이터 채우기
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// GapWidth 값 설정
series->get_ParentSeriesGroup()->set_GapWidth(50);

// 프레젠테이션을 디스크에 저장
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**단일 차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides는 추가할 수 있는 시리즈 수에 고정된 상한을 두지 않습니다. 실질적인 제한은 차트 가독성과 애플리케이션이 사용할 수 있는 메모리에 따라 달라집니다.

**클러스터 내 열이 서로 너무 가깝거나 너무 멀리 떨어져 있으면 어떻게 해야 하나요?**

해당 시리즈(또는 상위 시리즈 그룹)의 Gap Width 설정을 조정하십시오. 값을 높이면 열 사이 간격이 넓어지고, 값을 낮추면 간격이 좁아집니다.