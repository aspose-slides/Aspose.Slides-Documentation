---
title: Java에서 프레젠테이션 모양 사용자 지정
linktitle: 사용자 지정 모양
type: docs
weight: 20
url: /ko/java/custom-shape/
keywords:
- 사용자 지정 모양
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 모양을 만들고 사용자 지정합니다: 기하학 경로, 곡선 모서리, 복합 모양."
---
## **개요**

이 문서는 편집 포인트와 기하학 경로를 통해 모양 기하학을 편집하여 Aspose.Slides 프레젠테이션 모양을 사용자 정의하는 방법을 설명합니다. 기존 모양을 수정하고, 기본 경로 편집 작업을 수행하며, 포인트를 추가 또는 제거하고, 업데이트된 기하학을 모양에 다시 적용하기 위해 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 및 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)를 사용하는 방법을 보여줍니다.

또한 사용자 지정 및 복합 모양을 만드는 방법, 곡선 모서리가 있는 모양을 구성하는 방법, 모양 기하학이 닫혀 있는지 판단하는 방법, 모양 요소를 검사하는 방법, Java AWT 텍스트 윤곽을 기하학 경로로 변환하는 방법을 시연합니다.

## **편집 포인트를 사용하여 모양 변경**

PowerPoint에서 **Edit Points**를 사용하여 정사각형을 수정할 수 있습니다:

* 모서리를 안쪽이나 바깥쪽으로 이동합니다.
* 포인트에서 곡률을 조정합니다.
* 새 포인트를 추가합니다.

편집 포인트를 사용하면 모양의 외곽선을 수정하거나 기존 모양을 기반으로 새 모양을 만들 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 모양을 편집할 때 다음 개념을 기억하세요:

* 모양(또는 그 경로)은 닫혀 있거나 열려 있을 수 있습니다.
* 모양의 경로는 구간으로 연결된 앵커 포인트로 구성됩니다.
* 구간은 직선이거나 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 구간의 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 매끄러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접 구간이 각도를 이루며 만납니다.
  * 매끄러운 포인트에서는 두 제어 핸들이 정렬되고 앵커 포인트에서 같은 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 앵커 포인트에서 거리가 다를 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 모양의 외곽선이 바뀝니다.

PowerPoint 모양을 편집 포인트로 편집하려면 **Aspose.Slides**가 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 클래스와 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 인터페이스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 객체의 기하학 경로를 나타냅니다.
* [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)를 가져오려면 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) 메서드를 사용할 수 있습니다.
* 모양에 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)를 설정하려면 단일 경로 모양의 경우 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 메서드를, 다중 경로 모양의 경우 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 메서드를 사용합니다.
* 구간을 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) 및 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 메서드를 사용하여 기하학 경로의 외관을 설정할 수 있습니다.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/)의 기하학 경로를 구간 배열로 가져올 수 있습니다.
* 추가적인 모양 기하학 사용자 정의 옵션에 접근하려면 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 를 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 를 통해 읽고 그 구간을 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)에 다시 재생할 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하학 경로를 편집합니다. 인덱스를 받는 오버로드는 해당 제로 기반 위치에 구간을 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 두 개의 제어점과 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 하나의 제어점과 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 지정된 치수와 각도(도)로 타원형 호를 추가합니다. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 현재 도형의 끝점을 시작점에 연결하여 도형을 닫습니다. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| 도형의 시작점을 설정합니다. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 제로 기반 인덱스에 있는 구간을 제거합니다. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **모양에 사용자 지정 포인트 추가**

이 예제는 [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-)을 사용하여 사각형 모양에 두 개의 포인트를 삽입하고, 편집된 경로를 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)으로 적용합니다. 좌표는 모양에 대해 로컬이며, 두 새 포인트는 모양의 중앙에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 구간 인덱스 1과 4는 각각 위쪽 및 아래쪽 가장자리에 배치되어 해당 가장자를 안쪽으로 끌어당깁니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **모양에서 포인트 제거**

이 예제는 [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-)을 사용하여 제로 기반 인덱스 2에 있는 구간을 제거함으로써 하트형 윤곽을 변경합니다. 수정된 경로를 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)으로 적용하면 모양의 외곽이 업데이트됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **사용자 지정 모양 만들기**

이 예제는 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)를 사용하여 5각 별을 구축합니다. 외부 반경 100포인트와 내부 반경 50포인트를 교대로 사용하여 꼭짓점과 함몰 부분을 정의하고, 72도 간격으로 다섯 꼭짓점을 균등하게 배치합니다. 경로는 [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--)으로 닫히고, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)을 사용해 사각형 모양에 적용되어 기존 외곽을 대체합니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **복합 사용자 지정 모양 만들기**

이 예제는 모양의 상위 및 하위 3분의 1 영역을 위해 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 모두 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)으로 적용하면 가운데 3분의 1에 틈이 있는 단일 복합 모양이 생성됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 지정 모양 만들기**

이 예제는 직선 구간과 [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-)를 결합하여 안쪽으로 굽은 모서리를 가진 모양을 만듭니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 사분원 타원을 그립니다. 완성된 경로는 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)으로 적용되며, 프레젠테이션은 PPTX 형식으로 저장됩니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **모양 기하학이 닫혀 있는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하학 경로가 닫는 구간으로 끝나는지 확인합니다. [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--)를 읽고 최종 구간의 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--)를 [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없을 경우 false를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내 모든 하위 도형을 검사하지는 않습니다. 예제는 사각형에 대해 `true`를 출력합니다.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **기하학 경로 명령 검사**

[contour.pptx](contour.pptx)를 다운로드하여 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드의 첫 번째 모양은 직선 상단 가장자리, 3차 베지어 곡선, 그리고 직선 닫힘 가장자를 가집니다. [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--)을 사용해 모양의 경로를 읽고, [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--)를 사용해 각 경로의 구간을 그리기 순서대로 읽습니다. 각 구간에 대해 [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--)이 명령을 식별하고, [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--)가 반환하는 값을 해석하는 방법을 결정합니다.

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

모양은 슬라이드 상에서 (200, 100) 포인트에 위치합니다. 보고된 좌표는 모양에 대해 로컬이며, (0, 0)은 모양의 왼쪽 위 모서리이고, x는 오른쪽으로, y는 아래쪽으로 증가합니다. 닫는 구간은 추가 좌표 없이 시작점으로 돌아갑니다.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **모양 요소 추출 및 검사**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--)을 사용해 기존 모양을 경로 포인트와 포인트 유형을 포함하는 요소로 검사합니다. 반환된 각 [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/)을 [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/)으로 캐스팅하여 [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--)와 [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) 메서드를 통해 포인트와 유형 배열을 가져옵니다. 이 표현은 컨투어 분석이나 사용자 지정 그리기 도구에 기하학을 전달할 때 유용합니다.

예제는 input.pptx를 열고 첫 번째 슬라이드에 직접 있는 첫 번째 기하학 모양을 찾아 그 경로 구간을 출력합니다. 직선 및 곡선 구간이 모두 포함된 모양이 있는 프레젠테이션을 사용하면 두 종류의 출력 모두를 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // 세그먼트 유형을 유지하고 플래그는 제외합니다.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

배열은 인덱스로 대응됩니다: `points[i]`는 포인트이고 `types[i]`는 그 역할을 설명합니다. 유형 `0`은 도형을 시작하고, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그립니다. 3차 베지어 구간은 이전 끝점에서 시작하고 연속된 유형 `3` 세 개를 사용합니다: 두 개의 제어점과 새 끝점. 루프는 이 세 항목을 함께 소비하고 끝점이 닫힘인지 확인합니다.

포인트 유형에는 플래그도 포함됩니다. `0x07` 마스크를 사용해 구간 유형을 식별하고, `0x80`을 별도로 테스트해 닫힌 하위 경로를 감지합니다. 예를 들어 `129`(`0x81`)은 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 하위 경로를 닫는 베지어 끝점입니다. Java는 이러한 플래그를 부호 있는 바이트에 저장하므로 마스킹을 해야 의도한 비트 값을 유지합니다. 원시 값을 `1`이나 `3`만으로 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 구간 유형을 변경하지 않습니다.

**좌표 및 변환** 점은 포인트(1/72인치) 단위이며 X는 오른쪽, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 모양의 경우 추출된 좌표는 이미 [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--)와 [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--)가 반환한 위치를 포함하고 현재 너비와 높이를 반영합니다. 예를 들어 회전되지 않은 사각형이 `(100, 200)`에 위치하고 크기가 `120 × 80`이면 컨투어 경계는 `(100, 200)`–`(220, 280)`입니다. 위치를 다시 추가하지 마세요. X와 Y를 빼서 회전되지 않은 프레임에 대한 좌표를 얻으세요.

추출된 포인트는 [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--)이 반환하는 회전이나 가로·세로 뒤집기를 적용하지 않습니다. 표시된 컨투어를 재현하려면 이러한 변환을 모양 중앙을 기준으로 적용하세요. 그룹화된 모양의 경우 그룹 좌표 매핑과 변환도 고려해야 하며, 추출된 포인트가 최종 슬라이드 좌표가 아니거나 이미 자식 프레임에 반영된 경우 번역이나 스케일을 두 번 적용하지 않도록 하세요.

**검사 vs. 편집** 추출된 배열은 컨투어를 설명하지만, 이를 변경해도 원본 모양이 업데이트되지 않습니다. 포인트/유형 배열이 필요하고 분석이나 그리기 코드에 사용할 때 이 접근 방식을 선택하십시오. 모양의 로컬 좌표계에서 기하학 명령이 필요하거나 기하학을 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--)를 사용하십시오. 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 또는 [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)를 통해 적용합니다.

## **Java AWT Shape를 GeometryPath로 변환**

이 예제는 텍스트를 기하학으로 변환한 사각형 윤곽을 결합합니다. 윤곽의 [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 메서드는 채우기를 비활성화합니다. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html)는 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)에서 텍스트 윤곽을 생성합니다. 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)는 이동, 직선, 2차, 3차, 닫힘 구간을 제공하며, 예제는 이를 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)에 재생합니다.

텍스트는 40포인트 Arial 폰트를 사용합니다. 윤곽은 수평으로 20포인트 오프셋되고, 시각적 상단이 모양의 상단 가장자리 아래 10포인트에 배치됩니다. 텍스트 경로는 채워지고, 원래 사각형은 윤곽만 유지됩니다. 두 경로를 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)으로 적용하면 사각형과 텍스트를 포함하는 단일 모양이 생성됩니다.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // 새 모양 만들기
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 모양의 기하학 경로 가져오기
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 텍스트로 새로운 그래픽 경로 만들기
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // 그래픽 경로를 기하학 경로로 변환
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // 새 기하학 경로와 원본 기하학 경로를 결합하여 모양에 설정
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 모양에 그대로 남으며, 외곽선만 변경됩니다. 채우기와 외곽선은 새로운 기하학에 자동으로 적용됩니다.

**기하학과 함께 사용자 지정 모양을 올바르게 회전하려면 어떻게 해야 하나요?**

모양의 [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) 메서드를 사용하세요. 기하학은 모양에 바인딩되어 있기 때문에 모양을 회전하면 기하학도 함께 회전합니다.

**결과를 “잠그기” 위해 사용자 지정 모양을 이미지로 변환할 수 있나요?**

예. 필요한 [slide](/slides/ko/java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학 작업을 더 쉽게 진행할 수 있습니다.