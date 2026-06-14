---
title: Chuyển đổi bản trình chiếu PowerPoint sang Markdown trên Android
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/androidjava/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bản trình chiếu sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bản trình chiếu dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- PowerPoint
- bản trình chiếu
- Markdown
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint—PPT, PPTX—thành Markdown sạch sẽ với Aspose.Slides cho Android bằng Java, tự động hoá tài liệu và giữ nguyên định dạng."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi bản trình chiếu PowerPoint sang Markdown, điều này có thể hữu ích cho quy trình tài liệu, tạo trang tĩnh, di chuyển nội dung và xuất bản văn bản có phiên bản kiểm soát. API hỗ trợ xuất trực tiếp từ các bản PPT và PPTX sang tệp MD và cung cấp các tùy chọn bổ sung để kiểm soát cách nội dung slide được biểu diễn trong tài liệu Markdown kết quả.

Bạn có thể xuất bản trình chiếu dưới dạng Markdown thuần, chọn từ nhiều loại Markdown như CommonMark và GitHub Flavored Markdown, và cấu hình cách xử lý hình ảnh trong quá trình xuất. Đối với các bản trình chiếu có nội dung hình ảnh, Aspose.Slides cũng cho phép lưu hình ảnh vào một thư mục riêng và tham chiếu chúng từ tệp Markdown đã tạo.

Aspose.Slides hỗ trợ chuyển đổi bản trình chiếu sang markdown.

{{% alert color="warning" %}} 

Xuất PowerPoint sang markdown mặc định là **không có hình ảnh**. Nếu bạn muốn xuất tài liệu PowerPoint có chứa hình ảnh, bạn cần đặt `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` và cũng đặt `BasePath` nơi các hình ảnh được tham chiếu trong tài liệu markdown sẽ được lưu.

{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Markdown**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) để đại diện cho đối tượng bản trình chiếu.
2. Sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) để lưu đối tượng dưới dạng tệp markdown.

Mã Java này cho thấy cách chuyển đổi PowerPoint sang markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chuyển đổi PowerPoint sang Định dạng Markdown**

Aspose.Slides cho phép bạn chuyển đổi PowerPoint sang markdown (chứa cú pháp cơ bản), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab và 17 định dạng markdown khác.

Mã Java này cho thấy cách chuyển đổi PowerPoint sang CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

23 định dạng markdown được hỗ trợ được [liệt kê dưới enumeration Flavor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/flavor/) từ lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Chuyển đổi Bản trình chiếu có Hình ảnh sang Markdown**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) cung cấp các thuộc tính và enumeration cho phép bạn sử dụng một số tùy chọn hoặc cài đặt cho tệp markdown kết quả. Enum [MarkdownExportType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownexporttype/) có thể được đặt thành các giá trị xác định cách hình ảnh được hiển thị hoặc xử lý: `Sequential`, `TextOnly`, `Visual`.

### **Chuyển đổi Hình ảnh Theo Thứ Tự**

Nếu bạn muốn các hình ảnh xuất hiện riêng lẻ, từng cái một theo thứ tự trong markdown kết quả, bạn phải chọn tùy chọn sequential. Mã Java này cho thấy cách chuyển đổi bản trình chiếu có hình ảnh sang markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Chuyển đổi Hình ảnh Theo Cách Trực Quan**

Nếu bạn muốn các hình ảnh xuất hiện cùng nhau trong markdown kết quả, bạn phải chọn tùy chọn visual. Trong trường hợp này, hình ảnh sẽ được lưu vào thư mục hiện tại của ứng dụng (và một đường dẫn tương đối sẽ được tạo cho chúng trong tài liệu markdown), hoặc bạn có thể chỉ định đường dẫn và tên thư mục mong muốn.

Mã Java này minh họa thao tác:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Liệu siêu liên kết có được giữ lại khi xuất sang Markdown không?**

Có. Văn bản [hyperlinks](/slides/vi/androidjava/manage-hyperlinks/) được giữ nguyên dưới dạng liên kết Markdown chuẩn. Các [transitions](/slides/vi/androidjava/slide-transition/) và [animations](/slides/vi/androidjava/powerpoint-animation/) của slide không được chuyển đổi.

**Tôi có thể tăng tốc độ chuyển đổi bằng cách chạy đa luồng không?**

Bạn có thể thực hiện song song theo tệp, nhưng [đừng chia sẻ](/slides/vi/androidjava/multithreading/) cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) giữa các luồng. Hãy dùng các thể hiện hoặc tiến trình riêng cho mỗi tệp để tránh xung đột.

**Điều gì xảy ra với hình ảnh — chúng được lưu ở đâu và đường dẫn có tương đối không?**

[Images](/slides/vi/androidjava/image/) được xuất ra một thư mục riêng, và tệp Markdown tham chiếu chúng bằng các đường dẫn tương đối theo mặc định. Bạn có thể cấu hình đường dẫn đầu ra cơ bản và tên thư mục tài nguyên để duy trì cấu trúc repository dự đoán được.