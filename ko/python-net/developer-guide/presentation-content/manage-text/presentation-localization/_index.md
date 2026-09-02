---
title: Python을 사용한 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/python-net/presentation-localization/
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
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션 텍스트의 교정 언어를 설정하며, 기본값 및 다국어 단락을 포함합니다."
---
## **Overview**

Aspose.Slides for Python via .NET를 사용하면 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있습니다. 교정 언어를 식별하려면 [BasePortionFormat.language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/language_id/) 를, 철자 검사를 허용하거나 억제하려면 [BasePortionFormat.spell_check](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/spell_check/) 를, 더 넓은 무교정 상태를 제어하려면 [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/proof_disabled/) 를 사용합니다. 이러한 설정은 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 서로 다른 교정 규칙을 포함할 수 있습니다.

이 문서는 특정 텍스트에 언어를 할당하는 방법, [LoadOptions.default_text_language](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/default_text_language/) 로 새 텍스트의 기본 언어를 설정하는 방법, 다중 언어 단락을 만드는 방법, `spell_check` 와 `proof_disabled` 중 선택하는 방법, 그리고 [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) 을 사용할 때 의도된 설정을 유지하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 애플리케이션을 위한 메타데이터를 저장하며, 텍스트를 번역하거나 사전 기반 철자 검사를 수행하거나 맞춤법 오류를 반환하지 않습니다.

## **Set the Proofing Language for Text**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)을 만들거나 로드하고, [Portion.portion_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/portion_format/)을 통해 필요한 텍스트 부분에 접근한 다음 해당 언어 식별자를 할당합니다. 다음 예제는 도형을 만들고, 영국식 영어를 교정 언어로 설정한 뒤, [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 로 결과를 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Default Language for New Text**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/default_text_language/) 을 사용하여 Aspose.Slides가 새로 만든 텍스트에 할당할 교정 언어를 지정합니다. 이 설정은 프레젠테이션의 대부분 또는 모든 새 텍스트가 동일한 언어를 사용할 때 유용합니다. 이미 명시적 언어가 지정된 텍스트의 언어 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트에 독일어 교정 규칙을 적용하는 프레젠테이션을 생성합니다.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Use Multiple Languages in One Paragraph**

[Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)은 텍스트 부분 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/)을 만들고 `language_id` 를 독립적으로 설정합니다.

이 예제는 영어와 프랑스어 부분을 포함하는 하나의 단락을 생성합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Enable or Suppress Spell Checking for Individual Portions**

[PortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/) 은 [BasePortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/) 에서 정의된 공통 텍스트 속성을 상속합니다. [Portion.portion_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/portion_format/) 을 통해 부분의 형식에 접근하고, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/spell_check/) 를 설정하여 프레젠테이션 애플리케이션이 해당 부분의 맞춤법을 검사할 수 있는지 제어합니다. 기본값은 `False`이며, `True`는 맞춤법 검사를 허용하고 `False`는 억제합니다.

이 설정은 개별 텍스트 부분에 적용됩니다. 같은 단락 내의 다른 부분은 서로 다른 값을 사용할 수 있습니다. [BasePortionFormat.language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/language_id/) 와 `spell_check` 는 보완적인 역할을 합니다: `language_id` 가 교정 언어를 식별하고, `spell_check` 가 해당 부분에 대한 맞춤법 검사 허용 여부를 결정합니다.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/proof_disabled/) 도 교정을 제어하지만, 이는 [NullableBool](https://reference.aspose.com/slides/ko/python-net/aspose.slides/nullablebool/) 로 더 넓은 “교정 안 함” 상태를 나타냅니다. 맞춤법 검사에만 직접적인 Boolean 스위치가 필요하면 `spell_check` 를 사용하고, 프레젠테이션의 무교정 메타데이터와 그 `NOT_DEFINED` 상태를 보존하거나 명시적으로 제어해야 할 경우 `proof_disabled` 를 사용하십시오. 두 속성을 모두 설정하는 경우 값이 일관되도록 유지하고, `spell_check = True` 와 `proof_disabled = slides.NullableBool.TRUE` 를 함께 사용하지 마세요.

이 속성들은 PowerPoint 및 기타 프레젠테이션 애플리케이션에서 사용되는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사용해 사전 기반 맞춤법 검사를 수행하거나 맞춤법 오류 목록을 반환하지 않습니다.

다음 전체 예제는 입력 프레젠테이션을 만들고 로드한 뒤, 같은 단락 내 두 부분에 서로 다른 맞춤법 검사 설정 및 교정 언어를 할당하고, 결과를 저장한 뒤 다시 열어 저장된 값을 확인합니다.

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) 은 동일한 형식을 가진 인접 부분을 결합합니다. `spell_check` 값만 다른 경우에도 이러한 부분은 결합될 수 있으며, 결합된 결과 부분은 첫 번째 부분의 `spell_check` 값을 유지합니다. 부분마다 다른 맞춤법 검사 설정이 필요하면 해당 설정을 할당하기 전에 `join_portions_with_same_formatting` 을 호출하거나, 결합 후 결과 부분 경계를 확인하고 설정을 다시 적용하십시오. `language_id` 값이 다른 부분은 교정 언어 형식이 다르기 때문에 별도로 유지됩니다.

## **FAQ**

**Does a language ID translate the text?**

아니요. [BasePortionFormat.language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/language_id/) 은 맞춤법 및 문법 교정을 위한 메타데이터를 저장할 뿐, 텍스트 내용 자체를 변경하지 않습니다. 텍스트는 별도로 번역한 후 각 번역된 부분에 적절한 언어 식별자를 설정하세요.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

아니요. 언어 식별자는 교정용입니다. 텍스트 렌더링 및 레이아웃은 주로 사용 가능한 [fonts](/slides/ko/python-net/powerpoint-fonts/), 쓰기 시스템 및 텍스트 프레임 설정에 따릅니다. 신뢰성 있는 렌더링을 위해 필요한 글꼴을 제공하고, [font substitution](/slides/ko/python-net/font-substitution/) 을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/python-net/embedded-font/) 를 포함하세요.

**Can one paragraph use several proofing languages?**

예. 다국어 단락 예제에 나와 있듯이 각 언어를 별도의 부분에 할당하면 하나의 단락에서 여러 교정 언어를 사용할 수 있습니다.

**Should I use `default_text_language` or `language_id`?**

새로 만든 텍스트에 대한 기본값이 필요하면 [LoadOptions.default_text_language](https://reference.aspose.com/slides/ko/python-net/aspose.slides/loadoptions/default_text_language/) 를 사용하세요. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 여러 언어가 포함된 경우에는 [BasePortionFormat.language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/language_id/) 를 사용하십시오.