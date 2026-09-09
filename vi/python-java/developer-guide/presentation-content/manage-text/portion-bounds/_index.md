---
title: Lấy Giới Hạn Phần Văn Bản từ Bài Thuyết Trình trong Python qua Java
linktitle: Giới Hạn Phần
type: docs
weight: 47
url: /vi/python-java/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- phần văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong các bài thuyết trình PowerPoint bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Một phần văn bản đại diện cho một đoạn văn bản cụ thể trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy giới hạn của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này mô tả cách lấy hình chữ nhật bao quanh của một phần bằng cách sử dụng [Portion.getRect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getRect). Nó cũng chỉ ra cách lấy tọa độ của phần đầu của một phần bằng cách sử dụng [Portion.getCoordinates](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getCoordinates). Ngoài ra, bài viết còn nêu bật các tình huống thường gặp liên quan đến phần, chẳng hạn như áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa chủ đề, và xử lý các trường hợp phông chữ được chỉ định không có sẵn.

## **Lấy giới hạn của một phần văn bản**

Sử dụng [Portion.getRect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getRect) để lấy hình chữ nhật bao quanh của một phần văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Lấy tọa độ của một phần văn bản**

Sử dụng [Portion.getCoordinates](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getCoordinates) để lấy tọa độ của phần đầu của một phần văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/python-java/manage-hyperlinks/) cho một phần riêng biệt; chỉ đoạn văn bản đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Cơ chế kế thừa kiểu dáng hoạt động như thế nào: một phần ghi đè gì, và gì được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính ở cấp độ Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/), Aspose.Slides sẽ lấy nó từ [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/). Nếu cũng không được đặt ở đó, Aspose.Slides sẽ sử dụng kiểu dạng của [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) hoặc [theme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/theme/) .

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một phần không có trên máy hoặc máy chủ mục tiêu?**

[Các quy tắc thay thế phông chữ](/slides/vi/python-java/font-selection-sequence/) được áp dụng. Văn bản có thể tái bố trí: các chỉ số, cách ngắt từ và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient của phần tô màu chữ riêng cho một phần mà không ảnh hưởng đến các phần còn lại của đoạn không?**

Có, màu chữ, màu nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) có thể khác nhau so với các đoạn liền kề.