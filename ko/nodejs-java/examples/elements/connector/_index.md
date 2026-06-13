---
title: 연결자
type: docs
weight: 190
url: /ko/nodejs-java/examples/elements/connector/
keywords:
- 코드 예제
- 연결자
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 도형 사이에 연결자를 추가, 라우팅 및 스타일링하는 방법을 배우고 PPT, PPTX, ODP 프레젠테이션에 대한 JavaScript 예제를 확인하세요."
---
이 문서에서는 **Aspose.Slides for Node.js via Java**를 사용하여 연결자를 통해 도형을 연결하고 대상을 변경하는 방법을 보여줍니다.

## **연결자 추가**

슬라이드의 두 지점 사이에 연결자 모양을 삽입합니다.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **연결자 접근**

슬라이드에 추가된 첫 번째 연결자 모양을 검색합니다.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 슬라이드에서 첫 번째 연결자에 접근합니다.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **연결자 제거**

슬라이드에서 연결자를 삭제합니다.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 연결자라고 가정하고 이를 제거합니다.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **도형 재연결**

시작 및 끝 대상을 할당하여 연결자를 두 도형에 연결합니다.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```