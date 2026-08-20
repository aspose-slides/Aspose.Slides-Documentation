---
title: Chuyển đổi PPT sang PPTX trong Java
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/java/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT kế thừa sang PPTX trong Java bằng Aspose.Slides. Bao gồm các ví dụ Java cho chuyển đổi tệp đơn và hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân kế thừa, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides cho Java có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này trình bày cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những điều cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) , sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/#Pptx) . Khối `finally` giải phóng đối tượng trình chiếu và giải phóng tài nguyên.

```java
// Tải bản trình chiếu PPT kế thừa.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Lưu bản trình chiếu ở định dạng PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/#Pptx) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ dưới đây chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi không làm dừng toàn bộ lô.

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

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định có ghi đè lên tệp đầu ra hiện có hay không, và ghi tên các tệp thất bại vào hàng đợi thử lại hoặc rà soát. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà không cung cấp mật khẩu đúng, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/java/password-protected-presentation/) để tải các tệp đã mã hoá.

## **Độ trung thực và các tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không biểu diễn mọi tính năng một cách giống hệt nhau. Một tính năng kế thừa không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển cảnh, đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ ít gặp hoặc macro VBA. Tệp PPTX thuần không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro phù hợp khi cần giữ lại VBA. Đồng thời xác thực rằng các phông chữ và tài nguyên bên ngoài cần thiết có mặt trong môi trường mà bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, mở lại PPTX đã tạo bằng mã và kiểm tra số lượng slide và nội dung quan trọng, sau đó so sánh giao diện và hành vi chiếu slide trong trình xem dự kiến. Đừng coi một cuộc gọi thành công của [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên dùng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, được trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân kế thừa. Giữ lại tệp PPT gốc làm bản lưu trữ hoặc sao lưu cho tới khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc kiểu đầu ra khác, hãy sử dụng hướng dẫn định dạng cụ thể trong [Convert Presentations to Multiple Formats](/java/convert-presentation/)... thay vì cho rằng mọi mục tiêu đều giữ lại các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API Java.

## **Bài viết liên quan**

- [PPT và PPTX](/java/ppt-vs-pptx/)
- [Lưu bản trình chiếu trong Java](/java/save-presentation/)
- [Các định dạng tệp được hỗ trợ](/java/supported-file-formats/)
- [Mở bản trình chiếu trong Java](/java/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides cho Java tải và lưu các tệp trình chiếu mà không cần Microsoft PowerPoint.

**Việc chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ lại nội dung trình chiếu phổ biến, nhưng độ trung thực chính xác không được đảm bảo cho mọi tính năng kế thừa hoặc không được hỗ trợ. Hãy kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh đặc biệt hoặc phông chữ ít gặp.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu mật khẩu hoặc mật khẩu không đúng sẽ khiến thao tác tải thất bại.

**Có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ lại bản gốc cho đến khi bạn đã xác thực PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp bản sao lưu nếu một tính năng kế thừa chuyển đổi khác.