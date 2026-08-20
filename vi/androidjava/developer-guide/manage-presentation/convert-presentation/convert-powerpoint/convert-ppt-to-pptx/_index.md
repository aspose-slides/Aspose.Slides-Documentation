---
title: Chuyển đổi PPT sang PPTX trên Android
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT cổ điển sang PPTX trên Android bằng Aspose.Slides. Bao gồm các ví dụ Java cho chuyển đổi tệp đơn và hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng nhị phân cổ của PowerPoint, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for Android via Java có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này hướng dẫn cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những việc cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/#Pptx). Khối `finally` sẽ giải phóng presentation và giải phóng tài nguyên của nó.

```java
// Tải bản trình chiếu PPT cổ điển.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Lưu bản trình chiếu dưới định dạng PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phần đuôi tệp không tự động xác định định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/#Pptx) mới làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lần chuyển đổi thất bại sẽ không làm dừng phần còn lại của lô.

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

Đối với các tải công việc sản xuất, ghi lại toàn bộ ngoại lệ, quyết định liệu có được ghi đè tệp đầu ra đã tồn tại hay không, và ghi tên các tệp thất bại vào hàng đợi retry hoặc review. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu nhưng được mở mà không có mật khẩu đúng, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem mục [Password-Protected Presentations](/androidjava/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ trung thực và các tính năng cổ**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không biểu diễn mọi tính năng theo cùng một cách. Một tính năng cổ không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể bị chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển đổi, đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ hiếm, hoặc macro VBA. Tệp PPTX thuần không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần được duy trì. Cũng xác nhận rằng các phông chữ cần thiết và tài nguyên bên ngoài có sẵn trong môi trường nơi bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, mở lại PPTX đã tạo bằng mã và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi chiếu slide trong trình xem dự kiến. Đừng xem một lời gọi [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) thành công là bằng chứng rằng mọi tính năng cổ đều có biểu diễn PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, được trao đổi với các hệ thống làm việc với gói Open XML, hoặc được lưu ở định dạng dễ kiểm tra và phục hồi hơn so với PPT nhị phân cổ. Giữ lại PPT gốc như bản lưu trữ hoặc bản sao quay lại cho đến khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc định dạng đầu ra khác, hãy sử dụng hướng dẫn cụ thể cho từng định dạng trong mục [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) thay vì giả định rằng mọi mục tiêu đều bảo lưu các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với các tệp hiếm gặp hoặc so sánh nhanh, bạn có thể dùng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt, hoặc xử lý lỗi ở mức ứng dụng, hãy dùng API Android via Java.

## **Bài viết liên quan**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/androidjava/save-presentation/)
- [Supported File Formats](/androidjava/supported-file-formats/)
- [Open Presentations on Android](/androidjava/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for Android via Java tải và lưu các tệp trình chiếu mà không yêu cầu Microsoft PowerPoint.

**Việc chuyển đổi PPT sang PPTX có giữ nguyên mọi nội dung không?**

Nó giữ lại nội dung trình chiếu phổ biến, nhưng độ trung thực hoàn toàn không được đảm bảo đối với mọi tính năng cổ hoặc không được hỗ trợ. Xem lại tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên biệt hoặc phông chữ hiếm.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu hoặc sai mật khẩu sẽ khiến thao tác tải thất bại.

**Sau khi chuyển đổi, tôi nên xóa tệp PPT không?**

Giữ lại tệp gốc cho đến khi bạn đã xác nhận PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp một bản sao quay lại nếu tính năng cổ chuyển đổi khác đi.