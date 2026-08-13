---
title: Lưu bản trình chiếu ở chế độ chỉ đọc trên Android
linktitle: Bản trình chiếu chỉ đọc
type: docs
weight: 30
url: /vi/androidjava/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bản trình chiếu
- ngăn chặn chỉnh sửa
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Lưu tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc với Aspose.Slides cho Android qua Java, cung cấp bản xem trước slide chính xác mà không làm thay đổi bản trình chiếu của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu cài đặt **Always Open Read-Only** như một trong các tùy chọn mà người dùng có thể sử dụng để bảo vệ bản trình chiếu của họ. Bạn có thể muốn sử dụng cài đặt Đọc‑chỉ này để bảo vệ một bản trình chiếu khi

- Bạn muốn ngăn ngừa các chỉnh sửa vô tình và giữ nội dung bản trình chiếu của mình an toàn.
- Bạn muốn cảnh báo mọi người rằng bản trình chiếu bạn cung cấp là phiên bản cuối cùng.

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bản trình chiếu, khi người dùng mở bản trình chiếu, họ sẽ thấy khuyến nghị **Read-Only** và có thể thấy một thông báo dạng: *Để ngăn ngừa các thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Khuyến nghị Read-Only là một biện pháp ngăn chặn đơn giản nhưng hiệu quả, khuyến khích người dùng không chỉnh sửa vì họ phải thực hiện một thao tác để loại bỏ nó trước khi được phép chỉnh sửa bản trình chiếu. Nếu bạn không muốn người dùng thay đổi bản trình chiếu và muốn thông báo điều này một cách lịch sự, thì khuyến nghị Read-Only có thể là một lựa chọn tốt cho bạn.

> Nếu một bản trình chiếu có bảo vệ **Read-Only** được mở trong một phiên bản Microsoft PowerPoint cũ hơn — không hỗ trợ chức năng mới được giới thiệu — khuyến nghị **Read-Only** sẽ bị bỏ qua (bản trình chiếu được mở bình thường).

## **Áp dụng chế độ Đọc‑chỉ**

Aspose.Slides for Android via Java cho phép bạn đặt một bản trình chiếu ở trạng thái **Read-Only**, có nghĩa là người dùng (sau khi mở bản trình chiếu) sẽ thấy khuyến nghị **Read-Only**. Đoạn mã mẫu này cho bạn thấy cách đặt một bản trình chiếu ở **Read-Only** trong Java bằng cách sử dụng Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
**Note**: Khuyến nghị **Read-Only** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc dừng người dùng thực hiện các thay đổi vô tình đối với bản trình chiếu PowerPoint. Nếu một người có động lực — biết mình đang làm gì — quyết định chỉnh sửa bản trình chiếu của bạn, họ có thể dễ dàng loại bỏ cài đặt Read-Only. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ chặt chẽ hơn bao gồm mã hoá và mật khẩu](https://docs.aspose.com/slides/vi/androidjava/password-protected-presentation/).
{{% /alert %}} 

## **Câu hỏi thường gặp**

### 'Read-Only recommended' khác gì so với bảo vệ bằng mật khẩu đầy đủ?

'Read-Only recommended' chỉ hiển thị một đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Bảo vệ bằng mật khẩu](/slides/vi/androidjava/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các biện pháp kiểm soát bảo mật thực sự.

### 'Read-Only recommended' có thể kết hợp với dấu watermark để ngăn chặn việc chỉnh sửa hơn không?

Có. Khuyến nghị có thể được kết hợp với [dấu watermark](/slides/vi/androidjava/watermark/) như một biện pháp ngăn chặn bằng hình ảnh; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

### Một macro hoặc công cụ bên ngoài vẫn có thể sửa đổi tệp khi khuyến nghị được bật không?

Có. Khuyến nghị không chặn các thay đổi theo chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hoá](/slides/vi/androidjava/password-protected-presentation/).

### 'Read-Only recommended' liên quan như thế nào tới các phương thức 'isEncrypted' và 'isWriteProtected'?

Chúng là các tín hiệu khác nhau. 'Read-Only recommended' là một lời nhắc mềm, tùy chọn; [isWriteProtected](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) và [isEncrypted](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) cho biết các hạn chế thực tế về ghi hoặc đọc phụ thuộc vào mật khẩu hoặc mã hoá.