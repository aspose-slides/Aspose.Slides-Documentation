---
title: Chuyển đổi bài thuyết trình PowerPoint sang PDF có ghi chú trong .NET
linktitle: PowerPoint sang PDF có ghi chú
type: docs
weight: 50
url: /vi/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bài thuyết trình sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bài thuyết trình dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú người nói
- PDF có ghi chú
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho .NET. Bảo tồn bố cục và ghi chú người nói cho các bài thuyết trình chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi bài thuyết trình PowerPoint sang định dạng PDF có ghi chú người nói bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quy trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF trong khi giữ nguyên ghi chú người nói.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú người nói được bao gồm và định dạng theo yêu cầu của bạn.

Để đặt kích thước và hướng của trang ghi chú trước khi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/net/notes-size/).

## **Chuyển đổi PowerPoint sang PDF có Ghi chú**

Phương thức `Save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi một bài thuyết trình PPT hoặc PPTX sang PDF có ghi chú người nói. Với Aspose.Slides, bạn chỉ cần tải bài thuyết trình, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/) để bao gồm ghi chú người nói, sau đó lưu tệp dưới dạng PDF. Đoạn mã dưới đây minh họa cách chuyển đổi một bài thuyết trình mẫu sang PDF ở chế độ xem Slide Ghi chú.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Cấu hình các tùy chọn PDF để hiển thị ghi chú người nói.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Hiển thị ghi chú người nói bên dưới slide.
        }
    };

    // Lưu bài thuyết trình dưới dạng PDF có ghi chú người nói.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Bạn có thể muốn kiểm tra Aspose [Trình chuyển đổi PowerPoint sang PDF Trực tuyến](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}}