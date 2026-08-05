---
title: Chuyển đổi bản trình chiếu PowerPoint ở chế độ Handout trên Android
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chế độ handout
- phụ lục
- PPT
- PPTX
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi bản trình bày sang phụ lục trong Java. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides cho Android, kèm mã mẫu. Dùng thử miễn phí."
---
## **Introduction**

Aspose.Slides cung cấp khả năng chuyển đổi các bản trình bày sang nhiều định dạng khác nhau, bao gồm tạo tài liệu phụ lục để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide hiển thị trên một trang, rất hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách thiết lập phương thức `setSlidesLayoutOptions` trong các giao diện [IPdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihtmloptions/), và [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) .

## **Handout Mode Export**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handoutlayoutingoptions/) , đối tượng này xác định số slide được đặt trên một trang và các tham số hiển thị khác.

Dưới đây là một ví dụ mã cho thấy cách chuyển đổi bản trình bày sang PDF ở chế độ Handout.

```java
// Tải bản trình bày.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Đặt tùy chọn xuất.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // in số slide
	slidesLayoutOptions.setPrintFrameSlide(true);                     // in khung bao quanh các slide
	slidesLayoutOptions.setPrintComments(false);                      // không có chú thích

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Xuất bản trình bày ra PDF với bố cục đã chọn.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Lưu ý rằng phương thức `setSlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **FAQ**

**Số lượng thu nhỏ slide tối đa trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handouttype/) lên đến 9 thumbnail trên một trang với sắp xếp ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên mỗi trang không?**

Không. Số lượng và thứ tự của các thumbnail được kiểm soát chặt chẽ bởi lớp [HandoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handouttype/) ; các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Bật các slide ẩn bằng cách sử dụng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/).