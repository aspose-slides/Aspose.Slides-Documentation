---
title: .NET에서 프레젠테이션에 차트 워크시트 수식 적용
linktitle: 워크시트 수식
type: docs
weight: 70
url: /ko/net/chart-worksheet-formulas/
keywords:
- 차트 스프레드시트
- 차트 워크시트
- 차트 수식
- 워크시트 수식
- 스프레드시트 수식
- 차트 데이터 워크북
- 수식 계산
- 선호 문화권
- 문화권 별 수식
- DBCS
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 차트 워크시트에서 Excel 스타일 수식을 적용하고, 값을 재계산하며, 결과를 PowerPoint 차트에 사용합니다."
---
## **개요**

PowerPoint 차트는 일반적으로 소스 데이터를 포함된 워크시트에 저장합니다. Aspose.Slides for .NET에서는 차트 데이터 워크북을 통해 해당 워크시트에 액세스하고, 입력 값을 기록하고, 셀에 수식을 할당하며, 지원되는 수식을 계산하고, 계산된 셀을 차트 데이터로 사용할 수 있습니다.

이 문서에서는 전체 수식 워크플로를 설명합니다: 차트를 만들고, 워크시트를 채우고, A1 스타일 또는 R1C1 스타일 수식을 할당하고, 재계산하고, 계산된 값을 읽고, 해당 셀을 차트 시리즈에 연결하고, 프레젠테이션을 저장합니다. 또한 지원되는 수식 구문, 내장 함수 하위 집합, 캐시된 값, 지원되지 않는 수식 및 스프레드시트 전용 오류에 대해서도 설명합니다.

## **차트 워크시트 및 수식**

차트 워크시트에는 차트에서 사용하는 카테고리, 시리즈 이름 및 값이 포함됩니다. PowerPoint에서는 차트 데이터 편집기를 열어 워크시트를 검사할 수 있습니다:

![PowerPoint 차트와 포함된 워크시트가 열려 있어 카테고리 및 시리즈 데이터를 표시함](chart-worksheet-formulas_1.png)

Aspose.Slides에서는 워크시트가 [차트 데이터 워크북](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/)을 통해 노출됩니다. A1 스타일 수식은 [Formula](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/formula/) 속성을 사용하고, R1C1 스타일 수식은 [R1C1Formula](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/r1c1formula/) 속성을 사용합니다. 입력 셀이나 수식을 변경한 후에는 [CalculateFormulas](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)을 호출하여 지원되는 수식을 재계산하고 해당 셀 값을 업데이트합니다.

계산된 셀은 여전히 ​​[Value](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/value/) 속성을 통해 결과를 노출합니다. 이는 코드에서 수식 결과를 검사하거나 셀을 차트 데이터 포인트로 사용할 때 중요합니다.

## **차트 만들기 및 워크시트 수식 계산**

다음 예제는 엔드‑투‑엔드 워크플로를 보여줍니다. 클러스터형 열 차트를 만들고, 샘플 데이터를 지우고, 분기별 매출 및 비용 값을 기록하고, 수식으로 이익을 계산하고, 결과를 읽고, 계산된 셀을 차트 값으로 사용하고, 프레젠테이션을 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

차트 데이터 포인트는 `D2:D4`를 참조하므로 차트는 계산된 이익 값을 사용합니다. 이 워크플로에는 별도의 차트 새로 고침 호출이 없습니다: 워크북을 먼저 재계산한 다음 계산된 셀을 가리키는 차트 데이터를 사용하거나 저장합니다.

## **A1 스타일 수식 사용**

A1 표기법은 열을 문자, 행을 숫자로 식별합니다. [IChartDataCell.Formula](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/formula/)를 통해 A1 스타일 식을 할당합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

일반적인 A1 참조 형태는 다음과 같습니다:

| 참조 | 상대 | 절대 | 혼합 |
|---|---|---|---|
| 셀 | `A2` | `$A$2` | `A$2`, `$A2` |
| 행 | `2:2` | `$2:$2` | — |
| 열 | `A:A` | `$A:$A` | — |
| 범위 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

상대 참조는 수식이 스프레드시트 애플리케이션에서 이동하거나 복사될 때 변경될 수 있습니다. 절대 참조는 두 좌표를 모두 고정하고, 혼합 참조는 행 또는 열만 고정합니다.

## **R1C1 스타일 수식 사용**

R1C1 표기법은 행과 열을 모두 숫자로 식별합니다. 상대 참조는 대괄호 안의 오프셋을 사용합니다. [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/r1c1formula/)를 통해 이 구문을 할당합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
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
| 문자열 | `"abc"`, `"2/3/2020 12:00"` | 문자열 리터럴은 수식 내부에서 큰따옴표로 둘러싸여야 합니다. |
| 오류 결과 | `#DIV/0!`, `#N/A`, `#REF!` | 유효한 수식이 정상 결과 대신 스프레드시트 오류값을 반환할 수 있습니다. |

다음 예제는 여러 상수 유형을 사용합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // 거짓
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
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

평가 순서를 명시하려면 괄호를 사용하십시오. 예: `(A2+B2)*C2`.

### **비교 연산자**

비교식은 논리값을 반환합니다.

| 연산자 | 의미 | 예시 |
|---|---|---|
| `=` | 같음 | `A2=3` |
| `<>` | 다름 | `A2<>3` |
| `>` | 큼 | `A2>3` |
| `>=` | 크거나 같음 | `A2>=3` |
| `<` | 작음 | `A2<3` |
| `<=` | 작거나 같음 | `A2<=3` |

## **지원되는 사전 정의 함수**

Aspose.Slides에는 차트 워크시트를 위한 내장 수식 평가기가 포함되어 있지만, 전체 Excel 계산 엔진은 아닙니다. 문서화된 함수 집합은 아래에 제한됩니다. 임의의 Excel 함수가 [CalculateFormulas](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)로 재계산될 수 있다고 가정하지 마세요.

| 함수 | 목적 또는 지원 형태 | 예시 |
|---|---|---|
| `ABS` | 절대값 | `ABS(A2)` |
| `AVERAGE` | 산술 평균 | `AVERAGE(B2:B5)` |
| `CEILING` | 지정 배수로 올림 | `CEILING(A2,5)` |
| `CHOOSE` | 인덱스로 값 선택 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 텍스트 값 연결 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 텍스트 값 연결 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 날짜 시스템 사용 | `DATE(2026,8,19)` |
| `DAYS` | 날짜 간 일수 반환 | `DAYS(B2,A2)` |
| `FIND` | 텍스트 내 텍스트 찾기 | `FIND("-",A2)` |
| `FINDB` | 바이트 기반 텍스트 검색 | `FINDB("a",A2)` |
| `IF` | 조건 결과 | `IF(A2>0,A2,0)` |
| `INDEX` | 참조 형태 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 벡터 형태 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 벡터 형태 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 최대값 | `MAX(B2:B5)` |
| `SUM` | 합계 | `SUM(B2:B5)` |
| `VLOOKUP` | 수직 조회 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

표에 표시된 제한이 중요합니다: `INDEX`는 참조 형태로 문서화되고, `LOOKUP`과 `MATCH`는 벡터 형태로 문서화됩니다. `DATE`는 1900 날짜 시스템을 사용합니다. 여기서 언급되지 않은 기능과 함수는 Aspose.Slides 수식 평가기가 지원하지 않는 것으로 처리해야 합니다.

## **선호 문화권을 사용한 수식 계산**

일부 차트 워크북 함수는 텍스트를 문화권 별 규칙에 따라 해석합니다. 이는 특히 DBCS(이중 바이트 문자 집합)를 사용하는 언어에 중요합니다. 이러한 수식을 올바르게 계산하려면 [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/)를 생성하고, [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/spreadsheetoptions/)를 통해 [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/ko/net/aspose.slides/ispreadsheetoptions/preferredculture/)를 설정한 다음 프레젠테이션을 로드합니다.

다음 예제는 일본 문화권을 선택하고, 구성된 로드 옵션으로 프레젠테이션을 연 다음, 각 차트 워크북에 대해 [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)를 호출합니다:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

선호 문화권은 프레젠테이션 로드 구성의 일부이므로 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 만들기 전에 지정해야 합니다. 워크북 수식에 기대되는 문화권을 사용하십시오; 예를 들어 일본어 DBCS 계산 규칙을 따라야 하는 경우 `ja-JP`를 사용합니다.

## **재계산 및 캐시된 값**

스프레드시트 파일은 일반적으로 수식과 마지막으로 계산된 값을 모두 저장합니다. Aspose.Slides는 프레젠테이션이 로드되고 관련 차트 데이터가 변경되지 않은 경우 [IChartDataCell.Value](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/value/)에서 캐시된 값을 읽을 수 있습니다.

입력 셀이나 수식을 변경한 후에는 오래된 캐시 결과에 의존하지 마세요. 계산된 값을 읽거나 해당 값을 사용하는 차트 데이터를 저장하기 전에 [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)를 호출하십시오.

지원 범위 밖의 수식은 Aspose.Slides가 수식을 파싱하거나 종속성을 설정하지 못할 수 있습니다. 워크북이 수정된 경우 이전 캐시 값은 더 이상 신뢰할 수 없습니다. 이 상황에서 지원되지 않는 데이터를 가진 셀의 값을 읽으면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)이 발생할 수 있습니다.

차트가 Aspose.Slides가 평가하지 않는 Excel 함수를 사용하는 경우, 해당 수식을 지원하는 스프레드시트 엔진으로 계산한 뒤 결과 값을 차트 워크북에 기록하십시오. 추측한 값으로 지원되지 않는 수식을 대체하지 마세요.

## **수식 오류 처리**

구분해야 할 두 가지 문제 유형이 있습니다.

수식이 유효하지만 `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!`와 같은 스프레드시트 오류 결과를 반환할 수 있습니다. 이 경우 오류 토큰은 셀 결과이며 `Value`를 통해 반환될 수 있습니다.

수식이 구문, 참조, 종속성 또는 지원 데이터 수준에서 실패할 수도 있습니다. Aspose.Slides는 이러한 경우에 대해 스프레드시트 전용 예외를 제공합니다: [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) .

템플릿이나 사용자 입력으로부터 수식이 제공되는 경우, 재계산 및 값 액세스 주변에 이러한 예외를 처리하십시오:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **실용적인 제한 사항**

차트 워크시트의 수식 지원은 전체 Excel 호환성을 목표로 하지 않는 정의된 하위 집합을 대상으로 합니다. 보고 워크플로를 설계할 때 다음 제약을 염두에 두세요:

- Aspose.Slides가 수식을 재계산하도록 하려면 문서화된 상수, 연산자, 참조 및 함수만 사용하십시오.
- 수식 결과가 의존하는 셀을 변경한 후 반드시 재계산하십시오.
- 로드된 프레젠테이션에서 가져온 캐시 값은 스냅샷이며, 편집 후 재계산을 대체하지 않습니다.
- 기존 템플릿의 수식을 테스트하여 특히 문서화되지 않은 함수가 사용된 경우 계산된 값에 의존하기 전에 확인하십시오.
- 전체 스프레드시트 계산 엔진이 필요한 수식은 외부에서 계산한 뒤 차트 워크북에 결과 값을 업데이트하십시오.

## **FAQ**

**`Formula`와 `R1C1Formula`의 차이는 무엇인가요?**

[Formula](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/formula/)은 `B2-C2`와 같은 A1 스타일 식을 저장합니다. [R1C1Formula](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/r1c1formula/)은 `RC[-2]-RC[-1]`와 같은 R1C1 스타일 식을 저장합니다. 수식을 생성하거나 복사하는 방식에 가장 적합한 표기법을 사용하세요.

**계산 후 셀 자체를 읽어야 하나요, 아니면 값만 읽어야 하나요?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/getcell/)은 `IChartDataCell`을 반환합니다. 재계산 후 해당 셀의 [Value](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/value/) 속성을 읽어 계산된 결과를 얻으세요.

**`CalculateFormulas`를 언제 호출해야 하나요?**

입력 값이나 수식을 변경한 후, 계산 결과에 의존하기 전에 [CalculateFormulas](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)를 호출하십시오. 이는 내장 평가기가 지원하는 수식의 값을 업데이트합니다.

**Aspose.Slides가 모든 Excel 함수를 지원하나요?**

아니요. 내장 평가기는 문서화된 하위 집합만 지원합니다. 해당 집합에 포함되지 않은 함수는 올바르게 재계산된다고 가정하지 마세요. 전체 Excel 수식 호환성이 필요하면 적절한 스프레드시트 엔진으로 계산하고 최종 값을 차트 워크북에 기록하십시오.

**로드된 프레젠테이션에 지원되지 않는 수식이 포함되어 있으면 어떻게 되나요?**

차트 데이터가 변경되지 않은 경우 워크북에 이전에 계산된 캐시 값이 남아 있을 수 있습니다. 관련 데이터가 수정된 후에는 해당 캐시 값이 더 이상 유효하지 않을 수 있습니다. 처리할 수 없는 수식이 있는 셀에 접근하면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)이 발생할 수 있습니다.

**수식 오류 값이 .NET 예외와 동일한가요?**

아니요. `#DIV/0!`와 같은 결과는 유효한 계산이 만들어낸 스프레드시트 값입니다. [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellinvalidformulaexception/)이나 [CellCircularReferenceException](https://reference.aspose.com/slides/ko/net/aspose.slides.spreadsheet/cellcircularreferenceexception/)와 같은 예외는 수식을 정상적으로 처리할 수 없음을 나타냅니다.

**수식 셀이 변경될 때 차트가 자동으로 업데이트되나요?**

차트 시리즈는 워크북 셀을 참조할 수 있습니다. 먼저 워크북을 재계산하고 프레젠테이션을 저장하거나 렌더링하십시오. 차트 데이터 포인트가 계산된 셀을 참조하고 있다면 차트는 업데이트된 셀 값을 사용합니다; 별도의 차트 새로 고침 메서드는 필요하지 않습니다.

**차트가 외부 Excel 워크북을 사용할 수 있나요?**

예, 차트 데이터는 차트 데이터 API를 통해 외부 워크북을 사용하도록 구성할 수 있습니다. 하지만 이 문서에서 설명하는 수식 계산 워크플로는 차트 데이터 워크북과 Aspose.Slides가 평가하는 수식 하위 집합에만 적용됩니다. [CalculateFormulas](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)가 외부 XLSX 파일의 임의 수식을 전체 재계산한다는 가정은 하지 마세요.

**다른 워크시트나 워크북을 참조하는 수식을 사용할 수 있나요?**

Excel 스타일 참조가 차트 워크북에 존재할 수 있지만, 수식 평가가 지원되는 파서와 함수 집합에 의해 제한됩니다. 교차 시트 또는 외부 참조가 필수인 경우, 사용 중인 Aspose.Slides 버전에서 정확히 해당 수식을 검증하십시오. 광범위한 Excel 참조 호환성이 필요한 워크플로는 워크북을 외부에서 계산하고 결과 값을 차트 데이터에 다시 기록하는 것이 좋습니다.

**수식 문자열은 `=` 로 시작해야 하나요?**

Aspose.Slides API 예제에서는 `B2-C2` 또는 `SUM(B2:B5)`와 같이 앞에 `=` 없이 식을 할당합니다. 이러한 형태를 사용하면 생성된 수식이 문서화된 API 예제와 일관됩니다.