---
title: Chuyển đổi Bài thuyết trình PowerPoint ở Chế độ Handout trên Android
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/androidjava/convert-powerpoint-in-handout-mode/
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
description: "Chuyển đổi bài thuyết trình thành phiếu handout trong Java. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides cho Android, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bài thuyết trình sang nhiều định dạng khác nhau, bao gồm tạo tài liệu phụ lục để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide hiển thị trên một trang, rất hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách thiết lập phương thức `setSlidesLayoutOptions` trong các giao diện [IPdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihtmloptions/), và [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/).

Để thiết lập kích thước và hướng của trang phụ lục trước khi xuất, xem mục [Kích thước Trang Ghi chú](/slides/vi/androidjava/notes-size/).

## **Xuất chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handoutlayoutingoptions/), đối tượng này xác định số slide được đặt trên một trang và các tham số hiển thị khác.

Dưới đây là ví dụ mã cho việc chuyển đổi bài thuyết trình sang PDF ở chế độ Handout.

```java
import com.aspose.slides.*;

// Tải một bài thuyết trình.
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

	// Xuất bài thuyết trình ra PDF với bố cục đã chọn.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Lưu ý rằng phương thức `setSlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số tối đa các hình thu nhỏ slide trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handouttype/) lên tới 9 hình thu nhỏ trên mỗi trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc), và 9 (ngang/dọc).

**Tôi có thể định nghĩa một lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên một trang không?**

Không. Số lượng và thứ tự của các hình thu nhỏ được kiểm soát chặt chẽ bởi lớp [HandoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/handouttype/); các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Bật các slide ẩn bằng cách sử dụng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/).