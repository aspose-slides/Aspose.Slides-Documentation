---
title: Android에서 핸드아웃 모드로 PowerPoint 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PPT
- PPTX
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java에서 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 노트를 유지하며, Aspose.Slides for Android를 사용해 PDF 또는 이미지로 내보냅니다. 샘플 코드를 확인하고 무료로 사용해 보세요."
---
## **소개**

Aspose.Slides는 프레젠테이션을 다양한 형식으로 변환하는 기능을 제공하며, Handout 모드에서 인쇄용 유인물을 생성할 수도 있습니다. 이 모드를 사용하면 한 페이지에 여러 슬라이드를 배치하는 방식을 구성할 수 있어 회의, 세미나 및 기타 행사에 유용합니다. 이 모드는 [IPdfOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ihtmloptions/), 및 [ITiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiffoptions/) 인터페이스에서 `setSlidesLayoutOptions` 메서드를 설정하여 활성화할 수 있습니다.

## **핸드아웃 모드 내보내기**

Handout 모드를 구성하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handoutlayoutingoptions/) 객체를 사용하십시오. 이 객체는 한 페이지에 배치될 슬라이드 수 및 기타 표시 매개변수를 결정합니다.

아래는 Handout 모드에서 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```java
// 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
	// 내보내기 옵션을 설정합니다.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 한 페이지에 가로로 4개의 슬라이드
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // 슬라이드 번호 인쇄
	slidesLayoutOptions.setPrintFrameSlide(true);                     // 슬라이드 주위에 프레임 인쇄
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
`setSlidesLayoutOptions` 메서드는 PDF, HTML, TIFF와 같이 특정 출력 형식 및 이미지를 렌더링할 때에만 사용할 수 있다는 점을 기억하십시오. 
{{% /alert %}} 

## **FAQ**

**Handout 모드에서 페이지당 슬라이드 섬네일의 최대 개수는 얼마입니까?**

Aspose.Slides는 [presets](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handouttype/)를 지원하며, 페이지당 최대 9개의 섬네일을 가로 또는 세로 순서대로 배치할 수 있습니다: 1, 2, 3, 4 (가로/세로), 6 (가로/세로), 9 (가로/세로).

**5개 또는 8개 슬라이드와 같이 사용자 지정 그리드를 정의할 수 있나요?**

아닙니다. 섬네일의 수와 순서는 [HandoutType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handouttype/) 클래스에 의해 엄격히 제어되며, 임의 레이아웃은 지원되지 않습니다.

**숨겨진 슬라이드를 Handout 출력에 포함할 수 있나요?**

예. 대상 형식의 내보내기 설정에서 `setShowHiddenSlides` 메서드를 사용하여 숨겨진 슬라이드를 포함할 수 있습니다. 예를 들어 [PdfOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/htmloptions/), 또는 [TiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/)을 사용할 수 있습니다.