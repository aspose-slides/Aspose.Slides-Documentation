---
title: Android에서 프레젠테이션 모양 사용자 지정
linktitle: 사용자 지정 모양
type: docs
weight: 20
url: /ko/androidjava/custom-shape/
keywords:
- 사용자 지정 모양
- 모양 추가
- 모양 만들기
- 모양 변경
- 모양 기하학
- 기하 경로
- 경로 포인트
- 편집 포인트
- 포인트 추가
- 포인트 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 PowerPoint 프레젠테이션의 모양을 만들고 사용자 지정합니다: 기하 경로, 곡선 모서리, 복합 모양."
---
## **개요**

이 문서는 편집 포인트와 기하 경로를 통해 모양 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 모양을 맞춤 설정하는 방법을 설명합니다. [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)와 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/)를 사용하여 기존 모양을 수정하고, 기본 경로 편집 작업을 수행하며, 포인트를 추가·제거하고, 업데이트된 기하학을 모양에 적용하는 방법을 보여줍니다.

또한 사용자 지정 및 복합 모양을 만들고, 곡선 모서리가 있는 모양을 구성하며, 모양 기하학이 닫혔는지 확인하고, Android 포인트 배열을 사용하여 모양 요소를 검사하는 방법도 시연합니다.

## **편집 포인트를 사용하여 모양 변경**

PowerPoint에서 **편집 포인트**를 사용하여 사각형을 수정할 수 있습니다:

* 모서리를 안쪽이나 바깥쪽으로 이동
* 포인트의 곡률 조정
* 새로운 포인트 추가

편집 포인트를 사용하면 모양의 외곽선을 수정하거나 기존 모양을 기반으로 새 모양을 만들 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 모양을 편집할 때 다음 개념을 기억하십시오:

* 모양(또는 그 경로)은 닫히거나 열릴 수 있습니다.
* 모양의 경로는 구간으로 연결된 앵커 포인트로 구성됩니다.
* 구간은 직선이거나 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 부드러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접 구간이 각도로 만납니다.
  * 부드러운 포인트에서는 두 제어 핸들이 정렬되고 앵커 포인트와 같은 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 거리 차이가 있을 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 모양의 외곽선이 변경됩니다.

편집 포인트를 통해 PowerPoint 모양을 편집하려면 **Aspose.Slides**가 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 클래스와 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 인터페이스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 객체의 기하 경로를 나타냅니다.
* [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 메서드를 사용하여 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)를 가져올 수 있습니다.
* 모양에 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)를 설정하려면 단일 경로용 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 메서드와 다중 경로용 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 메서드를 사용합니다.
* 구간을 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 아래의 메서드를 사용합니다.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) 및 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) 메서드를 사용하여 기하 경로의 외관을 설정할 수 있습니다.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/)의 기하 경로를 구간 배열로 가져올 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하 경로를 편집합니다. 인덱스를 받는 오버로드는 해당 인덱스 위치에 구간을 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입 | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 두 제어점과 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 하나의 제어점과 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 지정된 치수와 각도(도)로 타원 호를 추가 | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 끝점을 시작점에 연결하여 현재 도형을 닫음 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| 도형의 시작점을 설정 | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 지정된 인덱스의 구간을 제거 | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **모양에 사용자 지정 포인트 추가**

다음 예제는 [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) 를 사용하여 사각형 모양에 두 개의 포인트를 삽입하고, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 로 편집된 경로를 적용합니다. 좌표는 모양에 대해 로컬이며, 두 새로운 포인트는 모양 중앙에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 구간 인덱스 1과 4는 각각 상단과 하단 가장자리에 배치되어 해당 가장자리를 안쪽으로 끌어당깁니다.

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

다음 예제는 [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) 로 0 기반 인덱스 2에 있는 구간을 제거하여 하트 형태의 외곽선을 변경합니다. 수정된 경로를 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 로 적용하면 모양의 윤곽이 업데이트됩니다.

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

다음 예제는 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 를 사용해 5각 별을 구성합니다. 바깥 반지름 100포인트와 안쪽 반지름 50포인트를 교대로 사용해 꼭짓점과 들뜸을 정의하고, 72도 간격으로 다섯 꼭짓점을 균등하게 배치합니다. 경로는 [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) 로 닫히며, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 로 사각형 모양에 적용되어 기존 외곽선을 대체합니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

다음 예제는 모양의 상·하 3분의 1을 위해 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 모두 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 로 적용하면 중간 3분의 1에 틈이 있는 하나의 복합 모양이 생성됩니다.

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

다음 예제는 직선 구간과 [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) 를 결합해 안쪽으로 굽은 모서리를 가진 모양을 만듭니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 1/4 타원을 그립니다. 완성된 경로는 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 로 적용되며, 프레젠테이션은 PPTX 형식으로 저장됩니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

## **모양 기하학이 닫혔는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하 경로가 닫는 구간으로 끝나는지 검사합니다. [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 를 읽고 최종 구간의 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) 를 [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) 와 비교합니다. 비어 있지 않은 경로가 없을 경우 false를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내 모든 하위 도형을 검사하지는 않습니다. 예제는 사각형에 대해 `true` 를 출력합니다.

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

## **기하 경로 명령 검사**

[contour.pptx](contour.pptx) 를 다운로드하고 샘플 파일 이름을 장치의 경로로 교체하십시오. 첫 번째 슬라이드의 첫 번째 모양은 직선 상단 가장자리, 3차 베지어 곡선, 그리고 직선 닫는 가장자리를 가집니다. [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 로 모양의 경로를 읽고, [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 로 각 경로의 구간을 그리기 순서대로 읽습니다. 각 구간에 대해 [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) 이 명령을 식별하고, [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) 로 반환된 값을 해석하는 방법을 결정합니다.

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

모양은 슬라이드에서 (200, 100) 포인트 위치에 있습니다. 보고된 좌표는 모양에 대해 로컬이며, (0, 0)은 왼쪽 위 모서리, x는 오른쪽으로, y는 아래쪽으로 증가합니다. 닫는 구간은 추가 좌표 없이 시작점으로 돌아갑니다.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **모양 요소 추출 및 검사**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) 를 사용하여 기존 모양을 경로 포인트와 포인트 유형을 포함하는 요소로 검사합니다. 반환된 각 [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) 를 [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) 로 캐스팅하여 [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) 와 [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) 메서드로 포인트와 유형 배열을 가져옵니다. 이 표현은 윤곽선 분석이나 기하학을 사용자 지정 그리기 도구에 전달할 때 유용합니다.

예제는 input.pptx 를 열어 첫 번째 슬라이드에 직접 있는 첫 번째 기하 모양을 찾고 그 경로 구간을 출력합니다. 직선과 곡선 구간이 모두 있는 모양이 포함된 프레젠테이션을 사용하면 두 종류의 출력이 모두 표시됩니다. 그룹 내부는 검색되지 않습니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
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
                        i += 2; // 두 제어점과 끝점을 모두 사용합니다.
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

배열은 인덱스로 일치합니다: `points[i]`는 포인트이며 `types[i]`는 해당 역할을 설명합니다. 유형 `0`은 도형을 시작하고, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그립니다. 3차 베지어 구간은 이전 끝점에서 시작하고 연속된 유형 `3` 세 개(두 제어점 + 새로운 끝점)를 사용합니다. 루프는 이 세 항목을 함께 소비하고 끝점이 닫힘인지 확인합니다.

포인트 유형에는 플래그도 포함됩니다. `0x07` 마스크를 사용해 구간 유형을 식별하고, `0x80` 플래그는 닫힌 하위 경로를 나타냅니다. 예를 들어 `129`(`0x81`)은 닫힌 하위 경로의 선 끝점이고, `131`(`0x83`)은 닫힌 베지어 끝점입니다. Java는 이러한 플래그를 부호 있는 바이트에 저장하므로 마스킹을 통해 의도된 비트를 유지해야 합니다. 값을 `1` 또는 `3`만으로 비교하면 이런 경우를 놓칠 수 있습니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 구간 유형에 영향을 주지 않습니다.

**좌표 및 변환**. 포인트는 포인트 단위(1/72인치)이며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 모양의 경우 추출된 좌표에는 이미 [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) 와 [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) 로 반환된 위치가 포함되어 현재 너비와 높이를 반영합니다. 예를 들어 `(100, 200)` 위치에 `120 × 80` 크기의 회전되지 않은 사각형은 윤곽 경계가 `(100, 200)`–`(220, 280)` 입니다. 위치를 다시 더하지 마십시오. X와 Y를 빼서 회전되지 않은 프레임에 대한 좌표를 얻으십시오.

추출된 포인트는 [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) 로 반환된 모양 회전이나 수평·수직 반전은 적용하지 않습니다. 표시된 윤곽을 재현하려면 이러한 변환을 모양 중심을 기준으로 적용하십시오. 그룹화된 모양의 경우 그룹 좌표 매핑 및 변환도 고려해야 하며, 추출된 포인트가 최종 슬라이드 좌표가 아니거나 이미 자식 프레임에 반영된 변환을 두 번 적용하지 않도록 주의하십시오.

**검사 vs. 편집**. 추출된 배열은 윤곽을 설명하며, 이를 변경해도 원본 모양은 업데이트되지 않습니다. 포인트/유형 배열이 필요한 분석이나 그리기 코드에 적합합니다. 로컬 좌표계에서 기하 명령이 필요하거나 기하를 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 를 사용하십시오. 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 또는 [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 로 적용합니다.

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 모양에 그대로 남으며, 윤곽만 변경됩니다. 채우기와 외곽선은 자동으로 새로운 기하학에 적용됩니다.

**기하학과 함께 사용자 지정 모양을 올바르게 회전하려면 어떻게 해야 하나요?**

모양의 [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) 메서드를 사용하십시오. 기하학은 모양의 좌표계에 바인딩되어 있기 때문에 모양과 함께 회전됩니다.

**사용자 지정 모양을 이미지로 변환해 결과를 “잠그”고 싶나요?**

예. 필요한 [slide](/slides/ko/androidjava/convert-powerpoint-to-png/) 영역 또는 [shape](/slides/ko/androidjava/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학을 다룰 때 작업이 간편해집니다.