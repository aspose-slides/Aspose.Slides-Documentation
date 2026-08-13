---
title: Lưu Bài Thuyết Trình ở Chế Độ Chỉ Đọc trong .NET
linktitle: Bài Thuyết Trình Chỉ Đọc
type: docs
weight: 30
url: /vi/net/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bài thuyết trình
- ngăn chặn việc chỉnh sửa
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc bằng Aspose.Slides cho .NET, cung cấp bản xem trước slide chính xác mà không làm thay đổi các bài thuyết trình của bạn."
---
## **Introduction**

Trong PowerPoint 2019, Microsoft đã giới thiệu cài đặt **Always Open Read-Only** như một trong các tùy chọn người dùng có thể dùng để bảo vệ bài thuyết trình của mình. Bạn có thể muốn sử dụng cài đặt Read-Only này để bảo vệ một bài thuyết trình khi

- Bạn muốn ngăn ngừa các sửa đổi vô tình và giữ nội dung bài thuyết trình an toàn. 
- Bạn muốn thông báo cho mọi người rằng bản thuyết trình bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bài thuyết trình, khi người dùng mở bài thuyết trình, họ sẽ thấy lời khuyên **Read-Only** và có thể thấy một thông báo dưới dạng: *Để ngăn ngừa các thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Lời khuyên Read-Only là một biện pháp ngăn chặn đơn giản nhưng hiệu quả, khiến người dùng phải thực hiện một thao tác để gỡ bỏ nó trước khi được phép chỉnh sửa bài thuyết trình. Nếu bạn không muốn người dùng thay đổi bài thuyết trình và muốn thông báo điều này một cách lịch sự, thì lời khuyên Read-Only có thể là một lựa chọn tốt cho bạn. 

> Nếu một bài thuyết trình có bảo vệ **Read-Only** được mở trong một phiên bản Microsoft PowerPoint cũ hơn—không hỗ trợ chức năng vừa được giới thiệu—lời khuyên **Read-Only** sẽ bị bỏ qua (bài thuyết trình được mở bình thường).

## **Apply Read-Only Mode**

Aspose.Slides for .NET cho phép bạn đặt một bài thuyết trình ở chế độ **Read-Only**, nghĩa là người dùng (sau khi mở bài thuyết trình) sẽ thấy lời khuyên **Read-Only**. Đoạn mã mẫu dưới đây cho thấy cách đặt một bài thuyết trình ở chế độ **Read-Only** trong C# bằng Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Note**: Lời khuyên **Read-Only** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc tránh những thay đổi vô tình trong một bài thuyết trình PowerPoint. Nếu một người có động lực—biết cách làm—quyết định chỉnh sửa bài thuyết trình của bạn, họ có thể dễ dàng gỡ bỏ cài đặt Read-Only. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [bảo vệ chặt chẽ hơn bao gồm mã hóa và mật khẩu](https://docs.aspose.com/slides/vi/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### How is 'Read-Only recommended' different from full password protection?

'Read-Only recommended' chỉ hiển thị một đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Password protection](/slides/vi/net/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các biện pháp bảo mật thực sự.

### Can 'Read-Only recommended' be combined with watermarks to further discourage edits?

Có. Lời khuyên có thể kết hợp với [watermarks](/slides/vi/net/watermark/) như một biện pháp ngăn chặn bằng hình ảnh; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

### Can a macro or external tool still modify the file when the recommendation is enabled?

Có. Lời khuyên không chặn các thay đổi theo chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [passwords and encryption](/slides/vi/net/password-protected-presentation/).

### How does 'Read-Only recommended' relate to the flags 'IsEncrypted' and 'IsWriteProtected'?

Chúng là các tín hiệu khác nhau. 'Read-Only recommended' là một lời nhắc nhẹ, tùy chọn; [IsWriteProtected](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/iswriteprotected/) và [IsEncrypted](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/isencrypted/) cho biết các hạn chế ghi hoặc đọc thực tế dựa trên mật khẩu hoặc mã hóa.