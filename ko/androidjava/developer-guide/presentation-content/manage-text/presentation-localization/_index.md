---
title: Android에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/androidjava/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 맞춤법 검사 억제
- 교정 언어
- 언어 ID
- 다국어 텍스트
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android용 Aspose.Slides for Android via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션 텍스트의 교정 언어를 설정합니다. 기본값 및 다국어 단락을 포함합니다."
---
## **개요**

Aspose.Slides for Android via Java을 사용하면 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있습니다. 교정 언어를 지정하려면 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)를 사용하고, 철자 검사를 허용하거나 억제하려면 [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-)를 사용하며, 더 넓은 “교정 안 함” 상태를 제어하려면 [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-)를 사용합니다. 이러한 설정이 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 서로 다른 교정 규칙을 포함시킬 수 있습니다.

이 문서에서는 특정 텍스트에 언어를 할당하고, [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)으로 새 텍스트의 기본 언어를 설정하며, 다국어 단락을 구성하고, `SpellCheck`와 `ProofDisabled` 중 하나를 선택하고, [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--)을 사용할 때 의도한 설정을 유지하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 애플리케이션을 위한 메타데이터를 저장할 뿐이며, 텍스트를 번역하거나 사전 기반 철자 검사를 수행하거나 맞춤법 오류 단어를 반환하지 않습니다.

## **텍스트에 교정 언어 설정**

[Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/)을 만들거나 로드하고, [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getPortionFormat--)을 통해 필요한 텍스트 부분에 접근한 뒤 언어 식별자를 할당합니다. 아래 예제는 도형을 만들고, 영국식 영어를 교정 언어로 설정한 뒤, [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)으로 결과를 저장합니다.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **새 텍스트의 기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)을 사용하여 Aspose.Slides가 새로 생성된 텍스트에 할당하는 교정 언어를 지정합니다. 이 설정은 프레젠테이션의 대부분 또는 전체 새 텍스트가 동일한 언어를 사용할 때 유용합니다. 이미 명시적인 언어가 지정된 텍스트의 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트에 독일어 교정 규칙을 적용하는 프레젠테이션을 생성합니다.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **한 단락에 여러 언어 사용**

[IParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/)은 텍스트 부분 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/)을 생성하고 `LanguageId`를 독립적으로 설정합니다.

다음 예제는 영어와 프랑스어 부분을 포함하는 하나의 단락을 만듭니다.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **개별 부분에 대한 철자 검사 활성화 또는 억제**

[IPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportionformat/)은 [IBasePortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/)이 정의한 일반 텍스트 속성을 상속합니다. [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getPortionFormat--)을 통해 부분의 형식에 접근하고, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-)을 사용하여 프레젠테이션 애플리케이션이 해당 부분의 철자를 검사하도록 제어합니다. 기본값은 `false`이며, `true`는 철자 검사를 허용하고 `false`는 억제합니다.

이 설정은 개별 텍스트 부분에 적용됩니다. 동일한 단락 내의 다른 부분은 서로 다른 값을 사용할 수 있습니다. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)와 `setSpellCheck`는 보완적인 역할을 합니다. `setLanguageId`는 교정 언어를 지정하고, `setSpellCheck`는 해당 부분에 대해 철자 검사가 허용되는지를 결정합니다.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) 또한 교정을 제어하지만, 이는 [NullableBool](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/nullablebool/)으로 표현되는 보다 광범위한 “교정 안 함” 상태를 나타냅니다. 철자 검사만을 위한 직접적인 Boolean 스위치가 필요할 때는 `setSpellCheck`를 사용하고, 프레젠테이션의 교정 메타데이터(특히 `NotDefined` 상태)를 보존하거나 명시적으로 제어해야 할 경우에는 `setProofDisabled`를 사용하십시오. 두 속성을 모두 설정하는 경우 값이 일관되도록 유지하고, `setSpellCheck(true)`와 `setProofDisabled(NullableBool.True)`를 결합하지 마세요.

이 속성들은 PowerPoint 및 기타 프레젠테이션 애플리케이션에서 사용되는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사용해 사전 기반 철자 검사를 수행하거나 맞춤법 오류 목록을 반환하지 않습니다.

다음 완전한 예제는 입력 프레젠테이션을 생성하고, 로드한 뒤, 동일한 단락 내 두 부분에 서로 다른 철자 검사 설정과 교정 언어를 할당하고, 결과를 저장한 후 다시 열어 저장된 값을 검증합니다.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--)은 동일한 형식을 가진 인접한 부분을 결합합니다. `SpellCheck`만 다른 경우에는 이러한 부분이 별도로 유지되지 않으며, 결합된 후 결과 부분은 첫 번째 부분의 `SpellCheck` 값을 유지합니다. 부분마다 다른 철자 검사 설정이 필요하면 해당 설정을 할당하기 전에 `joinPortionsWithSameFormatting`을 호출하거나, 결합 후 결과 부분 경계를 검사하고 설정을 다시 적용하십시오. `LanguageId` 값이 다른 부분은 교정 언어 형식이 다르기 때문에 별도로 유지됩니다.

## **FAQ**

**언어 ID가 텍스트를 번역합니까?**

아니요. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)는 철자 및 문법 교정을 위한 메타데이터를 저장할 뿐 텍스트 내용 자체를 변경하지 않습니다. 텍스트는 별도로 번역한 후, 각 번역된 부분에 적절한 언어 식별자를 설정하십시오.

**교정 언어가 글꼴, 자동 hyphenation, 줄 바꿈을 제어합니까?**

아니요. 언어 식별자는 교정을 위한 것이며, 텍스트 렌더링 및 레이아웃은 사용 가능한 [fonts](/slides/ko/androidjava/powerpoint-fonts/), 쓰기 체계 및 텍스트 프레임 설정에 따라 결정됩니다. 안정적인 렌더링을 위해 필요한 글꼴을 제공하고, [font substitution](/slides/ko/androidjava/font-substitution/)을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/androidjava/embedded-font/)를 포함하십시오.

**한 단락에 여러 교정 언어를 사용할 수 있습니까?**

예, 가능합니다. 다국어 단락 예제와 같이 각 언어를 별도의 부분에 할당하면 됩니다.

**`setDefaultTextLanguage`와 `setLanguageId` 중 어느 것을 사용해야 합니까?**

새로 생성된 텍스트에 대한 기본값이 필요하면 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)를 사용하십시오. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 여러 언어가 포함된 경우에는 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)를 사용하십시오.