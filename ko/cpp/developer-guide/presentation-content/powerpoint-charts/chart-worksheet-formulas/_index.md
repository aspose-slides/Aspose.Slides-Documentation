---
title: C++를 사용하여 프레젠테이션에서 차트 워크시트 수식 적용
linktitle: 워크시트 수식
type: docs
weight: 70
url: /ko/cpp/chart-worksheet-formulas/
keywords:
- 차트 스프레드시트
- 차트 워크시트
- 차트 수식
- 워크시트 수식
- 스프레드시트 수식
- 차트 데이터 워크북
- 수식 계산
- 논리 상수
- 숫자 상수
- 문자열 상수
- 오류 상수
- 산술 연산자
- 비교 연산자
- A1 스타일
- R1C1 스타일
- 사전 정의 함수
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 차트 워크시트에서 Excel 스타일 수식을 적용하고, 값을 다시 계산한 뒤 PowerPoint 차트에 결과를 사용합니다."
---
## **개요**

PowerPoint 차트는 일반적으로 소스 데이터를 포함된 워크시트에 저장합니다. Aspose.Slides for C++에서는 차트 데이터 워크북을 통해 해당 워크시트에 접근하고, 입력 값을 기록하고, 셀에 수식을 할당하고, 지원되는 수식을 계산하며, 계산된 셀을 차트 데이터로 사용할 수 있습니다.

이 문서는 전체 수식 흐름을 설명합니다: 차트를 만들고, 워크시트를 채우고, A1 스타일 또는 R1C1 스타일 수식을 할당하고, 다시 계산하고, 계산된 값을 읽고, 해당 셀을 차트 시리즈에 연결하고, 프레젠테이션을 저장합니다. 또한 지원되는 수식 구문, 기본 제공 함수 집합, 캐시된 값, 지원되지 않는 수식 및 스프레드시트 전용 오류에 대해 설명합니다.

## **차트 워크시트 및 수식**

차트 워크시트에는 차트에서 사용하는 카테고리, 시리즈 이름 및 값이 포함됩니다. PowerPoint에서는 차트 데이터 편집기를 열어 워크시트를 검사할 수 있습니다:

![PowerPoint 차트와 포함된 워크시트가 열려 있는 모습, 카테고리 및 시리즈 데이터 표시](chart-worksheet-formulas_1.png)

Aspose.Slides에서는 워크시트가 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/) 인터페이스를 통해 노출됩니다. A1 스타일 수식에는 [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/set_formula/)을, R1C1 스타일 수식에는 [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/)을 사용하세요. 입력 셀이나 수식을 변경한 후에는 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)을 호출하여 지원되는 수식을 다시 계산하고 해당 셀 값을 업데이트합니다.

계산된 셀은 여전히 [IChartDataCell::get_Value](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/get_value/)를 통해 결과를 노출합니다. 이는 코드에서 수식 결과를 검사하거나 셀을 차트 데이터 포인트로 사용할 때 중요합니다.

## **차트 만들기 및 워크시트 수식 계산**

다음 예제는 엔드‑투‑엔드 워크플로를 보여줍니다. 클러스터형 세로 막대 차트를 만들고, 샘플 데이터를 삭제하고, 분기별 매출 및 비용 값을 기록하고, 수식으로 이익을 계산하고, 결과를 읽고, 계산된 셀을 차트 값으로 사용하고, 프레젠테이션을 저장합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

차트 데이터 포인트는 `D2:D4`를 참조하므로 차트는 계산된 이익 값을 사용합니다. 이 워크플로에서는 별도의 차트 새로 고침 호출이 필요하지 않습니다: 먼저 워크북을 다시 계산하고, 그런 다음 계산된 셀을 가리키는 차트 데이터를 사용하거나 저장합니다.

## **A1 스타일 수식 사용**

A1 표기법은 열을 문자, 행을 숫자로 식별합니다. [IChartDataCell::set_Formula](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/set_formula/)를 통해 A1 스타일 표현식을 할당합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

일반적인 A1 참조 형태는 다음과 같습니다:

| 참조 | 상대 | 절대 | 혼합 |
|---|---|---|---|
| 셀 | `A2` | `$A$2` | `A$2`, `$A2` |
| 행 | `2:2` | `$2:$2` | — |
| 열 | `A:A` | `$A:$A` | — |
| 범위 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

상대 참조는 수식이 스프레드시트 응용 프로그램에서 이동하거나 복사될 때 변경될 수 있습니다. 절대 참조는 두 좌표를 모두 고정하고, 혼합 참조는 행이나 열 중 하나만 고정합니다.

## **R1C1 스타일 수식 사용**

R1C1 표기법은 행과 열을 모두 숫자로 식별합니다. 상대 참조는 대괄호 안에 오프셋을 사용합니다. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/)를 통해 이 구문을 할당합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

일반적인 R1C1 참조 형태는 다음과 같습니다:

| 참조 | 상대 | 절대 | 혼합 |
|---|---|---|---|
| 셀 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 행 | `R[2]` | `R2` | — |
| 열 | `C[3]` | `C3` | — |
| 범위 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

예를 들어 셀 `D2`에서 `RC[-2]`는 같은 행의 두 열 왼쪽 셀(`B2`)을 의미합니다.

## **수식 상수 및 연산자**

내장 수식 평가기는 논리값, 숫자 리터럴, 문자열, 스프레드시트 오류값, 산술 연산자 및 비교 연산자를 지원합니다.

### **상수 및 리터럴**

| 유형 | 예시 | 비고 |
|---|---|---|
| 논리 | `TRUE`, `FALSE` | `A2=TRUE`와 같은 논리식에 직접 사용할 수 있습니다. |
| 숫자 | `1`, `0.5`, `.3`, `1E-2` | 일반 및 과학적 표기법을 지원합니다. |
| 문자열 | `"abc"`, `"2/3/2020 12:00"` | 문자열 리터럴은 수식 내에서 큰따옴표로 감쌉니다. |
| 오류 결과 | `#DIV/0!`, `#N/A`, `#REF!` | 유효한 수식이 정상 결과 대신 스프레드시트 오류값으로 평가될 수 있습니다. |

다음 예제는 여러 상수 유형을 사용합니다:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // 거짓
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **산술 연산자**

| 연산자 | 의미 | 예시 |
|---|---|---|
| `+` | 덧셈 또는 단항 플러스 | `2+3` |
| `-` | 뺄셈 또는 부정 | `2-3`, `-3` |
| `*` | 곱셈 | `2*3` |
| `/` | 나눗셈 | `2/3` |
| `%` | 백분율 | `30%` |
| `^` | 지수 | `2^3` |

예를 들어 `(A2+B2)*C2`와 같이 괄호를 사용해 계산 순서를 명시할 수 있습니다.

### **비교 연산자**

비교식은 논리값을 반환합니다.

| 연산자 | 의미 | 예시 |
|---|---|---|
| `=` | 같다 | `A2=3` |
| `<>` | 같지 않다 | `A2<>3` |
| `>` | 크다 | `A2>3` |
| `>=` | 크거나 같다 | `A2>=3` |
| `<` | 작다 | `A2<3` |
| `<=` | 작거나 같다 | `A2<=3` |

## **지원되는 사전 정의 함수**

Aspose.Slides에는 차트 워크시트용 내장 수식 평가기가 포함되어 있지만, 전체 Excel 계산 엔진은 아닙니다. 문서화된 함수 집합은 아래에 나열된 함수들로 제한됩니다. 임의의 Excel 함수가 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)에 의해 재계산된다고 가정하지 마세요.

| 함수 | 목적 또는 지원 형태 | 예시 |
|---|---|---|
| `ABS` | 절대값 | `ABS(A2)` |
| `AVERAGE` | 산술 평균 | `AVERAGE(B2:B5)` |
| `CEILING` | 숫자를 지정된 배수로 올림 | `CEILING(A2,5)` |
| `CHOOSE` | 인덱스로 값 선택 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 텍스트 값 연결 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 텍스트 값 연결 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 날짜 시스템을 사용해 날짜 값 생성 | `DATE(2026,8,19)` |
| `DAYS` | 두 날짜 사이 일수 반환 | `DAYS(B2,A2)` |
| `FIND` | 텍스트 내에서 다른 텍스트 찾기 | `FIND("-",A2)` |
| `FINDB` | 바이트 기반 텍스트 검색 | `FINDB("a",A2)` |
| `IF` | 조건 결과 | `IF(A2>0,A2,0)` |
| `INDEX` | 참조 형태 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 벡터 형태 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 벡터 형태 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 최대값 | `MAX(B2:B5)` |
| `SUM` | 합계 | `SUM(B2:B5)` |
| `VLOOKUP` | 수직 조회 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

표에 표시된 제한 사항은 중요합니다: `INDEX`는 참조 형태로 문서화되고, `LOOKUP`과 `MATCH`는 벡터 형태로 문서화됩니다. `DATE`는 1900 날짜 시스템을 사용합니다. 여기 나열되지 않은 기능 및 함수는 별도로 문서화되지 않는 한 Aspose.Slides 수식 평가기에 의해 지원되지 않는다고 간주해야 합니다.

## **재계산 및 캐시된 값**

스프레드시트 파일은 일반적으로 수식과 마지막 계산된 값을 모두 저장합니다. 따라서 프레젠테이션을 로드하고 차트 데이터가 변경되지 않은 경우 Aspose.Slides는 [IChartDataCell::get_Value](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/get_value/)를 통해 캐시된 값을 읽을 수 있습니다.

입력 셀이나 수식을 변경한 후에는 오래된 캐시 결과에 의존하지 마세요. 계산된 값을 읽거나 해당 값에 의존하는 차트 데이터를 저장하기 전에 반드시 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)를 호출하십시오.

지원 범위 외의 수식에 대해서는 Aspose.Slides가 수식을 파싱하거나 종속성을 파악하지 못할 수 있습니다. 워크북이 수정된 경우 이전 캐시 값은 더 이상 신뢰할 수 없습니다. 이 경우 지원되지 않는 데이터가 있는 셀의 값을 읽으려고 하면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)이 발생할 수 있습니다.

차트가 Aspose.Slides가 평가하지 못하는 Excel 함수를 사용해야 한다면, 해당 함수를 지원하는 스프레드시트 엔진으로 수식을 계산한 뒤 결과 값을 차트 워크북에 기록하세요. 추측한 값으로 지원되지 않는 수식을 대체하지 마십시오.

## **수식 오류 처리**

구분해야 할 문제 유형이 두 가지 있습니다.

수식이 유효하지만 `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!`와 같은 스프레드시트 오류 결과를 반환할 수 있습니다. 이 경우 오류 토큰은 셀 결과이며 [IChartDataCell::get_Value](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/get_value/)를 통해 반환됩니다.

수식이 구문, 참조, 종속성 또는 지원 데이터 수준에서 실패할 수도 있습니다. Aspose.Slides는 이러한 경우에 대해 다음과 같은 스프레드시트 전용 예외를 제공합니다: [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

템플릿이나 사용자 입력으로부터 수식이 제공될 경우, 재계산 및 값 접근 시 이러한 예외를 처리하세요:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // 잘못된 수식을 처리합니다.
}
catch (CellInvalidReferenceException&)
{
    // 잘못된 셀 참조를 처리합니다.
}
catch (CellCircularReferenceException&)
{
    // 순환 참조를 처리합니다.
}
catch (CellUnsupportedDataException&)
{
    // 지원되지 않는 스프레드시트 데이터를 처리합니다.
}
```

## **실용적인 제한 사항**

차트 워크시트의 수식 지원은 전체 Excel 호환성을 목표로 하지 않고, 정의된 스프레드시트 계산 하위 집합에만 해당됩니다. 보고 워크플로를 설계할 때 다음 제약을 염두에 두세요:

- Aspose.Slides가 수식을 재계산하도록 하려면 문서화된 상수, 연산자, 참조 및 함수만 사용하십시오.
- 수식 결과가 의존하는 셀을 변경한 후 반드시 다시 계산하십시오.
- 로드된 프레젠테이션에서 가져온 캐시 값은 스냅샷이며, 편집 후 재계산을 대체하지 않습니다.
- 기존 템플릿의 수식을 사용하기 전에는 반드시 테스트하여, 문서에 없는 함수가 포함된 경우 결과가 신뢰할 수 없는지 확인하십시오.
- 전체 스프레드시트 계산 엔진이 필요한 경우 외부에서 수식을 계산한 뒤 차트 워크북에 최종 값을 업데이트하십시오.

## **FAQ**

**`set_Formula`와 `set_R1C1Formula`의 차이점은 무엇인가요?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/set_formula/)는 `B2-C2`와 같은 A1 스타일 표현식을 저장합니다. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/)는 `RC[-2]-RC[-1]`와 같은 R1C1 스타일 표현식을 저장합니다. 수식을 생성하거나 복사하는 방식에 가장 잘 맞는 표기법을 사용하세요.

**계산 후에 셀 자체를 읽어야 하나요, 아니면 값만 읽어야 하나요?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/getcell/)은 `IChartDataCell`을 반환합니다. 재계산 후에 해당 셀의 [IChartDataCell::get_Value](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/get_value/) 값을 읽어 계산 결과를 얻으세요.

**`CalculateFormulas`를 언제 호출해야 하나요?**

입력 값이나 수식을 변경한 뒤, 계산된 결과에 의존하기 전에 반드시 [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)를 호출하십시오. 이렇게 하면 내장 평가기가 지원하는 수식의 값이 업데이트됩니다.

**Aspose.Slides가 모든 Excel 함수를 지원하나요?**

아니요. 내장 평가기는 문서화된 함수 하위 집합만 지원합니다. 그 집합에 포함되지 않은 함수는 올바르게 재계산된다고 가정하지 마세요. 전체 Excel 수식 호환성이 필요하면 적절한 스프레드시트 엔진으로 계산하고 최종 값을 차트 워크북에 기록하십시오.

**로드된 프레젠테이션에 지원되지 않는 수식이 포함되어 있으면 어떻게 되나요?**

차트 데이터가 변경되지 않은 경우 워크북에 이전에 계산된 캐시 값이 남아 있을 수 있습니다. 관련 데이터가 수정되면 해당 캐시 값은 더 이상 유효하지 않을 수 있습니다. 처리할 수 없는 수식이 있는 셀에 접근하면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)이 발생할 수 있습니다.

**수식 오류 값과 C++ 예외는 같은 것인가요?**

아니요. `#DIV/0!`와 같은 결과는 유효한 계산에 의해 생성된 스프레드시트 값입니다. [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)이나 [CellCircularReferenceException](https://reference.aspose.com/slides/ko/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/)과 같은 예외는 수식을 정상적으로 처리할 수 없음을 나타냅니다.

**수식 셀이 변경되면 차트가 자동으로 업데이트되나요?**

차트 시리즈는 워크북 셀을 참조할 수 있습니다. 먼저 워크북을 다시 계산하고, 그 다음 프레젠테이션을 저장하거나 렌더링하면 업데이트된 셀 값을 차트가 사용합니다. 별도의 차트 새로 고침 메서드는 필요하지 않습니다.

**차트가 외부 Excel 워크북을 사용할 수 있나요?**

예, 차트 데이터는 차트 데이터 API를 통해 외부 워크북을 사용하도록 구성할 수 있습니다. 그러나 이 문서에서 설명하는 수식 계산 워크플로는 차트 데이터 워크북 및 Aspose.Slides가 평가하는 수식 하위 집합에만 해당됩니다. [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)가 외부 XLSX 파일의 임의 수식을 완전하게 재계산한다고 가정하지 마세요.

**다른 워크시트나 워크북을 참조하는 수식을 사용할 수 있나요?**

Excel 스타일 참조가 차트 워크북에 존재할 수 있지만, 수식 평가가 지원되는 파서와 함수 집합에 의해 제한됩니다. 교차 시트 또는 외부 참조가 필수인 경우 대상 Aspose.Slides 버전에서 정확한 수식을 검증하십시오. 광범위한 Excel 참조 호환성이 필요한 워크플로에서는 워크북을 외부에서 계산한 뒤 차트 데이터에 해석된 값을 기록하는 것이 좋습니다.

**수식 문자열은 `=`로 시작해야 하나요?**

Aspose.Slides API 예제는 `B2-C2` 또는 `SUM(B2:B5)`와 같이 앞에 `=` 없이 표현식을 할당합니다. 이렇게 하면 생성된 수식이 문서화된 API 예제와 일관성을 유지합니다.