---
title: Android용 PowerPoint 테이블에서 행 및 열 관리
linktitle: 행 및 열
type: docs
weight: 20
url: /ko/androidjava/manage-rows-and-columns/
keywords:
- 테이블 행
- 테이블 열
- 첫 번째 행
- 테이블 헤더
- 행 복제
- 열 복제
- 행 복사
- 열 복사
- 행 제거
- 열 제거
- 행 텍스트 서식
- 열 텍스트 서식
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint에서 테이블 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **소개**

Aspose.Slides for Android via Java를 사용하면 [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) 클래스와 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 인터페이스를 통해 PowerPoint 프레젠테이션의 표 구조와 서식을 관리할 수 있습니다. 머리글 행을 지정하고, 행 및 열을 복제하거나 제거하며, 전체 행이나 열에 텍스트 서식을 적용할 수 있습니다.

이 문서는 이러한 작업을 Java 예제와 함께 설명합니다. 또한 표 스타일 프리셋을 가져와 재사용하는 방법도 보여줍니다. 표 행 및 열 인덱스는 0부터 시작합니다.

## **행 높이 제어**

[IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-)을 사용하여 행의 최소 높이를 포인트 단위로 설정합니다. 이는 하한값이며 고정 높이가 아닙니다. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--)은 실제 높이를 반환합니다. 행은 [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--)를 통해 접근합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 [row-height-input.pptx](row-height-input.pptx)를 로드합니다. 첫 번째 행은 70포인트에서 시작합니다. 셀은 18포인트 Arial 텍스트, 자동 줄바꿈, 위아래 여백 6포인트를 사용합니다; 두 번째 열의 긴 텍스트는 여러 줄로 줄바꿈됩니다. 예제는 최소값을 100포인트로 늘렸다가 20포인트로 줄이고, 각 변경 후 실제 높이를 출력한 뒤 두 결과를 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

제공된 프레젠테이션에서 최소값을 늘리면 행에 공간이 추가됩니다. 최소값을 줄이면 그 여분의 공간이 제거되지만, 텍스트와 셀 여백 때문에 실제 높이는 20포인트보다 크게 유지됩니다. 최소값만 줄인다고 해서 내용이 요구하는 공간보다 낮게 강제할 수 없습니다.

실제 높이에 영향을 미치는 여러 요인:

- **텍스트 및 글꼴 크기:** 더 긴 텍스트, 명시적 줄바꿈 또는 큰 글꼴은 더 많은 수직 공간이 필요합니다.
- **줄바꿈 및 열 너비:** 줄바꿈이 활성화된 상태에서 [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-)로 열 너비를 줄이면 줄 수가 늘어납니다. 더 넓은 열은 수직 공간 요구량을 감소시킬 수 있습니다.
- **셀 여백:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-)와 [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-)은 수직 공간을 추가합니다. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-)와 [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-)는 텍스트에 사용 가능한 너비를 줄여 추가 줄바꿈을 유발할 수 있습니다.

병합된 셀이 없는 이 표에서는 가장 많은 수직 공간을 필요로 하는 셀이 전체 행의 내용 기반 하한을 결정합니다. 행을 더 짧게 만들려면 텍스트를 줄이거나, 글꼴 크기 또는 여백을 축소하거나, 열을 넓혀야 할 수도 있습니다.

아래 이미지들은 같은 표를 동일한 배율로 보여줍니다. 표시된 결과에서 실제 높이는 각각 70, 100, 55.2포인트였으며, 최종 행은 20포인트 최소값보다 높게 남았습니다. 정확한 텍스트 측정값은 환경에 설치된 글꼴에 따라 달라질 수 있습니다. 저장된 결과를 다운로드하세요: [증가된 최소값](row-height-increased.pptx) 및 [감소된 최소값](row-height-decreased.pptx).

| 원본: 최소 70pt, 실제 70pt | 증가된: 최소 100pt, 실제 100pt | 감소된: 최소 20pt, 실제 55.2pt |
| --- | --- | --- |
| ![원본 표의 70포인트 첫 행.](row-height-before.png) | ![첫 행 최소값을 100포인트로 증가시킨 표.](row-height-increased.png) | ![첫 행 최소값을 20포인트로 감소시킨 표; 줄바꿈된 텍스트 때문에 행이 최소값보다 높게 유지됨.](row-height-decreased.png) |

## **첫 번째 행을 머리글로 설정**

[setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) 메서드를 사용하여 첫 번째 행을 머리글 서식으로 표시합니다. 외관은 표에 적용된 표 스타일에 따라 달라집니다.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.  
2. 첫 번째 슬라이드를 접근합니다.  
3. 슬라이드의 첫 번째 도형으로 저장된 표에 접근합니다.  
4. 첫 번째 행에 머리글 서식을 활성화합니다.  
5. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 `table.pptx`가 필요합니다. 첫 번째 행에 머리글 서식을 적용하고 `First_row_header.pptx`로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 행 또는 열 복제**

행이나 열을 복제하여 내용과 서식을 재사용할 수 있습니다. 복제본을 표 끝에 추가하거나 특정 위치에 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.  
2. 첫 번째 슬라이드를 접근합니다.  
3. 열 너비와 행 높이를 정의합니다.  
4. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 메서드로 표를 추가합니다.  
5. 필요한 행을 복제합니다.  
6. 필요한 열을 복제합니다.  
7. 수정된 프레젠테이션을 저장합니다.

예제는 최소 하나의 슬라이드가 있는 `Test.pptx`가 필요합니다. 3열 5행 표를 포인트 단위로 만든 뒤, 첫 번째 행과 열을 복제하고, 두 번째 행과 열을 인덱스 3(네 번째 위치)에 삽입합니다. 결과 표는 7행 5열이 됩니다. `false` 인자는 인접한 병합된 행이나 열로의 복제를 비활성화하며, 이 표에는 병합된 셀이 없습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표에서 행 또는 열 제거**

더 이상 필요하지 않은 행이나 열을 제거합니다. 항목을 제거하면 그 뒤에 있는 행이나 열의 인덱스가 앞당겨집니다.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 생성합니다.  
2. 첫 번째 슬라이드를 접근합니다.  
3. 열 너비와 행 높이를 정의합니다.  
4. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 메서드로 표를 추가합니다.  
5. 두 번째 행과 두 번째 열을 제거합니다.  
6. 수정된 프레젠테이션을 저장합니다.

이 예제는 3×3 표를 만든 뒤 인덱스 1에 있는 행과 열을 제거하여 `TestTable_out.pptx`에 2×2 표를 남깁니다. 크기는 포인트 단위이며, `false` 인자는 인접한 병합된 행이나 열의 제거를 비활성화합니다. 이 표에도 병합된 셀은 없습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 행 수준에서 텍스트 서식 설정**

전체 행에 텍스트 서식을 적용하여 셀 간 일관성을 유지합니다. 글꼴 속성, 단락 서식 및 텍스트 방향을 개별 셀마다 지정하지 않고 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.  
2. 첫 번째 슬라이드의 표에 접근합니다.  
3. 첫 번째 행에 대해 [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)를 사용합니다.  
4. 첫 번째 행에 대해 [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-)와 [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)을 사용합니다.  
5. 두 번째 행에 대해 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)을 사용합니다.  
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형에 표가 포함된 `table.pptx`와 최소 두 행이 필요합니다. 첫 번째 행에 25포인트 텍스트, 오른쪽 정렬, 20포인트 오른쪽 단락 여백을 적용하고, 두 번째 행에 수직 텍스트를 설정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 열 수준에서 텍스트 서식 설정**

전체 열에 텍스트 서식을 적용하여 셀 간 일관성을 유지합니다. 글꼴 속성, 단락 서식 및 텍스트 방향을 개별 셀마다 지정하지 않고 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.  
2. 첫 번째 슬라이드의 표에 접근합니다.  
3. 첫 번째 열에 대해 [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)를 사용합니다.  
4. 첫 번째 열에 대해 [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-)와 [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)을 사용합니다.  
5. 두 번째 열에 대해 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)을 사용합니다.  
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형에 표가 포함된 `table.pptx`와 최소 두 열이 필요합니다. 첫 번째 열에 25포인트 텍스트, 오른쪽 정렬, 20포인트 오른쪽 단락 여백을 적용하고, 두 번째 열에 수직 텍스트를 설정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 스타일 속성 가져오기**

[getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) 메서드를 사용하여 표에 적용된 프리셋을 가져오고 다른 표에 재사용할 수 있습니다. 이는 개별 셀 서식 오버라이드가 아닌 프리셋 자체를 식별합니다.

예제는 표를 만든 뒤 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1)를 적용하고 프리셋을 다시 읽습니다. `DarkStyle1`에 해당하는 정수 값을 출력하고 `table.pptx`에 표를 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**이미 만든 표에 PowerPoint 테마/스타일을 적용할 수 있나요?**

네. 표는 슬라이드/레이아웃/마스터 테마를 상속받으며, 그 위에 채우기, 테두리, 텍스트 색상을 별도로 오버라이드할 수 있습니다.

**Excel처럼 표 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 표에는 내장된 정렬 또는 필터 기능이 없습니다. 데이터를 메모리에서 먼저 정렬한 뒤 해당 순서대로 표 행을 다시 채워야 합니다.

**특정 셀에 사용자 정의 색상을 유지하면서 줄무늬(밴디드) 열을 사용할 수 있나요?**

네. 줄무늬 열을 활성화한 뒤 특정 셀에 로컬 서식을 적용하면 셀 수준 서식이 표 스타일보다 우선합니다.