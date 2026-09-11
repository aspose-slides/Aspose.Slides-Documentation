---
title: Quản lý khả năng truy cập bài trình chiếu trong Python thông qua Java
linktitle: Khả năng truy cập bài trình chiếu
type: docs
weight: 30
url: /vi/python-java/presentation-accessibility/
keywords:
- khả năng truy cập bài trình chiếu
- đánh dấu là trang trí
- PowerPoint
- OpenDocument
- bài trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Python thông qua Java giúp tự động hoá kiểm tra khả năng truy cập bài trình chiếu trong các tệp PPT, PPTX và ODP—nâng cao trải nghiệm trình đọc màn hình và tăng cường tuân thủ."
---
## **Introduction**

Khả năng truy cập trong bài thuyết trình đảm bảo rằng những người sử dụng công nghệ hỗ trợ—như trình đọc màn hình, bộ hiển thị chữ nổi, hoặc điều hướng chỉ bằng bàn phím—có thể hiểu và di chuyển qua các slide của bạn hiệu quả như những người xem có thị lực và sử dụng chuột. Thực hành tốt tập trung vào thứ tự đọc rõ ràng, văn bản thay thế có ý nghĩa cho các hình ảnh thông tin, độ tương phản màu đủ, kiểu chữ dễ đọc, văn bản liên kết mô tả, và tránh truyền tải ý nghĩa chỉ bằng màu sắc hoặc vị trí. Khi khả năng truy cập được lên kế hoạch từ đầu, kết quả là cấu trúc sạch hơn, hình ảnh nhất quán hơn, và nội dung tiếp cận mọi người xem mà không cần các giải pháp tạm thời.

## **Mark as Decorative**

Đánh dấu là trang trí gắn cờ cho các hình ảnh chỉ mang tính trang trí thuần túy để trình đọc màn hình bỏ qua chúng, giảm tiếng ồn và giữ tập trung vào nội dung có ý nghĩa. Áp dụng nó cho nền, hoa văn và khoảng trống—không bao giờ cho biểu đồ, biểu tượng hoặc hình ảnh truyền tải thông tin. Aspose.Slides cung cấp cờ này để phát hiện và xác thực, cho phép kiểm tra khả năng truy cập tự động và làm sạch.

![Đánh dấu là trang trí](mark_as_decorative.png)

The following code sample shows how to determine whether a shape is marked as decorative.

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```