---
title: JavaScript에서 프레젠테이션의 Flash 개체 추출
linktitle: 플래시
type: docs
weight: 10
url: /ko/nodejs-java/flash/
keywords:
- Flash 추출
- Flash 개체
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides와 함께 JavaScript를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 Flash 개체를 추출하는 방법을 배우고, 완전한 코드 샘플과 모범 사례를 확인하세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션에서 Flash 개체를 추출하는 방법을 설명합니다. 슬라이드의 컨트롤 컬렉션에서 이름으로 Flash 컨트롤을 찾고 내장된 SWF 개체 데이터를 처리하는 방법을 보여줍니다.

## **프레젠테이션에서 Flash 개체 추출**

Node.js용 Aspose.Slides for Java는 프레젠테이션에서 Flash 개체를 추출하는 기능을 제공합니다. 이름으로 Flash 컨트롤에 접근하고 프레젠테이션에서 해당 컨트롤을 추출하여 SWF 개체 데이터를 저장할 수 있습니다.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Flash 콘텐츠를 추출할 때 지원되는 프레젠테이션 형식은 무엇입니까?**

[Aspose.Slides는](/slides/ko/nodejs-java/supported-file-formats/) PPT 및 PPTX와 같은 주요 PowerPoint 형식을 지원합니다. 이는 해당 컨테이너를 로드하고 Flash 관련 ActiveX 요소를 포함한 컨트롤에 접근할 수 있기 때문입니다.

**Flash가 포함된 프레젠테이션을 HTML5로 변환하고 Flash 인터랙티브 기능을 유지할 수 있습니까?**

아니요. Aspose.Slides는 SWF 콘텐츠를 실행하거나 그 인터랙티브성을 변환하지 않습니다. [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/ko/nodejs-java/export-to-html5/)로의 내보내기는 지원하지만, modern 브라우저에서는 Flash가 지원되지 않으므로 재생되지 않습니다. 권장 방법은 내보내기 전에 Flash를 비디오나 HTML5 애니메이션과 같은 대체 콘텐츠로 교체하는 것입니다.

**보안 측면에서 Aspose.Slides가 프레젠테이션을 읽는 동안 SWF 파일을 실행합니까?**

아니요. Aspose.Slides는 Flash를 파일에 포함된 바이너리 데이터로 취급하며 처리 과정에서 SWF 콘텐츠를 실행하지 않습니다.

**Flash와 OLE를 통해 포함된 다른 파일이 함께 포함된 프레젠테이션을 어떻게 처리해야 합니까?**

Aspose.Slides는 [내장 OLE 개체 추출](/slides/ko/nodejs-java/manage-ole/)을 지원하므로, Flash 컨트롤과 기타 OLE 포함 문서를 한 번에 처리할 수 있습니다.