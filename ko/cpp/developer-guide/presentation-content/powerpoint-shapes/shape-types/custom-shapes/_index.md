---
title: C++에서 프레젠테이션 도형 맞춤 설정
linktitle: 사용자 정의 도형
type: docs
weight: 20
url: /ko/cpp/custom-shape/
keywords:
- 맞춤 도형
- 도형 추가
- 도형 생성
- 도형 변경
- 도형 기하학
- 기하학 경로
- 경로 포인트
- 포인트 편집
- 포인트 추가
- 포인트 제거
- 편집 작업
- 곡선 모서리
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 도형을 생성하고 맞춤 설정합니다: 기하학 경로, 곡선 모서리, 복합 도형."
---
## **개요**

이 문서에서는 편집 포인트와 기하학 경로를 통해 도형의 기하학을 편집함으로써 Aspose.Slides 프레젠테이션 도형을 사용자 지정하는 방법을 설명합니다. 기존 도형을 수정하고, 기본 경로 편집 작업을 수행하며, 포인트를 추가하거나 제거하고, 업데이트된 기하학을 도형에 다시 적용하는 방법을 보여줍니다. 여기서는 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 및 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 작업을 예시합니다.

또한 사용자 정의 및 복합 도형을 만드는 방법, 곡선 모서리를 가진 도형을 구축하는 방법, 도형의 기하학이 닫혀 있는지 확인하는 방법을 보여줍니다.

## **편집 포인트를 사용하여 도형 변경**

* 코너를 안쪽이나 바깥쪽으로 이동합니다.
* 포인트에서 곡률을 조정합니다.
* 새 포인트를 추가합니다.

포인트를 편집하면 도형의 외곽선을 수정하거나 기존 도형을 새로운 도형의 기반으로 사용할 수 있습니다.

## **도형 편집 팁**

![overview_image](custom_shape_0.png)

PowerPoint 도형을 편집할 때 다음 개념을 기억하십시오:

* 도형(또는 그 경로)은 닫혀 있거나 열려 있을 수 있습니다.
* 도형의 경로는 세그먼트로 연결된 앵커 포인트로 구성됩니다.
* 세그먼트는 직선 또는 곡선일 수 있습니다. 앵커 포인트와 제어 핸들이 형태를 결정합니다.
* 앵커 포인트는 코너 포인트, 직선 포인트, 또는 부드러운 포인트로 존재합니다:
  * 코너 포인트에서는 인접 세그먼트가 각도로 만나게 됩니다.
  * 부드러운 포인트에서는 두 제어 핸들이 정렬되어 앵커 포인트와 같은 거리에 있습니다.
  * 직선 포인트에서는 두 제어 핸들이 정렬되지만 앵커 포인트와의 거리가 다를 수 있습니다.
* 앵커 포인트를 이동하거나 핸들을 조정하면 도형의 외곽선이 변경됩니다.

편집 포인트를 통해 PowerPoint 도형을 편집하려면 **Aspose.Slides**에서 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 클래스와 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 인터페이스를 제공합니다.

* A [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 인스턴스는 [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) 객체의 기하학 경로를 나타냅니다.
* [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) 인스턴스에서 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)를 가져오려면 [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) 메서드를 사용할 수 있습니다.
* 도형에 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)를 설정하려면 다음 메서드를 사용할 수 있습니다: 단일 경로를 가진 도형에는 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)을, 다중 경로를 가진 도형에는 [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)을 사용합니다.
* 세그먼트를 추가하려면 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 아래의 메서드를 사용할 수 있습니다.
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) 및 [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) 메서드를 사용하여 기하학 경로의 외관을 설정할 수 있습니다.
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) 메서드를 사용하여 [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/)의 기하학 경로를 경로 세그먼트 배열로 가져올 수 있습니다.

## **간단한 편집 작업**

다음 메서드를 사용하여 기하학 경로를 편집합니다. 인덱스를 허용하는 오버로드는 경로 세그먼트 배열의 해당 0 기반 위치에 세그먼트를 삽입합니다.

| 작업 | 메서드 |
| --- | --- |
| 직선 추가 또는 삽입. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| 두 개의 제어점과 끝점이 있는 3차 베지어 곡선 추가 또는 삽입. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| 한 개의 제어점과 끝점이 있는 2차 베지어 곡선 추가 또는 삽입. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| 지정된 치수와 각도(도)로 타원 호 추가. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| 현재 도형을 끝점과 시작점을 연결하여 닫기. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| 도형의 시작점 설정. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| 0 기반 인덱스 위치의 세그먼트 제거. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **도형에 사용자 정의 포인트 추가**

이 예제는 [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/)를 사용하여 직사각형 도형에 두 개의 포인트를 삽입하고, 편집된 경로를 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)으로 적용합니다. 좌표는 도형에 로컬이며, 두 새로운 포인트는 도형의 중앙에 위치하고 왼쪽에서 100포인트, 위에서 50포인트 떨어져 있습니다. 세그먼트 인덱스 1과 4는 각각 상단과 하단 가장자리에 배치되어 해당 가장자리를 안쪽으로 당깁니다.

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

## **도형에서 포인트 제거**

이 예제는 [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/)를 사용하여 0 기반 인덱스 2에 있는 세그먼트를 제거함으로써 하트 모양 외곽선을 변경합니다. 수정된 경로를 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)으로 적용하면 도형의 컨투어가 업데이트됩니다.

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

## **사용자 정의 도형 만들기**

이 예제는 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)를 사용하여 다섯 꼭짓점 별을 구축합니다. 외부와 내부 반경을 각각 100과 50포인트로 교대로 적용하여 팁과 들뜸을 정의하고, 72도 간격으로 다섯 팁을 고르게 배치합니다. 경로는 [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/)으로 닫히고, [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)을 사용하여 직사각형 도형에 적용되어 외곽선을 교체합니다.

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

## **복합 사용자 정의 도형 만들기**

이 예제는 도형의 상단 및 하단 3분의 1을 위한 두 개의 닫힌 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 객체를 정의합니다. 두 경로를 [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)으로 적용하면 중간 3분의 1에 간격이 있는 단일 복합 도형이 생성됩니다.

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
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **곡선 모서리를 가진 사용자 정의 도형 만들기**

이 예제는 직선 세그먼트를 [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/)와 결합하여 안쪽으로 굽은 모서리를 가진 도형을 생성합니다. 각 모서리 크기는 호의 너비와 높이를 포인트 단위로 설정하고, -90도 스윕은 반시계 방향 사분원 타원을 그립니다. 완성된 경로는 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)으로 적용되고, 프레젠테이션은 PPTX 형식으로 저장됩니다.

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

## **도형 기하학이 닫혀 있는지 확인**

다음 도우미는 모든 비어 있지 않은 기하학 경로가 닫는 세그먼트로 끝나는지 확인합니다. 이는 [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/)를 읽고 최종 세그먼트의 [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/)를 [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/)와 비교합니다. 비어 있지 않은 경로가 없을 때는 false를 반환합니다. 이는 각 경로의 최종 명령을 확인하며, 경로 내의 모든 하위 도형을 검사하지는 않습니다. 예제는 사각형에 대해 `True`를 출력합니다.

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

## **도형 요소 추출 및 검사**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/)을 사용하여 기존 도형을 경로 포인트와 포인트 유형을 포함하는 요소로 검사합니다. 반환된 각 [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/)을 [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/)으로 캐스팅하여 [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/)와 [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/)가 반환하는 배열을 읽습니다. 이 표현은 컨투어 분석이나 기하학을 사용자 정의 그리기 도구에 전달할 때 유용합니다.

예제는 프레젠테이션을 열고 첫 번째 슬라이드에서 첫 번째 기하학 도형을 직접 찾아 경로 세그먼트를 출력합니다. 직선과 곡선 세그먼트를 모두 포함하는 도형이 있는 프레젠테이션을 사용하면 두 종류의 출력을 확인할 수 있습니다. 그룹 내부는 검색하지 않습니다.

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
        auto pointType = types[i] & 0x07; // 플래그를 제외하고 세그먼트 유형만 유지합니다.
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
                i += 2; // 두 개의 제어점과 끝점을 모두 사용합니다.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

배열은 인덱스로 일치합니다: `points[i]`는 포인트이며 `types[i]`는 그 역할을 설명합니다. 유형 `0`은 도형 시작을 나타내고, 유형 `1`은 이전 포인트에서 현재 포인트까지 선을 그립니다. 3차 베지어 세그먼트는 이전 끝점에서 시작하여 연속된 유형 `3` 항목 세 개를 사용합니다: 두 개의 제어점 뒤에 새로운 끝점이 옵니다. 루프는 이 세 항목을 함께 소비하고 끝점의 닫힘 여부를 확인합니다.

포인트 유형에는 플래그도 포함됩니다. `0x07`로 마스크하여 세그먼트 유형을 식별하고, `0x80`을 별도로 테스트하여 닫힌 하위 경로를 감지합니다. 예를 들어 `129`(`0x81`)는 하위 경로를 닫는 선 끝점이며, `131`(`0x83`)은 하위 경로를 닫는 베지어 끝점입니다. 원시 값을 `1`이나 `3`만으로 비교하면 이러한 경우를 놓치게 됩니다. 대시(`0x10`)와 마커(`0x20`)와 같은 다른 플래그는 기본 세그먼트 유형을 변경하지 않습니다.

**좌표 및 변환.** 포인트는 포인트(1/72 인치) 단위로 측정되며, X는 오른쪽으로, Y는 아래쪽으로 증가합니다. 그룹에 속하지 않은 도형의 경우 추출된 좌표에는 이미 [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/)와 [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/)가 반환하는 위치가 포함되어 현재 너비와 높이를 반영합니다. 예를 들어, `(100, 200)`에 위치하고 크기가 `120 × 80`인 회전되지 않은 사각형은 컨투어 경계가 `(100, 200)`–`(220, 280)`입니다. 도형의 위치를 다시 추가하지 마세요. X와 Y를 빼서 회전되지 않은 프레임에 대한 좌표를 얻습니다.

추출된 포인트는 [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/)으로 설정된 회전이나 수평·수직 플립을 적용하지 않습니다. 표시된 컨투어를 재현하려면 해당 변환을 도형 중심을 기준으로 적용하십시오. 그룹화된 도형의 경우 그룹 좌표 매핑 및 변환도 고려해야 합니다; 추출된 포인트가 최종 렌더링된 슬라이드 좌표라고 가정하거나 이미 자식 프레임에 반영된 경우 번역이나 스케일을 두 번 적용하지 마세요.

**검사 vs 편집.** 추출된 배열은 컨투어를 설명하지만 이를 변경해도 원본 도형은 업데이트되지 않습니다. 포인트/유형 배열이 필요한 분석이나 그리기 코드에 이 접근 방식을 선택하십시오. 도형의 로컬 좌표계에서 기하 명령이 필요하거나 기하를 편집하려면 [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/)를 사용하십시오. 수정된 경로는 [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) 또는 [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)를 통해 적용합니다.

## **GeometryPath를 GraphicsPath로 변환**

현재 Aspose.Slides for C++ 공개 API는 기하학 경로와 그래픽 경로 간 변환을 제공하지 않습니다. 컨투어를 검사하려면 위에서 설명한 도형 요소를 사용하십시오. 도형을 편집하려면 기하학 경로를 사용하고 업데이트된 경로를 도형에 적용하십시오.

## **FAQ**

**기하학을 교체한 후 채우기와 외곽선은 어떻게 됩니까?**

스타일은 도형에 그대로 유지되며, 컨투어만 변경됩니다. 채우기와 외곽선은 새로운 기하학에 자동으로 적용됩니다.

**사용자 정의 도형을 기하학과 함께 올바르게 회전하려면 어떻게 해야 하나요?**

도형의 [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) 메서드를 사용하십시오; 기하학은 도형에 바인딩된 자체 좌표계이므로 도형과 함께 회전됩니다.

**사용자 정의 도형을 이미지로 변환하여 결과를 '잠그' 수 있나요?**

예. 필요한 [슬라이드](/slides/ko/cpp/convert-powerpoint-to-png/) 영역 또는 [도형](/slides/ko/cpp/shape-thumbnails/) 자체를 래스터 형식으로 내보내면 복잡한 기하학 작업을 단순화할 수 있습니다.