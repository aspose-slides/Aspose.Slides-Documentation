---
title: "Chuyển Đổi Bản Trình Chiếu Sang HTML5 trong JavaScript"
linktitle: "Bản Trình Chiếu sang HTML5"
type: docs
weight: 40
url: /vi/nodejs-java/export-to-html5/
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
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Xuất bản trình chiếu PowerPoint và OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Node.js. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint sang HTML5 bằng Aspose.Slides cho Node.js qua Java. Nó bao gồm xuất cơ bản, kiểm soát hoạt ảnh hình dạng và chuyển đổi slide, và bố cục bình luận. Nó cũng so sánh đầu ra HTML5 với đầu ra dựa trên SVG của xuất HTML tiêu chuẩn.

## **Xuất PowerPoint sang HTML5**

Ví dụ sau tải một bản trình chiếu từ thư mục làm việc và lưu nó ở định dạng HTML5. Nó sử dụng các cài đặt xuất mặc định; ví dụ tiếp theo cho thấy cách kiểm soát việc phát hoạt ảnh một cách rõ ràng. Thay đổi đường dẫn đầu vào bằng đường dẫn tới bản trình chiếu của bạn.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Ngoài tài liệu HTML, quá trình xuất còn ghi các tệp CSS và JavaScript hỗ trợ cho việc định dạng slide, hoạt ảnh, hiệu ứng và điều hướng. Giữ các tệp này cùng với tài liệu HTML khi di chuyển hoặc xuất bản kết quả. Trang được tạo cũng tải jQuery và Anime.js từ các CDN công cộng; nếu thiếu chúng, việc điều hướng slide và hoạt ảnh sẽ không hoạt động.
{{% /alert %}}

Để xuất mà không chạy hoạt ảnh hình dạng hoặc chuyển đổi slide, truyền `false` cho [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) và [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) trong [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Các cài đặt này độc lập, vì vậy bạn có thể bật một trong khi tắt cái khác. Ví dụ xuất bản trình chiếu với cả hai loại hoạt ảnh bị tắt trong trang được tạo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Xuất PowerPoint sang HTML**

Quá trình xuất HTML tiêu chuẩn sử dụng một cách tiếp cận render khác: nội dung slide được biểu diễn bằng SVG trong một trang HTML. Ví dụ sau chuyển đổi một bản trình chiếu thành tài liệu HTML bằng cách render này.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Mã HTML đơn giản bên dưới minh họa cấu trúc của trang được tạo. Thành phần SVG chứa nội dung slide đã render; văn bản giữ chỗ đại diện cho nội dung đó và không phải là đầu ra thực tế của quá trình xuất.

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
Quá trình xuất dựa trên SVG không hiển thị các hình dạng PowerPoint dưới dạng các phần tử HTML riêng lẻ. Sử dụng xuất HTML5 khi bạn cần các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide được trình bày trong bài viết này.
{{% /alert %}}

## **Xuất PowerPoint sang chế độ xem slide HTML5**

Xuất HTML5 tạo ra một trang để xem và duyệt các slide của bản trình chiếu trong trình duyệt. Ví dụ này bật cả [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) và [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) để chế độ xem slide đã xuất có thể phát hiệu ứng từ bản trình chiếu nguồn.

Sử dụng một bản trình chiếu đã có sẵn hoạt ảnh hình dạng và chuyển đổi slide để xem hiệu quả của các cài đặt này. Bật chúng không thêm hiệu ứng mới vào các slide không có. Sau khi xuất, mở tài liệu HTML5 đã tạo trong trình duyệt với các tệp hỗ trợ sẵn có.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi một bản trình chiếu thành tài liệu HTML5 có bình luận**

Bạn có thể bao gồm các bình luận slide hiện có trong đầu ra HTML5 để người đọc có thể xem phản hồi bên cạnh nội dung slide. Ví dụ trong phần này yêu cầu bản trình chiếu nguồn chứa bình luận, như minh họa bên dưới. Nó sẽ xuất các bình luận đó; không tạo bình luận mới.

![Hai bình luận trên slide bản trình chiếu](two_comments_pptx.png)

Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) vào phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) của [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Sử dụng [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) để chọn `Right` từ enumerations [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) nhằm đặt các bình luận ở bên phải mỗi slide.

Ví dụ dưới đây xuất bản trình chiếu sang HTML5 với bố cục bình luận này. Một bản trình chiếu không có bình luận sẽ không có văn bản bình luận nào để hiển thị.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Hình ảnh bên dưới hiển thị tài liệu HTML5 đã xuất với các bình luận được hiển thị bên cạnh slide.

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Loại bỏ siêu liên kết JavaScript trong quá trình xuất**

Giả sử `hyperlinks.pptx` chứa văn bản liên kết với mục tiêu `javascript:alert('Hello')` và một liên kết thông thường `https://example.com/`. Để loại bỏ siêu liên kết JavaScript khi xuất, truyền `true` cho [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Mặc định là `false`, do đó các liên kết này sẽ không bị lọc trừ khi bạn bật tùy chọn.

Ví dụ sau tải bản trình chiếu từ thư mục làm việc và xuất nó bằng [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Tệp đã xuất bỏ qua siêu liên kết JavaScript trong khi vẫn giữ lại văn bản và liên kết HTTPS thông thường. Bản trình chiếu nguồn không bị thay đổi.

Tùy chọn này lọc các siêu liên kết JavaScript; nó không xóa toàn bộ script hoặc nội dung hoạt động khác, cũng không đảm bảo tuân thủ CSP. Ví dụ, đầu ra HTML5 vẫn bao gồm các script cho việc điều hướng slide và hoạt ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có phát trong HTML5 không?**

Có, xuất HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) và [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Các bình luận có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, các bình luận hiện có có thể được bao gồm trong đầu ra HTML5 và đặt vị trí (ví dụ, bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) cho ghi chú và bình luận.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, cài đặt [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Mặc định là `false`. Xem [Loại bỏ siêu liên kết JavaScript trong quá trình xuất](/slides/vi/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) để biết ví dụ xuất HTML5 và phạm vi của bộ lọc. Cài đặt này không xóa JavaScript được sử dụng bởi trình xem HTML5 cho việc điều hướng và hoạt ảnh.