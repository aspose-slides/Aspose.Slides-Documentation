---
title: Tùy chỉnh các hình dạng trong bài thuyết trình bằng C++
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/cpp/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học hình dạng
- đường hình học
- các điểm đường
- chỉnh sửa điểm
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint bằng Aspose.Slides cho C++: đường hình học, góc cong, hình ghép."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình bằng Aspose.Slides bằng cách chỉnh sửa hình học của hình qua các điểm chỉnh sửa và các đường hình học. Nó chỉ ra cách làm việc với [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng minh họa cách tạo các hình tùy chỉnh và ghép, xây dựng các hình dạng có góc cong, và xác định liệu hình học của một hình có đóng không.

## **Thay đổi một Hình Dạng bằng Điểm Chỉnh Sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Chỉnh sửa các điểm cho phép bạn thay đổi khung viền của một hình hoặc sử dụng một hình hiện có làm cơ sở cho một hình mới.

## **Mẹo Chỉnh Sửa Hình Dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình trong PowerPoint, hãy lưu ý những khái niệm sau:

* Một hình (hoặc đường của nó) có thể là đóng hoặc mở.
* Đường của một hình bao gồm các điểm neo được nối bằng các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay điều khiển xác định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mịn:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau tạo thành một góc.
  * Tại một điểm mịn, hai tay điều khiển được căn chỉnh và cách điểm neo một khoảng bằng nhau.
  * Tại một điểm thẳng, hai tay điều khiển được căn chỉnh nhưng có thể có khoảng cách khác nhau tới điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh các tay của chúng sẽ thay đổi khung viền của hình.

Để chỉnh sửa các hình PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Một thể hiện của [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) đại diện cho đường hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) từ thể hiện [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), bạn có thể sử dụng phương thức [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) cho một hình, bạn có thể dùng các phương thức: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) cho các hình có một đường duy nhất và [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) cho các hình có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Bằng cách dùng các phương thức [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) và [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), bạn có thể đặt ngoại hình cho một đường hình học.
* Bằng cách dùng phương thức [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), bạn có thể lấy đường hình học của một [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) dưới dạng mảng các đoạn đường.

## **Các Thao Tác Chỉnh Sửa Đơn Giản**

Sử dụng các phương thức sau để chỉnh sửa một đường hình học. Các overload chấp nhận chỉ mục sẽ chèn một đoạn tại vị trí số không‑cơ sở trong mảng các đoạn của đường.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Thêm một cung elip với các kích thước và góc đã cho tính bằng độ. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Đóng hình hiện tại bằng cách nối điểm cuối của nó với điểm bắt đầu. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Xóa một đoạn tại chỉ mục số không‑cơ sở. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Thêm Các Điểm Tùy Chỉnh vào Một Hình Dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) và áp dụng đường đã chỉnh sửa với [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Các tọa độ là tương đối với hình: cả hai điểm mới nằm ở trung tâm, cách mép trái 100 điểm và cách mép trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

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

## **Xóa Các Điểm khỏi Một Hình Dạng**

Ví dụ này thay đổi đường viền hình trái tim bằng cách xóa đoạn tại chỉ mục số không‑cơ sở 2 với [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Áp dụng đường đã sửa với [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) sẽ cập nhật biên dạng của hình.

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

## **Tạo Một Hình Dạng Tùy Chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các đầu nhọn và các rãnh; bước 72 độ sẽ phân bố đều năm đầu nhọn. Đường được đóng bằng [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) và áp dụng cho một hình chữ nhật bằng [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), thay thế đường viền của nó.

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

## **Tạo Một Hình Dạng Ghép Tùy Chỉnh**

Ví dụ này định nghĩa hai [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình. Áp dụng cả hai đường bằng [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) tạo ra một hình ghép duy nhất với một khoảng trống ở phần giữa.

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

## **Tạo Một Hình Dạng Tùy Chỉnh Với Các Góc Cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) để tạo một hình có các góc cong vào trong. Mỗi kích thước góc xác định chiều rộng và chiều cao của cung tính bằng điểm, và góc quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), và bản trình bày được lưu ở định dạng PPTX.

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

## **Kiểm Tra Hình Học Của Một Hình Dạng Có Đóng Không**

Trợ giúp sau kiểm tra xem mọi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) và so sánh lệnh cuối cùng của đoạn với [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) so với [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường hình học nào không rỗng. Kiểm tra này chỉ xem lệnh cuối cùng của mỗi đường; nó không duyệt qua mọi tiểu hình trong một đường. Ví dụ in ra `True` cho một hình chữ nhật.

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

## **Kiểm Tra Các Lệnh Đường Hình Học**

Tải xuống [contour.pptx](contour.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Hình thứ nhất trên slide đầu tiên có một cạnh trên thẳng, một đường cong Bézier bậc ba, và một cạnh đóng thẳng. Sử dụng [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) để đọc các đường của nó. Đối với mỗi đường, [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) trả về các đoạn theo thứ tự vẽ. Lệnh trả về bởi [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) xác định cách diễn giải các giá trị trả về bởi [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

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

Hình nằm tại (200, 100) điểm trên slide. Các điểm báo cáo là tương đối với hình, với (0, 0) ở góc trên‑trái, x tăng về phía bên phải và y tăng xuống phía dưới. Đoạn đóng trả về điểm bắt đầu bằng cách không thêm tọa độ nào nữa.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Trích Xuất và Kiểm Tra Các Thành Phần Hình Dạng**

Sử dụng [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) để kiểm tra một hình hiện có dưới dạng các thành phần chứa các điểm đường và các kiểu điểm. Ép mỗi [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) để đọc các mảng trả về bởi [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) và [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Đại diện này hữu ích cho việc phân tích viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ mở một bản trình bày, tìm hình geometry đầu tiên trực tiếp trên slide đầu tiên, và in các đoạn đường của nó. Sử dụng một bản trình bày chứa một hình có các đoạn thẳng và cong để thấy cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

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
        auto pointType = types[i] & 0x07; // Giữ lại kiểu đoạn, loại trừ các cờ.
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

Các mảng tương ứng theo chỉ mục: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đường từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục liên tiếp kiểu‑`3`: hai điểm điều khiển và sau đó là điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định đóng.

Các kiểu điểm cũng chứa các cờ. Áp dụng mặt nạ `0x07` để xác định kiểu đoạn, và kiểm tra `0x80` riêng để phát hiện một tiểu đường đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối của đường thẳng đóng một tiểu đường, và `131` (`0x83`) là một điểm cuối của Bézier đóng một tiểu đường. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ qua các trường hợp này. Các cờ khác, chẳng hạn dash (`0x10`) và marker (`0x20`), không thay đổi kiểu đoạn cơ bản.

**Tọa độ và biến đổi.** Điểm được đo bằng point (1/72 inch), với X tăng sang phải và Y tăng xuống. Đối với một hình không thuộc nhóm, các tọa độ đã trích xuất đã bao gồm vị trí trả về bởi [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) và [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) và phản ánh chiều rộng, chiều cao hiện tại. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` có kích thước `120 × 80` sẽ có giới hạn viền `(100, 200)`–`(220, 280)`. Đừng cộng thêm vị trí của hình một lần nữa. Trừ X và Y để có tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng quay đặt qua [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) hoặc lật ngang và dọc. Để tái tạo viền hiển thị, áp dụng các biến đổi này quanh trung tâm của hình. Đối với các hình trong nhóm, cũng cần tính đến ánh xạ tọa độ và biến đổi của nhóm; đừng cho rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng dịch chuyển hoặc tỷ lệ hai lần nếu chúng đã được phản ánh trong khung của phần tử con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả viền; việc thay đổi chúng không cập nhật hình gốc. Chọn cách này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa qua [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) hoặc [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Chuyển GeometryPath Sang GraphicsPath**

API công khai hiện tại của Aspose.Slides cho C++ không cung cấp chuyển đổi giữa các đường hình học và các đường đồ họa. Để kiểm tra một viền, hãy sử dụng các thành phần hình như đã mô tả ở trên. Để chỉnh sửa một hình, hãy sử dụng các đường hình học và áp dụng các đường đã cập nhật cho hình.

## **Câu Hỏi Thường Gặp**

**Việc thay thế hình học sẽ ảnh hưởng như thế nào đến màu nền và viền?**

Kiểu vẫn giữ nguyên với hình; chỉ có viền thay đổi. Màu nền và viền sẽ tự động áp dụng cho hình học mới.

**Làm sao để xoay đúng một hình tùy chỉnh cùng với hình học của nó?**

Sử dụng phương thức [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) của hình; hình học sẽ xoay cùng với hình vì nó được gắn vào hệ tọa độ của hình.

**Có thể chuyển một hình tùy chỉnh thành hình ảnh để “khóa” kết quả không?**

Có. Xuất khu vực [slide](/slides/vi/cpp/convert-powerpoint-to-png/) hoặc [shape](/slides/vi/cpp/shape-thumbnails/) cần thiết sang định dạng raster; việc này giúp đơn giản hoá công việc với các hình học phức tạp.