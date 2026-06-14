---
title: Lưu bài thuyết trình ở chế độ chỉ đọc bằng Python
linktitle: Bài thuyết trình Chỉ Đọc
type: docs
weight: 30
url: /vi/python-net/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bài thuyết trình
- ngăn chỉnh sửa
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc với Aspose.Slides cho Python qua .NET, cung cấp bản xem trước slide chính xác mà không làm thay đổi bài thuyết trình của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu tùy chọn **Always Open Read-Only** như một trong các lựa chọn người dùng có thể dùng để bảo vệ bài thuyết trình của họ. Bạn có thể muốn sử dụng cài đặt Read-Only này để bảo vệ một bài thuyết trình khi

- Bạn muốn ngăn ngừa các chỉnh sửa vô tình và giữ nội dung bài thuyết trình của mình an toàn. 
- Bạn muốn cảnh báo mọi người rằng bản thuyết trình bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bài thuyết trình, khi người dùng mở bài thuyết trình, họ sẽ thấy đề xuất **Read-Only** và có thể thấy một tin nhắn dạng: *Để ngăn ngừa các thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Đề xuất Read-Only là một biện pháp ngăn chặn đơn giản nhưng hiệu quả, làm giảm việc chỉnh sửa vì người dùng phải thực hiện một thao tác để gỡ bỏ nó trước khi được phép chỉnh sửa bài thuyết trình. Nếu bạn không muốn người dùng thay đổi bài thuyết trình và muốn thông báo điều này một cách lịch sự, thì đề xuất Read-Only có thể là lựa chọn tốt cho bạn. 

> Nếu một bài thuyết trình có bảo vệ **Read-Only** được mở trong một phiên bản Microsoft PowerPoint cũ hơn—không hỗ trợ chức năng mới được giới thiệu—đề xuất **Read-Only** sẽ bị bỏ qua (bài thuyết trình được mở bình thường).

## **Áp dụng chế độ Read-Only**

Aspose.Slides for Python qua .NET cho phép bạn đặt một bài thuyết trình ở chế độ **Read-Only**, có nghĩa là người dùng (sau khi mở bài thuyết trình) sẽ thấy đề xuất **Read-Only**. Đoạn mã mẫu này hướng dẫn bạn cách đặt bài thuyết trình ở chế độ **Read-Only** trong Python bằng Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Lưu ý**: Đề xuất **Read-Only** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc ngăn người dùng gây ra những thay đổi vô tình đối với một bài thuyết trình PowerPoint. Nếu một người có động lực—người biết mình đang làm gì—quyết định chỉnh sửa bài thuyết trình của bạn, họ có thể dễ dàng gỡ bỏ cài đặt Read-Only. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ chặt chẽ hơn bao gồm mã hóa và mật khẩu](https://docs.aspose.com/slides/vi/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **Câu hỏi thường gặp**

**'Read-Only recommended' khác gì so với bảo mật bằng mật khẩu đầy đủ?**

'Read-Only recommended' chỉ hiển thị một đề xuất mở tệp ở chế độ chỉ đọc và rất dễ bỏ qua. [Bảo vệ bằng mật khẩu](/slides/vi/python-net/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các biện pháp bảo mật thực tế.

**'Read-Only recommended' có thể kết hợp với watermark để ngăn chặn việc chỉnh sửa hơn nữa không?**

Có. Đề xuất có thể kết hợp với [watermarks](/slides/vi/python-net/watermark/) như một biện pháp ngăn chặn bằng hình ảnh; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

**Macro hoặc công cụ bên ngoài vẫn có thể sửa đổi tệp khi đề xuất được bật không?**

Có. Đề xuất không chặn các thay đổi theo chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hóa](/slides/vi/python-net/password-protected-presentation/).

**'Read-Only recommended' liên quan như thế nào tới các cờ 'is_encrypted' và 'is_write_protected'?**

Chúng là các tín hiệu khác nhau. 'Read-Only recommended' là một lời nhắc mềm, tùy chọn; [is_write_protected](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/is_write_protected/) và [is_encrypted](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/is_encrypted/) chỉ ra các hạn chế thực tế về ghi hoặc đọc dựa trên mật khẩu hoặc mã hóa.