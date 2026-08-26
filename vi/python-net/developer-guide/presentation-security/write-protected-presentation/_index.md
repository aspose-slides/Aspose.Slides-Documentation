---
title: Bảo vệ ghi cho bản trình chiếu trong Python
linktitle: Bảo vệ ghi
type: docs
weight: 25
url: /vi/python-net/write-protected-presentation/
keywords:
- bảo vệ ghi
- PowerPoint bảo vệ ghi
- mật khẩu để chỉnh sửa
- hạn chế chỉnh sửa bản trình chiếu
- xóa bảo vệ ghi
- xác thực mật khẩu chỉnh sửa
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Thiết lập, phát hiện, xác thực và xóa mật khẩu bảo vệ ghi trong các bản trình chiếu PowerPoint PPT và PPTX bằng Aspose.Slides cho Python."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi không cho phép chỉnh sửa bản trình chiếu nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem bản trình chiếu được bảo vệ ghi mà không cần mật khẩu. Tùy thuộc vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu lại dưới tên khác, vì vậy bảo vệ ghi không nên được coi là cơ chế bảo mật.

Mật khẩu mở có mục đích khác: nó mã hoá bản trình chiếu và bắt buộc phải có để tải nội dung của nó. Để mã hoá một bản trình chiếu hoặc xác thực mật khẩu mở, xem [Password-Protect Presentations](/slides/vi/python-net/password-protected-presentation/).

Các luồng công việc trong bài viết này áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng tệp PPTX; khi lưu thành PPT, sử dụng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Thiết lập bảo vệ ghi cho bản trình chiếu**

Sử dụng [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/set_write_protection/) để gán mật khẩu cho việc chỉnh sửa bản trình chiếu. Lưu bản trình chiếu sẽ giữ lại cài đặt bảo vệ.

Ví dụ sau đặt bảo vệ ghi cho một bản trình chiếu PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Tải bản trình chiếu có bảo vệ ghi**

Vì bảo vệ ghi không mã hoá nội dung bản trình chiếu, không cần mật khẩu để tải bản trình chiếu. Mật khẩu chỉ có liên quan khi xác thực quyền chỉnh sửa bản trình chiếu được bảo vệ.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Không truyền mật khẩu bảo vệ ghi tới [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/). Thuộc tính này chỉ chấp nhận mật khẩu mở cho nội dung đã mã hoá. Nếu một bản trình chiếu có cả hai loại bảo vệ, cung cấp mật khẩu mở để tải nó và xử lý mật khẩu bảo vệ ghi riêng biệt.

## **Xóa bảo vệ ghi khỏi bản trình chiếu**

Sử dụng [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/remove_write_protection/) để bỏ giới hạn chỉnh sửa, sau đó lưu bản trình chiếu.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm tra xem bản trình chiếu có được bảo vệ ghi không**

Để kiểm tra một tệp mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) hoàn chỉnh, gọi [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) và kiểm tra [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/is_write_protected/). Thuộc tính này sử dụng [NullableBool](https://reference.aspose.com/slides/vi/python-net/aspose.slides/nullablebool/) và trả về `NullableBool.TRUE` khi phát hiện bảo vệ ghi.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Phiên bản overload theo luồng của [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) cung cấp cùng thông tin cho một bản trình chiếu được cung cấp dưới dạng luồng.

## **Xác thực mật khẩu bảo vệ ghi**

Sử dụng [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/check_write_protection/) để xác thực mật khẩu chỉnh sửa mà không tải bản trình chiếu đầy đủ. Đầu tiên kiểm tra [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/is_write_protected/) để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/check_write_protection/) chỉ xác thực mật khẩu bảo vệ ghi. Nó không xác thực mật khẩu mở hoặc xác định liệu nội dung đã mã hoá có thể được tải hay không. Ngược lại, [PresentationInfo.check_password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/check_password/) chỉ xác thực mật khẩu mở. Nếu một bản trình chiếu đầy đủ đã được tải, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/check_write_protection/) cung cấp kiểm tra bảo vệ ghi tương đương thông qua trình quản lý bảo vệ của nó.

Trong các ứng dụng thực tế, không ghi lại mật khẩu hoặc đưa chúng vào các tin nhắn chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết và chỉ lưu mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="Xem thêm" %}}
- [Password-Protect Presentations](/slides/vi/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/vi/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Bảo vệ ghi có mã hoá bản trình chiếu không?**

Không. Nó chỉ hạn chế việc chỉnh sửa nhưng vẫn cho phép tải và xem nội dung bản trình chiếu.

**Mật khẩu bảo vệ ghi có bắt buộc để mở bản trình chiếu không?**

Không. Chỉ cần một mật khẩu mở để tải nội dung bản trình chiếu đã mã hoá.

**Một bản trình chiếu có thể có cả mật khẩu mở và mật khẩu bảo vệ ghi không?**

Có. Cung cấp mật khẩu mở thông qua tùy chọn tải để mở bản trình chiếu đã mã hoá, và xác thực mật khẩu bảo vệ ghi riêng biệt khi cần quyền chỉnh sửa.