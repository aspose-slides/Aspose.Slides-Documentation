---
title: PHP를 사용하여 프레젠테이션에 차트 워크시트 수식 적용
linktitle: 워크시트 수식
type: docs
weight: 70
url: /ko/php-java/chart-worksheet-formulas/
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
- PHP
- Aspose.Slides
description: "PHP용 Aspose.Slides에서 Java 차트 워크시트를 통해 Excel 스타일 수식을 적용하고 PPT 및 PPTX 파일에 걸쳐 보고서를 자동화합니다."
---
## **개요**

차트 워크시트는 프레젠테이션의 차트 뒤에 있는 데이터 소스입니다. 차트에 표시되는 수치값과 함께 카테고리 및 시리즈 이름을 저장합니다. Aspose.Slides에서는 이 워크시트를 차트 데이터 워크북을 통해 사용할 수 있으며, 차트 데이터를 프로그래밍 방식으로 조작할 수 있습니다.

이 문서에서는 차트 데이터에서 워크시트 수식을 사용하는 방법을 설명합니다. 셀 값을 수동으로 입력하는 대신 자동으로 계산하고 업데이트하도록 할 수 있습니다. 수식 할당, A1 스타일 및 R1C1 스타일 참조 사용, 워크북 수식 재계산, 차트 워크시트에서 지원되는 상수·연산자·셀 참조·사전 정의 함수 등을 다룹니다.

## **프레젠테이션의 차트 스프레드시트 수식에 대해**
프레젠테이션의 **차트 스프레드시트**(또는 차트 워크시트)는 차트의 데이터 소스입니다. 차트 스프레드시트에는 차트에 그래픽 형태로 표시되는 데이터가 들어 있습니다. PowerPoint에서 차트를 만들면 해당 차트와 연결된 워크시트가 자동으로 생성됩니다. 차트 워크시트는 라인 차트, 막대 차트, 선버스트 차트, 파이 차트 등 모든 차트 유형에 대해 생성됩니다. PowerPoint에서 차트 스프레드시트를 보려면 차트를 더블 클릭하십시오.

![todo:image_alt_text](chart-worksheet-formulas_1.png)

차트 스프레드시트에는 차트 요소 이름(카테고리 이름: *Category1*, 시리즈 이름)과 이러한 카테고리·시리즈에 해당하는 숫자 데이터 표가 포함됩니다. 새 차트를 만들면 기본 데이터가 차트 스프레드시트에 설정됩니다. 이후 워크시트에서 데이터를 수동으로 변경할 수 있습니다.

보통 차트는 복잡한 데이터를 나타내며(예: 재무 분석, 과학 분석) 다른 셀 값이나 동적 데이터에서 계산된 셀을 포함합니다. 셀 값을 수동으로 계산하여 하드코딩하면 향후 변경이 어려워집니다. 특정 셀 값을 변경하면 해당 셀에 의존하는 모든 셀도 업데이트되어야 합니다. 또한 표 데이터가 다른 표의 데이터에 의존하여, 쉽게 그리고 유연하게 업데이트할 수 있는 복합적인 프레젠테이션 데이터 스키마를 만들게 됩니다.

프레젠테이션의 **차트 스프레드시트 수식**은 차트 스프레드시트 데이터를 자동으로 계산·업데이트하도록 하는 식입니다. 수식은 특정 셀 또는 셀 집합의 데이터 계산 로직을 정의합니다. 수식은 셀 참조, 수학 함수, 논리 연산자, 산술 연산자, 변환 함수, 문자열 상수 등을 사용한 수학식 또는 논리식입니다. 수식 정의는 셀에 기록되며, 해당 셀은 단순 값을 갖지 않습니다. 수식이 값을 계산해 반환하면 그 값이 셀에 할당됩니다. 차트 스프레드시트 수식은 실제로 엑셀 수식과 동일하며, 구현을 위해 동일한 기본 함수·연산자·상수가 지원됩니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/php-java/)에서 차트 스프레드시트는
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/#getChartDataWorkbook) 메서드로 표현됩니다.
스프레드시트 수식은  
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/#setFormula) 메서드로 할당·변경할 수 있습니다.
Aspose.Slides에서 수식에 대해 지원되는 기능은 다음과 같습니다.

- 논리 상수
- 숫자 상수
- 문자열 상수
- 오류 상수
- 산술 연산자
- 비교 연산자
- A1 스타일 셀 참조
- R1C1 스타일 셀 참조
- 사전 정의 함수

보통 스프레드시트는 마지막으로 계산된 수식 값을 저장합니다. 프레젠테이션을 로드한 후 차트 데이터가 변경되지 않았다면 [**ChartDataCell::getValue**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/#getValue) 메서드가 해당 값을 반환합니다. 그러나 스프레드시트 데이터가 변경된 경우 값을 읽는 중에 지원되지 않는 수식에 대해 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/CellUnsupportedDataException)이 발생합니다. 이는 수식이 성공적으로 구문 분석될 때 셀 의존성이 결정되고 마지막 값의 정확성이 확인되기 때문이며, 구문 분석에 실패하면 셀 값의 정확성을 보장할 수 없기 때문입니다.

## **프레젠테이션에 차트 스프레드시트 수식 추가**
먼저 새 프레젠테이션의 첫 번째 슬라이드에  
[ShapeCollection::addChart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addChart)  
메서드를 사용하여 차트를 추가합니다. 차트의 워크시트가 자동으로 생성되며, 다음 메서드로 접근할 수 있습니다.  

[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/#getChartDataWorkbook)

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

셀에 값을 쓰려면 **Object** 형식의 [**ChartDataCell::setValue**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/#setValue) 메서드를 사용합니다. 이는 모든 유형의 값을 설정할 수 있음을 의미합니다.

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

이제 셀에 수식을 쓰려면 [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/#setFormula) 메서드를 사용하면 됩니다.

*Note*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/#setFormula) 메서드는 A1 스타일 셀 참조를 설정할 때 사용됩니다.

R1C1 스타일 수식을 설정하려면 [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 메서드를 사용합니다.

그 후 셀 B2와 C2의 값을 읽으면 자동으로 계산됩니다.

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **논리 상수**
셀 수식에서 *FALSE*와 *TRUE*와 같은 논리 상수를 사용할 수 있습니다.

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// 값에 불리언 "false"가 포함됩니다
```

## **숫자 상수**
숫자는 일반 표기법 또는 과학적 표기법으로 차트 스프레드시트 수식에 사용할 수 있습니다.

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **문자열 상수**
문자열(리터럴) 상수는 그대로 사용되는 특정 값이며 변하지 않습니다. 문자열 상수는 날짜, 텍스트, 숫자 등을 포함할 수 있습니다.

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **오류 상수**
때때로 수식으로 결과를 계산할 수 없을 때 오류 코드가 셀에 표시됩니다. 각 오류 유형마다 고유한 코드가 있습니다.

- #DIV/0! - 수식이 0으로 나누려 할 때.
- #GETTING_DATA - 값이 아직 계산 중일 때 셀에 표시될 수 있습니다.
- #N/A - 정보가 없거나 사용 불가능할 때. 예: 수식에 사용된 셀이 비어 있거나, 여분의 공백 문자, 오타 등.
- #NAME? - 특정 셀이나 다른 수식 객체를 이름으로 찾지 못했을 때.
- #NULL! - 수식에 오류가 있을 때 발생합니다(예: (,) 혹은 콜론(:) 대신 공백 문자 사용).
- #NUM! - 수식에 숫자가 잘못되었을 때(너무 길거나 너무 짧음 등).
- #REF! - 잘못된 셀 참조.
- #VALUE! - 예상치 못한 값 유형. 예: 문자열 값을 숫자 셀에 할당한 경우.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// 값에 문자열 "#DIV/0!"가 포함됩니다


```

## **산술 연산자**
차트 워크시트 수식에서 모든 산술 연산자를 사용할 수 있습니다.

|**연산자**|**의미**|**예시**|
| :- | :- | :- |
|+ (플러스)|덧셈 또는 단항 플러스|2 + 3|
|- (마이너스)|뺄셈 또는 부정|2 - 3<br>-3|
|* (별표)|곱셈|2 * 3|
|/ (슬래시)|나눗셈|2 / 3|
|% (퍼센트)|백분율|30%|
|^ (캐럿)|거듭제곱|2 ^ 3|

*Note*: 계산 순서를 바꾸려면 먼저 계산할 부분을 괄호로 감싸십시오.

## **비교 연산자**
비교 연산자를 사용하면 셀 값들을 비교할 수 있습니다. 두 값을 비교한 결과는 *TRUE* 또는 FALSE라는 논리값이 됩니다.

|**연산자**|**의미**|**예시**|
| :- | :- | :- |
|= (등호)|같음|A2 = 3|
|<> (불일치)|같지 않음|A2 <> 3|
|> (보다 큼)|보다 큼|A2 > 3|
|>= (보다 크거나 같음)|보다 크거나 같음|A2 >= 3|
|< (보다 작음)|보다 작음|A2 < 3|
|<= (보다 작거나 같음)|보다 작거나 같음|A2 <= 3|

## **A1-스타일 셀 참조**
**A1-스타일 셀 참조**는 열이 문자 식별자(예: "*A*")이고 행이 숫자 식별자(예: "*1*")인 워크시트에 사용됩니다. A1-스타일 셀 참조는 다음과 같이 사용할 수 있습니다.

|**셀 참조**|**예시**|||
| :- | :- | :- | :- |
||절대|상대|혼합|
|셀|$A$2|A2|<p>A$2</p><p>$A2</p>|
|행|$2:$2|2:2|‑|
|열|$A:$A|A:A|‑|
|범위|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

다음은 A1-스타일 셀 참조를 수식에 사용하는 예시입니다.

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **R1C1-스타일 셀 참조**
**R1C1-스타일 셀 참조**는 행과 열 모두 숫자 식별자를 갖는 워크시트에 사용됩니다. R1C1-스타일 셀 참조는 다음과 같이 사용할 수 있습니다.

|**셀 참조**|**예시**|||
| :- | :- | :- | :- |
||절대|상대|혼합|
|셀|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|행|R2|R[2]|‑|
|열|C3|C[3]|‑|
|범위|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


다음은 R1C1-스타일 셀 참조를 수식에 사용하는 예시입니다.

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **사전 정의 함수**
수식에서 구현을 단순화하기 위해 사용할 수 있는 사전 정의 함수가 있습니다. 일반적으로 많이 사용되는 작업을 캡슐화합니다.

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

**외부 Excel 파일을 차트의 데이터 소스로 사용하고 수식을 적용할 수 있나요?**

예. Aspose.Slides는 외부 워크북을 [차트 데이터 소스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdatasourcetype/)로 지원하므로 프레젠테이션 외부의 XLSX 파일에서 수식을 사용할 수 있습니다.

**차트 수식이 동일 워크북 내의 시트명을 이용해 다른 시트를 참조할 수 있나요?**

예. 수식은 표준 Excel 참조 모델을 따르므로 동일 워크북 또는 외부 워크북의 다른 시트를 참조할 수 있습니다. 외부 참조의 경우 Excel 구문을 사용해 경로와 워크북 이름을 포함하면 됩니다.