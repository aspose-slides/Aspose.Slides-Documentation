---
title: "Chuyển Đổi Bản Trình Chiếu sang HTML5 trong Python"
linktitle: "Bản Trình Chiếu sang HTML5"
type: docs
weight: 40
url: /vi/python-net/export-to-html5/
keywords:
- "PowerPoint sang HTML5"
- "OpenDocument sang HTML5"
- "bản trình chiếu sang HTML5"
- "slide sang HTML5"
- "PPT sang HTML5"
- "PPTX sang HTML5"
- "ODP sang HTML5"
- "lưu PPT dưới dạng HTML5"
- "lưu PPTX dưới dạng HTML5"
- "lưu ODP dưới dạng HTML5"
- "xuất PPT sang HTML5"
- "xuất PPTX sang HTML5"
- "xuất ODP sang HTML5"
- "Python"
- "Aspose.Slides"
description: "Xuất bản trình chiếu PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Python qua .NET. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint sang HTML5 bằng Aspose.Slides cho Python qua .NET. Nó bao phủ việc xuất cơ bản, kiểm soát hoạt ảnh hình dạng và chuyển đổi slide, và bố cục bình luận. Nó cũng so sánh đầu ra HTML5 với đầu ra dựa trên SVG của việc xuất HTML tiêu chuẩn.

## **Xuất PowerPoint sang HTML5**

Ví dụ sau tải một bản trình chiếu từ thư mục làm việc và lưu nó ở định dạng HTML5. Nó sử dụng các cài đặt xuất mặc định; ví dụ tiếp theo cho thấy cách kiểm soát việc phát hoạt ảnh một cách rõ ràng. Thay thế đường dẫn đầu vào bằng đường dẫn tới bản trình chiếu của bạn.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Ngoài tài liệu HTML, quá trình xuất còn ghi các tệp CSS và JavaScript hỗ trợ để tạo kiểu cho slide, hoạt ảnh, hiệu ứng và điều hướng. Giữ các tệp này cùng với tài liệu HTML khi di chuyển hoặc xuất bản kết quả. Trang được tạo cũng tải jQuery và Anime.js từ các CDN công cộng; nếu không có chúng, việc điều hướng slide và hoạt ảnh sẽ không hoạt động.
{{% /alert %}}

Để xuất mà không phát hoạt ảnh hình dạng hoặc chuyển đổi slide, đặt [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) và [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) thành `False` trong [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Các cài đặt này độc lập, vì vậy bạn có thể bật một trong khi tắt cái kia. Ví dụ xuất bản trình chiếu với cả hai loại hoạt ảnh bị tắt trong trang được tạo.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Xuất PowerPoint sang HTML**

Quá trình xuất HTML tiêu chuẩn sử dụng một cách tiếp cận render khác: nội dung slide được biểu diễn bằng SVG trong một trang HTML. Ví dụ sau chuyển đổi một bản trình chiếu thành tài liệu HTML bằng cách render này.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Mã HTML đơn giản bên dưới minh họa cấu trúc của trang được tạo. Thành phần SVG chứa nội dung slide đã render; văn bản placeholder đại diện cho nội dung đó và không phải là đầu ra thực tế của quá trình xuất.

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
Quá trình xuất dựa trên SVG không tiết lộ các hình dạng PowerPoint dưới dạng các phần tử HTML riêng lẻ. Hãy sử dụng xuất HTML5 khi bạn cần các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide được trình bày trong bài viết này.
{{% /alert %}}

## **Xuất PowerPoint sang chế độ xem Slide HTML5**

Xuất HTML5 tạo ra một trang để xem và điều hướng các slide của bản trình chiếu trong trình duyệt. Ví dụ này bật cả [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) và [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) để chế độ xem slide đã xuất có thể phát các hiệu ứng từ bản trình chiếu gốc.

Sử dụng một bản trình chiếu đã chứa hoạt ảnh hình dạng và chuyển đổi slide để thấy hiệu quả của các cài đặt này. Bật chúng không thêm hiệu ứng mới cho các slide không có. Sau khi xuất, mở tài liệu HTML5 đã tạo trong trình duyệt với các tệp hỗ trợ sẵn sàng.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Chuyển đổi một bản trình chiếu thành tài liệu HTML5 có bình luận**

Bạn có thể đưa các bình luận slide hiện có vào đầu ra HTML5 để người đọc có thể thấy phản hồi bên cạnh nội dung slide. Ví dụ trong phần này giả định bản trình chiếu nguồn chứa bình luận, như minh họa bên dưới. Nó xuất các bình luận đó; không tạo bình luận mới.

![Hai bình luận trên slide bản trình chiếu](two_comments_pptx.png)

Gán một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) vào thuộc tính [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) của [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Đặt [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) thành `RIGHT` từ enum [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) để đặt các bình luận ở bên phải mỗi slide.

Ví dụ sau xuất bản trình chiếu sang HTML5 với bố cục bình luận này. Một bản trình chiếu không có bình luận sẽ không có văn bản bình luận để hiển thị.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

Các bình luận trong tài liệu HTML5 đầu ra

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Loại trừ siêu liên kết JavaScript khi xuất**

Giả sử `hyperlinks.pptx` chứa văn bản liên kết với mục tiêu `javascript:alert('Hello')` và một liên kết `https://example.com/` bình thường. Để loại trừ siêu liên kết JavaScript khi xuất, đặt [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) thành `True`. Mặc định là `False`, vì vậy các liên kết này sẽ không bị lọc trừ khi bạn bật tùy chọn.

Ví dụ sau tải bản trình chiếu từ thư mục làm việc và xuất nó bằng [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Tệp đã xuất bỏ qua siêu liên kết JavaScript trong khi giữ nguyên văn bản và liên kết HTTPS bình thường. Bản trình chiếu nguồn không bị thay đổi.

Tùy chọn này lọc các siêu liên kết JavaScript; nó không loại bỏ tất cả các script hoặc nội dung hoạt động khác, cũng không đảm bảo tuân thủ CSP. Ví dụ, đầu ra HTML5 vẫn bao gồm các script cho việc điều hướng slide và hoạt ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có phát trong HTML5 không?**

Có, xuất HTML5 cung cấp các tùy chọn riêng biệt để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) và [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Có hỗ trợ bình luận không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, các bình luận hiện có có thể được đưa vào đầu ra HTML5 và định vị (ví dụ, ở bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) cho ghi chú và bình luận.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, cài đặt [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Mặc định là `False`. Xem [Exclude JavaScript Hyperlinks During Export](/slides/vi/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) để biết ví dụ xuất HTML5 và phạm vi của bộ lọc. Cài đặt này không loại bỏ JavaScript mà trình xem HTML5 sử dụng để điều hướng và hoạt ảnh.