---
title: Python으로 프레젠테이션에서 연결자 관리
linktitle: 연결자
type: docs
weight: 10
url: /ko/python-net/connector/
keywords:
- 연결자
- 연결자 유형
- 연결자 포인트
- 연결자 선
- 연결자 각도
- 연결 사이트
- 조정점
- 도형 연결
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 .NET 환경에서 직선, 굽은 및 곡선 PowerPoint 연결자를 추가, 연결, 재경로 지정, 조정 및 검사하는 방법을 배웁니다."
---
## **개요**

연결자는 두 도형 중 하나가 이동해도 두 도형에 계속 붙어 있을 수 있는 선입니다. 끝부분은 PowerPoint에서 녹색 점으로 표시되는 연결 사이트에 연결됩니다. 일부 굽은 연결자와 곡선 연결자는 주황색 점으로 표시되는 조정점을 노출하여 개별 연결자 세그먼트의 위치를 제어합니다.

Aspose.Slides는 연결자를 [IConnector](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iconnector/) 인터페이스를 통해 나타냅니다. 연결자를 생성하고, 끝을 도형에 연결하고, 연결 사이트를 선택하고, 경로를 다시 지정하며, 조정점을 가진 연결자의 기하학을 수정할 수 있습니다.

## **연결자 유형**

[ShapeType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapetype/) 열거형에는 직선, 굽은, 곡선 연결자 프리셋이 포함되어 있습니다. 다음 표는 사용 가능한 연결자 기하학과 각 프리셋이 정의하는 조정점 수를 보여줍니다.

| 연결자 | 이미지 | 조정점 수 |
|---|---|---|
| `ShapeType.LINE` | ![연결자-직선](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![연결자-직선연결자1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![연결자-굽은연결자2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![연결자-굽은연결자3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![연결자-굽은연결자4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![연결자-굽은연결자5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![연결자-곡선연결자2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![연결자-곡선연결자3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![연결자-곡선연결자4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![연결자-곡선연결자5](shapetype.curvedconnector5.png) | 3 |

조정점의 수와 의미는 선택한 연결자 프리셋에 따라 다릅니다. 두 가지 다른 연결자 유형이 동일한 컬렉션 레이아웃을 제공한다고 가정하지 마십시오.

## **두 개의 도형 연결**

[IShapeCollection.add_connector](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapecollection/add_connector/)을 사용하여 연결자를 추가하고, 해당 연결자의 [start_shape_connected_to](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iconnector/start_shape_connected_to/) 및 [end_shape_connected_to](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iconnector/end_shape_connected_to/) 속성을 할당합니다. 양쪽 끝이 모두 연결된 후, [IConnector.reroute](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iconnector/reroute/)을 호출하면 도형 사이의 짧은 경로가 선택됩니다.

다음 예제는 타원과 사각형을 굽은 연결자로 연결합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="경고" %}}
`reroute`를 호출하면 [start_shape_connection_site_index](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) 및 [end_shape_connection_site_index](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) 값이 변경될 수 있습니다. 해당 사이트를 고정해야 하는 경우, 재경로 지정 후에 특정 연결 사이트를 다시 할당하십시오.
{{% /alert %}}

## **연결 사이트 선택**

각 연결 가능한 도형은 [connection_site_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides/igeometryshape/connection_site_count/)를 통해 사이트 수를 보고합니다. 원하는 0부터 시작하는 사이트 인덱스를 연결자 끝에 할당하기 전에 유효성을 검사하십시오. 사이트 수는 도형 기하학에 따라 다릅니다.

다음 예제는 해당 사이트가 존재할 경우 타원의 특정 사이트에 연결자를 연결합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **연결자 포인트 조정**

조정점을 가진 연결자는 [IGeometryShape.adjustments](https://reference.aspose.com/slides/ko/python-net/aspose.slides/igeometryshape/adjustments/)를 통해 노출됩니다. 각 [IAdjustValue](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iadjustvalue/)를 조사하고, 값을 변경하기 전에 그 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iadjustvalue/type/)을 확인하십시오. 일반 도형 조작에 대해서는 [도형 조작](/slides/ko/python-net/shape-manipulations/)을 참조하십시오.

연결자 조정의 수, 순서, 의미 및 유효 값 범위는 연결자 프리셋에 따라 다릅니다. `type` 속성은 읽기 전용이며, 조정값은 쓰기 가능합니다. 동일한 의미 유형이 여러 개 존재할 경우 추가 식별을 위해 읽기 전용 [name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iadjustvalue/name/) 속성을 사용할 수 있습니다.

### **장애물 우회**

다음 레이아웃에서 `ShapeType.BENT_CONNECTOR5` 연결자는 두 도형 사이에 있는 세 번째 도형을 통과합니다.

![장애물-우회](connector-obstruction.png)

이 코드는 방해받는 연결자를 생성합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

수직 굽힘을 이동하면 경로가 변경되어 연결자가 장애물을 우회합니다.

![장애물-우회-해결](connector-obstruction-fixed.png)

컬렉션 인덱스 `1`이 항상 수직 굽힘을 의미한다는 가정 대신, 이 예제는 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`를 찾아 기대되는 의미 유형이 존재할 때만 값을 변경합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

`ShapeType.BENT_CONNECTOR5`에는 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` 조정이 두 개, `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` 조정이 하나 있습니다. 필요한 유형이 여러 번 나타나는 경우, `name`과 해당 프리셋의 알려진 기하학을 검사한 후에 선택하십시오. 조정이 [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapeadjustmenttype/)를 반환하면 의미와 범위는 프리셋별이며, 계약이 확인될 때까지 변경하지 마십시오.

## **조정값을 연결자 기하학과 연관시키기**

굽은 연결자의 경우, 조정값을 사용하여 개별 세그먼트 위치를 추정할 수 있습니다. 이러한 계산은 연결자 프리셋에 특화됩니다.

- `ShapeType.BENT_CONNECTOR4`는 일반적으로 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X`와 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` 조정을 각각 하나씩 노출합니다.
- 이러한 굽힘 위치에 대해 `raw_value / 100000`을 적용하면 아래 예제에서 사용되는 연결자 프레임 너비 또는 높이의 비율이 됩니다.
- 연결자 프레임은 회전하거나 뒤집을 수 있으므로, 프레임 좌표를 슬라이드 좌표와 비교하기 전에 변환해야 합니다.

다음 예제는 먼저 `type`을 사용해 조정을 식별합니다. 컬렉션 인덱스를 휴대용 식별자로 사용하지 않습니다.

### **회전되지 않은 연결자**

초기 레이아웃은 `ShapeType.BENT_CONNECTOR4`로 연결된 두 텍스트 도형을 포함합니다.

![연결자-복합-구조](connector-shape-complex.png)

이 예제는 연결자를 검사하고 수평 및 수직 굽힘 조정을 얻습니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

두 굽힘을 모두 변경하려면 각 예상 유형을 찾아 두 값을 모두 찾은 후에만 수정하십시오.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

그 결과 수평 및 수직 세그먼트가 이동한 연결자를 얻을 수 있습니다.

![조정-연결자-1](connector-adjusted-1.png)

의미 유형을 알게 되면 해당 값을 연결자 프레임 좌표로 변환할 수 있습니다. 이 예제는 두 굽힘 조정이 제어하는 수직 세그먼트 위에 얇은 사각형을 그립니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

가이드 도형은 계산된 세그먼트를 표시합니다.

![조정-연결자-2](connector-adjusted-2.png)

### **회전 또는 뒤집힌 연결자**

같은 연결자 기하학이 수직으로 배치될 때, [frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapeframe/flip_h/), [flip_v](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishapeframe/flip_v/) 값이 연결자 프레임 좌표를 슬라이드 좌표로 변환하는 방식에 영향을 줍니다.

이 예제는 수직으로 배치된 연결자를 만들고 조정합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

조정된 연결자는 도형 사이에 수직으로 표시됩니다.

![조정-연결자-3](connector-adjusted-3.png)

임의의 회전 각도 `alpha`에 대해, 프레임 중심 `(x0, y0)`를 기준으로 연결자 프레임 점 `(x, y)`를 회전하면:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

다음 코드는 이 예제에서 사용된 90도 방향을 처리하고 해당 연결자 세그먼트 위에 빨간 가이드를 그립니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

좌표 변환 후 계산된 세그먼트를 빨간 가이드가 표시합니다.

![조정-연결자-4](connector-adjusted-4.png)

이 공식들은 예제에 사용된 프리셋을 설명할 뿐, 보편적인 연결자 모델을 의미하지 않습니다. 다른 프리셋에 동일한 계산을 적용하기 전에 조정 유형, 프레임 방향 및 값 범위를 확인하십시오.

## **연결자 방향 각도 찾기**

직선 연결자는 너비와 높이, 그리고 수평·수직 뒤집기를 고려하여 방향을 계산할 수 있습니다. 다음 예제는 슬라이드 좌표계에서 양의 수평 축을 기준으로 시계 방향 각도를 보고합니다.

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**연결자가 도형에 연결될 수 있는지 어떻게 확인합니까?**

도형의 [connection_site_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides/igeometryshape/connection_site_count/)를 확인하십시오. 양수 값이면 도형이 연결 사이트를 노출한다는 의미입니다. 연결자 끝에 할당하기 전에 선택한 사이트 인덱스를 검증하십시오.

**연결자 조정을 컬렉션 인덱스로 식별할 수 있습니까?**

인덱스는 알려진 연결자 프리셋 및 컬렉션 레이아웃에 대해서만 의미가 있습니다. 값을 수정하기 전에 [IAdjustValue.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iadjustvalue/type/)을 확인하고, 동일한 의미 유형이 여러 번 나타나는 경우 [IAdjustValue.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iadjustvalue/name/)을 추가 정보로 활용하십시오.

**연결된 도형이 삭제되면 어떻게 됩니까?**

해당 연결자의 끝이 분리됩니다. 연결자는 슬라이드에 남아 있으며 삭제하거나 자유 선으로 배치하거나 다른 도형에 다시 연결할 수 있습니다.

**슬라이드를 복사할 때 연결자 바인딩이 유지됩니까?**

연결된 도형과 함께 슬라이드를 복사하면 바인딩이 일반적으로 유지됩니다. 연결자를 복사했지만 대상 도형 중 하나가 없을 경우, 해당 끝을 다시 연결해야 합니다.