---
title: Python에서 프레젠테이션의 도형 효과 속성 가져오기
linktitle: 효과 속성
type: docs
weight: 50
url: /ko/python-net/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 조명 장치
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에서 로컬, 상속 및 효과적인 도형 서식을 구분하는 방법을 배웁니다."
---
## **로컬, 상속 및 효과적인 속성 이해**

PowerPoint 서식은 여러 출처에서 올 수 있습니다. 객체에 직접 저장된 값은 **로컬 값**입니다. 해당 값이 설정되지 않은 경우 PowerPoint는 단락 기본값, 텍스트 스타일, 레이아웃 또는 마스터 슬라이드, 테마, 프레젠테이션 수준 기본값과 같은 상위 서식 소스를 확인합니다. 이러한 값은 **상속값**입니다. 전체 계층 구조가 해결된 후 남는 값이 **효과값**이며, 이 값이 객체를 렌더링하는 데 사용됩니다.

예를 들어, 텍스트 부분에 자체 글꼴 높이가 정의되지 않을 수 있습니다. 해당 로컬 [font_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ibaseportionformat/font_height/)는 `float("nan")`이며, 이는 “여기에 설정되지 않음”을 의미합니다. 부분은 단락, 프레젠테이션 기본 텍스트 스타일 또는 다른 적용 가능한 소스에서 높이를 상속받을 수 있습니다. 부분 형식에서 [get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iportionformat/get_effective/)을 호출하면 최종 해결된 높이가 반환됩니다.

두 종류의 서식 데이터를 다른 목적에 사용하십시오:

- 값이 정의된 위치를 제어해야 할 때와 같이 로컬 형식 객체(예: [IPortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iportionformat/))를 읽거나 변경합니다.
- 최종 렌더링 결과가 필요할 때와 같이 효과 데이터 객체(예: [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iportionformateffectivedata/))를 읽습니다. 효과 데이터는 읽기 전용입니다.

## **로컬, 상속 및 효과값 비교**

다음 완전한 예제는 도형을 만들고 프레젠테이션, 단락 및 부분 수준에서 글꼴 높이를 적용합니다. 각 단계에서 해당 수준에 정의된 값과 동일한 텍스트 부분에 대한 결과 효과값을 출력합니다. 또한 서식 변경 후 효과 데이터를 다시 읽어야 하는 이유를 보여줍니다.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # 이전 변경 후 효과 데이터를 읽습니다.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # 두 개의 다른 수준에서 상속 값을 정의합니다.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 부분에 대한 로컬 값이 두 상속 값을 모두 우선합니다.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 상속 값을 변경해도 기존 로컬 값을 대체하지 않습니다.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # 로컬 값을 지웁니다. 이제 부분은 다시 단락에서 상속받습니다.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 단락 값을 지웁니다. 이제 프레젠테이션 기본값이 결과를 제공합니다.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

이 예제의 우선 순위는 부분 로컬 서식 → 단락 서식 → 프레젠테이션 기본값 순입니다. 다른 객체는 서로 다른 상속 체인을 가질 수 있지만 원리는 동일합니다: 보다 구체적인 명시적 값이 우선하며, [get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iportionformat/get_effective/)은 최종 결과를 반환합니다.

## **효과적인 텍스트 속성 가져오기**

텍스트 서식은 여러 객체에 걸쳐 나뉩니다:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/itextframeformat/get_effective/)은 여백, 정렬, 자동 맞춤 및 수직 텍스트 방향과 같은 텍스트 프레임 속성을 해결합니다.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/itextstyle/get_effective/)은 각 텍스트 스타일 레벨에 대한 단락 서식을 해결합니다.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iparagraphformat/get_effective/)은 정렬, 들여쓰기 및 글머리표와 같은 단락 속성을 해결합니다.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iportionformat/get_effective/)은 글꼴 높이, 글꼴, 색상, 굵게 및 기울임과 같은 문자 속성을 해결합니다.

다음 예제를 실행하려면 `text-formatting.pptx` 파일에 최소 하나의 슬라이드와 텍스트 프레임이 비어 있지 않은 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)이 포함되어 있어야 합니다. AutoShape는 도형 컬렉션의 어느 위치에 있어도 상관없으며, 코드는 적절한 객체를 찾아 사용하기 전에 검증합니다.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **효과적인 3D 속성 가져오기**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformat/get_effective/)은 모든 해결된 3D 설정을 그룹화한 하나의 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/) 객체를 반환합니다. 해당 객체의 [camera](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) 및 [bevel_bottom](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) 속성은 해당 효과 데이터를 노출합니다. 이러한 관련 설정을 함께 읽으면 도형의 최종 3D 모양을 이해하기가 쉬워집니다.

이 예제를 실행하려면 `shape-3d.pptx` 파일에 첫 번째 슬라이드에 최소 하나의 도형이 포함되어 있어야 합니다. 출력에 기본값이 아닌 값을 포함하려면 해당 도형에 3D 카메라, 조명 또는 베벨 설정을 적용하십시오.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **효과적인 표 서식 가져오기**

표 서식은 표 스타일과 전체 표, 열, 행 또는 개별 셀에 적용된 서식에서 올 수 있습니다. 명시적으로 정의된 채우기 간 충돌이 발생하면 우선 순위는 셀 → 행 → 열 → 전체 표입니다. 셀의 효과적인 서식은 해당 셀을 그리는 데 사용되는 최종 서식입니다.

이 예제를 실행하려면 `table-formatting.pptx` 파일에 첫 번째 슬라이드에 최소 하나의 표가 포함되어 있어야 합니다. 표에는 최소 하나의 행과 열이 있어야 합니다. 코드는 `shapes[0]`이 표라고 가정하지 않고 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/)을 검색합니다.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

색상 자체가 필요하고 채우기 유형만이 아니라면 먼저 효과적인 [fill_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ifillformateffectivedata/fill_type/)을 확인한 뒤, 해당 유형에 적용되는 속성을 읽으십시오. 예를 들어, 단색 채우기의 경우 [solid_fill_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/)을 사용합니다.

## **변경 후 효과 데이터 다시 읽기**

효과 데이터는 해결 시점의 서식 계층 구조를 설명합니다. 계층 구조에 참여할 수 있는 모든 요소를 변경한 후 `get_effective`를 다시 호출하십시오. 포함 요소:

- 객체의 로컬 서식;
- 단락 또는 텍스트 프레임 기본값;
- 표 스타일, 표, 열, 행 또는 셀 서식;
- 레이아웃 또는 마스터 슬라이드 서식;
- 테마 데이터 또는 프레젠테이션 수준 기본값;
- 슬라이드에 할당된 레이아웃 또는 마스터.

효과 데이터 객체를 영구적인 스냅샷으로 유지하지 마십시오. Aspose.Slides는 내부적으로 일부 효과 데이터를 캐시할 수 있으며, 이후 `get_effective` 호출로 해당 데이터를 새로 고칠 수 있습니다. 변경 전후 값을 비교해야 하는 경우, 글꼴 높이, 색상, 정렬 또는 베벨 너비와 같은 스칼라 값을 변경 전에 자체 변수에 복사해 두십시오.

값을 변경하려면 해당 로컬 형식 객체를 업데이트한 뒤 `get_effective`를 호출하여 결과를 확인합니다. 효과 데이터 객체 자체는 읽기 전용입니다.

## **FAQ**

**어떤 수준이 효과 값을 제공했는지 어떻게 알 수 있나요?**

효과 데이터에는 최종 값만 포함되며, 그 출처는 제공되지 않습니다. 가장 구체적인 수준부터 바깥쪽으로 적용 가능한 로컬 객체를 검사하십시오. 텍스트의 경우 부분, 단락, 텍스트 프레임, 레이아웃, 마스터, 테마 및 프레젠테이션 기본값이 포함될 수 있습니다. `float("nan")`이나 `None`과 같은 정의되지 않은 값은 검색이 다른 수준으로 계속됨을 나타냅니다.

**어떠한 수준도 속성을 정의하지 않으면 어떻게 되나요?**

Aspose.Slides는 적절한 PowerPoint 또는 라이브러리 기본값을 해결합니다. 해당 해결된 값은 로컬 객체가 명시적으로 정의하지 않았더라도 효과 데이터에 표시됩니다.

**왜 효과 값이 때때로 로컬 값과 동일한가요?**

로컬 값이 상속 계산에서 승리했기 때문입니다. 이는 객체에 해당 속성이 명시적으로 설정되고 더 구체적인 규칙이 이를 덮어쓰지 않을 때 예상되는 동작입니다.

**언제 로컬 데이터를 사용하고 언제 효과 데이터를 사용해야 하나요?**

특정 서식 수준을 검사하거나 편집해야 할 때는 로컬 데이터를 사용하십시오. 상속, 테마 규칙 및 적용 가능한 스타일이 모두 해결된 후의 최종 모습을 확인해야 할 때는 효과 데이터를 사용하십시오. [전체 비교 예제](#compare-local-inherited-and-effective-values)에서 두 가지를 동일 워크플로우에 적용하는 모습을 확인할 수 있습니다.