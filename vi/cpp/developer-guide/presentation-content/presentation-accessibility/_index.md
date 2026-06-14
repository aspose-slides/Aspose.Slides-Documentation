---
title: Quản lý Khả năng Truy cập Bài thuyết trình trong C++
linktitle: Khả năng Truy cập Bài thuyết trình
type: docs
weight: 30
url: /vi/cpp/presentation-accessibility/
keywords:
- khả năng truy cập bài thuyết trình
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho C++ giúp tự động kiểm tra khả năng truy cập bài thuyết trình trong các tệp PPT, PPTX và ODP—nâng cao trải nghiệm trình đọc màn hình và tăng cường tuân thủ."
---
## **Tổng quan**

Khả năng truy cập cho bài thuyết trình đảm bảo rằng người dùng công nghệ hỗ trợ—như trình đọc màn hình, màn hình chữ nổi hoặc điều hướng chỉ bằng bàn phím—có thể hiểu và di chuyển trong các slide của bạn một cách hiệu quả như khán giả nhìn thấy và sử dụng chuột. Thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền tải ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng truy cập được lên kế hoạch từ đầu, kết quả là cấu trúc sạch sẽ hơn, hình ảnh nhất quán hơn và nội dung tiếp cận mọi người xem mà không cần các biện pháp khắc phục.

## **Đánh dấu là trang trí**

Cờ "Mark as decorative" đánh dấu các hình ảnh chỉ mang tính trang trí để trình đọc màn hình bỏ qua chúng, giảm nhiễu và giữ tập trung vào nội dung quan trọng. Áp dụng cho nền, họa tiết và các khoảng trống—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền đạt thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra khả năng truy cập tự động và dọn dẹp.

![Mark as Decorative](mark_as_decorative.png)

Mẫu mã bên dưới cho thấy cách xác định liệu một hình dạng có được đánh dấu là trang trí hay không.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```