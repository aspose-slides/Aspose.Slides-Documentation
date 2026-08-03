---
title: Chuyển đổi các slide PowerPoint sang hình ảnh bằng Python
linktitle: Slide thành Hình ảnh
type: docs
weight: 41
url: /vi/python-net/convert-slide/
keywords:
- chuyển đổi slide
- chuyển đổi slide sang hình ảnh
- xuất slide dưới dạng hình ảnh
- lưu slide dưới dạng hình ảnh
- slide thành hình ảnh
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- Python
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi các slide PowerPoint và OpenDocument sang nhiều định dạng khác nhau bằng cách sử dụng Aspose.Slides cho Python qua .NET. Dễ dàng xuất các slide PPTX và ODP sang BMP, PNG, JPEG, TIFF và hơn nữa với kết quả chất lượng cao."
---
## **Introduction**

Aspose.Slides for Python via .NET cho phép bạn dễ dàng chuyển đổi các slide thuyết trình PowerPoint và OpenDocument sang nhiều định dạng ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành ảnh, hãy thực hiện các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/) hoặc
    - Lớp [RenderingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/).
2. Tạo ảnh slide bằng cách gọi phương thức `get_image` từ lớp [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) .

Trong Aspose.Slides for Python via .NET, [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) là một lớp cho phép bạn làm việc với các hình ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng một thể hiện của lớp này để lưu ảnh ở nhiều định dạng khác nhau (BMP, JPG, PNG, v.v.).

## **Convert Slides to Bitmap and Save the Images in PNG**

Bạn có thể chuyển đổi một slide thành một đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Hoặc, bạn có thể chuyển đổi slide thành bitmap rồi lưu ảnh dưới định dạng JPEG hoặc bất kỳ định dạng nào khác mà bạn muốn.

Đoạn mã Python sau minh họa cách chuyển đổi slide đầu tiên của một bản trình bày thành đối tượng bitmap và sau đó lưu ảnh ở định dạng PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap.
    with presentation.slides[0].get_image() as image:
        # Lưu ảnh ở định dạng PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Convert Slides to Images with Custom Sizes**

Bạn có thể cần tạo một hình ảnh có kích thước nhất định. Bằng cách sử dụng một overload của phương thức [get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize), bạn có thể chuyển đổi một slide thành hình ảnh với kích thước cụ thể (chiều rộng và chiều cao).

Đoạn mã mẫu dưới đây minh họa cách thực hiện:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap với kích thước đã chỉ định.
    with presentation.slides[0].get_image(image_size) as image:
        # Lưu ảnh ở định dạng JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Convert Slides with Notes and Comments to Images**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai lớp—[TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/) và [RenderingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/)—cho phép bạn kiểm soát quá trình render các slide thuyết trình thành ảnh. Cả hai lớp đều bao gồm thuộc tính `slides_layout_options`, cho phép bạn cấu hình cách render ghi chú và bình luận trên một slide khi chuyển đổi nó thành ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong ảnh kết quả.

Đoạn mã Python sau minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Đặt vị trí của ghi chú.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Đặt vị trí của các bình luận.
    notes_comments_options.comments_area_width = 500                                       # Đặt chiều rộng của vùng bình luận.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Đặt màu cho vùng bình luận.

    # Tạo các tùy chọn render.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Chuyển đổi slide đầu tiên của bản trình bày thành ảnh.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Lưu ảnh ở định dạng GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
Trong bất kỳ quá trình chuyển đổi slide sang ảnh nào, thuộc tính [notes_position](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) không thể được đặt là `BOTTOM_FULL` (để chỉ định vị trí cho ghi chú) vì nội dung ghi chú có thể quá lớn, khiến nó không vừa trong kích thước ảnh đã chỉ định.
{{% /alert %}} 

## **Convert Slides to Images Using TIFF Options**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/) cho phép bạn kiểm soát tốt hơn hình ảnh TIFF kết quả bằng cách chỉ định các tham số như kích thước, độ phân giải, bảng màu và các tùy chọn khác.

Đoạn mã Python sau minh họa quy trình chuyển đổi, trong đó các tùy chọn TIFF được sử dụng để tạo ra một hình ảnh đen trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Tải tệp bản trình bày.
with slides.Presentation("sample.pptx") as presentation:
    # Lấy slide đầu tiên từ bản trình bày.
    slide = presentation.slides[0]

    # Cấu hình các thiết lập cho ảnh TIFF đầu ra.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Đặt kích thước ảnh.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Đặt định dạng pixel (đen trắng).
    options.dpi_x = 300                                                        # Đặt độ phân giải theo chiều ngang.
    options.dpi_y = 300                                                        # Đặt độ phân giải theo chiều dọc.

    # Chuyển đổi slide thành ảnh với các tùy chọn đã chỉ định.
    with slide.get_image(options) as image:
        # Lưu ảnh ở định dạng TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Convert All Slides to Images**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình bày thành ảnh, thực chất là chuyển đổi toàn bộ bản trình bày thành một loạt các hình ảnh.

Đoạn mã mẫu dưới đây minh họa cách chuyển đổi tất cả các slide trong một bản trình bày thành ảnh bằng Python:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Render bản trình bày thành các ảnh từng slide.
    for i, slide in enumerate(presentation.slides):
        # Kiểm soát các slide ẩn (không render các slide ẩn).
        if slide.hidden:
            continue

        # Chuyển đổi slide thành ảnh.
        with slide.get_image(scale_x, scale_y) as image:
            # Lưu ảnh ở định dạng JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **Color Emoji Rendering**

{{% alert title="Note" color="warning" %}} 
Để render đúng các emoji màu khi chuyển đổi slide thuyết trình sang ảnh, các phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện quá trình chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** và phông chữ này thiếu, các emoji có thể xuất hiện dưới dạng đơn màu trong các ảnh đầu ra.
{{% /alert %}}

## **FAQ**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không, phương thức `get_image` chỉ lưu một ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn dưới dạng ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thông thường. Chỉ cần đảm bảo chúng được đưa vào vòng lặp xử lý.

**Có thể lưu ảnh với bóng đổ và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng ảnh.