---
title: Chuyển đổi bản trình chiếu PowerPoint sang Markdown trong Java
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/java/convert-powerpoint-to-markdown/
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
- exportPPTX sang MD
- PowerPoint
- bản trình chiếu
- Markdown
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint—PPT, PPTX—thành Markdown sạch sẽ với Aspose.Slides cho Java, tự động hoá tài liệu và giữ nguyên định dạng."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bản trình chiếu PowerPoint sang Markdown, điều này có thể hữu ích cho quy trình tài liệu, tạo trang tĩnh, di chuyển nội dung và xuất bản văn bản được quản lý bằng phiên bản. API hỗ trợ xuất trực tiếp từ bản trình chiếu PPT và PPTX sang tệp MD và cung cấp các tùy chọn bổ sung để kiểm soát cách nội dung slide được biểu thị trong tài liệu Markdown kết quả.

Bạn có thể xuất bản trình chiếu dưới dạng Markdown thuần, chọn từ nhiều kiểu Markdown như CommonMark và GitHub Flavored Markdown, và cấu hình cách xử lý hình ảnh trong quá trình xuất. Đối với các bản trình chiếu chứa nội dung hình ảnh, Aspose.Slides cũng cho phép bạn lưu hình ảnh vào một thư mục riêng và tham chiếu chúng từ tệp Markdown được tạo.

{{% alert color="warning" %}}

Xuất PowerPoint sang markdown **mặc định không bao gồm hình ảnh**. Nếu bạn muốn xuất tài liệu PowerPoint có chứa hình ảnh, bạn cần sử dụng `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` và cũng phải sử dụng `setBasePath` nơi các hình ảnh được tham chiếu trong tài liệu markdown sẽ được lưu.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang Markdown**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) để đại diện cho đối tượng bản trình chiếu.
2. Sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) để lưu đối tượng dưới dạng tệp markdown.

Đoạn mã Java này cho bạn thấy cách chuyển đổi PowerPoint sang markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chuyển đổi PowerPoint sang Kiểu Markdown**

Aspose.Slides cho phép bạn chuyển đổi PowerPoint sang markdown (chứa cú pháp cơ bản), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab và 17 kiểu markdown khác.

Đoạn mã Java này cho bạn thấy cách chuyển đổi PowerPoint sang CommonMark:

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

23 kiểu markdown được hỗ trợ được [liệt kê trong enum Flavor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/flavor/) từ lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/).

## **Chuyển đổi Bản Trình Chiếu Có Hình Ảnh sang Markdown**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) cung cấp các thuộc tính và enum cho phép bạn sử dụng một số tùy chọn hoặc cài đặt cho tệp markdown kết quả. Enum [MarkdownExportType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownexporttype/), ví dụ, có thể được đặt thành các giá trị xác định cách hình ảnh được hiển thị hoặc xử lý: `Sequential`, `TextOnly`, `Visual`.

### **Chuyển đổi Hình Ảnh Theo Thứ Tự**

Nếu bạn muốn các hình ảnh xuất hiện riêng lẻ từng cái một trong markdown kết quả, bạn phải chọn tùy chọn sequential. Đoạn mã Java này cho bạn thấy cách chuyển đổi một bản trình chiếu có hình ảnh sang markdown:

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

### **Chuyển đổi Hình Ảnh Theo Cách Trực Quan**

Nếu bạn muốn các hình ảnh xuất hiện cùng nhau trong markdown kết quả, bạn phải chọn tùy chọn visual.   Trong trường hợp này, hình ảnh sẽ được lưu vào thư mục hiện tại của ứng dụng (và một đường dẫn tương đối sẽ được tạo cho chúng trong tài liệu markdown), hoặc bạn có thể chỉ định đường dẫn và tên thư mục mong muốn.

Đoạn mã Java này minh họa thao tác:

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

## **Câu hỏi thường gặp**

**Liệu các siêu liên kết có được giữ lại khi xuất sang Markdown không?**

Có. Văn bản [hyperlinks](/slides/vi/java/manage-hyperlinks/) được bảo tồn dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/java/slide-transition/) và [animations](/slides/vi/java/powerpoint-animation/) của slide không được chuyển đổi.

**Tôi có thể tăng tốc chuyển đổi bằng cách chạy đa luồng không?**

Bạn có thể thực hiện song song trên các tệp, nhưng [đừng chia sẻ](/slides/vi/java/multithreading/) cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) giữa các luồng. Sử dụng các thể hiện/tiến trình riêng cho mỗi tệp để tránh xung đột.

**Xử lý hình ảnh như thế nào — chúng được lưu ở đâu và đường dẫn có phải là tương đối không?**

[Images](/slides/vi/java/image/) được xuất ra một thư mục riêng, và tệp Markdown tham chiếu chúng bằng các đường dẫn tương đối theo mặc định. Bạn có thể cấu hình đường dẫn đầu ra cơ bản và tên thư mục tài sản để duy trì cấu trúc repository dự đoán được.