---
title: Python을 통해 Java에서 프레젠테이션 도형 사용자 지정
linktitle: 맞춤형 도형
type: docs
weight: 20
url: /ko/python-java/custom-shape/
keywords:
- 맞춤형 도형
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
description: "Python을 통해 Java에서 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 도형을 만들고 사용자 지정합니다: 기하학 경로, 곡선 모서리, 복합 도형."
---
## **개요**

이 문서에서는 편집 포인트와 기하학 경로를 통해 도형 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 도형을 사용자 지정하는 방법을 설명합니다. 이 문서에서는 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 사용하여 기존 도형을 수정하고, 기본 경로 편집 작업을 수행하며, 포인트를 추가하거나 제거하고, 업데이트된 기하학을 도형에 다시 적용하는 방법을 보여줍니다.

또한 사용자 지정 및 복합 도형을 만들고, 곡선 모서리를 가진 도형을 구축하며, 도형 기하학이 닫혀 있는지 확인하고, 도형 요소를 검사하며, Java AWT 텍스트 윤곽을 기하학 경로로 변환하는 방법도 보여줍니다.

## **편집 포인트를 사용하여 도형 변경**

PowerPoint에서 **Edit Points**를 사용하여 사각형을 수정할 수 있습니다:

* 모서리를 안쪽이나 바깥쪽으로 이동합니다.
* 포인트에서 곡률을 조정합니다.
* 새로운 포인트를 추가합니다.

포인트를 편집하면 도형의 윤곽을 수정하거나 기존 도형을 새 도형의 기반으로 사용할 수 있습니다.

## **도형 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 도형을 편집할 때 다음 개념을 기억하세요:

* 도형(또는 그 경로)은 닫혀 있거나 열려 있을 수 있습니다.
* 도형의 경로는 세그먼트로 연결된 앵커 포인트로 구성됩니다.
* 세그먼트는 직선 또는 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 그 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트 또는 스무스 포인트로 존재합니다:
  * 코너 포인트에서는 인접 세그먼트가 각도로 만나지만
  * 스무스 포인트에서는 두 제어 핸들이 정렬되어 앵커 포인트와 동일한 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되어 있지만 앵커 포인트와 거리 차이가 있을 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 도형의 윤곽이 바뀝니다.

편집 포인트를 통해 PowerPoint 도형을 편집하려면 **Aspose.Slides**가 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 클래스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 인스턴스는 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 객체의 기하학 경로를 나타냅니다.
* [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 가져오려면 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) 메서드를 사용할 수 있습니다.
* 도형에 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 설정하려면 단일 경로를 가진 도형은 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), 다중 경로를 가진 도형은 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 메서드를 사용할 수 있습니다.
* 세그먼트를 추가하려면 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke)와 [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 메서드를 사용하여 기하학 경로의 모양을 설정할 수 있습니다.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)의 기하학 경로를 경로 세그먼트 배열로 가져올 수 있습니다.
* 추가 도형 기하학 맞춤 옵션에 접근하려면 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)을 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)로 읽고 세그먼트를 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)에 재생할 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하학 경로를 편집합니다. 인덱스를 받는 오버로드는 경로 세그먼트 배열의 해당 0부터 시작하는 위치에 세그먼트를 삽입합니다.

| Operation | Method |
| --- | --- |
| 직선 추가 또는 삽입. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| 두 개의 제어점과 끝점이 있는 3차 베지어 곡선 추가 또는 삽입. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 하나의 제어점과 끝점이 있는 2차 베지어 곡선 추가 또는 삽입. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 지정된 크기와 각도(도)로 타원 호 추가. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| 끝점을 시작점에 연결하여 현재 도형을 닫음. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| 도형의 시작점을 설정. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| 0부터 시작하는 인덱스 위치의 세그먼트를 제거. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **도형에 사용자 지정 포인트 추가**

이 예제에서는 [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo)를 사용하여 사각형 도형에 두 개의 포인트를 삽입하고, 편집된 경로를 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)로 적용합니다. 좌표는 도형에 대한 로컬 좌표이며, 두 새로운 포인트는 도형 중앙에 위치하고 왼쪽에서 100 포인트, 위에서 50 포인트 떨어져 있습니다. 세그먼트 인덱스 1과 4는 각각 위와 아래 가장자리에 배치되어 해당 가장자리를 안쪽으로 당깁니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **도형에서 포인트 제거**

이 예제에서는 [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt)를 사용하여 0부터 시작하는 인덱스 2에 해당하는 세그먼트를 제거함으로써 하트 모양의 윤곽을 변경합니다. 수정된 경로를 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용하면 도형의 윤곽이 업데이트됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **사용자 지정 도형 만들기**

이 예제에서는 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 사용하여 5각별을 만듭니다. 외부 반경 100 포인트와 내부 반경 50 포인트를 교대로 사용하여 별의 꼭짓점과 오목 부분을 정의하고, 72도 간격으로 다섯 꼭짓점을 균일하게 배치합니다. 경로는 [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure)으로 닫히며, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)를 사용하여 사각형 도형에 적용해 기존 윤곽을 교체합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **복합 사용자 지정 도형 만들기**

이 예제에서는 도형의 상단 1/3과 하단 1/3을 위한 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)로 적용하면 중간 1/3에 틈이 있는 하나의 복합 도형이 생성됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 지정 도형 만들기**

이 예제에서는 직선 세그먼트와 [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo)를 결합하여 안쪽으로 굽은 모서리를 가진 도형을 만듭니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 회전으로 시계 반대 방향의 1/4 타원을 그립니다. 완성된 경로는 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용되며, 프레젠테이션은 PPTX 형식으로 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **도형 기하학이 닫혔는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하학 경로가 닫는 세그먼트로 끝나는지 확인합니다. [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData)를 읽고 최종 세그먼트의 [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand)를 [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없을 경우 `False`를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내의 모든 하위 도형을 검사하지는 않습니다. 예제에서는 사각형에 대해 `True`를 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **도형 요소 추출 및 검사**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements)를 사용하면 경로 포인트와 포인트 유형을 포함하는 요소로 기존 도형을 검사할 수 있습니다. 반환된 각 요소를 `jpype.JObject`와 함께 [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/)로 캐스팅하여 [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints)와 [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) 메서드를 통해 포인트와 유형 배열을 가져옵니다. 이 표현은 윤곽 분석이나 기하학을 사용자 정의 그리기 도구에 전달할 때 유용합니다.

예제에서는 input.pptx를 열어 첫 번째 슬라이드에서 첫 번째 기하학 도형을 직접 찾아 그 경로 세그먼트를 출력합니다. 직선과 곡선 세그먼트를 모두 포함하는 도형이 있는 프레젠테이션을 사용하면 두 종류의 출력 모두 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

배열은 인덱스로 대응합니다: `points[i]`는 점을, `types[i]`는 해당 역할을 나타냅니다. 타입 `0`은 도형을 시작하고, 타입 `1`은 이전 점에서 현재 점까지 선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하여 연속된 세 개의 타입 `3` 항목을 사용합니다: 두 개의 제어점과 그 뒤의 새로운 끝점입니다. 루프는 이 세 항목을 함께 소비하고 끝점이 닫혔는지 확인합니다.

점 타입에는 플래그도 포함됩니다. 세그먼트 유형을 식별하려면 `0x07`로 마스크하고, 닫힌 하위 경로를 감지하려면 `0x80`을 별도로 테스트합니다. 예를 들어 `129`(`0x81`)는 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 이를 닫는 베지어 끝점입니다. Java는 이러한 플래그를 부호 있는 바이트에 저장하므로 마스크를 적용하면 의도된 비트 값이 보존됩니다. 원시 값을 `1`이나 `3`과만 비교하면 이러한 경우를 놓칠 수 있습니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환.** 점은 포인트(1/72 인치) 단위로 측정되며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹화되지 않은 도형의 경우 추출된 좌표에는 이미 [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX)와 [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY)가 반환하는 위치가 포함되어 현재 너비와 높이를 반영합니다. 예를 들어, 위치가 `(100, 200)`이고 크기가 `120 × 80`인 회전되지 않은 사각형은 윤곽 경계가 `(100, 200)`–`(220, 280)`입니다. 도형의 위치를 다시 추가하지 마세요. X와 Y를 빼서 회전되지 않은 프레임을 기준으로 한 좌표를 얻습니다.

추출된 점에는 [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation)이 반환하는 도형 회전이나 수평·수직 뒤집기가 적용되지 않습니다. 표시된 윤곽을 재현하려면 도형 중심을 기준으로 이러한 변환을 적용하세요. 그룹화된 도형의 경우 그룹 좌표 매핑 및 변환도 고려해야 하며, 추출된 점이 최종 렌더링된 슬라이드 좌표라고 가정하거나 이미 자식 프레임에 반영된 변환을 또 적용하지 마세요.

**검사와 편집의 구분.** 추출된 배열은 윤곽을 설명하며, 이를 변경해도 원래 도형은 업데이트되지 않습니다. 분석이나 그리기 코드가 점/유형 배열이 필요할 때 이 방법을 선택하세요. 도형의 로컬 좌표계에서 기하학 명령이 필요하거나 기하학을 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)을 사용하십시오. 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 또는 [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)를 통해 적용합니다.

## **Java AWT Shape를 GeometryPath로 변환하기**

이 예제에서는 사각형 윤곽과 기하학으로 변환된 텍스트를 결합합니다. 윤곽의 [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 메서드는 채우기를 비활성화합니다. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html)는 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)에 텍스트 윤곽을 만들고, 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)는 이동, 선, 2차, 3차, 닫기 세그먼트를 제공하며, 예제에서는 이를 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)에 재생합니다.

텍스트는 40포인트 Arial 폰트를 사용합니다. 윤곽은 가로로 20포인트 이동하고, 시각적인 상단이 도형의 상단 가장자리보다 10포인트 아래에 위치합니다. 텍스트 경로는 채워지고 원래 사각형은 윤곽만 남습니다. 두 경로를 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)으로 적용하면 사각형과 텍스트를 포함하는 단일 도형이 생성됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # 도형의 기하학 경로를 가져옵니다.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # 텍스트가 포함된 새로운 그래픽 경로를 생성합니다.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # 그래픽 경로를 기하학 경로로 변환합니다.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # 텍스트 경로를 원래 기하학 경로와 함께 적용합니다.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**기하학을 교체한 후 채우기와 윤곽선은 어떻게 되나요?**

스타일은 도형에 남아 있으며, 윤곽만 변경됩니다. 채우기와 윤곽선은 자동으로 새 기하학에 적용됩니다.

**사용자 지정 도형과 그 기하학을 어떻게 올바르게 회전시키나요?**

도형의 [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 메서드를 사용하십시오; 기하학은 도형에 바인딩된 자체 좌표계 때문에 도형과 함께 회전합니다.

**사용자 지정 도형을 이미지로 변환해 결과를 “고정”시킬 수 있나요?**

네. 필요한 [slide](/slides/ko/python-java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/python-java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학 작업을 보다 쉽게 할 수 있습니다.