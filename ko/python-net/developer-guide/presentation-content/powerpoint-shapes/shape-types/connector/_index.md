---
title: Python을 사용한 프레젠테이션에서 연결기 관리
linktitle: 연결기
type: docs
weight: 10
url: /ko/python-net/connector/
keywords:
- 연결기
- 연결기 유형
- 연결점
- 연결선
- 연결기 각도
- 도형 연결
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python 애플리케이션이 PowerPoint 및 OpenDocument 슬라이드에서 선을 그리고, 연결하고, 자동 라우팅하도록 지원하여 직선, 팔꿈치 및 곡선 연결기를 완전히 제어할 수 있습니다."
---
## **소개**

PowerPoint 연결기는 두 도형을 연결하는 특수한 선으로, 슬라이드에서 도형을 이동하거나 위치를 바꿔도 연결된 상태를 유지합니다. 연결기는 도형의 **연결 지점**(녹색 점)에 붙습니다. 포인터가 연결 지점에 근접하면 해당 지점이 표시됩니다. 특정 연결기에 제공되는 **조정 핸들**(노란색 점)을 사용하면 연결기의 위치와 모양을 수정할 수 있습니다.

## **연결기 유형**

PowerPoint에서는 직선, 팔꿈치(각형), 곡선의 세 가지 유형의 연결기를 사용할 수 있습니다.

Aspose.Slides는 다음 연결기 유형을 지원합니다:

| 연결기 유형 | 이미지 | 조정 지점 수 |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE` | ![선 연결기](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![직선 연결기 1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![굽은 연결기 2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![굽은 연결기 3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![굽은 연결기 4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![굽은 연결기 5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![곡선 연결기 2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![곡선 연결기 3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![곡선 연결기 4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![곡선 연결기 5](shapetype.curvedconnector5.png) | 3 |

## **연결기로 모양 연결**

이 섹션에서는 Aspose.Slides에서 연결기를 사용해 도형을 연결하는 방법을 보여줍니다. 슬라이드에 연결기를 추가하고 시작점과 끝점을 대상 도형에 연결합니다. 연결 사이트를 사용하면 도형이 이동하거나 크기가 변해도 연결기가 “붙어” 있게 됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/) 객체가 제공하는 `add_auto_shape` 메서드를 사용해 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 객체를 추가합니다.
1. [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/) 객체가 제공하는 `add_connector` 메서드를 사용해 연결기를 추가하고 연결기 유형을 지정합니다.
1. 연결기로 도형을 연결합니다.
1. `reroute` 메서드를 호출해 가장 짧은 연결 경로를 적용합니다.
1. 프레젠테이션을 저장합니다.

다음 Python 코드에서는 두 도형(타원과 사각형) 사이에 굽은 연결기를 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# PPTX 파일을 만들기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드의 도형 컬렉션에 접근합니다.
    shapes = presentation.slides[0].shapes

    # 타원 AutoShape을 추가합니다.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 사각형 AutoShape을 추가합니다.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 슬라이드에 연결기를 추가합니다.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # 연결기로 도형을 연결합니다.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 최단 경로를 설정하기 위해 reroute를 호출합니다.
    connector.reroute()

    # 프레젠테이션을 저장합니다.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
`connector.reroute` 메서드는 연결기를 재라우팅하여 도형 사이의 가장 짧은 경로를 강제합니다. 이를 수행하기 위해 메서드는 `start_shape_connection_site_index`와 `end_shape_connection_site_index` 값을 변경할 수 있습니다.
{{% /alert %}}

## **연결 지점 지정**

이 섹션에서는 Aspose.Slides에서 도형의 특정 연결 지점에 연결기를 부착하는 방법을 설명합니다. 정확한 연결 사이트를 지정하면 연결기의 라우팅 및 레이아웃을 제어하여 프레젠테이션에 깔끔하고 예측 가능한 다이어그램을 만들 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/) 객체가 제공하는 `add_auto_shape` 메서드를 사용해 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 객체를 추가합니다.
1. [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/) 객체에서 `add_connector` 메서드를 사용해 연결기를 추가하고 유형을 지정합니다.
1. 연결기로 도형을 연결합니다.
1. 도형에 원하는 연결 지점을 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 Python 코드는 원하는 연결 지점을 지정하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# PPTX 파일을 만들기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드의 도형 컬렉션에 접근합니다.
    shapes = presentation.slides[0].shapes

    # 타원 AutoShape을 추가합니다.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 사각형 AutoShape을 추가합니다.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 슬라이드의 도형 컬렉션에 연결기를 추가합니다.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 연결기로 도형을 연결합니다.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 타원에 선호하는 연결 사이트 인덱스를 설정합니다.
    site_index = 6

    # 선호하는 인덱스가 사용 가능한 사이트 수 내에 있는지 확인합니다.
    if  ellipse.connection_site_count > site_index:
        # 타원 AutoShape에 선호하는 연결 사이트를 할당합니다.
        connector.start_shape_connection_site_index = site_index

    # 프레젠테이션을 저장합니다.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **연결기 지점 조정**

조정 지점을 통해 연결기를 수정할 수 있습니다. 조정 지점을 제공하는 연결기만이 이 방식으로 편집 가능합니다. 어느 연결기가 조정을 지원하는지 자세한 내용은 [연결기 유형](/slides/ko/python-net/connector/#connector-types) 아래 표를 참고하세요.

### **간단한 사례**

두 도형(A와 B) 사이의 연결기가 세 번째 도형(C)과 교차하는 경우를 고려해 보세요:

![연결기 방해](connector-obstruction.png)

코드 예제:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

세 번째 도형을 피하려면 연결기의 수직 구간을 왼쪽으로 이동해 조정합니다:

![수정된 연결기 방해](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **복합 사례**

보다 고급 조정을 위해 다음을 고려하세요:

- 연결기의 조정 가능한 점은 위치를 결정하는 수식에 의해 제어됩니다. 이 점을 변경하면 연결기의 전체 모양이 바뀝니다.
- 연결기의 조정 점은 엄격히 순서가 지정된 배열에 저장되며, 연결기의 시작부터 끝까지 번호가 매겨집니다.
- 조정 점 값은 연결기 형태의 너비/높이에 대한 백분율을 나타냅니다.
  - 형태는 연결기의 시작점과 끝점으로 제한되며 1000으로 스케일링됩니다.
  - 첫 번째, 두 번째, 세 번째 조정 점은 각각: 너비 백분율, 높이 백분율, 다시 너비 백분율을 의미합니다.
- 조정 점 좌표를 계산할 때는 연결기의 회전 및 반사를 고려해야 합니다. **참고:** [연결기 유형](/slides/ko/python-net/connector/#connector-types) 에 나열된 모든 연결기의 회전 각도는 0입니다.

#### **사례 1**

두 텍스트 프레임 객체가 연결기로 연결된 경우를 생각해 보세요:

![연결된 도형](connector-shape-complex.png)

코드 예제:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX 파일을 만들기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 첫 번째 슬라이드를 가져옵니다.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # 연결기를 추가합니다.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 연결기의 방향을 설정합니다.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 연결기의 색상을 설정합니다.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 연결기의 선 두께를 설정합니다.
    connector.line_format.width = 3

    # 연결기로 도형을 연결합니다.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # 연결기의 조정점을 가져옵니다.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**조정**

연결기의 조정 점 값을 너비 백분율은 20% 늘리고, 높이 백분율은 200% 늘려 변경합니다:

```python
    # 조정점의 값을 변경합니다.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

결과:

![연결기 조정 1](connector-adjusted-1.png)

연결기 구간의 좌표와 형태를 정의하는 모델을 만들려면 `connector.adjustments[0]`에 해당하는 수직 구성 요소에 해당하는 도형을 생성합니다:

```python
    # 연결기의 수직 구성 요소를 그립니다.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

결과:

![연결기 조정 2](connector-adjusted-2.png)

#### **사례 2**

**사례 1**에서 기본 원리를 사용한 간단한 연결기 조정을 보여주었습니다. 일반적인 시나리오에서는 연결기의 회전 및 표시 설정(`connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v`)을 고려해야 합니다. 처리 과정은 다음과 같습니다.

먼저, 슬라이드에 새로운 텍스트 프레임 객체(**To 1**)를 추가하고 기존 객체와 연결되는 새로운 녹색 연결기를 생성합니다.

```python
    # 새 대상 객체를 생성합니다.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # 새 연결기를 생성합니다.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # 새로 만든 연결기를 사용해 객체를 연결합니다.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 연결기의 조정점을 가져옵니다.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 조정점의 값을 변경합니다.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

결과:

![연결기 조정 3](connector-adjusted-3.png)

둘째, 새로운 연결기의 조정 점 `connector.adjustments[0]`을 통과하는 **수평** 구간에 해당하는 도형을 생성합니다. `connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v` 값을 사용하고, 주어진 점 `x0`을 중심으로 회전하는 표준 좌표 변환 수식을 적용합니다:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

우리 경우 객체의 회전 각도는 90도이며 연결기가 수직으로 표시되므로 해당 코드는 다음과 같습니다:

```python
    # 연결기 좌표를 저장합니다.
    x = connector.x
    y = connector.y
    
    # 연결기가 뒤집힌 경우 좌표를 보정합니다.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 조정점 값을 좌표로 사용합니다.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # sin(90°)=1, cos(90°)=0이므로 좌표를 변환합니다.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 두 번째 조정점 값을 사용해 수평 구간의 너비를 결정합니다.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

결과:

![연결기 조정 4](connector-adjusted-4.png)

우리는 간단한 조정과 회전을 고려한 복잡한 조정 점을 포함한 계산을 보여주었습니다. 이 지식을 활용하면 직접 모델을 개발하거나 코드를 작성해 `GraphicsPath` 객체를 얻거나 특정 슬라이드 좌표에 따라 연결기의 조정 점 값을 설정할 수 있습니다.

## **연결선 각도 찾기**

아래 예제를 사용해 Aspose.Slides로 슬라이드에 있는 연결선의 각도를 구합니다. 연결기의 끝점을 읽고 방향을 계산하여 화살표, 레이블 및 기타 도형을 정확히 정렬하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. 연결선 도형에 접근합니다.
1. 선의 너비와 높이, 그리고 도형 프레임의 너비와 높이를 사용해 각도를 계산합니다.

다음 Python 코드는 연결선 도형의 각도를 계산하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**특정 도형에 연결기를 “붙일” 수 있는지 어떻게 확인하나요?**

도형이 [연결 사이트](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/connection_site_count/)를 제공하는지 확인하십시오. 없거나 카운트가 0이면 붙이기가 지원되지 않으며, 이 경우 자유 끝점을 사용해 수동으로 위치를 지정해야 합니다. 연결 전 사이트 카운트를 검사하는 것이 현명합니다.

**연결된 도형 중 하나를 삭제하면 연결기는 어떻게 되나요?**

끝점이 분리됩니다; 연결기는 자유 시작/끝을 가진 일반 선으로 슬라이드에 남습니다. 삭제하거나 연결을 재지정하고 필요한 경우 [reroute](https://reference.aspose.com/slides/ko/python-net/aspose.slides/connector/reroute/)할 수 있습니다.

**슬라이드를 다른 프레젠테이션으로 복사하면 연결기 바인딩이 유지되나요?**

일반적으로 대상 도형도 함께 복사되면 유지됩니다. 연결된 도형 없이 슬라이드를 다른 파일에 삽입하면 끝점이 자유롭게 되고 다시 연결해야 합니다.