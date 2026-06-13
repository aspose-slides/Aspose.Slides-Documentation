---
title: PHP에서 프레젠테이션의 도형 Effective 속성 가져오기
linktitle: Effective 속성
type: docs
weight: 50
url: /ko/php-java/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 조명 장치
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 서식
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java가 정확한 PowerPoint 렌더링을 위해 효과적인 도형 속성을 계산하고 적용하는 방법을 알아보세요."
---
## **개요**

이 항목에서는 **local** 및 **effective** 속성의 차이를 설명합니다. Local 값은 특정 서식 수준에서 직접 설정되는 값이며, 예를 들어:

1. 슬라이드의 Portion 속성.
1. 레이아웃 또는 마스터 슬라이드에 있는 Prototype shape 텍스트 스타일(Portion의 텍스트 프레임 쉐이프가 있는 경우).
1. 프레젠테이션의 전역 텍스트 설정.

Local 값은 어느 수준에서든 정의하거나 생략할 수 있습니다. Aspose.Slides가 최종 “렌더링된” 서식이 필요할 때는 상속 체인을 해결하고 **effective** 값을 반환합니다. 로컬 서식 객체에서 `getEffective` 메서드를 호출하면 얻을 수 있습니다.

다음 예제는 effective 값을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)이며 최소 하나의 Portion이 있다고 가정합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Effective 서식 데이터는 상속이 적용된 후 계산된 현재 서식을 나타냅니다. 현재 구현에서는 [PortionFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/geteffective/)와 같은 메서드가 반환하는 일부 effective 데이터 객체가 내부에 캐시될 수 있습니다. 부모 또는 상속된 서식을 변경한 후 `getEffective`를 다시 호출하면 캐시된 데이터가 새로 고침되며, 이전에 얻은 객체는 더 이상 이전 상태를 나타내지 않을 수 있습니다. 나중에 재사용하려면 폰트 높이, 채우기 색, 폰트 스타일 또는 정렬과 같은 필요한 속성을 자체 데이터 객체로 복사하십시오.
{{% /alert %}}

## **카메라의 Effective 속성 가져오기**

Aspose.Slides는 카메라의 effective 속성을 가져올 수 있도록 지원합니다. [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/)가 반환하는 effective 데이터에는 [ThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/)에 대한 최종 카메라 속성이 포함됩니다.

다음 코드 샘플은 카메라의 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **조명 장치(Light Rig)의 Effective 속성 가져오기**

Aspose.Slides는 조명 장치의 effective 속성을 가져올 수 있도록 지원합니다. [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/)가 반환하는 effective 데이터에는 [ThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/)에 대한 최종 조명 장치 속성이 포함됩니다.

다음 코드 샘플은 조명 장치의 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **베벨(모서리) 형태의 Effective 속성 가져오기**

Aspose.Slides는 도형 베벨의 effective 속성을 가져올 수 있도록 지원합니다. [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/geteffective/)가 반환하는 effective 데이터에는 [ThreeDFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/threedformat/)에 대한 최종 면-돌출 속성이 포함됩니다.

다음 코드 샘플은 도형의 상단 베벨에 대한 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **텍스트 프레임의 Effective 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 프레임의 effective 속성을 가져올 수 있습니다. [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/geteffective/)가 반환하는 effective 데이터에는 텍스트 프레임 서식 속성이 포함됩니다.

다음 코드 샘플은 텍스트 프레임 서식의 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)이라고 가정합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **텍스트 스타일의 Effective 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 스타일의 effective 속성을 가져올 수 있습니다. [TextStyle.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textstyle/geteffective/)가 반환하는 effective 데이터에는 텍스트 스타일 속성이 포함됩니다.

다음 코드 샘플은 텍스트 스타일의 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)이라고 가정합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Effective 폰트 높이 값 가져오기**

Aspose.Slides를 사용하면 effective 폰트 높이를 가져올 수 있습니다. 다음 코드는 프레젠테이션 구조의 서로 다른 수준에서 로컬 폰트 높이 값을 설정한 후 Portion의 effective 폰트 높이가 어떻게 변경되는지 보여줍니다.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **표에 대한 Effective 채우기 서식 가져오기**

Aspose.Slides를 사용하면 표의 다양한 부분에 대한 effective 채우기 서식을 가져올 수 있습니다. 형식 객체가 반환하는 effective 데이터에는 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/) 속성이 포함됩니다. 셀 서식이 행 서식보다 우선순위가 높고, 행 서식이 열 서식보다, 열 서식이 전체 표 서식보다 우선합니다.

따라서 effective [CellFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cellformat/) 속성이 표 셀을 그리는 데 사용됩니다. 다음 코드 샘플은 표의 다양한 부분에 대한 effective 채우기 서식을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 [Table](https://reference.aspose.com/slides/ko/php-java/aspose.slides/table/)이라고 가정합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**`getEffective`가 스냅샷을 반환합니까?**

항상 그런 것은 아닙니다. Effective 데이터는 상속이 적용된 후 계산된 서식을 나타내지만, 일부 effective 데이터 객체는 내부에 캐시될 수 있습니다. 이후 `getEffective` 호출은 서식을 다시 계산하고 캐시된 데이터를 새로 고침하므로 이전에 얻은 객체를 영구적인 스냅샷으로 취급해서는 안 됩니다.

**언제 다시 effective 속성을 읽어야 하나요?**

로컬 서식, 부모 스타일, 레이아웃 서식, 마스터 서식 또는 프레젠테이션 수준 기본값을 변경한 후 `getEffective`를 다시 호출하십시오. 다음 호출은 서식 계층을 재평가하고 현재의 effective 결과를 반환합니다.

**레이아웃/마스터 슬라이드를 변경하거나 제거하면 이미 가져온 effective 속성에 영향을 줍니까?**

예, 변경 내용은 다음 `getEffective` 호출 시 반영됩니다. 부모 서식 원본이 변경되거나 제거되면 이전에 얻은 effective 데이터가 오래될 수 있습니다. `getEffective`를 다시 호출하면 Aspose.Slides가 서식 트리를 재평가하고 폰트, 색상, 크기 등 값이 변경될 수 있습니다.

**effective 데이터 객체를 통해 값을 수정할 수 있나요?**

아니오. Effective 데이터 객체는 계산된 값을 노출합니다. 로컬 서식 객체에서 변경하고 다시 effective 값을 얻어야 합니다.

**속성이 도형 수준, 레이아웃/마스터, 전역 설정 중 어느 곳에도 설정되지 않은 경우 어떻게 됩니까?**

effective 값은 PowerPoint와 Aspose.Slides 기본값을 포함하는 기본 메커니즘에 의해 결정됩니다. 해석된 값이 현재 effective 데이터의 일부가 됩니다.

**effective 폰트 값만 보고 어느 수준에서 크기나 글꼴이 제공되었는지 알 수 있나요?**

직접적으로는 알 수 없습니다. effective 데이터는 최종 값을 반환합니다.來源을 찾으려면 Portion, Paragraph, TextFrame 및 레이아웃, 마스터, 프레젠테이션 수준의 텍스트 스타일에서 로컬 값을 확인하여 첫 번째 명시적 정의가 어디에 있는지 확인하십시오.

**왜 때때로 effective 값이 로컬 값과 동일하게 보이나요?**

로컬 값이 최종 값이 되었기 때문입니다(상위 레벨 상속이 필요하지 않았습니다). 이런 경우 effective 값은 로컬 값과 일치합니다.

**언제 effective 속성을 사용하고 언제 로컬 속성만 사용해야 하나요?**

모든 상속이 적용된 “렌더링된” 결과가 필요할 때는 effective 데이터를 사용하십시오(예: 색상, 들여쓰기, 크기 정렬). 이러한 값을 나중에 서식 변경에 관계없이 보존하려면 필요한 속성을 자체 객체에 복사하십시오. 특정 레벨에서 서식을 변경해야 하는 경우 로컬 속성을 수정하고 필요에 따라 effective 데이터를 다시 읽어 결과를 확인하십시오.