---
title: Python으로 프레젠테이션에서 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/python-net/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 라이트 릭
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET가 정확한 PowerPoint 렌더링을 위해 유효 도형 속성을 계산하고 적용하는 방식을 알아보세요."
---
## **개요**

이 항목에서는 **local**(로컬) 및 **effective**(유효) 속성의 차이를 설명합니다. 로컬 값은 다음과 같은 특정 서식 수준에 직접 설정되는 값입니다:

1. 슬라이드의 텍스트 구간 속성.
2. 레이아웃 또는 마스터 슬라이드에서 프로토타입 도형 텍스트 스타일(구간의 텍스트 프레임 도형이 있는 경우).
3. 프레젠테이션의 전역 텍스트 설정.

로컬 값은 어느 수준에서든 정의하거나 생략할 수 있습니다. Aspose.Slides가 최종 "렌더링된" 서식을 필요로 할 때는 상속 체인을 해결하고 **effective** 값을 반환합니다. 로컬 서식 객체에서 `get_effective` 메서드를 호출하면 이를 얻을 수 있습니다.

다음 예제는 유효 값을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임과 최소 하나의 구간을 가진 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)이라고 가정합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
유효 서식 데이터는 상속이 적용된 후 현재 계산된 서식을 나타냅니다. 현재 구현에서는 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iportionformateffectivedata/)와 같은 일부 유효 데이터 객체가 내부에 캐시될 수 있습니다. 상위 또는 상속된 서식을 변경한 후 `get_effective`를 다시 호출하면 캐시된 데이터가 새로 고쳐지고, 이전에 얻은 객체는 더 이상 이전 상태를 나타내지 않을 수 있습니다. 나중에 재사용하기 위해 유효 값을 보존해야 하는 경우, 글꼴 높이, 채우기 색, 글꼴 스타일 또는 정렬과 같은 필요한 속성을 자체 데이터 객체에 복사하십시오.
{{% /alert %}}

## **카메라의 유효 속성 가져오기**

Aspose.Slides를 사용하면 카메라의 유효 속성을 가져올 수 있습니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/icameraeffectivedata/) 타입은 유효 카메라 속성을 포함하는 불변 객체를 나타냅니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/icameraeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [ThreeDFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/)에 대한 유효 값을 제공합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **라이트 릭의 유효 속성 가져오기**

Aspose.Slides를 사용하면 라이트 릭의 유효 속성을 가져올 수 있습니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ilightrigeffectivedata/) 타입은 유효 라이트 릭 속성을 포함하는 불변 객체를 나타냅니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ilightrigeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [ThreeDFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/)에 대한 유효 값을 제공합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **베벨 도형의 유효 속성 가져오기**

Aspose.Slides를 사용하면 도형 베벨의 유효 속성을 가져올 수 있습니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapebeveleffectivedata/) 타입은 도형에 대한 유효 면-리프 속성을 포함하는 불변 객체를 나타냅니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapebeveleffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [ThreeDFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/)에 대한 유효 값을 제공합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **텍스트 프레임의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 프레임의 유효 속성을 가져올 수 있습니다. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/itextframeformateffectivedata/) 타입은 유효 텍스트 프레임 서식 속성을 포함합니다.

다음 예제는 유효 텍스트 프레임 서식 속성을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)이라고 가정합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **텍스트 스타일의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 스타일의 유효 속성을 가져올 수 있습니다. [ITextStyleEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/itextstyleeffectivedata/) 타입은 유효 텍스트 스타일 속성을 포함합니다.

다음 예제는 유효 텍스트 스타일 속성을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)이라고 가정합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **유효 글꼴 높이 값 가져오기**

Aspose.Slides를 사용하면 유효 글꼴 높이를 가져올 수 있습니다. 다음 코드는 프레젠테이션 구조의 서로 다른 수준에서 로컬 글꼴 높이 값을 설정한 후 구간의 유효 글꼴 높이가 어떻게 변하는지를 보여 줍니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블의 유효 채우기 서식 가져오기**

Aspose.Slides를 사용하면 테이블의 다양한 부분에 대한 유효 채우기 서식을 가져올 수 있습니다. [IFillFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ifillformateffectivedata/) 타입은 유효 채우기 서식 속성을 포함합니다. 셀 서식은 행 서식보다 우선순위가 높고, 행 서식은 열 서식보다, 열 서식은 전체 테이블 서식보다 우선합니다.

그 결과, [ICellFormatEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/icellformateffectivedata/) 속성이 테이블 셀을 그리는 데 사용됩니다. 다음 예제는 테이블의 다양한 부분에 대한 유효 채우기 서식을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 도형이 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/)이라고 가정합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**`get_effective`가 스냅샷을 반환합니까?**

항상 그렇지는 않습니다. 유효 데이터는 상속이 적용된 후 계산된 서식을 나타내지만, 일부 유효 데이터 객체는 내부에 캐시될 수 있습니다. `get_effective`를 다시 호출하면 서식이 재계산되고 캐시된 데이터가 새로 고쳐질 수 있으므로, 이전에 얻은 객체를 지속적인 스냅샷으로 취급해서는 안 됩니다.

**언제 유효 속성을 다시 읽어야 합니까?**

로컬 서식, 상위 스타일, 레이아웃 서식, 마스터 서식 또는 프레젠테이션 수준 기본값을 변경한 후 `get_effective`를 다시 호출하십시오. 다음 호출은 서식 계층을 다시 평가하고 현재 유효 결과를 반환합니다.

**레이아웃/마스터 슬라이드를 변경하거나 제거하면 이미 가져온 유효 속성에 영향을 줍니까?**

예, 하지만 변경 사항은 다음 `get_effective` 호출 시 반영됩니다. 상위 서식 소스가 변경되거나 제거되면 이전에 얻은 유효 데이터가 오래될 수 있습니다. `get_effective`를 다시 호출하면 Aspose.Slides가 서식 트리를 재평가하고 결과 글꼴, 색상, 크기 또는 기타 값이 변경될 수 있습니다.

**유효 데이터 객체를 통해 값을 수정할 수 있습니까?**

아니오. 유효 데이터 객체는 계산된 값을 노출할 뿐입니다. 로컬 서식 객체에서 변경하고 다시 `get_effective`를 호출하여 유효 값을 얻으십시오.

**속성이 도형 수준, 레이아웃/마스터, 전역 설정 중 어디에도 설정되지 않은 경우 어떻게 됩니까?**

유효 값은 PowerPoint 및 Aspose.Slides 기본값을 포함하는 기본 메커니즘에 의해 결정됩니다. 이렇게 결정된 값이 현재 유효 데이터의 일부가 됩니다.

**유효 글꼴 값만 보고 어떤 수준에서 크기나 글꼴이 제공됐는지 알 수 있습니까?**

직접적으로는 알 수 없습니다. 유효 데이터는 최종 값을 반환합니다. 출처를 찾으려면 구간, 단락, 텍스트 프레임 및 레이아웃, 마스터, 프레젠테이션 수준의 텍스트 스타일에서 로컬 값을 확인하여 첫 번째 명시적 정의가 어디에 있는지 확인하십시오.

**왜 유효 값이 로컬 값과 동일하게 보입니까?**

로컬 값이 최종 값이 되었기 때문입니다(상위 수준 상속이 필요하지 않았음). 이 경우 유효 값이 로컬 값과 일치합니다.

**언제 유효 속성을 사용하고 언제 로컬 속성만 사용해야 합니까?**

모든 상속이 적용된 후 "렌더링된" 결과가 필요할 때, 예를 들어 색상, 들여쓰기 또는 크기를 맞출 때 유효 데이터를 사용하십시오. 나중에 서식이 변경되더라도 해당 값을 보존해야 한다면 필요한 속성을 자신의 객체에 복사하십시오. 특정 수준에서 서식을 변경해야 할 경우 로컬 속성을 수정하고, 필요하면 유효 데이터를 다시 읽어 결과를 확인하십시오.