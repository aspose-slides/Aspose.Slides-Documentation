---
title: Tạo các bài thuyết trình bằng JavaScript
linktitle: Tạo bài thuyết trình
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
description: "Tạo các bài thuyết trình với Aspose.Slides—tạo tệp PPT, PPTX và ODP, tận dụng hỗ trợ OpenDocument, và lưu chúng bằng chương trình để có kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bài thuyết trình trong Aspose.Slides, thêm nội dung đơn giản vào một slide, và lưu kết quả dưới dạng tệp.

## **Tạo bài thuyết trình PowerPoint**

Để thêm một đường thẳng đơn giản vào slide đã chọn của bài thuyết trình, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp Presentation.
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục Index của nó.
1. Thêm một AutoShape loại Line bằng phương thức addAutoShape được cung cấp bởi đối tượng Shapes.
1. Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bài thuyết trình.

```javascript
// Tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm một autoshape loại line
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể lưu bài thuyết trình mới ở những định dạng nào?**

Bạn có thể lưu dưới dạng [PPTX, PPT và ODP](/slides/vi/nodejs-java/save-presentation/), và xuất ra [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/vi/nodejs-java/convert-powerpoint-to-png/), và [hình ảnh](/slides/vi/nodejs-java/convert-powerpoint-to-png/), trong số các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu dưới định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/nodejs-java/supported-file-formats/).

**Làm thế nào để kiểm soát kích thước/ tỷ lệ khung hình của slide khi tạo bài thuyết trình?**

Đặt [kích thước slide](/slides/vi/nodejs-java/slide-size/) (bao gồm các preset như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được co giãn.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Bằng điểm: 1 inch bằng 72 đơn vị.

**Làm sao để xử lý các bài thuyết trình rất lớn (có nhiều tệp media) nhằm giảm việc sử dụng bộ nhớ?**

Sử dụng [chiến lược quản lý BLOB](/slides/vi/nodejs-java/manage-blob/), hạn chế lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp thay vì các luồng chỉ trong bộ nhớ.

**Tôi có thể tạo/lưu các bài thuyết trình song song không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/nodejs-java/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc quá trình.

**Làm thế nào để loại bỏ watermark thử nghiệm và các hạn chế?**

[Áp dụng giấy phép](/slides/vi/nodejs-java/licensing/) một lần cho mỗi tiến trình. Tệp XML của giấy phép phải không bị thay đổi, và việc cài đặt giấy phép nên được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX tôi tạo không?**

Có. [Chữ ký kỹ thuật số](/slides/vi/nodejs-java/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bài thuyết trình.

**Các macro (VBA) có được hỗ trợ trong các bài thuyết trình được tạo không?**

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/nodejs-java/presentation-via-vba/) và lưu các tệp có hỗ trợ macro như PPTM/PPSM.