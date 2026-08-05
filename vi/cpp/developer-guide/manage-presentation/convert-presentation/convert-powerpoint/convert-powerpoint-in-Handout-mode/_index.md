---
title: "Chuyển đổi bản trình chiếu PowerPoint sang chế độ Handout bằng C++"
linktitle: "Chế độ Handout"
type: docs
weight: 150
url: /vi/cpp/convert-powerpoint-in-handout-mode/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bản trình chiếu"
- "chế độ handout"
- "bản in tay"
- "PPT"
- "PPTX"
- "PowerPoint"
- "bản trình chiếu"
- "C++"
- "Aspose.Slides"
description: "Chuyển đổi bản trình chiếu thành bản in tay bằng C++. Đặt số slide trên mỗi trang, giữ ghi chú, xuất ra PDF hoặc hình ảnh với Aspose.Slides, kèm mã mẫu. Dùng thử miễn phí."
---
## **Giới thiệu**

Aspose.Slides cung cấp khả năng chuyển đổi bản trình chiếu sang các định dạng khác nhau, bao gồm việc tạo bản in tay cho chế độ Handout. Chế độ này cho phép bạn cấu hình cách nhiều slide xuất hiện trên một trang, rất hữu ích cho hội nghị, hội thảo và các sự kiện khác. Bạn có thể bật chế độ này bằng cách thiết lập phương thức `set_SlidesLayoutOptions` trong các giao diện [IPdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ihtmloptions/), và [ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/).

## **Xuất chế độ Handout**

Để cấu hình chế độ Handout, sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handoutlayoutingoptions/) để xác định số slide đặt trên một trang và các tham số hiển thị khác.

Dưới đây là ví dụ mã cho việc chuyển đổi bản trình chiếu sang PDF ở chế độ Handout.

```cpp
// Tải bản trình chiếu.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Đặt các tùy chọn xuất.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slide trên một trang theo chiều ngang
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // in số slide
slidesLayoutOptions->set_PrintFrameSlide(true);                      // in khung quanh các slide
slidesLayoutOptions->set_PrintComments(false);                       // không có chú thích

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Xuất bản trình chiếu ra PDF với bố cục đã chọn.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Hãy nhớ rằng phương thức `set_SlidesLayoutOptions` chỉ có sẵn cho một số định dạng đầu ra nhất định, như PDF, HTML, TIFF và khi render dưới dạng hình ảnh. 
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Số lượng tối đa các hình thu nhỏ slide trên một trang trong chế độ Handout là bao nhiêu?**

Aspose.Slides hỗ trợ [presets](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handouttype/) lên đến 9 hình thu nhỏ trên mỗi trang với sắp xếp ngang hoặc dọc: 1, 2, 3, 4 (ngang/dọc), 6 (ngang/dọc), và 9 (ngang/dọc).

**Tôi có thể định nghĩa một lưới tùy chỉnh, chẳng hạn 5 hoặc 8 slide trên một trang không?**

Không. Số lượng và thứ tự của các hình thu nhỏ được kiểm soát chặt chẽ bởi enumeration [HandoutType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/handouttype/); các bố cục tùy ý không được hỗ trợ.

**Tôi có thể bao gồm các slide ẩn trong đầu ra Handout không?**

Có. Sử dụng phương thức `set_ShowHiddenSlides` trong cài đặt xuất cho định dạng mục tiêu, chẳng hạn [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/), hoặc [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/).