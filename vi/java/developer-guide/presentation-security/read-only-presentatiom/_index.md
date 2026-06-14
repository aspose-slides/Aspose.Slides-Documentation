---
title: Lưu bản trình chiếu ở chế độ Chỉ Đọc bằng Java
linktitle: Bản Trình Chiếu Chỉ Đọc
type: docs
weight: 30
url: /vi/java/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bản trình chiếu
- ngăn chặn chỉnh sửa
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc với Aspose.Slides cho Java, cung cấp bản xem trước slide chính xác mà không làm thay đổi bản trình chiếu của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu cài đặt **Always Open Read-Only** như một trong những tùy chọn người dùng có thể dùng để bảo vệ bản trình chiếu của họ. Bạn có thể muốn sử dụng cài đặt Đọc‑chỉ này để bảo vệ một bản trình chiếu khi

- Bạn muốn ngăn ngừa các chỉnh sửa vô tình và giữ nội dung bản trình chiếu của mình an toàn. 
- Bạn muốn cảnh báo mọi người rằng bản trình chiếu bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bản trình chiếu, khi người dùng mở bản trình chiếu, họ sẽ thấy đề xuất **Read-Only** và có thể thấy một thông báo như sau: *Để ngăn ngừa các thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Đề xuất **Read-Only** là một biện pháp ngăn cản đơn giản nhưng hiệu quả, khiến người dùng phải thực hiện một thao tác để gỡ bỏ nó trước khi được phép chỉnh sửa bản trình chiếu. Nếu bạn không muốn người dùng thay đổi bản trình chiếu và muốn thông báo điều này một cách lịch sự, thì đề xuất **Read-Only** có thể là một lựa chọn tốt cho bạn. 

> Nếu một bản trình chiếu có bảo vệ **Read-Only** được mở trong một phiên bản Microsoft PowerPoint cũ hơn — không hỗ trợ chức năng mới được giới thiệu — đề xuất **Read-Only** sẽ bị bỏ qua (bản trình chiếu sẽ mở bình thường).

## **Áp dụng chế độ Đọc‑chỉ**

Aspose.Slides for Java cho phép bạn đặt một bản trình chiếu ở chế độ **Read-Only**, tức là người dùng (sau khi mở bản trình chiếu) sẽ thấy đề xuất **Read-Only**. Đoạn mã mẫu này cho bạn thấy cách đặt một bản trình chiếu ở chế độ **Read-Only** trong Java bằng cách sử dụng Aspose.Slides:

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

**Lưu ý**: Đề xuất **Read-Only** chỉ nhằm ngăn cản việc chỉnh sửa hoặc ngăn người dùng thực hiện các thay đổi vô tình đối với bản trình chiếu PowerPoint. Nếu một người có động cơ — biết mình đang làm gì — quyết định chỉnh sửa bản trình chiếu của bạn, họ có thể dễ dàng gỡ bỏ cài đặt Đọc‑chỉ. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ nghiêm ngặt hơn có liên quan đến mã hoá và mật khẩu](https://docs.aspose.com/slides/vi/java/password-protected-presentation/). 

{{% /alert %}} 

## **Câu hỏi thường gặp**

**'Read-Only recommended' khác gì so với bảo vệ bằng mật khẩu đầy đủ?**

'Read-Only recommended' chỉ hiển thị một đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Bảo vệ bằng mật khẩu](/slides/vi/java/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các biện pháp bảo mật thực tế.

**'Read-Only recommended' có thể kết hợp với watermark để ngăn chặn việc chỉnh sửa hơn nữa không?**

Có. Đề xuất có thể kết hợp với [đánh dấu nước](/slides/vi/java/watermark/) như một biện pháp ngăn cản trực quan; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

**Macro hoặc công cụ bên ngoài vẫn có thể sửa đổi tệp khi đề xuất này được bật không?**

Có. Đề xuất không chặn các thay đổi thông qua chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hoá](/slides/vi/java/password-protected-presentation/).

**'Read-Only recommended' liên quan như thế nào tới các phương thức 'isEncrypted' và 'isWriteProtected'?**

Chúng là những tín hiệu khác nhau. 'Read-Only recommended' là một lời nhắc mềm, tùy chọn; [isWriteProtected](https://reference.aspose.com/slides/vi/java/com.aspose.slides/protectionmanager/#isWriteProtected--) và [isEncrypted](https://reference.aspose.com/slides/vi/java/com.aspose.slides/protectionmanager/#isEncrypted--) cho biết các hạn chế thực tế về ghi hoặc đọc phụ thuộc vào mật khẩu hoặc mã hoá.