---
title: Quản lý Trình Giữ Chỗ trong Bản Trình Chiếu bằng C++
linktitle: Quản lý Trình Giữ Chỗ
type: docs
weight: 10
url: /vi/cpp/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- trình giữ chỗ nội dung
- văn bản gợi ý
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các trình giữ chỗ văn bản, hình ảnh, biểu đồ và nội dung và hiểu cách kế thừa trình giữ chỗ với Aspose.Slides cho C++."
---
## **Tổng quan**

Placeholder là một hình dạng giữ chỗ cho một loại nội dung cụ thể trong mẫu bản trình chiếu. Các ví dụ phổ biến gồm tiêu đề, nội dung, hình ảnh, biểu đồ và các placeholder nội dung đa dụng. Khác với một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các cài đặt khác từ một slide bố cục hoặc slide chủ.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [IShape::get_Placeholder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_placeholder/) . Phương thức trả về một đối tượng [IPlaceholder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iplaceholder/) hoặc `nullptr` cho một hình dạng bình thường. Sử dụng [IPlaceholder::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iplaceholder/get_type/) để xác định placeholder dự định chứa gì.

Giao diện hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu diễn bằng [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) .
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) .
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng [IChart](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/) .
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [IPlaceholder::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iplaceholder/get_type/) và giao diện hình dạng thời gian chạy thay vì giả định rằng mọi placeholder đều là [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) .

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iplaceholder/get_type/) mô tả vai trò của một placeholder; nó không đảm bảo loại hình dạng thời gian chạy. Luôn kiểm tra loại trước khi truy cập các thành viên văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu Kế thừa Placeholder**

Placeholders hình thành một cây phân cấp:

1. Một slide chủ định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder cấp chủ.
2. Một slide bố cục định nghĩa cách sắp xếp được sử dụng bởi một hoặc nhiều slide bình thường và có thể kế thừa từ slide chủ.
3. Một slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ bố cục của nó.

Gọi [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/getbaseplaceholder/) để di chuyển lên một mức trong cây phân cấp này. Một placeholder slide thường trả về placeholder bố cục của nó; một placeholder bố cục có thể trả về placeholder chủ. Phương thức trả về `nullptr` khi hình dạng không có placeholder cơ sở.

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

Chỉnh sửa một placeholder trên slide bình thường tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa bố cục hoặc slide chủ liên quan có thể ảnh hưởng tới tất cả các slide vẫn kế thừa cài đặt đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Thay Đổi Văn Bản trong Placeholder**

Placeholder tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và văn bản thường hỗ trợ văn bản. Kiểm tra xem có phải là [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) trước khi sử dụng phương thức [get_TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/get_textframe/) của nó.

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

Mẫu này tránh việc ép kiểu các placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện sang [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) . Nó cũng xác định placeholder dựa trên mục đích thay vì dựa vào một chỉ mục hình dạng dễ gãy.

## **Đặt Văn Bản Gợi Ý trên Bố Cục**

Văn bản gợi ý là hướng dẫn thời gian thiết kế hiển thị trong một placeholder trống, chẳng hạn *Nhấp để thêm tiêu đề*. Đặt văn bản gợi ý tùy chỉnh trên placeholder bố cục thay vì cố gắng tiếp cận nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập bố cục qua [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/get_layoutslide/) và duyệt qua [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_shapes/) .

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

Văn bản gợi ý không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, gợi ý sẽ không còn hiển thị. Thay đổi một gợi ý cũng không thay thế văn bản hiện có trên các slide sử dụng bố cục đó.

## **Cập Nhật Placeholder Hình Ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) , thay thế hình ảnh qua [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/get_picture/) và [ISlidesPicture::set_Image](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/set_image/) .
- Nếu nó vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addpictureframe/) và xoá placeholder trống.

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

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [IShape::get_Placeholder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_placeholder/) chỉ đọc. Nó giữ vị trí đã đặt nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ mối quan hệ placeholder là quan trọng, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt ảnh, cắt ảnh và các hiệu ứng đặc thù khác, xem [Manage Picture Frames](/slides/vi/cpp/picture-frame/). Những thao tác đó thuộc về picture frame hoặc picture fill, không phải siêu dữ liệu placeholder.

## **Làm việc với Placeholder Biểu Đồ và Nội Dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng [IChart](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/) . Ví dụ này tìm biểu đồ như vậy bằng cả loại placeholder và giao diện thời gian chạy, thay đổi tiêu đề và lưu tệp:

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

Một placeholder nội dung chung thường có [PlaceholderType::Object](https://reference.aspose.com/slides/vi/cpp/aspose.slides/placeholdertype/) . Trong PowerPoint nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra giao diện hình dạng thực tế để biết nó chứa gì. Các bố cục chuyên biệt cũng có thể mở ra [PlaceholderType::Chart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/vi/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/vi/cpp/aspose.slides/placeholdertype/), hoặc [PlaceholderType::Diagram](https://reference.aspose.com/slides/vi/cpp/aspose.slides/placeholdertype/) .

Aspose.Slides không chuyển một placeholder [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) trống thành [IChart](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/) chỉ bằng cách thay đổi [IPlaceholder::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iplaceholder/get_type/) ; loại này chỉ đọc. Để điền một biểu đồ hoặc khu vực nội dung trống một cách lập trình, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó xoá placeholder trống. Ví dụ sau thực hiện điều này cho một biểu đồ:

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

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm diện tích của placeholder nhưng không kế thừa từ placeholder bố cục. Sử dụng các bài viết quản lý biểu đồ chuyên biệt [/slides/vi/cpp/powerpoint-charts/] khi bạn cần thay thế danh mục, chuỗi hoặc dữ liệu workbook của nó.

## **Ví dụ Hoàn Chỉnh: Cập Nhật Văn Bản hoặc Nội Dung Hình Ảnh**

Ví dụ toàn diện dưới đây mở một mẫu, tìm kiếm slide đầu tiên để xác định placeholder tiêu đề hoặc hình ảnh, kiểm tra loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ cố ý tránh giả định chỉ mục hình dạng hoặc ép kiểu mọi placeholder sang cùng một giao diện.

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

Placeholder cơ sở là hình dạng tương ứng trên bố cục hoặc slide chủ mà một placeholder khác kế thừa. Sử dụng [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/getbaseplaceholder/) để lấy nó. Một hình dạng cục bộ thông thường trả về `nullptr` vì nó không thuộc cây phân cấp placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa placeholder bố cục không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý thông qua một bố cục, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, duyệt qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày, số slide, tiêu đề và chân trang?**

Sử dụng các trình quản lý tiêu đề và chân trang ở cấp slide, bố cục, chủ, ghi chú hoặc tài liệu phát tay thích hợp. Xem [Manage Presentation Header and Footer](/slides/vi/cpp/presentation-header-and-footer/) để có các ví dụ đầy đủ.