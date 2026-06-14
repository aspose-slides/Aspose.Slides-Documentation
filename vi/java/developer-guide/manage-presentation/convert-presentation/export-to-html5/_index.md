---
title: Chuyển đổi Bản trình bày sang HTML5 trong Java
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
description: "Xuất bản trình bày PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Java. Bảo lưu định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm xuất HTML5 cơ bản mà không có phần mở rộng web hay phụ thuộc bổ sung, cũng như các tùy chọn để kiểm soát hoạt ảnh hình dạng và chuyển đổi slide. Bài viết cũng cho thấy quy trình xuất chuẩn PowerPoint‑to‑HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách bao gồm chú thích trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã Java này cho thấy cách xuất bản trình bày sang HTML5 mà không có phần mở rộng web và phụ thuộc:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Trong trường hợp này, bạn sẽ nhận được HTML sạch. 
{{% /alert %}}

Bạn có thể muốn chỉ định cài đặt cho hoạt ảnh hình dạng và chuyển đổi slide như sau:

```java
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

Đoạn Java này trình bày quy trình chuẩn PowerPoint sang HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Trong trường hợp này, nội dung bản trình bày được hiển thị qua SVG dưới dạng:

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
Khi bạn sử dụng phương pháp này để xuất PowerPoint sang HTML, do việc render bằng SVG, bạn sẽ không thể áp dụng kiểu dáng hoặc tạo hoạt ảnh cho các phần tử cụ thể. 
{{% /alert %}}

## **Xuất PowerPoint sang HTML5 ở chế độ Xem Slide**

**Aspose.Slides** cho phép bạn chuyển đổi bản trình bày PowerPoint sang tài liệu HTML5 trong đó các slide được trình bày ở chế độ xem slide. Khi mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bản trình bày ở chế độ xem slide trên trang web. 

Đoạn mã Java này minh họa quy trình xuất PowerPoint sang HTML5 ở chế độ Xem Slide:

```java
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

## **Chuyển đổi bản trình bày sang tài liệu HTML5 có chú thích**

Chú thích trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide. Chúng đặc biệt hữu ích trong các dự án hợp tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét vào các yếu tố slide cụ thể mà không thay đổi nội dung chính. Mỗi chú thích hiển thị tên người viết, giúp dễ dàng theo dõi ai đã để lại nhận xét.

Giả sử chúng ta có bản trình bày PowerPoint sau được lưu trong tệp "sample.pptx".

![Hai chú thích trên slide bản trình bày](two_comments_pptx.png)

Khi bạn chuyển đổi bản trình bày PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định việc bao gồm chú thích từ bản trình bày trong tài liệu đầu ra. Để làm điều này, bạn cần chỉ định các tham số hiển thị cho chú thích trong phương thức `getNotesCommentsLayouting` của lớp [Html5Options](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/).

Đoạn mã sau đây chuyển đổi bản trình bày sang tài liệu HTML5 với chú thích được hiển thị ở phía bên phải của các slide.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Tài liệu "output.html" được hiển thị trong hình dưới đây.

![Các chú thích trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có được phát trong HTML5 hay không?**

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [slide transitions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Việc xuất chú thích có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, chú thích có thể được thêm vào HTML5 và định vị (ví dụ, ở bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) cho ghi chú và chú thích.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, có một [setting](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.