---
title: Bảo vệ mật khẩu cho bản trình chiếu trong Python
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/python-net/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ bằng mật khẩu
- mật khẩu mở đầu
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- Python
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong Python với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở đầu mã hoá một bản trình chiếu. Mật khẩu đúng là bắt buộc để tải và xem nội dung bản trình chiếu, vì vậy bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở đầu khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/python-net/write-protected-presentation/).

Các quy trình làm việc dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá bản trình chiếu bằng mật khẩu mở đầu**

Sử dụng [ProtectionManager.encrypt](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/encrypt/) để gán mật khẩu mở đầu. Sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản trình chiếu PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Tải một bản trình chiếu đã được mã hoá**

Đặt [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/) thành mật khẩu mở đầu và truyền các tùy chọn này vào [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại nếu mật khẩu mở đầu được yêu cầu nhưng mật khẩu cung cấp bị thiếu hoặc không đúng.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Làm việc với bản trình chiếu đã giải mã.
    pass
```

## **Gỡ bỏ mã hoá khỏi bản trình chiếu**

Tải bản trình chiếu với mật khẩu mở đầu của nó, gọi [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/remove_encryption/), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Xác thực mật khẩu mở đầu trước khi tải**

Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) để lấy [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/) mà không tạo một thể hiện bản trình chiếu đầy đủ. Kiểm tra [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/is_password_protected/) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [PresentationInfo.check_password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/check_password/).

### **Quy trình làm việc Đường dẫn Tệp**

Ví dụ sau xác thực mật khẩu mở đầu cho một tệp PPTX, truyền giá trị đã xác thực vào [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/), và sau đó tải bản trình chiếu đầy đủ:

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

### **Quy trình làm việc Luồng dữ liệu**

Phiên bản quá tải luồng của [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) cung cấp cùng một quy trình làm việc. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải bản trình chiếu đầy đủ từ luồng đó.

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

[PresentationInfo.check_password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/check_password/) trả về `True` chỉ khi bản trình chiếu có mật khẩu mở đầu và mật khẩu được cung cấp là đúng. Nó trả về `False` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở đầu.
- Mật khẩu được cung cấp là `None` hoặc rỗng.

Hành vi này giống nhau cho bản trình chiếu PPT và PPTX.

## **Kiểm tra xem một bản trình chiếu đã tải có được mã hoá không**

Sau khi tải một bản trình chiếu với mật khẩu đúng, kiểm tra [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/vi/python-net/aspose.slides/protectionmanager/is_encrypted/) để xác nhận rằng bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ mật khẩu mở đầu trước khi tải, sử dụng `PresentationInfo.is_password_protected` như đã mô tả ở trên.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Khuyến nghị Bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở đầu hoặc bao gồm chúng trong các thông báo chuẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải bản trình chiếu ngay lập tức.
{{% /alert %}}

## **Bảo vệ bản trình chiếu bằng mật khẩu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
1. Chọn hoặc tải lên bản trình chiếu.
1. Nhập mật khẩu để bảo vệ chế độ xem.
1. Tùy chọn nhập mật khẩu riêng để bảo vệ chỉnh sửa.
1. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="See also" %}}
- [Bảo vệ ghi bản trình chiếu](/slides/vi/python-net/write-protected-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Sự khác nhau giữa mật khẩu mở đầu và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở đầu mã hoá bản trình chiếu và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở đầu mà không tải toàn bộ các slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ mật khẩu mở đầu hay không, và xác thực mật khẩu trước khi tạo một thể hiện bản trình chiếu đầy đủ.

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng đều hoạt động tương tự cho các bản trình chiếu PPT và PPTX.