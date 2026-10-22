---
title: JavaScript에서 프레젠테이션 모양 사용자 정의
linktitle: 사용자 정의 모양
type: docs
weight: 20
url: /ko/nodejs-java/custom-shape/
keywords:
- 사용자 정의 모양
- 모양 추가
- 모양 만들기
- 모양 변경
- 모양 기하
- 기하 경로
- 경로 포인트
- 편집 포인트
- 포인트 추가
- 포인트 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 프레젠테이션에서 모양을 만들고 사용자 정의합니다: 기하 경로, 곡선 모서리, 복합 모양."
---
## **개요**

이 문서에서는 편집 포인트와 기하 경로를 통해 모양 기하를 편집하여 Aspose.Slides에서 프레젠테이션 모양을 사용자 정의하는 방법을 설명합니다. 기존 모양을 수정하고, 기본 경로 편집 작업을 수행하고, 포인트를 추가하거나 제거한 뒤, 업데이트된 기하를 모양에 적용하기 위해 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)을 사용하는 방법을 보여줍니다.

또한 사용자 정의 및 복합 모양을 만들고, 곡선 모서리가 있는 모양을 구성하고, 모양 기하가 닫혀 있는지 확인하고, 모양 요소를 검사하며, Java AWT 텍스트 윤곽선을 기하 경로로 변환하는 방법을 시연합니다.

## **편집 포인트를 사용하여 모양 변경**

PowerPoint에서 **편집 포인트**를 사용하여 사각형을 수정할 수 있습니다.

* 모서리를 안쪽 또는 바깥쪽으로 이동합니다.
* 포인트의 곡률을 조정합니다.
* 새 포인트를 추가합니다.

편집 포인트를 사용하면 모양의 외곽선을 수정하거나 기존 모양을 새 모양의 기반으로 사용할 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 모양을 편집할 때 다음 개념을 기억하십시오.

* 모양(또는 그 경로)은 닫힌 형태이거나 열린 형태일 수 있습니다.
* 모양의 경로는 구간으로 연결된 앵커 포인트로 구성됩니다.
* 구간은 직선이거나 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 형태를 결정합니다.
* 앵커 포인트는 모서리 포인트, 직선 포인트, 매끄러운 포인트로 존재합니다.
  * 모서리 포인트에서는 인접 구간이 각도로 만날 수 있습니다.
  * 매끄러운 포인트에서는 두 제어 핸들이 정렬되어 앵커 포인트에서 같은 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 앵커 포인트에서 거리 차이가 있을 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 모양의 외곽선이 변경됩니다.

편집 포인트를 통해 PowerPoint 모양을 편집하려면 **Aspose.Slides**가 제공하는 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 클래스를 사용합니다.

* [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 인스턴스는 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 객체의 기하 경로를 나타냅니다.
* [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)를 가져오려면 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) 메서드를 사용합니다.
* 모양에 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)를 설정하려면 단일 경로 모양에는 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), 다중 경로 모양에는 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) 메서드를 사용합니다.
* 구간을 추가하려면 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) 및 [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) 메서드를 사용하여 기하 경로의 외관을 설정할 수 있습니다.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)의 기하 경로를 구간 배열로 가져올 수 있습니다.
* 추가적인 모양 기하 사용자 지정 옵션에 접근하려면 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)을 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)으로 읽은 뒤, 구간을 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)에 재생할 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하 경로를 편집합니다. 인덱스를 받는 오버로드는 경로 구간 배열의 해당 0 기반 위치에 구간을 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| 두 제어점과 끝점이 있는 3차 베지에 곡선을 추가하거나 삽입합니다. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 하나의 제어점과 끝점이 있는 2차 베지에 곡선을 추가하거나 삽입합니다. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 지정된 크기와 각도(도)로 타원형 호를 추가합니다. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| 현재 피규어를 닫아 끝점을 시작점에 연결합니다. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| 피규어의 시작점을 설정합니다. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| 0 기반 인덱스에서 구간을 제거합니다. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **모양에 사용자 정의 포인트 추가**

다음 예제는 [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo)를 사용하여 사각형 모양에 두 개의 포인트를 삽입하고, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)으로 편집된 경로를 적용합니다. 좌표는 모양에 대해 로컬이며, 두 새 포인트는 모양의 중앙에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 구간 인덱스 1과 4는 각각 위쪽 및 아래쪽 가장자리에 배치되어 해당 가장자리를 안쪽으로 끌어당깁니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **모양에서 포인트 제거**

다음 예제는 [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt)를 사용해 인덱스 2(0 기반)의 구간을 제거함으로써 하트 모양 외곽을 변경합니다. 수정된 경로를 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용하면 모양의 윤곽이 업데이트됩니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **사용자 정의 모양 만들기**

다음 예제는 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)를 사용해 5각 별을 구성합니다. 외부와 내부 반지름을 각각 100포인트와 50포인트로 교대로 지정하여 팁과凹을 정의하고, 72도 간격으로 다섯 팁을 균등하게 배치합니다. 경로는 [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure)으로 닫힌 뒤, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)으로 사각형 모양에 적용되어 기존 외곽을 대체합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **복합 사용자 정의 모양 만들기**

이 예제는 모양의 상단과 하단 1/3을 각각 위한 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)으로 적용하면 중간 1/3에 틈이 있는 단일 복합 모양이 생성됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 정의 모양 만들기**

이 예제는 직선 구간과 [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo)를 결합해 안쪽으로 굽은 모서리를 가진 모양을 생성합니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 지정하고, -90도 스윕은 반시계 방향 사분원 타원을 그립니다. 완성된 경로는 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)으로 적용되고, 프레젠테이션은 PPTX 형식으로 저장됩니다.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **모양 기하가 닫혀 있는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하 경로가 닫는 구간으로 끝나는지 확인합니다. [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData)를 읽고 마지막 구간의 [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand)와 [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/)를 비교합니다. 비어 있지 않은 경로가 없을 경우 false를 반환합니다. 이 검사는 각 경로의 마지막 명령만 확인하며, 경로 내 모든 하위 피규어를 검사하지는 않습니다. 예제는 사각형에 대해 `true`를 출력합니다.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **모양 요소 추출 및 검사**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements)를 사용하면 기존 모양을 경로 포인트와 포인트 유형을 포함하는 요소로 검사할 수 있습니다. 반환된 각각의 [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/)을 이용해 [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints)와 [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) 메서드로 포인트와 유형 배열을 가져올 수 있습니다. 이 표현은 윤곽 분석이나 사용자 정의 그리기 도구에 기하를 전달할 때 유용합니다.

예제는 input.pptx를 열어 첫 번째 슬라이드에 있는 첫 번째 기하 모양을 찾고, 해당 경로 구간을 출력합니다. 직선 및 곡선 구간이 포함된 모양이 있는 프레젠테이션을 사용하면 두 종류의 출력 모두 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // 플래그를 제외하고 구간 유형을 유지합니다.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 두 개의 제어점과 끝점을 모두 사용합니다.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

배열은 인덱스로 대응됩니다: `points[i]`는 포인트이고 `types[i]`는 그 역할을 설명합니다. 유형 `0`은 피규어 시작을, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그리는 것을 의미합니다. 3차 베지에 구간은 이전 끝점에서 시작하며 연속된 유형 `3` 항목 세 개(두 제어점 + 새로운 끝점)를 사용합니다. 루프는 이 세 항목을 함께 소비하고 끝점이 닫혀 있는지 확인합니다.

포인트 유형에는 플래그도 포함됩니다. `0x07`로 마스크하여 구간 유형을 식별하고, `0x80`을 별도로 테스트해 닫힌 하위 경로를 감지합니다. 예를 들어 `129`(`0x81`)는 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 닫힌 베지에 끝점입니다. Java는 이 플래그를 부호 있는 바이트로 저장하므로 마스킹이 의도한 비트 값을 유지합니다. 원시 값을 `1` 또는 `3`만으로 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`) 같은 다른 플래그는 기본 구간 유형을 변경하지 않습니다.

**좌표와 변환**. 포인트는 포인트(1/72인치) 단위이며 X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 모양의 경우 추출된 좌표에는 이미 [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX)와 [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY)에서 반환된 위치가 포함되어 현재 너비와 높이를 반영합니다. 예를 들어 `(100, 200)` 위치에 크기 `120 × 80`인 회전되지 않은 사각형은 외곽 경계가 `(100, 200)`–`(220, 280)`입니다. 위치를 다시 더하지 마세요. X와 Y를 빼서 회전되지 않은 프레임 기준 좌표를 얻으세요.

추출된 포인트는 [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation)으로 반환되는 모양의 회전이나 수평·수직 뒤집기를 적용하지 않습니다. 표시된 외곽을 재현하려면 해당 변환을 모양 중심을 기준으로 적용하세요. 그룹화된 모양의 경우 그룹 좌표 매핑 및 변환도 고려해야 하며, 추출된 포인트가 최종 렌더링 슬라이드 좌표가 아니거나 이미 자식 프레임에 반영된 변환을 두 번 적용하지 않도록 주의하세요.

**검사와 편집 구분**. 추출된 배열은 외곽을 설명하며, 이를 변경해도 원본 모양은 업데이트되지 않습니다. 분석이나 그리기 코드가 포인트/유형 배열이 필요할 때 이 방식을 선택하십시오. 모양의 로컬 좌표계에서 기하 명령이 필요하거나 기하를 편집하려면 [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths)를 사용하세요. 편집된 경로는 [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 또는 [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)를 통해 적용합니다.

## **Java AWT Shape를 GeometryPath로 변환**

이 예제는 텍스트를 기하로 변환한 사각형 외곽을 결합합니다. 외곽의 [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) 메서드는 채우기를 비활성화합니다. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html)은 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)에서 텍스트 외곽을 생성합니다. 해당 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)는 이동, 직선, 2차, 3차 및 닫기 구간을 제공하며, 예제는 이를 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)에 재생합니다.

Java 브리지에서는 해당 Java 매개변수에 대해 명시적인 float 및 byte 값을 사용합니다. 반복자는 좌표를 Java float 배열에 기록하고, 리플렉션은 업데이트된 값을 JavaScript으로 다시 읽어들입니다. 텍스트는 40포인트 Arial 폰트를 사용합니다. 외곽은 수평으로 20포인트 오프셋되고, 시각적 상단이 모양 상단 가장자리 아래 10포인트에 배치됩니다. 텍스트 경로는 채워지고, 원본 사각형은 외곽만 남습니다. 두 경로를 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)으로 적용하면 사각형과 텍스트를 포함하는 단일 모양이 생성됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // 이동.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // 직선.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // 2차 베지에 곡선.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // 3차 베지에 곡선.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // 피규어 닫기.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**기하를 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 모양에 그대로 남으며, 외곽선만 변경됩니다. 채우기와 외곽선은 새로운 기하에 자동으로 적용됩니다.

**기하와 함께 사용자 정의 모양을 올바르게 회전하려면 어떻게 해야 하나요?**

모양의 [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) 메서드를 사용하십시오. 기하가 모양 자체의 좌표계에 바인딩되어 있기 때문에 회전과 함께 회전됩니다.

**결과를 “잠그기” 위해 사용자 정의 모양을 이미지로 변환할 수 있나요?**

예. 필요한 [slide](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/nodejs-java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하 작업을 더 쉽게 진행할 수 있습니다.