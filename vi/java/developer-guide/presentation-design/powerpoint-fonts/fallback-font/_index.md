---
title: Quản lý phông chữ dự phòng cho bản trình chiếu trong Java
linktitle: Phông chữ dự phòng
type: docs
weight: 50
url: /vi/java/fallback-font/
keywords:
- phông chữ dự phòng
- phông chữ khả dụng
- thay thế glyph
- chỉ định phông chữ
- chỉ định quy tắc
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem cách Aspose.Slides cho Java sử dụng phông chữ dự phòng để giữ cho văn bản có thể đọc được trong các bản trình chiếu PowerPoint và OpenDocument khi các phông chữ gốc không khả dụng."
---
## **Giới thiệu**

Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống nhưng không chứa ký tự glyph cần thiết. Trong trường hợp này, Aspose.Slides có thể sử dụng một trong các phông chữ dự phòng đã chỉ định để thay thế ký tự glyph bị thiếu.

## **Phông chữ dự phòng**

Aspose.Slides cho phép tạo phông chữ dự phòng, thêm chúng vào bộ sưu tập phông chữ dự phòng, đặt bộ sưu tập phông chữ dự phòng cho một bản trình chiếu cụ thể, xóa phông chữ dự phòng khỏi bản trình chiếu, chỉ định các quy tắc để áp dụng phông chữ dự phòng và các tính năng khác.

Để làm quen với các tính năng này, hãy sử dụng các liên kết sau:

- [Tạo phông chữ dự phòng](/slides/vi/java/create-fallback-font)
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/java/create-fallback-fonts-collection)
- [Kết xuất bản trình chiếu với phông chữ dự phòng](/slides/vi/java/render-presentation-with-fallback-font)

## **Câu hỏi thường gặp**

**Phông chữ dự phòng khác với việc thay thế phông chữ như thế nào?**

Phông chữ dự phòng được áp dụng trên mỗi ký tự hoặc mỗi phạm vi Unicode khi phông chữ chính thiếu các glyph cụ thể; nó chỉ thay thế các ký tự bị thiếu. [Thay thế](/slides/vi/java/font-substitution/) thay thế phông chữ bị mất hoặc không khả dụng cho toàn bộ đoạn văn hoặc phần văn bản bằng một phông chữ khác. Chúng có thể được kết hợp, nhưng phạm vi và logic lựa chọn của chúng là khác nhau.

**Cài đặt dự phòng có được lưu trong tệp bản trình chiếu không?**

Không. Cấu hình dự phòng tồn tại trong thời gian xử lý/kết xuất trong thư viện và không được ghi vào tệp PPTX. Bản trình chiếu không lưu các quy tắc dự phòng của bạn.

**Phông chữ dự phòng có ảnh hưởng đến các yếu tố được tạo bởi các đối tượng PowerPoint (SmartArt, biểu đồ, WordArt) không?**

Có. Văn bản trong những đối tượng này đi qua cùng một quy trình kết xuất, do đó các quy tắc dự phòng giống nhau được áp dụng cho nó như với văn bản thường.