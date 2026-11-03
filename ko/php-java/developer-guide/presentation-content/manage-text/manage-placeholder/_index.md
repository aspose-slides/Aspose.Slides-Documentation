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
description: "Aspose.Slides for PHP via Java를 사용하여 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속을 이해하는 방법을 배웁니다."
---
## **개요**

A placeholder는 프레젠테이션 템플릿에서 특정 유형의 콘텐츠 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반용 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 플레이스홀더 정보를 [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 메서드를 통해 노출합니다. 이 메서드는 일반 도형에 대해 `null`을 반환하거나 [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) 객체를 반환합니다. 플레이스홀더가 어떤 내용을 포함하도록 설계되었는지 확인하려면 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 을 사용하십시오.

플레이스홀더 유형을 알게 된 후에도 도형 클래스는 여전히 중요합니다:

- 빈 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 으로 표현됩니다.
- 채워진 그림 플레이스홀더는 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 로 표현될 수 있습니다.
- 채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 로 표현될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 라고 가정하지 말고 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 과 런타임 도형 클래스를 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 은 플레이스홀더의 역할을 설명하지만 도형의 런타임 클래스를 보장하지 않습니다. 텍스트, 그림, 차트, 표 또는 미디어 관련 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하며 경우에 따라 마스터 수준의 플레이스홀더를 정의합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드에서 사용되는 배치를 정의하고 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하며 레이아웃으로부터 상속받을 수 있습니다.

[Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) 을 호출하여 이 계층에서 한 단계 위로 이동합니다. 슬라이드 플레이스홀더는 일반적으로 레이아웃 플레이스홀더를 반환하고; 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 도형에 기본 플레이스홀더가 없으면 이 메서드는 `null`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 플레이스홀더를 나열하고 해당 기본 플레이스홀더를 보고합니다:
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

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 해당 설정을 아직 상속받는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며 동일한 좌표에 있다고 해서 상속을 시작하지 않습니다.

## **플레이스홀더 상태 제거**

템플릿을 적용할 때 [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) 을 사용하여 기존 객체를 일반 도형으로 유지합니다. 해당 객체의 [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 메서드는 `null`을 반환하지만, 도형은 슬라이드 컬렉션에 남아 있습니다. 반면에 [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) 은 해당 컬렉션에서 도형을 삭제합니다.

다음 예제는 최소 하나의 슬라이드와 첫 번째 슬라이드에 비어 있지 않은 텍스트 플레이스홀더가 포함된 `template.pptx` 를 필요로 합니다. 레이아웃이나 마스터에서 상속된 서식을 가진 플레이스홀더를 사용하여 해당 관계를 제거했을 때의 효과를 확인하십시오. 예제는 동일한 도형이 남아 있는지를 검사하고, 이제 일반 도형에 대해 다시 메서드를 호출한 뒤 결과를 저장합니다.

{{% alert color="warning" title="Warning" %}}
플레이스홀더 상태를 제거해도 상속된 외관 설정이 자동으로 보존되지 않습니다. 아래 예제는 이러한 설정을 의도적으로 변경하지 않으므로 출력이 다르게 보일 수 있습니다. 위치와 크기가 완전히 상속된 도형은 호출 후 좌표와 차원이 0이 되어 컬렉션에 남아 있더라도 보이지 않을 수 있습니다.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // 일반 도형에 대해 메서드를 호출해도 효과가 없습니다.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

일치하는 플레이스홀더에 대해 세 가지 확인 모두 `true` 를 출력합니다. 텍스트는 유지되지만, 플레이스홀더 관계가 제거되면 상속된 위치, 크기, 회전, 글꼴, 단락 정렬, 텍스트 프레임 여백, 수직 고정, 채우기 및 선 설정이 변경될 수 있습니다. 예를 들어, 상속된 제목 서식이 일반 텍스트 서식으로 되돌아갈 수 있습니다. 레이아웃에 대한 자세한 내용은 [Slide Layout](/slides/ko/php-java/slide-layout/) 를 참조하십시오.

원래 의도된 외관을 유지하려면 호출 전에 해결된 위치, 크기 및 회전을 캡처하고 필요한 실제 서식 값을 별도의 변수에 복사하십시오. 이러한 값은 [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) 을 통해 가져올 수 있습니다. 관계가 제거된 후 텍스트 서식 값이 변경될 수 있으므로 실제 서식 객체만 유지하는 것에 의존하지 마십시오. 캡처한 값을 이후에 일반 도형에 명시적으로 적용하십시오. 여기에는 템플릿에서 사용하는 글꼴 패밀리, 크기, 스타일, 색상, 단락 설정, 텍스트 프레임 설정, 채우기 및 선이 포함됩니다.

상속된 도형 기하학도 [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) 을 통해 명시적으로 지정해야 할 수 있습니다. 직사각형 텍스트 플레이스홀더의 경우 이는 [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) 을 할당함을 의미합니다; 채우기와 선만 복원해도 보이는 직사각형이 복원되지 않을 수 있습니다. 추가 효과나 더 복잡한 서식이 있는 템플릿은 해당 설정도 처리해야 합니다.

## **플레이스홀더의 텍스트 변경**

제목, 중앙제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. 해당 도형의 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) 메서드를 사용하기 전에 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 인지 확인하십시오.

이 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:
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

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 객체로 취급하는 것을 방지합니다. 또한 불안정한 도형 인덱스에 의존하는 대신 목적에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 빈 플레이스홀더에 표시되는 디자인 타임 안내문으로, 예를 들어 *제목을 추가하려면 클릭* 과 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려고 하지 말고 레이아웃 플레이스홀더에 사용자 정의 프롬프트 텍스트를 설정하십시오. 레이아웃은 [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) 로 접근하고 [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 가 반환하는 컬렉션을 반복하십시오.

다음 예제는 첫 번째 슬라이드에 사용된 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:
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

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션에서 빈 플레이스홀더를 위한 것입니다. 사용자가 실제 콘텐츠를 제공하면 프롬프트는 더 이상 표시되지 않습니다. 프롬프트를 변경해도 레이아웃을 사용하는 슬라이드의 기존 텍스트가 대체되지는 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 로 표현된 경우, [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) 과 [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) 을 사용하여 이미지를 교체하십시오.
- 아직 빈 플레이스홀더인 경우, [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) 로 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 제거하십시오.

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

빈 플레이스홀더에 대해 생성된 교체물은 새로운 플레이스홀더가 아니라 로컬 그림 프레임이며, 이는 [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 에 설정자가 없기 때문입니다. 예약된 위치는 유지하지만 더 이상 플레이스홀더 전용 동작을 상속하지 않습니다. 플레이스홀더 관계를 유지하는 것이 필수인 경우 먼저 PowerPoint에서 플레이스홀더를 준비하고 채운 다음, Aspose.Slides 로 결과 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 을 업데이트하십시오.

이미지 투명도, 자르기 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/php-java/picture-frame/) 를 참조하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기에 속하며 플레이스홀더 메타데이터와는 무관합니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 로 표현될 수 있습니다. 이 예제는 플레이스홀더 유형과 런타임 클래스를 모두 사용하여 해당 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:
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

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) 를 가집니다. PowerPoint에서는 차트, 표, 다이어그램, 그림 및 미디어 등 여러 콘텐츠 유형을 시작하는 역할을 합니다. 채워진 후에는 실제 도형 클래스를 검사하여 무엇을 포함하고 있는지 확인하십시오. 특수 레이아웃은 [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) 을 노출할 수도 있습니다.

Aspose.Slides는 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 을 변경한다는 이유만으로 빈 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 플레이스홀더를 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 로 변환하지 않습니다; 클래스 자체에서 유형을 변경할 수 없습니다. 빈 차트나 콘텐츠 영역을 프로그래밍으로 채우려면 플레이스홀더 좌표에 필요한 객체를 추가한 뒤 빈 플레이스홀더를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:
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

추가된 차트는 일반 로컬 차트입니다. 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 카테고리, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [chart management articles](/slides/ko/php-java/powerpoint-charts/) 를 사용하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 엔드‑투‑엔드 예제는 템플릿을 열고, 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트하여 출력으로 저장합니다. 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일한 클래스로 취급하지 않도록 의도적으로 설계되었습니다:
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

**기본 플레이스홀더란 무엇입니까?**

기본 플레이스홀더는 다른 플레이스홀더가 상속받는 레이아웃 또는 마스터에 해당하는 도형입니다. 이를 검색하려면 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) 을 사용하십시오. 일반 로컬 도형은 플레이스홀더 계층의 일부가 아니므로 `null`을 반환합니다.

**레이아웃 플레이스홀더를 편집하여 모든 슬라이드 제목을 변경할 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 기존 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 실제 제목 텍스트를 교체하려면 슬라이드를 순회하면서 각 제목 플레이스홀더를 업데이트하십시오.

**날짜, 슬라이드 번호, 헤더 및 푸터 플레이스홀더는 어떻게 관리합니까?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 핸드아웃 범위에서 헤더와 푸터 관리자를 사용하십시오. 전체 예제는 [Manage Presentation Header and Footer](/slides/ko/php-java/presentation-header-and-footer/) 를 참조하세요.