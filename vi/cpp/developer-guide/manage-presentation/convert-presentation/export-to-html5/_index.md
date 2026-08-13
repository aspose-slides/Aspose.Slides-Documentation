---
title: Chuyển đổi bài thuyết trình sang HTML5 trong C++
linktitle: Bài thuyết trình sang HTML5
type: docs
weight: 40
url: /vi/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Xuất các bài thuyết trình PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho C++. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bài thuyết trình PowerPoint sang HTML5 bằng Aspose.Slides. Nó bao phủ việc xuất HTML5 cơ bản mà không có phần mở rộng web hoặc phụ thuộc bổ sung, cũng như các tùy chọn để kiểm soát hoạt ảnh hình dạng và chuyển đổi slide. Bài viết cũng trình bày quy trình xuất PowerPoint sang HTML tiêu chuẩn, giải thích cách tạo đầu ra HTML5 ở chế độ xem slide, và minh họa cách bao gồm nhận xét trong tài liệu đã xuất bằng cách cấu hình bố cục của chúng.

## **Xuất PowerPoint sang HTML5**

Đoạn mã C++ này cho thấy cách xuất một bài thuyết trình sang HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
Trong trường hợp này, bạn sẽ nhận được HTML sạch. 
{{% /alert %}}

Bạn có thể muốn chỉ định các cài đặt cho hoạt ảnh hình dạng và chuyển đổi slide theo cách này:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Xuất PowerPoint sang HTML**

Đoạn mã C++ này minh họa quy trình tiêu chuẩn chuyển PowerPoint sang HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Trong trường hợp này, nội dung bài thuyết trình được hiển thị qua SVG ở dạng như sau:

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
Khi bạn sử dụng phương pháp này để xuất PowerPoint sang HTML, do việc hiển thị bằng SVG, bạn sẽ không thể áp dụng kiểu dáng hoặc tạo hoạt ảnh cho các phần tử cụ thể. 
{{% /alert %}}

## **Xuất PowerPoint sang HTML5 ở chế độ xem slide**

**Aspose.Slides** cho phép bạn chuyển đổi một bài thuyết trình PowerPoint sang tài liệu HTML5 trong đó các slide được trình bày ở chế độ xem slide. Trong trường hợp này, khi bạn mở tệp HTML5 kết quả trong trình duyệt, bạn sẽ thấy bài thuyết trình ở chế độ xem slide trên một trang web. 

Đoạn mã C++ này minh họa quy trình xuất PowerPoint sang HTML5 ở chế độ xem slide:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Chuyển đổi một bài thuyết trình sang tài liệu HTML5 có nhận xét**

Nhận xét trong PowerPoint là công cụ cho phép người dùng để lại ghi chú hoặc phản hồi trên các slide của bài thuyết trình. Chúng đặc biệt hữu ích trong các dự án hợp tác, nơi nhiều người có thể thêm đề xuất hoặc nhận xét của họ vào các yếu tố slide cụ thể mà không làm thay đổi nội dung chính. Mỗi nhận xét hiển thị tên tác giả, giúp dễ dàng theo dõi ai đã để lại nhận xét.

Giả sử chúng ta có bài thuyết trình PowerPoint sau được lưu trong tệp "sample.pptx".

![Hai nhận xét trên slide của bài thuyết trình](two_comments_pptx.png)

Khi bạn chuyển đổi một bài thuyết trình PowerPoint sang tài liệu HTML5, bạn có thể dễ dàng chỉ định việc có bao gồm nhận xét từ bài thuyết trình trong tài liệu đầu ra hay không. Để làm điều này, bạn cần chỉ định các tham số hiển thị cho nhận xét trong phương thức `get_NotesCommentsLayouting` của lớp [Html5Options](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/) .

Ví dụ mã sau chuyển đổi một bài thuyết trình sang tài liệu HTML5 với các nhận xét được hiển thị ở bên phải của các slide.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Tài liệu "output.html" được hiển thị trong hình dưới đây.

![Các nhận xét trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Câu hỏi thường gặp**

### Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có chạy trong HTML5 không?

Có, HTML5 cung cấp các tùy chọn riêng để bật hoặc tắt [hoạt ảnh hình dạng](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/set_animateshapes/) và [chuyển đổi slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/set_animatetransitions/) .

### Đầu ra của nhận xét có được hỗ trợ không, và chúng có thể được đặt ở vị trí nào so với slide?

Có, nhận xét có thể được thêm vào HTML5 và đặt vị trí (ví dụ, ở bên phải slide) thông qua các cài đặt bố cục cho ghi chú và nhận xét.

### Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?

Có, có một [cài đặt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Điều này giúp tuân thủ các chính sách bảo mật nghiêm ngặt.