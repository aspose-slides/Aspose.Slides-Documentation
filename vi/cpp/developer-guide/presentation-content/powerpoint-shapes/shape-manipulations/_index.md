---
title: Quản lý các hình dạng trong bản trình chiếu bằng C++
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/cpp/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình trên slide
- tìm hình
- sao chép hình
- xóa hình
- ẩn hình
- thay đổi thứ tự hình
- lấy ID hình interop
- văn bản thay thế của hình
- điểm điều chỉnh hình
- điều chỉnh hình dạng preset
- hình học của hình
- định dạng layout của hình
- hình dưới dạng SVG
- chuyển hình sang SVG
- căn chỉnh hình
- lật hình
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ biểu diễn các hình dạng trên một slide dưới dạng một ordered [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/). Bộ sưu tập vừa là nơi bạn tìm và chỉnh sửa các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình ở phía sau nhất, trong khi chỉ mục cuối cùng là hình ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy và chỉnh sửa các điểm điều chỉnh hình dạng được đặt trước, sau đó cho thấy cách sao chép, xóa, ẩn và thay đổi thứ tự các hình dạng. Các phần cuối cùng bao gồm định dạng mức layout, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác cần thiết cho quy trình của mình.

## **Xác định và Tìm Kiếm Các Hình Dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một file đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc thay đổi thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách bản trình chiếu được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong **Selection Pane** của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_alternativetext/) hữu dụng khi mô tả khả năng truy cập hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị với người dùng, có thể được bản địa hoá hoặc viết lại để truy cập, và không được đảm bảo là duy nhất. Đừng chuyển mục đích của văn bản khả năng truy cập có ý nghĩa thành khóa cơ sở dữ liệu một cách âm thầm.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_officeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng mà PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng.

Thuộc tính [UniqueId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_uniqueid/) có phạm vi toàn bộ bản trình chiếu, nhưng nó được thiết kế cho các add‑in và có thể được gán lại. Không nên coi nó như một khóa ngoại permanents. Nếu nhận dạng lâu dài là cần thiết, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Đối với một ví dụ thực tế về đọc và cập nhật cả tiêu đề và mô tả văn bản thay thế, xem [Manage Alternative Text Titles and Descriptions](/slides/vi/cpp/presentation-accessibility/). Sử dụng văn bản thay thế để giải thích ý nghĩa hình ảnh cho người đọc, và giữ nó riêng biệt khỏi tên hình dạng mà mã dùng để tìm kiếm hình dạng.

Ví dụ dưới đây tìm kiếm bằng `Name` và báo cáo ID interop theo phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác đặc thù cho một loại hình dạng, hãy kiểm tra giao diện trước khi dùng các thành phần riêng loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/).

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

## **Xác định và Chỉnh Sửa Các Điều Chỉnh Hình Dạng Đặt Trước**

Các hình dạng hình học được đặt trước có thể hiển thị các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ đọc [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igeometryshape/get_adjustments/). Bộ sưu tập này được cung cấp bởi hình dạng, nhưng mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục cố định của bộ sưu tập. Duyệt qua các điều chỉnh và kiểm tra thuộc tính chỉ đọc [IAdjustValue::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/get_type/) mà giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapeadjustmenttype/) mô tả điều gì mà điều chỉnh kiểm soát. Thuộc tính chỉ đọc [IAdjustValue::get_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/get_name/) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa hơn một điều chỉnh có cùng kiểu ngữ nghĩa.

Sử dụng thuộc tính giá trị tương ứng với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước các góc bo tròn | [RawValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Độ dày phần cuối mũi tên | `RawValue` |
| `ArrowheadLength` | Chiều dài đầu mũi tên | `RawValue` |
| `ArrowheadWidth` | Chiều rộng đầu mũi tên | `RawValue` |
| `StartAngle` | Góc bắt đầu của phần tròn hoặc cung | [AngleValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Góc kết thúc của phần tròn hoặc cung | `AngleValue` |

`Type` và `Name` không thể gán giá trị. `RawValue` là một số nguyên đọc/ghi theo đơn vị hình học gốc của preset, trong khi `AngleValue` là một góc đọc/ghi tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset [ShapeType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igeometryshape/get_shapetype/). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho preset khác.

Khi `Type` là `ShapeAdjustmentType::Custom`, API không nhận ra ý nghĩa ngữ nghĩa tiêu chuẩn. Kiểm tra `Name`, kiểu preset và giá trị hiện tại, và để nguyên điều chỉnh nếu không biết ý nghĩa và phạm vi mong đợi. Ngay cả với các loại đã được công nhận, cũng hãy kiểm tra xem cùng một loại có xuất hiện hơn một lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/cpp/connector/) cho thấy tình huống này với các điều chỉnh độ cong của connector.

Ví dụ hoàn chỉnh dưới đây tạo các phiên bản mặc định và đã sửa đổi của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo `Name` và `Type`, thay đổi các giá trị liên quan đến kích thước bằng `RawValue`, thay đổi góc bằng `AngleValue`, và lưu kết quả. Cột bên trái giữ hình học mặc định; cột bên phải hiển thị hình chữ nhật bo tròn đã điều chỉnh, mũi tên bốn chiều và hình tròn.

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

Kiểm tra kiểu ngữ nghĩa trước khi thay đổi giá trị làm cho mã rõ ràng về mục đích và tránh giả sử rằng một chỉ mục bộ sưu tập cụ thể có cùng ý nghĩa trên các hình preset khác nhau.

## **Chỉnh Sửa Bộ Sưu Tập Hình Dạng**

Các phương thức add, clone, remove và reorder hoạt động ngay trên bộ sưu tập. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được ghi lại trước thao tác đó.

### **Sao Chép Một Hình Dạng**

[AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addclone/) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập đích. [InsertClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó tại một chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao có thể thay đổi kích thước đồng thời.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước và chèn một bản sao thứ hai vào phía sau. Thay đổi nào trên một bản sao cũng không ảnh hưởng đến hình dạng nguồn.

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

Sao chép sao chép nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được quản lý bởi bản trình chiếu, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Các Hình Dạng**

[Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều khớp trong quá trình lặp có chỉ mục, hãy duyệt từ cuối danh sách để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng hiện tại theo chỉ mục, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng một cách không cần thiết.

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

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình sau thay đổi. Tham chiếu tới các hình không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần xem xét các connector, animation và các tính năng khác của bản trình chiếu có thể tham chiếu tới đối tượng đã bị xóa; việc xóa một hình hiển thị có thể thay đổi hơn cả diện mạo của slide.

### **Ẩn Một Hình Dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_hidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi trình chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy ẩn thích hợp cho các yếu tố tùy chọn có thể được khôi phục sau.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được khám phá và hiển thị lại bởi người dùng hoặc mã, và nó vẫn là một phần của file bản trình chiếu.

### **Thay Đổi Thứ Tự Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự bộ sưu tập. [Reorder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/reorder/) di chuyển một hình dạng hiện có tới chỉ mục mục tiêu mà không sao chép nó. Chỉ mục `0` là phía sau; `Count - 1` là phía trước.

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

Hình chữ nhật được tạo đầu tiên và ban đầu nằm sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện thứ tự z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ thêm hoặc chèn các mục mới vào bộ sưu tập và có thể thay đổi lớp xếp chồng mong muốn.

## **Kiểm Tra Các Hình Dạng Trên Slide Layout**

Slide bình thường, slide layout và master slide có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập layout không phải là cùng một đối tượng với một hình dạng tương tự vị trí trên slide bình thường. Kiểm tra các hình dạng layout khi bạn cần hiểu hoặc thay đổi định dạng do layout cung cấp.

Ví dụ dưới đây đọc [FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_fillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_lineformat/) của mỗi hình dạng layout mà không giả định rằng mọi hình dạng đều là một `AutoShape`.

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

Chỉnh sửa một layout có thể ảnh hưởng tới nhiều slide dùng nó. Trước khi thay đổi một hình dạng layout, xác định slide bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và thử nghiệm mọi slide sử dụng layout đó.

## **Xuất Hình Dạng Thành SVG**

[WriteAsSvg](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/writeassvg/) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không bao gồm toàn bộ nền slide hay các hình dạng lân cận.

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

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì từng hình dạng riêng lẻ. Người gọi sở hữu luồng và phải đóng hoặc giải phóng nó.

## **Căn Chỉnh Các Hình Dạng**

Các overload của [SlideUtil::AlignShapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/alignshapes/) căn chỉnh tất cả các hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn chỉnh các hình đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng được trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không thay đổi z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại các chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `FlipH` và `FlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/cpp/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái không xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình không được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì việc gán một [Frame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_frame/) mới sẽ thay thế toàn bộ khung.

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

Hình đã lưu được lật ngược cả chiều ngang và chiều dọc trong khi vẫn giữ vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh cho một hình dạng không?**

Chỉ nên dùng cho các quy trình ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi sử dụng chỉ mục. Ưu tiên sử dụng `Name` hoặc quy ước `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop theo phạm vi slide.

**Ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn còn trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm, thay đổi thứ tự, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng sao chép lại xuất hiện phía trước một hình dạng khác?**

`AddClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước của z‑order. Sử dụng `InsertClone` để chọn chỉ mục ban đầu hoặc `Reorder` sau khi đã thêm tất cả các hình dạng.

**Có thể dùng một chỉ mục cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ được sau khi xác thực preset và bố cục bộ sưu tập chính xác. Ưu tiên duyệt qua `IGeometryShape::get_Adjustments` và kiểm tra `IAdjustValue::get_Type`; sử dụng `IAdjustValue::get_Name` như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.