---
title: "Chuyển đổi Bài thuyết trình PowerPoint ở Chế độ Handout bằng Java"
linktitle: "Chế độ Handout"
type: docs
weight: 150
url: /vi/java/convert-powerpoint-in-handout-mode/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bài thuyết trình"
- "chế độ handout"
- "bản phát tay"
- PPT
- PPTX
- PowerPoint
- "bài thuyết trình"
- Java
- Aspose.Slides
description: "Chuyển đổi bài thuyết trình thành bản phát tay bằng Java. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides, kèm ví dụ mã Java. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi bài thuyết trình sang các định dạng đầu ra hỗ trợ chế độ Handout. Trong chế độ này, nhiều slide được sắp xếp trên một trang, hữu ích cho việc in tài liệu trình bày cho hội nghị, hội thảo và các sự kiện tương tự.

Chế độ Handout được cấu hình thông qua phương thức `setSlidesLayoutOptions`, có sẵn trong [IPdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihtmloptions/) và [ITiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiffoptions/). Để xác định bố cục handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handoutlayoutingoptions/).

## **Xuất chế độ Handout**

Để xuất một bài thuyết trình ở chế độ Handout, thiết lập phương thức `setSlidesLayoutOptions` cho các tùy chọn xuất đích và gán một thể hiện của [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handoutlayoutingoptions/) xác định số slide trên mỗi trang và các tham số hiển thị liên quan.

Dưới đây là ví dụ mã cho thấy cách chuyển đổi một bài thuyết trình sang PDF ở chế độ Handout.

```java
// Tải một bài thuyết trình.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Đặt các tùy chọn xuất.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // in số slide
    slidesLayoutOptions.setPrintFrameSlide(true);                     // in khung quanh các slide
    slidesLayoutOptions.setPrintComments(false);                      // không có bình luận

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Xuất bài thuyết trình sang PDF với bố cục đã chọn.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Hãy nhớ rằng phương thức `setSlidesLayoutOptions` chỉ có sẵn cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng hình thu nhỏ slide tối đa trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handouttype/) lên tới 9 hình thu nhỏ trên mỗi trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên mỗi trang không?**

Không. Số lượng và thứ tự của các hình thu nhỏ được kiểm soát nghiêm ngặt bởi lớp [HandoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handouttype/); các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Bật các slide ẩn bằng cách sử dụng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng đích, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/).