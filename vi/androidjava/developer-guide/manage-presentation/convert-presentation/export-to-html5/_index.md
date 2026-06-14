---
title: Chuyển đổi Bài thuyết trình sang HTML5 trên Android
linktitle: Bài thuyết trình sang HTML5
type: docs
weight: 40
url: /vi/androidjava/export-to-html5/
keywords:
- PowerPoint sang HTML5
- OpenDocument sang HTML5
- bài thuyết trình sang HTML5
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
- Android
- Java
- Aspose.Slides
description: "Xuất các bài thuyết trình PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Android qua Java. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bài thuyết trình PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm việc xuất HTML5 cơ bản mà không cần phần mở rộng web hay các phụ thuộc bổ sung, cũng như các tùy chọn để kiểm soát hoạt ảnh hình dạng và chuyển tiếp slide. Bài viết cũng trình bày quy trình xuất chuẩn từ PowerPoint sang HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách đưa nhận xét vào tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã Java này cho thấy cách xuất một bài thuyết trình sang HTML5 mà không có phần mở rộng web và phụ thuộc:

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

Bạn có thể muốn chỉ định các cài đặt cho hoạt ảnh hình dạng và chuyển tiếp slide theo cách này:

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

Đoạn mã Java này trình bày quy trình chuẩn từ PowerPoint sang HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Trong trường hợp này, nội dung của bài thuyết trình được hiển thị qua SVG dưới dạng sau:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Ghi chú" color="warning" %}} 
Khi bạn sử dụng phương pháp này để xuất PowerPoint sang HTML, do việc render bằng SVG, bạn sẽ không thể áp dụng kiểu dáng hoặc tạo hoạt ảnh cho các phần tử cụ thể. 
{{% /alert %}}

## **Xuất PowerPoint sang HTML5 với chế độ Xem Slide**

**Aspose.Slides** cho phép bạn chuyển đổi một bài thuyết trình PowerPoint sang tài liệu HTML5 trong đó các slide được trình bày ở chế độ xem slide. Khi mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bài thuyết trình ở chế độ xem slide trên trang web.

Đoạn mã Java này minh họa quy trình xuất PowerPoint sang HTML5 chế độ Xem Slide:

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

## **Chuyển đổi Bài Thuyết Trình sang Tài liệu HTML5 có Nhận Xét**

Nhận xét trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide. Chúng đặc biệt hữu ích trong các dự án hợp tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét vào các thành phần cụ thể của slide mà không làm thay đổi nội dung chính. Mỗi nhận xét hiển thị tên tác giả, giúp dễ dàng theo dõi người để lại nhận xét.

Giả sử chúng ta có bài thuyết trình PowerPoint sau được lưu trong tệp "sample.pptx".

![Hai nhận xét trên slide bài thuyết trình](two_comments_pptx.png)

Khi bạn chuyển đổi một bài thuyết trình PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định việc có bao gồm các nhận xét từ bài thuyết trình trong tài liệu đầu ra hay không. Để làm điều này, bạn cần chỉ định các tham số hiển thị cho nhận xét trong phương thức `getNotesCommentsLayouting` của lớp [Html5Options](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/html5options/).

Ví dụ mã sau chuyển đổi một bài thuyết trình sang tài liệu HTML5 với các nhận xét được hiển thị ở bên phải các slide.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Tài liệu "output.html" được hiển thị trong hình dưới đây.

![Các nhận xét trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển tiếp slide có được phát trong HTML5 hay không?**

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [hoạt ảnh hình dạng](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [chuyển tiếp slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Việc xuất các nhận xét có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, các nhận xét có thể được thêm vào HTML5 và định vị (ví dụ, ở bên phải slide) thông qua [cài đặt bố cục](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) cho ghi chú và nhận xét.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, có một [cài đặt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) cho phép bạn bỏ qua các hyperlink có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.