---
title: .NET에서 프레젠테이션 도형 사용자 정의
linktitle: 사용자 정의 도형
type: docs
weight: 20
url: /ko/net/custom-shape/
keywords:
- 사용자 정의 도형
- 도형 추가
- 도형 만들기
- 도형 변경
- 도형 기하
- 기하 경로
- 경로 점
- 편집점
- 점 추가
- 점 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션에서 도형을 만들고 사용자 정의합니다: 기하 경로, 곡선 모서리, 복합 도형."
---
## **개요**

이 문서는 편집점 및 기하 경로를 통해 도형 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 도형을 사용자 지정하는 방법을 설명합니다. 기존 도형을 수정하고, 기본 경로 편집 작업을 수행하며, 점을 추가하거나 제거하고, 업데이트된 기하를 도형에 다시 적용하기 위해 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 및 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/)을 사용하는 방법을 보여줍니다.

또한 사용자 정의 및 복합 도형을 만들고, 곡선 모서리가 있는 도형을 구성하며, 도형 기하가 닫혀 있는지 판단하고, 추가적인 기하 사용자 지정 시나리오를 위해 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)와 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 간의 레거시 변환을 사용하는 방법을 데모합니다.

## **편집점을 사용하여 모양 변경**

PowerPoint에서 **편집점**을 사용하여 사각형을 수정할 수 있습니다:

* 모서리를 안쪽이나 바깥쪽으로 이동합니다.
* 점에서 곡률을 조정합니다.
* 새로운 점을 추가합니다.

편집점을 사용하면 도형의 외곽선을 수정하거나 기존 도형을 새로운 도형의 기반으로 사용할 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 도형을 편집할 때 다음 개념을 기억하십시오:

* 도형(또는 그 경로)은 닫힌 형태이거나 열린 형태일 수 있습니다.
* 도형의 경로는 세그먼트로 연결된 앵커 포인트로 구성됩니다.
* 세그먼트는 직선이거나 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트 또는 부드러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접 세그먼트가 각도를 이루며 만납니다.
  * 부드러운 포인트에서는 두 제어 핸들이 정렬되고 앵커 포인트에서 동일한 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸리가 정렬되어 있지만 앵커 포인트와의 거리가 다를 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 도형의 외곽선이 변경됩니다.

편집점을 통해 PowerPoint 도형을 편집하려면 **Aspose.Slides**에서 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 클래스와 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 인터페이스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 객체의 기하 경로를 나타냅니다.
* [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)를 가져오려면 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) 메서드를 사용할 수 있습니다.
* 도형에 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)를 설정하려면 단일 경로 도형의 경우 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)를, 여러 경로를 가진 도형의 경우 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)를 사용합니다.
* 세그먼트를 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) 및 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) 속성을 사용하여 기하 경로의 외관을 설정할 수 있습니다.
* [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) 속성을 사용하면 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/)의 기하 경로를 세그먼트 배열로 가져올 수 있습니다.
* 아래 변환 메서드를 지원하는 레거시 버전에서는 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)를 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)으로 변환할 수 있습니다.
* [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) 클래스의 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) 및 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 메서드를 사용하여 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)와 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 간을 변환합니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하 경로를 편집합니다. 인덱스를 받는 오버로드는 해당 제로 기반 위치에 세그먼트를 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| 두 개의 제어 점과 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| 하나의 제어 점과 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| 지정된 차원과 각도(도)로 타원 호를 추가합니다. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| 현재 그림을 닫아 끝점을 시작점에 연결합니다. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| 그림의 시작점을 설정합니다. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| 제로 기반 인덱스에서 세그먼트를 제거합니다. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **모양에 사용자 정의 점 추가**

다음 예제는 [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/)을 사용하여 사각형 도형에 두 점을 삽입하고, 편집된 경로를 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)로 적용합니다. 좌표는 도형에 대한 로컬 좌표이며, 두 새로운 점은 도형의 중심에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 세그먼트 인덱스 1과 4는 각각 상단 및 하단 가장자리에 배치되어 해당 가장자를 안쪽으로 끌어당깁니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **모양에서 점 제거**

다음 예제는 [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/)을 사용하여 제로 기반 인덱스 2에 있는 세그먼트를 제거함으로써 하트 모양의 외곽을 변경합니다. 수정된 경로를 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)로 적용하면 도형 윤곽이 업데이트됩니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **사용자 정의 모양 만들기**

다음 예제는 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)를 사용하여 다섯 꼭지점 별을 구축합니다. 외부와 내부 반경을 각각 100포인트와 50포인트로 교대로 지정하여 팁과 움푹 들어간 부분을 정의하고, 72도 간격으로 다섯 팁을 고르게 배치합니다. 경로는 [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/)로 닫히며, [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)를 사용하여 사각형 도형에 적용되어 기존 외곽을 대체합니다.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **복합 사용자 정의 모양 만들기**

다음 예제는 도형의 상단과 하단 3분의 1을 위한 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)로 적용하면 중간 3분의 1에 구멍이 있는 하나의 복합 도형이 생성됩니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 정의 모양 만들기**

다음 예제는 직선 세그먼트와 [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/)를 결합하여 내부가 굽은 모서리를 가진 도형을 생성합니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 사분원 타원을 그립니다. 완성된 경로는 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)로 적용되고, 프레젠테이션은 PPTX 형식으로 저장됩니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **모양 기하가 닫혀 있는지 확인**

다음 도우미는 모든 비어 있지 않은 기하 경로가 닫는 세그먼트로 끝나는지 확인합니다. [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/)를 읽고 최종 세그먼트의 [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/)를 [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없을 경우 false를 반환합니다. 이 검사는 각 경로의 최종 명령만 확인하며, 경로 내부의 모든 하위 도형을 검사하지는 않습니다. 예제는 사각형에 대해 `True`를 출력합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **기하 경로 명령 검사**

[contour.pptx](contour.pptx)를 다운로드하고 애플리케이션 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 직선 상단 가장자리, 3차 베지어 곡선 및 직선 닫는 가장자리를 가진 도형이 포함되어 있습니다. [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)를 사용하여 해당 경로를 읽습니다. 각 경로는 [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/)에 그리기 순서대로 세그먼트를 나열합니다. 각 세그먼트의 [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/)가 [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/)를 읽는 방법을 결정합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

도형은 슬라이드에서 (200, 100) 포인트 위치에 있습니다. 보고된 점은 도형에 대한 로컬 좌표이며, (0, 0)은 도형의 왼쪽 위 모서리이고, x는 오른쪽으로 증가하며 y는 아래쪽으로 증가합니다. 닫는 세그먼트는 추가 좌표 없이 시작점으로 돌아갑니다.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **모양 요소 추출 및 검사**

[IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/)을 사용하여 기존 도형을 경로 점 및 점 유형을 포함하는 요소로 검사합니다. 반환된 각 [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/)을 [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/)으로 캐스팅하여 [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/)와 [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) 배열을 읽습니다. 이 표현은 윤곽선 분석이나 기하를 사용자 정의 그리기 도구에 전달할 때 유용합니다.

예제는 프레젠테이션을 열고 첫 번째 슬라이드에서 첫 번째 기하 도형을 찾아 그 경로 세그먼트를 출력합니다. 직선 및 곡선 세그먼트를 가진 도형이 포함된 프레젠테이션을 사용하면 두 종류의 출력 모두를 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

배열은 인덱스로 대응됩니다: `points[i]`는 점이고 `types[i]`는 그 역할을 설명합니다. 타입 `0`은 도형을 시작하고, 타입 `1`은 이전 점에서 현재 점까지 직선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작해 연속된 타입 `3` 세 개(두 제어점과 새 끝점)를 사용합니다. 루프는 이 세 항목을 함께 처리하고 끝점이 닫힘인지 확인합니다.

점 유형에는 플래그도 포함됩니다. `0x07` 마스크를 적용해 세그먼트 유형을 식별하고, `0x80`을 별도로 테스트해 닫힌 하위 경로를 감지합니다. 예를 들어 `129`(`0x81`)는 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 닫힌 베지어 끝점입니다. 단순히 `1`이나 `3`만 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환**. 점은 포인트(1/72 인치) 단위이며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 도형의 경우, 추출된 좌표에는 이미 [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/)와 [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) 위치가 포함되어 현재 너비와 높이를 반영합니다. 예를 들어 `(100, 200)` 위치에 크기 `120 × 80`인 회전되지 않은 사각형은 윤곽 경계가 `(100, 200)`–`(220, 280)`입니다. 도형 위치를 다시 더하지 마십시오. 좌표를 X와 Y에서 빼서 회전되지 않은 프레임 기준 좌표를 얻으세요.

추출된 점은 도형의 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 또는 수평·수직 뒤집기를 적용하지 않습니다. 표시된 윤곽선을 재현하려면 도형 중심을 기준으로 이러한 변환을 적용하십시오. 그룹 도형의 경우에도 그룹 좌표 매핑과 변환을 고려해야 하며, 추출된 점이 최종 렌더링 슬라이드 좌표가 아니거나 이미 자식 프레임에 반영된 변환을 두 번 적용하지 않도록 주의하십시오.

**검사 vs 편집**. 추출된 배열은 윤곽선을 설명하며, 이를 변경해도 원본 도형이 업데이트되지 않습니다. 점/유형 배열이 필요할 때 이 방식을 사용하고, 도형의 로컬 좌표 시스템에서 기하 명령이 필요하거나 기하를 편집하려면 [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)를 사용하세요. 편집된 경로는 [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 또는 [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)를 통해 적용합니다.

## **GeometryPath를 GraphicsPath로 변환 (System.Drawing.Drawing2D)**

다음 예제는 [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/)를 지원하는 레거시 Aspose.Slides for .NET 어셈블리를 필요로 하며, 예를 들어 버전 25.10과 Windows 환경에서 `System.Drawing.Common`이 필요합니다. 변환 메서드는 [버전 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/)에서 제거되었습니다.

이 예제는 텍스트를 기하로 변환한 것을 포함한 사각형 외곽을 결합합니다. 외곽의 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/)을 비활성화하여 채우기를 하지 않도록 설정합니다. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)는 텍스트 외곽을 저장하고, [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/)가 이를 채워진 기하 경로로 변환합니다. 두 경로를 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)에 적용하면 사각형과 텍스트를 포함하는 단일 도형이 생성됩니다. 반대 방향 변환을 위해서는 [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/)를 사용합니다.

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **FAQ**

**기하를 교체한 후 채우기와 외곽선은 어떻게 되나요?**

스타일은 도형에 그대로 유지되며, 윤곽선만 변경됩니다. 채우기와 외곽선은 새로운 기하에 자동으로 적용됩니다.

**기하와 함께 사용자 정의 도형을 올바르게 회전하려면 어떻게 해야 하나요?**

도형의 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 속성을 사용하십시오. 기하가 도형 자체 좌표계에 바인딩되어 있기 때문에 도형과 함께 회전됩니다.

**사용자 정의 도형을 이미지로 변환하여 결과를 "잠그고" 싶나요?**

예. 필요한 [slide](/slides/ko/net/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/net/create-shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하 작업을 간소화할 수 있습니다.