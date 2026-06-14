---
title: Quản lý các phần văn bản trong bản trình chiếu bằng Python
linktitle: Phần Văn bản
type: docs
weight: 70
url: /vi/python-net/portion/
keywords:
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý các phần văn bản trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET, nâng cao hiệu suất và khả năng tùy chỉnh."
---
## **Giới thiệu**

Một phần văn bản đại diện cho một đoạn cụ thể của văn bản trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy vị trí của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

## **Lấy tọa độ của các phần văn bản**

Phương thức [get_coordinates](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/get_coordinates/) đã được thêm vào lớp [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) cho phép lấy tọa độ của các phần văn bản:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Bạn có thể áp dụng siêu liên kết cho chỉ một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [assign a hyperlink](/slides/vi/python-net/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn đó sẽ có thể nhấp được, không phải toàn bộ đoạn.

**Cơ chế kế thừa kiểu dáng hoạt động như thế nào: phần Portion ghi đè gì và gì được lấy từ Paragraph/TextFrame?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/), công cụ sẽ lấy từ [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/); nếu ở đó cũng không có, sẽ lấy từ [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) hoặc kiểu dáng [theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/theme/).

**Nếu phông chữ được chỉ định cho một Portion không có trên máy/ máy chủ mục tiêu thì sẽ xảy ra gì?**

[Font substitution rules](/slides/vi/python-net/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể được tái bố trí: các chỉ số đo, cách gạch nối và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient màu nền cho văn bản ở mức Portion mà không ảnh hưởng đến phần còn lại của đoạn không?**

Có, màu văn bản, màu nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) có thể khác nhau so với các phần lân cận.