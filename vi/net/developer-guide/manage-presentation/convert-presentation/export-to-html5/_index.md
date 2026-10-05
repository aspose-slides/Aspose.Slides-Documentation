---
title: Chuyển đổi bản trình bày sang HTML5 trong .NET
linktitle: Trình chiếu sang HTML5
type: docs
weight: 40
url: /vi/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho .NET. Bảo toàn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình bày PowerPoint sang HTML5 bằng Aspose.Slides cho .NET. Nó bao gồm việc xuất cơ bản, kiểm soát hoạt ảnh hình dạng và chuyển đổi slide, cũng như bố cục bình luận. Ngoài ra, nó so sánh đầu ra HTML5 với đầu ra dựa trên SVG của việc xuất HTML tiêu chuẩn.

## **Xuất PowerPoint sang HTML5**

Ví dụ sau tải một bản trình bày từ thư mục làm việc và lưu nó ở định dạng HTML5. Nó sử dụng các cài đặt xuất mặc định; ví dụ tiếp theo cho thấy cách kiểm soát việc phát hoạt ảnh một cách rõ ràng. Thay thế đường dẫn đầu vào bằng đường dẫn tới bản trình bày của bạn.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Lưu ý" %}}
Ngoài tài liệu HTML, quá trình xuất còn ghi các tệp CSS và JavaScript hỗ trợ cho việc tạo kiểu slide, hoạt ảnh, hiệu ứng và điều hướng. Giữ các tệp này cùng với tài liệu HTML khi di chuyển hoặc xuất bản kết quả. Trang được tạo cũng tải jQuery và Anime.js từ các CDN công cộng; nếu không có chúng, việc điều hướng slide và các hoạt ảnh sẽ không hoạt động.
{{% /alert %}}

Để xuất mà không phát hoạt ảnh hình dạng hoặc chuyển đổi slide, đặt [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) và [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) thành `false` trong [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Các cài đặt này độc lập, vì vậy bạn có thể bật một trong khi tắt cái còn lại. Ví dụ này xuất bản trình bày với cả hai loại hoạt ảnh bị tắt trong trang được tạo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Xuất PowerPoint sang HTML**

Xuất HTML tiêu chuẩn sử dụng một cách tiếp cận render khác: nội dung slide được biểu diễn bằng SVG bên trong một trang HTML. Ví dụ sau chuyển đổi một bản trình bày sang tài liệu HTML bằng cách tiếp cận render này.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Mã HTML đơn giản bên dưới minh họa cấu trúc của trang được tạo. Phần tử SVG chứa nội dung slide đã được render; văn bản placeholder đại diện cho nội dung đó và không phải là đầu ra thực tế của việc xuất.

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
Xuất dựa trên SVG không hiển thị các hình dạng PowerPoint dưới dạng các phần tử HTML riêng lẻ. Hãy sử dụng xuất HTML5 khi bạn cần các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide được mô tả trong bài viết này.
{{% /alert %}}

## **Xuất PowerPoint sang chế độ xem Slide HTML5**

Xuất HTML5 tạo một trang để xem và điều hướng các slide của bản trình bày trong trình duyệt. Ví dụ này bật cả [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) và [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) để chế độ xem slide được xuất có thể phát hiệu ứng từ bản trình bày nguồn.

Sử dụng một bản trình bày đã chứa hoạt ảnh hình dạng và chuyển đổi slide để thấy hiệu quả của các cài đặt này. Việc bật chúng không thêm hiệu ứng mới cho những slide không có. Sau khi xuất, mở tài liệu HTML5 đã tạo trong trình duyệt với các tệp hỗ trợ có sẵn.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Chuyển đổi Bản trình bày sang Tài liệu HTML5 có Bình luận**

Bạn có thể bao gồm các bình luận slide hiện có trong đầu ra HTML5 để người đọc có thể xem phản hồi bên cạnh nội dung slide. Ví dụ trong phần này giả định bản trình bày nguồn chứa bình luận, như minh họa bên dưới. Nó xuất các bình luận đó; không tạo bình luận mới.

![Hai bình luận trên slide bài thuyết trình](two_comments_pptx.png)

Gán một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) cho thuộc tính [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) của [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Đặt [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) thành `Right` từ enum [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) để đặt bình luận bên phải mỗi slide.

Ví dụ sau xuất bản trình bày sang HTML5 với bố cục bình luận này. Một bản trình bày không có bình luận sẽ không hiển thị văn bản bình luận nào.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Hình ảnh bên dưới hiển thị tài liệu HTML5 đã xuất với các bình luận hiển thị bên cạnh slide.

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Loại bỏ Siêu liên kết JavaScript Khi Xuất**

Giả sử `hyperlinks.pptx` chứa văn bản liên kết với mục tiêu `javascript:alert('Hello')` và một liên kết thường `https://example.com/`. Để loại bỏ siêu liên kết JavaScript khi xuất, đặt [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) thành `true`. Mặc định là `false`, vì vậy các liên kết này sẽ không bị lọc trừ khi bạn bật tùy chọn.

Ví dụ sau tải bản trình bày từ thư mục làm việc và xuất nó bằng [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Tệp đã xuất bỏ qua siêu liên kết JavaScript trong khi vẫn giữ nguyên văn bản và liên kết HTTPS thường. Bản trình bày nguồn không bị thay đổi.

Tùy chọn này lọc các siêu liên kết JavaScript; nó không loại bỏ tất cả các script hoặc nội dung hoạt động khác, cũng không đảm bảo tuân thủ CSP. Ví dụ, đầu ra HTML5 vẫn bao gồm các script cho việc điều hướng slide và hoạt ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có chạy trong HTML5 không?**

Có, xuất HTML5 cung cấp các tùy chọn riêng biệt để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) và [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Các bình luận có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, các bình luận hiện có có thể được bao gồm trong đầu ra HTML5 và được định vị (ví dụ, bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) cho ghi chú và bình luận.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, cài đặt [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Mặc định là `false`. Xem [Bỏ qua Siêu liên kết JavaScript khi Xuất](/slides/vi/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) cho ví dụ xuất HTML, HTML5 và PDF đơn giản và phạm vi của bộ lọc. Cài đặt này không loại bỏ JavaScript được trình xem HTML5 sử dụng cho việc điều hướng và hoạt ảnh.