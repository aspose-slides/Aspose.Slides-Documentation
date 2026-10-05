---
title: Chuyển Đổi Bản Trình Chiếu sang HTML5 trong Java
linktitle: Bản Trình Chiếu sang HTML5
type: docs
weight: 40
url: /vi/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho Java. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint sang HTML5 bằng Aspose.Slides for Java. Nó bao gồm việc xuất cơ bản, kiểm soát hoạt ảnh hình dạng và chuyển đổi trang chiếu, cũng như bố cục bình luận. Ngoài ra, nó so sánh đầu ra HTML5 với đầu ra dựa trên SVG của việc xuất HTML chuẩn.

## **Xuất PowerPoint sang HTML5**

Ví dụ sau tải một bản trình chiếu từ thư mục làm việc và lưu nó ở định dạng HTML5. Nó sử dụng các cài đặt xuất mặc định; ví dụ tiếp theo cho thấy cách kiểm soát phát hoạt ảnh một cách cụ thể. Thay thế đường dẫn nhập bằng đường dẫn tới bản trình chiếu của bạn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Ngoài tài liệu HTML, quá trình xuất còn ghi các tệp CSS và JavaScript hỗ trợ cho việc tạo kiểu slide, hoạt ảnh, hiệu ứng và điều hướng. Giữ các tệp này cùng với tài liệu HTML khi di chuyển hoặc công bố kết quả. Trang được tạo cũng tải jQuery và Anime.js từ các CDN công cộng; nếu không có chúng, việc điều hướng slide và hoạt ảnh sẽ không chạy.
{{% /alert %}}

Để xuất mà không phát hoạt ảnh hình dạng hoặc chuyển đổi slide, truyền `false` cho [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) trong [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Các cài đặt này độc lập, vì vậy bạn có thể bật một trong khi tắt cái còn lại. Ví dụ xuất bản trình chiếu với cả hai loại hoạt ảnh bị tắt trong trang được tạo.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Xuất PowerPoint sang HTML**

Việc xuất HTML chuẩn sử dụng một cách tiếp cận render khác: nội dung slide được biểu diễn bằng SVG bên trong một trang HTML. Ví dụ sau chuyển đổi một bản trình chiếu sang tài liệu HTML bằng cách tiếp cận render này.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Markup đơn giản dưới đây minh họa cấu trúc của trang được tạo. Phần tử SVG chứa nội dung slide đã render; văn bản placeholder đại diện cho nội dung đó và không phải là đầu ra xuất thực tế.

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
Việc xuất dựa trên SVG không hiển thị các hình dạng PowerPoint dưới dạng các phần tử HTML riêng lẻ. Sử dụng xuất HTML5 khi bạn cần các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide được trình bày trong bài viết này.
{{% /alert %}}

## **Xuất PowerPoint sang chế độ xem Slide HTML5**

Xuất HTML5 tạo ra một trang để xem và điều hướng các slide của bản trình chiếu trong trình duyệt. Ví dụ này bật cả [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) để chế độ xem slide đã xuất có thể phát các hiệu ứng từ bản trình chiếu nguồn.

Sử dụng một bản trình chiếu đã chứa hoạt ảnh hình dạng và chuyển đổi slide để thấy hiệu quả của các cài đặt này. Bật chúng không thêm hiệu ứng mới vào các slide không có hiệu ứng. Sau khi xuất, mở tài liệu HTML5 đã tạo trong trình duyệt với các tệp hỗ trợ có sẵn.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi một bản trình chiếu sang tài liệu HTML5 có bình luận**

Bạn có thể bao gồm các bình luận slide hiện có trong đầu ra HTML5 để người đọc có thể thấy phản hồi cạnh nội dung slide. Ví dụ trong phần này giả định bản trình chiếu nguồn chứa các bình luận, như minh họa bên dưới. Nó xuất các bình luận đó; không tạo bình luận mới.

![Hai bình luận trên slide bản trình chiếu](two_comments_pptx.png)

Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) cho phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) của [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Sử dụng [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) để chọn `Right` từ liệt kê [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) nhằm đặt các bình luận ở phía bên phải mỗi slide.

Ví dụ sau xuất bản trình chiếu sang HTML5 với bố cục bình luận này. Một bản trình chiếu không có bình luận sẽ không có văn bản bình luận để hiển thị.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Loại trừ siêu liên kết JavaScript khi xuất**

Giả sử `hyperlinks.pptx` chứa văn bản liên kết với mục tiêu `javascript:alert('Hello')` và một liên kết thông thường `https://example.com/`. Để loại trừ siêu liên kết JavaScript khi xuất, truyền `true` cho [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Mặc định là `false`, vì vậy các liên kết này sẽ không được lọc trừ khi bạn bật tùy chọn.

Ví dụ dưới đây tải bản trình chiếu từ thư mục làm việc và xuất nó bằng [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Tệp đã xuất bỏ qua siêu liên kết JavaScript trong khi vẫn giữ lại văn bản của nó và liên kết HTTPS thông thường. Bản trình chiếu nguồn không thay đổi.

Tùy chọn này lọc các siêu liên kết JavaScript; nó không loại bỏ tất cả các script hoặc nội dung hoạt động khác, cũng như không đảm bảo tuân thủ CSP. Ví dụ, đầu ra HTML5 vẫn bao gồm các script cho việc điều hướng slide và hoạt ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có được phát trong HTML5 không?**

Có, xuất HTML5 cung cấp các tùy chọn riêng biệt để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Các bình luận có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, các bình luận hiện có có thể được bao gồm trong đầu ra HTML5 và vị trí (ví dụ, phía bên phải slide) có thể được đặt thông qua [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) cho ghi chú và bình luận.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, cài đặt [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Mặc định là `false`. Xem [Loại trừ Siêu liên kết JavaScript khi xuất](/slides/vi/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) để xem ví dụ xuất HTML5 và phạm vi của bộ lọc. Cài đặt này không loại bỏ JavaScript được sử dụng bởi trình xem HTML5 cho việc điều hướng và hoạt ảnh.