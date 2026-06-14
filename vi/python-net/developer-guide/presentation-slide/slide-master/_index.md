---
title: Quản lý Slide Master của Bản trình bày trong Python
linktitle: Slide Master
type: docs
weight: 80
url: /vi/python-net/slide-master/
keywords:
- slide master
- master slide
- PPT master slide
- nhiều master slide
- so sánh master slide
- nền
- placeholder
- tạo bản sao master slide
- sao chép master slide
- nhân bản master slide
- master slide không sử dụng
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho Python qua .NET: truy cập, chỉnh sửa, sao chép, so sánh và xóa các slide master trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** xác định các cài đặt thiết kế chia sẻ cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, cài đặt chủ đề và cài đặt chân trang. Trong PowerPoint, chỉnh sửa slide master là cách thông thường để duy trì sự nhất quán của bản trình bày mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for Python via .NET hỗ trợ cùng mô hình. Một bản trình bày có thể chứa một hoặc nhiều master slide, và mỗi master slide có thể chứa một số layout slide. Các slide thông thường thường không tham chiếu trực tiếp đến master slide. Thay vào đó, một slide thông thường sử dụng một layout slide, và layout slide đó thuộc về một master slide.

Cấu trúc phân cấp là:

1. **Slide master** - xác định thiết kế và chủ đề chung.
1. **Layout slide** - xác định bố trí cụ thể của các placeholder và định dạng ở mức layout.
1. **Normal slide** - chứa nội dung thực tế của bản trình bày và sử dụng một layout slide.

![Cấu trúc phân cấp của master slide, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được biểu diễn bằng lớp [MasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/). Tất cả các master slide trong một bản trình bày đều có trong bộ sưu tập `Presentation.masters`.

{{% alert color="info" title="Kế thừa" %}}

Khi cùng một thuộc tính được định nghĩa ở nhiều mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một master slide và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Apply or Change Slide Layouts](/python-net/slide-layout/).

{{% /alert %}}

## **Truy cập Slide Master**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `masters` để truy cập các master slide:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Bạn cũng có thể lấy master slide được sử dụng bởi một slide bình thường thông qua layout của nó:

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

Một master slide là đối tượng kiểu slide. Nó kế thừa hành vi chung của slide từ lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như slide thông thường và layout. Các thành viên riêng của master được liệt kê trên trang API [MasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/).

Các thành viên master slide thường dùng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `background` | Đặt nền slide ở mức master. |
| `shapes` | Lưu trữ các hình dạng đặt trên master, chẳng hạn logo, khung hình ảnh và văn bản chia sẻ. |
| `layout_slides` | Lưu trữ các layout slide thuộc về master. |
| `theme_manager` | Cung cấp quyền truy cập vào các API chủ đề của master. |
| `header_footer_manager` | Kiểm soát header, footer, ngày tháng và số slide cho master và các layout con của nó. |
| `get_depending_slides` | Trả về các slide bình thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một master slide, nó sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ dưới đây thêm một logo vào master slide đầu tiên:

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

Để biết thêm thông tin về khung hình ảnh, xem [Picture Frame](/python-net/picture-frame/).

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Master slide cung cấp kiểu dáng và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào có sẵn và vị trí của chúng.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![Lệnh Insert Placeholder trong chế độ xem Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

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

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên master slide. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu nền gradient tuyến tính:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Placeholder tiêu đề đã định dạng được kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) và [Text Formatting](/python-net/text-formatting/).

## **Thay đổi nền Slide Master**

Nền master được kế thừa bởi các layout và slide nếu chúng không ghi đè. Ví dụ dưới đây đặt màu nền đặc cho master slide đầu tiên:

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

Đối với các chủ đề liên quan, xem [Presentation Background](/python-net/presentation-background/) và [Presentation Theme](/python-net/presentation-theme/).

## **Sao chép Slide Master sang Bản trình bày khác**

Sử dụng phương thức `add_clone` trên lớp [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/) để sao chép một master slide vào bản trình bày khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản đích.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn cần sao chép các slide bình thường cùng với master của chúng, xem [Clone Slides](/python-net/clone-slides/).

## **Thêm nhiều Slide Master**

Một bản trình bày có thể chứa nhiều master slide. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt chủ đề khác nhau.

![Các lệnh PowerPoint để chèn và quản lý master slide](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, lấy một layout trống dưới master đã sao chép, và thêm một slide mới dựa trên layout đó:

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

## **So sánh Slide Master**

Slide master có thể được so sánh bằng phương thức `equals` kế thừa từ lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/). Việc so sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn các shape, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất như ID slide, hay các giá trị placeholder động như ngày hiện tại.

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

Để biết thêm thông tin, xem [Compare Presentation Slides](/python-net/compare-slides/).

## **Đặt chế độ xem Slide Master làm chế độ xem mặc định**

Sử dụng thuộc tính `last_view` trên đối tượng [ViewProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/) của bản trình bày để kiểm soát chế độ xem mà PowerPoint mở lần đầu. Ví dụ dưới đây mở bản trình bày ở chế độ Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Để biết thêm các cài đặt chế độ xem, xem [Save Presentation](/python-net/save-presentation/).

## **Xóa các Master Slide không sử dụng**

Đôi khi bản trình bày chứa các master slide không còn được bất kỳ slide bình thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hoá việc bảo trì mẫu.

Sử dụng `remove_unused` để xóa các master không dùng khỏi bộ sưu tập `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Bạn cũng có thể dùng phương thức low-code `remove_unused_master_slides` từ lớp [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Sự khác biệt giữa slide master và layout slide là gì?**

Slide master định nghĩa các cài đặt thiết kế chung như chủ đề, nền, hình dạng chung và kiểu chữ. Layout slide thuộc về một master slide và định nghĩa bố trí cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, do đó nó kế thừa cả từ layout và master.

**Một bản trình bày có thể chứa nhiều slide master không?**

Có. Một bản trình bày có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc thương hiệu khác nhau.

**Nên thêm placeholder vào master slide hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên master slide, sau đó đặt placeholder nội dung trên các layout mà slide bình thường sẽ sử dụng.

**Có thể xóa một master slide đang được sử dụng không?**

Không. Một master slide có các slide phụ thuộc không thể bị xóa trực tiếp một cách an toàn. Đầu tiên chuyển các slide đó sang layout dưới một master khác, hoặc dùng phương thức dọn dẹp master không dùng chỉ xóa các master không có slide phụ thuộc.