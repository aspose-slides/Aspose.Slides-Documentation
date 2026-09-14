---
title: Quản lý phông chữ dự phòng cho bản trình bày trong Python qua Java
linktitle: Phông chữ dự phòng
type: docs
weight: 50
url: /vi/python-java/fallback-font/
keywords:
- phông chữ dự phòng
- phông chữ khả dụng
- thay thế glyph
- chỉ định phông chữ
- chỉ định quy tắc
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Xem cách Aspose.Slides cho Python qua Java sử dụng phông chữ dự phòng để giữ cho văn bản có thể đọc được trong các bản trình bày PowerPoint và OpenDocument khi phông chữ gốc không khả dụng."
---
## **Giới thiệu**

Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống nhưng không chứa ký tự glyph yêu cầu. Trong trường hợp này, Aspose.Slides có thể sử dụng một trong các phông chữ dự phòng được chỉ định để thay thế glyph bị thiếu.

## **Phông chữ dự phòng**

Aspose.Slides cho phép bạn tạo phông chữ dự phòng, thêm chúng vào bộ sưu tập phông chữ dự phòng, đặt bộ sưu tập phông chữ dự phòng cho một bản trình bày cụ thể, xóa phông chữ dự phòng khỏi bản trình bày, chỉ định các quy tắc áp dụng phông chữ dự phòng và thực hiện các thao tác liên quan khác.

Để làm quen với các tính năng này, hãy sử dụng các liên kết sau:

- [Tạo phông chữ dự phòng](/slides/vi/python-java/create-fallback-font/)
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/python-java/create-fallback-fonts-collection/)
- [Kết xuất bản trình bày với phông chữ dự phòng](/slides/vi/python-java/render-presentation-with-fallback-font/)

## **Câu hỏi thường gặp**

**Phông chữ dự phòng khác với việc thay thế phông chữ như thế nào?**

Phông chữ dự phòng được áp dụng cho mỗi ký tự hoặc mỗi phạm vi Unicode khi phông chữ chính thiếu các glyph cụ thể; nó chỉ thay thế các ký tự còn thiếu. [Thay thế](/slides/vi/python-java/font-substitution/) thay thế một phông chữ bị thiếu hoặc không khả dụng cho toàn bộ đoạn hoặc phần văn bản bằng một phông chữ khác. Chúng có thể được kết hợp, nhưng phạm vi và logic lựa chọn của chúng khác nhau.

**Cài đặt dự phòng có được lưu trong tệp bản trình bày không?**

Không. Cấu hình dự phòng tồn tại trong thời gian xử lý/kết xuất trong thư viện và không được ghi vào file PPTX. Bản trình bày không lưu các quy tắc dự phòng của bạn.

**Phông chữ dự phòng có ảnh hưởng đến các yếu tố được tạo bởi các đối tượng PowerPoint (SmartArt, biểu đồ, WordArt) không?**

Có. Văn bản bên trong các đối tượng này đi qua cùng quy trình kết xuất, vì vậy các quy tắc dự phòng giống nhau được áp dụng cho chúng như với văn bản thông thường.