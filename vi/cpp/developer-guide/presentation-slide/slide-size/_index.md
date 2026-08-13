---
title: Thay đổi kích thước slide của bản trình chiếu bằng C++
linktitle: Kích thước slide
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
- slide toàn kích thước
- loại màn hình
- không thu phóng
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng C++ và Aspose.Slides, tối ưu hóa bản trình chiếu cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình chiếu PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (Tỷ lệ 4:3)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (Tỷ lệ 16:9)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trên toàn bộ bản trình chiếu vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bản trình chiếu để tránh các vấn đề phức tạp.

{{% alert color="info" %}} 
Theo mặc định, các bản trình chiếu được tạo bằng Aspose.Slides sử dụng tỷ lệ 4:3 chuẩn.
{{% /alert %}}

## **Thay đổi kích thước slide trong bản trình chiếu**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình chiếu bằng C++ sử dụng Aspose.Slides:

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

## **Xác định kích thước slide tùy chỉnh trong bản trình chiếu**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide nguyên kích thước từ bản trình chiếu trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình chiếu trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng thiết lập kích thước tùy chỉnh cho bản trình chiếu.

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho C++ để xác định kích thước slide tùy chỉnh cho một bản trình chiếu bằng C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// kích thước giấy A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình chiếu, nội dung các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị méo. Theo mặc định, các đối tượng sẽ được tự động thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình chiếu, bạn có thể chỉ định một thiết lập xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ thiết lập nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng thiết lập này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ xuống kích thước slide nhỏ hơn và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa trên slide (điều này giúp tránh mất nội dung), hãy sử dụng thiết lập này. 

- `Maximize`

  Nếu bạn muốn phóng to lên kích thước slide lớn hơn và cần Aspose.Slides tăng kích thước các đối tượng trên slide sao cho tỷ lệ chúng phù hợp với kích thước slide mới, hãy sử dụng thiết lập này. 

Mã mẫu này cho bạn thấy cách sử dụng thiết lập `Maximize` khi thay đổi kích thước slide của một bản trình chiếu:

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

### Tôi có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ: điểm hoặc milimet) không?

Có. Aspose.Slides sử dụng điểm làm đơn vị nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao slide.

### Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ khi render không?

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỷ lệ render cao hơn sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy chọn kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt được chất lượng đầu ra mong muốn.

### Tôi có thể định nghĩa một kích thước slide không chuẩn rồi sau đó hợp nhất các slide từ các bản trình chiếu có kích thước khác nhau không?

Bạn không thể [merge presentations](/slides/vi/cpp/merge-presentation/) khi chúng có kích thước slide khác nhau — trước hết, hãy thay đổi kích thước một bản trình chiếu để khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách nội dung hiện có được xử lý qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/). Sau khi cân chỉnh kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

### Tôi có thể tạo hình thu nhỏ cho các hình dạng riêng lẻ hoặc các vùng cụ thể của slide không, và chúng có tuân theo kích thước slide mới không?

Có. Aspose.Slides có thể render hình thu nhỏ cho [entire slides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/getimage/) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/). Các hình ảnh tạo ra sẽ phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.