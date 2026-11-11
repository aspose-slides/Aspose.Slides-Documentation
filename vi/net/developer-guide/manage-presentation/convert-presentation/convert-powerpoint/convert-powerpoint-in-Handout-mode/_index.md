---
title: "Chuyển đổi bản trình chiếu PowerPoint ở chế độ Handout trong .NET"
linktitle: "Chế độ Handout"
type: docs
weight: 150
url: /vi/net/convert-powerpoint-in-handout-mode/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bản trình chiếu"
- "chế độ handout"
- "handout"
- "PowerPoint"
- "bản trình chiếu"
- "PPT"
- "PPTX"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Chuyển đổi bản trình chiếu thành handout trong .NET. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides, kèm mã mẫu C#. Thử ngay miễn phí."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bản trình bày sang các định dạng đầu ra hỗ trợ chế độ Handout. Trong chế độ này, nhiều slide được sắp xếp trên một trang duy nhất, rất hữu ích khi in tài liệu trình bày cho hội nghị, hội thảo và các sự kiện tương tự.

Chế độ Handout được cấu hình thông qua thuộc tính `SlidesLayoutOptions`, có sẵn trong [IPdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ihtmloptions/) và [ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/). Để xác định bố cục handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handoutlayoutingoptions/).

Để đặt kích thước và hướng của trang handout trước khi xuất, xem [Kích thước trang Ghi chú](/slides/vi/net/notes-size/).

## **Xuất chế độ Handout**

Để xuất một bản trình bày ở chế độ Handout, đặt thuộc tính `SlidesLayoutOptions` cho các tùy chọn xuất mục tiêu và gán một thể hiện của [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handoutlayoutingoptions/) xác định số slide trên mỗi trang và các tham số hiển thị liên quan.

Dưới đây là ví dụ mã minh họa cách chuyển đổi bản trình bày sang PDF ở chế độ Handout.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Tải một bản trình chiếu.
using var presentation = new Presentation("sample.pptx");

// Đặt các tùy chọn xuất.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slide trên một trang theo chiều ngang
        PrintSlideNumbers = true,                   // in số slide
        PrintFrameSlide = true,                     // in khung quanh các slide
        PrintComments = false                       // không có nhận xét
    }
};

// Xuất bản trình chiếu sang PDF với bố cục đã chọn.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Hãy nhớ rằng thuộc tính `SlidesLayoutOptions` chỉ có sẵn cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

### Số lượng tối đa của các hình thu nhỏ slide trên mỗi trang trong chế độ Handout là bao nhiêu?

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handouttype/) lên tới 9 hình thu nhỏ trên mỗi trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

### Tôi có thể xác định lưới tùy chỉnh, ví dụ 5 hoặc 8 slide trên mỗi trang không?

Không. Số lượng và thứ tự của các hình thu nhỏ được kiểm soát chặt chẽ bởi enumeration [HandoutType](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handouttype/); các bố cục tùy ý không được hỗ trợ.

### Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?

Có. Bật tùy chọn `ShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/).