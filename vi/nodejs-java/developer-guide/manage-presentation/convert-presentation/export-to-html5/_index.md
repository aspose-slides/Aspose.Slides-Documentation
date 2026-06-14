---
title: Chuyển đổi Bài thuyết trình sang HTML5 trong JavaScript
linktitle: Bài thuyết trình sang HTML5
type: docs
weight: 40
url: /vi/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Xuất các bài thuyết trình PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Node.js. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bài thuyết trình PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm việc xuất HTML5 cơ bản mà không cần tiện ích mở rộng web hoặc các phụ thuộc bổ sung, cũng như các tùy chọn để kiểm soát hoạt ảnh hình dạng và chuyển đổi slide. Bài viết cũng trình bày quy trình xuất chuẩn từ PowerPoint sang HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách bao gồm nhận xét trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã JavaScript này cho thấy cách xuất một bài thuyết trình sang HTML5 mà không cần tiện ích mở rộng web và phụ thuộc:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Trong trường hợp này, bạn sẽ nhận được HTML sạch sẽ. 
{{% /alert %}}

Bạn có thể muốn chỉ định các cài đặt cho hoạt ảnh hình dạng và chuyển đổi slide theo cách này:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xuất PowerPoint sang HTML**

Đoạn JavaScript này minh họa quy trình chuẩn chuyển PowerPoint sang HTML:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Trong trường hợp này, nội dung bài thuyết trình được hiển thị thông qua SVG dưới dạng này:

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
Khi bạn sử dụng phương pháp này để xuất PowerPoint sang HTML, do việc render bằng SVG, bạn sẽ không thể áp dụng kiểu dáng hoặc tạo hoạt ảnh cho các phần tử cụ thể. 
{{% /alert %}}

## **Xuất PowerPoint sang HTML5 Chế độ Xem Slide**

**Aspose.Slides** cho phép bạn chuyển đổi một bài thuyết trình PowerPoint sang tài liệu HTML5, trong đó các slide được hiển thị ở chế độ xem slide. Trong trường hợp này, khi bạn mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bài thuyết trình ở chế độ xem slide trên trang web. 

Đoạn mã JavaScript này minh họa quy trình xuất PowerPoint sang HTML5 ở chế độ xem slide:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Chuyển đổi bài thuyết trình sang tài liệu HTML5 có nhận xét**

Nhận xét trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide của bài thuyết trình. Chúng đặc biệt hữu ích trong các dự án cộng tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét vào các yếu tố cụ thể của slide mà không làm thay đổi nội dung chính. Mỗi nhận xét hiển thị tên tác giả, giúp dễ dàng theo dõi ai đã để lại nhận xét.

Giả sử chúng ta có bài thuyết trình PowerPoint sau được lưu trong tệp "sample.pptx".

![Hai nhận xét trên slide của bài thuyết trình](two_comments_pptx.png)

Khi bạn chuyển đổi một bài thuyết trình PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định liệu có bao gồm nhận xét từ bài thuyết trình trong tài liệu đầu ra hay không. Để thực hiện điều này, bạn cần chỉ định các tham số hiển thị cho nhận xét trong thuộc tính `notes_comments_layouting` của lớp [Html5Options](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/).

Ví dụ mã sau chuyển đổi một bài thuyết trình sang tài liệu HTML5 với các nhận xét được hiển thị ở phía bên phải của các slide.

```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

Tài liệu "output.html" được hiển thị trong hình dưới đây.

![Các nhận xét trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có chạy trong HTML5 không?**

Có, HTML5 cung cấp các tùy chọn riêng biệt để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/setanimateshapes/) và [slide transitions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Đầu ra của nhận xét có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, nhận xét có thể được thêm vào HTML5 và định vị (ví dụ, ở phía bên phải của slide) thông qua [layout settings](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) cho ghi chú và nhận xét.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, có một [setting](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.