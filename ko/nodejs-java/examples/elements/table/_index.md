---
title: 표
type: docs
weight: 120
url: /ko/nodejs-java/examples/elements/table/
keywords:
- 코드 예제
- 표
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 표를 사용하여 생성, 서식 지정, 셀 병합, 스타일 적용, 데이터 가져오기 및 PPT, PPTX 및 ODP 예시와 함께 내보내기 작업을 수행합니다."
---
Node.js via Java에서 **Aspose.Slides for Node.js via Java**를 사용하여 표를 추가하고, 접근하고, 제거하고, 셀을 병합하는 예제입니다.

## **표 추가**

두 개의 행과 두 개의 열을 가진 간단한 표를 만듭니다.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **표 접근**

슬라이드에서 첫 번째 표 모양을 가져옵니다.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 슬라이드에서 첫 번째 표에 접근합니다.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **표 제거**

슬라이드에서 표를 삭제합니다.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 표라고 가정합니다.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **표 셀 병합**

표의 인접한 셀을 하나의 셀로 병합합니다.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 표라고 가정합니다.
        let table = slide.getShapes().get_Item(0);

        // 셀을 병합합니다.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```