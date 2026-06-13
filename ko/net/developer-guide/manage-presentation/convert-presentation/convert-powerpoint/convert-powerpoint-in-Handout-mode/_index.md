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
description: ".NET에서 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 노트를 유지하며, Aspose.Slides를 사용해 PDF 또는 이미지로 내보내고, C# 샘플 코드가 제공됩니다. 무료로 사용해 보세요."
---
## **소개**

Aspose.Slides는 Handout 모드를 지원하는 출력 형식으로 프레젠테이션을 변환할 수 있게 합니다. 이 모드에서는 여러 슬라이드가 한 페이지에 배치되어 회의, 세미나 등에서 프레젠테이션 자료를 인쇄할 때 유용합니다.

Handout 모드는 `SlidesLayoutOptions` 속성을 통해 구성되며, 이 속성은 [IPdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ihtmloptions/), [ITiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/itiffoptions/)에서 사용할 수 있습니다. 핸드아웃 레이아웃을 정의하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handoutlayoutingoptions/) 객체를 사용하십시오.

## **핸드아웃 모드 내보내기**

핸드아웃 모드로 프레젠테이션을 내보내려면 대상 내보내기 옵션의 `SlidesLayoutOptions` 속성을 설정하고 페이지당 슬라이드 수 및 관련 표시 매개변수를 정의하는 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handoutlayoutingoptions/) 인스턴스를 할당합니다.

아래는 프레젠테이션을 PDF로 핸드아웃 모드에서 변환하는 코드 예제입니다.

```c#
// 프레젠테이션을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// 내보내기 옵션을 설정합니다.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 가로 방향으로 한 페이지에 슬라이드 4개
        PrintSlideNumbers = true,                   // 슬라이드 번호 인쇄
        PrintFrameSlide = true,                     // 슬라이드 주위에 프레임 인쇄
        PrintComments = false                       // 주석 없음
    }
};

// 선택한 레이아웃으로 프레젠테이션을 PDF로 내보냅니다.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 

`SlidesLayoutOptions` 속성은 PDF, HTML, TIFF와 같이 이미지로 렌더링할 때와 같은 특정 출력 형식에서만 사용할 수 있다는 점을 기억하십시오.

{{% /alert %}} 

## **자주 묻는 질문**

**Handout 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 가로 또는 세로 정렬이 가능한 1, 2, 3, 4(가로/세로), 6(가로/세로), 9(가로/세로)까지 최대 9개의 썸네일을 지원하는 [presets](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handouttype/)를 제공합니다.

**페이지당 5개 또는 8개의 슬라이드와 같은 사용자 정의 그리드를 정의할 수 있나요?**

아니요. 썸네일의 수와 정렬은 [HandoutType](https://reference.aspose.com/slides/ko/net/aspose.slides.export/handouttype/) 열거형에 의해 엄격히 제어되며, 임의 레이아웃은 지원되지 않습니다.

**Handout 출력에 숨김 슬라이드를 포함시킬 수 있나요?**

예. 대상 형식에 대한 내보내기 설정에서 `ShowHiddenSlides` 옵션을 활성화하십시오. 예: [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/), [TiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/).