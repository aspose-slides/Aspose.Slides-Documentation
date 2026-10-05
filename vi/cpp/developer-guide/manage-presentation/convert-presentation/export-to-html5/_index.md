---
title: Chuyển đổi bản trình bày sang HTML5 trong C++
linktitle: Bản trình bày sang HTML5
type: docs
weight: 40
url: /vi/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Xuất bản trình bày PowerPoint & OpenDocument sang HTML5 đáp ứng với Aspose.Slides cho C++. Bảo tồn định dạng, hoạt ảnh và tính tương tác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang HTML5 bằng Aspose.Slides cho C++. Nó bao gồm xuất cơ bản, kiểm soát hoạt ảnh hình dạng và chuyển đổi slide, cũng như bố cục nhận xét. Ngoài ra, nó so sánh đầu ra HTML5 với đầu ra dựa trên SVG của việc xuất HTML tiêu chuẩn.

## **Xuất PowerPoint sang HTML5**

Ví dụ sau tải một bản trình bày từ thư mục làm việc và lưu nó ở định dạng HTML5. Nó sử dụng cài đặt xuất mặc định; ví dụ tiếp theo cho thấy cách kiểm soát việc phát hoạt ảnh một cách rõ ràng. Thay đổi đường dẫn đầu vào bằng đường dẫn tới bản trình bày của bạn.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Ngoài tài liệu HTML, quá trình xuất sẽ ghi các tệp CSS và JavaScript hỗ trợ cho việc tạo kiểu slide, hoạt ảnh, hiệu ứng và điều hướng. Giữ các tệp này cùng với tài liệu HTML khi di chuyển hoặc công bố đầu ra. Trang được tạo cũng tải jQuery và Anime.js từ các CDN công cộng; nếu không có chúng, việc điều hướng slide và hoạt ảnh sẽ không chạy.
{{% /alert %}}

Để xuất mà không phát hoạt ảnh hình dạng hoặc chuyển đổi slide, truyền `false` vào [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) và [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) trong [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Các cài đặt này là độc lập, vì vậy bạn có thể bật một trong khi tắt cái khác. Ví dụ xuất bản trình bày với cả hai loại hoạt ảnh bị tắt trong trang được tạo.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Xuất PowerPoint sang HTML**

Quá trình xuất HTML tiêu chuẩn sử dụng một cách tiếp cận kết xuất khác: nội dung slide được biểu diễn bằng SVG trong một trang HTML. Ví dụ sau chuyển một bản trình bày sang tài liệu HTML bằng cách sử dụng cách tiếp cận kết xuất này.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Mã markup đơn giản bên dưới minh họa cấu trúc của trang được tạo. Phần tử SVG chứa nội dung slide đã được kết xuất; văn bản placeholder đại diện cho nội dung đó và không phải là đầu ra xuất thực tế.

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
Quá trình xuất dựa trên SVG không hiển thị các hình dạng PowerPoint dưới dạng các phần tử HTML riêng lẻ. Hãy sử dụng xuất HTML5 khi bạn cần các tùy chọn hoạt ảnh hình dạng và chuyển đổi slide được trình bày trong bài viết này.
{{% /alert %}}

## **Xuất PowerPoint sang chế độ xem Slide HTML5**

Xuất HTML5 tạo một trang để xem và điều hướng các slide của bản trình bày trong trình duyệt. Ví dụ này truyền `true` vào cả [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) và [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) để chế độ xem slide đã xuất có thể phát hiệu ứng từ bản trình bày nguồn.

Sử dụng một bản trình bày đã có sẵn các hoạt ảnh hình dạng và chuyển đổi slide để xem hiệu ứng của các cài đặt này. Bật chúng không thêm hiệu ứng mới vào các slide không có. Sau khi xuất, mở tài liệu HTML5 đã tạo trong trình duyệt với các tệp hỗ trợ có sẵn.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Chuyển đổi bản trình bày sang tài liệu HTML5 có nhận xét**

Bạn có thể bao gồm các nhận xét slide hiện có trong đầu ra HTML5 để người đọc có thể xem phản hồi bên cạnh nội dung slide. Ví dụ trong phần này giả định bản trình bày nguồn chứa nhận xét, như minh họa bên dưới. Nó xuất các nhận xét đó; không tạo mới.

![Hai nhận xét trên slide bản trình bày](two_comments_pptx.png)

Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) vào phương thức [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) của [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Gọi [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) với `CommentsPositions::Right` từ enum [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) để đặt các nhận xét bên phải mỗi slide.

Ví dụ sau xuất bản trình bày sang HTML5 với bố cục nhận xét này. Một bản trình bày không có nhận xét sẽ không có văn bản nhận xét nào để hiển thị.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Hình ảnh bên dưới hiển thị tài liệu HTML5 đã xuất với các nhận xét hiển thị bên cạnh slide.

![Các nhận xét trong tài liệu HTML5 đầu ra](two_comments_html5.png)

## **Loại bỏ Siêu liên kết JavaScript Khi Xuất**

Giả sử `hyperlinks.pptx` chứa văn bản liên kết với mục tiêu `javascript:alert('Hello')` và một liên kết thông thường `https://example.com/`. Để loại bỏ siêu liên kết JavaScript khi xuất, gọi [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) với `true`. Mặc định là `false`, vì vậy các liên kết này sẽ không bị lọc trừ khi bạn bật tùy chọn.

Ví dụ sau tải bản trình bày từ thư mục làm việc và xuất nó bằng cách sử dụng [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Tệp đã xuất bỏ qua siêu liên kết JavaScript trong khi vẫn giữ lại văn bản và liên kết HTTPS thông thường. Bản trình bày nguồn không thay đổi.

Tùy chọn này lọc các siêu liên kết JavaScript; nó không loại bỏ mọi đoạn script hoặc nội dung động khác, cũng không đảm bảo tuân thủ CSP. Ví dụ, đầu ra HTML5 vẫn bao gồm các script cho việc điều hướng slide và hoạt ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc các hoạt ảnh đối tượng và chuyển đổi slide có chạy trong HTML5 không?**

Có, xuất HTML5 cung cấp các tùy chọn riêng biệt để bật hoặc tắt [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) và [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Có hỗ trợ nhận xét không, và chúng có thể được đặt ở vị trí nào so với slide?**

Có, các nhận xét hiện có có thể được đưa vào đầu ra HTML5 và định vị (ví dụ, bên phải slide) thông qua [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) cho ghi chú và nhận xét.

**Tôi có thể bỏ qua các liên kết gọi JavaScript vì lý do bảo mật hoặc CSP không?**

Có, phương thức [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) cho phép bạn bỏ qua các siêu liên kết có lời gọi JavaScript khi lưu. Mặc định là `false`. Xem [Exclude JavaScript Hyperlinks During Export](/slides/vi/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) để biết ví dụ xuất HTML5 và phạm vi của bộ lọc. Cài đặt này không loại bỏ JavaScript được trình xem HTML5 sử dụng cho việc điều hướng và hoạt ảnh.