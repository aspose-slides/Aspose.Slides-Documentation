---
title: PHP에서 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/php-java/presentation-theme/
keywords:
- PowerPoint 테마
- 프레젠테이션 테마
- 슬라이드 테마
- 테마 설정
- 테마 변경
- 테마 관리
- 외부 테마
- THMX
- 테마 색상
- 추가 팔레트
- 테마 글꼴
- 테마 스타일
- 테마 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides에서 프레젠테이션 테마를 마스터하여 일관된 브랜드를 유지하면서 PowerPoint 파일을 생성, 맞춤 설정 및 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 각 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마 변경 시 많은 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서 프레젠테이션 수준 테마는 [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)을 통해 사용할 수 있습니다. 프레젠테이션은 하위 수준에서도 테마 재정의를 포함할 수 있습니다. 마스터는 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterthememanager/)을 통해 프레젠테이션 테마를 재정의할 수 있으며, 레이아웃이나 개별 슬라이드는 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseoverridethememanager/)을 통해 상속된 테마를 재정의할 수 있습니다. 실제로 슬라이드에 적용되는 효과적인 테마는 다음과 같은 상속 체인을 통해 해결됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 재정의가 해결된 후의 효과적인 값 읽기.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mastertheme/) 객체는 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mastertheme/), [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mastertheme/)을 통해 테마의 색 구성표, 글꼴 구성표 및 형식 구성표를 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하면 외부 소스에서 가져온 프레젠테이션의 경우 스타일 항목 수와 내용이 다양할 수 있기 때문에 특히 유용합니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선 및 효과 스타일의 개수를 보고합니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

파일에 여러 마스터가 사용된 경우 모든 슬라이드가 동일한 효과적인 테마를 가진다고 가정하지 마십시오. 슬라이드와 연결된 마스터를 검사하고, 레이아웃 또는 슬라이드 재정의가 존재할 수 있는 경우 아래에 표시된 효과적인 테마 작업 흐름을 사용하십시오.

## **테마 색상 변경**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/schemecolor/) 열거형의 논리 색상을 참조할 수 있습니다. [ColorScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/colorscheme/)에서 해당 항목을 변경하면 여전히 해당 테마 색상을 참조하는 모든 객체가 새 값으로 해결됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트에 의해 변경되지 않습니다.

다음 엔드‑투‑엔드 예제는 `Accent4`를 사용하는 도형을 만든 뒤 테마의 `Accent4` 색을 빨간색으로 변경하고, 프레젠테이션을 저장한 뒤 다시 열어 효과적인 채우기 색을 출력합니다:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

사각형이 `Accent4`에 계속 연결되어 있기 때문에 테마가 변경되면 표시 색상이 빨간색으로 바뀝니다. 도형에 직접 색을 지정하면 이후 `Accent4` 변경이 해당 채우기에 영향을 주지 않습니다.

### **추가 팔레트 색 사용**

PowerPoint는 테마 색상에 색 변환을 적용하여 밝고 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![주 테마 색상 및 추가 팔레트에서 생성된 밝고 어두운 색](additional-palette-colors.png)

**1** - 주 테마 색상.  
**2** - 주 테마 색상으로부터 생성된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 여섯 개 사각형을 만든 뒤 다섯 개에 밝기 변환을 적용하고 결과를 저장합니다:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이 변형들은 여전히 테마 색상을 기반으로 합니다. `Accent4`가 나중에 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `ColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [ColorScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/colorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이는 같은 테마 슬롯에 대한 다른 이름일 뿐이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 구성표는 제목용 주요 글꼴 집합과 본문용 부 글꼴 집합을 포함합니다. [FontScheme.getMajor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontscheme/) 및 [FontScheme.getMinor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontscheme/) 메서드를 통해 해당 집합을 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 형식 지정에 사용할 수 있습니다:

* `+mn-lt` - 본문 라틴 글꼴 (Minor Latin Font)
* `+mj-lt` - 제목 라틴 글꼴 (Major Latin Font)
* `+mn-ea` - 본문 동아시아 글꼴 (Minor East Asian Font)
* `+mj-ea` - 제목 동아시아 글꼴 (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 제목 하나와 부 라틴 테마 글꼴을 사용하는 본문 한 줄을 만든 뒤 테마 글꼴을 변경하고 결과를 저장합니다:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

제목은 주요 글꼴을 따르고 본문 텍스트는 부 글꼴을 따릅니다. 명시적으로 글꼴 이름을 지정한 텍스트는 테마 글꼴 구성표가 변경돼도 자동으로 전환되지 않습니다.

주요 및 부 글꼴 컬렉션에는 키릴 문자, 아라비아어, 일본어, 그루지야어, 타나 문자와 같은 개별 작문 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script‑Specific Theme Fonts](/slides/ko/php-java/script-specific-font-mappings/)를 참고하십시오.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/php-java/powerpoint-fonts/)를 참조하십시오.
{{% /alert %}}

## **테마 복사 또는 적용**

아래 작업 흐름은 서로 다른 테마 관련 문제를 해결합니다.

### **외부 테마를 마스터에 종속된 슬라이드에 적용**

PowerPoint 테마 파일(`.thmx`)이 있고 특정 마스터에 종속된 모든 슬라이드의 스타일을 재설정하려면 [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/)을 사용하십시오. [Presentation::getMasters](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 컬렉션에서 마스터를 선택하고(이는 [MasterSlideCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslidecollection/)에 의해 표현됩니다), 메서드에 테마 파일 경로를 전달합니다.

메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
1. 외부 테마를 새 마스터에 적용합니다.
1. 이전에 선택한 마스터에 종속되어 있던 모든 슬라이드에 새 마스터를 할당합니다.
1. 새로 생성된 [MasterSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/)을 반환합니다.

다음 예제는 첫 번째 마스터에 종속된 슬라이드에 외부 테마를 적용하고 프레젠테이션을 저장합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

잘못되었거나 손상되었거나 지원되지 않는 테마는 [PptxReadException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxreadexception/)을 발생시킬 수 있습니다. 사용자 제공 경로를 검증하고 파일 시스템 접근 실패를 처리하며, 테마가 성공적으로 적용된 뒤에만 프레젠테이션을 저장하십시오.

선택한 마스터에 종속된 슬라이드만 재할당됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 글꼴, 채우기, 선, 배경 및 효과는 외부 테마에 따라 해결됩니다. 직접 할당된 색상, 글꼴, 채우기 및 기타 명시적 서식은 변경되지 않을 수 있습니다. 레이아웃 수준 및 슬라이드 수준 재정의는 새로운 마스터에서 상속된 값보다 우선할 수 있습니다.

테마는 런타임 환경에 없는 글꼴을 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 글꼴을 설치하거나 [custom font sources](/slides/ko/php-java/custom-font/)를 통해 제공하거나 [font substitution](/slides/ko/php-java/font-substitution/)을 구성하십시오.

이 방법은 파일 경로만 받아서 `.thmx` 파일을 적용하므로 슬라이드 수준 또는 레이아웃 수준 테마 재정의를 수동으로 만들 필요가 없습니다.

### **다중 마스터 프레젠테이션에서 서로 다른 외부 테마 적용**

적용할 마스터를 미리 알 수 없는 경우 [Slide::getLayoutSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/)와 [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/)를 통해 대표 슬라이드에서 마스터를 가져옵니다. 테마를 적용하기 전에 원본 마스터 참조를 저장하십시오. 각 호출은 프레젠테이션에 새 마스터를 생성합니다.

다음 예제는 두 섹션의 슬라이드를 사용해 각각의 마스터를 찾고, 각 그룹에 다른 외부 테마를 적용합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

첫 번째 호출은 `$firstGroupMaster`에 종속된 슬라이드에만 영향을 주고, 두 번째 호출은 `$secondGroupMaster`에 종속된 슬라이드에만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 재스타일링되지 않습니다.

### **슬라이드 이동 시 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하면서 원본 디자인을 보존하려면 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslidecollection/)으로 소스 마스터를 대상 프레젠테이션에 복제한 뒤, [SlideCollection.addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/)와 복제된 마스터를 사용해 슬라이드를 복제합니다. 이렇게 하면 마스터와 레이아웃, 연관된 테마가 함께 복사됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

대상 프레젠테이션에서 슬라이드가 동일한 모습을 유지해야 할 때 권장되는 작업 흐름입니다. 무관한 대상 마스터에만 내용을 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 하는 경우 소스 테마를 기반으로 슬라이드 수준 재정의를 초기화합니다. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ko/php-java/aspose.slides/overridetheme/) 메서드는 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

이 방법은 다른 슬라이드가 상속하는 테마에는 영향을 주지 않고 해당 슬라이드에만 테마를 변경합니다. 로컬 재정을 제거하고 상속값으로 돌아가려면 [OverrideTheme.clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/overridetheme/)를 호출하십시오.

### **레이아웃에 테마 재정의 적용**

레이아웃 수준 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 재정의가 있는 경우는 예외가 됩니다. 동일한 초기화 메서드를 [LayoutSlideThemeManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslidethememanager/)를 통해 사용할 수 있습니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터 또는 프레젠테이션 수준 테마를 사용하고, 특정 레이아웃군이 다른 스타일링이 필요할 때 레이아웃 재정을, 진정한 예외인 경우에만 슬라이드 재정을 사용하십시오. 과도한 슬라이드 수준 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만들 수 있습니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/formatscheme/)에 저장됩니다. PowerPoint UI에서는 실제 컬렉션에 저장된 채우기 정의 수보다 더 많은 배경 옵션을 표시할 수 있는데, 이는 UI가 테마 채우기에 테마 색상 및 기타 스타일 참조를 조합할 수 있기 때문입니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background.getStyleIndex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/background/)를 확인하십시오. `0` 인덱스는 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경‑스타일 참조를 의미합니다. 이는 PHP 컬렉션을 직접 인덱싱할 때 `get_Item(0)`이 첫 번째 저장된 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션에 동일한 배경 채우기 스타일 수가 있다고 가정하지 마십시오.

다음 예제는 사용 가능한 배경 채우기 개수를 보고하고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

보이는 결과는 마스터가 참조하는 테마 항목 및 레이아웃이나 슬라이드 수준의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하고 있다면 마스터 배경만 변경해도 해당 슬라이드가 바뀌지 않을 수 있습니다. 최종 배경을 알아야 할 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/background/)를 사용하십시오.

{{% alert color="warning" title="Warning" %}}
스타일 인덱스를 0부터 시작하는 컬렉션 인덱스로 오해하지 마십시오. 또한 한 파일에서 추출한 스타일 번호를 다른 파일에 그대로 사용한다고 가정해서는 안 됩니다. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/php-java/presentation-background/)를 참고하십시오.
{{% /alert %}}

## **테마 효과 업데이트**

테마 형식 구성표는 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/formatscheme/), [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ko/php-java/aspose.slides/formatscheme/)을 통해 각각 채우기, 선, 효과 스타일 컬렉션을 노출합니다. 일반적인 Office 테마는 미묘함, 보통, 강렬한 서식을 시각적으로 대응시키는 세 개의 주요 스타일 항목을 포함하는 경우가 많지만, 코드에서는 고정된 개수를 가정하지 말고 각 컬렉션을 검사하십시오.

![같은 도형에 적용된 미묘, 보통, 강렬한 테마 효과](presentation-design_10.png)

PHP에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0부터 시작합니다: `get_Item(0)`은 첫 번째 저장된 스타일, `get_Item(2)`는 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념으로, [ShapeStyle](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapestyle/)을 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주지만, 직접 서식이 적용된 도형은 변경되지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외곽 그림자를 활성화하고 결과를 저장합니다:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

해당 슬롯을 참조하는 도형에 대해 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 단단한 포레스트 그린이 되며, 세 번째 효과 스타일은 거리 10포인트의 외곽 그림자를 갖게 됩니다. 정확한 시각 결과는 각 도형이 어떤 스타일 슬롯을 참조하고 직접 서식이 테마를 덮어쓰는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **효과적인 단색 채우기가 테마 색상을 사용하는지 판단**

채우기는 객체에 직접 저장될 수도 있고, 단락, 레이아웃, 마스터, 테마 스타일 또는 다른 서식 수준에서 상속될 수도 있습니다. [FillFormat::getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)을 호출하면 해당 계층 구조가 불변의 효과적인 채우기 데이터로 해결됩니다. 먼저 `getFillType` 결과를 확인하십시오. `FillType::Solid`인 경우에만 단색 채우기 속성을 읽어야 합니다.

단색 채우기의 경우 `getSolidFillColor`는 상속, 테마 조회 및 색 변환이 적용된 후 최종 렌더링된 RGB 값을 반환합니다. `getSolidFillSchemeColor` 메서드는 해당 논리 [SchemeColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/schemecolor/) 슬롯(예: `Text1`, `Accent6`)을 반환합니다. `SchemeColor::NotDefined` 값은 효과적인 단색 채우기가 스킴 색상을 기반으로 하지 않음을 의미합니다. 테마 색상 또는 직접 RGB 색상 중 하나만 사용하는 워크플로에서는 이 값이 직접 RGB 채우기를 식별합니다.

지역 [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/colorformat/) 값만으로 채우기를 분류하지 마십시오. 예를 들어 텍스트 일부는 지역적으로 스킴 색상이 정의되지 않아 `NotDefined`가 될 수 있지만, 효과적인 채우기는 테마 색상을 상속받아 `Text1`이나 `Accent6`으로 해결될 수 있습니다. 반대로 `getSolidFillSchemeColor`는 어떤 논리 테마 슬롯이 최종 색상을 만든 것인지 알려 주지만, 그 슬롯이 객체, 단락, 레이아웃, 마스터 혹은 다른 수준에서 온 것인지는 알려 주지 않습니다.

다음 예제는 프레젠테이션을 로드하고, 도형 채우기와 텍스트 부분 채우기를 모두 감사하며, 각 최종 RGB 값과 연관된 스킴 색을 출력하고, 테마 색상 변화에 따라 업데이트되지 않을 단색 채우기를 표시합니다:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`NotDefined` 분기는 테마 색상 슬롯 변경에 반응하지 않을 단색 채우기의 감사 목록을 제공합니다. 새 브랜드 팔레트를 적용해야 할 때 해당 객체를 검토하십시오. 보고된 RGB 값은 현재 모습을 보여 주며, 스킴 값은 해당 모습이 테마와 연결되어 있는지 설명합니다.

효과적인 객체는 스냅샷입니다. 프레젠테이션 테마, 테마 재정의 또는 상속된 서식을 변경한 후에는 `getEffective`을 다시 호출하고 새로운 효과적인 채우기 데이터를 읽은 뒤 색상을 비교하거나 보고하십시오.

## **효과적인 테마 값 읽기**

원시 테마 객체는 특정 수준에 정의된 내용을 알려 주지만, 효과적인 값은 상속 및 로컬 재정의가 해결된 뒤 슬라이드나 도형이 실제로 사용하는 내용을 알려 줍니다. 슬라이드의 경우 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseoverridethememanager/)를 호출합니다. 배경의 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/background/)를, 채우기의 경우 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)을 사용하십시오.

다음 예제는 슬라이드에서 효과적인 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

렌더링 진단, 검증 및 비교를 위해 효과적인 데이터를 사용하십시오. [Presentation.getMasterTheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 재정의가 최종 모습을 변경했는지 놓칠 수 있습니다.

## **FAQ**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드에 영향을 줍니까?**

아니요. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/)는 선택한 마스터에 종속된 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에만 테마를 적용할 수 있습니까?**

예. 해당 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidethememanager/)를 사용하고 재정의 테마를 초기화하십시오. 변경은 해당 슬라이드에만 적용되며, 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 가장 안전하게 전달하는 방법은?**

슬라이드를 이동하면서 원본 모습을 보존하려면 소스 마스터를 대상에 복제하고, 해당 마스터와 함께 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslidecollection/) 및 [SlideCollection.addClone](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/)를 사용해 슬라이드를 복제하십시오. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후의 효과적인 값을 어떻게 확인할 수 있습니까?**

슬라이드 또는 레이아웃 테마의 경우 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseoverridethememanager/)를 사용하고, 형식 객체의 경우 [Background.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/background/) 및 [FillFormat.getEffective](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/)와 같은 해당 효과적인 데이터 메서드를 사용하십시오. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.