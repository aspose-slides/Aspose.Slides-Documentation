---
title: Chỉnh sửa tài liệu PDF trong .NET
linktitle: Chỉnh sửa PDF
type: docs
weight: 65
url: /vi/net/edit-pdf/
keywords:
- chỉnh sửa PDF
- thay thế văn bản PDF
- PDF sang PPTX
- PPTX sang PDF
- .NET
- C#
- Aspose.Slides
description: "Chỉnh sửa tài liệu PDF bằng C# bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản và lưu bản trình chiếu đã chỉnh sửa trở lại dạng PDF."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng slide, chỉnh sửa bản trình bày và xuất lại thành PDF. Bài viết này minh họa cách thay thế văn bản đơn giản. Bản trình bày được giữ trong bộ nhớ, vì vậy việc lưu tạm file PPTX là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [AddFromPdf](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/addfrompdf/) để nhập các trang, [ReplaceText](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/replacetext/) để cập nhật văn bản và [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) để xuất kết quả.

Ví dụ dưới đây giả định `input.pdf` chứa từ “Draft” dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó thay thế từ đó bằng “Final” và ghi ra `edited.pdf`. Xóa slide ban đầu trước khi nhập giúp ngăn trang trống thừa trong đầu ra. Tìm kiếm khớp toàn từ với cùng kiểu chữ; `null` có nghĩa là không cần callback kết quả.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Để biết thêm tùy chọn, xem [Search and Replace Text](/slides/vi/net/search-and-replace-text/) và [Convert PowerPoint to PDF](/slides/vi/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Việc thay thế văn bản chỉ áp dụng cho văn bản đã được nhập, không áp dụng cho văn bản trong hình ảnh quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy kiểm tra đầu ra, đặc biệt khi văn bản thay thế dài hơn so với văn bản gốc.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Có cần lưu file PPTX trước khi xuất PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình bày trong bộ nhớ. Chỉ lưu bản sao PPTX nếu bạn muốn tiếp tục chỉnh sửa trong PowerPoint; xem [Save Presentations](/slides/vi/net/save-presentation/).

**Tại sao một số văn bản vẫn không thay đổi?**

Ví dụ khớp toàn từ “Draft” với cùng kiểu chữ. Văn bản được nhập dưới dạng hình ảnh hoặc chia thành các khung văn bản riêng sẽ không nhất thiết khớp với tìm kiếm. Hãy kiểm tra nội dung đã nhập và điều chỉnh tìm kiếm cho tài liệu của bạn.