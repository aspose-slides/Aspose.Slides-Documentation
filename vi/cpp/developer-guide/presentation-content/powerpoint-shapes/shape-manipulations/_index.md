---
title: Quản lý các hình dạng trong bản thuyết trình bằng C++
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/cpp/shape-manipulations/
keywords:
- Hình dạng PowerPoint
- Hình dạng bản thuyết trình
- Hình dạng trên slide
- Tìm hình dạng
- Sao chép hình dạng
- Xóa hình dạng
- Ẩn hình dạng
- Thay đổi thứ tự hình dạng
- Lấy ID hình dạng interop
- Văn bản thay thế cho hình dạng
- Định dạng bố cục hình dạng
- Hình dạng dưới dạng SVG
- Chuyển hình dạng sang SVG
- Căn chỉnh hình dạng
- Lật hình dạng
- PowerPoint
- bản thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách xác định, sao chép, xóa, ẩn, sắp xếp lại, xuất, căn chỉnh và lật các hình dạng trong bản thuyết trình bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides cho C++ biểu thị các hình dạng trên một slide dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng vừa là nguồn cung cấp thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy, sau đó trình bày cách sao chép, xóa, ẩn và sắp xếp lại các hình dạng. Các phần cuối cùng bao gồm định dạng ở mức layout, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ là độc lập, vì vậy bạn chỉ cần sử dụng những thao tác cần thiết cho quy trình của mình.

## **Xác định và Tìm kiếm Hình dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp xếp lại một hình dạng có thể thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách bản thuyết trình được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_alternativetext/) hữu dụng khi mô tả trợ năng hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho trợ năng, và cũng không được đảm bảo là duy nhất. Không nên tự ý dùng lại văn bản trợ năng có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_officeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt thời gian tồn tại của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và sẽ nhận ID riêng.

Thuộc tính [UniqueId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_uniqueid/) liên quan có phạm vi toàn bộ bản thuyết trình, nhưng nó được thiết kế cho các add‑in và có thể được gán lại. Không nên coi nó là khóa ngoại vi cố định. Nếu nhận dạng lâu dài là cần thiết, hãy lưu ánh xạ trong dữ liệu ứng dụng và kiểm tra rằng hình dạng mong đợi vẫn còn tồn tại.

Ví dụ sau tìm kiếm theo `Name` và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Khi một thao tác chỉ áp dụng cho một loại hình dạng, hãy kiểm tra giao diện trước khi sử dụng các thành viên đặc thù. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Sửa đổi Bộ sưu tập Hình dạng**

Các phương thức thêm, sao chép, xóa và sắp xếp lại hoạt động ngay trên bộ sưu tập. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, không tiếp tục dựa vào các chỉ mục đã được lấy trước khi thực hiện thao tác đó.

### **Sao chép một Hình dạng**

[AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addclone/) tạo một bản sao độc lập và thêm vào cuối bộ sưu tập đích. [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z‑order chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không làm thay đổi hình dạng nguồn.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sao chép sao chép nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được quản lý bởi bản thuyết trình, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Hình dạng**

[Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả khớp trong quá trình lặp có chỉ mục, hãy duyệt từ cuối về đầu để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng hiện đang được chỉ mục, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng một cách không cần thiết.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình dạng phía sau thay đổi. Các tham chiếu đến những hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần xem xét các connector, animation và các tính năng khác của bản thuyết trình có thể tham chiếu đến đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn cả giao diện của slide.

### **Ẩn một Hình dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_hidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó hiển thị trong chế độ trình chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn có sẵn cho mã, vì vậy việc ẩn phù hợp cho các thành phần tùy chọn có thể được khôi phục sau.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và hiển thị lại, và nó vẫn là một phần của file bản thuyết trình.

### **Thay đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [Reorder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/reorder/) di chuyển một hình dạng hiện có tới một chỉ mục mục tiêu mà không sao chép nó. Chỉ mục `0` là phía sau; `Count - 1` là phía trước.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ thêm hoặc chèn mục mới vào bộ sưu tập và có thể làm thay đổi cấu trúc xếp chồng dự định.

## **Kiểm tra Hình dạng trên Slide Layout**

Slide bình thường, slide layout và master slide có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập layout không phải là cùng một đối tượng với một hình dạng ở vị trí tương tự trên slide bình thường. Kiểm tra các hình dạng layout khi bạn cần hiểu hoặc thay đổi định dạng do layout cung cấp.

Ví dụ dưới đây đọc [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_fillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_lineformat/) của mỗi hình dạng layout mà không giả định mọi hình dạng đều là `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Việc chỉnh sửa một layout có thể ảnh hưởng đến nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng layout, xác định xem một slide bình thường có kế thừa đối tượng này hay chứa một ghi đè cục bộ, và kiểm thử mọi slide sử dụng layout đó.

## **Xuất Hình dạng sang SVG**

[WriteAsSvg](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/writeassvg/) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không phải toàn bộ nền slide hay các hình dạng lân cận.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Giữ bản thuyết trình mở khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và vào các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải đóng hoặc giải phóng nó.

## **Căn chỉnh Hình dạng**

Các overload của [SlideUtil::AlignShapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/alignshapes/) căn chỉnh hoặc toàn bộ hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân bố. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Căn chỉnh thay đổi vị trí, không thay đổi z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân bố theo chiều ngang hoặc chiều dọc cần đủ số hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, thiết lập lật ngang và dọc, và góc quay. Các giá trị `FlipH` và `FlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/cpp/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ nguyên trạng thái chưa xác định/mặc định.

Bản thuyết trình đầu vào dưới đây chứa một hình dạng chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai thiết lập lật. Điều này quan trọng vì việc gán một [Frame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_frame/) mới sẽ thay thế toàn bộ khung.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hình dạng đã lưu được lật ngược theo chiều ngang và chiều dọc trong khi vẫn giữ vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Nên sử dụng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng trong các quy trình ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên một quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo sẵn, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn ở trong bộ sưu tập với cùng chỉ mục. Nó có thể được tìm, sắp xếp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng được sao chép lại xuất hiện phía trước một hình dạng khác?**

`AddClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước của z‑order. Sử dụng `InsertClone` để chọn chỉ mục khởi tạo hoặc `Reorder` sau khi đã thêm tất cả các hình dạng.