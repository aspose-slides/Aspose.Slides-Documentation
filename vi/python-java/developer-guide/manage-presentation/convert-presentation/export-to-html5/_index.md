---
title: Chuyển đổi bản trình chiếu sang HTML5 trong Python qua Java
linktitle: Bản trình chiếu sang HTML5
type: docs
weight: 40
url: /vi/python-java/export-to-html5/
keywords:
- PowerPoint sang HTML5
- OpenDocument sang HTML5
- bản trình chiếu sang HTML5
- slide sang HTML5
- PPT sang HTML5
- PPTX sang HTML5
- ODP sang HTML5
- lưu PPT dưới dạng HTML5
- lưu PPTX dưới dạng HTML5
- lưu ODP dưới dạng HTML5
- xuất PPT sang HTML5
- xuất PPTX sang HTML5
- xuất ODP sang HTML5
- Python
- Java
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Python qua Java. Bảo toàn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm việc xuất HTML5 cơ bản mà không có các tiện ích mở rộng web bổ sung, cũng như các tùy chọn để kiểm soát hoạt ảnh hình dạng và chuyển đổi slide. Bài viết cũng trình bày quy trình xuất chuẩn từ PowerPoint sang HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách bao gồm bình luận trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

Các ví dụ yêu cầu Aspose.Slides for Python via Java và một môi trường Java tương thích. Đặt `pres.pptx` (hoặc `sample.pptx` cho ví dụ bình luận) trong thư mục làm việc hiện tại. Mỗi ví dụ sẽ khởi động JVM chỉ khi nó chưa được chạy.

## **Xuất PowerPoint sang HTML5**

Sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat.Html5](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Html5) để xuất bản trình chiếu mà không có các tiện ích mở rộng web bổ sung:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Lưu ý" %}} 

Trình xuất HTML5 tạo nội dung HTML để xem trong trình duyệt. 

{{% /alert %}}

Sử dụng [Html5Options](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/) để cấu hình quá trình xuất. Gọi [setAnimateShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateShapes) và [setAnimateTransitions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateTransitions) với `False` để tắt hoạt ảnh hình dạng và chuyển đổi slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Xuất PowerPoint sang HTML**

Sử dụng [SaveFormat.Html](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Html) cho việc xuất HTML chuẩn. Xem [Convert PowerPoint to HTML](/slides/vi/python-java/convert-powerpoint-to-html/) để biết thêm tùy chọn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Trong trường hợp này, nội dung bản trình bày được hiển thị thông qua SVG dưới dạng như sau:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Cảnh báo" color="warning" %}} 

Xuất HTML chuẩn hiển thị nội dung slide qua SVG và không cung cấp các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide của HTML5. 

{{% /alert %}}

## **Xuất PowerPoint sang HTML5 ở chế độ xem Slide**

**Aspose.Slides** cho phép bạn chuyển đổi bản trình bày PowerPoint sang tài liệu HTML5 trong đó các slide được hiển thị ở chế độ xem slide. Khi mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bản trình bày ở chế độ xem slide trên trang web.

Mã Python này trình diễn quá trình xuất PowerPoint sang HTML5 ở chế độ xem Slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Chuyển đổi bản trình bày sang tài liệu HTML5 có bình luận**

Bình luận trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide. Chúng rất hữu ích trong các dự án cộng tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét vào các thành phần slide cụ thể mà không làm thay đổi nội dung chính. Mỗi bình luận hiển thị tên tác giả, giúp dễ dàng theo dõi người để lại nhận xét.

Giả sử chúng ta có bản trình bày PowerPoint sau được lưu trong tệp "sample.pptx".

![Hai bình luận trên slide trình bày](two_comments_pptx.png)

Khi chuyển đổi bản trình bày PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định xem có bao gồm bình luận từ bản trình bày trong tài liệu đầu ra hay không. Để thực hiện, truyền các tham số hiển thị cho bình luận vào phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) của lớp [Html5Options](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/).

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) và [setCommentsPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) với [CommentsPositions.Right](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commentspositions/#Right). Đoạn mã sau chuyển đổi bản trình bày sang tài liệu HTML5 với bình luận được hiển thị ở phía bên phải của các slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Tài liệu "output.html" được hiển thị trong hình ảnh dưới đây.

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc hoạt ảnh đối tượng và chuyển đổi slide có phát trong HTML5 hay không?**

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateShapes) và [slide transitions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Đầu ra của bình luận có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, bình luận có thể được thêm vào HTML5 và đặt (ví dụ, ở bên phải slide) thông qua [cài đặt bố cục](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) cho ghi chú và bình luận.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, có một [setting](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này sẽ loại bỏ các liên kết đó; nó không tự động đảm bảo rằng tất cả các kịch bản HTML5 được tạo đáp ứng Chính sách Bảo mật Nội dung của trang web.