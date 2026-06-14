---
title: Quản lý phông chữ dự phòng cho bản trình bày trong PHP
linktitle: Phông chữ dự phòng
type: docs
weight: 50
url: /vi/php-java/fallback-font/
keywords:
  - phông chữ dự phòng
  - phông chữ có sẵn
  - thay thế glyph
  - chỉ định phông chữ
  - chỉ định quy tắc
  - PowerPoint
  - OpenDocument
  - bản trình bày
  - PHP
  - Aspose.Slides
description: "Xem cách Aspose.Slides cho PHP sử dụng phông chữ dự phòng để giữ cho văn bản có thể đọc được trong các bản trình bày PowerPoint và OpenDocument khi các phông chữ gốc không khả dụng."
---
## **Giới thiệu**

Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống nhưng không chứa glyph cần thiết. Trong trường hợp này, Aspose.Slides có thể sử dụng một trong các phông chữ dự phòng đã chỉ định để thay thế glyph bị thiếu.

## **Phông chữ dự phòng**
Phông chữ dự phòng được sử dụng khi phông chữ được chỉ định cho văn bản có sẵn trong hệ thống, nhưng phông chữ này không chứa glyph cần thiết. Trong trường hợp này, có thể sử dụng một trong các phông chữ dự phòng đã chỉ định để thay thế glyph.

Aspose.Slides cho phép tạo các phông chữ dự phòng, thêm chúng vào bộ sưu tập phông chữ dự phòng, đặt bộ sưu tập phông chữ dự phòng cho một bản trình bày cụ thể, loại bỏ phông chữ dự phòng khỏi bản trình bày, chỉ định các quy tắc áp dụng phông chữ dự phòng và các tính năng khác.

Để làm quen với các tính năng này, hãy sử dụng các liên kết sau:

- [Tạo phông chữ dự phòng](/slides/vi/php-java/create-fallback-font)
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/php-java/create-fallback-fonts-collection)
- [Kết xuất bản trình bày với phông chữ dự phòng](/slides/vi/php-java/render-presentation-with-fallback-font)

## **Câu hỏi thường gặp**

**Phông chữ dự phòng khác với việc thay thế phông chữ như thế nào?**

Phông chữ dự phòng được áp dụng cho từng ký tự hoặc cho một dải Unicode khi phông chữ chính thiếu các glyph cụ thể; nó chỉ lấp đầy các ký tự bị thiếu. [Thay thế](/slides/vi/php-java/font-substitution/) thay thế một phông chữ bị thiếu hoặc không khả dụng cho toàn bộ đoạn hoặc phần văn bản bằng một phông chữ khác. Hai phương pháp có thể được kết hợp, nhưng phạm vi và logic lựa chọn của chúng là khác nhau.

**Cài đặt dự phòng có được lưu trong tệp bản trình bày không?**

Không. Cấu hình dự phòng tồn tại ở thời điểm xử lý/kết xuất trong thư viện và không được tuần tự hoá vào file PPTX. Bản trình bày không lưu trữ các quy tắc dự phòng của bạn.

**Phông chữ dự phòng có ảnh hưởng đến các yếu tố được tạo bởi đối tượng PowerPoint (SmartArt, biểu đồ, WordArt) không?**

Có. Văn bản bên trong các đối tượng này đi qua cùng pipeline kết xuất, vì vậy các quy tắc dự phòng cũng áp dụng cho chúng giống như với văn bản thông thường.