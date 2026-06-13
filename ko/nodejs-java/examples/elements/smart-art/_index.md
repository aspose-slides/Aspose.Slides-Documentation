---
title: 스마트아트
type: docs
weight: 140
url: /ko/nodejs-java/examples/elements/smart-art/
keywords:
- 코드 예제
- 스마트아트
- 파워포인트
- OpenDocument
- 프레젠테이션
- Node.js
- 자바스크립트
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 스마트아트를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션용 JavaScript로 다이어그램을 만들고, 편집하고, 변환하고, 스타일을 지정합니다."
---
이 문서는 **Aspose.Slides for Node.js via Java**를 사용하여 SmartArt 그래픽을 추가하고, 액세스하고, 제거하며, 레이아웃을 변경하는 방법을 보여줍니다.

## **SmartArt 추가**

내장된 레이아웃 중 하나를 사용하여 SmartArt 그래픽을 삽입합니다.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt 액세스**

슬라이드에서 첫 번째 SmartArt 개체를 가져옵니다.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt 제거**

슬라이드에서 SmartArt 도형을 삭제합니다.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 SmartArt라고 가정합니다.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt 레이아웃 변경**

기존 SmartArt 그래픽의 레이아웃 유형을 업데이트합니다.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형이 SmartArt라고 가정합니다.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```