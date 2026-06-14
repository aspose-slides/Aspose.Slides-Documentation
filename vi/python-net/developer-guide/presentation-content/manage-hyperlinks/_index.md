---
title: "Quản lý Siêu liên kết trong bản trình bày bằng Python"
linktitle: "Quản lý Siêu liên kết"
type: docs
weight: 20
url: /vi/python-net/manage-hyperlinks/
keywords:
  - "thêm URL"
  - "thêm siêu liên kết"
  - "tạo siêu liên kết"
  - "định dạng siêu liên kết"
  - "xóa siêu liên kết"
  - "cập nhật siêu liên kết"
  - "siêu liên kết văn bản"
  - "siêu liên kết slide"
  - "siêu liên kết hình dạng"
  - "siêu liên kết hình ảnh"
  - "siêu liên kết video"
  - "siêu liên kết có thể thay đổi"
  - "PowerPoint"
  - "OpenDocument"
  - "bản trình bày"
  - "Python"
description: "Quản lý siêu liên kết trong các bản trình bày PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides for Python via .NET—tăng cường tính tương tác và quy trình làm việc trong vài phút."
---
## **Giới thiệu**

Siêu liên kết là một tham chiếu đến tài nguyên bên ngoài, một đối tượng hoặc mục dữ liệu, hoặc một vị trí cụ thể trong tệp. Các loại siêu liên kết phổ biến trong bản trình bày PowerPoint bao gồm:

* Liên kết tới các trang web được nhúng trong văn bản, hình dạng hoặc phương tiện
* Liên kết tới các slide

Aspose.Slides for Python via .NET cho phép thực hiện nhiều thao tác liên quan đến siêu liên kết trong bản trình bày.

## **Thêm Siêu Liên Kết URL**

Phần này giải thích cách thêm siêu liên kết URL vào các phần tử slide khi làm việc với Aspose.Slides. Nó bao gồm việc gán địa chỉ liên kết cho văn bản, hình dạng và hình ảnh để đảm bảo điều hướng mượt mà trong bản trình bày.

### **Thêm Siêu Liên Kết URL vào Văn Bản**

Mẫu mã sau cho thấy cách thêm siêu liên kết trang web vào văn bản:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Thêm Siêu Liên Kết URL vào Hình Dạng hoặc Khung**

Mẫu mã sau cho thấy cách thêm siêu liên kết trang web vào một hình dạng:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Thêm Siêu Liên Kết URL vào Phương Tiện**

Aspose.Slides cho phép bạn thêm siêu liên kết vào hình ảnh, tệp âm thanh và video.

Mẫu mã sau cho thấy cách thêm siêu liên kết vào một **hình ảnh**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Thêm một hình ảnh vào bản trình bày.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Tạo một khung hình ảnh trên slide 1 sử dụng hình ảnh đã thêm trước đó.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Mẫu mã sau cho thấy cách thêm siêu liên kết vào một **tệp âm thanh**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Mẫu mã sau cho thấy cách thêm siêu liên kết vào một **video**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Mẹo" color="primary" %}}
Bạn có thể muốn xem [Quản Lý OLE trong Bản Trình Bày Sử Dụng Python](/slides/vi/python-net/manage-ole/).
{{% /alert %}}

## **Sử Dụng Siêu Liên Kết Để Tạo Mục Lục**

Vì siêu liên kết cho phép bạn tham chiếu đến các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để xây dựng mục lục.

Mã mẫu bên dưới cho thấy cách tạo mục lục với siêu liên kết:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Định Dạng Siêu Liên Kết**

Phần này cho thấy cách định dạng hiển thị của siêu liên kết trong Aspose.Slides. Bạn sẽ học cách kiểm soát màu sắc và các tùy chọn kiểu khác để duy trì định dạng siêu liên kết nhất quán trên văn bản, hình dạng và hình ảnh.

### **Màu Siêu Liên Kết**

Sử dụng thuộc tính [color_source](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/color_source/) của lớp [Hyperlink](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/), bạn có thể đặt màu cho siêu liên kết và đọc thông tin màu của nó. Tính năng này được giới thiệu trong PowerPoint 2019, vì vậy các thay đổi qua thuộc tính này sẽ không áp dụng cho các phiên bản PowerPoint trước đó.

Mẫu sau minh họa cách thêm siêu liên kết với các màu khác nhau vào cùng một slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa Siêu Liên Kết khỏi Bản Trình Bày**

Phần này giải thích cách xóa siêu liên kết khỏi bản trình bày khi làm việc với Aspose.Slides. Bạn sẽ học cách xóa mục tiêu liên kết khỏi văn bản, hình dạng và hình ảnh đồng thời giữ nguyên nội dung và định dạng gốc.

### **Xóa Siêu Liên Kết khỏi Văn Bản**

Mã mẫu sau cho thấy cách xóa siêu liên kết khỏi văn bản trên một slide của bản trình bày:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Xóa Siêu Liên Kết khỏi Hình Dạng hoặc Khung**

Mã mẫu sau cho thấy cách xóa siêu liên kết khỏi các hình dạng trên một slide của bản trình bày: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Siêu Liên Kết Có Thể Thay Đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/) có thể thay đổi. Khi dùng lớp này, bạn có thể thay đổi giá trị của các thuộc tính sau:

- [target_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Mã đoạn sau cho thấy cách thêm siêu liên kết vào một slide và sau đó chỉnh sửa tooltip của nó:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Các Thuộc Tính Hỗ Trợ trong IHyperlinkQueries**

Bạn có thể truy cập [HyperlinkQueries](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkqueries/) từ bản trình bày, slide hoặc văn bản chứa siêu liên kết.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/hyperlink_queries/)

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkqueries/) hỗ trợ các phương thức sau:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Bạn có thể muốn kiểm tra trình chỉnh sửa trực tuyến đơn giản và miễn phí của Aspose là [PowerPoint editor](https://products.aspose.app/slides/vi/editor).
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide mà còn tới một "phần" hoặc slide đầu tiên của một phần?**

Các phần trong PowerPoint là các nhóm slide; điều hướng về mặt kỹ thuật đều nhắm tới một slide cụ thể. Để "đi tới một phần", bạn thường liên kết tới slide đầu tiên của phần đó.

**Tôi có thể đính kèm siêu liên kết vào các thành phần của master slide để nó hoạt động trên tất cả các slide không?**

Có. Các thành phần của master slide và layout hỗ trợ siêu liên kết. Các liên kết này xuất hiện trên các slide con và có thể nhấp được trong khi trình chiếu.

**Siêu liên kết có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Trong [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), có—liên kết thường được giữ lại. Khi xuất ra [hình ảnh](/slides/vi/python-net/convert-powerpoint-to-png/) và [video](/slides/vi/python-net/convert-powerpoint-to-video/), khả năng nhấp sẽ không được duy trì do đặc tính của các định dạng đó (khung raster/video không hỗ trợ siêu liên kết).