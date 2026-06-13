---
title: 그룹 도형
type: docs
weight: 170
url: /ko/nodejs-java/examples/elements/group-shape/
keywords:
- 코드 예제
- 그룹 도형
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 그룹화된 도형을 관리합니다: 생성, 중첩, 정렬, 재정렬 및 스타일 적용을 포함한 그룹 도형을 PPT, PPTX 및 ODP 프레젠테이션 예제로 보여줍니다."
---
Node.js를 통해 Java에서 **Aspose.Slides for Node.js via Java**를 사용하여 도형 그룹을 만들고, 접근하고, 그룹 해제 및 제거하는 예제.

## **그룹 도형 추가**

두 개의 기본 도형을 포함하는 그룹을 생성합니다.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **그룹 도형 접근**

슬라이드에서 첫 번째 그룹 도형을 가져옵니다.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **그룹 도형 제거**

슬라이드에서 그룹 도형을 삭제합니다.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 그룹 도형이라고 가정합니다.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **그룹 해제**

도형을 그룹 컨테이너에서 분리합니다.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 그룹 도형이라고 가정합니다.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // 그룹에서 각 도형을 복제하여 슬라이드에 추가합니다.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```