---
title: Bảo mật Bài thuyết trình bằng Mật khẩu trong Python
linktitle: Bảo mật Mật khẩu
type: docs
weight: 20
url: /vi/python-java/password-protected-presentation/
keywords:
- bài thuyết trình được bảo mật bằng mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bài thuyết trình
- kiểm tra mật khẩu bài thuyết trình
- mở bài thuyết trình đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bài thuyết trình
- Python
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bài thuyết trình PowerPoint PPT và PPTX được bảo mật bằng mật khẩu bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bài thuyết trình. Mật khẩu đúng cần thiết để tải và xem nội dung bài thuyết trình, do đó bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc chỉnh sửa nhưng không mã hoá nội dung hoặc ngăn không cho bài thuyết trình được tải. Để quản lý mật khẩu cho việc chỉnh sửa bài thuyết trình, xem [Write-Protect Presentations](/slides/vi/python-java/write-protected-presentation/).

Các quy trình làm việc dưới đây áp dụng cho cả bài thuyết trình PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá một bài thuyết trình bằng mật khẩu mở khóa**

Sử dụng [ProtectionManager.encrypt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#encrypt) để chỉ định mật khẩu mở khóa. Sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để lưu lại bài thuyết trình đã được mã hoá.

Ví dụ sau mã hoá một bài thuyết trình PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Giữ Thuộc tính Tài liệu Công khai**

Mặc định, Aspose.Slides bao gồm các thuộc tính tài liệu trong quá trình mã hoá bài thuyết trình. Phương thức [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) kiểm soát hành vi này một cách độc lập với việc mã hoá nội dung slide. Truyền `False` trước khi gọi [ProtectionManager.encrypt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#encrypt) khi một hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu cần đọc siêu dữ liệu mà không có mật khẩu mở khóa.

Ví dụ sau tạo một bài thuyết trình PPTX đã được mã hoá trong khi để lại các thuộc tính tài liệu tích hợp công khai:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Việc truyền `False` vào [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) không làm cho các slide, master, layout, shape, media hoặc nội dung bài thuyết trình khác trở nên công khai. Nó chỉ ảnh hưởng đến các thuộc tính tài liệu. Để đọc các thuộc tính đó mà không tải nội dung đã mã hoá, xem [Manage Presentation Properties](/slides/vi/python-java/presentation-properties/).

## **Tải một bài thuyết trình đã mã hoá**

Đặt [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setPassword) thành mật khẩu mở khóa và truyền các tùy chọn này vào [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi cần mật khẩu mở khóa nhưng mật khẩu được cung cấp thiếu hoặc không đúng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Làm việc với bài thuyết trình đã giải mã.
    pass
finally:
    presentation.dispose()
```

## **Gỡ bỏ mã hoá khỏi một bài thuyết trình**

Tải bài thuyết trình bằng mật khẩu mở khóa, gọi [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#removeEncryption), và lưu kết quả. Bài thuyết trình đã lưu sau đó có thể được tải mà không cần mật khẩu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) để lấy [PresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/) mà không tạo một thể hiện hoàn chỉnh của bài thuyết trình. Kiểm tra [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#isPasswordProtected) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Quy trình Đường dẫn Tệp**

Ví dụ sau xác thực mật khẩu mở khóa cho tệp PPTX, truyền giá trị đã xác thực vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setPassword), và sau đó tải toàn bộ bài thuyết trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Quy trình Luồng**

Phiên bản overload dựa trên luồng của [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) cung cấp cùng một quy trình. Đặt lại vị trí của luồng có thể seek trước khi tải toàn bộ bài thuyết trình từ luồng đó.

Ví dụ sau sử dụng tệp PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Giá trị trả về của checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#checkPassword) trả về `True` chỉ khi bài thuyết trình có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `False` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bài thuyết trình không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `None` hoặc rỗng.

Hành vi này tương tự cho các bài thuyết trình PPT và PPTX.

## **Kiểm tra xem một bài thuyết trình đã tải có bị mã hoá không**

Sau khi tải một bài thuyết trình bằng mật khẩu đúng, kiểm tra [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#isEncrypted) để xác nhận rằng bài thuyết trình nguồn đã được mã hoá. Để phát hiện bảo vệ mật khẩu mở khóa trước khi tải, sử dụng [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#isPasswordProtected) như đã mô tả ở trên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Khuyến nghị Bảo mật**

{{% alert color="warning" title="Bảo mật" %}}
Không ghi lại mật khẩu mở khóa hoặc đưa chúng vào các thông điệp chẩn đoán. Tránh các lần thử xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi ngay lập tức tải bài thuyết trình.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, nhận xét và các giá trị tùy chỉnh mặc dù nội dung bài thuyết trình đã được mã hoá. Mã hoá siêu dữ liệu nhạy cảm cùng với bài thuyết trình. Việc để các thuộc tính công khai nên là quyết định rõ ràng chỉ khi hệ thống phải lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không cần mật khẩu mở khóa.
{{% /alert %}}

## **Bảo vệ bằng mật khẩu một bài thuyết trình trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
1. Chọn hoặc tải lên bài thuyết trình.
1. Nhập mật khẩu để bảo vệ khi xem.
1. Tùy chọn nhập một mật khẩu riêng để bảo vệ khi chỉnh sửa.
1. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="Xem thêm" %}}
- [Bảo vệ ghi bài thuyết trình](/slides/vi/python-java/write-protected-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bài thuyết trình và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc chỉnh sửa mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ slide không?**

Có. Lấy thông tin bài thuyết trình, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện đầy đủ của bài thuyết trình.

**Ứng dụng có thể đọc siêu dữ liệu mà không cần mật khẩu mở khóa không?**

Có, nhưng chỉ khi bài thuyết trình được mã hoá với việc mã hoá thuộc tính tài liệu bị vô hiệu hoá. Ứng dụng sau đó phải sử dụng chế độ tải chỉ thuộc tính tài liệu được mô tả trong [Manage Presentation Properties](/slides/vi/python-java/presentation-properties/).

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động giống nhau cho các bài thuyết trình PPT và PPTX.