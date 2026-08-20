---
title: Python에서 프레젠테이션 도형 관리
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
- 도형 삭제
- 도형 숨기기
- 도형 순서 변경
- interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 서식
- SVG 형식 도형
- 도형을 SVG로
- 도형 정렬
- 도형 플립
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 도형을 식별, 복제, 삭제, 숨기기, 순서 변경, 내보내기, 정렬 및 플립하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET은 슬라이드의 도형을 순서가 지정된 [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/)으로 표현합니다. 이 컬렉션은 도형을 찾고 수정하는 위치이자 레이어 순서의 원천이며, 인덱스 `0`은 가장 뒤에 있는 도형이고 마지막 인덱스는 가장 앞에 있는 도형을 의미합니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 안정적으로 식별하는 방법을 설명하고, 이어서 도형을 복제, 삭제, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 플립 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 검색**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가·삭제·재정렬하면 인덱스가 변경될 수 있습니다. 프레젠테이션이 어떻게 작성·관리되는지에 따라 식별자를 선택하십시오.

- [Shape.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/name/)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정의하십시오.
- [Shape.alternative_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/alternative_text/)은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자에게 표시되며 로컬라이즈되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 조용히 재사용하지 마십시오.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/office_interop_shape_id/)은 슬라이드 내에서 고유한 읽기 전용 식별자로, PowerPoint 인터옵에서 사용하는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 가집니다.

관련된 [Shape.unique_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/unique_id/) 속성은 프레젠테이션 범위를 갖지만, 추가 기능용으로 설계되었으며 재할당될 수 있습니다. 영구적인 외부 키로 취급하지 말아야 합니다. 장기적인 식별이 필요하다면 애플리케이션 데이터에 매핑을 보관하고 기대하는 도형이 여전히 존재하는지 검증하십시오.

다음 예제는 `name`으로 정확히 비교하여 검색하고 슬라이드 범위의 인터옵 ID를 반환합니다. 템플릿에 기대하는 도형이 없을 경우 코드는 잘못된 객체를 계속 사용하지 않고 그 결과를 보고합니다.

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

작업이 특정 도형 유형에 국한되는 경우, 유형별 멤버를 사용하기 전에 타입을 확인하십시오. 이 예제는 명명된 객체가 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

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

## **도형 컬렉션 수정**

추가·복제·삭제·순서 변경 메서드는 컬렉션에 즉시 적용됩니다. 작업으로 인해 도형 수나 순서가 바뀌면, 해당 작업 이전에 저장한 인덱스에 계속 의존하지 마십시오.

### **도형 복제**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_clone/)은 독립적인 복사본을 만들고 대상 컬렉션에 추가합니다. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/insert_clone/)도 복사본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표를 받아들이는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비·높이를 지정하는 오버로드는 크기도 조정할 수 있습니다.

예제는 목적 슬라이드를 만든 뒤 라벨이 붙은 사각형을 앞쪽에 복제하고, 두 번째 복제본을 뒤쪽에 삽입합니다. 두 복제본 중 어느 하나를 변경해도 원본 도형은 영향을 받지 않습니다.

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

복제는 도형의 내용과 서식(이름·대체 텍스트 포함)을 복사합니다. 해당 값이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새로운 컬렉션 항목이자 새로운 도형 ID를 갖습니다.

### **도형 삭제**

[ShapeCollection.remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/remove/)은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스를 사용해 반복하면서 여러 일치를 삭제할 경우, 인덱스가 유효하게 유지되도록 끝부터 순회하십시오.

예제는 지정된 이름을 가진 모든 도형을 삭제합니다. 고정된 컬렉션 항목이 아닌 `slide.shapes[index]`를 읽으며, 불필요하게 형변환하지도 않습니다.

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

삭제 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결선, 애니메이션 등 삭제된 객체를 참조할 수 있는 프레젠테이션 기능도 고려하십시오. 보이는 도형을 삭제하면 슬라이드 외관뿐 아니라 다른 요소에도 영향을 미칠 수 있습니다.

### **도형 숨기기**

[Shape.hidden](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/hidden/)을 `True`로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 나타나지 않습니다. 인덱스·서식·내용은 코드에서 계속 접근 가능하므로, 나중에 복원할 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드도 여전히 도형을 찾아서 보이도록 할 수 있으며, 파일 내에 계속 존재합니다.

### **Z‑Order 변경**

중첩된 도형은 컬렉션 순서대로 그려집니다. [ShapeCollection.reorder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/reorder/)는 복제 없이 기존 도형을 목표 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `len(slide.shapes) - 1`은 앞쪽을 의미합니다.

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

예제에서는 사각형을 먼저 만들고 처음에는 타원 뒤에 배치합니다. 마지막 인덱스로 이동하면 앞쪽에 놓이게 됩니다. 모든 관련 도형을 추가·복제한 뒤에 Z‑order를 최종 설정하십시오. 이러한 작업은 새 컬렉션 항목을 추가하거나 삽입하면서 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 동일한 위치에 있더라도 같은 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경하려면 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [Shape.fill_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/fill_format/)와 [Shape.line_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/line_format/)을 읽으며, 모든 도형이 `AutoShape`라고 가정하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

레이아웃을 편집하면 이를 사용하는 여러 슬라이드에 영향을 미칩니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 해당 객체를 상속하는지 로컬에서 재정의하는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드에서 테스트하십시오.

## **도형을 SVG로 내보내기**

[Shape.write_as_svg](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/)은 하나의 도형이 렌더링된 내용을 스트림에 기록합니다. 결과에는 도형만 포함되며 전체 슬라이드 배경이나 주변 도형은 포함되지 않습니다.

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

렌더링하는 동안 프레젠테이션을 열어 두십시오. 출력은 도형 서식과 글꼴·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아닌 슬라이드를 내보내십시오. 스트림은 호출자가 소유하며 반드시 닫아야 합니다.

## **도형 정렬**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/align_shapes/) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapesalignmenttype/)은 가장자리·중심선·배분 방식을 지정합니다. `align_to_slide`을 `True`로 설정하면 슬라이드 가장자리를 기준으로, `False`로 설정하면 선택된 도형들 간의 상대 정렬을 수행합니다.

예제는 세 도형을 슬라이드의 위쪽 가장자리에 정렬합니다. 현재 인덱스는 정렬 직전에 즉시 확인됩니다.

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

정렬은 위치만 바꾸며 Z‑order에는 영향을 주지 않습니다. 상대 정렬은 일반적으로 두 개 이상의 도형이 필요하고, 수평·수직 배분은 간격을 정의할 충분한 도형이 있어야 합니다. 메서드를 호출하기 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 플립**

[ShapeFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapeframe/) 클래스는 위치·크기·수평·수직 플립 설정·회전을 저장합니다. `flip_h`와 `flip_v` 값은 [NullableBool](https://reference.aspose.com/slides/ko/python-net/aspose.slides/nullablebool/)을 사용하며, `TRUE`는 플립을, `FALSE`는 비활성화를, `NOT_DEFINED`는 지정되지 않거나 기본 상태를 유지합니다.

아래 입력 프레젠테이션은 플립되지 않은 도형 하나를 포함합니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 그대로 유지하면서 두 플립 설정만 교체합니다. 이는 새로운 [Shape.frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/frame/)을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 도형은 위치·크기·회전을 유지한 채 가로·세로로 뒤집혀 있습니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 변하지 않을 짧은 기간 처리에만 사용하십시오. 작성된 템플릿에는 검증된 `name` 또는 `alternative_text` 규칙을, 슬라이드 범위 인터옵 작업에는 `office_interop_shape_id`를 사용하는 것이 좋습니다.

**도형을 숨기면 Z‑order에서 제거되나요?**

아니요. 숨긴 도형은 동일한 인덱스에 남아 있으며, 찾고, 순서를 바꾸고, 편집하거나 다시 표시할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`add_clone`은 복제본을 컬렉션 끝에 추가하므로 Z‑order의 앞쪽에 배치됩니다. 초기 인덱스를 지정하려면 `insert_clone`을 사용하거나 모든 도형을 추가한 뒤 `reorder`로 위치를 조정하십시오.