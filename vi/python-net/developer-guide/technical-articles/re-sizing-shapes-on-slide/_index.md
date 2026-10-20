---
title: Thay đổi kích thước hình dạng trên slide bản trình chiếu bằng Python
type: docs
weight: 130
url: /vi/python-net/resizing-shapes-on-slide/
aliases:
  - /vi/python-net/re-sizing-shapes-on-slide/
keywords:
- điều chỉnh kích thước hình dạng
- thay đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument với Aspose.Slides cho Python thông qua .NET—tự động điều chỉnh bố cục slide và nâng cao năng suất."
---
## **Tổng quan**

Khi bạn thay đổi kích thước slide của bản trình chiếu, bạn cũng có thể cần thay đổi kích thước và vị trí lại các hình dạng để phù hợp với kích thước mới. Bài viết này hướng dẫn cách tự động mở rộng các hình dạng theo cách thủ công và cách xử lý bảng trên slide, master và layout.

## **Thay đổi kích thước hình dạng**

Để giữ nguyên vị trí và kích thước tương đối của từng hình dạng, nhân các tọa độ ngang và chiều rộng của nó với tỷ lệ giữa chiều rộng slide mới và chiều rộng gốc. Áp dụng tỷ lệ chiều cao tương ứng cho các tọa độ dọc và chiều cao của nó.

Ví dụ đầu tiên tải một bản trình chiếu mà các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) với [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) để vòng lặp tiếp theo kiểm soát việc mở rộng. Các tỷ lệ không có đơn vị; vị trí và kích thước của hình dạng được đo bằng điểm. Các tỷ lệ chiều rộng và chiều cao khác nhau có thể làm biến dạng hình dạng, và việc thay đổi kích thước của một hình dạng không mở rộng kích thước phông chữ của nó.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Tính các hệ số co dọc và ngang độc lập.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Bảng yêu cầu xử lý riêng: mở rộng chiều rộng cột và chiều cao hàng thay vì gán tổng chiều rộng và chiều cao cho bảng. Chiều cao hàng có thể vẫn lớn hơn yêu cầu nếu nội dung ô đòi hỏi nhiều không gian hơn.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ bảng và xử lý các hình dạng trên master và layout cũng như các slide riêng lẻ trước khi lưu bản trình chiếu đã thay đổi kích thước. Trợ giúp của nó xử lý mỗi [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) bằng cách mở rộng [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) và [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Sau đó nó mở rộng vị trí của bảng mà không mở rộng riêng tổng các kích thước của nó.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Kích thước bảng được kiểm soát bởi độ rộng cột và chiều cao hàng.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Tính các hệ số co dọc và ngang độc lập.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Thay đổi kích thước các hình dạng được định nghĩa trên master và layout cũng như các slide riêng lẻ.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**

Nếu bạn thay đổi kích thước slide mà không mở rộng các hình dạng, chúng sẽ giữ nguyên vị trí và kích thước ban đầu và có thể vượt ra ngoài slide. Việc mở rộng chiều rộng và chiều cao bằng các tỷ lệ khác nhau cũng có thể làm biến dạng các hình dạng.

**Mã được cung cấp có hoạt động cho mọi loại hình dạng không?**

Ví dụ đầu tiên thay đổi giới hạn của hình dạng một cách trực tiếp và dành cho các slide không có bảng. Ví dụ thứ hai xử lý bảng riêng biệt. Kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì các ví dụ này không mở rộng kích thước phông chữ và nội dung bảng có thể giới hạn chiều cao hàng.

**Làm thế nào để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Mở rộng chiều rộng cột theo tỷ lệ chiều rộng và chiều cao tối thiểu của hàng theo tỷ lệ chiều cao, sau đó mở rộng vị trí của bảng, như được minh họa trong ví dụ thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các master slide và layout slide không?**

Có. Ví dụ thứ hai duyệt qua [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) và [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) của mỗi master và áp dụng cùng logic thay đổi kích thước cho các hình dạng của chúng.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Đặt [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) sau khi thay đổi kích thước slide và trước khi đọc các kích thước mục tiêu, để các hệ số mở rộng phản ánh hướng cuối cùng.

**Có giới hạn nào cho kích thước slide tôi có thể đặt không?**

Bạn có thể chỉ định kích thước slide tùy chỉnh bằng [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Các kích thước được hỗ trợ cũng phụ thuộc vào định dạng bản trình chiếu và ứng dụng dùng để mở tệp.

**Làm thế nào để ngăn các hình dạng có tỷ lệ khung cố định bị biến dạng?**

Sử dụng cùng một hệ số mở rộng cho chiều rộng và chiều cao. Để vừa với bố cục gốc trong kích thước slide mới, hãy dùng tỷ lệ nhỏ hơn giữa chiều rộng và chiều cao cho cả hai kích thước và vị trí. Điều này giữ nguyên tỉ lệ nhưng có thể để lại không gian không dùng được ở một cạnh.