---
title: Thay đổi kích thước hình dạng trên các slide bài thuyết trình trong Python qua Java
type: docs
weight: 110
url: /vi/python-java/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên các slide PowerPoint và OpenDocument với Aspose.Slides cho Python qua Java—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Một trong những câu hỏi phổ biến nhất từ khách hàng Aspose.Slides for Python via Java là làm sao để thay đổi kích thước các hình dạng sao cho khi kích thước slide thay đổi, dữ liệu không bị cắt mất. Bài viết kỹ thuật ngắn này chỉ ra cách thực hiện.

## **Thay đổi kích thước hình dạng**

Để ngăn các hình dạng bị lệch khi kích thước slide thay đổi, cập nhật vị trí và kích thước của mỗi hình dạng để chúng phù hợp với bố cục slide mới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Tải tệp bài thuyết trình.
presentation = Presentation("sample.ppt")
try:
    # Lấy kích thước slide gốc.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Thay đổi kích thước slide mà không tỷ lệ các hình dạng hiện có.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Lấy kích thước slide mới.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Thay đổi kích thước và vị trí các hình dạng trên mỗi slide.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Lưu ý" %}} 

Bảng không cần xử lý đặc biệt: việc đặt chiều rộng và chiều cao cho bảng sẽ tự động tỷ lệ lại các cột và hàng, vì vậy việc lại tỷ lệ chiều cao hàng và chiều rộng cột sẽ áp dụng tỷ lệ hai lần.

{{% /alert %}} 

Mã trên chỉ thay đổi các hình dạng trên các slide. Các master slide và layout slide giữ các hình dạng riêng, vì vậy hãy mở rộng chúng nữa khi bạn muốn toàn bộ bài thuyết trình tuân theo kích thước slide mới:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Lấy kích thước slide gốc.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Thay đổi kích thước slide mà không tỷ lệ các hình dạng hiện có.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Lấy kích thước slide mới.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Tỷ lệ kích thước hình dạng.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Tỷ lệ vị trí hình dạng.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt khi thay đổi kích thước slide?**

Khi thay đổi kích thước slide, các hình dạng giữ nguyên vị trí và kích thước gốc trừ khi tỷ lệ được thay đổi một cách rõ ràng. Điều này có thể dẫn đến nội dung bị cắt hoặc các hình dạng bị lệch.

**Mã được cung cấp có hoạt động cho mọi loại hình dạng không?**

Có. Việc đặt chiều cao và chiều rộng hoạt động cho hộp văn bản, hình ảnh, biểu đồ và bảng đều tương tự.

**Làm sao để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Mở rộng hình dạng bảng như bất kỳ hình dạng nào khác. Các hàng và cột sẽ theo tỷ lệ một cách tự động, vì vậy không cần mở rộng chúng lại sau đó.

**Việc thay đổi kích thước này có áp dụng cho master slide và layout slide không?**

Có, nhưng bạn cũng nên duyệt qua [Presentation.getMasters](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasters) và [Presentation.getLayoutSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getLayoutSlides) và áp dụng cùng logic mở rộng cho các hình dạng của chúng để đảm bảo tính nhất quán trong toàn bộ bài thuyết trình.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Bạn có thể sử dụng [SlideSize.setOrientation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesize/#setOrientation) để thay đổi hướng. Đảm bảo điều chỉnh logic mở rộng cho phù hợp để giữ nguyên bố cục.

**Có giới hạn nào cho kích thước slide mà tôi có thể đặt không?**

Aspose.Slides hỗ trợ kích thước tùy chỉnh, nhưng kích thước quá lớn có thể ảnh hưởng đến hiệu năng hoặc khả năng tương thích với một số phiên bản PowerPoint.

**Làm thế nào để ngăn các hình dạng có tỷ lệ khung hình cố định bị biến dạng?**

Bạn có thể kiểm tra phương thức [getAspectRatioLocked](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) của khóa hình dạng trước khi mở rộng. Nếu nó được khóa, hãy điều chỉnh chiều rộng hoặc chiều cao một cách tỷ lệ thay vì mở rộng từng phần riêng lẻ.