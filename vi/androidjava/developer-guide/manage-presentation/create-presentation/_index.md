---
title: Tạo Bài Thuyết Trình trên Android
linktitle: Tạo Bài Thuyết Trình
type: docs
weight: 10
url: /vi/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Tạo bài thuyết trình trong Java với Aspose.Slides cho Android—tạo tệp PPT, PPTX và ODP, tận dụng hỗ trợ OpenDocument và lưu chúng một cách lập trình để có kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này cho thấy cách tạo một bài thuyết trình trong Aspose.Slides, thêm nội dung đơn giản vào một slide và lưu kết quả dưới dạng tệp. Nó cũng minh họa cách tạo và lưu một bài thuyết trình mới, mở một bài thuyết trình hiện có ở định dạng được hỗ trợ và lưu nó sang định dạng khác.

## **Tạo bài thuyết trình PowerPoint**
Để thêm một đường thẳng đơn giản vào slide đã chọn của bài thuyết trình, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp Presentation.
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục (Index) của nó.
3. Thêm một AutoShape kiểu Line bằng cách sử dụng phương thức addAutoShape được cung cấp bởi đối tượng Shapes.
4. Ghi bài thuyết trình đã sửa đổi thành tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường thẳng vào slide đầu tiên của bài thuyết trình.

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm một autoshape loại đường thẳng
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể lưu một bài thuyết trình mới ở những định dạng nào?**

Bạn có thể lưu ở định dạng [PPTX, PPT và ODP](/slides/vi/androidjava/save-presentation/), và xuất ra [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), [SVG](/slides/vi/androidjava/convert-powerpoint-to-png/), và [hình ảnh](/slides/vi/androidjava/convert-powerpoint-to-png/), trong số các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/androidjava/supported-file-formats/).

**Làm sao để kiểm soát kích thước/tỷ lệ khung hình của slide khi tạo bài thuyết trình?**

Đặt [kích thước slide](/slides/vi/androidjava/slide-size/) (bao gồm các cài đặt sẵn như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung nên được phóng đại.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Theo điểm: 1 inch tương đương 72 đơn vị.

**Làm sao để xử lý các bài thuyết trình rất lớn (có nhiều tệp media) nhằm giảm mức sử dụng bộ nhớ?**

Sử dụng [chiến lược quản lý BLOB](/slides/vi/androidjava/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp thay vì chỉ các luồng trong bộ nhớ.

**Tôi có thể tạo/lưu các bài thuyết trình một cách song song không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/androidjava/multithreading/). Hãy chạy các thể hiện riêng biệt, cách ly cho mỗi luồng hoặc quy trình.

**Làm sao để loại bỏ watermark phiên bản dùng thử và các hạn chế?**

[Áp dụng giấy phép](/slides/vi/androidjava/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị sửa đổi, và việc thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX mà tôi tạo không?**

Có. [Chữ ký số](/slides/vi/androidjava/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bài thuyết trình.

**Các macro (VBA) có được hỗ trợ trong các bài thuyết trình được tạo không?**

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/androidjava/presentation-via-vba/) và lưu các tệp có hỗ trợ macro như PPTM/PPSM.