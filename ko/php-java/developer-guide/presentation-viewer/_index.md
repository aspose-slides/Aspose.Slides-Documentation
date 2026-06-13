---
title: PHP에서 프레젠테이션 뷰어 만들기
linktitle: 프레젠테이션 뷰어
type: docs
weight: 50
url: /ko/php-java/presentation-viewer/
keywords:
- 프레젠테이션 보기
- 프레젠테이션 뷰어
- 프레젠테이션 뷰어 만들기
- PPT 보기
- PPTX 보기
- ODP 보기
- 파워포인트
- 오픈문서
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 맞춤형 프레젠테이션 뷰어를 만듭니다. Microsoft PowerPoint 없이도 PowerPoint 및 OpenDocument 파일을 쉽게 표시할 수 있습니다."
---
## **소개**

Aspose.Slides for PHP via Java은 슬라이드가 포함된 프레젠테이션 파일을 생성하는 데 사용됩니다. 이러한 슬라이드는 예를 들어 Microsoft PowerPoint에서 프레젠테이션을 열어 확인할 수 있습니다. 그러나 때때로 개발자는 슬라이드를 선호하는 이미지 뷰어에서 이미지로 보거나 자체 프레젠테이션 뷰어를 만들고 싶을 수 있습니다. 이러한 경우 Aspose.Slides를 사용하면 개별 슬라이드를 이미지로 내보낼 수 있습니다. 이 문서에서는 그 방법을 설명합니다.

## **슬라이드에서 SVG 이미지 생성**

Aspose.Slides를 이용해 프레젠테이션 슬라이드에서 SVG 이미지를 생성하려면 아래 단계를 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 파일 스트림을 엽니다.
1. 슬라이드를 SVG 이미지로 파일 스트림에 저장합니다.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **사용자 정의 Shape ID로 SVG 생성**

Aspose.Slides를 사용하여 사용자 정의 Shape ID가 있는 슬라이드에서 SVG를 생성할 수 있습니다. 이를 위해서는 [SvgShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgshape/)의 `setId` 메서드를 사용합니다. `CustomSvgShapeFormattingController`를 사용하여 Shape ID를 설정할 수 있습니다.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **슬라이드 썸네일 이미지 생성**

Aspose.Slides는 슬라이드 썸네일 이미지를 생성하는 데 도움을 줍니다. Aspose.Slides를 사용해 슬라이드 썸네일을 만들려면 아래 단계를 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 배율로 해당 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **사용자 정의 크기로 슬라이드 썸네일 생성**

사용자 정의 크기로 슬라이드 썸네일 이미지를 만들려면 아래 단계를 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 크기로 해당 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **발표자 노트가 포함된 슬라이드 썸네일 생성**

Aspose.Slides를 사용해 발표자 노트가 포함된 슬라이드 썸네일을 생성하려면 아래 단계를 따라 주세요:

1. [RenderingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/renderingoptions/) 클래스의 인스턴스를 생성합니다.
1. `RenderingOptions.setSlidesLayoutOptions` 메서드를 사용해 발표자 노트 위치를 설정합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 렌더링 옵션을 적용해 해당 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Live Example**

Aspose.Slides API로 구현할 수 있는 내용을 확인하려면 무료 앱인 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/ko/viewer/)를 사용해 보세요:

![온라인 PowerPoint 뷰어](online-PowerPoint-viewer.png)

## **FAQ**

**웹 애플리케이션에 프레젠테이션 뷰어를 임베드할 수 있나요?**

네. Aspose.Slides를 서버 측에서 사용해 슬라이드를 이미지나 HTML로 렌더링하고 브라우저에 표시할 수 있습니다. JavaScript를 활용해 탐색 및 줌 기능을 구현하면 인터랙티브한 경험을 제공할 수 있습니다.

**맞춤형 뷰어 안에서 슬라이드를 표시하는 가장 좋은 방법은 무엇인가요?**

권장 방법은 각 슬라이드를 이미지(PNG 또는 SVG 등)로 렌더링하거나 Aspose.Slides를 사용해 HTML로 변환한 후, 데스크톱에서는 picture box에, 웹에서는 HTML 컨테이너에 출력하는 것입니다.

**많은 슬라이드가 포함된 대용량 프레젠테이션을 어떻게 처리하나요?**

대용량 프레젠테이션의 경우 슬라이드를 지연 로드하거나 필요할 때만 렌더링하는 방식을 고려하세요. 즉, 사용자가 해당 슬라이드로 이동할 때만 내용을 생성함으로써 메모리 사용량과 로드 시간을 줄일 수 있습니다.