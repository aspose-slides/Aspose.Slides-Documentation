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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션의 텍스트를 검색하고, 강조하고, 교체합니다."
---
## **개요**

Aspose.Slides for Python via .NET는 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색하고, 강조 표시하며, 교체할 수 있습니다. 이러한 기능은 검토, 민감 정보 삭제, 용어 확인, 템플릿 정리 및 기타 자동 문서 처리 워크플로에 유용합니다.

아래 첫 번째 예제에서는 "sample.pptx"라는 파일을 사용합니다. 이 파일은 첫 번째 슬라이드에 다음 텍스트가 들어 있는 하나의 텍스트 상자를 포함하고 있습니다.

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

텍스트 프레임에 대한 작업을 제한하려면 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 메서드를 사용하십시오. 프레젠테이션의 모든 적용 가능한 텍스트를 처리하려면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 메서드를 사용하십시오.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [TextFrame.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_text/) |
| 정규식 일치 강조 | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_regex/) |
| 리터럴 텍스트 교체 | [TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_text/) |
| 정규식 일치 교체 | [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_regex/) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업의 경우, 매칭을 제어하려면 [TextSearchOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/)를 사용하십시오:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/whole_words_only/)는 일치를 전체 단어로 제한합니다.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/case_sensitive/)는 문자 대소문자를 일치시켜야 하는지를 제어합니다.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/include_notes/)는 슬라이드 노트를 프레젠테이션 수준 검색, 교체 및 강조 작업에 포함합니다.

정규식 작업은 패턴 문자열을 사용하므로 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 표현식 자체에 정의됩니다.

## **텍스트 프레임의 소유자 식별**

일반적인 텍스트 처리 워크플로는 검색, 교체, 검증 또는 텍스트 내보내기 중에 종종 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을(를) 받습니다. 텍스트 프레임을 소유한 프레젠테이션 객체를 확인하려면 [TextFrame.parent_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_shape/)와 [TextFrame.parent_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_cell/)을 사용하십시오.

예상 값은 소유자에 따라 달라집니다:

| 텍스트 프레임 소유자 | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape 또는 다른 텍스트 포함 도형 | The owning [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) | `None` |
| 테이블 셀 | `None` | The owning [Cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/) |

두 속성은 읽기 전용 탐색 속성입니다. 이를 읽어도 텍스트 프레임이 이동하거나 소유자가 변경되지 않습니다. 일반 코드는 두 값이 `None`인지 확인하고, 어느 소유자도 없을 가능성을 처리해야 합니다.

다음 예제는 [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/get_all_text_frames/)을 사용하여 프레젠테이션의 텍스트 프레임을 순회합니다. 도형에 대해서는 도형 이름, Python 런타임 유형 및 포함된 슬라이드를 보고합니다. 테이블 셀에 대해서는 0부터 시작하는 열 및 행 좌표와 포함된 슬라이드를 보고합니다.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

SmartArt 콘텐츠의 경우, [SmartArtNode.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartartnode/shapes/)에 있는 도형을 순회하고 각 [ISmartArtShape.text_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/ismartartshape/text_frame/)에 접근합니다. 텍스트 프레임은 [TextFrame.parent_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_shape/)을 통해 연결된 도형으로 추적할 수 있으며, [TextFrame.parent_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_cell/)는 `None`입니다. 따라서 예제의 도형 분기에서는 SmartArt 노드의 텍스트도 처리합니다.

## **텍스트 강조**

[TextFrame.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_text/) 메서드를 사용하여 텍스트 프레임에서 리터럴 텍스트 일치를 강조 표시합니다. 검색을 제어하려면 [TextSearchOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/)를 전달하십시오.

아래 코드 예제는 문자열 **"try"**의 모든 발생을 강조 표시한 다음, 전체 단어 **"to"**만 강조 표시합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # 텍스트 프레임에서 "try"가 나타나는 모든 위치를 강조 표시합니다.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # 전체 단어 "to"만 강조 표시합니다.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![강조된 텍스트](highlighted_text.png)

## **정규식 사용 텍스트 강조**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_regex/) 메서드는 정규식으로 찾은 텍스트 일치를 텍스트 프레임에서 강조 표시합니다.

다음 코드는 7자 이상인 모든 단어를 강조 표시합니다:

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

![정규식을 사용한 강조된 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체 텍스트 강조**

[Presentation.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_text/)와 [Presentation.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/highlight_regex/)를 사용하여 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 강조 표시합니다:

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

## **텍스트 프레임 내부 텍스트 교체**

리터럴 텍스트 교체는 [TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/)를, 패턴 기반 교체는 [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/)를 사용하십시오. 이러한 메서드는 기존 텍스트 프레임 내에서 일치하는 텍스트를 업데이트하며, 순수 문자열로 텍스트 프레임을 재구성하는 대신 주변 부분의 서식을 유지합니다.

다음 예제는 철자 변형을 표준화하고 이후 버전 레이블을 교체합니다:

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

하나의 일치가 서로 다른 서식 부분에 걸쳐 있는 경우, 교체 텍스트에 적용될 서식을 확인하기 위해 결과를 검토하십시오.

## **프레젠테이션 전체 텍스트 교체**

[Presentation.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_text/)와 [Presentation.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/replace_regex/)를 사용하여 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 민감 정보 삭제에 유용합니다.

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

**전체 프레젠테이션이 아니라 하나의 텍스트 상자만 검색하려면 어떻게 해야 하나요?**

모양의 텍스트 프레임을 가져와 해당 텍스트 프레임에서 [TextFrame.highlight_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/), 또는 [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/)를 호출하십시오. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**전체 단어를 올바른 대소문자로 일치시키려면 어떻게 해야 하나요?**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/whole_words_only/)와 [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/case_sensitive/)를 `True`로 설정하고, 해당 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달하십시오. 정규식의 경우, 패턴 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함될 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textsearchoptions/include_notes/)를 `True`로 설정하십시오.

**텍스트 교체 시 서식이 유지되나요?**

[TextFrame.replace_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_text/)와 [TextFrame.replace_regex](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/replace_regex/)는 기존 텍스트 프레임 내에서 일치하는 텍스트를 수정하며 주변 부분의 서식을 유지합니다. 일치가 서로 다른 서식 부분에 걸쳐 있는 경우, 교체가 원하는 스타일을 사용하는지 결과를 확인하십시오.