---
title: Quản lý khả năng truy cập bài thuyết trình trên Android
linktitle: Khả năng truy cập bài thuyết trình
type: docs
weight: 30
url: /vi/androidjava/presentation-accessibility/
keywords:
- khả năng truy cập bài thuyết trình
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Android qua Java giúp tự động hoá việc kiểm tra khả năng truy cập bài thuyết trình trong các tệp PPT, PPTX và ODP—nâng cao trải nghiệm đọc màn hình và tăng cường tuân thủ."
---
## **Tổng quan**

Khả năng truy cập bài thuyết trình đảm bảo rằng những người sử dụng công nghệ hỗ trợ—như trình đọc màn hình, màn hình chữ nổi hoặc điều hướng chỉ bằng bàn phím—có thể hiểu và điều hướng các slide của bạn hiệu quả như khán giả có thị lực và sử dụng chuột. Các thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho các hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền tải ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng truy cập được lên kế hoạch từ đầu, kết quả là cấu trúc sạch sẽ hơn, hình ảnh đồng nhất hơn và nội dung tiếp cận mọi người xem mà không cần các giải pháp tạm thời.

## **Đánh dấu là Trang trí**

Đánh dấu là trang trí gắn cờ cho các hình ảnh chỉ trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm nhiễu và giữ sự tập trung vào nội dung có ý nghĩa. Áp dụng nó cho nền, các họa tiết và khoảng trống—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền tải thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra khả năng truy cập tự động và dọn dẹp.

![Đánh dấu là Trang trí](mark_as_decorative.png)

The following code sample shows how to determine whether a shape is marked as decorative.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```