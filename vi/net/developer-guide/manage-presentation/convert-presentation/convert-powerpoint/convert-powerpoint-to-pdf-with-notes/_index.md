---
title: Chuyển đổi Bản trình chiếu PowerPoint sang PDF có Ghi chú trong .NET
linktitle: PowerPoint sang PDF có Ghi chú
type: docs
weight: 50
url: /vi/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PDF
- bản trình chiếu sang PDF
- slide sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu bản trình chiếu dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- ghi chú người thuyết trình
- PDF có ghi chú
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi định dạng PPT và PPTX sang PDF có ghi chú bằng Aspose.Slides cho .NET. Bảo tồn bố cục và ghi chú người thuyết trình cho các bản trình chiếu chuyên nghiệp."
---
## **Tổng quan**

Trong bài viết này, bạn sẽ học cách chuyển đổi các bản trình chiếu PowerPoint sang định dạng PDF có ghi chú người thuyết trình bằng Aspose.Slides. Hướng dẫn này sẽ trình bày các bước cần thiết và cung cấp các ví dụ mã để giúp bạn thực hiện nhiệm vụ này một cách hiệu quả. Khi kết thúc bài viết, bạn sẽ có thể:

- Thực hiện quá trình chuyển đổi để biến các slide PowerPoint thành tài liệu PDF đồng thời bảo tồn ghi chú người thuyết trình.
- Tùy chỉnh PDF đầu ra để đảm bảo ghi chú người thuyết trình được bao gồm và định dạng theo yêu cầu của bạn.

## **Chuyển PowerPoint sang PDF có Ghi chú**

Phương thức `Save` trong lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) có thể được sử dụng để chuyển đổi bản trình chiếu PPT hoặc PPTX sang PDF có ghi chú người thuyết trình. Với Aspose.Slides, bạn chỉ cần tải bản trình chiếu, cấu hình các tùy chọn bố cục bằng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/) để bao gồm ghi chú, sau đó lưu file dưới dạng PDF. Đoạn mã dưới đây minh họa cách chuyển một bản trình chiếu mẫu sang PDF ở chế độ xem Notes Slide.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Cấu hình tùy chọn PDF để hiển thị ghi chú người thuyết trình.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Hiển thị ghi chú người thuyết trình phía dưới slide.
        }
    };

    // Lưu bản trình chiếu sang PDF có ghi chú người thuyết trình.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Bạn có thể muốn kiểm tra công cụ **Aspose** [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/vi/conversion). 
{{% /alert %}}