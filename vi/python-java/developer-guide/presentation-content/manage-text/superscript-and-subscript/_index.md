---
title: Quản lý chỉ số trên và chỉ số dưới trong bản trình chiếu bằng Python qua Java
linktitle: Chỉ số trên và chỉ số dưới
type: docs
weight: 80
url: /vi/python-java/superscript-and-subscript/
keywords:
- chỉ số trên
- chỉ số dưới
- thêm chỉ số trên
- thêm chỉ số dưới
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Làm chủ chỉ số trên và chỉ số dưới trong Aspose.Slides cho Python qua Java và nâng cao bản trình chiếu của bạn với định dạng văn bản chuyên nghiệp để đạt hiệu quả tối đa."
---
## **Tổng quan**

Aspose.Slides cung cấp các tính năng để tích hợp văn bản chỉ số trên và chỉ số dưới vào các bản trình chiếu PowerPoint (PPT, PPTX) và OpenDocument (ODP). Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học, hay chú thích nội dung bằng chú thích chân trang, các tùy chọn định dạng chuyên biệt này giúp duy trì độ rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng phong cách chỉ số trên và chỉ số dưới một cách liền mạch và đảm bảo kết quả chuyên nghiệp cho mỗi slide.

## **Quản lý Văn bản Chỉ số trên và Chỉ số dưới**

Bạn có thể thêm văn bản chỉ số trên và chỉ số dưới vào bất kỳ phần nào của đoạn văn. Để áp dụng định dạng này trong khung văn bản Aspose.Slides, hãy sử dụng phương thức [setEscapement](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#setEscapement) của lớp [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/).

Giá trị escapement nằm trong khoảng từ -100% (chỉ số dưới) đến 100% (chỉ số trên). Ví dụ:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Lấy một slide theo chỉ mục của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) loại [ShapeType.Rectangle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#Rectangle) vào slide.
- Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) liên kết với [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).
- Xóa các đoạn văn hiện có.
- Tạo một đoạn văn để chứa văn bản chỉ số trên và thêm nó vào [bộ sưu tập đoạn](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParagraphs) của khung văn bản.
- Tạo một phần.
- Sử dụng [setEscapement](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#setEscapement) để đặt giá trị từ 0 đến 100 cho chỉ số trên (0 có nghĩa là không có chỉ số trên).
- Đặt văn bản của [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) và thêm nó vào bộ sưu tập phần của đoạn văn.
- Tạo một đoạn văn để chứa văn bản chỉ số dưới và thêm nó vào [bộ sưu tập đoạn](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParagraphs) của khung văn bản.
- Tạo một phần.
- Sử dụng [setEscapement](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#setEscapement) để đặt giá trị từ -100 đến 0 cho chỉ số dưới (0 có nghĩa là không có chỉ số dưới).
- Đặt văn bản của [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) và thêm nó vào bộ sưu tập phần của đoạn văn.
- Lưu bản trình bày dưới dạng tệp PPTX.

Ví dụ sau triển khai các bước này:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Tạo một bản trình chiếu.
presentation = Presentation()
try:
    # Lấy slide.
    slide = presentation.getSlides().get_Item(0)

    # Tạo một hộp văn bản.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Tạo một đoạn văn cho văn bản chỉ số trên.
    superscript_paragraph = Paragraph()

    # Tạo một phần với văn bản bình thường.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Tạo một phần với văn bản chỉ số trên.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Tạo một đoạn văn cho văn bản chỉ số dưới.
    subscript_paragraph = Paragraph()

    # Tạo một phần với văn bản bình thường.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Tạo một phần với văn bản chỉ số dưới.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Thêm các đoạn văn vào hộp văn bản.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Chỉ số trên và chỉ số dưới có được giữ lại khi xuất sang PDF hoặc các định dạng khác không?**

Có, Aspose.Slides giữ nguyên định dạng chỉ số trên và chỉ số dưới khi xuất bản trình chiếu sang PDF, PPT/PPTX, hình ảnh và các định dạng được hỗ trợ khác. Định dạng chuyên biệt vẫn còn nguyên vẹn trong mọi tệp đầu ra.

**Chỉ số trên và chỉ số dưới có thể kết hợp với các kiểu định dạng khác như in đậm hoặc in nghiêng không?**

Có, Aspose.Slides cho phép bạn kết hợp nhiều kiểu văn bản trong cùng một phần văn bản. Bạn có thể bật in đậm, in nghiêng, gạch chân và đồng thời áp dụng chỉ số trên hoặc chỉ số dưới bằng cách cấu hình các thuộc tính tương ứng trong [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/).

**Định dạng chỉ số trên và chỉ số dưới có hoạt động cho văn bản trong bảng, biểu đồ hoặc SmartArt không?**

Có, Aspose.Slides hỗ trợ định dạng trong hầu hết các đối tượng, bao gồm các thành phần bảng và biểu đồ. Khi làm việc với SmartArt, bạn cần truy cập các phần tử thích hợp (chẳng hạn như [SmartArtNode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/)) và các vùng chứa văn bản của chúng, sau đó cấu hình các thuộc tính của [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/) theo cách tương tự.