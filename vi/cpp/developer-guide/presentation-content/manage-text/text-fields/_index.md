---
title: Quản lý Trường Văn bản trong Bản trình chiếu PowerPoint bằng C++
linktitle: Trường Văn bản
type: docs
weight: 52
url: /vi/cpp/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- tiêu đề
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Tạo, kiểm tra, sửa đổi và xóa các trường văn bản trong bản trình bày PowerPoint bằng Aspose.Slides cho C++. Bảo tồn định dạng và kiểm tra các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản bao gồm các phần. Một [IPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/) thông thường chứa văn bản nguyên liệu; một phần trường (field) cũng có một [IField](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifield/) mà loại của nó xác định một giá trị được cập nhật tự động, chẳng hạn như số slide hoặc ngày. Hai phần có thể hiển thị cùng ký tự trong khi chỉ một phần chứa trường.

Sử dụng [IPortion::get_Field](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/get_field/) để phân biệt chúng: nó trả về `nullptr` cho văn bản thông thường. [IPortion::AddField](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/addfield/) chuyển một phần hiện có thành trường. Giữ nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không đồng thời thay thế nhãn.

Hướng dẫn này bao gồm các trường trong văn bản, định dạng của chúng, và việc lưu chúng trong PPTX và PPT. Đối với khung văn bản và đoạn văn, xem [Manage Text](/slides/vi/cpp/manage-text/).

## **Tạo Trường Số Slide**

Ví dụ sau tạo một hộp văn bản chứa nhãn nguyên liệu `Slide ` tiếp theo là một số được cập nhật tự động. Nó đặt kích thước, độ đậm và màu sắc của số trước khi thêm trường, sau đó mở lại bản trình bày đã lưu và kiểm tra loại trường, văn bản và định dạng. Không cần tệp đầu vào.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Bản trình bày mới bắt đầu với số slide 1, vì vậy văn bản mong đợi là `Slide 1`, và cả hai kiểm tra nên in ra `True`. Số vẫn là một trường sau khi mở lại; nó không phải là một ký tự nguyên liệu `1`. Các phép chuyển đổi và chỉ mục trong quá trình xác minh đề cập đến hình dạng và các phần được tạo bởi ví dụ này.

## **Chọn Loại Trường**

[FieldType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/) triển khai [IFieldType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifieldtype/) và cung cấp các giá trị định sẵn sau. Gửi giá trị thích hợp tới [AddField](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/addfield/).

| Trình truy cập | Mục đích |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_slidenumber/) | Số slide hiện tại. |
| [get_DateTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_datetime/) | Ngày/giờ theo định dạng mặc định của ứng dụng hiển thị. |
| [get_DateTime1](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_datetime9/) | Các định dạng ngày hoặc kết hợp ngày/giờ đã định sẵn. |
| [get_DateTime10](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_datetime13/) | Các định dạng thời gian đã định sẵn, có tùy chọn giây và đồng hồ 12 giờ. |
| [get_Header](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_header/) | Trường tiêu đề; xem các hạn chế về placeholder và định dạng dưới đây. |
| [get_Footer](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_footer/) | Trường chân trang. |

Ví dụ, [get_DateTime3](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/get_datetime3/) cung cấp ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường đã định sẵn, không phải chuỗi định dạng ngày tùy ý. Ngôn ngữ của phần, được đặt bằng [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_languageid/), và ứng dụng xử lý bản trình bày có thể ảnh hưởng đến kết quả hiển thị.

## **Tạo Trường từ Chuỗi Nội Bộ**

Phiên bản chấp nhận chuỗi của [AddField](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/addfield/) nhận một định danh trường nội bộ. Sử dụng nó khi bảo tồn một định danh được cung cấp bởi ứng dụng khác mà không có giá trị định sẵn. Bạn cũng có thể tạo một [FieldType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fieldtype/fieldtype/) từ định danh đó. [IFieldType::get_InternalString](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifieldtype/get_internalstring/) hiển thị định danh đó để kiểm tra.

Ví dụ này lưu trường `custom-report-id` cụ thể của ứng dụng với văn bản dự phòng `Report-042`. Không cần tệp đầu vào. Định danh không đăng ký phép tính: Aspose.Slides không tạo ID báo cáo cho kiểu không biết. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị của nó.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Sau vòng quay PPTX này, loại mong đợi là `custom-report-id` và văn bản mong đợi là `Report-042`. Truyền một chuỗi như `yyyy-MM-dd` sẽ đặt tên cho một loại trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với ngày cố định trong định dạng tùy ý, hãy sử dụng văn bản thường.

## **Kiểm Tra, Sửa Đổi và Xóa Trường Ngày/Giờ**

Đọc một loại trường hiện có qua [IField::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifield/get_type/) và thay đổi nó qua [IField::set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifield/set_type/). Kiểm tra trường tồn tại trước khi truy cập loại của nó. Để dừng cập nhật tự động, gọi [IPortion::RemoveField](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/removefield/). Thao tác này giữ lại phần và văn bản hiện tại trong khi xóa liên kết trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi xóa trường.

Đối với cài đặt API liên quan đến xử lý trường ngày/giờ, xem [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/set_currentdatetime/). Ví dụ dưới đây sử dụng ngày phê duyệt rõ ràng khi chuyển một trường thành văn bản thường.

Tải về [sample.pptx](sample.pptx) và đặt nó trong thư mục làm việc. Nó chứa hai hình dạng văn bản được đặt tên, `UpdatedAt` và `ApprovedDate`, mỗi cái có một trường ngày/giờ, cùng với các nhãn văn bản thường. Ví dụ sau duyệt các hình dạng văn bản cấp cao trên các slide thông thường. Nó đổi trường ngày/giờ sang định dạng ngày dài và làm chúng in nghiêng, trong khi giữ các định dạng khác. Chỉ các trường trong `ApprovedDate` trở thành văn bản cố định.

Mẫu nhận ra các định danh nội bộ tích hợp sẵn `datetime` và `datetime1` đến `datetime13`. Các nhóm, bảng, ghi chú, bố cục và mẫu yêu cầu duyệt các vùng văn bản riêng của chúng và nằm ngoài phạm vi của ví dụ này.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Sau khi mở lại, `UpdatedAt` nên có loại `datetime3` và vẫn động. `ApprovedDate` không nên có trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, cài đặt in đậm và màu sắc gốc vẫn giữ nguyên. Các nhãn văn bản thường không thay đổi. Việc xác minh đọc phần đầu tiên của hai hình dạng đã biết trong mẫu được cung cấp.

## **Bảo Vệ Định Dạng Văn Bản**

Làm việc với phần hiện có khi thêm trường, thay đổi loại hoặc xóa nó. Các thao tác này giữ lại định dạng của phần. Sử dụng [IPortion::get_PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/get_portionformat/) để chỉ thay đổi các thuộc tính cần thiết, như các ví dụ làm cho màu sắc hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc này có thể làm mất ranh giới phần ban đầu và định dạng riêng của chúng. Cũng cần phân biệt định dạng được đặt rõ ràng với định dạng kế thừa từ đoạn, bố cục hoặc chủ đề. Xem [Text Formatting](/slides/vi/cpp/text-formatting/) để biết các tùy chọn định dạng mở rộng.

## **Trường và Các Placeholder Tiêu Đề/Chân Trang**

Một trường là một phần của một phần văn bản. Placeholder là một hình dạng có vai trò trong bản trình bày, chẳng hạn như chân trang hoặc số slide. Thêm một trường vào hộp văn bản thông thường không biến hình dạng đó thành placeholder.

Trình quản lý tiêu đề/chân trang kiểm soát văn bản placeholder và khả năng hiển thị trên các slide, bố cục và mẫu, bao gồm việc lan truyền tới các slide phụ thuộc. Vì vậy một trường số trong hộp văn bản tùy chỉnh có thể hữu ích ngay cả khi bạn không sử dụng placeholder số slide. Ngược lại, thay đổi khả năng hiển thị placeholder không xóa một trường khỏi hộp văn bản không liên quan.

Các loại tiêu đề và chân trang định sẵn không tạo các placeholder tương ứng nor cung cấp nội dung của chúng. Cụ thể, một slide PowerPoint thông thường không có placeholder tiêu đề; tiêu đề thuộc về trang ghi chú và tài liệu phát tay. Đừng giả định rằng một trường tiêu đề hoặc chân trang trong một hình dạng bất kỳ sẽ tự động nhận được văn bản được cấu hình qua trình quản lý placeholder. Đối với quy trình đó, xem [Presentation Headers and Footers](/slides/vi/cpp/presentation-header-and-footer/).

## **Giới Hạn của PPTX và PPT**

Kiểm tra cả loại trường và văn bản kết quả của nó sau khi lưu và mở lại. Bảo tồn một định danh không chứng minh rằng một ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định dạng | Hành vi và giới hạn của trường |
|---|---|
| PPTX | Lưu các định danh trường nội bộ cùng với văn bản trường. Sử dụng các ví dụ trên để kiểm tra các loại định sẵn và định danh tùy chỉnh sau khi lưu và mở lại. Một loại tùy chỉnh không biết sẽ không có logic tính toán tự động. Ứng dụng khác có thể xử lý các định danh không được hỗ trợ khác nhau. |
| PPT | Sử dụng các biểu diễn trường legacy và có khả năng tương thích hạn chế hơn. Các trường số slide và trường ngày/giờ định sẵn có biểu diễn legacy. Các trường tùy chỉnh không được hỗ trợ hoặc các trường tiêu đề trong hộp văn bản slide thông thường có thể tạo ra `*` làm văn bản. Không nên dựa vào việc các trường tùy chỉnh hoặc ngữ cảnh trường không được hỗ trợ giữ lại văn bản hiển thị của chúng. |

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một số hoặc ngày hiển thị là trường hay không?**

Kiểm tra [IPortion::get_Field](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/get_field/). Giá trị không null xác định một trường; chỉ dựa vào văn bản hiển thị không thể biết được.

**Việc xóa một trường có xóa văn bản hoặc định dạng của nó không?**

Không. [RemoveField](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/removefield/) chuyển phần hiện có thành văn bản thường. Gán một giá trị rõ ràng sau đó nếu bạn cần một ngày cố định hoặc giá trị dự phòng cụ thể.

**Chuỗi nội bộ có thể định nghĩa định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một loại trường. Định danh không biết không cung cấp bộ đánh giá hoặc mẫu định dạng ngày. Sử dụng một loại định sẵn được hỗ trợ hoặc định dạng giá trị tự mình như văn bản thường.

**Tại sao phải kiểm tra lại bản trình bày sau khi lưu?**

Các định danh trường, văn bản đã tính và định dạng là các yếu tố riêng biệt cần xác minh. Việc chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay cả khi định danh trường vẫn còn.