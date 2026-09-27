---
title: Mở Bài Thuyết Trình trong Node.js via .NET
linktitle: Mở Bài Thuyết Trình
type: docs
weight: 20
url: /vi/nodejs-net/open-presentation/
keywords:
- mở bài thuyết trình
- mở PowerPoint
- mở PPTX
- mở PPT
- mở ODP
- tải bài thuyết trình
- bài thuyết trình từ buffer
- số slide
- chuyển đổi bài thuyết trình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Mở các bài thuyết trình PPTX, PPT và ODP trong JavaScript bằng Aspose.Slides cho Node.js qua .NET: tải từ đường dẫn tệp hoặc Buffer, đọc số slide và lưu dưới định dạng khác."
---
## **Tổng quan**

Aspose.Slides for Node.js via .NET mở các bài thuyết trình PowerPoint và OpenDocument, chẳng hạn như các tệp PPTX, PPT và ODP, từ một đường dẫn tệp hoặc từ một `Buffer` của Node.js. Bài viết này trình bày cả hai cách, đếm số slide và lưu bài thuyết trình đã mở sang định dạng khác.

Các ví dụ yêu cầu có một bài thuyết trình tên `sample.pptx` trong thư mục dự án mà bạn đã thiết lập trong [Cài đặt](/slides/vi/nodejs-net/installation/). Bất kỳ bài thuyết trình PowerPoint nào cũng được. Lưu mỗi ví dụ dưới dạng tệp `.js` trong thư mục dự án và chạy nó từ thư mục đó bằng `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET không có tài liệu tham khảo API riêng. Nó phản chiếu API của Aspose.Slides for .NET với các tên camelCase, vì vậy các liên kết API trong bài viết này dẫn tới các lớp và thành viên tương ứng trong [tham khảo API Aspose.Slides for .NET](https://reference.aspose.com/slides/vi/net/).
{{% /alert %}}

## **Mở một Bài Thuyết Trình Từ Tệp**

Để mở một bài thuyết trình, truyền đường dẫn của nó vào constructor [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/presentation/). Aspose.Slides xác định định dạng dựa trên nội dung tệp chứ không phải dựa vào phần mở rộng, vì vậy cùng một đoạn mã có thể mở các tệp PPTX, PPT và ODP. Đường dẫn tương đối được giải quyết dựa trên thư mục làm việc hiện tại, tức là thư mục dự án khi bạn chạy script từ đó.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Script in ra số slide trong `sample.pptx`, ví dụ `Slide count: 9`. Thuộc tính `count` của bộ sưu tập [slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/) bao gồm cả các slide ẩn. Gọi `dispose` trong một khối `finally`, như trong ví dụ, để giải phóng các tài nguyên .NET phía sau bài thuyết trình ngay cả khi mã của bạn gặp lỗi.

## **Mở một Bài Thuyết Trình Từ Buffer**

Khi một bài thuyết trình đến từ cơ sở dữ liệu, tải lên HTTP, hoặc nguồn nào đó cung cấp dữ liệu dạng byte thay vì đường dẫn tệp, truyền một `Buffer` của Node.js làm đối số thứ hai của constructor và `null` làm đối số thứ nhất. Ví dụ sau đọc `sample.pptx` vào một buffer để mô phỏng nguồn này:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Script in ra cùng số slide như ví dụ trước. Đối số thứ hai phải là một `Buffer`. Đối với bất kỳ kiểu nào khác, chẳng hạn `Uint8Array`, constructor không báo lỗi; nó sẽ tạo một bài thuyết trình mới chỉ có một slide trống. Đầu tiên chuyển các kiểu nhị phân khác sang `Buffer` bằng `Buffer.from`.

## **Lưu một Bài Thuyết Trình Sang Định Dạng Khác**

Để chuyển đổi một bài thuyết trình sang định dạng khác, mở nó và lưu với một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) khác. Ví dụ dưới đây in ra định dạng mà Aspose.Slides đã phát hiện (thuộc tính [sourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sourceformat/)) và lưu bài thuyết trình dưới dạng OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Script in `Source format: Pptx` và tạo `sample.odp`, chứa các slide giống nhau. `sourceFormat` trả về `Ppt`, `Pptx` hoặc `Odp`. Để lưu dưới dạng PDF hoặc dưới dạng hình ảnh, xem [Chuyển đổi PowerPoint sang PDF](/slides/vi/nodejs-net/convert-powerpoint-to-pdf/) và [Chuyển đổi Slides sang Hình ảnh](/slides/vi/nodejs-net/convert-slide/).

## **Câu hỏi thường gặp**

**Làm thế nào để mở một bài thuyết trình được bảo vệ bằng mật khẩu?**

Tạo một đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/), đặt thuộc tính [password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/) của nó, và truyền đối tượng này làm đối số thứ ba của constructor: `new Presentation("protected.pptx", null, loadOptions)`. Nếu không có mật khẩu đúng, constructor sẽ ném lỗi.

**Tại sao constructor ném `Error` mà không có thông báo?**

Khi constructor `Presentation` thất bại trong .NET, ví dụ vì tệp không tồn tại, không phải là bài thuyết trình, hoặc cần mật khẩu khác, JavaScript nhận được một `Error` có thông điệp rỗng. Trước khi mở tệp, hãy kiểm tra xem nó có tồn tại so với thư mục làm việc hay không, ví dụ bằng `fs.existsSync`.

**Tôi có thể mở những định dạng nào?**

Các định dạng bài thuyết trình PowerPoint và OpenDocument, bao gồm PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP và FODP.