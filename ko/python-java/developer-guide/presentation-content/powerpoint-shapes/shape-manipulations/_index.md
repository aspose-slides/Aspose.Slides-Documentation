---
title: Python via Java에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/python-java/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 삭제
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 조정점
- 사전 정의 도형 조정
- 도형 기하학
- 도형 레이아웃 서식
- SVG 도형
- 도형을 SVG로
- 도형 정렬
- 도형 플립
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 프레젠테이션 도형을 식별, 조정, 복제, 삭제, 숨기기, 순서 변경, 내보내기, 정렬 및 플립하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via Java은 슬라이드의 도형을 순서가 있는 [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/)으로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 곳이자, 쌓임 순서의 원천이기도 합니다. 인덱스 `0`은 가장 뒤에 있는 도형이며, 마지막 인덱스는 가장 앞에 있는 도형을 의미합니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 안정적으로 식별하고 사전 정의된 도형 조정점을 수정하는 방법을 설명한 뒤, 도형을 복제, 삭제, 숨기기, 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 플립 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 검색**

컬렉션 인덱스는 이미 알려진 파일을 처리할 때 편리하지만, 안정적인 식별자는 아닙니다. 도형을 추가, 삭제 또는 순서를 변경하면 인덱스가 바뀔 수 있습니다. 프레젠테이션이 어떻게 작성·관리되는지에 따라 식별자를 선택하세요.

- [Name](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getName)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드에서 사용하려면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getAlternativeText)은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별하는 경우에 유용합니다. 사용자가 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 무음으로 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getOfficeInteropShapeId)은 슬라이드 내에서 고유하고 PowerPoint interop에서 사용되는 도형 ID와 대응되는 읽기 전용 식별자입니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 다시 만든 도형은 다른 도형이며 자체 ID를 받습니다.

관련 [getUniqueId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getUniqueId) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이는 애드인용이며 재할당될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 정체성이 필요하면 애플리케이션 데이터에 매핑을 유지하고 예상 도형이 여전히 존재하는지 검증하십시오.

다음 예제는 이름을 정확히 비교하여 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 기대한 도형이 없을 경우 코드가 잘못된 객체로 진행되지 않고 해당 결과를 보고합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

작업이 특정 도형 유형에 국한되는 경우, 유형별 멤버를 사용하기 전에 타입을 확인하십시오. 이 예제는 지정된 이름의 객체가 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **사전 정의 도형 조정점 식별 및 수정**

사전 정의 기하학 도형은 모서리 크기, 화살표 비율, 호 각도와 같은 기능을 제어하는 조정점을 노출할 수 있습니다. 읽기 전용 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ko/python-java/aspose.slides/geometryshape/#getAdjustments) 컬렉션을 통해 접근하십시오. 컬렉션 자체는 도형이 제공하지만, 각 [AdjustValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/)는 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정점을 순회하면서 읽기 전용 [getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getType) 메서드를 검사하세요. 이 메서드가 반환하는 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 내용을 설명합니다. 읽기 전용 [getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getName) 메서드는 추가 식별 정보를 제공하며, 동일한 의미 유형이 여러 개 존재할 때 특히 유용합니다.

조정 의미에 맞는 값 메서드를 사용하십시오:

| 조정 유형 | 목적 | 변경할 값 |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | 둥근 모서리 크기 | [setRawValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | 화살표 꼬리 두께 | [setRawValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | 화살표 머리 길이 | [setRawValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | 화살표 머리 너비 | [setRawValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | 파이 또는 호의 시작 각도 | [setAngleValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | 파이 또는 호의 끝 각도 | [setAngleValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getType) 및 [getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getName)은 읽기 전용 정보를 반환합니다. [getRawValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getRawValue)와 [setRawValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setRawValue)는 사전 정의 기하학 단위의 정수를 다루고, [getAngleValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getAngleValue)와 [setAngleValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setAngleValue)는 각도를 도 단위로 다룹니다. 조정점의 수, 순서, 의미 및 유효 범위는 사전 정의된 [ShapeType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/geometryshape/#getShapeType)에 따라 달라집니다. 한 사전에서 유효한 값이 다른 사전에서는 무효이거나 다른 효과를 낼 수 있습니다.

[getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getType) 가 [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeadjustmenttype/#Custom) 을 반환하면 API가 표준 의미를 인식하지 못합니다. [getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getName), 사전 정의 유형 및 기존 값을 검사하고, 기대 의미와 범위가 명확하지 않다면 조정을 변경하지 마십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는지 확인한 뒤 값을 선택하십시오. [Connector](/slides/ko/python-java/connector/) 문서에서 연결자 굽힘 조정 상황을 확인할 수 있습니다.

다음 완전한 예제는 세 개의 사전 정의 도형에 대해 기본 및 수정된 버전을 생성합니다. 모든 조정점을 순회하면서 이름과 유형을 보고, [setRawValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setRawValue) 로 크기 관련 값을, [setAngleValue](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#setAngleValue) 로 각도를 변경하고 결과를 저장합니다. 왼쪽 열은 기본 기하학을 유지하고, 오른쪽 열은 조정된 둥근 사각형, 사방향 화살표, 파이를 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 기본 및 조정된 도형 열에 대한 헤더를 추가합니다.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

값을 변경하기 전에 의미 유형을 확인하면 코드 의도가 명확해지고, 서로 다른 사전 정의 도형에서 같은 컬렉션 인덱스가 동일한 의미를 가진다고 가정하는 실수를 방지합니다.

## **도형 컬렉션 수정**

추가, 복제, 삭제 및 순서 변경 메서드는 즉시 컬렉션에 적용됩니다. 작업이 도형 수나 순서를 변경한다면, 그 이전에 캡처한 인덱스에 계속 의존하지 마십시오.

### **도형 복제**

[addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addClone) 은 독립적인 복제본을 생성하고 대상 컬렉션에 추가합니다. [insertClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#insertClone) 도 복제본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표만 받는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비·높이를 받는 오버로드는 크기도 조정합니다.

예제는 대상 슬라이드를 만들고, 라벨이 지정된 사각형을 앞쪽에 복제한 뒤, 두 번째 복제본을 뒤쪽에 삽입합니다. 각각의 복제본을 변경해도 원본 도형은 영향을 받지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

복제는 도형의 내용과 서식(이름·대체 텍스트 포함)을 복사합니다. 이러한 값이 고유해야 한다면 복제본에 새 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새 컬렉션 항목이자 새로운 도형 ID를 갖습니다.

### **도형 삭제**

[remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#remove) 은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스로 순회하면서 여러 일치를 삭제할 경우, 남아 있는 인덱스가 유효하도록 끝에서부터 순회하십시오.

이 예제는 지정된 이름을 가진 모든 도형을 삭제합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스의 도형을 읽고, 불필요하게 형 변환하지도 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

삭제 후에는 도형 수와 이후 도형들의 인덱스가 변합니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결자, 애니메이션 등 삭제된 객체를 참조할 수 있는 프레젠테이션 기능을 고려하십시오; 보이는 도형을 삭제하면 슬라이드 외관 이상의 변화가 발생할 수 있습니다.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setHidden) 을 `True` 로 설정하면 도형은 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스·서식·내용은 코드에서 그대로 접근 가능하므로, 나중에 복구할 수 있는 선택적 요소에 적합합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드도 도형을 찾아 다시 표시할 수 있으며, 파일 내에 계속 존재합니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [reorder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#reorder) 은 복제하지 않고 기존 도형을 목표 인덱스로 이동합니다. 인덱스 `0` 은 뒤쪽이며, 컬렉션 [size](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#size)‑1 은 앞쪽입니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

사각형을 먼저 만든 뒤 타원 뒤에 배치합니다. 최종 인덱스로 이동하면 앞쪽에 놓이게 됩니다. 모든 관련 도형을 추가·복제한 뒤에 Z‑order를 최종화하십시오. 이러한 작업은 새로운 컬렉션 항목을 추가하거나 삽입해 스택 순서를 바꿀 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 같은 위치에 있더라도 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getFillFormat) 및 [LineFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getLineFormat) 을 읽으며, 모든 도형이 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 라는 가정 없이 처리합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 해당 객체를 상속하는지 로컬 오버라이드가 있는지 확인하고, 레이아웃을 사용하는 모든 슬라이드에서 테스트하십시오.

## **도형을 SVG로 내보내기**

[Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 의 `writeAsSvg` 메서드는 하나의 도형 렌더링 내용을 스트림에 기록합니다. 결과는 해당 도형만 포함하며 전체 슬라이드 배경이나 인접 도형은 포함하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

렌더링 중에는 프레젠테이션을 열어 두어야 합니다. 출력은 도형 서식과 폰트·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 호출자는 스트림을 소유하므로 반드시 닫아야 합니다.

## **도형 정렬**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideutil/#alignShapes) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapesalignmenttype/) 은 가장자리·센터선·분배 모드를 지정합니다. `align_to_slide` 를 `True` 로 설정하면 슬라이드 가장자리를 기준으로, `False` 로 설정하면 선택된 도형끼리 상대적으로 정렬합니다.

예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

정렬은 위치만 바꾸고 Z‑order는 변경하지 않습니다. 상대 정렬은 일반적으로 두 개 이상의 도형이 필요하고, 수평·수직 분배는 간격을 정의할 충분한 도형이 필요합니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 플립**

[ShapeFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeframe/) 클래스는 위치·크기·수평·수직 플립 설정·회전을 저장합니다. 그의 [getFlipH](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeframe/#getFlipH) 와 [getFlipV](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapeframe/#getFlipV) 값은 [NullableBool](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/) 로 표현되며, `True` 가 플립을 활성화하고, `False` 가 비활성화하며, `NotDefined` 가 지정되지 않음/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 플립되지 않은 도형 하나가 포함되어 있습니다.

![플립 전 도형](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하면서 두 플립 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setFrame) 을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

저장된 도형은 위치·크기·회전을 유지한 채 가로·세로로 좌우 반전됩니다.

![플립 후 도형](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 변경되지 않을 짧은 처리를 제외하고는 사용하지 마십시오. 작성된 템플릿에는 검증된 [Name](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getName) 또는 [AlternativeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getAlternativeText) 규칙을, 슬라이드 범위 interop 작업에는 [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getOfficeInteropShapeId) 를 선호하십시오.

**도형을 숨기면 Z‑order에서 제거되나요?**

아니요. 숨겨진 도형은 동일 인덱스에 남아 있으며, 찾아서 순서를 바꾸거나 편집하거나 다시 보이게 할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

[addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addClone) 은 복제본을 컬렉션 끝에 추가하는데, 이는 Z‑order 의 앞쪽에 해당합니다. 초기 인덱스를 지정하려면 [insertClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#insertClone) 을 사용하거나, 모든 도형을 추가한 뒤 [reorder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#reorder) 로 조정하십시오.

**고정 인덱스로 사전 정의 도형 조정점을 식별해도 될까요?**

정확한 사전 정의와 컬렉션 레이아웃을 검증한 경우에만 가능합니다. 일반적으로는 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ko/python-java/aspose.slides/geometryshape/#getAdjustments) 를 순회하며 [AdjustValue.getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getType) 을 확인하고, 동일 의미 유형이 여러 번 나타날 경우 [AdjustValue.getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/adjustvalue/#getName) 을 추가 정보로 활용하십시오.