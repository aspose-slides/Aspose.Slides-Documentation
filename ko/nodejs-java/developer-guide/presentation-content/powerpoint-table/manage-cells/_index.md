---
title: JavaScript를 사용하여 프레젠테이션에서 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/nodejs-java/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 PowerPoint 표 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 배경 색상 및 이미지를 Aspose.Slides for Node.js를 통해 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 표 셀에 접근하고 수정할 수 있습니다. 이 문서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 처리하는 방법, 셀 배경 색상을 변경하는 방법, 그리고 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 만들거나 열고, 슬라이드에서 표를 가져와 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

Aspose.Slides는 `(column, row)` 순서로 표 셀에 접근하기 위해 0부터 시작하는 인덱스를 사용합니다.

## **병합된 표 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 표로 접근합니다. 슬라이드와 도형이 존재하며 도형이 표라고 가정합니다. 그런 다음 모든 행과 열을 반복하면서 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/)을 사용해 병합된 영역의 셀을 식별합니다. 일치하는 각 셀에 대해 `row;column` 순서로 셀 좌표와 [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), 그리고 영역의 시작 좌표인 [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) 및 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)를 출력합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **표 셀 테두리 제거**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성하고 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/)을 사용해 첫 번째 슬라이드에 표를 추가합니다. 열 너비, 행 높이 및 표 위치는 포인트 단위로 지정됩니다. 예제에서는 모든 네 개의 셀 테두리를 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)으로 설정하여 보이지 않게 만듭니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **대각선 셀 테두리 추가**

대각선 아래쪽([getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/))을 사용해 왼쪽 위 모서리에서 오른쪽 아래 모서리까지 선을 그리고, 대각선 위쪽([getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/))을 사용해 왼쪽 아래 모서리에서 오른쪽 위 모서리까지 선을 그립니다. 대각선은 코너 헤더를 표시할 수 있으며, 두 대각선을 모두 사용하면 셀을 적용 불가로 표시하는 X를 만들 수 있습니다.

각 대각선은 [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/)입니다. 해당 [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/)에서 [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/)을 사용해 [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)를 선택하고 [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/)를 통해 색상을 지정합니다. 선의 두께는 포인트 단위로 [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/)로 설정합니다.

예제에서는 한 행에 세 개의 셀을 만들고, 각각 빨간 색상의 아래쪽 대각선, 파란 색상의 위쪽 대각선, 그리고 두 대각선을 모두 포함합니다. 상단, 하단, 왼쪽, 오른쪽 셀 테두리는 변경하지 않은 채로 둡니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

대각선은 셀 분할이 아니라 서식 속성입니다. 각 셀은 [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/)을 통해 접근되는 단일 텍스트 프레임을 유지하며, 대각선 양쪽 영역을 독립적으로 편집할 수 없습니다.

Microsoft PowerPoint에서 렌더링된 저장된 표:

![왼쪽 위에서 오른쪽 아래로 빨간 대각선, 왼쪽 아래에서 오른쪽 위로 파란 대각선, 그리고 X를 형성하는 두 대각선을 보여주는 세 개의 표 셀](diagonal-cell-borders.png)

*왼쪽부터 오른쪽: 아래쪽 대각선(빨강, 3 pt), 위쪽 대각선(파랑, 5 pt), 그리고 두 대각선.*

## **표 셀 병합**

[mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/)을 사용해 직사각형 영역의 표 셀들을 하나의 셀로 결합합니다. 영역의 왼쪽 위와 오른쪽 아래 셀을 지정합니다. 마지막 인자는 병합이 지정된 영역 외의 셀을 포함할 수 있는지를 제어하며, `false`는 병합을 해당 영역 내에만 유지합니다.

예제에서는 70 포인트 열과 행을 가진 4x4 표를 만든 다음, 중앙 네 개의 셀을 `(1, 1)`부터 `(2, 2)`까지 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 표의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 왼쪽 위 위치인 `table.get_Item(1, 1)`을 사용합니다. 병합 영역 외의 다른 위치는 표 그리드의 일부로 남아 있어, 범위 밖 셀의 인덱스는 변경되지 않습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 셀 분할**

이전 예제에서 셀을 병합하면 표의 그리드가 유지됩니다. 셀을 분할하면 새로운 그리드 열이 추가되고 오른쪽 셀들의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 표 그리드 모델을 따릅니다.

예제에서는 70 포인트 열과 행을 가진 4x4 표를 만든 뒤 셀 `(1, 1)`에 대해 [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/)을 호출합니다. 셀의 70 포인트 너비의 절반을 사용해 두 개의 동일한 너비 셀을 생성합니다.

분할 후 두 반쪽은 `table.get_Item(1, 1)` 및 `table.get_Item(2, 1)`으로 접근합니다. 표 그리드는 이제 다섯 열을 가지며, 원래 2열과 3열에 있던 셀은 각각 3열과 4열로 이동합니다. 행 인덱스는 변경되지 않습니다. 분할 후 셀에 접근할 때는 이러한 업데이트된 열 인덱스를 사용하십시오.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![병합되지 않은 70포인트 셀이 두 개의 35포인트 셀로 분할되어 다섯 번째 그리드 열이 추가되고 오른쪽의 인덱스가 이동합니다.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*너비 분할은 (1, 1) 셀에 영향을 주며, 0부터 시작하는 (column, row) 인덱스를 사용합니다. 다른 행들은 두 새로운 열 위치를 모두 차지하는 셀을 유지합니다.*
<!-- visual-explanation:manage-cells:end -->

### **행 또는 열 범위로 병합된 셀 분할**

데이터 입력을 위해 병합된 템플릿 셀을 준비하려면, 기존 행 경계를 따라 분할하려면 [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/)을 사용하고, 열 경계를 따라 분할하려면 [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/)을 사용합니다.

`index` 인자는 분할 상단 부분의 행 수 또는 왼쪽 부분의 열 수를 셉니다; 이는 병합된 영역을 기준으로 합니다:

- 행 분할: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)
- 열 분할: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)

예제에서는 프레젠테이션에 첫 번째 슬라이드의 첫 번째 도형으로 표가 있으며, `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 하단 위치에서 시작해 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)와 [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/)를 사용해 시작점을 찾고 두 스팬을 확인합니다. `splitByRowSpan(1)`은 제품 이름을 위해 행 2와 3을 분리합니다. 가로 두 열 병합의 경우 `splitByColSpan(1)`을 사용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // 분할 후 테이블에서 결과 셀을 가져옵니다.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

표 그리드와 주변 셀 인덱스는 변경되지 않습니다. 좌표로 결과 셀을 가져오면, 여기서는 두 셀 모두 span이 1이며 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/)은 `false`를 반환합니다. 더 큰 영역은 하나의 분할 후에도 부분적으로 병합된 상태를 유지할 수 있습니다.

원본 텍스트와 서식은 상위(또는 왼쪽) 셀에 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속합니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿의 셀 서식을 유지한 채 "Product A"와 "Product B" 셀이 별도로 포함됩니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)를 참조하십시오.

### **특정 높이에서 셀 분할**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/)은 상단 부분의 높이를 포인트 단위로 받아들입니다. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/)은 상단 부분에 있는 기존 그리드 행 수를 받아들입니다. 오른쪽 열에 40포인트 셀을 가운데 배치하려면 셀 실제 높이에서 40을 빼고 남은 공간을 위와 아래에 동일하게 나눕니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

첫 번째 분할은 그리드 행을 추가하고 셀 `(1, 1)`의 아래쪽 90포인트를 남깁니다. 두 번째 분할은 해당 셀을 40포인트 중간 셀과 50포인트 하단 셀로 나눕니다. 오른쪽 열은 이제 위에서 아래로 50, 40, 50포인트 높이의 세 셀을 가집니다. 왼쪽 셀은 세 행을 모두 차지하며 원래 높이인 140포인트를 유지합니다.

![왼쪽 셀은 가운데에 'Middle'이 있는 세 개의 셀 옆에 전체 표 높이를 차지합니다.](split-by-height.png)

## **표 셀 배경 색상 변경**

예제에서는 150포인트 열과 50포인트 행을 가진 표를 생성합니다. [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/)을 사용해 단색 채우기를 선택하고, [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/)이 반환하는 색상을 셀 `(2, 3)`(세 번째 열, 네 번째 행)에서 빨간색으로 설정합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **표 셀 안에 이미지 추가**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지는 [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile)을 사용해 로드하고 [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/)을 사용해 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 표의 첫 번째 셀인 `(0, 0)`의 그림 채우기에 할당합니다.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 늘려 채우며, 이 경우 종횡비가 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 `finally` 블록에서 해제됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**단일 셀의 각 면에 대해 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) 테두리는 각각 별도의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 설정할 수 있습니다.

**셀 배경으로 그림을 설정한 후 열/행 크기를 변경하면 이미지에 어떤 일이 발생하나요?**

동작은 [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)에 따라 다릅니다. stretch인 경우 이미지가 새로운 셀 크기에 맞게 조정되고, tile인 경우 타일이 다시 계산됩니다.

**셀의 전체 내용에 하이퍼링크를 할당할 수 있나요?**

[Hyperlinks](/slides/ko/nodejs-java/manage-hyperlinks/)는 셀의 텍스트 프레임 내부 텍스트(구절) 수준 또는 전체 표/도형 수준에서 설정됩니다. 실제로는 구절에 링크를 할당하거나 셀의 모든 텍스트에 할당합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)(런)별 독립적인 서식을 지원하므로 글꼴 종류, 스타일, 크기 및 색상을 각각 지정할 수 있습니다.