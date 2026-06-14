---
title: Tạo Trình Xem Trình Chiếu trong Python
linktitle: Trình Xem Trình Chiếu
type: docs
weight: 50
url: /vi/python-net/presentation-viewer/
keywords:
- xem bản trình chiếu
- trình xem trình chiếu
- tạo trình xem trình chiếu
- xem PPT
- xem PPTX
- xem ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo một trình xem bản trình chiếu tùy chỉnh trong Python bằng Aspose.Slides. Dễ dàng hiển thị các tệp PowerPoint (PPTX, PPT) và OpenDocument (ODP) mà không cần Microsoft PowerPoint hoặc phần mềm văn phòng khác."
---
## **Giới thiệu**

Aspose.Slides for Python được sử dụng để tạo các tệp trình chiếu có các slide. Các slide này có thể được xem bằng cách mở bản trình chiếu trong Microsoft PowerPoint, ví dụ. Tuy nhiên, các nhà phát triển đôi khi cần xem các slide dưới dạng hình ảnh trong trình xem ảnh ưa thích hoặc sử dụng chúng trong một trình xem trình chiếu tùy chỉnh. Trong những trường hợp như vậy, Aspose.Slides cho phép bạn xuất các slide riêng lẻ dưới dạng hình ảnh. Bài viết này giải thích cách thực hiện.

## **Tạo hình ảnh SVG từ một Slide**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Mở một luồng tệp.
1. Lưu slide dưới dạng hình ảnh SVG vào luồng tệp.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Tạo hình ảnh thu nhỏ của Slide**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Tạo một hình ảnh thu nhỏ của slide đã tham chiếu với tỉ lệ mong muốn.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh ưa thích của bạn.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Tạo hình ảnh thu nhỏ của Slide với kích thước do người dùng xác định**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Tạo một hình ảnh thu nhỏ của slide đã tham chiếu với các kích thước được chỉ định.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh ưa thích của bạn.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Tạo hình ảnh thu nhỏ của Slide kèm ghi chú người nói**

1. Tạo một thể hiện của lớp [RenderingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/) .
1. Sử dụng thuộc tính `RenderingOptions.slides_layout_options` để đặt vị trí của ghi chú người nói.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Tạo một hình ảnh thu nhỏ của slide đã tham chiếu bằng cách sử dụng các tùy chọn render.
1. Lưu hình ảnh thu nhỏ ở định dạng ảnh ưa thích của bạn.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng miễn phí [**Aspose.Slides Viewer**](https://products.aspose.app/slides/vi/viewer/) để xem bạn có thể thực hiện gì với API Aspose.Slides:

[![Trình xem PowerPoint trực tuyến](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/vi/viewer/)

## **Câu hỏi thường gặp**

**Có thể nhúng trình xem trình chiếu trong ứng dụng web ASP.NET không?**

Bạn có thể sử dụng Aspose.Slides ở phía máy chủ để render các slide dưới dạng [hình ảnh](/slides/vi/python-net/convert-powerpoint-to-png/) hoặc [HTML](/slides/vi/python-net/convert-powerpoint-to-html/) và hiển thị chúng trong trình duyệt. Các tính năng điều hướng và phóng to có thể được triển khai bằng JavaScript để tạo trải nghiệm tương tác.

**Cách tốt nhất để hiển thị slide trong một trình xem .NET tùy chỉnh là gì?**

Phương pháp được đề xuất là render mỗi slide dưới dạng một [hình ảnh](/slides/vi/python-net/convert-powerpoint-to-png/) (ví dụ, PNG hoặc SVG) hoặc chuyển đổi nó sang [HTML](/slides/vi/python-net/convert-powerpoint-to-html/) bằng Aspose.Slides, sau đó hiển thị kết quả trong một picture box (đối với desktop) hoặc trong một container HTML (đối với web).

**Làm sao để xử lý các bản trình chiếu lớn với nhiều slide?**

Đối với các bộ trình chiếu lớn, hãy cân nhắc việc tải lười hoặc render slide khi cần. Điều này có nghĩa là chỉ tạo nội dung của slide khi người dùng chuyển đến slide đó, giảm bộ nhớ và thời gian tải.