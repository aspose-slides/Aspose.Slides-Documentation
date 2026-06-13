---
title: Python으로 프레젠테이션에서 도형 맞춤
linktitle: 맞춤 도형
type: docs
weight: 20
url: /ko/python-net/custom-shape/
keywords:
- 맞춤 도형
- 도형 추가
- 도형 만들기
- 도형 변경
- 도형 기하학
- 기하 경로
- 경로 포인트
- 포인트 편집
- 포인트 추가
- 포인트 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python(.NET)을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형을 생성하고 맞춤 설정합니다: 기하 경로, 곡선 모서리, 복합 도형."
---
## **소개**

정사각형을 생각해 보세요. PowerPoint에서 **Edit Points**를 사용하면 다음을 할 수 있습니다:

* 정사각형의 모서리를 안쪽이나 바깥쪽으로 이동한다,
* 모서리 또는 점의 곡률을 조정한다,
* 정사각형에 새로운 점을 추가한다,
* 그 점들을 조작한다.

이러한 작업은 모든 도형에 적용할 수 있습니다. **Edit Points**를 사용하면 도형을 수정하거나 기존 도형에서 새로운 도형을 만들 수 있습니다.

## **도형 편집 팁**

!["Edit Points" command](custom_shape_0.png)

PowerPoint 도형을 **Edit Points**로 편집하기 전에, 도형에 대한 다음 참고 사항을 확인하십시오:

* 도형(또는 그 경로)은 **closed**(닫힌) 또는 **open**(열린) 상태일 수 있습니다.
* 닫힌 도형은 시작점이나 끝점이 없으며, 열린 도형은 시작점과 끝점이 있습니다.
* 모든 도형은 선분으로 연결된 최소 두 개의 앵커 포인트를 가지고 있습니다.
* 세그먼트는 직선이거나 곡선이며, 앵커 포인트가 세그먼트의 형태를 결정합니다.
* 앵커 포인트는 **corner**, **smooth**, **straight** 중 하나일 수 있습니다:
  * **corner** 포인트는 두 직선 세그먼트가 각을 이루며 만나는 지점입니다.
  * **smooth** 포인트는 두 개의 핸들이 한 직선 상에 있으며 인접 세그먼트가 부드러운 곡선을 형성합니다. 이 경우 두 핸들의 거리와 앵커 포인트까지의 거리가 동일합니다.
  * **straight** 포인트도 두 개의 공선 핸들을 가지며 인접 세그먼트가 부드러운 곡선을 형성합니다. 이 경우 핸들의 거리는 앵커 포인트와 동일할 필요가 없습니다.
* 앵커 포인트를 이동하거나 편집하여(세그먼트 각도를 변경함으로써) 도형의 모양을 바꿀 수 있습니다.

PowerPoint 도형을 편집하려면 Aspose.Slides에서 [GeometryPath](https://reference.aspose.com/slides/ko/python-net/aspose.slides/geometrypath/) 클래스를 제공합니다.

- [GeometryPath] 인스턴스는 [GeometryShape] 객체의 기하학 경로를 나타냅니다.
- [GeometryShape] 인스턴스에서 [GeometryPath]를 가져오려면 [GeometryShape.get_geometry_paths] 메서드를 사용합니다.
- 도형에 [GeometryPath]를 설정하려면 *solid shapes*에 대해 [GeometryShape.set_geometry_path]를, *composite shapes*에 대해 [GeometryShape.set_geometry_paths]를 사용합니다.
- 세그먼트를 추가하려면 [GeometryPath]의 메서드를 사용합니다.
- [GeometryPath.stroke] 및 [GeometryPath.fill_mode] 속성을 사용하여 기하 경로의 외관을 제어합니다.
- [GeometryPath.path_data] 속성을 사용하여 도형의 기하 경로를 경로 세그먼트 배열로 가져옵니다.

## **간단한 편집 작업**

다음 메서드들은 간단한 편집 작업에 사용됩니다.

**라인 추가** 경로 끝에:

```py
line_to(point)
line_to(x, y)
```

**라인 추가** 경로의 지정된 위치에:

```py    
line_to(point, index)
line_to(x, y, index)
```

**큐빅 베지어 곡선 추가** 경로 끝에:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**큐빅 베지어 곡선 추가** 경로의 지정된 위치에:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**2차 베지어 곡선 추가** 경로 끝에:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**2차 베지어 곡선 추가** 경로의 지정된 위치에:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**호 추가** 경로에:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**현재 도형 닫기** 경로에서:

```py
close_figure()
```

**다음 점 위치 설정**:

```py
move_to(point)
move_to(x, y)
```

**지정된 인덱스의 경로 세그먼트 제거**:

```py
remove_at(index)
```

## **도형에 사용자 정의 점 추가**

여기에서는 점의 순서를 직접 추가하여 자유형 도형을 정의하는 방법을 배웁니다. 순서가 지정된 점과 세그먼트 유형(직선 또는 곡선)을 지정하고 필요에 따라 경로를 닫음으로써 슬라이드에 정확한 사용자 정의 그래픽(다각형, 아이콘, 말풍선 또는 로고)을 직접 그릴 수 있습니다.

1. [GeometryShape] 클래스의 인스턴스를 생성하고 [ShapeType.RECTANGLE]를 설정합니다.
2. 도형에서 [GeometryPath] 인스턴스를 가져옵니다.
3. 경로의 상단 두 점 사이에 새로운 점을 삽입합니다.
4. 경로의 하단 두 점 사이에 새로운 점을 삽입합니다.
5. 업데이트된 경로를 도형에 적용합니다.

다음 Python 코드가 도형에 사용자 정의 점을 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Custom points](custom_shape_1.png)

##  **도형에서 점 제거**

때때로 사용자 정의 도형에는 불필요한 점이 포함되어 있어 기하학을 복잡하게 하거나 렌더링에 영향을 줄 수 있습니다. 이 섹션에서는 도형 경로에서 특정 점을 제거하여 외곽선을 간소화하고 더 깔끔하고 정확한 결과를 얻는 방법을 보여줍니다.

1. [GeometryShape] 클래스의 인스턴스를 생성하고 [ShapeType.HEART] 유형을 설정합니다.
2. 도형에서 [GeometryPath] 인스턴스를 가져옵니다.
3. 경로에서 세그먼트를 제거합니다.
4. 업데이트된 경로를 도형에 적용합니다.

다음 Python 코드가 도형에서 점을 제거하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Removed points](custom_shape_2.png)

## **사용자 정의 도형 만들기**

라인, 호, 베지어 곡선으로 구성된 [GeometryPath]를 정의하여 맞춤형 벡터 도형을 만듭니다. 이 섹션에서는 처음부터 사용자 정의 기하학을 구축하고 결과 도형을 슬라이드에 추가하는 방법을 보여줍니다.

1. 도형의 점들을 계산합니다.
2. [GeometryPath] 클래스의 인스턴스를 생성합니다.
3. 점들을 사용해 경로를 채웁니다.
4. [GeometryShape] 클래스의 인스턴스를 생성합니다.
5. 경로를 도형에 적용합니다.

다음 Python 코드가 사용자 정의 도형을 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Custom shape](custom_shape_3.png)

## **복합 사용자 정의 도형 만들기**

복합 사용자 정의 도형을 만들면 여러 기하학 경로를 결합하여 슬라이드에 재사용 가능한 단일 도형으로 만들 수 있습니다. 이러한 경로를 정의하고 병합하여 표준 도형 집합을 넘어서는 복잡한 시각 요소를 구축합니다.

1. [GeometryShape] 클래스의 인스턴스를 생성합니다.
2. [GeometryPath] 클래스의 첫 번째 인스턴스를 생성합니다.
3. [GeometryPath] 클래스의 두 번째 인스턴스를 생성합니다.
4. 두 경로를 모두 도형에 적용합니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Composite shape](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 정의 도형 만들기**

이 섹션에서는 기하학 경로를 사용하여 부드럽게 곡선 모서리를 가진 사용자 정의 도형을 그리는 방법을 보여줍니다. 직선 세그먼트와 원호를 결합하여 외곽선을 만들고 완성된 도형을 슬라이드에 추가합니다.

```py
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

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Curved corners](custom_shape_6.png)

## **도형의 기하학이 닫혀 있는지 확인하기**

닫힌 도형은 모든 면이 연결되어 틈 없이 하나의 경계선을 형성하는 것으로 정의됩니다. 이러한 도형은 단순한 기하 형태이거나 복잡한 사용자 정의 윤곽일 수 있습니다. 다음 코드 예제는 도형 기하가 닫혀 있는지 확인하는 방법을 보여줍니다:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**기하학을 교체한 후 채우기와 윤곽선은 어떻게 되나요?**

스타일은 도형에 남아 있으며, 컨투어만 변경됩니다. 채우기와 윤곽선은 새 기하학에 자동으로 적용됩니다.

**기하학과 함께 사용자 정의 도형을 올바르게 회전하려면 어떻게 해야 하나요?**

도형의 [rotation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/geometryshape/rotation/) 속성을 사용하십시오; 기하학은 도형에 바인딩된 자체 좌표계 때문에 도형과 함께 회전합니다.

**결과를 "고정"하기 위해 사용자 정의 도형을 이미지로 변환할 수 있나요?**

예. 필요한 [slide](/slides/ko/python-net/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/python-net/create-shape-thumbnails/) 자체를 래스터 형식으로 내보낼 수 있으며, 이렇게 하면 무거운 기하학 작업을 단순화할 수 있습니다.