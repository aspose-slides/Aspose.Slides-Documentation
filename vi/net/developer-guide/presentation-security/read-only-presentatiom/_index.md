---
title: Lưu Bản Trình Bày ở Chế Độ Chỉ Đọc trong .NET
linktitle: Bản Trình Bày Chỉ Đọc
type: docs
weight: 30
url: /vi/net/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bản trình bày
- ngăn chỉnh sửa
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc với Aspose.Slides cho .NET, cung cấp bản xem trước slide chính xác mà không làm thay đổi bản trình bày của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu tùy chọn **Luôn Mở ở Chế độ Chỉ Đọc** như một trong các tùy chọn người dùng có thể sử dụng để bảo vệ bản trình bày của họ. Bạn có thể muốn sử dụng thiết lập Chỉ Đọc này để bảo vệ một bản trình bày khi

- Bạn muốn ngăn các chỉnh sửa nhầm lẫn và giữ nội dung bản trình bày an toàn. 
- Bạn muốn thông báo cho người khác rằng bản trình bày bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Luôn Mở ở Chế độ Chỉ Đọc** cho một bản trình bày, khi người dùng mở bản trình bày, họ sẽ nhìn thấy đề xuất **Chỉ Đọc** và có thể thấy một thông báo dạng: *Để ngăn những thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Đề xuất Chỉ Đọc là một biện pháp ngăn chặn đơn giản nhưng hiệu quả, khiến người dùng phải thực hiện một tác vụ để loại bỏ nó trước khi được phép chỉnh sửa bản trình bày. Nếu bạn không muốn người dùng thực hiện thay đổi và muốn thông báo điều này một cách lịch sự, thì đề xuất Chỉ Đọc có thể là một lựa chọn tốt cho bạn. 

> Nếu một bản trình bày có bảo vệ **Chỉ Đọc** được mở trong một phiên bản Microsoft PowerPoint cũ hơn — không hỗ trợ chức năng mới được giới thiệu — đề xuất **Chỉ Đọc** sẽ bị bỏ qua (bản trình bày sẽ được mở bình thường).

## **Áp dụng Chế độ Chỉ Đọc**

Aspose.Slides for .NET cho phép bạn đặt một bản trình bày thành **Chỉ Đọc**, nghĩa là người dùng (sau khi mở bản trình bày) sẽ thấy đề xuất **Chỉ Đọc**. Đoạn mã mẫu này cho thấy cách đặt một bản trình bày thành **Chỉ Đọc** trong C# bằng Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Lưu ý**: Đề xuất **Chỉ Đọc** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc ngăn người dùng thực hiện các thay đổi vô tình đối với một bản trình bày PowerPoint. Nếu một người có động cơ — biết mình đang làm gì — quyết định chỉnh sửa bản trình bày của bạn, họ có thể dễ dàng loại bỏ cài đặt Chỉ Đọc. Nếu bạn thực sự cần ngăn ngừa việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ chặt chẽ hơn có liên quan đến mã hoá và mật khẩu](https://docs.aspose.com/slides/vi/net/password-protected-presentation/). 

{{% /alert %}} 

## **Câu hỏi thường gặp**

**‘Read-Only recommended’ khác gì so với bảo vệ bằng mật khẩu đầy đủ?**

‘Read-Only recommended’ chỉ hiển thị một gợi ý để mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Password protection](/slides/vi/net/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các kiểm soát bảo mật thực sự.

**‘Read-Only recommended’ có thể kết hợp với dấu watermarks để ngăn chặn việc chỉnh sửa hơn không?**

Có. Đề xuất có thể được kết hợp với [watermarks](/slides/vi/net/watermark/) như một biện pháp ngăn chặn trực quan; chúng là các cơ chế riêng biệt và làm việc tốt cùng nhau.

**Macro hoặc công cụ bên ngoài vẫn có thể thay đổi tệp khi đề xuất được bật không?**

Có. Đề xuất không chặn các thay đổi bằng chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hoá](/slides/vi/net/password-protected-presentation/).

**‘Read-Only recommended’ liên quan như thế nào đến các cờ ‘IsEncrypted’ và ‘IsWriteProtected’?**

Chúng là các tín hiệu khác nhau. ‘Read-Only recommended’ là một lời nhắc nhẹ, tùy chọn; [IsWriteProtected](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/iswriteprotected/) và [IsEncrypted](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/isencrypted/) cho biết các hạn chế ghi hoặc đọc thực tế dựa trên mật khẩu hoặc mã hoá.