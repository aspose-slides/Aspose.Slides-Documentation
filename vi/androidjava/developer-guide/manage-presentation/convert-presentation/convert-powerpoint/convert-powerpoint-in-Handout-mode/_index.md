---
title: Chuyển đổi Bài thuyết trình PowerPoint ở Chế độ Handout trên Android
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chế độ handout
- handout
- PPT
- PPTX
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình thành handout trong Java. Đặt số slide trên một trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides cho Android, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bài thuyết trình sang các định dạng khác nhau, bao gồm việc tạo handout để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide hiển thị trên một trang, hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách thiết lập phương thức `setSlidesLayoutOptions` trong các giao diện [IPdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihtmloptions/), và [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) .

## **Xuất chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handoutlayoutingoptions/) , đối tượng này xác định số slide đặt trên một trang và các tham số hiển thị khác.

Dưới đây là một ví dụ mã cho việc chuyển đổi một bản trình bày sang PDF ở chế độ Handout.

```java
// Tải một bản trình bày.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Đặt các tùy chọn xuất.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // in số slide
	slidesLayoutOptions.setPrintFrameSlide(true);                     // in khung quanh các slide
	slidesLayoutOptions.setPrintComments(false);                      // không có chú thích

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Xuất bản trình bày sang PDF với bố cục đã chọn.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 

Lưu ý rằng phương thức `setSlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.

{{% /alert %}} 

## **FAQ**

**Số lượng ảnh thu nhỏ slide tối đa trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handouttype/) lên tới 9 ảnh thu nhỏ trên mỗi trang với sắp xếp ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc), và 9 (ngang/dọc).

**Tôi có thể xác định lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên một trang không?**

Không. Số lượng và thứ tự của các ảnh thu nhỏ được kiểm soát chặt chẽ bởi lớp [HandoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handouttype/) ; các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Bật các slide ẩn bằng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng đích, chẳng hạn [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/).