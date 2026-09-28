---
title: Quản lý Slide Master của Bản trình chiếu trong Python
linktitle: Slide Master
type: docs
weight: 80
url: /vi/python-net/slide-master/
keywords:
- slide mẫu
- slide mẫu
- slide mẫu PPT
- nhiều slide mẫu
- so sánh slide mẫu
- nền
- trình giữ chỗ
- sao chép slide mẫu
- sao chép slide mẫu
- nhân bản slide mẫu
- slide mẫu không dùng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho Python qua .NET: truy cập, chỉnh sửa, sao chép, so sánh và xóa các slide master trong bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** xác định các cài đặt thiết kế chung cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu văn bản, cài đặt chủ đề và cài đặt footer. Trong PowerPoint, việc chỉnh sửa slide master là cách thường dùng để giữ cho bài thuyết trình nhất quán mà không phải lặp lại cùng một định dạng trên từng slide.

Aspose.Slides for Python via .NET hỗ trợ cùng mô hình này. Một bản trình chiếu có thể chứa một hoặc nhiều slide master, và mỗi slide master có thể chứa một số slide layout. Các slide bình thường thường không tham chiếu trực tiếp tới slide master. Thay vào đó, một slide bình thường sử dụng một slide layout, và slide layout đó thuộc về một slide master.

Cấu trúc phân cấp như sau:

1. **Slide master** – xác định thiết kế và chủ đề chung.
1. **Layout slide** – xác định một bố cục cụ thể của các placeholder và định dạng ở mức layout.
1. **Normal slide** – chứa nội dung thực tế của bài thuyết trình và sử dụng một layout slide.

![Cấu trúc của các slide master, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được biểu diễn bởi lớp [MasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/). Tất cả các slide master trong một bản trình chiếu có thể truy cập qua bộ sưu tập `Presentation.masters`.

{{% alert color="info" title="Kế thừa" %}}

Khi cùng một thuộc tính được định nghĩa ở nhiều cấp độ, cấp độ cụ thể hơn sẽ thắng. Ví dụ, nếu một slide master và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Apply or Change Slide Layouts](/slides/vi/python-net/slide-layout/).

{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `masters` để truy cập các slide master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Bạn cũng có thể lấy slide master mà một slide bình thường sử dụng thông qua layout của nó:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Nội dung của một Slide Master**

Một slide master là một đối tượng giống slide. Nó kế thừa hành vi slide chung từ lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như slide bình thường và layout. Các thành viên riêng của master được liệt kê trên trang API [MasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/).

Các thành viên master slide thường được sử dụng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `background` | Đặt nền ở mức master. |
| `shapes` | Lưu trữ các hình dạng được đặt trên master, chẳng hạn logo, khung ảnh và văn bản chung. |
| `layout_slides` | Lưu trữ các layout slide thuộc về master. |
| `theme_manager` | Cung cấp truy cập vào các API chủ đề master. |
| `header_footer_manager` | Điều khiển header, footer, ngày tháng và số slide cho master và các layout con của nó. |
| `get_depending_slides` | Trả về các slide bình thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm một hình ảnh vào slide master, nó sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ dưới đây thêm một logo vào slide master đầu tiên:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Để biết thêm về khung ảnh, xem [Picture Frame](/slides/vi/python-net/picture-frame/).

## **Kiểm soát khả năng hiển thị của đồ họa master**

Sử dụng [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/show_master_shapes/) để ẩn các đồ họa master kế thừa, chẳng hạn logo hoặc hình dạng trang trí, mà không xóa chúng khỏi master. Đặt [Slide.show_master_shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/show_master_shapes/) thành `False` trên slide mà bạn muốn bỏ các đồ họa đó và giữ `True` trên các slide muốn hiển thị chúng.

Ví dụ tự chứa dưới đây tạo một dải trang trí màu xanh trên một master và hai slide sử dụng cùng một layout trống. Dải này hiển thị trên slide đầu tiên và ẩn trên slide thứ hai. Không yêu cầu bản trình chiếu hoặc hình ảnh đầu vào.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Ví dụ sử dụng layout **Blank** được cung cấp với một bản trình chiếu mới và loại bỏ các placeholder mặc định của slide đầu tiên.

### **Chọn phạm vi cài đặt**

Một slide bình thường sử dụng master của nó thông qua [Slide.layout_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/layout_slide/) và [LayoutSlide.master_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/master_slide/). Đặt thuộc tính trên một slide riêng chỉ ảnh hưởng đến slide đó. Đặt [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/show_master_shapes/) thành `False` sẽ ẩn đồ họa master cho tất cả các slide sử dụng layout chung đó, ngay cả khi cài đặt riêng của chúng là `True`. Để ẩn đồ họa chỉ trên một slide, thay đổi thuộc tính slide và để layout chung không thay đổi.

Cài đặt không được hỗ trợ như một kiểm soát hiển thị trên chính slide master. Trên master nó luôn trả về `False`, và gán `True` sẽ ném ngoại lệ. Áp dụng nó cho một slide bình thường hoặc một layout thay vì master.

### **Phân biệt đồ họa và nền**

| Thao tác | Hiệu quả |
| --- | --- |
| Ẩn đồ họa master | Kiểm soát khả năng hiển thị của các shape master kế thừa mà không xóa chúng hoặc thay đổi shape của slide. |
| Thay đổi nền slide | Thay đổi màu, gradient hoặc hình ảnh nền. Đồ họa master là các shape riêng biệt và có thể vẫn hiển thị trên nền đó. Xem [Presentation Background](/slides/vi/python-net/presentation-background/). |
| Xóa shape khỏi master | Loại bỏ shape nguồn chung, vì vậy nó không còn khả dụng cho bất kỳ slide nào sử dụng master đó. |

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Slide master cung cấp kiểu và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào khả dụng và vị trí của chúng.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ Slide Master.

![Lệnh Insert Placeholder trong chế độ Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới bằng Aspose.Slides, làm việc với layout slide thuộc về master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên slide master. Ví dụ dưới đây tìm placeholder tiêu đề và áp dụng màu gradient tuyến tính:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Placeholder tiêu đề đã định dạng được kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/slides/vi/python-net/manage-placeholder/) và [Text Formatting](/slides/vi/python-net/text-formatting/).

## **Thay đổi nền của Slide Master**

Nền master được kế thừa bởi các layout và slide nếu chúng không ghi đè. Ví dụ dưới đây đặt màu nền đặc cho slide master đầu tiên:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Đối với các chủ đề liên quan, xem [Presentation Background](/slides/vi/python-net/presentation-background/) và [Presentation Theme](/slides/vi/python-net/presentation-theme/).

## **Sao chép Slide Master sang Bản trình chiếu khác**

Sử dụng phương thức `add_clone` trên lớp [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/) để sao chép một slide master vào bản trình chiếu khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản trình chiếu đích.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn cần sao chép các slide bình thường cùng với master của chúng, xem [Clone Slides](/slides/vi/python-net/clone-slides/).

## **Thêm nhiều Slide Master**

Một bản trình chiếu có thể chứa nhiều slide master. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt chủ đề riêng.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

Ví dụ dưới đây sao chép master mặc định, đặt nền khác cho bản sao, lấy một layout trống dưới master vừa sao chép, và thêm một slide mới dựa trên layout đó:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **So sánh Slide Masters**

Slide master có thể được so sánh bằng phương thức `equals` kế thừa từ lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/). Phép so sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn shape, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất như slide ID hoặc giá trị placeholder động như ngày hiện tại.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Để biết thêm thông tin, xem [Compare Presentation Slides](/slides/vi/python-net/compare-slides/).

## **Đặt Slide Master View làm chế độ xem mặc định**

Sử dụng thuộc tính `last_view` trên [ViewProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/) của bản trình chiếu để kiểm soát chế độ xem mà PowerPoint mở đầu tiên. Ví dụ dưới đây mở bản trình chiếu ở chế độ Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Để biết thêm các cài đặt chế độ xem, xem [Save Presentation](/slides/vi/python-net/save-presentation/).

## **Xóa các Slide Master không dùng**

Đôi khi bản trình chiếu chứa các slide master không còn được bất kỳ slide bình thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hóa việc bảo trì mẫu.

Sử dụng `remove_unused` để xóa các master không dùng khỏi bộ sưu tập `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Bạn cũng có thể sử dụng phương thức low-code `remove_unused_master_slides` từ lớp [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa slide master và layout slide là gì?**

Slide master định nghĩa các cài đặt thiết kế chung như chủ đề, nền, shape chung và kiểu văn bản. Layout slide thuộc về một slide master và xác định một bố cục cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, vì vậy nó kế thừa từ cả layout và master.

**Một bản trình chiếu có thể chứa nhiều slide master không?**

Có. Một bản trình chiếu có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần các hệ thống hình ảnh hoặc thương hiệu khác nhau.

**Nên thêm placeholder vào slide master hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên slide master, sau đó đặt placeholder nội dung trên các layout mà slide bình thường sẽ sử dụng.

**Có thể xóa một slide master mà vẫn đang được sử dụng không?**

Không. Một slide master có các slide phụ thuộc không thể bị xóa một cách an toàn. Đầu tiên hãy chuyển những slide đó sang layout dưới một master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng chỉ xóa các master không còn được sử dụng.