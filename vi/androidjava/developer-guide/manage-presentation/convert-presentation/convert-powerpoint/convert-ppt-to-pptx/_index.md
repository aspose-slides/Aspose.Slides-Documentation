---
title: Chuyển đổi PPT sang PPTX trên Android
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/androidjava/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT legacy sang PPTX trên Android bằng Aspose.Slides. Bao gồm các ví dụ Java cho việc chuyển đổi tệp đơn và chuyển đổi batch, xử lý lỗi và ghi chú về độ chính xác."
---
## **Tổng quan**

PPT là định dạng nhị phân Legacy của PowerPoint, trong khi PPTX là định dạng Open XML hiện đại hơn. Aspose.Slides for Android qua Java có thể tải một tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này hướng dẫn cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những điều cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/#Pptx). Khối `finally` sẽ giải phóng presentation và giải phóng các tài nguyên của nó.

```java
// Tải bản trình chiếu PPT cũ.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Lưu bản trình chiếu ở định dạng PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phần mở rộng tệp không tự động xác định định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/#Pptx) thực hiện điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ dưới đây chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi không làm dừng các tệp còn lại trong batch.

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

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định liệu có cho phép ghi đè tệp đầu ra đã tồn tại hay không, và ghi tên các tệp bị lỗi vào hàng đợi retry hoặc review. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà không cung cấp mật khẩu đúng, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/androidjava/password-protected-presentation/) để tải các tệp được mã hoá.

## **Độ chính xác và các tính năng Legacy**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không biểu diễn mọi tính năng theo cùng một cách. Một tính năng legacy không có tương đương trong PPTX, hoặc không được thư viện hỗ trợ, có thể bị chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển tiếp, đối tượng OLE được nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ hiếm hoặc macro VBA. Tệp PPTX thuần không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần được giữ lại. Đồng thời xác nhận rằng các phông chữ cần thiết và tài nguyên bên ngoài có sẵn trong môi trường mà bản thuyết trình đã chuyển sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, hãy mở lại PPTX đã tạo bằng mã và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự kiến. Đừng coi một lời gọi thành công của [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) là bằng chứng rằng mọi tính năng legacy đều có biểu diễn PPTX chính xác.

## **Khi nào nên dùng PPTX**

Sử dụng PPTX khi bản thuyết trình sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện hành, được trao đổi với các hệ thống làm việc với gói Open XML, hoặc được lưu dưới dạng dễ kiểm tra và khôi phục hơn so với định dạng nhị phân legacy PPT. Giữ bản PPT gốc làm bản lưu trữ hoặc bản sao phục hồi cho đến khi bản PPTX đã chuyển đổi vượt qua các kiểm tra độ chính xác của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc loại đầu ra khác, hãy tham khảo hướng dẫn cụ thể cho định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/androidjava/convert-presentation/) thay vì cho rằng mọi đích đến đều bảo tồn các tính năng PowerPoint có thể chỉnh sửa được.

## **Trình chuyển đổi trực tuyến**

Đối với một tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý batch, hoặc xử lý lỗi ở cấp ứng dụng, hãy sử dụng API Android qua Java.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/vi/androidjava/save-presentation/)
- [Supported File Formats](/slides/vi/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/vi/androidjava/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for Android qua Java tải và lưu các tệp thuyết trình mà không yêu cầu Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung không?**

Nó giữ lại nội dung chung của bản thuyết trình, nhưng độ chính xác tuyệt đối không được đảm bảo cho mọi tính năng legacy hoặc không được hỗ trợ. Kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên biệt hoặc phông chữ hiếm.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp đúng mật khẩu khi tải tệp. Thiếu mật khẩu hoặc mật khẩu sai sẽ khiến thao tác tải thất bại.

**Có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ lại bản gốc cho đến khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng đối với bạn. Điều này cung cấp bản sao phục hồi nếu một tính năng legacy được chuyển đổi khác đi.