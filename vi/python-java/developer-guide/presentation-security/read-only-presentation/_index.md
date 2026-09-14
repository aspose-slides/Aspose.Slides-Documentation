---
title: Lưu Bài Thuyết Trình ở Chế Độ Chỉ Đọc Bằng Python
linktitle: Bài Thuyết Trình Chỉ Đọc
type: docs
weight: 30
url: /vi/python-java/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bài thuyết trình
- ngăn chỉnh sửa
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc bằng Aspose.Slides cho Python qua Java, cung cấp bản xem trước slide chính xác mà không thay đổi bài thuyết trình của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu tùy chọn **Always Open Read-Only** như một trong các lựa chọn người dùng có thể dùng để bảo vệ bài thuyết trình của họ. Bạn có thể muốn sử dụng cài đặt Đọc‑chỉ này để bảo vệ một bài thuyết trình khi:

- Bạn muốn ngăn ngừa các chỉnh sửa vô tình và giữ nội dung bài thuyết trình của mình an toàn.
- Bạn muốn cảnh báo người khác rằng bài thuyết trình bạn cung cấp là phiên bản cuối cùng.

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bài thuyết trình, khi người dùng mở bài thuyết trình, họ sẽ thấy khuyến nghị **Read-Only** và có thể thấy một thông báo dạng: *Để ngăn ngừa các thay đổi vô tình, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Khuyến nghị **Read-Only** là một biện pháp ngăn chặn đơn giản nhưng hiệu quả, ngăn người dùng chỉnh sửa vì họ phải thực hiện một thao tác để gỡ bỏ nó trước khi được phép chỉnh sửa bài thuyết trình. Nếu bạn không muốn người dùng thay đổi bài thuyết trình và muốn thông báo điều này một cách lịch sự, thì khuyến nghị **Read-Only** có thể là lựa chọn phù hợp cho bạn.

> Nếu một bài thuyết trình có bảo vệ **Read-Only** được mở trong phiên bản Microsoft PowerPoint cũ hơn — không hỗ trợ chức năng mới vừa được giới thiệu — khuyến nghị **Read-Only** sẽ bị bỏ qua (bài thuyết trình được mở bình thường).

## **Áp dụng chế độ Đọc‑chỉ**

Aspose.Slides for Python qua Java cho phép bạn thiết lập một bài thuyết trình ở chế độ **Read-Only**, có nghĩa là người dùng (sau khi mở bài thuyết trình) sẽ thấy khuyến nghị **Read-Only**. Đoạn mã mẫu này cho bạn thấy cách đặt một bài thuyết trình thành **Read-Only** trong Python bằng Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Khuyến nghị **Read-Only** đơn giản chỉ nhằm ngăn chặn việc chỉnh sửa hoặc ngăn người dùng thực hiện các thay đổi vô tình đối với một bài thuyết trình PowerPoint. Nếu một người có động cơ — người biết mình đang làm gì — quyết định chỉnh sửa bài thuyết trình của bạn, họ có thể dễ dàng gỡ bỏ cài đặt Đọc‑chỉ. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ nghiêm ngặt hơn có liên quan đến mã hóa và mật khẩu](/slides/vi/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **Câu hỏi thường gặp**

**'Read-Only recommended' khác gì so với bảo vệ bằng mật khẩu đầy đủ?**

'Read-Only recommended' chỉ hiển thị một đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Bảo vệ bằng mật khẩu](/slides/vi/python-java/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và thích hợp khi bạn cần các biện pháp bảo mật thực tế.

**'Read-Only recommended' có thể kết hợp với watermark để ngăn chặn việc chỉnh sửa hơn nữa không?**

Có. Khuyến nghị có thể kết hợp với [đánh dấu nước](/slides/vi/python-java/watermark/) như một biện pháp ngăn chặn trực quan; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

**Macro hoặc công cụ bên ngoài vẫn có thể sửa đổi tệp khi khuyến nghị được bật không?**

Có. Khuyến nghị không chặn các thay đổi theo chương trình. Để ngăn chặn việc chỉnh sửa tự động, hãy sử dụng [mật khẩu và mã hóa](/slides/vi/python-java/password-protected-presentation/).

**'Read-Only recommended' liên quan như thế nào đến các phương thức [isEncrypted](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#isEncrypted) và [isWriteProtected](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**

Chúng là các tín hiệu khác nhau. 'Read-Only recommended' là một lời nhắc mềm, tùy chọn; [isWriteProtected](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#isWriteProtected) và [isEncrypted](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#isEncrypted) cho biết các hạn chế ghi hoặc đọc thực tế phụ thuộc vào mật khẩu hoặc mã hóa.