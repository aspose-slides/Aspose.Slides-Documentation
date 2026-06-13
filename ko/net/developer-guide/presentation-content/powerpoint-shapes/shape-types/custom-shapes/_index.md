---
title: .NET에서 프레젠테이션 도형 사용자 지정
linktitle: 사용자 정의 도형
type: docs
weight: 20
url: /ko/net/custom-shape/
keywords:
- 사용자 정의 도형
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션에서 도형을 만들고 사용자 지정합니다: 기하 경로, 곡선 모서리, 복합 도형."
---
## **Overview**

이 문서는 Aspose.Slides에서 편집 점과 기하 경로를 통해 도형 기하학을 수정하여 프레젠테이션 도형을 사용자 지정하는 방법을 설명합니다. `GeometryPath`와 `IGeometryPath`를 사용하여 기존 도형을 수정하고, 기본 경로 편집 작업을 수행하며, 점을 추가·제거하고, 업데이트된 기하학을 도형에 적용하는 방법을 보여줍니다.

또한 사용자 정의 및 복합 도형을 만드는 방법, 곡선 모서리를 가진 도형을 구성하는 방법, 도형 기하학이 닫혀 있는지 확인하는 방법, 그리고 추가적인 기하학 사용자 지정 시나리오를 위해 `GeometryPath`와 `GraphicsPath`를 서로 변환하는 방법도 시연합니다.

## **Change a Shape Using Edit Points**

정사각형을 예로 들어 보겠습니다. PowerPoint에서 **편집 점**을 사용하면  

* 정사각형 모서리를 안쪽 또는 바깥쪽으로 이동  
* 모서리 또는 점의 곡률 지정  
* 정사각형에 새로운 점 추가  
* 정사각형의 점을 조작 등  

위와 같은 작업을 모든 도형에 대해 수행할 수 있습니다. 편집 점을 사용하면 기존 도형을 변경하거나 기존 도형을 기반으로 새로운 도형을 만들 수 있습니다.

## **Shape Editing Tips**

![overview_image](custom_shape_0.png)

편집 점을 통해 PowerPoint 도형을 수정하기 전에 다음 사항을 고려하십시오.

* 도형(또는 그 경로)은 닫혀 있거나 열려 있을 수 있습니다.  
* 모든 도형은 최소 2개의 앵커 포인트가 선으로 연결되어 구성됩니다.  
* 선은 직선이거나 곡선일 수 있습니다. 앵커 포인트가 선의 형태를 결정합니다.  
* 앵커 포인트는 코너 포인트, 직선 포인트, 부드러운 포인트로 구분됩니다.  
  * 코너 포인트는 두 직선이 각을 이루어 만나는 지점입니다.  
  * 부드러운 포인트는 두 핸들이 같은 직선 상에 있고, 선 구간이 부드러운 곡선으로 이어지는 지점이며, 두 핸들은 앵커 포인트에서 같은 거리를 유지합니다.  
  * 직선 포인트는 두 핸들이 같은 직선 상에 있지만, 핸들이 앵커 포인트에서 동일한 거리일 필요는 없는 지점입니다.  
* 앵커 포인트를 이동·편집(선의 각도 변경)하면 도형의 모양을 바꿀 수 있습니다.

PowerPoint 도형을 편집 점으로 조작하기 위해 **Aspose.Slides**는 [**GeometryPath**](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 클래스와 [**IGeometryPath**](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometrypath) 인터페이스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape) 객체의 기하 경로를 나타냅니다.  
* `IGeometryShape` 인스턴스에서 `GeometryPath`를 얻으려면 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/methods/getgeometrypaths) 메서드를 사용합니다.  
* 도형에 `GeometryPath`를 설정하려면 *단일 도형*의 경우 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/methods/setgeometrypath) 메서드를, *복합 도형*의 경우 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/methods/setgeometrypaths) 메서드를 사용합니다.  
* 구간을 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometrypath) 아래의 메서드를 활용합니다.  
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometrypath/properties/stroke) 및 [IGeometryPath.FillMode](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometrypath/properties/fillmode) 속성을 사용해 기하 경로의 외관을 지정할 수 있습니다.  
* [IGeometryPath.PathData](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometrypath/properties/pathdata) 속성을 통해 `GeometryShape`의 기하 경로를 구간 배열 형태로 가져올 수 있습니다.  
* 추가적인 도형 기하학 사용자 지정 옵션에 접근하려면 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath)를 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 로 변환합니다.  
* [ShapeUtil](https://reference.aspose.com/slides/ko/net/aspose.slides.util/shapeutil) 클래스의 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/ko/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath)와 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) 메서드를 사용해 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath)와 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 간을 자유롭게 변환합니다.

## **Simple Editing Operations**

다음 C# 코드 예시는 다음 작업을 수행하는 방법을 보여 줍니다.

**경로 끝에 선 추가**

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**경로의 지정 위치에 선 추가**

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**경로 끝에 3차 베지에 곡선 추가**

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**경로의 지정 위치에 3차 베지에 곡선 추가**

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**경로 끝에 2차 베지에 곡선 추가**

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**경로의 지정 위치에 2차 베지에 곡선 추가**

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**주어진 호를 경로에 추가**

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**경로의 현재 도형 닫기**

``` csharp
void CloseFigure();
```
**다음 점의 위치 지정**

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**지정 인덱스에 있는 경로 구간 제거**

``` csharp
void RemoveAt(int index);
```

## **Add Custom Points to a Shape**

1. [GeometryShape](https://reference.aspose.com/slides/ko/net/aspose.slides/geometryshape) 클래스의 인스턴스를 생성하고 [ShapeType.Rectangle](https://reference.aspose.com/slides/ko/net/aspose.slides/shapetype) 유형을 설정합니다.  
2. 도형에서 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 클래스의 인스턴스를 가져옵니다.  
3. 경로 상의 상단 두 점 사이에 새로운 점을 추가합니다.  
4. 경로 상의 하단 두 점 사이에 새로운 점을 추가합니다.  
5. 경로를 도형에 적용합니다.

다음 C# 코드는 도형에 사용자 정의 점을 추가하는 방법을 보여 줍니다.

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

##  **Remove Points from a Shape**

1. [GeometryShape](https://reference.aspose.com/slides/ko/net/aspose.slides/geometryshape) 클래스의 인스턴스를 생성하고 [ShapeType.Heart](https://reference.aspose.com/slides/ko/net/aspose.slides/shapetype) 유형을 설정합니다.  
2. 도형에서 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 클래스의 인스턴스를 가져옵니다.  
3. 경로 구간을 제거합니다.  
4. 경로를 도형에 적용합니다.

다음 C# 코드는 도형에서 점을 제거하는 방법을 보여 줍니다.

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```

![example2_image](custom_shape_2.png)

##  **Create a Custom Shape**

1. 도형에 사용할 점들을 계산합니다.  
2. [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 클래스의 인스턴스를 생성합니다.  
3. 계산한 점들로 경로를 채웁니다.  
4. [GeometryShape](https://reference.aspose.com/slides/ko/net/aspose.slides/geometryshape) 클래스의 인스턴스를 생성합니다.  
5. 경로를 도형에 적용합니다.

다음 C# 코드는 사용자 정의 도형을 만드는 방법을 보여 줍니다.

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```

![example3_image](custom_shape_3.png)

## **Create a Composite Custom Shape**

1. [GeometryShape](https://reference.aspose.com/slides/ko/net/aspose.slides/geometryshape) 클래스의 인스턴스를 생성합니다.  
2. 첫 번째 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 인스턴스를 생성합니다.  
3. 두 번째 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 인스턴스를 생성합니다.  
4. 두 경로를 도형에 적용합니다.

다음 C# 코드는 복합 사용자 정의 도형을 만드는 방법을 보여 줍니다.

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```

![example4_image](custom_shape_4.png)

## **Create a Custom Shape with Curved Corners**

다음 C# 코드는 곡선 모서리(내부 방향) 를 가진 사용자 정의 도형을 만드는 방법을 보여 줍니다.

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Find Out If a Shape Geometry Is Closed**

닫힌 도형은 모든 변이 연결되어 하나의 경계선을 이루고, 틈이 없는 형태를 말합니다. 이 형태는 단순 기하 도형일 수도 있고 복잡한 사용자 정의 외곽선일 수도 있습니다. 아래 예제 코드는 도형 기하학이 닫혀 있는지 확인하는 방법을 보여 줍니다.

```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **Convert GeometryPath to GraphicsPath (System.Drawing.Drawing2D)** 

1. [GeometryShape](https://reference.aspose.com/slides/ko/net/aspose.slides/geometryshape) 클래스의 인스턴스를 생성합니다.  
2. [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 네임스페이스에 속한 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 클래스의 인스턴스를 생성합니다.  
3. [ShapeUtil](https://reference.aspose.com/slides/ko/net/aspose.slides.util/shapeutil) 을 사용해 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 인스턴스를 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath) 인스턴스로 변환합니다.  
4. 변환된 경로를 도형에 적용합니다.

다음 C# 코드는 위 단계들을 구현한 예시로, **GeometryPath**를 **GraphicsPath**로 변환하는 과정을 보여 줍니다.

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 도형에 그대로 유지되며, 컨투어만 변경됩니다. 채우기와 외곽선은 새로운 기하학에 자동으로 적용됩니다.

**기하학이 포함된 사용자 정의 도형을 올바르게 회전하려면 어떻게 해야 하나요?**

도형의 [rotation](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/rotation/) 속성을 사용하십시오. 기하학은 도형 자체 좌표계에 묶여 있기 때문에 도형과 함께 회전됩니다.

**결과를 “잠그기” 위해 사용자 정의 도형을 이미지로 변환할 수 있나요?**

예. 필요한 [slide](/slides/ko/net/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/net/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학 작업을 간소화할 수 있습니다.