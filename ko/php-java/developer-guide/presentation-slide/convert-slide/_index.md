---
title: PHP에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드에서 이미지로
type: docs
weight: 35
url: /ko/php-java/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드 이미지 저장
- 슬라이드 PNG 변환
- 슬라이드 JPEG 변환
- 슬라이드 비트맵 변환
- 슬라이드 TIFF 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PPT, PPTX 및 ODP 슬라이드를 이미지로 변환합니다 — 빠르고 고품질의 렌더링과 명확한 코드 예제를 제공합니다."
---
## **소개**

Aspose.Slides for PHP via Java를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션 슬라이드를 BMP, PNG, JPG(JPEG), GIF 등 다양한 이미지 형식으로 쉽게 변환할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르세요:

1. 원하는 변환 설정을 정의하고 내보낼 슬라이드를 선택합니다. 다음 중 하나를 사용합니다:
    - [TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/) 클래스, 또는
    - [RenderingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/renderingoptions/) 클래스.
2. [getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage) 메서드를 호출하여 슬라이드 이미지를 생성합니다.

Aspose.Slides for PHP via Java에서 [IImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/iimage/)은 픽셀 데이터로 정의된 이미지를 다룰 수 있게 해주는 클래스입니다. 이 클래스를 사용하면 BMP, JPG, PNG 등 다양한 형식으로 이미지를 저장할 수 있습니다.

## **슬라이드를 비트맵으로 변환하고 PNG로 저장하기**

슬라이드를 비트맵 객체로 변환하여 바로 애플리케이션에서 사용할 수 있습니다. 또는 슬라이드를 비트맵으로 변환한 뒤 JPEG 등 원하는 형식으로 저장할 수도 있습니다.

다음 코드는 프레젠테이션의 첫 번째 슬라이드를 비트맵 객체로 변환하고 PNG 형식으로 저장하는 방법을 보여줍니다:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // 이미지를 PNG 형식으로 저장합니다.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **사용자 정의 크기로 슬라이드 이미지 변환**

특정 크기의 이미지가 필요할 수 있습니다. [getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage) 메서드의 오버로드를 사용하면 폭과 높이를 지정하여 슬라이드를 이미지로 변환할 수 있습니다.

다음 샘플 코드는 이를 구현하는 방법을 보여줍니다:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // 프레젠테이션의 첫 번째 슬라이드를 지정된 크기의 비트맵으로 변환합니다.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // 이미지를 JPEG 형식으로 저장합니다.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **노트와 주석이 포함된 슬라이드를 이미지로 변환**

일부 슬라이드에는 노트와 주석이 포함될 수 있습니다.

Aspose.Slides는 [TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/)와 [RenderingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/renderingoptions/) 두 클래스를 제공하여 프레젠테이션 슬라이드의 이미지를 렌더링하는 방식을 제어할 수 있습니다. 두 클래스 모두 `setSlidesLayoutOptions` 메서드를 포함하고 있으며, 이 메서드를 사용하면 슬라이드를 이미지로 변환할 때 노트와 주석의 렌더링을 구성할 수 있습니다.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하면 결과 이미지에서 노트와 주석의 위치를 원하는대로 지정할 수 있습니다.

다음 코드는 노트와 주석이 포함된 슬라이드를 변환하는 방법을 보여줍니다:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // 노트의 위치를 설정합니다.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // 주석의 위치를 설정합니다.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // 주석 영역의 너비를 설정합니다.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // 주석 영역의 색상을 설정합니다.

    // 렌더링 옵션을 생성합니다.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // 프레젠테이션의 첫 번째 슬라이드를 이미지로 변환합니다.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // 이미지를 GIF 형식으로 저장합니다.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

슬라이드-이미지 변환 과정에서 [setNotesPosition](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 메서드는 `BottomFull`을 적용할 수 없습니다. 이는 노트 텍스트가 너무 커서 지정된 이미지 크기에 맞추기 어려울 수 있기 때문입니다.

{{% /alert %}} 

## **TIFF 옵션을 사용한 슬라이드 이미지 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/) 클래스는 크기, 해상도, 색상 팔레트 등 다양한 매개변수를 지정하여 결과 TIFF 이미지에 대한 제어력을 높여줍니다.

다음 코드는 TIFF 옵션을 사용해 흑백 이미지(300 DPI, 크기 2160 × 2800)를 출력하는 변환 과정을 보여줍니다:

```php
// 프레젠테이션 파일을 로드합니다.
$presentation = new Presentation("sample.pptx");
try {
    // 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.
    $slide = $presentation->getSlides()->get_Item(0);

    // 출력 TIFF 이미지의 설정을 구성합니다.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // 이미지 크기를 설정합니다.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // 픽셀 형식을 설정합니다 (흑백).
    $options->setDpiX(300);                                              // 수평 해상도를 설정합니다.
    $options->setDpiY(300);                                              // 수직 해상도를 설정합니다.
    
    // 지정된 옵션으로 슬라이드를 이미지로 변환합니다.
    $image = $slide->getImage($options);
    try {
        // 이미지를 TIFF 형식으로 저장합니다.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

JDK 9 이전 버전에서는 TIFF 지원이 보장되지 않습니다.

{{% /alert %}} 

## **모든 슬라이드를 이미지로 변환**

Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드를 이미지로 변환할 수 있어 전체 프레젠테이션을 일련의 이미지로 만들 수 있습니다.

다음 샘플 코드는 PHP에서 프레젠테이션의 모든 슬라이드를 이미지로 변환하는 방법을 보여줍니다:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // 프레젠테이션을 슬라이드별로 이미지로 렌더링합니다.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // 숨겨진 슬라이드를 제어합니다 (숨겨진 슬라이드는 렌더링하지 않음).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // 슬라이드를 이미지로 변환합니다.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // 이미지를 JPEG 형식으로 저장합니다.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Aspose.Slides가 애니메이션이 포함된 슬라이드 렌더링을 지원하나요?**

아니요, `getImage` 메서드는 슬라이드의 정적인 이미지만 저장하며 애니메이션은 포함되지 않습니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있나요?**

네, 숨겨진 슬라이드도 일반 슬라이드와 동일하게 처리할 수 있습니다. 처리 루프에 포함시키기만 하면 됩니다.

**이미지를 그림자와 효과가 적용된 상태로 저장할 수 있나요?**

네, Aspose.Slides는 슬라이드를 이미지로 저장할 때 그림자, 투명도 및 기타 그래픽 효과를 렌더링하는 것을 지원합니다.