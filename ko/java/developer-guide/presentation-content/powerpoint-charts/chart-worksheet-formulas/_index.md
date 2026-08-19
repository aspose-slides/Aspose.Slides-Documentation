---
title: Java 프레젠테이션에서 차트 워크시트 수식 적용
linktitle: 워크시트 수식
type: docs
weight: 70
url: /ko/java/chart-worksheet-formulas/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 차트 워크시트에서 Excel 스타일 수식을 적용하고, 값을 재계산한 후 PowerPoint 차트에 결과를 사용합니다."
---
## **개요**

PowerPoint 차트는 보통 원본 데이터를 포함된 워크시트에 저장합니다. Aspose.Slides for Java에서는 차트 데이터 워크북을 통해 해당 워크시트에 접근하고, 입력 값을 기록하고, 셀에 수식을 할당하고, 지원되는 수식을 계산하며, 계산된 셀을 차트 데이터로 사용할 수 있습니다.

이 문서는 전체 수식 워크플로우를 설명합니다: 차트를 만들고, 워크시트를 채우고, A1 스타일 또는 R1C1 스타일 수식을 할당하고, 다시 계산하고, 계산된 값을 읽고, 해당 셀을 차트 시리즈에 연결하고, 프레젠테이션을 저장합니다. 또한 지원되는 수식 구문, 내장 함수 하위 집합, 캐시된 값, 지원되지 않는 수식 및 스프레드시트 전용 오류에 대해서도 설명합니다.

## **차트 워크시트와 수식**

차트 워크시트에는 차트에서 사용하는 카테고리, 시리즈 이름 및 값이 포함됩니다. PowerPoint에서는 차트 데이터 편집기를 열어 워크시트를 확인할 수 있습니다:

![PowerPoint 차트와 포함된 워크시트가 열려 있어 카테고리와 시리즈 데이터가 표시된 이미지](chart-worksheet-formulas_1.png)

Aspose.Slides에서는 워크시트가 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/) 인터페이스를 통해 노출됩니다. A1 스타일 수식은 [IChartDataCell.setFormula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)을 사용하고, R1C1 스타일 수식은 [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)을 사용합니다. 입력 셀이나 수식을 변경한 후에는 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)을 호출해 지원되는 수식을 재계산하고 해당 셀 값을 업데이트합니다.

계산된 셀은 여전히 ​​[IChartDataCell.getValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#getValue--)를 통해 결과를 노출합니다. 이는 코드에서 수식 결과를 확인하거나 셀을 차트 데이터 포인트로 사용할 때 중요합니다.

## **차트 만들기 및 워크시트 수식 계산**

다음 예제는 엔드‑투‑엔드 워크플로우를 보여줍니다. 클러스터형 열 차트를 만들고, 샘플 데이터를 지우고, 분기 매출 및 비용 값을 기록하고, 수식으로 이익을 계산하고, 결과를 읽고, 계산된 셀을 차트 값으로 사용하고, 프레젠테이션을 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

차트 데이터 포인트는 `D2:D4`를 참조하므로 차트는 계산된 이익 값을 사용합니다. 이 워크플로우에는 별도의 차트 새로 고침 호출이 없습니다: 먼저 워크북을 재계산하고, 그런 다음 계산된 셀을 가리키는 차트 데이터를 사용하거나 저장합니다.

## **A1 스타일 수식 사용**

A1 표기법은 열을 문자로, 행을 숫자로 식별합니다. [IChartDataCell.setFormula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)을 통해 A1 스타일 표현식을 할당합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

일반적인 A1 참조 형태는 다음과 같습니다:

| 참조 | 상대 | 절대 | 혼합 |
|---|---|---|---|
| 셀 | `A2` | `$A$2` | `A$2`, `$A2` |
| 행 | `2:2` | `$2:$2` | — |
| 열 | `A:A` | `$A:$A` | — |
| 범위 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

상대 참조는 수식이 스프레드시트 애플리케이션에 의해 이동되거나 복사될 때 변경될 수 있습니다. 절대 참조는 두 좌표를 모두 고정하고, 혼합 참조는 행 또는 열만 고정합니다.

## **R1C1 스타일 수식 사용**

R1C1 표기법은 행과 열을 숫자로 식별합니다. 상대 참조는 대괄호 안의 오프셋을 사용합니다. 이 구문은 [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)을 통해 할당합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

일반적인 R1C1 참조 형태는 다음과 같습니다:

| 참조 | 상대 | 절대 | 혼합 |
|---|---|---|---|
| 셀 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 행 | `R[2]` | `R2` | — |
| 열 | `C[3]` | `C3` | — |
| 범위 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

예를 들어 셀 `D2`에서 `RC[-2]`는 같은 행에서 두 열 왼쪽에 있는 셀(`B2`)을 의미합니다.

## **수식 상수와 연산자**

내장 수식 평가기는 논리값, 숫자 리터럴, 문자열, 스프레드시트 오류값, 산술 연산자 및 비교 연산자를 지원합니다.

### **상수와 리터럴**

| 유형 | 예시 | 비고 |
|---|---|---|
| 논리 | `TRUE`, `FALSE` | `A2=TRUE`와 같은 논리식에 직접 사용할 수 있습니다. |
| 숫자 | `1`, `0.5`, `.3`, `1E-2` | 일반 및 과학적 표기법을 지원합니다. |
| 문자열 | `"abc"`, `"2/3/2020 12:00"` | 텍스트 리터럴은 수식 내부에서 큰따옴표로 둘러싸입니다. |
| 오류 결과 | `#DIV/0!`, `#N/A`, `#REF!` | 유효한 수식이 정상 결과 대신 스프레드시트 오류값을 반환할 수 있습니다. |

다음 예제는 여러 상수 유형을 사용합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // 거짓
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
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

예를 들어 `(A2+B2)*C2`처럼 괄호를 사용해 연산 순서를 명시할 수 있습니다.

### **비교 연산자**

비교식은 논리값을 반환합니다.

| 연산자 | 의미 | 예시 |
|---|---|---|
| `=` | 같음 | `A2=3` |
| `<>` | 같지 않음 | `A2<>3` |
| `>` | 큼 | `A2>3` |
| `>=` | 크거나 같음 | `A2>=3` |
| `<` | 작음 | `A2<3` |
| `<=` | 작거나 같음 | `A2<=3` |

## **지원되는 사전 정의 함수**

Aspose.Slides에는 차트 워크시트를 위한 내장 수식 평가기가 포함되어 있지만, 완전한 Excel 계산 엔진은 아닙니다. 문서화된 함수 집합은 아래에 제한됩니다. 임의의 Excel 함수가 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)에 의해 재계산된다고 가정하지 마세요.

| 함수 | 목적 또는 지원 형식 | 예시 |
|---|---|---|
| `ABS` | 절대값 | `ABS(A2)` |
| `AVERAGE` | 산술 평균 | `AVERAGE(B2:B5)` |
| `CEILING` | 지정 배수로 올림 | `CEILING(A2,5)` |
| `CHOOSE` | 인덱스로 값 선택 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 텍스트 값 연결 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 텍스트 값 연결 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 날짜 시스템을 사용해 날짜값 생성 | `DATE(2026,8,19)` |
| `DAYS` | 두 날짜 사이 일수 반환 | `DAYS(B2,A2)` |
| `FIND` | 텍스트 내에서 다른 텍스트 찾기 | `FIND("-",A2)` |
| `FINDB` | 바이트 기반 텍스트 검색 | `FINDB("a",A2)` |
| `IF` | 조건부 결과 | `IF(A2>0,A2,0)` |
| `INDEX` | 참조 형태 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 벡터 형태 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 벡터 형태 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 최대값 | `MAX(B2:B5)` |
| `SUM` | 합계 | `SUM(B2:B5)` |
| `VLOOKUP` | 수직 조회 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

표에 표시된 제한은 중요합니다: `INDEX`는 참조 형태로 문서화되고, `LOOKUP`과 `MATCH`는 벡터 형태로 문서화됩니다. `DATE`는 1900 날짜 시스템을 사용합니다. 여기 나열되지 않은 기능과 함수는 Aspose.Slides 수식 평가기에 의해 지원되지 않는다고 간주해야 합니다.

## **재계산 및 캐시된 값**

스프레드시트 파일은 일반적으로 수식과 마지막 계산된 값을 함께 저장합니다. 따라서 프레젠테이션을 로드하고 관련 차트 데이터가 변경되지 않은 경우 [IChartDataCell.getValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#getValue--)를 통해 캐시된 값을 읽을 수 있습니다.

입력 셀이나 수식을 변경한 후에는 오래된 캐시 결과에 의존하지 마세요. 계산된 값을 읽거나 해당 값을 사용해 차트 데이터를 저장하기 전에 반드시 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)를 호출하세요.

지원되지 않는 서브셋 외의 수식에 대해서는 Aspose.Slides가 수식을 파싱하거나 종속성을 파악하지 못할 수 있습니다. 워크북이 수정된 경우 이전 캐시 값은 더 이상 신뢰할 수 없습니다. 이 경우 지원되지 않는 데이터가 있는 셀의 값을 읽으면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellunsupporteddataexception/)이 발생할 수 있습니다.

차트가 Aspose.Slides에서 평가되지 않는 Excel 함수를 사용한다면, 해당 수식을 지원하는 스프레드시트 엔진으로 계산한 뒤 결과 값을 차트 워크북에 기록하세요. 추측된 값으로 지원되지 않는 수식을 대체하지 마세요.

## **수식 오류 처리**

두 가지 다른 유형의 문제를 구분해야 합니다.

수식이 유효하지만 `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!`와 같은 스프레드시트 오류 결과를 반환할 수 있습니다. 이 경우 오류 토큰은 셀 결과이며 [IChartDataCell.getValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#getValue--)를 통해 반환될 수 있습니다.

또한 수식이 구문 분석, 참조, 종속성 또는 지원 데이터 수준에서 실패할 수도 있습니다. Aspose.Slides는 이러한 경우에 대해 다음과 같은 스프레드시트 전용 예외를 제공합니다: [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellcircularreferenceexception/), [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellunsupporteddataexception/).

템플릿이나 사용자 입력에서 수식이 제공되는 경우, 재계산 및 값 접근 시 이러한 예외를 처리하세요:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **실용적인 제한 사항**

차트 워크시트의 수식 지원은 전체 Excel 호환성을 목표로 하지 않으며, 정의된 서브셋에만 적용됩니다. 보고 워크플로우를 설계할 때 다음 제약을 기억하세요:

- Aspose.Slides가 수식을 재계산하도록 하려면 문서화된 상수, 연산자, 참조 및 함数만 사용하세요.
- 수식 결과가 의존하는 셀을 변경한 후에는 반드시 재계산하세요.
- 로드된 프레젠테이션에서 가져온 캐시 값은 스냅샷이며, 편집 후 재계산을 대체할 수 없습니다.
- 기존 템플릿의 수식을 테스트하여 문서화된 목록에 없는 함수가 사용되지 않았는지 확인하세요.
- 전체 스프레드시트 계산 엔진이 필요한 수식은 외부에서 계산한 뒤 차트 워크북에 결과 값을 업데이트하세요.

## **FAQ**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)와 [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)의 차이는 무엇인가요?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)은 `B2-C2`와 같은 A1 스타일 표현식을 저장합니다. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)은 `RC[-2]-RC[-1]`와 같은 R1C1 스타일 표현식을 저장합니다. 수식을 생성하거나 복사하는 방식에 가장 적합한 표기법을 사용하세요.

**계산 후 셀 자체를 읽어야 하나, 셀 값을 읽어야 하나요?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-)은 [IChartDataCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/)을 반환합니다. 재계산 후 계산된 결과를 얻으려면 해당 셀의 [IChartDataCell.getValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#getValue--) 메서드를 호출하세요.

**[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)를 언제 호출해야 하나요?**

입력 값이나 수식을 변경한 뒤, 계산된 결과에 의존하기 전에 반드시 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)를 호출하세요. 이렇게 하면 내장 평가기가 지원하는 수식의 값이 업데이트됩니다.

**Aspose.Slides가 모든 Excel 함수를 지원하나요?**

아닙니다. 내장 평가기는 문서화된 함수 서브셋만 지원합니다. 그 외의 함수는 올바르게 재계산된다고 가정하지 마세요. 전체 Excel 수식 호환성이 필요하면 적절한 스프레드시트 엔진으로 계산한 뒤 차트 워크북에 최종 값을 기록하세요.

**로드된 프레젠테이션에 지원되지 않는 수식이 포함되어 있으면 어떻게 되나요?**

차트 데이터가 변경되지 않은 경우, 워크북에 이전에 계산된 캐시 값이 남아 있을 수 있습니다. 관련 데이터가 수정된 후에는 해당 캐시 값이 더 이상 유효하지 않을 수 있습니다. 처리할 수 없는 수식이 있는 셀에 접근하면 [CellUnsupportedDataException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellunsupporteddataexception/)이 발생할 수 있습니다.

**수식 오류 값과 Java 예외는 동일한가요?**

아닙니다. `#DIV/0!`와 같은 결과는 유효한 계산에 의해 생성된 스프레드시트 값입니다. [CellInvalidFormulaException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellinvalidformulaexception/)이나 [CellCircularReferenceException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/cellcircularreferenceexception/)과 같은 예외는 수식을 정상적으로 처리할 수 없음을 나타냅니다.

**수식 셀을 변경하면 차트가 자동으로 업데이트되나요?**

차트 시리즈는 워크북 셀을 참조할 수 있습니다. 먼저 워크북을 재계산하고 프레젠테이션을 저장하거나 렌더링하면 됩니다. 차트 데이터 포인트가 계산된 셀을 참조하고 있다면 차트는 해당 업데이트된 셀 값을 사용합니다; 별도의 차트 새로 고침 메서드는 필요하지 않습니다.

**차트가 외부 Excel 워크북을 사용할 수 있나요?**

예, 차트 데이터는 차트 데이터 API를 통해 외부 워크북을 사용하도록 구성할 수 있습니다. 그러나 이 문서에서 설명하는 수식 계산 워크플로우는 차트 데이터 워크북과 Aspose.Slides가 평가하는 수식 서브셋에만 적용됩니다. [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)가 외부 XLSX 파일의 임의 수식을 완전히 재계산한다고 가정하지 마세요.

**다른 워크시트나 워크북을 참조하는 수식을 사용할 수 있나요?**

Excel 스타일 참조가 차트 워크북에 존재할 수 있지만, 수식 평가는 지원되는 파서와 함수 집합에 의해 제한됩니다. 교차 시트 또는 외부 참조가 필수인 경우 대상 Aspose.Slides 버전에서 정확히 동작하는지 확인하세요. 광범위한 Excel 참조 호환성이 필요한 워크플로우는 워크북을 외부에서 계산하고 결과 값을 차트 데이터에 기록하는 것이 좋습니다.

**수식 문자열은 `=`로 시작해야 하나요?**

Aspose.Slides API 예제에서는 `B2-C2` 또는 `SUM(B2:B5)`와 같이 앞에 `=` 없이 표현식을 할당합니다. 이 형태를 사용하면 생성된 수식이 문서화된 API 예제와 일관됩니다.