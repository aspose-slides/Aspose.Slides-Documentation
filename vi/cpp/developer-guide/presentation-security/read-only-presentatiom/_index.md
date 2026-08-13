---
title: Lưu Bài Thuyết Trình ở Chế Độ Đọc‑chỉ bằng C++
linktitle: Bài Thuyết Trình Đọc‑chỉ
type: docs
weight: 30
url: /vi/cpp/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bài thuyết trình
- ngăn chỉnh sửa
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc với Aspose.Slides cho C++, cung cấp bản xem trước slide chính xác mà không làm thay đổi bài thuyết trình của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu tùy chọn **Always Open Read-Only** như một trong các cách người dùng có thể dùng để bảo vệ bài thuyết trình của mình. Bạn có thể muốn sử dụng tùy chọn Đọc‑chỉ này để bảo vệ một bài thuyết trình khi

- Bạn muốn ngăn việc chỉnh sửa nhầm và giữ nội dung bài thuyết trình an toàn.  
- Bạn muốn thông báo cho mọi người rằng bản thuyết trình bạn cung cấp là phiên bản cuối cùng.  

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bài thuyết trình, khi người dùng mở bài thuyết trình, họ sẽ thấy khuyến nghị **Read-Only** và có thể thấy một thông báo dạng này: *Để ngăn thay đổi nhầm, tác giả đã đặt tệp này mở ở chế độ chỉ đọc.*

Khuyến nghị Đọc‑chỉ là một biện pháp ngăn ngừa đơn giản nhưng hiệu quả, khiến người dùng phải thực hiện một thao tác để gỡ bỏ nó trước khi được phép chỉnh sửa bài thuyết trình. Nếu bạn không muốn người dùng thay đổi nội dung và muốn thông báo điều này một cách lịch sự, thì khuyến nghị Đọc‑chỉ có thể là lựa chọn tốt cho bạn.

> Nếu một bài thuyết trình có bảo vệ **Read-Only** được mở trong phiên bản Microsoft PowerPoint cũ hơn — không hỗ trợ tính năng mới này — khuyến nghị **Read-Only** sẽ bị bỏ qua (bài thuyết trình được mở bình thường).

## **Áp dụng chế độ Đọc‑chỉ**

Aspose.Slides for C++ cho phép bạn thiết lập một bài thuyết trình ở trạng thái **Read-Only**, nghĩa là người dùng (sau khi mở bài thuyết trình) sẽ thấy khuyến nghị **Read-Only**. Đoạn mã mẫu dưới đây cho thấy cách đặt một bài thuyết trình ở trạng thái **Read-Only** trong C++ bằng Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Lưu ý**: Khuyến nghị **Read-Only** chỉ nhằm ngăn ngừa việc chỉnh sửa hoặc tránh người dùng thực hiện các thay đổi vô tình đối với một bài thuyết trình PowerPoint. Nếu một người có động cơ—biết mình đang làm gì—quyết định chỉnh sửa bài thuyết trình của bạn, họ có thể dễ dàng gỡ bỏ cài đặt Đọc‑chỉ. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [các biện pháp bảo vệ chặt chẽ hơn liên quan đến mã hoá và mật khẩu](https://docs.aspose.com/slides/vi/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **Câu hỏi thường gặp**

### “Read-Only recommended” khác gì so với bảo vệ bằng mật khẩu đầy đủ?

“Read-Only recommended” chỉ hiển thị đề xuất mở tệp ở chế độ chỉ đọc và dễ bị bỏ qua. [Password protection](/slides/vi/cpp/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần các biện pháp bảo mật thực tế.

### “Read-Only recommended” có thể kết hợp với watermark để ngăn chỉnh sửa hơn không?

Có. Khuyến nghị có thể kết hợp với [watermarks](/slides/vi/cpp/watermark/) như một biện pháp ngăn chặn trực quan; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

### Macro hoặc công cụ bên ngoài vẫn có thể chỉnh sửa tệp khi khuyến nghị này được bật không?

Có. Khuyến nghị không chặn các thay đổi lập trình. Để ngăn chỉnh sửa tự động, hãy sử dụng [passwords and encryption](/slides/vi/cpp/password-protected-presentation/).

### “Read-Only recommended” liên quan như thế nào đến các cờ “is encrypted” và “is write protected”?

Chúng là các tín hiệu khác nhau. “Read-Only recommended” là một lời nhắc mềm, tùy chọn; [get_IsWriteProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) và [get_IsEncrypted](https://reference.aspose.com/slides/vi/cpp/aspose.slides/protectionmanager/get_isencrypted/) cho biết các hạn chế ghi hoặc đọc thực tế dựa trên mật khẩu hoặc mã hoá.