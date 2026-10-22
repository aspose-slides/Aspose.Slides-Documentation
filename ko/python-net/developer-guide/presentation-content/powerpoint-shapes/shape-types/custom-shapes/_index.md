---
title: Python에서 프레젠테이션 도형 맞춤 설정
linktitle: 사용자 정의 도형
type: docs
weight: 20
url: /ko/python-net/custom-shape/
keywords:
- 사용자 정의 도형
- 도형 추가
- 도형 만들기
- 도형 변경
- 도형 기하학
- 기하학 경로
- 경로 포인트
- 편집 포인트
- 포인트 추가
- 포인트 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 .NET을 통해 PowerPoint 프레젠테이션에서 도형을 만들고 맞춤 설정합니다: 기하학 경로, 곡선 모서리, 복합 도형."
---
## **개요**

이 문서에서는 편집 포인트와 기하학 경로를 통해 도형 기하학을 편집하여 Aspose.Slides 프레젠테이션 도형을 맞춤 설정하는 방법을 설명합니다. 기존 도형을 수정하기 위해 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)를 사용하는 방법, 기본 경로 편집 작업 수행, 포인트 추가 또는 제거, 그리고 업데이트된 기하학을 도형에 적용하는 방법을 보여줍니다. 또한 사용자 정의 및 복합 도형을 만드는 방법, 곡선 모서리를 가진 도형을 구축하는 방법, 도형 기하학이 닫혀 있는지 판단하는 방법, 그리고 윤곽선 분석을 위해 도형 요소를 추출하는 방법을 시연합니다.

## **편집 포인트를 사용하여 도형 변경**

* 모서리를 안쪽 또는 바깥쪽으로 이동합니다.
* 포인트에서 곡률을 조정합니다.
* 새 포인트를 추가합니다.

포인트를 편집하면 도형의 외곽선을 수정하거나 기존 도형을 새 도형의 기반으로 사용할 수 있습니다.

## **도형 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 도형을 편집할 때 다음 개념을 기억하십시오:

* 도형(또는 그 경로)은 닫힌 형태 또는 열린 형태일 수 있습니다.
* 도형의 경로는 세그먼트로 연결된 앵커 포인트로 구성됩니다.
* 세그먼트는 직선이 될 수도 있고 곡선이 될 수도 있습니다. 앵커 포인트와 제어 핸들이 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 또는 부드러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접 세그먼트가 각도로 만납니다.
  * 부드러운 포인트에서는 두 제어 핸들이 정렬되고 앵커 포인트와 같은 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 앵커 포인트와의 거리는 다를 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 도형의 외곽선이 변경됩니다.

편집 포인트를 통해 PowerPoint 도형을 편집하려면 **Aspose.Slides**가 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 클래스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 인스턴스는 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 객체의 기하학 경로를 나타냅니다.
* [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)를 가져오려면 [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) 메서드를 사용할 수 있습니다.
* 도형에 대한 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)를 설정하려면 단일 경로를 가진 도형에는 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 메서드를, 다중 경로를 가진 도형에는 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) 메서드를 사용할 수 있습니다.
* 세그먼트를 추가하려면 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) 및 [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) 속성을 사용하여 기하학 경로의 모양을 설정할 수 있습니다.
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 속성을 사용하여 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)의 기하학 경로를 경로 세그먼트 배열로 가져올 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하학 경로를 편집할 수 있습니다. 인덱스를 받는 오버로드는 경로 세그먼트 배열의 해당 0 기반 위치에 세그먼트를 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| 두 개의 제어점과 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| 하나의 제어점과 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| 지정된 치수와 각도(도)로 타원 호를 추가합니다. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| 끝점을 시작점에 연결하여 현재 도형을 닫습니다. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| 도형의 시작점을 설정합니다. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| 0 기반 인덱스에서 세그먼트를 제거합니다. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **도형에 사용자 지정 포인트 추가**

이 예제는 [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/)를 사용하여 직사각형 도형에 두 개의 포인트를 삽입하고, 편집된 경로를 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)로 적용합니다. 좌표는 도형에 로컬이며, 두 새로운 포인트는 도형의 중심에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 세그먼트 인덱스 1과 4는 각각 상단 및 하단 가장자리에 배치되어 해당 가장자리를 안쪽으로 끌어당깁니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **도형에서 포인트 제거**

이 예제는 0 기반 인덱스 2에서 [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/)을 사용해 세그먼트를 제거하여 하트 모양 윤곽을 변경합니다. 수정된 경로를 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)으로 적용하면 도형의 윤곽이 업데이트됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **사용자 지정 도형 만들기**

이 예제는 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)를 사용하여 다섯 꼭지점 별을 만듭니다. 외부와 내부 반경을 각각 100포인트와 50포인트로 교대로 지정하여 별의 팁과 함몰을 정의하고, 72도 간격으로 다섯 팁을 고르게 배치합니다. 경로는 [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/)으로 닫히며, [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)을 사용해 직사각형 도형에 적용하여 기존 외곽선을 대체합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **복합 사용자 지정 도형 만들기**

이 예제는 도형의 상단 및 하단 3분의 1에 대해 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)으로 적용하면 가운데 3분의 1에 틈이 있는 단일 복합 도형이 생성됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 지정 도형 만들기**

이 예제는 직선 세그먼트와 [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/)를 결합하여 안쪽으로 굽은 모서리를 가진 도형을 만듭니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 1/4 타원을 그립니다. 완성된 경로는 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)으로 적용되며, 프레젠테이션은 PPTX 형식으로 저장됩니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **도형 기하학이 닫혀 있는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하학 경로가 닫는 세그먼트로 끝나는지 확인합니다. [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/)를 읽고 마지막 세그먼트의 [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/)을 [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없을 경우 false를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내 모든 하위 도형을 검사하지는 않습니다. 예제는 직사각형에 대해 `True`를 출력합니다.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **도형 요소 추출 및 검사**

[GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/)을 사용하면 기존 도형을 경로 포인트와 포인트 유형을 포함하는 요소로 검사할 수 있습니다. 반환된 각 [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/)은 its [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) 및 [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) 배열을 공개합니다. 이 표현은 윤곽선 분석이나 기하학을 사용자 정의 그리기 도구에 전달할 때 유용합니다.

예제는 프레젠테이션을 열고 첫 번째 슬라이드에서 첫 번째 기하학 도형을 직접 찾아 해당 경로 세그먼트를 출력합니다. 직선 및 곡선 세그먼트를 포함하는 도형이 포함된 프레젠테이션을 사용하면 두 종류의 출력을 모두 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # 세그먼트 유형을 유지하고 플래그는 제외합니다.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

배열은 인덱스로 대응됩니다: `points[i]`는 포인트이며 `types[i]`는 해당 역할을 설명합니다. 유형 `0`은 도형을 시작하고, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하여 연속된 type-`3` 항목 세 개를 사용합니다: 두 개의 제어점과 그 뒤의 새 끝점. 루프는 이 세 항목을 함께 소모하고 끝점이 닫혔는지 확인합니다.

포인트 유형에는 플래그도 포함됩니다. 세그먼트 유형을 식별하려면 `0x07`으로 마스크하고, 닫힌 하위 경로를 감지하려면 `0x80`을 별도로 테스트합니다. 예를 들어, `129`(`0x81`)는 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 이를 닫는 베지어 끝점입니다. 원시 값을 `1`이나 `3`만으로 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환.** 포인트는 포인트(1/72 인치) 단위로 측정되며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹화되지 않은 도형의 경우, 추출된 좌표에는 이미 해당 도형의 [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)와 [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) 위치가 포함되어 있으며 현재 너비와 높이를 반영합니다. 예를 들어, `(100, 200)`에 위치하고 크기가 `120 × 80`인 회전되지 않은 직사각형은 윤곽 경계가 `(100, 200)`–`(220, 280)`입니다. 도형의 위치를 다시 추가하지 마십시오. X와 Y를 빼서 회전되지 않은 프레임에 대한 상대 좌표를 얻습니다.

추출된 포인트에는 도형의 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 또는 수평·수직 뒤집기가 적용되지 않습니다. 표시된 윤곽을 재현하려면 이러한 변환을 도형 중심을 기준으로 적용하십시오. 그룹화된 도형의 경우, 그룹 좌표 매핑 및 변환도 고려해야 하며, 추출된 포인트가 최종 렌더링된 슬라이드 좌표라고 가정하거나 이미 자식 프레임에 반영된 경우 다시 변환이나 스케일을 적용하지 마십시오.

**검사와 편집의 차이.** 추출된 배열은 윤곽을 설명하며, 이를 변경해도 원본 도형은 업데이트되지 않습니다. 분석 또는 그리기 코드에서 포인트/유형 배열이 필요할 때 이 방법을 선택하십시오. 도형의 로컬 좌표계에서 기하학 명령이 필요하거나 기하학을 편집하려면 [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)를 사용하십시오. 편집된 경로는 [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 또는 [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)를 통해 적용하십시오.

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 도형에 그대로 유지되며, 윤곽선만 변경됩니다. 채우기와 외곽선은 새로운 기하학에 자동으로 적용됩니다.

**사용자 지정 도형과 그 기하학을 어떻게 올바르게 회전시키나요?**

도형의 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 속성을 사용하십시오. 기하학은 도형에 바인딩된 자체 좌표계에 따라 도형과 함께 회전합니다.

**사용자 지정 도형을 이미지로 변환하여 결과를 '고정'할 수 있나요?**

예. 필요한 [슬라이드](/slides/ko/python-net/convert-powerpoint-to-png/) 영역이나 [도형](/slides/ko/python-net/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학을 다루는 작업을 단순화할 수 있습니다.