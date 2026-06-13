---
title: 핸드아웃 모드에서 JavaScript를 사용하여 PowerPoint 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PPT
- PPTX
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 노트를 유지하며, Aspose.Slides for Node.js를 사용하여 PDF 또는 이미지로 내보냅니다. 샘플 코드가 포함되어 있습니다. 무료로 사용해 보세요."
---
## **소개**

Aspose.Slides는 프레젠테이션을 다양한 형식으로 변환할 수 있는 기능을 제공하며, Handout 모드로 인쇄용 유인물을 만들 수 있습니다. 이 모드를 사용하면 한 페이지에 여러 슬라이드를 배치하는 방법을 설정할 수 있어 회의, 세미나 및 기타 행사에 유용합니다. `setSlidesLayoutOptions` 메서드를 [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/), [TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 클래스에서 설정하여 이 모드를 활성화할 수 있습니다.

## **핸드아웃 모드 내보내기**

핸드아웃 모드를 구성하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/handoutlayoutingoptions/) 객체를 사용합니다. 이 객체는 한 페이지에 배치되는 슬라이드 수 및 기타 표시 매개변수를 결정합니다.

아래는 핸드아웃 모드에서 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```js
// 프레젠테이션을 로드합니다.
let presentation = new asposeSlides.Presentation("sample.pptx");

// 내보내기 옵션을 설정합니다.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 한 페이지에 가로로 4개의 슬라이드
slidesLayoutOptions.setPrintSlideNumbers(true);                                // 슬라이드 번호를 인쇄합니다
slidesLayoutOptions.setPrintFrameSlide(true);                                  // 슬라이드 주변에 프레임을 인쇄합니다
slidesLayoutOptions.setPrintComments(false);                                   // 주석 없음

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// 선택한 레이아웃으로 프레젠테이션을 PDF로 내보냅니다.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` 메서드는 PDF, HTML, TIFF와 같이 특정 출력 형식에서만 사용할 수 있으며 이미지로 렌더링할 때도 사용할 수 있습니다.
{{% /alert %}} 

## **자주 묻는 질문**

**핸드아웃 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 페이지당 최대 9개의 썸네일을 가질 수 있는 [presets](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/handouttype/)를 지원하며 가로 또는 세로 정렬을 제공합니다: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), 9 (horizontal/vertical).

**5개 또는 8개 슬라이드와 같이 사용자 지정 그리드를 정의할 수 있습니까?**

아니오. 썸네일의 수와 정렬은 [HandoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/handouttype/) 열거형에 의해 엄격히 제어되며, 임의의 레이아웃은 지원되지 않습니다.

**핸드아웃 출력에 숨겨진 슬라이드를 포함할 수 있습니까?**

예. 대상 형식의 내보내기 설정에서 `setShowHiddenSlides` 메서드를 사용합니다. 예: [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/) 또는 [TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/).