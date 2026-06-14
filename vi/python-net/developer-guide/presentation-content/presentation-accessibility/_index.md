---
title: Quản lý khả năng truy cập bản trình chiếu trong Python
linktitle: Truy cập bản trình chiếu
type: docs
weight: 30
url: /vi/python-net/presentation-accessibility/
keywords:
- khả năng truy cập bản trình chiếu
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Python giúp tự động hoá việc kiểm tra khả năng truy cập bản trình chiếu trong các tệp PPT, PPTX và ODP—cải thiện trải nghiệm của trình đọc màn hình và tăng cường tuân thủ."
---
## **Giới thiệu**

Khả năng truy cập cho các bài thuyết trình đảm bảo rằng những người sử dụng công nghệ hỗ trợ—như trình đọc màn hình, màn hình chữ nổi, hoặc điều hướng chỉ bằng bàn phím—có thể hiểu và di chuyển qua các slide của bạn một cách hiệu quả như những khán giả có thị lực và dùng chuột. Thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho các hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền tải ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng truy cập được lên kế hoạch từ đầu, kết quả là cấu trúc sạch sẽ hơn, hình ảnh nhất quán hơn, và nội dung tiếp cận được mọi người xem mà không cần các biện pháp vòng vo.

## **Đánh dấu là trang trí**

Đánh dấu là trang trí gắn cờ cho các hình ảnh chỉ để trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm tiếng ồn và giữ tập trung vào nội dung có ý nghĩa. Áp dụng nó cho nền, họa tiết trang trí và các phần tử khoảng trống—không bao giờ dùng cho biểu đồ, biểu tượng, hoặc hình ảnh truyền tải thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra khả năng truy cập tự động và dọn dẹp.

![Mark as Decorative](mark_as_decorative.png)

Mẫu mã nguồn dưới đây cho thấy cách xác định một hình dạng có được đánh dấu là trang trí hay không.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```