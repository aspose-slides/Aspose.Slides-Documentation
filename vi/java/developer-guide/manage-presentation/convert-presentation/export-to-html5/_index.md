---
title: Chuyển đổi bản trình bày sang HTML5 trong Java
linktitle: Bản trình bày sang HTML5
type: docs
weight: 40
url: /vi/java/export-to-html5/
keywords:
- PowerPoint sang HTML5
- OpenDocument sang HTML5
- bản trình bày sang HTML5
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
- Java
- Aspose.Slides
description: "Xuất bản trình bày PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Java. Bảo toàn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm việc xuất HTML5 cơ bản mà không cần phần mở rộng web hay phụ thuộc bổ sung, cũng như các tùy chọn để điều khiển hoạt ảnh hình dạng và chuyển đổi slide. Bài viết còn trình bày quy trình xuất chuẩn từ PowerPoint sang HTML, mô tả cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách bao gồm bình luận trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã Java sau cho thấy cách xuất bản trình bày sang HTML5 mà không có phần mở rộng web và phụ thuộc:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Trong trường hợp này, bạn sẽ nhận được HTML sạch. 
{{% /alert %}}

Bạn có thể muốn chỉ định các cài đặt cho hoạt ảnh hình dạng và chuyển đổi slide như sau:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xuất PowerPoint sang HTML**

Đoạn mã Java này minh họa quy trình xuất chuẩn từ PowerPoint sang HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Trong trường hợp này, nội dung bản trình bày được hiển thị qua SVG dưới dạng như sau:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Khi bạn sử dụng phương pháp này để xuất PowerPoint sang HTML, do việc hiển thị bằng SVG, bạn sẽ không thể áp dụng kiểu dáng hoặc hoạt ảnh cho các phần tử cụ thể. 
{{% /alert %}}

## **Xuất PowerPoint sang HTML5 ở chế độ xem slide**

**Aspose.Slides** cho phép bạn chuyển đổi bản trình bày PowerPoint thành tài liệu HTML5 trong đó các slide được trình bày ở chế độ xem slide. Khi mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bản trình bày ở chế độ xem slide trên trang web. 

Đoạn mã Java sau minh họa quy trình xuất PowerPoint sang HTML5 ở chế độ xem slide:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chuyển đổi bản trình bày sang tài liệu HTML5 có bình luận**

Bình luận trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide. Chúng đặc biệt hữu ích trong các dự án cộng tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét vào các phần tử slide cụ thể mà không thay đổi nội dung chính. Mỗi bình luận hiển thị tên tác giả, giúp dễ dàng theo dõi người đã để lại nhận xét.

Giả sử chúng ta có bản trình bày PowerPoint sau được lưu trong tệp "sample.pptx".

![Hai bình luận trên slide trình bày](two_comments_pptx.png)

Khi bạn chuyển đổi bản trình bày PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định việc có bao gồm bình luận từ bản trình bày trong tài liệu đầu ra hay không. Để làm điều này, truyền các tham số hiển thị cho bình luận vào phương thức `setSlidesLayoutOptions` của lớp [Html5Options](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/).

Ví dụ mã sau chuyển đổi bản trình bày sang tài liệu HTML5 với các bình luận được hiển thị ở phía bên phải của các slide.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Tài liệu "output.html" được hiển thị trong hình dưới đây.

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

### Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có chạy trong HTML5 hay không?

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [hoạt ảnh hình dạng](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [chuyển đổi slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Đầu ra của bình luận có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?

Có, bình luận có thể được thêm vào HTML5 và định vị (ví dụ, ở phía bên phải slide) thông qua [cài đặt bố cục](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) cho ghi chú và bình luận.

### Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?

Có, có một [cài đặt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.