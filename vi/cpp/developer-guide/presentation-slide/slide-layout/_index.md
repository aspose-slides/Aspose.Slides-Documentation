---
title: "Áp dụng hoặc Thay đổi Bố cục Slide trong C++"
linktitle: "Bố cục Slide"
type: docs
weight: 60
url: /vi/cpp/slide-layout/
keywords:
- "bố cục slide"
- "bố cục nội dung"
- "trình giữ chỗ"
- "thiết kế bài thuyết trình"
- "thiết kế slide"
- "bố cục không sử dụng"
- "hiển thị chân trang"
- "slide tiêu đề"
- "tiêu đề và nội dung"
- "đầu mục phần"
- "hai nội dung"
- "so sánh"
- "chỉ tiêu đề"
- "bố cục trống"
- "nội dung có chú thích"
- "hình ảnh có chú thích"
- "tiêu đề và văn bản dọc"
- "tiêu đề dọc và văn bản"
- "PowerPoint"
- "OpenDocument"
- "bài thuyết trình"
- "C++"
- "Aspose.Slides"
description: "Áp dụng, tạo và sửa đổi bố cục slide trong Aspose.Slides cho C++, thêm trình giữ chỗ, loại bỏ các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Một bố cục slide xác định vị trí và định dạng của các placeholder như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán trong khi vẫn cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các placeholder tiêu đề và phụ đề.
- **Title and Content**: Chứa một placeholder tiêu đề và một placeholder nội dung chung.
- **Blank**: Không chứa placeholder nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình chiếu có ba cấp độ liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/) xác định giao diện, định dạng chung, nền và các đối tượng chung.
1. Một [layout slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/) thuộc về một master và xác định một sắp xếp cụ thể của các placeholder.
1. Một [normal slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) sử dụng một layout và lưu trữ nội dung được nhập cho slide đó.

Một normal slide kế thừa giao diện và định dạng từ layout của nó, và layout kế thừa từ master. Giá trị được đặt trực tiếp trên một normal slide sẽ ghi đè giá trị kế thừa ở cấp độ đó. Khi tạo một normal slide, các shape placeholder của nó được tạo ra từ layout đã chọn, trong khi nội dung nhập vào các placeholder đó thuộc về normal slide.

Thêm các placeholder cần thiết vào một layout trước khi tạo slide từ nó. Thêm một placeholder khác vào layout sau này sẽ không tự động thêm shape placeholder tương ứng vào các normal slide đã tồn tại.

Mối quan hệ này có hai hệ quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của các placeholder hiện có trên một layout có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một layout đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem lại bản trình chiếu kết quả.
- Một layout vẫn đang được một slide sử dụng không thể bị xóa. Hãy gán lại các slide phụ thuộc của nó sang layout khác trước, hoặc chỉ xóa các layout không sử dụng.

Để biết thêm thông tin về cấp cao nhất của cấu trúc này, xem [Slide Master](/slides/vi/cpp/slide-master/).

Để ẩn logo kế thừa hoặc các shape trang trí master trên một slide hoặc thông qua một layout chia sẻ, xem [Control the Visibility of Master Graphics](/slides/vi/cpp/slide-master/). Ví dụ so sánh hai slide sử dụng cùng một master.

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng loại layout khi bản trình chiếu tuân theo các định nghĩa layout chuẩn của PowerPoint. Tên layout có thể chỉnh sửa bởi người dùng và có thể được địa phương hoá, vì vậy việc chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu layout đó không có, nó sẽ dự phòng một cách cố ý sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình chiếu có thể chỉ chứa các layout tùy chỉnh. Layout đã chọn sau đó được áp dụng cho slide bình thường đầu tiên qua phương thức [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Thay đổi layout của một slide không loại bỏ các shape thông thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí placeholder, định dạng kế thừa và sự tương ứng giữa các placeholder hiện có và layout mới có thể thay đổi, vì vậy hãy kiểm tra đầu ra khi chuyển đổi giữa các layout khác nhau đáng kể.

## **Thêm một Bố cục Slide**

Lựa chọn và tạo là hai thao tác riêng biệt. Ví dụ trước chọn một layout hiện có; nó không tạo một layout mới. Để tạo một layout, gọi phương thức [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterlayoutslidecollection/add/) trên bộ sưu tập layout của master mục tiêu.

Ví dụ sau luôn thêm một layout **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một normal slide dựa trên nó. Tên layout phải là duy nhất trong bộ sưu tập.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Chỉ thêm layout khi mẫu thực sự cần một cấu trúc có thể tái sử dụng khác. Nếu đã có một layout phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Placeholder vào Bố cục Slide**

Phương thức [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) cung cấp một [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/) để thêm các shape placeholder vào một layout.

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Content](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Ví dụ sau xác minh layout **Blank** tồn tại, thêm bốn placeholder vào nó, và sau đó tạo một normal slide sử dụng layout đã sửa đổi. Thứ tự này có ý đồ: các placeholder được thêm trước khi tạo normal slide, để Aspose.Slides có thể tạo các shape placeholder tương ứng trên slide đó.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các placeholder trên bố cục slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các placeholder layout hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một placeholder layout mới được thêm sẽ không tự động điền vào các normal slide đã tồn tại. Kiểm tra các thay đổi layout trên một bản sao của bản trình chiếu và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Bố cục Slide không sử dụng**

Sử dụng phương thức [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để xóa các layout mà không có normal slide nào tham chiếu. Phương thức này để nguyên các layout vẫn đang được sử dụng.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để xóa một layout cụ thể, trước tiên sử dụng phương thức [get_HasDependingSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) hoặc [GetDependingSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/getdependingslides/). Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [ILayoutSlide::Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/remove/). Cố gắng xóa một layout đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Chân trang trên Bố cục Slide**

Một layout có riêng footer, slide-number và placeholder ngày‑giờ. Sử dụng phương thức [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) để kiểm soát các placeholder này cho một layout. Điều này hữu ích khi, ví dụ, layout nội dung nên hiển thị footer nhưng layout tiêu đề thì không.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kiểm soát Hiển thị Chân trang trên Master và Các Bố cục Con**

Để áp dụng cài đặt footer nhất quán trên toàn bộ hierarchy của master, sử dụng phương thức [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Các phương thức lan truyền của [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslideheaderfootermanager/) hoạt động trên master và các layout slide và normal slide phụ thuộc; chúng không chỉ nhắm vào một normal slide duy nhất.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Sự khác biệt giữa Master Slide và Layout Slide là gì?**

Master Slide xác định giao diện và định dạng chung của bản trình chiếu. Layout Slide thuộc về một master và xác định một sắp xếp có thể tái sử dụng của các placeholder. Normal slides sử dụng các layout này và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép một Layout Slide từ một bản trình chiếu sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Khi sao chép giữa các bản trình chiếu, cũng cần xác minh phông chữ, giao diện, hình ảnh và các tài nguyên khác được layout nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi layout trừ khi chúng ghi đè định dạng hoặc đối tượng liên quan ở mức cục bộ. Hình học của placeholder và kiểu kế thừa có thể thay đổi đồng thời trên nhiều slide. Sử dụng [GetDependingSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/getdependingslides/) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa layout.

**Điều gì sẽ xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném lỗi [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxeditexception/). Hãy gán lại các slide phụ thuộc trước, hoặc sử dụng [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để chỉ xóa các layout không được tham chiếu.