---
title: Quản lý khả năng truy cập bản trình chiếu trong C++
linktitle: Khả năng truy cập bản trình chiếu
type: docs
weight: 30
url: /vi/cpp/presentation-accessibility/
keywords:
- khả năng truy cập bản trình chiếu
- văn bản thay thế
- tiêu đề văn bản thay thế
- mô tả văn bản thay thế
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tự động kiểm tra khả năng truy cập bản trình chiếu trong các tệp PPT, PPTX và ODP bằng Aspose.Slides cho C++—cải thiện trải nghiệm trình đọc màn hình và tăng cường tuân thủ."
---
## **Giới thiệu**

Văn bản thay thế giúp người dùng công nghệ hỗ trợ hiểu ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin khác. Bài viết này giải thích cách đọc và cập nhật tiêu đề và mô tả văn bản thay thế bằng Aspose.Slides for C++, phân biệt mô tả khả năng truy cập với tên hình được sử dụng trong mã, và kiểm tra xem một hình có được đánh dấu là trang trí hay không.

Các tính năng này hỗ trợ khả năng truy cập của bản trình chiếu, nhưng không đảm bảo hoàn toàn. Thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu khả năng truy cập khác cũng cần được xem xét.

## **Quản lý tiêu đề và mô tả Văn bản thay thế**

Sử dụng văn bản thay thế để giải thích ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin cho những người không thể nhìn thấy chúng. Các thuộc tính sau phục vụ các mục đích khác nhau:

| Thuộc tính hoặc nội dung | Mục đích |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Tiêu đề ngắn cho mô tả thay thế. |
| [AlternativeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_alternativetext/) | Mô tả có ý nghĩa về nội dung hoặc mục đích của hình dạng trong ngữ cảnh của slide. |
| [Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) | Tên của hình dạng, mà mã có thể sử dụng để tìm một hình cụ thể trong bản trình chiếu. |
| Văn bản hiển thị | Nội dung hiển thị trên slide, chẳng hạn như văn bản của hình dạng hoặc tiêu đề và nhãn của biểu đồ. Cập nhật văn bản thay thế không thay đổi nội dung này. |

Khi một bản trình chiếu được sử dụng lại như mẫu, mã có thể tìm một hình bằng [Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) trước khi cập nhật nó. Tên này có mục đích khác với văn bản thay thế, vốn giải thích những gì hình ảnh truyền đạt cho người đọc. Tìm kiếm theo tên cho phép tác giả cải thiện hoặc dịch mô tả mà không thay đổi cách mã tìm hình. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy kiểm tra tên khớp với hình mong muốn; xem [Identify and Find Shapes](/slides/vi/cpp/shape-manipulations/#identify-and-find-shapes).

Ví dụ dưới đây yêu cầu file `input.pptx` có một hình ảnh của lối vào văn phòng là hình dạng đầu tiên trên slide đầu tiên. Hình ảnh không nên được đánh dấu là trang trí. Ví dụ này đọc và in tiêu đề và mô tả văn bản thay thế hiện tại, cập nhật cả hai giá trị, và lưu bản trình chiếu thành `output.pptx`. Điều chỉnh nội dung sao cho phù hợp với hình ảnh thực tế và thông tin mà nó truyền tải.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Thêm văn bản thay thế một mình không đảm bảo khả năng truy cập hoặc tuân thủ các tiêu chuẩn khả năng truy cập. Kiểm tra độ chính xác và liên quan của các mô tả, đồng thời xem xét thứ tự đọc, độ tương phản màu, văn bản có thể đọc được và các yêu cầu khả năng truy cập khác. Các hình ảnh thông tin không nên được đánh dấu là trang trí; phần tiếp theo cho thấy cách đọc [IsDecorative](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_isdecorative/).

## **Đánh dấu là Trang trí**

Đánh dấu là trang trí dùng để chỉ các hình ảnh chỉ mang tính trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm tiếng ồn và giữ tập trung vào nội dung có ý nghĩa. Áp dụng cho nền, họa tiết và khoảng trống—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền đạt thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra tự động khả năng truy cập và dọn dẹp.

![Mark as Decorative](mark_as_decorative.png)

Đoạn mã sau cho thấy cách xác định một hình có được đánh dấu là trang trí hay không.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Tôi nên đặt gì trong tiêu đề và mô tả văn bản thay thế?**

Sử dụng tiêu đề ngắn để xác định chủ đề và mô tả để giải thích thông tin mà hình ảnh truyền đạt trong ngữ cảnh của slide. Đối với biểu đồ, mô tả xu hướng hoặc so sánh liên quan thay vì chỉ nói "biểu đồ".

**Có nên dùng văn bản thay thế để định vị hình trong mẫu không?**

Ưu tiên tìm hình bằng [Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) và xác nhận nó là hình mong muốn. Văn bản thay thế có thể được chỉnh sửa hoặc dịch, điều này có thể làm hỏng mã tìm kiếm mô tả chính xác; xem [Identify and Find Shapes](/slides/vi/cpp/shape-manipulations/).

**Khi nào một hình nên được đánh dấu là trang trí?**

Sử dụng cờ trang trí cho các hình ảnh không cung cấp thông tin, chẳng hạn như họa tiết trang trí. Hình ảnh và biểu đồ truyền đạt ý nghĩa cần có mô tả thích hợp thay vì đánh dấu là trang trí.

**Việc thêm văn bản thay thế có làm cho bản trình chiếu hoàn toàn khả năng truy cập không?**

Không. Văn bản thay thế chỉ giải quyết một phần của khả năng truy cập. Cũng cần xem xét thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu áp dụng khác; việc chỉ đặt các thuộc tính này không tạo ra sự tuân thủ.