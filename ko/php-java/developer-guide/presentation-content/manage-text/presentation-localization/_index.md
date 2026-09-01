---
title: PHP에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/php-java/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 맞춤법 검사 억제
- 교정 언어
- 언어 ID
- 다국어 텍스트
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint 및 OpenDocument 프레젠테이션 텍스트의 교정 언어를 설정하고, 기본값 및 다국어 단락을 포함합니다."
---
## **개요**

Aspose.Slides for PHP via Java은 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있게 합니다. 교정 언어를 지정하려면 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setLanguageId)를 사용하고, 맞춤법 검사를 허용하거나 억제하려면 [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setSpellCheck)를 사용하며, 보다 넓은 무교정 상태를 제어하려면 [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setProofDisabled)를 사용하세요. 이러한 설정은 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 다른 교정 규칙을 포함할 수 있습니다.

이 문서에서는 특정 텍스트에 언어를 할당하는 방법, [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage)으로 새 텍스트의 기본 언어를 설정하는 방법, 다국어 단락을 만드는 방법, `SpellCheck`와 `ProofDisabled` 중 선택하는 방법, 그리고 [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)을 사용할 때 의도한 설정을 유지하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 응용 프로그램용 메타데이터를 저장하며, 텍스트를 번역하거나 사전 기반 맞춤법 검사를 수행하거나 맞춤법 오류 단어 목록을 반환하지 않습니다.

## **텍스트에 교정 언어 설정**

[Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)을 생성하거나 로드하고, [Portion::getPortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getPortionFormat)를 통해 필요한 텍스트 부분에 접근한 뒤 언어 식별자를 할당합니다. 다음 예제는 도형을 만들고, 영국 영어를 교정 언어로 설정한 뒤 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save)로 결과를 저장합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **새 텍스트에 대한 기본 언어 설정**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage)을 사용하여 Aspose.Slides가 새로 만든 텍스트에 할당하는 교정 언어를 지정합니다. 프레젠테이션의 대부분 또는 모든 새 텍스트가 동일한 언어를 사용할 때 유용합니다. 이미 명시적인 언어가 지정된 텍스트의 언어 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트가 독일어 교정 규칙을 사용하는 프레젠테이션을 생성합니다:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **하나의 단락에서 여러 언어 사용**

[Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)은 텍스트 부분의 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)을 만들고 `LanguageId`를 독립적으로 설정합니다.

다음 예제는 영어와 프랑스어 부분을 포함하는 하나의 단락을 생성합니다:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **개별 부분에 대한 맞춤법 검사 활성화 또는 억제**

[PortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portionformat/)은 [BasePortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/)에서 정의된 공통 텍스트 속성을 상속합니다. [Portion::getPortionFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getPortionFormat)을 통해 부분의 형식에 접근하고 [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setSpellCheck)를 사용하여 프레젠테이션 응용 프로그램이 해당 부분에 대해 맞춤법 검사를 수행할 수 있는지를 제어합니다. 기본값은 `false`이며, `true`는 맞춤법 검사를 허용하고 `false`는 억제합니다.

이 설정은 개별 텍스트 부분에 적용됩니다. 같은 단락의 서로 다른 부분은 서로 다른 값을 가질 수 있습니다. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setLanguageId)과 `setSpellCheck`는 보완적인 역할을 합니다: `setLanguageId`는 교정 언어를 지정하고, `setSpellCheck`는 해당 부분에 대해 맞춤법 검사가 허용되는지를 결정합니다.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setProofDisabled)도 교정을 제어하지만, 보다 넓은 "교정 안 함" 상태를 [NullableBool](https://reference.aspose.com/slides/ko/php-java/aspose.slides/nullablebool/)으로 나타냅니다. 맞춤법 검사 전용의 직접적인 Boolean 스위치가 필요할 경우 `setSpellCheck`를 사용하십시오. 프레젠테이션의 무교정 메타데이터와 그 `NotDefined` 상태를 보존하거나 명시적으로 제어해야 할 경우 `setProofDisabled`를 사용하십시오. 두 속성을 모두 설정하는 경우 값이 일관되게 유지하도록 하며, `setSpellCheck(true)`와 `setProofDisabled(NullableBool::True)`를 함께 사용하지 마십시오.

이 속성들은 PowerPoint 및 기타 프레젠테이션 응용 프로그램에서 사용되는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사전 기반 맞춤법 검사를 수행하거나 맞춤법 오류 단어 목록을 반환하는 데 사용하지 않습니다.

다음 전체 예제는 입력 프레젠테이션을 만들고, 로드한 뒤, 같은 단락의 두 부분에 서로 다른 맞춤법 검사 설정과 교정 언어를 할당하고, 결과를 저장한 후 다시 열어 저장된 값을 확인합니다:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)은 동일한 서식을 가진 인접한 부분을 결합합니다. `SpellCheck`만 다른 경우에는 이러한 부분이 분리된 상태를 유지하지 않으며, 결합된 후 결과 부분은 첫 번째 부분의 `SpellCheck` 값을 유지합니다. 부분마다 다른 맞춤법 검사 설정이 필요하면 해당 설정을 할당하기 전에 `joinPortionsWithSameFormatting`을 호출하거나, 결합 후 결과 부분 경계를 검사하고 설정을 다시 적용하십시오. `LanguageId` 값이 다른 부분은 교정 언어 서식이 다르기 때문에 별도로 유지됩니다.

## **FAQ**

**언어 ID가 텍스트를 번역합니까?**

아니요. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setLanguageId)은 맞춤법 및 문법 교정을 위한 메타데이터를 저장하며 텍스트 내용을 변경하지 않습니다. 텍스트는 별도로 번역한 뒤, 번역된 각 부분에 적절한 언어 식별자를 설정하십시오.

**교정 언어가 글꼴, 하이픈 삽입 또는 줄 바꿈을 제어합니까?**

아니요. 언어 식별자는 교정용입니다. 텍스트 렌더링 및 레이아웃은 주로 사용 가능한 [fonts](/slides/ko/php-java/powerpoint-fonts/), 문자 체계 및 텍스트 프레임 설정에 따라 달라집니다. 안정적인 렌더링을 위해 필요한 글꼴을 제공하고, [font substitution](/slides/ko/php-java/font-substitution/)을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/php-java/embedded-font/)를 포함하십시오.

**하나의 단락에서 여러 교정 언어를 사용할 수 있나요?**

예. 다국어 단락 예제와 같이 각 언어를 별도의 부분에 할당하면 됩니다.

**`setDefaultTextLanguage`와 `setLanguageId` 중 어느 것을 사용해야 하나요?**

새로 만든 텍스트에 대한 기본값을 원할 경우 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage)을 사용하십시오. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 여러 언어가 포함된 경우 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseportionformat/#setLanguageId)을 사용하십시오.