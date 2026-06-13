---
title: JavaScript에서 프레젠테이션 모양 사용자 정의
linktitle: 맞춤형 모양
type: docs
weight: 20
url: /ko/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 프레젠테이션에서 모양을 만들고 사용자 정의합니다: 기하학 경로, 곡선 모서리, 복합 모양."
---
## **개요**

이 문서는 편집 포인트와 기하학 경로를 통해 모양 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 모양을 사용자 정의하는 방법을 설명합니다. `GeometryPath`를 사용하여 기존 모양을 수정하고, 기본 경로 편집 작업을 수행하며, 포인트를 추가하거나 제거하고, 업데이트된 기하학을 모양에 적용하는 방법을 보여줍니다.

또한 사용자 정의 및 복합 모양을 만드는 방법, 곡선 모서리가 있는 모양을 구축하는 방법, 모양 기하학이 닫혀 있는지 여부를 판단하는 방법, 그리고 추가 기하학 사용자 정의 시나리오를 위해 `GeometryPath`와 `java.awt.Shape` 간에 변환하는 방법을 보여줍니다.

## **편집 포인트를 사용하여 모양 변경**

정사각형을 생각해 보세요. PowerPoint에서 **편집 포인트**를 사용하면

* 정사각형 모서리를 안쪽이나 바깥쪽으로 움직일 수 있습니다
* 모서리 또는 포인트의 곡률을 지정할 수 있습니다
* 정사각형에 새로운 포인트를 추가할 수 있습니다
* 정사각형의 포인트를 조작할 수 있습니다 등.

본질적으로, 이러한 작업은 모든 모양에 대해 수행할 수 있습니다. 편집 포인트를 사용하면 기존 모양을 변경하거나 기존 모양에서 새로운 모양을 만들 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

편집 포인트를 통해 PowerPoint 모양을 편집하기 전에, 모양에 대해 다음 사항을 고려해 보세요:

* 모양(또는 그 경로)은 닫힌 형태이거나 열린 형태일 수 있습니다.
* 모양이 닫혀 있으면 시작점이나 끝점이 없습니다. 모양이 열려 있으면 시작점과 끝점이 있습니다. 
* 모든 모양은 최소 2개의 앵커 포인트가 선으로 서로 연결되어 구성됩니다.
* 선은 직선이거나 곡선일 수 있습니다. 앵커 포인트가 선의 형태를 결정합니다. 
* 앵커 포인트는 코너 포인트, 스트레이트 포인트, 스무스 포인트로 존재합니다:
  * 코너 포인트는 두 직선이 각도로 만나고 있는 포인트입니다. 
  * 스무스 포인트는 두 핸들이 직선 상에 존재하고 선의 구간이 부드러운 곡선으로 연결되는 포인트입니다. 이 경우 모든 핸들은 앵커 포인트와 동일한 거리만큼 떨어져 있습니다. 
  * 스트레이트 포인트는 두 핸들이 직선 상에 존재하고 그 선의 구간이 부드러운 곡선으로 연결되는 포인트입니다. 이 경우 핸들은 앵커 포인트와 동일한 거리로 떨어질 필요가 없습니다. 
* 앵커 포인트를 이동하거나 편집(선의 각도를 변경)함으로써 모양의 모양새를 바꿀 수 있습니다. 

편집 포인트를 통해 PowerPoint 모양을 편집하려면 **Aspose.Slides**가 [**GeometryPath**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 클래스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 인스턴스는 [GeometryShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape) 객체의 기하학 경로를 나타냅니다.
* `GeometryShape` 인스턴스에서 `GeometryPath`를 가져오려면 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) 메서드를 사용할 수 있습니다.
* 모양에 `GeometryPath`를 설정하려면 다음 메서드를 사용할 수 있습니다: 단일 모양(solid shapes)에는 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-), 복합 모양(composite shapes)에는 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-).
* 세그먼트를 추가하려면 [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 아래의 메서드를 사용할 수 있습니다.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) 및 [GeometryPath.setFillMode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) 메서드를 사용하여 기하학 경로의 외형을 설정할 수 있습니다.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath#getPathData--) 메서드를 사용하면 `GeometryShape`의 기하학 경로를 경로 세그먼트 배열로 가져올 수 있습니다.
* 추가 모양 기하학 사용자 정의 옵션에 접근하려면 [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath)를 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)으로 변환할 수 있습니다.
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) 및 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) 메서드([ShapeUtil](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeUtil) 클래스에서)를 사용하여 [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath)를 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)으로, 그리고 다시 변환할 수 있습니다.

## **간단한 편집 작업**

다음 JavaScript 코드는 다음과 같이 수행하는 방법을 보여줍니다.

**선 추가** 경로 끝에

```javascript
lineTo(point);
lineTo(x, y);
```
**선 추가** 경로의 지정된 위치에:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**삼차 베지어 곡선 추가** 경로 끝에:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**삼차 베지어 곡선 추가** 경로의 지정된 위치에:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**이차 베지어 곡선 추가** 경로 끝에:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**이차 베지어 곡선 추가** 경로의 지정된 위치에:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**주어진 호 추가** 경로에:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**현재 도형 닫기** 경로의:

```javascript
closeFigure();
```
**다음 포인트 위치 설정**:

```javascript
moveTo(point);
moveTo(x, y);
```
**경로 세그먼트 제거** 지정된 인덱스에서:

```javascript
removeAt(index);
```

## **모양에 사용자 정의 포인트 추가**

1. [GeometryShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape) 클래스의 인스턴스를 만들고 [ShapeType.Rectangle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeType) 유형을 설정합니다.
2. 모양에서 [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 클래스의 인스턴스를 가져옵니다.
3. 경로의 두 상단 포인트 사이에 새로운 포인트를 추가합니다.
4. 경로의 두 하단 포인트 사이에 새로운 포인트를 추가합니다.
5. 경로를 모양에 적용합니다.

다음 JavaScript 코드는 모양에 사용자 정의 포인트를 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **모양에서 포인트 제거**

1. [GeometryShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape) 클래스의 인스턴스를 만들고 [ShapeType.Heart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeType) 유형을 설정합니다.
2. 모양에서 [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 클래스의 인스턴스를 가져옵니다.
3. 경로의 세그먼트를 제거합니다.
4. 경로를 모양에 적용합니다.

다음 JavaScript 코드는 모양에서 포인트를 제거하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **사용자 정의 모양 만들기**

1. 모양의 포인트를 계산합니다.
2. [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 클래스의 인스턴스를 만듭니다.
3. 포인트로 경로를 채웁니다.
4. [GeometryShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape) 클래스의 인스턴스를 만듭니다.
5. 경로를 모양에 적용합니다.

다음 JavaScript 코드는 사용자 정의 모양을 만드는 방법을 보여줍니다:

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **복합 사용자 정의 모양 만들기**

1. [GeometryShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape) 클래스의 인스턴스를 만든다.
2. [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 클래스의 첫 번째 인스턴스를 만든다.
3. [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 클래스의 두 번째 인스턴스를 만든다.
4. 경로들을 모양에 적용한다.

다음 JavaScript 코드는 복합 사용자 정의 모양을 만드는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 정의 모양 만들기**

다음 JavaScript 코드는 곡선 모서리(안쪽)로 사용자 정의 모양을 만드는 방법을 보여줍니다;

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **모양 기하학이 닫혔는지 확인하기**

닫힌 모양은 모든 면이 연결되어 틈 없이 단일 경계선을 형성하는 형태로 정의됩니다. 이러한 모양은 단순한 기하학 형태이거나 복잡한 사용자 정의 외곽선일 수 있습니다. 다음 코드 예제는 모양 기하학이 닫혀 있는지 확인하는 방법을 보여줍니다:

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **GeometryPath를 java.awt.Shape로 변환**

1. [GeometryShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape) 클래스의 인스턴스를 만든다.
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 클래스의 인스턴스를 만든다.
3. [ShapeUtil](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeUtil) 을 사용하여 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 인스턴스를 [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryPath) 인스턴스로 변환합니다.
4. 경로를 모양에 적용한다.

다음 JavaScript 코드는 위 단계들의 구현으로, **GeometryPath**를 **GraphicsPath**로 변환하는 과정을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 새 모양 만들기
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // 모양의 기하학 경로 가져오기
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // 텍스트가 포함된 새로운 그래픽 경로 만들기
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // 그래픽 경로를 기하학 경로로 변환
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // 새 기하학 경로와 원래 기하학 경로의 조합을 모양에 설정
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 모양에 그대로 남으며, 컨투어만 변경됩니다. 채우기와 외곽선은 새 기하학에 자동으로 적용됩니다.

**사용자 정의 모양을 기하학과 함께 올바르게 회전하려면 어떻게 해야 하나요?**

[setRotation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/setrotation/) 메서드를 사용하십시오. 기하학은 모양의 좌표계에 연결되어 있기 때문에 모양과 함께 회전합니다.

**사용자 정의 모양을 이미지로 변환하여 결과를 '고정'할 수 있나요?**

예. 필요한 [slide](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/nodejs-java/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면, 복잡한 기하학을 다루는 작업을 단순화할 수 있습니다.