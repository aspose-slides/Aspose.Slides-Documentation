---
title: Chuyển đổi Bài thuyết trình PowerPoint sang Markdown trong PHP
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/php-java/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bài thuyết trình sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bài thuyết trình dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- PowerPoint
- bài thuyết trình
- Markdown
- PHP
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint — PPT, PPTX — sang Markdown sạch với Aspose.Slides cho PHP qua Java, tự động hoá tài liệu và giữ định dạng."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình PowerPoint sang Markdown, điều này hữu ích cho quy trình tài liệu, tạo trang tĩnh, di chuyển nội dung và xuất bản văn bản có kiểm soát phiên bản. API hỗ trợ xuất trực tiếp từ các bài thuyết trình PPT và PPTX sang tệp MD và cung cấp các tùy chọn bổ sung để kiểm soát cách nội dung slide được biểu diễn trong tài liệu Markdown kết quả.

Bạn có thể xuất các bài thuyết trình dưới dạng Markdown thuần, chọn từ nhiều kiểu Markdown như CommonMark và GitHub Flavored Markdown, và cấu hình cách xử lý hình ảnh trong quá trình xuất. Đối với các bài thuyết trình chứa nội dung hình ảnh, Aspose.Slides cũng cho phép lưu ảnh vào thư mục riêng và tham chiếu chúng từ tệp Markdown được tạo.

{{% alert color="warning" %}}
Việc xuất PowerPoint sang Markdown **mặc định không bao gồm hình ảnh**. Nếu bạn muốn xuất một tài liệu PowerPoint có chứa hình ảnh, cần đặt `ExportType = MarkdownExportType::Visual` và chỉ định `BasePath`, nơi các hình ảnh được tham chiếu trong tài liệu Markdown sẽ được lưu.
{{% /alert %}}

## **Chuyển đổi bài thuyết trình sang Markdown**

Phần này giải thích cách Aspose.Slides chuyển đổi các bài thuyết trình PowerPoint và OpenDocument (PPT, PPTX, ODP) thành Markdown sạch, giữ nguyên cấu trúc slide, văn bản và định dạng cốt lõi để bạn có thể tái sử dụng nội dung trong tài liệu hoặc quy trình kiểm soát phiên bản mà không cần công sức thủ công thêm.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để đại diện cho bài thuyết trình.  
1. Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) để xuất nó dưới dạng tệp Markdown.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi bài thuyết trình sang một kiểu Markdown**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình PowerPoint sang Markdown với cú pháp cơ bản, cũng như sang CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab và mười bảy kiểu Markdown khác.

Mã PHP sau đây minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

23 kiểu Markdown được hỗ trợ được liệt kê trong [Flavor enumeration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/flavor/).

## **Chuyển đổi bài thuyết trình có chứa hình ảnh sang Markdown**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) cung cấp các thuộc tính và enum cho phép bạn cấu hình tệp Markdown kết quả. Ví dụ, enum [MarkdownExportType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownexporttype/) chỉ định cách xử lý hình ảnh: `Sequential`, `TextOnly` hoặc `Visual`.

{{% alert color="warning" %}}
Mặc định, việc xuất PowerPoint‑to‑Markdown **không bao gồm hình ảnh**. Để nhúng hình ảnh, gọi `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` và đặt `BasePath` chỉ ra nơi các hình ảnh được tham chiếu trong tệp Markdown sẽ được lưu.
{{% /alert %}}

### **Chuyển đổi hình ảnh theo thứ tự**

Nếu bạn muốn các hình ảnh xuất hiện riêng lẻ, lần lượt, trong Markdown kết quả, phải chọn tùy chọn `Sequential`. Mã PHP sau đây cho thấy cách chuyển đổi một bài thuyết trình có chứa hình ảnh sang Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Chuyển đổi hình ảnh theo dạng trực quan**

Nếu bạn muốn các hình ảnh xuất hiện cùng nhau trong Markdown kết quả, phải chọn tùy chọn `Visual`. Trong trường hợp này, các hình ảnh được lưu vào thư mục hiện tại của ứng dụng (và một đường dẫn tương đối được tạo cho chúng trong tài liệu Markdown), hoặc bạn có thể chỉ định thư mục và tên thư mục ưa thích của mình.

Mã PHP sau đây minh họa thao tác này:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Liệu các siêu liên kết có được giữ lại khi xuất sang Markdown không?**

Có. Các [siêu liên kết](/slides/vi/php-java/manage-hyperlinks/) trong văn bản được giữ lại dưới dạng liên kết Markdown tiêu chuẩn. Các [chuyển tiếp](/slides/vi/php-java/slide-transition/) và [hoạt ảnh](/slides/vi/php-java/powerpoint-animation/) không được chuyển đổi.

**Tôi có thể tăng tốc chuyển đổi bằng cách chạy đa luồng không?**

Bạn có thể thực hiện song song trên các tệp, nhưng [đừng chia sẻ](/slides/vi/php-java/multithreading/) cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) giữa các luồng. Sử dụng các thể hiện/tiến trình riêng cho mỗi tệp để tránh tranh chấp.

**Điều gì xảy ra với hình ảnh—chúng được lưu ở đâu và đường dẫn có phải là tương đối không?**

[Hình ảnh](/slides/vi/php-java/image/) được xuất ra một thư mục riêng, và tệp Markdown tham chiếu chúng bằng các đường dẫn tương đối theo mặc định. Bạn có thể cấu hình đường dẫn xuất cơ sở và tên thư mục tài sản để giữ cấu trúc kho dự đoán được.