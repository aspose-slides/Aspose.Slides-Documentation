---
title: Tùy chỉnh các hình dạng trong bài thuyết trình bằng C++
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/cpp/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình
- tạo hình
- thay đổi hình
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
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint với Aspose.Slides cho C++: đường hình học, góc cong, hình tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình của Aspose.Slides bằng cách chỉnh sửa hình học của hình thông qua các điểm chỉnh sửa và các đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) và [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa điểm, và áp dụng hình học đã cập nhật trở lại cho một hình.

Nó cũng trình bày cách tạo các hình tùy chỉnh và tổng hợp, xây dựng các hình có góc cong, và xác định xem một hình học của hình có kín hay không.

## **Thay đổi một hình bằng Điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn thay đổi đường viền của một hình hoặc sử dụng một hình hiện có làm cơ sở cho một hình mới.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình trong PowerPoint, hãy nhớ những khái niệm sau:

* Một hình (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Đường dẫn của một hình bao gồm các điểm neo được nối bằng các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển quyết định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng, hoặc điểm mượt:
  * Ở điểm góc, các đoạn liền kề có thể gặp nhau tạo một góc.
  * Ở điểm mượt, hai tay cầm điều khiển được căn chỉnh và cách đều nhau so với điểm neo.
  * Ở điểm thẳng, hai tay cầm điều khiển được căn chỉnh nhưng có thể có khoảng cách khác nhau tới điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh tay cầm của chúng sẽ thay đổi đường viền của hình.

Để chỉnh sửa các hình PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) và giao diện [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Một thể hiện của [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) đại diện cho đường dẫn hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) từ thể hiện [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), bạn có thể sử dụng phương thức [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) cho một hình, bạn có thể sử dụng các phương thức: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) cho các hình có một đường duy nhất và [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) cho các hình có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức trong [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Sử dụng các phương thức [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) và [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), bạn có thể thiết lập cách hiển thị cho một đường dẫn hình học.
* Sử dụng phương thức [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường.

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường dẫn hình học. Các overload chấp nhận chỉ mục sẽ chèn một đoạn vào vị trí chỉ mục không bắt đầu từ 0 trong mảng các đoạn của đường.

| Thao tác | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đoạn thẳng. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Thêm một cung elip với kích thước và góc đã chỉ định tính bằng độ. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Đóng hình hiện tại bằng cách nối điểm cuối của nó với điểm bắt đầu. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Xóa một đoạn tại chỉ mục không bắt đầu từ 0. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Thêm các điểm tùy chỉnh vào một hình**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) và áp dụng đường đã chỉnh sửa bằng [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Các tọa độ là cục bộ đối với hình: cả hai điểm mới đều ở trung tâm, cách mép trái 100 điểm và cách mép trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

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

## **Xóa các điểm khỏi một hình**

Ví dụ này thay đổi đường viền dạng trái tim bằng cách xóa đoạn tại chỉ mục không bắt đầu từ 0 là 2 bằng [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Áp dụng đường đã sửa đổi bằng [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) sẽ cập nhật đường viền của hình.

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

## **Tạo một hình tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ 100 và 50 điểm xác định các đầu mũi và các rãnh; một bước 72 độ chia đều năm đầu mũi. Đường được đóng bằng [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) và áp dụng vào một hình chữ nhật bằng [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), thay thế đường viền của nó.

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

## **Tạo một hình tùy chỉnh tổng hợp**

Ví dụ này định nghĩa hai [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình. Áp dụng cả hai đường bằng [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) tạo ra một hình tổng hợp duy nhất với một khoảng trống ở phần giữa của nó.

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

## **Tạo một hình tùy chỉnh với các góc cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) để tạo một hình có các góc cong vào trong. Mỗi kích thước góc đặt độ rộng và chiều cao của cung tính bằng points, và góc quét -90 độ vẽ một phần tư elip ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), và bài thuyết trình được lưu ở định dạng PPTX.

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

## **Xác định xem một hình học của hình có đóng không**

Trình trợ giúp sau kiểm tra xem mọi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) và so sánh lệnh cuối cùng của đoạn với [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) bằng [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường không rỗng. Kiểm tra này chỉ xem lệnh cuối cùng của mỗi đường; nó không kiểm tra từng hình con bên trong một đường. Ví dụ in ra `True` cho một hình chữ nhật.

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

## **Trích xuất và kiểm tra các thành phần của hình**

Sử dụng [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) để kiểm tra một hình hiện có dưới dạng các thành phần chứa các điểm đường và loại điểm. Chuyển đổi mỗi [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) trả về sang [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) để đọc các mảng trả về bởi [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) và [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ mở một bài thuyết trình, tìm hình học đầu tiên trực tiếp trên slide đầu tiên, và in ra các đoạn đường của nó. Sử dụng một bài thuyết trình có chứa hình với các đoạn thẳng và cong để xem cả hai kiểu đầu ra. Nó không tìm kiếm bên trong các nhóm.

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
        auto pointType = types[i] & 0x07; // Giữ lại loại đoạn, loại trừ các cờ.
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
                i += 2; // Tiêu thụ cả hai điểm điều khiển và điểm cuối.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Các mảng tương ứng theo chỉ mục: `points[i]` là một điểm và `types[i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đoạn thẳng từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu từ điểm cuối trước và sử dụng ba mục kiểu `3` liên tiếp: hai điểm điều khiển rồi điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định độ kín.

Các kiểu điểm cũng chứa các cờ. Áp dụng mask `0x07` để xác định kiểu đoạn, và kiểm tra `0x80` riêng để phát hiện một đường phụ đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối của đoạn thẳng đóng một đường phụ, và `131` (`0x83`) có nghĩa là một điểm cuối của Bézier đóng một đường phụ. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ lỡ các trường hợp này. Các cờ khác, như dash (`0x10`) và marker (`0x20`), không thay đổi kiểu đoạn cơ bản.

**Tọa độ và phép biến đổi.** Các điểm được đo bằng points (1/72 inch), với X tăng sang phải và Y tăng xuống dưới. Đối với một hình không được nhóm, các tọa độ đã trích xuất đã bao gồm vị trí trả về bởi [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) và [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) và phản ánh chiều rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` với kích thước `120 × 80` có giới hạn viền `(100, 200)`–`(220, 280)`. Đừng cộng thêm vị trí của hình một lần nữa. Trừ X và Y của nó để nhận được tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng việc xoay được thiết lập qua [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) hoặc các lật ngang và dọc. Để tái tạo đường viền hiển thị, hãy áp dụng các phép biến đổi này quanh trung tâm của hình. Đối với các hình được nhóm, cũng cần tính đến việc ánh xạ và biến đổi tọa độ của nhóm; đừng giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỉ lệ hai lần nếu đã được phản ánh trong khung của đối tượng con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng không cập nhật lại hình gốc. Chọn cách này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa qua [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) hoặc [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Chuyển GeometryPath sang GraphicsPath**

API công cộng hiện tại của Aspose.Slides cho C++ không cung cấp chuyển đổi giữa các đường hình học và các đường đồ họa. Để kiểm tra một đường viền, hãy sử dụng các thành phần hình như mô tả ở trên. Để chỉnh sửa một hình, sử dụng các đường hình học và áp dụng các đường đã cập nhật cho hình.

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế hình học?**

Kiểu dáng vẫn giữ nguyên trên hình; chỉ có đường viền thay đổi. Màu nền và viền sẽ tự động áp dụng cho hình học mới.

**Làm thế nào để xoay đúng một hình tùy chỉnh cùng với hình học của nó?**

Sử dụng phương thức [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) của hình; hình học sẽ xoay cùng với hình vì nó được gắn vào hệ tọa độ của chính hình.

**Tôi có thể chuyển một hình tùy chỉnh thành hình ảnh để “khóa” kết quả không?**

Có. Xuất vùng [slide](/slides/vi/cpp/convert-powerpoint-to-png/) cần thiết hoặc chính [shape](/slides/vi/cpp/shape-thumbnails/) sang định dạng raster; cách này đơn giản hoá công việc với các hình học phức tạp.