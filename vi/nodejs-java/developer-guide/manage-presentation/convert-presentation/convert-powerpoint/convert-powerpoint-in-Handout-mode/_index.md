---
title: Chuyển đổi bản trình chiếu PowerPoint ở chế độ Handout bằng JavaScript
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chế độ handout
- handout
- PPT
- PPTX
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu thành handout. Đặt số slide trên mỗi trang, giữ chú thích, xuất ra PDF hoặc hình ảnh với Aspose.Slides cho Node.js, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bản trình bày sang nhiều định dạng, bao gồm tạo tài liệu phụ đề để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide hiển thị trên một trang, rất hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách thiết lập phương thức `setSlidesLayoutOptions` trong các lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/), và [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) .

Để đặt kích thước và hướng trang handout trước khi xuất, xem [Notes Page Size](/slides/vi/nodejs-java/notes-size/) .

## **Xuất chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handoutlayoutingoptions/) , nó xác định số slide được đặt trên một trang và các tham số hiển thị khác.

Dưới đây là ví dụ mã cho thấy cách chuyển đổi một bản trình bày sang PDF ở chế độ Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// Tải một bản trình chiếu.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Đặt các tùy chọn xuất.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
slidesLayoutOptions.setPrintSlideNumbers(true);                                // in số slide
slidesLayoutOptions.setPrintFrameSlide(true);                                  // in khung quanh các slide
slidesLayoutOptions.setPrintComments(false);                                   // không có bình luận

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Xuất bản trình chiếu sang PDF với bố cục đã chọn.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
Hãy nhớ rằng phương thức `setSlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng ảnh thu nhỏ slide tối đa trên một trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handouttype/) lên tới 9 ảnh thu nhỏ trên một trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/ dọc), 6 (ngang/ dọc) và 9 (ngang/ dọc) .

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên một trang không?**

Không. Số lượng và thứ tự của ảnh thu nhỏ được điều khiển chặt chẽ bởi enumeration [HandoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handouttype/) ; các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Sử dụng phương thức `setShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) .