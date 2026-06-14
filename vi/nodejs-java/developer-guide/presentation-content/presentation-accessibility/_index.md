---
title: Quản lý khả năng tiếp cận trong bản trình chiếu bằng JavaScript
linktitle: Khả năng tiếp cận trong bản trình chiếu
type: docs
weight: 30
url: /vi/nodejs-java/presentation-accessibility/
keywords:
- khả năng tiếp cận trong bản trình chiếu
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tự động kiểm tra khả năng tiếp cận trong các tệp PPT, PPTX và ODP với Aspose.Slides cho Node.js — cải thiện trải nghiệm trình đọc màn hình và tăng cường tuân thủ."
---
## **Tổng quan**

Khả năng tiếp cận trong bản trình chiếu đảm bảo rằng những người sử dụng công nghệ hỗ trợ—chẳng hạn như trình đọc màn hình, thiết bị hiển thị chữ nổi hoặc điều hướng chỉ bằng bàn phím—có thể hiểu và di chuyển qua các slide của bạn một cách hiệu quả như người dùng có mắt và chuột. Thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho các hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền đạt ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng tiếp cận được lên kế hoạch từ đầu, kết quả là cấu trúc sạch sẽ hơn, hình ảnh nhất quán hơn và nội dung tiếp cận được mọi người xem mà không cần các giải pháp tạm thời.

## **Đánh dấu là trang trí**

Đánh dấu là trang trí đánh dấu các hình ảnh chỉ mang tính trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm nhiễu và giữ sự tập trung vào nội dung có ý nghĩa. Áp dụng nó cho nền, họa tiết và khoảng trống—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền đạt thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra khả năng tiếp cận tự động và dọn dẹp.

![Đánh dấu là trang trí](mark_as_decorative.png)

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```