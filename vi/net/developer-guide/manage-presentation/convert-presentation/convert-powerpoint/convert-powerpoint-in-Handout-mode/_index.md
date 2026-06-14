---
title: Chuyển đổi các bài thuyết trình PowerPoint ở chế độ bản phát tay trong .NET
linktitle: Chế độ bản phát tay
type: docs
weight: 150
url: /vi/net/convert-powerpoint-in-handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chế độ bản phát tay
- bản phát tay
- PowerPoint
- bài thuyết trình
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình thành bản phát tay trong .NET. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides, kèm mã C# mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình sang các định dạng đầu ra hỗ trợ chế độ Handout. Trong chế độ này, nhiều slide được sắp xếp trên một trang, rất hữu ích cho việc in tài liệu thuyết trình cho hội nghị, hội thảo và các sự kiện tương tự.

Chế độ Handout được cấu hình thông qua thuộc tính `SlidesLayoutOptions`, thuộc tính này có sẵn trong [IPdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ihtmloptions/), và [ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/). Để xác định bố cục handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handoutlayoutingoptions/) .

## **Xuất chế độ Handout**

Để xuất một bài thuyết trình ở chế độ Handout, đặt thuộc tính `SlidesLayoutOptions` cho các tùy chọn xuất mục tiêu và gán một thể hiện [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handoutlayoutingoptions/) xác định số slide trên mỗi trang và các tham số hiển thị liên quan.

Dưới đây là ví dụ mã minh họa cách chuyển đổi một bài thuyết trình sang PDF ở chế độ Handout.

```c#
// Tải một bài thuyết trình.
using var presentation = new Presentation("sample.pptx");

// Đặt các tùy chọn xuất.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slide trên một trang theo chiều ngang
        PrintSlideNumbers = true,                   // in số slide
        PrintFrameSlide = true,                     // in khung quanh các slide
        PrintComments = false                       // không có bình luận
    }
};

// Xuất bài thuyết trình sang PDF với bố cục đã chọn.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Lưu ý rằng thuộc tính `SlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng thumbnail slide tối đa trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [các thiết lập sẵn](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handouttype/) lên đến 9 thumbnail trên mỗi trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc), và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên mỗi trang không?**

Không. Số lượng và thứ tự của các thumbnail được kiểm soát chặt chẽ bởi enumeration [HandoutType](https://reference.aspose.com/slides/vi/net/aspose.slides.export/handouttype/); các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Bật tùy chọn `ShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/).