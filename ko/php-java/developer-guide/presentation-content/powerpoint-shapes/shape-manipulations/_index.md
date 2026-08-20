---
title: PHP에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/php-java/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 서식
- SVG로 도형
- 도형을 SVG로
- 도형 정렬
- 도형 뒤집기
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 도형을 식별하고, 복제하고, 제거하고, 숨기고, 순서를 변경하고, 내보내고, 정렬하고, 뒤집는 방법을 배우세요."
---
## **개요**

Aspose.Slides for PHP via Java은 슬라이드의 도형을 순서가 지정된 [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/)으로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 위치이면서 동시에 도형의 스택 순서의 원천이며, 인덱스 `0`은 가장 뒤에 있는 도형이고 마지막 인덱스는 가장 앞에 있는 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 신뢰성 있게 식별하는 방법을 설명하고, 이어서 도형을 복제, 제거, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준의 서식 지정, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만, 안정적인 식별자는 아닙니다. 도형을 추가, 제거 또는 순서를 변경하면 인덱스가 바뀔 수 있습니다. 프레젠테이션이 작성되고 유지 관리되는 방식에 따라 식별자를 선택하십시오:

- [Name](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getname/) 은 개발자가 제어하는 템플릿에 유용하며 PowerPoint의 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집할 수 있지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getalternativetext/) 은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자가 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있고, 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 조용히 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getofficeinteropshapeid/) 은 슬라이드 내에서 고유한 읽기 전용 식별자로, PowerPoint 인터롭에서 사용되는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 받습니다.

관련된 [Shape::getUniqueId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getuniqueid/) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이 식별자는 애드인용으로 설계되어 재지정될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 식별이 필수라면 애플리케이션 데이터에 매핑을 보관하고 기대하는 도형이 여전히 존재하는지 검증하십시오.

다음 예제는 정확히 일치하는 이름으로 검색하고 슬라이드 범위의 인터롭 ID를 보고합니다. 템플릿에 기대하는 도형이 없을 경우, 코드는 잘못된 객체를 계속 사용하지 않고 해당 결과를 보고합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

작업이 특정 도형 유형에만 해당되는 경우, 타입별 멤버를 사용하기 전에 런타임 클래스를 확인하십시오. 이 예제는 명명된 객체가 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **도형 컬렉션 수정**

add, clone, remove, reorder 메서드는 컬렉션에 즉시 적용됩니다. 작업으로 인해 도형 수나 순서가 변경되면, 해당 작업 이전에 캡처한 인덱스에 계속 의존하지 마십시오.

### **도형 복제**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addclone/) 은 독립적인 복사본을 생성하여 대상 컬렉션에 추가합니다. [ShapeCollection::insertClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/insertclone/) 도 복사본을 만들지만 지정된 Z 순서 인덱스에 배치합니다. 좌표를 받는 오버로드는 크기를 변경하지 않고 복제본을 이동하며, 너비와 높이를 받는 오버로드는 크기 조절도 할 수 있습니다.

예제는 대상 슬라이드를 만들고 라벨이 붙은 사각형을 앞쪽에 복제한 뒤, 두 번째 복제본을 뒤쪽에 삽입합니다. 각 복제본에 대한 변경은 원본 도형에 영향을 주지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

복제는 도형의 내용과 서식을 복사하며, 이름과 대체 텍스트도 포함합니다. 해당 값들이 고유해야 할 경우 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새로운 컬렉션 항목이자 새로운 도형 ID를 가집니다.

### **도형 제거**

[ShapeCollection::remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/remove/) 은 컬렉션에서 특정 도형 객체를 삭제합니다. 인덱스 순회 중에 여러 일치를 제거할 때는 끝에서부터 역순으로 탐색하면 남은 인덱스가 유효하게 유지됩니다.

이 예제는 지정된 이름을 가진 모든 도형을 제거합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스의 도형을 읽으며, 필요 없이 도형을 캐스팅하지도 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

제거 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조가 저장된 인덱스보다 더 신뢰됩니다. 또한 연결선, 애니메이션 및 기타 프레젠테이션 기능이 제거된 객체를 참조할 수 있으므로, 보이는 도형을 제거하면 슬라이드 모양 이상으로 변화가 일어날 수 있습니다.

### **도형 숨기기**

[Shape::setHidden](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/sethidden/) 을 `true` 로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에서 표시되지 않습니다. 인덱스, 서식, 내용은 코드에서 여전히 사용할 수 있으므로, 나중에 복원될 수 있는 선택적 요소를 숨기는 데 적합합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

숨기기는 삭제나 보안이 아닙니다. 사용자가 또는 코드가 여전히 객체를 찾아서 다시 보이게 할 수 있으며, 프레젠테이션 파일의 일부로 남아 있습니다.

### **Z 순서 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [ShapeCollection::reorder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/reorder/) 은 기존 도형을 복제하지 않고 대상 인덱스로 이동합니다. 인덱스 `0` 은 뒤쪽이며, `size() - 1` 은 앞쪽입니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

사각형은 먼저 생성되어 처음에 타원 뒤에 위치합니다. 최종 인덱스로 이동하면 앞쪽에 놓이게 됩니다. 관련 도형을 모두 추가하거나 복제한 후에 Z 순서를 확정하십시오. 이러한 작업은 새로운 컬렉션 항목을 추가하거나 삽입하여 의도된 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드의 동일한 위치에 있는 도형과 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 경우 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getfillformat/) 와 [LineFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getlineformat/) 을 읽으며, 모든 도형이 `AutoShape` 라는 가정을 하지 않습니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

레이아웃을 편집하면 이를 사용하는 여러 슬라이드에 영향을 미칠 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속받는지, 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG로 내보내기**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/) 은 하나의 도형 렌더링 내용을 스트림에 기록합니다. 결과에는 해당 도형만 포함되며 전체 슬라이드 배경이나 인접 도형은 포함되지 않습니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

렌더링 중에는 프레젠테이션을 열어 두십시오. 출력은 도형의 서식과 폰트, 이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 스트림의 소유자는 스트림을 닫아야 합니다.

## **도형 정렬**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/alignshapes/) 의 오버로드는 모든 도형이나 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapesalignmenttype/) 은 가장자리, 중심선 또는 배치 모드를 지정합니다. `alignToSlide` 를 `true` 로 설정하면 슬라이드 가장자리를 사용하고, `false` 로 설정하면 선택된 도형들을 서로 상대적으로 정렬합니다.

이 예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

정렬은 위치만 변경하고 Z 순서는 바꾸지 않습니다. 상대 정렬은 보통 최소 두 개의 도형이 필요하고, 수평 또는 수직 배치는 간격을 정의할 충분한 도형이 필요합니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평 및 수직 뒤집기 설정, 회전을 저장합니다. `getFlipH` 와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/php-java/aspose.slides/nullablebool/) 을 사용하며, `True` 는 뒤집기를 활성화하고, `False` 는 비활성화하며, `NotDefined` 는 지정되지 않거나 기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![뒤집기 전 도형](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하고 두 개의 뒤집기 설정만 교체합니다. 새 [Frame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/setframe/) 을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

저장된 도형은 위치, 크기, 회전을 유지하면서 수평 및 수직으로 반전됩니다.

![뒤집은 후 도형](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해야 하나요?**

인덱스 사용은 컬렉션이 인덱스 사용 전까지 변경되지 않을 짧은 처리 과정에만 제한하십시오. 작성된 템플릿에서는 검증된 `Name` 또는 `AlternativeText` 규칙을 선호하고, 슬라이드 범위 인터롭 작업에는 `OfficeInteropShapeId` 를 사용하십시오.

**도형을 숨기면 Z 순서에서 제거되나요?**

아니요. 숨겨진 도형은 동일한 인덱스에 컬렉션에 남아 있습니다. 찾아서 순서를 바꾸거나, 편집하거나, 다시 표시할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는 무엇인가요?**

`addClone` 은 복제본을 컬렉션 끝에 추가하므로 Z 순서의 앞쪽에 위치합니다. 초기 인덱스를 지정하려면 `insertClone` 을 사용하고, 모든 도형을 추가한 후에는 `reorder` 를 사용하십시오.