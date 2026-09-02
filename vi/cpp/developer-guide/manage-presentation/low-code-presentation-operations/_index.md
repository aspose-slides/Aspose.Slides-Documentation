---
title: Các hoạt động trình bày Low-Code trong C++
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/cpp/low-code-presentation-operations/
keywords:
- API trình bày low-code
- chuyển đổi bài thuyết trình
- hợp nhất các bài thuyết trình
- duyệt slide
- duyệt shape
- duyệt văn bản
- thu thập shape
- nén bài thuyết trình
- xóa master slide không dùng
- xóa layout slide không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Sử dụng API low-code Aspose.Slides trong C++ để chuyển đổi và hợp nhất các bài thuyết trình, duyệt nội dung, thu thập shape và giảm kích thước bài thuyết trình."
---
## **Tổng quan**

Namespace [Aspose::Slides::LowCode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/) cung cấp các lớp trợ giúp tĩnh cho các thao tác trình bày thông thường. Những trợ giúp này bao bọc các quy trình mô hình đối tượng thường dùng trong các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các thành phần trình bày, thu thập shape và loại bỏ nội dung không dùng tới với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bài thuyết trình và quy trình mặc định đáp ứng yêu cầu của bạn. Sử dụng [Aspose.Slides object model](https://reference.aspose.com/slides/vi/cpp/aspose.slides/) đầy đủ khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất, hoặc các mối quan hệ giữa các thành phần trình bày.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/) | Chuyển đổi một bài thuyết trình sang định dạng khác bằng cuộc gọi trực tiếp từ tệp này sang tệp khác. |
| [Merger](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/merger/) | Kết hợp các tệp bài thuyết trình hoàn chỉnh cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/) | Thực thi một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/collect/) | Lấy các shape từ toàn bộ bài thuyết trình để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) | Xóa các master và layout không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một bài thuyết trình**

Sử dụng [Convert::AutoByExtension](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/autobyextension/) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức này mở bài thuyết trình nguồn, xác định định dạng yêu cầu từ đường dẫn đầu ra và ghi kết quả.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/) cũng cung cấp các phương thức chuyên dụng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc chỉnh sửa bài thuyết trình trước khi xuất hoặc cấu hình tùy chọn xuất mà trợ giúp được chọn không cung cấp. Xem [Convert Presentation](/slides/vi/cpp/convert-presentation/) để biết quy trình và tùy chọn riêng cho từng định dạng.

## **Hợp nhất các bài thuyết trình**

Sử dụng [Merger::Process](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/merger/process/) để kết hợp các tệp bài thuyết trình hoàn chỉnh trong một lần gọi. Các bài thuyết trình đầu vào phải có cùng định dạng tệp.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối vào một kết quả mà không cần chọn hoặc ánh xạ lại từng slide. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, bảo tồn các phần một cách rõ ràng, hoặc điều chỉnh các kích thước slide khác nhau. Xem [Merge Presentations](/slides/vi/cpp/merge-presentation/) cho các kịch bản đó.

## **Duyệt qua các thành phần của bài thuyết trình**

Lớp [ForEach](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/) gọi một callback cho mỗi loại thành phần bài thuyết trình được yêu cầu. Nó tránh các vòng lặp bộ sưu tập lồng nhau và thuận tiện cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bài thuyết trình.

Ví dụ sau sử dụng [ForEach::Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/paragraph/), và [ForEach::Portion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/portion/) để kiểm tra các phần tử tương ứng:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Mặc định, việc duyệt shape và văn bản trên toàn bộ bài thuyết trình bao gồm các slide bình thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp bộ sưu tập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết cha-con là quan trọng.

## **Thu thập Shape**

Sử dụng [Collect::Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/collect/shapes/) khi bạn cần một tập hợp tất cả các shape trong một bài thuyết trình thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một tập sẽ được lọc, đếm hoặc xử lý nhiều lần.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Sử dụng [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/) thay thế khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung bài thuyết trình**

Lớp [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) có thể loại bỏ các yếu tố cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) xóa các slide layout mà không có slide bình thường nào tham chiếu.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) xóa các master slide không còn được sử dụng.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) loại bỏ các ký tự không dùng khỏi phông chữ nhúng.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Xóa các layout không dùng trước các master không dùng để một master trở nên không được tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bài thuyết trình đã tối ưu vào tệp mới nếu bạn có thể cần các master, layout hoặc dữ liệu phông chữ nhúng hoàn chỉnh gốc sau này. Để biết chi tiết hơn, xem [Slide Master](/slides/vi/cpp/slide-master/) và [Embedded Font](/slides/vi/cpp/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc bài thuyết trình và không yêu cầu kiểm soát chi tiết các yếu tố riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát mối quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các bài thuyết trình ở các định dạng tệp khác nhau không?**

Không. [Merger::Process](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/merger/process/) yêu cầu các bài thuyết trình đầu vào cùng định dạng. Đầu tiên hãy chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert::AutoByExtension](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/autobyextension/), rồi hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và notes không?**

[ForEach::Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/slide/) duyệt qua các slide trình bày thông thường. Các thao tác [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/paragraph/), và [ForEach::Portion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/portion/) trên toàn bài thuyết trình bao gồm các slide bình thường, master và layout theo mặc định. Sử dụng các overload với `includeNotes` đặt thành `true` để bao gồm các slide ghi chú.

**Sự khác nhau giữa ForEach::Shape và Collect::Shapes là gì?**

Sử dụng [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/) để xử lý mỗi shape ngay lập tức qua một callback. Sử dụng [Collect::Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/collect/shapes/) khi bạn cần một kết quả có thể lặp lại, có thể giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress luôn làm giảm kích thước tệp bài thuyết trình không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bài thuyết trình có chứa các layout không dùng, master không dùng, hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có các yếu tố đó, các thao tác [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) tương ứng có thể không giảm kích thước tệp.

**Các thay đổi được thực hiện bởi ForEach hoặc Compress có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các yếu tố trong callback của [ForEach](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/), gọi [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi bài thuyết trình](/slides/vi/cpp/convert-presentation/)
- [Hợp nhất bài thuyết trình](/slides/vi/cpp/merge-presentation/)
- [Slide Master](/slides/vi/cpp/slide-master/)
- [Quản lý Text Box](/slides/vi/cpp/manage-textbox/)
- [Embedded Font](/slides/vi/cpp/embedded-font/)