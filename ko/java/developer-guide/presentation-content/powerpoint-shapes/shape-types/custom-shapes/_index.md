---
title: Java에서 프레젠테이션 도형 사용자 지정
linktitle: 맞춤형 도형
type: docs
weight: 20
url: /ko/java/custom-shape/
keywords:
- 맞춤형 도형
- 도형 추가
- 도형 만들기
- 도형 변경
- 도형 기하학
- 기하 경로
- 경로 점
- 편집 점
- 점 추가
- 점 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 도형을 생성하고 사용자 지정합니다: 기하 경로, 곡선 모서리, 복합 도형."
---
## **개요**

이 문서는 편집 지점과 기하 경로를 통해 도형의 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 도형을 사용자 지정하는 방법을 설명합니다. 기존 도형을 수정하고, 기본 경로 편집 작업을 수행하고, 점을 추가하거나 제거하며, 업데이트된 기하학을 도형에 다시 적용하기 위해 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)와 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)를 사용하는 방법을 보여줍니다.

또한 사용자 지정 및 복합 도형을 만들고, 곡선 모서리가 있는 도형을 구축하고, 도형 기하학이 닫혀 있는지 확인하고, 도형 요소를 검사하며, Java AWT 텍스트 윤곽을 기하 경로로 변환하는 방법을 시연합니다.

## **편집 지점을 사용하여 도형 변경**

PowerPoint에서 **편집 지점**을 사용하여 사각형을 수정할 수 있습니다:

* 모서리를 안쪽이나 바깥쪽으로 이동합니다.
* 점에서 곡률을 조정합니다.
* 새 점을 추가합니다.

편집 지점을 사용하면 도형의 외곽선을 수정하거나 기존 도형을 기반으로 새 도형을 만들 수 있습니다.

## **도형 편집 팁**

![개요_이미지](custom_shape_0.png)

PowerPoint 도형을 편집할 때 다음 개념을 기억하세요:

* 도형(또는 그 경로)은 닫힌 형태일 수도 있고 열려 있을 수도 있습니다.
* 도형의 경로는 세그먼트로 연결된 앵커 포인트들로 구성됩니다.
* 세그먼트는 직선이거나 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 부드러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접한 세그먼트가 각을 이루며 만납니다.
  * 부드러운 포인트에서는 두 제어 핸들이 정렬되고 앵커 포인트로부터 동일한 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 앵커 포인트로부터 거리가 다를 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 도형의 외곽선이 변합니다.

편집 지점을 통해 PowerPoint 도형을 편집하려면 **Aspose.Slides**가 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 클래스와 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 인터페이스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 객체의 기하 경로를 나타냅니다.
* [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)를 가져오려면 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) 메서드를 사용할 수 있습니다.
* 도형에 대한 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)를 설정하려면 단일 경로 도형에는 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 메서드를, 다중 경로 도형에는 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 메서드를 사용할 수 있습니다.
* 세그먼트를 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) 및 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 메서드를 사용해 기하 경로의 외관을 설정할 수 있습니다.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/)의 기하 경로를 세그먼트 배열로 가져올 수 있습니다.
* 추가적인 도형 기하 맞춤 옵션에 접근하려면 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)를 그 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 를 통해 읽고, 해당 세그먼트를 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)에 재생할 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용해 기하 경로를 편집하세요. 인덱스를 받아들이는 오버로드는 해당 위치에 세그먼트를 삽입합니다(0부터 시작).

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 두 개의 제어점과 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 하나의 제어점과 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 지정된 크기와 각도(도)로 타원 호를 추가합니다. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 현재 피규어를 닫아 끝점을 시작점에 연결합니다. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| 피규어의 시작점을 설정합니다. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 0부터 시작하는 인덱스의 세그먼트를 제거합니다. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **도형에 사용자 지정 점 추가**

이 예제는 [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-)을 사용해 직사각형 도형에 두 점을 삽입하고, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)으로 편집된 경로를 적용합니다. 좌표는 도형에 상대적이며, 두 새로운 점은 각각 왼쪽에서 100포인트, 위에서 50포인트 떨어진 도형 중앙에 위치합니다. 세그먼트 인덱스 1과 4는 각각 상단과 하단 가장자리에 배치되어 해당 가장자리를 안쪽으로 당깁니다.

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

![예제1_이미지](custom_shape_1.png)

## **도형에서 점 제거**

이 예제는 [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-)을 사용해 0부터 시작하는 인덱스 2에 있는 세그먼트를 제거하여 하트 모양 외곽선을 변경합니다. [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)을 사용해 수정된 경로를 적용하면 도형의 윤곽이 업데이트됩니다.

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
![예제2_이미지](custom_shape_2.png)

## **사용자 지정 도형 만들기**

이 예제는 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)를 사용해 다섯 꼭짓점 별을 구축합니다. 외부 반경 100포인트와 내부 반경 50포인트를 번갈아가며 팁과 오목함을 정의하고, 72도 간격으로 다섯 팁을 고르게 배치합니다. 경로는 [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--)으로 닫힌 뒤, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)을 사용해 직사각형 도형에 적용되어 기존 외곽선을 대체합니다.

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
![예제3_이미지](custom_shape_3.png)

## **복합 사용자 지정 도형 만들기**

이 예제는 도형의 상단 1/3와 하단 1/3에 대해 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 모두 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)으로 적용하면 중간 1/3에 틈이 있는 단일 복합 도형이 생성됩니다.

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
![예제4_이미지](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 지정 도형 만들기**

이 예제는 직선 세그먼트와 [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-)을 결합해 안쪽으로 굽은 모서리를 가진 도형을 만듭니다. 각 모서리 크기는 아크의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 1/4 타원을 그립니다. 완성된 경로는 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)으로 적용되고, 프레젠테이션은 PPTX 형식으로 저장됩니다.

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

## **도형 기하가 닫혀 있는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하 경로가 닫는 세그먼트로 끝나는지 검사합니다. [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--)를 읽고 마지막 세그먼트의 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--)를 [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없으면 false를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내 모든 하위 피규어를 검사하지는 않습니다. 예제는 사각형에 대해 `true`를 출력합니다.

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

## **도형 요소 추출 및 검사**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--)을 사용해 기존 도형을 경로 점 및 점 유형을 포함하는 요소로 검사합니다. 반환된 각 [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/)을 [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/)으로 캐스팅하여 [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--)와 [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) 메서드를 통해 점 및 유형 배열을 가져옵니다. 이 표현은 윤곽 분석이나 사용자 지정 그리기 도구에 기하를 전달할 때 유용합니다.

예제는 input.pptx를 열고 첫 번째 슬라이드에서 첫 번째 기하 도형을 찾아 그 경로 세그먼트를 출력합니다. 직선 및 곡선 세그먼트를 포함한 도형이 있는 프레젠테이션을 사용하면 두 종류의 출력 모두를 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

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

배열은 인덱스로 대응합니다: `points[i]`는 점이고 `types[i]`는 그 역할을 설명합니다. 타입 `0`은 피규어 시작을, 타입 `1`은 이전 점에서 현재 점까지 선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하며 연속된 타입 `3` 항목 세 개(두 제어점과 새로운 끝점)를 사용합니다. 루프는 이 세 항목을 함께 소비하고 끝점이 닫혔는지 확인합니다.

점 유형에는 플래그도 포함됩니다. `0x07`로 마스크하여 세그먼트 유형을 식별하고, `0x80`을 별도로 테스트해 닫힌 하위 경로를 감지합니다. 예를 들어 `129`(`0x81`)는 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 닫힌 베지어 끝점입니다. Java는 이러한 플래그를 부호 있는 바이트로 저장하므로 마스크 연산을 사용해 의도된 비트를 보존해야 합니다. `1`이나 `3`만으로 원시 값을 비교하면 이런 경우를 놓칠 수 있습니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환** 점은 포인트(1/72인치) 단위이며 X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 도형의 경우 추출된 좌표에는 이미 [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--)와 [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--)가 반환하는 위치가 포함되어 현재 너비와 높이를 반영합니다. 예를 들어 `(100, 200)` 위치에 크기 `120 × 80`인 회전되지 않은 사각형은 외곽 경계가 `(100, 200)`–`(220, 280)`입니다. 도형 위치를 다시 추가하지 마세요. X와 Y를 빼서 회전되지 않은 프레임을 기준으로 좌표를 얻습니다.

추출된 점은 [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--)이 반환하는 도형 회전이나 수평·수직 뒤집기를 적용하지 않습니다. 표시된 윤곽을 재현하려면 도형 중심을 기준으로 이러한 변환을 적용하세요. 그룹에 속한 도형의 경우 그룹 좌표 매핑 및 변환도 고려해야 하며, 추출된 점이 최종 슬라이드 좌표가 아니므로 변환이나 스케일을 두 번 적용하지 않도록 주의하세요.

**검사 vs 편집** 추출된 배열은 윤곽을 설명할 뿐이며 이를 변경해도 원본 도형이 업데이트되지 않습니다. 점/유형 배열이 필요한 분석 또는 그리기 코드에 이 접근 방식을 사용하세요. 도형 로컬 좌표계에서 기하 명령이 필요하거나 기하를 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--)를 사용하고, 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 또는 [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)으로 적용하세요.

## **Java AWT Shape를 GeometryPath로 변환**

이 예제는 사각형 외곽과 텍스트를 기하 형태로 결합합니다. 외곽의 [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 메서드는 채우기를 비활성화합니다. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html)은 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)에서 텍스트 윤곽을 생성합니다. 그 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)는 이동, 선, 2차, 3차 및 닫기 세그먼트를 제공하며, 예제는 이를 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)에 재생합니다.

텍스트는 40포인트 Arial 폰트를 사용합니다. 외곽은 가로로 20포인트 오프셋되고, 시각적 상단이 도형 상단에서 10포인트 아래에 위치합니다. 텍스트 경로는 채워지고, 원래 사각형은 외곽선만 남습니다. 두 경로를 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)으로 적용하면 사각형과 텍스트를 포함하는 단일 도형이 생성됩니다.

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
    // 새 도형 만들기
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 도형의 기하 경로 가져오기
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 텍스트가 포함된 새로운 그래픽 경로 만들기
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

    // 그래픽 경로를 기하 경로로 변환
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

    // 새 기하 경로와 원본 기하 경로의 조합을 도형에 설정
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![예제5_이미지](custom_shape_5.png)

## **FAQ**

**기하를 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 도형에 그대로 유지되며, 윤곽선만 변경됩니다. 채우기와 외곽선은 새 기하에 자동으로 적용됩니다.

**기하와 함께 사용자 지정 도형을 올바르게 회전하려면 어떻게 해야 하나요?**

도형의 [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) 메서드를 사용하세요. 기하가 도형 자체 좌표계에 바인드되어 있기 때문에 도형과 함께 회전됩니다.

**결과를 “잠그기” 위해 사용자 지정 도형을 이미지로 변환할 수 있나요?**

예. 필요한 [slide](/slides/ko/java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하 작업을 더 쉽게 진행할 수 있습니다.