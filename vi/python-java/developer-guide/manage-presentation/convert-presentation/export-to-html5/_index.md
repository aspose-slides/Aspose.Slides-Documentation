---
title: Chuyển đổi Bản trình chiếu sang HTML5 trong Python qua Java
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

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang HTML5 bằng Aspose.Slides cho Python thông qua Java. Nó bao gồm xuất cơ bản, kiểm soát hoạt ảnh hình dạng và chuyển đổi slide, và bố cục nhận xét. Ngoài ra, nó so sánh đầu ra HTML5 với đầu ra dựa trên SVG của việc xuất HTML tiêu chuẩn.

Các ví dụ yêu cầu Aspose.Slides cho Python thông qua Java và một môi trường chạy Java tương thích. Đặt các bản trình chiếu đầu vào trong thư mục làm việc hiện tại. Mỗi ví dụ sẽ khởi động JVM chỉ khi nó chưa chạy.

## **Xuất PowerPoint sang HTML5**

Ví dụ sau tải một bản trình chiếu từ thư mục làm việc và lưu nó ở định dạng HTML5. Nó sử dụng các cài đặt xuất mặc định; ví dụ tiếp theo cho thấy cách kiểm soát việc phát hoạt ảnh một cách rõ ràng. Thay thế đường dẫn đầu vào bằng đường dẫn tới bản trình chiếu của bạn.

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

{{% alert color="info" title="Note" %}}
Ngoài tài liệu HTML, quá trình xuất còn ghi các tệp CSS và JavaScript hỗ trợ cho việc tạo kiểu slide, hoạt ảnh, hiệu ứng và điều hướng. Giữ những tệp này cùng với tài liệu HTML khi di chuyển hoặc xuất bản kết quả. Trang được tạo cũng tải jQuery và Anime.js từ các CDN công cộng; nếu không, việc điều hướng slide và hoạt ảnh sẽ không chạy.
{{% /alert %}}

Để xuất mà không phát hoạt ảnh hình dạng hoặc chuyển đổi slide, truyền `False` cho [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) và [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) trong [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Các cài đặt này độc lập, vì vậy bạn có thể bật một trong khi tắt cái còn lại. Ví dụ này xuất bản trình chiếu với cả hai loại hoạt ảnh bị vô hiệu hoá trong trang được tạo.

```python
import jpake
import asposeslides

if not jpake.isJVMStarted():
    jpake.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Xuất PowerPoint sang HTML**

Quá trình xuất HTML tiêu chuẩn sử dụng một cách tiếp cận render khác: nội dung slide được biểu diễn bằng SVG trong một trang HTML. Ví dụ sau chuyển một bản trình chiếu sang tài liệu HTML bằng cách render này.

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

Mã markup đơn giản bên dưới minh họa cấu trúc của trang được tạo. Phần tử SVG chứa nội dung slide đã được render; văn bản placeholder đại diện cho nội dung đó và không phải là đầu ra thực tế của việc xuất.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Xuất dựa trên SVG không hiển thị các hình dạng PowerPoint dưới dạng các phần tử HTML riêng lẻ. Hãy sử dụng xuất HTML5 khi bạn cần các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide được minh họa trong bài viết này.
{{% /alert %}}

## **Xuất PowerPoint sang chế độ xem Slide HTML5**

Xuất HTML5 tạo ra một trang để xem và điều hướng các slide của bản trình chiếu trong trình duyệt. Ví dụ này bật cả [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) và [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) để chế độ xem slide đã xuất có thể phát các hiệu ứng từ bản trình chiếu nguồn.

Sử dụng một bản trình chiếu đã chứa các hoạt ảnh hình dạng và chuyển đổi slide để thấy hiệu quả của các cài đặt này. Bật chúng không thêm hiệu ứng mới cho các slide không có. Sau khi xuất, mở tài liệu HTML5 đã tạo trong trình duyệt cùng với các tệp hỗ trợ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Chuyển đổi bản trình chiếu sang tài liệu HTML5 có bình luận**

Bạn có thể bao gồm các bình luận slide hiện có trong đầu ra HTML5 để người đọc có thể xem phản hồi bên cạnh nội dung slide. Ví dụ trong phần này giả định bản trình chiếu nguồn chứa các bình luận, như minh họa dưới đây. Nó xuất các bình luận đó; không tạo bình luận mới.

![Hai bình luận trên slide của bản trình chiếu](two_comments_pptx.png)

Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) cho phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) của [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Sử dụng [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) để chọn `Right` từ liệt kê [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) để đặt các bình luận ở bên phải mỗi slide.

Ví dụ sau xuất bản trình chiếu sang HTML5 với bố cục bình luận này. Một bản trình chiếu không có bình luận sẽ không có văn bản bình luận để hiển thị.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Loại trừ siêu liên kết JavaScript khi xuất**

Giả sử `hyperlinks.pptx` chứa văn bản liên kết với đích `javascript:alert('Hello')` và một liên kết thông thường `https://example.com/`. Để loại trừ siêu liên kết JavaScript khi xuất, truyền `True` cho [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Mặc định là `False`, vì vậy các liên kết này sẽ không bị lọc trừ khi bạn bật tùy chọn.

Ví dụ sau tải bản trình chiếu từ thư mục làm việc và xuất nó bằng [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Tệp đã xuất bỏ qua siêu liên kết JavaScript nhưng vẫn giữ lại văn bản và liên kết HTTPS thông thường. Bản trình chiếu nguồn không thay đổi.

Tùy chọn này lọc các siêu liên kết JavaScript; nó không loại bỏ tất cả các script hoặc nội dung hoạt động khác, cũng không đảm bảo tuân thủ CSP. Ví dụ, đầu ra HTML5 vẫn bao gồm các script cho việc điều hướng slide và hoạt ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có phát trong HTML5 không?**

Có, xuất HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) và [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Có hỗ trợ bình luận không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, các bình luận hiện có có thể được đưa vào đầu ra HTML5 và đặt vị trí (ví dụ, bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) cho ghi chú và bình luận.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, cài đặt [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Mặc định là `False`. Xem [Exclude JavaScript Hyperlinks During Export](/slides/vi/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) để biết ví dụ xuất HTML5 và phạm vi của bộ lọc. Cài đặt này không loại bỏ JavaScript được sử dụng bởi trình xem HTML5 cho việc điều hướng và hoạt ảnh.