---
title: Chuyển đổi PPT sang PPTX trong Node.js
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các tệp PPT cũ sang PPTX trong Node.js bằng Aspose.Slides. Bao gồm các ví dụ JavaScript cho chuyển đổi tệp đơn và hàng loạt, xử lý lỗi và ghi chú về độ chính xác."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides cho Node.js thông qua Java có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này trình bày cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/), sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/). Khối `finally` giải phóng presentation và giải phóng các tài nguyên của nó.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tải bản trình chiếu PPT kế thừa.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Lưu bản trình chiếu ở định dạng PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lần chuyển đổi thất bại sẽ không làm dừng phần còn lại của lô.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Đối với các tải công việc sản xuất, ghi lại lỗi đầy đủ, quyết định liệu có thể ghi đè tệp đầu ra đã tồn tại không, và ghi các tên tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà mở mà không có mật khẩu cần thiết, đường dẫn không thể truy cập và nội dung không được hỗ trợ đều có thể gây thất bại khi chuyển đổi. Xem [Password-Protected Presentations](/slides/vi/nodejs-java/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ chính xác và tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, bố cục, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng một cách hoàn toàn giống nhau. Một tính năng kế thừa không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt hình, chuyển tiếp, các đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến, hoặc macro VBA. Tệp PPTX thuần không hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA phải được giữ lại. Đồng thời xác minh rằng các phông chữ cần thiết và tài nguyên bên ngoài có trong môi trường nơi bản trình bày đã chuyển đổi sẽ được mở hoặc hiển thị.

Đối với các tài liệu quan trọng, hãy mở lại PPTX được tạo bằng chương trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi chiếu slide trong trình xem mong muốn. Đừng coi một lời gọi thành công tới [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) là bằng chứng rằng mọi tính năng kế thừa đều có biểu diễn PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình bày sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân cũ. Giữ bản PPT gốc làm bản lưu trữ hoặc sao lưu cho tới khi bản trình bày đã chuyển đổi vượt qua các kiểm tra độ chính xác của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS, hoặc loại đầu ra khác, hãy sử dụng hướng dẫn cụ thể cho định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/nodejs-java/convert-presentation/) thay vì cho rằng mọi mục tiêu đều giữ nguyên các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với tệp cá nhân hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt, hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API Node.js qua Java.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/nodejs-java/ppt-vs-pptx/)
- [Lưu trình chiếu trong Node.js](/slides/vi/nodejs-java/save-presentation/)
- [Định dạng tệp được hỗ trợ](/slides/vi/nodejs-java/supported-file-formats/)
- [Mở trình chiếu trong Node.js](/slides/vi/nodejs-java/open-presentation/)

## **FAQ**

**Có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides cho Node.js thông qua Java tải và lưu các tệp trình chiếu mà không yêu cầu Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung không?**

Nó giữ lại nội dung trình chiếu thông thường, nhưng không đảm bảo độ chính xác tuyệt đối cho mọi tính năng kế thừa hoặc không được hỗ trợ. Kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh đặc biệt, hoặc phông chữ không phổ biến.

**Có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu hoặc sai mật khẩu sẽ khiến thao tác tải thất bại.

**Có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ bản gốc cho tới khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp bản sao lưu nếu một tính năng kế thừa được chuyển đổi khác đi.