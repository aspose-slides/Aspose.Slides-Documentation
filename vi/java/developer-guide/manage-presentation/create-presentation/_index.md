---
title: Tạo Bản Trình Chiếu trong Java
linktitle: Tạo Bản Trình Chiếu
type: docs
weight: 10
url: /vi/java/create-presentation/
keywords:
- tạo bản trình chiếu
- bản trình chiếu mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo bản trình chiếu trong Java bằng Aspose.Slides—tạo các tệp PPT, PPTX và ODP, tận dụng hỗ trợ OpenDocument, và lưu chúng bằng chương trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này mô tả cách tạo một bản trình chiếu trong Aspose.Slides, thêm nội dung đơn giản vào một slide, và lưu kết quả thành tệp. Nó cũng trình bày cách tạo và lưu một bản trình chiếu mới, mở một bản trình chiếu hiện có ở định dạng được hỗ trợ, và lưu nó sang định dạng khác. Ngoài ra, bài viết còn bao gồm một phần Câu hỏi thường gặp ngắn gọn về các câu hỏi phổ biến liên quan đến định dạng, mẫu, kích thước slide, đơn vị, sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số, và hỗ trợ VBA.

## **Tạo một bản trình chiếu**

Việc tạo tệp PowerPoint từ đầu trong Aspose.Slides for Java đơn giản như khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) . Bộ khởi tạo tự động cung cấp một bộ slide trống với một slide duy nhất, cho bạn ngay một canvas để đặt các hình dạng, văn bản, biểu đồ hoặc bất kỳ nội dung nào mà ứng dụng của bạn cần. Khi bạn sửa đổi slide đó — hoặc thêm slide mới — bạn có thể lưu kết quả dưới dạng PPTX, PPT truyền thống, hoặc thậm chí các định dạng OpenDocument. Đoạn mã mẫu ngắn dưới đây minh họa quy trình này bằng cách thêm một hình dạng đơn giản vào slide đầu tiên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
1. Thêm một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) loại `Cloud` bằng phương thức `addAutoShape` được cung cấp bởi bộ sưu tập `Shapes`.
1. Thêm văn bản vào auto-shape.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, một hình dạng đám mây được thêm vào slide đầu tiên của bản trình chiếu.

```java
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto-shape loại Cloud.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Bản trình chiếu mới](new_presentation.png)

## **Câu hỏi thường gặp**

**Tôi có thể lưu bản trình chiếu mới sang định dạng nào?**

Bạn có thể lưu sang [PPTX, PPT, và ODP](/slides/vi/java/save-presentation/), và xuất sang [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/java/convert-powerpoint-to-xps/), [HTML](/slides/vi/java/convert-powerpoint-to-html/), [SVG](/slides/vi/java/convert-powerpoint-to-png/), và [images](/slides/vi/java/convert-powerpoint-to-png/), trong số các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và tương tự [được hỗ trợ](/slides/vi/java/supported-file-formats/).

**Làm sao tôi kiểm soát kích thước/tỷ lệ khung hình của slide khi tạo bản trình chiếu?**

Đặt [kích thước slide](/slides/vi/java/slide-size/) (bao gồm các thiết lập sẵn như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung được co giãn.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Theo điểm: 1 inch bằng 72 đơn vị.

**Làm sao tôi xử lý các bản trình chiếu rất lớn (có nhiều tệp media) để giảm việc sử dụng bộ nhớ?**

Sử dụng [BLOB management strategies](/slides/vi/java/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng tệp tạm, và ưu tiên quy trình làm việc dựa trên tệp hơn là luồng hoàn toàn trong bộ nhớ.

**Tôi có thể tạo/lưu bản trình chiếu song song không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation] từ [multiple threads](/slides/vi/java/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

**Làm sao tôi gỡ bỏ watermark dùng thử và các hạn chế?**

[Áp dụng giấy phép](/slides/vi/java/licensing/) một lần cho mỗi tiến trình. Tệp XML cấp phép phải không bị sửa đổi, và việc thiết lập giấy phép nên được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX mà tôi tạo không?**

Có. [Digital signatures](/slides/vi/java/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bản trình chiếu.

**Các macro (VBA) có được hỗ trợ trong các bản trình chiếu được tạo không?**

Có. Bạn có thể [create/edit VBA projects](/slides/vi/java/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.