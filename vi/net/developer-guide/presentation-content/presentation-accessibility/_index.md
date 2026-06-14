---
title: Quản lý khả năng truy cập bài thuyết trình trong .NET
linktitle: Truy cập bài thuyết trình
type: docs
weight: 30
url: /vi/net/presentation-accessibility/
keywords:
- khả năng truy cập bài thuyết trình
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tự động kiểm tra khả năng truy cập bài thuyết trình trong các tệp PPT, PPTX và ODP với Aspose.Slides cho .NET—nâng cao trải nghiệm của trình đọc màn hình và tăng cường tuân thủ."
---
## **Giới thiệu**

Khả năng truy cập vào bài thuyết trình đảm bảo rằng những người sử dụng công nghệ hỗ trợ — chẳng hạn như trình đọc màn hình, màn hình nổi Braille hoặc điều hướng chỉ bằng bàn phím — có thể hiểu và di chuyển qua các slide của bạn hiệu quả như những khán giả có thị lực và sử dụng chuột. Thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho các hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền tải ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng truy cập được lập kế hoạch từ đầu, kết quả là cấu trúc sạch sẽ hơn, hình ảnh nhất quán hơn và nội dung tiếp cận mọi người xem mà không cần các giải pháp tạm thời.

## **Đánh dấu là Trang trí**

Đánh dấu là trang trí gắn cờ cho các hình ảnh chỉ mang tính trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm nhiễu và giữ trọng tâm vào nội dung có ý nghĩa. Áp dụng nó cho nền, hoa văn và khoảng cách—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền tải thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra khả năng truy cập tự động và dọn dẹp.

![Đánh dấu là Trang trí](mark_as_decorative.png)

Mẫu mã sau đây cho thấy cách xác định liệu một hình dạng có được đánh dấu là trang trí hay không.

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```