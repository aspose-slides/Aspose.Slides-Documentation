---
title: Lấy toàn bộ nền slide từ bản trình bày dưới dạng hình ảnh
linktitle: Toàn bộ nền slide
type: docs
weight: 95
url: /vi/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- nền slide
- nền cuối cùng
- trích xuất nền
- toàn bộ nền
- nền thành hình ảnh
- nền PPT
- nền PPTX
- nền ODP
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Trích xuất toàn bộ nền slide dưới dạng hình ảnh từ các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java, giúp đơn giản hoá quy trình làm việc trực quan."
---
## **Tổng quan**

Trong các bản trình bày PowerPoint, nền slide có thể được tạo thành từ nhiều thành phần, bao gồm hình nền slide, chủ đề bản trình bày, bảng màu và các đối tượng được đặt trên slide mẫu hoặc slide bố cục.

Bài viết này trình bày cách trích xuất toàn bộ nền slide dưới dạng hình ảnh bằng Aspose.Slides for Python via Java. Vì không có phương pháp đơn lẻ cho nhiệm vụ này, cách tiếp cận bao gồm sao chép slide đã chọn vào một bản trình bày tạm thời, xóa các hình dạng trên slide và sau đó chuyển nền slide kết quả thành hình ảnh.

## **Lấy toàn bộ nền slide**

Aspose.Slides for Python via Java không cung cấp phương thức đơn giản để trích xuất toàn bộ nền slide của bản trình bày dưới dạng hình ảnh, nhưng bạn có thể làm theo các bước dưới đây:

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Lấy kích thước slide từ bản trình bày.
1. Chọn một slide.
1. Tạo một bản trình bày tạm thời.
1. Đặt cùng kích thước slide trong bản trình bày tạm thời.
1. Sao chép slide đã chọn vào bản trình bày tạm thời.
1. Xóa các hình dạng khỏi slide sao chép.
1. Chuyển đổi slide sao chép thành hình ảnh.

Ví dụ mã sau trích xuất toàn bộ nền slide của bản trình bày thành hình ảnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Các gradient phức tạp, kết cấu hoặc nền ảnh từ slide mẫu có được giữ nguyên trong hình ảnh nền kết quả không?**

Vâng. Aspose.Slides sẽ render các gradient, ảnh và kết cấu được định nghĩa trên slide, bố cục hoặc mẫu. Nếu bạn muốn tách biệt giao diện khỏi các mẫu kế thừa, hãy [set a custom background](/slides/vi/python-java/presentation-background/) trên slide hiện tại trước khi xuất.

**Tôi có thể thêm watermark vào hình ảnh nền kết quả trước khi lưu không?**

Vâng. Bạn có thể [add a watermark](/slides/vi/python-java/watermark/) hình hoặc ảnh vào một [copy of the slide](/slides/vi/python-java/clone-slides/) (đặt phía sau nội dung khác) rồi xuất. Điều này cho phép bạn tạo hình ảnh nền có watermark đã được tích hợp.

**Tôi có thể lấy nền cho một bố cục hoặc mẫu cụ thể mà không gắn nó vào slide hiện có không?**

Vâng. Truy cập vào mẫu hoặc bố cục mong muốn, áp dụng nó vào một [temporary slide](/slides/vi/python-java/clone-slides/) với kích thước yêu cầu, rồi xuất slide đó để lấy nền được tạo từ bố cục hoặc mẫu đó.

**Có giới hạn giấy phép nào ảnh hưởng đến xuất hình ảnh không?**

Các tính năng render có sẵn đầy đủ khi có [valid license](/slides/vi/python-java/licensing/). Khi ở chế độ đánh giá, đầu ra có thể có những hạn chế như watermark. Kích hoạt giấy phép một lần mỗi tiến trình trước khi thực hiện xuất hàng loạt.