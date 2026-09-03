---
title: Quản lý các hộp văn bản trong bản trình bày bằng C++
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/cpp/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tạo, xác định, định dạng và cập nhật các hộp văn bản trong bản trình bày PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho C++."
---
## **Giới thiệu**

Trong Aspose.Slides cho C++, văn bản của slide được lưu trong các khung văn bản (text frames) thuộc về các hình dạng. Giao diện [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) đại diện cho hình dạng chứa văn bản phổ biến nhất và cung cấp văn bản của nó thông qua phương thức [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Lưu ý" %}}
Mỗi auto shape đều triển khai [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), nhưng không phải mọi hình dạng đều là auto shape hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình bày hiện có, hãy kiểm tra xem một hình dạng có triển khai [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) trước khi truy cập văn bản của nó.
{{% /alert %}}

## **Tạo một hộp văn bản trên slide**

Để tạo một hộp văn bản, thêm một auto shape vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình bày. Ví dụ sau tạo một hộp văn bản hình chữ nhật:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Các tọa độ và kích thước truyền cho [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addautoshape/) được đo bằng điểm. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/addtextframe/) khởi tạo khung văn bản với văn bản được cung cấp.

## **Kiểm tra xem hình dạng có phải là hộp văn bản không**

Sử dụng phương thức [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/get_istextbox/) để xác định liệu một auto shape có được coi là hộp văn bản hay không. Điều này hữu ích khi một bản trình bày chứa cả các auto shape có văn bản và các auto shape chỉ là đồ họa.

![Một hộp văn bản và một hình dạng](istextbox.png)

Ví dụ sau kiểm tra mọi auto shape trong một bản trình bày:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Một auto shape mới được thêm vào sẽ không được coi là hộp văn bản cho tới khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó thông qua [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/addtextframe/) hoặc [ITextFrame::set_Text](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/set_text/). Gán một chuỗi rỗng sẽ khiến [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/get_istextbox/) trả về `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Hai kiểm tra đầu tiên trả về `true`; hai kiểm tra cuối trả về `false`.

## **Tìm hình dạng sở hữu một khung văn bản**

Mã xử lý văn bản chung có thể nhận một [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) mà không biết đối tượng bản trình bày nào chứa nó. Sử dụng phương thức [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentshape/) để quay lại hình dạng sở hữu [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/).

Đối với một khung văn bản thuộc về một auto shape hoặc một hình dạng khác có văn bản, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentshape/) trả về chủ sở hữu và [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentcell/) trả về `nullptr`. Cả hai phương thức đều cung cấp điều hướng chỉ đọc. Kiểm tra giá trị trả về đối với `nullptr` trước khi truy cập. Để xác định cả chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên quan tới nút SmartArt, hãy xem mục [Search and Replace Text](/slides/vi/cpp/search-and-replace-text/).

## **Thêm cột vào hộp văn bản**

Phương thức [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_columncount/) chia khung văn bản thành các cột, trong khi [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_columnspacing/) đặt khoảng cách giữa các cột tính bằng điểm. Cả hai phương thức đều thuộc về [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) và có thể được gọi thông qua khung văn bản của một hộp văn bản hiện có. Văn bản được luồng lại giữa các cột trong cùng một hình dạng; nó sẽ không tiếp tục sang một hình dạng khác.

Ví dụ sau tạo một hộp văn bản ba cột với khoảng 10 điểm giữa các cột, lưu bản trình bày và đọc lại các cài đặt đã lưu từ tệp đầu ra:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Trích xuất văn bản từ từng cột**

Sử dụng [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/splittextbycolumns/) để lấy văn bản được gán cho mỗi cột hiển thị trong một khung văn bản hiện có. Phương thức trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Khung văn bản một cột sẽ tạo một mảng có một phần tử, và một cột trống được biểu diễn bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng cấp phần không được lưu giữ.

Điều này hữu ích khi bạn cần:

- Trích xuất văn bản đồng thời giữ thứ tự đọc theo cột.
- Lập chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường trong cơ sở dữ liệu hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thiết lập số cột bằng [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_columncount/) hoặc khoảng cách bằng [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_columnspacing/), hoặc khi thay đổi phông chữ hoặc kích thước khung văn bản.

Phương thức báo cáo văn bản đã phân phối trong [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) hiện tại; nó không tự động luồng văn bản giữa các hình dạng hoặc hộp văn bản riêng biệt. Phân phối cột có thể phụ thuộc vào phông chữ khả dụng và các cài đặt bố cục văn bản khác, vì vậy hãy chắc chắn rằng các phông chữ cần thiết có sẵn khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình bày, tìm auto shape đa cột đầu tiên có khung văn bản trên slide đầu, đọc số cột đã cấu hình và ghi văn bản từ mỗi cột ra một tệp riêng. Các hình dạng không cung cấp khung văn bản sẽ bị bỏ qua.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Cập nhật văn bản**

Để cập nhật văn bản trong toàn bộ bản trình bày, duyệt qua các slide và hình dạng, chọn các auto shape, sau đó chỉnh sửa các phần văn bản của chúng. Làm việc ở cấp phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

Ví dụ sau thay thế mọi xuất hiện của `years` bằng `months` trong các phần văn bản của từng auto shape và đặt phần bị ảnh hưởng thành in đậm:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Quá trình duyệt này chỉ cập nhật văn bản trong auto shape. Văn bản lưu trong bảng, biểu đồ, SmartArt hoặc các hình dạng nhóm yêu cầu duyệt qua các bộ sưu tập riêng của các đối tượng đó.

## **Thêm hộp văn bản có siêu liên kết**

Một siêu liên kết có thể được gán cho một phần văn bản cụ thể, vì vậy chỉ phần văn bản đó sẽ hoạt động như một liên kết có thể nhấp. Sử dụng [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) để liên kết phần văn bản với URL bên ngoài.

Ví dụ sau tạo văn bản có liên kết và lưu nó vào một bản trình bày:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa hộp văn bản và phần giữ chỗ văn bản trên slide mẫu hoặc bố cục là gì?**

Một [placeholder](/slides/vi/cpp/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [master slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/masterslide/) hoặc [layout slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/layoutslide/). Một hộp văn bản thông thường là một hình dạng độc lập trên slide mà nó được tạo và không nhận hành vi giữ chỗ khi bố cục thay đổi.

**Làm thế nào để thay thế văn bản mà không thay đổi văn bản trong biểu đồ, bảng hoặc SmartArt?**

Hạn chế việc duyệt chỉ đối với các hình dạng triển khai [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/), như trong ví dụ Cập nhật văn bản. Biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng của chúng, vì vậy chúng sẽ không bị thay đổi bởi vòng lặp đó.