---
title: Chuyển đổi PPTX sang PPT trong PHP
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/php-java/convert-pptx-to-ppt/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPTX
- PPTX sang PPT
- lưu PPTX dưới dạng PPT
- xuất PPTX sang PPT
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Dễ dàng chuyển đổi PPTX sang PPT với Aspose.Slides — đảm bảo tương thích liền mạch với các định dạng PowerPoint đồng thời bảo tồn bố cục và chất lượng của bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint ở định dạng PPTX sang định dạng PPT bằng PHP. Các chủ đề sau được đề cập.

- Chuyển đổi PPTX sang PPT

## **Chuyển đổi PPTX sang PPT trong PHP**

Đối với mã mẫu Java để chuyển đổi PPTX sang PPT, vui lòng xem phần dưới đây tức là [Chuyển đổi PPTX sang PPT](#convert-pptx-to-ppt). Nó chỉ tải tệp PPTX và lưu dưới dạng PPT. Bằng cách chỉ định các định dạng lưu khác nhau, bạn cũng có thể lưu tệp PPTX thành nhiều định dạng khác như PDF, XPS, ODP, HTML, v.v. như đã thảo luận trong các bài viết này. 

- [Chuyển đổi PPTX sang PDF trong PHP](/slides/vi/php-java/convert-powerpoint-to-pdf/)
- [Chuyển đổi PPTX sang XPS trong PHP](/slides/vi/php-java/convert-powerpoint-to-xps/)
- [Chuyển đổi PPTX sang HTML trong PHP](/slides/vi/php-java/convert-powerpoint-to-html/)
- [Chuyển đổi PPTX sang ODP trong PHP](/slides/vi/php-java/save-presentation/)
- [Chuyển đổi PPTX sang PNG trong PHP](/slides/vi/php-java/convert-powerpoint-to-png/)

## **Chuyển đổi PPTX sang PPT**
Để chuyển đổi một tệp PPTX sang PPT, chỉ cần truyền tên tệp và định dạng lưu vào phương thức **Save** của lớp [**Presentation**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation). Mẫu mã PHP bên dưới chuyển đổi một Presentation từ PPTX sang PPT bằng các tùy chọn mặc định.

```php
  # khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
  $presentation = new Presentation("template.pptx");
  # lưu bản trình chiếu dưới dạng PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **Câu hỏi thường gặp**

**Tất cả các hiệu ứng và tính năng của PPTX có được bảo toàn khi lưu sang định dạng PPT (97–2003) không?**

Không phải lúc nào cũng vậy. Định dạng PPT thiếu một số khả năng mới (ví dụ: một số hiệu ứng, đối tượng và hành vi), vì vậy các tính năng có thể bị đơn giản hoá hoặc chuyển sang dạng raster trong quá trình chuyển đổi.

**Tôi có thể chuyển đổi chỉ các slide đã chọn sang PPT thay vì toàn bộ bản trình chiếu không?**

Việc lưu trực tiếp sẽ áp dụng cho toàn bộ bản trình chiếu. Để chuyển đổi các slide cụ thể, hãy tạo một bản trình chiếu mới chỉ chứa các slide đó và lưu dưới dạng PPT; hoặc sử dụng dịch vụ/API hỗ trợ các tham số chuyển đổi theo từng slide.

**Các bản trình chiếu được bảo vệ bằng mật khẩu có được hỗ trợ không?**

Có. Bạn có thể xác định xem tệp có được bảo vệ không, mở nó bằng mật khẩu, và cũng có thể [cấu hình cài đặt bảo vệ/mã hoá](/slides/vi/php-java/password-protected-presentation/) cho tệp PPT đã lưu.