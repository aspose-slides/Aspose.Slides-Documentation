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
description: "Xuất các bản trình chiếu PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Python qua Java. Bảo toàn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm việc xuất HTML5 cơ bản mà không có các tiện ích mở rộng web bổ sung, cũng như các tùy chọn kiểm soát hoạt ảnh hình dạng và chuyển đổi slide. Bài viết cũng trình bày quy trình xuất tiêu chuẩn từ PowerPoint sang HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách bao gồm nhận xét trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

Các ví dụ yêu cầu Aspose.Slides cho Python qua Java và một môi trường Java tương thích. Đặt `pres.pptx` (hoặc `sample.pptx` cho ví dụ về nhận xét) trong thư mục làm việc hiện tại. Mỗi ví dụ sẽ khởi động JVM chỉ khi nó chưa chạy.

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
Bộ xuất HTML5 tạo nội dung HTML để xem trên trình duyệt. 
{{% /alert %}}

Sử dụng [Html5Options](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/) để cấu hình việc xuất. Gọi [setAnimateShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateShapes) và [setAnimateTransitions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateTransitions) với `False` để tắt hoạt ảnh hình dạng và chuyển đổi slide:

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

Sử dụng [SaveFormat.Html](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Html) cho xuất HTML tiêu chuẩn. Xem [Convert PowerPoint to HTML](/slides/vi/python-java/convert-powerpoint-to-html/) để biết thêm tùy chọn:

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

Trong trường hợp này, nội dung bản trình chiếu được render qua SVG dưới dạng như sau:

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
Xuất HTML tiêu chuẩn render nội dung slide qua SVG và không cung cấp các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide của HTML5. 
{{% /alert %}}

## **Xuất PowerPoint sang HTML5 ở chế độ xem slide**

**Aspose.Slides** cho phép bạn chuyển đổi một bản trình chiếu PowerPoint sang tài liệu HTML5 trong đó các slide được hiển thị ở chế độ xem slide. Trong trường hợp này, khi bạn mở file HTML5 kết quả trong trình duyệt, bạn sẽ thấy bản trình chiếu ở chế độ xem slide trên trang web.

Mã Python này minh họa quy trình xuất PowerPoint sang HTML5 ở chế độ xem slide:

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

## **Chuyển đổi bản trình chiếu sang tài liệu HTML5 có nhận xét**

Nhận xét trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide của bản trình chiếu. Chúng đặc biệt hữu ích trong các dự án cộng tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét vào các thành phần slide cụ thể mà không làm thay đổi nội dung chính. Mỗi nhận xét hiển thị tên tác giả, giúp dễ dàng theo dõi ai đã để lại nhận xét.

Giả sử chúng ta có bản trình chiếu PowerPoint sau được lưu trong tệp "sample.pptx" file.

![Hai nhận xét trên slide bản trình chiếu](two_comments_pptx.png)

Khi bạn chuyển đổi một bản trình chiếu PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định có bao gồm nhận xét từ bản trình chiếu trong tài liệu đầu ra hay không. Để thực hiện điều này, truyền các tham số hiển thị cho nhận xét vào phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) của lớp [Html5Options](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/) .

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) và [setCommentsPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) với [CommentsPositions.Right](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commentspositions/#Right). Ví dụ mã sau chuyển đổi một bản trình chiếu sang tài liệu HTML5 với các nhận xét được hiển thị bên phải các slide.

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

![Các nhận xét trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có được phát trong HTML5 không?**  

Có, HTML5 cung cấp các tùy chọn riêng biệt để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateShapes) và [slide transitions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Có thể xuất nhận xét không, và chúng có thể được đặt ở vị trí nào so với slide?**  

Có, nhận xét có thể được thêm vào HTML5 và đặt vị trí (ví dụ, bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions).

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**  

Có, có một [setting](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này sẽ loại bỏ các liên kết đó; nó không tự động đảm bảo rằng mọi script HTML5 được tạo ra đều đáp ứng Content Security Policy của trang web.