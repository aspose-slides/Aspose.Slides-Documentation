---
title: Tạo Bài Thuyết Trình trong JavaScript
linktitle: Tạo Bài Thuyết Trình
type: docs
weight: 10
url: /vi/nodejs-java/create-presentation/
keywords:
- tạo bài thuyết trình
- bài thuyết trình mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo bài thuyết trình với Aspose.Slides—sản xuất tệp PPT, PPTX và ODP, tận hưởng hỗ trợ OpenDocument, và lưu chúng một cách lập trình để có kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bài thuyết trình trong Aspose.Slides, thêm hộp văn bản vào slide đầu tiên và lưu kết quả dưới dạng tệp.

Trước khi bắt đầu, cài đặt gói `aspose.slides.via.java` từ npm, cùng với JDK, Python và các công cụ xây dựng C++ mà nó yêu cầu. Xem [Installation](/slides/vi/nodejs-java/installation/).

## **Tạo bài thuyết trình PowerPoint**

Để tạo một bài thuyết trình và đặt một hộp văn bản trên slide đầu tiên, hãy làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Một bài thuyết trình mới đã chứa sẵn một slide trống.
2. Lấy slide đó từ [slide collection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslides/) bằng chỉ mục 0.
3. Thêm một hình chữ nhật bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/addautoshape/) và đặt văn bản cho nó bằng [setText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/settext/).
4. Lưu bài thuyết trình dưới dạng tệp PPTX bằng phương thức [save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/save/).
5. Giải phóng bài thuyết trình bằng phương thức [dispose](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/dispose/), và kết thúc quá trình.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides chạy trong một máy ảo Java giữ cho Node.js tiếp tục chạy, vì vậy hãy kết thúc tiến trình một cách rõ ràng.
process.exit(0);
```

Góc trái trên của hình chữ nhật cách cạnh trái 50 điểm và cách cạnh trên 50 điểm của slide, và hình chữ nhật rộng 400 điểm, cao 100 điểm. Lưu mã dưới dạng *hello.js* trong thư mục dự án và chạy `node hello.js`: nó sẽ lưu *hello.pptx*, chứa một slide có hình chữ nhật và văn bản của nó, trong thư mục hiện tại.

Aspose.Slides chạy trong một máy ảo Java mà gói `java` khởi động bên trong tiến trình Node.js. Máy ảo này ngăn Node.js tự thoát sau khi script kết thúc, vì vậy ví dụ kết thúc bằng `process.exit(0)`.

Nếu không có giấy phép, Aspose.Slides cũng sẽ thêm một dấu bản quyền đánh giá vào mỗi slide được lưu; xem [Licensing](/slides/vi/nodejs-java/licensing/).

## **Câu hỏi thường gặp**

### Tôi có thể lưu một bài thuyết trình mới thành những định dạng nào?

Bạn có thể lưu dưới dạng [PPTX, PPT và ODP](/slides/vi/nodejs-java/save-presentation/), và xuất sang [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/) và [hình ảnh](/slides/vi/nodejs-java/convert-powerpoint-to-png/), trong số các định dạng khác.

### Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/nodejs-java/supported-file-formats/).

### Làm sao để tôi kiểm soát kích thước/tỷ lệ khung hình của slide khi tạo một bài thuyết trình?

Đặt [slide size](/slides/vi/nodejs-java/slide-size/) (bao gồm các preset như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được thu phóng.

### Các kích thước và tọa độ được đo bằng đơn vị nào?

Bằng điểm: 1 inch tương đương 72 đơn vị.

### Làm sao để xử lý các bài thuyết trình rất lớn (có nhiều tệp phương tiện) để giảm việc sử dụng bộ nhớ?

Sử dụng [BLOB management strategies](/slides/vi/nodejs-java/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp thay vì chỉ sử dụng luồng trong bộ nhớ.

### Tôi có thể tạo/lưu các bài thuyết trình song song không?

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/nodejs-java/multithreading/). Hãy chạy các thể hiện riêng biệt, độc lập cho mỗi luồng hoặc tiến trình.

### Làm sao để xóa dấu bản quyền dùng thử và các hạn chế?

[Apply a license](/slides/vi/nodejs-java/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị sửa đổi, và việc thiết lập giấy phép nên được đồng bộ nếu có nhiều luồng tham gia.

### Tôi có thể ký số PPTX tôi tạo không?

Có. [Digital signatures](/slides/vi/nodejs-java/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bài thuyết trình.

### Các macro (VBA) có được hỗ trợ trong các bài thuyết trình được tạo không?

Có. Bạn có thể [create/edit VBA projects](/slides/vi/nodejs-java/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.