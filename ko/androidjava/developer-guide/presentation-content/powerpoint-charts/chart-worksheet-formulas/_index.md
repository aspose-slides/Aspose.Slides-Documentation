---
title: Android에서 프레젠테이션에 차트 워크시트 수식 적용
linktitle: 워크시트 수식
type: docs
weight: 70
url: /ko/androidjava/chart-worksheet-formulas/
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
- 미리 정의된 함수
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java 차트 워크시트를 통해 Android용 Aspose.Slides에서 Excel 스타일 수식을 적용하고 PPT 및 PPTX 파일 전반에 걸쳐 보고서를 자동화합니다."
---
## **개요**

차트 워크시트는 프레젠테이션의 차트 뒤에 있는 데이터 소스입니다. 차트에 표시되는 숫자 값과 함께 범주 및 시리즈 이름을 저장합니다. Aspose.Slides에서는 이 워크시트를 차트 데이터 워크북을 통해 사용할 수 있으며, 이를 통해 차트 데이터를 프로그래밍 방식으로 조작할 수 있습니다.

이 문서에서는 차트 데이터에서 워크시트 수식을 사용하는 방법을 설명합니다. 셀 값을 수동으로 입력하는 대신 자동으로 계산 및 업데이트할 수 있습니다. 수식 할당 방법, A1 스타일과 R1C1 스타일 참조 사용, 워크북 수식 재계산, 그리고 프레젠테이션의 차트 워크시트에서 지원되는 상수, 연산자, 셀 참조 및 미리 정의된 함수를 다루는 방법을 보여줍니다.

## **프레젠테이션에서 차트 스프레드시트 수식에 대하여**
**Chart spreadsheet**(또는 차트 워크시트)는 프레젠테이션에서 차트의 데이터 소스입니다. 차트 스프레드시트에는 차트에 그래픽 형태로 표시되는 데이터가 포함됩니다. PowerPoint에서 차트를 만들면 해당 차트와 연결된 워크시트가 자동으로 생성됩니다. 차트 워크시트는 모든 종류의 차트(라인 차트, 막대 차트, 선버스트 차트, 원형 차트 등)에서 생성됩니다. PowerPoint에서 차트 스프레드시트를 보려면 차트를 더블 클릭하십시오:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

차트 스프레드시트에는 차트 요소의 이름(범주 이름: *Category1*, 시리즈 이름)과 해당 범주 및 시리즈에 해당하는 숫자 데이터 표가 포함됩니다. 기본적으로 새 차트를 만들면 차트 스프레드시트 데이터가 기본 데이터로 설정됩니다. 이후 워크시트에서 스프레드시트 데이터를 수동으로 변경할 수 있습니다.

보통 차트는 복잡한 데이터(예: 재무 분석가, 과학 분석가)를 나타내며, 다른 셀의 값이나 동적 데이터에서 계산된 셀을 포함합니다. 셀 값을 수동으로 계산하여 하드코딩하면 향후 변경이 어려워집니다. 특정 셀의 값을 변경하면 그에 의존하는 모든 셀도 업데이트되어야 합니다. 또한 표 데이터가 다른 표의 데이터에 의존할 수 있어, 쉽게 유연하게 업데이트할 수 있는 복잡한 프레젠테이션 데이터 스키마가 생성됩니다.

프레젠테이션의 **Chart spreadsheet formula**은 차트 스프레드시트 데이터를 자동으로 계산하고 업데이트하는 식입니다. 스프레드시트 수식은 특정 셀 또는 셀 집합의 데이터 계산 논리를 정의합니다. 스프레드시트 수식은 셀 참조, 수학 함수, 논리 연산자, 산술 연산자, 변환 함수, 문자열 상수 등을 사용하는 수학 수식 또는 논리 수식입니다. 수식 정의는 셀에 기록되며, 해당 셀은 단순 값을 포함하지 않습니다. 스프레드시트 수식은 값을 계산해 반환하고, 그 값이 셀에 할당됩니다. 프레젠테이션의 차트 스프레드시트 수식은 실제로 엑셀 수식과 동일하며, 동일한 기본 함수, 연산자 및 상수를 지원합니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/androidjava/)에서 차트 스프레드시트는
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 메서드와
[**IChartDataWorkbook**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataWorkbook) 타입으로 표현됩니다.
스프레드시트 수식은 [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 메서드로 할당 및 변경할 수 있습니다.
Aspose.Slides에서 수식에 대해 지원되는 기능은 다음과 같습니다:

- 논리 상수
- 숫자 상수
- 문자열 상수
- 오류 상수
- 산술 연산자
- 비교 연산자
- A1 스타일 셀 참조
- R1C1 스타일 셀 참조
- 미리 정의된 함수

일반적으로 스프레드시트는 마지막으로 계산된 수식 값을 저장합니다. 프레젠테이션을 로드한 후 차트 데이터가 변경되지 않았다면 [**IChartDataCell.getValue**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataCell#getValue--) 메서드가 해당 값을 반환합니다. 하지만 스프레드시트 데이터가 변경된 경우 **ChartDataCell.Value** 속성을 읽을 때 지원되지 않는 수식에 대해 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/CellUnsupportedDataException) 예외가 발생합니다. 이는 수식이 성공적으로 파싱될 때 셀 종속성이 결정되고 마지막 값의 정확성이 확인되기 때문입니다. 그러나 수식을 파싱할 수 없으면 셀 값의 정확성을 보장할 수 없습니다.

## **프레젠테이션에 차트 스프레드시트 수식 추가**
먼저, 새 프레젠테이션의 첫 슬라이드에 차트를 추가합니다([IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-)). 차트의 워크시트가 자동으로 생성되며, [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 메서드로 접근할 수 있습니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

셀에 값을 쓰려면 **Object** 타입의 [**IChartDataCell.setValue**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) 속성을 사용합니다. 이는 속성에 任意 값을 설정할 수 있음을 의미합니다:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

이제 셀에 수식을 쓰려면 [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 메서드를 사용할 수 있습니다:

*Note*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 메서드는 A1 스타일 셀 참조를 설정하는 데 사용됩니다.

R1C1 스타일 셀 참조인 [R1C1Formula](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--)를 설정하려면 [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) 메서드를 사용할 수 있습니다:

그런 다음 B2와 C2 셀의 값을 읽으면 계산된 결과를 얻을 수 있습니다:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **논리 상수**
셀 수식에서 *FALSE*와 *TRUE*와 같은 논리 상수를 사용할 수 있습니다:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 값에는 boolean "false"가 포함됩니다
```

## **숫자 상수**
숫자는 일반 표기법 또는 과학 표기법으로 차트 스프레드시트 수식을 만들 때 사용할 수 있습니다:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **문자열 상수**
문자열(또는 리터럴) 상수는 그대로 사용되는 특정 값이며 변하지 않습니다. 문자열 상수는 날짜, 텍스트, 숫자 등일 수 있습니다:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **오류 상수**
때때로 수식으로 결과를 계산할 수 없습니다. 이 경우 셀에 값 대신 오류 코드가 표시됩니다. 각 오류 유형에는 특정 코드가 있습니다:

- #DIV/0! - 수식이 0으로 나누기를 시도합니다.
- #GETTING_DATA - 값이 아직 계산 중일 때 셀에 표시될 수 있습니다.
- #N/A - 정보가 없거나 사용할 수 없습니다. 원인으로는 수식에 사용된 셀이 비어 있거나, 공백 문자, 오타 등이 있습니다.
- #NAME? - 지정된 셀이나 다른 수식 객체를 이름으로 찾을 수 없습니다.
- #NULL! - 수식에 실수가 있을 때 나타날 수 있습니다(예: (,) 또는 콜론(:) 대신 공백 문자 사용).
- #NUM! - 수식의 숫자가 잘못되었거나, 너무 크거나 작을 수 있습니다.
- #REF! - 잘못된 셀 참조.
- #VALUE! - 예상치 못한 값 유형. 예: 문자열 값을 숫자 셀에 설정.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 값에 문자열 "#DIV/0!"이 포함됩니다
```

## **산술 연산자**
|**Operator**|**Meaning**|**Example**|
| :- | :- | :- |
|+ (plus sign)|덧셈 또는 단항 플러스|2 + 3|
|- (minus sign)|뺄셈 또는 부정|2 - 3<br>-3|
|* (asterisk)|곱셈|2 * 3|
|/ (forward slash)|나눗셈|2 / 3|
|% (percent sign)|퍼센트|30%|
|^ (caret)|거듭제곱|2 ^ 3|

*Note*: 평가 순서를 변경하려면 먼저 계산할 부분을 괄호로 감싸세요.

## **비교 연산자**
|**Operator**|**Meaning**|**Example**|
| :- | :- | :- |
|= (equal sign)|같음|A2 = 3|
|<> (not equal sign)|같지 않음|A2 <> 3|
|> (greater than sign)|크다|A2 > 3|
|>= (greater than or equal to sign)|크거나 같다|A2 >= 3|
|< (less than sign)|작다|A2 < 3|
|<= (less than or equal to sign)|작거나 같다|A2 <= 3|

## **A1 스타일 셀 참조**
**A1 스타일 셀 참조**는 열에 문자 식별자(예: "*A*")가 있고 행에 숫자 식별자(예: "*1*")가 있는 워크시트에서 사용됩니다. A1 스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||절대 |상대 |혼합|
|셀|$A$2|A2|<p>A$2</p><p>$A2</p>|
|행|$2:$2|2:2|-|
|열|$A:$A|A:A|-|
|범위|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1 스타일 셀 참조**
**R1C1 스타일 셀 참조**는 행과 열 모두에 숫자 식별자가 있는 워크시트에서 사용됩니다. R1C1 스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||절대 |상대 |혼합|
|셀|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|행|R2|R[2]|-|
|열|C3|C[3]|-|
|범위|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **미리 정의된 함수**
수식에서 구현을 간소화하기 위해 사용할 수 있는 미리 정의된 함수가 있습니다. 이러한 함수는 다음과 같은 가장 일반적으로 사용되는 연산을 포함합니다:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
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

**수식이 포함된 차트의 데이터 소스로 외부 Excel 파일을 지원합니까?**

예. Aspose.Slides는 차트의 [데이터 소스](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chartdatasourcetype/)로 외부 워크북을 지원하므로 프레젠테이션 외부의 XLSX 파일에서 수식을 사용할 수 있습니다.

**차트 수식이 동일 워크북 내의 시트명을 사용하여 다른 시트를 참조할 수 있습니까?**

예. 수식은 표준 Excel 참조 모델을 따르므로 동일 워크북 내 또는 외부 워크북의 다른 시트를 참조할 수 있습니다. 외부 참조의 경우 Excel 구문을 사용하여 경로와 워크북 이름을 포함합니다.