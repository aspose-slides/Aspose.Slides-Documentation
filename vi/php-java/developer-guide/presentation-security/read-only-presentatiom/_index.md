---
title: Lưu Bài Thuyết Trình ở Chế Độ Chỉ Đọc bằng PHP
linktitle: Bài Thuyết Trình Chỉ Đọc
type: docs
weight: 30
url: /vi/php-java/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bài thuyết trình
- ngăn chỉnh sửa
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc với Aspose.Slides cho PHP, cung cấp bản xem trước slide chính xác mà không thay đổi bài thuyết trình của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu cài đặt **Always Open Read-Only** như một trong các tùy chọn người dùng có thể sử dụng để bảo vệ bài thuyết trình của họ. Bạn có thể muốn sử dụng cài đặt Đọc‑chỉ này để bảo vệ một bài thuyết trình khi

- Bạn muốn ngăn ngừa các chỉnh sửa vô tình và giữ nội dung bài thuyết trình của mình an toàn. 
- Bạn muốn thông báo cho người khác rằng bài thuyết trình bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bài thuyết trình, khi người dùng mở bài thuyết trình, họ sẽ thấy khuyến nghị **Read-Only** và có thể thấy một thông điệp dạng: *Để ngăn ngừa các thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Khuyến nghị **Read-Only** là một biện pháp ngăn chặn đơn giản nhưng hiệu quả, vì nó khuyến khích người dùng không chỉnh sửa vì họ phải thực hiện một thao tác để loại bỏ nó trước khi được phép chỉnh sửa bài thuyết trình. Nếu bạn không muốn người dùng thay đổi bài thuyết trình và muốn thông báo điều này một cách lịch sự, thì khuyến nghị **Read-Only** có thể là một lựa chọn tốt cho bạn. 

> Nếu một bài thuyết trình có bảo vệ **Read-Only** được mở trong một phiên bản Microsoft PowerPoint cũ hơn—không hỗ trợ chức năng mới được giới thiệu—khuyến nghị **Read-Only** sẽ bị bỏ qua (bài thuyết trình được mở bình thường).

## **Áp dụng chế độ Đọc‑chỉ**

Aspose.Slides for PHP qua Java cho phép bạn đặt một bài thuyết trình ở trạng thái **Read-Only**, có nghĩa là người dùng (sau khi mở bài thuyết trình) sẽ thấy khuyến nghị **Read-Only**. Đoạn mã mẫu này cho bạn thấy cách đặt một bài thuyết trình ở trạng thái **Read-Only** bằng cách sử dụng Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Lưu ý**: Khuyến nghị **Read-Only** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc ngăn người dùng thực hiện các thay đổi vô tình đối với một bài thuyết trình PowerPoint. Nếu một người có động lực—biết mình đang làm gì—quyết định chỉnh sửa bài thuyết trình của bạn, họ có thể dễ dàng loại bỏ cài đặt Read-Only. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ nghiêm ngặt hơn bao gồm mã hóa và mật khẩu](https://docs.aspose.com/slides/vi/php-java/password-protected-presentation/).

{{% /alert %}} 

## **Câu hỏi thường gặp**

**'Read-Only recommended' khác gì so với bảo vệ bằng mật khẩu đầy đủ?**

'Read-Only recommended' chỉ hiển thị một đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Bảo vệ bằng mật khẩu](/slides/vi/php-java/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các biện pháp bảo mật thực tế. 

**'Read-Only recommended' có thể kết hợp với watermark để ngăn chặn chỉnh sửa hơn không?**

Có. Khuyến nghị có thể kết hợp với [đánh dấu](/slides/vi/php-java/watermark/) như một biện pháp ngăn chặn bằng hình ảnh; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau. 

**Macro hoặc công cụ bên ngoài vẫn có thể sửa đổi tệp khi khuyến nghị được bật không?**

Có. Khuyến nghị không chặn các thay đổi theo chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hóa](/slides/vi/php-java/password-protected-presentation/). 

**'Read-Only recommended' liên quan như thế nào đến các phương thức 'isEncrypted' và 'isWriteProtected'?**

Chúng là những tín hiệu khác nhau. 'Read-Only recommended' là một lời nhắc mềm, tùy chọn; [isWriteProtected](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/iswriteprotected/) và [isEncrypted](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/isencrypted/) cho biết các hạn chế ghi hoặc đọc thực tế phụ thuộc vào mật khẩu hoặc mã hóa.