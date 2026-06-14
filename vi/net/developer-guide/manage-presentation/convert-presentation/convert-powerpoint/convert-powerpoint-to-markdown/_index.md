---
title: Chuyển đổi các bản trình bày PowerPoint sang Markdown trong .NET
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/net/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bản trình bày sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bản trình bày dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- PowerPoint
- bản trình bày
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint—PPT, PPTX—sang Markdown sạch bằng Aspose.Slides cho .NET, tự động hoá tài liệu và giữ nguyên định dạng."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bản trình bày PowerPoint sang Markdown, hữu ích cho các quy trình tài liệu, tạo trang tĩnh, di chuyển nội dung và xuất bản văn bản được kiểm soát bằng phiên bản. API hỗ trợ xuất trực tiếp từ các bản PPT và PPTX sang tệp MD và cung cấp các tùy chọn bổ sung để kiểm soát cách nội dung slide được biểu diễn trong tài liệu Markdown kết quả.

Bạn có thể xuất bản trình bày dưới dạng Markdown thuần, chọn từ nhiều biến thể Markdown như CommonMark và GitHub Flavored Markdown, và cấu hình cách xử lý hình ảnh trong quá trình xuất. Đối với các bản trình bày có nội dung hình ảnh, Aspose.Slides cũng cho phép lưu hình ảnh vào một thư mục riêng và tham chiếu chúng từ tệp Markdown được tạo.

{{% alert color="warning" %}}

Việc xuất PowerPoint sang Markdown **mặc định không có hình ảnh**. Nếu muốn xuất tài liệu PowerPoint có hình ảnh, bạn cần đặt `ExportType = MarkdownExportType.Visual` và chỉ định `BasePath`, nơi các hình ảnh được tham chiếu trong tài liệu Markdown sẽ được lưu.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang Markdown**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) để đại diện cho đối tượng bản trình bày.  
2. Sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/save) để lưu đối tượng dưới dạng tệp markdown.

Mã C# dưới đây cho thấy cách chuyển đổi PowerPoint sang markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Chuyển đổi PowerPoint sang Biến thể Markdown**

Aspose.Slides cho phép bạn chuyển đổi PowerPoint sang markdown (chứa cú pháp cơ bản), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab và 17 biến thể markdown khác.

Mã C# dưới đây cho thấy cách chuyển đổi PowerPoint sang CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

23 biến thể markdown được hỗ trợ được **liệt kê trong enum Flavor**[listed under the Flavor enumeration](https://reference.aspose.com/slides/vi/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) của lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Chuyển đổi bản trình bày có hình ảnh sang Markdown**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) cung cấp các thuộc tính và enum cho phép bạn cấu hình các tùy chọn cho tệp markdown kết quả. Enum [MarkdownExportType](https://reference.aspose.com/slides/vi/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) chẳng hạn có thể được đặt thành các giá trị xác định cách hình ảnh được render hoặc xử lý: `Sequential`, `TextOnly`, `Visual`.

### **Chuyển đổi hình ảnh theo thứ tự**

Nếu muốn các hình ảnh xuất hiện riêng lẻ, lần lượt trong markdown kết quả, bạn phải chọn tùy chọn sequential. Mã C# dưới đây cho thấy cách chuyển đổi bản trình bày có hình ảnh sang markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Chuyển đổi hình ảnh dạng trực quan**

Nếu muốn các hình ảnh xuất hiện cùng nhau trong markdown kết quả, bạn phải chọn tùy chọn visual.  Trong trường hợp này, hình ảnh sẽ được lưu vào thư mục hiện tại của ứng dụng (và một đường dẫn tương đối sẽ được tạo trong tài liệu markdown), hoặc bạn có thể chỉ định đường dẫn và tên thư mục mong muốn.

Mã C# dưới đây minh họa thao tác:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**Các siêu liên kết có được giữ lại khi xuất sang Markdown không?**

Có. Văn bản [hyperlinks](/slides/vi/net/manage-hyperlinks/) được giữ dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/net/slide-transition/) và [animations](/slides/vi/net/powerpoint-animation/) của slide không được chuyển đổi.

**Tôi có thể tăng tốc độ chuyển đổi bằng cách chạy đa luồng không?**

Bạn có thể thực hiện song song trên các tệp, nhưng **không chia sẻ**[don’t share](/slides/vi/net/multithreading/) cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) giữa các luồng. Hãy sử dụng các thể hiện hoặc tiến trình riêng cho mỗi tệp để tránh tranh chấp.

**Hình ảnh sẽ được lưu ở đâu và đường dẫn có phải là tương đối không?**

[Images](/slides/vi/net/image/) được xuất ra một thư mục riêng, và tệp Markdown tham chiếu chúng bằng đường dẫn tương đối theo mặc định. Bạn có thể cấu hình đường dẫn đầu ra cơ bản và tên thư mục tài sản để duy trì cấu trúc kho lưu trữ dự đoán được.