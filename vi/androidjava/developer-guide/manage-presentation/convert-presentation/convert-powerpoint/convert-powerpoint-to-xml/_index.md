---
title: Chuyển đổi Bản trình chiếu PowerPoint sang XML trên Android
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/androidjava/convert-powerpoint-to-xml/
keywords:
- chuyển đổi PowerPoint sang XML
- chuyển đổi bản trình chiếu sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- lưu bản trình chiếu dưới dạng XML
- xuất bản trình chiếu sang XML
- luồng XML
- Android
- Java
- Aspose.Slides
description: Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang tệp hoặc luồng PowerPoint XML trên Android bằng Aspose.Slides.
---
## **Tổng quan**

Aspose.Slides for Android via Java có thể chuyển đổi các bản trình chiếu PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần một biểu diễn dạng văn bản để kiểm tra cấu trúc bản trình chiếu, khắc phục sự cố tài liệu được tạo, so sánh kết quả trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì một gói bản trình chiếu.

Sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) với [SaveFormat.Xml](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/#Xml). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` tạo ra một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn như `ppt/presentation.xml` hoặc các tệp XML slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.
{{% /alert %}}

## **Chuyển đổi Bản trình chiếu sang Tập tin XML**

Tải một bản trình chiếu nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và sau đó truyền đường dẫn đầu ra và [SaveFormat.Xml](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/#Xml) vào [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Nguồn có thể là bất kỳ định dạng bản trình chiếu nào được hỗ trợ để tải, chẳng hạn như PPT, PPTX hoặc ODP.

Ví dụ dưới đây chuyển đổi một bản trình chiếu PPTX sang tệp XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Ghi Đầu ra XML vào Luồng**

Sử dụng phiên bản overload của [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) khi XML cần ở trong bộ nhớ hoặc được truyền cho thành phần khác, chẳng hạn như dịch vụ web, nhà cung cấp lưu trữ, hoặc pipeline xử lý XML. Ví dụ dưới đây ghi kết quả vào một [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) và lấy XML đã tạo dưới dạng mảng byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Chuyển xmlData tới thành phần tiếp theo trong quy trình làm việc.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **So sánh XML với Định dạng Bản trình chiếu và Xuất**

Chọn định dạng đầu ra tùy theo cách kết quả sẽ được sử dụng:

| Định dạng | Đầu ra | Ứng dụng điển hình |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Một PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo, và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tập tin bản trình chiếu nhị phân lược đồ | Tương thích với quy trình làm việc PowerPoint cũ |
| PPTX (`.pptx`) | Gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thông thường và trao đổi bản trình chiếu |
| PDF hoặc TIFF | Các trang dàn cố định hoặc ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Biểu diễn đã render của một slide riêng lẻ | Ảnh thu nhỏ, bản xem trước và tài nguyên ảnh |
| HTML hoặc HTML5 | Đầu ra bản trình chiếu hướng web | Xem trên trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu nhằm mục đích kiểm tra và quy trình làm việc dựa trên dữ liệu. Khác với PDF, TIFF, HTML và các định dạng ảnh slide, nó biểu diễn dữ liệu bản trình chiếu thay vì render các slide thành trang hoặc tài sản hình ảnh. Bảng [định dạng tệp được hỗ trợ](/slides/vi/androidjava/supported-file-formats/) liệt kê PowerPoint XML Presentation là định dạng chỉ‑lưu, vì vậy không nên sử dụng khi một quy trình phải tải lại tệp đã xuất để tiếp tục chỉnh sửa trong Aspose.Slides.

## **Câu hỏi thường gặp**

**Liệu `SaveFormat.Xml` có giống như việc lưu tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat.Xml` tạo ra một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Chuyển một luồng ghi được vào [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Ví dụ, sử dụng một [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ được hỗ trợ để lưu mà không hỗ trợ tải lại. Hãy sử dụng PPTX hoặc định dạng bản trình chiếu được hỗ trợ khác khi cần chỉnh sửa vòng vòng.

**Quá trình chuyển đổi XML có render mỗi slide thành trang hoặc ảnh không?**

Không. Quá trình chuyển đổi XML ghi dữ liệu bản trình chiếu có cấu trúc. Sử dụng PDF hoặc TIFF để có đầu ra dạng trang, hoặc PNG, JPEG và SVG cho ảnh slide riêng lẻ.