---
title: JavaScript에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/nodejs-java/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 맞춤법 검사 억제
- 교정 언어
- 언어 ID
- 다국어 텍스트
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 PowerPoint 및 OpenDocument 프레젠테이션 텍스트의 교정 언어를 설정하고, 기본값 및 다국어 단락을 포함합니다."
---
## **개요**

Aspose.Slides for Node.js via Java을 사용하면 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있습니다. 교정 언어를 지정하려면 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)을 사용하고, 맞춤법 검사를 허용하거나 억제하려면 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-)을 사용하며, 보다 광범위한 교정 비활성 상태를 제어하려면 [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-)을 사용합니다. 이러한 설정은 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 서로 다른 교정 규칙을 포함할 수 있습니다.

이 문서에서는 특정 텍스트에 언어를 할당하고, [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)으로 새 텍스트에 대한 기본 언어를 설정하며, 다국어 단락을 구성하고, `SpellCheck`와 `ProofDisabled` 중 하나를 선택하고, [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--)을 사용할 때 의도된 설정을 유지하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 응용 프로그램을 위한 메타데이터를 저장하며, 텍스트를 번역하거나 사전 기반 맞춤법 검사를 수행하거나 틀린 단어 목록을 반환하지 않습니다.

## **텍스트에 대한 교정 언어 설정**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)을 생성하거나 로드하고, [Portion.getPortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#getPortionFormat--)을 통해 필요한 텍스트 부분에 접근한 후 해당 언어 식별자를 할당합니다. 다음 예제는 도형을 생성하고, 영국식 영어를 교정 언어로 설정한 뒤, [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-)으로 결과를 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **새 텍스트에 대한 기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)을 사용하여 Aspose.Slides가 새로 생성된 텍스트에 할당할 교정 언어를 지정합니다. 이 설정은 프레젠테이션에서 대부분 또는 모든 새 텍스트가 동일한 언어를 사용할 때 유용합니다. 이미 명시적인 언어가 지정된 텍스트의 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트에 독일어 교정 규칙을 적용하는 프레젠테이션을 생성합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **한 단락에서 여러 언어 사용**

[Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/)은 텍스트 부분 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)을 생성하고 `LanguageId`를 독립적으로 설정합니다.

다음 예제는 영어와 프랑스어 부분을 포함하는 하나의 단락을 생성합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **개별 부분에 대한 맞춤법 검사 활성화 또는 억제**

[PortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/)은 [BasePortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/)이 정의한 공통 텍스트 속성을 상속합니다. [Portion.getPortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/#getPortionFormat--)을 통해 부분의 형식에 접근하고, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-)을 사용하여 해당 부분에 대해 프레젠테이션 응용 프로그램이 맞춤법 검사를 수행할지 여부를 제어합니다. 기본값은 `false`이며, `true`는 맞춤법 검사를 허용하고 `false`는 억제합니다.

이 설정은 개별 텍스트 부분에 적용됩니다. 동일한 단락의 서로 다른 부분은 서로 다른 값을 가질 수 있습니다. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)와 `setSpellCheck`는 보완적인 역할을 합니다: `setLanguageId`는 교정 언어를 지정하고, `setSpellCheck`는 해당 부분에 대해 맞춤법 검사가 허용되는지를 결정합니다.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-)도 교정을 제어하지만, 이는 [NullableBool](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/nullablebool/) 형태의 보다 넓은 “교정하지 않음” 상태를 나타냅니다. 맞춤법 검사를 위한 직접적인 Boolean 스위치가 필요하면 `setSpellCheck`를 사용하고, 프레젠테이션의 교정 비활성 메타데이터(예: `NotDefined` 상태)를 유지하거나 명시적으로 제어해야 할 경우 `setProofDisabled`를 사용하십시오. 두 속성을 모두 설정하는 경우 값이 일치하도록 유지하고, `setSpellCheck(true)`와 `setProofDisabled(NullableBool.True)`를 같이 사용하지 마세요.

이러한 속성은 PowerPoint 및 기타 프레젠테이션 응용 프로그램에서 사용되는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사용해 사전 기반 맞춤법 검사를 수행하거나 틀린 단어 목록을 반환하지 않습니다.

다음 전체 예제는 입력 프레젠테이션을 만들고, 로드하고, 동일한 단락의 두 부분에 서로 다른 맞춤법 검사 설정과 교정 언어를 할당한 뒤, 결과를 저장하고 다시 열어 저장된 값을 검증합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--)은 동일한 형식을 가진 인접한 부분을 결합합니다. `SpellCheck` 값만 다르면 이러한 부분이 별도로 유지되지 않으며, 결합된 후 결과 부분은 첫 번째 부분의 `SpellCheck` 값을 유지합니다. 부분에 서로 다른 맞춤법 검사 설정이 필요하면 해당 설정을 할당하기 전에 `joinPortionsWithSameFormatting`을 호출하거나, 결합 후 결과 부분 경계를 검사하고 설정을 다시 적용하십시오. `LanguageId` 값이 다른 부분은 교정 언어 형식이 다르기 때문에 별도로 유지됩니다.

## **FAQ**

**언어 ID가 텍스트를 번역합니까?**

아니요. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)은 맞춤법 및 문법 교정을 위한 메타데이터를 저장할 뿐이며, 텍스트 내용 자체를 변경하지 않습니다. 텍스트는 별도로 번역한 뒤 각 번역된 부분에 적절한 언어 식별자를 설정하십시오.

**교정 언어가 폰트, 하이픈 삽입 또는 줄 바꿈을 제어합니까?**

아니요. 언어 식별자는 교정 용도이며, 텍스트 렌더링 및 레이아웃은 주로 사용 가능한 [fonts](/slides/ko/nodejs-java/powerpoint-fonts/), 글쓰기 시스템 및 텍스트 프레임 설정에 따라 결정됩니다. 신뢰할 수 있는 렌더링을 위해 필요한 폰트를 제공하고, [font substitution](/slides/ko/nodejs-java/font-substitution/)을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/nodejs-java/embedded-font/)를 포함하세요.

**한 단락에 여러 교정 언어를 사용할 수 있습니까?**

예. 다국어 단락 예제에 표시된 대로 각 언어를 별도의 부분에 할당하면 됩니다.

**`setDefaultTextLanguage`와 `setLanguageId` 중 어느 것을 사용해야 합니까?**

새로 생성되는 텍스트에 대해 기본값을 설정하려면 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)를 사용하십시오. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 여러 언어가 포함된 경우에는 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)를 사용하십시오.