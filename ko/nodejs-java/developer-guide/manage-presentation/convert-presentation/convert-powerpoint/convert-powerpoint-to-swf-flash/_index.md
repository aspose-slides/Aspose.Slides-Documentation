---
title: JavaScript에서 PowerPoint 프레젠테이션을 SWF Flash로 변환
linktitle: PowerPoint를 SWF로
type: docs
weight: 80
url: /ko/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 SWF로
- 프레젠테이션을 SWF로
- 슬라이드를 SWF로
- PPT를 SWF로
- PPTX를 SWF로
- PowerPoint를 Flash로
- 프레젠테이션을 Flash로
- 슬라이드를 Flash로
- PPT를 Flash로
- PPTX를 Flash로
- PPT를 SWF로 저장
- PPTX를 SWF로 저장
- PPT를 SWF로 내보내기
- PPTX를 SWF로 내보내기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint (PPT/PPTX)를 SWF Flash로 변환합니다. 단계별 코드 샘플, 빠른 고품질 출력, PowerPoint 자동화 없이."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 SWF로 변환하는 방법을 설명합니다. 프레젠테이션을 **SWF** 파일로 저장하려면 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 메서드를 사용하고, viewer 설정 및 노트 또는 주석 레이아웃을 포함한 내보내기 구성을 위해 [SwfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/swfoptions/)를 사용합니다.

## **PPT(X)를 SWF로 변환**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스에서 제공하는 [save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 메서드를 사용하면 전체 프레젠테이션을 **SWF** 문서로 변환할 수 있습니다. 다음 예제는 [**SWFOptions**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SwfOptions) 클래스가 제공하는 옵션을 사용하여 프레젠테이션을 **SWF** 문서로 변환하는 방법을 보여줍니다. 또한 [**SWFOptions**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SwfOptions) 클래스와 [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) 클래스를 사용하여 생성된 SWF에 주석을 포함시킬 수 있습니다.

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // 프레젠테이션 저장
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**SWF에 숨겨진 슬라이드를 포함시킬 수 있나요?**

예. [SwfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/swfoptions/)의 [setShowHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) 메서드를 사용하십시오. 기본적으로 숨겨진 슬라이드는 내보내지 않습니다.

**압축 및 최종 SWF 크기를 어떻게 제어할 수 있나요?**

파일 크기와 이미지 품질을 균형 있게 유지하려면 [setCompressed](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/swfoptions/setcompressed/) 메서드와 [setJpegQuality](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/swfoptions/setjpegquality/)를 사용하십시오.

**setViewerIncluded는 무엇이며 언제 사용해야 하나요?**

[setViewerIncluded](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/swfoptions/setviewerincluded/)는 내장된 플레이어 UI(탐색 컨트롤, 패널, 검색)를 추가합니다. 자체 플레이어를 사용하거나 UI 없이 최소한의 SWF 프레임만 필요할 경우에 사용하십시오.

**내보내기 머신에 원본 폰트가 없으면 어떻게 되나요?**

Aspose.Slides는 [SwfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/swfoptions/)의 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont)으로 지정한 폰트를 대체하여 의도치 않은 폰트 대체를 방지합니다.