---
title: Python을 사용한 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/python-net/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 조정점
- 프리셋 도형 조정
- 도형 기하학
- 도형 레이아웃 서식
- SVG 형식 도형
- 도형을 SVG로 변환
- 도형 정렬
- 도형 플립
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 도형을 식별하고, 조정하고, 복제하고, 제거하고, 숨기고, 재정렬하고, 내보내고, 정렬하고, 플립하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET는 슬라이드의 도형을 순서가 지정된 [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/)으로 나타냅니다. 컬렉션은 도형을 찾고 수정하는 장소이자, 도형의 쌓임 순서의 원천입니다: 인덱스 `0`은 가장 뒤쪽 도형이며, 마지막 인덱스는 가장 앞쪽 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 안정적으로 식별하고 사전 설정된 도형 조정점을 수정하는 방법을 설명하고, 이후 도형을 복제, 제거, 숨기기 및 재정렬하는 방법을 보여 줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 플립 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가·제거·재정렬하면 인덱스가 변경될 수 있습니다. 프레젠테이션이 작성·유지 관리되는 방식에 따라 식별자를 선택하십시오.

- [Shape.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/name/) 은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [Shape.alternative_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/alternative_text/) 은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자가 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 은밀히 재사용하지 마십시오.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/office_interop_shape_id/) 은 슬라이드 내에서 고유한 읽기 전용 식별자로 PowerPoint interop에서 사용되는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 가집니다.

관련 [Shape.unique_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/unique_id/) 속성은 프레젠테이션 범위를 갖지만, 애드인 용도로 설계되었으며 재할당될 수 있습니다. 영구적인 외부 키로 취급하지 마십시오. 장기적인 식별이 필요하면 애플리케이션 데이터에 매핑을 보관하고 기대하는 도형이 여전히 존재하는지 확인하십시오.

다음 예제는 `name`을 정확히 비교하여 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 기대하는 도형이 없을 경우 코드가 잘못된 객체로 진행되지 않고 해당 결과를 보고합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

작업이 도형 유형에 특화된 경우, 유형별 멤버를 사용하기 전에 타입을 확인하십시오. 이 예제는 명명된 객체가 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)일 때만 텍스트와 대체 텍스트를 업데이트합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **프리셋 도형 조정 식별 및 수정**

프리셋 기하학 도형은 코너 크기, 화살표 비율, 호 각도 등 기능을 제어하는 조정점을 노출할 수 있습니다. 읽기 전용 [GeometryShape.adjustments](https://reference.aspose.com/slides/ko/python-net/aspose.slides/geometryshape/adjustments/) 컬렉션을 통해 접근하십시오. 컬렉션 자체는 도형이 제공하지만, 각 [AdjustValue](https://reference.aspose.com/slides/ko/python-net/aspose.slides/adjustvalue/)에는 변경 가능한 값이 들어 있습니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정값을 반복하면서 읽기 전용 [AdjustValue.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/adjustvalue/type/) 속성을 확인하십시오. 이 속성의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapeadjustmenttype/) 값이 조정이 제어하는 내용을 설명합니다. 읽기 전용 [AdjustValue.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/adjustvalue/name/) 속성은 추가 식별 정보를 제공하며, 동일한 의미 유형을 가진 조정이 여러 개 있는 경우 특히 유용합니다.

조정 의미에 맞는 값 속성을 사용하십시오:

| 조정 유형 | 목적 | 변경할 값 |
|---|---|---|
| `CORNER_SIZE` | 둥근 모서리 크기 | [raw_value](https://reference.aspose.com/slides/ko/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | 화살표 꼬리 두께 | `raw_value` |
| `ARROWHEAD_LENGTH` | 화살표 머리 길이 | `raw_value` |
| `ARROWHEAD_WIDTH` | 화살표 머리 너비 | `raw_value` |
| `START_ANGLE` | 파이 또는 호의 시작 각도 | [angle_value](https://reference.aspose.com/slides/ko/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | 파이 또는 호의 끝 각도 | `angle_value` |

`type`과 `name`은 할당할 수 없습니다. `raw_value`는 프리셋 고유의 기하학 단위 정수이며 읽기/쓰기 가능하고, `angle_value`는 도 단위 각도로 읽기/쓰기 가능합니다. 조정의 개수, 순서, 의미 및 유효 범위는 프리셋 [GeometryShape.shape_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/geometryshape/shape_type/)에 따라 다릅니다. 한 프리셋에 유효한 값이 다른 프리셋에서는 무효이거나 다른 효과를 낼 수 있습니다.

`type`이 `ShapeAdjustmentType.CUSTOM`인 경우, API는 표준 의미를 인식하지 못합니다. `name`, 프리셋 유형 및 기존 값을 검사하고, 기대 의미와 범위를 알지 못한다면 조정을 변경하지 마십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는지 확인한 뒤 값을 선택하십시오. [Connector](/slides/ko/python-net/connector/) 문서에는 커넥터 굽힘 조정 상황이 나와 있습니다.

다음 완전한 예제는 세 가지 프리셋 도형의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 `name`과 `type`을 보고, `raw_value`로 크기 관련 값을, `angle_value`로 각도를 변경하고 결과를 저장합니다. 왼쪽 열은 기본 기하학을 유지하고, 오른쪽 열은 조정된 둥근 직사각형, 사방향 화살표 및 파이를 보여 줍니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 기본 및 조정된 도형 열에 대한 헤더를 추가합니다.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 드러내고, 다른 프리셋 도형에서 동일한 컬렉션 인덱스가 같은 의미를 가진다고 가정하는 오류를 방지합니다.

## **도형 컬렉션 수정**

추가, 복제, 제거 및 재정렬 메서드는 컬렉션에 즉시 적용됩니다. 작업으로 인해 도형 수나 순서가 바뀌면, 해당 작업 전후에 캡처한 인덱스에 의존하지 마십시오.

### **도형 복제**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_clone/) 은 독립적인 복사본을 생성하고 대상 컬렉션에 추가합니다. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/insert_clone/) 도 복사본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표를 받는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비·높이 매개변수를 받는 오버로드는 크기도 조정합니다.

예제는 대상 슬라이드를 만든 뒤 라벨이 붙은 직사각형을 앞쪽에 복제하고, 두 번째 복제본을 뒤쪽에 삽입합니다. 각 복제본에 대한 변경은 원본 도형에 영향을 주지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

복제는 도형의 내용과 서식, 이름 및 대체 텍스트를 포함합니다. 이러한 값이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 처리하지만, 복제본은 새로운 컬렉션 항목이며 새로운 도형 ID를 갖습니다.

### **도형 제거**

[ShapeCollection.remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/remove/) 은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스 기반 반복 중 여러 매치를 제거할 경우, 남은 인덱스가 유효하도록 끝에서부터 순회하십시오.

예제는 지정된 이름을 가진 모든 도형을 제거합니다. 고정된 컬렉션 항목이 아니라 `slide.shapes[index]` 를 읽으며, 불필요한 형 변환도 하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

제거 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 커넥터, 애니메이션 등 제거된 객체를 참조할 수 있는 프레젠테이션 기능을 고려하십시오; 보이는 도형을 제거하면 슬라이드 외관 외에도 다른 요소가 변경될 수 있습니다.

### **도형 숨기기**

[Shape.hidden](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/hidden/) 을 `True` 로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스·서식·내용은 코드에서 여전히 접근 가능하므로, 나중에 복원될 수 있는 선택적 요소에 적합합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드도 해당 객체를 찾아 다시 보이게 할 수 있으며, 파일에 그대로 남아 있습니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [ShapeCollection.reorder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/reorder/) 은 복제하지 않고 기존 도형을 목표 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `len(slide.shapes) - 1`은 앞쪽을 의미합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

직사각형을 먼저 만들면 처음에는 타원 뒤에 배치됩니다. 최종 인덱스로 이동하면 앞쪽에 놓입니다. 모든 관련 도형을 추가·복제한 뒤에 z‑order 를 최종 정리하십시오. 이러한 작업은 새로운 컬렉션 항목을 추가하거나 삽입하면서 스택을 바꿀 수 있습니다.

## **레이아웃 슬라이드에서 도형 검사**

일반 슬라이드·레이아웃 슬라이드·마스터 슬라이드는 각각 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드의 동일 위치 도형과 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [Shape.fill_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/fill_format/) 및 [Shape.line_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/line_format/) 을 읽으며, 모든 도형이 `AutoShape`이라고 가정하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속하는지 혹은 로컬 오버라이드가 있는지 판단하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG로 내보내기**

[Shape.write_as_svg](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/) 은 하나의 도형이 렌더링된 콘텐츠를 스트림에 기록합니다. 결과에는 해당 도형만 포함되며 전체 슬라이드 배경이나 인접 도형은 포함되지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

렌더링 중에는 프레젠테이션을 열어 두어야 합니다. 출력은 도형 서식 및 폰트·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 스트림의 소유자는 스트림을 닫아야 합니다.

## **도형 정렬**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/align_shapes/) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapesalignmenttype/) 은 가장자리, 중심선 또는 배치 모드를 지정합니다. `align_to_slide` 를 `True` 로 설정하면 슬라이드 가장자리를 기준으로, `False` 로 하면 선택한 도형 간의 상대 정렬을 수행합니다.

예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 현재 인덱스는 정렬 직전에 즉시 해결됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

정렬은 위치를 변경하지만 z‑order는 바꾸지 않습니다. 상대 정렬은 일반적으로 두 개 이상의 도형이 필요하며, 가로나 세로 배치는 충분한 도형이 있어야 간격을 정의할 수 있습니다. 메서드 호출 전 컬렉션을 수정했다면 인덱스를 재계산하십시오.

## **도형 플립**

[ShapeFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapeframe/) 클래스는 위치·크기·수평·수직 플립 설정·회전을 저장합니다. `flip_h`·`flip_v` 값은 [NullableBool](https://reference.aspose.com/slides/ko/python-net/aspose.slides/nullablebool/) 을 사용합니다: `TRUE` 는 플립을 활성화하고, `FALSE` 는 비활성화하며, `NOT_DEFINED` 은 지정되지 않거나 기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 플립되지 않은 도형 하나가 포함되어 있습니다.

![플립하기 전 도형](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하면서 두 플립 설정만 교체합니다. 이는 새로운 [Shape.frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/frame/) 을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

저장된 도형은 위치·크기·회전을 유지한 채 가로·세로로 미러링됩니다.

![플립 후 도형](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 변하지 않을 짧은 처리 과정에만 사용하십시오. 작성된 템플릿에는 검증된 `name` 또는 `alternative_text` 규칙을, 슬라이드 범위의 interop 작업에는 `office_interop_shape_id` 를 사용하는 것이 좋습니다.

**도형을 숨기면 z‑order에서도 제거되나요?**

아니오. 숨긴 도형은 동일한 인덱스에 남아 있으며, 찾기·재정렬·편집·다시 표시가 가능합니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`add_clone` 은 복제본을 컬렉션 끝에 추가하므로 z‑order 의 앞쪽에 배치됩니다. 초기 인덱스를 지정하려면 `insert_clone` 을 사용하거나 모든 도형을 추가한 뒤 `reorder` 로 조정하십시오.

**프리셋 도형 조정을 식별하기 위해 고정 인덱스를 사용할 수 있나요?**

정확한 프리셋과 컬렉션 레이아웃을 검증한 경우에만 가능합니다. 일반적으로 `GeometryShape.adjustments` 를 반복하면서 `AdjustValue.type` 을 확인하고, 동일한 의미 유형이 여러 번 나타날 때는 `AdjustValue.name` 을 추가 정보로 활용하십시오.