---
title: ActiveX
type: docs
weight: 200
url: /ko/nodejs-java/examples/elements/activex/
keywords:
- 코드 예제
- ActiveX
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ActiveX 예제를 확인하십시오: PPT 및 PPTX 프레젠테이션에서 ActiveX 객체를 삽입, 구성 및 제어하는 방법을 명확한 JavaScript 코드로 보여줍니다."
---
이 문서에서는 **Aspose.Slides for Node.js via Java**를 사용하여 프레젠테이션에서 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 방법을 보여줍니다.

## **ActiveX 컨트롤 추가**

슬라이드에 새 ActiveX 컨트롤을 추가합니다.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 새 ActiveX 컨트롤을 추가합니다.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX 컨트롤 액세스**

슬라이드의 첫 번째 ActiveX 컨트롤에서 정보를 읽습니다.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 첫 번째 ActiveX 컨트롤에 접근합니다.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX 컨트롤 제거**

슬라이드에서 기존 ActiveX 컨트롤을 삭제합니다.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 첫 번째 ActiveX 컨트롤을 제거합니다.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX 속성 설정**

여러 ActiveX 속성을 구성합니다.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```