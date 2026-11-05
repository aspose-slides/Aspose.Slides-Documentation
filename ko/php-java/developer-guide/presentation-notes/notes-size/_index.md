---
title: PHP에서 노트 페이지 크기 및 방향 변경
linktitle: 노트 페이지 크기
type: docs
weight: 10
url: /ko/php-java/notes-size/
keywords:
- 노트 페이지 크기
- 노트 방향
- 가로 노트
- 세로 노트
- 유인물 크기
- PowerPoint
- 프레젠테이션
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Java를 통한 PHP용 Aspose.Slides에서 노트 페이지 치수를 읽고 변경하며, 방향을 전환하고, 저장된 크기를 확인하고, 노트 또는 유인물을 PDF와 이미지로 내보냅니다."
---
## **개요**

[Presentation::getNotesSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getnotessize/)을 사용하여 프레젠테이션의 노트 페이지 설정에 접근합니다. 이 메서드는 [NotesSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notessize/) 객체를 반환하며, 해당 객체의 [setSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notessize/setsize/) 메서드로 페이지 크기를 설정합니다. 설정 객체 자체를 교체할 수는 없지만, 이 메서드를 통해 새로운 크기를 지정할 수 있습니다.

너비와 높이는 **포인트** 단위이며, 1인치당 72포인트입니다. 예를 들어 900 × 600 포인트는 12.5 × 8⅓ 인치에 해당합니다. 이러한 설정은 개별 슬라이드의 노트가 아니라 프레젠테이션 전체에 적용됩니다.

| 설정 | 목적 |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getnotessize/) | 노트 페이지 크기와 유인물 내보내기에 사용되는 페이지 크기를 제어합니다. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getslidesize/) | [SlideSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidesize/)를 통해 일반 프레젠테이션 슬라이드 크기를 제어합니다. |

두 설정 중 하나를 변경해도 다른 설정이 자동으로 변경되지는 않습니다. 노트 페이지 방향을 바꾸어도 일반 슬라이드가 회전하지 않습니다. 일반 슬라이드 크기 조정은 [Slide Size](/slides/ko/php-java/slide-size/)를 참고하세요.

아래 예제는 기존 `sample.pptx` 파일을 사용합니다. 내보내기 예제의 경우 최소 하나 이상의 슬라이드에 스피커 노트가 포함된 프레젠테이션을 사용하세요. 각 예제는 PHP/Java Bridge와 Aspose.Slides PHP 래퍼를 로드한 후 독립적으로 실행할 수 있습니다. Java에서 반환된 숫자 값은 `java_values`를 통해 PHP 값으로 변환된 후 비교 또는 계산에 사용됩니다.

## **노트 페이지 크기 및 방향 읽기**

너비와 높이를 읽어 비교함으로써 방향을 판단합니다: 가로가 더 길면 가로 방향, 세로가 더 길면 세로 방향, 크기가 같으면 정사각형 페이지입니다. 이 예제는 표준 용지 크기를 가정하지 않고 실제 포인트 단위 크기를 출력합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **용지 크기 변경 없이 가로 방향 전환**

방향만 바꾸려면 기존 너비와 높이를 교환합니다. 이렇게 하면 사용자 정의 용지 크기를 포함한 양쪽 길이가 그대로 유지됩니다. 아래 조건은 이미 가로 방향인 페이지가 세로 방향으로 전환되지 않도록 하고, 정사각형 페이지는 변경하지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

세로 방향인 경우에는 `java_values($size->getWidth()) > java_values($size->getHeight())`일 때 동일한 할당을 사용합니다. 용지 크기도 변경하고 싶지 않다면 A4나 Letter 크기를 대입하지 마세요.

## **사용자 정의 노트 페이지 크기 설정 및 확인**

두 차원을 동시에 할당한 뒤 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/save/)을 사용해 프레젠테이션을 저장합니다. 이 예제는 900 × 600 포인트 가로 페이지를 설정하고 PPTX로 저장한 뒤, 저장된 파일을 다시 열어 값을 확인합니다. 비교 시 부동소수점 값에 대해 0.01 포인트 오차를 허용합니다; 이는 모든 파일 형식에 대한 정확성을 보장하는 것은 아닙니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

예상 결과는 `900 x 600 points`와 `Size preserved: true`입니다. 새로 연 프레젠테이션을 확인함으로써 메모리상의 설정이 아니라 실제 저장된 파일을 검증합니다.

## **노트 및 유인물 내보내기**

페이지 크기는 노트 또는 유인물 레이아웃에 사용 가능한 영역을 정의합니다. 하지만 레이아웃 자체를 활성화하려면 내보내기 옵션도 설정해야 합니다. 일반 슬라이드 내보내기는 슬라이드 크기를 계속 사용합니다.

### **노트를 PDF 및 PNG로 내보내기**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notescommentslayoutingoptions/)을 [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 에 지정하면 PDF에 노트를 포함할 수 있습니다. 이 예제는 또한 첫 번째 슬라이드의 노트를 PNG로 렌더링하기 위해 [Slide::getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage)와 [RenderingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/renderingoptions/)를 사용합니다.

[BottomTruncated](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notespositions/) 모드는 노트를 한 페이지에 유지하고, 맞지 않는 부분은 잘라냅니다. PDF는 900 × 600 포인트 페이지를 사용합니다. 아래 예제에서 사용된 1 × 1 이미지 스케일에서는 PNG가 900 × 600 픽셀이 됩니다. 포인트는 페이지 기하학을 설명하고, 픽셀은 렌더링 스케일에 따라 결정되는 래스터 출력 크기를 설명합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

긴 노트를 포함한 PDF 내보내기의 경우 [BottomFull](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notespositions/)을 사용하면 필요에 따라 추가 페이지가 생성됩니다. 위의 단일 슬라이드 이미지 호출은 이 모드를 지원하지 않으니 사용하지 마세요. 크기를 조정한 후 출력에서 잘린 노트와 기존 노트‑마스터 개체 위치를 확인하세요; 페이지 크기만 바꾸는 것이 모든 콘텐츠가 맞게 들어간다는 보장은 아닙니다. 노트 내보내기에 대한 자세한 내용은 [Convert PowerPoint to PDF with Notes](/slides/ko/php-java/convert-powerpoint-to-pdf-with-notes/)를 참고하세요.

### **유인물을 PDF로 내보내기**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/handoutlayoutingoptions/)을 사용하면 한 페이지에 여러 슬라이드 썸네일을 배치할 수 있습니다. 아래 예제는 900 × 600 포인트 페이지를 설정하고 [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ko/php-java/aspose.slides/handouttype/)을 사용해 페이지당 최대 네 슬라이드를 가로 방향으로 정렬합니다. 가로 프리셋은 슬라이드 순서를 제어하고, 페이지 방향은 너비와 높이에서 유래합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

페이지 크기를 변경하면 유인물 그리드에 사용할 수 있는 영역이 바뀌지만 원본 슬라이드 크기는 변하지 않습니다. 유인물 이미지를 만들 때는 개별 슬라이드 이미지 메서드 대신 [Presentation::getImages](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getimages/)를 유인물 레이아웃과 함께 사용하세요. Aspose.Slides에서는 프레젠테이션 수준 유인물 렌더링이 노트 페이지 크기를 사용하지만, 개별 슬라이드 이미지 호출은 유인물 페이지를 생성하지 않습니다. 레이아웃 옵션은 [Handout Mode](/slides/ko/php-java/convert-powerpoint-in-handout-mode/)를 참고하세요.

## **뷰어, 내보내기 및 인쇄 시 페이지 크기**

저장된 프레젠테이션 크기, 내보낸 페이지 크기, 인쇄된 용지 크기를 구분하여 관리합니다:

- **프레젠테이션 뷰어:** 뷰어는 자체 레이아웃 규칙에 따라 노트를 표시하거나 인쇄할 수 있습니다. 다른 애플리케이션이 파일을 저장하면 다시 열어 차원을 확인하세요; 해당 애플리케이션의 형식 변환 과정에서 크기가 정규화될 수 있습니다.
- **내보내기 형식:** 위의 노트 및 유인물 PDF 예제는 구성된 페이지 크기를 사용합니다. 래스터 이미지는 정수 픽셀 크기와 렌더링 스케일을 사용하므로, 소수점 포인트 값이 이미지 출력에서 반올림될 수 있습니다. 일반 슬라이드 내보내기에는 노트 페이지 크기가 적용되지 않습니다.
- **프린터 드라이버:** 용지 선택, 자동 회전, 페이지 맞춤 설정 등은 실제 출력에 영향을 주지만 프레젠테이션이나 PDF에 저장된 차원을 바꾸지는 않습니다. 특정 용지 크기를 사용할 경우 프린터 설정을 맞추고 인쇄 미리보기를 확인하세요.

## **FAQ**

**한 슬라이드만 노트 크기를 지정할 수 있나요?**

노트 페이지 크기는 프레젠테이션 수준 설정입니다. 개별 슬라이드마다 다른 노트 내용을 가질 수는 있지만, 이 속성은 슬라이드마다 별도의 페이지 크기를 제공하지 못합니다.

**노트 방향을 바꿨는데 슬라이드가 바뀌지 않은 이유는?**

노트 페이지와 일반 슬라이드는 독립적인 차원을 가집니다. 슬라이드 자체 크기를 조정하려면 일반 슬라이드 크기 설정을 사용하세요.

**저장하거나 인쇄한 결과가 다른 크기로 나오는 이유는?**

먼저 저장된 프레젠테이션을 다시 열어 노트 차원을 비교하세요. 차원이 바뀌었다면 다른 애플리케이션에서 파일을 저장하거나 변환하면서 페이지 설정이 바뀌었을 수 있습니다. 그렇지 않다면 내보내기 레이아웃, 이미지 스케일, 뷰어 설정, 프린터 용지 선택 등을 확인하세요.