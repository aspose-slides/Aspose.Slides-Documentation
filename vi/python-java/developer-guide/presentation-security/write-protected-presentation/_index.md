---
title: Bảo vệ ghi bản trình chiếu trong Python
linktitle: Bảo vệ ghi
type: docs
weight: 25
url: /vi/python-java/write-protected-presentation/
keywords:
- bảo vệ ghi
- bảo vệ ghi PowerPoint
- mật khẩu để sửa đổi
- hạn chế chỉnh sửa bản trình chiếu
- xóa bỏ bảo vệ ghi
- xác thực mật khẩu sửa đổi
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Thiết lập, phát hiện, xác thực và xóa bỏ mật khẩu bảo vệ ghi trong các bản trình chiếu PowerPoint PPT và PPTX bằng Aspose.Slides cho Python qua Java."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi hạn chế việc sửa đổi một bản trình chiếu nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem bản trình chiếu được bảo vệ ghi mà không cần mật khẩu. Tùy thuộc vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu lại dưới tên khác, vì vậy bảo vệ ghi không nên được coi là cơ chế bảo mật.

Mật khẩu mở khóa có mục đích khác: nó mã hoá bản trình chiếu và bắt buộc phải có để tải nội dung của nó. Để mã hoá một bản trình chiếu hoặc xác thực mật khẩu mở khóa, xem [Password-Protect Presentations](/slides/vi/python-java/password-protected-presentation/).

Các quy trình trong bài viết này áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng file PPTX; khi lưu thành PPT, dùng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Đặt bảo vệ ghi trên bản trình chiếu**

Sử dụng [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#setWriteProtection) để gán mật khẩu cho việc sửa đổi một bản trình chiếu. Khi lưu bản trình chiếu, thiết lập bảo vệ sẽ được lưu lại.

Ví dụ sau đặt bảo vệ ghi trên một bản trình chiếu PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tải bản trình chiếu được bảo vệ ghi**

Vì bảo vệ ghi không mã hoá nội dung bản trình chiếu, không cần mật khẩu để tải bản trình chiếu. Mật khẩu chỉ có liên quan khi xác thực quyền sửa đổi bản trình chiếu được bảo vệ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Không truyền mật khẩu bảo vệ ghi cho [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setPassword). Phương thức đó chỉ nhận mật khẩu mở khóa cho nội dung được mã hoá. Nếu một bản trình chiếu có cả hai loại bảo vệ, cung cấp mật khẩu mở khóa để tải và xử lý mật khẩu bảo vệ ghi riêng biệt.

## **Xóa bỏ bảo vệ ghi khỏi bản trình chiếu**

Sử dụng [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#removeWriteProtection) để loại bỏ hạn chế sửa đổi, sau đó lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm tra xem bản trình chiếu có được bảo vệ ghi không**

Để kiểm tra một tệp mà không tạo một thể hiện [Presentation](/slides/vi/python-java/presentation/) đầy đủ, gọi [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) và kiểm tra [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#isWriteProtected). Phương thức sử dụng [NullableBool](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/) và trả về `NullableBool.True_` khi phát hiện bảo vệ ghi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Phiên bản nhận luồng của [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) cung cấp cùng thông tin cho một bản trình chiếu được cung cấp dưới dạng luồng.

## **Xác thực mật khẩu bảo vệ ghi**

Sử dụng [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#checkWriteProtection) để xác thực mật khẩu sửa đổi mà không tải toàn bộ bản trình chiếu. Trước tiên hãy kiểm tra [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#isWriteProtected) để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#checkWriteProtection) chỉ xác thực mật khẩu bảo vệ ghi. Nó không xác thực mật khẩu mở khóa hoặc xác định liệu nội dung đã mã hoá có thể được tải hay không. Ngược lại, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#checkPassword) chỉ xác thực mật khẩu mở khóa. Nếu một bản trình chiếu đầy đủ đã được tải, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#checkWriteProtection) cung cấp kiểm tra bảo vệ ghi tương đương thông qua trình quản lý bảo vệ.

Trong các ứng dụng sản xuất, không ghi nhật ký mật khẩu hoặc bao gồm chúng trong thông báo chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết và chỉ giữ mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="Xem thêm" %}}
- [Password-Protect Presentations](/slides/vi/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/vi/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Bảo vệ ghi có mã hoá bản trình chiếu không?**

Không. Nó chỉ hạn chế việc sửa đổi nhưng để nội dung bản trình chiếu vẫn có thể tải và xem.

**Mật khẩu bảo vệ ghi có bắt buộc để mở một bản trình chiếu không?**

Không. Chỉ mật khẩu mở khóa mới bắt buộc để tải nội dung bản trình chiếu được mã hoá.

**Một bản trình chiếu có thể có cả mật khẩu mở khóa và mật khẩu bảo vệ ghi không?**

Có. Cung cấp mật khẩu mở khóa qua tùy chọn tải để mở bản trình chiếu đã mã hoá, và xác thực mật khẩu bảo vệ ghi riêng biệt khi cần quyền sửa đổi.