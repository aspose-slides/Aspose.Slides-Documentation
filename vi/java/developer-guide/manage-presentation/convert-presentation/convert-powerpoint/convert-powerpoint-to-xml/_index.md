---
title: Chuyển đổi bản trình chiếu PowerPoint sang XML trong Java
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/java/convert-powerpoint-to-xml/
keywords:
- chuyển đổi PowerPoint sang XML
- chuyển đổi bản trình chiếu sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- Bản trình chiếu PowerPoint XML
- SaveFormat.Xml
- lưu bản trình chiếu dưới dạng XML
- xuất bản trình chiếu sang XML
- luồng XML
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang tệp hoặc luồng PowerPoint XML trong Java với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides for Java có thể chuyển đổi các bản trình chiếu PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần một biểu diễn dựa trên văn bản để kiểm tra cấu trúc bản trình chiếu, khắc phục sự cố tài liệu được tạo, so sánh kết quả trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì một gói bản trình chiếu.

Sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) với giá trị `Xml` từ lớp [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` tạo một PowerPoint XML Presentation. Nó không trích xuất các phần riêng lẻ của Office Open XML được lưu bên trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn như `ppt/presentation.xml` hoặc các tệp XML của slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.

{{% /alert %}}

## **Chuyển đổi bản trình chiếu sang tệp XML**

Tải một bản trình chiếu nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), sau đó truyền đường dẫn đầu ra và `SaveFormat.Xml` cho [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Nguồn có thể là bất kỳ định dạng bản trình chiếu nào được hỗ trợ để tải, chẳng hạn như PPT, PPTX hoặc ODP.

Ví dụ sau chuyển đổi một bản trình chiếu PPTX sang tệp XML:

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

## **Ghi đầu ra XML vào luồng**

Sử dụng phiên bản overload của [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) khi XML cần giữ trong bộ nhớ hoặc được truyền tới thành phần khác, chẳng hạn như dịch vụ web, nhà cung cấp lưu trữ, hoặc pipeline xử lý XML. Ví dụ sau ghi kết quả vào một [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) và lấy XML kết quả dưới dạng mảng byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Chuyển xmlData tới thành phần tiếp theo trong quy trình làm việc.
} finally {
    presentation.dispose();
}
```

## **So sánh XML với các định dạng bản trình chiếu và xuất**

Chọn định dạng đầu ra dựa trên cách kết quả sẽ được sử dụng:

| Định dạng | Đầu ra | Sử dụng thường |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh kết quả đã tạo và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tệp bản trình chiếu nhị phân legacy | Tương thích với quy trình làm việc PowerPoint cũ |
| PPTX (`.pptx`) | Gói Office Open XML chứa nhiều phần | Chỉnh sửa và trao đổi bản trình chiếu PowerPoint thông thường |
| PDF hoặc TIFF | Các trang cố định hoặc hình ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Đại diện được render của một slide riêng lẻ | Hình thu nhỏ, preview và tài sản hình ảnh |
| HTML hoặc HTML5 | Đầu ra bản trình chiếu hướng web | Xem trên trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu hướng tới việc kiểm tra và các quy trình làm việc dựa trên dữ liệu. Khác với PDF, TIFF, HTML và các định dạng hình ảnh slide, nó biểu diễn dữ liệu bản trình chiếu thay vì render các slide dưới dạng trang hoặc tài sản hình ảnh. Bảng [định dạng tệp được hỗ trợ](/slides/vi/java/supported-file-formats/) liệt kê PowerPoint XML Presentation là định dạng chỉ lưu, vì vậy không sử dụng nó khi một quy trình làm việc phải tải lại tệp đã xuất vào Aspose.Slides để tiếp tục chỉnh sửa.

## **Câu hỏi thường gặp**

**`SaveFormat.Xml` có giống như lưu một tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat.Xml` tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng ghi được tới [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Ví dụ, sử dụng một [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ được hỗ trợ để lưu, không hỗ trợ tải. Sử dụng PPTX hoặc định dạng bản trình chiếu khác được hỗ trợ khi cần chỉnh sửa vòng vòng.

**Quá trình chuyển đổi XML có render mỗi slide thành một trang hoặc hình ảnh không?**

Không. Chuyển đổi XML ghi dữ liệu cấu trúc của bản trình chiếu. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho hình ảnh slide riêng lẻ.