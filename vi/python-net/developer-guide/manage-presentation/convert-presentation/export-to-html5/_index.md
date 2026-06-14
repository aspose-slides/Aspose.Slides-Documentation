---
title: Chuyển đổi Bản thuyết trình sang HTML5 trong Python
linktitle: Xuất sang HTML5
type: docs
weight: 40
url: /vi/python-net/export-to-html5/
keywords:
- PowerPoint sang HTML5
- OpenDocument sang HTML5
- bản thuyết trình sang HTML5
- slide sang HTML5
- PPT sang HTML5
- PPTX sang HTML5
- ODP sang HTML5
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- xuất HTML5
- xuất bản thuyết trình
- xuất slide
- PowerPoint
- OpenDocument
- bản thuyết trình
- Python
- Aspose.Slides
description: "Xuất bản thuyết trình PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Python qua .NET. Bảo toàn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản thuyết trình PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm việc xuất HTML5 cơ bản mà không có phần mở rộng web hay phụ thuộc bổ sung, cũng như các tùy chọn để kiểm soát hoạt ảnh hình dạng và chuyển tiếp slide. Bài viết cũng cho thấy quy trình xuất chuẩn PowerPoint‑to‑HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide và minh họa cách bao gồm các bình luận trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã python dưới đây cho thấy cách xuất một bản thuyết trình sang HTML5 mà không cần phần mở rộng web và phụ thuộc:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
Trong trường hợp này, bạn sẽ nhận được HTML sạch. 
{{% /alert %}}

Bạn có thể muốn chỉ định các cài đặt cho hoạt ảnh hình dạng và chuyển tiếp slide theo cách này:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Xuất PowerPoint sang HTML**

Đoạn mã python này minh họa quy trình chuẩn PowerPoint‑to‑HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

Trong trường hợp này, nội dung bản thuyết trình được hiển thị dưới dạng SVG như sau:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Lưu ý" color="warning" %}} 
Khi bạn sử dụng phương pháp này để xuất PowerPoint sang HTML, do việc render bằng SVG, bạn sẽ không thể áp dụng kiểu dáng hoặc hoạt ảnh cho các phần tử cụ thể. 
{{% /alert %}}

## **Xuất PowerPoint sang HTML5 chế độ Xem Slide**

**Aspose.Slides** cho phép bạn chuyển đổi một bản thuyết trình PowerPoint sang tài liệu HTML5 trong đó các slide được hiển thị ở chế độ xem slide. Trong trường hợp này, khi bạn mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bản thuyết trình ở chế độ xem slide trên trang web. 

Đoạn mã Python dưới đây minh họa quy trình xuất PowerPoint sang HTML5 chế độ Xem Slide:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Xuất một bản thuyết trình có chuyển tiếp slide, hoạt ảnh và hoạt ảnh hình dạng sang HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Lưu bản thuyết trình
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Chuyển đổi Bản thuyết trình sang Tài liệu HTML5 có Bình luận**

Bình luận trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide của bản thuyết trình. Chúng đặc biệt hữu ích trong các dự án cộng tác, nơi nhiều người có thể thêm đề xuất hoặc ghi chú vào các thành phần cụ thể của slide mà không làm thay đổi nội dung chính. Mỗi bình luận hiển thị tên tác giả, giúp dễ dàng theo dõi người đã để lại ghi chú.

Giả sử chúng ta có bản thuyết trình PowerPoint sau được lưu trong tệp “sample.pptx”.

![Two comments on the presentation slide](two_comments_pptx.png)

Khi bạn chuyển đổi một bản thuyết trình PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định có bao gồm các bình luận từ bản thuyết trình trong tài liệu đầu ra hay không. Để làm điều này, bạn cần chỉ định các tham số hiển thị cho bình luận trong thuộc tính `notes_comments_layouting` của lớp [Html5Options](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/).

Đoạn mã mẫu dưới đây chuyển đổi một bản thuyết trình sang tài liệu HTML5 với các bình luận được hiển thị ở phía bên phải của các slide.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Tài liệu “output.html” được hiển thị trong hình dưới đây.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển tiếp slide có phát trong HTML5 không?**

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/animate_shapes/) và [slide transitions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/animate_transitions/).

**Việc xuất bình luận có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, bình luận có thể được thêm vào HTML5 và định vị (ví dụ, ở phía bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/notes_comments_layouting/) cho ghi chú và bình luận.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, có một [setting](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/skip_java_script_links/) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.