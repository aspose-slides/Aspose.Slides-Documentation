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
- lưu PPT thành PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT legacy sang PPTX trong Python với Aspose.Slides. Bao gồm các ví dụ Python cho chuyển đổi đơn tệp và hàng loạt, xử lý lỗi, và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for Python qua Java có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này mô tả cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

Mỗi ví dụ sẽ khởi động máy ảo Java nếu cần và giải phóng bản trình chiếu sau khi sử dụng. Thay thế các đường dẫn ví dụ bằng đường dẫn tệp hoặc thư mục của bạn.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Pptx). Khối `finally` sẽ giải phóng bản trình chiếu và giải phóng tài nguyên của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Tải bản trình chiếu PPT cũ.
presentation = Presentation("presentation.ppt")
try:
    # Lưu bản trình chiếu ở định dạng PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Pptx) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau sẽ chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi sẽ không dừng toàn bộ lô.

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

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định liệu có cho phép ghi đè tệp đầu ra hiện có hay không, và ghi tên các tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà không cung cấp mật khẩu đúng, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/slides/vi/python-java/password-protected-presentation/) để tải các tệp đã mã hóa.

## **Độ trung thực và tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, bố cục, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách. Một tính năng kế thừa không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển đổi, các đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến hoặc macro VBA. Tệp PPTX thông thường không hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần được giữ lại. Cũng hãy xác minh rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường mà bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, hãy mở lại tệp PPTX đã tạo bằng chương trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự định. Đừng coi một lời gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) thành công là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân cũ. Giữ tệp PPT gốc làm bản lưu trữ hoặc sao lưu cho đến khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc loại đầu ra khác, hãy sử dụng hướng dẫn cụ thể cho định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/python-java/convert-presentation/) thay vì cho rằng mọi mục tiêu đều giữ nguyên các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với tệp cá nhân hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt, hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API Python qua Java.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/python-java/ppt-vs-pptx/)
- [Lưu bản trình chiếu trong Python](/slides/vi/python-java/save-presentation/)
- [Định dạng tệp được hỗ trợ](/slides/vi/python-java/supported-file-formats/)
- [Mở bản trình chiếu trong Python](/slides/vi/python-java/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for Python qua Java tải và lưu các tệp bản trình chiếu mà không cần Microsoft PowerPoint.

**Việc chuyển đổi PPT sang PPTX có giữ nguyên mọi nội dung một cách chính xác không?**

Nó giữ lại nội dung trình chiếu thông thường, nhưng độ trung thực tuyệt đối không được đảm bảo cho mọi tính năng cũ hoặc không được hỗ trợ. Hãy xem lại tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên biệt, hoặc phông chữ không phổ biến.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp đúng mật khẩu khi tải tệp. Thiếu hoặc sai mật khẩu sẽ khiến thao tác tải thất bại.

**Có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ tệp gốc cho đến khi bạn đã kiểm tra PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp bản sao dự phòng nếu tính năng cũ được chuyển đổi khác nhau.