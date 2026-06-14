---
title: Lưu Bản Trình chiếu ở Chế độ Chỉ Đọc Sử dụng JavaScript
linktitle: Bản Trình chiếu Chỉ Đọc
type: docs
weight: 30
url: /vi/nodejs-java/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bản trình chiếu
- ngăn chặn chỉnh sửa
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tải và lưu tệp PowerPoint ở chế độ chỉ đọc với Aspose.Slides for Node.js via Java, cung cấp bản xem trước slide chính xác mà không thay đổi bản trình chiếu của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu tùy chọn **Always Open Read-Only** như một trong các cách người dùng có thể dùng để bảo vệ bản trình chiếu của họ. Bạn có thể muốn sử dụng thiết lập Read-Only này để bảo vệ một bản trình chiếu khi

- Bạn muốn ngăn chặn các chỉnh sửa vô tình và giữ nội dung bản trình chiếu an toàn. 
- Bạn muốn thông báo cho mọi người rằng bản trình chiếu bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bản trình chiếu, khi người dùng mở bản trình chiếu, họ sẽ thấy đề xuất **Read-Only** và có thể thấy một thông báo dạng: *Để ngăn ngừa các thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Đề xuất Read-Only là một biện pháp ngăn chặn đơn giản nhưng hiệu quả, khuyến khích không chỉnh sửa vì người dùng phải thực hiện một tác vụ để bỏ nó trước khi được phép chỉnh sửa bản trình chiếu. Nếu bạn không muốn người dùng thay đổi bản trình chiếu và muốn thông báo điều này một cách lịch sự, thì đề xuất Read-Only có thể là một lựa chọn tốt cho bạn. 

> Nếu một bản trình chiếu có bảo vệ **Read-Only** được mở trong một ứng dụng Microsoft PowerPoint cũ hơn — không hỗ trợ chức năng mới giới thiệu — thì đề xuất **Read-Only** sẽ bị bỏ qua (bản trình chiếu được mở bình thường).

## **Áp dụng chế độ Read-Only**

Aspose.Slides for Node.js via Java cho phép bạn đặt một bản trình chiếu ở trạng thái **Read-Only**, có nghĩa là người dùng (sau khi mở bản trình chiếu) sẽ thấy đề xuất **Read-Only**. Đoạn mã mẫu này cho bạn thấy cách đặt một bản trình chiếu ở **Read-Only** trong JavaScript bằng cách sử dụng Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Note**: Đề xuất **Read-Only** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc ngăn người dùng thực hiện các thay đổi vô tình đối với bản trình chiếu PowerPoint. Nếu một người có động cơ—biết mình đang làm gì—quyết định chỉnh sửa bản trình chiếu của bạn, họ có thể dễ dàng gỡ bỏ cài đặt Read-Only. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [nhiều biện pháp bảo vệ nghiêm ngặt hơn bao gồm mã hóa và mật khẩu](https://docs.aspose.com/slides/vi/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **Câu hỏi thường gặp**

**'Read-Only recommended' khác gì so với bảo vệ bằng mật khẩu đầy đủ?**

'Read-Only recommended' chỉ hiển thị một đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Bảo vệ bằng mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần kiểm soát bảo mật thực sự.

**Có thể kết hợp 'Read-Only recommended' với đánh dấu nước để ngăn chặn chỉnh sửa hơn nữa không?**

Có. Đề xuất có thể kết hợp với [đánh dấu nước](/slides/vi/nodejs-java/watermark/) như một biện pháp ngăn chặn bằng hình ảnh; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

**Macro hoặc công cụ bên ngoài vẫn có thể sửa đổi tệp khi đề xuất được bật không?**

Có. Đề xuất không chặn các thay đổi theo chương trình. Để ngăn chặn các chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hóa](/slides/vi/nodejs-java/password-protected-presentation/).

**'Read-Only recommended' liên quan như thế nào tới các cờ 'IsEncrypted' và 'IsWriteProtected'?**

Chúng là các tín hiệu khác nhau. 'Read-Only recommended' là một lời nhắc mềm, tùy chọn; [isWriteProtected](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) và [isEncrypted](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/isencrypted/) cho biết các hạn chế ghi hoặc đọc thực tế dựa trên mật khẩu hoặc mã hóa.