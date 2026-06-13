---
title: Android에서 Handout 모드로 PowerPoint 프레젠테이션 변환
linktitle: Handout 모드
type: docs
weight: 150
url: /ko/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- Handout 모드
- 유인물
- PPT
- PPTX
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java에서 프레젠테이션을 유인물로 변환합니다. 슬라이드당 페이지 수를 설정하고, 노트를 유지하며, Aspose.Slides for Android를 사용해 PDF 또는 이미지로 내보냅니다. 샘플 코드와 함께 제공됩니다. 무료로 체험해 보세요."
---
## **소개**

Aspose.Slides는 프레젠테이션을 다양한 형식으로 변환하는 기능을 제공하며, Handout 모드에서 인쇄용 유인물을 만들 수 있습니다. 이 모드를 사용하면 여러 슬라이드를 한 페이지에 어떻게 배치할지 구성할 수 있어 회의, 세미나 및 기타 행사에 유용합니다. `setSlidesLayoutOptions` 메서드를 [IPdfOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ihtmloptions/), 및 [ITiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiffoptions/) 인터페이스에 설정하여 이 모드를 활성화할 수 있습니다.

## **Handout 모드 내보내기**

Handout 모드를 구성하려면 한 페이지에 몇 개의 슬라이드를 배치할지 및 기타 표시 매개변수를 결정하는 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handoutlayoutingoptions/) 개체를 사용합니다.

아래 코드는 Handout 모드에서 프레젠테이션을 PDF로 변환하는 예시입니다.

```java
// 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
	// 내보내기 옵션을 설정합니다.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 가로 방향으로 한 페이지에 슬라이드 4개
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // 슬라이드 번호를 인쇄합니다
	slidesLayoutOptions.setPrintFrameSlide(true);                     // 슬라이드 주변에 프레임을 인쇄합니다
	slidesLayoutOptions.setPrintComments(false);                      // 주석 없음

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// 선택한 레이아웃으로 프레젠테이션을 PDF로 내보냅니다.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 

`setSlidesLayoutOptions` 메서드는 PDF, HTML, TIFF와 같이 이미지로 렌더링할 때와 같은 특정 출력 형식에서만 사용할 수 있다는 점을 기억하십시오. 

{{% /alert %}} 

## **FAQ**

**Handout 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 가로 또는 세로 정렬이 가능한 1, 2, 3, 4(가로/세로), 6(가로/세로), 9(가로/세로)까지 페이지당 최대 9개의 썸네일을 지원하는 [presets](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handouttype/)를 제공합니다.

**페이지당 5개 또는 8개 슬라이드와 같은 사용자 정의 그리드를 정의할 수 있습니까?**

아니요. 썸네일의 개수와 정렬은 [HandoutType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handouttype/) 클래스에 의해 엄격히 제어되며 임의 레이아웃은 지원되지 않습니다.

**Handout 출력에 숨겨진 슬라이드를 포함할 수 있습니까?**

예. 대상 형식에 대한 내보내기 설정에서 `setShowHiddenSlides` 메서드를 활성화하면 숨겨진 슬라이드를 포함할 수 있습니다. 예: [PdfOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/), 또는 [TiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/).