---
title: .NET에서 핸드아웃 모드로 PowerPoint 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PowerPoint
- 프레젠테이션
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: ".NET에서 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 메모를 유지하며, Aspose.Slides를 사용해 PDF 또는 이미지로 내보내고, 샘플 C# 코드를 제공합니다. 무료로 사용해 보세요."
---
## **소개**

Aspose.Slides를 사용하면 Handout 모드를 지원하는 출력 형식으로 프레젠테이션을 변환할 수 있습니다. 이 모드에서는 여러 슬라이드가 한 페이지에 배열되어 회의, 세미나 및 유사한 이벤트용 프레젠테이션 자료를 인쇄할 때 유용합니다.

Handout 모드는 `SlidesLayoutOptions` 속성을 통해 구성되며, 이 속성은 [IPdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ihtmloptions/), 및 [ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/) 에서 사용할 수 있습니다. Handout 레이아웃을 정의하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handoutlayoutingoptions/) 객체를 사용합니다.

내보내기 전에 Handout 페이지 크기와 방향을 설정하려면 [Notes Page Size](/slides/ko/net/notes-size/)를 참조하세요.

## **Handout 모드 내보내기**

Handout 모드로 프레젠테이션을 내보내려면 대상 내보내기 옵션의 `SlidesLayoutOptions` 속성을 설정하고, 페이지당 슬라이드 수 및 관련 표시 매개변수를 정의하는 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handoutlayoutingoptions/) 인스턴스를 할당합니다.

다음은 Handout 모드로 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// 내보내기 옵션을 설정합니다.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 한 페이지에 슬라이드 4장을 가로로 배치
        PrintSlideNumbers = true,                   // 슬라이드 번호를 인쇄합니다
        PrintFrameSlide = true,                     // 슬라이드 주변에 테두리를 인쇄합니다
        PrintComments = false                       // 주석 없음
    }
};

// 선택한 레이아웃으로 프레젠테이션을 PDF에 내보냅니다.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 

`SlidesLayoutOptions` 속성은 PDF, HTML, TIFF와 같이 이미지로 렌더링할 때와 같은 특정 출력 형식에서만 사용할 수 있다는 점을 기억하세요.

{{% /alert %}} 

## **FAQ**

### Handout 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?

Aspose.Slides는 가로 또는 세로 정렬 방식으로 페이지당 최대 9개의 썸네일을 지원하는 [presets](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handouttype/)를 제공합니다: 1, 2, 3, 4(가로/세로), 6(가로/세로), 9(가로/세로).

### 페이지당 5개 또는 8개의 슬라이드와 같은 사용자 정의 그리드를 정의할 수 있나요?

아니요. 썸네일 수와 정렬은 [HandoutType](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handouttype/) 열거형에 의해 엄격히 제어되며 임의 레이아웃은 지원되지 않습니다.

### Handout 출력에 숨김 슬라이드를 포함할 수 있나요?

예. 대상 형식의 내보내기 설정에서 `ShowHiddenSlides` 옵션을 활성화하면 됩니다. 예: [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/), 또는 [TiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/).