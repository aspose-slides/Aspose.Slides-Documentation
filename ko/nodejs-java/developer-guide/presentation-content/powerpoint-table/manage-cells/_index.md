---
title: JavaScript를 사용한 프레젠테이션에서 테이블 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/nodejs-java/manage-cells/
keywords:
- 테이블 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내부 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides를 사용하여 PowerPoint에서 테이블 셀을 관리합니다. 셀에 대한 접근, 수정 및 스타일링을 빠르게 마스터하여 원활한 슬라이드 자동화를 실현하세요."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 테이블 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 뒤 셀 번호 매기기를 처리하는 방법, 셀 배경색을 변경하는 방법, 그리고 테이블 셀 내부에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 테이블을 가져오며, 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

## **병합된 테이블 셀 식별**
1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에서 테이블을 가져옵니다. 
3. 테이블의 행과 열을 순회하면서 병합된 셀을 찾습니다.
4. 병합된 셀이 발견되면 메시지를 출력합니다.

다음 JavaScript 코드는 프레젠테이션에서 병합된 테이블 셀을 식별하는 방법을 보여 줍니다:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// Slide#0.Shape#0이 테이블이라고 가정합니다
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **테이블 셀 테두리 제거**
1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. 너비가 지정된 열 배열을 정의합니다.
4. 높이가 지정된 행 배열을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 메서드를 사용하여 슬라이드에 테이블을 추가합니다.
6. 모든 셀을 순회하면서 위, 아래, 오른쪽, 왼쪽 테두리를 모두 지웁니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 테이블 셀의 테두리를 제거하는 방법을 보여 줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 슬라이드에 테이블 도형을 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀에 대한 테두리 형식을 설정합니다
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // PPTX를 디스크에 저장합니다
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **병합 셀의 번호 매기기**
2개의 셀 쌍 (1, 1) x (2, 1)과 (1, 2) x (2, 2)를 병합하면 결과 테이블에 번호가 매겨집니다. 다음 JavaScript 코드가 그 과정을 보여 줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 슬라이드에 테이블 도형을 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀에 대한 테두리 형식을 설정합니다
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
    // 셀 (1, 1) x (2, 1)을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // 셀 (1, 2) x (2, 2)를 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

그런 다음 (1, 1)과 (1, 2)를 다시 병합하여 중앙에 큰 병합 셀이 있는 테이블을 만듭니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 슬라이드에 테이블 도형을 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀에 대한 테두리 형식을 설정합니다
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
    // 셀 (1, 1) x (2, 1)을 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // 셀 (1, 2) x (2, 2)를 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // 셀 (1, 1) x (1, 2)를 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **분할 셀의 번호 매기기**
앞선 예제에서는 테이블 셀이 병합될 때 다른 셀의 번호 체계는 변하지 않았습니다.

이번에는 병합되지 않은 일반 테이블을 사용하고 (1, 1) 셀을 분할하여 특수한 테이블을 만들었습니다. 이 테이블의 번호 매기기가 다소 이상하게 보일 수 있지만, 이는 Microsoft PowerPoint가 테이블 셀에 번호를 매기는 방식이며 Aspose.Slides도 동일하게 동작합니다.

다음 JavaScript 코드는 위에서 설명한 과정을 보여 줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 슬라이드에 테이블 도형을 추가합니다
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 각 셀에 대한 테두리 형식을 설정합니다
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
    // 셀 (1, 1) x (2, 1)를 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // 셀 (1, 2) x (2, 2)를 병합합니다
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // 셀 (1, 1)을 분할합니다
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **테이블 셀 배경색 변경**

다음 JavaScript 코드는 테이블 셀의 배경색을 변경하는 방법을 보여 줍니다:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // 새 테이블을 생성합니다
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // 셀의 배경색을 설정합니다
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **테이블 셀 내부에 이미지 추가**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 너비가 지정된 열 배열을 정의합니다.
4. 높이가 지정된 행 배열을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 메서드를 사용하여 슬라이드에 테이블을 추가합니다.
6. 이미지 파일을 보유할 `Images` 객체를 생성합니다.
7. `IImage` 이미지를 `PPImage` 객체에 추가합니다.
8. 테이블 셀의 `FillFormat`을 `Picture`로 설정합니다.
9. 이미지를 테이블의 첫 번째 셀에 추가합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 테이블을 만들 때 셀 내부에 이미지를 배치하는 방법을 보여 줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var islide = pres.getSlides().get_Item(0);
    // 너비가 지정된 열과 높이가 지정된 행을 정의합니다
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // 슬라이드에 테이블 도형을 추가합니다
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // 이미지 파일을 사용하여 PPImage 객체를 생성합니다
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 이미지를 첫 번째 테이블 셀에 추가합니다
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**단일 셀의 서로 다른 면에 대해 다른 선 두께와 스타일을 지정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cellformat/getborderright/) 테두리는 별도의 속성을 가지고 있으므로 각 면의 두께와 스타일을 다르게 지정할 수 있습니다. 이는 본문에서 설명한 셀 단위 면별 테두리 제어와 논리적으로 일치합니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillmode/) (stretch/​tile)에 따라 달라집니다. stretch인 경우 이미지가 새로운 셀 크기에 맞게 조정되고, tile인 경우 타일이 다시 계산됩니다. 본문에서는 셀 내 이미지 표시 모드에 대해 언급했습니다.

**셀 내용 전체에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/nodejs-java/manage-hyperlinks/)는 셀의 텍스트 프레임 내 텍스트(부분) 수준이나 전체 테이블/쉐이프 수준에서 설정됩니다. 실제로는 부분에 링크를 지정하거나 셀의 전체 텍스트에 링크를 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 사용할 수 있나요?**

예. 셀의 텍스트 프레임은 [portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)(런) 별로 독립적인 서식(글꼴 종류, 스타일, 크기, 색상)을 지원합니다.