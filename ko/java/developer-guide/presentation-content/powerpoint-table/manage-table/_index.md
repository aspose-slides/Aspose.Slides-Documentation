---
title: Java에서 프레젠테이션 테이블 관리
linktitle: 테이블 관리
type: docs
weight: 10
url: /ko/java/manage-table/
keywords:
- 테이블 추가
- 테이블 만들기
- 테이블 접근
- 가로세로 비율
- 텍스트 정렬
- 텍스트 서식
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 슬라이드에서 테이블을 만들고 편집합니다. 테이블 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 테이블은 정보를 행과 열로 정리하여 값을 읽고 비교하기 쉽게 해줍니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 인터페이스, [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) 클래스, [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) 인터페이스 및 기타 유형을 제공하여 프레젠테이션에서 테이블을 만들고, 업데이트하고, 관리할 수 있게 해줍니다.

## **테이블을 처음부터 만들기**

위치, 열 폭 및 행 높이를 지정하여 테이블을 만듭니다. 슬라이드에 추가한 후 셀 테두리를 서식 지정하고, 셀을 병합하고, 텍스트를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 포인트 단위의 열 폭 배열을 정의합니다.
4. 포인트 단위의 행 높이 배열을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 메서드를 통해 슬라이드에 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 객체를 추가합니다.
6. 각 [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/)을 반복하면서 상, 하, 좌, 우 테두리 서식을 적용합니다.
7. 테이블 첫 번째 행의 처음 두 셀을 병합합니다.
8. 병합된 셀을 [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) 메서드로 접근합니다.
9. 병합된 셀에 텍스트를 설정합니다.
10. 수정된 프레젠테이션을 저장합니다.

아래 예제는 (100, 50) 포인트 위치에 열 3개, 행 5개인 테이블을 만들고, 빨간색 테두리(두께 5 포인트)를 적용하며, 첫 번째 행의 처음 두 셀을 병합하고, 결과를 `table.pptx`로 저장합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표준 테이블에서 번호 매기기**

표준 테이블에서 셀 인덱스는 0부터 시작하며 순서는 (열, 행)입니다. 첫 번째 셀은 (0, 0)으로 인덱싱됩니다.

예를 들어, 4열 4행 테이블의 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 예제는 위에 표시된 4 × 4 테이블을 만들고, 열 폭과 행 높이를 70 포인트, 빨간색 셀 테두리(두께 5 포인트)로 설정합니다. 좌표는 셀 인덱스를 나타내며, 셀은 비워 두고 `StandardTables_out.pptx`로 저장합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **기존 테이블에 접근하기**

테이블은 슬라이드의 shape 컬렉션에 저장됩니다. shape들을 순회하여 테이블을 찾은 다음, [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 인터페이스를 사용해 셀을 읽거나 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.
2. 인덱스로 테이블이 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 객체들을 순회하면서 테이블을 찾을 때까지 진행합니다. 슬라이드에 여러 테이블이 있는 경우, [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--)를 사용해 원하는 테이블을 식별합니다.
4. 대상 셀의 텍스트를 업데이트합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `UpdateExistingTable.pptx`를 열어 첫 번째 슬라이드의 첫 번째 테이블을 찾고, 열 0, 행 1 셀에 `New`를 설정한 뒤 결과를 `table1_out.pptx`로 저장합니다. 입력 파일에는 최소 하나의 슬라이드가 있어야 하며, 해당 슬라이드의 첫 번째 테이블은 최소 하나의 열과 두 개의 행을 포함해야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

기존 테이블의 행 높이를 조정하고 실제 높이가 요청한 최소값을 초과할 수 있는 이유를 보려면 [Control Row Height](/slides/ko/java/manage-rows-and-columns/#control-row-height)를 참조하십시오.

## **텍스트 프레임을 소유한 셀 찾기**

일반 텍스트 처리 코드가 테이블에서 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)를 받을 때, [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) 메서드를 사용해 소유자 [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/)을 가져옵니다. 테이블 셀 텍스트 프레임의 경우, [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--)는 소유자를 반환하고, [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--)는 `null`을 반환합니다(테이블 자체도 shape이지만).

셀 좌표는 읽기 전용 [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) 및 [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) 메서드를 통해 확인할 수 있습니다. [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--)은 또한 읽기 전용 탐색을 제공하며, 반환된 셀이 `null`인지 항상 확인한 후 사용하십시오.

테이블 셀 및 shape 소유자를 식별하는 전체 예제(스마트아트 노드와 연결된 shape 포함)는 [Search and Replace Text](/slides/ko/java/search-and-replace-text/)를 참조하십시오.

## **테이블에서 텍스트 정렬**

개별 테이블 셀의 수직 정렬 및 텍스트 방향을 제어할 수 있습니다. 이 섹션의 예제는 첫 번째 셀의 텍스트를 가운데 정렬하고 270도 회전시킵니다.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 객체를 추가합니다.
4. 테이블에서 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) 객체에 접근합니다.
5. 첫 번째 [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/)에 접근하여 텍스트와 색상을 설정합니다.
6. [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) 및 [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-)을 사용해 셀의 수직 정렬과 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 예제는 열 폭 120 포인트, 행 높이 100 포인트인 4 × 4 테이블을 만들고, 셀 (0, 0)의 텍스트를 서식 지정한 뒤 첫 번째 행의 나머지 셀에 값을 추가하고 `Vertical_Align_Text_out.pptx`로 저장합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **테이블 수준에서 텍스트 서식 설정**

[setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-)을 사용하면 테이블의 모든 셀에 텍스트 서식을 적용할 수 있습니다. 이 메서드의 오버로드는 부분, 단락 및 텍스트 프레임 서식을 받아 개별 셀을 반복하지 않아도 이러한 속성을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 객체에 접근합니다.
4. 텍스트에 대해 [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)을 사용해 글꼴 크기를 설정합니다.
5. [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 및 [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)을 사용해 단락 정렬과 오른쪽 여백을 설정합니다.
6. [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)을 사용해 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

아래 예제는 최소 하나의 슬라이드와 첫 번째 shape가 테이블인 `table.pptx`를 열어 글꼴 크기를 25 포인트로 설정하고, 오른쪽 여백 20 포인트로 단락을 오른쪽 정렬하며, 텍스트를 수직으로 전환한 뒤 `result.pptx`로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **테이블 스타일 속성 가져오기**

[getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--)을 사용해 테이블의 사전 정의된 스타일을 읽고, [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-)을 사용해 스타일을 지정합니다. 이 예제는 하나의 테이블에 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/)을 적용하고, 사전 값을 출력한 뒤 동일한 사전값을 두 번째 테이블에 할당합니다. 두 테이블은 `table-style.pptx`에 저장됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **테이블의 가로세로 비율 고정**

테이블의 가로세로 비율은 너비와 높이의 비율을 의미합니다. [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-)을 사용해 이 비율을 고정할 수 있습니다.

아래 예제는 최소 하나의 슬라이드와 첫 번째 shape가 테이블인 `pres.pptx`를 열어 현재 잠금 상태를 출력하고, 가로세로 비율 잠금을 활성화한 뒤 업데이트된 상태(`true`)를 출력하고 `pres-out.pptx`로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**전체 테이블과 셀 내부 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 테이블은 [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) 메서드를 제공하며, 단락은 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-)을 지원합니다. 두 메서드를 모두 사용하면 셀 내부에서도 올바른 RTL 순서와 렌더링이 보장됩니다.

**최종 파일에서 사용자가 테이블을 이동하거나 크기를 조정하지 못하게 하려면 어떻게 해야 하나요?**

[shape locks](/slides/ko/java/applying-protection-to-presentation/)를 사용해 이동, 크기 조정, 선택 등을 비활성화하십시오. 이러한 잠금은 테이블에도 적용됩니다.

**셀 내부에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/)을 설정하면 이미지가 선택한 모드(늘리기 또는 타일)대로 셀 영역을 덮습니다.