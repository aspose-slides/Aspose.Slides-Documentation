---
title: Chuyển đổi bài thuyết trình PowerPoint sang chế độ Handout bằng PHP
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chế độ handout
- tài liệu phát tay
- PPT
- PPTX
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Chuyển đổi bài thuyết trình sang tài liệu phát tay trong PHP. Định dạng số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides cho PHP, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bài thuyết trình sang các định dạng khác nhau, bao gồm việc tạo tài liệu phát tay để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide hiển thị trên một trang, rất hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách thiết lập phương thức `setSlidesLayoutOptions` trong các lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/), và [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/) .

## **Xuất chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/handoutlayoutingoptions/) , mà xác định số slide được đặt trên một trang và các tham số hiển thị khác.

Dưới đây là một ví dụ mã cho thấy cách chuyển đổi một bài thuyết trình sang PDF ở chế độ Handout.

```php
// Tải một bài thuyết trình.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // in số slide
$slidesLayoutOptions->setPrintFrameSlide(true);                      // in khung quanh các slide
$slidesLayoutOptions->setPrintComments(false);                       // không có bình luận

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Xuất bài thuyết trình sang PDF với bố cục đã chọn.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Lưu ý rằng phương thức `setSlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi kết xuất dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng hình thu nhỏ slide tối đa trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [các cài đặt trước](https://reference.aspose.com/slides/vi/php-java/aspose.slides/handouttype/) lên tới 9 hình thu nhỏ trên mỗi trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên mỗi trang không?**

Không. Số lượng và thứ tự của các hình thu nhỏ được kiểm soát chặt chẽ bởi lớp [HandoutType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/handouttype/) , các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm slide ẩn trong đầu ra Handout không?**

Có. Bật các slide ẩn bằng cách sử dụng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/).