---
title: Thay đổi kích thước và hướng trang ghi chú trong C++
linktitle: Kích thước trang ghi chú
type: docs
weight: 10
url: /vi/cpp/notes-size/
keywords:
- kích thước trang ghi chú
- hướng ghi chú
- ghi chú ngang
- ghi chú dọc
- kích thước tài liệu phát tay
- PowerPoint
- bản trình chiếu
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Đọc và thay đổi kích thước trang ghi chú trong Aspose.Slides cho C++, chuyển hướng, xác minh kích thước đã lưu, và xuất ghi chú hoặc tài liệu phát tay sang PDF và hình ảnh."
---
## **Tổng quan**

Sử dụng [Presentation::get_NotesSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_notessize/) để truy cập cài đặt trang ghi chú của bản trình chiếu. Nó trả về một đối tượng [INotesSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotessize/) mà phương thức [set_Size](https://reference.aspose.com/slides/vi/cpp/aspose.slides/inotessize/set_size/) đặt các kích thước. Mặc dù đối tượng cài đặt ghi chú không thể thay thế, bạn vẫn có thể thay đổi kích thước của nó.

Chiều rộng và chiều cao được xác định bằng **points**, với 72 points mỗi inch. Ví dụ, 900 × 600 points tương đương 12.5 × 8⅓ inch. Các cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho ghi chú của từng slide riêng lẻ.

| Cài đặt | Mục đích |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_notessize/) | Điều khiển kích thước trang ghi chú và kích thước trang được sử dụng cho việc xuất bản handout. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slidesize/) | Điều khiển kích thước slide thông thường của bản trình chiếu thông qua [ISlideSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidesize/). |

Thay đổi một trong hai cài đặt không tự động thay đổi cài đặt còn lại. Thay đổi hướng của trang ghi chú cũng không xoay các slide thông thường. Xem [Slide Size](/slides/vi/cpp/slide-size/) để thay đổi kích thước slide thông thường.

Các ví dụ bên dưới sử dụng tệp `sample.pptx` hiện có. Đối với các ví dụ xuất, hãy dùng một bản trình chiếu có ít nhất một slide chứa ghi chú người thuyết trình. Mỗi ví dụ có thể chạy độc lập.

## **Đọc Kích Thước và Hướng của Trang Ghi Chú**

Đọc chiều rộng và chiều cao và so sánh chúng để xác định hướng: trang rộng hơn là ngang, trang cao hơn là dọc, và các kích thước bằng nhau mô tả một trang vuông. Ví dụ này in ra kích thước thực tế bằng points, mà không giả định kích thước giấy chuẩn.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Chuyển sang Ngang mà Không Thay Đổi Kích Thước Giấy**

Để chỉ thay đổi hướng, hoán đổi chiều rộng và chiều cao hiện có. Điều này bảo toàn độ dài của cả hai cạnh, bao gồm cả những kích thước giấy tùy chỉnh. Điều kiện dưới đây ngăn một trang đã ở chế độ ngang bị chuyển lại thành dọc và giữ nguyên một trang vuông.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Đối với hướng dọc, sử dụng cùng một phép gán khi `size.get_Width() > size.get_Height()`. Không thay thế kích thước A4 hoặc Letter trừ khi bạn cũng muốn thay đổi kích thước giấy.

## **Đặt và Xác Nhận Kích Thước Trang Ghi Chú Tùy Chỉnh**

Gán cả hai kích thước đồng thời, sau đó sử dụng [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) để ghi bản trình chiếu. Ví dụ này đặt một trang ngang 900 × 600 point, lưu dưới dạng PPTX, và mở lại tệp đã lưu để kiểm tra các giá trị đã được lưu. So sánh cho phép sai số 0.01 point đối với các giá trị số thực; đây không phải là cam kết độ chính xác cho mọi định dạng tệp.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Kết quả mong đợi là `900 x 600 points` và `Size preserved: True`. Kiểm tra một bản trình chiếu mới mở xác nhận tệp đã lưu, thay vì chỉ các cài đặt trong bộ nhớ.

## **Xuất Ghi Chú và Handout**

Kích thước trang xác định khu vực khả dụng cho ghi chú hoặc bố cục handout. Chúng không tự động kích hoạt các bố cục đó: cần cấu hình các tùy chọn xuất. Xuất slide thông thường vẫn sử dụng kích thước slide.

### **Xuất Ghi chú ra PDF và PNG**

Gán [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/) vào [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) để bao gồm ghi chú trong PDF. Ví dụ này cũng render slide đầu tiên có ghi chú sang PNG bằng [Slide::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/getimage/) và [RenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/renderingoptions/).

Chế độ [BottomTruncated](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notespositions/) giữ ghi chú trên một trang; các ghi chú không vừa có thể bị cắt ngắn. PDF sử dụng các trang 900 × 600 point. Với tỷ lệ hình ảnh 1 × 1 được sử dụng bên dưới, PNG có kích thước 900 × 600 pixel. Points mô tả hình học trang; pixels mô tả đầu ra raster, kích thước của chúng cũng phụ thuộc vào tỷ lệ render.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Đối với xuất PDF với ghi chú dài, [BottomFull](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notespositions/) cho phép tạo thêm các trang khi cần. Không sử dụng chế độ này với lệnh tạo hình ảnh một slide ở trên, vì nó không hỗ trợ. Sau khi thay đổi kích thước, kiểm tra đầu ra để xem có ghi chú bị cắt hay không và vị trí của các đối tượng notes-master hiện có; việc chỉ thay đổi kích thước trang không nên được coi là bảo đảm mọi nội dung sẽ vừa. Xem [Convert PowerPoint to PDF with Notes](/slides/vi/cpp/convert-powerpoint-to-pdf-with-notes/) để biết thêm về xuất ghi chú.

### **Xuất Handout ra PDF**

Sử dụng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handoutlayoutingoptions/) cho nhiều hình thu nhỏ slide trên một trang. Ví dụ dưới đây đặt một trang 900 × 600 point và sử dụng [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handouttype/) để sắp xếp tới bốn slide trên mỗi trang. Cài đặt ngang kiểm soát thứ tự slide; hướng trang được lấy từ chiều rộng và chiều cao của nó.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Thay đổi kích thước trang sẽ thay đổi khu vực khả dụng cho lưới handout mà không thay đổi kích thước của các slide gốc. Đối với hình ảnh handout, sử dụng [Presentation::GetImages](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/getimages/) với bố cục handout, thay vì phương thức image của slide riêng lẻ. Trong Aspose.Slides, việc render handout ở mức bản trình chiếu sử dụng kích thước trang ghi chú, trong khi lời gọi image của slide riêng lẻ không tạo ra trang handout. Xem [Handout Mode](/slides/vi/cpp/convert-powerpoint-in-handout-mode/) để biết các tùy chọn bố cục.

## **Kích Thước Trang trong Trình Xem, Xuất và In**

Giữ riêng biệt kích thước bản trình chiếu đã lưu, kích thước trang xuất và kích thước giấy in:

- **Trình xem bản trình chiếu:** Một trình xem có thể hiển thị hoặc in ghi chú bằng các quy tắc bố cục riêng của nó. Nếu một ứng dụng khác lưu tệp, hãy mở lại và kiểm tra kích thước lần nữa; việc chuyển đổi định dạng của ứng dụng đó có thể chuẩn hoá chúng.
- **Định dạng xuất:** Ví dụ PDF và handout ở trên sử dụng kích thước trang đã cấu hình. Hình ảnh raster sử dụng kích thước pixel nguyên và tỷ lệ render, do đó các giá trị point thập phân có thể được làm tròn trong đầu ra hình ảnh. Xuất slide thông thường không áp dụng kích thước trang ghi chú.
- **Trình điều khiển máy in:** Trình điều khiển máy in, lựa chọn giấy, tự động xoay và cài đặt vừa trang có thể thay đổi kết quả vật lý mà không thay đổi kích thước lưu trong bản trình chiếu hoặc PDF. Đối với một kích thước giấy cụ thể, hãy khớp cài đặt máy in và kiểm tra bản xem trước khi in.

## **Câu hỏi thường gặp**

**Có thể đặt kích thước ghi chú cho chỉ một slide không?**

Kích thước trang ghi chú là cài đặt ở mức bản trình chiếu. Các slide riêng lẻ có thể có nội dung ghi chú khác nhau, nhưng thuộc tính này không cung cấp kích thước trang riêng cho từng slide.

**Tại sao việc thay đổi hướng ghi chú không thay đổi các slide của tôi?**

Các trang ghi chú và các slide thông thường có kích thước độc lập. Sử dụng cài đặt kích thước slide thông thường khi bạn muốn thay đổi kích thước của các slide.

**Tại sao kết quả đã lưu hoặc đã in của tôi có kích thước khác?**

Đầu tiên mở lại bản trình chiếu đã lưu và so sánh kích thước ghi chú của nó. Nếu chúng đã thay đổi, kiểm tra xem việc lưu hoặc chuyển đổi tệp trong một ứng dụng khác có thay đổi cài đặt trang không. Nếu không, hãy kiểm tra bố cục xuất, tỷ lệ hình ảnh, cài đặt trình xem và lựa chọn giấy của máy in.