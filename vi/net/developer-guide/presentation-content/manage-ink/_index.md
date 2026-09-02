---
title: Quản lý các đối tượng mực của PowerPoint trong .NET
linktitle: Quản lý mực
type: docs
weight: 95
url: /vi/net/manage-ink/
keywords:
- mực
- đối tượng mực
- dấu vết mực
- quản lý mực
- vẽ mực
- vẽ
- xuất mực
- render mực
- ẩn mực
- IInkOptions
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint, chỉnh sửa dấu vết và thuộc tính brush, và kiểm soát cách hiển thị mực khi xuất PDF, HTML, SVG, TIFF và hình ảnh với Aspose.Slides cho .NET."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng mực cho phép bạn vẽ các nét tự do. Mực có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.

Namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/) chứa các lớp và giao diện cần thiết để làm việc với các đối tượng mực. Ví dụ, giao diện [IInk](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/iink/) đại diện cho một đối tượng mực trên slide.

## **Sự khác biệt giữa Đối tượng thường và Đối tượng mực**

Các đối tượng trên slide PowerPoint thường được đại diện bằng các đối tượng shape. Ở dạng đơn giản nhất, shape là một container định nghĩa vùng của chính đối tượng (khung) cùng với các thuộc tính như kích thước container, hình dạng và nền. Để biết thêm thông tin, xem [Shape Layout Format](httpshttps://docs.aspose.com/slides/vi/net/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước khu vực container được xác định bởi các thuộc tính chuẩn [IShape.Width](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/width/) và [IShape.Height](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết mực**

Một dấu vết mực là yếu tố cơ bản dùng để ghi lại quỹ đạo của bút khi người dùng viết mực kỹ thuật số. Một dấu vết lưu trữ một chuỗi các điểm nối nhau.

Dạng mã hóa đơn giản nhất chỉ định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm nối nhau được vẽ, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Brush để Vẽ**

Brush được dùng để vẽ các đường nối các điểm của một dấu vết mực. Brush có màu và kích thước riêng, được biểu diễn bằng các thuộc tính [IInkBrush.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/iinkbrush/color/) và [IInkBrush.Size](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/iinkbrush/size/).

### **Đặt màu Brush cho mực**

Đoạn mã C# sau cho thấy cách đặt màu cho brush:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Đặt kích thước Brush cho mực**

Đoạn mã C# sau cho thấy cách đặt kích thước cho brush:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Nhìn chung, chiều rộng và chiều cao của brush không khớp nhau, vì vậy PowerPoint không hiển thị kích thước brush (phần dữ liệu tương ứng được làm mờ). Khi chiều rộng và chiều cao của brush khớp, PowerPoint hiển thị kích thước như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của các brush — nó luôn giả định độ dày của đường là zero (xem hình ảnh trước).

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng mực, phải tính đến kích thước brush của các dấu vết. Ở đây, đối tượng mục tiêu (dấu vết văn bản viết tay) đã được mở rộng tới kích thước của container (khung). Khi kích thước container thay đổi, kích thước brush giữ nguyên, và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint sử dụng hành vi tương tự cho các đối tượng văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát Hiển thị Mực khi Xuất và Render**

Aspose.Slides cung cấp giao diện [IInkOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/) để kiểm soát cách các đối tượng mực xuất hiện trong kết quả xuất hoặc render. Bạn có thể sử dụng các thuộc tính của nó để ẩn hoàn toàn mực hoặc thay đổi cách các thao tác mask brush được diễn giải.

Các tùy chọn mực có sẵn thông qua các tùy chọn xuất hoặc render cho một số loại đầu ra:

| Đầu ra | Thuộc tính tùy chọn mực |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Ảnh slide | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/vi/net/aspose.slides.export/renderingoptions/inkoptions/) |

Hai cài đặt cùng có sẵn qua các thuộc tính này:

- [`HideInk`](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/hideink/) xác định xem các đối tượng mực có được bao gồm trong đầu ra hay không. Giá trị mặc định là `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) xác định việc một thao tác mask có được diễn giải là độ trong suốt khi render brush mực hay không. Giá trị mặc định là `true`; đặt thành `false` để sử dụng thao tác ROP thay thế.

### **Ẩn Đối tượng mực trong Đầu ra PDF**

Mặc định, các đối tượng mực vẫn hiển thị khi xuất. Đặt [IInkOptions.HideInk](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/hideink/) thành `true` khi bạn cần một đầu ra sạch sẽ không có chú thích viết tay hoặc nội dung mực khác.

Đoạn C# sau xuất một bản trình bày ra PDF đồng thời ẩn tất cả các đối tượng mực:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Ẩn Đối tượng mực Khi Render Slide thành Ảnh**

Để ẩn các đối tượng mực khi render slide thành ảnh bitmap, cấu hình [RenderingOptions.InkOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/renderingoptions/inkoptions/) và truyền các tùy chọn render vào phương thức [ISlide.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/).

Đoạn C# sau render slide đầu tiên thành ảnh PNG mà không có đối tượng mực:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Kiểm soát Render Mask Mực**

Thuộc tính [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) kiểm soát cách các thao tác mask được diễn giải khi render brush mực. Giá trị mặc định là `true`, dùng độ trong suốt. Đặt thuộc tính thành `false` để sử dụng thao tác ROP thay thế.

Đoạn C# sau xuất một slide ra SVG và dùng render dựa trên ROP cho các thao tác mask mực:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Cài đặt tương tự có thể áp dụng qua [TiffOptions.InkOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/inkoptions/) khi xuất bản trình bày hoặc render slide thành TIFF.

### **Chọn Ẩn hay Giữ lại Mực**

Sử dụng [IInkOptions.HideInk](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/hideink/) đặt thành `true` khi tệp xuất cần là phiên bản sạch của bản trình bày có chú thích, ví dụ bản cuối cùng dành cho phân phối mà không có dấu đánh dấu xem xét.

Để [IInkOptions.HideInk](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/hideink/) ở giá trị mặc định `false` khi các chú thích mực là nội dung dự định, chẳng hạn bình luận đánh giá, ghi chú viết tay, tô sáng hoặc bản vẽ cần vẫn hiển thị trong kết quả xuất. Điều này cho phép ứng dụng tạo ra các bản xuất đánh giá và bản cuối cùng riêng biệt từ cùng một bản trình bày mà không phải sửa đổi các đối tượng mực nguồn.

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi màu hoặc kích thước của một nét mực đã tồn tại không?**

Có. Lấy dấu vết từ [IInk.Traces](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/iink/traces/), sau đó thay đổi thuộc tính [IInkTrace.Brush](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/iinktrace/brush/). Bạn có thể đặt thuộc tính [IInkBrush.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/iinkbrush/color/) và [IInkBrush.Size](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/iinkbrush/size/) của brush.

**Việc ẩn mực có thay đổi bản trình bày nguồn không?**

Không. [IInkOptions.HideInk](https://reference.aspose.com/slides/vi/net/aspose.slides.export/iinkoptions/hideink/) chỉ ảnh hưởng đến kết quả render hoặc xuất; nó không xóa hay sửa đổi các đối tượng mực trong bản trình bày nguồn.

**Các định dạng xuất nào hỗ trợ tùy chọn mực?**

Bạn có thể cấu hình tùy chọn mực cho PDF, HTML, SVG, TIFF và ảnh slide bitmap thông qua các tùy chọn xuất hoặc render tương ứng được liệt kê ở trên.

**Đọc thêm**

* Để tìm hiểu về shape nói chung, xem mục [PowerPoint Shapes](https://docs.aspose.com/slides/vi/net/powerpoint-shapes/).
* Để biết thêm về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/net/shape-effective-properties/#get-effective-font-height-value).
* Để biết chi tiết xuất PDF, xem [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/vi/net/convert-powerpoint-to-pdf/).
* Để biết chi tiết xuất HTML, xem [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/vi/net/convert-powerpoint-to-html/).
* Để biết chi tiết xuất SVG, xem [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/vi/net/render-a-slide-as-an-svg-image/).
* Để biết chi tiết xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/vi/net/convert-powerpoint-to-tiff/).
* Để biết chi tiết render slide thành ảnh, xem [Convert Presentation Slides to Images](https://docs.aspose.com/slides/vi/net/convert-slide/).