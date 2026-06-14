---
title: Lưu bản trình chiếu ở chế độ chỉ đọc trên Android
linktitle: Bản trình chiếu Chỉ Đọc
type: docs
weight: 30
url: /vi/androidjava/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bản trình chiếu
- ngăn chỉnh sửa
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc bằng Aspose.Slides for Android qua Java, cung cấp bản xem trước slide chính xác mà không làm thay đổi bản trình chiếu của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu cài đặt **Luôn mở ở chế độ chỉ đọc** như một trong những tùy chọn người dùng có thể sử dụng để bảo vệ bản trình chiếu của họ. Bạn có thể muốn sử dụng cài đặt Chỉ Đọc này để bảo vệ một bản trình chiếu khi

- Bạn muốn ngăn việc chỉnh sửa vô tình và giữ nội dung bản trình chiếu của mình an toàn. 
- Bạn muốn thông báo cho mọi người rằng bản trình chiếu bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Luôn mở ở chế độ chỉ đọc** cho một bản trình chiếu, khi người dùng mở bản trình chiếu, họ sẽ thấy đề xuất **Chỉ Đọc** và có thể nhìn thấy thông báo dưới dạng này: *Để ngăn thay đổi vô tình, tác giả đã đặt tệp này để mở ở chế độ chỉ đọc.*

Đề xuất Chỉ Đọc là một biện pháp ngăn cản đơn giản nhưng hiệu quả, khuyến khích người dùng không chỉnh sửa vì họ phải thực hiện một thao tác để gỡ bỏ nó trước khi được phép chỉnh sửa bản trình chiếu. Nếu bạn không muốn người dùng thực hiện thay đổi và muốn thông báo điều này một cách lịch sự, thì đề xuất Chỉ Đọc có thể là một lựa chọn tốt cho bạn. 

> Nếu một bản trình chiếu có bảo vệ **Chỉ Đọc** được mở bằng một ứng dụng Microsoft PowerPoint cũ hơn — không hỗ trợ chức năng mới được giới thiệu — thì đề xuất **Chỉ Đọc** sẽ bị bỏ qua (bản trình chiếu sẽ được mở bình thường).

## **Áp dụng chế độ Chỉ Đọc**

Aspose.Slides for Android via Java cho phép bạn đặt một bản trình chiếu ở trạng thái **Chỉ Đọc**, có nghĩa là người dùng (sau khi mở bản trình chiếu) sẽ thấy đề xuất **Chỉ Đọc**. Đoạn mã mẫu này cho bạn thấy cách đặt một bản trình chiếu ở trạng thái **Chỉ Đọc** trong Java bằng Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Lưu ý**: Đề xuất **Chỉ Đọc** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc tránh người dùng gây ra những thay đổi vô tình đối với một bản trình chiếu PowerPoint. Nếu một người có động cơ—biết cách thực hiện—quyết định chỉnh sửa bản trình chiếu của bạn, họ có thể dễ dàng gỡ bỏ cài đặt Chỉ Đọc. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ chặt chẽ hơn bao gồm mã hoá và mật khẩu](https://docs.aspose.com/slides/vi/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **Câu hỏi thường gặp**

**'Chỉ Đọc được đề xuất' khác gì so với bảo vệ bằng mật khẩu đầy đủ?**

'Chỉ Đọc được đề xuất' chỉ hiển thị đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Bảo vệ bằng mật khẩu](/slides/vi/androidjava/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các kiểm soát bảo mật thực sự.

**'Chỉ Đọc được đề xuất' có thể kết hợp với dấu nước để ngăn chặn chỉnh sửa hơn không?**

Có. Đề xuất có thể kết hợp với [dấu nước](/slides/vi/androidjava/watermark/) như một biện pháp ngăn cản trực quan; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

**Một macro hoặc công cụ bên ngoài vẫn có thể sửa đổi tệp khi đề xuất này được bật không?**

Có. Đề xuất không chặn các thay đổi theo chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hoá](/slides/vi/androidjava/password-protected-presentation/).

**'Chỉ Đọc được đề xuất' liên quan như thế nào đến các phương thức 'isEncrypted' và 'isWriteProtected'?**

Chúng là các tín hiệu khác nhau. 'Chỉ Đọc được đề xuất' là một lời nhắc mềm, tùy chọn; [isWriteProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) và [isEncrypted](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) cho biết hạn chế ghi hoặc đọc thực sự dựa trên mật khẩu hoặc mã hoá.