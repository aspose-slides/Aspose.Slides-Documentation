---
title: Python을 통한 Java 기반 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/python-java/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 맞춤법 검사 억제
- 교정 언어
- 언어 ID
- 다국어 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용한 Python via Java로 PowerPoint 및 OpenDocument 프레젠테이션 텍스트의 교정 언어를 설정하며, 기본값 및 다국어 단락을 포함합니다."
---
## **개요**

Aspose.Slides for Python via Java를 사용하면 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있습니다. 교정 언어를 지정하려면 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId)를 사용하고, 맞춤법 검사를 허용하거나 억제하려면 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)를 사용하며, 보다 넓은 “교정 안 함” 상태를 제어하려면 [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setProofDisabled)를 사용합니다. 이러한 설정은 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 서로 다른 교정 규칙을 포함시킬 수 있습니다.

이 문서에서는 특정 텍스트에 언어를 할당하는 방법, [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)으로 새 텍스트의 기본 언어를 설정하는 방법, 다국어 단락을 만드는 방법, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)와 [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setProofDisabled) 중 선택하는 방법, 그리고 [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)을 사용할 때 의도한 설정을 보존하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 응용 프로그램을 위한 메타데이터를 저장하며, 텍스트를 번역하거나 사전 기반 맞춤법 검사를 수행하거나 오탈자를 반환하지는 않습니다.

## **텍스트에 대한 교정 언어 설정**

[Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)을 만들거나 로드한 후, [Portion.getPortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getPortionFormat)을 통해 필요한 텍스트 부분에 접근하고 언어 식별자를 지정합니다. 다음 예제는 도형을 생성하고, 교정 언어를 영국식 영어로 설정한 뒤, 결과를 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **새 텍스트에 대한 기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)를 사용하면 Aspose.Slides가 새로 만든 텍스트에 자동으로 할당하는 교정 언어를 지정할 수 있습니다. 프레젠테이션의 대부분 또는 전체 새 텍스트가 동일한 언어를 사용할 경우 유용합니다. 이미 명시적인 언어가 지정된 텍스트의 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트에 독일어 교정 규칙을 적용하는 프레젠테이션을 생성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **하나의 단락에 여러 언어 사용**

[Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/)은 텍스트 부분의 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)을 만들고, 해당 부분의 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId)를 독립적으로 설정합니다.

다음 예제는 영어와 프랑스어 부분을 포함하는 하나의 단락을 생성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **개별 부분에 대한 맞춤법 검사 활성화 또는 억제**

[PortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/)은 [BasePortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/)에서 정의한 공통 텍스트 속성을 상속합니다. [Portion.getPortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getPortionFormat)을 통해 부분의 형식에 접근하고, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)를 사용하여 해당 부분에 대해 프레젠테이션 응용 프로그램이 맞춤법 검사를 수행할 수 있는지 제어합니다. 기본값은 `False`이며, `True`는 검사를 허용하고 `False`는 억제합니다.

이 설정은 개별 텍스트 부분에만 적용됩니다. 동일한 단락 내의 서로 다른 부분은 서로 다른 값을 가질 수 있습니다. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId)와 [setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)는 보완적인 역할을 합니다: [setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId)은 교정 언어를 지정하고, [setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)은 해당 부분에 대한 맞춤법 검사 허용 여부를 결정합니다.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setProofDisabled)도 교정을 제어하지만, 이는 [NullableBool](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/)으로 표현되는 보다 넓은 “교정 안 함” 상태를 나타냅니다. 맞춤법 검사를 위한 직접적인 불리언 스위치가 필요할 경우 [setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)를 사용하고, 프레젠테이션의 교정 비활성 메타데이터를 명시적으로 제어하거나 보존해야 할 경우 [setProofDisabled](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setProofDisabled)를 사용합니다. 두 속성을 동시에 설정할 경우 값이 일치하도록 유지하십시오; `True`로 설정된 [setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)과 [NullableBool.True](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/#True) 상태의 [setProofDisabled](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setProofDisabled)를 함께 사용하지 마십시오.

이러한 속성은 PowerPoint 및 기타 프레젠테이션 응용 프로그램에서 사용하는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사용해 사전 기반 맞춤법 검사를 실행하거나 오탈자 목록을 반환하지 않습니다.

다음 완전한 예제는 입력 프레젠테이션을 만들고, 로드한 뒤, 같은 단락 내 두 부분에 서로 다른 맞춤법 검사 설정과 교정 언어를 할당하고, 결과를 저장한 후 다시 열어 저장된 값을 확인합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)은 동일한 형식을 가진 인접한 부분을 결합합니다. [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck)만이 다르면 이러한 부분이 분리되지 않으며, 결합된 후 결과 부분은 첫 번째 부분의 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setSpellCheck) 값을 유지합니다. 부분마다 다른 맞춤법 검사 설정이 필요하면 해당 설정을 지정하기 전에 [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)을 호출하거나, 결합 후 생성된 부분 경계를 검사하고 설정을 다시 적용하십시오. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId) 값이 다른 부분은 교정 언어 형식이 다르기 때문에 별도로 유지됩니다.

## **FAQ**

**언어 ID가 텍스트를 번역합니까?**

아니요. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId)는 맞춤법 및 문법 교정을 위한 메타데이터를 저장할 뿐, 텍스트 내용 자체를 변경하지 않습니다. 텍스트는 별도로 번역한 뒤, 각 번역된 부분에 적절한 언어 식별자를 설정하십시오.

**교정 언어가 글꼴, 하이픈 부착 또는 줄 바꿈을 제어합니까?**

아니요. 언어 식별자는 교정을 위한 것이며, 텍스트 렌더링 및 레이아웃은 주로 사용 가능한 [fonts](/slides/ko/python-java/powerpoint-fonts/), 쓰기 체계 및 텍스트 프레임 설정에 따라 결정됩니다. 안정적인 렌더링을 위해 필요한 글꼴을 제공하고, [font substitution](/slides/ko/python-java/font-substitution/)을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/python-java/embedded-font/)를 포함하십시오.

**하나의 단락에 여러 교정 언어를 사용할 수 있습니까?**

예. 다국어 단락 예시와 같이 각 언어를 별도의 부분에 할당하면 됩니다.

**[setDefaultTextLanguage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)과 [setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId) 중 어느 것을 사용해야 합니까?**

새로 만든 텍스트에 대한 기본값이 필요하면 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)를 사용하십시오. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 여러 언어가 포함되는 경우에는 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setLanguageId)를 사용하십시오.