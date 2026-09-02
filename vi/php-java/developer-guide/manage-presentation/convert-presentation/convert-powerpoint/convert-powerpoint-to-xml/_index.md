---
title: "Chuyển đổi bản thuyết trình PowerPoint sang XML trong PHP"
linktitle: "PowerPoint sang XML"
type: docs
weight: 145
url: /vi/php-java/convert-powerpoint-to-xml/
keywords:
- "chuyển đổi PowerPoint sang XML"
- "chuyển đổi bản thuyết trình sang XML"
- "PPT sang XML"
- "PPTX sang XML"
- "ODP sang XML"
- "PowerPoint XML Presentation"
- SaveFormat.Xml
- "lưu bản thuyết trình dưới dạng XML"
- "xuất bản thuyết trình sang XML"
- "luồng XML"
- PHP
- Aspose.Slides
description: "Chuyển đổi các bản thuyết trình PowerPoint và OpenDocument sang tệp XML PowerPoint hoặc luồng trong PHP với Aspose.Slides for PHP via Java."
---
## **Tổng quan**

Aspose.Slides for PHP via Java có thể chuyển đổi các bản thuyết trình PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần biểu diễn dạng văn bản để kiểm tra cấu trúc bài thuyết trình, khắc phục sự cố tài liệu được tạo, so sánh kết quả trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì gói bản thuyết trình.

Sử dụng phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) với giá trị `Xml` từ enum [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Lưu ý" %}}

`SaveFormat::Xml` tạo một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn `ppt/presentation.xml` hoặc các tệp XML slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.

{{% /alert %}}

## **Chuyển đổi bản thuyết trình sang tệp XML**

Tải một bản thuyết trình nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), sau đó truyền đường dẫn đầu ra và `SaveFormat::Xml` cho [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Nguồn có thể là bất kỳ định dạng bản thuyết trình nào được hỗ trợ để tải, chẳng hạn PPT, PPTX hoặc ODP.

Ví dụ sau chuyển đổi một bản thuyết trình PPTX sang tệp XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Ghi đầu ra XML vào luồng**

Sử dụng bản overload luồng của [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) khi XML phải ở trong bộ nhớ hoặc được truyền cho thành phần khác, như dịch vụ web, nhà cung cấp lưu trữ, hoặc pipeline xử lý XML. Ví dụ sau ghi kết quả vào một [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) và lấy XML đã tạo dưới dạng mảng byte:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Chuyển $xmlBytes tới thành phần tiếp theo trong quy trình làm việc.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` lưu tất cả dữ liệu được tạo trong bộ nhớ, do đó không cần đặt lại vị trí trước khi gọi `toByteArray`.

## **So sánh XML với các định dạng bản thuyết trình và xuất**

Chọn định dạng đầu ra tùy theo cách kết quả sẽ được sử dụng:

| Định dạng | Đầu ra | Ứng dụng phổ biến |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo, và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tệp bản thuyết trình nhị phân kế thừa | Tương thích với quy trình PowerPoint cũ |
| PPTX (`.pptx`) | Gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thường và trao đổi bản thuyết trình |
| PDF hoặc TIFF | Các trang bố cục cố định hoặc ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Đại diện đã render của một slide riêng lẻ | Hình thu nhỏ, xem trước và tài sản hình ảnh |
| HTML hoặc HTML5 | Đầu ra bản thuyết trình hướng web | Xem trên trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu được dùng để kiểm tra và các quy trình làm việc dựa trên dữ liệu. Khác với PDF, TIFF, HTML và các định dạng hình ảnh slide, nó biểu diễn dữ liệu bản thuyết trình thay vì render các slide thành trang hoặc tài sản hình ảnh. Bảng [supported file formats](/slides/vi/php-java/supported-file-formats/) liệt kê PowerPoint XML Presentation là định dạng chỉ lưu, vì vậy không nên sử dụng khi quy trình phải tải lại tệp đã xuất vào Aspose.Slides để tiếp tục chỉnh sửa.

## **Câu hỏi thường gặp**

**`SaveFormat::Xml` có giống như lưu một tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat::Xml` tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng có thể ghi được cho [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Ví dụ, sử dụng một [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ hỗ trợ lưu mà không hỗ trợ tải. Sử dụng PPTX hoặc định dạng bản thuyết trình khác được hỗ trợ khi cần chỉnh sửa vòng tròn.

**Việc chuyển đổi XML có render mỗi slide thành trang hoặc hình ảnh không?**

Không. Chuyển đổi XML ghi dữ liệu bản thuyết trình có cấu trúc. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho hình ảnh slide riêng lẻ.