---
title: Thao tác Trình chiếu Low-Code trong .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/net/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- duyệt slide
- duyệt shape
- duyệt văn bản
- thu thập shape
- nén trình chiếu
- loại bỏ master slide không dùng
- loại bỏ layout slide không dùng
- nén phông chữ được nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Sử dụng API low-code Aspose.Slides trong .NET để chuyển đổi và hợp nhất trình chiếu, duyệt nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

[Ns Aspose.Slides.LowCode](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/) cung cấp các lớp trợ giúp tĩnh cho các thao tác chung trên bản trình chiếu. Các trợ giúp này bao bọc các quy trình mô hình đối tượng thường được sử dụng trong các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các phần tử của bản trình chiếu, thu thập các hình dạng và loại bỏ nội dung không sử dụng với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bản trình chiếu và luồng công việc mặc định đáp ứng yêu cầu của bạn. Sử dụng toàn bộ [mô hình đối tượng Aspose.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất hoặc quan hệ giữa các phần tử bản trình chiếu.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Chuyển đổi](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/) | Chuyển đổi một bản trình chiếu sang định dạng khác bằng một lời gọi trực tiếp từ tệp này sang tệp khác. |
| [Kết hợp](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/merger/) | Kết hợp các tệp bản trình chiếu hoàn chỉnh có cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/) | Thực hiện một hành động cho mỗi slide, shape, paragraph hoặc portion. |
| [Thu thập](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Nén](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) | Loại bỏ các master và layout không sử dụng và giảm dữ liệu phông chữ được nhúng. |

## **Chuyển đổi Bản trình chiếu**

Sử dụng [Convert.AutoByExtension](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/autobyextension/) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức này mở bản trình chiếu nguồn, xác định định dạng yêu cầu từ đường dẫn đầu ra và ghi kết quả.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/) cũng cung cấp các phương pháp riêng biệt cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc sửa đổi bản trình chiếu trước khi xuất hoặc cấu hình một tùy chọn xuất không được trợ giúp low-code cung cấp. Xem [Chuyển đổi Bản trình chiếu](/net/convert-presentation/) để biết quy trình và tùy chọn riêng cho từng định dạng.

## **Kết hợp Bản trình chiếu**

Sử dụng [Merger.Process](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/merger/process/) để kết hợp các tệp bản trình chiếu hoàn chỉnh chỉ với một lời gọi. Các bản trình chiếu đầu vào phải có cùng định dạng tệp.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Trợ giúp này thích hợp khi tất cả các slide cần được nối vào một kết quả duy nhất mà không cần chọn hoặc ánh xạ chúng riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, bảo lưu các section một cách rõ ràng, hoặc điều chỉnh kích thước slide khác nhau. Xem [Kết hợp Bản trình chiếu](/net/merge-presentation/) cho các kịch bản đó.

## **Duyệt qua Các phần tử Bản trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/) gọi một hàm phản hồi cho mỗi loại phần tử bản trình chiếu được yêu cầu. Nó tránh các vòng lặp bộ sưu tập lồng nhau và thuận tiện cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bản trình chiếu.

Ví dụ sau sử dụng [ForEach.Slide](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/paragraph/), và [ForEach.Portion](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/portion/) để kiểm tra các phần tử tương ứng:

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

Mặc định, việc duyệt shape và văn bản trên toàn bộ bản trình chiếu bao gồm các slide bình thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp bộ sưu tập trực tiếp khi thứ tự duyệt, việc thoát sớm, lọc trước khi gọi hàm phản hồi, hoặc kiểm soát chi tiết quan hệ cha‑con là quan trọng.

## **Thu thập Shapes**

Sử dụng [Collect.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/collect/shapes/) khi bạn cần một bộ sưu tập tất cả các shape trong bản trình chiếu thay vì một hàm phản hồi cho mỗi shape. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

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

Sử dụng [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/) thay thế khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén Nội dung Bản trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) có thể loại bỏ các phần tử cấu trúc không sử dụng và giảm dữ liệu phông chữ được nhúng:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) loại bỏ các slide layout mà không có slide bình thường nào tham chiếu.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) loại bỏ các master slide không còn được sử dụng.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/compressembeddedfonts/) loại bỏ các ký tự không sử dụng trong phông chữ được nhúng.

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

Loại bỏ các layout không sử dụng trước các master không sử dụng để một master mất tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bản trình chiếu đã tối ưu vào một tệp mới nếu bạn có thể cần các master, layout hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/net/slide-master/) và [Embedded Font](/net/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc bản trình chiếu và không yêu cầu kiểm soát chi tiết các phần tử riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các bản trình chiếu có định dạng tệp khác nhau không?**

Không. [Merger.Process](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/merger/process/) yêu cầu các bản trình chiếu đầu vào có cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert.AutoByExtension](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/autobyextension/), rồi mới hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và notes không?**

[ForEach.Slide](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/slide/) duyệt qua các slide bình thường của bản trình chiếu. Các thao tác [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/paragraph/), và [ForEach.Portion](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/portion/) bao gồm slide bình thường, master và layout theo mặc định. Sử dụng các overload với `includeNotes` được đặt thành `true` để bao gồm slide ghi chú.

**Sự khác nhau giữa ForEach.Shape và Collect.Shapes là gì?**

Sử dụng [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/) để xử lý mỗi shape ngay lập tức thông qua hàm phản hồi. Sử dụng [Collect.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/collect/shapes/) khi bạn cần một kết quả enumerable có thể giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress có luôn làm cho tệp bản trình chiếu nhỏ hơn không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bản trình chiếu có chứa các layout không sử dụng, master không sử dụng hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có các yếu tố trên, các thao tác [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) có thể không giảm kích thước tệp.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) đã tải vào bộ nhớ. Sau khi thay đổi các phần tử trong hàm phản hồi [ForEach](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/), hãy gọi [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi Bản trình chiếu](/net/convert-presentation/)
- [Kết hợp Bản trình chiếu](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Quản lý Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)