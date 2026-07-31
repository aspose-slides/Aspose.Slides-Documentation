---
title: C++를 이용한 핸드아웃 모드에서 PowerPoint 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PPT
- PPTX
- 파워포인트
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++에서 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 노트를 유지하며, Aspose.Slides를 사용해 PDF 또는 이미지로 내보내고, 샘플 코드를 제공합니다. 무료로 체험해 보세요."
---
## **소개**

Aspose.Slides는 프레젠테이션을 다양한 형식으로 변환하는 기능을 제공하며, Handout 모드로 인쇄용 유인물을 만들 수 있습니다. 이 모드를 사용하면 한 페이지에 여러 슬라이드를 어떻게 배치할지 구성할 수 있어 회의, 세미나 및 기타 행사에 유용합니다. `set_SlidesLayoutOptions` 메서드를 [IPdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ihtmloptions/), 및 [ITiffOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/itiffoptions/) 인터페이스에서 설정하여 이 모드를 활성화할 수 있습니다.

## **핸드아웃 모드 내보내기**

Handout 모드를 구성하려면 한 페이지에 배치되는 슬라이드 수 및 기타 표시 매개변수를 결정하는 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/handoutlayoutingoptions/) 객체를 사용하십시오.

아래는 Handout 모드에서 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```cpp
// 프레젠테이션을 로드합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 한 페이지에 가로로 4장 슬라이드
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // 슬라이드 번호 출력
slidesLayoutOptions->set_PrintFrameSlide(true);                      // 슬라이드 주변에 프레임 출력
slidesLayoutOptions->set_PrintComments(false);                       // 주석 없음

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` 메서드는 PDF, HTML, TIFF와 같이 특정 출력 형식에만 사용할 수 있으며, 이미지를 렌더링할 때에도 사용할 수 있다는 점을 기억하십시오. 
{{% /alert %}} 

## **FAQ**

**핸드아웃 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 가로 또는 세로 순서로 페이지당 최대 9개의 썸네일을 지원하는 [presets](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/handouttype/)를 제공하며, 1, 2, 3, 4(가로/세로), 6(가로/세로), 9(가로/세로) 옵션이 있습니다.

**5개 또는 8개와 같이 페이지당 슬라이드 수를 직접 정의할 수 있나요?**

아닙니다. 썸네일의 개수와 순서는 [HandoutType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/handouttype/) 열거형에 의해 엄격히 제어되며, 임의의 레이아웃은 지원되지 않습니다.

**핸드아웃 출력에 숨겨진 슬라이드를 포함시킬 수 있나요?**

예. 대상 형식의 내보내기 설정에서 `set_ShowHiddenSlides` 메서드를 사용하면 됩니다. 예를 들어 [PdfOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/), 또는 [TiffOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/)을 사용할 수 있습니다.