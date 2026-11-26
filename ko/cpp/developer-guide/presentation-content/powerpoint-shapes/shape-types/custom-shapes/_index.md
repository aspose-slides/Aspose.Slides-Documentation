---
title: C++에서 프레젠테이션 모양 맞춤 설정
linktitle: 사용자 정의 모양
type: docs
weight: 20
url: /ko/cpp/custom-shape/
keywords:
- 사용자 정의 모양
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 모양을 만들고 맞춤 설정합니다: 기하학 경로, 곡선 모서리, 복합 모양."
---
## **개요**

이 문서는 편집 포인트와 기하학 경로를 통해 모양 기하학을 편집하여 Aspose.Slides에서 프레젠테이션 모양을 사용자 지정하는 방법을 설명합니다. 기존 모양을 수정하고, 기본 경로 편집 작업을 수행하며, 포인트를 추가·삭제하고, 업데이트된 기하학을 모양에 적용하기 위해 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 및 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/)를 사용하는 방법을 보여줍니다.

또한 사용자 정의 및 복합 모양을 만들고, 곡선 모서리가 있는 모양을 구축하며, 모양 기하학이 닫혀 있는지 확인하는 방법을 시연합니다.

## **편집 포인트로 모양 변경**

PowerPoint에서 **편집 포인트**를 사용하여 사각형을 수정할 수 있습니다:

* 모서리를 안쪽이나 바깥쪽으로 이동합니다.
* 포인트의 곡률을 조정합니다.
* 새로운 포인트를 추가합니다.

포인트를 편집하면 모양의 외곽선을 수정하거나 기존 모양을 새 모양의 기반으로 사용할 수 있습니다.

## **모양 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 모양을 편집할 때 다음 개념을 기억하세요:

* 모양(또는 그 경로)은 닫혀 있거나 열려 있을 수 있습니다.
* 모양의 경로는 세그먼트로 연결된 앵커 포인트로 구성됩니다.
* 세그먼트는 직선 또는 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 부드러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접 세그먼트가 각도를 이루며 만날 수 있습니다.
  * 부드러운 포인트에서는 두 제어 핸들이 정렬되고 앵커 포인트에서 같은 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 앵커 포인트에서 거리 차이가 있을 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 모양의 외곽선이 변경됩니다.

편집 포인트를 통해 PowerPoint 모양을 편집하려면 **Aspose.Slides**가 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 클래스와 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 인터페이스를 제공합니다.

* [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) 객체의 기하학 경로를 나타냅니다.
* [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)를 가져오려면 [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) 메서드를 사용할 수 있습니다.
* 모양에 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)를 설정하려면 단일 경로 모양의 경우 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), 다중 경로 모양의 경우 [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) 메서드를 사용할 수 있습니다.
* 세그먼트를 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 아래의 메서드를 사용합니다.
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) 및 [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) 메서드를 사용하여 기하학 경로의 외관을 설정할 수 있습니다.
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) 메서드를 사용하면 [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/)의 기하학 경로를 세그먼트 배열로 가져올 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하학 경로를 편집합니다. 인덱스를 받는 오버로드는 경로 세그먼트 배열의 해당 0 기반 위치에 세그먼트를 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선을 추가하거나 삽입합니다. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| 두 제어 점과 끝점이 있는 3차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| 하나의 제어 점과 끝점이 있는 2차 베지어 곡선을 추가하거나 삽입합니다. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| 지정된 크기와 각도(도)로 타원형 호를 추가합니다. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| 현재 도형을 시작점과 끝점을 연결하여 닫습니다. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| 도형의 시작점을 설정합니다. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| 0 기반 인덱스에서 세그먼트를 제거합니다. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **모양에 사용자 정의 포인트 추가**

이 예제는 [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/)를 사용해 직사각형 모양에 두 개의 포인트를 삽입하고, [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)로 편집된 경로를 적용합니다. 좌표는 모양을 기준으로 하며, 두 새로운 포인트는 가운데에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 세그먼트 인덱스 1과 4는 각각 상단 및 하단 가장자리에 배치되어 해당 가장자를 안쪽으로 끌어당깁니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **모양에서 포인트 제거**

이 예제는 [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/)를 사용해 0 기반 인덱스 2에 있는 세그먼트를 제거하여 하트 모양 외곽을 변경합니다. 수정된 경로를 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)으로 적용하면 모양의 윤곽이 업데이트됩니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **사용자 정의 모양 만들기**

이 예제는 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)를 사용해 5각 별을 생성합니다. 외부 반경 100포인트와 내부 반경 50포인트를 교대로 사용해 꼭짓점과 오목을 정의하고, 72도 간격으로 다섯 꼭짓점을 고르게 배치합니다. 경로는 [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/)로 닫힌 뒤, [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)를 사용해 직사각형 모양에 적용되어 기존 외곽을 대체합니다.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **복합 사용자 정의 모양 만들기**

이 예제는 모양의 상·하 3분의 1을 각각 담당하는 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)로 적용하면 중간 3분의 1에 간격이 있는 단일 복합 모양이 생성됩니다.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(shape->get_Height() / 3 * 2, 0.0f);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **곡선 모서리가 있는 사용자 정의 모양 만들기**

이 예제는 직선 세그먼트와 [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/)를 결합해 내부로 굽은 모서리를 가진 모양을 만듭니다. 각 모서리 크기는 아크의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 1/4 타원을 그립니다. 완성된 경로는 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)로 적용되며 프레젠테이션은 PPTX 형식으로 저장됩니다.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **모양 기하학이 닫혀 있는지 확인하기**

다음 도우미는 모든 비어 있지 않은 기하학 경로가 닫는 세그먼트로 끝나는지 검사합니다. [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/)를 읽고 마지막 세그먼트의 [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/)를 [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없을 경우 false를 반환합니다. 이는 각 경로의 최종 명령만 검사하며, 경로 내의 모든 하위 도형을 검사하지는 않습니다. 예제는 직사각형에 대해 `True`를 출력합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **기하학 경로 명령 검사**

[contour.pptx](contour.pptx)를 다운로드하고 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드의 첫 번째 모양은 직선 상단 가장자리, 3차 베지어 곡선, 직선 폐쇄 가장자를 가지고 있습니다. [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/)를 사용해 경로를 읽습니다. 각 경로에 대해 [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/)는 그리기 순서대로 세그먼트를 반환합니다. [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/)가 반환하는 명령은 [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/)가 반환하는 값을 해석하는 방법을 결정합니다.

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

모양은 슬라이드 상에서 (200, 100) 포인트에 위치합니다. 보고된 포인트는 모양을 기준으로 하며, (0, 0)은 왼쪽 위 모서리이고 x는 오른쪽으로, y는 아래쪽으로 증가합니다. 폐쇄 세그먼트는 추가 좌표 없이 시작점으로 돌아갑니다.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **모양 요소 추출 및 검사**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/)를 사용해 기존 모양을 경로 포인트와 포인트 유형을 포함하는 요소로 검사합니다. 반환된 각 [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/)를 [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/)으로 캐스팅해 [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/)와 [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/)가 반환하는 배열을 읽습니다. 이 표현은 윤곽 분석이나 사용자 정의 그리기 도구에 기하학을 전달할 때 유용합니다.

예제는 프레젠테이션을 열고 첫 번째 슬라이드에 직접 있는 첫 번째 기하학 모양을 찾아 그 경로 세그먼트를 출력합니다. 직선 및 곡선 세그먼트를 모두 포함하는 모양이 있는 프레젠테이션을 사용하면 두 종류의 출력이 모두 표시됩니다. 그룹 내부는 검색하지 않습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // 세그먼트 유형을 유지하고 플래그는 제외합니다.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

배열은 인덱스로 매핑됩니다: `points[i]`는 포인트이고 `types[i]`는 그 역할을 설명합니다. 유형 `0`은 도형을 시작하고, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하고 연속된 유형 `3` 세 항목을 사용합니다: 두 제어점과 새로운 끝점. 루프는 이 세 항목을 함께 소비하고 끝점이 폐쇄되는지 확인합니다.

포인트 유형에는 플래그도 포함됩니다. `0x07` 마스크를 사용해 세그먼트 유형을 식별하고, `0x80`을 별도로 테스트해 닫힌 하위 경로를 감지합니다. 예를 들어 `129`(`0x81`)은 하위 경로를 닫는 선 끝점을 의미하고, `131`(`0x83`)은 닫는 베지어 끝점을 의미합니다. 기본 세그먼트 유형만 `1` 또는 `3`과 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환**. 포인트는 포인트(인치의 1/72) 단위이며 X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 모양의 경우 추출된 좌표는 이미 [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/)와 [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/)가 반환한 위치를 포함하고 현재 너비와 높이를 반영합니다. 예를 들어 `(100, 200)`에 위치하고 크기가 `120 × 80`인 회전되지 않은 직사각형은 윤곽 경계가 `(100, 200)`–`(220, 280)`입니다. 모양의 위치를 다시 더하지 마세요. X와 Y를 빼서 회전되지 않은 프레임에 대한 좌표를 얻으세요.

추출된 포인트는 [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/)이나 수평·수직 뒤집기에 의해 적용된 회전을 반영하지 않습니다. 표시된 윤곽을 재현하려면 이러한 변환을 모양 중심을 기준으로 적용하십시오. 그룹화된 모양의 경우 그룹 좌표 매핑 및 변환도 고려해야 합니다; 추출된 포인트가 이미 자식 프레임에 반영된 경우 슬라이드 최종 좌표나 변환을 두 번 적용하지 마세요.

**검사 vs. 편집**. 추출된 배열은 윤곽을 설명하며 이를 변경해도 원본 모양이 업데이트되지 않습니다. 분석이나 그리기 코드가 포인트/유형 배열이 필요할 때 이 접근 방식을 선택하십시오. 모양의 로컬 좌표계에서 기하학 명령이 필요하거나 기하학을 편집하려면 [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/)를 사용하고, 편집된 경로는 [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) 또는 [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)로 적용하십시오.

## **GeometryPath를 GraphicsPath로 변환**

현재 Aspose.Slides for C++ 공개 API는 기하학 경로와 그래픽스 경로 간 변환을 제공하지 않습니다. 윤곽을 검사하려면 위에서 설명한 모양 요소를 사용하고, 모양을 편집하려면 기하학 경로를 사용하고 업데이트된 경로를 모양에 적용하십시오.

## **FAQ**

**기하학을 교체한 후 채우기 및 외곽선은 어떻게 됩니까?**

스타일은 모양에 그대로 남으며 윤곽만 변경됩니다. 채우기와 외곽선은 자동으로 새로운 기하학에 적용됩니다.

**기하학과 함께 사용자 정의 모양을 올바르게 회전하려면 어떻게 해야 합니까?**

모양의 [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) 메서드를 사용하십시오; 기하학은 모양에 바인드되어 있기 때문에 모양과 함께 회전됩니다.

**결과를 “잠그기” 위해 사용자 정의 모양을 이미지로 변환할 수 있나요?**

예. 필요한 [slide](/slides/ko/cpp/convert-powerpoint-to-png/) 영역이나 [shape](/slides/ko/cpp/shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학 작업을 더 쉽게 진행할 수 있습니다.