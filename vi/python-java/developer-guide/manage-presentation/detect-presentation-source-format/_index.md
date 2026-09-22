---
title: Xác định Định dạng Bản trình chiếu Gốc trong Python qua Java
linktitle: Định dạng nguồn
type: docs
weight: 35
url: /vi/python-java/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản trình chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Đọc định dạng gốc của bản trình chiếu đã tải trong Python qua Java với Aspose.Slides cho Python qua Java, so sánh các API phát hiện và xử lý tệp, luồng và các định dạng kế thừa."
---
## **Tổng quan**

Sau khi tải một bản trình chiếu, gọi phương thức [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSourceFormat) để xác định định dạng gốc của nó. Sử dụng nó khi quá trình xử lý tiếp theo phụ thuộc vào định dạng mà đối tượng hiện tại được tải.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) được chọn cho tệp đầu ra. Lưu sang định dạng khác không làm thay đổi định dạng nguồn của đối tượng hiện có.

Các ví dụ yêu cầu Aspose.Slides cho Python thông qua Java và một môi trường chạy Java tương thích. Mỗi ví dụ sẽ khởi động JVM nếu nó chưa chạy.

## **Đọc Định dạng Nguồn của Tệp**

Ví dụ này yêu cầu một tệp `sample.pptx` tồn tại. Nó tải tệp và chọn chính sách xử lý ứng dụng bằng cách sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSourceFormat), thay vì tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ in ra chính sách đã chọn; hãy thay thế các thông báo bằng logic ứng dụng của bạn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Nhận dạng các Giá trị Hỗ trợ**

Lớp [SourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sourceformat/) định nghĩa các hằng số nguyên để phân biệt các định dạng bản trình chiếu sau. Các phần mở rộng dưới đây là phần mở rộng thông thường, không phải là sự tái tạo của tên tệp gốc.

| Giá trị SourceFormat | Phần mở rộng | Định dạng |
| --- | --- | --- |
| `Ppt` | `.ppt` | Bản trình chiếu PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Bản trình chiếu Office Open XML |
| `Pptm` | `.pptm` | Bản trình chiếu Office Open XML có macro |
| `Pps` | `.pps` | Trình chiếu PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Trình chiếu Office Open XML |
| `Ppsm` | `.ppsm` | Trình chiếu Office Open XML có macro |
| `Pot` | `.pot` | Mẫu PowerPoint 97–2003 |
| `Potx` | `.potx` | Mẫu Office Open XML |
| `Potm` | `.potm` | Mẫu Office Open XML có macro |
| `Odp` | `.odp` | Bản trình chiếu OpenDocument |
| `Otp` | `.otp` | Mẫu bản trình chiếu OpenDocument |
| `Fodp` | `.fodp` | Bản trình chiếu Flat XML ODF |
| `Xml` | `.xml` | Bản trình chiếu PowerPoint XML |

## **Đọc Định dạng Nguồn của Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` tồn tại. Đọc các byte của nó vào một luồng nhớ mô phỏng đầu vào nhận được mà không có tên tệp, chẳng hạn như giá trị trong cơ sở dữ liệu hoặc mảng byte đã tải lên. Hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chỉ nhận luồng. Python đọc các byte của tệp, và JPype chuyển chúng thành mảng byte Java cho luồng nhớ Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS và POT sử dụng cùng một định dạng nhị phân nền tảng. Khi tải theo đường dẫn tệp, phần mở rộng có thể giúp phân biệt trình chiếu hoặc mẫu. Khi không có tên tệp, nội dung PPS và POT cũ có thể được báo cáo là `SourceFormat.Ppt`; ví dụ PPS ở trên in ra giá trị nguyên của `SourceFormat.Ppt`.

Nếu ứng dụng của bạn cần giữ sự phân biệt này, hãy lưu lại tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là một gợi ý hữu ích cho các phụ loại cũ này, nhưng không nên là cơ sở duy nhất để nhận dạng nội dung bản trình chiếu bất kỳ.

## **So sánh Phát hiện Trước và Sau khi Tải**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) và [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#getLoadFormat) khi bạn cần kiểm tra tệp trước khi tải toàn bộ mô hình đối tượng bản trình chiếu. Sử dụng [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSourceFormat) khi đối tượng đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra các giá trị nguyên của `LoadFormat.Pptx` và `SourceFormat.Pptx`, tương ứng. Trong môi trường thực tế, chọn API phù hợp với giai đoạn xử lý của bạn; một bản trình chiếu đã được tải không cần kiểm tra lần thứ hai chỉ để lấy định dạng nguồn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Kết quả sử dụng các hằng số từ các lớp khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sourceformat/). Không so sánh giá trị số của chúng hoặc giả định rằng mọi định dạng đều có kết quả phát hiện giống nhau. PowerPoint XML có thể được báo là `LoadFormat.Unknown` trước khi tải và `SourceFormat.Xml` sau khi tải.

## **Giữ Định dạng Nguồn và Đầu ra Riêng biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra giá trị nguyên của `SourceFormat.Pptx` cả trước và sau khi lưu đối tượng gốc. Chỉ đối tượng mới được tải từ đầu ra ODP mới báo `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Một bản trình chiếu được tạo mới bằng `Presentation()` báo `SourceFormat.Pptx`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một đối tượng mới tạo, không phải bằng chứng rằng một tệp PPTX đã được tải. Theo dõi xem ứng dụng của bạn tạo hay tải đối tượng để phân biệt nếu điều đó quan trọng.

## **Ánh xạ Định dạng Nguồn sang Phần mở rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mỗi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sourceformat/) hiện đang hỗ trợ sang một phần mở rộng thông thường, mà không phân tích tên tệp đầu vào. Phương pháp dự phòng tránh gán phần mở rộng một cách im lặng cho giá trị không nhận diện được.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Ánh xạ này không chuyển đổi tệp hoặc khôi phục phụ loại PPS/POT cũ bị mất khi tải qua luồng. Để lưu thực tế, hãy chọn một [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) một cách rõ ràng, hoặc sử dụng chuyển đổi được trình bày trong [Save Presentations in Their Original Format](/slides/vi/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Xác minh Định dạng bằng Cách Lưu và Mở Lại**

Ví dụ tự chứa này tạo một bản trình chiếu và ghi ba tệp trong thư mục làm việc, ghi đè các tệp cùng tên. Nó mở lại mỗi đầu ra cả theo đường dẫn và qua luồng nhớ. Đối với PPTX và ODP, cả hai cách đều báo định dạng đã lưu. Đối với PPS, tải theo đường dẫn báo `Pps`, trong khi tải cùng các byte mà không có tên tệp báo `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

Bảng dưới đây tóm tắt việc xác định định dạng nguồn cho các bản trình chiếu có phần mở rộng trùng khớp. Tên biểu thị các hằng số; các ví dụ Python in ra giá trị nguyên của chúng:

| Định dạng đã lưu | SourceFormat từ đường dẫn tệp | SourceFormat từ luồng không tên |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` tương ứng | Giống như đường dẫn tệp |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` tương ứng | Giống như đường dẫn tệp |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` tương ứng | Giống như đường dẫn tệp |
| ODP, OTP | `Odp`, `Otp` tương ứng | Giống như đường dẫn tệp |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Nội dung PPS/POT được xác định là `Ppt` cho các luồng không tên. Bảng mô tả việc nhận dạng định dạng, không phải việc bảo tồn mọi tính năng của bản trình chiếu trong quá trình chuyển đổi.

## **Câu hỏi thường gặp**

**Lưu sang ODP có thay đổi định dạng nguồn của bản trình chiếu được tải từ PPTX không?**

Không. Đối tượng hiện có vẫn báo `Pptx`. Một đối tượng được tải từ tệp ODP đã lưu sẽ báo `Odp`.

**Luồng có luôn phân biệt được bản trình chiếu cũ, trình chiếu và mẫu không?**

Không. PPT, PPS và POT chia sẻ cùng định dạng nhị phân. Giữ lại tên tệp hoặc siêu dữ liệu phụ loại riêng khi cần phân biệt.

**Nên sử dụng API nào nếu bản trình chiếu đã được tải?**

Đọc [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSourceFormat). Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) để kiểm tra trước khi tải.