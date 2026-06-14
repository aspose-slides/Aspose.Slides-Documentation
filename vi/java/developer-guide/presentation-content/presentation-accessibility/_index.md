---
title: Quản lý khả năng truy cập bài thuyết trình trong Java
linktitle: Khả năng truy cập bài thuyết trình
type: docs
weight: 30
url: /vi/java/presentation-accessibility/
keywords:
- khả năng truy cập bài thuyết trình
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Java giúp tự động kiểm tra khả năng truy cập bài thuyết trình trong các tệp PPT, PPTX và ODP — cải thiện trải nghiệm trình đọc màn hình và tăng cường tuân thủ."
---
## **Giới thiệu**

Khả năng truy cập cho bài thuyết trình đảm bảo rằng những người sử dụng công nghệ hỗ trợ—như trình đọc màn hình, màn hình chữ nổi hoặc điều hướng chỉ bằng bàn phím—có thể hiểu và di chuyển qua các slide của bạn một cách hiệu quả như người xem có thị lực và sử dụng chuột. Thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền tải ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng truy cập được lên kế hoạch từ đầu, kết quả là cấu trúc sạch hơn, hình ảnh nhất quán hơn và nội dung tiếp cận mọi người xem mà không cần giải pháp tạm thời.

## **Đánh dấu là trang trí**

Đánh dấu là trang trí đánh dấu các hình ảnh chỉ mang tính trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm tiếng ồn và giữ tập trung vào nội dung có ý nghĩa. Áp dụng nó cho nền, họa tiết và khoảng cách—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền đạt thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra khả năng truy cập tự động và dọn dẹp.

![Đánh dấu là trang trí](mark_as_decorative.png)

Mẫu code sau đây cho thấy cách xác định xem một hình dạng có được đánh dấu là trang trí hay không.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```