---
title: Chuyển đổi Bản trình chiếu PowerPoint sang Markdown trong JavaScript
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint trong JavaScript—PPT, PPTX—thành Markdown sạch sẽ với Aspose.Slides cho Node.js qua Java, tự động hoá tài liệu và giữ nguyên định dạng."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bản thuyết trình PowerPoint sang Markdown, điều này có thể hữu ích cho quy trình làm tài liệu, tạo trang tĩnh, di chuyển nội dung và xuất bản văn bản có kiểm soát phiên bản. API hỗ trợ xuất trực tiếp từ các bản thuyết trình PPT và PPTX sang tệp MD và cung cấp các tùy chọn bổ sung để kiểm soát cách nội dung slide được biểu diễn trong tài liệu Markdown kết quả.

Bạn có thể xuất các bản thuyết trình dưới dạng Markdown thuần, lựa chọn từ nhiều loại Markdown như CommonMark và GitHub Flavored Markdown, và cấu hình cách xử lý hình ảnh trong quá trình xuất. Đối với các bản thuyết trình chứa nội dung hình ảnh, Aspose.Slides cũng cho phép bạn lưu hình ảnh vào một thư mục riêng và tham chiếu chúng từ tệp Markdown đã tạo.

{{% alert color="warning" %}} 
Việc xuất PowerPoint sang markdown mặc định **không có hình ảnh**. Nếu bạn muốn xuất tài liệu PowerPoint có chứa hình ảnh, bạn cần gọi `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` và cũng phải đặt `BasePath` nơi các hình ảnh được tham chiếu trong tài liệu markdown sẽ được lưu.
{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Markdown**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để đại diện cho một đối tượng bản thuyết trình.
2. Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) để lưu đối tượng dưới dạng tệp markdown.

Đoạn mã JavaScript này cho thấy cách chuyển đổi PowerPoint sang markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Chuyển đổi PowerPoint sang Các Loại Markdown**

Aspose.Slides cho phép bạn chuyển đổi PowerPoint sang markdown (chứa cú pháp cơ bản), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab và 17 loại markdown khác.

Đoạn mã JavaScript này cho thấy cách chuyển đổi PowerPoint sang CommonMark:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

23 loại markdown được hỗ trợ được [liệt kê dưới enumeration Flavor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/flavor/) từ lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Chuyển đổi Bản Thuyết Trình Có Hình Ảnh sang Markdown**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) cung cấp các thuộc tính và enumeration cho phép bạn sử dụng một số tùy chọn hoặc cài đặt cho tệp markdown kết quả. Enum [MarkdownExportType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownexporttype/) ví dụ có thể được đặt thành các giá trị xác định cách hình ảnh được hiển thị hoặc xử lý: `Sequential`, `TextOnly`, `Visual`.

### **Chuyển đổi Hình Ảnh Theo Thứ Tự**

Nếu bạn muốn các hình ảnh xuất hiện riêng lẻ, lần lượt trong markdown kết quả, bạn phải chọn tùy chọn sequential. Đoạn mã JavaScript này cho thấy cách chuyển đổi một bản thuyết trình có hình ảnh sang markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Chuyển đổi Hình Ảnh Dưới Dạng Trực Quan**

Nếu bạn muốn các hình ảnh xuất hiện cùng nhau trong markdown kết quả, bạn phải chọn tùy chọn visual. Trong trường hợp này, hình ảnh sẽ được lưu vào thư mục hiện tại của ứng dụng (và một đường dẫn tương đối sẽ được tạo cho chúng trong tài liệu markdown), hoặc bạn có thể chỉ định đường dẫn và tên thư mục mong muốn.

Đoạn mã JavaScript này minh họa thao tác:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Liệu các siêu liên kết có được giữ lại khi xuất sang Markdown không?**

Có. Văn bản [hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) được giữ lại dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/nodejs-java/slide-transition/) và [animations](/slides/vi/nodejs-java/powerpoint-animation/) của slide không được chuyển đổi.

**Tôi có thể tăng tốc chuyển đổi bằng cách chạy đa luồng không?**

Bạn có thể thực hiện song song trên nhiều tệp, nhưng [don’t share](/slides/vi/nodejs-java/multithreading/) cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) giữa các luồng. Hãy sử dụng các thể hiện hoặc tiến trình riêng cho mỗi tệp để tránh tranh chấp.

**Điều gì xảy ra với hình ảnh — chúng được lưu ở đâu và đường dẫn có phải tương đối không?**

[Images](/slides/vi/nodejs-java/image/) được xuất ra một thư mục riêng, và tệp Markdown tham chiếu chúng bằng đường dẫn tương đối theo mặc định. Bạn có thể cấu hình đường dẫn đầu ra cơ bản và tên thư mục tài sản để duy trì cấu trúc kho dự đoán được.