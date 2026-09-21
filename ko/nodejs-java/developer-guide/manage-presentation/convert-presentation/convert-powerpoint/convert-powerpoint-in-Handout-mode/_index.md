---
title: 핸드아웃 모드에서 JavaScript를 사용한 PowerPoint 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/nodejs-java/convert-powerpoint-in-handout-mode/
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
description: "프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 노트를 유지하며, Aspose.Slides for Node.js를 사용해 PDF 또는 이미지로 내보냅니다. 샘플 코드를 확인하고 무료로 사용해 보세요."
---
## **소개**

Aspose.Slides는 Handout 모드로 인쇄용 핸드아웃을 생성하는 등 프레젠테이션을 다양한 형식으로 변환할 수 있는 기능을 제공합니다. 이 모드를 사용하면 한 페이지에 여러 슬라이드가 어떻게 표시될지 구성할 수 있어 회의, 세미나 및 기타 행사에 유용합니다. `setSlidesLayoutOptions` 메서드를 [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/), 및 [TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 클래스에 설정하여 이 모드를 활성화할 수 있습니다.

내보내기 전에 핸드아웃 페이지 크기와 방향을 설정하려면 [노트 페이지 크기](/slides/ko/nodejs-java/notes-size/)를 참조하십시오.

## **핸드아웃 모드 내보내기**

핸드아웃 모드를 구성하려면 한 페이지에 배치될 슬라이드 수와 기타 표시 매개변수를 결정하는 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/handoutlayoutingoptions/) 객체를 사용하십시오.

아래는 핸드아웃 모드에서 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 한 페이지에 가로로 4 슬라이드
slidesLayoutOptions.setPrintSlideNumbers(true);                                // 슬라이드 번호 인쇄
slidesLayoutOptions.setPrintFrameSlide(true);                                  // 슬라이드 주위에 프레임 인쇄
slidesLayoutOptions.setPrintComments(false);                                   // 주석 없음

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` 메서드는 PDF, HTML, TIFF와 같이 이미지로 렌더링할 때와 같이 특정 출력 형식에서만 사용할 수 있다는 점을 기억하십시오.
{{% /alert %}} 

## **자주 묻는 질문**

**핸드아웃 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 [presets](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/handouttype/)을 지원하며, 가로 또는 세로 정렬을 포함해 페이지당 최대 9개의 썸네일을 표시할 수 있습니다: 1, 2, 3, 4 (가로/세로), 6 (가로/세로), 그리고 9 (가로/세로).

**5개 또는 8개 슬라이드와 같은 사용자 정의 그리드를 정의할 수 있습니까?**

아니요. 썸네일의 수와 정렬 순서는 [HandoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/handouttype/) 열거형에 의해 엄격히 제어되며, 임의 레이아웃은 지원되지 않습니다.

**핸드아웃 출력에 숨겨진 슬라이드를 포함할 수 있습니까?**

예. 대상 형식에 대한 내보내기 설정에서 `setShowHiddenSlides` 메서드를 사용하십시오. 예: [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/), 또는 [TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/).