---
title: Chuyển đổi bản trình bày sang HTML5 trong .NET
linktitle: Bản trình bày sang HTML5
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
description: "Xuất bản trình bày PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho .NET. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang HTML5 bằng Aspose.Slides. Nó đề cập đến việc xuất HTML5 cơ bản, cũng như các tùy chọn để kiểm soát hoạt ảnh hình dạng và chuyển đổi slide. Bài viết cũng trình bày quy trình xuất chuẩn PowerPoint sang HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách bao gồm bình luận trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã C# này cho thấy cách xuất một bản trình bày sang HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
Ngoài tài liệu HTML, quá trình xuất còn ghi các tệp hỗ trợ mà nó tham chiếu: `pres.css`, `master.css`, `animation.js`, `effects.js`, và `navigation.js`. Trang được tạo cũng tải jQuery và Anime.js từ các CDN công cộng; nếu không có chúng, việc điều hướng slide và các hoạt ảnh sẽ không hoạt động. 
{{% /alert %}}

Bạn có thể muốn chỉ định các cài đặt cho hoạt ảnh hình dạng và chuyển đổi slide theo cách này:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Xuất PowerPoint sang HTML**

Đoạn mã C# này minh họa quy trình chuẩn chuyển PowerPoint sang HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Trong trường hợp này, nội dung bản trình bày được render thông qua SVG dưới dạng như sau:

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

## **Xuất PowerPoint sang HTML5 chế độ Xem Slide**

**Aspose.Slides** cho phép bạn chuyển đổi bản trình bày PowerPoint sang tài liệu HTML5 trong đó các slide được trình bày ở chế độ xem slide. Trong trường hợp này, khi bạn mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bản trình bày ở chế độ xem slide trên một trang web. 

Đoạn mã C# này minh họa quy trình xuất PowerPoint sang HTML5 chế độ Xem Slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Chuyển đổi bản trình bày thành tài liệu HTML5 có bình luận**

Bình luận trong PowerPoint là một công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide của bản trình bày. Chúng đặc biệt hữu ích trong các dự án hợp tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét vào các yếu tố cụ thể của slide mà không làm thay đổi nội dung chính. Mỗi bình luận hiển thị tên tác giả, giúp dễ dàng theo dõi người đã để lại nhận xét.

Giả sử chúng ta có bản trình bày PowerPoint sau được lưu trong tệp "sample.pptx".

![Hai bình luận trên slide bản trình bày](two_comments_pptx.png)

Khi bạn chuyển đổi một bản trình bày PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định việc bao gồm các bình luận từ bản trình bày trong tài liệu đầu ra. Để thực hiện điều này, bạn cần chỉ định các tham số hiển thị cho bình luận trong thuộc tính `NotesCommentsLayouting` của lớp [Html5Options](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/).

Ví dụ mã dưới đây chuyển đổi một bản trình bày thành tài liệu HTML5 với các bình luận được hiển thị ở phía bên phải của các slide.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Tài liệu "output.html" được hiển thị trong hình ảnh bên dưới.

![Các bình luận trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

### Liệu tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide sẽ được phát trong HTML5 không?

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [hoạt ảnh hình dạng](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animateshapes/) và [chuyển đổi slide](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animatetransitions/).

### Có hỗ trợ xuất bình luận không, và chúng có thể được đặt ở vị trí nào so với slide?

Có, bình luận có thể được thêm vào HTML5 và định vị (ví dụ, ở phía bên phải của slide) thông qua [cài đặt bố cục](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/notescommentslayouting/) cho ghi chú và bình luận.

### Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?

Có, có một [cài đặt](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.