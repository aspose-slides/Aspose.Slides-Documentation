---
title: Chuyển đổi bản trình bày sang HTML5 trong PHP
linktitle: Bản trình bày sang HTML5
type: docs
weight: 40
url: /vi/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Xuất các bản trình chiếu PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho PHP qua Java. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao gồm việc xuất HTML5 cơ bản mà không cần tiện ích web hay các phụ thuộc thêm, cũng như các tùy chọn kiểm soát hoạt ảnh hình dạng và chuyển tiếp slide. Bài viết cũng minh họa quy trình xuất chuẩn từ PowerPoint sang HTML, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và trình bày cách chèn nhận xét vào tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã PHP này cho thấy cách xuất bản trình bày sang HTML5 mà không có tiện ích web và phụ thuộc:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Trong trường hợp này, bạn nhận được HTML sạch. 

{{% /alert %}}

Bạn có thể muốn chỉ định các cài đặt cho hoạt ảnh hình dạng và chuyển tiếp slide như sau:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xuất PowerPoint sang HTML**

Đoạn Java này minh họa quy trình chuẩn từ PowerPoint sang HTML:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Trong trường hợp này, nội dung bản trình bày được hiển thị qua SVG dưới dạng sau:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();

Tài liệu "output.html" được hiển thị trong hình ảnh dưới đây.

![Nhận xét trong tài liệu HTML5 xuất ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển tiếp slide có phát trong HTML5 hay không?**

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/setanimateshapes/) và [slide transitions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/setanimatetransitions/).

**Việc xuất nhận xét có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, nhận xét có thể được thêm vào HTML5 và định vị (ví dụ, ở bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) cho ghi chú và nhận xét.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, có một [setting](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.