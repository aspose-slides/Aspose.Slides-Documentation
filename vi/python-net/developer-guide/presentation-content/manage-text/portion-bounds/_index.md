---
title: Lấy giới hạn phần văn bản từ bản trình chiếu trong Python
linktitle: Giới hạn Phần
type: docs
weight: 47
url: /vi/python-net/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Python thông qua .NET."
---
## **Tổng quan**

Một phần văn bản đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy giới hạn của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi của văn bản ở mức chi tiết hơn.

Bài viết này chỉ cách lấy hình chữ nhật bao quanh một phần bằng cách sử dụng [Portion.get_rect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/get_rect/). Nó cũng chỉ cách lấy tọa độ của đầu phần bằng cách sử dụng [Portion.get_coordinates](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/get_coordinates/). Ngoài ra, nó nêu bật các kịch bản thường gặp liên quan đến phần, chẳng hạn như áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa giao diện chủ đề, và xử lý các trường hợp phông chữ được chỉ định không có sẵn.

## **Lấy Giới Hạn Của Một Phần Văn Bản**

Sử dụng [Portion.get_rect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/get_rect/) để lấy hình chữ nhật bao quanh một phần văn bản:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Lấy Tọa Độ Của Một Phần Văn Bản**

Sử dụng [Portion.get_coordinates](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/get_coordinates/) để lấy tọa độ của đầu phần văn bản:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Tôi có thể áp dụng siêu liên kết cho chỉ một phần của văn bản trong cùng một đoạn không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/python-net/manage-hyperlinks/) cho một phần riêng biệt; chỉ đoạn đó sẽ có thể nhấn được, không phải toàn bộ đoạn.

**Kế thừa kiểu dáng hoạt động như thế nào: phần ghi đè gì, và gì được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/), Aspose.Slides sẽ lấy nó từ [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/). Nếu ở đó cũng không được đặt, Aspose.Slides sẽ sử dụng kiểu dáng của [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) hoặc [theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/theme/) .

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một phần không có trên máy hoặc máy chủ đích?**

Áp dụng [Font substitution rules](/slides/vi/python-net/font-selection-sequence/). Văn bản có thể thay đổi dòng: các chỉ số, cách gạch nối và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient của phần văn bản một cách riêng biệt so với phần còn lại của đoạn không?**

Có, màu văn bản, màu nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) có thể khác với các đoạn lân cận.