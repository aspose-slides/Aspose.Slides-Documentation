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
- 도형 조정점
- 프리셋 도형 조정
- 도형 기하학
- 도형 레이아웃 형식
- SVG 형식 도형
- 도형을 SVG로
- 도형 정렬
- 도형 뒤집기
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 도형을 식별하고, 조정하고, 복제하고, 제거하고, 숨기고, 순서를 변경하고, 내보내고, 정렬하고, 뒤집는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for PHP via Java은 슬라이드의 도형을 순서가 지정된 [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/)으로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 위치이자, 도형의 쌓임 순서의 원천입니다: 인덱스 `0`은 가장 뒤에 있는 도형이며, 마지막 인덱스는 가장 앞에 있는 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 신뢰성 있게 식별하고 미리 정의된 도형 조정점을 수정하는 방법을 설명하고, 이후 도형을 복제, 제거, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자가 아닙니다. 도형을 추가·제거·재정렬하면 인덱스가 바뀔 수 있습니다. 프레젠테이션이 어떻게 작성·관리되는지에 따라 식별자를 선택하세요:

- [Name](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getname/)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하세요.
- [AlternativeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getalternativetext/)은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자는 이를 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 은밀히 재사용하지 마세요.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getofficeinteropshapeid/)은 슬라이드 내에서 고유한 읽기 전용 식별자로, PowerPoint interop에서 사용하는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하세요. 복제되거나 다시 생성된 도형은 다른 도형이며 자체 ID를 가집니다.

관련 [Shape::getUniqueId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getuniqueid/) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이는 애드인용이며 재할당될 수 있습니다. 영구적인 외부 키로 취급하면 안 됩니다. 장기적인 정체성이 필요하면 애플리케이션 데이터에 매핑을 보관하고 기대하는 도형이 여전히 존재하는지 검증하세요.

다음 예제는 정확히 일치하는 이름으로 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 기대한 도형이 없을 경우, 코드는 잘못된 객체로 진행하지 않고 해당 결과를 보고합니다.

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

연산이 특정 도형 타입에만 해당되는 경우, 타입별 멤버를 사용하기 전에 런타임 클래스를 확인하세요. 이 예제는 이름이 지정된 객체가 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

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

## **미리 정의된 도형 조정점 식별 및 수정**

프리셋 기하학 도형은 모서리 크기, 화살표 비율, 호 각도와 같은 기능을 제어하는 조정점을 노출할 수 있습니다. 읽기 전용 [GeometryShape::getAdjustments](https://reference.aspose.com/slides/ko/php-java/aspose.slides/geometryshape/#getAdjustments) 컬렉션을 통해 접근합니다. 컬렉션 자체는 도형에 의해 제공되지만, 각 [AdjustValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/)는 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마세요. 조정점을 반복하면서 읽기 전용 [AdjustValue::getType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/#getType) 메서드를 검사하세요. 이 메서드의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 내용을 설명합니다. 읽기 전용 [AdjustValue::getName](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/getname/) 메서드는 추가 식별 정보를 제공하며, 같은 의미 유형의 조정이 여러 개 있는 경우 특히 유용합니다.

조정 의미에 맞는 값 메서드를 사용하세요:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | 둥근 모서리 크기 | [setRawValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 화살표 꼬리 두께 | `setRawValue` |
| `ArrowheadLength` | 화살촉 길이 | `setRawValue` |
| `ArrowheadWidth` | 화살촉 너비 | `setRawValue` |
| `StartAngle` | 파이 또는 호의 시작 각도 | [setAngleValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | 파이 또는 호의 끝 각도 | `setAngleValue` |

`getType`과 `getName`은 읽기 전용 정보를 반환합니다. `getRawValue`와 `setRawValue`는 프리셋 고유의 기하학 단위 정수를 사용하고, `getAngleValue`와 `setAngleValue`는 각도를 도(degree) 단위로 사용합니다. 조정의 개수, 순서, 의미 및 유효 범위는 프리셋 [GeometryShape::getShapeType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/geometryshape/#getShapeType)에 따라 달라집니다. 한 프리셋에 유효한 값이 다른 프리셋에서는 무효이거나 다른 효과를 낼 수 있습니다.

`getType`이 `ShapeAdjustmentType::Custom`을 반환하면 API가 표준 의미를 인식하지 못합니다. `getName`, 프리셋 타입 및 기존 값을 검토하고, 기대하는 의미와 범위를 알 때만 조정을 변경하세요. 인식된 타입이라도 동일 타입이 여러 번 나타나는지 확인한 후 값을 선택하세요. [Connector](/slides/ko/php-java/connector/) 문서에서는 커넥터 굽힘 조정 상황을 보여줍니다.

다음 완전한 예제는 세 가지 프리셋 도형의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 이름과 타입을 보고, `setRawValue`로 크기 관련 값을, `setAngleValue`로 각도를 변경하고 결과를 저장합니다. 왼쪽 열은 기본 기하학을 유지하고, 오른쪽 열은 조정된 라운드 사각형, 4방향 화살표 및 파이를 보여줍니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 기본 및 조정된 도형 열에 대한 헤더를 추가합니다.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

값을 변경하기 전에 의미 유형을 확인하면 코드의 의도가 명확해지고, 다른 프리셋 도형에서도 동일한 컬렉션 인덱스가 같은 의미를 가진다고 가정하는 실수를 방지할 수 있습니다.

## **도형 컬렉션 수정**

추가, 복제, 제거 및 순서 변경 메서드는 컬렉션에 즉시 적용됩니다. 연산이 도형 수나 순서를 바꾸면, 연산 이전에 캡처한 인덱스에 계속 의존하지 마세요.

### **도형 복제**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addclone/)은 독립적인 복제본을 만들고 대상 컬렉션에 추가합니다. [ShapeCollection::insertClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/insertclone/)도 복제본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표만 받는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비·높이를 받는 오버로드는 크기도 조정합니다.

예제는 대상 슬라이드를 만들고, 라벨이 붙은 사각형을 앞에 복제한 뒤, 두 번째 복제본을 뒤에 삽입합니다. 두 복제본 중 어느 하나를 변경해도 원본 도형은 수정되지 않습니다.

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

복제는 도형의 내용과 서식, 이름 및 대체 텍스트까지 복사합니다. 이러한 값이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하세요. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새로운 컬렉션 항목이며 새로운 도형 정체성을 가집니다.

### **도형 제거**

[ShapeCollection::remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/remove/)은 컬렉션에서 특정 도형 객체를 삭제합니다. 인덱스 기반 반복 중에 여러 일치를 제거할 경우, 남은 인덱스가 유효하도록 끝에서부터 순회하세요.

이 예제는 지정된 이름을 가진 모든 도형을 제거합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스의 도형을 읽으며, 불필요하게 형변환하지도 않습니다.

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

제거 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 커넥터, 애니메이션 등 제거된 객체를 참조할 수 있는 프레젠테이션 기능도 고려하세요; 보이는 도형을 제거하면 슬라이드 외관 이상의 변화가 일어날 수 있습니다.

### **도형 숨기기**

[Shape::setHidden](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/sethidden/)을 `true` 로 설정하면 도형은 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스, 서식 및 내용은 여전히 코드에서 접근 가능하므로, 나중에 복구할 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 사용자가 혹은 코드가 아직 객체를 발견하고 다시 표시할 수 있으며, 파일 내에 그대로 남아 있습니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [ShapeCollection::reorder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/reorder/)는 기존 도형을 복제하지 않고 목표 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `size() - 1`은 앞쪽을 의미합니다.

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

사각형을 먼저 만들면 처음에는 타원 뒤에 놓입니다. 최종 인덱스로 이동하면 앞에 배치됩니다. 모든 관련 도형을 추가·복제한 뒤에 z‑order를 최종 조정하세요. 이러한 연산은 새 컬렉션 항목을 추가하거나 삽입하면서 의도된 스택을 바꿀 수 있습니다.

## **레이아웃 슬라이드에서 도형 검사**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 동일 위치에 있더라도 같은 객체가 아닙니다. 레이아웃에서 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하세요.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getfillformat/) 및 [LineFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getlineformat/)을 읽으며, 모든 도형이 `AutoShape`인 것으로 가정하지 않습니다.

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

레이아웃을 편집하면 이를 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 해당 객체를 상속받는지 혹은 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하세요.

## **도형을 SVG로 내보내기**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/)은 하나의 도형 렌더링 결과를 스트림에 기록합니다. 결과에는 도형 자체만 포함되며 슬라이드 배경이나 인접 도형은 포함되지 않습니다.

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

렌더링 중에는 프레젠테이션을 열어 둬야 합니다. 출력은 도형 서식과 글꼴·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내세요. 호출자는 스트림을 소유하며 닫아야 합니다.

## **도형 정렬**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/alignshapes/) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapesalignmenttype/)은 가장자리, 중심선 또는 배치 방식을 지정합니다. `alignToSlide`를 `true` 로 설정하면 슬라이드 가장자리를 기준으로, `false` 로 설정하면 선택된 도형들 간의 상대 정렬을 수행합니다.

이 예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전 현재 인덱스로 변환됩니다.

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

정렬은 위치만 변경하고 z‑order는 바꾸지 않습니다. 상대 정렬은 일반적으로 최소 두 개의 도형이 필요하고, 가로·세로 배치는 간격을 정의할 만큼 충분한 도형이 필요합니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하세요.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapeframe/) 클래스는 위치, 크기, 가·세로 뒤집기 설정 및 회전을 저장합니다. `getFlipH`와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/php-java/aspose.slides/nullablebool/)을 사용합니다: `True`는 뒤집기 활성화, `False`는 비활성화, `NotDefined`는 지정되지 않은/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![뒤집기 전 도형](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하면서 두 뒤집기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/setframe/)을 할당하면 프레임 전체가 교체되기 때문에 중요합니다.

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

저장된 도형은 위치·크기·회전을 유지한 채 가로·세로로 모두 미러링됩니다.

![뒤집기 후 도형](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 연산 중에 변하지 않을 짧은 기간에만 사용하세요. 템플릿이 작성된 경우 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위 interop 작업에는 `OfficeInteropShapeId`를 권장합니다.

**도형을 숨기면 z‑order에서 제거되나요?**

아니요. 숨긴 도형은 같은 인덱스에 남아 있으며, 찾아서 순서를 바꾸거나 편집하거나 다시 표시할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`addClone`은 복제본을 컬렉션 끝에 추가합니다. 컬렉션 끝은 z‑order의 앞쪽에 해당합니다. 초기 인덱스를 지정하려면 `insertClone`을 사용하거나 모든 도형 추가 후 `reorder`로 조정하세요.

**프리셋 도형 조정점을 식별하기 위해 고정 인덱스를 사용할 수 있나요?**

프리셋과 컬렉션 레이아웃을 정확히 검증한 경우에만 가능합니다. `GeometryShape::getAdjustments`를 반복하면서 `AdjustValue::getType`을 확인하고, 동일 의미 유형이 여러 번 나타날 경우 `AdjustValue::getName`을 추가 정보로 활용하세요.