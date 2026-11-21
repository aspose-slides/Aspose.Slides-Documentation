---
title: Thay đổi kích thước và hướng trang ghi chú trong .NET
linktitle: Kích thước trang ghi chú
type: docs
weight: 10
url: /vi/net/notes-size/
keywords:
- kích thước trang ghi chú
- hướng ghi chú
- ghi chú ngang
- ghi chú dọc
- kích thước bản tay
- PowerPoint
- bản trình chiếu
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Đọc và thay đổi kích thước trang ghi chú trong Aspose.Slides cho .NET, chuyển hướng, xác minh kích thước đã lưu, và xuất ghi chú hoặc bản tay ra PDF và hình ảnh."
---
## **Tổng quan**

Sử dụng [Presentation.NotesSize](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/notessize/) để truy cập cài đặt trang ghi chú của bản trình chiếu. Nó trả về một đối tượng [INotesSize](https://reference.aspose.com/slides/vi/net/aspose.slides/inotessize/) có thuộc tính [Size](https://reference.aspose.com/slides/vi/net/aspose.slides/inotessize/size/) có thể ghi được. Mặc dù đối tượng cài đặt này là chỉ đọc, bạn vẫn có thể gán các kích thước mới cho thuộc tính size của nó.

Chiều rộng và chiều cao được xác định bằng **points**, với 72 points mỗi inch. Ví dụ, 900 × 600 points tương đương 12,5 × 8⅓ inch. Các cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho ghi chú của từng slide riêng lẻ.

| Cài đặt | Mục đích |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/notessize/) | Kiểm soát kích thước trang ghi chú và kích thước trang được sử dụng khi xuất bản tay. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slidesize/) | Kiểm soát kích thước các slide trình chiếu thông thường qua [ISlideSize](https://reference.aspose.com/slides/vi/net/aspose.slides/islidesize/). |

Thay đổi một trong hai cài đặt sẽ không tự động thay đổi cài đặt còn lại. Thay đổi hướng của trang ghi chú cũng không làm xoay các slide thông thường. Xem [Slide Size](/slides/vi/net/slide-size/) để thay đổi kích thước các slide thông thường.

Các ví dụ dưới đây sử dụng tệp `sample.pptx` có sẵn. Đối với các ví dụ xuất, hãy sử dụng một bản trình chiếu có ít nhất một slide chứa ghi chú người thuyết trình. Mỗi ví dụ có thể được chạy độc lập.

## **Đọc kích thước và hướng của trang ghi chú**

Đọc chiều rộng và chiều cao và so sánh chúng để xác định hướng: trang rộng hơn là ngang (landscape), trang cao hơn là dọc (portrait), và các kích thước bằng nhau mô tả một trang vuông. Ví dụ này in ra kích thước thực tế bằng points, mà không giả định kích thước giấy tiêu chuẩn.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Chuyển sang ngang mà không thay đổi kích thước giấy**

Để chỉ thay đổi hướng, hãy hoán đổi chiều rộng và chiều cao hiện có. Điều này giữ nguyên độ dài của cả hai phía, kể cả khi sử dụng kích thước giấy tùy chỉnh. Điều kiện dưới đây ngăn một trang đã ở chế độ ngang bị chuyển lại thành dọc và để trang vuông không thay đổi.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Đối với hướng dọc, sử dụng cùng một phép gán khi `size.Width > size.Height`. Không thay thế bằng kích thước A4 hoặc Letter trừ khi bạn cũng muốn thay đổi kích thước giấy.

## **Đặt và xác minh kích thước trang ghi chú tùy chỉnh**

Gán cả hai kích thước cùng lúc, sau đó sử dụng [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) để lưu bản trình chiếu. Ví dụ này đặt một trang ngang 900 × 600 point, lưu dưới dạng PPTX, và mở lại tệp đã lưu để kiểm tra các giá trị đã được lưu. So sánh cho phép sai số 0,01 point đối với các giá trị dấu phẩy động; đây không phải là bảo đảm độ chính xác cho mọi định dạng tệp.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Kết quả mong đợi là `900 x 600 points` và `Size preserved: True`. Kiểm tra một bản trình chiếu mới mở sẽ xác minh tệp đã lưu, chứ không chỉ các cài đặt trong bộ nhớ.

## **Xuất Ghi chú và Bản tay**

Kích thước trang xác định vùng khả dụng cho bố cục ghi chú hoặc bản tay. Chúng không tự động kích hoạt các bố cục này: cần cấu hình các tùy chọn xuất. Xuất slide thông thường vẫn sử dụng kích thước slide.

### **Xuất Ghi chú sang PDF và PNG**

Gán [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/) vào [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) để bao gồm ghi chú trong PDF. Ví dụ này cũng render slide đầu tiên có ghi chú thành PNG bằng cách sử dụng [Slide.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage/) và [RenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/renderingoptions/).

Chế độ [BottomTruncated](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notespositions/) giữ ghi chú trên một trang; các ghi chú không vừa có thể bị cắt ngắn. PDF sử dụng các trang 900 × 600 point. Với tỉ lệ hình ảnh 1 × 1 được sử dụng dưới đây, PNG có kích thước 900 × 600 pixel. Points mô tả hình học trang; pixel mô tả đầu ra raster, kích thước cũng phụ thuộc vào tỉ lệ render.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Đối với xuất PDF với ghi chú dài, [BottomFull](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notespositions/) cho phép tạo thêm các trang khi cần. Không sử dụng chế độ này với lệnh tạo ảnh một slide ở trên, vì nó không hỗ trợ. Sau khi thay đổi kích thước, kiểm tra đầu ra để xem có ghi chú bị cắt không và vị trí của các đối tượng notes-master hiện có; việc chỉ thay đổi kích thước trang không nên được xem là bảo đảm mọi nội dung sẽ vừa. Xem [Convert PowerPoint to PDF with Notes](/slides/vi/net/convert-powerpoint-to-pdf-with-notes/) để biết thêm về xuất ghi chú.

### **Xuất Bản tay sang PDF**

Sử dụng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handoutlayoutingoptions/) cho nhiều ảnh thu nhỏ slide trên một trang. Ví dụ sau đặt một trang 900 × 600 point và sử dụng [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handouttype/) để sắp xếp tối đa bốn slide trên mỗi trang. Cài đặt ngang kiểm soát thứ tự slide; hướng trang được xác định từ chiều rộng và chiều cao của nó.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Thay đổi kích thước trang sẽ thay đổi vùng khả dụng cho lưới bản tay mà không ảnh hưởng đến kích thước của các slide nguồn. Đối với hình ảnh bản tay, sử dụng [Presentation.GetImages](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/getimages/) với bố cục bản tay, thay vì phương thức tạo ảnh của từng slide. Trong Aspose.Slides, việc render bản tay ở mức bản trình chiếu sử dụng kích thước trang ghi chú, trong khi gọi tạo ảnh cho slide riêng lẻ không tạo ra trang bản tay. Xem [Handout Mode](/slides/vi/net/convert-powerpoint-in-handout-mode/) để biết các tùy chọn bố cục.

## **Kích thước Trang trong Trình xem, Xuất và In**

Giữ riêng biệt kích thước bản trình chiếu đã lưu, kích thước trang được xuất và kích thước giấy in:

- **Presentation viewers:** Trình xem có thể hiển thị hoặc in ghi chú theo quy tắc bố cục riêng của nó. Nếu một ứng dụng khác lưu tệp, mở lại và kiểm tra kích thước một lần nữa; việc chuyển đổi định dạng của ứng dụng đó có thể chuẩn hoá chúng.
- **Export formats:** Các ví dụ PDF ghi chú và bản tay ở trên sử dụng kích thước trang đã cấu hình. Hình ảnh raster sử dụng kích thước pixel nguyên và tỉ lệ render, vì vậy các giá trị point thập phân có thể được làm tròn trong đầu ra hình ảnh. Xuất các slide thông thường không áp dụng kích thước trang ghi chú.
- **Printer drivers:** Lựa chọn giấy, tự động xoay và cài đặt vừa trang có thể thay đổi kết quả in mà không thay đổi kích thước lưu trong bản trình chiếu hoặc PDF. Đối với một kích thước giấy cụ thể, hãy đồng bộ cài đặt máy in và kiểm tra bản xem trước khi in.

## **FAQ**

**Có thể đặt kích thước ghi chú cho một slide riêng lẻ không?**

Kích thước trang ghi chú là cài đặt ở mức bản trình chiếu. Các slide riêng lẻ có thể có nội dung ghi chú khác nhau, nhưng thuộc tính này không cung cấp kích thước trang riêng cho từng slide.

**Tại sao việc thay đổi hướng ghi chú không làm thay đổi các slide của tôi?**

Các trang ghi chú và các slide thông thường có kích thước độc lập. Sử dụng cài đặt kích thước slide thông thường khi bạn muốn thay đổi kích thước của các slide.

**Tại sao kết quả đã lưu hoặc in của tôi lại có kích thước khác?**

Đầu tiên mở lại bản trình chiếu đã lưu và so sánh kích thước ghi chú của nó. Nếu chúng đã thay đổi, kiểm tra xem việc lưu hoặc chuyển đổi tệp trong một ứng dụng khác có gây thay đổi cài đặt trang hay không. Nếu không, kiểm tra bố cục xuất, tỉ lệ hình ảnh, cài đặt trình xem và lựa chọn giấy của máy in.