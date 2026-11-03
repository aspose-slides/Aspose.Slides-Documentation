---
title: Quản lý Placeholder trong Bản Trình Chiếu bằng C++
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/cpp/manage-placeholder/
keywords:
- placeholder
- placeholder văn bản
- placeholder hình ảnh
- placeholder biểu đồ
- placeholder nội dung
- văn bản gợi ý
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, cũng như hiểu về kế thừa placeholder với Aspose.Slides cho C++."
---
## **Tổng quan**

Placeholder là một hình dạng dành chỗ cho một loại nội dung nhất định trong mẫu bài thuyết trình. Các ví dụ phổ biến gồm tiêu đề, phần thân, hình ảnh, biểu đồ và các placeholder nội dung tổng quát. Không giống như một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ slide bố cục hoặc slide chủ.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/). Phương thức này trả về một đối tượng [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) hoặc `nullptr` cho một hình dạng bình thường. Sử dụng [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) để xác định placeholder dự định chứa gì.

Interface của hình dạng vẫn quan trọng sau khi bạn đã biết loại placeholder:

- Placeholder trống cho văn bản, hình ảnh, biểu đồ hoặc nội dung thường được biểu diễn bằng một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Giao diện placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) và giao diện hình dạng thời gian chạy thay vì giả định mọi placeholder đều là một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) mô tả vai trò của placeholder; nó không đảm bảo kiểu thời gian chạy của hình dạng. Luôn kiểm tra kiểu trước khi truy cập các thành viên liên quan đến văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.{{% /alert %}}

## **Hiểu về Kế thừa Placeholder**

Placeholder tạo thành một phân cấp:

1. Slide chủ định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức master.
2. Slide bố cục định nghĩa cách sắp xếp được sử dụng cho một hoặc nhiều slide bình thường và có thể kế thừa từ master.
3. Slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ bố cục của nó.

Gọi [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) để di chuyển lên một cấp trong phân cấp này. Placeholder của slide thường trả về placeholder bố cục của nó; một placeholder bố cục có thể trả về placeholder master. Phương thức trả về `nullptr` khi hình dạng không có placeholder cơ sở.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo placeholder cơ sở của chúng:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Chỉnh sửa một placeholder trên slide bình thường tạo hoặc thay đổi ghi đè cục bộ cho slide đó. Chỉnh sửa bố cục hoặc master liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Xóa Trạng Thái Placeholder**

Khi điều chỉnh một mẫu, sử dụng [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) để giữ đối tượng hiện có như một hình dạng bình thường. Phương thức [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) của nó trả về `nullptr`, nhưng hình dạng vẫn tồn tại trong bộ sưu tập của slide. Ngược lại, [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) xóa hình dạng khỏi bộ sưu tập đó.

Ví dụ sau yêu cầu tệp `template.pptx` có ít nhất một slide và một placeholder văn bản không rỗng trên slide đầu tiên. Sử dụng một placeholder với định dạng được kế thừa từ bố cục hoặc master để xem ảnh hưởng của việc xóa quan hệ đó. Ví dụ kiểm tra rằng cùng một hình dạng vẫn tồn tại, gọi lại phương thức trên hình dạng hiện đã trở thành bình thường, và lưu kết quả.

{{% alert color="warning" title="Warning" %}}
Xóa trạng thái placeholder không tự động giữ lại các thiết lập hiển thị kế thừa. Ví dụ dưới đây cố ý để nguyên các thiết lập đó, vì vậy đầu ra có thể trông khác. Một hình dạng mà vị trí và kích thước hoàn toàn được kế thừa có thể có tọa độ và kích thước bằng không sau lời gọi và trở nên vô hình mặc dù vẫn còn trong bộ sưu tập.{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Gọi phương thức trên một hình dạng thông thường không có tác dụng.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Đối với một placeholder phù hợp, cả ba kiểm tra đều in ra `True`. Văn bản vẫn còn, nhưng vị trí, kích thước, quay, phông chữ, căn đoạn, lề khung văn bản, neo dọc, màu nền và thiết lập đường viền kế thừa có thể thay đổi khi quan hệ placeholder bị xóa. Ví dụ, định dạng tiêu đề kế thừa có thể quay trở lại định dạng văn bản bình thường. Xem [Bố cục Slide](/slides/vi/cpp/slide-layout/) để biết thêm về bố cục.

Để giữ lại định dạng mong muốn, hãy lấy vị trí, kích thước và góc quay đã được giải quyết trước khi gọi, và sao chép các giá trị định dạng thực tế cần thiết vào các biến riêng. Lấy các giá trị này thông qua [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), và [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). Không dựa chỉ vào các đối tượng định dạng thực tế, vì các giá trị định dạng văn bản của chúng có thể thay đổi sau khi quan hệ bị xóa. Áp dụng rõ ràng các giá trị đã lấy cho hình dạng bình thường sau đó, bao gồm họ phông chữ, kích thước, kiểu, màu, cài đặt đoạn, cài đặt khung văn bản, màu nền và đường viền được mẫu của bạn sử dụng.

Định dạng hình học kế thừa cũng có thể cần được gán một cách rõ ràng thông qua [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). Đối với placeholder văn bản hình chữ nhật, điều này có nghĩa là gán [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); chỉ khôi phục màu nền và đường viền có thể không khôi phục lại hình chữ nhật hiển thị. Các mẫu có hiệu ứng bổ sung hoặc định dạng phức tạp hơn cũng yêu cầu xử lý những thiết lập này.

## **Thay Đổi Văn Bản trong Placeholder**

Placeholder tiêu đề, tiêu đề trung tâm, phụ đề, phần thân và văn bản thường hỗ trợ văn bản. Kiểm tra [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) trước khi sử dụng phương thức [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) của nó.

Ví dụ này cập nhật placeholder tiêu đề đầu tiên trên slide đầu tiên và lưu kết quả:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Mẫu này tránh việc ép kiểu các placeholder hình ảnh, biểu đồ, bảng hoặc đa phương tiện sang [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Nó cũng xác định placeholder dựa trên mục đích thay vì dựa vào chỉ số hình dạng dễ phá vỡ.

## **Đặt Văn Bản Gợi Ý trên Bố Cục**

Văn bản gợi ý là chỉ dẫn thời gian thiết kế hiển thị trong một placeholder rỗng, chẳng hạn *Click to add title*. Đặt văn bản gợi ý tùy chỉnh trên placeholder bố cục thay vì cố gắng truy xuất nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập bố cục thông qua [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) và lặp qua [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

Ví dụ sau thay đổi các gợi ý tiêu đề và phụ đề trên bố cục được sử dụng bởi slide đầu tiên:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Văn bản gợi ý không phải là nội dung slide bình thường. Nó được dành cho các placeholder rỗng trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, gợi ý sẽ không còn hiển thị. Thay đổi gợi ý cũng không thay thế văn bản hiện có trên các slide sử dụng bố cục đó.

## **Cập Nhật Placeholder Hình Ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), thay thế ảnh thông qua [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) và [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Nếu nó vẫn là một placeholder rỗng, thêm một khung hình ảnh tại tọa độ của placeholder bằng [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) và xóa placeholder rỗng.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình chiếu:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Đối tượng thay thế được tạo cho một placeholder rỗng là một khung hình ảnh cục bộ, không phải một placeholder mới, vì [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) chỉ đọc. Nó giữ vị trí dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ lại quan hệ placeholder là cần thiết, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt ảnh, cắt xén và các hiệu ứng đặc thù của hình ảnh, xem [Quản Lý Khung Ảnh](/slides/vi/cpp/picture-frame/). Những thao tác này thuộc về khung ảnh hoặc nền ảnh, không phải siêu dữ liệu của placeholder.

## **Làm việc với Placeholder Biểu Đồ và Nội Dung**

Placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). Ví dụ này tìm một biểu đồ như vậy bằng cả loại placeholder và giao diện thời gian chạy, thay đổi tiêu đề của nó và lưu tệp:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Một placeholder nội dung chung thường có [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). Trong PowerPoint, nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra giao diện hình dạng thực tế để biết nó chứa gì. Các bố cục chuyên biệt cũng có thể hiển thị [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), hoặc [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) rỗng thành một [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) chỉ bằng cách thay đổi [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); kiểu này chỉ đọc. Để điền một biểu đồ hoặc khu vực nội dung rỗng một cách lập trình, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó xóa placeholder rỗng. Ví dụ sau thực hiện điều này cho một biểu đồ:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Biểu đồ được thêm là một biểu đồ cục bộ bình thường. Nó chiếm vùng của placeholder nhưng không kế thừa từ placeholder bố cục. Sử dụng các [bài viết quản lý biểu đồ](/slides/vi/cpp/powerpoint-charts/) khi bạn cần thay thế các danh mục, chuỗi hoặc dữ liệu workbook của nó.

## **Ví Dụ Hoàn Chỉnh: Cập Nhật Văn Bản hoặc Nội Dung Hình Ảnh**

Ví dụ end-to-end dưới đây mở một mẫu, tìm kiếm slide đầu tiên để tìm placeholder tiêu đề hoặc hình ảnh, kiểm tra các loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ cố ý tránh giả định chỉ số hình dạng hoặc ép kiểu mọi placeholder sang cùng một giao diện.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên bố cục hoặc master mà một placeholder khác kế thừa. Sử dụng [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) để lấy nó. Một hình dạng cục bộ bình thường trả về `nullptr` vì nó không thuộc phần của phân cấp placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa một placeholder bố cục không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý qua một bố cục, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, hãy lặp qua các slide và cập nhật từng placeholder tiêu đề.

**Làm thế nào để quản lý các placeholder ngày, số slide, tiêu đề và chân trang?**

Sử dụng các trình quản lý tiêu đề và chân trang ở phạm vi slide, bố cục, master, ghi chú hoặc tài liệu phát tay thích hợp. Xem [Quản Lý Tiêu Đề và Chân Trang Bản Trình Chiếu](/slides/vi/cpp/presentation-header-and-footer/) để biết các ví dụ đầy đủ.