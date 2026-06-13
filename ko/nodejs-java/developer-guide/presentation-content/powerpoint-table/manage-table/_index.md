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
description: "JavaScript와 Node.js용 Aspose.Slides를 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집하세요. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하십시오."
---
## **소개**

PowerPoint의 표는 정보를 표시하고 전달하는 효율적인 방법입니다. 행과 열로 배열된 셀 그리드에 있는 정보는 직관적이며 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 클래스, [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/) 클래스 및 기타 유형을 제공하여 모든 종류의 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있습니다.

## **스크래치에서 테이블 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. `columnWidth` 배열을 정의합니다.  
4. `rowHeight` 배열을 정의합니다.  
5. [addTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 메서드를 사용하여 슬라이드에 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 추가합니다.  
6. 각 [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/)을 순회하면서 상하좌우 테두리에 서식을 적용합니다.  
7. 표 첫 번째 행의 처음 두 셀을 병합합니다.  
8. [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.  
9. [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 텍스트를 추가합니다.  
10. 수정된 프레젠테이션을 저장합니다.

This JavaScript code shows you how to create a table in a presentation:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 열의 너비와 행의 높이를 정의합니다
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 슬라이드에 테이블 모양을 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀에 대한 테두리 서식을 설정합니다
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
    // 1행의 셀 1과 2를 병합합니다
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

## **표준 표에서의 번호 매기기**

표준 표에서 셀 번호 매기는 방식은 단순하고 0부터 시작합니다. 표의 첫 번째 셀은 0,0 (열 0, 행 0)으로 인덱스가 매겨집니다.  

예를 들어, 4열 4행 표의 셀 번호는 다음과 같습니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This JavaScript code shows you how to specify the numbering for cells in a table:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 열 너비와 행 높이를 정의합니다
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 슬라이드에 표 모양을 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀에 대한 테두리 서식을 설정합니다
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

## **기존 테이블에 접근**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 표가 포함된 슬라이드에 대한 참조를 가져옵니다.  
3. [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 생성하고 null로 설정합니다.  
4. 표가 발견될 때까지 모든 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 객체를 순회합니다.  

   처리 중인 슬라이드에 단일 표만 포함되어 있다고 생각한다면, 포함된 모든 도형을 확인하면 됩니다. 도형이 표로 확인되면 이를 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체로 형변환할 수 있습니다. 하지만 슬라이드에 여러 표가 포함되어 있다면, 필요한 표를 [setAlternativeText(String value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) 메서드를 통해 검색하는 것이 좋습니다.  

5. [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 사용하여 표를 작업합니다. 아래 예제에서는 표에 새 행을 추가했습니다.  
6. 수정된 프레젠테이션을 저장합니다.

This JavaScript code shows you how to access and work with an existing table:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // null TableEx를 초기화합니다
    var tbl = null;
    // 도형들을 순회하면서 찾은 표에 대한 참조를 설정합니다
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

## **표에서 텍스트 정렬**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 슬라이드에 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체를 추가합니다.  
4. 표에서 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 객체에 접근합니다.  
5. [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)의 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/)에 접근합니다.  
6. 텍스트를 수직으로 정렬합니다.  
7. 수정된 프레젠테이션을 저장합니다.

This JavaScript code shows you how to align the text in a table:

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    // 열 너비와 행 높이를 정의합니다
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // 슬라이드에 표 모양을 추가합니다
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // 텍스트 프레임에 접근합니다
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // 텍스트 프레임에 대한 Paragraph 객체를 생성합니다
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Paragraph에 대한 Portion 객체를 생성합니다
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 텍스트를 수직으로 정렬합니다
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
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
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Table) 객체에 접근합니다.  
4. 텍스트에 대한 [setFontHeight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) 메서드를 설정합니다.  
5. [setAlignment(int value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 및 [setMarginRight(float value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) 메서드를 설정합니다.  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 메서드를 설정합니다.  
7. 수정된 프레젠테이션을 저장합니다.

This JavaScript code shows you how to apply your preferred formatting options to the text in a table:

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // 첫 번째 슬라이드의 첫 번째 도형이 표라고 가정합니다
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 표 셀의 글꼴 높이를 설정합니다
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // 한 번에 표 셀의 텍스트 정렬과 오른쪽 여백을 설정합니다
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // 표 셀의 텍스트 수직 방향을 설정합니다
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 스타일 속성 가져오기**

Aspose.Slides는 표에 대한 스타일 속성을 검색할 수 있게 하여 해당 세부 정보를 다른 표나 다른 위치에 사용할 수 있도록 합니다. 이 JavaScript 코드는 표 사전 설정 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// 기본 스타일 사전 설정 테마를 변경합니다
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표의 종횡비 잠금**

기하학적 도형의 종횡비는 다른 차원에서 크기의 비율을 의미합니다. Aspose.Slides는 표 및 기타 도형에 대한 종횡비 잠금 설정을 할 수 있도록 [**setAspectRatioLocked**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) 속성을 제공했습니다.

This JavaScript code shows you how to lock the aspect ratio for a table:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**전체 표와 셀 안의 텍스트에 오른쪽-왼쪽(RTL) 읽기 방향을 설정할 수 있나요?**

예. 표는 [setRightToLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/setrighttoleft/) 메서드를 제공하고, 단락은 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) 메서드를 제공합니다. 두 메서드를 모두 사용하면 셀 내부의 RTL 순서와 렌더링이 올바르게 적용됩니다.

**최종 파일에서 사용자가 표를 이동하거나 크기 조정하지 못하도록 하려면 어떻게 해야 하나요?**

모양 잠금을 사용하여 이동, 크기 조정, 선택 등을 비활성화합니다. 이러한 잠금은 표에도 적용됩니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/)을 설정할 수 있으며, 선택된 모드(스트레치 또는 타일)에 따라 이미지가 셀 영역을 덮습니다.