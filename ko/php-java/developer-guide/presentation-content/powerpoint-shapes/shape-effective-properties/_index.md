---
title: PHP에서 프레젠테이션의 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/php-java/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 라이트 릭
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 로컬, 상속 및 유효 도형 서식을 구분하는 방법을 배웁니다."
---
## **로컬, 상속 및 유효 속성 이해**

PowerPoint 서식은 여러 위치에서 올 수 있습니다. 객체에 직접 저장된 값은 **로컬 값**입니다. 해당 값이 설정되지 않으면 PowerPoint는 단락 기본값, 텍스트 스타일, 레이아웃 또는 마스터 슬라이드, 테마 또는 프레젠테이션 수준 기본값과 같은 상위 서식 소스를 확인합니다. 이러한 값은 **상속 값**입니다. 전체 계층 구조가 해결된 후 남는 값이 **유효 값**—객체를 렌더링하는 데 사용되는 값입니다.

예를 들어, 텍스트 부분이 자체 글꼴 높이를 정의하지 않을 수 있습니다. 해당 로컬 [getFontHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/) 값은 `NAN`이며, 이는 "여기에서 설정되지 않음"을 의미합니다. 이 부분은 단락, 프레젠테이션 기본 텍스트 스타일 또는 다른 적용 가능한 소스에서 높이를 상속받을 수 있습니다. 부분 형식에서 [getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/geteffective/)을 호출하면 최종 해결된 높이가 반환됩니다.

다음 두 종류의 서식 데이터를 다른 목적에 사용하십시오:

- 값이 정의된 위치를 제어해야 할 때와 같이 [PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/)과 같은 로컬 서식 객체를 읽거나 변경합니다.
- 최종 렌더링 결과가 필요할 때와 같이 [PortionFormat.getEffective가 반환하는 데이터](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/geteffective/)와 같은 유효 데이터 객체를 읽습니다. 유효 데이터는 읽기 전용입니다.

예제를 실행하기 전에, [Aspose.Slides for PHP via Java 설치](/slides/ko/php-java/installation/)하십시오.

## **로컬, 상속 및 유효 값 비교**

다음 전체 예제는 도형을 만들고 프레젠테이션, 단락 및 부분 수준에서 글꼴 높이를 적용합니다. 각 단계에서는 해당 수준에서 정의된 값을 출력하고 동일한 텍스트 부분에 대한 결과 유효 값을 표시합니다. 또한 서식 변경 후 유효 데이터를 다시 읽어야 하는 이유를 보여줍니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // 이전 변경 후 유효 데이터를 읽습니다.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // 두 가지 다른 레벨에서 상속된 값을 정의합니다.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // 부분에 대한 로컬 값이 두 상속 값을 모두 덮어씁니다.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // 상속된 값을 변경해도 기존 로컬 값을 덮어쓰지 않습니다.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // 로컬 값을 지웁니다. 이제 부분이 다시 단락에서 상속받습니다.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // 단락 값을 지웁니다. 이제 프레젠테이션 기본값이 결과를 제공합니다.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이 예제에서 우선 순위는 부분 로컬 서식, 다음은 단락 서식, 그리고 프레젠테이션 기본값입니다. 다른 객체는 다른 상속 체인을 가질 수 있지만 원리는 동일합니다: 보다 구체적인 명시적 값이 우선하며, [getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/geteffective/)은 최종 결과를 반환합니다.

## **유효 텍스트 속성 가져오기**

텍스트 서식은 여러 객체에 걸쳐 분할됩니다:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/geteffective/) 텍스트 프레임 여백, 앵커링, 자동 맞춤 및 세로 텍스트 방향과 같은 텍스트 프레임 속성을 해결합니다.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textstyle/geteffective/) 각 텍스트 스타일 레벨에 대한 단락 서식을 해결합니다.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraphformat/geteffective/) 정렬, 들여쓰기 및 글머리 기호와 같은 단락 속성을 해결합니다.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/geteffective/) 글꼴 높이, 글꼴, 색상, 굵게 및 기울임꼴과 같은 문자 속성을 해결합니다.

다음 예제에서는 `text-formatting.pptx`에 최소 하나의 슬라이드와 비어 있지 않은 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)이 포함되어 있어야 합니다. AutoShape는 도형 컬렉션의 어느 위치에든 나타날 수 있으며, 코드는 사용 전에 적합한 객체를 검색하고 검증합니다.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **유효 3D 속성 가져오기**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/)는 모든 해결된 3D 설정을 그룹화하는 하나의 유효 데이터 객체를 반환합니다. 해당 객체의 [getCamera](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/), [getBevelBottom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/) 메서드는 각각의 유효 데이터를 표시합니다. 이러한 관련 설정을 함께 읽으면 도형의 최종 3D 외관을 이해하기가 쉬워집니다.

이 예제에서는 `shape-3d.pptx`의 첫 번째 슬라이드에 최소 하나의 도형이 포함되어 있어야 합니다. 출력에 기본값 이외의 값이 포함되도록 하려면 해당 도형에 3D 카메라, 조명 또는 베벨 설정을 적용하십시오.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **유효 테이블 서식 가져오기**

테이블 서식은 테이블 스타일 및 전체 테이블, 열, 행 또는 개별 셀에 적용된 서식에서 올 수 있습니다. 명시적으로 정의된 채우기 간의 충돌이 있을 경우 우선 순위는 셀, 행, 열, 그 다음 전체 테이블입니다. 셀의 유효 서식은 해당 셀을 그리는 데 사용되는 최종 서식입니다.

이 예제에서는 `table-formatting.pptx`의 첫 번째 슬라이드에 최소 하나의 테이블이 포함되어 있어야 합니다. 테이블은 최소 하나의 행과 하나의 열을 가져야 합니다. 코드는 `getShapes()->get_Item(0)`이 테이블이라고 가정하는 대신 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/)을 검색합니다.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

채우기 유형만이 아니라 색상이 필요한 경우, 먼저 유효 [getFillType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/geteffective/) 값을 확인한 다음 해당 유형에 적용되는 메서드를 읽습니다—예를 들어, 단색 채우기의 경우 [getSolidFillColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/geteffective/)을 사용합니다.

## **변경 후 유효 데이터 다시 읽기**

유효 데이터는 해결 시점의 서식 계층 구조를 설명합니다. 해당 계층에 참여할 수 있는 항목을 변경한 후 `getEffective`을 다시 호출하십시오. 대상에는 다음이 포함됩니다:

- 객체의 로컬 서식;
- 단락 또는 텍스트 프레임 기본값;
- 테이블 스타일, 테이블, 열, 행 또는 셀 서식;
- 레이아웃 또는 마스터 슬라이드 서식;
- 테마 데이터 또는 프레젠테이션 수준 기본값;
- 슬라이드에 할당된 레이아웃 또는 마스터.

유효 데이터 객체를 영구 스냅샷으로 보관하지 마십시오. Aspose.Slides는 일부 유효 데이터를 내부에 캐시할 수 있으며, 이후 `getEffective` 호출 시 해당 데이터를 새로 고칠 수 있습니다. 변경 전후의 값을 비교해야 하는 경우, 변경하기 전에 글꼴 높이, 색상, 정렬 또는 베벨 너비와 같은 필요한 스칼라 값을 자신의 변수에 복사하십시오.

값을 변경하려면 해당 로컬 서식 객체를 업데이트한 다음 `getEffective`을 호출하여 결과를 확인하십시오. 유효 데이터 객체 자체는 읽기 전용입니다.

## **FAQ**

**어떤 레벨에서 유효 값을 제공했는지 어떻게 알 수 있나요?**

유효 데이터에는 최종 값만 포함되고, 그 출처는 포함되지 않습니다. 가장 구체적인 레벨부터 외부로 적용 가능한 로컬 객체들을 검사하십시오. 텍스트의 경우, 부분, 단락, 텍스트 프레임, 레이아웃, 마스터, 테마 및 프레젠테이션 기본값이 포함될 수 있습니다. `NAN` 또는 `null`과 같은 정의되지 않은 값은 검색이 다른 레벨로 계속됨을 나타냅니다.

**어떤 레벨도 속성을 정의하지 않을 경우 어떻게 되나요?**

Aspose.Slides는 적절한 PowerPoint 또는 라이브러리 기본값을 해결합니다. 해당 해결된 값은 로컬 객체가 명시적으로 정의하지 않았더라도 유효 데이터에 나타납니다.

**왜 유효 값이 때때로 로컬 값과 동일한가요?**

로컬 값이 상속 계산에서 승리했기 때문입니다. 객체에 속성이 명시적으로 설정되고 더 구체적인 규칙이 이를 덮어쓰지 않을 때 기대되는 상황입니다.

**언제 로컬 데이터를 사용하고 언제 유효 데이터를 사용해야 하나요?**

특정 서식 레벨을 검사하거나 편집하려면 로컬 데이터를 사용하십시오. 상속, 테마 규칙 및 적용 가능한 스타일이 해결된 후 최종 외관이 필요할 때는 유효 데이터를 사용합니다. [전체 비교 예제](#compare-local-inherited-and-effective-values)에서는 동일한 워크플로에서 두 가지를 모두 보여줍니다.