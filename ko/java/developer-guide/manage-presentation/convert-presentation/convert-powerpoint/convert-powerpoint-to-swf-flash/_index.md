---
title: Java에서 PowerPoint 프레젠테이션을 SWF Flash로 변환
linktitle: PowerPoint를 SWF로
type: docs
weight: 80
url: /ko/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint (PPT/PPTX)를 SWF Flash로 변환합니다. 단계별 코드 샘플, 빠른 고품질 출력, PowerPoint 자동화 없이."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 SWF로 변환하는 방법을 설명합니다. [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드로 프레젠테이션을 SWF 파일로 저장하는 방법과 [SwfOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/swfoptions/)를 사용하여 뷰어 설정 및 메모 또는 주석 레이아웃을 구성하는 방법을 보여줍니다.

## **프레젠테이션을 Flash로 변환**

[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스에서 제공하는 [save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드를 사용하면 전체 프레젠테이션을 **SWF** 문서로 변환할 수 있습니다. 다음 예제는 [**SWFOptions**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SwfOptions) 클래스로 제공되는 옵션을 사용하여 프레젠테이션을 **SWF** 문서로 변환하는 방법을 보여줍니다. 또한 생성된 SWF에 주석을 포함하려면 [**ISWFOptions**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISwfOptions) 클래스와 [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INotesCommentsLayoutingOptions) 인터페이스를 사용할 수 있습니다.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // 프레젠테이션 저장
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **자주 묻는 질문**

**SWF에 숨겨진 슬라이드를 포함할 수 있나요?**

예. [SwfOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/swfoptions/)의 [setShowHiddenSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) 메서드를 사용하여 숨겨진 슬라이드를 활성화합니다. 기본적으로 숨겨진 슬라이드는 내보내지 않습니다.

**압축 및 최종 SWF 파일 크기를 어떻게 제어할 수 있나요?**

[setCompressed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) 메서드와 [adjust JPEG quality](https://reference.aspose.com/slides/ko/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) 를 사용하여 파일 크기와 이미지 품질 사이의 균형을 맞출 수 있습니다.

**'setViewerIncluded'는 무엇을 위해 사용되며, 언제 비활성화해야 하나요?**

[setViewerIncluded](https://reference.aspose.com/slides/ko/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) 은 임베디드 플레이어 UI(네비게이션 제어, 패널, 검색)를 추가합니다. 자체 플레이어를 사용하거나 UI 없이 순수한 SWF 프레임만 필요할 경우 이를 비활성화하십시오.

**내보내는 머신에 원본 폰트가 없으면 어떻게 되나요?**

Aspose.Slides는 [SwfOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/swfoptions/)의 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) 로 지정한 폰트를 사용하여 의도하지 않은 폰트 대체를 방지합니다.