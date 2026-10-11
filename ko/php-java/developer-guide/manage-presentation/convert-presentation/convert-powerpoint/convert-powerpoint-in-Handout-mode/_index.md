---
title: PHP를 사용한 핸드아웃 모드에서 PowerPoint 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PPT
- PPTX
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 노트를 유지하며, Aspose.Slides for PHP를 사용해 PDF 또는 이미지로 내보냅니다. 샘플 코드와 함께 무료로 체험해 보세요."
---
## **소개**

Aspose.Slides는 프레젠테이션을 다양한 형식으로 변환하는 기능을 제공하며, Handout 모드에서 인쇄용 유인물을 만들 수도 있습니다. 이 모드를 사용하면 여러 슬라이드를 한 페이지에 어떻게 표시할지 구성할 수 있어 회의, 세미나 및 기타 행사에 유용합니다. 해당 모드는 [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/htmloptions/), 및 [TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/) 클래스에서 `setSlidesLayoutOptions` 메서드를 설정하여 활성화할 수 있습니다.

내보내기 전에 유인물 페이지 크기와 방향을 설정하려면 [Notes Page Size](/slides/ko/php-java/notes-size/)을 참조하십시오.

## **유인물 모드 내보내기**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/handoutlayoutingoptions/) 객체를 사용하여 유인물 모드를 구성할 수 있으며, 이 객체는 한 페이지에 배치되는 슬라이드 수와 기타 표시 매개변수를 결정합니다.

다음은 유인물 모드에서 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```php
// 프레젠테이션을 로드합니다.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 한 페이지에 가로로 4개의 슬라이드
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // 슬라이드 번호 인쇄
$slidesLayoutOptions->setPrintFrameSlide(true);                      // 슬라이드 주변에 프레임 인쇄
$slidesLayoutOptions->setPrintComments(false);                       // 주석 없음

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` 메서드는 PDF, HTML, TIFF와 같이 이미지로 렌더링할 때와 같은 특정 출력 형식에서만 사용할 수 있다는 점을 유념하세요.
{{% /alert %}} 

## **FAQ**

**핸드아웃 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 [presets](https://reference.aspose.com/slides/ko/php-java/aspose.slides/handouttype/)를 지원하며, 가로 또는 세로 순서로 페이지당 최대 9개의 썸네일을 제공합니다: 1, 2, 3, 4(가로/세로), 6(가로/세로), 9(가로/세로).

**페이지당 5개 또는 8개의 슬라이드와 같은 사용자 정의 그리드를 정의할 수 있나요?**

아니요. 썸네일의 수와 순서는 [HandoutType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/handouttype/) 클래스로 엄격히 제어되며, 임의의 레이아웃은 지원되지 않습니다.

**핸드아웃 출력에 숨겨진 슬라이드를 포함할 수 있나요?**

예. 대상 형식의 내보내기 설정에서 `setShowHiddenSlides` 메서드를 사용해 숨겨진 슬라이드를 활성화할 수 있습니다. 예: [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/htmloptions/), 또는 [TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/).