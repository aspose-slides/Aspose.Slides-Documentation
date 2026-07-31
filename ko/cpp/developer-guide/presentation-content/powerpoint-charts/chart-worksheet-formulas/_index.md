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
- 데이터 소스
- 논리 상수
- 수치 상수
- 문자열 상수
- 오류 상수
- 산술 상수
- 비교 연산자
- A1 스타일
- R1C1 스타일
- 미리 정의된 함수
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides의 C++ 차트 워크시트에서 Excel 스타일 수식을 적용하고 PPT 및 PPTX 파일의 보고서를 자동화합니다."
---
## **개요**

차트 워크시트는 프레젠테이션에 있는 차트 뒤에 있는 데이터 소스입니다. 차트에 표시되는 숫자 값과 함께 카테고리 및 시리즈 이름을 저장합니다. Aspose.Slides에서는 차트 데이터 워크북을 통해 이 워크시트를 사용할 수 있으며, 이를 통해 차트 데이터를 프로그래밍 방식으로 작업할 수 있습니다.

이 문서는 차트 데이터에서 워크시트 수식을 사용하는 방법을 설명합니다. 셀 값을 수동으로 입력하는 대신 자동으로 계산하고 업데이트하도록 할 수 있습니다. 수식 지정, A1 스타일 및 R1C1 스타일 참조 사용, 워크북 수식 재계산, 프레젠테이션 차트 워크시트에서 지원되는 상수, 연산자, 셀 참조 및 미리 정의된 함수에 대해 다룹니다.

## **프레젠테이션에서 차트 스프레드시트 수식에 대해**
프레젠테이션의 **차트 스프레드시트**(또는 차트 워크시트)는 차트의 데이터 소스입니다. 차트 스프레드시트는 차트에 그래픽 형태로 표시되는 데이터를 포함합니다. PowerPoint에서 차트를 만들면 해당 차트와 연결된 워크시트도 자동으로 생성됩니다. 차트 워크시트는 라인 차트, 막대 차트, 썬버스트 차트, 파이 차트 등 모든 차트 유형에 대해 생성됩니다. PowerPoint에서 차트 스프레드시트를 보려면 차트를 더블 클릭하면 됩니다:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

차트 스프레드시트에는 차트 요소 이름(카테고리 이름: *Category1*, 시리즈 이름)과 이러한 카테고리 및 시리즈에 해당하는 숫자 데이터 테이블이 들어 있습니다. 기본적으로 새 차트를 만들면 차트 스프레드시트 데이터가 기본값으로 설정됩니다. 그런 다음 워크시트에서 스프레드시트 데이터를 수동으로 변경할 수 있습니다.

보통 차트는 복잡한 데이터를 나타내며(예: 재무 분석가, 과학 연구자) 다른 셀의 값이나 동적 데이터에서 계산된 셀을 포함합니다. 셀 값을 수동으로 계산하고 하드코딩하면 이후에 변경하기 어려워집니다. 특정 셀의 값을 변경하면 해당 셀에 의존하는 모든 셀도 업데이트되어야 합니다. 또한 테이블 데이터가 다른 테이블의 데이터에 의존할 수 있어, 쉽게 유연하게 업데이트해야 하는 복잡한 프레젠테이션 데이터 구조가 만들어집니다.

프레젠테이션의 **차트 스프레드시트 수식**은 차트 스프레드시트 데이터를 자동으로 계산하고 업데이트하는 표현식입니다. 스프레드시트 수식은 특정 셀 또는 셀 집합에 대한 데이터 계산 논리를 정의합니다. 수식은 셀 참조, 수학 함수, 논리 연산자, 산술 연산자, 변환 함수, 문자열 상수 등을 사용합니다. 수식 정의는 셀에 작성되며, 해당 셀은 단순 값을 포함하지 않습니다. 스프레드시트 수식은 값을 계산해 반환하고, 이 값이 셀에 할당됩니다. 프레젠테이션의 차트 스프레드시트 수식은 실제로 엑셀 수식과 동일하며, 구현을 위해 동일한 기본 함수, 연산자 및 상수가 지원됩니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/cpp/)에서 차트 스프레드시트는  
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 메서드를 통해 표현됩니다.  
스프레드시트 수식은  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 메서드로 지정 및 변경할 수 있습니다.  
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

일반적으로 스프레드시트는 마지막으로 계산된 수식 값을 저장합니다. 프레젠테이션 로드 후 차트 데이터가 변경되지 않았다면 **IChartDataCell.get_Value()** 메서드가 해당 값을 반환합니다. 그러나 스프레드시트 데이터가 변경된 경우 **ChartDataCell.get_Value()** 메서드가 지원되지 않는 수식에 대해 **CellUnsupportedDataException**을 발생시킵니다. 이는 수식이 성공적으로 구문 분석될 때 셀 의존성이 결정되고 마지막 값의 정확성이 확인되기 때문이며, 수식을 구문 분석할 수 없을 경우 셀 값의 정확성을 보장할 수 없기 때문입니다.

## **프레젠테이션에 차트 스프레드시트 수식 추가**
먼저 새 프레젠테이션의 첫 번째 슬라이드에  
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374)  
메서드를 사용해 차트를 추가합니다. 차트의 워크시트는 자동으로 생성되며 다음 메서드로 접근할 수 있습니다:  
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)  

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

다음 메서드를 사용해 **Object** 형식의 값을 셀에 쓸 수 있습니다:  
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec)  

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

이제 셀에 수식을 쓰려면  
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)  
메서드를 사용할 수 있습니다:

*Note*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 메서드는 A1 스타일 셀 참조를 설정하는 데 사용됩니다.  

R1C1Formula 셀 참조를 설정하려면  
[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7)  
메서드를 사용합니다:

그런 다음 B2와 C2 셀의 값을 읽으면 계산된 결과가 반환됩니다:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **논리 상수**
셀 수식에서 *FALSE*와 *TRUE* 같은 논리 상수를 사용할 수 있습니다:

## **숫자 상수**
숫자는 일반 표기법이나 과학적 표기법으로 차트 스프레드시트 수식을 만들 때 사용할 수 있습니다:

## **문자열 상수**
문자열(리터럴) 상수는 그대로 사용되는 특정 값이며 변하지 않습니다. 문자열 상수는 날짜, 텍스트, 숫자 등이 될 수 있습니다:

## **오류 상수**
때때로 수식으로 결과를 계산할 수 없습니다. 이 경우 셀에 값 대신 오류 코드가 표시됩니다. 각 오류 유형마다 고유한 코드가 있습니다:

- #DIV/0! - 수식이 0으로 나누기를 시도함.
- #GETTING_DATA - 셀 값이 아직 계산 중일 때 표시될 수 있음.
- #N/A - 정보가 없거나 사용할 수 없음. 예: 수식에 사용된 셀이 비어 있거나, 추가 공백 문자, 철자 오류 등.
- #NAME? - 특정 셀 또는 다른 수식 개체를 이름으로 찾을 수 없음.
- #NULL! - 수식에 실수가 있을 때 표시됨(예: (,) 또는 콜론(:) 대신 공백 문자 사용).
- #NUM! - 수식에 있는 숫자가 잘못됐거나 너무 크거나 작음.
- #REF! - 잘못된 셀 참조.
- #VALUE! - 예상치 못한 값 유형. 예: 문자열 값을 숫자 셀에 넣은 경우.

## **산술 연산자**
차트 워크시트 수식에서 모든 산술 연산자를 사용할 수 있습니다:

|**연산자**|**의미**|**예시**|
| :- | :- | :- |
|+ (플러스)|덧셈 또는 단항 플러스|2 + 3|
|- (마이너스)|뺄셈 또는 부호 반전|2 - 3<br>-3|
|* (별표)|곱셈|2 * 3|
|/ (슬래시)|나눗셈|2 / 3|
|% (퍼센트)|백분율|30%|
|^ (캐럿)|거듭제곱|2 ^ 3|

*Note*: 계산 순서를 변경하려면 먼저 계산할 부분을 괄호로 묶으세요.

## **비교 연산자**
비교 연산자를 사용해 셀 값을 비교할 수 있습니다. 이 연산자를 사용해 두 값을 비교하면 결과는 *TRUE* 또는 FALSE 논리값이 됩니다:

|**연산자**|**의미**|**예시**|
| :- | :- | :- |
|= (등호)|같음|A2 = 3|
|<> (다름)|같지 않음|A2 <> 3|
|> (큰 없음)|보다 큼|A2 > 3|
|>= (크거나 같음)|보다 크거나 같음|A2 >= 3|
|< (작음)|보다 작음|A2 < 3|
|<= (작거나 같음)|보다 작거나 같음|A2 <= 3|

## **A1 스타일 셀 참조**
**A1 스타일 셀 참조**는 열이 문자 식별자(예: "*A*")이고 행이 숫자 식별자(예: "*1*")인 워크시트에 사용됩니다. A1 스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**셀 참조**|**예시**| | |
| :- | :- | :- | :- |
| |절대|상대|혼합|
|셀|$A$2|A2|<p>A$2</p><p>$A2</p>|
|행|$2:$2|2:2|-|
|열|$A:$A|A:A|-|
|범위|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

다음은 수식에서 A1 스타일 셀 참조를 사용하는 예시입니다:

## **R1C1 스타일 셀 참조**
**R1C1 스타일 셀 참조**는 행과 열 모두 숫자 식별자를 갖는 워크시트에 사용됩니다. R1C1 스타일 셀 참조는 다음과 같이 사용할 수 있습니다:

|**셀 참조**|**예시**| | |
| :- | :- | :- | :- |
| |절대|상대|혼합|
|셀|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|행|R2|R[2]|-|
|열|C3|C[3]|-|
|범위|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

다음은 수식에서 A1 스타일 셀 참조를 사용하는 예시입니다:

## **미리 정의된 함수**
수식에서 구현을 단순화하기 위해 사용할 수 있는 미리 정의된 함수가 있습니다. 이 함수들은 가장 흔히 사용되는 작업을 캡슐화합니다:

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
- INDEX (참조 형식)
- LOOKUP (벡터 형식)
- MATCH (벡터 형식)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**외부 Excel 파일을 차트의 데이터 소스로, 수식과 함께 사용할 수 있나요?**

예. Aspose.Slides는 [차트 데이터 소스](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chartdatasourcetype/)로 외부 워크북을 지원하므로 프레젠테이션 외부의 XLSX 파일에서 수식을 사용할 수 있습니다.

**차트 수식이 동일 워크북 내의 시트를 시트 이름으로 참조할 수 있나요?**

예. 수식은 표준 Excel 참조 모델을 따르므로 동일 워크북 내의 다른 시트나 외부 워크북을 참조할 수 있습니다. 외부 참조의 경우 Excel 구문을 사용해 경로와 워크북 이름을 포함하면 됩니다.