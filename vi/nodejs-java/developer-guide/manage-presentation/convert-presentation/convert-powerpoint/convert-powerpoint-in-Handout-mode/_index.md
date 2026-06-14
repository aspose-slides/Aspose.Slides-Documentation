---
title: Chuyển đổi Bài thuyết trình PowerPoint ở Chế độ Handout bằng JavaScript
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chế độ handout
- tài liệu tóm tắt
- PPT
- PPTX
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi bài thuyết trình sang tài liệu tóm tắt. Đặt số slide mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides cho Node.js, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bài thuyết trình sang nhiều định dạng khác nhau, bao gồm việc tạo tài liệu tóm tắt để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide xuất hiện trên một trang, rất hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách đặt phương thức `setSlidesLayoutOptions` trong các lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/), và [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/).

## **Xuất chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handoutlayoutingoptions/), nó xác định số slide được đặt trên một trang và các tham số hiển thị khác.

Dưới đây là ví dụ mã cho thấy cách chuyển đổi một bài thuyết trình sang PDF ở chế độ Handout.

```js
// Tải một bài thuyết trình.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Đặt các tùy chọn xuất.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
slidesLayoutOptions.setPrintSlideNumbers(true);                                // in số slide
slidesLayoutOptions.setPrintFrameSlide(true);                                  // in khung bao quanh các slide
slidesLayoutOptions.setPrintComments(false);                                   // không có bình luận

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Xuất bài thuyết trình ra PDF với bố cục đã chọn.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Lưu ý rằng phương thức `setSlidesLayoutOptions` chỉ có sẵn cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **FAQ**

**Số lượng tối đa của các hình thu nhỏ slide trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handouttype/) lên tới 9 hình thu nhỏ trên mỗi trang với sắp xếp ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, ví dụ 5 hoặc 8 slide trên mỗi trang không?**

Không. Số lượng và thứ tự của các hình thu nhỏ được kiểm soát chặt chẽ bởi enumeration [HandoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handouttype/); các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Sử dụng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/).