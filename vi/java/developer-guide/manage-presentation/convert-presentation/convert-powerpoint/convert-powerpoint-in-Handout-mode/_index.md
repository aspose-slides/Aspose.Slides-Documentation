---
title: Chuyển đổi Bản trình chiếu PowerPoint sang Chế độ Handout bằng Java
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/java/convert-powerpoint-in-Handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chế độ Handout
- handout
- PPT
- PPTX
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu sang handout trong Java. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides, kèm mã Java mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bản thuyết trình sang các định dạng đầu ra hỗ trợ chế độ Handout. Trong chế độ này, nhiều slide được sắp xếp trên một trang, rất hữu ích cho việc in tài liệu thuyết trình cho hội nghị, hội thảo và các sự kiện tương tự.

Chế độ Handout được cấu hình thông qua phương thức `setSlidesLayoutOptions`, phương thức này có sẵn trong [IPdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihtmloptions/) và [ITiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiffoptions/). Để xác định bố cục handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handoutlayoutingoptions/).

## **Xuất chế độ Handout**

Để xuất một bản thuyết trình ở chế độ Handout, thiết lập phương thức `setSlidesLayoutOptions` cho tùy chọn xuất đích và gán một thể hiện của [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handoutlayoutingoptions/) xác định số lượng slide trên mỗi trang và các tham số hiển thị liên quan.

Dưới đây là một ví dụ mã cho thấy cách chuyển đổi một bản thuyết trình sang PDF ở chế độ Handout.

```java
// Tải một bản trình chiếu.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Đặt các tùy chọn xuất.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // in số slide
    slidesLayoutOptions.setPrintFrameSlide(true);                     // in khung bao quanh slide
    slidesLayoutOptions.setPrintComments(false);                      // không có bình luận

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Xuất bản trình chiếu sang PDF với bố cục đã chọn.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Lưu ý rằng phương thức `setSlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng thumbnail slide tối đa trên một trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [các preset](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handouttype/) lên tới 9 thumbnail trên mỗi trang với thứ tự theo chiều ngang hoặc chiều dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, như 5 hoặc 8 slide trên mỗi trang không?**

Không. Số lượng và thứ tự của các thumbnail được kiểm soát chặt chẽ bởi lớp [HandoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/handouttype/); các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Bật các slide ẩn bằng cách sử dụng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng đích, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/).