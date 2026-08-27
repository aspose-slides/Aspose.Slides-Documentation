---
title: JavaScript로 프레젠테이션 표 관리
linktitle: 표 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-table/
keywords:
- 표 추가
- 표 만들기
- 표 접근
- 종횡비
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집합니다. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 표시하고 전달하는 효율적인 방법입니다. 행과 열로 배열된 셀 그리드에 있는 정보는 직관적이며 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 클래스, [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/) 클래스 및 기타 유형을 제공하여 모든 종류의 프레젠테이션에서 표를 생성, 업데이트 및 관리할 수 있게 합니다.

## **처음부터 표 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. `columnWidth` 배열을 정의합니다.  
4. `rowHeight` 배열을 정의합니다.  
5. [addTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 메서드를 통해 슬라이드에 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 추가합니다.  
6. 각 [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/)을 반복하여 상단, 하단, 오른쪽 및 왼쪽 테두리에 서식을 적용합니다.  
7. 표의 왼쪽 상단 모서리(첫 번째 두 행의 첫 번째 두 열)에 있는 네 개의 셀을 하나의 셀로 병합합니다.  
8. [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/)의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.  
9. [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 텍스트를 추가합니다.  
10. 수정된 프레젠테이션을 저장합니다.  

이 JavaScript 코드는 프레젠테이션에서 표를 만드는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 열 너비와 행 높이를 정의합니다
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 슬라이드에 표 셰이프를 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀의 테두리 형식을 설정합니다
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // 왼쪽 상단 2x2 셀 블록을 하나의 셀로 병합합니다
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // 병합된 셀에 텍스트를 추가합니다
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표준 표에서 번호 매기기**

표준 표에서는 셀 번호 매기기가 직관적이며 0부터 시작합니다. 표의 첫 번째 셀은 0,0(열 0, 행 0)으로 인덱싱됩니다.  

예를 들어, 4열 4행 표의 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 JavaScript 코드는 표에서 셀 번호를 지정하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 열 너비와 행 높이를 정의합니다
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 슬라이드에 표 셰이프를 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀의 테두리 형식을 설정합니다
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **기존 표에 접근하기**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 표가 포함된 슬라이드에 대한 참조를 가져옵니다.  
3. [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 생성하고 null로 설정합니다.  
4. 표가 발견될 때까지 모든 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 객체를 반복합니다.  
   슬라이드에 단일 표만 포함되어 있다고 의심되는 경우, 포함된 모든 도형을 확인하면 됩니다. 도형이 표로 식별되면 이를 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체로 타입 캐스트할 수 있습니다. 슬라이드에 여러 표가 포함되어 있는 경우, [setAlternativeText(String value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-)을 통해 원하는 표를 검색하는 것이 좋습니다.  
5. [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 사용하여 표를 작업합니다. 아래 예제에서는 표 셀의 텍스트를 설정합니다.  
6. 수정된 프레젠테이션을 저장합니다.  

이 JavaScript 코드는 기존 표에 접근하고 작업하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // null TableEx를 초기화합니다
    var tbl = null;
    // 도형들을 반복하면서 찾은 표에 대한 참조를 설정합니다
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // 두 번째 행의 첫 번째 열에 텍스트를 설정합니다
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **텍스트 프레임을 소유하는 셀 찾기**

표에서 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 받는 일반 텍스트 처리 코드는 해당 프레임의 소유자 [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/)을 가져오기 위해 [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentCell--) 메서드를 사용합니다. 표 셀 텍스트 프레임의 경우, [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentCell--)은 소유자를 반환하고 [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentShape--)은 `null`을 반환합니다(표 자체도 도형이지만).  

셀 좌표는 읽기 전용 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) 및 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) 메서드를 통해 얻을 수 있습니다. [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentCell--)은 또한 읽기 전용 내비게이션을 제공하며, 소유자를 반환하지만 소유권을 변경하지 않습니다. 사용하기 전에 반환된 셀이 `null`인지 항상 확인하십시오.  

표 셀 및 도형 소유자를 식별하는 완전한 예제(스마트아트 노드와 연결된 도형 포함)는 [Search and Replace Text](/slides/ko/nodejs-java/search-and-replace-text/)를 참고하십시오.

## **표에서 텍스트 정렬**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 추가합니다.  
4. 표에서 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 객체에 접근합니다.  
5. [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)의 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/)에 접근합니다.  
6. 텍스트를 수직으로 정렬합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

이 JavaScript 코드는 표에서 텍스트를 정렬하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    // 열 너비와 행 높이를 정의합니다
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // 슬라이드에 표 셰이프를 추가합니다
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // 텍스트 프레임에 접근합니다
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // 텍스트 프레임용 Paragraph 객체를 생성합니다
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Paragraph용 Portion 객체를 생성합니다
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 텍스트를 수직으로 정렬합니다
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 수준에서 텍스트 서식 설정**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체에 접근합니다.  
4. 텍스트에 대해 [setFontHeight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)을 설정합니다.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 및 [setMarginRight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)을 설정합니다.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)을 설정합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

이 JavaScript 코드는 표의 텍스트에 원하는 서식 옵션을 적용하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // 첫 번째 슬라이드의 첫 번째 도형이 표라고 가정합니다
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 표 셀의 글꼴 높이를 설정합니다
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // 표 셀의 텍스트 정렬과 오른쪽 여백을 한 번에 설정합니다
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // 표 셀의 텍스트 수직 유형을 설정합니다
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 스타일 프리셋 설정**

Aspose.Slides는 내장된 PowerPoint 표 스타일을 [TableStylePreset](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tablestylepreset/) 열거형으로 제공하므로, 어떤 표에도 동일한 모양을 적용할 수 있습니다. 이 JavaScript 코드는 표의 기본 스타일을 프리셋 스타일로 교체하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// 기본 스타일 프리셋 테마를 변경합니다
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표의 종횡비 잠금**

기하학적 도형의 종횡비는 서로 다른 차원에서의 크기 비율을 의미합니다. Aspose.Slides는 표 및 기타 도형에 대한 종횡비 잠금 설정을 허용하기 위해 [**setAspectRatioLocked**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) 속성을 제공합니다.

이 JavaScript 코드는 표의 종횡비를 잠그는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// 반전
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**전체 표와 셀 내 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [setRightToLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/setrighttoleft/) 메서드를 제공하고, 단락은 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/)를 가지고 있습니다. 두 가지를 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링을 보장할 수 있습니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 조정하지 못하도록 할 수 있나요?**

도형 잠금을 사용하여 이동, 크기 조정, 선택 등을 비활성화하십시오. 이러한 잠금은 표에도 적용됩니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/)을 설정하면 이미지가 선택한 모드(확대 또는 타일)에 따라 셀 영역을 채웁니다.