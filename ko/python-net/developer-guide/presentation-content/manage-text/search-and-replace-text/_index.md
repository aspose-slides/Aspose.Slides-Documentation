---
title: Python에서 PowerPoint 프레젠테이션의 텍스트 검색 및 교체
linktitle: 텍스트 검색 및 교체
type: docs
weight: 55
url: /ko/python-net/search-and-replace-text/
keywords:
- 텍스트 검색
- 텍스트 강조
- 텍스트 교체
- 정규식
- 텍스트 프레임
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에서 텍스트를 검색하고, 강조하고, 교체합니다."
---
## **개요**

Aspose.Slides for Python via .NET은 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색, 강조 및 교체할 수 있습니다. 이러한 기능은 검토, 민감 정보 삭제, 용어 검사, 템플릿 정리 및 기타 자동 문서 처리 워크플로에 유용합니다.

아래 첫 번째 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다. 텍스트 상자 내용은 다음과 같습니다:

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

[TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 메서드를 사용하여 작업을 하나의 텍스트 프레임으로 제한합니다. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)의 메서드를 사용하면 프레젠테이션 전체의 적용 가능한 텍스트를 처리할 수 있습니다.

| 작업 | 하나의 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [TextFrame.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_text/) |
| 정규식 일치 강조 | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_regex/) |
| 리터럴 텍스트 교체 | [TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_text/) |
| 정규식 일치 교체 | [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_regex/) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업에서는 [TextSearchOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/)를 사용해 매칭 방식을 제어합니다.

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/whole_words_only/)은 일치를 완전한 단어로 제한합니다.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/case_sensitive/)은 대소문자 구분 여부를 제어합니다.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/include_notes/)은 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 패턴 문자열을 사용하므로 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 정규식 자체에 정의됩니다.

## **텍스트 강조**

[TextFrame.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_text/) 메서드를 사용하면 텍스트 프레임에서 리터럴 텍스트 일치를 강조할 수 있습니다. 검색을 제어하려면 [TextSearchOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/)를 전달합니다.

아래 코드 예제는 **"try"** 문자열을 모두 강조하고, 그 다음 **"to"** 라는 완전한 단어만 강조합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # 텍스트 프레임에서 "try"가 나타나는 모든 경우를 강조합니다.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # 전체 단어 "to"만 강조합니다.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![강조된 텍스트](highlighted_text.png)

## **정규식을 사용한 텍스트 강조**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_regex/) 메서드는 정규식으로 찾은 텍스트 일치를 텍스트 프레임에서 강조합니다.

다음 코드는 길이가 7자 이상인 모든 단어를 강조합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

결과:

![정규식을 사용한 강조 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체 텍스트 강조**

[Presentation.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_text/)와 [Presentation.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_regex/)를 사용하면 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 강조합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **텍스트 프레임에서 텍스트 교체**

리터럴 텍스트 교체는 [TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/)를, 패턴 기반 교체는 [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/)를 사용합니다. 이 메서드들은 기존 텍스트 프레임 내에서 일치하는 텍스트만 업데이트하므로 주변 부분의 서식은 유지되고 전체 텍스트 프레임을 새 문자열로 재구성하지 않습니다.

다음 예제는 철자 변형을 표준화하고 버전 라벨을 교체합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

일치 항목이 서로 다른 서식이 적용된 부분에 걸쳐 있는 경우, 교체 텍스트에 적용할 서식을 확인하려면 결과를 검토하십시오.

## **프레젠테이션 전체 텍스트 교체**

[Presentation.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_text/)와 [Presentation.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_regex/)를 사용하면 동일한 작업을 프레젠테이션 전체에 적용할 수 있습니다. 이는 템플릿 정리, 용어 업데이트 및 민감 정보 삭제에 유용합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**하나의 텍스트 상자만 검색하고 전체 프레젠테이션을 대상으로 하지 않으려면 어떻게 해야 하나요?**

해당 도형의 텍스트 프레임을 가져와서 그 텍스트 프레임에 대해 [TextFrame.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/), 또는 [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/)를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**전체 단어와 정확한 대소문자를 매치하려면 어떻게 설정하나요?**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/whole_words_only/)와 [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/case_sensitive/)를 `True` 로 설정하고 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달하십시오. 정규식의 경우 패턴 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트를 포함할 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/include_notes/)를 `True` 로 설정합니다.

**텍스트 교체 시 서식이 보존되나요?**

[TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/)와 [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/)는 기존 텍스트 프레임 내에서 일치하는 텍스트를 수정하고 주변 부분의 서식을 유지합니다. 일치 항목이 서로 다른 서식이 적용된 부분에 걸쳐 있으면 결과를 검사하여 교체 텍스트가 원하는 스타일을 사용하는지 확인하십시오.