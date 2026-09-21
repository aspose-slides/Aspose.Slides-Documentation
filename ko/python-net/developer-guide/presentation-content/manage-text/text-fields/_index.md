---
title: Python을 사용한 PowerPoint 프레젠테이션 텍스트 필드 관리
linktitle: 텍스트 필드
type: docs
weight: 52
url: /ko/python-net/text-fields/
keywords:
- 텍스트 필드
- 자동 텍스트
- 슬라이드 번호
- 날짜 및 시간
- 머리글
- 바닥글
- 텍스트 부분
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 통해 .NET에서 PowerPoint 프레젠테이션의 텍스트 필드를 생성, 검사, 수정 및 제거합니다. 형식을 보존하고 저장된 PPTX 및 PPT 파일을 검증합니다."
---
## **개요**

텍스트 단락은 부분으로 구성됩니다. 일반적인 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/)은 리터럴 텍스트를 포함하고; 필드 부분은 자동으로 업데이트되는 값(예: 슬라이드 번호 또는 날짜)을 식별하는 유형을 가진 [Field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/field/)도 가지고 있습니다. 두 부분이 동일한 문자를 표시할 수 있지만 필드를 포함하는 것은 하나뿐입니다.

이들을 구분하려면 [Portion.field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/field/)을 사용하십시오: 일반 텍스트인 경우 `None`입니다. [Portion.add_field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/add_field/)은 기존 부분을 필드로 변환합니다. 값을 변환해도 라벨이 교체되지 않도록 라벨과 동적 값을 별개의 부분에 보관하십시오.

이 가이드는 텍스트 내부의 필드, 해당 형식 지정 및 PPTX와 PPT 저장 방법을 다룹니다. 텍스트 프레임 및 단락에 대해서는 [Manage Text](/slides/ko/python-net/manage-text/)를 참조하십시오.

## **슬라이드 번호 필드 생성**

다음 완전한 예제는 리터럴 `Slide ` 라벨과 자동으로 업데이트되는 번호를 포함하는 텍스트 상자를 생성합니다. 필드를 추가하기 전에 번호의 크기, 두께 및 색상을 설정하고, 저장된 프레젠테이션을 다시 열어 필드 유형, 텍스트 및 형식을 확인합니다. 입력 파일은 필요하지 않습니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

새 프레젠테이션은 슬라이드 번호 1부터 시작하므로 텍스트는 `Slide 1`이며, 두 검증 모두 `True`를 출력합니다. 번호는 다시 열어도 필드로 남아 있으며, 리터럴 `1`이 아닙니다. 검증에 사용된 인덱스는 이 예제에서 만든 도형과 부분을 가리킵니다.

## **필드 유형 선택**

[FieldType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/)은 다음과 같은 사전 정의된 값을 제공합니다. 적절한 값을 [add_field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/add_field/)에 전달하십시오.

| 값 | 목적 |
|---|---|
| [slide_number](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/slide_number/) | 현재 슬라이드 번호. |
| [date_time](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/date_time/) | 렌더링 애플리케이션의 기본 형식인 날짜/시간. |
| [date_time1](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/date_time9/) | 미리 정의된 날짜 또는 결합 날짜/시간 형식. |
| [date_time10](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/date_time13/) | 초 및 12시간 시계 옵션이 있는 미리 정의된 시간 형식. |
| [header](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/header/) | 헤더 필드; 아래 자리표시자 및 형식 제한 사항을 참조하십시오. |
| [footer](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/footer/) | 푸터 필드. |

예를 들어, [date_time3](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/date_time3/)은 영어로 하루, 전체 월 이름 및 연도를 나타냅니다. 이는 임의의 Python 날짜 형식 문자열이 아니라 사전 정의된 필드 형식입니다. 부분의 [language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseportionformat/language_id/) 및 프레젠테이션을 처리하는 애플리케이션에 따라 표시 결과가 달라질 수 있습니다.

## **내부 문자열에서 필드 생성**

[add_field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/add_field/)의 문자열 오버로드는 내부 필드 식별자를 허용합니다. 사전 정의된 값이 없는 다른 애플리케이션이 제공한 식별자를 보존하려는 경우 사용하십시오. 식별자를 통해 [FieldType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/__init__/)을 만들 수도 있습니다. [FieldType.internal_string](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fieldtype/internal_string/)은 해당 식별자를 검사용으로 노출합니다.

이 예제는 애플리케이션 고유의 `custom-report-id` 필드를 기본 텍스트 `Report-042`와 함께 저장합니다. 이 식별자는 계산을 등록하지 않습니다: Aspose.Slides는 알 수 없는 유형에 대한 보고서 ID를 생성하지 않습니다. 이 식별자를 이해하는 애플리케이션이 의미를 제공하고 값을 업데이트해야 합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

이 PPTX 라운드 트립 후, 유형은 `custom-report-id`이고 텍스트는 `Report-042`입니다. `%Y-%m-%d`와 같은 문자열을 전달하면 필드 유형 이름이 지정되는 것이며, 사용자 지정 날짜 형식을 구성하지는 않습니다. 임의 형식의 고정 날짜가 필요하면 일반 텍스트를 사용하십시오.

## **날짜/시간 필드 검사, 수정 및 제거**

[Field.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/field/type/)을 통해 기존 필드를 읽고 변경합니다. 유형에 접근하기 전에 필드가 존재하는지 확인하십시오. 자동 업데이트를 중지하려면 [Portion.remove_field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/remove_field/)을 호출하십시오. 이는 필드 연결을 제거하면서 부분과 현재 텍스트를 유지합니다. 특정 고정값이 필요하면 필드를 제거한 후 해당 텍스트를 할당하십시오.

날짜/시간 필드 처리와 관련된 API 설정은 [Presentation.current_date_time](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/current_date_time/)을 참고하십시오. 아래 예제는 필드를 일반 텍스트로 변환할 때 명시적인 승인 날짜를 사용합니다. 영어 월 이름 튜플은 시스템 로케일과 무관하게 고정 날짜를 유지합니다.

[sample.pptx](sample.pptx)를 다운로드하여 작업 디렉터리에 배치하십시오. 여기에는 두 개의 명명된 텍스트 도형 `UpdatedAt` 및 `ApprovedDate`가 포함되어 있으며, 각각 날짜/시간 필드와 일반 텍스트 라벨이 있습니다. 아래 예제는 일반 슬라이드의 최상위 텍스트 도형을 순회합니다. 날짜/시간 필드를 긴 날짜 형식으로 변경하고 이탤릭체로 만들면서 다른 형식은 유지합니다. `ApprovedDate`의 필드만 고정 텍스트가 됩니다.

샘플은 내장된 내부 식별자 `datetime` 및 `datetime1`부터 `datetime13`까지를 인식합니다. 그룹, 표, 노트, 레이아웃 및 마스터는 자체 텍스트 컨테이너를 순회해야 하며 이 예제 범위에 포함되지 않습니다.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

다시 열면 `UpdatedAt`은 유형 `datetime3`이며 동적 상태를 유지합니다. `ApprovedDate`는 필드가 없으며 `05 April 2030`이 들어 있습니다. 두 날짜 부분 모두 이탤릭체이며 원래 글꼴 크기, 굵게 설정 및 색상이 그대로 유지됩니다. 일반 텍스트 라벨은 변하지 않습니다. 검증은 제공된 샘플의 두 알려진 도형의 첫 번째 부분을 읽습니다.

## **텍스트 형식 보존**

필드를 추가하거나 유형을 변경하거나 제거할 때 기존 부분을 사용하십시오. 이러한 작업은 해당 부분의 형식을 유지합니다. 색상이나 이탤릭과 같이 필요한 속성만 변경하려면 [Portion.portion_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/portion_format/)을 사용하십시오.

하나의 필드만 업데이트하기 위해 전체 텍스트 프레임을 재구성하는 것을 피하십시오. 이렇게 하면 원래 부분 경계와 개별 형식이 손실될 수 있습니다. 또한 단락, 레이아웃 또는 테마에서 상속된 형식과 명시적으로 설정된 형식을 구분하십시오. 더 폭넓은 형식 옵션은 [Text Formatting](/slides/ko/python-net/text-formatting/)을 참고하십시오.

## **필드와 머리글/바닥글 자리표시자**

필드는 텍스트 부분의 일부입니다. 자리표시자는 푸터나 슬라이드 번호와 같은 프레젠테이션 역할을 가진 도형입니다. 일반 텍스트 상자에 필드를 추가해도 해당 도형이 자리표시자로 변환되지 않습니다.

머리글/바닥글 관리자는 슬라이드, 레이아웃 및 마스터에서 자리표시자 텍스트와 가시성을 제어하며, 종속 슬라이드에 전파됩니다. 따라서 슬라이드 번호 자리표시자를 사용하지 않더라도 사용자 지정 텍스트 상자의 번호 필드는 유용할 수 있습니다. 반대로, 자리표시자 가시성을 변경해도 관련 없는 텍스트 상자의 필드는 제거되지 않습니다.

사전 정의된 머리글 및 바닥글 유형은 해당 자리표시자를 생성하거나 내용을 제공하지 않습니다. 특히 일반 PowerPoint 슬라이드에는 머리글 자리표시자가 없으며, 머리글은 노트 페이지와 유인물에 속합니다. 임의 도형의 머리글 또는 바닥글 필드가 자리표시자 관리자를 통해 설정된 텍스트를 자동으로 얻는다고 가정하지 마십시오. 해당 작업 흐름은 [Presentation Headers and Footers](/slides/ko/python-net/presentation-header-and-footer/)를 참고하십시오.

## **PPTX 및 PPT 제한**

저장하고 다시 연 후 필드 유형과 결과 텍스트를 모두 확인하십시오. 식별자를 보존한다고 해서 해당 애플리케이션이 값을 계산하거나 표시할 수 있음을 증명하는 것은 아닙니다.

| 형식 | 필드 동작 및 제한 사항 |
|---|---|
| PPTX | 내부 필드 식별자를 필드 텍스트와 함께 저장합니다. 라운드‑트립 검증에서 위에서 사용한 사전 정의된 유형과 사용자 정의 식별자가 모두 저장·재열림을 견뎠습니다. 알 수 없는 사용자 정의 유형은 기본 텍스트를 유지했으며 자동 계산 로직을 획득하지 않았습니다. 다른 애플리케이션은 지원되지 않는 식별자를 다르게 처리할 수 있습니다. |
| PPT | 레거시 필드 표현을 사용하며 호환성이 더 제한적입니다. 라운드‑트립 검증에서 슬라이드 번호와 사전 정의된 날짜/시간 필드는 저장·재열림을 견뎠습니다. 일반 슬라이드 텍스트 상자의 사용자 정의 필드는 식별자는 유지되지만 텍스트는 `*`로 열렸으며, 동일 컨텍스트의 머리글 필드도 `*`를 생성했습니다. 사용자 정의 필드나 지원되지 않는 필드 컨텍스트가 표시 텍스트를 유지한다는 가정은 하지 마십시오. |

휴대 가능하고 고정된 출력을 위해서는 지원되지 않는 필드를 일반 텍스트로 변환하고 저장하기 전에 원하는 값을 명시적으로 할당하십시오. 이렇게 하면 선택한 텍스트가 보존되지만 자동 업데이트는 의도적으로 중지됩니다. 워크플로우에 대상 애플리케이션의 자체 필드 재계산이 포함되는 경우 해당 애플리케이션도 테스트하십시오.

## **FAQ**

**표시된 번호나 날짜가 필드인지 어떻게 알 수 있나요?**  
[Portion.field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/field/)을 검사하십시오. `None`이 아닌 값은 필드를 나타냅니다; 표시된 텍스트만으로는 판단할 수 없습니다.

**필드를 제거하면 텍스트나 형식이 함께 제거되나요?**  
아니오. [remove_field](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/remove_field/)은 기존 부분을 일반 텍스트로 변환합니다. 특정 고정 날짜나 대체 값이 필요하면 이후에 명시적인 값을 할당하십시오.

**내부 문자열이 새로운 날짜 형식이나 수식을 정의할 수 있나요?**  
아니오. 이는 필드 유형을 식별할 뿐입니다. 알 수 없는 식별자는 평가자나 Python 날짜 형식 패턴을 제공하지 않습니다. 지원되는 사전 정의된 유형을 사용하거나 값을 일반 텍스트로 직접 형식화하십시오.

**저장 후 프레젠테이션을 다시 확인해야 하는 이유는 무엇인가요?**  
필드 식별자, 계산된 텍스트 및 형식은 각각 확인해야 하는 별개 항목입니다. 형식 변환은 필드 식별자가 여전히 존재해도 표시 결과를 변경할 수 있습니다.