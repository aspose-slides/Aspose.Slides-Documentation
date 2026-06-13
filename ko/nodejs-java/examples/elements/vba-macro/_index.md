---
title: VBA 매크로
type: docs
weight: 150
url: /ko/nodejs-java/examples/elements/vba-macro/
keywords:
- 코드 예제
- VBA
- 매크로
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션을 자동화합니다: PPT, PPTX 및 ODP에서 VBA 매크로를 생성, 가져오기 및 보안 설정을 명확한 JavaScript 예제로 제공합니다."
---
이 문서에서는 **Aspose.Slides for Node.js via Java**를 사용하여 VBA 매크로를 추가, 액세스 및 제거하는 방법을 보여줍니다.

## **VBA 매크로 추가**

VBA 프로젝트와 간단한 매크로 모듈이 포함된 프레젠테이션을 생성합니다.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA 매크로 액세스**

VBA 프로젝트에서 첫 번째 모듈을 가져옵니다.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // 프레젠테이션에 적어도 하나의 VBA 모듈이 있다고 가정합니다.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA 매크로 제거**

VBA 프로젝트에서 모듈을 삭제합니다.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // 프레젠테이션에 적어도 하나의 VBA 모듈이 있다고 가정합니다.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```