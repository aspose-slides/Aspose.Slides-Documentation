---
title: Chuyển đổi PPT sang PPTX trong Python
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/python-java/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT cổ điển sang PPTX trong Python với Aspose.Slides. Bao gồm các ví dụ Python cho chuyển đổi tệp đơn và hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for Python via Java có thể tải tệp PPT và lưu dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này chỉ ra cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những điều cần kiểm tra sau khi chuyển đổi.

Mỗi ví dụ sẽ khởi động máy ảo Java nếu cần và giải phóng đối tượng presentation sau khi sử dụng. Thay thế các đường dẫn ví dụ bằng đường dẫn tệp hoặc thư mục của bạn.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp Presentation, sau đó gọi Presentation.save với SaveFormat.Pptx. Khối `finally` sẽ giải phóng presentation và giải phóng các tài nguyên của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Tải bài thuyết trình PPT cổ điển.
presentation = Presentation("presentation.ppt")
try:
    # Lưu bài thuyết trình ở định dạng PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Phần mở rộng tệp không tự động xác định định dạng đầu ra; đối số SaveFormat.Pptx mới làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ dưới đây sẽ chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một việc chuyển đổi thất bại sẽ không làm dừng phần còn lại của lô.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định có cho phép ghi đè tệp đầu ra đã tồn tại hay không, và ghi danh sách các tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà không cung cấp mật khẩu đúng, các đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây thất bại trong quá trình chuyển đổi. Xem [Password-Protected Presentations](/slides/vi/python-java/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ trung thực và tính năng cổ điển**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách. Một tính năng cổ điển không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hóa, bỏ qua hoặc hiển thị khác nhau.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt hình, chuyển cảnh, đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến, hoặc macro VBA. Tệp PPTX thông thường không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần được giữ lại. Ngoài ra, kiểm tra rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường mà bản trình bày đã chuyển sẽ được mở hoặc hiển thị.

Đối với các tài liệu quan trọng, hãy mở lại tệp PPTX đã tạo bằng chương trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu của nó trong trình xem mục tiêu. Đừng coi một lời gọi Presentation.save thành công là bằng chứng cho rằng mọi tính năng cổ điển đều có đại diện chính xác trong PPTX.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình bày sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, được trao đổi với các hệ thống làm việc với gói Open XML, hoặc được lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân cổ điển. Giữ bản PPT gốc làm bản lưu trữ hoặc sao lưu cho đến khi bản trình bày đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS, hoặc loại đầu ra khác, hãy sử dụng hướng dẫn cụ thể cho định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/python-java/convert-presentation/) thay vì cho rằng tất cả các mục tiêu đều giữ nguyên các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với các tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt, hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API Python via Java.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/python-java/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/vi/python-java/save-presentation/)
- [Supported File Formats](/slides/vi/python-java/supported-file-formats/)
- [Open Presentations in Python](/slides/vi/python-java/open-presentation/)

## **FAQ**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for Python via Java tải và lưu các tệp trình chiếu mà không cần Microsoft PowerPoint.

**Việc chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ lại nội dung trình chiếu phổ biến, nhưng độ trung thực tuyệt đối không được đảm bảo đối với mọi tính năng cổ điển hoặc không được hỗ trợ. Hãy xem lại tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt hình chuyên biệt, hoặc phông chữ không phổ biến.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu mật khẩu hoặc mật khẩu sai sẽ khiến quá trình tải thất bại.

**Tôi có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ lại tệp gốc cho đến khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp bản sao dự phòng nếu một tính năng cổ điển chuyển đổi khác nhau.