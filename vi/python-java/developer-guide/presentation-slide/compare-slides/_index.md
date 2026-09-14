---
title: So sánh các slide trình chiếu trong Python
linktitle: So sánh Slide
type: docs
weight: 50
url: /vi/python-java/compare-slides/
keywords:
- so sánh slide
- so sánh slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "So sánh các bài thuyết trình PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho Python thông qua Java. Xác định nhanh các khác biệt của slide trong mã."
---
## **Tổng quan**

Aspose.Slides cho phép bạn so sánh các slide, slide bố cục và slide chủ đề bằng cách sử dụng phương thức [equals](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#equals) được cung cấp bởi lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/). Phương thức này trả về `True` khi các slide được so sánh hoàn toàn giống nhau về cấu trúc và nội dung tĩnh.

## **So sánh Hai Slide**

Phương thức [equals](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#equals) trong lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/) trả về `True` cho các slide, slide bố cục và slide chủ đề có cấu trúc và nội dung tĩnh giống hệt nhau.

Hai slide được coi là bằng nhau nếu tất cả các hình dạng, kiểu dáng, văn bản, hoạt ảnh và các thiết lập khác của chúng cũng bằng nhau. Việc so sánh không tính đến các giá trị định danh duy nhất, chẳng hạn như ID slide, hoặc nội dung động, như ngày hiện tại trong trình giữ chỗ ngày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Câu hỏi thường gặp**

**Việc một slide bị ẩn có ảnh hưởng tới việc so sánh các slide hay không?**

Trạng thái ẩn là thuộc tính ở mức trình chiếu/đặt phát, không phải nội dung hình ảnh. Độ bằng nhau của hai slide cụ thể được xác định bởi cấu trúc và nội dung tĩnh của chúng; việc một slide bị ẩn không làm cho các slide trở nên khác nhau.

**Liệu các siêu liên kết và các tham số của chúng có được tính đến không?**

Đúng. Các liên kết là một phần của nội dung tĩnh của slide. Nếu URL hoặc hành động siêu liên kết khác nhau, điều này thường được xem là sự khác nhau trong nội dung tĩnh.

**Nếu một biểu đồ tham chiếu tới tệp Excel bên ngoài, nội dung của tệp đó có được tính đến không?**

Không. Việc so sánh được thực hiện dựa trên chính các slide. Các nguồn dữ liệu bên ngoài thường không được đọc vào thời điểm so sánh; chỉ những gì có trong cấu trúc và trạng thái tĩnh của slide được xem xét.