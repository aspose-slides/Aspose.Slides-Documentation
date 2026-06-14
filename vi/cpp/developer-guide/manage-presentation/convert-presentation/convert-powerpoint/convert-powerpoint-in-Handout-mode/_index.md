---
title: Chuyển đổi bài thuyết trình PowerPoint ở chế độ Handout bằng C++
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chế độ handout
- phát tay
- PPT
- PPTX
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Chuyển đổi bài thuyết trình thành phát tay trong C++. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bài thuyết trình sang nhiều định dạng khác nhau, bao gồm việc tạo tài liệu phát tay để in ở chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide xuất hiện trên một trang, rất hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách thiết lập phương thức `set_SlidesLayoutOptions` trong các giao diện [IPdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ihtmloptions/) và [ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/).

## **Xuất chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handoutlayoutingoptions/) , đối tượng này xác định số slide được đặt trên một trang và các tham số hiển thị khác.

Dưới đây là ví dụ mã cho thấy cách chuyển đổi một bài thuyết trình sang PDF ở chế độ Handout.

```cpp
// Tải một bài thuyết trình.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // in số slide
slidesLayoutOptions->set_PrintFrameSlide(true);                      // in khung bao quanh các slide
slidesLayoutOptions->set_PrintComments(false);                       // không có bình luận

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Xuất bài thuyết trình ra PDF với bố cục đã chọn.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 

Lưu ý rằng phương thức `set_SlidesLayoutOptions` chỉ khả dụng cho một số định dạng đầu ra nhất định, chẳng hạn như PDF, HTML, TIFF, và khi render dưới dạng hình ảnh.

{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng tối đa các hình thu nhỏ của slide trên mỗi trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handouttype/) lên tới 9 hình thu nhỏ trên mỗi trang với thứ tự ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc) và 9 (ngang/dọc).

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên một trang không?**

Không. Số lượng và thứ tự các hình thu nhỏ được kiểm soát chặt chẽ bởi enumeration [HandoutType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handouttype/) ; các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Sử dụng phương thức `set_ShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn như [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/).