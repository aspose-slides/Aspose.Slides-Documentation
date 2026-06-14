---
title: Quản lý phông chữ dự phòng cho bản trình chiếu trong Python
linktitle: Phông chữ dự phòng
type: docs
weight: 50
url: /vi/python-net/fallback-font/
keywords:
- phông chữ dự phòng
- phông chữ khả dụng
- thay thế glyph
- chỉ định phông chữ
- chỉ định quy tắc
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Xem cách Aspose.Slides for Python via .NET sử dụng phông chữ dự phòng để giữ cho văn bản có thể đọc được trong các bản trình chiếu PowerPoint và OpenDocument khi các phông chữ gốc không khả dụng."
---
## **Giới thiệu**

Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống nhưng không chứa ký tự glyph cần thiết. Trong trường hợp này, Aspose.Slides có thể sử dụng một trong các phông chữ dự phòng đã chỉ định để thay thế ký tự glyph bị thiếu.

## **Phông chữ dự phòng**

Aspose.Slides cho phép tạo phông chữ dự phòng, thêm chúng vào bộ sưu tập phông chữ dự phòng, thiết lập bộ sưu tập phông chữ dự phòng cho một bản trình chiếu nhất định, xóa phông chữ dự phòng khỏi bản trình chiếu, chỉ định các quy tắc để áp dụng phông chữ dự phòng và các tính năng khác.

Để làm quen với các tính năng này, hãy sử dụng các liên kết sau:

- [Tạo phông chữ dự phòng](/slides/vi/python-net/create-fallback-font)
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/python-net/create-fallback-fonts-collection)
- [Kết xuất bản trình chiếu với phông chữ dự phòng](/slides/vi/python-net/render-presentation-with-fallback-font)

## **Câu hỏi thường gặp**

**Phông chữ dự phòng khác gì so với việc thay thế phông chữ?**

Phông chữ dự phòng được áp dụng cho từng ký tự hoặc cho một phạm vi Unicode khi phông chữ chính thiếu các glyph cụ thể; nó chỉ điền các ký tự còn thiếu. [Thay thế](/slides/vi/python-net/font-substitution/) thay thế phông chữ bị mất hoặc không khả dụng cho toàn bộ đoạn hoặc phần văn bản bằng một phông chữ khác. Chúng có thể được kết hợp, nhưng phạm vi và logic lựa chọn của chúng là khác nhau.

**Cài đặt dự phòng có được lưu trong tệp bản trình chiếu không?**

Không. Cấu hình dự phòng tồn tại trong quá trình xử lý/khửu dựng trong thư viện và không được tuần tự hoá vào file PPTX. Bản trình chiếu không lưu các quy tắc dự phòng của bạn.

**Phông chữ dự phòng có ảnh hưởng đến các thành phần được tạo bởi các đối tượng PowerPoint (SmartArt, biểu đồ, WordArt) không?**

Có. Văn bản bên trong các đối tượng này đi qua cùng một quy trình kết xuất, vì vậy các quy tắc dự phòng giống nhau áp dụng cho chúng như đối với văn bản thông thường.