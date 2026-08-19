---
title: Python으로 프레젠테이션에서 차트 워크시트 수식 적용
linktitle: 워크시트 수식
type: docs
weight: 70
url: /ko/python-net/chart-worksheet-formulas/
keywords:
- 차트 스프레드시트
- 차트 워크시트
- 차트 수식
- 워크시트 수식
- 스프레드시트 수식
- 차트 데이터 워크북
- 수식 계산
- 논리 상수
- 수치 상수
- 문자열 상수
- 오류 상수
- 산술 연산자
- 비교 연산자
- A1 스타일
- R1C1 스타일
- 미리 정의된 함수
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET 차트 워크시트에서 Excel 스타일 수식을 적용하고, 값을 다시 계산하여 PowerPoint 차트에 결과를 사용합니다."
---
## **개요**

PowerPoint 차트는 일반적으로 원본 데이터를 포함된 워크시트에 저장합니다. Aspose.Slides for Python via .NET에서 차트 데이터 워크북을 통해 해당 워크시트에 접근하고, 입력 값을 기록하고, 셀에 수식을 할당하고, 지원되는 수식을 계산하며, 계산된 셀을 차트 데이터로 사용할 수 있습니다.

이 문서는 전체 수식 작업 흐름을 설명합니다: 차트를 만들고, 워크시트를 채우고, A1 스타일 또는 R1C1 스타일 수식을 할당하고, 이를 다시 계산하고, 계산된 값을 읽고, 해당 셀을 차트 시리즈에 연결하고, 프레젠테이션을 저장합니다. 또한 지원되는 수식 구문, 내장 함수 집합, 캐시된 값, 지원되지 않는 수식 및 스프레드시트 전용 오류에 대해서도 설명합니다.

## **차트 워크시트 및 수식**

차트 워크시트에는 차트에서 사용하는 범주, 시리즈 이름 및 값이 포함됩니다. PowerPoint에서 차트 데이터 편집기를 열어 워크시트를 확인할 수 있습니다:

![PowerPoint 차트와 해당 포함 워크시트가 열려있으며, 카테고리 및 시리즈 데이터 표시](chart-worksheet-formulas_1.png)

Aspose.Slides에서는 워크시트가 [chart data workbook](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdataworkbook/)를 통해 노출됩니다. A1 스타일 수식은 [formula](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/formula/) 속성을, R1C1 스타일 수식은 [r1c1_formula](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) 속성을 사용합니다. 입력 셀이나 수식을 변경한 후에는 [calculate_formulas](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)를 호출하여 지원되는 수식을 다시 계산하고 해당 셀 값을 업데이트합니다.

계산된 셀은 여전히 ​​[value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/value/) 속성을 통해 결과를 노출합니다. 이는 코드에서 수식 결과를 검사하거나 셀을 차트 데이터 포인트로 사용할 때 중요합니다.

## **차트 만들기 및 워크시트 수식 계산**

다음 예제는 엔드‑투‑엔드 작업 흐름을 보여줍니다. 클러스터형 컬럼 차트를 만들고, 샘플 데이터를 지우고, 분기별 매출 및 비용 값을 기록하고, 수식으로 이익을 계산하고, 결과를 읽고, 계산된 셀을 차트 값으로 사용하고, 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

차트 데이터 포인트는 `D2:D4`를 참조하므로 차트는 계산된 이익 값을 사용합니다. 이 워크플로우에는 별도의 차트 새로 고침 호출이 없습니다: 먼저 워크북을 다시 계산하고, 그런 다음 계산된 셀을 가리키는 차트 데이터를 사용하거나 저장합니다.

## **A1 스타일 수식 사용**

A1 표기법은 열을 문자로, 행을 숫자로 식별합니다. [IChartDataCell.formula](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/formula/)을 통해 A1 스타일 식을 할당합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

일반적인 A1 참조 형태는 다음과 같습니다:

| 참조 | 상대 | 절대 | 혼합 |
|---|---|---|---|
| 셀 | `A2` | `$A$2` | `A$2`, `$A2` |
| 행 | `2:2` | `$2:$2` | — |
| 열 | `A:A` | `$A:$A` | — |
| 범위 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

상대 참조는 수식이 스프레드시트 응용 프로그램에 의해 이동되거나 복사될 때 변경될 수 있습니다. 절대 참조는 두 좌표를 모두 고정하고, 혼합 참조는 행 또는 열만 고정합니다.

## **R1C1 스타일 수식 사용**

R1C1 표기법은 행과 열을 모두 숫자로 식별합니다. 상대 참조는 대괄호 안의 오프셋을 사용합니다. [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)을 통해 이 구문을 할당합니다.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

일반적인 R1C1 참조 형태는 다음과 같습니다:

| 참조 | 상대 | 절대 | 혼합 |
|---|---|---|---|
| 셀 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 행 | `R[2]` | `R2` | — |
| 열 | `C[3]` | `C3` | — |
| 범위 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

예를 들어 셀 `D2`에서 `RC[-2]`는 같은 행에서 두 열 왼쪽에 있는 셀(`B2`)을 의미합니다.

## **수식 상수 및 연산자**

내장 수식 평가기는 논리값, 숫자 리터럴, 문자열, 스프레드시트 오류값, 산술 연산자 및 비교 연산자를 지원합니다.

### **상수 및 리터럴**

| 유형 | 예시 | 비고 |
|---|---|---|
| 논리 | `TRUE`, `FALSE` | `A2=TRUE`와 같은 논리식에 직접 사용할 수 있습니다. |
| 숫자 | `1`, `0.5`, `.3`, `1E-2` | 일반 및 과학적 표기법을 지원합니다. |
| 문자열 | `"abc"`, `"2/3/2020 12:00"` | 문자열 리터럴은 수식 내부에서 큰따옴표로 묶습니다. |
| 오류 결과 | `#DIV/0!`, `#N/A`, `#REF!` | 유효한 수식이 정상 결과 대신 스프레드시트 오류값을 반환할 수 있습니다. |

다음 예제는 여러 종류의 상수를 사용합니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # 거짓
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
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

평가 순서를 명시하려면 괄호를 사용합니다. 예: `(A2+B2)*C2`.

### **비교 연산자**

비교 식은 논리값을 반환합니다.

| 연산자 | 의미 | 예시 |
|---|---|---|
| `=` | 같다 | `A2=3` |
| `<>` | 같지 않다 | `A2<>3` |
| `>` | 초과 | `A2>3` |
| `>=` | 이상 | `A2>=3` |
| `<` | 미만 | `A2<3` |
| `<=` | 이하 | `A2<=3` |

## **지원되는 사전 정의 함수**

Aspose.Slides에는 차트 워크시트를 위한 내장 수식 평가기가 포함되어 있지만, 전체 Excel 계산 엔진은 아닙니다. 문서화된 함수 집합은 아래 표에 제한되어 있습니다. 임의의 Excel 함수가 [calculate_formulas](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)로 다시 계산된다고 가정하지 마세요.

| 함수 | 목적 또는 지원 형태 | 예시 |
|---|---|---|
| `ABS` | 절대값 | `ABS(A2)` |
| `AVERAGE` | 산술 평균 | `AVERAGE(B2:B5)` |
| `CEILING` | 지정 배수로 올림 | `CEILING(A2,5)` |
| `CHOOSE` | 인덱스로 값 선택 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 텍스트 연결 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 텍스트 연결 | `CONCATENATE(A2," ",B2)` |
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

표에 표시된 제한 사항은 중요합니다: `INDEX`는 참조 형태로 문서화되고, `LOOKUP`과 `MATCH`는 벡터 형태로 문서화됩니다. `DATE`는 1900 날짜 시스템을 사용합니다. 여기 나열되지 않은 기능은 Aspose.Slides 수식 평가기에 의해 지원되지 않는 것으로 간주해야 합니다.

## **재계산 및 캐시된 값**

스프레드시트 파일은 일반적으로 수식과 마지막 계산된 값을 모두 저장합니다. 따라서 프레젠테이션을 로드하고 해당 차트 데이터가 변경되지 않은 경우 [IChartDataCell.value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/value/)에서 캐시된 값을 읽을 수 있습니다.

입력 셀이나 수식을 변경한 후에는 오래된 캐시 결과에 의존하지 마세요. 계산된 값을 읽거나 해당 값을 사용하는 차트 데이터를 저장하기 전에 [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)를 호출하십시오.

지원되지 않는 부분에 해당하는 수식은 Aspose.Slides가 수식을 파싱하거나 의존성을 파악하지 못할 수 있습니다. 워크북이 수정되면 이전 캐시 값은 신뢰할 수 없게 됩니다. 이 경우 지원되지 않는 데이터를 가진 셀을 읽으면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)이 발생할 수 있습니다.

차트가 Aspose.Slides가 평가하지 못하는 Excel 함수를 사용한다면, 해당 수식을 지원하는 스프레드시트 엔진으로 계산한 뒤 결과 값을 차트 워크북에 기록하십시오. 지원되지 않는 수식을 추측값으로 대신하지 마세요.

## **수식 오류 처리**

구분해야 할 두 가지 문제 유형이 있습니다.

수식이 유효하지만 `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!`와 같은 스프레드시트 오류 결과를 반환할 수 있습니다. 이 경우 오류 토큰이 셀 결과이며 `value`를 통해 반환됩니다.

수식이 구문, 참조, 의존성 또는 지원 데이터 수준에서 실패할 수도 있습니다. Aspose.Slides는 이러한 경우에 대해 스프레드시트 전용 예외를 제공합니다: [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), 및 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

템플릿이나 사용자 입력에서 수식이 제공되는 경우, 재계산 및 값 접근 주변에 이러한 예외를 처리하십시오:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **실용적인 제한 사항**

차트 워크시트에서의 수식 지원은 정의된 하위 집합을 위한 것이며, 전체 Excel 호환성을 목표로 하지 않습니다. 보고 워크플로우를 설계할 때 다음 제약을 염두에 두세요:

- Aspose.Slides가 수식을 다시 계산하도록 해야 할 경우, 문서화된 상수, 연산자, 참조 및 함수만 사용하십시오.
- 수식 결과가 의존하는 셀을 변경한 후 반드시 다시 계산하십시오.
- 로드된 프레젠테이션에서 얻은 캐시 값은 스냅샷이며, 편집 후 재계산을 대체하지 않습니다.
- 기존 템플릿의 수식을 테스트하여 계산된 값에 의존하기 전에 확인하십시오. 특히 문서화된 목록에 없는 함수를 사용하는 경우에 유의하세요.
- 전체 스프레드시트 계산 엔진이 필요한 수식은 외부에서 계산한 뒤 차트 워크북에 결과 값을 업데이트하십시오.

## **FAQ**

**`formula`와 `r1c1_formula`의 차이는 무엇인가요?**

[formula](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/formula/)은 `B2-C2`와 같은 A1 스타일 식을 저장합니다. [r1c1_formula](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)은 `RC[-2]-RC[-1]`와 같은 R1C1 스타일 식을 저장합니다. 생성하거나 복사하는 방식에 가장 적합한 표기법을 사용하세요.

**재계산 후 셀 자체를 읽어야 하나요, 아니면 값만 읽어야 하나요?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)은 `IChartDataCell`을 반환합니다. 재계산 후 해당 셀의 [value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/value/) 속성을 읽어 계산된 결과를 얻으세요.

**`calculate_formulas`는 언제 호출해야 하나요?**

입력 값이나 수식을 변경한 후, 계산된 결과에 의존하기 전에 [calculate_formulas](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)를 호출하십시오. 이렇게 하면 내장 평가기가 지원하는 수식의 값이 업데이트됩니다.

**Aspose.Slides가 모든 Excel 함수를 지원하나요?**

아니요. 내장 평가기는 문서화된 함수 하위 집합만 지원합니다. 그 외의 함수는 올바르게 재계산된다고 가정하지 마세요. 전체 Excel 수식 호환성이 필요하면 적절한 스프레드시트 엔진으로 계산하고 최종 값을 차트 워크북에 기록하십시오.

**로드된 프레젠테이션에 지원되지 않는 수식이 포함되어 있으면 어떻게 되나요?**

차트 데이터가 변경되지 않은 경우, 워크북에 이전에 계산된 캐시 값이 남아 있을 수 있습니다. 관련 데이터가 수정되면 해당 캐시 값은 더 이상 유효하지 않을 수 있습니다. 처리할 수 없는 수식을 가진 셀에 접근하면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)이 발생할 수 있습니다.

**수식 오류값이 Python 예외와 동일한가요?**

아니요. `#DIV/0!`와 같은 결과는 유효한 계산이 만든 스프레드시트 값입니다. [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/)이나 [CellCircularReferenceException](https://reference.aspose.com/slides/ko/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/)과 같은 예외는 수식을 정상적으로 처리할 수 없음을 나타냅니다.

**수식 셀을 변경하면 차트가 자동으로 업데이트되나요?**

차트 시리즈가 워크북 셀을 참조합니다. 먼저 워크북을 재계산한 뒤 프레젠테이션을 저장하거나 렌더링하면 차트는 업데이트된 셀 값을 사용합니다. 이 워크플로우에서는 별도의 차트 새로 고침 메서드가 필요하지 않습니다.

**차트가 외부 Excel 워크북을 사용할 수 있나요?**

예, 차트 데이터 API를 통해 외부 워크북을 사용할 수 있습니다. 하지만 이 문서에서 설명하는 수식 계산 워크플로우는 차트 데이터 워크북과 Aspose.Slides가 평가하는 수식 하위 집합에만 적용됩니다. [calculate_formulas](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)가 외부 XLSX 파일의 임의 수식을 완전히 재계산한다고 가정하지 마세요.

**다른 워크시트나 워크북을 참조하는 수식을 사용할 수 있나요?**

Excel 스타일 참조가 차트 워크북에 존재할 수 있지만, 수식 평가가 지원 파서와 함수 집합에 의해 제한됩니다. 교차 시트 또는 외부 참조가 필수라면 대상 Aspose.Slides 버전에서 해당 정확한 수식을 검증하십시오. 광범위한 Excel 참조 호환성이 필요한 경우 워크북을 외부에서 계산하고 해결된 값을 차트 데이터에 기록하십시오.

**수식 문자열을 `=` 로 시작해야 하나요?**

Aspose.Slides API 예제에서는 `B2-C2` 또는 `SUM(B2:B5)`와 같이 앞에 `=` 없이 식을 할당합니다. 이렇게 하면 생성된 수식이 문서화된 API 예제와 일치합니다.