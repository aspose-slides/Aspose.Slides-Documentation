---
title: Chuyển đổi các bài thuyết trình PowerPoint sang HTML trong Python
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/python-net/convert-powerpoint-to-html/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang HTML
- bài thuyết trình sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- lưu PowerPoint dưới dạng HTML
- lưu bài thuyết trình dưới dạng HTML
- lưu slide dưới dạng HTML
- lưu PPT dưới dạng HTML
- lưu PPTX dưới dạng HTML
- xuất PPT sang HTML
- xuất PPTX sang HTML
- Python
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PowerPoint sang HTML trong Python. Sử dụng Aspose.Slides để xuất các tệp PPT và PPTX, các slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và phương tiện."
---
## **Tổng quan**

Aspose.Slides for Python thông qua .NET có thể lưu các bài thuyết trình PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Quy trình chuyển đổi cơ bản là tải một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) duy nhất và gọi `save` với [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/) khi bạn cần kiểm soát bố cục, phông chữ, hình ảnh, ghi chú, nhận xét, đầu ra SVG, hoặc các tài nguyên được liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tiễn:

- Xuất toàn bộ bài thuyết trình hoặc các slide đã chọn.
- Tạo HTML có bố cục cố định, đáp ứng hoặc dựa trên SVG.
- Bao gồm ghi chú người trình bày và nhận xét.
- Kiểm soát chất lượng hình ảnh và dữ liệu hình ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng biệt.
- Chọn cách các tài nguyên bên ngoài và tệp phương tiện được ghi và tham chiếu.

Mặc định, xuất HTML tạo ra một tài liệu HTML tự chứa trong đó hầu hết các tài nguyên được nhúng. Điều này tiện lợi cho việc chia sẻ một tệp, nhưng có thể làm tăng kích thước đầu ra. Đối với xuất bản web, hãy xem xét các tài nguyên bên ngoài, giảm DPI hình ảnh và chỉ nhúng các phông chữ không có sẵn đáng tin cậy trong môi trường đích.

## **Chuyển đổi một Presentation sang HTML**

Để xuất một bài thuyết trình sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và lưu nó bằng [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Ví dụ này ghi một tệp HTML. `Câu lệnh with` giải phóng đối tượng presentation và giải phóng các handle tệp và tài nguyên rendering sau khi xuất.

## **Sử dụng HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/) là lớp cấu hình chính cho xuất HTML. Các thiết lập phổ biến bao gồm:

- `slides_layout_options`: thêm ghi chú, nhận xét, tài liệu phát tay hoặc thông tin bố cục khác.
- `html_formatter`: thay đổi cấu trúc tài liệu HTML hoặc ủy thác định dạng cho một controller.
- `slide_image_format`: thay đổi cách các slide được biểu diễn, ví dụ dưới dạng SVG.
- `pictures_compression`: kiểm soát DPI hình ảnh và kích thước đầu ra.
- `delete_pictures_cropped_areas`: giữ hoặc xóa dữ liệu hình ảnh đã cắt.
- `svg_responsive_layout`: làm cho nội dung SVG xuất ra thích nghi với container của nó.
- `show_hidden_slides`: bao gồm các slide ẩn khi cần.

Những phần sau đây hiển thị các tùy chọn phổ biến nhất riêng biệt để bạn có thể kết hợp chỉ những tùy chọn mà quy trình công việc của bạn cần.

## **Chuyển đổi các Slide đã chọn sang HTML**

`Phương thức overload save` chấp nhận số slide sử dụng vị trí slide bắt đầu từ 1. Vòng lặp dưới đây lưu mỗi slide vào một tệp HTML riêng.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Sử dụng mẫu này khi một trang web hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide nên có cùng bố cục, tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/) và truyền nó vào mỗi lần gọi `save`.

## **Tạo HTML đáp ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmlformatter/). Sử dụng nó khi trang xuất ra cần thích nghi tốt hơn với chiều rộng trình duyệt.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Đối với bố cục đáp ứng dựa trên SVG, thiết lập `svg_responsive_layout` trên [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/). Điều này hữu ích khi nội dung slide được xuất dưới dạng markup SVG có thể mở rộng.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Bao gồm Ghi chú người trình bày và Nhận xét**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/notescommentslayoutingoptions/) qua `html_options.slides_layout_options` để bao gồm ghi chú người trình bày hoặc nhận xét. Ghi chú và nhận xét mặc định bị ẩn trừ khi bạn chọn vị trí của chúng.

Giả sử bài thuyết trình nguồn chứa ghi chú người trình bày:

![Slide có ghi chú người trình bày trong PowerPoint](slide_with_notes.png)

Mã sau xuất nội dung slide cùng với ghi chú người trình bày bên dưới slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

![Đầu ra HTML với slide và ghi chú người trình bày](HTML_with_notes.png)

Để xuất nhận xét, đặt `comments_position`, ví dụ `CommentsPositions.RIGHT` hoặc `CommentsPositions.BOTTOM`. Nếu chỉ cần nhận xét, bỏ qua `notes_position`. Nếu cần cả ghi chú và nhận xét, đặt cả hai thuộc tính.

## **Kiểm soát Chất lượng Hình ảnh và Các Vùng Đã Cắt**

Xuất HTML có thể nén các hình ảnh slide để giảm kích thước đầu ra. Đặt `pictures_compression` thành một giá trị từ [PicturesCompression](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/picturescompression/) khi bạn cần chất lượng hình ảnh cao hơn.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Mặc định, các khu vực đã cắt của hình ảnh có thể bị loại bỏ khỏi đầu ra xuất. Giữ dữ liệu đã cắt chỉ khi người dùng cần có khả năng khôi phục hoặc kiểm tra các phần hình ảnh ẩn đó. Giữ lại có thể làm tăng kích thước HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Thêm CSS**

Đối với kiểu dáng đơn giản, truyền một chuỗi CSS vào [HtmlFormatter](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmlformatter/). Điều này thay đổi tài liệu HTML bao quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS liên kết, hoặc markup tùy chỉnh quanh các slide và shape, sử dụng một controller định dạng tùy chỉnh và truyền nó vào [HtmlFormatter](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmlformatter/) với `create_custom_formatter`.

## **Nhúng Phông chữ**

Nếu môi trường đích có thể không có các phông chữ của bài thuyết trình được cài đặt, hãy nhúng phông chữ vào HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Việc nhúng cải thiện độ trung thực hình ảnh nhưng làm tăng kích thước đầu ra.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Loại trừ một phông chữ chỉ khi bạn chắc chắn rằng các trình duyệt hoặc hệ thống đích đã cung cấp nó. Đối với phông chữ thương hiệu hoặc phông chữ ít phổ biến, việc nhúng thường an toàn hơn.

## **Liên kết Tệp Phông chữ Thay vì Nhúng Chúng**

Để giảm kích thước tệp HTML, bạn có thể ghi dữ liệu phông chữ vào các tệp WOFF riêng biệt và thêm quy tắc `@font-face` vào HTML. Điều này yêu cầu một controller tùy chỉnh cách dữ liệu phông chữ được ghi trong quá trình xuất. Trong Python qua .NET, triển khai controller đó trong một assembly trợ giúp .NET nhỏ, tải nó trong Python, và truyền đối tượng trợ giúp vào [HtmlFormatter](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmlformatter/) với `create_custom_formatter`.

Khi bạn tách riêng phông chữ, hãy chọn hai đường dẫn một cách có ý thức:

- Thư mục đầu ra trên hệ thống tập tin nơi các tệp WOFF được tạo sẽ được ghi.
- Đường dẫn URL sẽ xuất hiện trong tài liệu HTML và trình duyệt sẽ sử dụng để tải các tệp phông chữ đó.

Giữ tệp HTML và các tệp phông chữ đã tạo cùng nhau cho đến khi các đường dẫn triển khai cuối cùng. Nếu các tệp được triển khai tới vị trí khác, hãy làm cho tiền tố URL khớp với đường dẫn URL đã triển khai.

## **Lưu Tài nguyên Bên ngoài**

HTML tự chứa dễ di chuyển, nhưng các tài nguyên Base64 nhúng có thể làm tệp lớn. Nếu ứng dụng của bạn cần các tệp hình ảnh, phông chữ, âm thanh hoặc video bên ngoài, sử dụng một controller liên kết/nhúng tùy chỉnh và truyền nó vào hàm tạo [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/).

Khi bạn tách riêng tài nguyên, hãy chọn hai đường dẫn một cách có ý thức:

- Đường dẫn đầu ra trên hệ thống tập tin, nơi ứng dụng của bạn ghi các hình ảnh, phông chữ, âm thanh hoặc video được tạo.
- Đường dẫn URL, là những gì trình duyệt sử dụng từ tài liệu HTML để tải các tệp đó.

Để tham khảo chi tiết về việc liên kết hình ảnh, xem [Export Presentations to HTML with Externally Linked Images](/slides/vi/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Xuất Tệp Phương Tiện**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/videoplayerhtmlcontroller/) xuất các tệp video và âm thanh và ghi HTML có thể phát chúng trong trình duyệt. Hàm tạo của nó nhận:

- `path`: thư mục nơi các tệp phương tiện được tạo sẽ được ghi.
- `file_name`: tên tệp HTML đang được tạo.
- `base_uri`: tiền tố URI tuyệt đối được sử dụng trong các liên kết HTML tới các tệp phương tiện.

Nếu tệp HTML là `html-output/presentation.html` và các tệp phương tiện được lưu trong `html-output/media`, `path` nên trỏ tới thư mục media trên đĩa, trong khi `base_uri` nên trỏ tới cùng thư mục từ quan điểm của trình duyệt. Đối với xem trước cục bộ, bạn có thể tạo URI `file:///` từ thư mục media. Đối với ứng dụng đã triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Sử dụng các thư mục đầu ra độc nhất cho mỗi công việc xuất, đặc biệt trong các ứng dụng máy chủ. Các đường dẫn đầu ra chung có thể gây các tệp từ các lần chuyển đổi khác nhau ghi đè lên nhau.

## **Hiệu năng và Quản lý Tài nguyên**

Chuyển đổi HTML là một hoạt động render, vì vậy thời gian xử lý và sử dụng bộ nhớ phụ thuộc vào số lượng slide, độ phân giải hình ảnh, phông chữ, hiệu ứng, biểu đồ và phương tiện nhúng. Giá trị DPI `pictures_compression` cao hơn, phông chữ nhúng, đầu ra SVG, và việc giữ lại các khu vực hình ảnh đã cắt có thể cải thiện độ trung thực nhưng thường làm tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Giải phóng ngay mỗi thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
- Sử dụng các thư mục đầu ra riêng biệt cho các công việc riêng.
- Tránh nhúng các phông chữ chung trừ khi độ trung thực yêu cầu.
- Giảm DPI hình ảnh khi HTML chỉ dùng cho xem trước hoặc hình thu nhỏ.
- Giữ bài thuyết trình nguồn, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho đến khi các đường dẫn triển khai cuối cùng.

## **Câu hỏi thường gặp**

**Liệu các siêu liên kết có được giữ lại trong đầu ra HTML không?**

Có. Các siêu liên kết trong Presentation được xuất ra HTML và vẫn có thể nhấp khi URL đích hợp lệ.

**Có thể chuyển đổi các bài thuyết trình sang HTML song song không?**

Có, nhưng không chia sẻ một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) giữa các luồng. Xử lý các tệp khác nhau với các thể hiện presentation riêng, các stream riêng và các thư mục đầu ra riêng. Xem hướng dẫn [multithreading guidance](/slides/vi/python-net/multithreading/) để biết chi tiết.

**Đối tượng Presentation có an toàn với đa luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) nên được tải, sửa đổi, lưu và giải phóng trên một luồng duy nhất. Đối với công việc song song, tạo một thể hiện độc lập cho mỗi luồng hoặc tiến trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Mặc định xuất có thể nhúng tài nguyên trực tiếp vào HTML. Các phông chữ nhúng, hình ảnh DPI cao, phương tiện, nội dung SVG và việc giữ lại các khu vực hình ảnh đã cắt cũng làm tăng kích thước. Sử dụng tài nguyên bên ngoài, loại trừ các phông chữ chung khỏi việc nhúng, và giảm `pictures_compression` khi kích thước nhỏ hơn quan trọng hơn độ trung thực tối đa.

**Tại sao kích thước phông chữ PowerPoint như 24 pt lại xuất hiện là 17.999819 pt trong HTML?**

Điều này có thể xảy ra vì PowerPoint và HTML sử dụng các mô hình DPI khác nhau. PowerPoint lưu kích thước văn bản bằng điểm kiểu chữ dựa trên 72 DPI, trong khi bố cục HTML dựa trên pixel CSS trong mô hình 96 DPI. Khi Aspose.Slides xuất một presentation sang HTML, kích thước phông chữ được dịch giữa các hệ thống này, và quá trình chuyển đổi có thể gây ra sự khác biệt làm tròn nhỏ.

Những giá trị này không cho thấy sự thay đổi thực tế về kích thước phông chữ. Chúng chỉ là hiệu ứng phụ toán học khi chuyển đổi các chỉ số văn bản giữa PowerPoint và HTML.

**Làm thế nào để chọn base_uri cho việc xuất phương tiện?**

Chọn `base_uri` từ quan điểm của trình duyệt và truyền nó dưới dạng URI tuyệt đối. Đối với xem trước cục bộ, bạn có thể tạo nó từ thư mục đầu ra bằng `Path(media_directory).as_uri() + "/"`. Đối với triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố. Tham số `path` trên hệ thống tệp và `base_uri` trên trình duyệt không cần phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí tài nguyên.

**Có thể bao gồm các slide ẩn không?**

Có. Đặt `show_hidden_slides = True` trên [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/) khi các slide ẩn cần được xuất.