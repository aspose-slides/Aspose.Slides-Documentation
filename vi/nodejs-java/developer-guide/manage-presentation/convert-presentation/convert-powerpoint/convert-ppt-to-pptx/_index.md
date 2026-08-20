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
description: "Chuyển đổi các tệp PPT cổ điển sang PPTX trong Node.js với Aspose.Slides. Bao gồm các ví dụ JavaScript cho chuyển đổi một tệp và hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng nhị phân PowerPoint cũ, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides cho Node.js qua Java có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này hướng dẫn cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

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

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ nguyên tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ dưới đây chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một chuyển đổi thất bại sẽ không làm dừng phần còn lại của lô.

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

Đối với môi trường sản xuất, ghi lại lỗi đầy đủ, quyết định liệu có cho phép ghi đè tệp đầu ra đã tồn tại hay không, và ghi các tên tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà mở mà không có mật khẩu cần thiết, đường dẫn không truy cập được và nội dung không hỗ trợ đều có thể gây chuyển đổi thất bại. Xem [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) để tải các tệp đã mã hóa.

## **Độ trung thực và các tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng một cách hoàn toàn giống nhau. Một tính năng kế thừa không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển tiếp, các đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến, hoặc macro VBA. Tệp PPTX thông thường không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần được giữ lại. Cũng hãy xác minh rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường mà bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, mở lại PPTX được tạo một cách lập trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem mục tiêu. Đừng coi một cuộc gọi thành công [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân cũ. Giữ bản PPT gốc như một bản lưu trữ hoặc bản sao khôi phục cho đến khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS, hoặc loại đầu ra khác, hãy sử dụng hướng dẫn riêng cho định dạng trong [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) thay vì giả định rằng mọi mục tiêu đều bảo lưu các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với một tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt, hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API Node.js qua Java.

## **Bài viết liên quan**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Lưu bản trình chiếu trong Node.js](/nodejs-java/save-presentation/)
- [Các định dạng tệp được hỗ trợ](/nodejs-java/supported-file-formats/)
- [Mở bản trình chiếu trong Node.js](/nodejs-java/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides cho Node.js qua Java tải và lưu các tệp trình chiếu mà không cần Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ lại nội dung trình chiếu chung, nhưng độ trung thực chính xác không được đảm bảo cho mọi tính năng cũ hoặc không được hỗ trợ. Kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên biệt, hoặc phông chữ không phổ biến.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu mật khẩu hoặc mật khẩu không đúng sẽ khiến thao tác tải thất bại.

**Tôi có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ bản gốc cho đến khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp một bản sao khôi phục nếu tính năng cũ chuyển đổi khác nhau.