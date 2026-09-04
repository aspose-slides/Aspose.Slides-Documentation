---
title: Bảo vệ bản trình chiếu bằng mật khẩu trong Python
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/python-net/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã được mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- Python
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ mật khẩu trong Python với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình chiếu. Mật khẩu đúng cần thiết để tải và xem nội dung bản trình chiếu, do đó biện pháp bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/python-net/write-protected-presentation/).

Các quy trình làm việc dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá một bản trình chiếu bằng mật khẩu mở khóa**

Sử dụng [ProtectionManager.encrypt](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/encrypt/) để chỉ định mật khẩu mở khóa. Sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản trình chiếu PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Giữ thuộc tính tài liệu được công khai**

Mặc định, Aspose.Slides bao gồm các thuộc tính tài liệu trong quá trình mã hoá bản trình chiếu. Thuộc tính [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) kiểm soát hành vi này một cách độc lập so với việc mã hoá nội dung slide. Đặt nó thành `False` trước khi gọi [ProtectionManager.encrypt](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/encrypt/) khi một hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu cần đọc siêu dữ liệu mà không có mật khẩu mở khóa.

Ví dụ sau tạo một bản trình chiếu PPTX đã được mã hoá trong khi vẫn để các thuộc tính tài liệu tích hợp của nó được công khai:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Đặt `encrypt_document_properties` thành `False` không làm cho các slide, master, layout, shape, media hoặc nội dung khác của bản trình chiếu trở nên công khai. Nó chỉ ảnh hưởng đến các thuộc tính tài liệu. Để đọc các thuộc tính đó mà không tải nội dung đã được mã hoá, xem [Manage Presentation Properties](/slides/vi/python-net/presentation-properties/).

## **Tải một bản trình chiếu đã được mã hoá**

Đặt [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/) thành mật khẩu mở khóa và truyền các tùy chọn này vào [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi cần mật khẩu mở khóa nhưng mật khẩu được cung cấp bị thiếu hoặc không đúng.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Làm việc với bản trình chiếu đã giải mã.
    pass
```

## **Gỡ bỏ mã hoá khỏi một bản trình chiếu**

Tải bản trình chiếu bằng mật khẩu mở khóa của nó, gọi [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/remove_encryption/), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) để lấy [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/) mà không cần tạo một thể hiện đầy đủ của bản trình chiếu. Kiểm tra [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/is_password_protected/) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [PresentationInfo.check_password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/check_password/).

### **Quy trình làm việc theo đường dẫn tệp**

Ví dụ sau xác thực mật khẩu mở khóa cho một tệp PPTX, truyền giá trị đã xác thực tới [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/), và sau đó tải bản trình chiếu đầy đủ:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Quy trình làm việc dựa trên luồng**

Phiên bản overload dựa trên luồng của [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) cung cấp cùng một quy trình làm việc. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải bản trình chiếu đầy đủ từ luồng đó.

Ví dụ sau sử dụng một tệp PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Giá trị trả về của CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/check_password/) trả về `True` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `False` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `None` hoặc rỗng.

Hành vi này giống nhau cho các bản trình chiếu PPT và PPTX.

## **Kiểm tra xem một bản trình chiếu đã tải có được mã hoá hay không**

Sau khi tải một bản trình chiếu bằng mật khẩu đúng, kiểm tra [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/is_encrypted/) để xác nhận rằng bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ bằng mật khẩu mở khóa trước khi tải, sử dụng `PresentationInfo.is_password_protected` như đã trình bày ở trên.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Khuyến nghị bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở khóa hoặc bao gồm chúng trong các thông báo chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi ngay lập tức tải bản trình chiếu.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và giá trị tùy chỉnh ngay cả khi nội dung bản trình chiếu đã được mã hoá. Mã hoá siêu dữ liệu nhạy cảm cùng với bản trình chiếu. Việc để các thuộc tính công khai nên là quyết định rõ ràng, chỉ thực hiện khi các hệ thống phải lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không có mật khẩu mở khóa.
{{% /alert %}}

## **Bảo vệ bản trình chiếu bằng mật khẩu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình chiếu.
3. Nhập mật khẩu để bảo vệ chế độ xem.
4. Tùy chọn nhập một mật khẩu riêng cho bảo vệ chỉnh sửa.
5. Áp dụng bảo vệ và tải về tệp kết quả.

{{% alert color="info" title="See also" %}}
- [Bảo vệ ghi bản trình chiếu](/slides/vi/python-net/write-protected-presentation/)
- [Chữ ký kỹ thuật số trong PowerPoint](/slides/vi/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bản trình chiếu và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ các slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện đầy đủ của bản trình chiếu.

**Một ứng dụng có thể đọc siêu dữ liệu mà không có mật khẩu mở khóa không?**

Có, nhưng chỉ khi bản trình chiếu được mã hoá với `encrypt_document_properties` được đặt thành `False`. Ứng dụng sau đó phải sử dụng chế độ tải chỉ thuộc tính tài liệu như mô tả trong [Manage Presentation Properties](/slides/vi/python-net/presentation-properties/).

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động giống nhau cho các bản trình chiếu PPT và PPTX.