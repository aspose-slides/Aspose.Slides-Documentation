---
title: Chuyển đổi Bài thuyết trình PowerPoint sang HTML trong Python qua Java
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/python-java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PowerPoint sang HTML trong Python qua Java. Sử dụng Aspose.Slides để xuất các tệp PPT và PPTX, các slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và media."
---
## **Tổng quan**

Aspose.Slides for Python via Java có thể lưu các bài thuyết trình PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Chuyển đổi cơ bản chỉ bao gồm một lần tải [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và một lời gọi [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/) khi bạn cần kiểm soát bố cục xuất, phông chữ, hình ảnh, ghi chú, bình luận, đầu ra SVG, hoặc các tài nguyên liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tế:

- Xuất toàn bộ bài thuyết trình hoặc các slide đã chọn.
- Tạo HTML có bố cục cố định, đáp ứng, hoặc dựa trên SVG.
- Bao gồm ghi chú người thuyết trình và bình luận.
- Kiểm soát chất lượng hình ảnh và dữ liệu hình ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng biệt.
- Chọn cách các tài nguyên bên ngoài và tệp media được ghi và tham chiếu.

Mặc định, xuất HTML tạo ra một tài liệu HTML tự chứa, trong đó hầu hết các tài nguyên được nhúng. Điều này tiện lợi cho việc chia sẻ một tệp, nhưng có thể làm tăng kích thước đầu ra. Đối với xuất bản trên web, hãy cân nhắc sử dụng tài nguyên bên ngoài, giảm DPI hình ảnh, và chỉ nhúng các phông chữ không có sẵn đáng tin cậy trong môi trường mục tiêu.

## **Chuyển đổi Bài thuyết trình sang HTML**

Để xuất một bài thuyết trình sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và lưu nó bằng [SaveFormat.Html](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Mỗi ví dụ tải `presentation.pptx` từ thư mục làm việc hiện tại. Cài đặt Aspose.Slides cho Python qua Java và một môi trường chạy Java tương thích trước khi chạy. JVM được khởi động một lần cho mỗi tiến trình Python.

Ví dụ này ghi một tệp HTML. Đối tượng presentation được giải phóng trong khối `finally`, giúp giải phóng các tay cầm tệp và tài nguyên render sau khi xuất.

## **Cấu hình Xuất HTML**

[HtmlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/) là lớp cấu hình chính cho xuất HTML. Các thiết lập chung bao gồm:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): thêm ghi chú, bình luận, tài liệu phát tay, hoặc các thông tin bố cục khác.
- [setHtmlFormatter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setHtmlFormatter): thay đổi cấu trúc tài liệu HTML hoặc ủy thác việc định dạng cho một bộ điều khiển.
- [setSlideImageFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setSlideImageFormat): thay đổi cách các slide được biểu diễn, ví dụ dưới dạng SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setPicturesCompression): kiểm soát DPI hình ảnh và kích thước đầu ra.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): giữ hoặc loại bỏ dữ liệu hình ảnh đã cắt.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): làm cho nội dung SVG xuất ra thích nghi với container của nó.
- [setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): bao gồm các slide ẩn khi cần.

Các phần sau đây hiển thị các tùy chọn phổ biến nhất riêng biệt để bạn có thể kết hợp chỉ những tùy chọn cần thiết cho quy trình làm việc của mình.

## **Chuyển đổi các Slide Được Chọn sang HTML**

Phiên bản overload của [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) chấp nhận số slide sử dụng vị trí slide bắt đầu từ 1. Vòng lặp dưới đây lưu mỗi slide vào một tệp HTML riêng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Sử dụng mẫu này khi một trang web hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide nên có cùng bố cục, tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/) và truyền nó vào mỗi lời gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save).

## **Tạo HTML Đáp ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/python-java/aspose.slides/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmlformatter/). Sử dụng nó khi trang xuất ra cần thích nghi tốt hơn với độ rộng trình duyệt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Đối với bố cục đáp ứng dựa trên SVG, gọi [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) với `True`. Điều này hữu ích khi nội dung slide được xuất dưới dạng markup SVG có thể mở rộng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Bao gồm Ghi chú Người thuyết trình và Bình luận**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) thông qua [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) để bao gồm ghi chú người thuyết trình hoặc bình luận. Ghi chú và bình luận mặc định được ẩn trừ khi bạn chọn vị trí của chúng.

Giả sử bài thuyết trình nguồn chứa ghi chú người thuyết trình:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Mã sau xuất nội dung slide kèm ghi chú người thuyết trình dưới slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

HTML đã xuất bao gồm vùng ghi chú:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Để xuất bình luận, gọi [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) ví dụ với [CommentsPositions.Right](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commentspositions/#Right) hoặc [CommentsPositions.Bottom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commentspositions/#Bottom). Nếu chỉ cần bình luận, bỏ qua [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Nếu cần cả ghi chú và bình luận, gọi cả hai phương thức.

## **Kiểm soát Chất lượng Hình ảnh và Các Khu vực Đã Cắt**

Xuất HTML có thể nén hình ảnh slide để giảm kích thước đầu ra. Truyền một giá trị vào [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setPicturesCompression) từ [PicturesCompression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturescompression/) khi bạn cần chất lượng hình ảnh cao hơn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Mặc định, các khu vực đã cắt của hình ảnh có thể bị loại bỏ khỏi đầu ra đã xuất. Giữ dữ liệu đã cắt chỉ khi người dùng cần khôi phục hoặc kiểm tra các phần hình ảnh ẩn đó. Việc giữ lại có thể làm tăng kích thước HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Thêm CSS**

Đối với kiểu dáng đơn giản, truyền một chuỗi CSS vào [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Điều này sẽ thay đổi tài liệu HTML bao quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS liên kết, hoặc markup tùy chỉnh quanh các slide và hình dạng, sử dụng bộ điều khiển định dạng tùy chỉnh qua một proxy giao diện JPype và truyền nó vào [HtmlFormatter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmlformatter/) bằng [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Nhúng Phông chữ**

Nếu môi trường mục tiêu có thể không có các phông chữ của bài thuyết trình được cài đặt, hãy nhúng phông chữ trong HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/python-java/aspose.slides/embedallfontshtmlcontroller/). Việc nhúng cải thiện độ trung thực hình ảnh nhưng làm tăng kích thước đầu ra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Loại bỏ phông chữ chỉ khi bạn chắc rằng các trình duyệt hoặc hệ thống mục tiêu đã cung cấp chúng. Đối với phông chữ thương hiệu hoặc phông chữ ít phổ biến, việc nhúng thường an toàn hơn.

## **Lưu Tài nguyên Bên ngoài**

HTML tự chứa dễ di chuyển, nhưng các tài nguyên Base64 được nhúng có thể làm tệp lớn. Nếu ứng dụng của bạn cần các tệp hình ảnh bên ngoài, triển khai bộ điều khiển liên kết tài nguyên qua một proxy giao diện JPype và truyền nó vào constructor của [HtmlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/).

Khi bạn tách tài nguyên ra bên ngoài, hãy chọn hai đường dẫn một cách có chủ đích:

- Đường dẫn đầu ra hệ thống tệp, nơi ứng dụng của bạn ghi các hình ảnh, phông chữ, âm thanh hoặc video được tạo.
- Đường dẫn URL, là những gì trình duyệt sử dụng từ tài liệu HTML để tải các tệp đó.

## **Xuất Tệp Media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoplayerhtmlcontroller/) xuất các tệp video và âm thanh và ghi HTML có thể phát chúng trong trình duyệt. Constructor của nó nhận:

- `path`: thư mục nơi các tệp media được tạo sẽ được ghi.
- `fileName`: tên tệp HTML đang được tạo.
- `baseUri`: tiền tố URI tuyệt đối được sử dụng trong các liên kết HTML tới các tệp media.

Ví dụ sau xuất media đã được nhúng trong `presentation.pptx`. HTML được tạo tham chiếu các tệp media chỉ bằng tên tệp, tương đối với tài liệu HTML, vì vậy `path` phải là thư mục cũng nhận tệp HTML. `baseUri` phải là một URI tuyệt đối: đối với xem trước cục bộ, tạo URI `file:///` từ thư mục đầu ra; đối với ứng dụng triển khai, sử dụng URL tuyệt đối của thư mục đã công bố.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Sử dụng các thư mục đầu ra riêng biệt cho mỗi công việc xuất, đặc biệt trong các ứng dụng máy chủ. Các đường dẫn đầu ra chung có thể gây các tệp từ các chuyển đổi khác nhau ghi đè lên nhau.

## **Hiệu năng và Quản lý Tài nguyên**

Chuyển đổi HTML là một hoạt động render, vì vậy thời gian xử lý và dung lượng bộ nhớ phụ thuộc vào số slide, độ phân giải hình ảnh, phông chữ, hiệu ứng, biểu đồ và media được nhúng. Giá trị DPI hình ảnh cao hơn truyền vào [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setPicturesCompression), phông chữ được nhúng, đầu ra SVG, và việc giữ lại các khu vực hình ảnh đã cắt có thể cải thiện độ trung thực nhưng thường làm tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Giải phóng ngay mọi thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Sử dụng các thư mục đầu ra riêng biệt cho từng công việc.
- Tránh nhúng các phông chữ phổ biến trừ khi độ trung thực yêu cầu.
- Giảm DPI hình ảnh khi HTML dùng để xem trước hoặc tạo thumbnail.
- Giữ bài thuyết trình nguồn, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho đến khi đường dẫn triển khai cuối cùng.

## **Câu hỏi thường gặp**

**Liệu các siêu liên kết có được giữ lại trong đầu ra HTML không?**

Có. Các siêu liên kết trong bài thuyết trình được xuất ra HTML và vẫn có thể nhấp chuột khi URL đích hợp lệ.

**Tôi có thể chuyển đổi các bài thuyết trình sang HTML song song không?**

Có, nhưng không nên chia sẻ một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) giữa các luồng. Xử lý các tệp khác nhau với các thể hiện presentation riêng biệt, các stream riêng biệt và các thư mục đầu ra riêng biệt. Xem hướng dẫn [multithreading guidance](/slides/vi/python-java/multithreading/) để biết chi tiết.

**Đối tượng presentation có an toàn với luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) duy nhất nên được tải, sửa đổi, lưu và giải phóng trên một luồng. Đối với công việc song song, tạo một thể hiện độc lập cho mỗi luồng hoặc quy trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Mặc định, xuất có thể nhúng tài nguyên trực tiếp vào HTML. Các phông chữ được nhúng, hình ảnh DPI cao, media, nội dung SVG, và việc giữ lại các khu vực hình ảnh đã cắt cũng làm tăng kích thước. Sử dụng tài nguyên bên ngoài, loại bỏ các phông chữ phổ biến khỏi việc nhúng, và truyền giá trị DPI thấp hơn vào [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setPicturesCompression) khi kích thước đầu ra nhỏ hơn quan trọng hơn độ trung thực tối đa.

**Tại sao giá trị font-size trong HTML có thể khác với giá trị trong PowerPoint?**

Trang đã xuất có thể sử dụng hệ tọa độ SVG và các phép biến đổi tỉ lệ. Một giá trị CSS hoặc SVG font-size thuần túy không mô tả kích thước hiển thị cuối cùng. So sánh slide đã render ở mức phóng đại dự định, và kiểm tra sự có sẵn của phông chữ nếu văn bản trông khác nhau.

**Làm thế nào để chọn baseUri cho việc xuất media?**

Chọn `baseUri` từ góc nhìn của trình duyệt và truyền nó dưới dạng một URI tuyệt đối. Đối với xem trước cục bộ, bạn có thể suy ra nó từ thư mục đầu ra bằng `output_directory.as_uri() + "/"`. Đối với triển khai, sử dụng URL tuyệt đối của thư mục đã công bố. `path` hệ thống tệp và `baseUri` trình duyệt không nhất thiết phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí, và vị trí đó phải là thư mục chứa tệp HTML đã tạo vì các liên kết media được ghi tương đối với nó.

**Tôi có thể bao gồm các slide ẩn không?**

Có. Gọi [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) với `True` khi các slide ẩn phải được xuất.