---
title: 잉크
type: docs
weight: 180
url: /ko/nodejs-java/examples/elements/ink/
keywords:
- 코드 예제
- 잉크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 잉크를 사용하세요: 스트로크를 그리기, 가져오기 및 편집하고, 색상과 두께를 조정하며, 예제를 사용해 PPT, PPTX 및 ODP로 내보낼 수 있습니다."
---
이 문서에서는 **Aspose.Slides for Node.js via Java**를 사용하여 기존 잉크 모양에 액세스하고 이를 제거하는 예제를 제공합니다.

> ❗ **Note:** 잉크 모양은 특수 장치에서 사용자가 입력한 것을 나타냅니다. Aspose.Slides는 프로그래밍 방식으로 새로운 잉크 스트로크를 생성할 수 없지만, 기존 잉크를 읽고 수정할 수 있습니다.

## **Access Ink**
첫 번째 잉크 모양을 슬라이드에서 검색합니다.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Ink**
슬라이드에서 잉크 모양을 삭제합니다.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 잉크 모양이 슬라이드의 첫 번째 도형이라고 가정합니다.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```