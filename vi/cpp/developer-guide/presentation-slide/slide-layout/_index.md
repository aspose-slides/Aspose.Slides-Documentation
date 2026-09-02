---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong C++
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/cpp/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- trình giữ chỗ
- thiết kế bản trình bày
- thiết kế slide
- bố cục không sử dụng
- hiển thị chân trang
- slide tiêu đề
- tiêu đề và nội dung
- đầu mục phần
- hai nội dung
- so sánh
- chỉ tiêu đề
- bố cục trống
- nội dung có chú thích
- hình ảnh có chú thích
- tiêu đề và văn bản dọc
- tiêu đề dọc và văn bản
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho C++, thêm trình giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các trình giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của mình.

- **Slide Tiêu đề**: Chứa các trình giữ chỗ tiêu đề và phụ đề.
- **Tiêu đề và Nội dung**: Chứa một trình giữ chỗ tiêu đề và một trình giữ chỗ nội dung đa năng.
- **Trống**: Không chứa trình giữ chỗ nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về Kế thừa Bố cục**

Một bài thuyết trình có ba cấp độ liên quan:

1. A [slide chủ](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/) xác định chủ đề, định dạng chung, nền và các đối tượng chung.
1. A [slide bố cục](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/) thuộc về một slide chủ và xác định một sắp xếp cụ thể của các trình giữ chỗ.
1. A [slide thường](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) sử dụng một bố cục và lưu trữ nội dung đã nhập cho slide đó.

Một slide thường kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục kế thừa từ slide chủ. Giá trị được đặt trực tiếp trên một slide thường sẽ ghi đè giá trị kế thừa ở cấp độ đó. Khi một slide thường được tạo, các hình dạng trình giữ chỗ của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các trình giữ chỗ đó thuộc về slide thường.

Thêm các trình giữ chỗ cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một trình giữ chỗ khác vào bố cục sau này sẽ không tự động thêm hình dạng trình giữ chỗ tương ứng vào các slide thường đã tồn tại.

Mối quan hệ này có hai hệ quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của trình giữ chỗ hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem lại bài thuyết trình kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Hãy gán lại các slide phụ thuộc của nó sang một bố cục khác trước, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cấu trúc này, xem [Slide Master](/slides/vi/cpp/slide-master/).

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng kiểu bố cục khi bài thuyết trình tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể được chỉnh sửa bởi người dùng và có thể được bản địa hóa, vì vậy lựa chọn dựa trên tên ít tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Tiêu đề và Nội dung** trên master đầu tiên. Nếu bố cục đó không có, nó sẽ cố ý chuyển sang **Trống**. Kiểm tra null thứ hai là cần thiết vì một bài thuyết trình có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide thường đầu tiên thông qua phương thức [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/set_layoutslide/).

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

Thay đổi bố cục của một slide không xóa các hình dạng thông thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí trình giữ chỗ, định dạng kế thừa và sự tương ứng giữa các trình giữ chỗ hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các bố cục có sự khác biệt đáng kể.

## **Thêm Slide Bố cục**

Lựa chọn và tạo là hai hoạt động riêng biệt. Ví dụ trước chọn một bố cục hiện có; nó không tạo một bố cục mới. Để tạo một bố cục, gọi phương thức [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterlayoutslidecollection/add/) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ sau luôn thêm một bố cục **Tiêu đề và Nội dung** mới có tên `Report Title and Content`, sau đó thêm một slide thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

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

Thêm một bố cục chỉ khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã có một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao trùng lặp.

## **Thêm Trình giữ chỗ vào Slide Bố cục**

Phương thức [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) cung cấp một [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/) để thêm các hình dạng trình giữ chỗ vào một bố cục.

| Trình giữ chỗ PowerPoint          | Phương thức `ILayoutPlaceholderManager` |
| --------------------------------- | ---------------------------------------- |
| ![Nội dung](content.png)          | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Nội dung (Dọc)](contentV.png)   | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Văn bản](text.png)              | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Văn bản (Dọc)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Hình ảnh](picture.png)          | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Biểu đồ](chart.png)             | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Bảng](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)         | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Hình ảnh Trực tuyến](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Ví dụ sau xác minh rằng bố cục **Trống** tồn tại, thêm bốn trình giữ chỗ vào nó, và sau đó tạo một slide thường sử dụng bố cục đã được chỉnh sửa. Thứ tự này có ý định: các trình giữ chỗ được thêm trước khi slide thường được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng trình giữ chỗ tương ứng trên slide đó.

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

![Các trình giữ chỗ trên slide bố cục](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các trình giữ chỗ bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một trình giữ chỗ bố cục mới được thêm vào sẽ không tự động được bổ sung vào các slide thường đã tồn tại. Hãy thử các thay đổi bố cục trên một bản sao của bài thuyết trình và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Slide Bố cục Không dùng**

Sử dụng phương thức [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để xóa các bố cục mà không có slide thường nào tham chiếu. Phương thức sẽ để nguyên các bố cục vẫn đang được sử dụng.

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

Để xóa một bố cục cụ thể, trước tiên sử dụng phương thức [get_HasDependingSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) hoặc [GetDependingSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/getdependingslides/) của nó. Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [ILayoutSlide::Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/remove/). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Chân trang trên Slide Bố cục**

Một bố cục có các trình giữ chỗ chân trang, số slide và ngày‑giờ riêng. Sử dụng phương thức [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) để kiểm soát các trình giữ chỗ này cho một bố cục. Điều này hữu ích khi, ví dụ, các bố cục nội dung nên hiển thị chân trang nhưng các bố cục tiêu đề thì không.

Ví dụ sau chọn một bố cục một cách an toàn và làm cho các yếu tố chân trang của nó hiển thị:

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

## **Kiểm soát Hiển thị Chân trang trên Master và Các Slide Bố cục Con**

Để áp dụng cài đặt chân trang nhất quán trên toàn bộ cây master, sử dụng phương thức [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Các phương thức lan truyền của [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslideheaderfootermanager/) hoạt động trên master và các slide bố cục cũng như slide thường phụ thuộc; chúng không chỉ nhắm đến một slide thường duy nhất.

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

## **Câu hỏi thường gặp**

**Sự khác nhau giữa Slide Master và Slide Bố cục là gì?**

Slide Master định nghĩa chủ đề và định dạng chung của bài thuyết trình. Slide Bố cục thuộc về một Slide Master và xác định một sắp xếp có thể tái sử dụng của các trình giữ chỗ. Các slide thường sử dụng những bố cục này và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép Slide Bố cục từ một bài thuyết trình sang bài thuyết trình khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Khi sao chép giữa các bài thuyết trình, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác mà bố cục nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Slide Bố cục đã được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi của bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng ở cấp địa phương. Do đó, hình học của trình giữ chỗ và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [GetDependingSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/getdependingslides/) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì xảy ra nếu tôi xóa một Slide Bố cục vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxeditexception/). Hãy gán lại các slide phụ thuộc trước, hoặc dùng [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để chỉ xóa các bố cục không được tham chiếu.