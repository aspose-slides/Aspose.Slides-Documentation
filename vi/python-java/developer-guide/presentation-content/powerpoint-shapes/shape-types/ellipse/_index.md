---
title: Thêm Elip vào Bài Thuyết Trình trong Python qua Java
linktitle: Elip
type: docs
weight: 30
url: /vi/python-java/ellipse/
keywords:
- elip
- hình dạng
- thêm elip
- tạo elip
- vẽ elip
- elip đã định dạng
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác các hình elip trong Aspose.Slides cho Python qua Java trên các bản trình bày PPT và PPTX—kèm ví dụ mã Python."
---
## **Tổng quan**

Bài viết này hướng dẫn cách thêm các hình ellipse vào các slide PowerPoint bằng Aspose.Slides. Nó bao gồm việc tạo một ellipse đơn giản, tạo một ellipse có định dạng, và lưu bản trình bày đã cập nhật thành tệp PPTX. Ngoài ra còn đề cập đến các câu hỏi liên quan như làm việc với vị trí và kích thước của ellipse, kiểm soát thứ tự xếp chồng, và áp dụng hiệu ứng hoạt ảnh.

## **Tạo ellipse**

Để thêm một ellipse đơn giản vào một slide đã chọn của bản trình bày, thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Lấy tham chiếu đến slide theo chỉ mục của nó.
- Thêm một ellipse bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) của đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/).
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Ví dụ sau thêm một ellipse vào slide đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình elip.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Ghi tệp PPTX ra đĩa.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tạo ellipse đã định dạng**

Để thêm một ellipse đã định dạng vào một slide, thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Lấy tham chiếu đến slide theo chỉ mục của nó.
- Thêm một ellipse bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) của đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/).
- Đặt kiểu tô của ellipse thành đặc.
- Đặt màu tô của ellipse thông qua [getSolidFillColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getSolidFillColor) trên đối tượng [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/) liên kết với đối tượng [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/).
- Đặt màu viền của ellipse.
- Đặt độ rộng của viền ellipse.
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Ví dụ sau thêm một ellipse đã định dạng vào slide đầu tiên của bài thuyết trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình elip.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Định dạng màu nền của elip.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Định dạng đường viền của elip.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Ghi tệp PPTX ra đĩa.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đặt vị trí và kích thước chính xác của một ellipse dựa trên đơn vị của slide?**

Các tọa độ và kích thước thường được chỉ định **theo điểm**. Để có kết quả dự đoán được, hãy tính toán dựa trên kích thước slide và chuyển đổi milimet hoặc inch cần thiết thành điểm trước khi gán giá trị.

**Làm sao tôi có thể đặt một ellipse lên trên hoặc dưới các đối tượng khác (kiểm soát thứ tự xếp chồng)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên trước hoặc gửi nó xuống phía sau. Điều này cho phép ellipse chồng lên các đối tượng khác hoặc hiển thị các đối tượng ở dưới nó.

**Làm sao tôi có thể tạo hoạt ảnh cho sự xuất hiện hoặc nhấn mạnh của một ellipse?**

[Áp dụng](/slides/vi/python-java/shape-animation/) hiệu ứng nhập, nhấn mạnh hoặc thoát cho hình, và cấu hình trình kích hoạt cũng như thời gian để điều khiển khi nào và cách hoạt ảnh được phát.