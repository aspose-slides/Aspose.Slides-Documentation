---
title: Android에서 프레젠테이션 모양 사용자 지정
linktitle: 맞춤형 모양
type: docs
weight: 20
url: /ko/androidjava/custom-shape/
keywords:
- 맞춤형 모양
- 모양 추가
- 모양 만들기
- 모양 변경
- 모양 기하학
- 기하학 경로
- 경로 점
- 편집점
- 점 추가
- 점 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 사용하여 Android용 Aspose.Slides로 PowerPoint 프레젠테이션에서 모양을 만들고 사용자 지정합니다: 기하학 경로, 곡선 모서리, 복합 모양."
---
## **개요**

이 문서는 편집점과 기하학 경로를 통해 모양 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 모양을 사용자 지정하는 방법을 설명합니다. `GeometryPath`와 `IGeometryPath`를 사용하여 기존 모양을 수정하고, 기본 경로 편집 작업을 수행하며, 점을 추가·제거하고, 업데이트된 기하학을 모양에 적용하는 방법을 보여줍니다.

또한 사용자 정의 및 복합 모양을 만드는 방법, 곡선 모서리를 가진 모양을 구축하는 방법, 모양 기하학이 닫혀 있는지 확인하는 방법, 그리고 추가 기하학 사용자 지정 시나리오를 위해 `GeometryPath`와 `java.awt.Shape` 간에 변환하는 방법을 시연합니다.

## **편집점을 사용한 모양 변경**
정사각형을 생각해 보세요. PowerPoint에서 **편집점**을 사용하면  

* 정사각형 모서리를 안쪽이나 바깥쪽으로 이동
* 모서리나 점의 곡률 지정
* 정사각형에 새 점 추가
* 정사각형의 점을 조작 등  

위와 같은 작업을 모든 모양에 적용할 수 있습니다. 편집점을 사용하면 기존 모양을 변경하거나 기존 모양으로부터 새 모양을 만들 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 모양을 편집점으로 편집하기 전에 다음 사항을 고려하십시오.

* 모양(또는 그 경로)은 닫힌 형태이거나 열린 형태일 수 있습니다.
* 모양이 닫혀 있으면 시작점이나 끝점이 없습니다. 열린 모양은 시작점과 끝점을 가집니다.
* 모든 모양은 최소 2개의 앵커 포인트가 선으로 연결된 구조입니다.
* 선은 직선이거나 곡선일 수 있습니다. 앵커 포인트가 선의 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 부드러운 포인트 중 하나입니다.
  * 코너 포인트는 두 직선이 각을 이루며 만나는 지점입니다.
  * 부드러운 포인트는 두 핸들이 직선 상에 존재하고 선분이 부드러운 곡선으로 연결되는 지점이며, 이 경우 모든 핸들은 앵커 포인트와 동일한 거리만큼 떨어져 있습니다.
  * 직선 포인트는 두 핸들이 직선 상에 존재하지만 선분이 부드러운 곡선으로 연결되는 지점이며, 이 경우 핸들의 거리는 동일할 필요가 없습니다.
* 앵커 포인트를 이동하거나 편집하여(선의 각도가 바뀌어) 모양의 모양을 바꿀 수 있습니다.

PowerPoint 모양을 편집점으로 편집하려면 **Aspose.Slides**가 [**GeometryPath**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 클래스와 [**IGeometryPath**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryPath) 인터페이스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryShape) 객체의 기하학 경로를 나타냅니다.
* `IGeometryShape` 인스턴스에서 `GeometryPath`를 가져오려면 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) 메서드를 사용할 수 있습니다.
* 모양에 `GeometryPath`를 설정하려면 다음 메서드를 사용하십시오: 단일(솔리드) 모양의 경우 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-), 복합 모양의 경우 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) .
* 세그먼트를 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryPath) 아래의 메서드를 사용하십시오.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) 및 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) 메서드를 사용하여 기하학 경로의 외관을 설정할 수 있습니다.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryPath#getPathData--) 메서드를 사용하면 `GeometryShape`의 기하학 경로를 경로 세그먼트 배열로 가져올 수 있습니다.
* 추가 모양 기하학 사용자 지정 옵션에 접근하려면 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath)를 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 로 변환하십시오.
* [ShapeUtil](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeUtil) 클래스의 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) 및 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) 메서드를 사용하면 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath)와 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)를 서로 변환할 수 있습니다.

## **단순 편집 작업**

다음 Java 코드는 다음과 같은 작업을 보여 줍니다.

**경로 끝에 선 추가**

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**경로의 지정된 위치에 선 추가:**

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**경로 끝에 3차 베지어 곡선 추가:**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**경로의 지정된 위치에 3차 베지어 곡선 추가:**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**경로 끝에 2차 베지어 곡선 추가:**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**경로의 지정된 위치에 2차 베지어 곡선 추가:**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**주어진 호를 경로에 추가:**

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**경로의 현재 도형 닫기:**

``` java
public void closeFigure();
```
**다음 점의 위치 설정:**

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**지정된 인덱스의 경로 세그먼트 제거:**

``` java
public void removeAt(int index);
```

## **모양에 사용자 정의 점 추가**
1. [GeometryShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryShape) 클래스의 인스턴스를 생성하고 [ShapeType.Rectangle](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeType) 유형을 설정합니다.
2. 모양에서 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 클래스의 인스턴스를 가져옵니다.
3. 경로의 두 상단 점 사이에 새 점을 추가합니다.
4. 경로의 두 하단 점 사이에 새 점을 추가합니다.
5. 경로를 모양에 적용합니다.

다음 Java 코드는 모양에 사용자 정의 점을 추가하는 방법을 보여 줍니다:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **모양에서 점 제거**

1. [GeometryShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryShape) 클래스의 인스턴스를 생성하고 [ShapeType.Heart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeType) 유형을 설정합니다.
2. 모양에서 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 클래스의 인스턴스를 가져옵니다.
3. 경로의 세그먼트를 제거합니다.
4. 경로를 모양에 적용합니다.

다음 Java 코드는 모양에서 점을 제거하는 방법을 보여 줍니다:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

## **사용자 정의 모양 만들기**

1. 모양의 점을 계산합니다.
2. [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 클래스의 인스턴스를 생성합니다.
3. 점들로 경로를 채웁니다.
4. [GeometryShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryShape) 클래스의 인스턴스를 생성합니다.
5. 경로를 모양에 적용합니다.

다음 Java 코드는 사용자 정의 모양을 만드는 방법을 보여 줍니다:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}

```
![example3_image](custom_shape_3.png)


## **복합 사용자 정의 모양 만들기**

1. [GeometryShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryShape) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 클래스의 인스턴스를 생성합니다.
3. 두 번째 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 클래스의 인스턴스를 생성합니다.
4. 경로들을 모양에 적용합니다.

다음 Java 코드는 복합 사용자 정의 모양을 만드는 방법을 보여 줍니다:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **곡선 모서리를 가진 사용자 정의 모양 만들기**

다음 Java 코드는 안쪽으로 굽은 곡선 모서리를 가진 사용자 정의 모양을 만드는 방법을 보여 줍니다:

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **모양 기하학이 닫혀 있는지 확인하기**

닫힌 모양은 모든 면이 연결되어 구멍 없이 하나의 경계를 형성하는 형태를 말합니다. 이러한 모양은 단순한 기하학 형태일 수도 있고 복잡한 사용자 정의 윤곽일 수도 있습니다. 다음 코드 예제는 모양 기하학이 닫혀 있는지 확인하는 방법을 보여 줍니다:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **GeometryPath를 java.awt.Shape로 변환하기**

1. [GeometryShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryShape) 클래스의 인스턴스를 생성합니다.
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 클래스의 인스턴스를 생성합니다.
3. [ShapeUtil](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapeUtil) 을 사용하여 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 인스턴스를 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/GeometryPath) 인스턴스로 변환합니다.
4. 경로들을 모양에 적용합니다.

위 단계들을 구현한 다음 Java 코드는 **GeometryPath**를 **GraphicsPath**로 변환하는 과정을 시연합니다:

``` java
Presentation pres = new Presentation();
try {
    // 새 모양 만들기
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 모양의 기하학 경로 가져오기
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 텍스트가 포함된 새 그래픽 경로 생성
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // 그래픽 경로를 기하학 경로로 변환
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // 새로운 기하학 경로와 원본 기하학 경로를 결합하여 모양에 설정
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 모양에 그대로 유지되며, 윤곽선만 변경됩니다. 채우기와 외곽선은 새 기하학에 자동으로 적용됩니다.

**기하학과 함께 사용자 정의 모양을 올바르게 회전하려면 어떻게 해야 하나요?**

모양의 [setRotation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#setRotation-float-) 메서드를 사용하십시오. 기하학은 모양 자체의 좌표계에 바인딩되어 있기 때문에 모양과 함께 회전됩니다.

**맞춤형 모양을 이미지로 변환하여 결과를 “잠그”고 싶으면 어떻게 하나요?**

예, 필요한 [slide](/slides/ko/androidjava/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/androidjava/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 됩니다. 이렇게 하면 복잡한 기하학을 다룰 때 작업이 간소화됩니다.