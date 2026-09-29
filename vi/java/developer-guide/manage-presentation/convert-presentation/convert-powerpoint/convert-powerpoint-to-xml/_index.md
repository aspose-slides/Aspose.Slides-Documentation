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
- Bản trình chiếu XML PowerPoint
- SaveFormat.Xml
- lưu bản trình chiếu dưới dạng XML
- xuất bản trình chiếu sang XML
- luồng XML
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang các tệp hoặc luồng XML PowerPoint trong Java với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides for Java có thể chuyển đổi các bản trình chiếu PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần một biểu diễn dạng văn bản để kiểm tra cấu trúc bản trình chiếu, khắc phục sự cố tài liệu được tạo, so sánh kết quả trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì gói bản trình chiếu.

Sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) với giá trị `Xml` từ lớp [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` tạo ra một PowerPoint XML Presentation. Nó không tách các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn `ppt/presentation.xml` hoặc các tệp XML slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.

{{% /alert %}}

## **Chuyển đổi bản trình chiếu sang tệp XML**

Tải bản trình chiếu nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và sau đó truyền đường dẫn đầu ra cùng `SaveFormat.Xml` vào [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Nguồn có thể là bất kỳ định dạng bản trình chiếu nào được hỗ trợ để tải, chẳng hạn PPT, PPTX, hoặc ODP.

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

Sử dụng phiên bản overload của [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) khi XML cần giữ trong bộ nhớ hoặc truyền cho thành phần khác, như dịch vụ web, nhà cung cấp lưu trữ, hoặc pipeline xử lý XML. Ví dụ sau ghi kết quả vào một [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) và lấy XML dưới dạng mảng byte:

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

Chọn định dạng đầu ra dựa trên cách sử dụng kết quả:

| Định dạng | Đầu ra | Sử dụng phổ biến |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo, và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tệp bản trình chiếu nhị phân cổ | Tương thích với quy trình PowerPoint cũ |
| PPTX (`.pptx`) | Gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thường xuyên và trao đổi bản trình chiếu |
| PDF hoặc TIFF | Các trang có bố cục cố định hoặc ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Đại diện đã render của một slide riêng lẻ | Hình thu nhỏ, xem trước và tài nguyên hình ảnh |
| HTML hoặc HTML5 | Đầu ra bản trình chiếu hướng web | Xem trên trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu dành cho việc kiểm tra và quy trình làm việc dựa trên dữ liệu. Khác với PDF, TIFF, HTML và các định dạng ảnh slide, nó biểu diễn dữ liệu bản trình chiếu chứ không render slide dưới dạng trang hoặc tài sản hình ảnh. Bảng [supported file formats](/slides/vi/java/supported-file-formats/) liệt kê mọi định dạng mà Aspose.Slides có thể tải, nhập, lưu hoặc render.

## **Câu hỏi thường gặp**

**`SaveFormat.Xml` có giống như lưu một tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat.Xml` tạo ra một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng ghi được vào [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Ví dụ, sử dụng một [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Có. Truyền tệp XML hoặc luồng vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSourceFormat--) sau đó trả về `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) báo cáo `LoadFormat.Unknown` cho định dạng này, vì vậy đừng dùng nó để quyết định liệu tệp XML có thể mở được hay không.

**Chuyển đổi XML có render mỗi slide thành trang hoặc ảnh không?**

Không. Chuyển đổi XML ghi dữ liệu cấu trúc của bản trình chiếu. Sử dụng PDF hoặc TIFF để có đầu ra dạng trang, hoặc PNG, JPEG và SVG cho ảnh slide riêng lẻ.