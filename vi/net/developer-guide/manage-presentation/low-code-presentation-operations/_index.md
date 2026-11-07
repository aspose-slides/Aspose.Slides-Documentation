---
title: Các thao tác trình chiếu low-code trong .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/net/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- lặp qua các slide
- lặp qua các shape
- lặp qua văn bản
- thu thập shape
- nén trình chiếu
- xóa các master slide không dùng
- xóa các layout slide không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong .NET để chuyển đổi và hợp nhất các trình chiếu, lặp qua nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

Không gian tên [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) cung cấp các lớp trợ giúp tĩnh cho các thao tác trình chiếu thông thường. Các trợ giúp này gói gọn các quy trình mô hình đối tượng thường dùng vào các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các yếu tố của trình chiếu, thu thập các shape và loại bỏ nội dung không dùng tới với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bản trình chiếu và quy trình làm việc mặc định phù hợp với yêu cầu của bạn. Sử dụng [mô hình đối tượng Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất hoặc mối quan hệ giữa các yếu tố trình chiếu.

Bảng sau tóm tắt các trợ giúp khả dụng:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Chuyển đổi](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Chuyển đổi một bản trình chiếu sang định dạng khác bằng lời gọi trực tiếp file‑to‑file. |
| [Hợp nhất](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Kết hợp các tệp bản trình chiếu hoàn chỉnh có cùng định dạng. |
| [Lặp](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Thực thi một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Thu thập](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Nén](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Xóa các master/layout không dùng, giảm dữ liệu phông chữ nhúng và nén hình ảnh. |

## **Chuyển đổi một bản trình chiếu**

Sử dụng [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức mở bản trình chiếu nguồn, xác định định dạng cần thiết từ đường dẫn đầu ra và ghi kết quả.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) cũng cung cấp các phương thức chuyên dụng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc chỉnh sửa bản trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất mà trợ giúp đã chọn không cung cấp. Xem [Chuyển đổi bản trình chiếu](/slides/vi/net/convert-presentation/) để biết các quy trình và tùy chọn theo định dạng.

## **Hợp nhất bản trình chiếu**

Sử dụng [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) để kết hợp các tệp bản trình chiếu hoàn chỉnh bằng một lần gọi. Các bản trình chiếu đầu vào phải có cùng định dạng tệp.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Trợ giúp này thích hợp khi tất cả các slide cần được nối vào một kết quả mà không cần chọn hoặc ánh xạ lại từng slide. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, bảo lưu các phần rõ ràng, hoặc điều chỉnh các kích thước slide khác nhau. Xem [Hợp nhất bản trình chiếu](/slides/vi/net/merge-presentation/) cho các kịch bản đó.

## **Duyệt qua các yếu tố của bản trình chiếu**

Class [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) gọi một callback cho mỗi loại yếu tố bản trình chiếu được yêu cầu. Nó tránh các vòng lặp bộ sưu tập lồng nhau và tiện lợi cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bản trình chiếu.

Ví dụ sau sử dụng [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), và [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) để kiểm tra các yếu tố tương ứng:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Mặc định, việc duyệt hình dạng và văn bản trên toàn bộ bản trình chiếu bao gồm các slide thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý slide ghi chú. Sử dụng vòng lặp bộ sưu tập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết cha‑con là quan trọng.

## **Thu thập Shapes**

Sử dụng [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) khi bạn cần một tập hợp tất cả các shape trong một bản trình chiếu thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một bộ sẽ được lọc, đếm hoặc xử lý nhiều lần.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Sử dụng [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) thay thế khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung bản trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) có thể loại bỏ các yếu tố cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) loại bỏ các slide layout mà không có slide thường nào tham chiếu.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) loại bỏ các slide master không còn được sử dụng.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) loại bỏ các ký tự không dùng khỏi phông chữ nhúng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Xóa các layout không dùng trước các master không dùng để một master trở nên không tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bản trình chiếu đã tối ưu vào tệp mới nếu bạn có thể cần các master, layout hoặc dữ liệu phông chữ nhúng hoàn chỉnh sau này. Để biết chi tiết hơn, xem [Master Slide](/slides/vi/net/slide-master/) và [Phông chữ nhúng](/slides/vi/net/embedded-font/).

### **Nén toàn bộ bản trình chiếu**

Aspose.Slides for .NET 26.11 bổ sung [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Nó kết hợp việc loại bỏ các slide layout/master không dùng, rút gọn phông chữ nhúng tới các ký tự đã dùng, và nén hình ảnh ở 150 DPI. Sử dụng các thao tác riêng ở trên khi bạn cần kiểm soát những thay đổi được áp dụng.

Cài đặt [Aspose.Slides for .NET](/slides/vi/net/installation/) 26.11 trở lên và cung cấp `input.pptx`. Lưu vào tệp riêng: các layout đã xóa, ký tự phông chữ và pixel ảnh đã cắt có thể cần cho việc chỉnh sửa sau.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Nén hình ảnh ở độ phân giải đã chọn**

Sử dụng [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) để xử lý các ảnh đủ điều kiện mà không loại bỏ layout hoặc rút gọn phông chữ. Ví dụ này sử dụng 96 DPI; chọn giá trị [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) khác cho nhu cầu xuất của bạn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Cả hai trợ giúp đều sử dụng phạm vi xử lý ảnh sau:

| Nội dung | Xử lý |
| --- | --- |
| Ảnh raster và nền ảnh shape trên slide thường, master và layout, bao gồm các shape nhóm | Có thể nén. |
| Ảnh đã ở độ phân giải yêu cầu hoặc thấp hơn | Không tăng kích thước. Vùng đã cắt vẫn có thể bị xóa. |
| Vùng ảnh đã cắt | Các pixel ẩn bị xóa vĩnh viễn và độ dịch cắt được đặt lại. |
| Nền slide và nền ô bảng | Không được các trợ giúp này xử lý. |
| Cấu trúc Chart/SmartArt, GIF và định dạng vector như SVG, EMF và WMF | Ngoài phạm vi nén ảnh được tài liệu ghi chú. |

Trong 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) tránh việc giảm mẫu dựa trên độ phân giải của ảnh chưa cắt, nhưng **không bảo tồn pixel đã cắt**. Một ảnh đã cắt vẫn có thể được ghi lại với các khu vực ẩn đã bị xóa. Không có trợ giúp nào cung cấp tùy chọn giữ lại cắt. Đối với kiểm soát riêng, xem [ví dụ nén từng ảnh](/slides/vi/net/examples/optimization-batch/compression/).

So sánh giao diện và kích thước tệp đầu ra trước khi thay thế bản gốc. Tiết kiệm phụ thuộc vào ảnh nguồn, kích thước hiển thị và nội dung không dùng; nén không đảm bảo tệp nhỏ hơn. Xem [Phông chữ nhúng](/slides/vi/net/embedded-font/) để hiểu các tác động của việc rút gọn phông chữ.

## **FAQ**

**Khi nào tôi nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc bản trình chiếu và không yêu cầu kiểm soát chi tiết các yếu tố riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các bản trình chiếu ở các định dạng tệp khác nhau không?**

Không. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) yêu cầu các bản trình chiếu đầu vào có cùng định dạng tệp. Đầu tiên chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), rồi hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và ghi chú không?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) duyệt qua các slide trình chiếu bình thường. Các thao tác [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), và [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) trên toàn bộ bản trình chiếu bao gồm các slide bình thường, master và layout theo mặc định. Sử dụng các overload với `includeNotes` đặt thành `true` để bao gồm slide ghi chú.

**Sự khác biệt giữa ForEach.Shape và Collect.Shapes là gì?**

Sử dụng [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) để xử lý mỗi shape ngay lập tức qua callback. Sử dụng [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) khi bạn cần một kết quả enumerable có thể giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress luôn làm tệp bản trình chiếu nhỏ hơn không?**

Không nhất thiết. Tiết kiệm phụ thuộc vào các layout/master không dùng, phông chữ nhúng có ký tự không dùng, và ảnh có thể nén. Các trợ giúp [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) có thể giữ nguyên kích thước hoặc thậm chí tạo tệp lớn hơn đối với một số đầu vào. So sánh cả kích thước và chất lượng hiển thị, và giữ lại bản gốc.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các yếu tố trong callback [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), gọi [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi bản trình chiếu](/slides/vi/net/convert-presentation/)
- [Hợp nhất bản trình chiếu](/slides/vi/net/merge-presentation/)
- [Master Slide](/slides/vi/net/slide-master/)
- [Quản lý hộp văn bản](/slides/vi/net/manage-textbox/)
- [Phông chữ nhúng](/slides/vi/net/embedded-font/)