---
title: Cấp phép
type: docs
weight: 80
url: /vi/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- tệp giấy phép
- giấy phép tạm thời
- giấy phép tính theo mức
- hạn chế khi đánh giá
description: "Áp dụng giấy phép từ tệp, dựa trên byte hoặc tính theo mức trong Aspose.Slides cho Python qua Java và loại bỏ các hạn chế khi đánh giá khỏi ứng dụng của bạn."
---
## **Tổng quan**

Aspose.Slides for Python via Java có thể chạy ở chế độ đánh giá hoặc có giấy phép. Bài viết này giải thích cách áp dụng giấy phép từ tệp hoặc từ byte và cách cấu hình giấy phép tính theo mức.

Đối với các tùy chọn mua, xem [Thông tin giá](https://purchase.aspose.com/pricing/slides/vi/family). Đối với các câu hỏi chung về giấy phép và mua hàng, xem [Chính sách mua hàng và FAQ](https://purchase.aspose.com/policies).

Đối với các hạn chế khi đánh giá và cách yêu cầu giấy phép tạm thời, xem [Đánh giá Aspose.Slides](/slides/vi/python-java/evaluate-aspose-slides/). Áp dụng giấy phép tạm thời theo cùng cách như một tệp giấy phép đã mua.

## **Về giấy phép**

Một tệp giấy phép chứa thông tin như tên sản phẩm, số lượng nhà phát triển được cấp phép và ngày hết hạn đăng ký. Tệp này là XML được ký số.

{{% alert color="warning" title="Warning" %}}
Không chỉnh sửa tệp giấy phép. Ngay cả một ký tự xuống dòng thừa cũng có thể làm mất hiệu lực chữ ký số của nó.
{{% /alert %}}

Áp dụng giấy phép một lần cho mỗi ứng dụng hoặc quy trình, trước khi tạo bản trình bày hoặc thực hiện các thao tác Aspose.Slides khác. Đối với tệp giấy phép, sử dụng lớp [License](https://reference.aspose.com/slides/vi/python-java/aspose.slides/license/). Giấy phép tính theo mức sử dụng cặp khóa công khai và riêng tư thay cho tệp giấy phép.

## **Áp dụng giấy phép**

Các ví dụ sau giả định rằng Aspose.Slides for Python via Java và các yêu cầu tiền đề đã được cài đặt. Mỗi ví dụ là một script độc lập khởi động JVM, nhập API và áp dụng giấy phép. Trong ứng dụng của bạn, thực hiện các thao tác trình chiếu sau khi đã áp dụng giấy phép và tắt JVM chỉ sau khi tất cả công việc Aspose.Slides hoàn tất.

### **Áp dụng giấy phép từ tệp**

Gửi đường dẫn tệp giấy phép tới [License.setLicense](https://reference.aspose.com/slides/vi/python-java/aspose.slides/license/#setLicense). Thay `Aspose.Slides.lic` bằng đường dẫn tới tệp giấy phép của bạn.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Thực hiện các thao tác trình chiếu ở đây, trước khi tắt JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Sử dụng đúng tên tệp, bao gồm cả phần mở rộng. Ví dụ, nếu tệp có tên `Aspose.Slides.lic.xml`, bao gồm `.xml` trong đường dẫn. Đường dẫn tuyệt đối tránh sự không chắc chắn về thư mục làm việc của ứng dụng.

Ví dụ sử dụng [License.isLicensed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/license/#isLicensed) để kiểm tra xem giấy phép đã được áp dụng chưa.

### **Áp dụng giấy phép từ byte**

Sử dụng [License.setLicenseFromBytes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/license/#setLicenseFromBytes) khi giấy phép có sẵn dưới dạng byte Python. Ví dụ sau đọc tệp ở chế độ nhị phân và đóng nó trước khi áp dụng giấy phép.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Thực hiện các thao tác trình chiếu ở đây, trước khi tắt JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Giữ nguyên byte gốc không thay đổi. Không giải mã, định dạng lại hoặc thay đổi nội dung giấy phép trước khi áp dụng.

## **Áp dụng giấy phép Metered**

Giấy phép Metered tính phí dựa trên việc sử dụng API. Sau khi có giấy phép Metered, áp dụng khóa công khai và khóa riêng tư bằng [Metered.setMeteredKey](https://reference.aspose.com/slides/vi/python-java/aspose.slides/metered/#setMeteredKey). Khởi tạo đối tượng [Metered](https://reference.aspose.com/slides/vi/python-java/aspose.slides/metered/) và áp dụng các khóa một lần khi khởi động ứng dụng.

Ví dụ dưới đây đọc các khóa từ các biến môi trường `ASPOSE_METERED_PUBLIC_KEY` và `ASPOSE_METERED_PRIVATE_KEY`. Đặt cả hai biến trước khi chạy script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Thực hiện các thao tác trình chiếu ở đây, trước khi tắt JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Giấy phép Metered yêu cầu kết nối Internet để xác thực các khóa và báo cáo việc sử dụng. Giữ khóa riêng tư ra khỏi mã nguồn và nhật ký. Xem [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) để biết chi tiết kết nối và thanh toán.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt gói khác sau khi mua giấy phép không?**

Không. Áp dụng giấy phép cho cùng một gói mà bạn đã dùng để đánh giá.

**Tôi có phải áp dụng giấy phép cho mỗi bản trình bày không?**

Không. Áp dụng một lần khi khởi động ứng dụng, trước khi tạo hoặc tải bản trình bày.

**Tôi có thể đổi tên tệp giấy phép không?**

Có. Sử dụng đúng tên tệp mới trong mã và giữ nguyên nội dung tệp.

**Tôi có thể sử dụng giấy phép tạm thời với ví dụ dựa trên byte không?**

Có. Đọc tệp giấy phép tạm thời dưới dạng byte và áp dụng nó theo cùng cách như giấy phép đã mua.