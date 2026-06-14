---
title: Quản lý phông chữ dự phòng cho bản trình chiếu trên Android
linktitle: Phông chữ dự phòng
type: docs
weight: 50
url: /vi/androidjava/fallback-font/
keywords:
- phông chữ dự phòng
- phông chữ có sẵn
- thay thế glyph
- chỉ định phông chữ
- chỉ định quy tắc
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Xem cách Aspose.Slides cho Android via Java sử dụng phông chữ dự phòng để giữ cho văn bản có thể đọc được trong các bản trình chiếu PowerPoint và OpenDocument khi phông chữ gốc không có sẵn."
---
## **Giới thiệu**

Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống, nhưng phông chữ này không chứa glyph cần thiết. Trong trường hợp này, có thể sử dụng một trong các phông chữ dự phòng đã chỉ định để thay thế glyph.

## **Phông chữ dự phòng**

Aspose.Slides cho phép tạo phông chữ dự phòng, thêm chúng vào bộ sưu tập phông chữ dự phòng, thiết lập bộ sưu tập phông chữ dự phòng cho một bản trình chiếu cụ thể, xóa phông chữ dự phòng khỏi bản trình chiếu, chỉ định các quy tắc áp dụng phông chữ dự phòng và các tính năng khác.

Để làm quen với các tính năng này, hãy sử dụng các liên kết sau:

- [Tạo phông chữ dự phòng](/slides/vi/androidjava/create-fallback-font)
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/androidjava/create-fallback-fonts-collection)
- [Kết xuất bản trình chiếu với phông chữ dự phòng](/slides/vi/androidjava/render-presentation-with-fallback-font)

## **Câu hỏi thường gặp**

**Phông chữ dự phòng khác gì so với việc thay thế phông chữ?**

Phông chữ dự phòng được áp dụng cho từng ký tự hoặc cho một dải Unicode khi phông chữ chính thiếu các glyph cụ thể; nó chỉ điền các ký tự còn thiếu. [Substitution](/slides/vi/androidjava/font-substitution/) thay thế một phông chữ bị thiếu hoặc không khả dụng cho toàn bộ đoạn hoặc phần văn bản bằng một phông chữ khác. Hai phương pháp có thể được kết hợp, nhưng phạm vi và logic lựa chọn của chúng khác nhau.

**Cài đặt dự phòng có được lưu trong tệp bản trình chiếu không?**

Không. Cấu hình dự phòng tồn tại trong thời gian xử lý/khử dạng trong thư viện và không được ghi vào tệp PPTX. Bản trình chiếu không lưu các quy tắc dự phòng của bạn.

**Phông chữ dự phòng có ảnh hưởng đến các yếu tố được tạo bởi các đối tượng PowerPoint (SmartArt, biểu đồ, WordArt) không?**

Có. Văn bản bên trong các đối tượng này đi qua cùng một quy trình kết xuất, vì vậy các quy tắc dự phòng giống nhau được áp dụng cho chúng như với văn bản thông thường.