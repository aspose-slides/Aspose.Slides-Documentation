---
title: Python을 사용하여 Java에서 프레젠테이션 모양 사용자 지정
linktitle: 맞춤형 모양
type: docs
weight: 20
url: /ko/python-java/custom-shape/
keywords:
- 맞춤형 모양
- 모양 추가
- 모양 만들기
- 모양 변경
- 모양 기하학
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
description: "Java를 통한 Python용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 모양을 만들고 사용자 지정하십시오: 기하학 경로, 곡선 모서리, 복합 모양."
---
## **개요**

이 문서에서는 편집 포인트와 기하학 경로를 통해 모양 기하학을 편집하여 Aspose.Slides 프레젠테이션 모양을 사용자 지정하는 방법을 설명합니다. 기존 모양을 수정하고 기본 경로 편집 작업을 수행하며 포인트를 추가하거나 제거하고 업데이트된 기하학을 모양에 적용하기 위해 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 사용하는 방법을 보여줍니다.

또한 사용자 정의 및 복합 모양을 만들고, 곡선 모서리가 있는 모양을 구축하며, 모양 기하학이 닫혀 있는지 확인하고, 모양 요소를 검사하고, Java AWT 텍스트 윤곽선을 기하학 경로로 변환하는 방법을 시연합니다.

## **편집 포인트를 사용하여 모양 변경**

PowerPoint에서 **편집 포인트**를 사용하여 정사각형을 수정할 수 있습니다:

* 모서리를 안쪽이나 바깥쪽으로 이동합니다.
* 포인트에서 곡률을 조정합니다.
* 새로운 포인트를 추가합니다.

편집 포인트를 사용하면 모양의 외곽선을 수정하거나 기존 모양을 새로운 모양의 기반으로 사용할 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 모양을 편집할 때 다음 개념을 기억하십시오:

* 모양(또는 해당 경로)은 닫힌 상태이거나 열린 상태일 수 있습니다.
* 모양의 경로는 세그먼트로 연결된 앵커 포인트로 구성됩니다.
* 세그먼트는 직선이거나 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 그 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트 또는 매끄러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접 세그먼트가 각을 이루어 만납니다.
  * 매끄러운 포인트에서는 두 제어 핸들이 정렬되고 앵커 포인트로부터 동일한 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 앵커 포인트로부터 거리 차이가 있을 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 모양의 외곽선이 변경됩니다.

편집 포인트를 통해 PowerPoint 모양을 편집하려면 **Aspose.Slides**에서 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 클래스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 인스턴스는 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 개체의 기하학 경로를 나타냅니다.
* [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 가져오려면 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) 메서드를 사용할 수 있습니다.
* 모양에 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 설정하려면 단일 경로가 있는 경우 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), 다중 경로가 있는 경우 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 메서드를 사용할 수 있습니다.
* 세그먼트를 추가하려면 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 아래의 메서드를 사용하십시오.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) 및 [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 메서드를 사용하면 기하학 경로의 외관을 설정할 수 있습니다.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)의 기하학 경로를 세그먼트 배열로 가져올 수 있습니다.
* 추가적인 모양 기하학 사용자 지정 옵션에 액세스하려면 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)의 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)를 통해 읽고 해당 세그먼트를 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)에 재생할 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하학 경로를 편집하십시오. 인덱스를 허용하는 오버로드는 경로 세그먼트 배열의 해당 0 기반 위치에 세그먼트를 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| 두 개의 제어 포인트와 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 하나의 제어 포인트와 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 지정된 치수와 각도(도)로 타원 호를 추가합니다. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| 현재 도형을 닫아 끝점을 시작점과 연결합니다. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| 도형의 시작점을 설정합니다. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| 0 기반 인덱스에서 세그먼트를 제거합니다. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **모양에 사용자 정의 포인트 추가**

이 예제는 [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo)를 사용하여 직사각형 모양에 두 개의 포인트를 삽입하고, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)를 사용하여 편집된 경로를 적용합니다. 좌표는 모양에 상대적이며, 두 새로운 포인트는 모양 중앙에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 세그먼트 인덱스 1과 4는 각각 상단 및 하단 가장자리에 배치되어 해당 가장자를 안쪽으로 당깁니다.

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

## **모양에서 포인트 제거**

이 예제는 [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt)으로 0 기반 인덱스 2에 있는 세그먼트를 제거하여 하트 모양 윤곽을 변경합니다. 수정된 경로를 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용하면 모양의 외곽선이 업데이트됩니다.

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

## **사용자 정의 모양 만들기**

이 예제는 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)를 사용하여 5각별 별을 만듭니다. 외부와 내부 반경을 각각 100포인트와 50포인트로 번갈아가며 팁과凹을 정의하고, 72도 간격으로 다섯 팁을 고르게 배치합니다. 경로는 [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure)으로 닫히고, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)를 통해 직사각형 모양에 적용되어 기존 윤곽을 대체합니다.

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

## **복합 사용자 정의 모양 만들기**

이 예제는 모양의 상단 및 하단 3분의 1을 위해 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)로 적용하면 중간 3분의 1에 간격이 있는 단일 복합 모양이 생성됩니다.

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

## **곡선 모서리가 있는 사용자 정의 모양 만들기**

이 예제는 직선 세그먼트와 [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo)를 결합하여 안쪽으로 굽은 모서리를 가진 모양을 만듭니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 사분원 타원을 그립니다. 완성된 경로는 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용되며, 프레젠테이션은 PPTX 형식으로 저장됩니다.

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

## **모양 기하학이 닫혀 있는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하학 경로가 닫는 세그먼트로 끝나는지 확인합니다. [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData)를 읽고 최종 세그먼트의 [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand)와 [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/)를 비교합니다. 비어 있지 않은 경로가 없을 경우 `False`를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내 모든 하위 피규어를 검사하지는 않습니다. 예제는 사각형에 대해 `True`를 출력합니다.

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

## **기하학 경로 명령 검사**

[contour.pptx](contour.pptx)를 다운로드하고 애플리케이션 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드의 첫 번째 모양은 직선 상단 가장자리, 3차 베지어 곡선, 그리고 직선 닫는 가장자를 가지고 있습니다. [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)를 사용하여 모양의 경로를 읽고, [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData)를 사용하여 각 경로의 세그먼트를 그리기 순서대로 읽으십시오. 각 세그먼트에 대해 [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand)가 명령을 식별하고, 반환된 값을 해석하기 위해 [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData)를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

모양은 슬라이드에서 (200, 100) 포인트 위치에 있습니다. 보고된 좌표는 모양에 상대적이며, (0, 0)은 모양의 왼쪽 위 모서리이며, x는 오른쪽으로, y는 아래쪽으로 증가합니다. 닫는 세그먼트는 추가 좌표 없이 시작점으로 돌아갑니다.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **모양 요소 추출 및 검사**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements)를 사용하여 기존 모양을 경로 포인트와 포인트 유형을 포함하는 요소로 검사하십시오. 반환된 각 요소를 `jpype.JObject`와 함께 [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/)로 캐스트하여 [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints)와 [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) 메서드를 통해 포인트와 유형 배열을 가져옵니다. 이 표현은 외곽선 분석이나 사용자 정의 그리기 도구에 기하학을 전달할 때 유용합니다.

예제는 input.pptx를 열고 첫 번째 슬라이드의 첫 번째 기하학 모양을 찾아 그 경로 세그먼트를 출력합니다. 직선 및 곡선 세그먼트를 포함하는 모양이 있는 프레젠테이션을 사용하면 두 종류의 출력 모두를 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

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
                point_type = types[i] & 0x07  # 세그먼트 유형을 유지하고 플래그는 제외합니다.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # 두 개의 제어 포인트와 끝점 모두를 소비합니다.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

배열은 인덱스로 대응됩니다: `points[i]`는 포인트이고 `types[i]`는 그 역할을 설명합니다. 유형 `0`은 피규어 시작을, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하고 연속된 유형 `3` 세 개(두 제어 포인트와 새로운 끝점)를 사용합니다. 루프는 이 세 항목을 함께 소비하고 종료점이 닫혔는지 확인합니다.

포인트 유형에는 플래그도 포함됩니다. `0x07`을 마스크하여 세그먼트 유형을 식별하고, `0x80`을 별도로 테스트하여 닫힌 하위 경로를 감지합니다. 예를 들어 `129`(`0x81`)은 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 닫는 베지어 끝점입니다. Java는 이러한 플래그를 부호 있는 바이트에 저장하므로 마스크를 적용해야 의도된 비트 값을 유지할 수 있습니다. 원시 값을 `1`이나 `3`만으로 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환.** 포인트는 포인트(1/72인치) 단위로 측정되며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 포함되지 않은 모양의 경우, 추출된 좌표에는 이미 [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX)와 [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY)에서 반환된 위치가 포함되어 있으며 현재 너비와 높이를 반영합니다. 예를 들어, `(100, 200)` 위치에 크기 `120 × 80`인 회전되지 않은 직사각형은 외곽선 경계가 `(100, 200)`–`(220, 280)`입니다. 모양의 위치를 다시 추가하지 마십시오. 좌표를 X와 Y에서 빼서 회전되지 않은 프레임에 상대적인 좌표를 얻으십시오.

추출된 포인트는 [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation)으로 반환되는 모양의 회전이나 수평·수직 뒤집기를 적용하지 않습니다. 표시된 외곽선을 재현하려면 이러한 변환을 모양 중심을 기준으로 적용하십시오. 그룹화된 모양의 경우에도 그룹 좌표 매핑 및 변환을 고려해야 하며, 추출된 포인트가 최종 렌더링된 슬라이드 좌표라고 가정하거나 이미 자식 프레임에 반영된 변환을 두 번 적용하지 마십시오.

**검사 vs. 편집.** 추출된 배열은 외곽선을 설명하며, 이를 변경해도 원래 모양은 업데이트되지 않습니다. 분석이나 그리기 코드가 포인트/유형 배열이 필요할 때 이 접근 방식을 선택하십시오. 모양의 로컬 좌표계에서 기하학 명령이 필요하거나 기하학을 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)를 사용하십시오. 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 또는 [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)를 통해 적용하십시오.

## **Java AWT Shape를 GeometryPath로 변환**

이 예제는 텍스트를 기하학으로 변환한 사각형 윤곽을 결합합니다. 윤곽의 [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 메서드는 채우기를 비활성화합니다. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html)는 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)에서 텍스트 윤곽을 생성합니다. 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)는 이동, 선, 2차, 3차 및 닫는 세그먼트를 제공하며, 예제는 이를 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)에 재생합니다.

텍스트는 40포인트 Arial 폰트를 사용합니다. 윤곽은 수평으로 20포인트 오프셋되고, 시각적 상단이 모양 상단 가장자리 아래 10포인트에 배치됩니다. 텍스트 경로는 채워지고, 원래 직사각형은 윤곽만 유지됩니다. 두 경로를 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)로 적용하면 직사각형과 텍스트를 포함하는 단일 모양이 생성됩니다.

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

    # 모양의 기하학 경로를 가져옵니다.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # 텍스트를 사용하여 새 그래픽 경로를 생성합니다.
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

    # 원래 기하학 경로와 함께 텍스트 경로를 적용합니다.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 됩니까?**

스타일은 모양에 그대로 남으며, 외곽선만 변경됩니다. 채우기와 외곽선은 새 기하학에 자동으로 적용됩니다.

**기하학과 함께 사용자 정의 모양을 올바르게 회전하려면 어떻게 해야 합니까?**

모양의 [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 메서드를 사용하십시오. 기하학은 모양에 결합된 좌표계에 따라 모양과 함께 회전됩니다.

**사용자 정의 모양을 이미지로 변환하여 결과를 “잠그”고 싶습니까?**

예. 필요한 [slide](/slides/ko/python-java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/python-java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학 작업을 더 쉽게 할 수 있습니다.