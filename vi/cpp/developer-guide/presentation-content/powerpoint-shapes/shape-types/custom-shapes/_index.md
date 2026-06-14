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
- điểm đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint với Aspose.Slides cho C++: đường hình học, góc cong, hình dạng tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình trên Aspose.Slides bằng cách chỉnh sửa hình học của hình thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó cho thấy cách làm việc với `GeometryPath` và `IGeometryPath` để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc loại bỏ các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình.

## **Thay đổi hình bằng các điểm chỉnh sửa**

Xem xét một hình vuông. Trong PowerPoint, sử dụng **edit points**, bạn có thể 

* di chuyển góc của hình vuông vào trong hoặc ra ngoài  
* xác định độ cong cho một góc hoặc một điểm  
* thêm các điểm mới vào hình vuông  
* thao tác các điểm trên hình vuông, v.v.  

Về cơ bản, bạn có thể thực hiện các nhiệm vụ đã mô tả trên bất kỳ hình dạng nào. Sử dụng các điểm chỉnh sửa, bạn có thể thay đổi một hình hoặc tạo một hình mới từ một hình hiện có. 

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Trước khi bạn bắt đầu chỉnh sửa các hình dạng trong PowerPoint thông qua các điểm chỉnh sửa, bạn có thể muốn cân nhắc những điểm sau về các hình dạng:

* Một hình dạng (hoặc đường dẫn của nó) có thể là khép kín hoặc mở.  
* Khi một hình dạng khép kín, nó không có điểm bắt đầu hoặc kết thúc. Khi một hình dạng mở, nó có điểm đầu và điểm cuối.  
* Tất cả các hình dạng bao gồm ít nhất 2 điểm neo được liên kết với nhau bằng các đường.  
* Một đường có thể thẳng hoặc cong. Các điểm neo quyết định tính chất của đường.  
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:  
  * Điểm góc là điểm mà 2 đường thẳng nối lại với nhau tại một góc.  
  * Điểm mượt là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn của đường nối lại trong một đường cong mượt. Trong trường hợp này, tất cả các tay cầm cách điểm neo một khoảng cách bằng nhau.  
  * Điểm thẳng là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn của đường nối lại trong một đường cong mượt. Trong trường hợp này, các tay cầm không cần cách điểm neo một khoảng cách bằng nhau.  
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (điều này thay đổi góc của các đường), bạn có thể thay đổi giao diện của một hình dạng.  

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [**GeometryPath**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path) và giao diện [**IGeometryPath**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_path).

* Một thể hiện của [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path) đại diện cho đường hình học của đối tượng [IGeometryShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_shape).  
* Để lấy `GeometryPath` từ thể hiện `IGeometryShape`, bạn có thể sử dụng phương pháp [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1).  
* Để đặt `GeometryPath` cho một hình, bạn có thể sử dụng các phương pháp này: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) cho *solid shapes* và [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) cho *composite shapes*.  
* Để thêm các đoạn, bạn có thể sử dụng các phương pháp trong [IGeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_path).  
* Bằng cách sử dụng các phương pháp [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) và [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), bạn có thể thiết lập ngoại hình cho một đường hình học.  
* Bằng cách sử dụng phương pháp [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), bạn có thể lấy đường hình học của một `GeometryShape` dưới dạng một mảng các đoạn đường.  
* Để truy cập các tùy chọn tùy chỉnh hình học bổ sung cho hình, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path) sang [GraphicsPath](https://reference.aspose.com/slides/vi/cpp/class/system.drawing.drawing2_d.graphics_path).  
* Sử dụng các phương pháp [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) và [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.util.shape_util)) để chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path) sang [GraphicsPath](https://reference.aspose.com/slides/vi/cpp/class/system.drawing.drawing2_d.graphics_path) và ngược lại.  

## **Các thao tác chỉnh sửa đơn giản**

Mã C++ này cho bạn thấy cách

**Thêm một đường** vào cuối một đường dẫn

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Thêm một đường** vào vị trí chỉ định trên một đường dẫn:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Thêm một đường cong Bezier bậc ba** vào cuối một đường dẫn:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Thêm một đường cong Bezier bậc ba** vào vị trí chỉ định trên một đường dẫn:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Thêm một đường cong Bezier bậc hai** vào cuối một đường dẫn:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Thêm đường cong Bezier bậc hai** vào vị trí chỉ định trên một đường dẫn:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Thêm một cung** đã cho vào một đường dẫn:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Đóng hình hiện tại** của một đường dẫn:

``` cpp
void CloseFigure();
```
**Đặt vị trí cho điểm tiếp theo**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Xóa đoạn đường** tại một chỉ số cho trước:

``` cpp
void RemoveAt(int32_t index);
```

## **Thêm các điểm tùy chỉnh vào một hình dạng**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_shape) và đặt loại [ShapeType.Rectangle](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path) từ hình.  
3. Thêm một điểm mới giữa hai điểm trên cùng trên đường dẫn.  
4. Thêm một điểm mới giữa hai điểm dưới cùng trên đường dẫn.  
5. Áp dụng đường dẫn cho hình.

Mã C++ này cho bạn thấy cách thêm các điểm tùy chỉnh vào một hình dạng:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Xóa các điểm khỏi một hình dạng**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_shape) và đặt loại [ShapeType.Heart](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path) từ hình.  
3. Xóa đoạn cho đường dẫn.  
4. Áp dụng đường dẫn cho hình.

Mã C++ này cho bạn thấy cách xóa các điểm khỏi một hình dạng:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **Tạo một hình dạng tùy chỉnh**

1. Tính toán các điểm cho hình dạng.  
2. Tạo một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path).  
3. Điền các điểm vào đường dẫn.  
4. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_shape).  
5. Áp dụng đường dẫn cho hình.

Mã C++ này cho bạn thấy cách tạo một hình dạng tùy chỉnh:

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)

## **Tạo một hình dạng tùy chỉnh tổng hợp**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_shape).  
2. Tạo một thể hiện đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path).  
3. Tạo một thể hiện thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path).  
4. Áp dụng các đường dẫn cho hình.

Mã C++ này cho bạn thấy cách tạo một hình dạng tùy chỉnh tổng hợp:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```

![example4_image](custom_shape_4.png)

## **Tạo một hình dạng tùy chỉnh với các góc cong**

Mã C++ này cho bạn thấy cách tạo một hình dạng tùy chỉnh với các góc cong (hướng vào trong);

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Xác định xem hình học của một hình dạng có bị đóng không**

Một hình dạng khép kín được định nghĩa là hình mà tất cả các cạnh của nó nối nhau, tạo thành một ranh giới duy nhất không có khoảng trống. Hình dạng như vậy có thể là một hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Ví dụ mã dưới đây cho thấy cách kiểm tra xem hình học của một hình dạng có bị đóng không:

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **Chuyển đổi GeometryPath sang GraphicsPath** 

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_shape).  
2. Tạo một thể hiện của lớp [GraphicsPath](https://reference.aspose.com/slides/vi/cpp/class/system.drawing.drawing2_d.graphics_path) trong không gian tên [System.Drawing.Drawing2D](https://reference.aspose.com/slides/vi/cpp/namespace/system.drawing.drawing2_d).  
3. Chuyển đổi thể hiện [GraphicsPath](https://reference.aspose.com/slides/vi/cpp/class/system.drawing.drawing2_d.graphics_path) sang thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.geometry_path) bằng [ShapeUtil](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.util.shape_util).  
4. Áp dụng các đường dẫn cho hình.

Mã C++ này — một triển khai các bước trên — trình bày quá trình chuyển đổi **GeometryPath** sang **GraphicsPath**:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```

![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với phần tô và đường viền sau khi thay thế hình học?**

Kiểu dáng vẫn giữ nguyên với hình; chỉ đường viền thay đổi. Phần tô và đường viền sẽ tự động được áp dụng cho hình học mới.

**Làm thế nào để quay đúng một hình dạng tùy chỉnh cùng với hình học của nó?**

Sử dụng thuộc tính [rotation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/set_rotation/) của hình; hình học sẽ quay cùng với hình vì nó được gắn vào hệ tọa độ của chính hình.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành ảnh để "khóa" kết quả không?**

Có. Xuất vùng [slide](/slides/vi/cpp/convert-powerpoint-to-png/) cần thiết hoặc chính [shape](/slides/vi/cpp/create-shape-thumbnails/) ra định dạng raster; điều này làm cho việc làm việc với các hình học phức tạp trở nên đơn giản hơn.