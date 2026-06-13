---
title: JavaScript를 사용하여 프레젠테이션에서 차트 워크시트 수식 적용
linktitle: 워크시트 수식
type: docs
weight: 70
url: /ko/nodejs-java/chart-worksheet-formulas/
keywords:
- 차트 스프레드시트
- 차트 워크시트
- 차트 수식
- 워크시트 수식
- 스프레드시트 수식
- 데이터 원본
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript를 사용하여 Aspose.Slides for Node.js에서 Excel 스타일 수식을 차트 워크시트를 통해 적용하고 PPT 및 PPTX 파일의 보고서를 자동화합니다."
---
## **개요**

차트 워크시트는 프레젠테이션의 차트 뒤에 있는 데이터 원본입니다. 차트에 표시되는 숫자 값과 함께 범주 및 시리즈 이름을 저장합니다. Aspose.Slides에서 이 워크시트는 차트 데이터 워크북을 통해 사용할 수 있으며, 이를 통해 차트 데이터를 프로그래밍 방식으로 작업할 수 있습니다.

이 문서에서는 차트 데이터에서 워크시트 수식을 사용하는 방법을 설명합니다. 이를 통해 셀 값을 수동으로 입력하는 대신 자동으로 계산 및 업데이트할 수 있습니다. 수식 할당, A1 스타일 및 R1C1 스타일 참조 사용, 워크북 수식 재계산, 그리고 프레젠테이션의 차트 워크시트에서 사용할 수 있는 지원되는 상수, 연산자, 셀 참조 및 사전 정의 함수와 작업하는 방법을 보여줍니다.

## **프레젠테이션에서 차트 스프레드시트 수식에 대하여**
**Chart spreadsheet** (또는 chart worksheet)는 프레젠테이션에서 차트의 데이터 원본입니다. Chart spreadsheet는 차트에 그래픽 방식으로 표시되는 데이터를 포함합니다. PowerPoint에서 차트를 만들면 이 차트와 연결된 워크시트도 자동으로 생성됩니다. 차트 워크시트는 모든 차트 유형(라인 차트, 막대 차트, 선버스트 차트, 파이 차트 등)에서 생성됩니다. PowerPoint에서 차트 스프레드시트를 보려면 차트를 두 번 클릭하십시오:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet에는 차트 요소의 이름(카테고리 이름: *Category1*, 시리즈 이름)과 이러한 카테고리 및 시리즈에 해당하는 숫자 데이터 테이블이 포함됩니다. 기본적으로 새 차트를 만들면 차트 스프레드시트 데이터가 기본값으로 설정됩니다. 그런 다음 워크시트에서 스프레드시트 데이터를 수동으로 변경할 수 있습니다.

보통 차트는 복잡한 데이터를 나타내며(예: 재무 분석가, 과학 분석가), 다른 셀의 값이나 동적 데이터를 기반으로 계산된 셀을 가지고 있습니다. 셀 값을 수동으로 계산하여 하드코딩하면 향후 변경하기 어려워집니다. 특정 셀의 값을 변경하면 해당 셀에 의존하는 모든 셀도 업데이트되어야 합니다. 또한 테이블 데이터가 다른 테이블의 데이터에 의존할 수 있어 복잡한 프레젠테이션 데이터 스키마가 생성되며, 이를 쉽게 유연하게 업데이트할 필요가 있습니다.

프레젠테이션의 **Chart spreadsheet formula**는 차트 스프레드시트 데이터를 자동으로 계산하고 업데이트하는 표현식입니다. 스프레드시트 수식은 특정 셀 또는 셀 집합에 대한 데이터 계산 논리를 정의합니다. 스프레드시트 수식은 셀 참조, 수학 함수, 논리 연산자, 산술 연산자, 변환 함수, 문자열 상수 등을 사용하는 수학 수식 또는 논리 수식입니다. 수식 정의는 셀에 입력되며, 이 셀은 단순 값을 포함하지 않습니다. 스프레드시트 수식은 값을 계산하고 반환한 뒤, 해당 값이 셀에 할당됩니다. 프레젠테이션의 차트 스프레드시트 수식은 실제로 Excel 수식과 동일하며, 구현을 위해 동일한 기본 함수, 연산자 및 상수가 지원됩니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/nodejs-java/)에서 차트 스프레드시트는
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) 메서드로
[**ChartDataWorkbook**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataWorkbook) 타입과 연결됩니다.
스프레드시트 수식은 
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 메서드로 할당 및 변경할 수 있습니다.
Aspose.Slides에서 수식에 대해 지원되는 기능은 다음과 같습니다.

- 논리 상수
- 숫자 상수
- 문자열 상수
- 오류 상수
- 산술 연산자
- 비교 연산자
- A1-스타일 셀 참조
- R1C1-스타일 셀 참조
- 사전 정의 함수


일반적으로 스프레드시트는 마지막으로 계산된 수식 값을 저장합니다. 프레젠테이션 로드 후 차트 데이터가 변경되지 않은 경우 [**ChartDataCell.getValue**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataCell#getValue--) 메서드가 해당 값을 반환합니다. 그러나 스프레드시트 데이터가 변경된 경우 **ChartDataCell.Value** 속성을 읽을 때 지원되지 않는 수식에 대해 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CellUnsupportedDataException) 예외가 발생합니다. 이는 수식이 성공적으로 구문 분석될 때 셀 의존성이 결정되고 마지막 값의 정확성이 판단되기 때문이며, 수식이 구문 분석되지 않으면 셀 값의 정확성을 보장할 수 없기 때문입니다.

## **프레젠테이션에 차트 스프레드시트 수식 추가**
먼저 새 프레젠테이션의 첫 번째 슬라이드에 차트를 추가합니다  
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-) 메서드를 사용합니다. 차트의 워크시트가 자동으로 생성되며 다음 메서드로 접근할 수 있습니다.

[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) 메서드:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

셀에 값을 기록하려면 [**ChartDataCell.setValue**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) 속성을 사용합니다. 이 속성은 **Object** 형식이므로 어떤 값이든 설정할 수 있습니다:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

이제 셀에 수식을 작성하려면 [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 메서드를 사용할 수 있습니다:

*Note*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 메서드는 A1-스타일 셀 참조를 설정하는 데 사용됩니다. 

[R1C1Formula](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) 셀 참조를 설정하려면 [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) 메서드를 사용할 수 있습니다:

그런 다음 B2와 C2 셀의 값을 읽으면 계산된 결과가 반환됩니다:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **논리 상수**
셀 수식에서 *FALSE*와 *TRUE*와 같은 논리 상수를 사용할 수 있습니다:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// 값에 불리언 "false"가 포함됩니다
```

## **숫자 상수**
숫자는 일반 표기법 또는 과학적 표기법으로 차트 스프레드시트 수식에 사용할 수 있습니다:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **문자열 상수**
문자열(또는 리터럴) 상수는 그대로 사용되며 변경되지 않는 특정값입니다. 문자열 상수는 날짜, 텍스트, 숫자 등일 수 있습니다:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **오류 상수**
때로는 수식으로 결과를 계산할 수 없습니다. 이 경우 셀에 값 대신 오류 코드가 표시됩니다. 각 오류 유형마다 특정 코드가 있습니다:

- #DIV/0! - 수식이 0으로 나누기를 시도합니다.
- #GETTING_DATA - 값이 아직 계산 중일 때 셀에 표시될 수 있습니다.
- #N/A - 정보가 없거나 사용할 수 없습니다. 예: 수식에 사용된 셀이 비어 있거나, 불필요한 공백 문자, 오탈자 등이 원인입니다.
- #NAME? - 특정 셀이나 다른 수식 개체를 이름으로 찾을 수 없습니다. 
- #NULL! - 수식에 실수가 있을 때 발생할 수 있습니다(예: (,) 또는 콜론(:) 대신 공백 문자 사용).
- #NUM! - 수식의 숫자가 잘못되었거나 너무 크거나 작습니다.
- #REF! - 잘못된 셀 참조.
- #VALUE! - 예상치 못한 값 유형. 예를 들어 문자열 값을 숫자 셀에 넣은 경우.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// 값에 문자열 "#DIV/0!"이 포함됩니다
```

## **산술 연산자**
차트 워크시트 수식에서 모든 산술 연산자를 사용할 수 있습니다:

|**Operator** |**Meaning** |**Example**|
| :- | :- | :- |
|+ (plus sign) |덧셈 또는 단항 플러스|2 + 3|
|- (minus sign) |뺄셈 또는 부정 |2 - 3<br>-3|
|* (asterisk)|곱셈 |2 * 3|
|/ (forward slash)|나눗셈 |2 / 3|
|% (percent sign) |백분율 |30%|
|^ (caret) |거듭제곱 |2 ^ 3|

*Note*: 평가 순서를 변경하려면 먼저 계산할 부분을 괄호로 묶으십시오.

## **비교 연산자**
비교 연산자를 사용하여 셀 값을 비교할 수 있습니다. 이러한 연산자를 사용해 두 값을 비교하면 결과는 *TRUE* 또는 FALSE인 논리값이 됩니다:

|**Operator** |**Meaning** |**Meaning** |
| :- | :- | :- |
|= (equal sign) |동일|A2 = 3|
|<> (not equal sign) |다름|A2 <> 3|
|> (greater than sign) |크다|A2 > 3|
|>= (greater than or equal to sign)|크거나 같다|A2 >= 3|
|< (less than sign)|작다|A2 < 3|
|<= (less than or equal to sign)|작거나 같다|A2 <= 3|

## **A1-스타일 셀 참조**
**A1-스타일 셀 참조**는 열에 문자 식별자(예: "*A*")가, 행에 숫자 식별자(예: "*1*")가 있는 워크시트에서 사용됩니다. A1-스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute |Relative |Mixed|
|Cell |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Row |$2:$2 |2:2 |-|
|Column |$A:$A |A:A |-|
|Range |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


다음은 수식에서 A1-스타일 셀 참조를 사용하는 예시입니다:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-스타일 셀 참조**
**R1C1-스타일 셀 참조**는 행과 열 모두에 숫자 식별자가 있는 워크시트에서 사용됩니다. R1C1-스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute |Relative |Mixed|
|Cell |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row |R2|R[2]|-|
|Column |C3|C[3]|-|
|Range |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


다음은 수식에서 R1C1-스타일 셀 참조를 사용하는 예시입니다:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **사전 정의 함수**
수식에서 구현을 간소화하기 위해 사용할 수 있는 사전 정의 함수가 있습니다. 이러한 함수는 다음과 같은 가장 일반적으로 사용되는 작업을 캡슐화합니다:

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
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**외부 Excel 파일을 차트 수식의 데이터 원본으로 지원하나요?**

예. Aspose.Slides는 차트의 데이터 원본으로 외부 워크북을 지원합니다[chart's data source](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatasourcetype/), 이를 통해 프레젠테이션 외부의 XLSX 파일에서 수식을 사용할 수 있습니다.

**차트 수식이 동일 워크북 내의 시트 이름으로 시트를 참조할 수 있나요?**

예. 수식은 표준 Excel 참조 모델을 따르므로 동일 워크북 내의 다른 시트나 외부 워크북을 참조할 수 있습니다. 외부 참조의 경우 Excel 구문을 사용하여 경로와 워크북 이름을 포함하면 됩니다.