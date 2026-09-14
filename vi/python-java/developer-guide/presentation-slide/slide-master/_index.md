---
title: Quản lý các Slide Master của bản trình chiếu trong Python qua Java
linktitle: Slide Master
type: docs
weight: 70
url: /vi/python-java/slide-master/
keywords:
- slide master
- slide master
- slide master PPT
- nhiều slide master
- so sánh slide master
- nền
- placeholder
- sao chép slide master
- chép slide master
- nhân bản slide master
- slide master không dùng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho Python qua Java: truy cập, chỉnh sửa, sao chép, so sánh và xóa slide master trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** định nghĩa các cài đặt thiết kế chia sẻ cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, cài đặt chủ đề và cài đặt chân trang. Trong PowerPoint, chỉnh sửa slide master là cách thông thường để giữ cho bản trình chiếu nhất quán mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for Python via Java hỗ trợ cùng mô hình. Một bản trình chiếu có thể chứa một hoặc nhiều slide master, và mỗi slide master có thể chứa một số slide layout. Các slide bình thường thường không tham chiếu trực tiếp tới slide master. Thay vào đó, một slide bình thường sử dụng một slide layout, và slide layout đó thuộc về một slide master.

Cấu trúc phân cấp là:

1. **Slide master** – định nghĩa thiết kế và chủ đề chung.
1. **Layout slide** – định nghĩa bố cục cụ thể của các placeholder và định dạng cấp layout.
1. **Normal slide** – chứa nội dung thực tế của bản trình chiếu và sử dụng một layout slide.

![Cấu trúc phân cấp của slide master, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được biểu diễn bởi lớp [MasterSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/). Tất cả các slide master trong một bản trình chiếu có thể truy cập thông qua bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasters), được biểu diễn bởi [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Khi cùng một thuộc tính được định nghĩa ở nhiều cấp độ, cấp độ cụ thể hơn sẽ thắng. Ví dụ, nếu một slide master và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Áp dụng hoặc Thay đổi bố cục Slide](/slides/vi/python-java/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasters) để truy cập các slide master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Bạn cũng có thể lấy slide master được một slide bình thường sử dụng thông qua layout của nó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Nội dung của Slide Master**

Một slide master là một đối tượng giống slide. Nó kế thừa từ [BaseSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như slide bình thường và layout slide. Các thành viên đặc thù của master được liệt kê trên trang API [MasterSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/).

Các thành viên master thường dùng bao gồm:

| Member | Mục đích |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getBackground) | Đặt nền slide cấp master. |
| [getShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getShapes) | Lưu trữ các hình dạng đặt trên master, chẳng hạn logo, khung hình ảnh và văn bản chia sẻ. |
| [getLayoutSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#getLayoutSlides) | Lưu trữ các layout slide thuộc về master. |
| [getThemeManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#getThemeManager) | Cung cấp quyền truy cập vào các API chủ đề master. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Điều khiển tiêu đề, chân trang, ngày tháng và số slide cho master và các layout con. |
| [getDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#getDependingSlides) | Trả về các slide bình thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một slide master, hình ảnh sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào slide master đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để biết thêm thông tin về khung hình ảnh, xem [Khung Hình](/slides/vi/python-java/picture-frame/).

## **Làm việc với Placeholders**

Placeholders thường được định nghĩa trên layout slide. Slide master cung cấp kiểu dáng và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholders nào khả dụng và chúng được đặt ở đâu.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![Lệnh Insert Placeholder trong chế độ xem Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới bằng Aspose.Slides, làm việc với layout slide thuộc về master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bạn cũng có thể định dạng các hình dạng placeholder đã tồn tại trên slide master. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu nền gradient tuyến tính:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Placeholder tiêu đề đã định dạng được kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Đặt Văn bản Nhắc trong Placeholder](/slides/vi/python-java/manage-placeholder/) và [Định dạng Văn bản](/slides/vi/python-java/text-formatting/).

## **Thay đổi nền Slide Master**

Nền master được các layout và slide không ghi đè kế thừa. Ví dụ sau thiết lập màu nền đặc cho slide master đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đối với các chủ đề liên quan, xem [Nền Presentation](/slides/vi/python-java/presentation-background/) và [Chủ đề Presentation](/slides/vi/python-java/presentation-theme/).

## **Sao chép Slide Master sang Bản trình chiếu khác**

Sử dụng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/#addClone) để sao chép một slide master vào bản trình chiếu khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản đích.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Nếu bạn cần sao chép các slide bình thường cùng với master của chúng, xem [Sao chép Slides](/slides/vi/python-java/clone-slides/).

## **Thêm nhiều Slide Masters**

Một bản trình chiếu có thể chứa nhiều slide master. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt chủ đề khác nhau.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép và thêm một slide mới dựa trên layout đó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **So sánh Slide Masters**

Slide master có thể được so sánh bằng phương thức [equals](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#equals) kế thừa từ [BaseSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/). So sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn hình dạng, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất như ID slide, hoặc các giá trị placeholder động như ngày hiện tại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Để biết thêm thông tin, xem [So sánh Slides trong Presentation](/slides/vi/python-java/compare-slides/).

## **Đặt chế độ xem Slide Master làm chế độ xem mặc định**

Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#setLastView) trên [ViewProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/) để điều khiển chế độ mà PowerPoint mở đầu tiên. Ví dụ sau mở bản trình chiếu ở chế độ Slide Master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để biết thêm cài đặt chế độ xem, xem [Lưu Presentation](/slides/vi/python-java/save-presentation/).

## **Xóa các Slide Master không dùng**

Đôi khi bản trình chiếu chứa các slide master không còn được bất kỳ slide bình thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hoá việc bảo trì mẫu.

Sử dụng [removeUnused](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/#removeUnused) để xóa các master không dùng khỏi bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bạn cũng có thể dùng phương thức low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Sự khác biệt giữa slide master và layout slide là gì?**

Slide master định nghĩa các cài đặt thiết kế chung như chủ đề, nền, hình dạng chung và kiểu chữ. Layout slide thuộc một slide master và định nghĩa bố cục cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, vì vậy nó kế thừa từ cả layout và master.

**Một bản trình chiếu có thể chứa nhiều slide master không?**

Có. Một bản trình chiếu có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần các hệ thống hình ảnh hoặc thương hiệu khác nhau.

**Nên thêm placeholder vào slide master hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên slide master, sau đó đặt các placeholder nội dung trên các layout mà slide bình thường sẽ sử dụng.

**Tôi có thể xóa một slide master vẫn đang được sử dụng không?**

Không. Slide master có các slide phụ thuộc không thể bị xóa trực tiếp một cách an toàn. Đầu tiên hãy chuyển những slide đó sang layout dưới một master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng để chỉ xóa các master không có slide phụ thuộc.