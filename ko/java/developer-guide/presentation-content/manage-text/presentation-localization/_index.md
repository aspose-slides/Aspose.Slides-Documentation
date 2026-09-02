---
title: Java에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/java/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 맞춤법 검사 억제
- 교정 언어
- 언어 ID
- 다국어 텍스트
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 및 OpenDocument 프레젠테이션 텍스트의 교정 언어를 설정하고, 기본값 및 다국어 단락을 포함합니다."
---
## **개요**

Aspose.Slides for Java를 사용하면 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있습니다. 교정 언어를 지정하려면 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)를, 맞춤법 검사를 허용하거나 억제하려면 [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-)를, 보다 광범위한 교정 비활성 상태를 제어하려면 [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-)를 사용합니다. 이러한 설정은 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 서로 다른 교정 규칙을 포함시킬 수 있습니다.

이 문서에서는 특정 텍스트에 언어를 할당하고, 새 텍스트에 대한 기본 언어를 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)으로 설정하며, 다국어 단락을 작성하고, `SpellCheck`와 `ProofDisabled` 중 하나를 선택하고, [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--)을 사용할 때 의도한 설정을 유지하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 애플리케이션을 위한 메타데이터를 저장할 뿐이며, 텍스트를 번역하거나 사전 기반 맞춤법 검사를 수행하거나 맞춤법 오류를 반환하지 않습니다.

## **텍스트에 대한 교정 언어 설정**

[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)을 새로 만들거나 로드하고, [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#getPortionFormat--)을 통해 필요한 텍스트 부분에 접근한 다음 언어 식별자를 할당합니다. 다음 예제는 도형을 만들고, 영국식 영어를 교정 언어로 설정한 뒤, [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-)으로 결과를 저장합니다:

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

## **새 텍스트에 대한 기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)을 사용하면 Aspose.Slides가 새로 만든 텍스트에 자동으로 할당하는 교정 언어를 지정할 수 있습니다. 이 설정은 프레젠테이션의 대부분 또는 전체 새 텍스트가 동일한 언어를 사용할 때 유용합니다. 이미 명시적인 언어가 지정된 텍스트의 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트가 독일어 교정 규칙을 사용하도록 프레젠테이션을 생성합니다:

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

## **하나의 단락에서 여러 언어 사용**

[IParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/)은 텍스트 부분 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/portion/)을 만들고 `LanguageId`를 독립적으로 설정합니다.

다음 예제는 영어와 프랑스어 부분을 포함하는 하나의 단락을 생성합니다:

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

## **개별 부분에 대한 맞춤법 검사 활성화 또는 억제**

[IPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportionformat/)은 [IBasePortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/)이 정의한 공통 텍스트 속성을 상속합니다. [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/#getPortionFormat--)을 통해 부분의 형식을 가져오고, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-)을 사용하여 프레젠테이션 애플리케이션이 해당 부분에 대해 맞춤법 검사를 수행할지 여부를 제어합니다. 기본값은 `false`이며, `true`는 맞춤법 검사를 허용하고 `false`는 억제합니다.

이 설정은 개별 텍스트 부분에 적용됩니다. 동일한 단락 내의 서로 다른 부분은 서로 다른 값을 가질 수 있습니다. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)와 `setSpellCheck`는 보완적인 역할을 합니다. `setLanguageId`는 교정 언어를 지정하고, `setSpellCheck`는 해당 부분에 맞춤법 검사가 허용되는지를 결정합니다.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-)도 교정을 제어하지만, 이는 [NullableBool](https://reference.aspose.com/slides/ko/java/com.aspose.slides/nullablebool/)으로 표현되는 보다 포괄적인 “교정 안 함” 상태를 나타냅니다. 맞춤법 검사에만 직접적인 Boolean 스위치가 필요할 경우 `setSpellCheck`를 사용하고, 프레젠테이션의 교정 비활성 메타데이터(예: `NotDefined` 상태)를 유지하거나 명시적으로 제어해야 할 경우 `setProofDisabled`를 사용하십시오. 두 속성을 모두 설정하는 경우 값이 일치하도록 유지하고, `setSpellCheck(true)`와 `setProofDisabled(NullableBool.True)`를 동시에 사용하는 것은 피하십시오.

이러한 속성은 PowerPoint 및 기타 프레젠테이션 애플리케이션에서 사용되는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사용해 사전 기반 맞춤법 검사를 수행하거나 맞춤법 오류 목록을 반환하지 않습니다.

다음 전체 예제는 입력 프레젠테이션을 생성하고, 이를 로드한 뒤, 동일한 단락 내 두 부분에 서로 다른 맞춤법 검사 설정과 교정 언어를 할당하고, 결과를 저장한 후 다시 열어 저장된 값을 확인합니다:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--)은 동일한 형식을 가진 인접한 부분을 결합합니다. `SpellCheck` 값만 다르면 이러한 부분이 별도로 유지되지 않으며, 결합된 후 결과 부분은 첫 번째 부분의 `SpellCheck` 값을 유지합니다. 부분마다 다른 맞춤법 검사 설정이 필요하면 해당 설정을 적용하기 전에 `joinPortionsWithSameFormatting`을 호출하거나, 결합된 부분 경계를 검사한 뒤 설정을 다시 적용하십시오. `LanguageId` 값이 다른 부분은 교정 언어 형식이 다르기 때문에 별도로 유지됩니다.

## **FAQ**

**언어 ID가 텍스트를 번역합니까?**

아니요. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)은 맞춤법 및 문법 교정을 위한 메타데이터를 저장할 뿐, 텍스트 내용은 변경하지 않습니다. 텍스트는 별도로 번역한 뒤, 각 번역된 부분에 적절한 언어 식별자를 설정하십시오.

**교정 언어가 글꼴, 하이픈 삽입 또는 줄 바꿈을 제어합니까?**

아니요. 언어 식별자는 교정 용도이며, 텍스트 렌더링 및 레이아웃은 사용 가능한 [fonts](/slides/ko/java/powerpoint-fonts/), 쓰기 시스템 및 텍스트 프레임 설정에 주로 의존합니다. 안정적인 렌더링을 위해 필요한 글꼴을 제공하고, [font substitution](/slides/ko/java/font-substitution/)을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/java/embedded-font/)를 포함하십시오.

**하나의 단락에서 여러 교정 언어를 사용할 수 있습니까?**

예. 다국어 단락 예시와 같이 각 언어를 별도의 부분에 할당하면 됩니다.

**`setDefaultTextLanguage`와 `setLanguageId` 중 어느 것을 사용해야 합니까?**

새로 만든 텍스트에 대한 기본값이 필요하면 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)를 사용하십시오. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 여러 언어가 포함된 경우에는 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)를 사용하십시오.