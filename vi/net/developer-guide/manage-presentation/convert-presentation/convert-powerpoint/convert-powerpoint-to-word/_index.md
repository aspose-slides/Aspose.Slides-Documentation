---
title: Chuyển đổi bản trình chiếu PowerPoint sang tài liệu Word trong .NET
linktitle: PowerPoint sang Word
type: docs
weight: 110
url: /vi/net/convert-powerpoint-to-word/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang Word
- bản trình chiếu sang Word
- slide sang Word
- PPT sang Word
- PPTX sang Word
- PowerPoint sang DOCX
- bản trình chiếu sang DOCX
- slide sang DOCX
- PPT sang DOCX
- PPTX sang DOCX
- PowerPoint sang DOC
- bản trình chiếu sang DOC
- slide sang DOC
- PPT sang DOC
- PPTX sang DOC
- lưu PPT dưới dạng DOCX
- lưu PPTX dưới dạng DOCX
- xuất PPT sang DOCX
- xuất PPTX sang DOCX
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint PPT và PPTX sang tài liệu Word có thể chỉnh sửa trong C# bằng Aspose.Slides cho .NET, giữ nguyên bố cục, hình ảnh và định dạng chính xác."
---
## **Tổng quan**

Bài viết này cung cấp giải pháp cho các nhà phát triển về việc chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word bằng Aspose.Slides for .NET và Aspose.Words for .NET. Hướng dẫn từng bước sẽ dẫn bạn qua mọi giai đoạn của quá trình chuyển đổi.

## **Chuyển đổi bản trình chiếu sang tài liệu Word**

Thực hiện các bước dưới đây để chuyển đổi bản trình chiếu PowerPoint hoặc OpenDocument sang tài liệu Word:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và tải tệp bản trình chiếu.
2. Khởi tạo các lớp [Document](https://reference.aspose.com/words/net/aspose.words/document/) và [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) để tạo tài liệu Word.
3. Đặt kích thước trang cho tài liệu Word sao cho khớp với bản trình chiếu bằng thuộc tính [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Đặt lề cho tài liệu Word bằng thuộc tính [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Duyệt qua tất cả các slide của bản trình chiếu bằng thuộc tính [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/).
    - Tạo hình ảnh slide bằng phương thức `GetImage` từ giao diện [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/) và lưu nó vào một stream bộ nhớ.
    - Thêm hình ảnh slide vào tài liệu Word bằng phương thức `InsertImage` từ lớp [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Lưu tài liệu Word vào tệp.

Giả sử chúng ta có một bản trình chiếu "sample.pptx" trông như sau:

![Bản trình chiếu PowerPoint](PowerPoint.png)

```cs
using Aspose.Slides;
using Aspose.Words;

// Tải tệp bản trình chiếu.
using var presentation = new Presentation("sample.pptx");

// Tạo các đối tượng Document và DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Đặt kích thước trang cho tài liệu Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Đặt lề cho tài liệu Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Duyệt qua tất cả các slide của bản trình chiếu.
foreach (var slide in presentation.Slides)
{
    // Tạo hình ảnh slide và lưu nó vào một stream bộ nhớ.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Thêm hình ảnh slide vào tài liệu Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Lưu tài liệu Word vào tệp.
document.Save("output.docx");
```

Kết quả:

![Tài liệu Word](Word.png)

{{% alert color="info" %}} 
Hãy thử [**Trình chuyển đổi PPT sang Word trực tuyến**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) của chúng tôi để xem bạn có thể đạt được gì khi chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word. 
{{% /alert %}}

## **Câu hỏi thường gặp**

### Cần cài đặt những thành phần nào để chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word?

Bạn chỉ cần thêm các gói NuGet tương ứng cho [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) và [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) vào dự án C# của mình. Cả hai thư viện hoạt động như các API độc lập và không yêu cầu cài đặt Microsoft Office.

### Có hỗ trợ tất cả các định dạng bản trình chiếu PowerPoint và OpenDocument không?

Aspose.Slides for .NET [hỗ trợ tất cả các định dạng bản trình chiếu](/slides/vi/net/supported-file-formats/), bao gồm PPT, PPTX, ODP và các loại tệp phổ biến khác. Điều này đảm bảo bạn có thể làm việc với các bản trình chiếu được tạo trong nhiều phiên bản khác nhau của Microsoft PowerPoint.