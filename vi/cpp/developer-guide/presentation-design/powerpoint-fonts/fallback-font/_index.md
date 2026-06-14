---
title: Quản lý phông chữ dự phòng cho bản trình chiếu trong C++
linktitle: Phông chữ dự phòng
type: docs
weight: 50
url: /vi/cpp/fallback-font/
keywords:
- phông chữ dự phòng
- phông chữ có sẵn
- thay thế glyph
- chỉ định phông chữ
- chỉ định quy tắc
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Xem cách Aspose.Slides cho C++ sử dụng phông chữ dự phòng để giữ cho văn bản có thể đọc được trong các bản trình chiếu PowerPoint và OpenDocument khi các phông chữ gốc không có sẵn."
---
## **Giới thiệu**

Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống nhưng không chứa ký tự glyph cần thiết. Trong trường hợp này, Aspose.Slides có thể sử dụng một trong các phông chữ dự phòng đã chỉ định để thay thế glyph bị thiếu.

## **Phông chữ dự phòng**
Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống, nhưng phông chữ này không chứa glyph cần thiết. Trong trường hợp này, có thể sử dụng một trong các phông chữ dự phòng đã chỉ định để thay thế glyph.

Aspose.Slides cho phép tạo phông chữ dự phòng, thêm chúng vào bộ sưu tập phông chữ dự phòng, đặt bộ sưu tập phông chữ dự phòng cho một bản trình chiếu cụ thể, xóa phông chữ dự phòng khỏi bản trình chiếu, chỉ định các quy tắc áp dụng phông chữ dự phòng và các chức năng khác.

Để làm quen với các tính năng này, hãy sử dụng các liên kết sau:

- [Tạo phông chữ dự phòng](/slides/vi/cpp/create-fallback-font)
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/cpp/create-fallback-fonts-collection)
- [Hiển thị bản trình chiếu với phông chữ dự phòng](/slides/vi/cpp/render-presentation-with-fallback-font)

## **Câu hỏi thường gặp**

**Phông chữ dự phòng khác với việc thay thế phông chữ như thế nào?**

Phông chữ dự phòng được áp dụng cho từng ký tự hoặc cho một phạm vi Unicode khi phông chữ chính thiếu các glyph cụ thể; nó chỉ lấp đầy các ký tự bị thiếu. [Thay thế](/slides/vi/cpp/font-substitution/) thay thế một phông chữ bị thiếu hoặc không khả dụng cho toàn bộ đoạn hoặc phần văn bản bằng một phông chữ khác. Hai phương pháp có thể được kết hợp, nhưng phạm vi và logic lựa chọn của chúng khác nhau.

**Các cài đặt dự phòng có được lưu trong tệp bản trình chiếu không?**

Không. Cấu hình dự phòng tồn tại chỉ trong thời gian xử lý/hiển thị trong thư viện và không được ghi vào tệp PPTX. Bản trình chiếu không lưu trữ các quy tắc dự phòng của bạn.

**Phông chữ dự phòng có ảnh hưởng đến các yếu tố được tạo bởi các đối tượng PowerPoint (SmartArt, biểu đồ, WordArt) không?**

Có. Văn bản bên trong các đối tượng này cũng đi qua cùng quy trình hiển thị, do đó các quy tắc dự phòng tương tự được áp dụng cho chúng giống như văn bản thông thường.