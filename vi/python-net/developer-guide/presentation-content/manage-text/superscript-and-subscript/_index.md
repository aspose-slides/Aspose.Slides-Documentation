---
title: Quản lý Siêu Chỉ Số và Chỉ Số Dưới trong Python
linktitle: Siêu Chỉ Số và Chỉ Số Dưới
type: docs
weight: 80
url: /vi/python-net/superscript-and-subscript/
keywords:
- siêu chỉ số
- chỉ số dưới
- thêm siêu chỉ số
- thêm chỉ số dưới
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Làm chủ siêu chỉ số và chỉ số dưới trong Aspose.Slides cho Python qua .NET và nâng cao các bản trình bày của bạn với định dạng văn bản chuyên nghiệp để đạt hiệu quả tối đa."
---
## **Overview**

Aspose.Slides cung cấp các tính năng để tích hợp văn bản siêu chỉ số và chỉ số dưới vào các bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) của bạn. Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học, hay chú thích nội dung bằng chú thích chân trang, những tùy chọn định dạng chuyên biệt này giúp duy trì độ rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng phong cách siêu chỉ số và chỉ số dưới một cách liền mạch và đảm bảo kết quả chuyên nghiệp trên mỗi slide.

## **Add Superscript and Subscript Text**

Bạn có thể thêm văn bản siêu chỉ số và chỉ số dưới vào bất kỳ phần đoạn văn nào. Trong Aspose.Slides, sử dụng thuộc tính `escapement` của lớp [PortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/) để điều khiển điều này.

`escapement` là một phần trăm từ **-100% to 100%**:

- **> 0** → siêu chỉ số (ví dụ, 25% = tăng nhẹ; 100% = siêu chỉ số đầy đủ)
- **0** → đường cơ bản (không có siêu/chỉ số dưới)
- **< 0** → chỉ số dưới (ví dụ, -25% = hạ nhẹ; -100% = chỉ số dưới đầy đủ)

Steps:

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và lấy một slide.
1. Thêm một hình chữ nhật [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) và truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của nó.
1. Xóa các đoạn văn hiện có.
1. Đối với siêu chỉ số: tạo một đoạn văn và một phần, đặt `portion.portion_format.escapement` thành giá trị từ **0 đến 100**, đặt văn bản, và thêm phần đó.
1. Đối với chỉ số dưới: tạo một đoạn văn và phần khác, đặt `escapement` thành giá trị từ **-100 đến 0**, đặt văn bản, và thêm phần đó.
1. Lưu bản trình bày dưới dạng PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Lấy một slide.
    slide = presentation.slides[0]

    # Tạo một hộp văn bản.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Tạo một đoạn văn cho văn bản siêu chỉ số.
    superscript_paragraph = slides.Paragraph()

    # Tạo một phần văn bản với văn bản thường.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Tạo một phần văn bản với văn bản siêu chỉ số.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Tạo một đoạn văn cho văn bản chỉ số dưới.
    subscript_paragraph = slides.Paragraph()

    # Tạo một phần văn bản với văn bản thường.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Tạo một phần văn bản với văn bản chỉ số dưới.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Thêm các đoạn văn vào hộp văn bản.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Tôi có thể áp dụng siêu chỉ số/chỉ số dưới trong bảng và các container khác, không chỉ trong các hộp văn bản thông thường không?**

Có. Bạn có thể định dạng văn bản thành siêu chỉ số hoặc chỉ số dưới bên trong bất kỳ đối tượng nào có [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) (bao gồm các ô bảng). Định dạng sẽ áp dụng cho các phần văn bản trong khung đó.

**Siêu chỉ số/chỉ số dưới có được giữ nguyên khi xuất ra PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides giữ định dạng siêu chỉ số/chỉ số dưới khi xuất ra các định dạng phổ biến như [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), và [raster images](/slides/vi/python-net/convert-powerpoint-to-png/) vì quy trình render tôn trọng định dạng văn bản ở mức phần.

**Tôi có thể kết hợp siêu chỉ số/chỉ số dưới với siêu liên kết trong cùng một đoạn văn bản không?**

Có. [Hyperlinks](/slides/vi/python-net/manage-hyperlinks/) được gán ở mức phần (fragment), vì vậy một phần có thể đồng thời có siêu liên kết và được định dạng là siêu chỉ số hoặc chỉ số dưới.