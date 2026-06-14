---
title: Tạo bản trình chiếu trong PHP
linktitle: Tạo bản trình chiếu
type: docs
weight: 10
url: /vi/php-java/create-presentation/
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
- PHP
- Aspose.Slides
description: "Tạo bản trình chiếu với Aspose.Slides cho PHP qua Java — tạo các tệp PPT, PPTX và ODP và lưu chúng một cách có chương trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này chỉ cách tạo bản trình chiếu trong Aspose.Slides, thêm nội dung đơn giản vào một slide và lưu kết quả dưới dạng tệp. Ngoài ra, nó còn trình bày cách tạo và lưu một bản trình chiếu mới, mở một bản trình chiếu hiện có ở định dạng được hỗ trợ và lưu nó sang định dạng khác. Bài viết cũng bao gồm một phần FAQ ngắn, trả lời các câu hỏi thường gặp về định dạng, mẫu, kích thước slide, đơn vị đo, sử dụng bộ nhớ, đa luồng, giấy phép, chữ ký số và hỗ trợ VBA.

## **Tạo bản trình chiếu**

Để thêm một đường thẳng đơn giản vào một slide đã chọn trong bản trình chiếu, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp Presentation.
1. Lấy tham chiếu của slide bằng cách sử dụng chỉ mục (Index) của nó.
1. Thêm một AutoShape kiểu Đường thẳng bằng phương thức addAutoShape được cung cấp bởi đối tượng Shapes.
1. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường thẳng vào slide đầu tiên của bản trình chiếu.

```php
  # Tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Thêm một autoshape kiểu đường thẳng
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Các định dạng nào tôi có thể lưu bản trình chiếu mới?**

Bạn có thể lưu thành [PPTX, PPT, và ODP](/slides/vi/php-java/save-presentation/), và xuất sang [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/php-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), [SVG](/slides/vi/php-java/convert-powerpoint-to-png/), và [hình ảnh](/slides/vi/php-java/convert-powerpoint-to-png/), trong số các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu thành PPTX thông thường được không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/php-java/supported-file-formats/).

**Làm thế nào để tôi kiểm soát kích thước/tỷ lệ khung hình của slide khi tạo bản trình chiếu?**

Đặt [kích thước slide](/slides/vi/php-java/slide-size/) (bao gồm các cài đặt trước như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được thu phóng.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Tính bằng điểm: 1 inch tương đương 72 đơn vị.

**Làm sao để xử lý các bản trình chiếu rất lớn (với nhiều tệp media) nhằm giảm sử dụng bộ nhớ?**

Sử dụng [chiến lược quản lý BLOB](/slides/vi/php-java/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng tệp tạm, và ưu tiên quy trình làm việc dựa trên tệp thay vì các luồng chỉ trong bộ nhớ.

**Tôi có thể tạo/lưu các bản trình chiếu song song không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/php-java/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

**Làm thế nào để loại bỏ dấu watermar ký thử và các hạn chế?**

[Áp dụng giấy phép](/slides/vi/php-java/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị sửa đổi, và việc thiết lập giấy phép nên được đồng bộ hóa nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX mà tôi tạo không?**

Có. [Chữ ký số](/slides/vi/php-java/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bản trình chiếu.

**Macro (VBA) có được hỗ trợ trong các bản trình chiếu được tạo không?**

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/php-java/presentation-via-vba/) và lưu các tệp có macro như PPTM/PPSM.