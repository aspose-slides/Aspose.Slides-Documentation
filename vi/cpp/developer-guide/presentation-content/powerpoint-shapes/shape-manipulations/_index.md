---
title: Quản lý các hình dạng trong bài thuyết trình bằng C++
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/cpp/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- điểm điều chỉnh hình dạng
- điều chỉnh hình dạng preset
- hình học hình dạng
- định dạng layout hình dạng
- hình dạng dưới dạng SVG
- chuyển hình dạng sang SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình dạng trong bài thuyết trình bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ biểu diễn các hình dạng trên một trang chiếu dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và chỉnh sửa các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình ở phía sau nhất, trong khi chỉ mục cuối cùng là hình ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách chắc chắn và chỉnh sửa các điểm điều chỉnh hình dạng được đặt sẵn, sau đó cho thấy cách sao chép, xóa, ẩn và thay đổi thứ tự các hình dạng. Các phần cuối đề cập đến định dạng ở mức layout, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng những thao tác mà quy trình của bạn yêu cầu.

## **Xác định và Tìm hình dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc thay đổi thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Hãy chọn một định danh tùy thuộc vào cách bài thuyết trình được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy tắc đặt tên nếu mã của bạn phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_alternativetext/) hữu dụng khi một mô tả khả năng truy cập hoặc thẻ do người tạo cung cấp đã xác định rõ hình dạng. Nó hiển thị cho người dùng, có thể được địa phương hoá hoặc viết lại cho khả năng truy cập và không được đảm bảo là duy nhất. Đừng lạm dụng văn bản khả năng truy cập có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_officeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một trang chiếu và tương ứng với ID hình dạng mà PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt thời gian tồn tại của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng của nó.

Thuộc tính [UniqueId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_uniqueid/) liên quan có phạm vi toàn bộ bài thuyết trình, nhưng nó được dự định cho các add‑in và có thể được gán lại. Nó không nên được xem như một khóa bên ngoài vĩnh viễn. Nếu nhận dạng lâu dài là cần thiết, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Ví dụ sau tìm kiếm theo `Name` và báo cáo ID interop theo phạm vi trang chiếu. Khi mẫu không chứa hình dạng mong đợi, đoạn mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác chỉ áp dụng cho một loại hình dạng, hãy kiểm tra giao diện trước khi sử dụng các thành viên đặc thù loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/).

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

## **Xác định và Chỉnh sửa Các Điều chỉnh Hình dạng Đặt sẵn**

Các hình dạng hình học đặt sẵn có thể tiết lộ các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ đọc [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igeometryshape/get_adjustments/). Bộ sưu tập được cung cấp bởi hình dạng, nhưng mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục cố định trong bộ sưu tập. Duyệt qua các điều chỉnh và kiểm tra thuộc tính chỉ đọc [IAdjustValue::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/get_type/) mà giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapeadjustmenttype/) mô tả điều chỉnh đang kiểm soát gì. Thuộc tính chỉ đọc [IAdjustValue::get_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/get_name/) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa nhiều hơn một điều chỉnh cùng kiểu ngữ nghĩa.

Sử dụng thuộc tính giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước các góc bo tròn | [RawValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Độ dày của phần đuôi mũi tên | `RawValue` |
| `ArrowheadLength` | Độ dài của đầu mũi tên | `RawValue` |
| `ArrowheadWidth` | Độ rộng của đầu mũi tên | `RawValue` |
| `StartAngle` | Góc bắt đầu của một phần bánh hoặc cung | [AngleValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Góc kết thúc của một phần bánh hoặc cung | `AngleValue` |

`Type` và `Name` không thể gán. `RawValue` là một số nguyên đọc/ghi theo đơn vị hình học gốc của preset, trong khi `AngleValue` là một góc đọc/ghi tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào [ShapeType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igeometryshape/get_shapetype/) của preset. Một giá trị hợp lệ với một preset có thể không hợp lệ hoặc có hiệu ứng khác với preset khác.

Khi `Type` là `ShapeAdjustmentType::Custom`, API không nhận diện ý nghĩa ngữ nghĩa tiêu chuẩn. Kiểm tra `Name`, kiểu preset và giá trị hiện có, và để nguyên điều chỉnh trừ khi bạn biết ý nghĩa và phạm vi mong đợi. Ngay cả với các kiểu được nhận diện, cũng hãy kiểm tra xem cùng một kiểu có xuất hiện hơn một lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/cpp/connector/) cho thấy tình huống này với các điều chỉnh độ cong của connector.

Ví dụ hoàn chỉnh sau tạo các phiên bản mặc định và đã chỉnh sửa của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo `Name` và `Type`, thay đổi các giá trị liên quan tới kích thước qua `RawValue`, thay đổi góc qua `AngleValue`, và lưu kết quả. Cột bên trái giữ nguyên hình học mặc định; cột bên phải hiển thị hình chữ nhật bo tròn, mũi tên bốn chiều và bánh đã được điều chỉnh.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Thêm tiêu đề cho các cột hình dạng mặc định và đã điều chỉnh.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kiểm tra kiểu ngữ nghĩa trước khi thay đổi giá trị làm cho mã rõ ràng về ý định và tránh giả định rằng một chỉ mục bộ sưu tập cụ thể có cùng ý nghĩa trên các hình dạng preset khác nhau.

## **Chỉnh sửa Bộ sưu tập Hình dạng**

Các phương thức thêm, sao chép, xóa và thay đổi thứ tự hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự của các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước thao tác đó.

### **Sao chép một Hình dạng**

[AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addclone/) tạo một bản sao độc lập và thêm vào cuối bộ sưu tập đích. [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/insertclone/) cũng tạo bản sao nhưng đặt nó ở một chỉ mục z‑order xác định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Các thay đổi đối với bất kỳ bản sao nào cũng không làm thay đổi hình dạng nguồn.

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

Sao chép bao gồm nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên được sử dụng bởi các hình dạng phức tạp được trình chiếu quản lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với một định danh hình dạng mới.

### **Xóa Hình dạng**

[Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều đối tượng phù hợp trong quá trình lặp có chỉ mục, hãy duyệt từ cuối danh sách để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên đã chỉ định. Nó đọc hình dạng hiện tại theo chỉ mục, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng một cách không cần thiết.

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

Sau khi xóa, số lượng hình dạng và các chỉ mục của các hình dạng sau thay đổi. Tham chiếu tới các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần cân nhắc các connector, hoạt ảnh và các tính năng trình chiếu khác có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn cả giao diện của slide.

### **Ẩn một Hình dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_hidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi trình chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy việc ẩn phù hợp cho các yếu tố tùy chọn có thể được khôi phục sau này.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và bỏ ẩn, và nó vẫn là một phần của tệp trình chiếu.

### **Thay đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [Reorder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/reorder/) di chuyển một hình dạng đã tồn tại tới một chỉ mục đích mà không sao chép nó. Chỉ mục `0` là phía sau; `Count - 1` là phía trước.

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

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện thứ tự z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác này thêm hoặc chèn mục mới vào bộ sưu tập và có thể làm thay đổi ngăn xếp dự định.

## **Kiểm tra Hình dạng trên Slides Layout**

Slides bình thường, slides layout và master slides có các bộ sưu tập hình dạng riêng. Một hình dạng trong bộ sưu tập layout không phải là cùng một đối tượng với một hình dạng tương tự trên slide bình thường. Kiểm tra các hình dạng layout khi bạn cần hiểu hoặc thay đổi định dạng do layout cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_fillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_lineformat/) của mỗi hình dạng layout mà không giả định rằng mọi hình dạng đều là `AutoShape`.

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

Chỉnh sửa một layout có thể ảnh hưởng đến nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng layout, hãy xác định liệu một slide bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và kiểm tra mọi slide sử dụng layout đó.

## **Xuất Hình dạng thành SVG**

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

Giữ trình chiếu mở khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải đóng hoặc giải phóng nó.

## **Căn chỉnh Hình dạng**

Các overload của [SlideUtil::AlignShapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/alignshapes/) căn chỉnh toàn bộ hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương đối với nhau.

Ví dụ này căn ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển đổi thành chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không phải z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn thay đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `FlipH` và `FlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/cpp/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ nguyên trạng thái chưa xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình dạng chưa được lật.

![Hình dạng trước khi lật](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_frame/) mới sẽ thay thế toàn bộ khung.

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

Hình dạng đã lưu được lật ngược chiều ngang và chiều dọc trong khi giữ nguyên vị trí, kích thước và góc quay.

![Hình dạng sau khi lật](flipped_shape.png)

## **Câu hỏi thường gặp**

**Tôi có nên dùng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng trong quá trình xử lý ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên một quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo sẵn, hoặc `OfficeInteropShapeId` cho công việc interop theo phạm vi slide.

**Việc ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn còn trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm, thay đổi thứ tự, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng được sao chép lại xuất hiện trước một hình dạng khác?**

`AddClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước trong z‑order. Hãy dùng `InsertClone` để chọn chỉ mục ban đầu hoặc `Reorder` sau khi đã thêm tất cả các hình dạng.

**Tôi có thể dùng một chỉ mục cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ được sau khi xác thực preset và cấu trúc bộ sưu tập chính xác. Ưu tiên duyệt qua `IGeometryShape::get_Adjustments` và kiểm tra `IAdjustValue::get_Type`; dùng `IAdjustValue::get_Name` như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện hơn một lần.