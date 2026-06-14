---
title: Lưu bản trình chiếu ở chế độ chỉ đọc bằng C++
linktitle: Bản trình chiếu chỉ đọc
type: docs
weight: 30
url: /vi/cpp/read-only-presentation/
keywords:
- chỉ đọc
- bảo vệ bản trình chiếu
- ngăn chặn chỉnh sửa
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tải và lưu các tệp PowerPoint (PPT, PPTX) ở chế độ chỉ đọc với Aspose.Slides cho C++, cung cấp bản xem trước slide chính xác mà không làm thay đổi bản trình chiếu của bạn."
---
## **Giới thiệu**

Trong PowerPoint 2019, Microsoft đã giới thiệu tùy chọn **Always Open Read-Only** như một trong các cách người dùng có thể dùng để bảo vệ bản trình chiếu của mình. Bạn có thể muốn sử dụng cài đặt Đọc‑chỉ này để bảo vệ một bản trình chiếu khi

- Bạn muốn ngăn ngừa các chỉnh sửa vô tình và giữ nguyên nội dung bản trình chiếu của mình. 
- Bạn muốn thông báo cho mọi người rằng bản trình chiếu bạn cung cấp là phiên bản cuối cùng. 

Sau khi bạn chọn tùy chọn **Always Open Read-Only** cho một bản trình chiếu, khi người dùng mở bản trình chiếu, họ sẽ thấy khuyến nghị **Read-Only** và có thể gặp thông báo dạng: *To prevent accidental changes, the author has set this file to open as read-only.*

Khuyến nghị Read-Only là một biện pháp đơn giản nhưng hiệu quả để ngăn chặn việc chỉnh sửa vì người dùng phải thực hiện một thao tác để bỏ nó trước khi được phép chỉnh sửa bản trình chiếu. Nếu bạn không muốn người dùng thay đổi bản trình chiếu và muốn thông báo điều này một cách lịch sự, thì khuyến nghị Read-Only có thể là một lựa chọn tốt cho bạn. 

> Nếu một bản trình chiếu có bảo vệ **Read-Only** được mở trong phiên bản Microsoft PowerPoint cũ hơn—không hỗ trợ chức năng mới giới thiệu—khuyến nghị **Read-Only** sẽ bị bỏ qua (bản trình chiếu được mở bình thường).

## **Áp dụng chế độ Đọc‑chỉ**

Aspose.Slides for C++ cho phép bạn đặt một bản trình chiếu ở trạng thái **Read-Only**, có nghĩa là người dùng (sau khi mở bản trình chiếu) sẽ thấy khuyến nghị **Read-Only**. Đoạn mã mẫu dưới đây cho thấy cách thiết lập bản trình chiếu ở chế độ **Read-Only** trong C++ bằng Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 
**Lưu ý**: Khuyến nghị **Read-Only** chỉ nhằm ngăn chặn việc chỉnh sửa hoặc tránh người dùng thực hiện các thay đổi vô tình đối với bản trình chiếu PowerPoint. Nếu một người có động lực—biết cách thực hiện—quyết định chỉnh sửa bản trình chiếu của bạn, họ có thể dễ dàng loại bỏ cài đặt Read-Only. Nếu bạn thực sự cần ngăn chặn việc chỉnh sửa trái phép, bạn nên sử dụng [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/vi/cpp/password-protected-presentation/). 
{{% /alert %}} 

## **FAQ**

**'Read-Only recommended' khác gì so với bảo vệ bằng mật khẩu đầy đủ?**

'Read-Only recommended' chỉ hiển thị đề xuất mở file ở chế độ chỉ đọc và dễ bị bỏ qua. [Password protection](/slides/vi/cpp/password-protected-presentation/) thực sự hạn chế việc mở hoặc chỉnh sửa và phù hợp khi bạn cần kiểm soát bảo mật thực sự.

**'Read-Only recommended' có thể kết hợp với watermark để giảm thiểu việc chỉnh sửa không?**

Có. Khuyến nghị có thể được ghép với [watermarks](/slides/vi/cpp/watermark/) như một biện pháp ngăn cản bằng hình ảnh; chúng là các cơ chế riêng biệt và hoạt động tốt cùng nhau.

**Macro hoặc công cụ bên ngoài vẫn có thể thay đổi file khi khuyến nghị được bật?**

Có. Khuyến nghị không chặn các thay đổi theo chương trình. Để ngăn chỉnh sửa tự động, hãy sử dụng [passwords and encryption](/slides/vi/cpp/password-protected-presentation/).

**'Read-Only recommended' liên quan thế nào tới các cờ 'is encrypted' và 'is write protected'?**

Chúng là các tín hiệu khác nhau. 'Read-Only recommended' là lời nhắc mềm, tùy chọn; [get_IsWriteProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) và [get_IsEncrypted](https://reference.aspose.com/slides/vi/cpp/aspose.slides/protectionmanager/get_isencrypted/) cho biết các hạn chế ghi hoặc đọc thực tế phụ thuộc vào mật khẩu hoặc mã hoá.