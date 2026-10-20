---
title: "Thay đổi kích thước các hình dạng trên slide của bản trình chiếu trong Python qua Java"
type: docs
weight: 110
url: /vi/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /vi/python-java/re-sizing-shapes-on-slide/
keywords:
- "thay đổi kích thước hình dạng"
- "thay đổi kích thước hình"
- PowerPoint
- OpenDocument
- "bản trình chiếu"
- Python
- Java
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument với Aspose.Slides cho Python qua Java—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Khi bạn thay đổi kích thước slide của bản trình chiếu, bạn có thể cũng cần thay đổi kích thước và vị trí lại các hình dạng để phù hợp với kích thước mới. Bài viết này giới thiệu cách thu phóng các hình dạng một cách thủ công và cách xử lý bảng trên slide, master và layout.

## **Thay đổi kích thước hình dạng**

Để giữ nguyên vị trí và kích thước tương đối của mỗi hình dạng, hãy nhân tọa độ ngang và chiều rộng của nó với tỉ lệ giữa chiều rộng slide mới và chiều rộng gốc. Áp dụng tỉ lệ chiều cao tương ứng cho các tọa độ dọc và chiều cao của nó.

Ví dụ đầu tiên tải một bản trình chiếu mà các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) với [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) để vòng lặp tiếp theo kiểm soát việc thu phóng. Các tỉ lệ không có đơn vị; vị trí và kích thước của hình dạng được đo bằng point. Các tỉ lệ chiều rộng và chiều cao khác nhau có thể làm biến dạng hình dạng, và việc thay đổi kích thước của hình dạng không làm thu phóng kích thước phông chữ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Tính các hệ số thu phóng ngang và dọc độc lập.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Bảng yêu cầu xử lý riêng: thu phóng độ rộng cột và chiều cao hàng thay vì gán độ rộng và chiều cao tổng thể của bảng. Chiều cao hàng có thể vẫn lớn hơn yêu cầu nếu nội dung ô yêu cầu nhiều không gian hơn.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ bảng và xử lý các hình dạng trên master và layout cũng như các slide riêng lẻ trước khi lưu bản trình chiếu đã thu phóng. Trợ giúp của nó xử lý mỗi [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) bằng cách thu phóng độ rộng cột với [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) và chiều cao tối thiểu của hàng với [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Sau đó, nó thu phóng vị trí của bảng mà không thu phóng riêng các kích thước tổng thể của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Kích thước bảng được kiểm soát bởi độ rộng cột và chiều cao hàng.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Tính các hệ số thu phóng ngang và dọc độc lập.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Thay đổi kích thước các hình dạng được định nghĩa trên master và layout cũng như các slide riêng lẻ.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**  
Nếu bạn thay đổi kích thước slide mà không thu phóng các hình dạng, chúng sẽ giữ nguyên vị trí và kích thước gốc và có thể vượt ra ngoài slide. Việc thu phóng chiều rộng và chiều cao bằng các tỉ lệ khác nhau cũng có thể làm biến dạng hình dạng.

**Mã cung cấp có hoạt động cho tất cả các loại hình dạng không?**  
Ví dụ đầu tiên thay đổi giới hạn của hình dạng trực tiếp và được thiết kế cho các slide không có bảng. Ví dụ thứ hai xử lý bảng riêng biệt. Kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì những ví dụ này không thu phóng kích thước phông chữ và nội dung bảng có thể hạn chế chiều cao hàng.

**Làm sao tôi có thể thay đổi kích thước bảng khi thay đổi kích thước slide?**  
Thu phóng độ rộng cột bằng tỉ lệ chiều rộng và chiều cao tối thiểu của hàng bằng tỉ lệ chiều cao, sau đó thu phóng vị trí của bảng, như đã minh họa trong ví dụ thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các master slide và layout slide không?**  
Có. Ví dụ thứ hai lặp qua [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) và các [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) của mỗi master và áp dụng cùng logic thay đổi kích thước cho các hình dạng của chúng.

**Tôi có thể thay đổi hướng của slide (portrait/landscape) cùng với việc thay đổi kích thước không?**  
Có. Gọi [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) sau khi thay đổi kích thước slide và trước khi đọc các kích thước mục tiêu, để các hệ số thu phóng phản ánh hướng cuối cùng.

**Có giới hạn nào cho kích thước slide tôi có thể đặt không?**  
Bạn có thể chỉ định kích thước slide tùy chỉnh bằng [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Các kích thước được hỗ trợ cũng phụ thuộc vào định dạng bản trình chiếu và ứng dụng được dùng để mở tệp.

**Làm sao tôi có thể ngăn các hình dạng có tỷ lệ khung cố định bị biến dạng?**  
Sử dụng cùng một hệ số thu phóng cho chiều rộng và chiều cao. Để vừa bố cục gốc trong kích thước slide mới, hãy dùng tỉ lệ nhỏ hơn giữa tỉ lệ chiều rộng và chiều cao cho cả hai chiều và vị trí. Điều này giữ nguyên tỉ lệ nhưng có thể để lại không gian trống ở một cạnh.