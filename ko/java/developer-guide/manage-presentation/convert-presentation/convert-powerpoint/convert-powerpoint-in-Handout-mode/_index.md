---
title: Java를 사용하여 Handout 모드에서 PowerPoint 프레젠테이션 변환
linktitle: Handout 모드
type: docs
weight: 150
url: /ko/java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PPT
- PPTX
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java에서 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 노트를 유지하며, Aspose.Slides를 사용해 PDF 또는 이미지로 내보냅니다. 샘플 Java 코드 포함. 무료로 사용해 보세요."
---
## **소개**

Aspose.Slides를 사용하면 Handout 모드를 지원하는 출력 형식으로 프레젠테이션을 변환할 수 있습니다. 이 모드에서는 여러 슬라이드를 한 페이지에 배치하여 회의, 세미나 및 유사한 행사에서 프레젠테이션 자료를 인쇄할 때 유용합니다.

Handout 모드는 `setSlidesLayoutOptions` 메서드를 통해 구성되며, 이 메서드는 [IPdfOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ihtmloptions/) 및 [ITiffOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiffoptions/)에서 사용할 수 있습니다. Handout 레이아웃을 정의하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/handoutlayoutingoptions/) 객체를 사용하십시오.

## **핸드아웃 모드 내보내기**

Handout 모드로 프레젠테이션을 내보내려면 대상 내보내기 옵션에 `setSlidesLayoutOptions` 메서드를 설정하고, 페이지당 슬라이드 수와 관련 표시 매개변수를 정의하는 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/handoutlayoutingoptions/) 인스턴스를 지정합니다.

아래는 Handout 모드에서 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```java
// 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 내보내기 옵션을 설정합니다.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 가로 방향으로 한 페이지에 슬라이드 4개
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // 슬라이드 번호를 인쇄합니다
    slidesLayoutOptions.setPrintFrameSlide(true);                     // 슬라이드 주위에 프레임을 인쇄합니다
    slidesLayoutOptions.setPrintComments(false);                      // 댓글 없음

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 선택한 레이아웃으로 프레젠테이션을 PDF로 내보냅니다.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` 메서드는 PDF, HTML, TIFF와 같이 특정 출력 형식 및 이미지로 렌더링할 때에만 사용할 수 있다는 점을 기억하십시오.
{{% /alert %}} 

## **자주 묻는 질문**

**Handout 모드에서 페이지당 슬라이드 썸네일의 최대 개수는 얼마입니까?**

Aspose.Slides는 가로 또는 세로 정렬로 페이지당 최대 9개의 썸네일을 지원하는 [presets](https://reference.aspose.com/slides/ko/java/com.aspose.slides/handouttype/)를 제공합니다: 1, 2, 3, 4(가로/세로), 6(가로/세로), 9(가로/세로).

**페이지당 5개 또는 8개와 같은 맞춤 그리드를 정의할 수 있습니까?**

아니오. 썸네일의 수와 순서는 [HandoutType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/handouttype/) 클래스에 의해 엄격히 제어되며, 임의의 레이아웃은 지원되지 않습니다.

**Handout 출력에 숨겨진 슬라이드를 포함할 수 있습니까?**

예. 대상 형식의 내보내기 설정에서 `setShowHiddenSlides` 메서드를 사용하여 숨겨진 슬라이드를 활성화할 수 있습니다. 예: [PdfOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/) 또는 [TiffOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/).