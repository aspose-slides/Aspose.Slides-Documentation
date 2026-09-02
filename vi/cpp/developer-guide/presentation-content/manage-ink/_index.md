---
title: "Quản lý các đối tượng bút ký trong bài thuyết trình bằng C++"
linktitle: "Quản lý bút ký"
type: docs
weight: 95
url: /vi/cpp/manage-ink/
keywords:
- "bút ký"
- "đối tượng bút ký"
- "vết bút ký"
- "quản lý bút ký"
- "vẽ bút ký"
- "vẽ"
- "xuất bút ký"
- "kết xuất bút ký"
- "ẩn bút ký"
- IInkOptions
- PowerPoint
- "bài thuyết trình"
- C++
- Aspose.Slides
description: "Quản lý các đối tượng bút ký trong PowerPoint, chỉnh sửa vết và thuộc tính brush, và kiểm soát hiển thị bút ký khi xuất PDF, HTML, SVG, TIFF và hình ảnh với Aspose.Slides cho C++."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng bút ký cho phép bạn vẽ các nét tự do. Bút ký có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị kết nối và quy trình, và thu hút sự chú ý tới các mục cụ thể trên một slide.

Namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/) chứa các lớp và giao diện cần thiết để làm việc với các đối tượng bút ký. Ví dụ, giao diện [IInk](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/iink/) đại diện cho một đối tượng bút ký trên slide.

## **Sự khác biệt giữa Đối tượng Thông thường và Đối tượng Bút ký**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng shape. Trong dạng đơn giản nhất, một shape là một container xác định khu vực của chính đối tượng (khung của nó) cùng với các thuộc tính như kích thước container, hình dạng và nền. Để biết thêm thông tin, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/cpp/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng bút ký, nó bỏ qua mọi thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước của vùng container được xác định bằng các phương thức chuẩn [IShape::get_Width](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_width/) và [IShape::get_Height](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Vết bút ký (Ink Traces)**

Một vết bút ký là yếu tố cơ bản được dùng để ghi lại quỹ đạo của bút khi người dùng viết bút ký kỹ thuật số. Một vết lưu trữ một chuỗi các điểm nối nhau.

Dạng mã hoá đơn giản nhất chỉ định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm nối nhau được vẽ, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Brush để Vẽ**

Brush được dùng để vẽ các đường nối các điểm của một vết bút ký. Brush có màu và kích thước riêng, được biểu diễn bằng các phương thức [IInkBrush::get_Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/iinkbrush/get_color/) và [IInkBrush::get_Size](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Đặt Màu Brush Bút ký**

Đoạn mã C++ dưới đây cho thấy cách đặt màu cho một brush bút ký:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Đặt Kích thước Brush Bút ký**

Đoạn mã C++ dưới đây cho thấy cách đặt kích thước cho một brush bút ký:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Thông thường, chiều rộng và chiều cao của brush không khớp, vì vậy PowerPoint không hiển thị kích thước brush (phần dữ liệu tương ứng bị làm mờ). Khi chiều rộng và chiều cao của brush khớp, PowerPoint hiển thị kích thước như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để minh bạch, hãy tăng chiều cao của đối tượng bút ký và xem xét các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của brush — nó luôn giả định độ dày đường bằng 0 (xem hình ảnh trước).

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng bút ký, phải tính đến kích thước brush của các vết. Ở đây, đối tượng mục tiêu (vết văn bản viết tay) đã được kéo dãn tới kích thước của container (khung). Khi kích thước của container thay đổi, kích thước brush vẫn không đổi, và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint áp dụng hành vi tương tự cho các đối tượng văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát Hiển thị Bút ký Khi Xuất và Kết xuất**

Aspose.Slides cung cấp giao diện [IInkOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/iinkoptions/) để kiểm soát cách các đối tượng bút ký xuất hiện trong kết quả xuất hoặc kết xuất. Bạn có thể dùng các phương thức của nó để ẩn hoàn toàn bút ký hoặc thay đổi cách các phép toán mask của brush bút ký được diễn giải.

Các tùy chọn bút ký có sẵn thông qua các tùy chọn xuất hoặc kết xuất cho một số loại đầu ra:

| Output | Ink options method |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspos

e.com/slides/vi/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Hai cài đặt sau có sẵn thông qua các phương thức này:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/iinkoptions/set_hideink/) xác định liệu các đối tượng bút ký có được đưa vào đầu ra hay không. Giá trị mặc định là `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) xác định liệu một phép toán mask có được diễn giải thành độ trong suốt khi kết xuất brush bút ký hay không. Giá trị mặc định là `true`; đặt thành `false` để sử dụng phép toán ROP thay thế.

### **Ẩn Đối tượng Bút ký trong Đầu ra PDF**

Mặc định, các đối tượng bút ký vẫn hiển thị khi xuất. Gọi [IInkOptions::set_HideInk](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/iinkoptions/set_hideink/) với `true` khi bạn cần một đầu ra sạch sẽ không có chú thích viết tay hoặc nội dung bút ký khác.

Ví dụ C++ dưới đây xuất một bản trình chiếu sang PDF trong khi ẩn tất cả các đối tượng bút ký:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Ẩn Đối tượng Bút ký Khi Kết xuất Slide dưới Dạng Ảnh**

Để ẩn các đối tượng bút ký khi kết xuất slide thành ảnh bitmap, cấu hình [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) và truyền các tùy chọn kết xuất vào phương thức [ISlide::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/).

Ví dụ C++ dưới đây kết xuất slide đầu tiên dưới dạng ảnh PNG mà không có đối tượng bút ký:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Kiểm soát Kết xuất Mask Bút ký**

Phương thức [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) kiểm soát cách các phép toán mask được diễn giải khi kết xuất brush bút ký. Giá trị mặc định là `true`, tức sử dụng độ trong suốt. Gọi phương thức này với `false` để sử dụng phép toán ROP thay thế.

Ví dụ C++ dưới đây xuất một slide sang SVG và dùng kết xuất dựa trên ROP cho các phép toán mask bút ký:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Cài đặt tương tự có thể được áp dụng qua [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) khi xuất bản trình chiếu hoặc kết xuất slide sang TIFF.

### **Chọn Ẩn hay Giữ lại Bút ký**

Sử dụng [IInkOptions::set_HideInk](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/iinkoptions/set_hideink/) với `true` khi tệp xuất cần là phiên bản sạch sẽ của bản trình chiếu có chú thích, ví dụ bản cuối cùng dự định phân phối mà không có dấu đánh giá.

Giữ bút ký hiển thị (cài đặt mặc định `false`) khi các chú thích bút ký là một phần của nội dung dự định, chẳng hạn như bình luận đánh giá, ghi chú viết tay, đánh dấu hoặc bản vẽ cần hiển thị trong kết quả xuất. Điều này cho phép các ứng dụng tạo ra các đầu ra đánh giá và cuối cùng riêng biệt từ cùng một bản trình chiếu mà không phải sửa đổi các đối tượng bút ký nguồn.

## **FAQ**

**Tôi có thể thay đổi màu hoặc kích thước của một nét bút ký hiện có không?**

Có. Lấy vết từ [IInk::get_Traces](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/iink/get_traces/), sau đó thay đổi [IInkTrace::get_Brush](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/iinktrace/get_brush/). Bạn có thể gọi [IInkBrush::set_Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/iinkbrush/set_color/) và [IInkBrush::set_Size](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/iinkbrush/set_size/) trên brush.

**Việc ẩn bút ký có thay đổi bản trình chiếu nguồn không?**

Không. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/iinkoptions/set_hideink/) chỉ ảnh hưởng đến kết quả kết xuất hoặc xuất; nó không xóa hoặc sửa đổi các đối tượng bút ký trong bản trình chiếu nguồn.

**Các định dạng xuất nào hỗ trợ tùy chọn bút ký?**

Bạn có thể cấu hình tùy chọn bút ký cho PDF, HTML, SVG, TIFF và ảnh slide bitmap thông qua các tùy chọn xuất hoặc kết xuất tương ứng được liệt kê ở trên.

**Đọc thêm**

* Để tìm hiểu về các shape nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/cpp/powerpoint-shapes/).
* Để biết thêm về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/cpp/shape-effective-properties/#get-effective-font-height-value).
* Để biết chi tiết xuất PDF, xem [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/vi/cpp/convert-powerpoint-to-pdf/).
* Để biết chi tiết xuất HTML, xem [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/vi/cpp/convert-powerpoint-to-html/).
* Để biết chi tiết xuất SVG, xem [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/vi/cpp/render-a-slide-as-an-svg-image/).
* Để biết chi tiết xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/vi/cpp/convert-powerpoint-to-tiff/).
* Để biết chi tiết kết xuất slide thành ảnh, xem [Convert Presentation Slides to Images](https://docs.aspose.com/slides/vi/cpp/convert-slide/).