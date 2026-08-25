---
title: Chuyển đổi PPT sang PPTX trong Java
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/java/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT kế thừa sang PPTX trong Java với Aspose.Slides. Bao gồm các ví dụ Java cho chuyển đổi tệp đơn và hàng loạt, xử lý lỗi, và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân kế thừa, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for Java có thể tải tệp PPT và lưu dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này giới thiệu cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những nội dung cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/#Pptx). Khối `finally` giải phóng đối tượng presentation và giải phóng tài nguyên của nó.

```java
// Tải bản trình bày PPT kế thừa.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Lưu bản trình bày ở định dạng PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/#Pptx) quyết định. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ nguyên tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi không làm dừng toàn bộ lô.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định có nên ghi đè tệp đầu ra đã tồn tại hay không, và ghi tên các tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà không cung cấp mật khẩu đúng, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/slides/vi/java/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ trung thực và các tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách. Một tính năng kế thừa không có tương đương trong PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa các hoạt ảnh, chuyển đổi, đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến hoặc macro VBA. Tệp PPTX thông thường không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro khi cần giữ lại VBA. Đồng thời, xác minh rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường nơi bản trình bày đã chuyển đổi sẽ được mở hoặc hiển thị.

Đối với các tài liệu quan trọng, hãy mở lại tệp PPTX đã tạo bằng chương trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong phần mềm xem mong muốn. Không coi một lời gọi [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) thành công là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình bày sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện đại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân kế thừa. Giữ bản PPT gốc như bản lưu trữ hoặc bản sao quay lại cho đến khi bản trình bày đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc loại đầu ra khác, hãy sử dụng hướng dẫn theo định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/java/convert-presentation/) thay vì giả định rằng mọi mục tiêu đều giữ lại các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với tệp không thường xuyên hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý batch, hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng Java API.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/java/ppt-vs-pptx/)
- [Lưu bản trình bày trong Java](/slides/vi/java/save-presentation/)
- [Định dạng tệp được hỗ trợ](/slides/vi/java/supported-file-formats/)
- [Mở bản trình bày trong Java](/slides/vi/java/open-presentation/)

## **Câu hỏi thường gặp**

**Có thể chuyển đổi PPT sang PPTX mà không cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for Java tải và lưu các tệp trình bày mà không cần Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ lại nội dung chung của bản trình bày, nhưng độ trung thực chính xác không được đảm bảo cho mọi tính năng kế thừa hoặc không được hỗ trợ. Kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh đặc biệt hoặc phông chữ không phổ biến.

**Có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu mật khẩu hoặc mật khẩu không đúng sẽ làm cho thao tác tải thất bại.

**Có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ bản gốc cho đến khi bạn đã kiểm tra PPTX trong các trình xem và quy trình làm việc quan trọng đối với bạn. Điều này cung cấp một bản sao quay lại nếu một tính năng kế thừa được chuyển đổi khác nhau.