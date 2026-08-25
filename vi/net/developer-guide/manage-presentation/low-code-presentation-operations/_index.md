---
title: Các thao tác trình chiếu Low-Code trong .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/net/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- lặp qua slide
- lặp qua shape
- lặp qua văn bản
- thu thập shape
- nén trình chiếu
- xóa master slide không dùng
- xóa layout slide không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong .NET để chuyển đổi và hợp nhất trình chiếu, lặp qua nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

[**Aspose.Slides.LowCode**](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/) cung cấp các lớp trợ giúp tĩnh cho các thao tác phổ biến trên bản trình chiếu. Các trợ giúp này gói gọn các quy trình làm việc thường dùng của mô hình đối tượng trong các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các thành phần của bản trình chiếu, thu thập các hình dạng và loại bỏ nội dung không sử dụng mà không cần viết nhiều mã.

Các trợ giúp low‑code đặc biệt hữu ích khi thao tác áp dụng cho toàn bộ tệp hoặc bản trình chiếu và quy trình mặc định đáp ứng yêu cầu của bạn. Sử dụng mô hình đối tượng đầy đủ của [Aspose.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất, hoặc quan hệ giữa các thành phần của bản trình chiếu.

Bảng dưới đây tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/) | Chuyển đổi bản trình chiếu sang định dạng khác bằng một lệnh gọi file‑to‑file trực tiếp. |
| [Merger](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/merger/) | Kết hợp các tệp bản trình chiếu cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/) | Thực thi một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp đi lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) | Loại bỏ các master và layout không dùng và giảm dữ liệu phông chữ được nhúng. |

## **Chuyển đổi bản trình chiếu**

Sử dụng [Convert.AutoByExtension](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/autobyextension/) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức này mở bản trình chiếu nguồn, xác định định dạng cần thiết từ đường dẫn đầu ra và ghi kết quả.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/) cũng cung cấp các phương thức riêng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc sửa đổi bản trình chiếu trước khi xuất hoặc cấu hình một tùy chọn xuất mà trợ giúp không cung cấp. Xem [Convert Presentation](/slides/vi/net/convert-presentation/) để biết các quy trình và tùy chọn riêng cho từng định dạng.

## **Hợp nhất các bản trình chiếu**

Sử dụng [Merger.Process](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/merger/process/) để kết hợp các tệp bản trình chiếu hoàn chỉnh chỉ với một lệnh gọi. Các bản trình chiếu đầu vào phải có cùng định dạng tệp.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối vào một kết quả duy nhất mà không cần chọn hoặc ánh xạ chúng riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, giữ lại các phần một cách rõ ràng, hoặc đồng nhất các kích thước slide khác nhau. Xem [Merge Presentations](/slides/vi/net/merge-presentation/) cho những kịch bản đó.

## **Duyệt qua các thành phần của bản trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/) gọi một hàm callback cho mỗi loại thành phần được yêu cầu. Nó tránh các vòng lặp thu thập lồng nhau và thuận tiện cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bản trình chiếu.

Ví dụ sau sử dụng [ForEach.Slide](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/paragraph/) và [ForEach.Portion](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/portion/) để kiểm tra các phần tử tương ứng:

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

Mặc định, việc duyệt shape và văn bản trên toàn bản trình chiếu bao gồm slide bình thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý slide ghi chú. Sử dụng vòng lặp thu thập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết quan hệ cha‑con là quan trọng.

## **Thu thập Shapes**

Sử dụng [Collect.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/collect/shapes/) khi bạn cần một tập hợp tất cả các shape trong bản trình chiếu thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

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

Dùng [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/) khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung bản trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) có thể loại bỏ các phần tử cấu trúc không dùng và giảm dữ liệu phông chữ được nhúng:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) loại bỏ các layout slide mà không có slide bình thường nào tham chiếu.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) loại bỏ các master slide không còn được sử dụng.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/compressembeddedfonts/) loại bỏ các ký tự không dùng trong phông chữ được nhúng.

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

Đầu tiên loại bỏ các layout không dùng, sau đó loại bỏ các master không dùng để một master không còn được tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bản trình chiếu đã tối ưu vào tệp mới nếu bạn có thể cần lại các master, layout hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/slides/vi/net/slide-master/) và [Embedded Font](/slides/vi/net/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào nên sử dụng API low‑code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low‑code khi một thao tác chuẩn áp dụng cho toàn bộ tệp hoặc bản trình chiếu và không yêu cầu kiểm soát chi tiết từng phần tử. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát quan hệ master‑layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các bản trình chiếu có định dạng tệp khác nhau không?**

Không. [Merger.Process](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/merger/process/) yêu cầu các bản trình chiếu đầu vào có cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert.AutoByExtension](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/convert/autobyextension/), rồi mới hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và notes không?**

[ForEach.Slide](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/slide/) duyệt qua các slide bình thường của bản trình chiếu. Các thao tác [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/paragraph/) và [ForEach.Portion](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/portion/) trên toàn bộ bản trình chiếu bao gồm slide bình thường, master và layout theo mặc định. Sử dụng các overload với `includeNotes` đặt thành `true` để bao gồm slide ghi chú.

**Sự khác nhau giữa ForEach.Shape và Collect.Shapes là gì?**

Dùng [ForEach.Shape](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/shape/) để xử lý mỗi shape ngay lập tức thông qua callback. Dùng [Collect.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/collect/shapes/) khi bạn cần một kết quả enumerable có thể lưu lại, lọc, đếm hoặc duyệt lại nhiều lần.

**Compress luôn làm giảm kích thước tệp bản trình chiếu không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bản trình chiếu có chứa các layout, master không dùng hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có những yếu tố này, các thao tác [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) có thể không làm giảm kích thước tệp.

**Các thay đổi do ForEach hoặc Compress gây ra có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các phần tử trong callback của [ForEach](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/), hãy gọi [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) để ghi kết quả.

## **Bài viết liên quan**

- [Convert Presentation](/slides/vi/net/convert-presentation/)
- [Merge Presentations](/slides/vi/net/merge-presentation/)
- [Slide Master](/slides/vi/net/slide-master/)
- [Manage Text Box](/slides/vi/net/manage-textbox/)
- [Embedded Font](/slides/vi/net/embedded-font/)