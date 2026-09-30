---
title: JavaScript에서 프레젠테이션 테이블 관리
linktitle: 테이블 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-table/
keywords:
- 테이블 추가
- 테이블 생성
- 테이블 액세스
- 가로세로 비율
- 텍스트 정렬
- 텍스트 서식
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집합니다. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 행과 열로 구성하여 값을 읽고 비교하기 쉽게 합니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 클래스, [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) 클래스 및 기타 유형을 제공하여 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있도록 합니다.

## **처음부터 표 만들기**

위치, 열 너비 및 행 높이를 지정하여 표를 만듭니다. 슬라이드에 추가한 후 셀 테두리를 서식 지정하고, 셀을 병합하고, 텍스트를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 열 너비 배열을 포인트 단위로 정의합니다.
4. 행 높이 배열을 포인트 단위로 정의합니다.
5. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) 메서드를 통해 슬라이드에 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 객체를 추가합니다.
6. 각 [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)을 반복하여 상단, 하단, 오른쪽 및 왼쪽 테두리에 서식을 적용합니다.
7. 표 첫 번째 행의 첫 두 셀을 병합합니다.
8. 병합된 셀을 [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) 메서드로 액세스합니다.
9. 병합된 셀에 텍스트를 설정합니다.
10. 수정된 프레젠테이션을 저장합니다.

아래 예제는 (100, 50) 포인트 위치에 3열 5행 표를 생성하고, 빨간색 테두리(두께 5포인트)를 적용하고, 첫 번째 행의 첫 두 셀을 병합한 뒤 결과를 `table.pptx`로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표의 표준 번호 매기기**

표준 표에서 셀 인덱스는 0부터 시작하며 (열, 행) 순서로 사용됩니다. 첫 번째 셀은 (0, 0)으로 인덱싱됩니다.

예를 들어, 4열 4행 표의 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 예제는 위에 표시된 4 × 4 표를 생성하고, 열 너비와 행 높이를 70포인트, 빨간색 셀 테두리(두께 5포인트)로 설정합니다. 좌표는 셀 인덱스를 나타내며, 예제는 셀을 비워 둔 상태로 `StandardTables_out.pptx`로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **기존 표에 액세스하기**

표는 슬라이드의 Shape 컬렉션에 저장됩니다. Shapes를 반복하여 표를 찾은 다음, [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 클래스를 사용해 셀을 읽거나 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 인덱스로 표가 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 객체를 반복하고 표가 발견되면 중단합니다. 슬라이드에 여러 표가 있는 경우 [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--)을 사용해 필요한 표를 식별합니다.
4. 대상 셀의 텍스트를 업데이트합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `UpdateExistingTable.pptx`를 열고 첫 번째 슬라이드에서 첫 번째 표를 찾은 뒤, 열 0, 행 1에 해당하는 셀을 `New`로 설정하고 결과를 `table1_out.pptx`로 저장합니다. 입력 파일에는 최소 하나의 슬라이드가 있어야 하며, 해당 슬라이드의 첫 번째 표는 최소 하나의 열과 두 개의 행을 포함해야 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

기존 표에서 행의 높이를 조정하고 실제 높이가 요청된 최소값을 초과할 수 있는 이유에 대해서는 [Control Row Height](/slides/ko/nodejs-java/manage-rows-and-columns/#control-row-height)를 참조하십시오.

## **텍스트 프레임을 소유한 셀 찾기**

표에서 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)을 받는 일반 텍스트 처리 코드는 [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) 메서드를 사용해 소유 [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)을 가져옵니다. 표 셀 텍스트 프레임의 경우, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--)은 소유자를 반환하고 [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--)은 `null`을 반환합니다(표 자체는 Shape이지만).

셀 좌표는 읽기 전용 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) 및 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) 메서드를 통해 확인할 수 있습니다. [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--)은 읽기 전용 탐색도 제공하며, 반환된 셀이 `null`인지 항상 확인한 후 사용하십시오.

표 셀 및 Shape 소유자를 식별하는 전체 예제(스마트아트 노드와 연결된 Shape 포함)는 [Search and Replace Text](/slides/ko/nodejs-java/search-and-replace-text/)를 참조하십시오.

## **표 안의 텍스트 정렬**

개별 셀의 수직 정렬 및 텍스트 방향을 제어할 수 있습니다. 이 섹션의 예제는 첫 번째 셀의 텍스트를 가운데 정렬하고 270도 회전시킵니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 객체를 추가합니다.
4. 표에서 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 객체에 액세스합니다.
5. 첫 번째 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)에 접근하여 텍스트와 색상을 설정합니다.
6. [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) 및 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-)을 사용해 셀의 수직 정렬과 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 예제는 열 너비 120포인트, 행 높이 100포인트인 4 × 4 표를 만들고, 셀 (0, 0) 의 텍스트를 서식 지정한 뒤 첫 번째 행의 나머지 셀에 값을 추가하고 결과를 `Vertical_Align_Text_out.pptx`로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 수준에서 텍스트 서식 지정하기**

[setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-)을 사용하면 표의 모든 셀에 텍스트 서식을 적용할 수 있습니다. 이 메서드의 오버로드는 부분, 단락 및 텍스트 프레임 서식을 받아 개별 셀을 반복하지 않고도 해당 속성을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 객체에 액세스합니다.
4. 텍스트에 대해 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)을 사용해 글꼴 크기를 설정합니다.
5. [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 및 [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)을 사용해 단락 정렬과 오른쪽 여백을 설정합니다.
6. [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)을 사용해 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

아래 예제는 최소 하나의 슬라이드와 첫 번째 Shape가 표인 `table.pptx`를 열어 글꼴 크기를 25포인트로 설정하고, 오른쪽 여백 20포인트로 단락을 오른쪽 정렬하며, 텍스트를 수직으로 표시한 뒤 결과를 `result.pptx`로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 스타일 속성 가져오기**

[getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--)을 사용해 표의 사전 정의 스타일을 읽고, [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-)을 사용해 적용할 수 있습니다. 이 예제는 하나의 표에 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/)을 적용하고, 프리셋 값을 출력한 뒤 동일한 프리셋을 두 번째 표에 할당합니다. 두 표는 `table-style.pptx`에 저장됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표의 가로세로 비율 고정**

표의 가로세로 비율은 너비와 높이의 비율을 의미합니다. [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-)을 사용해 이 비율을 잠글 수 있습니다.

아래 예제는 최소 하나의 슬라이드와 첫 번째 Shape가 표인 `pres.pptx`를 열어 현재 잠금 상태를 출력하고, 가로세로 비율 잠금을 활성화한 뒤 업데이트된 상태(`true`)를 출력하고 결과를 `pres-out.pptx`로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**전체 표와 셀 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) 메서드를 제공하고, 단락은 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-)을 지원합니다. 둘을 모두 사용하면 셀 내부의 RTL 순서와 렌더링이 올바르게 적용됩니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 조정하지 못하도록 방지하려면 어떻게 해야 하나요?**

[shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/)를 사용해 이동, 크기 조정, 선택 등을 비활성화할 수 있습니다. 이러한 잠금은 표에도 적용됩니다.

**셀 내부에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/)을 설정하면 선택한 모드(늘리기 또는 타일)대로 이미지가 셀 영역을 덮습니다.