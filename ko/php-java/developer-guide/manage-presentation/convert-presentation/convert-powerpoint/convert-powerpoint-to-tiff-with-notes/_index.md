---
title: PHP에서 노트가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환
linktitle: 노트가 포함된 PowerPoint를 TIFF로
type: docs
weight: 100
url: /ko/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 TIFF로
- 프레젠테이션을 TIFF로
- 슬라이드를 TIFF로
- PPT를 TIFF로
- PPTX를 TIFF로
- PPT를 TIFF로 저장
- PPTX를 TIFF로 저장
- PPT를 TIFF로 내보내기
- PPTX를 TIFF로 내보내기
- 노트가 포함된 PowerPoint
- 노트가 포함된 프레젠테이션
- 노트가 포함된 슬라이드
- 노트가 포함된 PPT
- 노트가 포함된 PPTX
- 노트가 포함된 TIFF
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 노트가 포함된 PowerPoint 프레젠테이션을 TIFF로 변환합니다. 발표자 노트가 포함된 슬라이드를 효율적으로 내보내는 방법을 배워보세요."
---
## **소개**

Aspose.Slides for PHP via Java은 노트가 포함된 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX 및 ODP)을 TIFF 형식으로 변환하는 간단한 솔루션을 제공합니다. 이 형식은 고품질 이미지 저장, 인쇄 및 문서 보관에 널리 사용됩니다. Aspose.Slides를 사용하면 발표자 노트가 포함된 전체 프레젠테이션을 내보낼 수 있을 뿐만 아니라 Notes Slide 보기에서 슬라이드 썸네일을 생성할 수도 있습니다. 변환 과정은 간단하고 효율적이며, 전체 프레젠테이션을 노트와 레이아웃을 유지하면서 일련의 TIFF 이미지로 변환하기 위해 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 `save` 메서드를 활용합니다.

## **노트가 포함된 프레젠테이션을 TIFF로 변환**

Aspose.Slides for PHP via Java을 사용하여 노트가 포함된 PowerPoint 또는 OpenDocument 프레젠테이션을 TIFF로 저장하려면 다음 단계가 필요합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다: PowerPoint 또는 OpenDocument 파일을 로드합니다.
1. 출력 레이아웃 옵션을 구성합니다: [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하여 노트와 댓글이 표시되는 방식을 지정합니다.
1. 프레젠테이션을 TIFF로 저장합니다: 구성된 옵션을 [save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 메서드에 전달합니다.

예를 들어, 다음 슬라이드가 포함된 "speaker_notes.pptx" 파일이 있다고 가정해 보겠습니다:

![발표자 노트가 포함된 프레젠테이션 슬라이드](slide_with_notes.png)

아래 코드 스니펫은 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 메서드를 사용하여 노트 슬라이드 보기에서 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다.

```php
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // 슬라이드 아래에 노트를 표시합니다.

    // 노트 레이아웃을 사용하여 TIFF 옵션을 구성합니다.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // 발표자 노트와 함께 프레젠테이션을 TIFF로 저장합니다.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

결과:

![발표자 노트가 포함된 TIFF 이미지](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose의 [무료 PowerPoint 포스터 변환기](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **자주 묻는 질문**

**결과 TIFF에서 노트 영역의 위치를 제어할 수 있나요?**

예. [notes layout settings](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions)를 사용하여 `None`, `BottomTruncated`, `BottomFull` 등 옵션 중에서 선택할 수 있습니다. 각각 노트를 숨기거나, 한 페이지에 맞추거나, 추가 페이지로 흐르게 합니다.

**노트가 포함된 TIFF 파일 크기를 눈에 띄는 품질 손실 없이 줄이려면 어떻게 해야 하나요?**

효율적인 [compression](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/setcompressiontype/)(`LZW` 또는 `RLE` 등)를 선택하고, 적절한 DPI를 설정하며, 허용되는 경우 [pixel format](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/setpixelformat/)을 낮은 값(예: 8 bpp 또는 1 bpp)으로 지정합니다. 또한 [image dimensions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/setimagesize/)을 약간 줄이면 가독성을 크게 해치지 않으면서 파일 크기를 감소시킬 수 있습니다.

**시스템에 원본 폰트가 없을 경우 노트의 폰트가 결과에 영향을 미치나요?**

예. 누락된 폰트는 [substitution](/slides/ko/php-java/font-selection-sequence/)을 트리거하여 텍스트 메트릭과 외관을 변경할 수 있습니다. 이를 방지하려면 [필요한 폰트를 제공](/slides/ko/php-java/custom-font/)하거나 기본 [fallback font](/slides/ko/php-java/fallback-font/)를 설정하여 의도한 서체가 사용되도록 하세요.