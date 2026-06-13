---
title: Python을 사용한 프레젠테이션 차트 워크시트 수식 적용
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
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: ".NET 차트 워크시트를 통해 Python용 Aspose.Slides에서 Excel 스타일 수식을 적용하고 PPT, PPTX 및 ODP 파일 전반에 걸쳐 보고서를 자동화합니다."
---
## **개요**

차트 워크시트는 프레젠테이션의 차트 뒤에 있는 데이터 소스입니다. 차트에 표시되는 수치값과 함께 카테고리 및 시리즈 이름을 저장합니다. Aspose.Slides에서는 차트 데이터 워크북을 통해 이 워크시트에 접근할 수 있으며, 프로그래밍 방식으로 차트 데이터를 조작할 수 있습니다.

이 문서는 차트 데이터에 워크시트 수식을 사용하여 셀 값을 수동으로 입력하는 대신 자동으로 계산·업데이트하도록 하는 방법을 설명합니다. 수식 할당, A1 스타일 및 R1C1 스타일 참조 사용, 워크북 수식 재계산, 프레젠테이션 차트 워크시트에서 지원되는 상수·연산자·셀 참조·미리 정의된 함수 등을 다룹니다.

## **프레젠테이션의 차트 스프레드시트 수식에 대하여**
프레젠테이션의 **차트 스프레드시트**(또는 차트 워크시트)는 차트의 데이터 소스입니다. 차트 스프레드시트는 차트에 그래픽으로 표시되는 데이터를 포함합니다. PowerPoint에서 차트를 만들면 해당 차트와 연결된 워크시트가 자동으로 생성됩니다. 모든 차트 유형(선 차트, 막대 차트, 썬버스트 차트, 원형 차트 등)에서 차트 워크시트가 만들어집니다. PowerPoint에서 차트 스프레드시트를 보려면 차트를 더블 클릭하면 됩니다.

![todo:image_alt_text](chart-worksheet-formulas_1.png)

차트 스프레드시트에는 차트 요소 이름(카테고리 이름: *Category1*, 시리즈 이름)과 이러한 카테고리·시리즈에 해당하는 숫자 데이터 표가 포함됩니다. 새 차트를 만들면 기본 데이터가 자동으로 설정됩니다. 이후 워크시트에서 데이터를 수동으로 변경할 수 있습니다.

보통 차트는 복잡한 데이터를 나타내며(예: 재무 분석, 과학 분석) 다른 셀의 값 또는 동적 데이터에서 계산된 셀을 포함합니다. 셀 값을 수동으로 계산해 하드코딩하면 향후 변경이 어려워집니다. 특정 셀 값을 변경하면 해당 셀에 의존하는 모든 셀도 업데이트되어야 합니다. 또한 표 데이터가 다른 표의 데이터에 의존할 수 있어, 쉽게 유연하게 업데이트할 수 있는 프레젠테이션 데이터 스키마가 필요합니다.

프레젠테이션의 **차트 스프레드시트 수식**은 차트 스프레드시트 데이터를 자동으로 계산·업데이트하는 식입니다. 수식은 특정 셀 또는 셀 집합의 데이터 계산 로직을 정의합니다. 수식은 셀 참조, 수학 함수, 논리 연산자, 산술 연산자, 변환 함수, 문자열 상수 등을 사용할 수 있는 수학·논리 식입니다. 수식 정의는 셀에 기록되며, 해당 셀은 단순 값을 포함하지 않습니다. 수식은 값을 계산해 반환하고, 그 값이 셀에 할당됩니다. 프레젠테이션의 차트 스프레드시트 수식은 Excel 수식과 동일하며, 동일한 기본 함수·연산자·상수를 지원합니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/python-net/)에서 차트 스프레드시트는  
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdata/) 속성을 통해 접근할 수 있는  
[**IChartDataWorkbook**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdataworkbook/) 타입입니다.  
수식은  
[**formula**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/) 속성을 사용해 할당·수정할 수 있습니다.  
Aspose.Slides에서 수식에 대해 지원되는 기능은 다음과 같습니다.

- 논리 상수
- 숫자 상수
- 문자열 상수
- 오류 상수
- 산술 연산자
- 비교 연산자
- A1 스타일 셀 참조
- R1C1 스타일 셀 참조
- 미리 정의된 함수

일반적으로 스프레드시트는 마지막으로 계산된 수식 값을 저장합니다. 프레젠테이션 로드 후 차트 데이터가 변경되지 않았다면 **IChartDataCell.Value** 속성이 해당 값을 반환합니다. 그러나 스프레드시트 데이터가 변경된 경우 **ChartDataCell.Value** 속성을 읽을 때 지원되지 않는 수식에 대해 **CellUnsupportedDataException**이 발생합니다. 이는 수식이 성공적으로 구문 분석될 때 셀 의존성이 결정되고 마지막 값의 정확성이 확인되지만, 수식이 구문 분석되지 않으면 셀 값의 정확성을 보장할 수 없기 때문입니다.

## **프레젠테이션에 차트 스프레드시트 수식 추가**
먼저 새 프레젠테이션의 첫 번째 슬라이드에  
[add_chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapecollection/)  
을 사용해 샘플 데이터를 가진 차트를 추가합니다. 차트의 워크시트는 자동으로 생성되며  
[**chart_data_workbook**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdata/)  
속성을 통해 접근할 수 있습니다:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

다음과 같이 **Object** 타입의  
[**value**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/)  
속성을 사용해 셀에 값을 기록할 수 있습니다:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

이제 셀에 수식을 기록하려면  
[**formula**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/)  
속성을 사용합니다:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Note*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/) 속성은 A1 스타일 셀 참조를 설정하는 데 사용됩니다.

R1C1 스타일 셀 참조를 설정하려면 [**r1c1_formula**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/ichartdatacell/) 속성을 사용합니다:

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

그런 다음 [**calculate_formulas**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdataworkbook/) 메서드를 호출해 워크북 내 모든 수식을 계산하고 해당 셀 값을 업데이트합니다:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **논리 상수**
셀 수식에서 *FALSE*와 *TRUE*와 같은 논리 상수를 사용할 수 있습니다.

## **숫자 상수**
숫자는 일반 표기법이나 과학적 표기법으로 차트 스프레드시트 수식을 만들 때 사용할 수 있습니다.

## **문자열 상수**
문자열(또는 리터럴) 상수는 그대로 사용되는 특정 값이며 변경되지 않습니다. 문자열 상수에는 날짜, 텍스트, 숫자 등이 포함될 수 있습니다.

## **오류 상수**
때때로 수식으로 결과를 계산할 수 없을 경우 셀에 오류 코드가 표시됩니다. 각 오류 유형에 대한 코드는 다음과 같습니다.

- #DIV/0! ‑ 수식이 0으로 나누기를 시도함.
- #GETTING_DATA ‑ 값이 아직 계산 중일 때 셀에 표시될 수 있음.
- #N/A ‑ 정보가 없거나 사용할 수 없음. 예: 수식에 사용된 셀이 비어 있거나, 공백 문자, 오타 등.
- #NAME? ‑ 특정 셀이나 다른 수식 객체를 이름으로 찾을 수 없음.
- #NULL! ‑ 수식에 오류가 있을 때 나타남(예: (,) 또는 콜론(:) 대신 공백 문자 사용).
- #NUM! ‑ 숫자 값이 잘못됐거나 너무 길거나 너무 짧음.
- #REF! ‑ 잘못된 셀 참조.
- #VALUE! ‑ 예상치 못한 값 유형. 예: 문자열 값을 숫자 셀에 지정함.

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

*Note*: 평가 순서를 변경하려면 먼저 계산할 부분을 괄호로 감싸십시오.

## **비교 연산자**
비교 연산자를 사용해 셀 값을 비교할 수 있습니다. 두 값을 비교하면 결과는 *TRUE* 또는 FALSE 논리값이 됩니다.

|**연산자**|**의미**|**예시**|
| :- | :- | :- |
|= (동등)|같음|A2 = 3|
|<> (부등)|다름|A2 <> 3|
|> (대입)|초과|A2 > 3|
|>= (이상)|이상|A2 >= 3|
|< (미만)|미만|A2 < 3|
|<= (이하)|이하|A2 <= 3|

## **A1‑스타일 셀 참조**
**A1‑스타일 셀 참조**는 열에 문자 식별자(예: "*A*")가, 행에 숫자 식별자(예: "*1*")가 있는 워크시트에서 사용됩니다. A1‑스타일 셀 참조는 다음과 같이 사용할 수 있습니다.

|**셀 참조**|**예시**| | |
| :- | :- | :- | :- |
| |절대|상대|혼합|
|셀|$A$2|A2|<p>A$2</p><p>$A2</p>|
|행|$2:$2|2:2|‑|
|열|$A:$A|A:A|‑|
|범위|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

다음은 A1‑스타일 셀 참조를 수식에 사용하는 예시입니다.

## **R1C1‑스타일 셀 참조**
**R1C1‑스타일 셀 참조**는 행과 열 모두 숫자 식별자를 사용하는 워크시트에 사용됩니다. R1C1‑스타일 셀 참조는 다음과 같이 사용할 수 있습니다.

|**셀 참조**|**예시**| | |
| :- | :- | :- | :- |
| |절대|상대|혼합|
|셀|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|행|R2|R[2]|‑|
|열|C3|C[3]|‑|
|범위|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

다음은 R1C1‑스타일 셀 참조를 수식에 사용하는 예시입니다.

## **미리 정의된 함수**
다음과 같은 가장 일반적으로 사용되는 작업을 캡슐화한 미리 정의된 함수들을 수식에 사용할 수 있습니다.

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

**외부 Excel 파일을 차트의 데이터 소스로, 수식과 함께 사용할 수 있나요?**

예. Aspose.Slides는 외부 워크북을 [차트 데이터 소스](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chartdatasourcetype/) 로 지원하므로 프레젠테이션 외부의 XLSX 파일에 있는 수식을 사용할 수 있습니다.

**차트 수식이 같은 워크북 내 시트 이름으로 시트를 참조할 수 있나요?**

예. 수식은 표준 Excel 참조 모델을 따르므로 동일 워크북 내 다른 시트나 외부 워크북을 참조할 수 있습니다. 외부 참조의 경우 Excel 구문을 사용해 경로와 워크북 이름을 포함하면 됩니다.