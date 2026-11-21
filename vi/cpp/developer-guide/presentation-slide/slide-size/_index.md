---
title: Thay đổi kích thước slide của bản trình bày trong C++
linktitle: Kích thước Slide
type: docs
weight: 70
url: /vi/cpp/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- chuẩn
- màn hình rộng
- 4:3
- 16:9
- đặt kích thước slide
- thay đổi kích thước slide
- kích thước slide tùy chỉnh
- kích thước slide đặc biệt
- kích thước slide duy nhất
- slide kích thước đầy đủ
- loại màn hình
- không co giãn
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng C++ và Aspose.Slides, tối ưu hóa bản trình bày cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình bày PowerPoint, quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide phổ biến và tỷ lệ:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho các máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong suốt bản trình bày vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tốt nhất, hãy đặt kích thước slide của bạn ngay từ đầu quá trình tạo bản trình bày để tránh các phức tạp.

{{% alert color="info" %}} 
Mặc định, các bản trình bày được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

Các trang Ghi chú và tài liệu phát tay có kích thước riêng so với các slide thông thường. Xem [Kích thước trang Ghi chú](/slides/vi/cpp/notes-size/) để thay đổi kích thước và hướng của chúng.

## **Thay đổi kích thước slide trong bản trình bày**

Đoạn mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình bày bằng C++ sử dụng Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Chỉ định kích thước slide tùy chỉnh trong bản trình bày**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước nguyên bản từ bản trình bày trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình bày trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bản trình bày.

Đoạn mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho C++ để chỉ định một kích thước slide tùy chỉnh cho một bản trình bày bằng C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Kích thước giấy A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình bày, nội dung của các slide (ví dụ hình ảnh hoặc đối tượng) có thể bị biến dạng. Mặc định, các đối tượng sẽ được tự động thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình bày, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục đích hoặc kết quả bạn muốn đạt được, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide được thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa trên slide (điều này giúp bạn tránh mất nội dung), hãy sử dụng cài đặt này.

- `Maximize`

  Nếu bạn muốn mở rộng kích thước slide và cần Aspose.Slides phóng to các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Đoạn mã mẫu này cho bạn thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bản trình bày:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Câu hỏi thường gặp**

### Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác nhau ngoài inch (ví dụ, points hoặc millimeters) không?

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như millimeters hoặc centimeters) sang point và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao của slide.

### Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ trong quá trình render không?

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỷ lệ render cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy nhắm tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

### Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bản trình bày có kích thước khác nhau không?

Bạn không thể [hợp nhất bản trình bày](/slides/vi/cpp/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình bày để khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/). Sau khi căn chỉnh kích thước, bạn có thể hợp nhất các slide trong khi vẫn giữ định dạng.

### Tôi có thể tạo hình thu nhỏ cho các hình dạng riêng lẻ hoặc khu vực cụ thể của một slide không, và chúng có tuân theo kích thước slide mới không?

Có. Aspose.Slides có thể tạo hình thu nhỏ cho [toàn bộ slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/getimage/) cũng như cho [các hình dạng đã chọn](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.