---
title: Chỉnh sửa tài liệu PDF trong C++
linktitle: Chỉnh sửa PDF
type: docs
weight: 65
url: /vi/cpp/edit-pdf/
keywords:
- chỉnh sửa PDF
- thay thế văn bản PDF
- PDF sang PPTX
- PPTX sang PDF
- C++
- Aspose.Slides
description: "Chỉnh sửa tài liệu PDF trong C++ bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản, và lưu bản trình bày đã sửa lại thành PDF."
---
## **Tổng quan**

Aspose.Slides for C++ cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng các slide, sửa đổi bản trình bày và xuất lại thành PDF. Bài viết này trình bày cách thay thế văn bản đơn giản. Bản trình bày tồn tại trong bộ nhớ, vì vậy việc lưu một tệp PPTX trung gian là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidecollection/addfrompdf/) để nhập các trang, [Presentation::ReplaceText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/replacetext/) để cập nhật văn bản, và [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) để xuất kết quả.

Ví dụ dưới đây giả định rằng `input.pdf` chứa từ "Draft" dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó thay thế từ đó bằng "Final" và ghi ra `edited.pdf`. Xóa slide đầu tiên trước khi nhập giúp ngăn một trang trắng thừa trong đầu ra. Tìm kiếm khớp toàn bộ từ với cùng kiểu chữ; `nullptr` có nghĩa là không cần hàm gọi lại kết quả.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Để biết thêm tùy chọn, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/cpp/search-and-replace-text/) và [Chuyển đổi PowerPoint sang PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Việc thay thế văn bản hoạt động trên văn bản đã nhập, không phải văn bản trong hình ảnh đã quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy xem lại kết quả, đặc biệt khi văn bản thay thế dài hơn văn bản gốc.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có cần lưu tệp PPTX trước khi xuất PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình bày trong bộ nhớ. Chỉ lưu một bản sao PPTX nếu bạn muốn tiếp tục chỉnh sửa nó trong PowerPoint; xem [Lưu Bản Trình Bày](/slides/vi/cpp/save-presentation/).

**Tại sao một số văn bản có thể không thay đổi?**

Ví dụ khớp toàn bộ từ "Draft" với đúng kiểu chữ. Văn bản được nhập dưới dạng hình ảnh hoặc được chia thành các khung văn bản riêng sẽ không nhất thiết khớp với tìm kiếm. Kiểm tra nội dung đã nhập và điều chỉnh tìm kiếm cho tài liệu của bạn.