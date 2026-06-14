---
title: Quản lý phông chữ dự phòng cho bản trình chiếu trong .NET
linktitle: Phông chữ dự phòng
type: docs
weight: 50
url: /vi/net/fallback-font/
keywords:
- phông chữ dự phòng
- phông chữ có sẵn
- thay thế glyph
- chỉ định phông chữ
- chỉ định quy tắc
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem cách Aspose.Slides cho .NET sử dụng phông chữ dự phòng để giữ cho văn bản có thể đọc được trong các bản trình chiếu PowerPoint và OpenDocument khi phông chữ gốc không khả dụng."
---
## **Giới thiệu**

Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống nhưng không chứa glyph cần thiết. Trong trường hợp này, Aspose.Slides có thể sử dụng một trong các phông chữ dự phòng được chỉ định để thay thế glyph bị thiếu.

## **Phông chữ dự phòng**

Aspose.Slides cho phép tạo phông chữ dự phòng, thêm chúng vào bộ sưu tập phông chữ dự phòng, đặt bộ sưu tập phông chữ dự phòng cho một bản trình chiếu nhất định, xóa phông chữ dự phòng khỏi bản trình chiếu, chỉ định các quy tắc áp dụng phông chữ dự phòng và các tính năng khác.

Để làm quen với các tính năng này, hãy sử dụng các liên kết sau:

- [Tạo phông chữ dự phòng](/slides/vi/net/create-fallback-font)
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/net/create-fallback-fonts-collection)
- [Kết xuất bản trình chiếu với phông chữ dự phòng](/slides/vi/net/render-presentation-with-fallback-font)

## **Câu hỏi thường gặp**

**Phông chữ dự phòng khác với thay thế phông chữ như thế nào?**

Phông chữ dự phòng được áp dụng cho từng ký tự hoặc cho một dải Unicode khi phông chữ chính thiếu các glyph cụ thể; nó chỉ điền các ký tự còn thiếu. [Thay thế](/slides/vi/net/font-substitution/) thay thế phông chữ bị thiếu hoặc không khả dụng cho toàn bộ một đoạn văn bản hoặc một phần văn bản bằng một phông chữ khác. Chúng có thể được kết hợp, nhưng phạm vi và logic lựa chọn của chúng là khác nhau.

**Cài đặt dự phòng có được lưu trong tệp bản trình chiếu không?**

Không. Cấu hình dự phòng tồn tại trong thời gian xử lý/kết xuất trong thư viện và không được ghi vào PPTX. Bản trình chiếu không lưu trữ các quy tắc dự phòng của bạn.

**Phông chữ dự phòng có ảnh hưởng đến các phần tử được tạo bởi các đối tượng PowerPoint (SmartArt, biểu đồ, WordArt) không?**

Có. Văn bản bên trong các đối tượng này đi qua cùng một quy trình kết xuất, vì vậy các quy tắc dự phòng giống nhau được áp dụng cho chúng như với văn bản thông thường.