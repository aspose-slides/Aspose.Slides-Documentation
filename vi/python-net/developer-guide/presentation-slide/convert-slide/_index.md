---
title: Chuyển đổi các slide trình chiếu sang hình ảnh trong Python
linktitle: Slide sang Hình ảnh
type: docs
weight: 41
url: /vi/python-net/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang hình ảnh
- lưu slide dưới dạng hình ảnh
- slide sang EMF
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Chuyển đổi các slide từ các bản trình bày PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng hình ảnh khác trong Python bằng Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET có thể render các trang slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument dưới dạng PNG, JPEG, GIF, TIFF và các định dạng hình ảnh khác.

Để chuyển đổi một slide thành hình ảnh, thực hiện các bước sau:

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Chọn slide mà bạn muốn render.
3. Nếu cần, cấu hình việc render bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/).
4. Gọi phương thức [Slide.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/). Nó trả về một đối tượng [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/).
5. Gọi phương thức [IImage.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/save/) và chỉ định định dạng đầu ra bằng giá trị [ImageFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imageformat/).

## **Chuyển đổi Slide sang ảnh PNG**

Cách chuyển đổi đơn giản nhất sử dụng cài đặt render mặc định. Đối tượng [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) kết quả có thể được xử lý trong bộ nhớ hoặc lưu vào tệp.

Ví dụ Python sau render slide đầu tiên và lưu nó dưới dạng ảnh PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Chuyển đổi Slides sang ảnh với kích thước tùy chỉnh**

Sử dụng phương thức overload [Slide.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) chấp nhận giá trị [Size](https://reference.aspose.com/slides/vi/python-net/aspose.pydrawing/size/) để render slide với kích thước pixel chính xác.

Ví dụ sau tạo ảnh JPEG kích thước 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Chuyển đổi Slides có Ghi chú và Bình luận sang ảnh**

Mặc định, ảnh slide không bao gồm ghi chú hoặc bình luận. Gán một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/) cho thuộc tính [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) để kiểm soát vị trí hiển thị ghi chú và bình luận.

Ví dụ sau đặt ghi chú đã cắt ngắn bên dưới slide và bình luận sang bên phải:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}

Đối với chuyển đổi slide sang ảnh, không nên đặt thuộc tính [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) thành [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notespositions/). Ghi chú có thể chứa nhiều văn bản hơn kích thước ảnh cố định có thể chứa. Thay vào đó, sử dụng [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notespositions/).

{{% /alert %}}

## **Chuyển đổi Slides sang ảnh bằng tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của ảnh TIFF đã render.

Ví dụ sau render slide đầu tiên thành ảnh TIFF kích thước 2160 × 2880 với độ phân giải 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Chuyển đổi Tất cả Slides sang ảnh**

Duyệt qua bộ sưu tập slide để chuyển đổi toàn bộ bản trình bày thành một loạt ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách có chủ ý.

Ví dụ sau render mọi slide thành ảnh JPEG với hệ số tỷ lệ chiều ngang và chiều dọc là 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Tạo đầu ra Enhanced Metafile**

Enhanced Metafile (EMF) hữu ích khi cần trao đổi đồ họa dựa trên vector với Microsoft Office hoặc các ứng dụng Windows khác hỗ trợ metafile Windows. Không giống như ảnh dựa trên pixel, EMF có thể giữ lại các thao tác vẽ vector mà không mất độ sắc nét khi phóng to. Tuy nhiên, EMF chủ yếu là định dạng tương thích cho các ứng dụng có hỗ trợ metafile Windows, không phải là định dạng trao đổi chung. Ngoài ra, nội dung slide phức tạp, chẳng hạn như ảnh bitmap và một số hiệu ứng, có thể được lưu dưới dạng các phần tử raster trong container metafile vector.

### **Xuất slide sang EMF**

Phương thức [Slide.write_as_emf](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/write_as_emf/) ghi một [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) vào luồng mục tiêu ở định dạng EMF. Ví dụ sau tải một bản trình bày, chọn slide đầu tiên và ghi nó vào luồng tệp EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Người gọi chịu trách nhiệm quản lý luồng được truyền cho [Slide.write_as_emf](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/write_as_emf/) và phải đóng luồng. Aspose.Slides ghi vào vị trí hiện tại của luồng và để luồng mở.

### **Chuyển đổi ảnh SVG sang EMF và thêm vào bản trình bày**

Sử dụng [SvgImage.write_as_emf](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/write_as_emf/) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bản trình bày qua [ImageCollection.add_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/add_image/) và đặt lên slide bằng [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/).

Ví dụ sau tạo một [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/) từ markup SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile vào slide đầu tiên và lưu bản trình bày:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/write_as_emf/) không nắm quyền sở hữu luồng đích. Sau khi ghi, vị trí luồng sẽ ở cuối dữ liệu đã tạo. Gọi `getvalue` để lấy toàn bộ buffer bất kể vị trí hiện tại của luồng, như trong ví dụ trên. Giữ luồng mở cho đến khi dữ liệu đã được đọc, sau đó đóng lại.

Việc tạo EMF khả dụng trên các hệ điều hành được Aspose.Slides for Python via .NET hỗ trợ, nhưng quá trình render có thể khác nhau giữa các nền tảng khi font hoặc phụ thuộc đồ họa gốc không có sẵn. Cài đặt các font được sử dụng trong nội dung nguồn hoặc cấu hình các thay thế phù hợp, tuân thủ [yêu cầu nền tảng](/slides/vi/python-net/system-requirements/) cho Aspose.Slides, và xác thực kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng Linux và macOS thường có hỗ trợ hạn chế hoặc không đồng nhất cho việc hiển thị và chỉnh sửa metafile Windows.

## **Render Emoji Màu**

{{% alert title="Note" color="info" %}}

Để render emoji màu đúng cách khi chuyển đổi slide trình bày sang ảnh, các font emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** mà font này thiếu, emoji có thể xuất hiện dưới dạng đơn sắc trong ảnh đầu ra.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt hình không?**

Không. Phương thức [Slide.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/) render một hình ảnh tĩnh của slide và không xuất hoạt hình.

**Có thể xuất các slide ẩn thành ảnh không?**

Có. Các slide ẩn có thể được render giống như các slide thường. Bao gồm chúng trong vòng xử lý, như trong ví dụ ở trên.

**Bóng đổ và các hiệu ứng khác có được giữ lại trong ảnh slide không?**

Có. Aspose.Slides render bóng đổ, độ trong suốt và các hiệu ứng đồ họa được hỗ trợ khác trong ảnh slide.