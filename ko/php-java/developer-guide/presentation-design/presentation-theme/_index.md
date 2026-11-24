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
description: "Java를 통한 Aspose.Slides for PHP에서 마스터 프레젠테이션 테마를 사용하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 사용자 정의하고, 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 모든 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마 변경으로 여러 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서는 프레젠테이션 수준 테마를 [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 통해 사용할 수 있습니다. 프레젠테이션은 하위 수준에서도 테마 재정의를 포함할 수 있습니다. 마스터는 [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/)을 통해 프레젠테이션 테마를 재정의할 수 있으며, 레이아웃이나 개별 슬라이드는 [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/)을 통해 상속된 테마를 재정의할 수 있습니다. 실제로 슬라이드에 적용되는 유효 테마는 다음과 같은 상속 체인을 통해 해결됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 글꼴 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 재정의가 해결된 후 유효 값을 읽는 방법.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) 객체는 [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)을 통해 테마의 색 구성표, 글꼴 구성표 및 형식 구성표를 노출합니다. 변경하기 전에 이러한 컬렉션을 검사하는 것은 프레젠테이션이 외부 소스에서 온 경우 특히 유용합니다. 스타일 항목의 수와 내용이 다양할 수 있기 때문입니다.

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

파일에 여러 마스터가 사용된 경우 모든 슬라이드가 동일한 유효 테마를 가지고 있다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃이나 슬라이드 재정의가 존재할 수 있을 때 아래에 설명된 유효 테마 작업 흐름을 사용하세요.

## **테마 색상 변경**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/)에서 해당 항목을 변경하면 해당 테마 색상을 여전히 참조하는 모든 객체가 새 값으로 해석됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 종단-종단 예제는 `Accent4`를 사용하는 도형을 만들고, 테마의 `Accent4` 색상을 빨간색으로 변경한 뒤 프레젠테이션을 저장하고 다시 열어 유효 채우기 색상을 출력합니다:

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

사각형이 `Accent4`에 계속 연결되어 있기 때문에 테마가 변경된 후 보이는 색상이 빨간색으로 바뀝니다. 도형에 직접 색을 지정하면 이후 `Accent4` 변경이 해당 채우기에 영향을 주지 않습니다.

### **추가 팔레트의 색상 사용**

PowerPoint는 테마 색상에 색 변환을 적용하여 더 밝고 어두운 변형을 파생합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) 열거형을 통해 노출합니다.

![주 테마 색상과 추가 팔레트에서 생성된 밝고 어두운 색상](additional-palette-colors.png)

**1** - 주 테마 색상.

**2** - 주 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기준으로 여섯 개의 사각형을 만들고, 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

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

이 변형은 테마 색상을 기반으로 유지됩니다. `Accent4`가 나중에 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `ColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이는 동일한 테마 슬롯에 대한 다른 이름일 뿐이며, 동적으로 한 형태에서 다른 형태로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 구성표는 제목용 주요 글꼴 세트와 본문용 보조 글꼴 세트를 포함합니다. [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) 및 [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) 메서드가 이 세트를 노출합니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에서 사용할 수 있습니다:

* `+mn-lt` - 본문 라틴 글꼴 (Minor Latin Font)
* `+mj-lt` - 제목 라틴 글꼴 (Major Latin Font)
* `+mn-ea` - 본문 동아시아 글꼴 (Minor East Asian Font)
* `+mj-ea` - 제목 동아시아 글꼴 (Major East Asian Font)
* `+mn-cs` - 본문 복합 스크립트 글꼴 (Minor Complex Script Font)
* `+mj-cs` - 제목 복합 스크립트 글꼴 (Major Complex Script Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 제목 하나와 보조 라틴 테마 글꼴을 사용하는 본문 줄 하나를 만든 뒤, 테마 글꼴을 변경하고 결과를 저장합니다:

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

제목은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 명시적인 글꼴 이름이 테마 식별자가 아닌 경우 테마 글꼴 구성표가 변경되어도 자동으로 전환되지 않습니다.

주요 및 보조 글꼴 컬렉션에는 키릴 문자, 아랍어, 일본어, 조지아어, 타나와 같은 개별 작문 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script-Specific Theme Fonts](/slides/ko/php-java/script-specific-font-mappings/)를 참조하세요.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/php-java/powerpoint-fonts/)를 참조하세요.
{{% /alert %}}

### **테마 글꼴 참조 해결**

텍스트를 검사할 때 [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/)는 글꼴 패밀리 이름 대신 `+mn-lt`와 같은 테마 참조를 반환할 수 있습니다. 적절한 유효 테마 데이터를 사용하여 해당 참조를 해결하려면 [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/)를 호출하세요. `+mj`와 `+mn` 접두사는 주요 및 보조 글꼴 세트를 선택하고, `-lt`, `-ea`, `-cs` 접미사는 각각 라틴, 동아시아, 복합 스크립트 글꼴을 선택합니다.

테마가 적용되는 객체에 대해 [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)를 호출하여 유효 테마를 얻습니다. 일반 텍스트가 슬라이드에 있는 경우 해당 슬라이드에 메서드를 호출하여 슬라이드의 상속된 테마와 로컬 재정의를 포함하도록 컨텍스트를 설정합니다. 레이아웃이나 마스터 자체를 검사할 때는 해당 객체의 유효 테마를 사용하세요. 첫 번째 마스터의 테마가 모든 슬라이드에 적용된다고 가정하지 마세요.

다음 예제는 보조 라틴 글꼴을 명시적으로 참조하는 텍스트 구역을 만들고, [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)를 통해 슬라이드 글꼴 구성표를 초기화한 뒤 주요 및 보조 라틴 패밀리를 `Arial`과 `Calibri`로 설정합니다. 이렇게 하면 입력 파일 없이도 결과를 재현할 수 있습니다.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

출력은 `+mn-lt -> Calibri` 뒤에 `Verdana -> Verdana`가 표시됩니다. 저장된 참조는 그대로 유지되며, 명시적인 패밀리 이름은 그대로 반환됩니다. 만약 구역이 `+mj-lt`를 사용했다면 이 테마에서는 `Arial`로 해결됩니다.

테마 참조를 해결하면 테마에 의해 지정된 글꼴 패밀리를 식별합니다. 이는 글꼴 가용성을 확인하거나 렌더링 중 대체 또는 글리프 폴백 후 실제 사용되는 글꼴 파일을 결정하지 않습니다. 해당 별도 단계에 대해서는 [Font Selection Sequence](/slides/ko/php-java/font-selection-sequence/)와 [Font Substitution](/slides/ko/php-java/font-substitution/)을 참고하세요.

## **테마 복사 또는 적용**

아래 작업 흐름은 서로 다른 테마 관련 문제를 해결합니다.

### **외부 테마를 마스터에 의존하는 슬라이드에 적용**

PowerPoint 테마 파일(`.thmx`)이 있고 특정 마스터에 의존하는 모든 슬라이드의 스타일을 다시 지정하려면 [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)를 사용하세요. [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 컬렉션에서 마스터를 선택하고, 이는 [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/)으로 표현되며, 메서드에 테마 파일 경로를 전달합니다.

이 메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
1. 새 마스터에 외부 테마를 적용합니다.
1. 이전에 선택한 마스터에 의존하던 모든 슬라이드에 새 마스터를 할당합니다.
1. 새로 생성된 [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)을 반환합니다.

다음 예제는 첫 번째 마스터에 의존하는 슬라이드에 외부 테마를 적용하고 프레젠테이션을 저장합니다:

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

잘못되었거나 손상되었거나 지원되지 않는 테마는 [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/)을 발생시킬 수 있습니다. 사용자가 제공한 경로를 검증하고 파일 시스템 접근 오류를 처리하며, 테마가 성공적으로 적용된 후에만 프레젠테이션을 저장하세요.

선택한 마스터에 의존했던 슬라이드만 재할당됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 글꼴, 채우기, 선, 배경 및 효과는 외부 테마에 따라 해석됩니다. 직접 지정된 색상, 글꼴, 채우기 및 기타 명시적 서식은 변경되지 않을 수 있습니다. 레이아웃 수준 및 슬라이드 수준 재정의도 새 마스터에서 상속된 값보다 우선할 수 있습니다.

테마는 실행 환경에 없는 글꼴을 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 글꼴을 설치하거나 [custom font sources](/slides/ko/php-java/custom-font/)를 통해 제공하거나 [font substitution](/slides/ko/php-java/font-substitution/)을 구성하세요.

이 방법은 파일 경로만 요구하는 직접적인 마스터 수준 워크플로이며, 슬라이드 수준이나 레이아웃 수준 테마 재정의를 수동으로 만들 필요가 없습니다.

### **다중 마스터 프레젠테이션에서 서로 다른 외부 테마 적용**

관련 마스터를 사전에 알 수 없는 경우 [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)와 [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)를 통해 대표 슬라이드에서 마스터를 가져옵니다. 테마를 적용하기 전에 원본 마스터 참조를 저장하세요. 각 호출은 프레젠테이션에 새 마스터를 추가합니다.

다음 예제는 두 개 섹션의 슬라이드를 사용해 각각의 마스터를 찾고, 각 그룹에 서로 다른 외부 테마를 적용합니다:

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

첫 번째 호출은 `$firstGroupMaster`에 의존하는 슬라이드에만 영향을 주고, 두 번째 호출은 `$secondGroupMaster`에 의존하는 슬라이드에만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 스타일이 변경되지 않습니다.

### **슬라이드 이동 시 원본 테마 유지**

슬라이드를 다른 프레젠테이션으로 이동하면서 원본 디자인을 유지하려면 [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/)를 사용해 원본 마스터를 대상 프레젠테이션에 복제한 뒤, [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)와 복제된 마스터로 슬라이드를 복제합니다. 이렇게 하면 마스터, 레이아웃 및 연관된 테마가 함께 복사됩니다.

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

목적지 프레젠테이션에서 원본 슬라이드가 동일하게 보이도록 하는 권장 워크플로입니다. 무관한 대상 마스터에만 콘텐츠를 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 할 경우, 소스 테마에서 슬라이드 수준 재정의를 초기화합니다. [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) 메서드가 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

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

이렇게 하면 다른 슬라이드가 상속한 테마는 유지하면서 해당 슬라이드에만 새로운 테마가 적용됩니다. 로컬 재정을 제거하고 상속 값을 복원하려면 [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)를 호출하세요.

### **레이아웃에 테마 재정의 적용**

레이아웃 수준 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 자체 재정의가 있으면 그 슬라이드가 우선합니다. 동일한 초기화 메서드는 [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/)를 통해 사용할 수 있습니다:

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

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터 또는 프레젠테이션 수준 테마를 사용하고, 하나의 레이아웃 패밀리만 다른 스타일이 필요할 때는 레이아웃 재정의를, 진정한 예외에만 슬라이드 재정을 사용하세요. 과도한 슬라이드 수준 재정의는 이후 전역 테마 변경을 예측하기 어렵게 만듭니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)에 저장됩니다. PowerPoint UI는 실제 컬렉션에 저장된 채우기 정의보다 더 많은 배경 선택지를 제공할 수 있습니다. UI는 테마 채우기와 테마 색상 및 기타 스타일 참조를 조합할 수 있기 때문입니다.

![프레젠테이션 테마의 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/)를 검사하세요. `0` 인덱스는 테마 채우기가 없음을 의미하고, 양수 값은 테마 배경 스타일 참조입니다. 이는 PHP 컬렉션을 직접 인덱싱할 때 `get_Item(0)`이 첫 번째 저장 항목을 의미하는 것과 다릅니다. 모든 프레젠테이션에 동일한 배경 채우기 스타일 수가 있다고 가정하지 마세요.

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

보이는 결과는 마스터가 참조하는 테마 항목과 레이아웃 또는 슬라이드 수준에서의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용한다면 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 최종 배경을 확인하려면 [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)를 사용하세요.

{{% alert color="warning" title="Warning" %}}
스타일 인덱스를 0 기반 컬렉션 인덱스로 취급하지 마세요. 또한 한 파일에서 사용한 스타일 번호를 다른 파일에 그대로 적용한다고 가정하지 마세요. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접적인 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/php-java/presentation-background/)를 참고하세요.
{{% /alert %}}

## **테마 효과 업데이트**

테마 형식 구성표는 [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)를 통해 각각 채우기, 선, 효과 스타일 컬렉션을 노출합니다. 일반적인 Office 테마는 미묘함, 보통, 강렬한 세 가지 주요 스타일 항목을 포함하지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![같은 도형에 적용된 미묘함, 보통, 강렬함 테마 효과](presentation-design_10.png)

PHP에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0 기반입니다: `get_Item(0)`은 첫 번째 저장 스타일, `get_Item(2)`는 세 번째 스타일을 의미합니다. 도형의 스타일 참조 인덱스는 별도 개념으로, [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/)을 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주며, 직접 서식이 적용된 도형은 변경되지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하고, 세 번째 효과 스타일에 외부 그림자를 적용한 뒤 결과를 저장합니다:

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

해당 슬롯을 참조하는 도형에 대해 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 단단한 숲 초록색이 되며, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 갖게 됩니다. 정확한 시각적 결과는 각 도형이 어떤 스타일 슬롯을 참조하는지와 직접 서식이 테마를 재정의하는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정 변경 후 테마 효과 스타일](presentation-design_11.png)

## **도형에 대한 테마 채우기 및 선 스타일 선택**

도형은 [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex)와 [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex)를 사용해 채우기와 외곽선을 독립적으로 선택할 수 있습니다. 두 메서드 모두 인덱스 `1`은 해당 테마 컬렉션의 첫 번째 항목(`get_Item(0)`)을, 인덱스 `2`는 두 번째 항목(`get_Item(1)`)을 선택합니다.

다음 예제는 새 프레젠테이션의 기본 테마에 금색 및 하늘색 채우기와 두 개의 선 스타일(6pt 짙은 파란색, 12pt 짙은 빨간색)을 설정하고, 세 단계에 걸쳐 슬라이드를 저장해 PowerPoint에서 결과를 비교할 수 있게 합니다:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 초기 스타일 | 오른쪽 외곽선 변경 | 첫 번째 테마 채우기 편집 |
|:---:|:---:|:---:|
| ![금색 및 하늘색 사각형, 얇은 짙은 파란색 외곽선과 일치](theme-style-initial.png) | ![하늘색 사각형이 이제 두꺼운 짙은 빨간색 외곽선을 가짐](theme-style-line-changed.png) | ![왼쪽 사각형이 이제 초록색이며 두 외곽선은 변경되지 않음](theme-style-fill-changed.png) |

다른 선 스타일을 선택하면 오른쪽 사각형의 외곽선만 변경됩니다. 첫 번째 테마 채우기를 편집하면 해당 채우기를 사용하는 모든 도형이 업데이트됩니다. 여기서는 왼쪽 사각형만 초록색으로 바뀝니다.

기존 도형에 로컬 채우기 색, 선 색 또는 선 너비가 설정되어 있으면 해당 테마 스타일 부분을 재정의할 수 있습니다. 스타일 인덱스 변경이 보이지 않을 경우 도형의 [direct formatting](/slides/ko/php-java/shape-formatting/)을 확인하세요.

## **유효한 단색 채우기가 테마 색상을 사용하는지 확인**

채우기는 객체에 직접 저장되거나 단락, 레이아웃, 마스터, 테마 스타일 또는 다른 서식 수준에서 상속될 수 있습니다. [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)를 호출해 해당 계층을 불변의 유효 채우기 데이터로 해결하세요. 먼저 `getFillType` 결과를 확인합니다. `FillType::Solid`인 경우에만 단색 채우기 속성을 읽어야 합니다.

단색 채우기의 경우 `getSolidFillColor`는 상속, 테마 조회 및 색 변환이 적용된 후 최종 렌더링된 RGB 값을 반환합니다. `getSolidFillSchemeColor` 메서드는 해당 논리적 [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 슬롯(`Text1` 또는 `Accent6` 등)을 반환합니다. `SchemeColor::NotDefined`는 유효 단색 채우기가 스킴 색상을 기반으로 하지 않음을 의미합니다. 채우기가 테마 색상인지 직접 RGB 색상인지 구분하려면 이 값을 사용하세요.

지역 [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) 값만으로 채우기를 분류하지 마세요. 예를 들어 텍스트 구역에 로컬 스킴 색상이 정의되지 않아 `NotDefined`일 수 있지만, 유효 채우기는 테마 색상을 상속받아 `Text1`이나 `Accent6`으로 해결될 수 있습니다. 반대로 `getSolidFillSchemeColor`는 어떤 논리적 테마 슬롯이 최종 색상을 만들었는지 알려주지만, 해당 슬롯이 객체, 단락, 레이아웃, 마스터 또는 다른 수준에서 왔는지는 알려주지 않습니다.

다음 예제는 프레젠테이션을 로드하고, 도형 채우기와 텍스트 구역 채우기를 모두 감사하여 각 최종 RGB 값과 연관된 스킴 색상을 출력하고, 테마 색상 변경에 따라 변하지 않을 단색 채우기를 표시합니다:

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

`NotDefined` 분기는 테마 색상 슬롯이 변경되어도 반응하지 않는 단색 채우기 목록을 제공합니다. 새 브랜드 팔레트를 적용해야 할 때 이러한 객체를 검토하세요. 보고된 RGB 값은 현재 모습을 보여주며, 스킴 값은 해당 모습이 테마와 연결되어 있는지를 설명합니다.

유효 형식 객체는 스냅샷입니다. 프레젠테이션 테마, 테마 재정의 또는 상속된 서식을 변경한 후에는 `getEffective`를 다시 호출하고 새 유효 채우기 데이터를 읽은 뒤 색상을 비교하거나 보고하세요.

## **유효 테마 값 읽기**

원시 테마 객체는 특정 레벨에 정의된 내용을 알려줍니다. 유효 값은 상속 및 로컬 재정의가 해결된 후 슬라이드或 도형이 실제로 사용하는 내용을 알려줍니다. 슬라이드의 경우 [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/)를 호출합니다. 배경은 [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)을, 채우기는 [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)을 사용합니다.

다음 예제는 슬라이드에서 유효 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

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

렌더링 진단, 검증 및 비교를 위해 유효 데이터를 사용하세요. [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 재정의가 최종 모습을 바꾼 경우를 놓칠 수 있습니다.

## **FAQ**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드가 영향을 받나요?**

아니요. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)은 선택된 마스터에 의존하는 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에만 테마를 적용할 수 있나요?**

예. 슬라이드의 [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/)를 사용하고 재정의 테마를 초기화하면 됩니다. 변경은 해당 슬라이드에만 적용되며, 다른 슬라이드는 기존 테마를 계속 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 전달하는 가장 안전한 방법은?**

슬라이드를 이동하고 원본 모습을 보존하려면 [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/)와 [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)을 사용해 소스 마스터와 해당 마스터를 가진 슬라이드를 대상에 복제하세요. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 유효 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해 [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/)를 사용하고, 포맷 객체에 대해서는 해당 유효 데이터 메서드([Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/))를 사용하세요. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.