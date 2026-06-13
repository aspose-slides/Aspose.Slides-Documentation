---
title: ".NET에서 프레젠테이션에 차트 워크시트 수식 적용"
linktitle: "워크시트 수식"
type: docs
weight: 70
url: /ko/net/chart-worksheet-formulas/
keywords:
- 차트 스프레드시트
- 차트 워크시트
- 차트 수식
- 워크시트 수식
- 스프레드시트 수식
- 데이터 소스
- 논리 상수
- 숫자 상수
- 문자열 상수
- 오류 상수
- 산술 상수
- 비교 연산자
- A1 스타일
- R1C1 스타일
- 사전 정의 함수
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 차트 워크시트에서 Excel 스타일 수식을 적용하고 PPT 및 PPTX 파일 전반에 걸쳐 보고서를 자동화합니다."
---
## **개요**

차트 워크시트는 프레젠테이션의 차트 뒤에 있는 데이터 소스입니다. 카테고리 및 시리즈 이름과 차트에 표시되는 숫자 값을 함께 저장합니다. Aspose.Slides에서 이 워크시트는 차트 데이터 워크북을 통해 제공되며, 차트 데이터를 프로그래밍 방식으로 작업할 수 있게 합니다.

이 문서에서는 차트 데이터에서 워크시트 수식을 사용하여 셀 값을 수동으로 입력하는 대신 자동으로 계산하고 업데이트하는 방법을 설명합니다. 수식을 할당하고, A1 스타일 및 R1C1 스타일 참조를 모두 사용하고, 워크북 수식을 다시 계산하고, 프레젠테이션의 차트 워크시트에서 지원되는 상수, 연산자, 셀 참조 및 사전 정의 함수와 작업하는 방법을 보여줍니다.

## **프레젠테이션에서 차트 스프레드시트 수식에 대해**
프레젠테이션의 **차트 스프레드시트**(또는 차트 워크시트)는 차트의 데이터 소스입니다. 차트 스프레드시트에는 차트에 그래픽 형태로 표시되는 데이터가 들어 있습니다. PowerPoint에서 차트를 만들면 이 차트와 연결된 워크시트가 자동으로 생성됩니다. 차트 워크시트는 모든 차트 유형에 대해 생성됩니다: 꺾은선 차트, 막대 차트, 썬버스트 차트, 원형 차트 등. PowerPoint에서 차트 스프레드시트를 보려면 차트를 더블 클릭하면 됩니다:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

차트 스프레드시트에는 차트 요소의 이름(카테고리 이름: *Category1*, 시리즈 이름)과 해당 카테고리 및 시리즈에 맞는 숫자 데이터 테이블이 포함됩니다. 기본적으로 새로운 차트를 만들면 차트 스프레드시트 데이터가 기본 데이터로 설정됩니다. 그런 다음 워크시트의 데이터를 수동으로 변경할 수 있습니다.

보통 차트는 복잡한 데이터를 나타내며(예: 재무 분석가, 과학 분석가), 다른 셀의 값이나 동적 데이터에서 계산된 셀을 포함합니다. 셀 값을 수동으로 계산하여 셀에 하드코딩하면 향후 변경하기 어려워집니다. 특정 셀의 값을 변경하면 해당 셀에 의존하는 모든 셀이 업데이트되어야 합니다. 또한 테이블 데이터가 다른 테이블의 데이터에 의존할 수 있어, 복잡한 프레젠테이션 데이터 스키마가 쉽게 유연하게 업데이트될 필요가 있습니다.

프레젠테이션의 **차트 스프레드시트 수식**은 차트 스프레드시트 데이터를 자동으로 계산하고 업데이트하는 표현식입니다. 스프레드시트 수식은 특정 셀 또는 셀 집합에 대한 데이터 계산 논리를 정의합니다. 스프레드시트 수식은 셀 참조, 수학 함수, 논리 연산자, 산술 연산자, 변환 함수, 문자열 상수 등을 사용하는 수학 수식 또는 논리 수식입니다. 수식 정의는 셀에 기록되며, 이 셀은 단순 값을 포함하지 않습니다. 스프레드시트 수식은 값을 계산해 반환하고, 이 값이 셀에 할당됩니다. 프레젠테이션의 차트 스프레드시트 수식은 실제로 Excel 수식과 동일하며, 구현을 위해 동일한 기본 함수, 연산자 및 상수가 지원됩니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/net/)에서 차트 스프레드시트는  
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) 속성의  
[**IChartDataWorkbook**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook) 타입으로 표시됩니다.  
스프레드시트 수식은  
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/properties/formula) 속성을 통해 할당 및 변경할 수 있습니다.  
Aspose.Slides에서 수식에 대해 지원되는 기능은 다음과 같습니다:

- 논리 상수
- 숫자 상수
- 문자열 상수
- 오류 상수
- 산술 연산자
- 비교 연산자
- A1 스타일 셀 참조
- R1C1 스타일 셀 참조
- 사전 정의 함수

일반적으로 스프레드시트는 마지막으로 계산된 수식 값을 저장합니다. 프레젠테이션 로드 후 차트 데이터가 변경되지 않았다면 **IChartDataCell.Value** 속성이 해당 값을 반환합니다. 그러나 스프레드시트 데이터가 변경된 경우 **ChartDataCell.Value** 속성을 읽을 때 지원되지 않는 수식에 대해 **CellUnsupportedDataException**이 발생합니다. 이는 수식이 성공적으로 구문 분석될 때 셀 종속성이 결정되고 마지막 값의 정확성이 판단되기 때문이며, 구문 분석이 실패하면 셀 값의 정확성을 보장할 수 없기 때문입니다.

## **프레젠테이션에 차트 스프레드시트 수식 추가**
먼저 새 프레젠테이션의 첫 번째 슬라이드에  
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/addchart/methods/1)  
메서드를 사용해 샘플 데이터가 포함된 차트를 추가합니다. 차트의 워크시트는 자동으로 생성되며 다음 속성을 통해 접근할 수 있습니다:  
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) :

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}
```

다음과 같이 **Object** 타입의  
[**IChartDataCell.Value**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/properties/value)  
속성을 사용해 셀에 값을 기록할 수 있습니다(어떤 값이든 설정 가능):

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

이제 셀에 수식을 기록하려면  
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/properties/formula)  
속성을 사용할 수 있습니다:

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Note*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/properties/formula) 속성은 A1 스타일 셀 참조를 설정하는 데 사용됩니다.

R1C1 스타일 셀 참조를 설정하려면 [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) 속성을 사용할 수 있습니다:

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

그런 다음 [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) 메서드를 사용해 워크북 내 모든 수식을 계산하고 해당 셀 값을 업데이트합니다:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **논리 상수**
셀 수식에서 *FALSE*와 *TRUE*와 같은 논리 상수를 사용할 수 있습니다:

## **숫자 상수**
숫자는 일반 표기 또는 과학적 표기로 차트 스프레드시트 수식을 만들 때 사용할 수 있습니다:

## **문자열 상수**
문자열(리터럴) 상수는 그대로 사용되는 특정 값이며 변경되지 않습니다. 문자열 상수는 날짜, 텍스트, 숫자 등일 수 있습니다:

## **오류 상수**
때때로 수식으로 결과를 계산할 수 없을 때 오류 코드가 셀에 값 대신 표시됩니다. 각 오류 유형에는 고유한 코드가 있습니다:

- #DIV/0! - 수식이 0으로 나누려 할 때.
- #GETTING_DATA - 값이 아직 계산 중일 때 셀에 표시될 수 있습니다.
- #N/A - 정보가 없거나 사용할 수 없습니다. 예: 수식에 사용된 셀이 비어 있거나, 공백 문자, 철자 오류 등.
- #NAME? - 특정 셀이나 다른 수식 개체를 이름으로 찾을 수 없을 때.
- #NULL! - 수식에 실수가 있을 때, 예: (,) 혹은 콜론(:) 대신 공백 문자를 사용한 경우.
- #NUM! - 수식의 숫자가 잘못되었거나 너무 크거나 작을 때.
- #REF! - 잘못된 셀 참조.
- #VALUE! - 예상하지 못한 값 유형. 예: 문자열 값을 숫자 셀에 넣은 경우.

## **산술 연산자**
차트 워크시트 수식에서 모든 산술 연산자를 사용할 수 있습니다:

|**연산자**|**의미**|**예시**|
| :- | :- | :- |
|+ (플러스)|덧셈 또는 단항 플러스|2 + 3|
|- (마이너스)|뺄셈 또는 부정|2 - 3<br>-3|
|* (곱셈)|곱하기|2 * 3|
|/ (슬래시)|나누기|2 / 3|
|% (퍼센트)|백분율|30%|
|^ (캐럿)|거듭제곱|2 ^ 3|

*Note*: 평가 순서를 바꾸려면 먼저 계산할 부분을 괄호로 감싸세요.

## **비교 연산자**
비교 연산자를 사용해 셀 값을 비교할 수 있습니다. 이 연산자를 사용해 두 값을 비교하면 결과는 *TRUE* 또는 FALSE라는 논리 값이 됩니다:

|**연산자**|**의미**|**예시**|
| :- | :- | :- |
|= (등호)|같음|A2 = 3|
|<> (불일치)|다름|A2 <> 3|
|> (초과)|보다 큼|A2 > 3|
|>= (이상)|크거나 같음|A2 >= 3|
|< (미만)|보다 작음|A2 < 3|
|<= (이하)|작거나 같음|A2 <= 3|

## **A1 스타일 셀 참조**
**A1 스타일 셀 참조**는 열에 문자 식별자(예: "*A*")가, 행에 숫자 식별자(예: "*1*")가 있는 워크시트에서 사용됩니다. A1 스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**셀 참조**|**예시**| | |
| :- | :- | :- | :- |
| |절대|상대|혼합|
|셀|$A$2|A2|<p>A$2</p><p>$A2</p>|
|행|$2:$2|2:2|-|
|열|$A:$A|A:A|-|
|범위|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

다음은 수식에서 A1 스타일 셀 참조를 사용하는 예시입니다:

## **R1C1 스타일 셀 참조**
**R1C1 스타일 셀 참조**는 행과 열 모두 숫자 식별자를 갖는 워크시트에서 사용됩니다. R1C1 스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**셀 참조**|**예시**| | |
| :- | :- | :- | :- |
| |절대|상대|혼합|
|셀|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|행|R2|R[2]|-|
|열|C3|C[3]|-|
|범위|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

다음은 수식에서 R1C1 스타일 셀 참조를 사용하는 예시입니다:

## **사전 정의 함수**
수식에서 구현을 단순화하기 위해 사용할 수 있는 사전 정의 함수가 있습니다. 이러한 함수는 다음과 같은 가장 일반적으로 사용되는 작업을 캡슐화합니다:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 날짜 시스템)
- DAYS
- FIND
- FINDB
- IF
- INDEX (참조 형태)
- LOOKUP (벡터 형태)
- MATCH (벡터 형태)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**외부 Excel 파일을 차트 수식의 데이터 소스로 사용할 수 있나요?**

예. Aspose.Slides는 [차트의 데이터 소스](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdatasourcetype/)로 외부 워크북을 지원하므로 프레젠테이션 외부의 XLSX 파일에서 수식을 사용할 수 있습니다.

**차트 수식이 같은 워크북 내의 시트 이름으로 시트를 참조할 수 있나요?**

예. 수식은 표준 Excel 참조 모델을 따르므로 같은 워크북 내의 다른 시트나 외부 워크북을 참조할 수 있습니다. 외부 참조의 경우 Excel 구문을 사용해 경로와 워크북 이름을 포함하면 됩니다.