---
title: PHP에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/php-java/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 콘텐츠 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속을 이해하는 방법을 배우세요."
---
## **개요**

플레이스홀더는 프레젠테이션 템플릿에서 특정 종류의 콘텐츠를 위해 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 다목적 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 [Shape::getPlaceholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getplaceholder/) 메서드를 통해 플레이스홀더 정보를 제공합니다. 이 메서드는 일반 도형의 경우 `null`을 반환하고, [Placeholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholder/) 객체를 반환합니다. 플레이스홀더가 어떤 콘텐츠를 담도록 설계되었는지 확인하려면 [Placeholder::getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholder/gettype/)를 사용하십시오.

플레이스홀더 유형을 알게 된 후에도 도형 클래스는 여전히 중요합니다:

- 비어 있는 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)으로 표시됩니다.
- 내용이 채워진 그림 플레이스홀더는 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)으로 표시될 수 있습니다.
- 내용이 채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/)으로 표시될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)라고 가정하지 말고 [Placeholder::getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholder/gettype/)과 런타임 도형 클래스를 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholder/gettype/)은 플레이스홀더의 역할을 설명하지만, 도형의 런타임 클래스를 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어와 관련된 멤버에 접근하기 전에 항상 유형을 확인하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 다음과 같은 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고, 경우에 따라 마스터 수준의 플레이스홀더도 정의합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드에 사용되는 배치를 정의하며, 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[Shape::getBasePlaceholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getbaseplaceholder/)를 호출하면 이 계층에서 한 단계 위로 이동합니다. 일반 슬라이드의 플레이스홀더는 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 해당 도형에 기본 플레이스홀더가 없으면 메서드는 `null`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 플레이스홀더를 열거하고 해당 기본 플레이스홀더를 보고합니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 해당 설정을 아직 상속받는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며, 동일한 좌표에 있다고 해서 자동으로 상속을 시작하지는 않습니다.

## **플레이스홀더의 텍스트 변경**

제목, 중앙 제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. 텍스트 프레임에 접근하기 전에 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)인지 확인하고, 그 뒤에 [getTextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/gettextframe/) 메서드를 사용하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 객체로 취급하지 않도록 방지합니다. 또한 취약한 도형 인덱스에 의존하지 않고 용도별로 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 지정**

프롬프트 텍스트는 빈 플레이스홀더에 표시되는 디자인 타임 안내문으로, 예를 들어 *클릭하여 제목 입력*과 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려고 시도하기보다 레이아웃 플레이스홀더에 직접 사용자 지정 프롬프트 텍스트를 설정하십시오. 레이아웃은 [Slide::getLayoutSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getLayoutSlide)으로 접근하고, [BaseSlide::getShapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/#getShapes)으로 반환된 컬렉션을 순회하십시오.

다음 예제는 첫 번째 슬라이드가 사용하는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션에서 빈 플레이스홀더에 표시되는 안내문이며, 사용자가 실제 콘텐츠를 입력하면 더 이상 표시되지 않습니다. 프롬프트를 변경해도 해당 레이아웃을 사용하는 슬라이드의 기존 텍스트가 교체되지는 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)으로 표시되는 경우, [PictureFillFormat::getPicture](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillformat/getpicture/)와 [SlidesPicture::setImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidespicture/setimage/)를 사용해 이미지를 교체합니다.
- 아직 빈 플레이스홀더라면, [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addpictureframe/)으로 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 제거합니다.

다음 예제는 두 경우를 모두 지원하고 프레젠테이션을 저장합니다:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

빈 플레이스홀더에 대해 만든 교체는 새로운 플레이스홀더가 아니라 로컬 그림 프레임이며, [Shape::getPlaceholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getplaceholder/)에 설정자가 없기 때문에 자리만 예약하고 플레이스홀더 고유 동작을 상속하지 않습니다. 플레이스홀더와의 관계를 유지해야 한다면 먼저 PowerPoint에서 플레이스홀더를 준비하고 채운 뒤, Aspose.Slides로 해당 [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/)을 업데이트하십시오.

이미지 투명도, 크롭 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/php-java/picture-frame/)를 참고하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기와 관련이 있으며, 플레이스홀더 메타데이터와는 별개입니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/)로 표시될 수 있습니다. 다음 예제는 플레이스홀더 유형과 런타임 클래스를 모두 확인하여 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType::Object](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholdertype/)를 갖습니다. PowerPoint에서 이는 차트, 표, 다이어그램, 그림, 미디어 등 여러 콘텐츠 유형의 시작점 역할을 합니다. 콘텐츠가 채워진 후에는 실제 도형 클래스를 검사해 어떤 내용이 포함됐는지 확인하십시오. 특수 레이아웃은 [PlaceholderType::Chart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholdertype/), 또는 [PlaceholderType::Diagram](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholdertype/)을 노출할 수 있습니다.

Aspose.Slides는 [Placeholder::getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/placeholder/gettype/)을 변경한다고 해서 빈 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 플레이스홀더가 자동으로 [Chart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/)로 변환되지 않으며, 유형은 클래스 자체를 통해 변경할 수 없습니다. 빈 차트 또는 콘텐츠 영역을 프로그래밍 방식으로 채우려면 해당 좌표에 필요한 객체를 추가한 뒤 빈 플레이스홀더를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

추가된 차트는 일반 로컬 차트이며, 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 카테고리, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [chart management articles](/slides/ko/php-java/powerpoint-charts/)를 참고하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 엔드‑투‑엔드 예제는 템플릿을 열고, 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고, 적절한 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 이 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일 클래스라고 취급하는 것을 의도적으로 피합니다.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**기본 플레이스홀더란 무엇인가요?**

기본 플레이스홀더는 다른 플레이스홀더가 상속받는 레이아웃 또는 마스터에 있는 해당 도형을 의미합니다. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getbaseplaceholder/)를 사용해 가져올 수 있습니다. 일반 로컬 도형은 플레이스홀더 계층에 속하지 않기 때문에 `null`을 반환합니다.

**레이아웃 플레이스홀더를 편집해서 모든 슬라이드 제목을 바꿀 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 실제 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 제목 텍스트를 교체하려면 슬라이드를 순회하면서 각 제목 플레이스홀더를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 머리글 및 바닥글 플레이스홀더는 어떻게 관리하나요?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 핸드아웃 범위에서 머리글·바닥글 관리자를 사용하십시오. 전체 예제는 [Manage Presentation Header and Footer](/slides/ko/php-java/presentation-header-and-footer/)를 참고하세요.