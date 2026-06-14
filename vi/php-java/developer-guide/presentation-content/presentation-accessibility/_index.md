---
title: Quản lý khả năng truy cập bản trình chiếu trong PHP
linktitle: Khả năng truy cập bản trình chiếu
type: docs
weight: 30
url: /vi/php-java/presentation-accessibility/
keywords:
- khả năng truy cập bản trình chiếu
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Khám phá cách Aspose.Slides giúp tự động kiểm tra khả năng truy cập bản trình chiếu trong các tệp PPT, PPTX và ODP — nâng cao trải nghiệm trình đọc màn hình và tăng cường tuân thủ."
---
## **Tổng quan**

Khả năng truy cập trong trình chiếu đảm bảo rằng những người sử dụng công nghệ hỗ trợ — chẳng hạn như trình đọc màn hình, màn hình chữ nổi hoặc điều hướng chỉ bằng bàn phím — có thể hiểu và di chuyển qua các slide của bạn hiệu quả như khán giả nhìn thấy và sử dụng chuột. Thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho các hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền tải ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng truy cập được lên kế hoạch từ đầu, kết quả là cấu trúc sạch hơn, hình ảnh nhất quán hơn và nội dung tiếp cận mọi người xem mà không cần các giải pháp tạm thời.

## **Đánh dấu là trang trí**

Đánh dấu là trang trí gắn cờ cho các hình ảnh chỉ mang tính trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm nhiễu và giữ tiêu điểm vào nội dung có ý nghĩa. Áp dụng nó cho nền, họa tiết và khoảng trống — không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền tải thông tin. Aspose.Slides cung cấp cờ này để phát hiện và kiểm tra, cho phép thực hiện kiểm tra khả năng truy cập tự động và làm sạch.

![Đánh dấu là trang trí](mark_as_decorative.png)

Mẫu mã sau đây cho thấy cách xác định xem một hình dạng có được đánh dấu là trang trí hay không.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```