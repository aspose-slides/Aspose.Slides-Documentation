---
title: Python을 사용하여 Java로 프레젠테이션에서 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/python-java/shape-effective-properties/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 로컬, 상속 및 유효 도형 서식을 구분하는 방법을 배웁니다."
---
## **로컬, 상속 및 유효 속성 이해**

PowerPoint 서식은 여러 출처에서 올 수 있습니다. 객체에 직접 저장된 값은 **로컬 값**입니다. 해당 값이 설정되지 않으면 PowerPoint는 단락 기본값, 텍스트 스타일, 레이아웃 또는 마스터 슬라이드, 테마, 프레젠테이션 수준 기본값과 같은 상위 서식 소스를 확인합니다. 이러한 값은 **상속 값**입니다. 전체 계층 구조가 해결된 후 남는 값이 **유효 값**이며—객체를 렌더링하는 데 사용되는 값입니다.

예를 들어, 텍스트 구간이 자체 폰트 높이를 정의하지 않을 수 있습니다. 해당 구간의 로컬 [getFontHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#getFontHeight) 값은 `float("nan")`이며, 이는 “여기에서 설정되지 않음”을 의미합니다. 구간은 단락, 프레젠테이션의 기본 텍스트 스타일 또는 다른 적용 가능한 소스에서 높이를 상속받을 수 있습니다. 구간 형식에서 [getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#getEffective) 을 호출하면 최종 해결된 높이가 반환됩니다.

다음 두 종류의 서식 데이터를 다양한 목적에 사용하십시오:

- 값이 정의된 위치를 제어해야 할 때와 같이 로컬 형식 객체(예: [PortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/))를 읽거나 변경합니다.
- 최종 렌더링 결과가 필요할 때와 같이 `PortionFormatEffectiveData`와 같은 유효 데이터 객체를 읽습니다. 유효 데이터는 읽기 전용입니다.

## **로컬, 상속 및 유효 값 비교**

다음 전체 예제는 도형을 생성하고 프레젠테이션, 단락 및 구간 수준에서 폰트 높이를 적용합니다. 각 단계에서는 해당 수준에서 정의된 값을 출력하고 동일한 텍스트 구간에 대한 결과 유효 값을 표시합니다. 또한 서식 변경 후 유효 데이터를 다시 읽어야 하는 이유를 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # 이전 변경 후에 유효 데이터를 읽습니다.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # 두 가지 다른 수준에서 상속 값을 정의합니다.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 구간의 로컬 값이 두 상속 값을 모두 덮어씁니다.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 상속 값을 변경해도 기존 로컬 값을 덮어쓰지 않습니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # 로컬 값을 지웁니다. 이제 구간이 다시 단락에서 상속받습니다.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 단락 값을 지웁니다. 이제 프레젠테이션 기본값이 결과를 제공합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 예제에서 우선순위는 구간 로컬 서식, 그 다음 단락 서식, 마지막으로 프레젠테이션 기본값입니다. 다른 객체는 다른 상속 체인을 가질 수 있지만 원리는 동일합니다: 보다 구체적인 명시적 값이 우선하며, [getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#getEffective) 은 최종 결과를 반환합니다.

## **유효 텍스트 속성 가져오기**

텍스트 서식은 여러 객체에 분산되어 있습니다:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#getEffective) 은 여백, 고정, 자동 맞춤, 수직 텍스트 방향과 같은 텍스트 프레임 속성을 해결합니다.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textstyle/#getEffective) 은 각 텍스트 스타일 수준에 대한 단락 서식을 해결합니다.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#getEffective) 은 정렬, 들여쓰기, 글머리표와 같은 단락 속성을 해결합니다.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#getEffective) 은 폰트 높이, 글꼴, 색상, 굵게 및 기울임과 같은 문자 속성을 해결합니다.

다음 예제에서는 `text-formatting.pptx`에 최소 하나의 슬라이드와 비어 있지 않은 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)이 포함되어 있어야 합니다. AutoShape는 도형 컬렉션의 어느 위치에든 나타날 수 있으며, 코드는 사용 전에 적절한 객체를 검색하고 검증합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **유효 3D 속성 가져오기**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/threedformat/#getEffective) 은 모든 해결된 3D 설정을 그룹화한 하나의 `ThreeDFormatEffectiveData` 객체를 반환합니다. 이 객체의 `getCamera`, `getLightRig`, `getBevelTop`, `getBevelBottom` 메서드는 해당 유효 데이터를 제공합니다. 이러한 관련 설정을 함께 읽으면 도형의 최종 3D 모양을 이해하기가 쉬워집니다.

이 예제에서는 `shape-3d.pptx`의 첫 번째 슬라이드에 최소 하나의 도형이 포함되어 있어야 합니다. 기본값이 아닌 값을 출력에 포함하려면 해당 도형에 3D 카메라, 조명 또는 베벨 설정을 적용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **유효 테이블 서식 가져오기**

테이블 서식은 테이블 스타일과 전체 테이블, 열, 행 또는 개별 셀에 적용된 서식에서 올 수 있습니다. 명시적으로 정의된 채우기 간 충돌이 있을 경우 우선순위는 셀, 행, 열, 그리고 전체 테이블 순입니다. 셀의 유효 서식은 해당 셀을 그리는 데 사용되는 최종 서식입니다.

이 예제에서는 `table-formatting.pptx`의 첫 번째 슬라이드에 최소 하나의 테이블이 포함되어 있어야 합니다. 테이블은 최소 하나의 행과 하나의 열을 가져야 합니다. 코드는 `getShapes().get_Item(0)`이 테이블이라고 가정하는 대신 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 을 검색합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

채우기 유형뿐만 아니라 색상이 필요한 경우 먼저 유효 `getFillType` 을 확인한 다음 해당 유형에 적용되는 메서드(예: 단색 채우기의 경우 `getSolidFillColor`)를 읽습니다.

## **변경 후 유효 데이터 다시 읽기**

유효 데이터는 해결된 시점의 서식 계층 구조를 설명합니다. 아래와 같은 서식 요소를 변경한 후에는 [getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#getEffective) 을 다시 호출하십시오:

- 객체의 로컬 서식;
- 단락 또는 텍스트 프레임 기본값;
- 테이블 스타일, 테이블, 열, 행 또는 셀 서식;
- 레이아웃 또는 마스터 슬라이드 서식;
- 테마 데이터 또는 프레젠테이션 수준 기본값;
- 슬라이드에 할당된 레이아웃 또는 마스터.

유효 데이터 객체를 영구적인 스냅샷으로 보관하지 마십시오. Aspose.Slides는 내부적으로 일부 유효 데이터를 캐시할 수 있으며, 이후 [getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#getEffective) 호출은 해당 데이터를 새로 고칠 수 있습니다. 변경 전후의 값을 비교해야 하는 경우, 변경하기 전에 필요한 스칼라 값(예: 폰트 높이, 색상, 정렬 또는 베벨 폭)을 자체 변수에 복사하십시오.

값을 변경하려면 해당 로컬 형식 객체를 업데이트한 다음 [getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#getEffective) 를 호출하여 결과를 확인합니다. 유효 데이터 객체 자체는 읽기 전용입니다.

## **FAQ**

**어떤 수준이 유효 값을 제공했는지 어떻게 알 수 있나요?**

유효 데이터에는 최종 값만 포함되고 원본은 포함되지 않습니다. 가장 구체적인 수준부터 외부로 적용 가능한 로컬 객체를 확인하십시오. 텍스트의 경우 구간, 단락, 텍스트 프레임, 레이아웃, 마스터, 테마 및 프레젠테이션 기본값이 포함될 수 있습니다. `float("nan")` 또는 `None`와 같은 정의되지 않은 값은 검색이 다른 수준으로 계속 진행됨을 나타냅니다.

**어떤 수준에서도 속성을 정의하지 않으면 어떻게 됩니까?**

Aspose.Slides는 적절한 PowerPoint 또는 라이브러리 기본값을 해결합니다. 해당 해결된 값은 로컬 객체가 명시적으로 정의하지 않았더라도 유효 데이터에 나타납니다.

**왜 유효 값이 때때로 로컬 값과 동일합니까?**

로컬 값이 상속 계산에서 우선했기 때문입니다. 해당 속성이 객체에 명시적으로 설정되고 더 구체적인 규칙이 이를 덮어쓰지 않을 경우에 예상되는 동작입니다.

**언제 로컬 데이터를 사용하고 유효 데이터를 사용하지 않아야 할까요?**

특정 서식 수준을 검사하거나 편집하려면 로컬 데이터를 사용하십시오. 상속, 테마 규칙 및 적용 가능한 스타일이 해결된 후 최종 모습을 필요로 할 때는 유효 데이터를 사용합니다. [전체 비교 예제](#compare-local-inherited-and-effective-values) 가 동일한 워크플로에서 두 가지를 모두 보여줍니다.