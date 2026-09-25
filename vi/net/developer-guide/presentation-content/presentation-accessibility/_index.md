---
title: Quản lý khả năng truy cập bản trình chiếu trong .NET
linktitle: Khả năng truy cập bản trình chiếu
type: docs
weight: 30
url: /vi/net/presentation-accessibility/
keywords:
- khả năng truy cập bản trình chiếu
- văn bản thay thế
- tiêu đề văn bản thay thế
- mô tả văn bản thay thế
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tự động kiểm tra khả năng truy cập bản trình chiếu trong các tệp PPT, PPTX và ODP bằng Aspose.Slides cho .NET—cải thiện trải nghiệm cho trình đọc màn hình và nâng cao tuân thủ."
---
## **Giới thiệu**

Văn bản thay thế giúp người dùng công nghệ hỗ trợ hiểu ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin khác. Bài viết này giải thích cách đọc và cập nhật tiêu đề và mô tả văn bản thay thế bằng Aspose.Slides cho .NET, phân biệt mô tả khả năng truy cập với tên hình dạng được sử dụng trong mã, và kiểm tra xem một hình dạng có được đánh dấu là trang trí hay không.

Các tính năng này hỗ trợ khả năng truy cập của bản trình chiếu, nhưng không đảm bảo đầy đủ. Cần xem xét thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu khả năng truy cập khác.

## **Quản lý Tiêu đề và Mô tả Văn bản Thay thế**

Sử dụng văn bản thay thế để giải thích ý nghĩa của hình ảnh, biểu đồ và các hình dạng thông tin cho những người không thể nhìn thấy chúng. Các thuộc tính sau phục vụ các mục đích khác nhau:

| Thuộc tính hoặc nội dung | Mục đích |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/alternativetexttitle/) | Tiêu đề ngắn cho mô tả thay thế. |
| [AlternativeText](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/alternativetext/) | Mô tả có ý nghĩa về nội dung hoặc mục đích của hình dạng trong ngữ cảnh của slide. |
| [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/name/) | Tên của hình dạng, mà mã có thể dùng để tìm một hình dạng cụ thể trong bản trình chiếu. |
| Văn bản hiển thị | Nội dung hiển thị trên slide, như văn bản của hình dạng hoặc tiêu đề và nhãn của biểu đồ. Cập nhật văn bản thay thế không thay đổi nội dung này. |

Khi một bản trình chiếu được tái sử dụng làm mẫu, mã có thể tìm một hình dạng bằng **[Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/name/)** trước khi cập nhật. Tên này có mục đích khác với văn bản thay thế, vốn giải thích những gì hình ảnh truyền đạt cho người đọc. Tìm kiếm bằng tên cho phép tác giả cải thiện hoặc dịch các mô tả mà không thay đổi cách mã tìm hình dạng. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy kiểm tra tên khớp với hình dạng mong muốn; xem **[Identify and Find Shapes](/slides/vi/net/shape-manipulations/#identify-and-find-shapes)**.

Ví dụ bên dưới yêu cầu tệp `input.pptx` có một hình ảnh của lối vào văn phòng làm hình dạng đầu tiên trên slide đầu tiên. Hình ảnh không được đánh dấu là trang trí. Ví dụ đọc và in tiêu đề và mô tả văn bản thay thế hiện tại, cập nhật cả hai giá trị, và lưu bản trình chiếu thành `output.pptx`. Điều chỉnh nội dung sao cho phù hợp với hình ảnh thực tế và thông tin mà nó truyền đạt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Việc chỉ thêm văn bản thay thế không đảm bảo khả năng truy cập của bản trình chiếu hoặc tuân thủ các tiêu chuẩn khả năng truy cập. Hãy kiểm tra độ chính xác và liên quan của mô tả, đồng thời rà soát thứ tự đọc, độ tương phản màu, văn bản dễ đọc và các yêu cầu khả năng truy cập khác. Các hình ảnh mang tính thông tin không nên được đánh dấu là trang trí; phần tiếp theo cho thấy cách đọc **[IsDecorative](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/isdecorative/)**.

## **Đánh dấu là Trang trí**

Đánh dấu là trang trí gắn nhãn cho các hình ảnh chỉ để trang trí để trình đọc màn hình bỏ qua chúng, giảm tiếng ồn và giữ tập trung vào nội dung có ý nghĩa. Áp dụng cho nền, họa tiết, và khoảng cách — không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền đạt thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra tự động khả năng truy cập và dọn dẹp.

![Đánh dấu là Trang trí](mark_as_decorative.png)

Mẫu mã sau cho thấy cách xác định một hình dạng có được đánh dấu là trang trí hay không.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **Câu hỏi thường gặp**

**Tôi nên đưa gì vào tiêu đề và mô tả văn bản thay thế?**

Sử dụng tiêu đề ngắn để xác định chủ đề và mô tả để giải thích thông tin mà hình ảnh truyền đạt trong ngữ cảnh của slide. Đối với biểu đồ, mô tả xu hướng hoặc so sánh liên quan thay vì chỉ nói “biểu đồ”.

**Có nên dùng văn bản thay thế để tìm vị trí các hình dạng trong mẫu không?**

Ưu tiên tìm hình dạng bằng **[Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/name/)** và kiểm tra xem đó có phải là hình dạng mong muốn không. Văn bản thay thế có thể được chỉnh sửa hoặc dịch, có thể làm hỏng mã tìm mô tả chính xác; xem **[Identify and Find Shapes](/slides/vi/net/shape-manipulations/)**.

**Khi nào một hình dạng nên được đánh dấu là trang trí?**

Sử dụng cờ trang trí cho các hình ảnh không cung cấp thông tin, như họa tiết trang trí. Hình ảnh và biểu đồ truyền đạt ý nghĩa cần có mô tả phù hợp thay vì được đánh dấu là trang trí.

**Việc thêm văn bản thay thế có làm cho bản trình chiếu hoàn toàn khả năng truy cập không?**

Không. Văn bản thay thế chỉ giải quyết một phần của khả năng truy cập. Cũng cần xem xét thứ tự đọc, độ tương phản màu, khả năng đọc văn bản và các yêu cầu liên quan khác; chỉ thiết lập các thuộc tính này không tạo nên sự tuân thủ.